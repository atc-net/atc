namespace Atc.Console.Spectre.CommandSettings;

public class BaseCommandSettings : global::Spectre.Console.Cli.CommandSettings
{
    [CommandOption($"{CommandConstants.ArgumentLongVerbose}")]
    [Description("Use verbose for more debug/trace information")]
    public bool Verbose { get; set; }

    [SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "OK. Will be used in a none-static context.")]
    public bool IsOptionValueTrue(
        bool? value)
        => value is not null &&
           value.Value;
}