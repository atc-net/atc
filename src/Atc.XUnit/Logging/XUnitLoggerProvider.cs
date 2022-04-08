namespace Atc.XUnit.Logging;

public sealed class XUnitLoggerProvider : ILoggerProvider
{
    private readonly ITestOutputHelper testOutputHelper;
    private readonly LoggerExternalScopeProvider scopeProvider = new ();

    public XUnitLoggerProvider(
        ITestOutputHelper testOutputHelper)
    {
        this.testOutputHelper = testOutputHelper;
    }

    public ILogger CreateLogger(
        string categoryName)
        => new XUnitLogger(testOutputHelper, scopeProvider, categoryName);

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    private static void Dispose(bool disposing)
    {
        if (disposing)
        {
            // Dummy
        }
    }
}