using Oc6.Library.Calc.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Oc6.Library.Calc
{
    public sealed class Parser
    {
        private readonly CultureInfo cultureInfo;
        private readonly Tokenizer tokenizer;

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

        public Expression<Func<decimal>> Parse(string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            Span<Token> tokens = tokenizer
                   .GetTokens(input.ToCharArray())
                   .ToArray();

            var expression = Parse(tokens);

            return Expression.Lambda<Func<decimal>>(expression);
        }

        private Expression Parse(Span<Token> tokens)
        {
            Stack<Expression> operandStack = new Stack<Expression>();
            //Stack<TokenType>

            throw new NotImplementedException();
        }
    }
}
