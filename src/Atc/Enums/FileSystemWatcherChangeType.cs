// ReSharper disable once CheckNamespace
namespace Atc;

/// <summary>
/// Represents the types of changes that can occur to files and directories in the file system.
/// This is a flags enumeration that allows multiple change types to be combined.
/// </summary>
[SuppressMessage("Minor Code Smell", "S2342:Enumeration types should comply with a naming convention", Justification = "OK.")]
[Flags]
public enum FileSystemWatcherChangeType
{
    /// <summary>
    /// No change type specified.
    /// </summary>
    [LocalizedDescription(null, typeof(EnumResources))]
    None = 0x00,

    /// <summary>
    /// A file or directory was added to the file system.
    /// </summary>
    [LocalizedDescription("FileSystemWatcherChangeTypeAdded", typeof(EnumResources))]
    Added = 0x01,

    /// <summary>
    /// A file or directory was deleted from the file system.
    /// </summary>
    [LocalizedDescription("FileSystemWatcherChangeTypeDeleted", typeof(EnumResources))]
    Deleted = 0x02,

    /// <summary>
    /// A file or directory was renamed in the file system.
    /// </summary>
    [LocalizedDescription("FileSystemWatcherChangeTypeRenamed", typeof(EnumResources))]
    Renamed = 0x04,

    /// <summary>
    /// A file or directory's contents or attributes were changed.
    /// </summary>
    [LocalizedDescription("FileSystemWatcherChangeTypeChanged", typeof(EnumResources))]
    Changed = 0x08,

    /// <summary>
    /// All change types combined (Added, Deleted, Renamed, and Changed).
    /// </summary>
    [LocalizedDescription("All", typeof(EnumResources))]
    All = Added | Deleted | Renamed | Changed,
}