// ReSharper disable StringLiteralTypo
namespace Atc.Tests.XUnitTestData;

internal static class TestMemberDataForTimeSpanExtensions
{
    public static TheoryData<string, TimeSpan, int> GetPrettyTime()
        => new()
        {
            { "11,509 days", new TimeSpan(11, 12, 13, 14, 15), GlobalizationLcidConstants.UnitedStates },
            { "12,213 hours", new TimeSpan(0, 12, 13, 14, 15), GlobalizationLcidConstants.UnitedStates },
            { "13,234 min", new TimeSpan(0, 0, 13, 14, 15), GlobalizationLcidConstants.UnitedStates },
            { "14,015 sec", new TimeSpan(0, 0, 0, 14, 15), GlobalizationLcidConstants.UnitedStates },
            { "15,000 ms", new TimeSpan(0, 0, 0, 0, 15), GlobalizationLcidConstants.UnitedStates },
            { "11,509 days", new TimeSpan(11, 12, 13, 14, 15), GlobalizationLcidConstants.GreatBritain },
            { "12,213 hours", new TimeSpan(0, 12, 13, 14, 15), GlobalizationLcidConstants.GreatBritain },
            { "13,234 min", new TimeSpan(0, 0, 13, 14, 15), GlobalizationLcidConstants.GreatBritain },
            { "14,015 sec", new TimeSpan(0, 0, 0, 14, 15), GlobalizationLcidConstants.GreatBritain },
            { "15,000 ms", new TimeSpan(0, 0, 0, 0, 15), GlobalizationLcidConstants.GreatBritain },
            { "11,509 dage", new TimeSpan(11, 12, 13, 14, 15), GlobalizationLcidConstants.Denmark },
            { "12,213 timer", new TimeSpan(0, 12, 13, 14, 15), GlobalizationLcidConstants.Denmark },
            { "13,234 min", new TimeSpan(0, 0, 13, 14, 15), GlobalizationLcidConstants.Denmark },
            { "14,015 sek", new TimeSpan(0, 0, 0, 14, 15), GlobalizationLcidConstants.Denmark },
            { "15,000 ms", new TimeSpan(0, 0, 0, 0, 15), GlobalizationLcidConstants.Denmark },
            { "11,509 tage", new TimeSpan(11, 12, 13, 14, 15), GlobalizationLcidConstants.Germany },
            { "12,213 stunden", new TimeSpan(0, 12, 13, 14, 15), GlobalizationLcidConstants.Germany },
            { "13,234 min", new TimeSpan(0, 0, 13, 14, 15), GlobalizationLcidConstants.Germany },
            { "14,015 sec", new TimeSpan(0, 0, 0, 14, 15), GlobalizationLcidConstants.Germany },
            { "15,000 ms", new TimeSpan(0, 0, 0, 0, 15), GlobalizationLcidConstants.Germany },
        };

    public static TheoryData<string, TimeSpan, int, int> GetPrettyTimeWithDecimalPrecision()
        => new()
        {
            { "11,5 days", new TimeSpan(11, 12, 13, 14, 15), 1, GlobalizationLcidConstants.UnitedStates },
            { "12,2 hours", new TimeSpan(0, 12, 13, 14, 15), 1, GlobalizationLcidConstants.UnitedStates },
            { "13,2 min", new TimeSpan(0, 0, 13, 14, 15), 1, GlobalizationLcidConstants.UnitedStates },
            { "14,0 sec", new TimeSpan(0, 0, 0, 14, 15), 1, GlobalizationLcidConstants.UnitedStates },
            { "15,0 ms", new TimeSpan(0, 0, 0, 0, 15), 1, GlobalizationLcidConstants.UnitedStates },
            { "11,51 days", new TimeSpan(11, 12, 13, 14, 15), 2, GlobalizationLcidConstants.UnitedStates },
            { "12,21 hours", new TimeSpan(0, 12, 13, 14, 15), 2, GlobalizationLcidConstants.UnitedStates },
            { "13,23 min", new TimeSpan(0, 0, 13, 14, 15), 2, GlobalizationLcidConstants.UnitedStates },
            { "14,02 sec", new TimeSpan(0, 0, 0, 14, 15), 2, GlobalizationLcidConstants.UnitedStates },
            { "15,00 ms", new TimeSpan(0, 0, 0, 0, 15), 2, GlobalizationLcidConstants.UnitedStates },
            { "11,509 days", new TimeSpan(11, 12, 13, 14, 15), 3, GlobalizationLcidConstants.UnitedStates },
            { "12,213 hours", new TimeSpan(0, 12, 13, 14, 15), 3, GlobalizationLcidConstants.UnitedStates },
            { "13,234 min", new TimeSpan(0, 0, 13, 14, 15), 3, GlobalizationLcidConstants.UnitedStates },
            { "14,015 sec", new TimeSpan(0, 0, 0, 14, 15), 3, GlobalizationLcidConstants.UnitedStates },
            { "15,000 ms", new TimeSpan(0, 0, 0, 0, 15), 3, GlobalizationLcidConstants.UnitedStates },
        };
}