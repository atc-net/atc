using System;
using Atc.Rest.Extended;
using Xunit;

namespace Atc.Rest.Tests.Extensions
{
    public class TypeExtensionsTests
    {
        [Fact]
        public void GetApiName()
        {
            // Act
            var actual = typeof(AtcRestExtendedAssemblyTypeInitializer).GetApiName();

            // Assert
            Assert.Equal("Atc Rest Extended", actual);
        }

        [Theory]
        [InlineData("Atc Rest Extended", false)]
        [InlineData("Atc Rest", true)]
        public void GetApiName_RemoveLastVerb(string expected, bool removeLastVerb)
        {
            // Act
            var actual = typeof(AtcRestExtendedAssemblyTypeInitializer).GetApiName(removeLastVerb);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}