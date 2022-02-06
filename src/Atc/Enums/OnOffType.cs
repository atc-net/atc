// ReSharper disable once CheckNamespace
namespace Atc;

/// <summary>
/// Enumeration: OnOffType.
/// </summary>
public enum OnOffType
{
    /// <summary>
    /// Default None.
    /// </summary>
    [LocalizedDescription(null, typeof(EnumResources))]
    None = 0,

    /// <summary>
    /// Off.
    /// </summary>
    [LocalizedDescription("OnOffTypeOff", typeof(EnumResources))]
    Off = 1,

    /// <summary>
    /// ON.
    /// </summary>
    [LocalizedDescription("OnOffTypeOn", typeof(EnumResources))]
    On = 2,
}