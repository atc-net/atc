namespace Atc.Data.Models;

/// <summary>
/// LogKeyValueItem.
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
    public LogKeyValueItem(LogCategoryType logCategory, string key, string value)
        : base(key, value)
    {
        this.LogCategory = logCategory;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="LogKeyValueItem"/> class.
    /// </summary>
    /// <param name="logCategory">The log category.</param>
    /// <param name="key">The key.</param>
    /// <param name="value">The value.</param>
    /// <param name="description">The description.</param>
    public LogKeyValueItem(LogCategoryType logCategory, string key, string value, string description)
        : this(logCategory, key, value)
    {
        this.Description = description;
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
    /// <param name="includeKey">if set to <c>true</c> [include key].</param>
    /// <param name="includeDescription">if set to <c>true</c> [include description].</param>
    [SuppressMessage("Major Code Smell", "S3358:Ternary operators should not be nested", Justification = "OK.")]
    public string GetLogMessage(bool includeKey = true, bool includeDescription = true)
        => includeKey switch
        {
            true when includeDescription => string.IsNullOrEmpty(this.Description)
                ? $"{this.Key}: {this.Value}"
                : $"{this.Key}: {this.Value} - {this.Description}",
            true => $"{this.Key}: {this.Value}",
            _ => includeDescription
                ? string.IsNullOrEmpty(this.Description)
                    ? $"{this.Value}"
                    : $"{this.Value} - {this.Description}"
                : $"{this.Value}"
        };

    /// <inheritdoc />
    public override string ToString()
        => $"{base.ToString()}, {nameof(this.LogCategory)}: {this.LogCategory}, {nameof(this.Description)}: {this.Description}";
}