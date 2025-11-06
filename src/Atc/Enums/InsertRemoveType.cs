// ReSharper disable once CheckNamespace
namespace Atc;

/// <summary>
/// Represents an operation to insert or remove an item.
/// </summary>
public enum InsertRemoveType
{
    /// <summary>
    /// No operation specified.
    /// </summary>
    [LocalizedDescription(null, typeof(EnumResources))]
    None,

    /// <summary>
    /// Insert operation to add an item.
    /// </summary>
    [LocalizedDescription("InsertRemoveTypeInsert", typeof(EnumResources))]
    Insert,

    /// <summary>
    /// Remove operation to delete an item.
    /// </summary>
    [LocalizedDescription("InsertRemoveTypeRemove", typeof(EnumResources))]
    Remove,
}