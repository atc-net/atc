using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using Atc.Data.Models;
using Atc.Rest.ApiGenerator.CLI.Commands.Options;
using Atc.Rest.ApiGenerator.Helpers;
using McMaster.Extensions.CommandLineUtils;

// ReSharper disable LocalizableElement
namespace Atc.Rest.ApiGenerator.CLI.Commands
{
    [Command("csharp", Description = "Generate client project in C#.")]
    public class GenerateClientCSharpCommand : ClientCommandOptions
    {
        private const string CommandArea = "Client-CSharp";

        [SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "OK.")]
        public int OnExecute(CommandLineApplication configCmd)
        {
            ConsoleHelper.WriteHeader();

            var apiOptions = ApiOptionsHelper.CreateDefault(configCmd);
            ApiOptionsHelper.ApplyValidationOverrides(apiOptions, configCmd);

            var specificationPath = CommandLineApplicationHelper.GetSpecificationPath(configCmd);
            var apiYamlDoc = OpenApiDocumentHelper.CombineAndGetApiYamlDoc(specificationPath);

            var logItems = new List<LogKeyValueItem>();
            logItems.AddRange(OpenApiDocumentHelper.Validate(apiYamlDoc, apiOptions.Validation));

            if (logItems.Any(x => x.LogCategory == LogCategoryType.Error))
            {
                return ConsoleHelper.WriteLogItemsAndExit(logItems, CommandArea);
            }

            Console.WriteLine();
            Colorful.Console.Write("Command for client-CSharp is not implemented yet, sorry...", Color.DarkKhaki);

            return ExitStatusCodes.Success;
        }
    }
}