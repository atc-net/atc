using System;
using System.IO;
using System.Text;
using Xunit;

namespace Atc.Tests.Extensions
{
    public class MemoryStreamExtensionsTests
    {
        [Fact]
        public void ToBytes()
        {
            // Arrange
            var input = "Hallo world".ToStream() as MemoryStream;

            // Act
            var actual = input!.ToString(Encoding.UTF8);

            // Assert
            Assert.Equal("Hallo world", actual);
        }
    }
}