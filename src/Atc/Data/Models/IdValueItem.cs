namespace Atc.Data.Models;

/// <summary>
/// Represents a key-value pair with a GUID identifier and a string value.
/// </summary>
[Serializable]
public class IdValueItem
{
    /// <summary>
    /// Initializes a new instance of the <see cref="IdValueItem"/> class.
    /// </summary>
    public IdValueItem()
    {
        Value = string.Empty;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="IdValueItem"/> class.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <param name="value">The value.</param>
    [SuppressMessage("Major Code Smell", "S5766:Deserializing objects without performing data validation is security-sensitive", Justification = "OK.")]
    public IdValueItem(Guid id, string value)
    {
        Id = id;
        Value = value ?? throw new ArgumentNullException(nameof(value));
    }

    /// <summary>
    /// Gets or sets the unique identifier.
    /// </summary>
    /// <value>
    /// The unique identifier.
    /// </value>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the value.
    /// </summary>
    /// <value>
    /// The value.
    /// </value>
    public string Value { get; set; }

    /// <inheritdoc />
    public override string ToString()
        => $"{nameof(Id)}: {Id}, {nameof(Value)}: {Value}";
}