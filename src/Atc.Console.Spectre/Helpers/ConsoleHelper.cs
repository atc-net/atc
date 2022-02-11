namespace Atc.Console.Spectre.Helpers;

/// <summary>
/// ConsoleHelper.
/// </summary>
public static class ConsoleHelper
{
    /// <summary>Write a header in ASCII with blue color.</summary>
    /// <param name="text">The text.</param>
    public static void WriteHeader(
        string text)
        => AnsiConsole.Write(new FigletText(text).Color(Color.CornflowerBlue));

    /// <summary>Write a header in ASCII with blue color.</summary>
    /// <param name="text">The text.</param>
    /// <param name="color">The color.</param>
    public static void WriteHeader(
        string text,
        Color color)
            => AnsiConsole.Write(new FigletText(text).Color(color));

    /// <summary>Writes the log item through the logger.</summary>
    /// <param name="logger">The logger.</param>
    /// <param name="logItem">The log item.</param>
    /// <param name="includeKey">if set to <c>true</c> [include key].</param>
    /// <param name="includeDescription">if set to <c>true</c> [include description].</param>
    public static void WriteLog(
        ILogger logger,
        LogKeyValueItem logItem,
        bool includeKey = true,
        bool includeDescription = true)
            => logger.LogKeyValueItem(logItem, includeKey, includeDescription);

    /// <summary>Writes the log items through the logger.</summary>
    /// <param name="logger">The logger.</param>
    /// <param name="logItems">The log items.</param>
    /// <param name="includeKey">if set to <c>true</c> [include key].</param>
    /// <param name="includeDescription">if set to <c>true</c> [include description].</param>
    public static void WriteLogs(
        ILogger logger,
        List<LogKeyValueItem> logItems,
        bool includeKey = true,
        bool includeDescription = true)
            => logger.LogKeyValueItems(logItems, includeKey, includeDescription);
}