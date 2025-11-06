namespace Atc.Data.Models;

/// <summary>
/// Represents a log entry with a key-value pair, log category, and optional description.
/// Extends <see cref="KeyValueItem"/> to add logging-specific functionality.
/// </summary>
[Serializable]
public class LogKeyValueItem : KeyValueItem
{
    /// <summary>
    /// Initializes a new instance of the <see cref="LogKeyValueItem"/> class.
    /// </summary>
    public LogKeyValueItem()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="LogKeyValueItem"/> class.
    /// </summary>
    /// <param name="logCategory">The log category.</param>
    /// <param name="key">The key.</param>
    /// <param name="value">The value.</param>
    public LogKeyValueItem(
        LogCategoryType logCategory,
        string key,
        string value)
        : base(key, value)
    {
        LogCategory = logCategory;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="LogKeyValueItem"/> class.
    /// </summary>
    /// <param name="logCategory">The log category.</param>
    /// <param name="key">The key.</param>
    /// <param name="value">The value.</param>
    /// <param name="description">The description.</param>
    public LogKeyValueItem(
        LogCategoryType logCategory,
        string key,
        string value,
        string description)
        : this(logCategory, key, value)
    {
        Description = description;
    }

    /// <summary>
    /// Gets or sets the log category.
    /// </summary>
    /// <value>
    /// The log category.
    /// </value>
    public LogCategoryType LogCategory { get; set; }

    /// <summary>
    /// Gets or sets the description.
    /// </summary>
    /// <value>
    /// The description.
    /// </value>
    public string? Description { get; set; }

    /// <summary>
    /// Gets the log message.
    /// </summary>
    /// <param name="includeKey">if set to <see langword="true" /> [include key].</param>
    /// <param name="includeDescription">if set to <see langword="true" /> [include description].</param>
    [SuppressMessage("Major Code Smell", "S3358:Ternary operators should not be nested", Justification = "OK.")]
    public string GetLogMessage(
        bool includeKey = true,
        bool includeDescription = true)
        => includeKey switch
        {
            true when includeDescription => string.IsNullOrEmpty(Description)
                ? $"{Key}: {Value}"
                : $"{Key}: {Value} - {Description}",
            true => $"{Key}: {Value}",
            _ => includeDescription
                ? string.IsNullOrEmpty(Description)
                    ? $"{Value}"
                    : $"{Value} - {Description}"
                : $"{Value}",
        };

    /// <inheritdoc />
    public override string ToString()
        => $"{base.ToString()}, {nameof(LogCategory)}: {LogCategory}, {nameof(Description)}: {Description}";
}