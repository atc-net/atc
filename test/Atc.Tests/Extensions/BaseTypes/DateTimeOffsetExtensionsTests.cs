namespace Atc.Tests.Extensions.BaseTypes;

public class DateTimeOffsetExtensionsTests
{
    [Theory]
    [InlineData(true, 2019, 10, 5, 15)]
    [InlineData(true, 2019, 10, 10, 15)]
    [InlineData(true, 2019, 10, 5, 10)]
    [InlineData(false, 2019, 10, 15, 25)]
    public void IsBetween(bool expected, int year, int inputSeconds, int secondsA, int secondsB)
    {
        // Arrange
        var input = new DateTimeOffset(year, 1, 1, 0, 0, inputSeconds, TimeSpan.Zero);
        var inputA = new DateTimeOffset(year, 1, 1, 0, 0, secondsA, TimeSpan.Zero);
        var inputB = new DateTimeOffset(year, 1, 1, 0, 0, secondsB, TimeSpan.Zero);

        // Act
        var actual = input.IsBetween(inputA, inputB);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory, AutoData]
    public void ResetToStartOfCurrentHour(DateTimeOffset input)
    {
        // Act
        var actual = input.ResetToStartOfCurrentHour();

        // Assert
        Assert.Equal(input.Year, actual.Year);
        Assert.Equal(input.Month, actual.Month);
        Assert.Equal(input.Day, actual.Day);
        Assert.Equal(input.Hour, actual.Hour);

        Assert.Equal(0, actual.Minute);
        Assert.Equal(0, actual.Second);
        Assert.Equal(0, actual.Millisecond);
        Assert.Equal(input.Offset, actual.Offset);
    }

    [Theory, AutoData]
    public void SetHourAndMinutes(
        DateTimeOffset input,
        [Range(0, 23)] int inputHour,
        [Range(0, 59)] int inputMinutes)
    {
        // Act
        var actual = input.SetHourAndMinutes(inputHour, inputMinutes);

        // Assert
        Assert.Equal(input.Year, actual.Year);
        Assert.Equal(input.Month, actual.Month);
        Assert.Equal(input.Day, actual.Day);

        Assert.Equal(inputHour, actual.Hour);
        Assert.Equal(inputMinutes, actual.Minute);

        Assert.Equal(0, actual.Second);
        Assert.Equal(0, actual.Millisecond);
        Assert.Equal(TimeSpan.Zero, actual.Offset);
    }

    [Theory]
    [InlineData(42, 42)]
    public void ToUnixTime(int expected, int seconds)
    {
        // Arrange
        var input = new DateTimeOffset(1970, 1, 1, 0, 0, seconds, TimeSpan.Zero);

        // Act
        var actual = input.ToUnixTime();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("1970-01-01T00:00:42", 42)]
    public void ToIso8601Date(string expected, int seconds)
    {
        // Arrange
        var input = new DateTimeOffset(1970, 1, 1, 0, 0, seconds, TimeSpan.Zero);

        // Act
        var actual = input.ToIso8601Date();

        // Assert
        Assert.Equal(expected, actual);
    }
}