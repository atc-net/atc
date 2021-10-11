using Xunit;

// ReSharper disable StringLiteralTypo
namespace Atc.Tests.XUnitTestData
{
    internal static class TestMemberDataForCultureHelper
    {
        public static TheoryData<int, string[], string[], int, int[]> GetCulturesDisplayLanguageLcidIncludeOnlyLcidsData
            => new TheoryData<int, string[], string[], int, int[]>
            {
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
                    }
                },
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
                    }
                },
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
                    }
                },
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
                    }
                },
            };

        public static TheoryData<int, string[], string[], int, string[]> GetCulturesDisplayLanguageLcidIncludeOnlyCultureNamesData
            => new TheoryData<int, string[], string[], int, string[]>
           {
                {
                    4,
                    new[] { "Denmark", "Germany", "United Kingdom", "United States" },
                    new[] { "Danish", "German", "English", "English" },
                    GlobalizationLcidConstants.UnitedStates,
                    new[] { "en-US", "en-GB", "da-DK", "de-DE" }
                },
                {
                    4,
                    new[] { "Denmark", "Germany", "United Kingdom", "United States" },
                    new[] { "Danish", "German", "English", "English" },
                    GlobalizationLcidConstants.GreatBritain,
                    new[] { "en-US", "en-GB", "da-DK", "de-DE" }
                },
                {
                    4,
                    new[] { "Danmark", "Tyskland", "Storbritannien", "USA" },
                    new[] { "Dansk", "Tysk", "Engelsk", "Engelsk" },
                    GlobalizationLcidConstants.Denmark,
                    new[] { "en-US", "en-GB", "da-DK", "de-DE" }
                },
                {
                    4,
                    new[] { "Dänemark", "Deutschland", "Großbritannien", "Vereinigte Staaten" },
                    new[] { "Dänisch", "Deutsche", "Englisch", "Englisch" },
                    GlobalizationLcidConstants.Germany,
                    new[] { "en-US", "en-GB", "da-DK", "de-DE" }
                },
           };

        public static TheoryData<string, string, int, int> GetCultureByLcidDisplayLanguageLcidData
            => new TheoryData<string, string, int, int>
            {
                { "United States", "English", GlobalizationLcidConstants.UnitedStates, GlobalizationLcidConstants.UnitedStates },
                { "United Kingdom", "English", GlobalizationLcidConstants.GreatBritain, GlobalizationLcidConstants.UnitedStates },
                { "Denmark", "Danish", GlobalizationLcidConstants.Denmark, GlobalizationLcidConstants.UnitedStates },
                { "Germany", "German", GlobalizationLcidConstants.Germany, GlobalizationLcidConstants.UnitedStates },

                { "United States", "English", GlobalizationLcidConstants.UnitedStates, GlobalizationLcidConstants.GreatBritain },
                { "United Kingdom", "English", GlobalizationLcidConstants.GreatBritain, GlobalizationLcidConstants.GreatBritain },
                { "Denmark", "Danish", GlobalizationLcidConstants.Denmark, GlobalizationLcidConstants.GreatBritain },
                { "Germany", "German", GlobalizationLcidConstants.Germany, GlobalizationLcidConstants.GreatBritain },

                { "USA", "Engelsk", GlobalizationLcidConstants.UnitedStates, GlobalizationLcidConstants.Denmark },
                { "Storbritannien", "Engelsk", GlobalizationLcidConstants.GreatBritain, GlobalizationLcidConstants.Denmark },
                { "Danmark", "Dansk", GlobalizationLcidConstants.Denmark, GlobalizationLcidConstants.Denmark },
                { "Tyskland", "Tysk", GlobalizationLcidConstants.Germany, GlobalizationLcidConstants.Denmark },

                { "Vereinigte Staaten", "Englisch", GlobalizationLcidConstants.UnitedStates, GlobalizationLcidConstants.Germany },
                { "Großbritannien", "Englisch", GlobalizationLcidConstants.GreatBritain, GlobalizationLcidConstants.Germany },
                { "Dänemark", "Dänisch", GlobalizationLcidConstants.Denmark, GlobalizationLcidConstants.Germany },
                { "Deutschland", "Deutsche", GlobalizationLcidConstants.Germany, GlobalizationLcidConstants.Germany },
            };

        public static TheoryData<string, string, string, int> GetCultureByCountryCodeA2LcidDisplayLanguageLcidData
            => new TheoryData<string, string, string, int>
            {
                { "United States", "English", "US", GlobalizationLcidConstants.UnitedStates },
                { "United Kingdom", "English", "GB", GlobalizationLcidConstants.UnitedStates },
                { "Denmark", "Danish", "DK", GlobalizationLcidConstants.UnitedStates },
                { "Germany", "German", "DE", GlobalizationLcidConstants.UnitedStates },

                { "United States", "English", "US", GlobalizationLcidConstants.GreatBritain },
                { "United Kingdom", "English", "GB", GlobalizationLcidConstants.GreatBritain },
                { "Denmark", "Danish", "DK", GlobalizationLcidConstants.GreatBritain },
                { "Germany", "German", "DE", GlobalizationLcidConstants.GreatBritain },

                { "USA", "Engelsk", "US", GlobalizationLcidConstants.Denmark },
                { "Storbritannien", "Engelsk", "GB", GlobalizationLcidConstants.Denmark },
                { "Danmark", "Dansk", "DK", GlobalizationLcidConstants.Denmark },
                { "Tyskland", "Tysk", "DE", GlobalizationLcidConstants.Denmark },

                { "Vereinigte Staaten", "Englisch", "US", GlobalizationLcidConstants.Germany },
                { "Großbritannien", "Englisch", "GB", GlobalizationLcidConstants.Germany },
                { "Dänemark", "Dänisch", "DK", GlobalizationLcidConstants.Germany },
                { "Deutschland", "Deutsche", "DE", GlobalizationLcidConstants.Germany },
            };

        public static TheoryData<string, string, string, int> GetCultureFromValueDisplayLanguageLcidData
            => new TheoryData<string, string, string, int>
            {
                { "United States", "English", "US", GlobalizationLcidConstants.UnitedStates },
                { "United Kingdom", "English", "GB", GlobalizationLcidConstants.UnitedStates },
                { "Denmark", "Danish", "DK", GlobalizationLcidConstants.UnitedStates },
                { "Germany", "German", "DE", GlobalizationLcidConstants.UnitedStates },

                { "United States", "English", "US", GlobalizationLcidConstants.GreatBritain },
                { "United Kingdom", "English", "GB", GlobalizationLcidConstants.GreatBritain },
                { "Denmark", "Danish", "DK", GlobalizationLcidConstants.GreatBritain },
                { "Germany", "German", "DE", GlobalizationLcidConstants.GreatBritain },

                { "USA", "Engelsk", "US", GlobalizationLcidConstants.Denmark },
                { "Storbritannien", "Engelsk", "GB", GlobalizationLcidConstants.Denmark },
                { "Danmark", "Dansk", "DK", GlobalizationLcidConstants.Denmark },
                { "Deutschland", "Deutsche", "DE", GlobalizationLcidConstants.Germany },

                { "Vereinigte Staaten", "Englisch", "US", GlobalizationLcidConstants.Germany },
                { "Großbritannien", "Englisch", "GB", GlobalizationLcidConstants.Germany },
                { "Dänemark", "Dänisch", "DK", GlobalizationLcidConstants.Germany },
                { "Deutschland", "Deutsche", "DE", GlobalizationLcidConstants.Germany },
            };

        public static TheoryData<string, string, string, int[], int> GetCultureFromValueDisplayLanguageLcidIncludeLcidsData
            => new TheoryData<string, string, string, int[], int>
            {
                { "United States", "English", "US", new[] { 1030, 1031, 1033, 2057 }, GlobalizationLcidConstants.UnitedStates },
                { "United Kingdom", "English", "GB", new[] { 1030, 1031, 1033, 2057 }, GlobalizationLcidConstants.UnitedStates },
                { "Denmark", "Danish", "DK", new[] { 1030, 1031, 1033, 2057 }, GlobalizationLcidConstants.UnitedStates },
                { "Germany", "German", "DE", new[] { 1030, 1031, 1033, 2057 }, GlobalizationLcidConstants.UnitedStates },

                { "United States", "English", "US", new[] { 1030, 1031, 1033, 2057 }, GlobalizationLcidConstants.GreatBritain },
                { "United Kingdom", "English", "GB", new[] { 1030, 1031, 1033, 2057 }, GlobalizationLcidConstants.GreatBritain },
                { "Denmark", "Danish", "DK", new[] { 1030, 1031, 1033, 2057 }, GlobalizationLcidConstants.GreatBritain },
                { "Germany", "German", "DE", new[] { 1030, 1031, 1033, 2057 }, GlobalizationLcidConstants.GreatBritain },

                { "USA", "Engelsk", "US", new[] { 1030, 1031, 1033, 2057 }, GlobalizationLcidConstants.Denmark },
                { "Storbritannien", "Engelsk", "GB", new[] { 1030, 1031, 1033, 2057 }, GlobalizationLcidConstants.Denmark },
                { "Danmark", "Dansk", "DK", new[] { 1030, 1031, 1033, 2057 }, GlobalizationLcidConstants.Denmark },
                { "Deutschland", "Deutsche", "DE", new[] { 1030, 1031, 1033, 2057 }, GlobalizationLcidConstants.Germany },

                { "Vereinigte Staaten", "Englisch", "US", new[] { 1030, 1031, 1033, 2057 }, GlobalizationLcidConstants.Germany },
                { "Großbritannien", "Englisch", "GB", new[] { 1030, 1031, 1033, 2057 }, GlobalizationLcidConstants.Germany },
                { "Dänemark", "Dänisch", "DK", new[] { 1030, 1031, 1033, 2057 }, GlobalizationLcidConstants.Germany },
                { "Deutschland", "Deutsche", "DE", new[] { 1030, 1031, 1033, 2057 }, GlobalizationLcidConstants.Germany },
            };
    }
}