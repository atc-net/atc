// ReSharper disable once CheckNamespace
namespace Atc;

/// <summary>
/// Represents directional arrows that can be combined using bitwise operations.
/// This is a flags enumeration that allows multiple directions to be combined.
/// </summary>
[Flags]
public enum ArrowDirectionType
{
    /// <summary>
    /// No direction specified.
    /// </summary>
    [LocalizedDescription(null, typeof(EnumResources))]
    None = 0x0,

    /// <summary>
    /// Arrow pointing to the left.
    /// </summary>
    [LocalizedDescription("ArrowDirectionTypeLeft", typeof(EnumResources))]
    Left = 0x1,

    /// <summary>
    /// Arrow pointing upward.
    /// </summary>
    [LocalizedDescription("ArrowDirectionTypeUp", typeof(EnumResources))]
    Up = 0x2,

    /// <summary>
    /// Arrow pointing to the right.
    /// </summary>
    [LocalizedDescription("ArrowDirectionTypeRight", typeof(EnumResources))]
    Right = 0x4,

    /// <summary>
    /// Arrow pointing downward.
    /// </summary>
    [LocalizedDescription("ArrowDirectionTypeDown", typeof(EnumResources))]
    Down = 0x8,
}