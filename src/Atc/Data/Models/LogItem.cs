namespace Atc.Data.Models;

/// <summary>
/// LogKeyValueItem.
/// </summary>
[Serializable]
public class LogItem
{
    /// <summary>
    /// Initializes a new instance of the <see cref="LogItem"/> class.
    /// </summary>
    public LogItem()
    {
        this.TimeStamp = DateTime.Now;
        this.Severity = LogCategoryType.Information;
        this.Message = string.Empty;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="LogItem" /> class.
    /// </summary>
    /// <param name="message">The message.</param>
    public LogItem(string message)
        : this()
    {
        this.Message = message ?? throw new ArgumentNullException(nameof(message));
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="LogItem" /> class.
    /// </summary>
    /// <param name="severity">The severity.</param>
    /// <param name="message">The message.</param>
    public LogItem(LogCategoryType severity, string message)
        : this(message)
    {
        this.Severity = severity;
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
        this.TimeStamp = timeStamp;
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