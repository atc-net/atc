// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global
namespace Atc.Console.Spectre.Logging;

public class ConsoleLoggerConfiguration
{
    public ConsoleLoggerConfiguration()
    {
        ConsoleConfiguration = null;
        ConsoleSettings = null;
        MinimumLogLevel = LogLevel.Information;
        RenderingMode = ConsoleRenderingMode.Default;
        UseTimestamp = false;
        UseShortNameForLogLevel = true;
        IncludeInnerMessageForException = true;
        IncludeExceptionNameForException = true;
        AllowMarkup = false;
        UseTimestampUtc = false;
        TimeStampFormat = "yyyy-MM-dd HH:mm:ss";
    }

    [JsonIgnore]
    public Action<IAnsiConsole>? ConsoleConfiguration { get; set; }

    [JsonIgnore]
    public AnsiConsoleSettings? ConsoleSettings { get; set; }

    public LogLevel MinimumLogLevel { get; set; }

    public ConsoleRenderingMode RenderingMode { get; set; }

    public bool UseTimestamp { get; set; }

    public bool UseShortNameForLogLevel { get; set; }

    public bool IncludeInnerMessageForException { get; set; }

    public bool IncludeExceptionNameForException { get; set; }

    public bool AllowMarkup { get; set; }

    public bool UseTimestampUtc { get; set; }

    public string? TimeStampFormat { get; set; }

    public override string ToString()
        => $"{nameof(MinimumLogLevel)}: {MinimumLogLevel}, {nameof(RenderingMode)}: {RenderingMode}, {nameof(UseTimestamp)}: {UseTimestamp}, {nameof(UseShortNameForLogLevel)}: {UseShortNameForLogLevel}, {nameof(IncludeInnerMessageForException)}: {IncludeInnerMessageForException}, {nameof(IncludeExceptionNameForException)}: {IncludeExceptionNameForException}, {nameof(AllowMarkup)}: {AllowMarkup}, {nameof(UseTimestampUtc)}: {UseTimestampUtc}, {nameof(TimeStampFormat)}: {TimeStampFormat}";
}