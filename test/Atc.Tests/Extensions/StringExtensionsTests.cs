// ReSharper disable StringLiteralTypo
namespace Atc.Tests.Extensions;

[SuppressMessage("Performance", "CA1861:Avoid constant arrays as arguments", Justification = "OK.")]
public class StringExtensionsTests
{
    [Theory]
    [InlineData(new[] { 4, 7 }, "Hallo world", "o")]
    public void IndexersOf(int[] expected, string input, string pattern)
        => Assert.Equal(expected, input.IndexersOf(pattern));

    [Theory]
    [InlineData(new[] { 4, 7, 24 }, "Hallo world. Over the  top.", "o", false)]
    [InlineData(new[] { 4, 7, 13, 24 }, "Hallo world. Over the  top.", "o", true)]
    public void IndexersOf_IgnoreCaseSensitive(int[] expected, string input, string pattern, bool ignoreCaseSensitive)
        => Assert.Equal(expected, input.IndexersOf(pattern, ignoreCaseSensitive));

    [Theory]
    [InlineData(new[] { 4, 7, 24 }, "Hallo world. Over the  top.", "o", false, false)]
    [InlineData(new[] { 4, 7, 13, 24 }, "Hallo world. Over the  top.", "o", true, false)]
    [InlineData(new[] { 5, 8, 25 }, "Hallo world. Over the  top.", "o", false, true)]
    [InlineData(new[] { 5, 8, 14, 25 }, "Hallo world. Over the  top.", "o", true, true)]
    public void IndexersOf_IgnoreCaseSensitive_UseEndOfPatternToMatch(int[] expected, string input, string pattern, bool ignoreCaseSensitive, bool useEndOfPatternToMatch)
        => Assert.Equal(expected, input.IndexersOf(pattern, ignoreCaseSensitive, useEndOfPatternToMatch));

    [Theory]
    [InlineData(1, "Hallo-world")]
    [InlineData(2, "Hallo world")]
    [InlineData(2, "Hallo world .")]
    public void WordCount(int expected, string input)
        => Assert.Equal(expected, input.WordCount());

    [Theory]
    [InlineData(0, "Hallo world")]
    [InlineData(2, "Hest {0}, {1}")]
    [InlineData(-1, "Hest {0, {1}")]
    [InlineData(-1, "Hest {a}, {1}")]
    [InlineData(1, "Hest {0}, {0}")]
    [InlineData(-1, "Hest {{0}, {0}")]
    [InlineData(-1, "Hest {0{0}}, {0}")]
    [InlineData(-1, "Hest {{0}0}, {0}")]
    public void GetStringFormatParameterNumericCount(int expected, string input)
        => Assert.Equal(expected, input.GetStringFormatParameterNumericCount());

    [Theory]
    [InlineData(0, "Hallo world")]
    [InlineData(1, "Hest {a}")]
    [InlineData(1, "Hest {a} {a}")]
    [InlineData(2, "Hest {a} {A}")]
    [InlineData(2, "Hest {a} {b}")]
    [InlineData(-1, "Hest {a, {1}")]
    [InlineData(-1, "Hest {a}, {1}")]
    [InlineData(-1, "Hest {0}, {0}")]
    [InlineData(-1, "Hest {{a}, {0}")]
    [InlineData(-1, "Hest {a{a}}, {a}")]
    [InlineData(-1, "Hest {{a}a}, {a}")]
    public void GetStringFormatParameterLiteralCount(int expected, string input)
        => Assert.Equal(expected, input.GetStringFormatParameterLiteralCount());

    [Theory]
    [InlineData(new string[] { }, "Hallo World")]
    [InlineData(new string[] { }, "Hallo World {0}-{1}")]
    [InlineData(new[] { "{{0}}", "{{1}}", "{{A1}}" }, "Hallo World {{0}}-{{1}}-{{A1}}")]
    public void GetStringFormatParameterTemplatePlaceholders(string[] expected, string input)
        => Assert.Equal(expected, input.GetStringFormatParameterTemplatePlaceholders());

