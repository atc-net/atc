// ReSharper disable once CheckNamespace
namespace Atc;

/// <summary>
/// Enumeration: InsertRemoveType.
/// </summary>
public enum InsertRemoveType
{
    /// <summary>
    /// Default None.
    /// </summary>
    [LocalizedDescription(null, typeof(EnumResources))]
    None,

    /// <summary>
    /// Insert.
    /// </summary>
    [LocalizedDescription("InsertRemoveTypeInsert", typeof(EnumResources))]
    Insert,

    /// <summary>
    /// Remove.
    /// </summary>
    [LocalizedDescription("InsertRemoveTypeRemove", typeof(EnumResources))]
    Remove,
}