namespace Atc.Tests.Helpers;

public class SearchQueryHelperTests
{
    private const string GuidText = "5b1eba26-8b25-f111-8341-7c1e52fbbe51";

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData(" , ")]
    [InlineData("\"\"")]
    [InlineData("\" , \"")]
    public void Parse_Blank_ReturnsNoTerms(string? search)
        => Assert.Empty(SearchQueryHelper.Parse(search));

    [Fact]
    public void Parse_Words_SplitsOnWhiteSpaceAndCommas()
    {
        // Act
        var actual = SearchQueryHelper.Parse("  Main Street\t8,7900  ");

        // Assert
        Assert.Equal(
            [
                new SearchTerm(SearchTermType.Word, "Main"),
                new SearchTerm(SearchTermType.Word, "Street"),
                new SearchTerm(SearchTermType.Word, "8"),
                new SearchTerm(SearchTermType.Word, "7900"),
            ],
            actual);
    }

    [Fact]
    public void Parse_QuotedText_IsOnePhrase()
    {
        // Act
        var actual = SearchQueryHelper.Parse("\"Main Street 8\"");

        // Assert
        Assert.Equal([new SearchTerm(SearchTermType.Phrase, "Main Street 8")], actual);
    }

    [Fact]
    public void Parse_PhraseAndWords_KeepTheirOrder()
    {
        // Act
        var actual = SearchQueryHelper.Parse("Springfield \"Main Street 8\" north");

        // Assert
        Assert.Equal(
            [
                new SearchTerm(SearchTermType.Word, "Springfield"),
                new SearchTerm(SearchTermType.Phrase, "Main Street 8"),
                new SearchTerm(SearchTermType.Word, "north"),
            ],
            actual);
    }

    [Fact]
    public void Parse_UnclosedQuote_RunsToTheEnd()
    {
        // Act
        var actual = SearchQueryHelper.Parse("Springfield \"Main Street 8");

        // Assert
        Assert.Equal(
            [
                new SearchTerm(SearchTermType.Word, "Springfield"),
                new SearchTerm(SearchTermType.Phrase, "Main Street 8"),
            ],
            actual);
    }

    [Fact]
    public void Parse_Phrase_FoldsSeparatorsAndWhiteSpaceIntoSingleSpaces()
    {
        // Act
        var actual = SearchQueryHelper.Parse("\"  Main   Street 8,  North-Side (B) \"");

        // Assert
        Assert.Equal([new SearchTerm(SearchTermType.Phrase, "Main Street 8 North Side B")], actual);
    }

    [Theory]
    [InlineData("5B1EBA26-8B25-F111-8341-7C1E52FBBE51")]
    [InlineData(GuidText)]
    [InlineData("\" " + GuidText + " \"")]
    public void Parse_FullGuid_IsAnIdentifierInLowerCase(string search)
        => Assert.Equal([new SearchTerm(SearchTermType.Identifier, GuidText)], SearchQueryHelper.Parse(search));

    [Fact]
    public void Parse_PartOfAGuid_IsAWord()
        => Assert.Equal([new SearchTerm(SearchTermType.Word, "5b1eba26")], SearchQueryHelper.Parse("5b1eba26"));

    [Fact]
    public void Parse_DetectGuidsOff_KeepsAGuidAsAWord()
    {
        // Arrange
        var options = new SearchQueryOptions { DetectGuids = false };

        // Act
        var actual = SearchQueryHelper.Parse(GuidText, options);

        // Assert
        Assert.Equal([new SearchTerm(SearchTermType.Word, GuidText)], actual);
    }

    [Fact]
    public void Parse_CustomSeparators_AreUsed()
    {
        // Arrange
        var options = new SearchQueryOptions
        {
            WordSeparators = [';'],
            PhraseSeparators = ['_'],
        };

        // Act
        var actual = SearchQueryHelper.Parse("alpha;beta,gamma \"one_two-three\"", options);

        // Assert
        Assert.Equal(
            [
                new SearchTerm(SearchTermType.Word, "alpha"),
                new SearchTerm(SearchTermType.Word, "beta,gamma"),
                new SearchTerm(SearchTermType.Phrase, "one two-three"),
            ],
            actual);
    }
}