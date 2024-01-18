// ReSharper disable once CheckNamespace
namespace Atc;

[Flags]
public enum ArrowDirectionType
{
    /// <summary>
    /// Default None.
    /// </summary>
    [LocalizedDescription(null, typeof(EnumResources))]
    None = 0x0,

    /// <summary>
    /// Left.
    /// </summary>
    [LocalizedDescription("ArrowDirectionTypeLeft", typeof(EnumResources))]
    Left = 0x1,

    /// <summary>
    /// Up.
    /// </summary>
    [LocalizedDescription("ArrowDirectionTypeUp", typeof(EnumResources))]
    Up = 0x2,

    /// <summary>
    /// Right.
    /// </summary>
    [LocalizedDescription("ArrowDirectionTypeRight", typeof(EnumResources))]
    Right = 0x4,

    /// <summary>
    /// Down.
    /// </summary>
    [LocalizedDescription("ArrowDirectionTypeDown", typeof(EnumResources))]
    Down = 0x8,
}