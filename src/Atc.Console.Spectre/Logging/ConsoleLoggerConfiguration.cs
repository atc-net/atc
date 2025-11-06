// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global
namespace Atc.Console.Spectre.Logging;

/// <summary>
/// Configuration options for the console logger used in Spectre.Console CLI applications.
/// </summary>
public class ConsoleLoggerConfiguration
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ConsoleLoggerConfiguration"/> class with default settings.
    /// </summary>
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

    /// <summary>
    /// Gets or sets an optional configuration action to customize the <see cref="IAnsiConsole"/> instance.
    /// </summary>
    [JsonIgnore]
    public Action<IAnsiConsole>? ConsoleConfiguration { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="AnsiConsoleSettings"/> for console configuration.
    /// </summary>
    [JsonIgnore]
    public AnsiConsoleSettings? ConsoleSettings { get; set; }

    /// <summary>
    /// Gets or sets the minimum log level.
    /// If set to Information, then Trace and Debug will not be included.
    /// </summary>
    /// <remarks>
    /// The ordered list:<br />
    /// Trace, Debug, Information, Warning, Error, Critical.
    /// </remarks>
    public LogLevel MinimumLogLevel { get; set; }

    /// <summary>
    /// Gets or sets the rendering mode.
    /// </summary>
    /// <remarks>
    /// The options:<br />
    /// Default, LogLevel, CategoryName, LogLevelAndCategoryName.
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
    /// UseTimestamp setting has to be set in order for this setting to take effect.
    /// </remarks>
    public bool UseTimestampUtc { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the Timestamp should be rendered with the custom format.
    /// </summary>
    /// <remarks>
    /// UseTimestamp setting has to be set in order for this setting to take effect.<br />
    /// The format has to be in a valid DateTime.ToString([TimestampFormat]) format.<br />
    /// Read more: https://docs.microsoft.com/en-us/dotnet/api/system.datetime.tostring?view=net-6.0
    /// </remarks>
    public string? TimestampFormat { get; set; }

    /// <inheritdoc />
    public override string ToString()
        => $"{nameof(MinimumLogLevel)}: {MinimumLogLevel}, {nameof(RenderingMode)}: {RenderingMode}, {nameof(UseTimestamp)}: {UseTimestamp}, {nameof(UseShortNameForLogLevel)}: {UseShortNameForLogLevel}, {nameof(IncludeInnerMessageForException)}: {IncludeInnerMessageForException}, {nameof(IncludeExceptionNameForException)}: {IncludeExceptionNameForException}, {nameof(AllowMarkup)}: {AllowMarkup}, {nameof(UseTimestampUtc)}: {UseTimestampUtc}, {nameof(TimestampFormat)}: {TimestampFormat}";
}