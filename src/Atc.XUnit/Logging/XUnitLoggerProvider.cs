namespace Atc.XUnit.Logging;

/// <summary>
/// A logger provider that creates <see cref="XUnitLogger"/> instances for xUnit test output.
/// </summary>
public sealed class XUnitLoggerProvider : ILoggerProvider
{
    private readonly ITestOutputHelper testOutputHelper;
    private readonly LoggerExternalScopeProvider scopeProvider = new();

    /// <summary>
    /// Initializes a new instance of the <see cref="XUnitLoggerProvider"/> class.
    /// </summary>
    /// <param name="testOutputHelper">The xUnit test output helper.</param>
    public XUnitLoggerProvider(
        ITestOutputHelper testOutputHelper)
    {
        this.testOutputHelper = testOutputHelper;
    }

    /// <inheritdoc />
    public ILogger CreateLogger(
        string categoryName)
        => new XUnitLogger(testOutputHelper, scopeProvider, categoryName);

    /// <inheritdoc />
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