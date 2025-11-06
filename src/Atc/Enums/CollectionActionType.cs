// ReSharper disable once CheckNamespace
namespace Atc;

/// <summary>
/// Represents actions that can be performed on a collection of items.
/// </summary>
public enum CollectionActionType
{
    /// <summary>
    /// No action specified.
    /// </summary>
    [LocalizedDescription(null, typeof(EnumResources))]
    None,

    /// <summary>
    /// An item was added to the collection.
    /// </summary>
    [LocalizedDescription("CollectionActionTypeAdded", typeof(EnumResources))]
    Added,

    /// <summary>
    /// An item in the collection was updated.
    /// </summary>
    [LocalizedDescription("CollectionActionTypeUpdated", typeof(EnumResources))]
    Updated,

    /// <summary>
    /// An item was removed from the collection.
    /// </summary>
    [LocalizedDescription("CollectionActionTypeRemoved", typeof(EnumResources))]
    Removed,

    /// <summary>
    /// All items were removed from the collection.
    /// </summary>
    [LocalizedDescription("CollectionActionTypeCleared", typeof(EnumResources))]
    Cleared,

    /// <summary>
    /// The collection was saved to persistent storage.
    /// </summary>
    [LocalizedDescription("CollectionActionTypeSaved", typeof(EnumResources))]
    Saved,

    /// <summary>
    /// The collection was loaded from persistent storage.
    /// </summary>
    [LocalizedDescription("CollectionActionTypeLoaded", typeof(EnumResources))]
    Loaded,
}