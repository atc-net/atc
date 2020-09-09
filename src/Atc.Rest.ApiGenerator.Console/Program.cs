using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text.Json;
using Atc.Rest.ApiGenerator.Helpers;
using Atc.Rest.ApiGenerator.Models.ApiOptions;
using CommandLine;

// ReSharper disable LocalizableElement
namespace Atc.Rest.ApiGenerator.Console
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            // TODO: This args = new should be removed when development has completed -> CMD.file
            string pathBase = @"C:\CodeDelegate\ATC\sample";
            args = new[]
            {
                "-n",
                "Demo.Api",
                "-p",
                @$"{pathBase}\Demo.ApiDesign\SingleFileVersion",
                "-o",
                @$"{pathBase}\Demo.Api.Generated",
                "--optionsPath",
                @$"{pathBase}\Demo.ApiDesign\DelegateApiGeneratorOptions.json",
            };

            Parser.Default.ParseArguments<ArgumentOptions>(args)
                .WithParsed(Run)
                .WithNotParsed(HandleInvalidArguments);
        }

        private static void HandleInvalidArguments(IEnumerable<Error> errors)
        {
            System.Console.WriteLine("Press any key...");
            System.Console.ReadKey();
        }

        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Ok.")]
        private static void Run(ArgumentOptions options)
        {
            var isGenerated = false;
            try
            {
                var apiOptions = LoadApiOptions(options.OptionsPath);
                var apiYamlDoc = OpenApiDocumentHelper.CombineAndGetApiYamlDoc(options.ApiDesignPath!);
                isGenerated = ApiGeneratorHelper.Create(
                    options.ApiProjectName!,
                    new DirectoryInfo(options.ApiOutputPath!),
                    apiYamlDoc,
                    apiOptions);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }

            System.Console.WriteLine(isGenerated
                ? "Api is now generated - done."
                : "Api is not generated - sorry.");
            System.Console.WriteLine("Press any key...");
            System.Console.ReadKey();
        }

        private static ApiOptions LoadApiOptions(string? optionsPath)
        {
            var apiOptions = new ApiOptions();

            if (string.IsNullOrEmpty(optionsPath))
            {
                return apiOptions;
            }

            var fileInfo = optionsPath.EndsWith(".json", StringComparison.Ordinal)
                ? new FileInfo(optionsPath)
                : new FileInfo(Path.Combine(optionsPath, "ApiGeneratorOptions.json"));

            if (!fileInfo.Exists)
            {
                return apiOptions;
            }

            using var stream = new StreamReader(fileInfo.FullName);
            var json = stream.ReadToEnd();
            apiOptions = JsonSerializer.Deserialize<ApiOptions>(json);

            return apiOptions;
        }
    }
}