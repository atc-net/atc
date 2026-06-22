namespace Atc.Tests.Helpers;

public class DateTimeOffsetHelperTests
{
    [Theory]
    [InlineData(true, GlobalizationLcidConstants.UnitedStates, "10/15/2023")]
    [InlineData(true, GlobalizationLcidConstants.UnitedStates, "10-15-2023")]
    [InlineData(true, GlobalizationLcidConstants.UnitedStates, "10.15.2023")]
    [InlineData(false, GlobalizationLcidConstants.UnitedStates, "20/15/2023")]
    [InlineData(false, GlobalizationLcidConstants.UnitedStates, "20152023")]
    [InlineData(true, GlobalizationLcidConstants.GreatBritain, "15/10/2023")]
    [InlineData(true, GlobalizationLcidConstants.GreatBritain, "15-10-2023")]
    [InlineData(true, GlobalizationLcidConstants.GreatBritain, "15.10.2023")]
    [InlineData(false, GlobalizationLcidConstants.GreatBritain, "15/20/2023")]
    [InlineData(true, GlobalizationLcidConstants.Denmark, "15.10.2023")]
    [InlineData(true, GlobalizationLcidConstants.Denmark, "15-10-2023")]
    [InlineData(true, GlobalizationLcidConstants.Denmark, "15/10/2023")]
    [InlineData(false, GlobalizationLcidConstants.Denmark, "15.20.2023")]
    [InlineData(true, GlobalizationLcidConstants.Germany, "15.10.2023")]
    [InlineData(true, GlobalizationLcidConstants.Germany, "15-10-2023")]
    [InlineData(true, GlobalizationLcidConstants.Germany, "15/10/2023")]
    [InlineData(false, GlobalizationLcidConstants.Germany, "15.20.2023")]
    public void TryParseUsingCurrentUiCulture(
        bool expected,
        int arrangeUiLcid,
        string value)
    {
        // Arrange
        Thread.CurrentThread.CurrentUICulture = new CultureInfo(arrangeUiLcid);

        // Act
        var actual = DateTimeOffsetHelper.TryParseUsingCurrentUiCulture(value, out _);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(true, GlobalizationLcidConstants.UnitedStates, "10/15/2023")]
    [InlineData(true, GlobalizationLcidConstants.UnitedStates, "10-15-2023")]
    [InlineData(true, GlobalizationLcidConstants.UnitedStates, "10.15.2023")]
    [InlineData(false, GlobalizationLcidConstants.UnitedStates, "20/15/2023")]
    [InlineData(true, GlobalizationLcidConstants.GreatBritain, "15/10/2023")]
    [InlineData(true, GlobalizationLcidConstants.GreatBritain, "15-10-2023")]
    [InlineData(true, GlobalizationLcidConstants.GreatBritain, "15.10.2023")]
    [InlineData(false, GlobalizationLcidConstants.GreatBritain, "15/20/2023")]
    [InlineData(true, GlobalizationLcidConstants.Denmark, "15.10.2023")]
    [InlineData(true, GlobalizationLcidConstants.Denmark, "15-10-2023")]
    [InlineData(true, GlobalizationLcidConstants.Denmark, "15/10/2023")]
    [InlineData(false, GlobalizationLcidConstants.Denmark, "15.20.2023")]
    [InlineData(true, GlobalizationLcidConstants.Germany, "15.10.2023")]
    [InlineData(true, GlobalizationLcidConstants.Germany, "15-10-2023")]
    [InlineData(true, GlobalizationLcidConstants.Germany, "15/10/2023")]
    [InlineData(false, GlobalizationLcidConstants.Germany, "15.20.2023")]
    public void TryParseShortDateUsingCurrentUiCulture(
        bool expected,
        int arrangeUiLcid,
        string value)
    {
        // Arrange
        Thread.CurrentThread.CurrentUICulture = new CultureInfo(arrangeUiLcid);

        // Act
        var actual = DateTimeOffsetHelper.TryParseShortDateUsingCurrentUiCulture(value, out _);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(true, GlobalizationLcidConstants.UnitedStates, "3:30 AM")]
    [InlineData(true, GlobalizationLcidConstants.UnitedStates, "3:30 PM")]
    [InlineData(false, GlobalizationLcidConstants.UnitedStates, "3:30 X")]
    [InlineData(true, GlobalizationLcidConstants.UnitedStates, "3.30 PM")]
    [InlineData(true, GlobalizationLcidConstants.GreatBritain, "03:30")]
    [InlineData(true, GlobalizationLcidConstants.GreatBritain, "15:30")]
    [InlineData(false, GlobalizationLcidConstants.GreatBritain, "24:30")]
    [InlineData(false, GlobalizationLcidConstants.GreatBritain, "15.30")]
    [InlineData(true, GlobalizationLcidConstants.Denmark, "03.30")]
    [InlineData(true, GlobalizationLcidConstants.Denmark, "15.30")]
    [InlineData(false, GlobalizationLcidConstants.Denmark, "24.30")]
    [InlineData(true, GlobalizationLcidConstants.Denmark, "15:30")]
    [InlineData(true, GlobalizationLcidConstants.Germany, "03:30")]
    [InlineData(true, GlobalizationLcidConstants.Germany, "15:30")]
    [InlineData(false, GlobalizationLcidConstants.Germany, "24:30")]
    [InlineData(false, GlobalizationLcidConstants.Germany, "15.30")]
    public void TryParseShortTimeUsingCurrentUiCulture(
        bool expected,
        int arrangeUiLcid,
        string value)
    {
        // Arrange
        Thread.CurrentThread.CurrentUICulture = new CultureInfo(arrangeUiLcid);

        // Act
        var actual = DateTimeOffsetHelper.TryParseShortTimeUsingCurrentUiCulture(value, out _);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(true, GlobalizationLcidConstants.UnitedStates, "3:30 AM")]
    [InlineData(true, GlobalizationLcidConstants.UnitedStates, "3:30 PM")]
    [InlineData(false, GlobalizationLcidConstants.UnitedStates, "3:30 X")]
    [InlineData(true, GlobalizationLcidConstants.UnitedStates, "3.30 PM")]
    [InlineData(true, GlobalizationLcidConstants.GreatBritain, "03:30")]
    [InlineData(true, GlobalizationLcidConstants.GreatBritain, "15:30")]
    [InlineData(false, GlobalizationLcidConstants.GreatBritain, "24:30")]
    [InlineData(false, GlobalizationLcidConstants.GreatBritain, "15.30")]
    [InlineData(true, GlobalizationLcidConstants.Denmark, "03.30")]
    [InlineData(true, GlobalizationLcidConstants.Denmark, "15.30")]
    [InlineData(false, GlobalizationLcidConstants.Denmark, "24.30")]
    [InlineData(true, GlobalizationLcidConstants.Denmark, "15:30")]
    [InlineData(true, GlobalizationLcidConstants.Germany, "03:30")]
    [InlineData(true, GlobalizationLcidConstants.Germany, "15:30")]
    [InlineData(false, GlobalizationLcidConstants.Germany, "24:30")]
    [InlineData(false, GlobalizationLcidConstants.Germany, "15.30")]
    public void TryParseShortTimeUsingCurrentUiCultureUtc(
        bool expected,
        int arrangeUiLcid,
        string value)
    {
        // Arrange
        Thread.CurrentThread.CurrentUICulture = new CultureInfo(arrangeUiLcid);

        // Act
        var actual = DateTimeOffsetHelper.TryParseShortTimeUsingCurrentUiCultureUtc(value, out _);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(true, GlobalizationLcidConstants.UnitedStates, "10/15/2023")]
    [InlineData(true, GlobalizationLcidConstants.UnitedStates, "10-15-2023")]
    [InlineData(false, GlobalizationLcidConstants.UnitedStates, "20/15/2023")]
    [InlineData(true, GlobalizationLcidConstants.GreatBritain, "15/10/2023")]
    [InlineData(false, GlobalizationLcidConstants.GreatBritain, "15/20/2023")]
    [InlineData(true, GlobalizationLcidConstants.Denmark, "15.10.2023")]
    [InlineData(false, GlobalizationLcidConstants.Denmark, "15.20.2023")]
    [InlineData(true, GlobalizationLcidConstants.Germany, "15.10.2023")]
    [InlineData(false, GlobalizationLcidConstants.Germany, "15.20.2023")]
    public void TryParseUsingSpecificCulture(
        bool expected,
        int lcid,
        string value)
    {
        var actual = DateTimeOffsetHelper.TryParseUsingSpecificCulture(
            value,
            new CultureInfo(lcid),
            out _);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(true, GlobalizationLcidConstants.UnitedStates, "10/15/2023")]
    [InlineData(true, GlobalizationLcidConstants.UnitedStates, "10-15-2023")]
    [InlineData(false, GlobalizationLcidConstants.UnitedStates, "20/15/2023")]
    [InlineData(true, GlobalizationLcidConstants.GreatBritain, "15/10/2023")]
    [InlineData(false, GlobalizationLcidConstants.GreatBritain, "15/20/2023")]
    [InlineData(true, GlobalizationLcidConstants.Denmark, "15.10.2023")]
    [InlineData(false, GlobalizationLcidConstants.Denmark, "15.20.2023")]
    [InlineData(true, GlobalizationLcidConstants.Germany, "15.10.2023")]
    [InlineData(false, GlobalizationLcidConstants.Germany, "15.20.2023")]
    public void TryParseShortDateUsingSpecificCulture(
        bool expected,
        int lcid,
        string value)
    {
        var actual = DateTimeOffsetHelper.TryParseShortDateUsingSpecificCulture(
            value,
            new CultureInfo(lcid),
            out _);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(true, GlobalizationLcidConstants.UnitedStates, "3:30 AM")]
    [InlineData(true, GlobalizationLcidConstants.UnitedStates, "3:30 PM")]
    [InlineData(false, GlobalizationLcidConstants.UnitedStates, "3:30 X")]
    [InlineData(true, GlobalizationLcidConstants.GreatBritain, "03:30")]
    [InlineData(true, GlobalizationLcidConstants.GreatBritain, "15:30")]
    [InlineData(false, GlobalizationLcidConstants.GreatBritain, "24:30")]
    [InlineData(true, GlobalizationLcidConstants.Denmark, "03.30")]
    [InlineData(true, GlobalizationLcidConstants.Denmark, "15.30")]
    [InlineData(false, GlobalizationLcidConstants.Denmark, "24.30")]
    [InlineData(true, GlobalizationLcidConstants.Germany, "03:30")]
    [InlineData(true, GlobalizationLcidConstants.Germany, "15:30")]
    [InlineData(false, GlobalizationLcidConstants.Germany, "24:30")]
    public void TryParseShortTimeUsingSpecificCulture(
        bool expected,
        int lcid,
        string value)
    {
        var actual = DateTimeOffsetHelper.TryParseShortTimeUsingSpecificCulture(
            value,
            new CultureInfo(lcid),
            out _);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(true, GlobalizationLcidConstants.UnitedStates, "3:30 AM")]
    [InlineData(true, GlobalizationLcidConstants.UnitedStates, "3:30 PM")]
    [InlineData(false, GlobalizationLcidConstants.UnitedStates, "3:30 X")]
    [InlineData(true, GlobalizationLcidConstants.GreatBritain, "03:30")]
    [InlineData(true, GlobalizationLcidConstants.GreatBritain, "15:30")]
    [InlineData(false, GlobalizationLcidConstants.GreatBritain, "24:30")]
    [InlineData(true, GlobalizationLcidConstants.Denmark, "03.30")]
    [InlineData(true, GlobalizationLcidConstants.Denmark, "15.30")]
    [InlineData(false, GlobalizationLcidConstants.Denmark, "24.30")]
    [InlineData(true, GlobalizationLcidConstants.Germany, "03:30")]
    [InlineData(true, GlobalizationLcidConstants.Germany, "15:30")]
    [InlineData(false, GlobalizationLcidConstants.Germany, "24:30")]
    public void TryParseShortTimeUsingSpecificCultureUtc(
        bool expected,
        int lcid,
        string value)
    {
        var actual = DateTimeOffsetHelper.TryParseShortTimeUsingSpecificCultureUtc(
            value,
            new CultureInfo(lcid),
            out _);
        Assert.Equal(expected, actual);
    }
}