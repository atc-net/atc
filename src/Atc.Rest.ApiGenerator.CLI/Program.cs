using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Reflection;
using Atc.Rest.ApiGenerator.CLI.Commands;
using Microsoft.Extensions.Hosting;

namespace Atc.Rest.ApiGenerator.CLI
{
    [ExcludeFromCodeCoverage]
    public static class Program
    {
        public static int Main(string[] args)
        {
            var builder = new HostBuilder();

            args = new[]
            {
                "generate",
                "server",
                "api",
                "--validate-strictMode", "true",
                "--specificationPath", @"C:\Code\atc-net\ATC\sample\Demo.ApiDesign\SingleFileVersion\Api.v1.yaml",
                "-p", "Demo",
                "-o", @"C:\Code\atc-net\ATC\sample",
                "--optionsPath", @"C:\Code\atc-net\atc\sample\Demo.ApiDesign\ApiGeneratorOptions.json",
                "-v", "true",
                ////"-?",
            };

            try
            {
                return builder
                    .RunCommandLineApplicationAsync<RootCommand>(args)
                    .GetAwaiter()
                    .GetResult();
            }
            catch (TargetInvocationException ex) when (ex.InnerException != null)
            {
                Colorful.Console.WriteLine($@"Error: {ex.InnerException.Message}", Color.Red);
                return ExitStatusCodes.Failure;
            }
            catch (Exception ex)
            {
                Colorful.Console.WriteLine($@"Error: {ex.Message}", Color.Red);
                return ExitStatusCodes.Failure;
            }
        }
    }
}