// ReSharper disable StringLiteralTypo
namespace Demo.Atc.Dotnet.Cli.Commands;

internal sealed class BuildDemoConsoleSpectreCliCommand : Command<BuildDemoConsoleSpectreCliCommandSettings>
{
    private readonly ILogger<BuildDemoConsoleSpectreCliCommand> logger;

    public BuildDemoConsoleSpectreCliCommand(
        ILogger<BuildDemoConsoleSpectreCliCommand> logger)
    {
        this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public override int Execute(
        CommandContext context,
        BuildDemoConsoleSpectreCliCommandSettings settings,
        CancellationToken cancellationToken)
    {
        var directory = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
        do
        {
            if (directory.Parent is not null)
            {
                directory = new DirectoryInfo(directory.Parent.FullName);
            }
        }
        while (!directory.Name.Equals("sample", StringComparison.OrdinalIgnoreCase));

        var demoDirectory = directory
            .GetDirectories("Demo.Atc.Console.Spectre.Cli", SearchOption.AllDirectories)
            .Single();

        var demoCsproj = new FileInfo(Path.Combine(demoDirectory.FullName, "Demo.Atc.Console.Spectre.Cli.csproj"));

        var buildAndCollectErrors = TaskHelper.RunSync(() =>
            DotnetBuildHelper.BuildAndCollectErrors(
                logger,
                demoDirectory,
                1,
                demoCsproj,
                cancellationToken: cancellationToken));

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