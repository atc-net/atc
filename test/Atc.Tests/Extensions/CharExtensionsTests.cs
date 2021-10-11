using System;
using Xunit;

namespace Atc.Tests.Extensions
{
    public class CharExtensionsTests
    {
        [Theory]
        [InlineData(true, 'a')]
        [InlineData(true, 'z')]
        [InlineData(true, 'A')]
        [InlineData(true, 'Z')]
        [InlineData(false, 'æ')]
        [InlineData(false, 'ø')]
        [InlineData(false, 'å')]
        [InlineData(false, 'Æ')]
        [InlineData(false, 'Ø')]
        [InlineData(false, 'Å')]
        public void IsAscii(bool expected, char input)
        {
            // Act
            var actual = input.IsAscii();

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}