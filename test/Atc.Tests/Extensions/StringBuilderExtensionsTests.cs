using System;
using System.Text;
using Xunit;

namespace Atc.Tests.Extensions
{
    public class StringBuilderExtensionsTests
    {
        [Theory]
        [InlineData("Hallo a, 88", "Hallo {0}, {1}", new object[] { "a", 88 })]
        public void Append(string expected, string format, params object[] args)
        {
            // Arrange
            var sb = new StringBuilder();

            // Act
            sb.Append(format, args);
            var actual = sb.ToString();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("Hallo a, 88", "Hallo {0}, {1}", new object[] { "a", 88 })]
        public void AppendLine(string expected, string format, params object[] args)
        {
            // Arrange
            var sb = new StringBuilder();

            // Act
            sb.AppendLine(format, args);
            var actual = sb.ToString();

            // Assert
            Assert.Equal(expected + Environment.NewLine, actual);
        }
    }
}