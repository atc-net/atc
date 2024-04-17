namespace Atc.Tests.Extensions;

public class EnumExtensionsTests
{
    [Theory]
    [InlineData(true, DayOfWeek.Monday, DayOfWeek.Monday)]
    public void AreFlagsSet(
        bool expected,
        DayOfWeek value1,
        DayOfWeek value2)
        => Assert.Equal(expected, value1.AreFlagsSet(value2));

    [Theory]
    [InlineData(true, DayOfWeek.Monday, DayOfWeek.Monday)]
    public void IsSet(
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
}