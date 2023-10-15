// ReSharper disable StringLiteralTypo
namespace Atc.Tests.XUnitTestData;

internal static class TestMemberDataForDateTimeOffsetExtensions
{
    public static TheoryData<string, DateTimeOffset, int> GetPrettyTimeDiff()
    {
        var unitTestEnd = DateTimeOffset.Now;

        return new TheoryData<string, DateTimeOffset, int>
        {
            { "11.509 days", new DateTimeOffset(unitTestEnd.DateTime).AddDays(-11).AddHours(-12).AddMinutes(-13).AddSeconds(-14).AddMilliseconds(-15), GlobalizationLcidConstants.UnitedStates },
            { "12.213 hours", new DateTimeOffset(unitTestEnd.DateTime).AddHours(-12).AddMinutes(-13).AddSeconds(14).AddMilliseconds(-15), GlobalizationLcidConstants.UnitedStates },
            { "13.234 min", new DateTimeOffset(unitTestEnd.DateTime).AddMinutes(-13).AddSeconds(-14).AddMilliseconds(-15), GlobalizationLcidConstants.UnitedStates },
            { "14.015 sec", new DateTimeOffset(unitTestEnd.DateTime).AddSeconds(-14).AddMilliseconds(-15), GlobalizationLcidConstants.UnitedStates },
            { "15.000 ms", new DateTimeOffset(unitTestEnd.DateTime).AddMilliseconds(-15), GlobalizationLcidConstants.UnitedStates },
            { "11.509 days", new DateTimeOffset(unitTestEnd.DateTime).AddDays(-11).AddHours(-12).AddMinutes(-13).AddSeconds(-14).AddMilliseconds(-15), GlobalizationLcidConstants.GreatBritain },
            { "12.213 hours", new DateTimeOffset(unitTestEnd.DateTime).AddHours(-12).AddMinutes(-13).AddSeconds(14).AddMilliseconds(-15), GlobalizationLcidConstants.GreatBritain },
            { "13.234 min", new DateTimeOffset(unitTestEnd.DateTime).AddMinutes(-13).AddSeconds(-14).AddMilliseconds(-15), GlobalizationLcidConstants.GreatBritain },
            { "14.015 sec", new DateTimeOffset(unitTestEnd.DateTime).AddSeconds(-14).AddMilliseconds(-15), GlobalizationLcidConstants.GreatBritain },
            { "15.000 ms", new DateTimeOffset(unitTestEnd.DateTime).AddMilliseconds(-15), GlobalizationLcidConstants.GreatBritain },
            { "11,509 dage", new DateTimeOffset(unitTestEnd.DateTime).AddDays(-11).AddHours(-12).AddMinutes(-13).AddSeconds(-14).AddMilliseconds(-15), GlobalizationLcidConstants.Denmark },
            { "12,213 timer", new DateTimeOffset(unitTestEnd.DateTime).AddHours(-12).AddMinutes(-13).AddSeconds(14).AddMilliseconds(-15), GlobalizationLcidConstants.Denmark },
            { "13,234 min", new DateTimeOffset(unitTestEnd.DateTime).AddMinutes(-13).AddSeconds(-14).AddMilliseconds(-15), GlobalizationLcidConstants.Denmark },
            { "14,015 sek", new DateTimeOffset(unitTestEnd.DateTime).AddSeconds(-14).AddMilliseconds(-15), GlobalizationLcidConstants.Denmark },
            { "15,000 ms", new DateTimeOffset(unitTestEnd.DateTime).AddMilliseconds(-15), GlobalizationLcidConstants.Denmark },
            { "11,509 tage", new DateTimeOffset(unitTestEnd.DateTime).AddDays(-11).AddHours(-12).AddMinutes(-13).AddSeconds(-14).AddMilliseconds(-15), GlobalizationLcidConstants.Germany },
            { "12,213 stunden", new DateTimeOffset(unitTestEnd.DateTime).AddHours(-12).AddMinutes(-13).AddSeconds(14).AddMilliseconds(-15), GlobalizationLcidConstants.Germany },
            { "13,234 min", new DateTimeOffset(unitTestEnd.DateTime).AddMinutes(-13).AddSeconds(-14).AddMilliseconds(-15), GlobalizationLcidConstants.Germany },
            { "14,015 sek", new DateTimeOffset(unitTestEnd.DateTime).AddSeconds(-14).AddMilliseconds(-15), GlobalizationLcidConstants.Germany },
            { "15,000 ms", new DateTimeOffset(unitTestEnd.DateTime).AddMilliseconds(-15), GlobalizationLcidConstants.Germany },
        };
    }

