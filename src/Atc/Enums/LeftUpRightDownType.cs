// ReSharper disable once CheckNamespace
namespace Atc;

/// <summary>
/// Enumeration: LeftUpRightDownType.
/// </summary>
public enum LeftUpRightDownType
{
    /// <summary>
    /// Default None
    /// </summary>
    [LocalizedDescription(null, typeof(EnumResources))]
    None = 0,

    /// <summary>
    /// Left
    /// </summary>
    [LocalizedDescription("LeftRightTypeLeft", typeof(EnumResources))]
    Left = 1,

    /// <summary>
    /// Up.
    /// </summary>
    [LocalizedDescription("UpDownTypeUp", typeof(EnumResources))]
    Up = 2,

    /// <summary>
    /// Right
    /// </summary>
    [LocalizedDescription("LeftRightTypeRight", typeof(EnumResources))]
    Right = 3,

    /// <summary>
    /// Down.
    /// </summary>
    [LocalizedDescription("UpDownTypeDown", typeof(EnumResources))]
    Down = 4,
}