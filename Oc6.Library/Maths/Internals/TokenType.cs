using Oc6.Library.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oc6.Library.Maths.Internals
{
    internal enum TokenType
    {
        Number = 1,             //Any number

        Nop = 2,                // No-Operation
        Add = 3,                // '+'
        //Subtract = 4,           // '-'
        Multiply = 5,           // '*'
        Divide = 6,             // '/'
        Power = 7,              // '^'

        Word = 8,               // [A-Za-z][A-Za-z0-9]*

        ParanthesisOpen = 9,    // '('
        ParanthesisClose = 10,  // ')'

        Negate = 11,        // '-',
    }

    internal static class TokenTypeExtensions
    {
        public static bool IsOperator(this TokenType tokenType)
        {
            return tokenType == TokenType.Nop
                || tokenType == TokenType.Add
                //|| tokenType == TokenType.Subtract
                || tokenType == TokenType.Multiply
                || tokenType == TokenType.Divide
                || tokenType == TokenType.Power;
        }

        public static bool HasLowerPrecedenceThan(this TokenType that, TokenType other)
        {
            if (!that.IsOperator())
            {
                throw new ArgumentException(ErrorMessages.TokenType_InvalidType, nameof(that));
            }

            if (!other.IsOperator())
            {
                throw new ArgumentException(ErrorMessages.TokenType_InvalidType, nameof(other));
            }

            int l = (int)that;
            int r = (int)other;

            return l < r;
        }
    }
}
