using Atc.Resources;

// ReSharper disable once CheckNamespace
namespace Atc
{
    /// <summary>
    /// Enumeration: ForwardReverseType.
    /// </summary>
    public enum ForwardReverseType
    {
        /// <summary>
        /// Default None.
        /// </summary>
        [LocalizedDescription(null, typeof(EnumResources))]
        None = 0,

        /// <summary>
        /// Forward.
        /// </summary>
        [LocalizedDescription("ForwardReverseTypeForward", typeof(EnumResources))]
        Forward = 1,

        /// <summary>
        /// Reverse.
        /// </summary>
        [LocalizedDescription("ForwardReverseTypeReverse", typeof(EnumResources))]
        Reverse = 2,
    }
}