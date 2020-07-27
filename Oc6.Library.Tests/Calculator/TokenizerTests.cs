using Microsoft.VisualStudio.TestTools.UnitTesting;
using Oc6.Library.Calculator;
using Oc6.Library.Calculator.Models;
using System.Globalization;
using System.Linq;

namespace Oc6.Library.Tests.Calculator
{
    [TestClass]
    public class TokenizerTests
    {
        [TestMethod]
        public void GetTokens_Number_Plus_Number_Minus_Word_ParaOpen_Number_ParaClose_DefaultCulture()
        {
            string x0 = "1";
            string x1 = "+";
            string x2 = "2.0";
            string x3 = "-";
            string x4 = "PV";
            string x5 = "(";
            string x6 = "3.2";
            string x7 = ")";
            string input = x0 + x1 + x2 + x3 + x4 + x5 + x6 + x7;

            Tokenizer tokenizer = new Tokenizer();
            var enumerable = tokenizer.GetTokens(input.ToCharArray());
            var tokens = enumerable.ToList();

            Assert.AreEqual<int>(8, tokens.Count);

            AssertToken(tokens[0], TokenType.Number, x0);
            AssertToken(tokens[1], TokenType.Plus, x1);
            AssertToken(tokens[2], TokenType.Number, x2);
            AssertToken(tokens[3], TokenType.Minus, x3);
            AssertToken(tokens[4], TokenType.Word, x4);
            AssertToken(tokens[5], TokenType.ParanthesisOpen, x5);
            AssertToken(tokens[6], TokenType.Number, x6);
            AssertToken(tokens[7], TokenType.ParanthesisClose, x7);
        }

        [TestMethod]
        public void GetTokens_Number_Plus_Number_DefaultCulture()
        {
            string a = "1";
            string b = "+";
            string c = "2.0";
            string input = a + b + c;

            Tokenizer tokenizer = new Tokenizer();
            var enumerable = tokenizer.GetTokens(input.ToCharArray());
            var tokens = enumerable.ToList();

            Assert.AreEqual<int>(3, tokens.Count);

            AssertToken(tokens[0], TokenType.Number, a);
            AssertToken(tokens[1], TokenType.Plus, b);
            AssertToken(tokens[2], TokenType.Number, c);
        }

        [TestMethod]
        public void GetTokens_Number_DkCulture()
        {
            string input = "2,0";

            Tokenizer tokenizer = new Tokenizer(CultureInfo.GetCultureInfo("da-DK"));
            var enumerable = tokenizer.GetTokens(input.ToCharArray());
            var tokens = enumerable.ToList();

            Assert.AreEqual<int>(1, tokens.Count);

            AssertToken(tokens[0], TokenType.Number, input);
        }

        [TestMethod]
        public void GetTokens_Word_DefaultCulture()
        {
            string input = "ThisIsAMethod";

            Tokenizer tokenizer = new Tokenizer(CultureInfo.GetCultureInfo("da-DK"));
            var enumerable = tokenizer.GetTokens(input.ToCharArray());
            var tokens = enumerable.ToList();

            Assert.AreEqual<int>(1, tokens.Count);

            AssertToken(tokens[0], TokenType.Word, input);
        }

        [TestMethod]
        public void GetTokens_NumberWithGrouping_DkCulture()
        {
            string input = "1.000.000,00";

            Tokenizer tokenizer = new Tokenizer(CultureInfo.GetCultureInfo("da-DK"));
            var enumerable = tokenizer.GetTokens(input.ToCharArray());
            var tokens = enumerable.ToList();

            Assert.AreEqual<int>(1, tokens.Count);

            AssertToken(tokens[0], TokenType.Number, input);
        }

        private void AssertToken(Token token, TokenType type, string input)
        {
            Assert.AreEqual<TokenType>(type, token.TokenType);

            var span = token.ToSpan();
            var arr = span.ToArray();
            var str = new string(arr);

            Assert.AreEqual<string>(input, str);
        }
    }
}
