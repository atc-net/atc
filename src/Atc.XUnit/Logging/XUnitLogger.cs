// ReSharper disable SwitchExpressionHandlesSomeKnownEnumValuesWithExceptionInDefault
// ReSharper disable StringLiteralTypo
namespace Atc.XUnit.Logging;

public class XUnitLogger : ILogger
{
    private readonly ITestOutputHelper testOutputHelper;
    private readonly string categoryName;
    private readonly LoggerExternalScopeProvider scopeProvider;

    public static ILogger Create(
        ITestOutputHelper testOutputHelper)
        => new XUnitLogger(testOutputHelper, new LoggerExternalScopeProvider(), string.Empty);

    public static ILogger<T> Create<T>(
        ITestOutputHelper testOutputHelper)
        => new XUnitLogger<T>(testOutputHelper, new LoggerExternalScopeProvider());

    public XUnitLogger(
        ITestOutputHelper testOutputHelper,
        LoggerExternalScopeProvider scopeProvider,
        string categoryName)
    {
        this.testOutputHelper = testOutputHelper;
        this.scopeProvider = scopeProvider;
        this.categoryName = categoryName;
    }

    public bool IsEnabled(
        LogLevel logLevel)
        => logLevel != LogLevel.None;

    public IDisposable BeginScope<TState>(
        TState state)
            => scopeProvider.Push(state);

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
        sb.Append(" [").Append(GetLogLevelString(logLevel)).Append("] ");

        if (!string.IsNullOrEmpty(categoryName))
        {
          sb.Append('[').Append(categoryName).Append("] ");
        }

        var message = state?.ToString() ?? string.Empty;
        if (!string.IsNullOrEmpty(message))
        {
            sb.Append(message);
        }

        if (exception is not null)
        {
            sb.Append(Environment.NewLine).Append(exception);
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

    private static string GetLogLevelString(
        LogLevel logLevel)
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