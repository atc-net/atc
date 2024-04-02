namespace Atc.Console.Spectre.Helpers;

/// <summary>
/// ProgramCsHelper.
/// </summary>
public static class ProgramCsHelper
{
    /// <summary>Sets the minimum log level if needed from the verbose argument.</summary>
    /// <param name="args">The arguments.</param>
    /// <param name="consoleLoggerConfiguration">The console logger configuration.</param>
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