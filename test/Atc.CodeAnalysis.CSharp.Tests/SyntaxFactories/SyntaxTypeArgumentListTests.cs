using Atc.CodeAnalysis.CSharp.SyntaxFactories;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Xunit;

namespace Atc.CodeAnalysis.CSharp.Tests.SyntaxFactories
{
    public class SyntaxTypeArgumentListTests
    {
        [Fact]
        public void CreateWithOneItem()
        {
            // Arrange
            var expected = SyntaxFactory.TypeArgumentList(
                SyntaxFactory.SingletonSeparatedList<TypeSyntax>(
                    SyntaxFactory.IdentifierName("int")));

            // Act
            var actual = SyntaxTypeArgumentListFactory.CreateWithOneItem("int");

            // Assert
            Assert.Equal(expected.ToFullString(), actual.ToFullString());
        }

        [Fact]
        public void CreateWithTwoItems()
        {
            // Arrange
            var expected = SyntaxFactory.TypeArgumentList(
                SyntaxFactory.SeparatedList<TypeSyntax>(
                    new SyntaxNodeOrToken[]
                    {
                        SyntaxFactory.IdentifierName("int"),
                        SyntaxFactory.Token(SyntaxTriviaList.Empty, SyntaxKind.CommaToken,  new SyntaxTriviaList(SyntaxFactory.Space)),
                        SyntaxFactory.IdentifierName("bool"),
                    }));

            // Act
            var actual = SyntaxTypeArgumentListFactory.CreateWithTwoItems("int", "bool");

            // Assert
            Assert.Equal(expected.ToFullString(), actual.ToFullString());
        }
    }
}