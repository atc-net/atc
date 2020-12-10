using Atc.Resources;

// ReSharper disable once CheckNamespace
namespace Atc
{
    /// <summary>
    /// Enumeration: CollectionActionType.
    /// </summary>
    public enum CollectionActionType
    {
        /// <summary>
        /// Default None.
        /// </summary>
        [LocalizedDescription(null, typeof(EnumResources))]
        None,

        /// <summary>
        /// Added.
        /// </summary>
        [LocalizedDescription("CollectionActionTypeAdded", typeof(EnumResources))]
        Added,

        /// <summary>
        /// Updated.
        /// </summary>
        [LocalizedDescription("CollectionActionTypeUpdated", typeof(EnumResources))]
        Updated,

        /// <summary>
        /// Removed.
        /// </summary>
        [LocalizedDescription("CollectionActionTypeRemoved", typeof(EnumResources))]
        Removed,

        /// <summary>
        /// Cleared.
        /// </summary>
        [LocalizedDescription("CollectionActionTypeCleared", typeof(EnumResources))]
        Cleared,

        /// <summary>
        /// Saved.
        /// </summary>
        [LocalizedDescription("CollectionActionTypeSaved", typeof(EnumResources))]
        Saved,

        /// <summary>
        /// Loaded.
        /// </summary>
        [LocalizedDescription("CollectionActionTypeLoaded", typeof(EnumResources))]
        Loaded,
    }
}