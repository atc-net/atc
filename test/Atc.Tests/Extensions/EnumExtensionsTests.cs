namespace Atc.Tests.Extensions;

public class EnumExtensionsTests
{
    [SuppressMessage("Naming", "S2344:Enumeration type names should not have 'Flags' or 'Enum' suffixes", Justification = "Test fixture name.")]
    [Flags]
    private enum LongBackedEnum : long
    {
        None = 0,
        A = 1L,
        B = 2L,
        HighBit = 1L << 33, // beyond uint range — previously caused OverflowException
    }

    [Theory]
    [InlineData(true, DayOfWeek.Monday, DayOfWeek.Monday)]
    [InlineData(false, DayOfWeek.Monday, DayOfWeek.Tuesday)]
    public void AreFlagsSet(
        bool expected,
        DayOfWeek value1,
        DayOfWeek value2)
        => Assert.Equal(expected, value1.AreFlagsSet(value2));

    [Theory]
    [InlineData(true, DayOfWeek.Monday, DayOfWeek.Monday)]
    [InlineData(false, DayOfWeek.Monday, DayOfWeek.Tuesday)]
    public void IsSet(
        bool expected,
        DayOfWeek value1,
        DayOfWeek value2)
        => Assert.Equal(expected, ((Enum)value1).IsSet(value2));

    [Fact]
    public void IsSet_LongBackedEnum_DoesNotOverflow()
    {
        Assert.True(((Enum)(LongBackedEnum.A | LongBackedEnum.HighBit)).IsSet(LongBackedEnum.HighBit));
        Assert.False(((Enum)LongBackedEnum.A).IsSet(LongBackedEnum.HighBit));
    }

    [Fact]
    public void IsSet_RequiresAllFlagsSet_ConsistentWithHasFlag()
    {
        Assert.False(((Enum)LongBackedEnum.A).IsSet(LongBackedEnum.A | LongBackedEnum.B));
        Assert.True(((Enum)(LongBackedEnum.A | LongBackedEnum.B)).IsSet(LongBackedEnum.A));
    }

    [Theory]
    [InlineData(true, DayOfWeek.Monday, DayOfWeek.Monday)]
    [InlineData(false, DayOfWeek.Monday, DayOfWeek.Tuesday)]
    public void IsSet_Generic(
        bool expected,
        DayOfWeek value1,
        DayOfWeek value2)
        => Assert.Equal(expected, value1.IsSet(value2));

    [Theory]
    [InlineData("Monday", DayOfWeek.Monday)]
    public void GetName(
        string expected,
        DayOfWeek value)
        => Assert.Equal(expected, value.GetName());

    [Theory]
    [InlineData("Monday", DayOfWeek.Monday)]
    public void GetDescription(
        string expected,
        DayOfWeek value)
        => Assert.Equal(expected, value.GetDescription());

    [Theory]
    [InlineData("Monday", DayOfWeek.Monday, false)]
    [InlineData("Monday", DayOfWeek.Monday, true)]
    public void GetDescription_UseLocalizedIfPossible(
        string expected,
        DayOfWeek value,
        bool useLocalizedIfPossible)
        => Assert.Equal(expected, value.GetDescription(useLocalizedIfPossible));

    [Theory]
    [InlineData("MONDAY", DayOfWeek.Monday)]
    public void ToStringUpperCase(
        string expected,
        DayOfWeek value)
        => Assert.Equal(expected, value.ToStringUpperCase());

    [Theory]
    [InlineData("monday", DayOfWeek.Monday)]
    public void ToStringLowerCase(
        string expected,
        DayOfWeek value)
        => Assert.Equal(expected, value.ToStringLowerCase());

    [Theory]
    [InlineData(TestPetTypeA.Dog, TestPetTypeB.Dog, TestPetTypeA.None)]
    [InlineData(TestPetTypeA.Cat, TestPetTypeB.Cat, TestPetTypeA.None)]
    [InlineData(TestPetTypeA.None, TestPetTypeB.Unknown, TestPetTypeA.None)]
    [InlineData(TestPetTypeA.None, (TestPetTypeB)24, TestPetTypeA.None)]
    public void MapTo_WithDefault(
        TestPetTypeA expected,
        TestPetTypeB source,
        TestPetTypeA defaultValue)
        => Assert.Equal(expected, source.MapTo<TestPetTypeA>(defaultValue));

    [Theory]
    [InlineData(TestPetTypeA.Dog, TestPetTypeB.Dog)]
    [InlineData(TestPetTypeA.Cat, TestPetTypeB.Cat)]
    public void MapTo_WithoutDefault(
        TestPetTypeA expected,
        TestPetTypeB source)
        => Assert.Equal(expected, source.MapTo<TestPetTypeA>());

    [Fact]
    public void MapTo_WithoutDefault_Throws()
        => Assert.Throws<InvalidOperationException>(() => TestPetTypeB.Unknown.MapTo<TestPetTypeA>());

    [Theory]
    [InlineData(true, TestPetTypeA.Dog, TestPetTypeB.Dog)]
    [InlineData(true, TestPetTypeA.Cat, TestPetTypeB.Cat)]
    public void TryMapTo_MatchingName_ReturnsTrue(
        bool expectedSuccess,
        TestPetTypeA expectedResult,
        TestPetTypeB source)
    {
        var success = source.TryMapTo<TestPetTypeA>(out var result);
        Assert.Equal(expectedSuccess, success);
        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void TryMapTo_NoMatch_ReturnsFalse()
    {
        var success = TestPetTypeB.Unknown.TryMapTo<TestPetTypeA>(out var result);
        Assert.False(success);
        Assert.Equal(default(TestPetTypeA), result);
    }

    [Theory]
    [InlineData("Display Red", TestColorType.Red)]
    [InlineData("Display Green", TestColorType.Green)]
    [InlineData("None", TestColorType.None)]
    public void GetName_WithAttributes(
        string expected,
        TestColorType value)
        => Assert.Equal(expected, value.GetName());

    [Theory]
    [InlineData("The color red", TestColorType.Red)]
    [InlineData("The color blue", TestColorType.Blue)]
    [InlineData("The color red", TestColorType.Red, false)]
    [InlineData("None", TestColorType.None)]
    public void GetDescription_WithAttributes(
        string expected,
        TestColorType value,
        bool useLocalizedIfPossible = true)
        => Assert.Equal(expected, value.GetDescription(useLocalizedIfPossible));
}