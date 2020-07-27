using Oc6.Library.Calculator.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oc6.Library.Calculator
{
    public sealed class Parser
    {
        private readonly CultureInfo cultureInfo;
        private readonly Tokenizer tokenizer;

        public Parser()
        {

        }

        public Parser(CultureInfo cultureInfo)
        {
            this.cultureInfo = cultureInfo;
            tokenizer = new Tokenizer(this.cultureInfo);
        }

        public decimal Evaluate(string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            List<Token> tokens = tokenizer
                .GetTokens(input.ToCharArray())
                .ToList();



            return default;
        }
    }
}
