// ReSharper disable InvertIf
// ReSharper disable StringLiteralTypo
// ReSharper disable SwitchExpressionHandlesSomeKnownEnumValuesWithExceptionInDefault
// ReSharper disable SwitchStatementHandlesSomeKnownEnumValuesWithDefault
// ReSharper disable MemberCanBeMadeStatic.Local
namespace Atc.Console.Spectre.Logging;

/// <summary>
/// A logger implementation that writes colorful, formatted output using Spectre.Console.
/// </summary>
[SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "OK.")]
public class ConsoleLogger : ILogger
{
    private readonly string categoryName;
    private readonly ConsoleLoggerConfiguration config;
    private readonly IAnsiConsole console;

    /// <summary>
    /// Initializes a new instance of the <see cref="ConsoleLogger"/> class.
    /// </summary>
    /// <param name="categoryName">The category name for the logger.</param>
    /// <param name="config">The console logger configuration.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="config"/> is null.</exception>
    public ConsoleLogger(
        string categoryName,
        ConsoleLoggerConfiguration config)
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

    /// <inheritdoc />
    public IDisposable BeginScope<TState>(TState state) => default!;

    /// <inheritdoc />
    public bool IsEnabled(LogLevel logLevel)
        => logLevel >= config.MinimumLogLevel;

