using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Atc.Data.Models;
using Atc.Rest.ApiGenerator.CLI.Commands.Options;
using Atc.Rest.ApiGenerator.Helpers;
using McMaster.Extensions.CommandLineUtils;

// ReSharper disable LocalizableElement
namespace Atc.Rest.ApiGenerator.CLI.Commands
{
    [Command("api", Description = "Create API project.")]
    public class GenerateServerApiCommand : BaseGenerateCommandOptions
    {
        private const string CommandArea = "Server-API";

        [SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "OK.")]
        public int OnExecute(CommandLineApplication configCmd)
        {
            ConsoleHelper.WriteHeader();

            var verboseMode = CommandLineApplicationHelper.GetVerboseMode(configCmd);
            var apiOptions = ApiOptionsHelper.CreateDefault(configCmd);
            ApiOptionsHelper.ApplyValidationOverrides(apiOptions, configCmd);
            ApiOptionsHelper.ApplyGeneratorOverrides(apiOptions, configCmd);

            var specificationPath = CommandLineApplicationHelper.GetSpecificationPath(configCmd);
            var apiYamlDoc = OpenApiDocumentHelper.CombineAndGetApiYamlDoc(specificationPath);

            var logItems = new List<LogKeyValueItem>();
            logItems.AddRange(OpenApiDocumentHelper.Validate(apiYamlDoc, apiOptions.Validation));

            if (logItems.Any(x => x.LogCategory == LogCategoryType.Error))
            {
                return ConsoleHelper.WriteLogItemsAndExit(logItems, verboseMode, CommandArea);
            }

            var projectPrefixName = CommandLineApplicationHelper.GetProjectPrefixName(configCmd);
            var outputPath = CommandLineApplicationHelper.GetOutputPath(configCmd);

            logItems = GeneratorHelper.GenerateServerApi(
                projectPrefixName,
                outputPath,
                apiYamlDoc,
                apiOptions);

            return ConsoleHelper.WriteLogItemsAndExit(logItems, verboseMode, CommandArea);
        }
    }
}