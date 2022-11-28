namespace Atc.Tests.XUnitTestData;

[SuppressMessage("StyleCop.CSharp.LayoutRules", "SA1509:OpeningBracesMustNotBePrecededByBlankLine", Justification = "OK.")]
internal static class TestMemberDataForExtensionsInteger
{
    public static TheoryData<int, string, int, bool> MonthNameData
        => new()
        {
            { GlobalizationLcidConstants.UnitedStates, "january", 1, false },
            { GlobalizationLcidConstants.UnitedStates, "february", 2, false },
            { GlobalizationLcidConstants.UnitedStates, "march", 3, false },
            { GlobalizationLcidConstants.UnitedStates, "april", 4, false },
            { GlobalizationLcidConstants.UnitedStates, "may", 5, false },
            { GlobalizationLcidConstants.UnitedStates, "june", 6, false },
            { GlobalizationLcidConstants.UnitedStates, "july", 7, false },
            { GlobalizationLcidConstants.UnitedStates, "august", 8, false },
            { GlobalizationLcidConstants.UnitedStates, "september", 9, false },
            { GlobalizationLcidConstants.UnitedStates, "october", 10, false },
            { GlobalizationLcidConstants.UnitedStates, "november", 11, false },
            { GlobalizationLcidConstants.UnitedStates, "december", 12, false },
            { GlobalizationLcidConstants.UnitedStates, "January", 1, true },
            { GlobalizationLcidConstants.UnitedStates, "February", 2, true },
            { GlobalizationLcidConstants.UnitedStates, "March", 3, true },
            { GlobalizationLcidConstants.UnitedStates, "April", 4, true },
            { GlobalizationLcidConstants.UnitedStates, "May", 5, true },
            { GlobalizationLcidConstants.UnitedStates, "June", 6, true },
            { GlobalizationLcidConstants.UnitedStates, "July", 7, true },
            { GlobalizationLcidConstants.UnitedStates, "August", 8, true },
            { GlobalizationLcidConstants.UnitedStates, "September", 9, true },
            { GlobalizationLcidConstants.UnitedStates, "October", 10, true },
            { GlobalizationLcidConstants.UnitedStates, "November", 11, true },
            { GlobalizationLcidConstants.UnitedStates, "December", 12, true },

            { GlobalizationLcidConstants.GreatBritain, "january", 1, false },
            { GlobalizationLcidConstants.GreatBritain, "february", 2, false },
            { GlobalizationLcidConstants.GreatBritain, "march", 3, false },
            { GlobalizationLcidConstants.GreatBritain, "april", 4, false },
            { GlobalizationLcidConstants.GreatBritain, "may", 5, false },
            { GlobalizationLcidConstants.GreatBritain, "june", 6, false },
            { GlobalizationLcidConstants.GreatBritain, "july", 7, false },
            { GlobalizationLcidConstants.GreatBritain, "august", 8, false },
            { GlobalizationLcidConstants.GreatBritain, "september", 9, false },
            { GlobalizationLcidConstants.GreatBritain, "october", 10, false },
            { GlobalizationLcidConstants.GreatBritain, "november", 11, false },
            { GlobalizationLcidConstants.GreatBritain, "december", 12, false },
            { GlobalizationLcidConstants.GreatBritain, "January", 1, true },
            { GlobalizationLcidConstants.GreatBritain, "February", 2, true },
            { GlobalizationLcidConstants.GreatBritain, "March", 3, true },
            { GlobalizationLcidConstants.GreatBritain, "April", 4, true },
            { GlobalizationLcidConstants.GreatBritain, "May", 5, true },
            { GlobalizationLcidConstants.GreatBritain, "June", 6, true },
            { GlobalizationLcidConstants.GreatBritain, "July", 7, true },
            { GlobalizationLcidConstants.GreatBritain, "August", 8, true },
            { GlobalizationLcidConstants.GreatBritain, "September", 9, true },
            { GlobalizationLcidConstants.GreatBritain, "October", 10, true },
            { GlobalizationLcidConstants.GreatBritain, "November", 11, true },
            { GlobalizationLcidConstants.GreatBritain, "December", 12, true },

            { GlobalizationLcidConstants.Denmark, "januar", 1, false },
            { GlobalizationLcidConstants.Denmark, "februar", 2, false },
            { GlobalizationLcidConstants.Denmark, "marts", 3, false },
            { GlobalizationLcidConstants.Denmark, "april", 4, false },
            { GlobalizationLcidConstants.Denmark, "maj", 5, false },
            { GlobalizationLcidConstants.Denmark, "juni", 6, false },
            { GlobalizationLcidConstants.Denmark, "juli", 7, false },
            { GlobalizationLcidConstants.Denmark, "august", 8, false },
            { GlobalizationLcidConstants.Denmark, "september", 9, false },
            { GlobalizationLcidConstants.Denmark, "oktober", 10, false },
            { GlobalizationLcidConstants.Denmark, "november", 11, false },
            { GlobalizationLcidConstants.Denmark, "december", 12, false },
            { GlobalizationLcidConstants.Denmark, "Januar", 1, true },
            { GlobalizationLcidConstants.Denmark, "Februar", 2, true },
            { GlobalizationLcidConstants.Denmark, "Marts", 3, true },
            { GlobalizationLcidConstants.Denmark, "April", 4, true },
            { GlobalizationLcidConstants.Denmark, "Maj", 5, true },
            { GlobalizationLcidConstants.Denmark, "Juni", 6, true },
            { GlobalizationLcidConstants.Denmark, "Juli", 7, true },
            { GlobalizationLcidConstants.Denmark, "August", 8, true },
            { GlobalizationLcidConstants.Denmark, "September", 9, true },
            { GlobalizationLcidConstants.Denmark, "Oktober", 10, true },
            { GlobalizationLcidConstants.Denmark, "November", 11, true },
            { GlobalizationLcidConstants.Denmark, "December", 12, true },

            { GlobalizationLcidConstants.Germany, "januar", 1, false },
            { GlobalizationLcidConstants.Germany, "februar", 2, false },
            { GlobalizationLcidConstants.Germany, "märz", 3, false },
            { GlobalizationLcidConstants.Germany, "april", 4, false },
            { GlobalizationLcidConstants.Germany, "mai", 5, false },
            { GlobalizationLcidConstants.Germany, "juni", 6, false },
            { GlobalizationLcidConstants.Germany, "juli", 7, false },
            { GlobalizationLcidConstants.Germany, "august", 8, false },
            { GlobalizationLcidConstants.Germany, "september", 9, false },
            { GlobalizationLcidConstants.Germany, "oktober", 10, false },
            { GlobalizationLcidConstants.Germany, "november", 11, false },
            { GlobalizationLcidConstants.Germany, "dezember", 12, false },
            { GlobalizationLcidConstants.Germany, "Januar", 1, true },
            { GlobalizationLcidConstants.Germany, "Februar", 2, true },
            { GlobalizationLcidConstants.Germany, "März", 3, true },
            { GlobalizationLcidConstants.Germany, "April", 4, true },
            { GlobalizationLcidConstants.Germany, "Mai", 5, true },
            { GlobalizationLcidConstants.Germany, "Juni", 6, true },
            { GlobalizationLcidConstants.Germany, "Juli", 7, true },
            { GlobalizationLcidConstants.Germany, "August", 8, true },
            { GlobalizationLcidConstants.Germany, "September", 9, true },
            { GlobalizationLcidConstants.Germany, "Oktober", 10, true },
            { GlobalizationLcidConstants.Germany, "November", 11, true },
            { GlobalizationLcidConstants.Germany, "Dezember", 12, true },
        };
}