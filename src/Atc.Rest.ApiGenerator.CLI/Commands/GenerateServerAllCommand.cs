using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using Atc.Rest.ApiGenerator.CLI.Commands.Options;
using McMaster.Extensions.CommandLineUtils;

// ReSharper disable LocalizableElement
namespace Atc.Rest.ApiGenerator.CLI.Commands
{
    [Command("all", Description = "Creates API, domain and host projects.")]
    public class GenerateServerAllCommand : ServerAllCommandOptions
    {
        [SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "OK.")]
        [SuppressMessage("Usage", "CA1801:Review unused parameters", Justification = "Imp. this.")]
        public int OnExecute(CommandLineApplication configCmd)
        {
            ConsoleHelper.WriteHeader();

            Console.WriteLine();
            Colorful.Console.Write("Command for server-all is not implemented yet, sorry...", Color.DarkKhaki);

            return ExitStatusCodes.Success;
        }
    }
}