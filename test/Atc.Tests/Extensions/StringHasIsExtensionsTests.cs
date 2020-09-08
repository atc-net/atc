using System;
using Xunit;

namespace Atc.Tests.Extensions
{
    public class StringHasIsExtensionsTests
    {
        [Theory]
        [InlineData(false, "John Doe")]
        [InlineData(true, "<b>John Doe</b>")]
        [InlineData(true, "John Doe<hr />")]
        [InlineData(true, "John Doe<div class='asd'>Cow<div>")]
        public void HasHtmlTags(bool expected, string input)
            => Assert.Equal(expected, input.HasHtmlTags());

        [Theory]
        [InlineData(true, "John Doe", "John Doe")]
        [InlineData(false, "John Doe", "John DOE")]
        public void IsEqual(bool expected, string inputA, string inputB)
            => Assert.Equal(expected, inputA.IsEqual(inputB));

        [Theory]
        [InlineData(false, "John Doe", "John DOE", StringComparison.Ordinal)]
        [InlineData(true, "John Doe", "John DOE", StringComparison.OrdinalIgnoreCase)]
        [InlineData(false, "Strasse", "Straße", StringComparison.OrdinalIgnoreCase)]
        [InlineData(true, "Strasse", "Straße", StringComparison.InvariantCultureIgnoreCase)]
        [InlineData(true, "Strasse", "Straße", StringComparison.CurrentCultureIgnoreCase)]
        public void IsEqual_StringComparison(bool expected, string inputA, string inputB, StringComparison comparison)
            => Assert.Equal(expected, inputA.IsEqual(inputB, comparison));

        [Theory]
        [InlineData(false, "", null, StringComparison.Ordinal, false)]
        [InlineData(true, "", null, StringComparison.Ordinal, true)]
        public void IsEqual_StringComparison_TreatNullAsEmpty(bool expected, string inputA, string inputB, StringComparison comparison, bool treatNullAsEmpty)
            => Assert.Equal(expected, inputA.IsEqual(inputB, comparison, treatNullAsEmpty));

        [Theory]
        [InlineData(false, "übersetzer", "ubersetzer", StringComparison.Ordinal, false, false)]
        [InlineData(true, "übersetzer", "ubersetzer", StringComparison.Ordinal, false, true)]
        public void IsEqual_StringComparison_TreatNullAsEmpty_UseNormalizeAccents(bool expected, string inputA, string inputB, StringComparison comparison, bool treatNullAsEmpty, bool useNormalizeAccents)
            => Assert.Equal(expected, inputA.IsEqual(inputB, comparison, treatNullAsEmpty, useNormalizeAccents));

        [Theory]
        [InlineData(true, "true")]
        [InlineData(true, "1")]
        [InlineData(true, "yes")]
        [InlineData(false, "false")]
        [InlineData(false, "0")]
        [InlineData(false, "no")]
        public void IsTrue(bool expected, string input)
            => Assert.Equal(expected, input.IsTrue());

        [Theory]
        [InlineData(false, "true")]
        [InlineData(false, "1")]
        [InlineData(false, "yes")]
        [InlineData(true, "false")]
        [InlineData(true, "0")]
        [InlineData(true, "no")]
        public void IsFalse(bool expected, string input)
            => Assert.Equal(expected, input.IsFalse());

        [Theory]
        [InlineData(true, "abc")]
        [InlineData(false, "123")]
        [InlineData(false, "abc123")]
        [InlineData(false, "abc123!#")]
        public void IsAlphaOnly(bool expected, string input)
            => Assert.Equal(expected, input.IsAlphaOnly());

        [Theory]
        [InlineData(true, "abc")]
        [InlineData(true, "123")]
        [InlineData(true, "abc123")]
        [InlineData(false, "abc123!#")]
        public void IsAlphaNumericOnly(bool expected, string input)
            => Assert.Equal(expected, input.IsAlphaNumericOnly());

        [Theory]
        [InlineData(true, "03-24-2000")]
        [InlineData(false, "24-03-2000")]
        public void IsDate(bool expected, string input)
            => Assert.Equal(expected, input.IsDate());

        [Theory]
        [InlineData(false, "03-24-2000")]
        [InlineData(true, "24-03-2000")]
        public void IsDate_DanishCultureCulture(bool expected, string input)
        {
            var danishCultureInfo = GlobalizationConstants.DanishCultureInfo;
            Assert.Equal(expected, input.IsDate(danishCultureInfo));
        }

        [Theory]
        [InlineData(false, "abc")]
        [InlineData(true, "123")]
        [InlineData(false, "abc123")]
        [InlineData(false, "abc123!#")]
        public void IsDigitOnly(bool expected, string input)
            => Assert.Equal(expected, input.IsDigitOnly());

        [Theory]
        [InlineData(false, "abc")]
        [InlineData(true, "{}")]
        public void IsFormatJson(bool expected, string input)
            => Assert.Equal(expected, input.IsFormatJson());

        [Theory]
        [InlineData(false, "abc")]
        [InlineData(true, "<root>abc</root>")]
        public void IsFormatXml(bool expected, string input)
            => Assert.Equal(expected, input.IsFormatXml());

        [Theory]
        [InlineData(false, "abc")]
        [InlineData(true, "77C01D96-EED4-491D-9A2A-D3A4067A55EC")]
        [InlineData(true, "{77C01D96-EED4-491D-9A2A-D3A4067A55EC}")]
        public void IsGuid(bool expected, string input)
            => Assert.Equal(expected, input.IsGuid());

