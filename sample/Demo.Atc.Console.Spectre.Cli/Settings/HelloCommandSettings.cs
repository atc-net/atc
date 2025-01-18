namespace Demo.Atc.Console.Spectre.Cli.Settings;

internal sealed class HelloCommandSettings : CommandSettings
{
    [CommandArgument(0, "[Name]")]
    public string Name { get; set; } = string.Empty;

    [CommandOption("-c|--count")]
    public int Count { get; set; }
}