[assembly: CollectionBehavior(CollectionBehavior.CollectionPerAssembly)]

namespace Atc.Tests;

public class EnumTests
{
    [Theory]
    [InlineData(DayOfWeek.Monday, "Monday")]
    [InlineData(DayOfWeek.Monday, "MONDAY")]
    public void GetEnumValue(DayOfWeek expected, string value)
    {
        Assert.Equal(expected, Enum<DayOfWeek>.GetEnumValue(value));
    }

    [Theory]
    [InlineData(DayOfWeek.Monday, "Monday", false)]
    [InlineData(DayOfWeek.Sunday, "MONDAY", false)]
    [InlineData(DayOfWeek.Monday, "Monday", true)]
    [InlineData(DayOfWeek.Monday, "MONDAY", true)]
    public void GetEnumValue_IgnoreCase(DayOfWeek expected, string value, bool ignoreCase)
    {
        Assert.Equal(expected, Enum<DayOfWeek>.GetEnumValue(value, ignoreCase));
    }

    [Theory]
    [InlineData(DayOfWeek.Monday, "Monday", true)]
    [InlineData(DayOfWeek.Monday, "MONDAY", true)]
    public void TryGetEnumValue(DayOfWeek expected, string value, bool ignoreCase)
    {
        var isParsed = Enum<DayOfWeek>.TryGetEnumValue(value, ignoreCase, out var dayOfWeek);
        Assert.True(isParsed, "Can parse");
        Assert.True(expected.Equals(dayOfWeek), "Enum-value compare");
    }

    [Theory]
    [InlineData(DayOfWeek.Monday, DayOfWeek.Monday)]
    public void TryGetEnumFromEnumType(DayOfWeek expected, Enum value)
    {
        var isParsed = Enum<DayOfWeek>.TryGetEnumValue(value, out var dayOfWeek);
        Assert.True(isParsed, "Can parse");
        Assert.True(expected.Equals(dayOfWeek), "Enum-value compare");
    }

    [Theory]
    [InlineData(DayOfWeek.Monday, "Monday")]
    [InlineData(DayOfWeek.Monday, "MONDAY")]
    public void ParseWithDefaultIgnoreCase(DayOfWeek expected, string value)
    {
        Assert.Equal(expected, Enum<DayOfWeek>.Parse(value));
    }

    [Theory]
    [InlineData(DayOfWeek.Monday, "Monday")]
    public void ParseWithCaseSensitive(DayOfWeek expected, string value)
    {
        Assert.Equal(expected, Enum<DayOfWeek>.Parse(value, ignoreCase: false));
    }

    [Theory]
    [InlineData("MONDAY")]
    public void ParseWithCaseSensitiveExpectedThrows(string value)
    {
        Assert.Throws<ArgumentException>(() => Enum<DayOfWeek>.Parse(value, ignoreCase: false));
    }

    [Theory]
    [InlineData(DayOfWeek.Monday, "Monday")]
    [InlineData(DayOfWeek.Monday, "MONDAY")]
    public void TryParseWithDefaultIgnoreCase(DayOfWeek expectedOut, string value)
    {
        var isParsed = Enum<DayOfWeek>.TryParse(value, out var dayOfWeek);
        Assert.True(isParsed);
        Assert.Equal(expectedOut, dayOfWeek);
    }

    [Theory]
    [InlineData(DayOfWeek.Monday, "Monday", true)]
    [InlineData(DayOfWeek.Monday, "MONDAY", true)]
    public void TryParse(DayOfWeek expected, string value, bool ignoreCase)
    {
        var isParsed = Enum<DayOfWeek>.TryParse(value, ignoreCase, out var dayOfWeek);
        Assert.True(isParsed, "Can parse");
        Assert.True(expected.Equals(dayOfWeek), "Enum-value compare");
    }

    [Theory]
    [SuppressMessage("Minor Code Smell", "S1481:Unused local variables should be removed", Justification = "OK.")]
    [MemberData(nameof(TestMemberDataForEnum.DayOfWeekData), MemberType = typeof(TestMemberDataForEnum), DisableDiscoveryEnumeration = true)]
    public void ToArray<T>(
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
        _ = dummyForT;

        // Act
        var actual = Enum<T>.ToArray(dropDownFirstItemType, useDescriptionAttribute, includeDefault, sortDirectionType, byFlagIncludeBase, byFlagIncludeCombined);

        // Assert
        actual.Cast<string>().Should().NotBeNull().And.HaveCount(expectedCount);
    }

    [Theory]
    [MemberData(nameof(TestMemberDataForEnum.DayOfWeekData), MemberType = typeof(TestMemberDataForEnum), DisableDiscoveryEnumeration = true)]
    [SuppressMessage("Minor Code Smell", "S1481:Unused local variables should be removed", Justification = "OK.")]
    public void ToDictionary<T>(
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
        _ = dummyForT;

        // Act
        var actual = Enum<T>.ToDictionary(dropDownFirstItemType, useDescriptionAttribute, includeDefault, sortDirectionType, byFlagIncludeBase, byFlagIncludeCombined);

        // Assert
        actual.Should().NotBeNull().And.HaveCount(expectedCount);
    }

    [Theory]
    [MemberData(nameof(TestMemberDataForEnum.DayOfWeekData), MemberType = typeof(TestMemberDataForEnum), DisableDiscoveryEnumeration = true)]
    [SuppressMessage("Minor Code Smell", "S1481:Unused local variables should be removed", Justification = "OK.")]
    public void ToDictionaryWithStringKey<T>(
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
        _ = dummyForT;

        // Act
        var actual = Enum<T>.ToDictionaryWithStringKey(dropDownFirstItemType, useDescriptionAttribute, includeDefault, sortDirectionType, byFlagIncludeBase, byFlagIncludeCombined);

        // Assert
        actual.Should().NotBeNull().And.HaveCount(expectedCount);
    }

    [Theory]
    [MemberData(nameof(TestMemberDataForEnum.DayOfWeekData), MemberType = typeof(TestMemberDataForEnum), DisableDiscoveryEnumeration = true)]
    [SuppressMessage("Minor Code Smell", "S1481:Unused local variables should be removed", Justification = "OK.")]
    public void ToKeyValuePairs<T>(
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
        _ = dummyForT;

        // Act
        var actual = Enum<T>.ToKeyValuePairs(dropDownFirstItemType, useDescriptionAttribute, includeDefault, sortDirectionType, byFlagIncludeBase, byFlagIncludeCombined);

        // Assert
        actual.Should().NotBeNull().And.HaveCount(expectedCount);
    }

    [Theory]
    [MemberData(nameof(TestMemberDataForEnum.DayOfWeekData), MemberType = typeof(TestMemberDataForEnum), DisableDiscoveryEnumeration = true)]
    [SuppressMessage("Minor Code Smell", "S1481:Unused local variables should be removed", Justification = "OK.")]
    public void ToKeyValuePairsWithStringKey<T>(
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
        _ = dummyForT;

        // Act
        var actual = Enum<T>.ToKeyValuePairsWithStringKey(dropDownFirstItemType, useDescriptionAttribute, includeDefault, sortDirectionType, byFlagIncludeBase, byFlagIncludeCombined);

        // Assert
        actual.Should().NotBeNull().And.HaveCount(expectedCount);
    }
}