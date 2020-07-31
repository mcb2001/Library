using Oc6.Library.Resources;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oc6.Library.Maths.Internals
{
    internal sealed class Tokenizer
    {
        private readonly char numberDecimalSeparator;
        private readonly char numberGroupSeparator;

        public Tokenizer(CultureInfo cultureInfo)
        {
            if (cultureInfo == null)
            {
                throw new ArgumentNullException(nameof(cultureInfo));
            }

            if (cultureInfo.NumberFormat.NumberDecimalSeparator.Length > 1)
            {
                throw new NotImplementedException(ErrorMessages.Tokenizer_Only_SingleCharacterNumberFormats);
            }

            if (cultureInfo.NumberFormat.NumberGroupSeparator.Length > 1)
            {
                throw new NotImplementedException(ErrorMessages.Tokenizer_Only_SingleCharacterNumberFormats);
            }

            numberDecimalSeparator = cultureInfo.NumberFormat.NumberDecimalSeparator[0];
            numberGroupSeparator = cultureInfo.NumberFormat.NumberGroupSeparator[0];
        }

        public IEnumerable<Token> GetTokens(char[] input)
        {
            for (int i = 0; i < input.Length; ++i)
            {
                var c = input[i];

                if (char.IsWhiteSpace(c))
                {
                    throw new ArgumentException($"Invalid character at {i} in [[{input}]]");
                }

                switch (c)
                {
                    case '+':
                        {
                            yield return new Token(TokenType.Add, input, i, 1);
                            break;
                        }
                    case '-':
                        {
                            if (IsBinarySubtrackt(input, i))
                            {
                                yield return new Token(TokenType.Add, input, i, 1);
                            }

                            yield return new Token(TokenType.Negate, input, i, 1);

                            break;
                        }
                    case '*':
                        {
                            yield return new Token(TokenType.Multiply, input, i, 1);
                            break;
                        }
                    case '/':
                        {
                            yield return new Token(TokenType.Divide, input, i, 1);
                            break;
                        }
                    case '^':
                        {
                            yield return new Token(TokenType.Power, input, i, 1);
                            break;
                        }
                    case '(':
                        {
                            yield return new Token(TokenType.ParanthesisOpen, input, i, 1);
                            break;
                        }
                    case ')':
                        {
                            yield return new Token(TokenType.ParanthesisClose, input, i, 1);
                            break;
                        }
                    default:
                        {
                            yield return GetToken(input, ref i);

                            --i;

                            break;
                        }
                }
            }
        }

        private static bool IsBinarySubtrackt(char[] input, int i)
        {
            if (i == 0)
            {
                return false;
            }

            switch (input[i - 1])
            {
                case '+':
                case '-':
                case '*':
                case '/':
                case '^':
                case '(':
                    {
                        return false;
                    }
            }

            return true;
        }

        private Token GetToken(char[] input, ref int i)
        {
            return char.IsLetter(input[i]) ? GetWord(input, ref i) : GetNumber(input, ref i);
        }

        private Token GetNumber(char[] input, ref int i)
        {
            int start = i;
            int length = 0;
            char c = input[i];

            while (char.IsDigit(c) || c == numberDecimalSeparator || c == numberGroupSeparator)
            {
                ++i;
                ++length;

                if (i == input.Length)
                {
                    break;
                }

                c = input[i];
            }

            return new Token(TokenType.Number, input, start, length);
        }

        private static Token GetWord(char[] input, ref int i)
        {
            int start = i;
            int length = 0;
            char c = input[i];

            while (char.IsLetterOrDigit(c))
            {
                ++i;
                ++length;

                if (i == input.Length)
                {
                    break;
                }

                c = input[i];
            }

            return new Token(TokenType.Word, input, start, length);
        }
    }
}
