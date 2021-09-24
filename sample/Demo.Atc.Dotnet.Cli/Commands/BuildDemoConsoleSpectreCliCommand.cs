using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Atc;
using Atc.DotNet;
using Demo.Atc.Dotnet.Cli.Settings;
using Microsoft.Extensions.Logging;
using Spectre.Console;
using Spectre.Console.Cli;

// ReSharper disable StringLiteralTypo
namespace Demo.Atc.Dotnet.Cli.Commands
{
    public class BuildDemoConsoleSpectreCliCommand : Command<BuildDemoConsoleSpectreCliCommandSettings>
    {
        private readonly ILogger<BuildDemoConsoleSpectreCliCommand> logger;

        public BuildDemoConsoleSpectreCliCommand(ILogger<BuildDemoConsoleSpectreCliCommand> logger)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [SuppressMessage("Async", "AsyncifyInvocation:Use Task Async", Justification = "OK.")]
        public override int Execute(CommandContext context, BuildDemoConsoleSpectreCliCommandSettings settings)
        {
            var directory = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
            do
            {
                directory = new DirectoryInfo(directory.Parent.FullName);
            }
            while (!directory.Name.Equals("sample", StringComparison.OrdinalIgnoreCase));

            var demoDirectory = directory.GetDirectories("Demo.Atc.Console.Spectre.Cli", SearchOption.AllDirectories).Single();
            var demoCsproj = new FileInfo(Path.Combine(demoDirectory.FullName, "Demo.Atc.Console.Spectre.Cli.csproj"));

            var buildAndCollectErrors = Task.Run(async () =>
                await DotnetBuildHelper.BuildAndCollectErrors(
                        logger,
                        demoDirectory,
                        1,
                        demoCsproj)
                    .ConfigureAwait(false))
                    .Result;

            AnsiConsole.MarkupLine(string.Empty);
            if (buildAndCollectErrors.Any())
            {
                AnsiConsole.MarkupLine($"[red]{Markup.Escape($"Encountered the following errors when building project '{demoCsproj.Name}'")}[/]");
                foreach (var (errorCode, errorCount) in buildAndCollectErrors)
                {
                    AnsiConsole.MarkupLine($"- [yellow]{Markup.Escape(errorCode)}[/] - [blue]{errorCount}[/]");
                }
            }
            else
            {
                AnsiConsole.MarkupLine($"[green]{Markup.Escape($"Yahoo, we can build the project {demoCsproj.Name}")}[/]");
            }

            return ConsoleExitStatusCodes.Success;
        }
    }
}