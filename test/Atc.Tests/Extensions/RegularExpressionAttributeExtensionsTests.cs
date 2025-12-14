namespace Atc.Tests.Extensions;

public class RegularExpressionAttributeExtensionsTests
{
    [Fact]
    public void GetEscapedPattern_NullAttribute_ThrowsArgumentNullException()
    {
        // Arrange
        RegularExpressionAttribute? sut = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => sut!.GetEscapedPattern());
    }

    [Theory]
    [InlineData("^[a-z]+$", "\"^[a-z]+$\"")]
    [InlineData("[0-9]{3}", "\"[0-9]{3}\"")]
    [InlineData("test", "\"test\"")]
    public void GetEscapedPattern_SimplePattern_WithEnsureQuotes_ReturnsQuotedPattern(
        string pattern,
        string expected)
    {
        // Arrange
        var sut = new RegularExpressionAttribute(pattern);

        // Act
        var actual = sut.GetEscapedPattern(ensureQuotes: true);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("^[a-z]+$", "^[a-z]+$")]
    [InlineData("[0-9]{3}", "[0-9]{3}")]
    [InlineData("test", "test")]
    public void GetEscapedPattern_SimplePattern_WithoutEnsureQuotes_ReturnsUnquotedPattern(
        string pattern,
        string expected)
    {
        // Arrange
        var sut = new RegularExpressionAttribute(pattern);

        // Act
        var actual = sut.GetEscapedPattern(ensureQuotes: false);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GetEscapedPattern_PatternWithBackslash_EscapesBackslash()
    {
        // Arrange
        var sut = new RegularExpressionAttribute(@"^\d+$");

        // Act
        var actual = sut.GetEscapedPattern(ensureQuotes: true);

        // Assert
        Assert.Equal(@"""^\\d+$""", actual);
    }

    [Fact]
    public void GetEscapedPattern_PatternWithDoubleBackslash_WithEnsureQuotes_WrapsInQuotes()
    {
        // Arrange
        var sut = new RegularExpressionAttribute(@"^\\d+$");

        // Act
        var actual = sut.GetEscapedPattern(ensureQuotes: true);

        // Assert
        Assert.Equal(@"""^\\d+$""", actual);
    }

    [Fact]
    public void GetEscapedPattern_PatternWithDoubleBackslash_WithoutEnsureQuotes_ReturnsAsIs()
    {
        // Arrange
        var sut = new RegularExpressionAttribute(@"^\\d+$");

        // Act
        var actual = sut.GetEscapedPattern(ensureQuotes: false);

        // Assert
        Assert.Equal(@"^\\d+$", actual);
    }

    [Fact]
    public void GetEscapedPattern_PatternAlreadyQuoted_DoesNotDoubleQuote()
    {
        // Arrange
        var sut = new RegularExpressionAttribute("\"^\\\\d+$\"");

        // Act
        var actual = sut.GetEscapedPattern(ensureQuotes: true);

        // Assert
        Assert.Equal("\"^\\\\d+$\"", actual);
    }

    [Fact]
    public void GetEscapedPattern_PatternWithQuoteCharacter_EscapesQuote()
    {
        // Arrange
        var sut = new RegularExpressionAttribute("test\"value");

        // Act
        var actual = sut.GetEscapedPattern(ensureQuotes: true);

        // Assert
        Assert.Equal("\"test\\\"value\"", actual);
    }

    [Fact]
    public void GetEscapedPattern_PatternWithNewline_EscapesNewline()
    {
        // Arrange
        var sut = new RegularExpressionAttribute("test\nvalue");

        // Act
        var actual = sut.GetEscapedPattern(ensureQuotes: true);

        // Assert
        Assert.Equal("\"test\\nvalue\"", actual);
    }

    [Fact]
    public void GetEscapedPattern_PatternWithCarriageReturn_EscapesCarriageReturn()
    {
        // Arrange
        var sut = new RegularExpressionAttribute("test\rvalue");

        // Act
        var actual = sut.GetEscapedPattern(ensureQuotes: true);

        // Assert
        Assert.Equal("\"test\\rvalue\"", actual);
    }

    [Fact]
    public void GetEscapedPattern_PatternWithTab_EscapesTab()
    {
        // Arrange
        var sut = new RegularExpressionAttribute("test\tvalue");

        // Act
        var actual = sut.GetEscapedPattern(ensureQuotes: true);

        // Assert
        Assert.Equal("\"test\\tvalue\"", actual);
    }

    [Fact]
    public void GetEscapedPattern_PatternWithNullChar_EscapesNullChar()
    {
        // Arrange
        var sut = new RegularExpressionAttribute("test\0value");

        // Act
        var actual = sut.GetEscapedPattern(ensureQuotes: true);

        // Assert
        Assert.Equal("\"test\\0value\"", actual);
    }

    [Fact]
    public void GetEscapedPattern_DefaultEnsureQuotes_IsTrue()
    {
        // Arrange
        var sut = new RegularExpressionAttribute("^test$");

        // Act
        var actual = sut.GetEscapedPattern();

        // Assert
        Assert.Equal("\"^test$\"", actual);
    }

    [Fact]
    public void GetEscapedPattern_EmptyPattern_ReturnsEmptyQuotedString()
    {
        // Arrange
        var sut = new RegularExpressionAttribute(string.Empty);

        // Act
        var actual = sut.GetEscapedPattern(ensureQuotes: true);

        // Assert
        Assert.Equal("\"\"", actual);
    }

    [Fact]
    public void GetEscapedPattern_EmptyPattern_WithoutQuotes_ReturnsEmptyString()
    {
        // Arrange
        var sut = new RegularExpressionAttribute(string.Empty);

        // Act
        var actual = sut.GetEscapedPattern(ensureQuotes: false);

        // Assert
        Assert.Equal(string.Empty, actual);
    }
}