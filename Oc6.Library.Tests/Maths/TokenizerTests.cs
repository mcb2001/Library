using Microsoft.VisualStudio.TestTools.UnitTesting;
using Oc6.Library.Maths;
using Oc6.Library.Maths.Internals;
using System;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;

namespace Oc6.Library.Tests.Maths
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

            Tokenizer tokenizer = new(CultureInfo.InvariantCulture);
            var enumerable = tokenizer.GetTokens(input.ToCharArray());
            var tokens = enumerable.ToList();

            Assert.AreEqual<int>(9, tokens.Count);

            AssertToken(tokens[0], TokenType.Number, x0);
            AssertToken(tokens[1], TokenType.Add, x1);
            AssertToken(tokens[2], TokenType.Number, x2);
            AssertToken(tokens[3], TokenType.Add, x3);
            AssertToken(tokens[4], TokenType.Negate, x3);
            AssertToken(tokens[5], TokenType.Word, x4);
            AssertToken(tokens[6], TokenType.ParanthesisOpen, x5);
            AssertToken(tokens[7], TokenType.Number, x6);
            AssertToken(tokens[8], TokenType.ParanthesisClose, x7);
        }

        [TestMethod]
        public void GetTokens_Number_Plus_Number_DefaultCulture()
        {
            string a = "1";
            string b = "+";
            string c = "2.0";
            string input = a + b + c;

            Tokenizer tokenizer = new(CultureInfo.InvariantCulture);
            var enumerable = tokenizer.GetTokens(input.ToCharArray());
            var tokens = enumerable.ToList();

            Assert.AreEqual<int>(3, tokens.Count);

            AssertToken(tokens[0], TokenType.Number, a);
            AssertToken(tokens[1], TokenType.Add, b);
            AssertToken(tokens[2], TokenType.Number, c);
        }

        [TestMethod]
        public void GetTokens_Number_Plus_NegativeNumber_DefaultCulture()
        {
            string a = "1";
            string b = "+";
            string c = "-";
            string d = "2.0";
            string input = a + b + c + d;

            Tokenizer tokenizer = new(CultureInfo.InvariantCulture);
            var enumerable = tokenizer.GetTokens(input.ToCharArray());
            var tokens = enumerable.ToList();

            Assert.AreEqual<int>(4, tokens.Count);

            AssertToken(tokens[0], TokenType.Number, a);
            AssertToken(tokens[1], TokenType.Add, b);
            AssertToken(tokens[2], TokenType.Negate, c);
            AssertToken(tokens[3], TokenType.Number, d);
        }

        [TestMethod]
        public void GetTokens_Number_DkCulture()
        {
            string input = "2,0";

            Tokenizer tokenizer = new(CultureInfo.GetCultureInfo("da-DK"));
            var enumerable = tokenizer.GetTokens(input.ToCharArray());
            var tokens = enumerable.ToList();

            Assert.AreEqual<int>(1, tokens.Count);

            AssertToken(tokens[0], TokenType.Number, input);
        }

        [TestMethod]
        public void GetTokens_Word_DefaultCulture()
        {
            string input = "ThisIsAMethod";

            Tokenizer tokenizer = new(CultureInfo.GetCultureInfo("da-DK"));
            var enumerable = tokenizer.GetTokens(input.ToCharArray());
            var tokens = enumerable.ToList();

            Assert.AreEqual<int>(1, tokens.Count);

            AssertToken(tokens[0], TokenType.Word, input);
        }

        [TestMethod]
        public void GetTokens_NumberWithGrouping_DkCulture()
        {
            string input = "1.000.000,00";

            Tokenizer tokenizer = new(CultureInfo.GetCultureInfo("da-DK"));
            var enumerable = tokenizer.GetTokens(input.ToCharArray());
            var tokens = enumerable.ToList();

            Assert.AreEqual<int>(1, tokens.Count);

            AssertToken(tokens[0], TokenType.Number, input);
        }

        [TestMethod]
        public void Test_Expression()
        {
            Span<int> span = new int[] { 0, 1, 2, 3, 4, 5 };

            int index = 3;

            var left = span[..index];
            var right = span[(index + 1)..];

            Assert.AreEqual(3, left.Length);
            Assert.AreEqual(0, left[0]);
            Assert.AreEqual(1, left[1]);
            Assert.AreEqual(2, left[2]);

            Assert.AreEqual(2, right.Length);
            Assert.AreEqual(4, right[0]);
            Assert.AreEqual(5, right[1]);
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
