namespace Atc.Console.Spectre;

/// <summary>
/// Provides commonly used command-line argument and option name constants for Spectre.Console CLI applications.
/// </summary>
public static class CommandConstants
{
    /// <summary>
    /// Short form help argument: "-h".
    /// </summary>
    public const string ArgumentShortHelp = "-h";

    /// <summary>
    /// Long form help argument: "--help".
    /// </summary>
    public const string ArgumentLongHelp = "--help";

    /// <summary>
    /// Short form version argument: "-v".
    /// </summary>
    public const string ArgumentShortVersion = "-v";

    /// <summary>
    /// Long form version argument: "--version".
    /// </summary>
    public const string ArgumentLongVersion = "--version";

    /// <summary>
    /// Long form verbose argument: "--verbose".
    /// </summary>
    public const string ArgumentLongVerbose = "--verbose";

    /// <summary>
    /// Name for options file command: "options-file".
    /// </summary>
    public const string NameOptionsFile = "options-file";

    /// <summary>
    /// Name for create options file sub-command: "create".
    /// </summary>
    public const string NameOptionsFileCreate = "create";

    /// <summary>
    /// Name for validate options file sub-command: "validate".
    /// </summary>
    public const string NameOptionsFileValidate = "validate";
}