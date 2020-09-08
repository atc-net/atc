﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Atc.Tests.XUnitTestData
{
    internal class TestMemberDataForExtensionsInteger
    {
        public static IEnumerable<object[]> MonthNameData =>
            new List<object[]>
            {
                new object[] { GlobalizationLcidConstants.UnitedStates, "january", 1, false },
                new object[] { GlobalizationLcidConstants.UnitedStates, "february", 2, false },
                new object[] { GlobalizationLcidConstants.UnitedStates, "march", 3, false },
                new object[] { GlobalizationLcidConstants.UnitedStates, "april", 4, false },
                new object[] { GlobalizationLcidConstants.UnitedStates, "may", 5, false },
                new object[] { GlobalizationLcidConstants.UnitedStates, "june", 6, false },
                new object[] { GlobalizationLcidConstants.UnitedStates, "july", 7, false },
                new object[] { GlobalizationLcidConstants.UnitedStates, "august", 8, false },
                new object[] { GlobalizationLcidConstants.UnitedStates, "september", 9, false },
                new object[] { GlobalizationLcidConstants.UnitedStates, "october", 10, false },
                new object[] { GlobalizationLcidConstants.UnitedStates, "november", 11, false },
                new object[] { GlobalizationLcidConstants.UnitedStates, "december", 12, false },
                new object[] { GlobalizationLcidConstants.UnitedStates, "January", 1, true },
                new object[] { GlobalizationLcidConstants.UnitedStates, "February", 2, true },
                new object[] { GlobalizationLcidConstants.UnitedStates, "March", 3, true },
                new object[] { GlobalizationLcidConstants.UnitedStates, "April", 4, true },
                new object[] { GlobalizationLcidConstants.UnitedStates, "May", 5, true },
                new object[] { GlobalizationLcidConstants.UnitedStates, "June", 6, true },
                new object[] { GlobalizationLcidConstants.UnitedStates, "July", 7, true },
                new object[] { GlobalizationLcidConstants.UnitedStates, "August", 8, true },
                new object[] { GlobalizationLcidConstants.UnitedStates, "September", 9, true },
                new object[] { GlobalizationLcidConstants.UnitedStates, "October", 10, true },
                new object[] { GlobalizationLcidConstants.UnitedStates, "November", 11, true },
                new object[] { GlobalizationLcidConstants.UnitedStates, "December", 12, true },

                new object[] { GlobalizationLcidConstants.GreatBritain, "january", 1, false },
                new object[] { GlobalizationLcidConstants.GreatBritain, "february", 2, false },
                new object[] { GlobalizationLcidConstants.GreatBritain, "march", 3, false },
                new object[] { GlobalizationLcidConstants.GreatBritain, "april", 4, false },
                new object[] { GlobalizationLcidConstants.GreatBritain, "may", 5, false },
                new object[] { GlobalizationLcidConstants.GreatBritain, "june", 6, false },
                new object[] { GlobalizationLcidConstants.GreatBritain, "july", 7, false },
                new object[] { GlobalizationLcidConstants.GreatBritain, "august", 8, false },
                new object[] { GlobalizationLcidConstants.GreatBritain, "september", 9, false },
                new object[] { GlobalizationLcidConstants.GreatBritain, "october", 10, false },
                new object[] { GlobalizationLcidConstants.GreatBritain, "november", 11, false },
                new object[] { GlobalizationLcidConstants.GreatBritain, "december", 12, false },
                new object[] { GlobalizationLcidConstants.GreatBritain, "January", 1, true },
                new object[] { GlobalizationLcidConstants.GreatBritain, "February", 2, true },
                new object[] { GlobalizationLcidConstants.GreatBritain, "March", 3, true },
                new object[] { GlobalizationLcidConstants.GreatBritain, "April", 4, true },
                new object[] { GlobalizationLcidConstants.GreatBritain, "May", 5, true },
                new object[] { GlobalizationLcidConstants.GreatBritain, "June", 6, true },
                new object[] { GlobalizationLcidConstants.GreatBritain, "July", 7, true },
                new object[] { GlobalizationLcidConstants.GreatBritain, "August", 8, true },
                new object[] { GlobalizationLcidConstants.GreatBritain, "September", 9, true },
                new object[] { GlobalizationLcidConstants.GreatBritain, "October", 10, true },
                new object[] { GlobalizationLcidConstants.GreatBritain, "November", 11, true },
                new object[] { GlobalizationLcidConstants.GreatBritain, "December", 12, true },

                new object[] { GlobalizationLcidConstants.Denmark, "januar", 1, false },
                new object[] { GlobalizationLcidConstants.Denmark, "februar", 2, false },
                new object[] { GlobalizationLcidConstants.Denmark, "marts", 3, false },
                new object[] { GlobalizationLcidConstants.Denmark, "april", 4, false },
                new object[] { GlobalizationLcidConstants.Denmark, "maj", 5, false },
                new object[] { GlobalizationLcidConstants.Denmark, "juni", 6, false },
                new object[] { GlobalizationLcidConstants.Denmark, "juli", 7, false },
                new object[] { GlobalizationLcidConstants.Denmark, "august", 8, false },
                new object[] { GlobalizationLcidConstants.Denmark, "september", 9, false },
                new object[] { GlobalizationLcidConstants.Denmark, "oktober", 10, false },
                new object[] { GlobalizationLcidConstants.Denmark, "november", 11, false },
                new object[] { GlobalizationLcidConstants.Denmark, "december", 12, false },
                new object[] { GlobalizationLcidConstants.Denmark, "Januar", 1, true },
                new object[] { GlobalizationLcidConstants.Denmark, "Februar", 2, true },
                new object[] { GlobalizationLcidConstants.Denmark, "Marts", 3, true },
                new object[] { GlobalizationLcidConstants.Denmark, "April", 4, true },
                new object[] { GlobalizationLcidConstants.Denmark, "Maj", 5, true },
                new object[] { GlobalizationLcidConstants.Denmark, "Juni", 6, true },
                new object[] { GlobalizationLcidConstants.Denmark, "Juli", 7, true },
                new object[] { GlobalizationLcidConstants.Denmark, "August", 8, true },
                new object[] { GlobalizationLcidConstants.Denmark, "September", 9, true },
                new object[] { GlobalizationLcidConstants.Denmark, "Oktober", 10, true },
                new object[] { GlobalizationLcidConstants.Denmark, "November", 11, true },
                new object[] { GlobalizationLcidConstants.Denmark, "December", 12, true },

                new object[] { GlobalizationLcidConstants.Germany, "januar", 1, false },
                new object[] { GlobalizationLcidConstants.Germany, "februar", 2, false },
                new object[] { GlobalizationLcidConstants.Germany, "märz", 3, false },
                new object[] { GlobalizationLcidConstants.Germany, "april", 4, false },
                new object[] { GlobalizationLcidConstants.Germany, "mai", 5, false },
                new object[] { GlobalizationLcidConstants.Germany, "juni", 6, false },
                new object[] { GlobalizationLcidConstants.Germany, "juli", 7, false },
                new object[] { GlobalizationLcidConstants.Germany, "august", 8, false },
                new object[] { GlobalizationLcidConstants.Germany, "september", 9, false },
                new object[] { GlobalizationLcidConstants.Germany, "oktober", 10, false },
                new object[] { GlobalizationLcidConstants.Germany, "november", 11, false },
                new object[] { GlobalizationLcidConstants.Germany, "dezember", 12, false },
                new object[] { GlobalizationLcidConstants.Germany, "Januar", 1, true },
                new object[] { GlobalizationLcidConstants.Germany, "Februar", 2, true },
                new object[] { GlobalizationLcidConstants.Germany, "März", 3, true },
                new object[] { GlobalizationLcidConstants.Germany, "April", 4, true },
                new object[] { GlobalizationLcidConstants.Germany, "Mai", 5, true },
                new object[] { GlobalizationLcidConstants.Germany, "Juni", 6, true },
                new object[] { GlobalizationLcidConstants.Germany, "Juli", 7, true },
                new object[] { GlobalizationLcidConstants.Germany, "August", 8, true },
                new object[] { GlobalizationLcidConstants.Germany, "September", 9, true },
                new object[] { GlobalizationLcidConstants.Germany, "Oktober", 10, true },
                new object[] { GlobalizationLcidConstants.Germany, "November", 11, true },
                new object[] { GlobalizationLcidConstants.Germany, "Dezember", 12, true },
            };
    }
}