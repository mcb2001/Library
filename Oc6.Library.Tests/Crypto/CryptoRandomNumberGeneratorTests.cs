using Microsoft.VisualStudio.TestTools.UnitTesting;
using NuGet.Frameworks;
using Oc6.Library.Crypto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oc6.Library.Tests.Crypto
{
    [TestClass]
    public sealed class CryptoRandomNumberGeneratorTests
    {
        private const int ITERATIONS = 10000;
        private ICryptoRandomNumberGenerator randomNumberGenerator;

        [TestInitialize]
        public void Init()
        {
            randomNumberGenerator = new CryptoRandomNumberGenerator();
        }

        [TestCleanup]
        public void Cleanup()
        {
            randomNumberGenerator.Dispose();
        }

        [TestMethod]
        public void NextToFrom_HitsAllValuesWithInAReasonableTime()
        {
            int from = 0;
            int to = 10;

            for (int number = from; number < to; ++number)
            {
                int i;

                for (i = 0; i < ITERATIONS && randomNumberGenerator.Next(from, to) != number; ++i)
                {
                }

                if (i == ITERATIONS)
                {
                    Assert.IsTrue(false);
                }
            }
        }

        [TestMethod]
        public void Next_ShouldNeverBeNegative()
        {
            for (int i = 0; i < ITERATIONS; ++i)
            {
                Assert.IsTrue(randomNumberGenerator.Next() >= 0);
            }
        }

        [TestMethod]
        public void NextToFrom_ShouldWorkWithNegativeNumbers()
        {
            for (int i = 0; i < ITERATIONS; ++i)
            {
                Assert.IsTrue(randomNumberGenerator.Next(-100, 0) < 0);
            }
        }

        [TestMethod]
        public void NextToFrom_IsBoundedOnNegative()
        {
            NextToFrom_IsBounded(-1000, -100);
        }

        [TestMethod]
        public void NextToFrom_IsBoundedTight()
        {
            NextToFrom_IsBounded(0, 2);
        }

        [TestMethod]
        public void NextToFrom_IsBoundedLoose()
        {
            NextToFrom_IsBounded(int.MinValue / 2, int.MaxValue / 2);
        }

        [TestMethod]
        public void Next_IsRandom()
        {
            int[] first = Enumerable.Range(0, ITERATIONS)
                .Select(_ => randomNumberGenerator.Next())
                .ToArray();

            int[] second = Enumerable.Range(0, ITERATIONS)
                .Select(_ => randomNumberGenerator.Next())
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

            Assert.IsTrue(sum < ITERATIONS / 3);
        }

        private void NextToFrom_IsBounded(int from, int to)
        {
            for (int i = 0; i < ITERATIONS; ++i)
            {
                var a = randomNumberGenerator.Next(from, to);
                Assert.IsTrue(a >= from);
                Assert.IsTrue(a < to);
            }
        }

        [TestMethod]
        public void NextToFrom_FailsOnReversedFromTo()
        {
            Assert.ThrowsException<ArgumentException>(() => randomNumberGenerator.Next(0, -1));
        }

        [TestMethod]
        public void NextToFrom_FailsOnEqualFromTo()
        {
            Assert.ThrowsException<ArgumentException>(() => randomNumberGenerator.Next(0, 0));
        }
    }
}
