using System;
using Xunit;

namespace Atc.Tests.Extensions
{
    public class VersionExtensionsTests
    {
        [Theory]
        [InlineData(0, new[] { 1, 0, 0, 0 }, new[] { 1, 0, 0, 0 }, 4)]
        [InlineData(1, new[] { 2, 0, 0, 0 }, new[] { 1, 0, 0, 0 }, 4)]
        [InlineData(1, new[] { 1, 1, 0, 0 }, new[] { 1, 0, 0, 0 }, 4)]
        [InlineData(1, new[] { 1, 0, 1, 0 }, new[] { 1, 0, 0, 0 }, 4)]
        [InlineData(1, new[] { 1, 0, 0, 1 }, new[] { 1, 0, 0, 0 }, 4)]
        [InlineData(-1, new[] { 1, 0, 0, 0 }, new[] { 2, 0, 0, 0 }, 4)]
        [InlineData(-1, new[] { 1, 0, 0, 0 }, new[] { 1, 1, 0, 0 }, 4)]
        [InlineData(-1, new[] { 1, 0, 0, 0 }, new[] { 1, 0, 1, 0 }, 4)]
        [InlineData(-1, new[] { 1, 0, 0, 0 }, new[] { 1, 0, 0, 1 }, 4)]
        [InlineData(0, new[] { 1, 0, 0, 0 }, new[] { 1, 0, 0, 0 }, 3)]
        [InlineData(1, new[] { 2, 0, 0, 0 }, new[] { 1, 0, 0, 0 }, 3)]
        [InlineData(1, new[] { 1, 1, 0, 0 }, new[] { 1, 0, 0, 0 }, 3)]
        [InlineData(1, new[] { 1, 0, 1, 0 }, new[] { 1, 0, 0, 0 }, 3)]
        [InlineData(0, new[] { 1, 0, 0, 1 }, new[] { 1, 0, 0, 0 }, 3)]
        [InlineData(-1, new[] { 1, 0, 0, 0 }, new[] { 2, 0, 0, 0 }, 3)]
        [InlineData(-1, new[] { 1, 0, 0, 0 }, new[] { 1, 1, 0, 0 }, 3)]
        [InlineData(-1, new[] { 1, 0, 0, 0 }, new[] { 1, 0, 1, 0 }, 3)]
        [InlineData(0, new[] { 1, 0, 0, 0 }, new[] { 1, 0, 0, 1 }, 3)]
        [InlineData(0, new[] { 1, 0, 0, 0 }, new[] { 1, 0, 0, 0 }, 2)]
        [InlineData(1, new[] { 2, 0, 0, 0 }, new[] { 1, 0, 0, 0 }, 2)]
        [InlineData(1, new[] { 1, 1, 0, 0 }, new[] { 1, 0, 0, 0 }, 2)]
        [InlineData(0, new[] { 1, 0, 1, 0 }, new[] { 1, 0, 0, 0 }, 2)]
        [InlineData(0, new[] { 1, 0, 0, 1 }, new[] { 1, 0, 0, 0 }, 2)]
        [InlineData(-1, new[] { 1, 0, 0, 0 }, new[] { 2, 0, 0, 0 }, 2)]
        [InlineData(-1, new[] { 1, 0, 0, 0 }, new[] { 1, 1, 0, 0 }, 2)]
        [InlineData(0, new[] { 1, 0, 0, 0 }, new[] { 1, 0, 1, 0 }, 2)]
        [InlineData(0, new[] { 1, 0, 0, 0 }, new[] { 1, 0, 0, 1 }, 2)]
        [InlineData(0, new[] { 1, 0, 0, 0 }, new[] { 1, 0, 0, 0 }, 1)]
        [InlineData(1, new[] { 2, 0, 0, 0 }, new[] { 1, 0, 0, 0 }, 1)]
        [InlineData(0, new[] { 1, 1, 0, 0 }, new[] { 1, 0, 0, 0 }, 1)]
        [InlineData(0, new[] { 1, 0, 1, 0 }, new[] { 1, 0, 0, 0 }, 1)]
        [InlineData(0, new[] { 1, 0, 0, 1 }, new[] { 1, 0, 0, 0 }, 1)]
        [InlineData(-1, new[] { 1, 0, 0, 0 }, new[] { 2, 0, 0, 0 }, 1)]
        [InlineData(0, new[] { 1, 0, 0, 0 }, new[] { 1, 1, 0, 0 }, 1)]
        [InlineData(0, new[] { 1, 0, 0, 0 }, new[] { 1, 0, 1, 0 }, 1)]
        [InlineData(0, new[] { 1, 0, 0, 0 }, new[] { 1, 0, 0, 1 }, 1)]
        public void CompareTo(int expected, int[] inputA, int[] inputB, int significantParts)
        {
            var versionA = new Version(inputA[0], inputA[1], inputA[2], inputA[3]);
            var versionB = new Version(inputB[0], inputB[1], inputB[2], inputB[3]);

            var actual = versionA.CompareTo(versionB, significantParts);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(false, new[] { 1, 0, 0, 0 }, new[] { 1, 0, 0, 0 })]
        [InlineData(true, new[] { 2, 0, 0, 0 }, new[] { 1, 0, 0, 0 })]
        [InlineData(true, new[] { 1, 1, 0, 0 }, new[] { 1, 0, 0, 0 })]
        [InlineData(true, new[] { 1, 0, 1, 0 }, new[] { 1, 0, 0, 0 })]
        [InlineData(true, new[] { 1, 0, 0, 1 }, new[] { 1, 0, 0, 0 })]
        [InlineData(false, new[] { 1, 0, 0, 0 }, new[] { 2, 0, 0, 0 })]
        [InlineData(false, new[] { 1, 0, 0, 0 }, new[] { 1, 1, 0, 0 })]
        [InlineData(false, new[] { 1, 0, 0, 0 }, new[] { 1, 0, 1, 0 })]
        [InlineData(false, new[] { 1, 0, 0, 0 }, new[] { 1, 0, 0, 1 })]
        public void GreaterThan(bool expected, int[] inputA, int[] inputB)
        {
            var versionA = new Version(inputA[0], inputA[1], inputA[2], inputA[3]);
            var versionB = new Version(inputB[0], inputB[1], inputB[2], inputB[3]);

            var actual = versionA.GreaterThan(versionB);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(false, new[] { 1, 1, 1, 1 }, new[] { 1, 1, 1, 1 }, 4)]
        [InlineData(true, new[] { 2, 1, 1, 1 }, new[] { 1, 1, 1, 1 }, 4)]
        [InlineData(true, new[] { 2, 1, 1, 1 }, new[] { 1, 2, 1, 1 }, 4)]
        [InlineData(false, new[] { 1, 1, 1, 1 }, new[] { 2, 1, 1, 1 }, 4)]
        [InlineData(false, new[] { 1, 1, 1, 1 }, new[] { 2, 2, 1, 1 }, 4)]
        public void GreaterThan_SignificantParts(bool expected, int[] inputA, int[] inputB, int significantParts)
        {
            var versionA = new Version(inputA[0], inputA[1], inputA[2], inputA[3]);
            var versionB = new Version(inputB[0], inputB[1], inputB[2], inputB[3]);

            var actual = versionA.GreaterThan(versionB, significantParts);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(false, new[] { 1, 1, 1, 1 }, new[] { 1, 1, 1, 1 }, 4, 1)]
        [InlineData(true, new[] { 2, 1, 1, 1 }, new[] { 1, 1, 1, 1 }, 4, 1)]
        [InlineData(false, new[] { 2, 1, 1, 1 }, new[] { 1, 1, 1, 1 }, 4, 2)]
        [InlineData(false, new[] { 2, 1, 1, 1 }, new[] { 1, 2, 1, 1 }, 4, 2)]
        [InlineData(false, new[] { 1, 1, 1, 1 }, new[] { 2, 1, 1, 1 }, 4, 2)]
        [InlineData(false, new[] { 1, 2, 1, 1 }, new[] { 1, 3, 1, 1 }, 4, 2)]
        [InlineData(false, new[] { 2, 2, 1, 1 }, new[] { 1, 3, 1, 1 }, 4, 2)]
        [InlineData(true, new[] { 1, 3, 1, 1 }, new[] { 1, 2, 1, 1 }, 4, 2)]
        public void GreaterThan_SignificantParts_StartingParts(bool expected, int[] inputA, int[] inputB, int significantParts, int startingPart)
        {
            var versionA = new Version(inputA[0], inputA[1], inputA[2], inputA[3]);
            var versionB = new Version(inputB[0], inputB[1], inputB[2], inputB[3]);

            var actual = versionA.GreaterThan(versionB, significantParts, startingPart);

            Assert.Equal(expected, actual);
        }
    }
}