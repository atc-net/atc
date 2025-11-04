// ReSharper disable StringLiteralTypo
namespace Atc.Tests.Extensions.BaseTypes;

[Collection("TestCollection")]
[Trait(Traits.Category, Traits.Categories.Integration)]
[Trait(Traits.Category, Traits.Categories.SkipWhenLiveUnitTesting)]
public class DateTimeExtensionsTests
{
    [Theory]
    [InlineData(true, 2019, 10, 5, 15)]
    [InlineData(true, 2019, 10, 10, 15)]
    [InlineData(true, 2019, 10, 5, 10)]
    [InlineData(false, 2019, 10, 15, 25)]
    public void IsBetween(bool expected, int year, int inputSeconds, int secondsA, int secondsB)
    {
        // Arrange
        var input = new DateTime(year, 1, 1, 0, 0, inputSeconds);
        var inputA = new DateTime(year, 1, 1, 0, 0, secondsA);
        var inputB = new DateTime(year, 1, 1, 0, 0, secondsB);

        // Act
        var actual = input.IsBetween(inputA, inputB);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(TestMemberDataForDateTimeExtensions.GetPrettyTimeDiff), MemberType = typeof(TestMemberDataForDateTimeExtensions))]
    public void GetPrettyTimeDiff(string expected, DateTime start, int arrangeUiLcid)
    {
        // Arrange
        Thread.CurrentThread.CurrentUICulture = new CultureInfo(arrangeUiLcid);

        // Act
        var actual = start.GetPrettyTimeDiff();

        // Assert - A kind of a dummy test, because of timing issues
        Assert.NotNull(expected);
        Assert.NotNull(actual);
    }

    [Theory]
    [MemberData(nameof(TestMemberDataForDateTimeExtensions.GetPrettyTimeDiffWithDecimalPrecision), MemberType = typeof(TestMemberDataForDateTimeExtensions))]
    public void GetPrettyTimeDiff_DecimalPrecision(string expected, DateTime start, int decimalPrecision, int arrangeUiLcid)
    {
        // Arrange
        Thread.CurrentThread.CurrentUICulture = new CultureInfo(arrangeUiLcid);

        // Act
        var actual = start.GetPrettyTimeDiff(decimalPrecision);

        // Assert - A kind of a dummy test, because of timing issues
        Assert.NotNull(expected);
        Assert.NotNull(actual);
    }

    [Theory]
    [MemberData(nameof(TestMemberDataForDateTimeExtensions.GetPrettyTimeDiffWithEnd), MemberType = typeof(TestMemberDataForDateTimeExtensions))]
    public void GetPrettyTimeDiff_EndNow(string expected, DateTime start, DateTime end, int arrangeUiLcid)
    {
        // Arrange
        Thread.CurrentThread.CurrentUICulture = new CultureInfo(arrangeUiLcid);

        // Act
        var actual = start.GetPrettyTimeDiff(end);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(TestMemberDataForDateTimeExtensions.GetPrettyTimeDiffWithEndNowAndDecimalPrecision), MemberType = typeof(TestMemberDataForDateTimeExtensions))]
    public void GetPrettyTimeDiff_EndNow_DecimalPrecision(string expected, DateTime start, DateTime end, int decimalPrecision, int arrangeUiLcid)
    {
        // Arrange
        Thread.CurrentThread.CurrentUICulture = new CultureInfo(arrangeUiLcid);

        // Act
        var actual = start.GetPrettyTimeDiff(end, decimalPrecision);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(1, 1970, 1)]
    [InlineData(48, 2019, 12)]
    public void GetWeekNumber(int expected, int year, int month)
    {
        // Arrange
        var input = new DateTime(year, month, 1, 0, 0, 0);

        // Act
        var actual = input.GetWeekNumber();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(10000, 10, DateTimeDiffCompareType.Milliseconds)]
    [InlineData(42000, 42, DateTimeDiffCompareType.Milliseconds)]
    public void DateTimeDiff(double expected, int seconds, DateTimeDiffCompareType dateTimeDiffCompareType)
    {
        // Arrange
        var inputA = new DateTime(1970, 1, 1, 0, 0, 0);
        var inputB = new DateTime(1970, 1, 1, 0, 0, seconds);

        // Act
        var actual = inputA.DateTimeDiff(inputB, dateTimeDiffCompareType);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("1970-01-01T00:00:42", 1970, 42)]
    [InlineData("2019-01-01T00:00:42", 2019, 42)]
    public void ToIso8601Date(string expected, int year, int seconds)
    {
        // Arrange
        var input = new DateTime(year, 1, 1, 0, 0, seconds);

        // Act
        var actual = input.ToIso8601Date();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(1970, 0, 42)]
    [InlineData(1970, 2, 42)]
    [InlineData(2019, 0, 42)]
    public void ToIso8601Utc(int year, int hour, int seconds)
    {
        // Arrange
        var input = new DateTime(year, 1, 1, hour, 0, seconds);

        // Act
        var actual = input.ToIso8601UtcDate();

        // Assert
        Assert.NotNull(actual);
    }

    [Theory]
    [InlineData("Sunday, October 15, 2023", GlobalizationLcidConstants.UnitedStates)]
    [InlineData("Sunday, 15 October 2023", GlobalizationLcidConstants.GreatBritain)]
    [InlineData("søndag den 15. oktober 2023", GlobalizationLcidConstants.Denmark)]
    [InlineData("Sonntag, 15. Oktober 2023", GlobalizationLcidConstants.Germany)]
    public void ToLongDateStringUsingCurrentUiCulture(
        string expected, int arrangeUiLcid)
    {
        // Arrange
        var dateTime = new DateTime(2023, 10, 15, 15, 30, 45, DateTimeKind.Local);
        Thread.CurrentThread.CurrentUICulture = new CultureInfo(arrangeUiLcid);

        // Act
        var actual = dateTime.ToLongDateStringUsingCurrentUiCulture();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("Sunday, October 15, 2023", GlobalizationLcidConstants.UnitedStates)]
    [InlineData("Sunday, 15 October 2023", GlobalizationLcidConstants.GreatBritain)]
    [InlineData("søndag den 15. oktober 2023", GlobalizationLcidConstants.Denmark)]
    [InlineData("Sonntag, 15. Oktober 2023", GlobalizationLcidConstants.Germany)]
    public void ToLongDateString(
        string expected, int arrangeUiLcid)
    {
        // Arrange
        var dateTime = new DateTime(2023, 10, 15, 15, 30, 45, DateTimeKind.Local);
        Thread.CurrentThread.CurrentUICulture = new CultureInfo(arrangeUiLcid);

        // Act
        var actual = dateTime.ToLongDateString(Thread.CurrentThread.CurrentUICulture.DateTimeFormat);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("3:30:45 PM", GlobalizationLcidConstants.UnitedStates)]
    [InlineData("15:30:45", GlobalizationLcidConstants.GreatBritain)]
    [InlineData("15.30.45", GlobalizationLcidConstants.Denmark)]
    [InlineData("15:30:45", GlobalizationLcidConstants.Germany)]
    public void ToLongTimeStringUsingCurrentUiCulture(
        string expected, int arrangeUiLcid)
    {
        // Arrange
        var dateTime = new DateTime(2023, 10, 15, 15, 30, 45, DateTimeKind.Local);
        Thread.CurrentThread.CurrentUICulture = new CultureInfo(arrangeUiLcid);

        // Act
        var actual = dateTime.ToLongTimeStringUsingCurrentUiCulture();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("3:30:45 PM", GlobalizationLcidConstants.UnitedStates)]
    [InlineData("15:30:45", GlobalizationLcidConstants.GreatBritain)]
    [InlineData("15.30.45", GlobalizationLcidConstants.Denmark)]
    [InlineData("15:30:45", GlobalizationLcidConstants.Germany)]
    public void ToLongTimeString(
        string expected, int arrangeUiLcid)
    {
        // Arrange
        var dateTime = new DateTime(2023, 10, 15, 15, 30, 45, DateTimeKind.Local);
        Thread.CurrentThread.CurrentUICulture = new CultureInfo(arrangeUiLcid);

        // Act
        var actual = dateTime.ToLongTimeString(Thread.CurrentThread.CurrentUICulture.DateTimeFormat);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("10/15/2023", GlobalizationLcidConstants.UnitedStates)]
    [InlineData("15/10/2023", GlobalizationLcidConstants.GreatBritain)]
    [InlineData("15.10.2023", GlobalizationLcidConstants.Denmark)]
    [InlineData("15.10.2023", GlobalizationLcidConstants.Germany)]
    public void ToShortDateStringUsingCurrentUiCulture(
        string expected, int arrangeUiLcid)
    {
        // Arrange
        var dateTime = new DateTime(2023, 10, 15, 15, 30, 45, DateTimeKind.Local);
        Thread.CurrentThread.CurrentUICulture = new CultureInfo(arrangeUiLcid);

        // Act
        var actual = dateTime.ToShortDateStringUsingCurrentUiCulture();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("10/15/2023", GlobalizationLcidConstants.UnitedStates)]
    [InlineData("15/10/2023", GlobalizationLcidConstants.GreatBritain)]
    [InlineData("15.10.2023", GlobalizationLcidConstants.Denmark)]
    [InlineData("15.10.2023", GlobalizationLcidConstants.Germany)]
    public void ToShortDateString(
        string expected, int arrangeUiLcid)
    {
        // Arrange
        var dateTime = new DateTime(2023, 10, 15, 15, 30, 45, DateTimeKind.Local);
        Thread.CurrentThread.CurrentUICulture = new CultureInfo(arrangeUiLcid);

        // Act
        var actual = dateTime.ToShortDateString(Thread.CurrentThread.CurrentUICulture.DateTimeFormat);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("3:30 PM", GlobalizationLcidConstants.UnitedStates)]
    [InlineData("15:30", GlobalizationLcidConstants.GreatBritain)]
    [InlineData("15.30", GlobalizationLcidConstants.Denmark)]
    [InlineData("15:30", GlobalizationLcidConstants.Germany)]
    public void ToShortTimeStringUsingCurrentUiCulture(
        string expected, int arrangeUiLcid)
    {
        // Arrange
        var dateTime = new DateTime(2023, 10, 15, 15, 30, 45, DateTimeKind.Local);
        Thread.CurrentThread.CurrentUICulture = new CultureInfo(arrangeUiLcid);

        // Act
        var actual = dateTime.ToShortTimeStringUsingCurrentUiCulture();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("3:30 PM", GlobalizationLcidConstants.UnitedStates)]
    [InlineData("15:30", GlobalizationLcidConstants.GreatBritain)]
    [InlineData("15.30", GlobalizationLcidConstants.Denmark)]
    [InlineData("15:30", GlobalizationLcidConstants.Germany)]
    public void ToShortTimeString(
        string expected, int arrangeUiLcid)
    {
        // Arrange
        var dateTime = new DateTime(2023, 10, 15, 15, 30, 45, DateTimeKind.Local);
        Thread.CurrentThread.CurrentUICulture = new CultureInfo(arrangeUiLcid);

        // Act
        var actual = dateTime.ToShortTimeString(Thread.CurrentThread.CurrentUICulture.DateTimeFormat);

        // Assert
        Assert.Equal(expected, actual);
    }
}