// ReSharper disable SwitchExpressionHandlesSomeKnownEnumValuesWithExceptionInDefault
// ReSharper disable StringLiteralTypo
namespace Atc.XUnit.Logging;

/// <summary>
/// An <see cref="ILogger"/> implementation that writes log messages to xUnit's <see cref="ITestOutputHelper"/>.
/// </summary>
public class XUnitLogger : ILogger
{
    private readonly ITestOutputHelper testOutputHelper;
    private readonly string categoryName;
    private readonly LoggerExternalScopeProvider scopeProvider;

    /// <summary>
    /// Creates a non-generic logger instance for xUnit test output.
    /// </summary>
    /// <param name="testOutputHelper">The xUnit test output helper.</param>
    /// <returns>An <see cref="ILogger"/> instance.</returns>
    public static ILogger Create(ITestOutputHelper testOutputHelper)
        => new XUnitLogger(testOutputHelper, new LoggerExternalScopeProvider(), string.Empty);

    /// <summary>
    /// Creates a generic logger instance for xUnit test output.
    /// </summary>
    /// <typeparam name="T">The type to use for the logger category name.</typeparam>
    /// <param name="testOutputHelper">The xUnit test output helper.</param>
    /// <returns>An <see cref="ILogger{T}"/> instance.</returns>
    public static ILogger<T> Create<T>(ITestOutputHelper testOutputHelper)
        => new XUnitLogger<T>(testOutputHelper, new LoggerExternalScopeProvider());

    /// <summary>
    /// Initializes a new instance of the <see cref="XUnitLogger"/> class.
    /// </summary>
    /// <param name="testOutputHelper">The xUnit test output helper.</param>
    /// <param name="scopeProvider">The logger scope provider.</param>
    /// <param name="categoryName">The category name for the logger.</param>
    public XUnitLogger(
        ITestOutputHelper testOutputHelper,
        LoggerExternalScopeProvider scopeProvider,
        string categoryName)
    {
        this.testOutputHelper = testOutputHelper;
        this.scopeProvider = scopeProvider;
        this.categoryName = categoryName;
    }

    /// <inheritdoc />
    public bool IsEnabled(LogLevel logLevel)
        => logLevel != LogLevel.None;

    /// <inheritdoc />
    public IDisposable BeginScope<TState>(TState state)
            => scopeProvider.Push(state);

    /// <inheritdoc />
    public void Log<TState>(
        LogLevel logLevel,
        EventId eventId,
        TState state,
        Exception? exception,
        Func<TState, Exception, string> formatter)
    {
        if (formatter is null)
        {
            throw new ArgumentNullException(nameof(formatter));
        }

        if (!IsEnabled(logLevel))
        {
            return;
        }

        var sb = new StringBuilder();
        sb.Append(DateTime.Now.ToString("HH:mm:ss", GlobalizationConstants.EnglishCultureInfo));
        sb.Append(" [");
        sb.Append(GetLogLevelString(logLevel));
        sb.Append("] ");

        if (!string.IsNullOrEmpty(categoryName))
        {
            sb.Append('[');
            sb.Append(categoryName);
            sb.Append("] ");
        }

        var message = state?.ToString() ?? string.Empty;
        if (!string.IsNullOrEmpty(message))
        {
            sb.Append(message);
        }

        if (exception is not null)
        {
            sb.Append(Environment.NewLine);
            sb.Append(exception);
        }

        // Append scopes
        scopeProvider.ForEachScope(
            (scope, scopeState) =>
            {
                scopeState.Append(Environment.NewLine);
                scopeState.Append(" => ");
                scopeState.Append(scope);
            },
            sb);

        testOutputHelper.WriteLine(sb.ToString());
    }

    private static string GetLogLevelString(LogLevel logLevel)
        => logLevel switch
        {
            LogLevel.Trace => "trce",
            LogLevel.Debug => "dbug",
            LogLevel.Information => "info",
            LogLevel.Warning => "warn",
            LogLevel.Error => "fail",
            LogLevel.Critical => "crit",
            _ => throw new SwitchCaseDefaultException(logLevel),
        };
}