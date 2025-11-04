namespace Atc.CodeAnalysis.CSharp.Tests.SyntaxFactories;

public class SyntaxInterpolatedFactoryTests
{
    [Fact]
    public void StringText_Should_Create_Interpolated_String_Text()
    {
        // Arrange
        const string value = "Test value";

        // Act
        var result = SyntaxInterpolatedFactory.StringText(value);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<InterpolatedStringTextSyntax>(result);
        var textSyntax = (InterpolatedStringTextSyntax)result;
        Assert.Equal(value, textSyntax.TextToken.Text, StringComparer.Ordinal);
    }

    [Fact]
    public void StringTextColon_Should_Create_Colon_Text()
    {
        // Act
        var result = SyntaxInterpolatedFactory.StringTextColon();

        // Assert
        Assert.NotNull(result);
        Assert.IsType<InterpolatedStringTextSyntax>(result);
        var textSyntax = (InterpolatedStringTextSyntax)result;
        Assert.Equal(": ", textSyntax.TextToken.Text, StringComparer.Ordinal);
    }

    [Fact]
    public void StringTextComma_Should_Create_Comma_Text()
    {
        // Act
        var result = SyntaxInterpolatedFactory.StringTextComma();

        // Assert
        Assert.NotNull(result);
        Assert.IsType<InterpolatedStringTextSyntax>(result);
        var textSyntax = (InterpolatedStringTextSyntax)result;
        Assert.Equal(", ", textSyntax.TextToken.Text, StringComparer.Ordinal);
    }

    [Fact]
    public void StringTextDotCountColon_Should_Create_DotCount_Text()
    {
        // Act
        var result = SyntaxInterpolatedFactory.StringTextDotCountColon();

        // Assert
        Assert.NotNull(result);
        Assert.IsType<InterpolatedStringTextSyntax>(result);
        var textSyntax = (InterpolatedStringTextSyntax)result;
        Assert.Equal(".Count: ", textSyntax.TextToken.Text, StringComparer.Ordinal);
    }

    [Fact]
    public void StringTextColonAndParenthesesStart_Should_Create_ColonParentheses_Text()
    {
        // Act
        var result = SyntaxInterpolatedFactory.StringTextColonAndParenthesesStart();

        // Assert
        Assert.NotNull(result);
        Assert.IsType<InterpolatedStringTextSyntax>(result);
        var textSyntax = (InterpolatedStringTextSyntax)result;
        Assert.Equal(": (", textSyntax.TextToken.Text, StringComparer.Ordinal);
    }

    [Fact]
    public void StringTextParenthesesEnd_Should_Create_Parentheses_End_Text()
    {
        // Act
        var result = SyntaxInterpolatedFactory.StringTextParenthesesEnd();

        // Assert
        Assert.NotNull(result);
        Assert.IsType<InterpolatedStringTextSyntax>(result);
        var textSyntax = (InterpolatedStringTextSyntax)result;
        Assert.Equal(")", textSyntax.TextToken.Text, StringComparer.Ordinal);
    }

    [Fact]
    public void CreateNameOf_Should_Create_NameOf_Interpolation()
    {
        // Arrange
        const string argumentName = "testArgument";

        // Act
        var result = SyntaxInterpolatedFactory.CreateNameOf(argumentName);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<InterpolationSyntax>(result);
        var interpolation = (InterpolationSyntax)result;
        Assert.NotNull(interpolation.Expression);
        var code = interpolation.ToString();
        Assert.Contains("nameof", code, StringComparison.Ordinal);
        Assert.Contains(argumentName, code, StringComparison.Ordinal);
    }
}