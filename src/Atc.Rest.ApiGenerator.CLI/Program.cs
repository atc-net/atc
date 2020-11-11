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
            args = new[]
            {
                "generate",
                "server",
                "all",
                "--validate-strictMode", "false",
                "--specificationPath", @"C:\Temp\shit\Api.v1.yaml",
                "--projectPrefixName", "Common.Recipe",
                "--outputSlnPath", @"C:\Temp\shit",
                "--outputSrcPath", @"C:\Temp\shit",
                "--outputTestPath", @"C:\Temp\shit",
                "--optionsPath", @"C:\Code\atc-net\ATC\sample\Demo.ApiDesign\ApiGeneratorOptions.json",
                "-v", "true",
            };

            //// ATC-DEMO
            ////args = new[]
            ////{
            ////    "generate",
            ////    "server",
            ////    "all",
            ////    "--validate-strictMode", "false",
            ////    "--specificationPath", @"C:\Code\atc-net\ATC\sample\Demo.ApiDesign\SingleFileVersion\Api.v1.yaml",
            ////    "--projectPrefixName", "Demo",
            ////    "--outputSlnPath", @"C:\Code\atc-net\ATC\sample",
            ////    "--outputSrcPath", @"C:\Code\atc-net\ATC\sample",
            ////    "--outputTestPath", @"C:\Code\atc-net\ATC\sample",
            ////    "--optionsPath", @"C:\Code\atc-net\ATC\sample\Demo.ApiDesign\ApiGeneratorOptions.json",
            ////    "-v", "true",
            ////};

            var builder = new HostBuilder();

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