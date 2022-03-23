namespace Atc.Data.Models;

/// <summary>
/// IdValueItem.
/// </summary>
[Serializable]
public class IdValueItem
{
    /// <summary>
    /// Initializes a new instance of the <see cref="IdValueItem"/> class.
    /// </summary>
    public IdValueItem()
    {
        this.Value = string.Empty;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="IdValueItem"/> class.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <param name="value">The value.</param>
    [SuppressMessage("Major Code Smell", "S5766:Deserializing objects without performing data validation is security-sensitive", Justification = "OK.")]
    public IdValueItem(Guid id, string value)
    {
        this.Id = id;
        this.Value = value ?? throw new ArgumentNullException(nameof(value));
    }

    /// <summary>
    /// Gets or sets the key.
    /// </summary>
    /// <value>
    /// The key.
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
        => $"{nameof(this.Id)}: {this.Id}, {nameof(this.Value)}: {this.Value}";
}