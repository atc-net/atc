// ReSharper disable once CheckNamespace
namespace Atc;

/// <summary>
/// Associates a globally unique identifier (GUID) with an enum value, property, field, interface, or delegate.
/// This attribute is useful for assigning stable, unique identifiers to enum values that persist across code changes.
/// </summary>
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Enum | AttributeTargets.Interface | AttributeTargets.Delegate)]
public sealed class EnumGuidAttribute : Attribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="EnumGuidAttribute" /> class.
    /// </summary>
    /// <param name="value">The GUID value as a string representation.</param>
    /// <exception cref="FormatException">Thrown when the GUID string format is invalid.</exception>
    [SuppressMessage("Design", "CA1019:Define accessors for attribute arguments", Justification = "OK.")]
    public EnumGuidAttribute(string value)
    {
        GlobalIdentifier = new Guid(value);
    }

    /// <summary>
    /// Gets the globally unique identifier associated with this attribute.
    /// </summary>
    public Guid GlobalIdentifier { get; }
}