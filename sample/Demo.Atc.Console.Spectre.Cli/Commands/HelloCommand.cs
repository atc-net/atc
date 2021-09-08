using Atc;
using Demo.Atc.Console.Spectre.Cli.Settings;
using Spectre.Console;
using Spectre.Console.Cli;

namespace Demo.Atc.Console.Spectre.Cli.Commands
{
    public class HelloCommand : Command<HelloCommandSettings>
    {
        public override int Execute(CommandContext context, HelloCommandSettings settings)
        {
            AnsiConsole.MarkupLine(settings.Count > 0
                ? $"Hello, [blue]{Markup.Escape(settings.Name)}[/] - [red]{settings.Count}[/]"
                : $"Hello, [blue]{Markup.Escape(settings.Name)}[/]");

            return ConsoleExitStatusCodes.Success;
        }
    }
}