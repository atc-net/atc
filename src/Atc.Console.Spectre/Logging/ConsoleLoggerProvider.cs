namespace Atc.Console.Spectre.Logging;

/// <summary>
/// Provides logger instances configured for Spectre.Console rendering.
/// </summary>
public class ConsoleLoggerProvider : ILoggerProvider
{
    private readonly ConsoleLoggerConfiguration config;
    private readonly ConcurrentDictionary<string, ConsoleLogger> loggers = new(StringComparer.Ordinal);

    /// <summary>
    /// Initializes a new instance of the <see cref="ConsoleLoggerProvider"/> class.
    /// </summary>
    /// <param name="config">The console logger configuration to use.</param>
    public ConsoleLoggerProvider(ConsoleLoggerConfiguration config)
    {
        this.config = config;
    }

    /// <summary>
    /// Creates a new <see cref="ConsoleLogger"/> instance for the specified category.
    /// </summary>
    /// <param name="categoryName">The category name for the logger.</param>
    /// <returns>A <see cref="ConsoleLogger"/> instance.</returns>
    public ILogger CreateLogger(string categoryName)
    {
        return loggers.GetOrAdd(categoryName, name => new ConsoleLogger(name, config));
    }

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