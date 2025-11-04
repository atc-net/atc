namespace Atc.CodeAnalysis.CSharp.Tests.SyntaxFactories;

public class SyntaxTokenFactoryTests
{
    [Fact]
    public void Token_Should_Create_Token_For_Given_SyntaxKind()
    {
        // Arrange
        const SyntaxKind syntaxKind = SyntaxKind.PublicKeyword;

        // Act
        var result = SyntaxTokenFactory.Token(syntaxKind);

        // Assert
        Assert.Equal(syntaxKind, result.Kind());
    }

    [Fact]
    public void TokenWithTrailingSpace_Should_Create_Token_With_Trailing_Space()
    {
        // Arrange
        const SyntaxKind syntaxKind = SyntaxKind.PublicKeyword;

        // Act
        var result = SyntaxTokenFactory.TokenWithTrailingSpace(syntaxKind);

        // Assert
        Assert.Equal(syntaxKind, result.Kind());
        Assert.NotEmpty(result.TrailingTrivia);
    }

    [Fact]
    public void TokenWithTrailing_Should_Create_Token_With_Trailing_Trivia()
    {
        // Arrange
        const SyntaxKind syntaxKind = SyntaxKind.PublicKeyword;
        var syntaxTrivia = SyntaxFactory.Space;

        // Act
        var result = SyntaxTokenFactory.TokenWithTrailing(syntaxKind, syntaxTrivia);

        // Assert
        Assert.Equal(syntaxKind, result.Kind());
        Assert.NotEmpty(result.TrailingTrivia);
        Assert.Single(result.TrailingTrivia, t => t.IsKind(SyntaxKind.WhitespaceTrivia));
    }
}