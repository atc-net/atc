using System.Collections.Generic;

namespace Atc.Tests.XUnitTestData
{
    internal static class TestMemberDataForCultureHelper
    {
        public static IEnumerable<object[]> GetCulturesDisplayLanguageLcidIncludeOnlyLcidsData =>
            new List<object[]>
            {
                new object[]
                {
                    4,
                    new[] { "Denmark", "Germany", "United Kingdom", "United States" },
                    new[] { "Danish", "German", "English", "English" },
                    GlobalizationLcidConstants.UnitedStates,
                    new[]
                    {
                        GlobalizationLcidConstants.UnitedStates,
                        GlobalizationLcidConstants.GreatBritain,
                        GlobalizationLcidConstants.Denmark,
                        GlobalizationLcidConstants.Germany,
                    },
                },
                new object[]
                {
                    4,
                    new[] { "Denmark", "Germany", "United Kingdom", "United States" },
                    new[] { "Danish", "German", "English", "English" },
                    GlobalizationLcidConstants.GreatBritain,
                    new[]
                    {
                        GlobalizationLcidConstants.UnitedStates,
                        GlobalizationLcidConstants.GreatBritain,
                        GlobalizationLcidConstants.Denmark,
                        GlobalizationLcidConstants.Germany,
                    },
                },
                new object[]
                {
                    4,
                    new[] { "Danmark", "Tyskland", "Storbritannien", "USA" },
                    new[] { "Dansk", "Tysk", "Engelsk", "Engelsk" },
                    GlobalizationLcidConstants.Denmark,
                    new[]
                    {
                        GlobalizationLcidConstants.UnitedStates,
                        GlobalizationLcidConstants.GreatBritain,
                        GlobalizationLcidConstants.Denmark,
                        GlobalizationLcidConstants.Germany,
                    },
                },
                new object[]
                {
                    4,
                    new[] { "Dänemark", "Deutschland", "Großbritannien", "Vereinigte Staaten" },
                    new[] { "Dänisch", "Deutsche", "Englisch", "Englisch" },
                    GlobalizationLcidConstants.Germany,
                    new[]
                    {
                        GlobalizationLcidConstants.UnitedStates,
                        GlobalizationLcidConstants.GreatBritain,
                        GlobalizationLcidConstants.Denmark,
                        GlobalizationLcidConstants.Germany,
                    },
                },
            };

        public static IEnumerable<object[]> GetCulturesDisplayLanguageLcidIncludeOnlyCultureNamesData =>
           new List<object[]>
           {
                new object[]
                {
                    4,
                    new[] { "Denmark", "Germany", "United Kingdom", "United States" },
                    new[] { "Danish", "German", "English", "English" },
                    GlobalizationLcidConstants.UnitedStates,
                    new[] { "en-US", "en-GB", "da-DK", "de-DE" },
                },
                new object[]
                {
                    4,
                    new[] { "Denmark", "Germany", "United Kingdom", "United States" },
                    new[] { "Danish", "German", "English", "English" },
                    GlobalizationLcidConstants.GreatBritain,
                    new[] { "en-US", "en-GB", "da-DK", "de-DE" },
                },
                new object[]
                {
                    4,
                    new[] { "Danmark", "Tyskland", "Storbritannien", "USA" },
                    new[] { "Dansk", "Tysk", "Engelsk", "Engelsk" },
                    GlobalizationLcidConstants.Denmark,
                    new[] { "en-US", "en-GB", "da-DK", "de-DE" },
                },
                new object[]
                {
                    4,
                    new[] { "Dänemark", "Deutschland", "Großbritannien", "Vereinigte Staaten" },
                    new[] { "Dänisch", "Deutsche", "Englisch", "Englisch" },
                    GlobalizationLcidConstants.Germany,
                    new[] { "en-US", "en-GB", "da-DK", "de-DE" },
                },
           };