    [Theory]
    [InlineData("Hallo World John-Doe-42", "Hallo World {{0}}-{{1}}-{{A1}}", new[] { "0", "John", "1", "Doe", "A1", "42" })]
    [InlineData("Hallo World John-Doe-42", "Hallo World {{0}}-{{1}}-{{A1}}", new[] { "{{0}}", "John", "{{1}}", "Doe", "{{A1}}", "42" })]
    public void SetStringFormatParameterTemplatePlaceholders(string expected, string input, string[] data)
    {
        // Arrange
        var replacements = new Dictionary<string, string>(StringComparer.Ordinal);
        for (var i = 0; i < data.Length; i += 2)
        {
            replacements.Add(data[i], data[i + 1]);
        }

        // Act
        var actual = input.SetStringFormatParameterTemplatePlaceholders(replacements);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(false, "Hello, World!", TemplatePatternType.None)]
    [InlineData(true, "Hello [World]!", TemplatePatternType.SingleHardBrackets)]
    [InlineData(false, "Hello [World]!", TemplatePatternType.SingleCurlyBraces)]
    [InlineData(false, "Hello [World]!", TemplatePatternType.DoubleHardBrackets)]
    [InlineData(false, "Hello [World]!", TemplatePatternType.DoubleCurlyBraces)]
    [InlineData(true, "Hello [[World]]!", TemplatePatternType.DoubleHardBrackets)]
    [InlineData(false, "Hello {World}!", TemplatePatternType.DoubleCurlyBraces)]
    [InlineData(false, "Hello {World}!", TemplatePatternType.SingleHardBrackets)]
    [InlineData(true, "Hello {World}!", TemplatePatternType.SingleCurlyBraces)]
    [InlineData(false, "Hello {World}!", TemplatePatternType.DoubleHardBrackets)]
    [InlineData(false, "Hello {{World}}!", TemplatePatternType.DoubleHardBrackets)]
    [InlineData(true, "Hello {{World}}!", TemplatePatternType.DoubleCurlyBraces)]
    [InlineData(false, "Hello World!", TemplatePatternType.All)]
    [InlineData(true, "Hello [World]!", TemplatePatternType.All)]
    [InlineData(true, "Hello {World}!", TemplatePatternType.All)]
    [InlineData(true, "Hello [[World]]!", TemplatePatternType.All)]
    [InlineData(true, "Hello {{World}}!", TemplatePatternType.All)]
    public void ContainsTemplatePattern(bool expected, string input, TemplatePatternType patternType)
        => Assert.Equal(expected, input.ContainsTemplatePattern(patternType));

    [Theory]
    [InlineData(new[] { "[World]" }, "Hello [World]!", TemplatePatternType.SingleHardBrackets, true)]
    [InlineData(new[] { "World" }, "Hello [World]!", TemplatePatternType.SingleHardBrackets, false)]
    [InlineData(new[] { "[[World]]" }, "Hello [[World]]!", TemplatePatternType.DoubleHardBrackets, true)]
    [InlineData(new[] { "World" }, "Hello [[World]]!", TemplatePatternType.DoubleHardBrackets, false)]
    [InlineData(new[] { "[World]" }, "Hello [World]!", TemplatePatternType.HardBrackets, true)]
    [InlineData(new[] { "World" }, "Hello [World]!", TemplatePatternType.HardBrackets, false)]
    [InlineData(new[] { "[[World]]" }, "Hello [[World]]!", TemplatePatternType.HardBrackets, true)]
    [InlineData(new[] { "World" }, "Hello [[World]]!", TemplatePatternType.HardBrackets, false)]
    [InlineData(new[] { "[Hello]", "[World]" }, "[Hello] [World]!", TemplatePatternType.HardBrackets, true)]
    [InlineData(new[] { "Hello", "World" }, "[Hello] [World]!", TemplatePatternType.HardBrackets, false)]
    [InlineData(new[] { "{World}" }, "Hello {World}!", TemplatePatternType.SingleCurlyBraces, true)]
    [InlineData(new[] { "World" }, "Hello {World}!", TemplatePatternType.SingleCurlyBraces, false)]
    [InlineData(new[] { "{{World}}" }, "Hello {{World}}!", TemplatePatternType.DoubleCurlyBraces, true)]
    [InlineData(new[] { "World" }, "Hello {{World}}!", TemplatePatternType.DoubleCurlyBraces, false)]
    [InlineData(new[] { "{World}" }, "Hello {World}!", TemplatePatternType.CurlyBraces, true)]
    [InlineData(new[] { "World" }, "Hello {World}!", TemplatePatternType.CurlyBraces, false)]
    [InlineData(new[] { "{{World}}" }, "Hello {{World}}!", TemplatePatternType.CurlyBraces, true)]
    [InlineData(new[] { "World" }, "Hello {{World}}!", TemplatePatternType.CurlyBraces, false)]
    [InlineData(new[] { "{Hello}", "{World}" }, "{Hello} {World}!", TemplatePatternType.CurlyBraces, true)]
    [InlineData(new[] { "Hello", "World" }, "{Hello} {World}!", TemplatePatternType.CurlyBraces, false)]
    [InlineData(new[] { "[Hello]", "{World}" }, "[Hello] {World}!", TemplatePatternType.All, true)]
    [InlineData(new[] { "Hello", "World" }, "[Hello] {World}!", TemplatePatternType.All, false)]
    [InlineData(new[] { "[Hello]", "[[Hello2]]", "{World}", "{{World2}}" }, "[Hello] {World}! [[Hello2]] {{World2}}", TemplatePatternType.All, true)]
    [InlineData(new[] { "Hello", "Hello2", "World", "World2" }, "[Hello] {World}! [[Hello2]] {{World2}}", TemplatePatternType.All, false)]
    public void GetTemplateKeys(string[] expected, string input, TemplatePatternType patternType, bool includePattern)
        => Assert.Equal(expected, input.GetTemplateKeys(patternType, includePattern));

