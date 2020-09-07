using System;
using System.Reflection;
using Xunit;

namespace Atc.Tests.Extensions.Reflection
{
    public class AssemblyExtensionsTests
    {
        [Fact]
        public void IsAssemblyDebugBuild()
        {
            // Act
            var actual = Assembly.GetExecutingAssembly().IsDebugBuild();

            // Assert
            Assert.True(actual);
        }

        [Theory]
        [InlineData(null, nameof(UnexpectedTypeException))]
        [InlineData(typeof(AssemblyExtensionsTests), nameof(AssemblyExtensionsTests))]
        public void GetExportedTypeByName(Type expected, string typeName)
        {
            // Arrange
            var assembly = Assembly.GetExecutingAssembly();

            // Act
            var actual = assembly.GetExportedTypeByName(typeName);

            // Assert
            if (expected == null)
            {
                Assert.Null(actual);
            }
            else
            {
                Assert.NotNull(actual);
                Assert.Equal(expected, actual);
            }
        }

        [Fact]
        public void GetPrettyName()
        {
            // Act
            var actual = Assembly.GetExecutingAssembly().GetBeautifiedName();

            // Assert
            Assert.NotNull(actual);
            Assert.Equal("Atc Tests", actual);
        }
    }
}