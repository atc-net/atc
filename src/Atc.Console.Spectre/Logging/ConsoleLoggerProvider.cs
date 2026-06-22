namespace Atc.Console.Spectre.Logging;

/// <summary>
/// Provides logger instances configured for Spectre.Console rendering.
/// </summary>
public class ConsoleLoggerProvider : ILoggerProvider
{
    private readonly ConsoleLoggerConfiguration config;
    private readonly IAnsiConsole console;
    private readonly ConcurrentDictionary<string, ConsoleLogger> loggers = new(StringComparer.Ordinal);

    /// <summary>
    /// Initializes a new instance of the <see cref="ConsoleLoggerProvider"/> class.
    /// A single <see cref="IAnsiConsole"/> is created here and shared across all loggers produced
    /// by this provider, preventing torn interleaved output under concurrent log calls.
    /// </summary>
    /// <param name="config">The console logger configuration to use.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="config"/> is null.</exception>
    public ConsoleLoggerProvider(ConsoleLoggerConfiguration config)
    {
        ArgumentNullException.ThrowIfNull(config);

        this.config = config;

        var settings = config.ConsoleSettings ?? new AnsiConsoleSettings
        {
            Ansi = AnsiSupport.Detect,
            ColorSystem = ColorSystemSupport.Detect,
        };

        console = AnsiConsole.Create(settings);
        config.ConsoleConfiguration?.Invoke(console);
    }

    /// <summary>
    /// Creates a new <see cref="ConsoleLogger"/> instance for the specified category.
    /// All loggers share the provider's <see cref="IAnsiConsole"/> instance.
    /// </summary>
    /// <param name="categoryName">The category name for the logger.</param>
    /// <returns>A <see cref="ConsoleLogger"/> instance.</returns>
    public ILogger CreateLogger(string categoryName)
        => loggers.GetOrAdd(categoryName, name => new ConsoleLogger(name, config, console));

    /// <inheritdoc />
    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Disposes the logger provider and clears all cached loggers.
    /// </summary>
    /// <param name="disposing">True if disposing managed resources.</param>
    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            loggers.Clear();
        }
    }
}