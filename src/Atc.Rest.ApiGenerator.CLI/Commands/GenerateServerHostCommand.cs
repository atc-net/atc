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
    [Command("host", Description = "Create ASP.NET Core host project (requires API and domain projects).")]
    public class GenerateServerHostCommand : ServerHostCommandOptions
    {
        private const string CommandArea = "Server-Host";

        [SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "OK.")]
        public int OnExecute(CommandLineApplication configCmd)
        {
            ConsoleHelper.WriteHeader();

            var apiOptions = ApiOptionsHelper.CreateDefault(configCmd);
            ApiOptionsHelper.ApplyValidationOverrides(apiOptions, configCmd);
            ApiOptionsHelper.ApplyGeneratorOverrides(apiOptions, configCmd);

            var specificationPath = CommandLineApplicationHelper.GetSpecificationPath(configCmd);
            var apiYamlDoc = OpenApiDocumentHelper.CombineAndGetApiYamlDoc(specificationPath);

            var logItems = new List<LogKeyValueItem>();
            logItems.AddRange(OpenApiDocumentHelper.Validate(apiYamlDoc, apiOptions.Validation));

            if (logItems.Any(x => x.LogCategory == LogCategoryType.Error))
            {
                return ConsoleHelper.WriteLogItemsAndExit(logItems, CommandArea);
            }

            var projectPrefixName = CommandLineApplicationHelper.GetProjectPrefixName(configCmd);
            var outputPath = CommandLineApplicationHelper.GetOutputPath(configCmd);
            var apiPath = CommandLineApplicationHelper.GetApiPath(configCmd);
            var domainPath = CommandLineApplicationHelper.GetDomainPath(configCmd);

            logItems = GeneratorHelper.GenerateServerHost(
                projectPrefixName,
                outputPath,
                apiYamlDoc,
                apiOptions,
                apiPath,
                domainPath);

            return ConsoleHelper.WriteLogItemsAndExit(logItems, CommandArea);
        }
    }
}