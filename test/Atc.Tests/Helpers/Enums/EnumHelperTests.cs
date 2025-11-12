namespace Atc.Tests.Helpers.Enums;

public class EnumHelperTests
{
    [Theory]
    [InlineData("On", OnOffType.On)]
    [InlineData("Off", OnOffType.Off)]
    public void GetName(
        string expected,
        Enum input)
    {
        // Act
        var actual = EnumHelper.GetName(input);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("On", "On")]
    [InlineData("Off", "Off")]
    public void GetEnumValue_OnOffType(
        string expected,
        string input)
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
    public void GetEnumValue_OnOffType_IgnoreCase(
        string expected,
        string input,
        bool ignoreCase)
    {
        // Act
        var actual = EnumHelper.GetEnumValue<OnOffType>(input, ignoreCase);

        // Assert
        Assert.Equal(expected, actual.ToString());
    }

    [Theory]
    [InlineData("Monday", DayOfWeek.Monday)]
    public void GetDescription(
        string expected,
        DayOfWeek value)
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
    public void GetValueFromDescription_ForwardReverseType(
        int arrangeUiLcid,
        ForwardReverseType expected,
        string input)
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
    [MemberData(nameof(TestMemberDataForEnum.DayOfWeekData), MemberType = typeof(TestMemberDataForEnum), DisableDiscoveryEnumeration = true)]
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
        actual
            .Cast<string>()
            .Should().NotBeNull()
            .And.HaveCount(expectedCount);
    }

    [Theory]
    [MemberData(nameof(TestMemberDataForEnum.DayOfWeekData), MemberType = typeof(TestMemberDataForEnum), DisableDiscoveryEnumeration = true)]
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
        actual
            .Should().NotBeNull()
            .And.HaveCount(expectedCount);
    }

    [Theory]
    [MemberData(nameof(TestMemberDataForEnum.DayOfWeekData), MemberType = typeof(TestMemberDataForEnum), DisableDiscoveryEnumeration = true)]
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
        actual
            .Should().NotBeNull()
            .And.HaveCount(expectedCount);
    }

    [Theory]
    [InlineData(16, false)]
    [InlineData(17, true)]
    public void GetIndividualValues_CardinalDirectionType(
        int expected,
        bool includeDefault)
    {
        // Act
        var actual = EnumHelper.GetIndividualValues<CardinalDirectionType>(includeDefault);

        // Assert
        Assert.Equal(expected, actual.Count);
    }

    [Theory]
    [InlineData(16, false)]
    [InlineData(17, true)]
    public void GetIndividualValuesFromFlagEnum_CardinalDirectionType(
        int expected,
        bool includeDefault)
    {
        // Act
        var actual = EnumHelper.GetIndividualValuesFromFlagEnum<CardinalDirectionType>(includeDefault);

        // Assert
        Assert.Equal(expected, actual.Count);
    }

    [Theory]
    [InlineData(4, false, CardinalDirectionType.Simple)]
    [InlineData(5, true, CardinalDirectionType.Simple)]
    [InlineData(8, false, CardinalDirectionType.Medium)]
    [InlineData(9, true, CardinalDirectionType.Medium)]
    [InlineData(16, false, CardinalDirectionType.Advanced)]
    [InlineData(17, true, CardinalDirectionType.Advanced)]
    public void GetIndividualValuesByCombinedValueFromFlagEnum_CardinalDirectionType(
        int expected,
        bool includeDefault,
        CardinalDirectionType cardinalDirectionType)
    {
        // Act
        var actual = EnumHelper.GetIndividualValuesByCombinedValueFromFlagEnum(
            cardinalDirectionType,
            includeDefault);

        // Assert
        Assert.Equal(expected, actual.Count);
    }

    [Theory]
    [InlineData(6, false)]
    [InlineData(7, true)]
    public void GetIndividualValuesFromEnum_DayOfWeek(
        int expected,
        bool includeDefault)
    {
        // Act
        var actual = EnumHelper.GetIndividualValuesFromEnum<DayOfWeek>(includeDefault);

        // Assert
        Assert.Equal(expected, actual.Count);
    }
}