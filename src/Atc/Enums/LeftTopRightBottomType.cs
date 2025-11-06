// ReSharper disable once CheckNamespace
namespace Atc;

/// <summary>
/// Represents a position or alignment relative to a rectangle (left, top, right, or bottom).
/// </summary>
public enum LeftTopRightBottomType
{
    /// <summary>
    /// No position specified.
    /// </summary>
    [LocalizedDescription(null, typeof(EnumResources))]
    None = 0,

    /// <summary>
    /// Left side position.
    /// </summary>
    [LocalizedDescription("LeftTopRightBottomTypeLeft", typeof(EnumResources))]
    Left = 1,

    /// <summary>
    /// Top position.
    /// </summary>
    [LocalizedDescription("LeftTopRightBottomTypeTop", typeof(EnumResources))]
    Top = 2,

    /// <summary>
    /// Right side position.
    /// </summary>
    [LocalizedDescription("LeftTopRightBottomTypeRight", typeof(EnumResources))]
    Right = 3,

    /// <summary>
    /// Bottom position.
    /// </summary>
    [LocalizedDescription("LeftTopRightBottomTypeBottom", typeof(EnumResources))]
    Bottom = 4,
}