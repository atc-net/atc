using System;
using System.Collections.Generic;
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

        [Theory]
        [InlineData(new[] { 1, 2, 4, 8 }, 16, 8)]
        [InlineData(new[] { 1 }, 1, 1)]
        [InlineData(new[] { 1, 3 }, 9, 5)]
        [InlineData(new[] { 1, 3, 9 }, 9, 9)]
        [InlineData(new[] { 1, 3, 9 }, 9, 29)]
        [InlineData(new[] { 1, 5, 13, 65, 1381, 6905, 17953 }, 89765, 44882)]
        public void GetDivisorsLessThanOrEqual(IEnumerable<int> expected, int value, int max)
        {
            // Act
            var actual = MathEx.GetDivisorsLessThanOrEqual(value, max);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(-1, 10)]
        [InlineData(0, 10)]
        [InlineData(10, -1)]
        [InlineData(10, 0)]
        public void GetDivisorsLessThanOrEqual_Expected_ArgumentOutOfRangeException(int value, int max)
            => Assert.Throws<ArgumentOutOfRangeException>(() => MathEx.GetDivisorsLessThanOrEqual(value, max));
    }
}
