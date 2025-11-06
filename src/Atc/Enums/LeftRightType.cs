// ReSharper disable once CheckNamespace
namespace Atc;

/// <summary>
/// Represents a horizontal direction or position (left or right).
/// </summary>
public enum LeftRightType
{
    /// <summary>
    /// No direction specified.
    /// </summary>
    [LocalizedDescription(null, typeof(EnumResources))]
    None = 0,

    /// <summary>
    /// Left direction or position.
    /// </summary>
    [LocalizedDescription("LeftRightTypeLeft", typeof(EnumResources))]
    Left = 1,

    /// <summary>
    /// Right direction or position.
    /// </summary>
    [LocalizedDescription("LeftRightTypeRight", typeof(EnumResources))]
    Right = 2,
}