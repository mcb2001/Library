using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Oc6.Library.Calc.Models
{
    internal class Token
    {
        public TokenType TokenType { get; }
        public Expression<Func<decimal>> Expression { get; set; }

        private readonly int start;
        private readonly int length;
        private readonly Memory<char> input;

        public Token(TokenType type, Memory<char> input, int start, int length)
        {
            this.start = start;
            this.length = length;
            this.input = input;
            this.TokenType = type;
        }

        public Span<char> ToSpan()
        {
            return input.Span.Slice(start, length);
        }
    }
}
