// ReSharper disable once CheckNamespace
namespace Atc;

/// <summary>
/// Represents a direction of movement or traversal (forward or reverse/backward).
/// </summary>
public enum ForwardReverseType
{
    /// <summary>
    /// No direction specified.
    /// </summary>
    [LocalizedDescription(null, typeof(EnumResources))]
    None = 0,

    /// <summary>
    /// Forward direction or normal sequence.
    /// </summary>
    [LocalizedDescription("ForwardReverseTypeForward", typeof(EnumResources))]
    Forward = 1,

    /// <summary>
    /// Reverse direction or backward sequence.
    /// </summary>
    [LocalizedDescription("ForwardReverseTypeReverse", typeof(EnumResources))]
    Reverse = 2,
}