        [Theory]
        [InlineData(false, "abc")]
        [InlineData(true, "77C01D96-EED4-491D-9A2A-D3A4067A55EC")]
        [InlineData(true, "{77C01D96-EED4-491D-9A2A-D3A4067A55EC}")]
        public void IsGuid_Out(bool expected, string input)
            => Assert.Equal(expected, input.IsGuid(out _));

        [Theory]
        [InlineData(false, "Hest gris")]
        [InlineData(true, "Hest")]
        [InlineData(false, "123")]
        [InlineData(false, "123 hest")]
        [InlineData(false, "hest 123")]
        [InlineData(true, "Hest123")]
        [InlineData(false, "123Hest")]
        [InlineData(true, "Hest_123")]
        [InlineData(false, "123_Hest")]
        public void IsKey(bool expected, string input)
            => Assert.Equal(expected, input.IsKey());

        [Theory]
        [InlineData(false, "")]
        [InlineData(false, "1")]
        [InlineData(true, "12")]
        [InlineData(false, "123")]
        [InlineData(true, "1234")]
        [InlineData(false, "12345")]
        public void IsLengthEven(bool expected, string input)
            => Assert.Equal(expected, input.IsLengthEven());

        [Theory]
        [InlineData(false, "abc")]
        [InlineData(true, "123")]
        [InlineData(false, "abc123")]
        [InlineData(false, "abc123!#")]
        public void IsNumericOnly(bool expected, string input)
            => Assert.Equal(expected, input.IsNumericOnly());

        [Theory]
        [InlineData(true, "Hest gris")]
        [InlineData(false, "Hest")]
        [InlineData(false, "123")]
        [InlineData(true, "123 hest")]
        [InlineData(true, "hest 123")]
        public void IsSentence(bool expected, string input)
            => Assert.Equal(expected, input.IsSentence());

        [Theory]
        [InlineData(true, "Hest {0}, {1}")]
        [InlineData(false, "Hest {0, {1}")]
        [InlineData(false, "Hest {a}, {1}")]
        [InlineData(true, "Hest {0}, {0}")]
        [InlineData(false, "Hest {{0}, {0}")]
        [InlineData(false, "Hest {0{0}}, {0}")]
        [InlineData(false, "Hest {{0}0}, {0}")]
        public void IsStringFormatParametersBalanced(bool expected, string input)
            => Assert.Equal(expected, input.IsStringFormatParametersBalanced());

        [Theory]
        [InlineData(true, "Hest {0}, {1}", false)]
        [InlineData(false, "Hest {0, {1}", false)]
        [InlineData(true, "Hest {a}, {1}", false)]
        [InlineData(true, "Hest {0}, {0}", false)]
        [InlineData(false, "Hest {{0}, {0}", false)]
        [InlineData(false, "Hest {0{0}}, {0}", false)]
        [InlineData(false, "Hest {{0}0}, {0}", false)]
        public void IsStringFormatParametersBalanced_IsNumeric(bool expected, string input, bool isNumeric)
            => Assert.Equal(expected, input.IsStringFormatParametersBalanced(isNumeric));

        [Theory]
        [InlineData(false, "Hest gris")]
        [InlineData(true, "Hest")]
        [InlineData(false, "123")]
        [InlineData(false, "123 hest")]
        [InlineData(false, "hest 123")]
        [InlineData(false, "Hest123")]
        [InlineData(false, "123Hest")]
        [InlineData(false, "Hest_123")]
        [InlineData(false, "123_Hest")]
        public void IsWord(bool expected, string input)
            => Assert.Equal(expected, input.IsWord());

        [Theory]
        [InlineData(false, "")]
        [InlineData(false, "1")]
        [InlineData(true, "hest")]
        [InlineData(false, "Hest")]
        public void IsFirstCharacterLowerCase(bool expected, string input)
            => Assert.Equal(expected, input.IsFirstCharacterLowerCase());

        [Theory]
        [InlineData(false, "")]
        [InlineData(false, "1")]
        [InlineData(false, "hest")]
        [InlineData(true, "Hest")]
        public void IsFirstCharacterUpperCase(bool expected, string input)
            => Assert.Equal(expected, input.IsFirstCharacterUpperCase());

        [Theory]
        [InlineData(false, "Hest")]
        [InlineData(false, "2675972")]
        [InlineData(true, "26759722")]
        public void IsCompanyCvrNumber(bool expected, string input)
            => Assert.Equal(expected, input.IsCompanyCvrNumber());

        [Theory]
        [InlineData(false, "Hest")]
        [InlineData(false, "101342617")]
        [InlineData(true, "1013426178")]
        public void IsCompanyPNumber(bool expected, string input)
            => Assert.Equal(expected, input.IsCompanyPNumber());

        [Theory]
        [InlineData(false, "Hest")]
        [InlineData(false, "240300-7260")]
        [InlineData(true, "240300-7261")]
        public void IsPersonCprNumber(bool expected, string input)
            => Assert.Equal(expected, input.IsPersonCprNumber());

        [Theory]
        [InlineData(false, "Hest")]
        [InlineData(false, "Hest@gris")]
        [InlineData(true, "Hest@gris.dk")]
        public void IsEmailAddress(bool expected, string input)
            => Assert.Equal(expected, input.IsEmailAddress());
    }
}