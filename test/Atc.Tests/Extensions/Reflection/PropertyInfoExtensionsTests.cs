using System;
using System.Linq;
using System.Reflection;
using Xunit;

namespace Atc.Tests.Extensions.Reflection
{
    public class PropertyInfoExtensionsTests
    {
        [Theory]
        [InlineData("string", typeof(UnexpectedTypeException))]
        public void BeautifyName(string expected, Type type)
        {
            // Arrange
            var propertyInfo = type.GetProperties().First(x => string.Equals(x.Name, "Message", StringComparison.Ordinal));

            // Act
            var actual = propertyInfo.BeautifyName();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("Message", typeof(UnexpectedTypeException))]
        public void GetName(string expected, Type type)
        {
            // Arrange
            var propertyInfo = type.GetProperties().First(x => string.Equals(x.Name, "Message", StringComparison.Ordinal));

            // Act
            var actual = propertyInfo.GetName();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("Message", typeof(UnexpectedTypeException))]
        public void GetDescription(string expected, Type type)
        {
            // Arrange
            var propertyInfo = type.GetProperties().First(x => string.Equals(x.Name, "Message", StringComparison.Ordinal));

            // Act
            var actual = propertyInfo.GetDescription();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("Message", typeof(UnexpectedTypeException), false)]
        [InlineData("Message", typeof(UnexpectedTypeException), true)]
        public void GetDescription_UseLocalizedIfPossible(string expected, Type type, bool useLocalizedIfPossible)
        {
            // Arrange
            var propertyInfo = type.GetProperties().First(x => string.Equals(x.Name, "Message", StringComparison.Ordinal));

            // Act
            var actual = propertyInfo.GetDescription(useLocalizedIfPossible);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}