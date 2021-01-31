using Atc.CodeAnalysis.CSharp.SyntaxFactories;
using Microsoft.CodeAnalysis.CSharp;
using Xunit;

namespace Atc.CodeAnalysis.CSharp.Tests.SyntaxFactories
{
    public class SyntaxSimpleBaseTypeFactoryTests
    {
        [Fact]
        public void Create()
        {
            // Arrange
            var expected = SyntaxFactory.SimpleBaseType(
                SyntaxFactory.ParseTypeName("int"));

            // Act
            var actual = SyntaxSimpleBaseTypeFactory.Create("int");

            // Assert
            Assert.Equal(expected.ToFullString(), actual.ToFullString());
        }
    }
}