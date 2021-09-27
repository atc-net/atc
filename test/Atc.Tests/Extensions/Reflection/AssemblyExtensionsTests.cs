using System;
using System.Reflection;
using Atc.Data.Models;
using FluentAssertions;
using Xunit;

namespace Atc.Tests.Extensions.Reflection
{
    public class AssemblyExtensionsTests
    {
        [Fact]
        public void IsDebugBuild()
        {
            // Act
            var actual = Assembly.GetExecutingAssembly().IsDebugBuild();

            // Assert
#if DEBUG
            Assert.True(actual);
#else
            Assert.False(actual);
#endif
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
            if (expected is null)
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
        public void GetBeautifiedName()
        {
            // Act
            var actual = Assembly.GetExecutingAssembly().GetBeautifiedName();

            // Assert
            Assert.NotNull(actual);
            Assert.Equal("Atc Tests", actual);
        }

        [Fact]
        public void GetTypesInheritingFromType()
        {
            // Arrange
            var assembly = typeof(KeyValueItem).Assembly;
            var type = typeof(KeyValueItem);

            // Act
            var types = assembly.GetTypesInheritingFromType(type);

            // Assert
            types
                .Should()
                .NotBeNull()
                .And
                .HaveCountGreaterOrEqualTo(1);
        }
    }
}