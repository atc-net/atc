using System;
using Xunit;

namespace Atc.Tests.Extensions.BaseTypes
{
    public class DateTimeOffsetExtensionsTests
    {
        [Theory]
        [InlineData(true, 2019, 10, 5, 15)]
        [InlineData(true, 2019, 10, 10, 15)]
        [InlineData(true, 2019, 10, 5, 10)]
        [InlineData(false, 2019, 10, 15, 25)]
        public void IsBetween(bool expected, int year, int inputSeconds, int secondsA, int secondsB)
        {
            // Arrange
            var input = new DateTimeOffset(year, 1, 1, 0, 0, inputSeconds, TimeSpan.Zero);
            var inputA = new DateTimeOffset(year, 1, 1, 0, 0, secondsA, TimeSpan.Zero);
            var inputB = new DateTimeOffset(year, 1, 1, 0, 0, secondsB, TimeSpan.Zero);

            // Act
            var actual = input.IsBetween(inputA, inputB);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(42, 42)]
        public void ToUnixTime(int expected, int seconds)
        {
            // Arrange
            var input = new DateTimeOffset(1970, 1, 1, 0, 0, seconds, TimeSpan.Zero);

            // Act
            var actual = input.ToUnixTime();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("1970-01-01T00:00:42", 42)]
        public void ToIso8601Date(string expected, int seconds)
        {
            // Arrange
            var input = new DateTimeOffset(1970, 1, 1, 0, 0, seconds, TimeSpan.Zero);

            // Act
            var actual = input.ToIso8601Date();

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}