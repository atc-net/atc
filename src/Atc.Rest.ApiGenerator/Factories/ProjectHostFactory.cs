using System;
using System.Collections.Generic;

// ReSharper disable InvertIf
namespace Atc.Rest.ApiGenerator.Factories
{
    internal static class ProjectHostFactory
    {
        public static string[] CreateUsingListForProgram()
        {
            var list = new List<string>
            {
                "Microsoft.AspNetCore.Hosting",
                "Microsoft.Extensions.Hosting"
            };

            return list.ToArray();
        }

        public static string[] CreateUsingListForStartup(string projectName, bool useExtended)
        {
            var name = projectName.Replace(".Api", string.Empty, StringComparison.Ordinal);

            var list = new List<string>
            {
                "System.Reflection",
                useExtended
                    ? "Atc.Rest.Extended.Options"
                    : "Atc.Rest.Options",
                "Microsoft.AspNetCore.Builder",
                "Microsoft.AspNetCore.Hosting",
                "Microsoft.Extensions.Configuration",
                "Microsoft.Extensions.DependencyInjection",
                $"{name}.Api.Generated",
                $"{name}.Domain"
            };

            return list.ToArray();
        }
    }
}