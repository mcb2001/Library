using Oc6.Library.Maths;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oc6.Library.Tests.Maths
{
    public  class DecimalMathsTests
    {
        [Theory]
        [InlineData("81", "9", "2")]
        [InlineData("0.012345679012345679012345679", "9", "-2")]
        [InlineData("1.8587296919794811670420219951", "1.2", "3.4")]
        [InlineData("0.5380018430410047863745228634", "1.2", "-3.4")]
        public void Pow(string expectedString, string valueString, string powerString)
        {
            decimal expected = decimal.Parse(expectedString, NumberStyles.Number, CultureInfo.InvariantCulture);

            decimal value = decimal.Parse(valueString, NumberStyles.Number, CultureInfo.InvariantCulture);
            decimal power = decimal.Parse(powerString, NumberStyles.Number, CultureInfo.InvariantCulture);
            decimal actual = DecimalMath.Pow(value, power);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Sqrt()
        {
            const decimal expected = 9.0M;
            decimal actual = 81.0M;
            actual = DecimalMath.Sqrt(actual);
            Assert.Equal<decimal>(expected, actual);
        }

        [Fact]
        public void Root()
        {
            const decimal expected = 100.0M;
            decimal actual = expected * expected * expected;
            actual = DecimalMath.Root(actual, 3);
            Assert.Equal<decimal>(expected, actual);
        }

        [Fact]
        public void CosZero()
        {
            decimal expected = 0.0M;
            decimal actual = DecimalMath.PI / 2.0M;
            actual = DecimalMath.Cos(actual);
            Assert.Equal<decimal>(expected, actual);
        }

        [Fact]
        public void CosNegative()
        {
            decimal expected = -1.0M;
            decimal actual = DecimalMath.PI;
            actual = DecimalMath.Cos(actual);
            Assert.Equal<decimal>(expected, actual);
        }

        [Fact]
        public void SinOne()
        {
            decimal expected = 1.0M;
            decimal actual = DecimalMath.PI / 2.0M;
            actual = DecimalMath.Sin(actual);
            Assert.Equal<decimal>(expected, actual);
        }

        [Fact]
        public void SinZero()
        {
            decimal expected = 0.0M;
            decimal actual = DecimalMath.PI;
            actual = DecimalMath.Sin(actual);
            Assert.Equal<decimal>(expected, actual);
        }

        [Fact]
        public void TanSqrt3()
        {
            const decimal THREE = 3.0M;
            decimal expected = DecimalMath.Sqrt(THREE);
            decimal actual = DecimalMath.PI / THREE;
            actual = DecimalMath.Tan(actual);

            expected = Math.Round(expected, 22);    //1.7320508075688772935274463415
            actual = Math.Round(actual, 22);        //1.7320508075688772935274463414

            Assert.Equal<decimal>(expected, actual);
        }

        [Fact]
        public void TanException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => DecimalMath.Tan(DecimalMath.PI / 2));
        }
    }
}
