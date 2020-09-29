using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Atc.Rest.ApiGenerator.CLI.Commands.Options;
using McMaster.Extensions.CommandLineUtils;

// ReSharper disable LocalizableElement
namespace Atc.Rest.ApiGenerator.CLI.Commands
{
    [Command("api", Description = "Create API project.")]
    public class GenerateServerApiCommand : BaseGenerateCommandOptions
    {
        [SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "OK.")]
        public int OnExecute(CommandLineApplication configCmd)
        {
            ConsoleHelper.WriteHeader();

            var commandOptions = configCmd.GetOptions().ToList();

            Console.WriteLine("Hallo - GenerateServerApiCommand");
            Console.WriteLine();

            return ExitStatusCodes.Success;
        }
    }
}