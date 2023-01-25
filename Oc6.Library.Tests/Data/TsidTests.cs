using FluentAssertions;
using FluentAssertions.Collections;
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
            ITsidFactory tsidFactory = new TsidFactory();

            List<long> unsorted = Enumerable.Range(0, byte.MaxValue)
                .Select(_ => tsidFactory.CreateTsid())
                .ToList();

            unsorted
                .Should()
                .BeInAscendingOrder()
                .And
                .OnlyHaveUniqueItems()
                .And
                .AllSatisfy(value => value.Should().BePositive());

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
        public void TryParseTsid(string value, long expected)
        {
            ITsidFactory tsidFactory = new TsidFactory();

            Assert.True(tsidFactory.TryParseTsid(value, out long actual));
            
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("000000000000-03-0DEF", 0xCDEF)]
        [InlineData("00048D159E26-AF-0DEF", 0x0123456789ABCDEF)]
        [InlineData("000000000000-00-0000", 0)]
        [InlineData("000000000000-00-0001", 1)]
        [InlineData("01FFFFFFFFFF-FF-3FFE", long.MaxValue - 1)]
        [InlineData("01FFFFFFFFFF-FF-3FFF", long.MaxValue)]
        public void ToTsidString(string expected, long tsid)
        {
            ITsidFactory tsidFactory = new TsidFactory();

            Assert.Equal(expected, tsidFactory.ToTsidString(tsid));
        }

        [Fact]
        public void RandomTsidShouldParseToString()
        {
            ITsidFactory tsidFactory = new TsidFactory();

            for (int i = 0; i < 100; ++i)
            {
                long expected = (((long)Random.Shared.Next() << 32) | (long)Random.Shared.Next()) & long.MaxValue;

                Assert.True(tsidFactory.TryParseTsid(tsidFactory.ToTsidString(expected), out long actual));

                Assert.Equal(expected, actual);
            }
        }

        [Fact]
        public void CreatedTsidShouldParseToString()
        {
            ITsidFactory tsidFactory = new TsidFactory();

            for (int i = 0; i < 100; ++i)
            {
                long expected = tsidFactory.CreateTsid();

                Assert.True(tsidFactory.TryParseTsid(tsidFactory.ToTsidString(expected), out long actual));

                Assert.Equal(expected, actual);
            }
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(long.MinValue)]
        public void ToTsidString_Exception(long tsid)
        {
            ITsidFactory tsidFactory = new TsidFactory();

            Assert.Throws<ArgumentOutOfRangeException>(() => tsidFactory.ToTsidString(tsid));
        }
    }
}
