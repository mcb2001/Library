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
        public void HasHigherPrecedenceThan()
        {
            Assert.IsFalse(TokenType.Nop.HasHigherPrecedenceThan(TokenType.Nop));
            Assert.IsFalse(TokenType.Nop.HasHigherPrecedenceThan(TokenType.Add));
            Assert.IsFalse(TokenType.Nop.HasHigherPrecedenceThan(TokenType.Subtract));
            Assert.IsFalse(TokenType.Nop.HasHigherPrecedenceThan(TokenType.Multiply));
            Assert.IsFalse(TokenType.Nop.HasHigherPrecedenceThan(TokenType.Divide));
            Assert.IsFalse(TokenType.Nop.HasHigherPrecedenceThan(TokenType.Power));

            Assert.IsTrue(TokenType.Add.HasHigherPrecedenceThan(TokenType.Nop));
            Assert.IsFalse(TokenType.Add.HasHigherPrecedenceThan(TokenType.Add));
            Assert.IsFalse(TokenType.Add.HasHigherPrecedenceThan(TokenType.Subtract));
            Assert.IsFalse(TokenType.Add.HasHigherPrecedenceThan(TokenType.Multiply));
            Assert.IsFalse(TokenType.Add.HasHigherPrecedenceThan(TokenType.Divide));
            Assert.IsFalse(TokenType.Add.HasHigherPrecedenceThan(TokenType.Power));

            Assert.IsTrue(TokenType.Subtract.HasHigherPrecedenceThan(TokenType.Nop));
            Assert.IsTrue(TokenType.Subtract.HasHigherPrecedenceThan(TokenType.Add));
            Assert.IsFalse(TokenType.Subtract.HasHigherPrecedenceThan(TokenType.Subtract));
            Assert.IsFalse(TokenType.Subtract.HasHigherPrecedenceThan(TokenType.Multiply));
            Assert.IsFalse(TokenType.Subtract.HasHigherPrecedenceThan(TokenType.Divide));
            Assert.IsFalse(TokenType.Subtract.HasHigherPrecedenceThan(TokenType.Power));

            Assert.IsTrue(TokenType.Multiply.HasHigherPrecedenceThan(TokenType.Nop));
            Assert.IsTrue(TokenType.Multiply.HasHigherPrecedenceThan(TokenType.Add));
            Assert.IsTrue(TokenType.Multiply.HasHigherPrecedenceThan(TokenType.Subtract));
            Assert.IsFalse(TokenType.Multiply.HasHigherPrecedenceThan(TokenType.Multiply));
            Assert.IsFalse(TokenType.Multiply.HasHigherPrecedenceThan(TokenType.Divide));
            Assert.IsFalse(TokenType.Multiply.HasHigherPrecedenceThan(TokenType.Power));

            Assert.IsTrue(TokenType.Divide.HasHigherPrecedenceThan(TokenType.Nop));
            Assert.IsTrue(TokenType.Divide.HasHigherPrecedenceThan(TokenType.Add));
            Assert.IsTrue(TokenType.Divide.HasHigherPrecedenceThan(TokenType.Subtract));
            Assert.IsTrue(TokenType.Divide.HasHigherPrecedenceThan(TokenType.Multiply));
            Assert.IsFalse(TokenType.Divide.HasHigherPrecedenceThan(TokenType.Divide));
            Assert.IsFalse(TokenType.Divide.HasHigherPrecedenceThan(TokenType.Power));

            Assert.IsTrue(TokenType.Power.HasHigherPrecedenceThan(TokenType.Nop));
            Assert.IsTrue(TokenType.Power.HasHigherPrecedenceThan(TokenType.Add));
            Assert.IsTrue(TokenType.Power.HasHigherPrecedenceThan(TokenType.Subtract));
            Assert.IsTrue(TokenType.Power.HasHigherPrecedenceThan(TokenType.Multiply));
            Assert.IsTrue(TokenType.Power.HasHigherPrecedenceThan(TokenType.Divide));
            Assert.IsFalse(TokenType.Power.HasHigherPrecedenceThan(TokenType.Power));
        }

        [TestMethod]
        public void HasHigherPrecedenceThan_Exceptions()
        {
            Assert.ThrowsException<ArgumentException>(() => TokenType.Number.HasHigherPrecedenceThan(TokenType.Nop));
            Assert.ThrowsException<ArgumentException>(() => TokenType.Nop.HasHigherPrecedenceThan(TokenType.Number));
        }
    }
}
