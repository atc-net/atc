namespace Atc.Console.Spectre.CommandSettings;

public class BaseCommandSettings : global::Spectre.Console.Cli.CommandSettings
{
    [CommandOption($"{CommandConstants.ArgumentShortVerbose}|{CommandConstants.ArgumentLongVerbose}")]
    [Description("Use verbose for more debug/trace information")]
    public bool Verbose { get; set; }

    public static bool IsOptionValueTrue(
        bool? value)
        => value is not null &&
           value.Value;
}