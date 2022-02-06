// ReSharper disable once CheckNamespace
namespace Atc;

/// <summary>
/// Enum Guid Attribute.
/// </summary>
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Enum | AttributeTargets.Interface | AttributeTargets.Delegate)]
public sealed class EnumGuidAttribute : Attribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="EnumGuidAttribute" /> class.
    /// </summary>
    /// <param name="value">The GUID.</param>
    public EnumGuidAttribute(string value)
    {
        this.GlobalIdentifier = new Guid(value);
    }

    /// <summary>
    /// Gets the global identifier.
    /// </summary>
    /// <value>
    /// The global identifier.
    /// </value>
    public Guid GlobalIdentifier { get; }
}