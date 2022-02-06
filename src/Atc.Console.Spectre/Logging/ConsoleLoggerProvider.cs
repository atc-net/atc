namespace Atc.Console.Spectre.Logging;

public class ConsoleLoggerProvider : ILoggerProvider
{
    private readonly ConsoleLoggerConfiguration config;
    private readonly ConcurrentDictionary<string, ConsoleLogger> loggers = new ConcurrentDictionary<string, ConsoleLogger>(StringComparer.Ordinal);

    public ConsoleLoggerProvider(ConsoleLoggerConfiguration config)
    {
        this.config = config;
    }

    public ILogger CreateLogger(string categoryName)
    {
        return loggers.GetOrAdd(categoryName, name => new ConsoleLogger(name, config));
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            loggers.Clear();
        }
    }
}