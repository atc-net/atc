using System;
using Xunit;

namespace Atc.Tests.Extensions.BaseTypes
{
    public class TimeSpanExtensionsTests
    {
        [Theory]
        [InlineData(true, 2, 3)]
        [InlineData(true, 3, 3)]
        [InlineData(false, 3, 2)]
        public void Min(bool expected, int seconds1, int seconds2)
        {
            // Arrange
            var ts1 = new TimeSpan(0, 0, seconds1);
            var ts2 = new TimeSpan(0, 0, seconds2);

            // Act
            var actual = ts1.Min(ts2);

            // Assert
            Assert.Equal(expected ? ts1 : ts2, actual);
        }

        [Theory]
        [InlineData(false, 2, 3)]
        [InlineData(false, 3, 3)]
        [InlineData(true, 3, 2)]
        public void Max(bool expected, int seconds1, int seconds2)
        {
            // Arrange
            var ts1 = new TimeSpan(0, 0, seconds1);
            var ts2 = new TimeSpan(0, 0, seconds2);

            // Act
            var actual = ts1.Max(ts2);

            // Assert
            Assert.Equal(expected ? ts1 : ts2, actual);
        }

        [Fact]
        public void RemoveMilliseconds()
        {
            // Arrange
            var expected = new TimeSpan(1, 1, 1, 1, 0);
            var input = new TimeSpan(1, 1, 1, 1, 123);

            // Act
            var actual = input.RemoveMilliseconds();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(true, 2)]
        [InlineData(false, 0)]
        public void SecondsNotZero(bool expected, int seconds)
        {
            // Arrange
            var input = new TimeSpan(0, 0, seconds);

            // Act
            var actual = input.SecondsNotZero();

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}