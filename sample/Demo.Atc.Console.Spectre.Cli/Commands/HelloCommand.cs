namespace Demo.Atc.Console.Spectre.Cli.Commands;

internal sealed class HelloCommand : Command<HelloCommandSettings>
{
    public override int Execute(
        CommandContext context,
        HelloCommandSettings settings,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(settings);

        AnsiConsole.MarkupLine(settings.Count > 0
            ? $"Hello, [blue]{Markup.Escape(settings.Name)}[/] - [red]{settings.Count}[/]"
            : $"Hello, [blue]{Markup.Escape(settings.Name)}[/]");

        return ConsoleExitStatusCodes.Success;
    }
}