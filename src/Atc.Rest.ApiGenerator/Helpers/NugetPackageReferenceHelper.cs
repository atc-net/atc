using System;
using System.Collections.Generic;

// ReSharper disable InvertIf
namespace Atc.Rest.ApiGenerator.Helpers
{
    public static class NugetPackageReferenceHelper
    {
        public static List<Tuple<string, string>> CreateForHostProject(bool useRestExtended)
        {
            var packageReference = new List<Tuple<string, string>>
            {
                new Tuple<string, string>("Atc", "1.0.131"),
                new Tuple<string, string>("Atc.Rest", "1.0.131")
            };

            if (useRestExtended)
            {
                packageReference.Add(new Tuple<string, string>("Atc.Rest.Extended", "1.0.131"));
                packageReference.Add(new Tuple<string, string>("FluentValidation.AspNetCore", "9.2.0"));
                packageReference.Add(new Tuple<string, string>("Microsoft.ApplicationInsights.AspNetCore", "2.14.0"));
                packageReference.Add(new Tuple<string, string>("Microsoft.AspNetCore.Mvc.Versioning", "4.1.1"));
                packageReference.Add(new Tuple<string, string>("Microsoft.AspNetCore.Mvc.Versioning.ApiExplorer", "4.1.1"));
                packageReference.Add(new Tuple<string, string>("Swashbuckle.AspNetCore", "5.5.1"));
            }

            return packageReference;
        }

        public static List<Tuple<string, string>> CreateForTestProject()
        {
            var packageReference = new List<Tuple<string, string>>
            {
                new Tuple<string, string>("AutoFixture", "4.11.0"),
                new Tuple<string, string>("AutoFixture.AutoNSubstitute", "4.11.0"),
                new Tuple<string, string>("AutoFixture.Xunit2", "4.11.0"),
                new Tuple<string, string>("FluentAssertions", "5.10.3"),
                new Tuple<string, string>("NSubstitute", "4.2.1"),
                new Tuple<string, string>("xunit", "2.4.1"),
                new Tuple<string, string>("xunit.runner.visualstudio", "2.4.1"),
            };

            return packageReference;
        }
    }
}