        public static IEnumerable<object[]> GetCultureByLcidDisplayLanguageLcidData =>
            new List<object[]>
            {
                new object[] { "United States", "English", GlobalizationLcidConstants.UnitedStates, GlobalizationLcidConstants.UnitedStates },
                new object[] { "United Kingdom", "English", GlobalizationLcidConstants.GreatBritain, GlobalizationLcidConstants.UnitedStates },
                new object[] { "Denmark", "Danish", GlobalizationLcidConstants.Denmark, GlobalizationLcidConstants.UnitedStates },
                new object[] { "Germany", "German", GlobalizationLcidConstants.Germany, GlobalizationLcidConstants.UnitedStates },

                new object[] { "United States", "English", GlobalizationLcidConstants.UnitedStates, GlobalizationLcidConstants.GreatBritain },
                new object[] { "United Kingdom", "English", GlobalizationLcidConstants.GreatBritain, GlobalizationLcidConstants.GreatBritain },
                new object[] { "Denmark", "Danish", GlobalizationLcidConstants.Denmark, GlobalizationLcidConstants.GreatBritain },
                new object[] { "Germany", "German", GlobalizationLcidConstants.Germany, GlobalizationLcidConstants.GreatBritain },

                new object[] { "USA", "Engelsk", GlobalizationLcidConstants.UnitedStates, GlobalizationLcidConstants.Denmark },
                new object[] { "Storbritannien", "Engelsk", GlobalizationLcidConstants.GreatBritain, GlobalizationLcidConstants.Denmark },
                new object[] { "Danmark", "Dansk", GlobalizationLcidConstants.Denmark, GlobalizationLcidConstants.Denmark },
                new object[] { "Tyskland", "Tysk", GlobalizationLcidConstants.Germany, GlobalizationLcidConstants.Denmark },

                new object[] { "Vereinigte Staaten", "Englisch", GlobalizationLcidConstants.UnitedStates, GlobalizationLcidConstants.Germany },
                new object[] { "Großbritannien", "Englisch", GlobalizationLcidConstants.GreatBritain, GlobalizationLcidConstants.Germany },
                new object[] { "Dänemark", "Dänisch", GlobalizationLcidConstants.Denmark, GlobalizationLcidConstants.Germany },
                new object[] { "Deutschland", "Deutsche", GlobalizationLcidConstants.Germany, GlobalizationLcidConstants.Germany },
            };

        public static IEnumerable<object[]> GetCultureByCountryCodeA2LcidDisplayLanguageLcidData =>
            new List<object[]>
            {
                new object[] { "United States", "English", "US", GlobalizationLcidConstants.UnitedStates },
                new object[] { "United Kingdom", "English", "GB", GlobalizationLcidConstants.UnitedStates },
                new object[] { "Denmark", "Danish", "DK", GlobalizationLcidConstants.UnitedStates },
                new object[] { "Germany", "German", "DE", GlobalizationLcidConstants.UnitedStates },

                new object[] { "United States", "English", "US", GlobalizationLcidConstants.GreatBritain },
                new object[] { "United Kingdom", "English", "GB", GlobalizationLcidConstants.GreatBritain },
                new object[] { "Denmark", "Danish", "DK", GlobalizationLcidConstants.GreatBritain },
                new object[] { "Germany", "German", "DE", GlobalizationLcidConstants.GreatBritain },

                new object[] { "USA", "Engelsk", "US", GlobalizationLcidConstants.Denmark },
                new object[] { "Storbritannien", "Engelsk", "GB", GlobalizationLcidConstants.Denmark },
                new object[] { "Danmark", "Dansk", "DK", GlobalizationLcidConstants.Denmark },
                new object[] { "Tyskland", "Tysk", "DE", GlobalizationLcidConstants.Denmark },

                new object[] { "Vereinigte Staaten", "Englisch", "US", GlobalizationLcidConstants.Germany },
                new object[] { "Großbritannien", "Englisch", "GB", GlobalizationLcidConstants.Germany },
                new object[] { "Dänemark", "Dänisch", "DK", GlobalizationLcidConstants.Germany },
                new object[] { "Deutschland", "Deutsche", "DE", GlobalizationLcidConstants.Germany },
            };

