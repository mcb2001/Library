using Microsoft.VisualStudio.TestTools.UnitTesting;
using Oc6.Library.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oc6.Library.Tests.Data
{
    [TestClass]
    public class TsidTests
    {
        [TestMethod]
        public void Create_Validate_Sortable()
        {
            List<long> unsorted = Enumerable.Range(0, byte.MaxValue)
                .Select(_ => Tsid.Create())
                .ToList();

            List<long> sorted = new(unsorted);

            sorted.Sort();

            for (int i = 0; i < sorted.Count; ++i)
            {
                Assert.AreEqual(sorted[i], unsorted[i]);
            }
        }

        [TestMethod]
        public void ToShortString_Binaries()
        {
            Assert.AreEqual("0000-0000-0000-0000", Tsid.ToShortString(0b0000000000000000000000000000000000000000000000000000000000000000));
            Assert.AreEqual("0000-0000-0000-0001", Tsid.ToShortString(0b0000000000000000000000000000000000000000000000000000000000000001));
            Assert.AreEqual("7FFF-FFFF-FFFF-FFFF", Tsid.ToShortString(0b0111111111111111111111111111111111111111111111111111111111111111));
        }

        [TestMethod]
        public void ToShortString_Hexadecimals()
        {
            Assert.AreEqual("0000-0000-0000-CDEF", Tsid.ToShortString(0xCDEF));
            Assert.AreEqual("0123-4567-89AB-CDEF", Tsid.ToShortString(0x0123456789ABCDEF));
        }

        [TestMethod]
        public void ToShortString_EdgeCases()
        {
            Assert.AreEqual("0000-0000-0000-0000", Tsid.ToShortString(0));
            Assert.AreEqual("0000-0000-0000-0001", Tsid.ToShortString(1));
            Assert.AreEqual("7FFF-FFFF-FFFF-FFFE", Tsid.ToShortString(long.MaxValue - 1));
            Assert.AreEqual("7FFF-FFFF-FFFF-FFFF", Tsid.ToShortString(long.MaxValue));
        }

        [TestMethod]
        public void ToShortString_Exception()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => Tsid.ToShortString(-1));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => Tsid.ToShortString(long.MinValue));
        }
    }
}
