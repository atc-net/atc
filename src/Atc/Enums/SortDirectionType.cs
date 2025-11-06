// ReSharper disable once CheckNamespace
namespace Atc;

/// <summary>
/// Defines the direction for sorting data (ascending or descending).
/// </summary>
public enum SortDirectionType
{
    /// <summary>
    /// No sort direction specified.
    /// </summary>
    [LocalizedDescription(null, typeof(EnumResources))]
    None = 0,

    /// <summary>
    /// Sort in ascending order (smallest to largest, A to Z).
    /// </summary>
    [LocalizedDescription("SortDirectionTypeAscending", typeof(EnumResources))]
    Ascending,

    /// <summary>
    /// Sort in descending order (largest to smallest, Z to A).
    /// </summary>
    [LocalizedDescription("SortDirectionTypeDescending", typeof(EnumResources))]
    Descending,
}