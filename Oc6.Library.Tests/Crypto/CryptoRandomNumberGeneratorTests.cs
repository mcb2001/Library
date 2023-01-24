using NuGet.Frameworks;
using Oc6.Library.Crypto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oc6.Library.Tests.Crypto
{
    public  class CryptoRandomNumberGeneratorTests
    {
        private const int ITERATIONS = 10000;

        [Fact]
        public void NextToFrom_HitsAllValuesWithInAReasonableTime()
        {
            using ICryptoRandomNumberGenerator randomNumberGenerator = new CryptoRandomNumberGenerator();

            int from = 0;
            int to = 10;

            for (int number = from; number < to; ++number)
            {
                int i;

                for (i = 0; i < ITERATIONS && randomNumberGenerator.NextInt(from, to) != number; ++i)
                {
                }

                if (i == ITERATIONS)
                {
                    Assert.True(false);
                }
            }
        }

        [Fact]
        public void Next_ShouldNeverBeNegative()
        {
            using ICryptoRandomNumberGenerator randomNumberGenerator = new CryptoRandomNumberGenerator();

            for (int i = 0; i < ITERATIONS; ++i)
            {
                Assert.True(randomNumberGenerator.NextInt() >= 0);
            }
        }

        [Fact]
        public void NextToFrom_ShouldWorkWithNegativeNumbers()
        {
            using ICryptoRandomNumberGenerator randomNumberGenerator = new CryptoRandomNumberGenerator();

            for (int i = 0; i < ITERATIONS; ++i)
            {
                Assert.True(randomNumberGenerator.NextInt(-100, 0) < 0);
            }
        }

        [Fact]
        public void NextToFrom_IsBoundedOnNegative()
        {
            NextToFrom_IsBounded(-1000, -100);
        }

        [Fact]
        public void NextToFrom_IsBoundedTight()
        {
            NextToFrom_IsBounded(0, 2);
        }

        [Fact]
        public void NextToFrom_IsBoundedLoose()
        {
            NextToFrom_IsBounded(int.MinValue / 2, int.MaxValue / 2);
        }

        [Fact]
        public void Next_IsRandom()
        {
            using ICryptoRandomNumberGenerator randomNumberGenerator = new CryptoRandomNumberGenerator();

            int[] first = Enumerable.Range(0, ITERATIONS)
                .Select(_ => randomNumberGenerator.NextInt())
                .ToArray();

            int[] second = Enumerable.Range(0, ITERATIONS)
                .Select(_ => randomNumberGenerator.NextInt())
                .ToArray();

            int equal = 0;
            int nonequal = 0;

            int baseEqualFirst = 0;
            int baseEqualSecond = 0;

            for (int i = 0; i < ITERATIONS; ++i)
            {
                if (first[i] == second[i])
                {
                    ++equal;
                }
                else
                {
                    ++nonequal;
                }

                if (first[i] == i || first[i] == default)
                {
                    ++baseEqualFirst;
                }

                if (second[i] == i || second[i] == default)
                {
                    ++baseEqualSecond;
                }
            }

            int sum = equal + baseEqualFirst + baseEqualSecond;

            Assert.True(sum < ITERATIONS / 3);
        }

        private static void NextToFrom_IsBounded(int from, int to)
        {
            using ICryptoRandomNumberGenerator randomNumberGenerator = new CryptoRandomNumberGenerator();

            for (int i = 0; i < ITERATIONS; ++i)
            {
                var a = randomNumberGenerator.NextInt(from, to);
                Assert.True(a >= from);
                Assert.True(a < to);
            }
        }

        [Fact]
        public void NextToFrom_FailsOnReversedFromTo()
        {
            using ICryptoRandomNumberGenerator randomNumberGenerator = new CryptoRandomNumberGenerator();

            Assert.Throws<ArgumentException>(() => randomNumberGenerator.NextInt(0, -1));
        }

        [Fact]
        public void NextToFrom_FailsOnEqualFromTo()
        {
            using ICryptoRandomNumberGenerator randomNumberGenerator = new CryptoRandomNumberGenerator();

            Assert.Throws<ArgumentException>(() => randomNumberGenerator.NextInt(0, 0));
        }

        [Fact]
        public void NextUnBounded_ReturnsBothPositiveAndNegativeValues()
        {
            using ICryptoRandomNumberGenerator randomNumberGenerator = new CryptoRandomNumberGenerator();

            int i;

            //check if we hit below 0
            for (i = 0; i < ITERATIONS && randomNumberGenerator.NextUnBounded() < 0; ++i)
            {
            }

            if (i == ITERATIONS)
            {
                Assert.True(false);
            }

            //check if we hit above 0
            for (i = 0; i < ITERATIONS && randomNumberGenerator.NextUnBounded() > 0; ++i)
            {
            }

            if (i == ITERATIONS)
            {
                Assert.True(false);
            }
        }
    }
}
