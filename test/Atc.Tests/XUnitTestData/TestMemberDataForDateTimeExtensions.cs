// ReSharper disable StringLiteralTypo
namespace Atc.Tests.XUnitTestData;

internal static class TestMemberDataForDateTimeExtensions
{
    public static TheoryData<string, DateTime, int> GetPrettyTimeDiff()
    {
        var unitTestEnd = DateTime.Now;

        return new TheoryData<string, DateTime, int>
        {
            { "11.509 days", new DateTime(unitTestEnd.Ticks).AddDays(-11).AddHours(-12).AddMinutes(-13).AddSeconds(-14).AddMilliseconds(-15), GlobalizationLcidConstants.UnitedStates },
            { "12.213 hours", new DateTime(unitTestEnd.Ticks).AddHours(-12).AddMinutes(-13).AddSeconds(14).AddMilliseconds(-15), GlobalizationLcidConstants.UnitedStates },
            { "13.234 min", new DateTime(unitTestEnd.Ticks).AddMinutes(-13).AddSeconds(-14).AddMilliseconds(-15), GlobalizationLcidConstants.UnitedStates },
            { "14.015 sec", new DateTime(unitTestEnd.Ticks).AddSeconds(-14).AddMilliseconds(-15), GlobalizationLcidConstants.UnitedStates },
            { "15.000 ms", new DateTime(unitTestEnd.Ticks).AddMilliseconds(-15), GlobalizationLcidConstants.UnitedStates },
            { "11.509 days", new DateTime(unitTestEnd.Ticks).AddDays(-11).AddHours(-12).AddMinutes(-13).AddSeconds(-14).AddMilliseconds(-15), GlobalizationLcidConstants.GreatBritain },
            { "12.213 hours", new DateTime(unitTestEnd.Ticks).AddHours(-12).AddMinutes(-13).AddSeconds(14).AddMilliseconds(-15), GlobalizationLcidConstants.GreatBritain },
            { "13.234 min", new DateTime(unitTestEnd.Ticks).AddMinutes(-13).AddSeconds(-14).AddMilliseconds(-15), GlobalizationLcidConstants.GreatBritain },
            { "14.015 sec", new DateTime(unitTestEnd.Ticks).AddSeconds(-14).AddMilliseconds(-15), GlobalizationLcidConstants.GreatBritain },
            { "15.000 ms", new DateTime(unitTestEnd.Ticks).AddMilliseconds(-15), GlobalizationLcidConstants.GreatBritain },
            { "11,509 dage", new DateTime(unitTestEnd.Ticks).AddDays(-11).AddHours(-12).AddMinutes(-13).AddSeconds(-14).AddMilliseconds(-15), GlobalizationLcidConstants.Denmark },
            { "12,213 timer", new DateTime(unitTestEnd.Ticks).AddHours(-12).AddMinutes(-13).AddSeconds(14).AddMilliseconds(-15), GlobalizationLcidConstants.Denmark },
            { "13,234 min", new DateTime(unitTestEnd.Ticks).AddMinutes(-13).AddSeconds(-14).AddMilliseconds(-15), GlobalizationLcidConstants.Denmark },
            { "14,015 sek", new DateTime(unitTestEnd.Ticks).AddSeconds(-14).AddMilliseconds(-15), GlobalizationLcidConstants.Denmark },
            { "15,000 ms", new DateTime(unitTestEnd.Ticks).AddMilliseconds(-15), GlobalizationLcidConstants.Denmark },
            { "11,509 tage", new DateTime(unitTestEnd.Ticks).AddDays(-11).AddHours(-12).AddMinutes(-13).AddSeconds(-14).AddMilliseconds(-15), GlobalizationLcidConstants.Germany },
            { "12,213 stunden", new DateTime(unitTestEnd.Ticks).AddHours(-12).AddMinutes(-13).AddSeconds(14).AddMilliseconds(-15), GlobalizationLcidConstants.Germany },
            { "13,234 min", new DateTime(unitTestEnd.Ticks).AddMinutes(-13).AddSeconds(-14).AddMilliseconds(-15), GlobalizationLcidConstants.Germany },
            { "14,015 sek", new DateTime(unitTestEnd.Ticks).AddSeconds(-14).AddMilliseconds(-15), GlobalizationLcidConstants.Germany },
            { "15,000 ms", new DateTime(unitTestEnd.Ticks).AddMilliseconds(-15), GlobalizationLcidConstants.Germany },
        };
    }

