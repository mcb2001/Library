using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oc6.Library.Strings;

namespace Oc6.Library.Tests.Strings
{
    [TestClass]
    public sealed class StringExtensionsTests
    {
        [TestMethod]
        public void RemoveAll_Func_Digit()
        {
            string actual = "1a2a3a4";
            actual = actual.RemoveAll(c => char.IsDigit(c));

            string expected = "aaa";

            Assert.AreEqual<string>(expected, actual);
        }

        [TestMethod]
        public void RemoveAllWhiteSpace()
        {
            string actual = " 1\t2\n3\r";
            actual = actual.RemoveAllWhiteSpace();

            string expected = "123";

            Assert.AreEqual<string>(expected, actual);
        }

        [TestMethod]
        public void RemoveAll_Params_PeriodAndComma()
        {
            string actual = ".1.2,3.";
            actual = actual.RemoveAll('.', ',');

            string expected = "123";

            Assert.AreEqual<string>(expected, actual);
        }
    }
}
