using Oc6.Library.Maths;

namespace Oc6.Library.Tests.Maths
{
    public class DoubleMathsTests
    {
        [Theory]
        [InlineData(1, 1, 1)]
        [InlineData(1.4142135623730949, 2, 2)]
        [InlineData(1.4422495703074083, 3, 3)]
        [InlineData(1.1676234836961077, 19, 19)]
        [InlineData(3, 27, 3)]
        [InlineData(3, 81, 4)]
        public void Root(double expected, double value, int root)
        {
            double actual = DoubleMath.Root(value, root);
            Assert.Equal(expected, actual);
        }
    }
}
