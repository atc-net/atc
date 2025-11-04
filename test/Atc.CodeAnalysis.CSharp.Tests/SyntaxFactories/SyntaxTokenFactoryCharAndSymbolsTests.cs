namespace Atc.CodeAnalysis.CSharp.Tests.SyntaxFactories;

public class SyntaxTokenFactoryCharAndSymbolsTests
{
    [Fact]
    public void LineFeed_Should_Create_LineFeed_Token()
    {
        // Act
        var result = SyntaxTokenFactory.LineFeed();

        // Assert
        Assert.NotEmpty(result.LeadingTrivia);
    }

    [Fact]
    public void CarriageReturnLineFeed_Should_Create_CRLF_Token()
    {
        // Act
        var result = SyntaxTokenFactory.CarriageReturnLineFeed();

        // Assert
        Assert.NotEmpty(result.LeadingTrivia);
    }

    [Fact]
    public void Comma_Should_Create_Comma_Token_With_Trailing_Space_By_Default()
    {
        // Act
        var result = SyntaxTokenFactory.Comma();

        // Assert
        Assert.Equal(SyntaxKind.CommaToken, result.Kind());
        Assert.NotEmpty(result.TrailingTrivia);
    }

    [Fact]
    public void Comma_Should_Create_Comma_Token_Without_Trailing_Space_When_False()
    {
        // Act
        var result = SyntaxTokenFactory.Comma(withTrailingSpace: false);

        // Assert
        Assert.Equal(SyntaxKind.CommaToken, result.Kind());
    }

    [Fact]
    public void Colon_Should_Create_Colon_Token_Without_Trailing_Space_By_Default()
    {
        // Act
        var result = SyntaxTokenFactory.Colon();

        // Assert
        Assert.Equal(SyntaxKind.ColonToken, result.Kind());
    }

    [Fact]
    public void Colon_Should_Create_Colon_Token_With_Trailing_Space_When_True()
    {
        // Act
        var result = SyntaxTokenFactory.Colon(withTrailingSpace: true);

        // Assert
        Assert.Equal(SyntaxKind.ColonToken, result.Kind());
        Assert.NotEmpty(result.TrailingTrivia);
    }

    [Fact]
    public void Semicolon_Should_Create_Semicolon_Token_Without_Trailing_Space_By_Default()
    {
        // Act
        var result = SyntaxTokenFactory.Semicolon();

        // Assert
        Assert.Equal(SyntaxKind.SemicolonToken, result.Kind());
    }

    [Fact]
    public void Semicolon_Should_Create_Semicolon_Token_With_Trailing_Space_When_True()
    {
        // Act
        var result = SyntaxTokenFactory.Semicolon(withTrailingSpace: true);

        // Assert
        Assert.Equal(SyntaxKind.SemicolonToken, result.Kind());
        Assert.NotEmpty(result.TrailingTrivia);
    }

    [Fact]
    public void Equals_Should_Create_Equals_Token_With_Trailing_Space_By_Default()
    {
        // Act
        var result = SyntaxTokenFactory.Equals();

        // Assert
        Assert.Equal(SyntaxKind.EqualsToken, result.Kind());
        Assert.NotEmpty(result.TrailingTrivia);
    }

    [Fact]
    public void Equals_Should_Create_Equals_Token_Without_Trailing_Space_When_False()
    {
        // Act
        var result = SyntaxTokenFactory.Equals(withTrailingSpace: false);

        // Assert
        Assert.Equal(SyntaxKind.EqualsToken, result.Kind());
    }

    [Fact]
    public void EqualsGreaterThan_Should_Create_EqualsGreaterThan_Token_With_Trailing_Space_By_Default()
    {
        // Act
        var result = SyntaxTokenFactory.EqualsGreaterThan();

        // Assert
        Assert.Equal(SyntaxKind.EqualsGreaterThanToken, result.Kind());
        Assert.NotEmpty(result.TrailingTrivia);
    }

    [Fact]
    public void EqualsGreaterThan_Should_Create_EqualsGreaterThan_Token_Without_Trailing_Space_When_False()
    {
        // Act
        var result = SyntaxTokenFactory.EqualsGreaterThan(withTrailingSpace: false);

        // Assert
        Assert.Equal(SyntaxKind.EqualsGreaterThanToken, result.Kind());
    }
}