        public static IEnumerable<object[]> GetCultureFromValueDisplayLanguageLcidData =>
            new List<object[]>
            {
                new object[] { "United States", "English", "US", GlobalizationLcidConstants.UnitedStates },
                new object[] { "United Kingdom", "English", "GB", GlobalizationLcidConstants.UnitedStates },
                new object[] { "Denmark", "Danish", "DK", GlobalizationLcidConstants.UnitedStates },
                new object[] { "Germany", "German", "DE", GlobalizationLcidConstants.UnitedStates },

                new object[] { "United States", "English", "US", GlobalizationLcidConstants.GreatBritain },
                new object[] { "United Kingdom", "English", "GB", GlobalizationLcidConstants.GreatBritain },
                new object[] { "Denmark", "Danish", "DK", GlobalizationLcidConstants.GreatBritain },
                new object[] { "Germany", "German", "DE", GlobalizationLcidConstants.GreatBritain },

                new object[] { "USA", "Engelsk", "US", GlobalizationLcidConstants.Denmark },
                new object[] { "Storbritannien", "Engelsk", "GB", GlobalizationLcidConstants.Denmark },
                new object[] { "Danmark", "Dansk", "DK", GlobalizationLcidConstants.Denmark },
                new object[] { "Deutschland", "Deutsche", "DE", GlobalizationLcidConstants.Germany },

                new object[] { "Vereinigte Staaten", "Englisch", "US", GlobalizationLcidConstants.Germany },
                new object[] { "Großbritannien", "Englisch", "GB", GlobalizationLcidConstants.Germany },
                new object[] { "Dänemark", "Dänisch", "DK", GlobalizationLcidConstants.Germany },
                new object[] { "Deutschland", "Deutsche", "DE", GlobalizationLcidConstants.Germany },
            };

        public static IEnumerable<object[]> GetCultureFromValueDisplayLanguageLcidIncludeLcidsData =>
            new List<object[]>
            {
                new object[] { "United States", "English", "US", new object[] { 1030, 1031, 1033, 2057 }, GlobalizationLcidConstants.UnitedStates },
                new object[] { "United Kingdom", "English", "GB", new object[] { 1030, 1031, 1033, 2057 }, GlobalizationLcidConstants.UnitedStates },
                new object[] { "Denmark", "Danish", "DK", new object[] { 1030, 1031, 1033, 2057 }, GlobalizationLcidConstants.UnitedStates },
                new object[] { "Germany", "German", "DE", new object[] { 1030, 1031, 1033, 2057 }, GlobalizationLcidConstants.UnitedStates },

                new object[] { "United States", "English", "US", new object[] { 1030, 1031, 1033, 2057 }, GlobalizationLcidConstants.GreatBritain },
                new object[] { "United Kingdom", "English", "GB", new object[] { 1030, 1031, 1033, 2057 }, GlobalizationLcidConstants.GreatBritain },
                new object[] { "Denmark", "Danish", "DK", new object[] { 1030, 1031, 1033, 2057 }, GlobalizationLcidConstants.GreatBritain },
                new object[] { "Germany", "German", "DE", new object[] { 1030, 1031, 1033, 2057 }, GlobalizationLcidConstants.GreatBritain },

                new object[] { "USA", "Engelsk", "US", new object[] { 1030, 1031, 1033, 2057 }, GlobalizationLcidConstants.Denmark },
                new object[] { "Storbritannien", "Engelsk", "GB", new object[] { 1030, 1031, 1033, 2057 }, GlobalizationLcidConstants.Denmark },
                new object[] { "Danmark", "Dansk", "DK", new object[] { 1030, 1031, 1033, 2057 }, GlobalizationLcidConstants.Denmark },
                new object[] { "Deutschland", "Deutsche", "DE", new object[] { 1030, 1031, 1033, 2057 }, GlobalizationLcidConstants.Germany },

                new object[] { "Vereinigte Staaten", "Englisch", "US", new object[] { 1030, 1031, 1033, 2057 }, GlobalizationLcidConstants.Germany },
                new object[] { "Großbritannien", "Englisch", "GB", new object[] { 1030, 1031, 1033, 2057 }, GlobalizationLcidConstants.Germany },
                new object[] { "Dänemark", "Dänisch", "DK", new object[] { 1030, 1031, 1033, 2057 }, GlobalizationLcidConstants.Germany },
                new object[] { "Deutschland", "Deutsche", "DE", new object[] { 1030, 1031, 1033, 2057 }, GlobalizationLcidConstants.Germany },
            };
    }
}