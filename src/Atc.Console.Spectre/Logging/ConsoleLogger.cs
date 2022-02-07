// ReSharper disable InvertIf
// ReSharper disable StringLiteralTypo
// ReSharper disable SwitchExpressionHandlesSomeKnownEnumValuesWithExceptionInDefault
// ReSharper disable SwitchStatementHandlesSomeKnownEnumValuesWithDefault
namespace Atc.Console.Spectre.Logging;

public class ConsoleLogger : ILogger
{
    private readonly string categoryName;
    private readonly ConsoleLoggerConfiguration config;
    private readonly IAnsiConsole console;

    public ConsoleLogger(string categoryName, ConsoleLoggerConfiguration config)
    {
        this.categoryName = categoryName;
        this.config = config ?? throw new ArgumentNullException(nameof(config));

        var settings = config.ConsoleSettings ?? new AnsiConsoleSettings
        {
            Ansi = AnsiSupport.Detect,
            ColorSystem = ColorSystemSupport.Detect,
        };

        console = AnsiConsole.Create(settings);
        config.ConsoleConfiguration?.Invoke(console);
    }

    public IDisposable BeginScope<TState>(TState state) => default!;

    public bool IsEnabled(LogLevel logLevel) => logLevel >= config.MinimumLogLevel;

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

        var stateStr = state?.ToString() ?? string.Empty;
        var message = config.AllowMarkup
            ? stateStr
            : Markup.Escape(stateStr);

        var exceptionMessage = exception?.GetMessage(
            includeInnerMessage: config.IncludeInnerMessageForException,
            includeExceptionName: config.IncludeInnerMessageForException);
        if (!string.IsNullOrEmpty(exceptionMessage))
        {
            exceptionMessage = Markup.Escape(exceptionMessage);
        }

