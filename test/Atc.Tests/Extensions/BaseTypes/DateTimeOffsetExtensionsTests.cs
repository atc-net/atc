using System;
using Xunit;

namespace Atc.Tests.Extensions.BaseTypes
{
    public class DateTimeOffsetExtensionsTests
    {
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