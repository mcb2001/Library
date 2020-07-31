using Microsoft.VisualStudio.TestTools.UnitTesting;
using Oc6.Library.Maths;
using Oc6.Library.Maths.Internals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oc6.Library.Tests.Maths
{
    [TestClass]
    public class TokenTypeTests
    {
        [TestMethod]
        public void HasLowerPrecedenceThan()
        {
            Assert.IsFalse(TokenType.Nop.HasLowerPrecedenceThan(TokenType.Nop));
            Assert.IsTrue(TokenType.Nop.HasLowerPrecedenceThan(TokenType.Add));
            Assert.IsTrue(TokenType.Nop.HasLowerPrecedenceThan(TokenType.Multiply));
            Assert.IsTrue(TokenType.Nop.HasLowerPrecedenceThan(TokenType.Divide));
            Assert.IsTrue(TokenType.Nop.HasLowerPrecedenceThan(TokenType.Power));

            Assert.IsFalse(TokenType.Add.HasLowerPrecedenceThan(TokenType.Nop));
            Assert.IsFalse(TokenType.Add.HasLowerPrecedenceThan(TokenType.Add));
            Assert.IsTrue(TokenType.Add.HasLowerPrecedenceThan(TokenType.Multiply));
            Assert.IsTrue(TokenType.Add.HasLowerPrecedenceThan(TokenType.Divide));
            Assert.IsTrue(TokenType.Add.HasLowerPrecedenceThan(TokenType.Power));

            Assert.IsFalse(TokenType.Multiply.HasLowerPrecedenceThan(TokenType.Nop));
            Assert.IsFalse(TokenType.Multiply.HasLowerPrecedenceThan(TokenType.Add));
            Assert.IsFalse(TokenType.Multiply.HasLowerPrecedenceThan(TokenType.Multiply));
            Assert.IsTrue(TokenType.Multiply.HasLowerPrecedenceThan(TokenType.Divide));
            Assert.IsTrue(TokenType.Multiply.HasLowerPrecedenceThan(TokenType.Power));

            Assert.IsFalse(TokenType.Divide.HasLowerPrecedenceThan(TokenType.Nop));
            Assert.IsFalse(TokenType.Divide.HasLowerPrecedenceThan(TokenType.Add));
            Assert.IsFalse(TokenType.Divide.HasLowerPrecedenceThan(TokenType.Multiply));
            Assert.IsFalse(TokenType.Divide.HasLowerPrecedenceThan(TokenType.Divide));
            Assert.IsTrue(TokenType.Divide.HasLowerPrecedenceThan(TokenType.Power));

            Assert.IsFalse(TokenType.Power.HasLowerPrecedenceThan(TokenType.Nop));
            Assert.IsFalse(TokenType.Power.HasLowerPrecedenceThan(TokenType.Add));
            Assert.IsFalse(TokenType.Power.HasLowerPrecedenceThan(TokenType.Multiply));
            Assert.IsFalse(TokenType.Power.HasLowerPrecedenceThan(TokenType.Divide));
            Assert.IsFalse(TokenType.Power.HasLowerPrecedenceThan(TokenType.Power));
        }

        [TestMethod]
        public void HasLowerPrecedenceThan_Exceptions()
        {
            Assert.ThrowsException<ArgumentException>(() => TokenType.Number.HasLowerPrecedenceThan(TokenType.Nop));
            Assert.ThrowsException<ArgumentException>(() => TokenType.Nop.HasLowerPrecedenceThan(TokenType.Number));
        }
    }
}
