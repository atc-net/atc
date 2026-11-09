namespace Atc.Console.Spectre.Helpers;

/// <summary>
/// Opt-in settings for a Spectre.Console <see cref="ICommandApp"/>, such as the one created by
/// <see cref="Factories.CommandAppFactory"/>. Nothing here is applied unless it is called.
/// </summary>
public static class CommandAppHelper
{
    /// <summary>
    /// Makes the application report a parse error, a validation error or an unhandled exception as a single red line
    /// on <see cref="AnsiConsole.Console"/> and exit with code 1, instead of printing a stack trace.
    /// </summary>
    /// <param name="app">The command application to configure.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="app"/> is null.</exception>
    /// <seealso cref="WriteException(IAnsiConsole, Exception)"/>
    public static void UseSingleLineExceptionHandler(ICommandApp app)
    {
        ArgumentNullException.ThrowIfNull(app);

        app.Configure(config => config.SetExceptionHandler((exception, _) => WriteException(AnsiConsole.Console, exception)));
    }

    /// <summary>
    /// Makes the application report a parse error, a validation error or an unhandled exception as a single red line
    /// on the given console and exit with code 1, instead of printing a stack trace.
    /// </summary>
    /// <param name="app">The command application to configure.</param>
    /// <param name="console">The console the error is written to.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="app"/> or <paramref name="console"/> is null.</exception>
    /// <seealso cref="WriteException(IAnsiConsole, Exception)"/>
    public static void UseSingleLineExceptionHandler(
        ICommandApp app,
        IAnsiConsole console)
    {
        ArgumentNullException.ThrowIfNull(app);
        ArgumentNullException.ThrowIfNull(console);

        app.Configure(config => config.SetExceptionHandler((exception, _) => WriteException(console, exception)));
    }

    /// <summary>
    /// Makes the application treat an argument or option that no command defines as an error,
    /// so a mistyped option fails instead of being silently ignored.
    /// </summary>
    /// <param name="app">The command application to configure.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="app"/> is null.</exception>
    public static void UseStrictParsing(ICommandApp app)
    {
        ArgumentNullException.ThrowIfNull(app);

        app.Configure(config => config.UseStrictParsing());
    }

    /// <summary>
    /// Writes an exception as a single red <c>Error:</c> line and returns exit code 1.
    /// A Spectre.Console.Cli parse error that carries its own rendering (<see cref="CommandAppException.Pretty"/>)
    /// is written as that rendering. The exception message is never parsed as markup, so a message that holds
    /// a <c>[</c>, such as a path, is written as it is.
    /// Use it from <c>config.SetExceptionHandler</c> when the handler is set up in your own <c>Configure</c> call.
    /// </summary>
    /// <param name="console">The console the error is written to.</param>
    /// <param name="exception">The exception to report.</param>
    /// <returns>The exit code: always 1.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="console"/> or <paramref name="exception"/> is null.</exception>
    public static int WriteException(
        IAnsiConsole console,
        Exception exception)
    {
        ArgumentNullException.ThrowIfNull(console);
        ArgumentNullException.ThrowIfNull(exception);

        if (exception is CommandAppException { Pretty: { } pretty })
        {
            console.Write(pretty);
        }
        else
        {
            console.MarkupLineInterpolated(CultureInfo.InvariantCulture, $"[red]Error:[/] {exception.Message}");
        }

        return 1;
    }
}