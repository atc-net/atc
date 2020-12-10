using Atc.Resources;

// ReSharper disable once CheckNamespace
namespace Atc
{
    /// <summary>
    /// Enumeration: SortDirectionType.
    /// </summary>
    public enum SortDirectionType
    {
        /// <summary>
        /// Default None.
        /// </summary>
        [LocalizedDescription(null, typeof(EnumResources))]
        None = 0,

        /// <summary>
        /// Ascending.
        /// </summary>
        [LocalizedDescription("SortDirectionTypeAscending", typeof(EnumResources))]
        Ascending,

        /// <summary>
        /// Descending.
        /// </summary>
        [LocalizedDescription("SortDirectionTypeDescending", typeof(EnumResources))]
        Descending,
    }
}