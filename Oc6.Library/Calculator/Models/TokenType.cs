using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oc6.Library.Calculator.Models
{
    internal enum TokenType
    {
        Number = 0,             //Any number

        Plus = 1,               // '+'
        Minus = 2,              // '-'
        Multiply = 3,           // '*'
        Divide = 4,             // '/'
        Power = 5,              // '^'
        
        Word = 6,               // [A-Za-z][A-Za-z0-9]*

        ParanthesisOpen = 7,    // '('
        ParanthesisClose = 8,   // ')'

        Assign = 9,             // '='
    }
}
