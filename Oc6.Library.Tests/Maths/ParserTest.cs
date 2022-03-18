using Microsoft.VisualStudio.TestTools.UnitTesting;
using Oc6.Library.Maths;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Oc6.Library.Tests.Maths
{
    [TestClass]
    public class ParserTest
    {
        [TestMethod]
        public void Evaluate_DefaultCulture()
        {
            Parser parser = new Parser();

            decimal expected = 1 + 2 + -3;

            decimal actual = parser.Evaluate("1.00 + 2.0 - 3");

            Assert.AreEqual<decimal>(expected, actual);
        }

        [TestMethod]
        public void Evaluate_Negate()
        {
            Parser parser = new Parser();

            decimal expected = -1.0M;

            decimal actual = parser.Evaluate("-1");

            Assert.AreEqual<decimal>(expected, actual);
        }

        [TestMethod]
        public void Evaluate_Negate_Multi()
        {
            Parser parser = new Parser();

            decimal expected = -1.0M;

            decimal actual = parser.Evaluate("0+-1");

            Assert.AreEqual<decimal>(expected, actual);
        }

        [TestMethod]
        public void Evaluate_Power()
        {
            Parser parser = new Parser();

            decimal expected = 8.0M;

            decimal actual = parser.Evaluate("2^3");

            Assert.AreEqual<decimal>(expected, actual);
        }

        [TestMethod]
        public void Evaluate_Value()
        {
            Parser parser = new Parser();
            parser.State["M"] = 200.0M;

            decimal expected = 202.0M;

            decimal actual = parser.Evaluate("M+2");

            Assert.AreEqual<decimal>(expected, actual);
        }

        [TestMethod]
        public void Evaluate_ErrorProne()
        {
            Parser parser = new Parser(CultureInfo.GetCultureInfo("da-DK"));

            decimal expected = 0.0437609211829063596253579438M;

            decimal actual = parser.Evaluate("(1+4,290698690388/1200)^12-1");

            Assert.AreEqual<decimal>(expected, actual);
        }

        [TestMethod]
        public void Evaluate_Full()
        {
            Parser parser = new Parser();

            decimal expected = 1.0M + 2.0M - (3.0M * 4.0M / 8.0M); // 8 = 2^3

            decimal actual = parser.Evaluate("1 + 2 - (1 + 2) * 4 / 2 ^ 3");

            Assert.AreEqual<decimal>(expected, actual);
        }

        [TestMethod]
        public void Evaluate_Paranthesis_Right()
        {
            Parser parser = new Parser();

            decimal expected = 5;

            decimal actual = parser.Evaluate("1 * (2 + 3)");

            Assert.AreEqual<decimal>(expected, actual);
        }

        [TestMethod]
        public void Evaluate_Paranthesis_Left()
        {
            Parser parser = new Parser();

            decimal expected = 5;

            decimal actual = parser.Evaluate("(2 + 3) * 1");

            Assert.AreEqual<decimal>(expected, actual);
        }

        [TestMethod]
        public void Evaluate_Paranthesis_Complex()
        {
            Parser parser = new Parser();

            decimal expected = (1.0M * (2.0M + 3.0M)) + (2.0M * (3.0M - 4.0M) / 5.0M) + 2.0M + (3.0M * 4.0M);

            decimal actual = parser.Evaluate("(1 * (2 + 3)) + (2 * (3 - 4) / 5) + 2 + (3 * 4)");

            Assert.AreEqual<decimal>(expected, actual);
        }
    }
}
