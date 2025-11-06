namespace Atc.Console.Spectre.CommandSettings;

/// <summary>
/// Base command settings class providing common options for Spectre.Console CLI commands.
/// </summary>
public class BaseCommandSettings : global::Spectre.Console.Cli.CommandSettings
{
    /// <summary>
    /// Gets or sets a value indicating whether verbose logging is enabled.
    /// </summary>
    [CommandOption($"{CommandConstants.ArgumentLongVerbose}")]
    [Description("Use verbose for more debug/trace information")]
    public bool Verbose { get; set; }

    /// <summary>
    /// Determines whether an optional boolean value is true.
    /// </summary>
    /// <param name="value">The nullable boolean value to check.</param>
    /// <returns>True if the value is not null and is true; otherwise, false.</returns>
    [SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "OK. Will be used in a none-static context.")]
    public bool IsOptionValueTrue(
        bool? value)
        => value is not null &&
           value.Value;
}