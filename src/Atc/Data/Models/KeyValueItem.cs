namespace Atc.Data.Models;

/// <summary>
/// Represents a key-value pair with string key and value.
/// </summary>
[Serializable]
public class KeyValueItem
{
    /// <summary>
    /// Initializes a new instance of the <see cref="KeyValueItem"/> class.
    /// </summary>
    public KeyValueItem()
    {
        Key = string.Empty;
        Value = string.Empty;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="KeyValueItem"/> class.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <param name="value">The value.</param>
    [SuppressMessage("Major Code Smell", "S5766:Deserializing objects without performing data validation is security-sensitive", Justification = "OK.")]
    public KeyValueItem(
        string key,
        string value)
    {
        Key = key ?? throw new ArgumentNullException(nameof(key));
        Value = value ?? throw new ArgumentNullException(nameof(value));
    }

    /// <summary>
    /// Gets or sets the key.
    /// </summary>
    /// <value>
    /// The key.
    /// </value>
    public string Key { get; set; }

    /// <summary>
    /// Gets or sets the value.
    /// </summary>
    /// <value>
    /// The value.
    /// </value>
    public string Value { get; set; }

    /// <inheritdoc />
    public override string ToString()
        => $"{nameof(Key)}: {Key}, {nameof(Value)}: {Value}";
}