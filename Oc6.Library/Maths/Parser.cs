using Oc6.Library.Maths.Internals;
using Oc6.Library.Resources;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Oc6.Library.Maths
{
    public sealed class Parser
    {
        private readonly CultureInfo cultureInfo;
        private readonly Tokenizer tokenizer;
        private static readonly MethodInfo PowMethod = typeof(DecimalMath).GetMethod(nameof(DecimalMath.Pow));

        public State State { get; }

        public Parser()
            : this(CultureInfo.InvariantCulture)
        {

        }

        public Parser(CultureInfo cultureInfo)
        {
            this.cultureInfo = cultureInfo;
            tokenizer = new Tokenizer(this.cultureInfo);
            State = new State();
        }

        public decimal Evaluate(string input)
        {
            var parsed = Parse(input);
            var compiled = parsed.Compile();
            return compiled();
        }

        public Expression<Func<decimal>> Parse(string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            var chars = input
                .ToCharArray()
                .Where(c => !char.IsWhiteSpace(c))
                .ToArray();

            Span<Token> tokens = tokenizer
                   .GetTokens(chars)
                   .ToArray();

            var expression = Parse(tokens);

            return Expression.Lambda<Func<decimal>>(expression);
        }

        private Expression Parse(Span<Token> tokens)
        {
            Stack<Expression> operandStack = new Stack<Expression>();

            Stack<TokenType> operatorStack = new Stack<TokenType>();
            operatorStack.Push(TokenType.Nop);

            for (int i = 0; i < tokens.Length; ++i)
            {
                var token = tokens[i];
                var type = token.TokenType;

                ParseToken(operandStack, operatorStack, token, type, tokens, ref i);
            }

            while (operandStack.Count > 1)
            {
                PopAndApply(operandStack, operatorStack);
            }

            return operandStack.Pop();
        }

        private void ParseToken(Stack<Expression> operandStack, Stack<TokenType> operatorStack, Token token, TokenType type, Span<Token> tokens, ref int i)
        {
            switch (type)
            {
                case TokenType.Add:
                case TokenType.Divide:
                case TokenType.Multiply:
                case TokenType.Subtract:
                case TokenType.Power:
                    {
                        Binary(operandStack, operatorStack, type);

                        return;
                    }
                case TokenType.Number:
                    {
                        operandStack.Push(ParseNumber(token));

                        return;
                    }
                case TokenType.ParanthesisClose:
                    {
                        throw new NotImplementedException();
                    }
                case TokenType.ParanthesisOpen:
                    {
                        throw new NotImplementedException();
                    }
                case TokenType.UnaryMinus:
                    {
                        ++i;
                        token = tokens[i];
                        type = token.TokenType;

                        ParseToken(operandStack, operatorStack, token, type, tokens, ref i);

                        var operand = operandStack.Pop();

                        operandStack.Push(Expression.Negate(operand));

                        return;
                    }
                case TokenType.Word:
                    {
                        operandStack.Push(ParseWord(token));

                        return;
                    }
            }

            throw new ParseException(string.Format(CultureInfo.InvariantCulture, ErrorMessages.Parser_InvalidTokenType, type));
        }

        private static void PopAndApply(Stack<Expression> operandStack, Stack<TokenType> operatorStack)
        {
            var right = operandStack.Pop();
            var left = operandStack.Pop();

            var operation = operatorStack.Pop();

            switch (operation)
            {
                case TokenType.Add:
                    {
                        operandStack.Push(Expression.Add(left, right));
                        return;
                    }
                case TokenType.Divide:
                    {
                        operandStack.Push(Expression.Divide(left, right));
                        return;
                    }
                case TokenType.Multiply:
                    {
                        operandStack.Push(Expression.Multiply(left, right));
                        return;
                    }
                case TokenType.Subtract:
                    {
                        operandStack.Push(Expression.Subtract(left, right));
                        return;
                    }
                case TokenType.Power:
                    {
                        operandStack.Push(Expression.Call(PowMethod, left, right));
                        return;
                    }
            }
        }

        private static void Binary(Stack<Expression> operandStack, Stack<TokenType> operatorStack, TokenType type)
        {
            if (type.HasHigherPrecedenceThan(operatorStack.Peek()))
            {
                operatorStack.Push(type);
            }
            else
            {
                PopAndApply(operandStack, operatorStack);
            }
        }

        private Expression ParseNumber(Token token)
        {
            var span = token.ToSpan();

            if (decimal.TryParse(span, NumberStyles.Float | NumberStyles.AllowThousands, cultureInfo, out decimal result))
            {
                return Expression.Constant(result, typeof(decimal));
            }
            else
            {
                string str = new string(span);

                string message = string.Format(CultureInfo.InvariantCulture, ErrorMessages.Parser_InvalidNumber, str);

                throw new ParseException(message);
            }
        }

        private Expression ParseWord(Token token)
        {
            var span = token.ToSpan();
            string str = new string(span);

            return Expression.Constant(State[str], typeof(decimal));
        }
    }
}