    [Theory]
    [InlineData("World", 2, "Hello [World] and [World] again.", TemplatePatternType.SingleHardBrackets, false)]
    [InlineData("[World]", 2, "Hello [World] and [World] again.", TemplatePatternType.SingleHardBrackets, true)]
    [InlineData("World", 2, "Hello {World} and {World} again.", TemplatePatternType.SingleCurlyBraces, false)]
    [InlineData("{World}", 2, "Hello {World} and {World} again.", TemplatePatternType.SingleCurlyBraces, true)]
    public void GetUniqueTemplateKeysWithOccurrence(
        string expectedString, int expectedCount, string input, TemplatePatternType patternType, bool includePattern)
    {
        // Act
        var result = input.GetUniqueTemplateKeysWithOccurrence(patternType, includePattern);

        // Assert
        Assert.NotNull(result);
        Assert.Single(result);
        Assert.Equal(expectedString, result.Keys.First());
        Assert.Equal(expectedCount, result.Values.First());
    }

    [Theory]
    [InlineData("Hello John!", "Hello [Name]!", "Name", "John", TemplatePatternType.SingleHardBrackets)]
    [InlineData("Hello [John]!", "Hello [[Name]]!", "Name", "John", TemplatePatternType.SingleHardBrackets)]
    [InlineData("Hello John!", "Hello [[Name]]!", "Name", "John", TemplatePatternType.DoubleHardBrackets)]
    [InlineData("Hello John!", "Hello [[Name]]!", "Name", "John", TemplatePatternType.HardBrackets)]
    [InlineData("Hello John!", "Hello {Name}!", "Name", "John", TemplatePatternType.SingleCurlyBraces)]
    [InlineData("Hello {John}!", "Hello {{Name}}!", "Name", "John", TemplatePatternType.SingleCurlyBraces)]
    [InlineData("Hello John!", "Hello {{Name}}!", "Name", "John", TemplatePatternType.DoubleCurlyBraces)]
    [InlineData("Hello John!", "Hello {{Name}}!", "Name", "John", TemplatePatternType.CurlyBraces)]
    [InlineData("Hello John John!", "Hello [[Name]] {{Name}}!", "Name", "John", TemplatePatternType.All)]
    public void ReplaceTemplateKeyWithValue(
        string expected, string input, string templateKey, string templateValue, TemplatePatternType patternType)
        => Assert.Equal(expected, input.ReplaceTemplateKeyWithValue(templateKey, templateValue, patternType));

    [Theory]
    [InlineData("Hello John", "Hello [FirstName]", TemplatePatternType.SingleHardBrackets)]
    [InlineData("Hello John Doe", "Hello [FirstName] [LastName]", TemplatePatternType.SingleHardBrackets)]
    [InlineData("Hello John Doe and 30!", "Hello [FirstName] [LastName] and [Age]!", TemplatePatternType.SingleHardBrackets)]
    [InlineData("Hello John", "Hello [[FirstName]]", TemplatePatternType.DoubleHardBrackets)]
    [InlineData("Hello John Doe", "Hello [[FirstName]] [[LastName]]", TemplatePatternType.DoubleHardBrackets)]
    [InlineData("Hello John Doe and 30!", "Hello [[FirstName]] [[LastName]] and [[Age]]!", TemplatePatternType.DoubleHardBrackets)]
    [InlineData("Hello [Name]", "Hello [Name]", TemplatePatternType.SingleHardBrackets)]
    [InlineData("Hello [[Name]]", "Hello [[Name]]", TemplatePatternType.DoubleHardBrackets)]
    [InlineData("Hello John", "Hello {FirstName}", TemplatePatternType.SingleCurlyBraces)]
    [InlineData("Hello John Doe", "Hello {FirstName} {LastName}", TemplatePatternType.SingleCurlyBraces)]
    [InlineData("Hello John Doe and 30!", "Hello {FirstName} {LastName} and {Age}!", TemplatePatternType.SingleCurlyBraces)]
    [InlineData("Hello John", "Hello {{FirstName}}", TemplatePatternType.DoubleCurlyBraces)]
    [InlineData("Hello John Doe", "Hello {{FirstName}} {{LastName}}", TemplatePatternType.DoubleCurlyBraces)]
    [InlineData("Hello John Doe and 30!", "Hello {{FirstName}} {{LastName}} and {{Age}}!", TemplatePatternType.DoubleCurlyBraces)]
    [InlineData("Hello {Name}", "Hello {Name}", TemplatePatternType.SingleCurlyBraces)]
    [InlineData("Hello {{Name}}", "Hello {{Name}}", TemplatePatternType.DoubleCurlyBraces)]
    public void ReplaceTemplateKeysWithValues(string expected, string input, TemplatePatternType patternType)
    {
        // Arrange
        var templateKeyValues = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            { "FirstName", "John" },
            { "LastName", "Doe" },
            { "Age", "30" },
        };

