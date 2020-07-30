using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oc6.Library.Calc.Models
{
    internal enum TokenType
    {
        Number = 1,             //Any number

        Nop = 2,                // No-Operation
        Add = 3,                // '+'
        Subtract = 4,           // '-'
        Multiply = 5,           // '*'
        Divide = 6,             // '/'
        Power = 7,              // '^'

        Word = 8,               // [A-Za-z][A-Za-z0-9]*

        ParanthesisOpen = 9,    // '('
        ParanthesisClose = 10,  // ')'

        UnaryMinus = 11,        // '-'
    }

    internal static class TokenTypeExtensions
    {
        public static bool HasHigherPrecedenceThan(this TokenType that, TokenType other)
        {
            switch (that)
            {
                case TokenType.Number:
                case TokenType.Word:
                case TokenType.ParanthesisOpen:
                case TokenType.ParanthesisClose:
                case TokenType.UnaryMinus:
                    {
                        throw new ArgumentException("Invalid type");
                    }
            }

            switch (other)
            {
                case TokenType.Number:
                case TokenType.Word:
                case TokenType.ParanthesisOpen:
                case TokenType.ParanthesisClose:
                case TokenType.UnaryMinus:
                    {
                        throw new ArgumentException("Invalid type");
                    }
            }

            int l = (int)that;
            int r = (int)other;

            return l > r;
        }
    }
}
