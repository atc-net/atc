namespace Atc.Tests.Helpers;

public class CSharpKeywordHelperTests
{
    [Fact]
    public void ReservedKeywords_HasTheReservedKeywords()
    {
        var keywords = CSharpKeywordHelper.ReservedKeywords;

        Assert.Equal(81, keywords.Count);
        Assert.Contains("class", keywords, StringComparer.Ordinal);
        Assert.Contains("__arglist", keywords, StringComparer.Ordinal);
        Assert.DoesNotContain("var", keywords, StringComparer.Ordinal);
    }

    [Theory]
    [InlineData(true, "class")]
    [InlineData(true, "event")]
    [InlineData(true, "__arglist")]
    [InlineData(true, "__refvalue")]
    [InlineData(false, "Class")]
    [InlineData(false, "var")]
    [InlineData(false, "record")]
    [InlineData(false, "pet")]
    [InlineData(false, "")]
    [InlineData(false, null)]
    public void IsReservedKeyword(
        bool expected,
        string? name)
        => Assert.Equal(expected, CSharpKeywordHelper.IsReservedKeyword(name));

    [Theory]
    [InlineData("@event", "event")]
    [InlineData("@public", "public")]
    [InlineData("pets", "pets")]
    [InlineData("Public", "Public")]
    public void EscapeIfReservedKeyword(
        string expected,
        string name)
        => Assert.Equal(expected, CSharpKeywordHelper.EscapeIfReservedKeyword(name));

    [Theory]
    [InlineData(true, "pet")]
    [InlineData(true, "_pet")]
    [InlineData(true, "Pet2")]
    [InlineData(true, "æble")]
    [InlineData(false, "2pet")]
    [InlineData(false, "pet-store")]
    [InlineData(false, "pet store")]
    [InlineData(false, "class")]
    [InlineData(false, "__arglist")]
    [InlineData(false, "@class")]
    [InlineData(false, "")]
    [InlineData(false, null)]
    public void IsValidIdentifier(
        bool expected,
        string? name)
        => Assert.Equal(expected, CSharpKeywordHelper.IsValidIdentifier(name));

    [Theory]
    [InlineData("Header2fa", "2fa")]
    [InlineData("Header", "")]
    [InlineData("Header-x", "-x")]
    [InlineData("fa2", "fa2")]
    [InlineData("_fa", "_fa")]
    public void EnsureIdentifierStart(
        string expected,
        string name)
        => Assert.Equal(expected, CSharpKeywordHelper.EnsureIdentifierStart(name, "Header"));

    [Fact]
    public void EnsureIdentifierStart_NullName_Throws()
        => Assert.Throws<ArgumentNullException>(() => CSharpKeywordHelper.EnsureIdentifierStart(null!, "Header"));
}