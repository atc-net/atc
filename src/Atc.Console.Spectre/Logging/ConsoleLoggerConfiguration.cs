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
        TimestampFormat = "yyyy-MM-dd HH:mm:ss";
    }

    [JsonIgnore]
    public Action<IAnsiConsole>? ConsoleConfiguration { get; set; }

    [JsonIgnore]
    public AnsiConsoleSettings? ConsoleSettings { get; set; }

    /// <summary>
    /// Gets or sets the minimum log level.
    /// If set to Information, then Trace and Debug will not be included.
    /// </summary>
    /// <remarks>
    /// The ordered list: Trace, Debug, Information, Warning, Error, Critical.
    /// </remarks>
    public LogLevel MinimumLogLevel { get; set; }

    /// <summary>
    /// Gets or sets the rendering mode.
    /// </summary>
    /// <remarks>
    /// The options: Default, LogLevel, CategoryName, LogLevelAndCategoryName.
    /// </remarks>
    public ConsoleRenderingMode RenderingMode { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the Timestamp should be rendered.
    /// </summary>
    public bool UseTimestamp { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the LogLevel should be rendered.
    /// </summary>
    public bool UseShortNameForLogLevel { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the inner-exception-message should be rendered.
    /// </summary>
    public bool IncludeInnerMessageForException { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the exception-name should be rendered.
    /// </summary>
    public bool IncludeExceptionNameForException { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the Spectre-markup is allowed.
    /// </summary>
    public bool AllowMarkup { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the Timestamp should be rendered as UTC.
    /// </summary>
    /// <remarks>
    /// UseTimestamp have to be set.
    /// </remarks>
    public bool UseTimestampUtc { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the Timestamp should be rendered with the custom format.
    /// </summary>
    /// <remarks>
    /// UseTimestamp have to be set.
    /// The format have to be a valid DateTime.ToString([TimestampFormat]) format.
    /// </remarks>
    public string? TimestampFormat { get; set; }

    public override string ToString()
        => $"{nameof(MinimumLogLevel)}: {MinimumLogLevel}, {nameof(RenderingMode)}: {RenderingMode}, {nameof(UseTimestamp)}: {UseTimestamp}, {nameof(UseShortNameForLogLevel)}: {UseShortNameForLogLevel}, {nameof(IncludeInnerMessageForException)}: {IncludeInnerMessageForException}, {nameof(IncludeExceptionNameForException)}: {IncludeExceptionNameForException}, {nameof(AllowMarkup)}: {AllowMarkup}, {nameof(UseTimestampUtc)}: {UseTimestampUtc}, {nameof(TimestampFormat)}: {TimestampFormat}";
}