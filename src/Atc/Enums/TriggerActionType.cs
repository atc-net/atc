// ReSharper disable CheckNamespace
namespace Atc;

/// <summary>
/// Represents database trigger actions (insert, update, delete).
/// </summary>
public enum TriggerActionType
{
    /// <summary>
    /// No trigger action specified.
    /// </summary>
    [LocalizedDescription(null, typeof(EnumResources))]
    None = 0,

    /// <summary>
    /// Insert action when a new record is added.
    /// </summary>
    [LocalizedDescription("TriggerActionTypeInsert", typeof(EnumResources))]
    Insert = 1,

    /// <summary>
    /// Update action when an existing record is modified.
    /// </summary>
    [LocalizedDescription("TriggerActionTypeUpdate", typeof(EnumResources))]
    Update = 2,

    /// <summary>
    /// Delete action when a record is removed.
    /// </summary>
    [LocalizedDescription("TriggerActionTypeDelete", typeof(EnumResources))]
    Delete = 3,
}