    public static TheoryData<string, DateTime, int, int> GetPrettyTimeDiffWithDecimalPrecision()
    {
        var unitTestEnd = DateTime.Now;

        return new TheoryData<string, DateTime, int, int>
        {
            { "11.5 days", new DateTime(unitTestEnd.Ticks).AddDays(-11).AddHours(-12).AddMinutes(-13).AddSeconds(-14).AddMilliseconds(-15), 1, GlobalizationLcidConstants.UnitedStates },
            { "12.2 hours", new DateTime(unitTestEnd.Ticks).AddHours(-12).AddMinutes(-13).AddSeconds(14).AddMilliseconds(-15), 1, GlobalizationLcidConstants.UnitedStates },
            { "13.2 min", new DateTime(unitTestEnd.Ticks).AddMinutes(-13).AddSeconds(-14).AddMilliseconds(-15), 1, GlobalizationLcidConstants.UnitedStates },
            { "14.0 sec", new DateTime(unitTestEnd.Ticks).AddSeconds(-14).AddMilliseconds(-15), 1, GlobalizationLcidConstants.UnitedStates },
            { "15.0 ms", new DateTime(unitTestEnd.Ticks).AddMilliseconds(-15), 1, GlobalizationLcidConstants.UnitedStates },
            { "11.51 days", new DateTime(unitTestEnd.Ticks).AddDays(-11).AddHours(-12).AddMinutes(-13).AddSeconds(-14).AddMilliseconds(-15), 2, GlobalizationLcidConstants.UnitedStates },
            { "12.21 hours", new DateTime(unitTestEnd.Ticks).AddHours(-12).AddMinutes(-13).AddSeconds(14).AddMilliseconds(-15), 2, GlobalizationLcidConstants.UnitedStates },
            { "13.23 min", new DateTime(unitTestEnd.Ticks).AddMinutes(-13).AddSeconds(-14).AddMilliseconds(-15), 2, GlobalizationLcidConstants.UnitedStates },
            { "14.02 sec", new DateTime(unitTestEnd.Ticks).AddSeconds(-14).AddMilliseconds(-15), 2, GlobalizationLcidConstants.UnitedStates },
            { "15.00 ms", new DateTime(unitTestEnd.Ticks).AddMilliseconds(-15), 2, GlobalizationLcidConstants.UnitedStates },
            { "11.509 days", new DateTime(unitTestEnd.Ticks).AddDays(-11).AddHours(-12).AddMinutes(-13).AddSeconds(-14).AddMilliseconds(-15), 3, GlobalizationLcidConstants.UnitedStates },
            { "12.213 hours", new DateTime(unitTestEnd.Ticks).AddHours(-12).AddMinutes(-13).AddSeconds(14).AddMilliseconds(-15), 3, GlobalizationLcidConstants.UnitedStates },
            { "13.234 min", new DateTime(unitTestEnd.Ticks).AddMinutes(-13).AddSeconds(-14).AddMilliseconds(-15), 3, GlobalizationLcidConstants.UnitedStates },
            { "14.015 sec", new DateTime(unitTestEnd.Ticks).AddSeconds(-14).AddMilliseconds(-15), 3, GlobalizationLcidConstants.UnitedStates },
            { "15.000 ms", new DateTime(unitTestEnd.Ticks).AddMilliseconds(-15), 3, GlobalizationLcidConstants.UnitedStates },
        };
    }

    public static TheoryData<string, DateTime, DateTime, int> GetPrettyTimeDiffWithEnd()
    {
        var unitTestEnd = DateTime.Now;

        return new TheoryData<string, DateTime, DateTime, int>
        {
            { "11.509 days", new DateTime(unitTestEnd.Ticks).AddDays(-11).AddHours(-12).AddMinutes(-13).AddSeconds(-14).AddMilliseconds(-15), unitTestEnd, GlobalizationLcidConstants.UnitedStates },
            { "12.213 hours", new DateTime(unitTestEnd.Ticks).AddHours(-12).AddMinutes(-13).AddSeconds(14).AddMilliseconds(-15), unitTestEnd, GlobalizationLcidConstants.UnitedStates },
            { "13.234 min", new DateTime(unitTestEnd.Ticks).AddMinutes(-13).AddSeconds(-14).AddMilliseconds(-15), unitTestEnd, GlobalizationLcidConstants.UnitedStates },
            { "14.015 sec", new DateTime(unitTestEnd.Ticks).AddSeconds(-14).AddMilliseconds(-15), unitTestEnd, GlobalizationLcidConstants.UnitedStates },
            { "15.000 ms", new DateTime(unitTestEnd.Ticks).AddMilliseconds(-15), unitTestEnd, GlobalizationLcidConstants.UnitedStates },
        };
    }

