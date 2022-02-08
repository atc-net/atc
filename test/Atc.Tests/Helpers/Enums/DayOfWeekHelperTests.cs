namespace Atc.Tests.Helpers.Enums;

public class DayOfWeekHelperTests
{
    [Theory]
    [InlineData(GlobalizationLcidConstants.Invariant, "Monday", DayOfWeek.Monday)]
    [InlineData(GlobalizationLcidConstants.Invariant, "Tuesday", DayOfWeek.Tuesday)]
    [InlineData(GlobalizationLcidConstants.Invariant, "Wednesday", DayOfWeek.Wednesday)]
    [InlineData(GlobalizationLcidConstants.Invariant, "Thursday", DayOfWeek.Thursday)]
    [InlineData(GlobalizationLcidConstants.Invariant, "Friday", DayOfWeek.Friday)]
    [InlineData(GlobalizationLcidConstants.Invariant, "Saturday", DayOfWeek.Saturday)]
    [InlineData(GlobalizationLcidConstants.Invariant, "Sunday", DayOfWeek.Sunday)]
    [InlineData(GlobalizationLcidConstants.UnitedStates, "Monday", DayOfWeek.Monday)]
    [InlineData(GlobalizationLcidConstants.UnitedStates, "Tuesday", DayOfWeek.Tuesday)]
    [InlineData(GlobalizationLcidConstants.UnitedStates, "Wednesday", DayOfWeek.Wednesday)]
    [InlineData(GlobalizationLcidConstants.UnitedStates, "Thursday", DayOfWeek.Thursday)]
    [InlineData(GlobalizationLcidConstants.UnitedStates, "Friday", DayOfWeek.Friday)]
    [InlineData(GlobalizationLcidConstants.UnitedStates, "Saturday", DayOfWeek.Saturday)]
    [InlineData(GlobalizationLcidConstants.UnitedStates, "Sunday", DayOfWeek.Sunday)]
    [InlineData(GlobalizationLcidConstants.GreatBritain, "Monday", DayOfWeek.Monday)]
    [InlineData(GlobalizationLcidConstants.GreatBritain, "Tuesday", DayOfWeek.Tuesday)]
    [InlineData(GlobalizationLcidConstants.GreatBritain, "Wednesday", DayOfWeek.Wednesday)]
    [InlineData(GlobalizationLcidConstants.GreatBritain, "Thursday", DayOfWeek.Thursday)]
    [InlineData(GlobalizationLcidConstants.GreatBritain, "Friday", DayOfWeek.Friday)]
    [InlineData(GlobalizationLcidConstants.GreatBritain, "Saturday", DayOfWeek.Saturday)]
    [InlineData(GlobalizationLcidConstants.GreatBritain, "Sunday", DayOfWeek.Sunday)]
    [InlineData(GlobalizationLcidConstants.Denmark, "Mandag", DayOfWeek.Monday)]
    [InlineData(GlobalizationLcidConstants.Denmark, "Tirsdag", DayOfWeek.Tuesday)]
    [InlineData(GlobalizationLcidConstants.Denmark, "Onsdag", DayOfWeek.Wednesday)]
    [InlineData(GlobalizationLcidConstants.Denmark, "Torsdag", DayOfWeek.Thursday)]
    [InlineData(GlobalizationLcidConstants.Denmark, "Fredag", DayOfWeek.Friday)]
    [InlineData(GlobalizationLcidConstants.Denmark, "Lørdag", DayOfWeek.Saturday)]
    [InlineData(GlobalizationLcidConstants.Denmark, "Søndag", DayOfWeek.Sunday)]
    [InlineData(GlobalizationLcidConstants.Germany, "Montag", DayOfWeek.Monday)]
    [InlineData(GlobalizationLcidConstants.Germany, "Dienstag", DayOfWeek.Tuesday)]
    [InlineData(GlobalizationLcidConstants.Germany, "Mittwoch", DayOfWeek.Wednesday)]
    [InlineData(GlobalizationLcidConstants.Germany, "Donnerstag", DayOfWeek.Thursday)]
    [InlineData(GlobalizationLcidConstants.Germany, "Freitag", DayOfWeek.Friday)]
    [InlineData(GlobalizationLcidConstants.Germany, "Samstag", DayOfWeek.Saturday)]
    public void GetDescription(int arrangeUiLcid, string expected, DayOfWeek input)
    {
        // Arrange
        var culture = arrangeUiLcid == 0
            ? GlobalizationConstants.EnglishCultureInfo
            : new CultureInfo(arrangeUiLcid);

        // Act
        var actual = DayOfWeekHelper.GetDescription(input, culture);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(GlobalizationLcidConstants.Invariant, 7)]
    public void GetDescriptions(int arrangeUiLcid, int expected)
    {
        // Arrange
        CultureInfo? culture = null;
        if (arrangeUiLcid > 0)
        {
            culture = new CultureInfo(arrangeUiLcid);
        }

        // Act
        var actual = DayOfWeekHelper.GetDescriptions(culture);

        // Assert
        actual.Should()
            .BeOfType<Dictionary<DayOfWeek, string>>()
            .And.HaveCount(expected);
    }

    [Theory]
    [InlineData(GlobalizationLcidConstants.Invariant, true, "Monday")]
    [InlineData(GlobalizationLcidConstants.Invariant, false, "Mandag")]
    [InlineData(GlobalizationLcidConstants.UnitedStates, true, "Monday")]
    [InlineData(GlobalizationLcidConstants.UnitedStates, false, "Mandag")]
    [InlineData(GlobalizationLcidConstants.Denmark, false, "Monday")]
    [InlineData(GlobalizationLcidConstants.Denmark, true, "Mandag")]
    public void TryParseDescription(int arrangeUiLcid, bool expected, string input)
    {
        // Arrange
        var culture = arrangeUiLcid == 0
            ? GlobalizationConstants.EnglishCultureInfo
            : new CultureInfo(arrangeUiLcid);

        // Act
        var actual = DayOfWeekHelper.TryParseDescription(input, out var dayOfWeek, culture);

        // Assert
        Assert.Equal(expected, actual);
        if (actual)
        {
            Assert.Equal(input, DayOfWeekHelper.GetDescription(dayOfWeek, culture));
        }
    }
}