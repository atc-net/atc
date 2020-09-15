using System;
using System.IO;
using System.Text;
using Xunit;

// ReSharper disable ConvertToConstant.Local
namespace Atc.Tests.Extensions
{
    public class StreamExtensionsTests
    {
        [Fact]
        public void CopyToStream()
        {
            // Arrange
            var input = "Hallo world".ToStream();

            // Act
            var actual = input.CopyToStream();

            // Assert
            Assert.Equal("Hallo world", actual.ToStringData());
        }

        [Fact]
        public void CopyToStream_BufferSize()
        {
            // Arrange
            var input = "Hallo world".ToStream();
            var bufferSize = 1024;

            // Act
            var actual = input.CopyToStream(bufferSize);

            // Assert
            Assert.Equal("Hallo world", actual.ToStringData());
        }

        [Fact]
        public void ToBytes()
        {
            // Arrange
            var input = "Hallo world".ToStream();

            // Act
            var buffer = input.ToBytes();
            var actual = Encoding.UTF8.GetString(buffer, 0, buffer.Length);

            // Assert
            Assert.Equal("Hallo world", actual);
        }

        [Fact]
        public void ToStringData()
        {
            // Arrange
            var input = "Hallo world".ToStream();

            // Act
            var actual = input.ToStringData();

            // Assert
            Assert.Equal("Hallo world", actual);
        }
    }
}