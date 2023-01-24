using Oc6.Library.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oc6.Library.Tests.Collections
{
    public class IListExtensionsTests
    {
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(10_000)]
        public void Shuffle(int size)
        {
            List<int> list = Enumerable.Range(0, size).ToList();
            list.Shuffle();
        }

        [Fact]
        public void Shuffle_ShouldBeRandom()
        {
            List<int> expected = Enumerable.Range(0, 1_000)
                .ToList();

            List<int> actual = new(expected);

            actual.Shuffle();

            Assert.NotEqual(expected, actual);
        }

        [Fact]
        public void Shuffle_ArrayShouldWork()
        {
            int[] list = Enumerable.Range(0, 100)
                .ToArray();

            list.Shuffle();
        }

        [Fact]
        public void TakeAndRemoveLast()
        {
            List<int> list = Enumerable.Range(0, 10).ToList();
            int expected = 9;
            int actual = list.TakeAndRemoveLast();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TakeAndRemoveLast_EmptyShouldFail()
        {
            List<int> list = new();
            Assert.Throws<ArgumentOutOfRangeException>(() => list.TakeAndRemoveLast());
        }
    }
}
