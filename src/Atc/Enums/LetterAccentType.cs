// ReSharper disable once CheckNamespace
namespace Atc;

/// <summary>
/// Flag-Enumeration: LetterAccentType.
/// </summary>
[SuppressMessage("Microsoft.Naming", "CA1714:FlagsEnumsShouldHavePluralNames", Justification = "OK.")]
[SuppressMessage("Minor Code Smell", "S2342:Enumeration types should comply with a naming convention", Justification = "OK.")]
[Flags]
public enum LetterAccentType
{
    /// <summary>
    /// Default None.
    /// </summary>
    None = 0x00,

    /// <summary>
    /// Grave.
    /// </summary>
    Grave = 0x01,

    /// <summary>
    /// Acute.
    /// </summary>
    Acute = 0x02,

    /// <summary>
    /// Circumflex.
    /// </summary>
    Circumflex = 0x04,

    /// <summary>
    /// Tilde.
    /// </summary>
    Tilde = 0x08,

    /// <summary>
    /// Umlaut.
    /// </summary>
    Umlaut = 0x10,

    /// <summary>
    /// All.
    /// </summary>
    All = Grave | Acute | Circumflex | Tilde | Umlaut,
}