using Microsoft.VisualStudio.TestTools.UnitTesting;
using Oc6.Library.Maths;
using System;
using System.Collections.Generic;
using System.Linq;
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

            decimal expected = 0.0M;

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
    }
}
