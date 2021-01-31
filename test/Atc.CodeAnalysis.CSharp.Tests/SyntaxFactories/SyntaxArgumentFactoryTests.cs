using Atc.CodeAnalysis.CSharp.SyntaxFactories;
using Microsoft.CodeAnalysis.CSharp;
using Xunit;

namespace Atc.CodeAnalysis.CSharp.Tests.SyntaxFactories
{
    public class SyntaxArgumentFactoryTests
    {
        [Fact]
        public void CreateWithOneItem()
        {
            // Arrange
            var expected = SyntaxFactory.Argument(
                SyntaxFactory.IdentifierName("hallo"));

            // Act
            var actual = SyntaxArgumentFactory.Create("hallo");

            // Assert
            Assert.Equal(expected.ToFullString(), actual.ToFullString());
        }
    }
}