using System;
using System.Diagnostics.CodeAnalysis;

// ReSharper disable once CheckNamespace
namespace Atc
{
    /// <summary>
    /// Flag-Enumeration: LetterAccentType.
    /// </summary>
    [Flags]
    [SuppressMessage("Naming", "CA1714:FlagsEnumsShouldHavePluralNames", Justification = "OK.")]
    public enum LetterAccentType
    {
        /// <summary>
        /// Default None.
        /// </summary>
        None = 0x00,

        /// <summary>
        /// The grave.
        /// </summary>
        Grave = 0x01,

        /// <summary>
        /// The acute.
        /// </summary>
        Acute = 0x02,

        /// <summary>
        /// The circumflex.
        /// </summary>
        Circumflex = 0x04,

        /// <summary>
        /// The tilde.
        /// </summary>
        Tilde = 0x08,

        /// <summary>
        /// The umlaut.
        /// </summary>
        Umlaut = 0x10,

        /// <summary>
        /// All.
        /// </summary>
        All = Grave | Acute | Circumflex | Tilde | Umlaut
    }
}