// ReSharper disable once CheckNamespace
namespace Atc;

/// <summary>
/// Flag-Enumeration: FileSystemWatcherChangeType.
/// </summary>
[SuppressMessage("Microsoft.Naming", "CA1714:FlagsEnumsShouldHavePluralNames", Justification = "OK.")]
[SuppressMessage("Minor Code Smell", "S2342:Enumeration types should comply with a naming convention", Justification = "OK.")]
[Flags]
public enum FileSystemWatcherChangeType
{
    /// <summary>
    /// Default None.
    /// </summary>
    [LocalizedDescription(null, typeof(EnumResources))]
    None = 0x00,

    /// <summary>
    /// Added.
    /// </summary>
    [LocalizedDescription("FileSystemWatcherChangeTypeAdded", typeof(EnumResources))]
    Added = 0x01,

    /// <summary>
    /// Deleted.
    /// </summary>
    [LocalizedDescription("FileSystemWatcherChangeTypeDeleted", typeof(EnumResources))]
    Deleted = 0x02,

    /// <summary>
    /// Renamed.
    /// </summary>
    [LocalizedDescription("FileSystemWatcherChangeTypeRenamed", typeof(EnumResources))]
    Renamed = 0x04,

    /// <summary>
    /// Changed.
    /// </summary>
    [LocalizedDescription("FileSystemWatcherChangeTypeChanged", typeof(EnumResources))]
    Changed = 0x08,

    /// <summary>
    /// All = Added | Deleted | Renamed | Changed.
    /// </summary>
    [LocalizedDescription("All", typeof(EnumResources))]
    All = Added | Deleted | Renamed | Changed,
}