namespace Atc.Console.Spectre.Helpers;

/// <summary>
/// Helper methods for Program.cs setup in Spectre.Console CLI applications.
/// </summary>
public static class ProgramCsHelper
{
    /// <summary>
    /// Returns the command-line arguments with the help argument (<c>-h</c>) when none are given,
    /// so a tool started without arguments shows its help instead of an error.
    /// </summary>
    /// <param name="args">The command-line arguments.</param>
    /// <returns>
    /// An array holding only <see cref="CommandConstants.ArgumentShortHelp"/> when <paramref name="args"/> is empty;
    /// otherwise <paramref name="args"/> itself.
    /// </returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="args"/> is null.</exception>
    public static string[] SetHelpArgumentIfNeeded(string[] args)
    {
        ArgumentNullException.ThrowIfNull(args);

        return args.Length == 0
            ? [CommandConstants.ArgumentShortHelp]
            : args;
    }

    /// <summary>
    /// Sets the minimum log level to Trace if the verbose argument is present in the command-line arguments.
    /// </summary>
    /// <param name="args">The command-line arguments to check.</param>
    /// <param name="consoleLoggerConfiguration">The console logger configuration to modify.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="consoleLoggerConfiguration"/> is null.</exception>
    public static void SetMinimumLogLevelIfNeeded(
        string[] args,
        ConsoleLoggerConfiguration consoleLoggerConfiguration)
    {
        if (consoleLoggerConfiguration is null)
        {
            throw new ArgumentNullException(nameof(consoleLoggerConfiguration));
        }

        if (args.Any(x => x.Equals(CommandConstants.ArgumentLongVerbose, StringComparison.OrdinalIgnoreCase)))
        {
            consoleLoggerConfiguration.MinimumLogLevel = LogLevel.Trace;
        }
    }
}