    /// <inheritdoc />
    public void Log<TState>(
        LogLevel logLevel,
        EventId eventId,
        TState state,
        Exception? exception,
        Func<TState, Exception, string> formatter)
    {
        ArgumentNullException.ThrowIfNull(formatter);

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

    private void OutputWithLogLevelAndCategoryName(
        LogLevel logLevel,
        string message,
        string? exceptionMessage)
    {
        var spaces = GetSpacesForLogLevel(logLevel);

        if (config.UseTimestamp)
        {
            console.MarkupLine($"{GetTimeStampWithMarkup()} {GetLogLevelWithMarkup(logLevel, config.UseShortNameForLogLevel)}{spaces}{GetCategoryNameWithMarkup()} {GetMessageWithMarkup(logLevel, message)}");

            if (!string.IsNullOrEmpty(exceptionMessage))
            {
                var spacesForException = GetSpacesForTimeStampAndLogLevelAndCategoryNameExceptionPart();
                console.MarkupLine($"{spacesForException}{GetMessageWithMarkup(logLevel, exceptionMessage)}");
            }
        }
        else
        {
            console.MarkupLine($"{GetLogLevelWithMarkup(logLevel, config.UseShortNameForLogLevel)}{spaces}{GetCategoryNameWithMarkup()} {GetMessageWithMarkup(logLevel, message)}");

            if (!string.IsNullOrEmpty(exceptionMessage))
            {
                var spacesForException = GetSpacesForLogLevelAndCategoryNameExceptionPart();
                console.MarkupLine($"{spacesForException}{GetMessageWithMarkup(logLevel, exceptionMessage)}");
            }
        }
    }

    private void OutputWithLogLevel(
        LogLevel logLevel,
        string message,
        string? exceptionMessage)
    {
        var spaces = GetSpacesForLogLevel(logLevel);

        if (config.UseTimestamp)
        {
            console.MarkupLine($"{GetTimeStampWithMarkup()} {GetLogLevelWithMarkup(logLevel, config.UseShortNameForLogLevel)}{spaces}{GetMessageWithMarkup(logLevel, message)}");

            if (!string.IsNullOrEmpty(exceptionMessage))
            {
                var spacesForException = GetSpacesForTimeStampAndLogLevelExceptionPart();
                console.MarkupLine($"{spacesForException}{GetMessageWithMarkup(logLevel, exceptionMessage)}");
            }
        }
        else
        {
            console.MarkupLine($"{GetLogLevelWithMarkup(logLevel, config.UseShortNameForLogLevel)}{spaces}{GetMessageWithMarkup(logLevel, message)}");

            if (!string.IsNullOrEmpty(exceptionMessage))
            {
                var spacesForException = GetSpacesForLogLevelExceptionPart();
                console.MarkupLine($"{spacesForException}{GetMessageWithMarkup(logLevel, exceptionMessage)}");
            }
        }
    }

    private void OutputWithCategoryName(
        LogLevel logLevel,
        string message,
        string? exceptionMessage)
    {
        if (config.UseTimestamp)
        {
            console.MarkupLine($"{GetTimeStampAndCategoryNameWithMarkup()} {GetMessageWithMarkup(logLevel, message)}");

            if (!string.IsNullOrEmpty(exceptionMessage))
            {
                var spaces = GetSpacesForTimeStampAndCategoryName();
                console.MarkupLine($"{spaces}{GetMessageWithMarkup(logLevel, exceptionMessage)}");
            }
        }
        else
        {
            console.MarkupLine($"{GetCategoryNameWithMarkup()} {GetMessageWithMarkup(logLevel, message)}");

            if (!string.IsNullOrEmpty(exceptionMessage))
            {
                var spaces = GetSpacesForCategoryName();
                console.MarkupLine($"{spaces}{GetMessageWithMarkup(logLevel, exceptionMessage)}");
            }
        }
    }

    private void OutputDefault(
        LogLevel logLevel,
        string message,
        string? exceptionMessage)
    {
        if (config.UseTimestamp)
        {
            console.MarkupLine($"{GetTimeStampWithMarkup()} {GetMessageWithMarkup(logLevel, message)}");

            if (!string.IsNullOrEmpty(exceptionMessage))
            {
                console.MarkupLine($"{GetTimeStampWithMarkup()} {GetMessageWithMarkup(logLevel, exceptionMessage)}");
            }
        }
        else
        {
            console.MarkupLine(GetMessageWithMarkup(logLevel, message));

            if (!string.IsNullOrEmpty(exceptionMessage))
            {
                console.MarkupLine(GetMessageWithMarkup(logLevel, exceptionMessage));
            }
        }
    }

    private string GetTimeStamp()
        => config.UseTimestampUtc
            ? DateTime.UtcNow.ToString(config.TimestampFormat ?? "s", GlobalizationConstants.EnglishCultureInfo)
            : DateTime.Now.ToString(config.TimestampFormat ?? "s", GlobalizationConstants.EnglishCultureInfo);

    private string GetSpacesForLogLevel(LogLevel logLevel)
        => string.Empty.PadRight(GetLengthForLogLevel(logLevel));

    private string GetSpacesForCategoryName()
        => string.Empty.PadRight(categoryName.Length + 1);

    private string GetSpacesForTimeStampAndCategoryName()
        => string.Empty.PadRight(GetTimeStamp().Length + categoryName.Length + 2);

    private string GetSpacesForTimeStampAndLogLevelExceptionPart()
        => string.Empty.PadRight(GetLengthForLogLevelExceptionPart() + GetTimeStamp().Length + 1);

    private string GetSpacesForTimeStampAndLogLevelAndCategoryNameExceptionPart()
        => string.Empty.PadRight(GetLengthForLogLevelExceptionPart() + GetTimeStamp().Length + categoryName.Length + 2);

    private string GetSpacesForLogLevelExceptionPart()
        => string.Empty.PadRight(GetLengthForLogLevelExceptionPart());

    private string GetSpacesForLogLevelAndCategoryNameExceptionPart()
        => string.Empty.PadRight(GetLengthForLogLevelExceptionPart() + categoryName.Length + 1);

    private int GetLengthForLogLevel(LogLevel logLevel)
        => config.UseShortNameForLogLevel
            ? 9 - GetShortLogLevelCharCount(logLevel, useShort: true)
            : 12 - GetShortLogLevelCharCount(logLevel, useShort: false);

    private int GetLengthForLogLevelExceptionPart()
        => config.UseShortNameForLogLevel
            ? 10
            : 13;

    private static int GetShortLogLevelCharCount(
        LogLevel logLevel,
        bool useShort)
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
                _ => throw new SwitchCaseDefaultException(logLevel),
            };
        }

        return logLevel.ToString().Length;
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
            _ => throw new SwitchCaseDefaultException(logLevel),
        };

    private static string GetLogLevelWithMarkup(
        LogLevel logLevel,
        bool useShort)
    {
        var startTag = GetLogLevelMarkupStartTag(logLevel);

        if (useShort)
        {
            return logLevel switch
            {
                LogLevel.Trace => $"{startTag}trace:[/]",
                LogLevel.Debug => $"{startTag}debug:[/]",
                LogLevel.Information => $"{startTag}info:[/]",
                LogLevel.Warning => $"{startTag}warn:[/]",
                LogLevel.Error => $"{startTag}error:[/]",
                LogLevel.Critical => $"{startTag}critical:[/]",
                _ => throw new SwitchCaseDefaultException(logLevel),
            };
        }

        return $"{startTag}{logLevel}:[/]";
    }

    private string GetTimeStampWithMarkup()
        => $"[white]{GetTimeStamp()}[/]";

    private string GetCategoryNameWithMarkup()
        => $"[grey]{categoryName}[/]";

    private string GetTimeStampAndCategoryNameWithMarkup()
        => $"{GetTimeStampWithMarkup()} {GetCategoryNameWithMarkup()}";

    private string GetMessageWithMarkup(
        LogLevel logLevel,
        string message)
        => $"{GetLogLevelMarkupStartTag(logLevel)}{message}[/]";
}