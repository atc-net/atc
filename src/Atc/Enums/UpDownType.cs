using Atc.Resources;

// ReSharper disable once CheckNamespace
namespace Atc
{
    /// <summary>
    /// Enumeration: UpDownType.
    /// </summary>
    public enum UpDownType
    {
        /// <summary>
        /// Default None.
        /// </summary>
        [LocalizedDescription(null, typeof(EnumResources))]
        None = 0,

        /// <summary>
        /// Up.
        /// </summary>
        [LocalizedDescription("UpDownTypeUp", typeof(EnumResources))]
        Up = 1,

        /// <summary>
        /// Down.
        /// </summary>
        [LocalizedDescription("UpDownTypeDown", typeof(EnumResources))]
        Down = 2,
    }
}