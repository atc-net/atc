using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Atc.Data.Models;
using Atc.Rest.ApiGenerator.Helpers;
using Atc.Rest.ApiGenerator.Models.ApiOptions;
using CommandLine;

// ReSharper disable SwitchStatementMissingSomeEnumCasesNoDefault
// ReSharper disable LocalizableElement
namespace Atc.Rest.ApiGenerator.CLI
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Parser.Default.ParseArguments<ArgumentOptions>(args)
                    .WithParsed(Run)
                    .WithNotParsed(HandleInvalidArguments);
        }

        private static void HandleInvalidArguments(IEnumerable<Error> errors)
        {
            Colorful.Console.WriteLine("Invalid arguments received.", Color.Red);
        }

        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "OK.")]
        private static void Run(ArgumentOptions options)
        {
            Colorful.Console.WriteAscii("ATC-API Generator", Color.Chocolate);

            var logItems = new List<LogKeyValueItem>();
            try
            {
                var apiOptions = LoadApiOptions(options.OptionsPath);
                var apiYamlDoc = OpenApiDocumentHelper.CombineAndGetApiYamlDoc(options.ApiDesignPath!);
                logItems = ApiGeneratorHelper.Create(
                    options.ApiProjectName!,
                    new DirectoryInfo(options.ApiOutputPath!),
                    apiYamlDoc,
                    apiOptions);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            WriteLogItemsToConsole(logItems);
            if (logItems.All(x => x.LogCategory != LogCategoryType.Error))
            {
                Colorful.Console.WriteLine("Api is now generated - done.", Color.DarkGreen);
            }
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

            var serializeOptions = new JsonSerializerOptions();
            serializeOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
            serializeOptions.WriteIndented = true;

            using var stream = new StreamReader(fileInfo.FullName);
            var json = stream.ReadToEnd();
            apiOptions = JsonSerializer.Deserialize<ApiOptions>(json, serializeOptions);

            return apiOptions;
        }

        private static void WriteLogItemsToConsole(IEnumerable<LogKeyValueItem> logItems)
        {
            foreach (var logItem in logItems)
            {
                var message = "#".Equals(logItem.Value, StringComparison.Ordinal)
                    ? $"{logItem.Key} # {logItem.LogCategory}: {logItem.Description}"
                    : $"{logItem.Key} # {logItem.LogCategory}: {logItem.Value} - {logItem.Description}";
                switch (logItem.LogCategory)
                {
                    case LogCategoryType.Error:
                        Colorful.Console.WriteLine(message, Color.Red);
                        break;
                    case LogCategoryType.Warning:
                        Colorful.Console.WriteLine(message, Color.Yellow);
                        break;
                    case LogCategoryType.Information:
                        Colorful.Console.WriteLine(message, Color.LightSkyBlue);
                        break;
                }
            }
        }
    }
}