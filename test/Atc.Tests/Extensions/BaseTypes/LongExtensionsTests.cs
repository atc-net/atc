using System;
using Xunit;

namespace Atc.Tests.Extensions.BaseTypes
{
    public class LongExtensionsTests
    {
        [Theory]
        [InlineData(1, 0, 0, 0, 0)]
        [InlineData(1, 0, 0, 10, 10)]
        [InlineData(12, 13, 46, 40, 1000000)]
        public void FromUnixTime(int expectedDay, int expectedHour, int expectedMinute, int expectedSecond, long input)
        {
            // Arrange
            var expectedDateTimeOffset = new DateTimeOffset(1970, 1, expectedDay, expectedHour, expectedMinute, expectedSecond, new TimeSpan(0, 0, 0, 0, 0));

            // Act
            var actual = input.FromUnixTime();

            // Assert
            Assert.Equal(expectedDateTimeOffset, actual);
        }
    }
}