    public static TheoryData<string, DateTime, DateTime, int, int> GetPrettyTimeDiffWithEndNowAndDecimalPrecision()
    {
        var unitTestEnd = DateTime.Now;

        return new TheoryData<string, DateTime, DateTime, int, int>
        {
            { "11.5 days", new DateTime(unitTestEnd.Ticks).AddDays(-11).AddHours(-12).AddMinutes(-13).AddSeconds(-14).AddMilliseconds(-15), unitTestEnd, 1, GlobalizationLcidConstants.UnitedStates },
            { "12.2 hours", new DateTime(unitTestEnd.Ticks).AddHours(-12).AddMinutes(-13).AddSeconds(14).AddMilliseconds(-15), unitTestEnd, 1, GlobalizationLcidConstants.UnitedStates },
            { "13.2 min", new DateTime(unitTestEnd.Ticks).AddMinutes(-13).AddSeconds(-14).AddMilliseconds(-15), unitTestEnd, 1, GlobalizationLcidConstants.UnitedStates },
            { "14.0 sec", new DateTime(unitTestEnd.Ticks).AddSeconds(-14).AddMilliseconds(-15), unitTestEnd, 1, GlobalizationLcidConstants.UnitedStates },
            { "15.0 ms", new DateTime(unitTestEnd.Ticks).AddMilliseconds(-15), unitTestEnd, 1, GlobalizationLcidConstants.UnitedStates },
            { "11.51 days", new DateTime(unitTestEnd.Ticks).AddDays(-11).AddHours(-12).AddMinutes(-13).AddSeconds(-14).AddMilliseconds(-15), unitTestEnd, 2, GlobalizationLcidConstants.UnitedStates },
            { "12.21 hours", new DateTime(unitTestEnd.Ticks).AddHours(-12).AddMinutes(-13).AddSeconds(14).AddMilliseconds(-15), unitTestEnd, 2, GlobalizationLcidConstants.UnitedStates },
            { "13.23 min", new DateTime(unitTestEnd.Ticks).AddMinutes(-13).AddSeconds(-14).AddMilliseconds(-15), unitTestEnd, 2, GlobalizationLcidConstants.UnitedStates },
            { "14.02 sec", new DateTime(unitTestEnd.Ticks).AddSeconds(-14).AddMilliseconds(-15), unitTestEnd, 2, GlobalizationLcidConstants.UnitedStates },
            { "15.00 ms", new DateTime(unitTestEnd.Ticks).AddMilliseconds(-15), unitTestEnd, 2, GlobalizationLcidConstants.UnitedStates },
            { "11.509 days", new DateTime(unitTestEnd.Ticks).AddDays(-11).AddHours(-12).AddMinutes(-13).AddSeconds(-14).AddMilliseconds(-15), unitTestEnd, 3, GlobalizationLcidConstants.UnitedStates },
            { "12.213 hours", new DateTime(unitTestEnd.Ticks).AddHours(-12).AddMinutes(-13).AddSeconds(14).AddMilliseconds(-15), unitTestEnd, 3, GlobalizationLcidConstants.UnitedStates },
            { "13.234 min", new DateTime(unitTestEnd.Ticks).AddMinutes(-13).AddSeconds(-14).AddMilliseconds(-15), unitTestEnd, 3, GlobalizationLcidConstants.UnitedStates },
            { "14.015 sec", new DateTime(unitTestEnd.Ticks).AddSeconds(-14).AddMilliseconds(-15), unitTestEnd, 3, GlobalizationLcidConstants.UnitedStates },
            { "15.000 ms", new DateTime(unitTestEnd.Ticks).AddMilliseconds(-15), unitTestEnd, 3, GlobalizationLcidConstants.UnitedStates },
        };
    }
}