        switch (config.RenderingMode)
        {
            case ConsoleRenderingMode.LogLevelAndCategoryName:
                OutputWithLogLevelAndCategoryName(logLevel, message, exceptionMessage);
                return;
            case ConsoleRenderingMode.LogLevel:
                OutputWithLogLevel(logLevel, message, exceptionMessage);
                return;
            case ConsoleRenderingMode.CategoryName:
                OutputWithCategoryName(logLevel, message, exceptionMessage);
                return;
            default:
                OutputDefault(logLevel, message, exceptionMessage);
                break;
        }
    }

    private void OutputWithLogLevelAndCategoryName(LogLevel logLevel, string message, string? exceptionMessage)
    {
        var logLevelMarkup = GetLogLevelWithMarkup(logLevel, config.UseShortNameForLogLevel);

        if (config.UseFixedWidthSpacing)
        {
            var padLength1 = config.UseShortNameForLogLevel
                ? 8 - GetShortLogLevelCharCount(logLevel, useShort: true)
                : 11 - GetShortLogLevelCharCount(logLevel, useShort: false);

            var spaces1 = string.Empty.PadRight(padLength1);
            console.MarkupLine($"{logLevelMarkup}{spaces1}{GetCategoryNameWithMarkup()}");

            var padLength2 = config.UseShortNameForLogLevel
                ? 10
                : 13;

            var spaces2 = string.Empty.PadRight(padLength2);
            console.MarkupLine($"{spaces2}{message}");

            if (!string.IsNullOrEmpty(exceptionMessage))
            {
                console.MarkupLine($"{spaces2}{exceptionMessage}");
            }
        }
        else
        {
            const int padLength = 7;
            var spaces = string.Empty.PadRight(padLength);

            console.MarkupLine($"{logLevelMarkup}{GetCategoryNameWithMarkup()}");
            console.MarkupLine($"{spaces}{message}");

            if (!string.IsNullOrEmpty(exceptionMessage))
            {
                var spacesForException = string.Empty.PadRight(padLength);
                console.MarkupLine($"{spacesForException}{exceptionMessage}");
            }
        }
    }

    private void OutputWithLogLevel(LogLevel logLevel, string message, string? exceptionMessage)
    {
        var logLevelMarkup = GetLogLevelWithMarkup(logLevel, config.UseShortNameForLogLevel);

        if (config.UseFixedWidthSpacing)
        {
            var padLength = config.UseShortNameForLogLevel
                ? 8 - GetShortLogLevelCharCount(logLevel, useShort: true)
                : 11 - GetShortLogLevelCharCount(logLevel, useShort: false);

            var spaces = string.Empty.PadRight(padLength);
            console.MarkupLine($"{logLevelMarkup}{spaces}{message}");

            if (!string.IsNullOrEmpty(exceptionMessage))
            {
                var padLengthException = config.UseShortNameForLogLevel
                    ? 10
                    : 13;

                var spacesForException = string.Empty.PadRight(padLengthException);
                console.MarkupLine($"{spacesForException}{exceptionMessage}");
            }
        }
        else
        {
            console.MarkupLine(logLevelMarkup + message);

            if (!string.IsNullOrEmpty(exceptionMessage))
            {
                const int padLengthException = 7;
                var spaces = string.Empty.PadRight(padLengthException);
                console.MarkupLine($"{spaces}{exceptionMessage}");
            }
        }
    }

    private void OutputWithCategoryName(LogLevel logLevel, string message, string? exceptionMessage)
    {
        var logLevelMarkupTag = GetLogLevelMarkupStartTag(logLevel);

        console.MarkupLine($"{GetCategoryNameWithMarkup()}: {logLevelMarkupTag}{message}[/]");

        if (!string.IsNullOrEmpty(exceptionMessage))
        {
            var padLength = categoryName.Length + 2;
            var spaces = string.Empty.PadRight(padLength);
            console.MarkupLine($"{spaces}{logLevelMarkupTag}{exceptionMessage}[/]");
        }
    }

    private void OutputDefault(LogLevel logLevel, string message, string? exceptionMessage)
    {
        var logLevelMarkupTag = GetLogLevelMarkupStartTag(logLevel);

        console.MarkupLine($"{logLevelMarkupTag}{message}[/]");

        if (!string.IsNullOrEmpty(exceptionMessage))
        {
            console.MarkupLine($"{logLevelMarkupTag}{exceptionMessage}[/]");
        }
    }

    private string GetCategoryNameWithMarkup()
    {
        return $"[grey]{categoryName}[/]";
    }

    private static int GetShortLogLevelCharCount(LogLevel logLevel, bool useShort)
    {
        if (useShort)
        {
            return logLevel switch
            {
                LogLevel.Trace => 5,
                LogLevel.Debug => 5,
                LogLevel.Information => 4,
                LogLevel.Warning => 4,
                LogLevel.Error => 5,
                LogLevel.Critical => 8,
                _ => throw new SwitchCaseDefaultException(nameof(logLevel))
            };
        }

        return logLevel.ToString().Length;
    }

    private static string GetLogLevelWithMarkup(LogLevel logLevel, bool useShort)
    {
        var startTag = GetLogLevelMarkupStartTag(logLevel);

        if (useShort)
        {
            return logLevel switch
            {
                LogLevel.Trace => $"{startTag}trace[/]: ",
                LogLevel.Debug => $"{startTag}debug[/]: ",
                LogLevel.Information => $"{startTag}info[/]: ",
                LogLevel.Warning => $"{startTag}warn[/]: ",
                LogLevel.Error => $"{startTag}error[/]: ",
                LogLevel.Critical => $"{startTag}critical[/]: ",
                _ => throw new SwitchCaseDefaultException(nameof(logLevel))
            };
        }

        return $"{startTag}{logLevel}[/]: ";
    }

    private static string GetLogLevelMarkupStartTag(LogLevel logLevel)
        => logLevel switch
        {
            LogLevel.Trace => "[grey]",
            LogLevel.Debug => "[green]",
            LogLevel.Information => "[deepskyblue1]",
            LogLevel.Warning => "[orange1]",
            LogLevel.Error => "[red]",
            LogLevel.Critical => "[red on white]",
            _ => throw new SwitchCaseDefaultException(nameof(logLevel))
        };
}