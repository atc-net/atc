using System;
using System.Collections.Generic;
using System.Globalization;
using Atc.Extensions.BaseTypes;
using Xunit;

namespace Atc.Tests.Extensions
{
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
            var replacements = new Dictionary<string, string>();
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
            => Assert.Equal(expected, input.TryParseDateFromIso8601(out DateTime _));

        [Theory]
        [InlineData(true, "03-24-2000")]
        [InlineData(false, "24-03-2000")]
        public void TryParseDate(bool expected, string input)
            => Assert.Equal(expected, input.TryParseDate(out DateTime _));

        [Theory]
        [InlineData(false, "03-24-2000")]
        [InlineData(true, "24-03-2000")]
        public void TryParseDate_DanishCultureCulture(bool expected, string input)
            => Assert.Equal(expected, input.TryParseDate(out DateTime _, GlobalizationConstants.DanishCultureInfo));

        [Theory]
        [InlineData(false, "03-24-2000", DateTimeStyles.None)]
        [InlineData(true, "24-03-2000", DateTimeStyles.None)]
        public void TryParseDate_DanishCultureCulture_DateTimeStyles(bool expected, string input, DateTimeStyles dateTimeStyles)
            => Assert.Equal(expected, input.TryParseDate(out DateTime _, GlobalizationConstants.DanishCultureInfo, dateTimeStyles));

        [Theory]
        [InlineData("Hallo world")]
        public void Base64Encode(string input)
        {
            // Act
            string encodeData = input.Base64Encode();

            // Assert
            Assert.NotNull(encodeData);
        }

        [Theory]
        [InlineData("Hallo world")]
        public void Base64Decode(string input)
        {
            // Arrange
            string encodeData = input.Base64Encode();

            // Act
            string decodeData = encodeData!.Base64Decode();

            // Assert
            Assert.NotNull(decodeData);
            Assert.Equal(input.Length, decodeData.Length);
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
        [InlineData("abc", "&agrave;bc", LetterAccentTypes.Grave, true, true, true)]
        [InlineData("abc", "&aacute;bc", LetterAccentTypes.Acute, true, true, true)]
        [InlineData("abc", "&acirc;bc", LetterAccentTypes.Circumflex, true, true, true)]
        [InlineData("abc", "&atilde;bc", LetterAccentTypes.Tilde, true, true, true)]
        [InlineData("abc", "&auml;bc", LetterAccentTypes.Umlaut, true, true, true)]
        public void NormalizeAccents_LetterAccentType_LetterAccentType_Decode_ForLower_ForUpper(string expected, string input, LetterAccentTypes letterAccentType, bool decode, bool forLower, bool forUpper)
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
        public void PascalCase(string expected, string input)
            => Assert.Equal(expected, input.PascalCase());

        [Theory]
        [InlineData("HalloWorld", "halloWorld", false)]
        [InlineData("Hallo World", "hallo World", false)]
        [InlineData("Hallo World", "hallo world", false)]
        [InlineData("HalloWorld", "halloWorld", true)]
        [InlineData("HalloWorld", "hallo World", true)]
        [InlineData("HalloWorld", "hallo world", true)]
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
        [InlineData("Hallo", "hallo")]
        public void EnsureFirstCharacterToUpper(string expected, string input)
            => Assert.Equal(expected, input.EnsureFirstCharacterToUpper());

        [Theory]
        [InlineData("hallo", "Hallo")]
        public void EnsureFirstCharacterToLower(string expected, string input)
            => Assert.Equal(expected, input.EnsureFirstCharacterToLower());

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
            var replacements = new Dictionary<string, string>();
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
    }
}