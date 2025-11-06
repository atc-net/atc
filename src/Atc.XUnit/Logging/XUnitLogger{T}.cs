namespace Atc.XUnit.Logging;

/// <summary>
/// A generic <see cref="ILogger{T}"/> implementation that writes log messages to xUnit's <see cref="ITestOutputHelper"/>.
/// </summary>
/// <typeparam name="T">The type to use for the logger category name.</typeparam>
public sealed class XUnitLogger<T> : XUnitLogger, ILogger<T>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="XUnitLogger{T}"/> class.
    /// </summary>
    /// <param name="testOutputHelper">The xUnit test output helper.</param>
    /// <param name="scopeProvider">The logger scope provider.</param>
    public XUnitLogger(
        ITestOutputHelper testOutputHelper,
        LoggerExternalScopeProvider scopeProvider)
        : base(testOutputHelper, scopeProvider, typeof(T).FullName!)
    {
    }
}