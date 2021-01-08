using System;
using System.Collections.Generic;
using System.Linq;
using Atc.Data.Models;
using Atc.Helpers;
using Atc.Tests.XUnitTestData;
using FluentAssertions;
using Xunit;

namespace Atc.Tests.Helpers
{
    public class CultureHelperTests
    {
        [Theory]
        [InlineData(200)]
        public void GetCultures(int expectedAtLeast)
        {
            // Act
            var actual = CultureHelper.GetCultures();

            // Assert
            actual.Should().NotBeNull()
                .And.BeOfType<List<Culture>>()
                .And.HaveCountGreaterThan(expectedAtLeast - 1);
        }

        [Theory]
        [InlineData(2, new[] { 1030, 1033 })]
        public void GetCultures_IncludeOnlyLcids(int expected, int[] input)
        {
            // Arrange
            var inputList = input.ToList();

            // Act
            var actual = CultureHelper.GetCultures(inputList);

            // Assert
            actual.Should().NotBeNull()
                .And.BeOfType<List<Culture>>()
                .And.HaveCount(expected);
        }

        [Theory]
        [InlineData(2, new[] { "da-DK", "en-US" })]
        public void GetCultures_IncludeOnlyCultureNames(int expected, string[] input)
        {
            // Arrange
            var inputList = input.ToList();

            // Act
            var actual = CultureHelper.GetCultures(inputList);

            // Assert
            actual.Should().NotBeNull()
                .And.BeOfType<List<Culture>>()
                .And.HaveCount(expected);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForCultureHelper.GetCulturesDisplayLanguageLcidIncludeOnlyLcidsData), MemberType = typeof(TestMemberDataForCultureHelper))]
        public void GetCultures_DisplayLanguageLcid_IncludeOnlyLcids(int expectedCount, string[] expectedCountryNames, string[] expectedLanguageNames, int displayLanguageLcid, int[] includeOnlyLcids)
        {
            // Arrange
            var inputList = includeOnlyLcids.ToList();

            // Act
            var actual = CultureHelper.GetCultures(displayLanguageLcid, inputList);

            // Assert
            actual.Should().NotBeNull()
                .And.BeOfType<List<Culture>>()
                .And.HaveCount(expectedCount);

            var countryNames = actual.Select(x => x.CountryDisplayName).ToArray();
            countryNames.Should().Equal(expectedCountryNames);

            var languageNames = actual.Select(x => x.LanguageDisplayName).ToArray();
            languageNames.Should().Equal(expectedLanguageNames);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForCultureHelper.GetCulturesDisplayLanguageLcidIncludeOnlyCultureNamesData), MemberType = typeof(TestMemberDataForCultureHelper))]
        public void GetCultures_DisplayLanguageLcid_IncludeCultureNames(int expectedCount, string[] expectedCountryNames, string[] expectedLanguageNames, int displayLanguageLcid, string[] includeOnlyCultureNames)
        {
            // Arrange
            var inputList = includeOnlyCultureNames.ToList();

            // Act
            var actual = CultureHelper.GetCultures(displayLanguageLcid, inputList);

            // Assert
            actual.Should().NotBeNull()
                .And.BeOfType<List<Culture>>()
                .And.HaveCount(expectedCount);

            var countryNames = actual.Select(x => x.CountryDisplayName).ToArray();
            countryNames.Should().Equal(expectedCountryNames);

            var languageNames = actual.Select(x => x.LanguageDisplayName).ToArray();
            languageNames.Should().Equal(expectedLanguageNames);
        }

        [Theory]
        [InlineData(200, GlobalizationLcidConstants.UnitedStates)]
        public void GetCultures_DisplayLanguageLcid(int expectedAtLeast, int displayLanguageLcid)
        {
            // Act
            var actual = CultureHelper.GetCultures(displayLanguageLcid);

            // Assert
            actual.Should().NotBeNull()
                .And.BeOfType<List<Culture>>()
                .And.HaveCountGreaterThan(expectedAtLeast - 1);
        }

        [Theory]
        [InlineData(100)]
        public void GetCulturesForCountries(int expected)
        {
            // Act
            var actual = CultureHelper.GetCulturesForCountries();

            // Assert
            actual.Should().NotBeNull()
                .And.BeOfType<List<Culture>>()
                .And.HaveCountGreaterThan(expected);
        }

        [Theory]
        [InlineData("US", GlobalizationLcidConstants.UnitedStates)]
        [InlineData("GB", GlobalizationLcidConstants.GreatBritain)]
        [InlineData("DK", GlobalizationLcidConstants.Denmark)]
        [InlineData("DE", GlobalizationLcidConstants.Germany)]
        public void GetCultureByLcid(string expected, int input)
        {
            // Act
            var actual = CultureHelper.GetCultureByLcid(input);

            // Assert
            actual.Should().NotBeNull()
                .And.BeOfType<Culture>();
            Assert.Equal(expected, actual!.CountryCodeA2);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForCultureHelper.GetCultureByLcidDisplayLanguageLcidData), MemberType = typeof(TestMemberDataForCultureHelper))]
        public void GetCultureByLcid_DisplayLanguageLcid(string expectedCountryName, string expectedLanguageName, int input, int displayLanguageLcid)
        {
            // Act
            var actual = CultureHelper.GetCultureByLcid(displayLanguageLcid, input);

            // Assert
            actual.Should().NotBeNull()
                .And.BeOfType<Culture>();
            Assert.Equal(expectedCountryName, actual!.CountryDisplayName);
            Assert.Equal(expectedLanguageName, actual.LanguageDisplayName);
        }

        [Theory]
        [InlineData(GlobalizationLcidConstants.UnitedStates, "US")]
        [InlineData(GlobalizationLcidConstants.GreatBritain, "GB")]
        [InlineData(GlobalizationLcidConstants.Denmark, "DK")]
        [InlineData(GlobalizationLcidConstants.Germany, "DE")]
        public void GetCultureByCountryCodeA2(int expected, string input)
        {
            // Act
            var actual = CultureHelper.GetCultureByCountryCodeA2(input);

            // Assert
            actual.Should().NotBeNull()
                .And.BeOfType<Culture>();
            Assert.Equal(expected, actual!.Lcid);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForCultureHelper.GetCultureByCountryCodeA2LcidDisplayLanguageLcidData), MemberType = typeof(TestMemberDataForCultureHelper))]
        public void GetCultureByCountryCodeA2_DisplayLanguageLcid(string expectedCountryName, string expectedLanguageName, string input, int displayLanguageLcid)
        {
            // Act
            var actual = CultureHelper.GetCultureByCountryCodeA2(displayLanguageLcid, input);

            // Assert
            actual.Should().NotBeNull()
                .And.BeOfType<Culture>();
            Assert.Equal(expectedCountryName, actual!.CountryDisplayName);
            Assert.Equal(expectedLanguageName, actual.LanguageDisplayName);
        }

        [Theory]
        [InlineData(4, "us")]
        [InlineData(1, "dk")]
        [InlineData(0, "en")]
        [InlineData(0, "da")]
        public void GetCulturesByCountryCodeA2(int expected, string input)
        {
            // Act
            var actual = CultureHelper.GetCulturesByCountryCodeA2(input);

            // Assert
            if ("us".Equals(input, StringComparison.Ordinal))
            {
                actual.Should().NotBeNull()
                    .And.BeOfType<List<Culture>>()
                    .And.HaveCountGreaterOrEqualTo(expected - 1);
            }
            else
            {
                actual.Should().NotBeNull()
                    .And.BeOfType<List<Culture>>()
                    .And.HaveCount(expected);
            }
        }

        [Theory]
        [InlineData(4, GlobalizationLcidConstants.UnitedStates, "us")]
        [InlineData(1, GlobalizationLcidConstants.UnitedStates, "dk")]
        [InlineData(0, GlobalizationLcidConstants.UnitedStates, "en")]
        [InlineData(0, GlobalizationLcidConstants.UnitedStates, "da")]
        public void GetCulturesByCountryCodeA2_DisplayLanguageLcid(int expected, int displayLanguageLcid, string input)
        {
            // Act
            var actual = CultureHelper.GetCulturesByCountryCodeA2(displayLanguageLcid, input);

            // Assert
            if ("us".Equals(input, StringComparison.Ordinal))
            {
                actual.Should().NotBeNull()
                    .And.BeOfType<List<Culture>>()
                    .And.HaveCountGreaterOrEqualTo(expected - 1);
            }
            else
            {
                actual.Should().NotBeNull()
                    .And.BeOfType<List<Culture>>()
                    .And.HaveCount(expected);
            }
        }

        [Theory]
        [InlineData(0, "us")]
        [InlineData(0, "dk")]
        [InlineData(17, "en")]
        [InlineData(1, "da")]
        public void GetCulturesByLanguageCodeA2(int expected, string input)
        {
            // Act
            var actual = CultureHelper.GetCulturesByLanguageCodeA2(input);

            // Assert
            if (string.Equals(input, "en", StringComparison.Ordinal))
            {
                actual.Should().NotBeNull()
                    .And.BeOfType<List<Culture>>()
                    .And.HaveCountGreaterOrEqualTo(expected - 1);
            }
            else
            {
                actual.Should().NotBeNull()
                    .And.BeOfType<List<Culture>>()
                    .And.HaveCount(expected);
            }
        }

        [Theory]
        [InlineData(0, GlobalizationLcidConstants.UnitedStates, "us")]
        [InlineData(0, GlobalizationLcidConstants.UnitedStates, "dk")]
        [InlineData(17, GlobalizationLcidConstants.UnitedStates, "en")]
        [InlineData(1, GlobalizationLcidConstants.UnitedStates, "da")]
        public void GetCulturesByLanguageCodeA2_DisplayLanguageLcid(int expected, int displayLanguageLcid, string input)
        {
            // Act
            var actual = CultureHelper.GetCulturesByLanguageCodeA2(displayLanguageLcid, input);

            // Assert
            if (string.Equals(input, "en", StringComparison.Ordinal))
            {
                actual.Should().NotBeNull()
                    .And.BeOfType<List<Culture>>()
                    .And.HaveCountGreaterOrEqualTo(expected - 1);
            }
            else
            {
                actual.Should().NotBeNull()
                    .And.BeOfType<List<Culture>>()
                    .And.HaveCount(expected);
            }
        }

        [Theory]
        [InlineData(GlobalizationLcidConstants.UnitedStates, "US")]
        [InlineData(GlobalizationLcidConstants.GreatBritain, "GB")]
        [InlineData(GlobalizationLcidConstants.Denmark, "DK")]
        [InlineData(GlobalizationLcidConstants.Germany, "DE")]
        public void GetCultureFromValue(int expected, string input)
        {
            // Act
            var actual = CultureHelper.GetCultureFromValue(input);

            // Assert
            actual.Should().NotBeNull()
                .And.BeOfType<Culture>();
            Assert.Equal(expected, actual!.Lcid);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForCultureHelper.GetCultureFromValueDisplayLanguageLcidData), MemberType = typeof(TestMemberDataForCultureHelper), DisableDiscoveryEnumeration = true)]
        public void GetCultureFromValue_DisplayLanguageLcid(string expectedCountryName, string expectedLanguageName, string input, int displayLanguageLcid)
        {
            // Act
            var actual = CultureHelper.GetCultureFromValue(displayLanguageLcid, input);

            // Assert
            actual.Should().NotBeNull()
                .And.BeOfType<Culture>();
            Assert.Equal(expectedCountryName, actual!.CountryDisplayName);
            Assert.Equal(expectedLanguageName, actual.LanguageDisplayName);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForCultureHelper.GetCultureFromValueDisplayLanguageLcidIncludeLcidsData), MemberType = typeof(TestMemberDataForCultureHelper), DisableDiscoveryEnumeration = true)]
        public void GetCultureFromValue_DisplayLanguageLcid_IncludeLcids(string expectedCountryName, string expectedLanguageName, string input, int[] includeLcids, int displayLanguageLcid)
        {
            // Arrange
            var inputList = includeLcids.ToList();

            // Act
            var actual = CultureHelper.GetCultureFromValue(displayLanguageLcid, inputList, input);

            // Assert
            actual.Should().NotBeNull()
                .And.BeOfType<Culture>();
            Assert.Equal(expectedCountryName, actual!.CountryDisplayName);
            Assert.Equal(expectedLanguageName, actual.LanguageDisplayName);
        }

        [Theory]
        [InlineData(200)]
        public void GetCountryNames_Base(int expectedAtLeast)
        {
            // Act
            var actual = CultureHelper.GetCountryNames();

            // Assert
            actual.Should().NotBeNull()
                .And.BeOfType<Dictionary<int, string>>()
                .And.HaveCountGreaterThan(expectedAtLeast - 1);
        }

        [Theory]
        [InlineData(0, DropDownFirstItemType.None)]
        [InlineData(1, DropDownFirstItemType.Blank)]
        [InlineData(1, DropDownFirstItemType.PleaseSelect)]
        [InlineData(1, DropDownFirstItemType.IncludeAll)]
        public void GetCountryNames(int expectedExtraOnCultureCount, DropDownFirstItemType input)
        {
            // Arrange
            var culturesCount = CultureHelper.GetCultures().Count;

            // Act
            var actual = CultureHelper.GetCountryNames(input);

            // Assert
            actual.Should().NotBeNull()
                .And.BeOfType<Dictionary<int, string>>()
                .And.HaveCount(culturesCount + expectedExtraOnCultureCount);
        }

        [Theory]
        [InlineData(0, DropDownFirstItemType.None, GlobalizationLcidConstants.UnitedStates)]
        [InlineData(1, DropDownFirstItemType.Blank, GlobalizationLcidConstants.UnitedStates)]
        [InlineData(1, DropDownFirstItemType.PleaseSelect, GlobalizationLcidConstants.UnitedStates)]
        [InlineData(1, DropDownFirstItemType.IncludeAll, GlobalizationLcidConstants.UnitedStates)]
        public void GetCountryNames_DisplayLanguageLcid(int expectedExtraOnCultureCount, DropDownFirstItemType dropDownFirstItemType, int displayLanguageLcid)
        {
            // Arrange
            var culturesCount = CultureHelper.GetCultures().Count;

            // Act
            var actual = CultureHelper.GetCountryNames(displayLanguageLcid, dropDownFirstItemType);

            // Assert
            actual.Should().NotBeNull()
                .And.BeOfType<Dictionary<int, string>>()
                .And.HaveCount(culturesCount + expectedExtraOnCultureCount);
        }

        [Theory]
        [InlineData(4, DropDownFirstItemType.None, new[] { 1030, 1031, 1033, 2057 })]
        [InlineData(5, DropDownFirstItemType.Blank, new[] { 1030, 1031, 1033, 2057 })]
        [InlineData(5, DropDownFirstItemType.PleaseSelect, new[] { 1030, 1031, 1033, 2057 })]
        [InlineData(5, DropDownFirstItemType.IncludeAll, new[] { 1030, 1031, 1033, 2057 })]
        public void GetCountryNames_IncludeOnlyLcids(int expected, DropDownFirstItemType dropDownFirstItemType, int[] includeLcids)
        {
            // Arrange
            var inputList = includeLcids.ToList();

            // Act
            var actual = CultureHelper.GetCountryNames(inputList, dropDownFirstItemType);

            // Assert
            actual.Should().NotBeNull()
                .And.BeOfType<Dictionary<int, string>>()
                .And.HaveCount(expected);
        }

        [Theory]
        [InlineData(4, DropDownFirstItemType.None, GlobalizationLcidConstants.UnitedStates, new[] { 1030, 1031, 1033, 2057 })]
        [InlineData(5, DropDownFirstItemType.Blank, GlobalizationLcidConstants.UnitedStates, new[] { 1030, 1031, 1033, 2057 })]
        [InlineData(5, DropDownFirstItemType.PleaseSelect, GlobalizationLcidConstants.UnitedStates, new[] { 1030, 1031, 1033, 2057 })]
        [InlineData(5, DropDownFirstItemType.IncludeAll, GlobalizationLcidConstants.UnitedStates, new[] { 1030, 1031, 1033, 2057 })]
        public void GetCountryNames_DisplayLanguageLcid_IncludeOnlyLcids(int expected, DropDownFirstItemType dropDownFirstItemType, int displayLanguageLcid, int[] includeLcids)
        {
            // Arrange
            var inputList = includeLcids.ToList();

            // Act
            var actual = CultureHelper.GetCountryNames(displayLanguageLcid, inputList, dropDownFirstItemType);

            // Assert
            actual.Should().NotBeNull()
                .And.BeOfType<Dictionary<int, string>>()
                .And.HaveCount(expected);
        }

        [Theory]
        [InlineData(4, DropDownFirstItemType.None, new[] { "en-US", "en-GB", "da-DK", "de-DE" })]
        [InlineData(5, DropDownFirstItemType.Blank, new[] { "en-US", "en-GB", "da-DK", "de-DE" })]
        [InlineData(5, DropDownFirstItemType.PleaseSelect, new[] { "en-US", "en-GB", "da-DK", "de-DE" })]
        [InlineData(5, DropDownFirstItemType.IncludeAll, new[] { "en-US", "en-GB", "da-DK", "de-DE" })]
        public void GetCountryNames_IncludeOnlyNames(int expected, DropDownFirstItemType dropDownFirstItemType, string[] includeNames)
        {
            // Arrange
            var inputList = includeNames.ToList();

            // Act
            var actual = CultureHelper.GetCountryNames(inputList, dropDownFirstItemType);

            // Assert
            actual.Should().NotBeNull()
                .And.BeOfType<Dictionary<int, string>>()
                .And.HaveCount(expected);
        }

        [Theory]
        [InlineData(4, DropDownFirstItemType.None, GlobalizationLcidConstants.UnitedStates, new[] { "en-US", "en-GB", "da-DK", "de-DE" })]
        [InlineData(5, DropDownFirstItemType.Blank, GlobalizationLcidConstants.UnitedStates, new[] { "en-US", "en-GB", "da-DK", "de-DE" })]
        [InlineData(5, DropDownFirstItemType.PleaseSelect, GlobalizationLcidConstants.UnitedStates, new[] { "en-US", "en-GB", "da-DK", "de-DE" })]
        [InlineData(5, DropDownFirstItemType.IncludeAll, GlobalizationLcidConstants.UnitedStates, new[] { "en-US", "en-GB", "da-DK", "de-DE" })]
        public void GetCountryNames_DisplayLanguageLcid_IncludeOnlyNames(int expected, DropDownFirstItemType dropDownFirstItemType, int displayLanguageLcid, string[] includeNames)
        {
            // Arrange
            var inputList = includeNames.ToList();

            // Act
            var actual = CultureHelper.GetCountryNames(displayLanguageLcid, inputList, dropDownFirstItemType);

            // Assert
            actual.Should().NotBeNull()
                .And.BeOfType<Dictionary<int, string>>()
                .And.HaveCount(expected);
        }

        [Theory]
        [InlineData(200)]
        public void GetLanguageNames_Base(int expectedAtLeast)
        {
            // Act
            var actual = CultureHelper.GetLanguageNames();

            // Assert
            actual.Should().NotBeNull()
                .And.BeOfType<Dictionary<int, string>>()
                .And.HaveCountGreaterThan(expectedAtLeast - 1);
        }

        [Theory]
        [InlineData(0, DropDownFirstItemType.None)]
        [InlineData(1, DropDownFirstItemType.Blank)]
        [InlineData(1, DropDownFirstItemType.PleaseSelect)]
        [InlineData(1, DropDownFirstItemType.IncludeAll)]
        public void GetLanguageNames(int expectedExtraOnCultureCount, DropDownFirstItemType input)
        {
            // Arrange
            var culturesCount = CultureHelper.GetCultures().Count;

            // Act
            var actual = CultureHelper.GetLanguageNames(input);

            // Assert
            actual.Should().NotBeNull()
                .And.BeOfType<Dictionary<int, string>>()
                .And.HaveCount(culturesCount + expectedExtraOnCultureCount);
        }

        [Theory]
        [InlineData(0, DropDownFirstItemType.None, GlobalizationLcidConstants.UnitedStates)]
        [InlineData(1, DropDownFirstItemType.Blank, GlobalizationLcidConstants.UnitedStates)]
        [InlineData(1, DropDownFirstItemType.PleaseSelect, GlobalizationLcidConstants.UnitedStates)]
        [InlineData(1, DropDownFirstItemType.IncludeAll, GlobalizationLcidConstants.UnitedStates)]
        public void GetLanguageNames_DisplayLanguageLcid(int expectedExtraOnCultureCount, DropDownFirstItemType dropDownFirstItemType, int displayLanguageLcid)
        {
            // Arrange
            var culturesCount = CultureHelper.GetCultures().Count;

            // Act
            var actual = CultureHelper.GetLanguageNames(displayLanguageLcid, dropDownFirstItemType);

            // Assert
            actual.Should().NotBeNull()
                .And.BeOfType<Dictionary<int, string>>()
                .And.HaveCount(culturesCount + expectedExtraOnCultureCount);
        }

        [Theory]
        [InlineData(4, DropDownFirstItemType.None, new[] { 1030, 1031, 1033, 2057 })]
        [InlineData(5, DropDownFirstItemType.Blank, new[] { 1030, 1031, 1033, 2057 })]
        [InlineData(5, DropDownFirstItemType.PleaseSelect, new[] { 1030, 1031, 1033, 2057 })]
        [InlineData(5, DropDownFirstItemType.IncludeAll, new[] { 1030, 1031, 1033, 2057 })]
        public void GetLanguageNames_IncludeOnlyLcids(int expected, DropDownFirstItemType dropDownFirstItemType, int[] includeLcids)
        {
            // Arrange
            var inputList = includeLcids.ToList();

            // Act
            var actual = CultureHelper.GetLanguageNames(inputList, dropDownFirstItemType);

            // Assert
            actual.Should().NotBeNull()
                .And.BeOfType<Dictionary<int, string>>()
                .And.HaveCount(expected);
        }

        [Theory]
        [InlineData(4, DropDownFirstItemType.None, GlobalizationLcidConstants.UnitedStates, new[] { 1030, 1031, 1033, 2057 })]
        [InlineData(5, DropDownFirstItemType.Blank, GlobalizationLcidConstants.UnitedStates, new[] { 1030, 1031, 1033, 2057 })]
        [InlineData(5, DropDownFirstItemType.PleaseSelect, GlobalizationLcidConstants.UnitedStates, new[] { 1030, 1031, 1033, 2057 })]
        [InlineData(5, DropDownFirstItemType.IncludeAll, GlobalizationLcidConstants.UnitedStates, new[] { 1030, 1031, 1033, 2057 })]
        public void GetLanguageNames_DisplayLanguageLcid_IncludeOnlyLcids(int expected, DropDownFirstItemType dropDownFirstItemType, int displayLanguageLcid, int[] includeLcids)
        {
            // Arrange
            var inputList = includeLcids.ToList();

            // Act
            var actual = CultureHelper.GetLanguageNames(displayLanguageLcid, inputList, dropDownFirstItemType);

            // Assert
            actual.Should().NotBeNull()
                .And.BeOfType<Dictionary<int, string>>()
                .And.HaveCount(expected);
        }

        [Theory]
        [InlineData(4, DropDownFirstItemType.None, new[] { "en-US", "en-GB", "da-DK", "de-DE" })]
        [InlineData(5, DropDownFirstItemType.Blank, new[] { "en-US", "en-GB", "da-DK", "de-DE" })]
        [InlineData(5, DropDownFirstItemType.PleaseSelect, new[] { "en-US", "en-GB", "da-DK", "de-DE" })]
        [InlineData(5, DropDownFirstItemType.IncludeAll, new[] { "en-US", "en-GB", "da-DK", "de-DE" })]
        public void GetLanguageNames_IncludeOnlyNames(int expected, DropDownFirstItemType dropDownFirstItemType, string[] includeNames)
        {
            // Arrange
            var inputList = includeNames.ToList();

            // Act
            var actual = CultureHelper.GetLanguageNames(inputList, dropDownFirstItemType);

            // Assert
            actual.Should().NotBeNull()
                .And.BeOfType<Dictionary<int, string>>()
                .And.HaveCount(expected);
        }

        [Theory]
        [InlineData(4, DropDownFirstItemType.None, GlobalizationLcidConstants.UnitedStates, new[] { "en-US", "en-GB", "da-DK", "de-DE" })]
        [InlineData(5, DropDownFirstItemType.Blank, GlobalizationLcidConstants.UnitedStates, new[] { "en-US", "en-GB", "da-DK", "de-DE" })]
        [InlineData(5, DropDownFirstItemType.PleaseSelect, GlobalizationLcidConstants.UnitedStates, new[] { "en-US", "en-GB", "da-DK", "de-DE" })]
        [InlineData(5, DropDownFirstItemType.IncludeAll, GlobalizationLcidConstants.UnitedStates, new[] { "en-US", "en-GB", "da-DK", "de-DE" })]
        public void GetLanguageNames_DisplayLanguageLcid_IncludeOnlyNames(int expected, DropDownFirstItemType dropDownFirstItemType, int displayLanguageLcid, string[] includeNames)
        {
            // Arrange
            var inputList = includeNames.ToList();

            // Act
            var actual = CultureHelper.GetLanguageNames(displayLanguageLcid, inputList, dropDownFirstItemType);

            // Assert
            actual.Should().NotBeNull()
                .And.BeOfType<Dictionary<int, string>>()
                .And.HaveCount(expected);
        }

        [Theory]
        [InlineData(0, GlobalizationLcidConstants.UnitedStates, new[] { 1030, 1031, 1033, 2057 })]
        public void GetCultureLcidsWhereCountryIsNotTranslated_DisplayLanguageLcid_IncludeOnlyLcids(int expected, int displayLanguageLcid, int[] includeLcids)
        {
            // Arrange
            var inputList = includeLcids.ToList();

            // Act
            var actual = CultureHelper.GetCultureLcidsWhereCountryIsNotTranslated(displayLanguageLcid, inputList);

            // Assert
            actual.Should().NotBeNull()
                .And.BeOfType<List<int>>()
                .And.HaveCount(expected);
        }

        [Theory]
        [InlineData(0, GlobalizationLcidConstants.UnitedStates, new[] { 1030, 1031, 1033, 2057 })]
        public void GetCultureLcidsWhereLanguageIsNotTranslated_DisplayLanguageLcid_IncludeOnlyLcids(int expected, int displayLanguageLcid, int[] includeLcids)
        {
            // Arrange
            var inputList = includeLcids.ToList();

            // Act
            var actual = CultureHelper.GetCultureLcidsWhereLanguageIsNotTranslated(displayLanguageLcid, inputList);

            // Assert
            actual.Should().NotBeNull()
                .And.BeOfType<List<int>>()
                .And.HaveCount(expected);
        }
    }
}