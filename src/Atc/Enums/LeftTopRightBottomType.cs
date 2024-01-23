// ReSharper disable once CheckNamespace
namespace Atc;

/// <summary>
/// Enumeration: LeftTopRightBottomType.
/// </summary>
public enum LeftTopRightBottomType
{
    /// <summary>
    /// Default None
    /// </summary>
    [LocalizedDescription(null, typeof(EnumResources))]
    None = 0,

    /// <summary>
    /// Left
    /// </summary>
    [LocalizedDescription("LeftTopRightBottomTypeLeft", typeof(EnumResources))]
    Left = 1,

    /// <summary>
    /// Top.
    /// </summary>
    [LocalizedDescription("LeftTopRightBottomTypeTop", typeof(EnumResources))]
    Top = 2,

    /// <summary>
    /// Right
    /// </summary>
    [LocalizedDescription("LeftTopRightBottomTypeRight", typeof(EnumResources))]
    Right = 3,

    /// <summary>
    /// Bottom.
    /// </summary>
    [LocalizedDescription("LeftTopRightBottomTypeBottom", typeof(EnumResources))]
    Bottom = 4,
}