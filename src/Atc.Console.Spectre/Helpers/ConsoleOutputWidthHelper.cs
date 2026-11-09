namespace Atc.Console.Spectre.Helpers;

/// <summary>
/// Sets the width Spectre.Console writes in when the output is redirected (a pipe, a CI log, a file).
/// </summary>
/// <remarks>
/// A console without a window is reported as 80 columns wide, so redirected output is wrapped at 80 columns,
/// which breaks long paths and messages over lines that a log reader or a script then cannot find.
/// Applying the redirected width is opt-in: call <see cref="ApplyRedirectedOutputWidth()"/> early in <c>Program.Main</c>.
/// </remarks>
public static class ConsoleOutputWidthHelper
{
    /// <summary>
    /// The width, in columns, used for redirected output when the <c>COLUMNS</c> environment variable does not give one.
    /// </summary>
    public const int RedirectedOutputWidth = 240;

    /// <summary>
    /// The name of the environment variable that can give the width of redirected output: <c>COLUMNS</c>.
    /// </summary>
    public const string ColumnsEnvironmentVariable = "COLUMNS";

    /// <summary>
    /// Gets the width for redirected output.
    /// </summary>
    /// <param name="columns">The value of the <c>COLUMNS</c> environment variable, if any.</param>
    /// <returns>
    /// The value of <paramref name="columns"/> when it holds a positive whole number (surrounding white space is ignored);
    /// otherwise <see cref="RedirectedOutputWidth"/>.
    /// </returns>
    public static int GetRedirectedOutputWidth(string? columns)
        => int.TryParse(columns?.Trim(), NumberStyles.None, CultureInfo.InvariantCulture, out var width) && width > 0
            ? width
            : RedirectedOutputWidth;

    /// <summary>
    /// Sets the width of <see cref="AnsiConsole.Console"/> for redirected output when the standard output
    /// is redirected, using the <c>COLUMNS</c> environment variable or <see cref="RedirectedOutputWidth"/>.
    /// Nothing is changed when the output goes to a console window.
    /// </summary>
    /// <returns><see langword="true"/> when the output is redirected and the width was set; otherwise <see langword="false"/>.</returns>
    public static bool ApplyRedirectedOutputWidth()
        => ApplyRedirectedOutputWidth(
            AnsiConsole.Console,
            System.Console.IsOutputRedirected,
            Environment.GetEnvironmentVariable(ColumnsEnvironmentVariable));

    /// <summary>
    /// Sets the width of the given console for redirected output when <paramref name="isOutputRedirected"/> is true.
    /// </summary>
    /// <param name="console">The console whose profile width is set.</param>
    /// <param name="isOutputRedirected">Whether the output is redirected, normally <see cref="System.Console.IsOutputRedirected"/>.</param>
    /// <param name="columns">The value of the <c>COLUMNS</c> environment variable, if any.</param>
    /// <returns><see langword="true"/> when the width was set; otherwise <see langword="false"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="console"/> is null.</exception>
    public static bool ApplyRedirectedOutputWidth(
        IAnsiConsole console,
        bool isOutputRedirected,
        string? columns)
    {
        ArgumentNullException.ThrowIfNull(console);

        if (!isOutputRedirected)
        {
            return false;
        }

        console.Profile.Width = GetRedirectedOutputWidth(columns);
        return true;
    }
}