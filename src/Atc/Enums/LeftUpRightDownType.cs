// ReSharper disable once CheckNamespace
namespace Atc;

/// <summary>
/// Represents a directional position in four cardinal directions (left, up, right, or down).
/// </summary>
public enum LeftUpRightDownType
{
    /// <summary>
    /// No direction specified.
    /// </summary>
    [LocalizedDescription(null, typeof(EnumResources))]
    None = 0,

    /// <summary>
    /// Left direction.
    /// </summary>
    [LocalizedDescription("LeftRightTypeLeft", typeof(EnumResources))]
    Left = 1,

    /// <summary>
    /// Upward direction.
    /// </summary>
    [LocalizedDescription("UpDownTypeUp", typeof(EnumResources))]
    Up = 2,

    /// <summary>
    /// Right direction.
    /// </summary>
    [LocalizedDescription("LeftRightTypeRight", typeof(EnumResources))]
    Right = 3,

    /// <summary>
    /// Downward direction.
    /// </summary>
    [LocalizedDescription("UpDownTypeDown", typeof(EnumResources))]
    Down = 4,
}