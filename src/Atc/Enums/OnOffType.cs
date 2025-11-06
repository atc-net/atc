// ReSharper disable once CheckNamespace
namespace Atc;

/// <summary>
/// Represents a binary on/off state.
/// </summary>
public enum OnOffType
{
    /// <summary>
    /// No state specified.
    /// </summary>
    [LocalizedDescription(null, typeof(EnumResources))]
    None = 0,

    /// <summary>
    /// Off state (disabled or inactive).
    /// </summary>
    [LocalizedDescription("OnOffTypeOff", typeof(EnumResources))]
    Off = 1,

    /// <summary>
    /// On state (enabled or active).
    /// </summary>
    [LocalizedDescription("OnOffTypeOn", typeof(EnumResources))]
    On = 2,
}