        // Act
        var result = input.ReplaceTemplateKeysWithValues(templateKeyValues, patternType);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("2000-12-01T23:47:37", "2000-12-01T23:47:37")]
    public void ParseDateFromIso8601(string expected, string input)
    {
        // Act
        var actual = input.ParseDateFromIso8601();

        // Assert
        Assert.Equal(expected, actual.ToIso8601Date());
    }

    [Theory]
    [InlineData(true, "2000-12-01T23:47:37")]
    [InlineData(false, "2000-12-01")]
    public void TryParseDateFromIso8601(bool expected, string input)
        => Assert.Equal(expected, input.TryParseDateFromIso8601(out var _));

    [Theory]
    [InlineData(true, "03-24-2000")]
    [InlineData(false, "24-03-2000")]
    public void TryParseDate(bool expected, string input)
        => Assert.Equal(expected, input.TryParseDate(out var _));

    [Theory]
    [InlineData(false, "03-24-2000")]
    [InlineData(true, "24-03-2000")]
    public void TryParseDate_DanishCultureCulture(bool expected, string input)
        => Assert.Equal(expected, input.TryParseDate(out var _, GlobalizationConstants.DanishCultureInfo));

    [Theory]
    [InlineData(false, "03-24-2000", DateTimeStyles.None)]
    [InlineData(true, "24-03-2000", DateTimeStyles.None)]
    public void TryParseDate_DanishCultureCulture_DateTimeStyles(bool expected, string input, DateTimeStyles dateTimeStyles)
        => Assert.Equal(expected, input.TryParseDate(out var _, GlobalizationConstants.DanishCultureInfo, dateTimeStyles));

    [Theory]
    [InlineData("", "")]
    [InlineData("Zg==", "f")]
    [InlineData("Zm8=", "fo")]
    [InlineData("Zm9v", "foo")]
    [InlineData("Zm9vYg==", "foob")]
    [InlineData("Zm9vYmE=", "fooba")]
    [InlineData("Zm9vYmFy", "foobar")]
    public void Base64Encode(string expected, string input)
    {
        // Act
        var actual = input.Base64Encode();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("", "")]
    [InlineData("Zg==", "f")]
    [InlineData("Zm8=", "fo")]
    [InlineData("Zm9v", "foo")]
    [InlineData("Zm9vYg==", "foob")]
    [InlineData("Zm9vYmE=", "fooba")]
    [InlineData("Zm9vYmFy", "foobar")]
    public void Base64Encode_EncodingOverload(string expected, string input)
    {
        // Act
        var actual = input.Base64Encode(Encoding.ASCII);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("", "")]
    [InlineData("f", "Zg==")]
    [InlineData("fo", "Zm8=")]
    [InlineData("foo", "Zm9v")]
    [InlineData("foob", "Zm9vYg==")]
    [InlineData("fooba", "Zm9vYmE=")]
    [InlineData("foobar", "Zm9vYmFy")]
    public void Base64Decode(string expected, string input)
    {
        // Act
        var actual = input.Base64Decode();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("", "")]
    [InlineData("f", "Zg==")]
    [InlineData("fo", "Zm8=")]
    [InlineData("foo", "Zm9v")]
    [InlineData("foob", "Zm9vYg==")]
    [InlineData("fooba", "Zm9vYmE=")]
    [InlineData("foobar", "Zm9vYmFy")]
    public void Base64Decode_EncodingOverload(string expected, string input)
    {
        // Act
        var actual = input.Base64Decode(Encoding.ASCII);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("<script>window.alert('Hallo')</script>", "<script>window.alert('Hallo')</script>", false)]
    [InlineData("&lt;script&gt;window.alert(&#39;Hallo&#39;)&lt;/script&gt;", "<script>window.alert('Hallo')</script>", true)]
    public void JavaScriptEncode(string expected, string input, bool htmlEncode)
        => Assert.Equal(expected, input.JavaScriptEncode(htmlEncode));

    [Theory]
    [InlineData("<script>window.alert('Hallo')</script>", "<script>window.alert('Hallo')</script>", false)]
    [InlineData("<script>window.alert('Hallo')</script>", "&lt;script&gt;window.alert(&#39;Hallo&#39;)&lt;/script&gt;", true)]
    public void JavaScriptDecode(string expected, string input, bool htmlDecode)
        => Assert.Equal(expected, input.JavaScriptDecode(htmlDecode));

    [Theory]
    [InlineData("&lt;root&gt;&lt;node name=&#39;TheName&#39;&gt;Hallo&lt;/node&gt;&lt;/root&gt;", "<root><node name='TheName'>Hallo</node></root>")]
    public void XmlEncode(string expected, string input)
        => Assert.Equal(expected, input.XmlEncode());

    [Theory]
    [InlineData("<root><node name='TheName'>Hallo</node></root>", "&lt;root&gt;&lt;node name=&#39;TheName&#39;&gt;Hallo&lt;/node&gt;&lt;/root&gt;")]
    public void XmlDecode(string expected, string input)
        => Assert.Equal(expected, input.XmlDecode());

    [Theory]
    [InlineData("abc", "abc")]
    [InlineData("abc", "bac")]
    [InlineData("Bac", "aBc")]
    [InlineData("Bac", "Bac")]
    public void Alphabetize(string expected, string input)
        => Assert.Equal(expected, input.Alphabetize());

    [Theory]
    [InlineData("abc", "&agrave;bc")]
    [InlineData("abc", "&aacute;bc")]
    [InlineData("abc", "&acirc;bc")]
    [InlineData("abc", "&atilde;bc")]
    [InlineData("abc", "&auml;bc")]
    public void NormalizeAccents(string expected, string input)
        => Assert.Equal(expected, input.NormalizeAccents());

    [Theory]
    [InlineData("abc", "&agrave;bc", LetterAccentType.Grave, true, true, true)]
    [InlineData("abc", "&aacute;bc", LetterAccentType.Acute, true, true, true)]
    [InlineData("abc", "&acirc;bc", LetterAccentType.Circumflex, true, true, true)]
    [InlineData("abc", "&atilde;bc", LetterAccentType.Tilde, true, true, true)]
    [InlineData("abc", "&auml;bc", LetterAccentType.Umlaut, true, true, true)]
    public void NormalizeAccents_LetterAccentType_LetterAccentType_Decode_ForLower_ForUpper(string expected, string input, LetterAccentType letterAccentType, bool decode, bool forLower, bool forUpper)
        => Assert.Equal(expected, input.NormalizeAccents(letterAccentType, decode, forLower, forUpper));

    [Theory]
    [InlineData("Hallo world", "HalloWorld")]
    [InlineData("Hallo_ world", "Hallo_World")]
    public void NormalizePascalCase(string expected, string input)
        => Assert.Equal(expected, input.NormalizePascalCase());

    [Theory]
    [InlineData("Hallo World", "HalloWorld")]
    [InlineData("Hallo World", "Hallo_World")]
    public void Humanize(string expected, string input)
        => Assert.Equal(expected, input.Humanize());

    [Theory]
    [InlineData("halloWorld", "HalloWorld")]
    [InlineData("hallo world", "Hallo world")]
    [InlineData("hallo World", "Hallo World")]
    public void CamelCase(string expected, string input)
        => Assert.Equal(expected, input.CamelCase());

    [Theory]
    [InlineData("HalloWorld", "halloWorld")]
    [InlineData("Hallo World", "hallo World")]
    [InlineData("Hallo World", "hallo world")]
    [InlineData("Hallo World-Yea", "HALLO WORLD-YeA")]
    public void PascalCase(string expected, string input)
        => Assert.Equal(expected, input.PascalCase());

    [Theory]
    [InlineData("HalloWorld", "halloWorld", false)]
    [InlineData("Hallo World", "hallo World", false)]
    [InlineData("Hallo World", "hallo world", false)]
    [InlineData("Hallo World-Yea", "HALLO WORLD-YeA", false)]
    [InlineData("HalloWorld", "halloWorld", true)]
    [InlineData("HalloWorld", "hallo World", true)]
    [InlineData("HalloWorld", "hallo world", true)]
    [InlineData("HalloWorldYea", "HALLO WORLD-YeA", true)]
    public void PascalCase_RemoveSeparators(string expected, string input, bool removeSeparators)
        => Assert.Equal(expected, input.PascalCase(removeSeparators));

    [Theory]
    [InlineData("HalloWorld", "halloWorld", new[] { ' ', '-' })]
    [InlineData("Hallo World", "hallo World", new[] { ' ', '-' })]
    [InlineData("Hallo World", "hallo world", new[] { ' ', '-' })]
    [InlineData("Hallo-World", "hallo-World", new[] { ' ', '-' })]
    [InlineData("Hallo-World", "hallo-world", new[] { ' ', '-' })]
    public void PascalCase_Separators(string expected, string input, char[] separators)
        => Assert.Equal(expected, input.PascalCase(separators));

    [Theory]
    [InlineData("HalloWorld", "halloWorld", new[] { ' ', '-' }, false)]
    [InlineData("Hallo World", "hallo World", new[] { ' ', '-' }, false)]
    [InlineData("Hallo World", "hallo world", new[] { ' ', '-' }, false)]
    [InlineData("Hallo-World", "hallo-World", new[] { ' ', '-' }, false)]
    [InlineData("Hallo-World", "hallo-world", new[] { ' ', '-' }, false)]
    [InlineData("HalloWorld", "halloWorld", new[] { ' ', '-' }, true)]
    [InlineData("HalloWorld", "hallo World", new[] { ' ', '-' }, true)]
    [InlineData("HalloWorld", "hallo world", new[] { ' ', '-' }, true)]
    [InlineData("HalloWorld", "hallo-World", new[] { ' ', '-' }, true)]
    [InlineData("HalloWorld", "hallo-world", new[] { ' ', '-' }, true)]
    public void PascalCase_Separators_RemoveSeparators(string expected, string input, char[] separators, bool removeSeparators)
        => Assert.Equal(expected, input.PascalCase(separators, removeSeparators));

    [Theory]
    [InlineData("Hallo{{NEWLINE}}World", "Hallo\r\nWorld")]
    [InlineData("Hallo{{NEWLINE}}World", "Hallo\nWorld")]
    [InlineData("Hallo{{NEWLINE}}World", "Hallo\rWorld")]
    [InlineData("Hallo{{NEWLINE}}World{{NEWLINE}}John{{NEWLINE}}Doe", "Hallo\r\nWorld\nJohn\rDoe")]
    public void EnsureEnvironmentNewLines(string expected, string input)
        => Assert.Equal(expected.Replace("{{NEWLINE}}", Environment.NewLine, StringComparison.Ordinal), input.EnsureEnvironmentNewLines());

    [Theory]
    [InlineData("Hallo", "hallo")]
    public void EnsureFirstCharacterToUpper(string expected, string input)
        => Assert.Equal(expected, input.EnsureFirstCharacterToUpper());

    [Theory]
    [InlineData("hallo", "Hallo")]
    public void EnsureFirstCharacterToLower(string expected, string input)
        => Assert.Equal(expected, input.EnsureFirstCharacterToLower());

    [Theory]
    [InlineData("hallo.", "hallo")]
    [InlineData("hallo:.", "hallo:")]
    [InlineData("hallo.", "hallo.")]
    public void EnsureEndsWithDot(string expected, string input)
        => Assert.Equal(expected, input.EnsureEndsWithDot());

    [Theory]
    [InlineData("hallo:", "hallo")]
    [InlineData("hallo.:", "hallo.")]
    [InlineData("hallo:", "hallo:")]
    public void EnsureEndsWithColon(string expected, string input)
        => Assert.Equal(expected, input.EnsureEndsWithColon());

    [Theory]
    [InlineData("Hallo", "Hallo")]
    [InlineData("Hallo", "Hallos")]
    public void EnsureSingular(string expected, string input)
        => Assert.Equal(expected, input.EnsureSingular());

    [Theory]
    [InlineData("Hallos", "Hallo")]
    [InlineData("Hallos", "Hallos")]
    public void EnsurePlural(string expected, string input)
        => Assert.Equal(expected, input.EnsurePlural());

    [Theory]
    [InlineData("Hallo", "hallo")]
    [InlineData("Hallo", "hallos")]
    public void EnsureFirstCharacterToUpperAndSingular(string expected, string input)
        => Assert.Equal(expected, input.EnsureFirstCharacterToUpperAndSingular());

    [Theory]
    [InlineData("Hallos", "hallo")]
    [InlineData("Hallos", "hallos")]
    public void EnsureFirstCharacterToUpperAndPlural(string expected, string input)
        => Assert.Equal(expected, input.EnsureFirstCharacterToUpperAndPlural());

    [Theory]
    [InlineData(false, "Hallo World", "world")]
    [InlineData(true, "Hallo World", "World")]
    public void Contains(bool expected, string inputA, string inputB)
        => Assert.Equal(expected, inputA.Contains(inputB, StringComparison.Ordinal));

    [Theory]
    [InlineData(false, "Hallo World", "world", false)]
    [InlineData(true, "Hallo World", "world", true)]
    public void Contains_IgnoreCaseSensitive(bool expected, string inputA, string inputB, bool ignoreCaseSensitive)
        => Assert.Equal(expected, inputA.Contains(inputB, ignoreCaseSensitive));

    [Theory]
    [InlineData(false, "Hallo World", new[] { 'w' }, false)]
    [InlineData(true, "Hallo World", new[] { 'W' }, true)]
    [InlineData(false, "Hallo World", new[] { 'h', 'w' }, false)]
    [InlineData(true, "Hallo World", new[] { 'h', 'w' }, true)]
    [InlineData(false, "Hallo World", new[] { 'h', 'w', 'b' }, false)]
    [InlineData(false, "Hallo World", new[] { 'h', 'W', 'b' }, true)]
    public void Contains_IgnoreCaseSensitive_MultipleChars(bool expected, string inputA, char[] inputB, bool ignoreCaseSensitive)
        => Assert.Equal(expected, inputA.Contains(inputB, ignoreCaseSensitive));

    [Theory]
    [InlineData(false, "Hallo World", new[] { "world" }, false)]
    [InlineData(true, "Hallo World", new[] { "World" }, true)]
    [InlineData(false, "Hallo World", new[] { "hallo", "world" }, false)]
    [InlineData(true, "Hallo World", new[] { "hallo", "World" }, true)]
    [InlineData(false, "Hallo World", new[] { "hallo", "world", "bob" }, false)]
    [InlineData(false, "Hallo World", new[] { "hallo", "World", "bob" }, true)]
    public void Contains_IgnoreCaseSensitive_MultipleStrings(bool expected, string inputA, string[] inputB, bool ignoreCaseSensitive)
        => Assert.Equal(expected, inputA.Contains(inputB, ignoreCaseSensitive));

    [Theory]
    [InlineData("Hallo Wo...", "Hallo World", 8)]
    [InlineData("Hallo World", "Hallo World", 20)]
    public void Cut(string expected, string input, int maxLength)
        => Assert.Equal(expected, input.Cut(maxLength));

    [Theory]
    [InlineData("Hallo Wo#", "Hallo World", 8, "#")]
    [InlineData("Hallo World", "Hallo World", 20, "#")]
    public void Cut_AppendValue(string expected, string input, int maxLength, string appendValue)
        => Assert.Equal(expected, input.Cut(maxLength, appendValue));

    [Theory]
    [InlineData("Hallo Wo#ld", "Hallo World", 8, '#')]
    public void ReplaceAt(string expected, string input, int index, char newChar)
        => Assert.Equal(expected, input.ReplaceAt(index, newChar));

    [Theory]
    [InlineData("Hallo World John-Doe-42", "Hallo World 0-1-2", new[] { "0", "John", "1", "Doe", "2", "42" })]
    [InlineData("Hallo World John-Doe-42", "Hallo World {{0}}-{{1}}-{{A1}}", new[] { "{{0}}", "John", "{{1}}", "Doe", "{{A1}}", "42" })]
    public void ReplaceMany_ReplacementsKeyValue(string expected, string input, string[] data)
    {
        // Arrange
        var replacements = new Dictionary<string, string>(StringComparer.Ordinal);
        for (var i = 0; i < data.Length; i += 2)
        {
            replacements.Add(data[i], data[i + 1]);
        }

        // Act
        var actual = input.ReplaceMany(replacements);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("H#ll# W#rld", "Hallo World", new[] { 'a', 'o' }, '#')]
    public void ReplaceMany_Chars(string expected, string input, char[] chars, char replacement)
        => Assert.Equal(expected, input.ReplaceMany(chars, replacement));

    [Theory]
    [InlineData("Hallo World", "Hallo\r\nWorld", " ")]
    [InlineData("Hallo World", "Hallo\nWorld", " ")]
    [InlineData("Hallo World", "Hallo\rWorld", " ")]
    [InlineData("Hallo World John Doe", "Hallo\r\nWorld\nJohn\rDoe", " ")]
    [InlineData("Hallo-World-John-Doe", "Hallo\r\nWorld\nJohn\rDoe", "-")]
    public void ReplaceNewLines(string expected, string input, string newValue)
        => Assert.Equal(expected, input.ReplaceNewLines(newValue));

    [Theory]
    [InlineData("HalloWorld", "Hallo\r\nWorld")]
    [InlineData("HalloWorld", "Hallo\nWorld")]
    [InlineData("HalloWorld", "Hallo\rWorld")]
    [InlineData("HalloWorldJohnDoe", "Hallo\r\nWorld\nJohn\rDoe")]
    public void RemoveNewLines(string expected, string input)
        => Assert.Equal(expected, input.RemoveNewLines());

    [Theory]
    [InlineData("llo World", "Hallo World", "Ha")]
    public void RemoveStart(string expected, string input, string startValue)
        => Assert.Equal(expected, input.RemoveStart(startValue));

    [Theory]
    [InlineData("Hallo World", "Hallo World", "HA", false)]
    [InlineData("llo World", "Hallo World", "HA", true)]
    public void RemoveStart_IgnoreCaseSensitive(string expected, string input, string startValue, bool ignoreCaseSensitive)
        => Assert.Equal(expected, input.RemoveStart(startValue, ignoreCaseSensitive));

    [Theory]
    [InlineData("Hallo Wor", "Hallo World", "ld")]
    public void RemoveEnd(string expected, string input, string endValue)
        => Assert.Equal(expected, input.RemoveEnd(endValue));

    [Theory]
    [InlineData("Hallo World", "Hallo World", "LD", false)]
    [InlineData("Hallo Wor", "Hallo World", "LD", true)]
    public void RemoveEnd_IgnoreCaseSensitive(string expected, string input, string endValue, bool ignoreCaseSensitive)
        => Assert.Equal(expected, input.RemoveEnd(endValue, ignoreCaseSensitive));

    [Theory]
    [InlineData("Hallo World", "Hallo World/")]
    public void RemoveEndingSlashIfExist(string expected, string input)
        => Assert.Equal(expected, input.RemoveEndingSlashIfExist());

    [Theory]
    [InlineData("Hallo World", "Hallo\u0006World")]
    public void RemoveDataCrap(string expected, string input)
        => Assert.Equal(expected, input.RemoveDataCrap());

    [Theory]
    [InlineData("HalloWorld", "Hallo\u0006World")]
    public void RemoveNonPrintableCharacter(string expected, string input)
        => Assert.Equal(expected, input.RemoveNonPrintableCharacter());

    [Theory]
    [InlineData("Hallo Wo...", "Hallo World", 8)]
    [InlineData("Hallo World", "Hallo World", 20)]
    public void Truncate(string expected, string input, int maxLength)
        => Assert.Equal(expected, input.Truncate(maxLength));

    [Theory]
    [InlineData("Hallo Wo#", "Hallo World", 8, "#")]
    [InlineData("Hallo World", "Hallo World", 20, "#")]
    public void Truncate_AppendValue(string expected, string input, int maxLength, string appendValue)
        => Assert.Equal(expected, input.Truncate(maxLength, appendValue));

    [Theory]
    [InlineData("Hallo World.", "   Hallo\tWorld..   ")]
    public void TrimSpecial(string expected, string input)
        => Assert.Equal(expected, input.TrimSpecial());

    [Theory]
    [InlineData("Hallo World", "Hallo World")]
    [InlineData("Hallo World", "  Hallo      World  ")]
    public void TrimExtended(string expected, string input)
        => Assert.Equal(expected, input.TrimExtended());

    [Theory]
    [InlineData(new string[0], null)]
    [InlineData(new[] { "Hallo", "World" }, "Hallo\r\nWorld")]
    public void ToLines(string[] expected, string input)
        => Assert.Equal(expected, input.ToLines());

    [Theory]
    [InlineData("MyData", "MyData")]
    [InlineData("MyData", "List<MyData>")]
    [InlineData("MyData", "Hallo world List<MyData> HalloFoo")]
    [InlineData("MyData Foo", "MyData Foo")]
    [InlineData("MyDataListFoo", "MyDataListFoo")]
    public void GetValueBetweenLessAndGreaterThanCharsIfExist(string expected, string input)
        => Assert.Equal(expected, input.GetValueBetweenLessAndGreaterThanCharsIfExist());

    [Fact]
    public void ToStream()
    {
        // Arrange
        const string input = "Hallo word";

        // Atc
        var actual = input.ToStream();

        // Assert
        Assert.NotNull(actual);
    }

    [Fact]
    public void ToStreamFromBase64()
    {
        // Arrange
        var input = "Hallo word".Base64Encode();

        // Atc
        var actual = input!.ToStreamFromBase64();

        // Assert
        Assert.NotNull(actual);
    }

    [Theory]
    [InlineData("OK", true, (int)HttpStatusCode.OK)]
    [InlineData("NotFound", true, (int)HttpStatusCode.NotFound)]
    [InlineData("BadRequest", true, (int)HttpStatusCode.BadRequest)]
    [InlineData("InternalServerError", true, (int)HttpStatusCode.InternalServerError)]
    [InlineData("InvalidStatusCode", false, 0)]
    [InlineData("", false, 0)]
    public void TryParseToHttpStatusCode(
        string input,
        bool expectedResult,
        int expectedStatusCodeAsInt)
    {
        // Arrange
        var expectedStatusCode = (HttpStatusCode)expectedStatusCodeAsInt;

        // Act
        var result = input.TryParseToHttpStatusCode(out var httpStatusCode);

        // Assert
        Assert.Equal(expectedResult, result);
        Assert.Equal(expectedStatusCode, httpStatusCode);
    }
}