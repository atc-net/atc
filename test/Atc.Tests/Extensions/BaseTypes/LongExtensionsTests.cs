namespace Atc.Tests.Extensions.BaseTypes;

public class LongExtensionsTests
{
    [Theory]
    [InlineData(1, 0, 0, 0, 0)]
    [InlineData(1, 0, 0, 10, 10)]
    [InlineData(12, 13, 46, 40, 1000000)]
    public void FromUnixTime(
        int expectedDay,
        int expectedHour,
        int expectedMinute,
        int expectedSecond,
        long input)
    {
        // Arrange
        var expectedDateTimeOffset = new DateTimeOffset(1970, 1, expectedDay, expectedHour, expectedMinute, expectedSecond, new TimeSpan(0, 0, 0, 0, 0));

        // Act
        var actual = input.FromUnixTime();

        // Assert
        Assert.Equal(expectedDateTimeOffset, actual);
    }

    [Theory]
    [InlineData(1, 0, 0, 0, 0)]
    [InlineData(1, 0, 0, 10, 10000)]
    [InlineData(12, 13, 46, 40, 1000000000)]
    public void FromUnixTimeMs(
        int expectedDay,
        int expectedHour,
        int expectedMinute,
        int expectedSecond,
        long input)
    {
        // Arrange
        var expectedDateTimeOffset = new DateTimeOffset(1970, 1, expectedDay, expectedHour, expectedMinute, expectedSecond, new TimeSpan(0, 0, 0, 0, 0));

        // Act
        var actual = input.FromUnixTimeMs();

        // Assert
        Assert.Equal(expectedDateTimeOffset, actual);
    }

    [Theory]
    [InlineData(true, 1L)]
    [InlineData(true, 2L)]
    [InlineData(true, 4L)]
    [InlineData(true, 1L << 32)]
    [InlineData(true, 1L << 62)]
    [InlineData(false, 0L)]
    [InlineData(false, 3L)]
    [InlineData(false, 6L)]
    [InlineData(false, -1L)]
    public void IsBinarySequence(
        bool expected,
        long input)
    {
        Assert.Equal(expected, input.IsBinarySequence());
    }

    [Theory]
    [InlineData(500, 1970, 1, 1, 0, 0, 0, 500)]
    [InlineData(1500, 1970, 1, 1, 0, 0, 1, 500)]
    [InlineData(999, 1970, 1, 1, 0, 0, 0, 999)]
    public void FromUnixTimeMs_ShouldPreserveSubSecondMilliseconds(
        long input,
        int expectedYear,
        int expectedMonth,
        int expectedDay,
        int expectedHour,
        int expectedMinute,
        int expectedSecond,
        int expectedMillisecond)
    {
        // Arrange
        var expectedDateTimeOffset = new DateTimeOffset(expectedYear, expectedMonth, expectedDay, expectedHour, expectedMinute, expectedSecond, expectedMillisecond, TimeSpan.Zero);

        // Act
        var actual = input.FromUnixTimeMs();

        // Assert
        Assert.Equal(expectedDateTimeOffset, actual);
    }
}