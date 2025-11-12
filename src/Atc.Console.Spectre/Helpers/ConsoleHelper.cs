namespace Atc.Console.Spectre.Helpers;

/// <summary>
/// Helper methods for writing formatted output to the console using Spectre.Console.
/// </summary>
public static class ConsoleHelper
{
    /// <summary>
    /// Writes a header in ASCII art format with cornflower blue color.
    /// </summary>
    /// <param name="text">The text to render as an ASCII header.</param>
    public static void WriteHeader(string text)
        => AnsiConsole.Write(new FigletText(text).Color(Color.CornflowerBlue));

    /// <summary>
    /// Writes a header in ASCII art format with a specified color.
    /// </summary>
    /// <param name="text">The text to render as an ASCII header.</param>
    /// <param name="color">The color to use for the header.</param>
    public static void WriteHeader(
        string text,
        Color color)
            => AnsiConsole.Write(new FigletText(text).Color(color));

    /// <summary>
    /// Writes a single log key-value item through the logger.
    /// </summary>
    /// <param name="logger">The logger to use for output.</param>
    /// <param name="logItem">The log key-value item to write.</param>
    /// <param name="includeKey">If true, includes the key in the output.</param>
    /// <param name="includeDescription">If true, includes the description in the output.</param>
    public static void WriteLog(
        ILogger logger,
        LogKeyValueItem logItem,
        bool includeKey = true,
        bool includeDescription = true)
            => logger.LogKeyValueItem(logItem, includeKey, includeDescription);

    /// <summary>
    /// Writes multiple log key-value items through the logger.
    /// </summary>
    /// <param name="logger">The logger to use for output.</param>
    /// <param name="logItems">The list of log key-value items to write.</param>
    /// <param name="includeKey">If true, includes the keys in the output.</param>
    /// <param name="includeDescription">If true, includes the descriptions in the output.</param>
    public static void WriteLogs(
        ILogger logger,
        List<LogKeyValueItem> logItems,
        bool includeKey = true,
        bool includeDescription = true)
            => logger.LogKeyValueItems(logItems, includeKey, includeDescription);
}