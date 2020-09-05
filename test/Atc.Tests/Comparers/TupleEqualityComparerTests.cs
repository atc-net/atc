using System;
using Xunit;

namespace Atc.Tests.Comparers
{
    public class TupleEqualityComparerTests
    {
        [Theory]
        [InlineData(false, 1, 1, 1, 2)]
        [InlineData(true, 1, 1, 1, 1)]
        public void OverrideEquals(bool expected, int a1, int a2, int b1, int b2)
        {
            // Arrange
            var comparer = new TupleEqualityComparer<int, int>();
            var tupleA = new Tuple<int, int>(a1, a2);
            var tupleB = new Tuple<int, int>(b1, b2);

            // Act
            var actual = comparer.Equals(tupleA, tupleB);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void OverrideGetHashCode()
        {
            // Arrange
            var comparer = new TupleEqualityComparer<int, int>();

            // Act
            var actual = comparer.GetHashCode();

            // Assert
            Assert.True(actual > 0);
        }
    }
}