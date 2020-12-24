using System;
using System.Globalization;
using System.Threading;
using Atc.Helpers;
using Atc.Tests.XUnitTestData;
using FluentAssertions;
using Xunit;

namespace Atc.Tests.Helpers.Enums
{
    public class EnumHelperTests
    {
        [Theory]
        [InlineData("On", OnOffType.On)]
        [InlineData("Off", OnOffType.Off)]
        public void GetName(string expected, Enum input)
        {
            // Act
            var actual = EnumHelper.GetName(input);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("On", "On")]
        [InlineData("Off", "Off")]
        public void GetEnumValue_OnOffType(string expected, string input)
        {
            // Act
            var actual = EnumHelper.GetEnumValue<OnOffType>(input);

            // Assert
            Assert.Equal(expected, actual.ToString());
        }

        [Theory]
        [InlineData("On", "On", true)]
        [InlineData("Off", "Off", true)]
        [InlineData("On", "on", true)]
        [InlineData("Off", "off", true)]
        [InlineData("None", "on", false)]
        [InlineData("None", "off", false)]
        public void GetEnumValue_OnOffType_IgnoreCase(string expected, string input, bool ignoreCase)
        {
            // Act
            var actual = EnumHelper.GetEnumValue<OnOffType>(input, ignoreCase);

            // Assert
            Assert.Equal(expected, actual.ToString());
        }

        [Theory]
        [InlineData("Monday", DayOfWeek.Monday)]
        public void GetDescription(string expected, DayOfWeek value)
        {
            Assert.Equal(expected, EnumHelper.GetDescription(value));
        }

        [Theory]
        [InlineData(GlobalizationLcidConstants.Invariant, ForwardReverseType.Forward, "Forward")]
        [InlineData(GlobalizationLcidConstants.Invariant, ForwardReverseType.Forward, "forward")]
        [InlineData(GlobalizationLcidConstants.UnitedStates, ForwardReverseType.Forward, "Forward")]
        [InlineData(GlobalizationLcidConstants.UnitedStates, ForwardReverseType.Forward, "forward")]
        [InlineData(GlobalizationLcidConstants.Denmark, ForwardReverseType.Forward, "Fremad")]
        [InlineData(GlobalizationLcidConstants.Denmark, ForwardReverseType.Forward, "fremad")]
        public void GetValueFromDescription_ForwardReverseType(int arrangeUiLcid, ForwardReverseType expected, string input)
        {
            // Arrange
            if (arrangeUiLcid > 0)
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(arrangeUiLcid);
            }

            // Act
            var actual = EnumHelper.GetValueFromDescription<ForwardReverseType>(input);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForEnum.DayOfWeekData), MemberType = typeof(TestMemberDataForEnum))]
        public void ConvertEnumToArray<T>(
            T dummyForT,
            int expectedCount,
            DropDownFirstItemType dropDownFirstItemType,
            bool useDescriptionAttribute,
            bool includeDefault,
            SortDirectionType sortDirectionType,
            bool byFlagIncludeBase,
            bool byFlagIncludeCombined)
            where T : Enum
        {
            // Arrange
            var enumType = dummyForT.GetType();

            // Act
            var actual = EnumHelper.ConvertEnumToArray(
                enumType,
                dropDownFirstItemType,
                useDescriptionAttribute,
                includeDefault,
                sortDirectionType,
                byFlagIncludeBase,
                byFlagIncludeCombined);

            // Assert
            actual.Should().NotBeNull().And.HaveCount(expectedCount);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForEnum.DayOfWeekData), MemberType = typeof(TestMemberDataForEnum))]
        public void ConvertEnumToDictionary<T>(
            T dummyForT,
            int expectedCount,
            DropDownFirstItemType dropDownFirstItemType,
            bool useDescriptionAttribute,
            bool includeDefault,
            SortDirectionType sortDirectionType,
            bool byFlagIncludeBase,
            bool byFlagIncludeCombined)
            where T : Enum
        {
            // Arrange
            var enumType = dummyForT.GetType();

            // Act
            var actual = EnumHelper.ConvertEnumToDictionary(
                enumType,
                dropDownFirstItemType,
                useDescriptionAttribute,
                includeDefault,
                sortDirectionType,
                byFlagIncludeBase,
                byFlagIncludeCombined);

            // Assert
            actual.Should().NotBeNull().And.HaveCount(expectedCount);
        }

        [Theory]
        [MemberData(nameof(TestMemberDataForEnum.DayOfWeekData), MemberType = typeof(TestMemberDataForEnum))]
        public void ConvertEnumToDictionaryWithStringKey<T>(
            T dummyForT,
            int expectedCount,
            DropDownFirstItemType dropDownFirstItemType,
            bool useDescriptionAttribute,
            bool includeDefault,
            SortDirectionType sortDirectionType,
            bool byFlagIncludeBase,
            bool byFlagIncludeCombined)
            where T : Enum
        {
            // Arrange
            var enumType = dummyForT.GetType();

            // Act
            var actual = EnumHelper.ConvertEnumToDictionaryWithStringKey(
                enumType,
                dropDownFirstItemType,
                useDescriptionAttribute,
                includeDefault,
                sortDirectionType,
                byFlagIncludeBase,
                byFlagIncludeCombined);

            // Assert
            actual.Should().NotBeNull().And.HaveCount(expectedCount);
        }
    }
}