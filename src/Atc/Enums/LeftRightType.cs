using Atc.Resources;

// ReSharper disable once CheckNamespace
namespace Atc
{
    /// <summary>
    /// Enumeration: LeftRightType.
    /// </summary>
    public enum LeftRightType
    {
        /// <summary>
        /// Default None
        /// </summary>
        [LocalizedDescription(null, typeof(EnumResources))]
        None = 0,

        /// <summary>
        /// Left
        /// </summary>
        [LocalizedDescription("LeftRightTypeLeft", typeof(EnumResources))]
        Left = 1,

        /// <summary>
        /// Right
        /// </summary>
        [LocalizedDescription("LeftRightTypeRight", typeof(EnumResources))]
        Right = 2
    }
}