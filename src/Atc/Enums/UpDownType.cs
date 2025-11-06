// ReSharper disable once CheckNamespace
namespace Atc;

/// <summary>
/// Represents a vertical direction or position (up or down).
/// </summary>
public enum UpDownType
{
    /// <summary>
    /// No direction specified.
    /// </summary>
    [LocalizedDescription(null, typeof(EnumResources))]
    None = 0,

    /// <summary>
    /// Upward direction or position.
    /// </summary>
    [LocalizedDescription("UpDownTypeUp", typeof(EnumResources))]
    Up = 1,

    /// <summary>
    /// Downward direction or position.
    /// </summary>
    [LocalizedDescription("UpDownTypeDown", typeof(EnumResources))]
    Down = 2,
}