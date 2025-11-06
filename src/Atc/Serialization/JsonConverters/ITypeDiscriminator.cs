namespace Atc.Serialization.JsonConverters;

/// <summary>
/// Defines a contract for objects that expose a type discriminator property for polymorphic JSON serialization.
/// </summary>
/// <remarks>
/// Types implementing this interface can be used with <see cref="TypeDiscriminatorJsonConverter{T}"/> to enable
/// deserialization of polymorphic objects based on a discriminator field in the JSON payload.
/// </remarks>
public interface ITypeDiscriminator
{
    /// <summary>
    /// Gets the type discriminator value used to identify the concrete type during deserialization.
    /// </summary>
    /// <value>
    /// A string value that uniquely identifies the concrete type of the implementing class.
    /// </value>
    string TypeDiscriminator { get; }
}