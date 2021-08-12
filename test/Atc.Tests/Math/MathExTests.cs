using Atc.Math;
using Xunit;

namespace Atc.Tests.Math
{
    public class MathExTests
    {
        [Theory]
        [InlineData(3, 9, 3)]
        [InlineData(4, 8, 12)]
        [InlineData(6, 54, 24)]
        [InlineData(14, 42, 56)]
        [InlineData(6, 48, 18)]
        [InlineData(21, 1071, 462)]
        [InlineData(65, 89765, 12350)]
        public void GreatestCommonDivisor(int expected, int v1, int v2)
        {
            // Act
            var actual = MathEx.GreatestCommonDivisor(v1, v2);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(0.5, 1.5, 2.5)]
        [InlineData(3.3, 9.9, 3.3)]
        [InlineData(9.5, 89765.5, 12350)]
        public void GreatestCommonDivisor_As_Double(double expected, double v1, double v2)
        {
            // Act
            var actual = MathEx.GreatestCommonDivisor(v1, v2);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
