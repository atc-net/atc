namespace Demo.Atc.Console.Spectre.Cli.Commands;

public class HelloCommand : Command<HelloCommandSettings>
{
    public override int Execute(CommandContext context, HelloCommandSettings settings)
    {
        if (settings is null)
        {
            throw new ArgumentNullException(nameof(settings));
        }

        AnsiConsole.MarkupLine(settings.Count > 0
            ? $"Hello, [blue]{Markup.Escape(settings.Name)}[/] - [red]{settings.Count}[/]"
            : $"Hello, [blue]{Markup.Escape(settings.Name)}[/]");

        return ConsoleExitStatusCodes.Success;
    }
}