namespace Atc.Data.Models;

/// <summary>
/// Represents a log entry with timestamp, severity, and message.
/// </summary>
[Serializable]
public class LogItem
{
    /// <summary>
    /// Initializes a new instance of the <see cref="LogItem"/> class.
    /// </summary>
    public LogItem()
    {
        TimeStamp = DateTime.Now;
        Severity = LogCategoryType.Information;
        Message = string.Empty;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="LogItem" /> class.
    /// </summary>
    /// <param name="message">The message.</param>
    public LogItem(string message)
        : this()
    {
        Message = message ?? throw new ArgumentNullException(nameof(message));
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="LogItem" /> class.
    /// </summary>
    /// <param name="severity">The severity.</param>
    /// <param name="message">The message.</param>
    public LogItem(LogCategoryType severity, string message)
        : this(message)
    {
        Severity = severity;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="LogItem" /> class.
    /// </summary>
    /// <param name="timeStamp">The time stamp.</param>
    /// <param name="severity">The severity.</param>
    /// <param name="message">The message.</param>
    public LogItem(DateTime timeStamp, LogCategoryType severity, string message)
        : this(severity, message)
    {
        TimeStamp = timeStamp;
    }

    /// <summary>
    /// Gets or sets the time stamp.
    /// </summary>
    public DateTime TimeStamp { get; set; }

    /// <summary>
    /// Gets or sets the severity.
    /// </summary>
    public LogCategoryType Severity { get; set; }

    /// <summary>
    /// Gets or sets the message.
    /// </summary>
    public string Message { get; set; }

    /// <inheritdoc />
    public override string ToString()
        => $"{nameof(TimeStamp)}: {TimeStamp}, {nameof(Severity)}: {Severity}, {nameof(Message)}: {Message}";
}