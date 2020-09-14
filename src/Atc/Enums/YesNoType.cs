using Atc.Resources;

// ReSharper disable once CheckNamespace
namespace Atc
{
    /// <summary>
    /// Enumeration: YesNoType.
    /// </summary>
    public enum YesNoType
    {
        /// <summary>
        /// Default None.
        /// </summary>
        [LocalizedDescription(null, typeof(EnumResources))]
        None = 0,

        /// <summary>
        /// No.
        /// </summary>
        [LocalizedDescription("YesNoTypeNo", typeof(EnumResources))]
        No = 1,

        /// <summary>
        /// Yes.
        /// </summary>
        [LocalizedDescription("YesNoTypeYes", typeof(EnumResources))]
        Yes = 2
    }
}