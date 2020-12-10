using Atc.Resources;

// ReSharper disable CheckNamespace
namespace Atc
{
    /// <summary>
    /// Enumeration: TriggerActionType.
    /// </summary>
    public enum TriggerActionType
    {
        /// <summary>
        /// Default None.
        /// </summary>
        [LocalizedDescription(null, typeof(EnumResources))]
        None = 0,

        /// <summary>
        /// Insert.
        /// </summary>
        [LocalizedDescription("TriggerActionTypeInsert", typeof(EnumResources))]
        Insert = 1,

        /// <summary>
        /// Update.
        /// </summary>
        [LocalizedDescription("TriggerActionTypeUpdate", typeof(EnumResources))]
        Update = 2,

        /// <summary>
        /// Delete.
        /// </summary>
        [LocalizedDescription("TriggerActionTypeDelete", typeof(EnumResources))]
        Delete = 3,
    }
}