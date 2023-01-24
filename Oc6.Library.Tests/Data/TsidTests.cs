using Oc6.Library.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Oc6.Library.Tests.Data
{
    public class TsidTests
    {
        [Fact]
        public void Create_Validate_Sortable()
        {
            TsidFactory tsidFactory = new();

            List<long> unsorted = Enumerable.Range(0, byte.MaxValue)
                .Select(_ => tsidFactory.Create())
                .ToList();

            List<long> sorted = new(unsorted);

            sorted.Sort();

            for (int i = 0; i < sorted.Count; ++i)
            {
                Assert.Equal(sorted[i], unsorted[i]);
            }
        }

        [Theory]
        [InlineData("000000000000-03-0DEF", 0xCDEF)]
        [InlineData("00048D159E26-AF-0DEF", 0x0123456789ABCDEF)]
        [InlineData("000000000000-00-0000", 0)]
        [InlineData("000000000000-00-0001", 1)]
        [InlineData("01FFFFFFFFFF-FF-3FFE", long.MaxValue - 1)]
        [InlineData("01FFFFFFFFFF-FF-3FFF", long.MaxValue)]
        public void ToShortString(string expected, long tsid)
        {
            Assert.Equal(expected, TsidFactory.ToShortString(tsid));
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(long.MinValue)]
        public void ToShortString_Exception(long tsid)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => TsidFactory.ToShortString(tsid));
        }
    }
}
