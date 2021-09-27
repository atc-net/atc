using System.Reflection;
using Xunit;

namespace Atc.Rest.Extended.Tests.Extensions
{
    public class AssemblyExtensionsTests
    {
        [Fact]
        public void GetValidationTypes()
        {
            // Act
            var actual = Assembly.GetExecutingAssembly().GetValidationTypes();

            // Assert
            Assert.True(actual.Length == default);
        }
    }
}