    public static TheoryData<string, DateTimeOffset, int, int> GetPrettyTimeDiffWithDecimalPrecision()
    {
        var unitTestEnd = DateTimeOffset.Now;

        return new TheoryData<string, DateTimeOffset, int, int>
        {
            { "11.5 days", new DateTimeOffset(unitTestEnd.DateTime).AddDays(-11).AddHours(-12).AddMinutes(-13).AddSeconds(-14).AddMilliseconds(-15), 1, GlobalizationLcidConstants.UnitedStates },
            { "12.2 hours", new DateTimeOffset(unitTestEnd.DateTime).AddHours(-12).AddMinutes(-13).AddSeconds(14).AddMilliseconds(-15), 1, GlobalizationLcidConstants.UnitedStates },
            { "13.2 min", new DateTimeOffset(unitTestEnd.DateTime).AddMinutes(-13).AddSeconds(-14).AddMilliseconds(-15), 1, GlobalizationLcidConstants.UnitedStates },
            { "14.0 sec", new DateTimeOffset(unitTestEnd.DateTime).AddSeconds(-14).AddMilliseconds(-15), 1, GlobalizationLcidConstants.UnitedStates },
            { "15.0 ms", new DateTimeOffset(unitTestEnd.DateTime).AddMilliseconds(-15), 1, GlobalizationLcidConstants.UnitedStates },
            { "11.51 days", new DateTimeOffset(unitTestEnd.DateTime).AddDays(-11).AddHours(-12).AddMinutes(-13).AddSeconds(-14).AddMilliseconds(-15), 2, GlobalizationLcidConstants.UnitedStates },
            { "12.21 hours", new DateTimeOffset(unitTestEnd.DateTime).AddHours(-12).AddMinutes(-13).AddSeconds(14).AddMilliseconds(-15), 2, GlobalizationLcidConstants.UnitedStates },
            { "13.23 min", new DateTimeOffset(unitTestEnd.DateTime).AddMinutes(-13).AddSeconds(-14).AddMilliseconds(-15), 2, GlobalizationLcidConstants.UnitedStates },
            { "14.02 sec", new DateTimeOffset(unitTestEnd.DateTime).AddSeconds(-14).AddMilliseconds(-15), 2, GlobalizationLcidConstants.UnitedStates },
            { "15.00 ms", new DateTimeOffset(unitTestEnd.DateTime).AddMilliseconds(-15), 2, GlobalizationLcidConstants.UnitedStates },
            { "11.509 days", new DateTimeOffset(unitTestEnd.DateTime).AddDays(-11).AddHours(-12).AddMinutes(-13).AddSeconds(-14).AddMilliseconds(-15), 3, GlobalizationLcidConstants.UnitedStates },
            { "12.213 hours", new DateTimeOffset(unitTestEnd.DateTime).AddHours(-12).AddMinutes(-13).AddSeconds(14).AddMilliseconds(-15), 3, GlobalizationLcidConstants.UnitedStates },
            { "13.234 min", new DateTimeOffset(unitTestEnd.DateTime).AddMinutes(-13).AddSeconds(-14).AddMilliseconds(-15), 3, GlobalizationLcidConstants.UnitedStates },
            { "14.015 sec", new DateTimeOffset(unitTestEnd.DateTime).AddSeconds(-14).AddMilliseconds(-15), 3, GlobalizationLcidConstants.UnitedStates },
            { "15.000 ms", new DateTimeOffset(unitTestEnd.DateTime).AddMilliseconds(-15), 3, GlobalizationLcidConstants.UnitedStates },
        };
    }

    public static TheoryData<string, DateTimeOffset, DateTimeOffset, int> GetPrettyTimeDiffWithEnd()
    {
        var unitTestEnd = DateTimeOffset.Now;

        return new TheoryData<string, DateTimeOffset, DateTimeOffset, int>
        {
            { "11.509 days", new DateTimeOffset(unitTestEnd.DateTime).AddDays(-11).AddHours(-12).AddMinutes(-13).AddSeconds(-14).AddMilliseconds(-15), unitTestEnd, GlobalizationLcidConstants.UnitedStates },
            { "12.213 hours", new DateTimeOffset(unitTestEnd.DateTime).AddHours(-12).AddMinutes(-13).AddSeconds(14).AddMilliseconds(-15), unitTestEnd, GlobalizationLcidConstants.UnitedStates },
            { "13.234 min", new DateTimeOffset(unitTestEnd.DateTime).AddMinutes(-13).AddSeconds(-14).AddMilliseconds(-15), unitTestEnd, GlobalizationLcidConstants.UnitedStates },
            { "14.015 sec", new DateTimeOffset(unitTestEnd.DateTime).AddSeconds(-14).AddMilliseconds(-15), unitTestEnd, GlobalizationLcidConstants.UnitedStates },
            { "15.000 ms", new DateTimeOffset(unitTestEnd.DateTime).AddMilliseconds(-15), unitTestEnd, GlobalizationLcidConstants.UnitedStates },
        };
    }

    public static TheoryData<string, DateTimeOffset, DateTimeOffset, int, int> GetPrettyTimeDiffWithEndNowAndDecimalPrecision()
    {
        var unitTestEnd = DateTimeOffset.Now;

        return new TheoryData<string, DateTimeOffset, DateTimeOffset, int, int>
        {
            { "11.5 days", new DateTimeOffset(unitTestEnd.DateTime).AddDays(-11).AddHours(-12).AddMinutes(-13).AddSeconds(-14).AddMilliseconds(-15), unitTestEnd, 1, GlobalizationLcidConstants.UnitedStates },
            { "12.2 hours", new DateTimeOffset(unitTestEnd.DateTime).AddHours(-12).AddMinutes(-13).AddSeconds(14).AddMilliseconds(-15), unitTestEnd, 1, GlobalizationLcidConstants.UnitedStates },
            { "13.2 min", new DateTimeOffset(unitTestEnd.DateTime).AddMinutes(-13).AddSeconds(-14).AddMilliseconds(-15), unitTestEnd, 1, GlobalizationLcidConstants.UnitedStates },
            { "14.0 sec", new DateTimeOffset(unitTestEnd.DateTime).AddSeconds(-14).AddMilliseconds(-15), unitTestEnd, 1, GlobalizationLcidConstants.UnitedStates },
            { "15.0 ms", new DateTimeOffset(unitTestEnd.DateTime).AddMilliseconds(-15), unitTestEnd, 1, GlobalizationLcidConstants.UnitedStates },
            { "11.51 days", new DateTimeOffset(unitTestEnd.DateTime).AddDays(-11).AddHours(-12).AddMinutes(-13).AddSeconds(-14).AddMilliseconds(-15), unitTestEnd, 2, GlobalizationLcidConstants.UnitedStates },
            { "12.21 hours", new DateTimeOffset(unitTestEnd.DateTime).AddHours(-12).AddMinutes(-13).AddSeconds(14).AddMilliseconds(-15), unitTestEnd, 2, GlobalizationLcidConstants.UnitedStates },
            { "13.23 min", new DateTimeOffset(unitTestEnd.DateTime).AddMinutes(-13).AddSeconds(-14).AddMilliseconds(-15), unitTestEnd, 2, GlobalizationLcidConstants.UnitedStates },
            { "14.02 sec", new DateTimeOffset(unitTestEnd.DateTime).AddSeconds(-14).AddMilliseconds(-15), unitTestEnd, 2, GlobalizationLcidConstants.UnitedStates },
            { "15.00 ms", new DateTimeOffset(unitTestEnd.DateTime).AddMilliseconds(-15), unitTestEnd, 2, GlobalizationLcidConstants.UnitedStates },
            { "11.509 days", new DateTimeOffset(unitTestEnd.DateTime).AddDays(-11).AddHours(-12).AddMinutes(-13).AddSeconds(-14).AddMilliseconds(-15), unitTestEnd, 3, GlobalizationLcidConstants.UnitedStates },
            { "12.213 hours", new DateTimeOffset(unitTestEnd.DateTime).AddHours(-12).AddMinutes(-13).AddSeconds(14).AddMilliseconds(-15), unitTestEnd, 3, GlobalizationLcidConstants.UnitedStates },
            { "13.234 min", new DateTimeOffset(unitTestEnd.DateTime).AddMinutes(-13).AddSeconds(-14).AddMilliseconds(-15), unitTestEnd, 3, GlobalizationLcidConstants.UnitedStates },
            { "14.015 sec", new DateTimeOffset(unitTestEnd.DateTime).AddSeconds(-14).AddMilliseconds(-15), unitTestEnd, 3, GlobalizationLcidConstants.UnitedStates },
            { "15.000 ms", new DateTimeOffset(unitTestEnd.DateTime).AddMilliseconds(-15), unitTestEnd, 3, GlobalizationLcidConstants.UnitedStates },
        };
    }
}