// ReSharper disable once CheckNamespace
namespace Atc;

/// <summary>
/// Represents different types of diacritical marks (accents) that can be applied to letters.
/// This is a flags enumeration that allows multiple accent types to be combined.
/// </summary>
[SuppressMessage("Minor Code Smell", "S2342:Enumeration types should comply with a naming convention", Justification = "OK.")]
[Flags]
public enum LetterAccentType
{
    /// <summary>
    /// No accent type specified.
    /// </summary>
    None = 0x00,

    /// <summary>
    /// Grave accent (e.g., à, è, ù).
    /// </summary>
    Grave = 0x01,

    /// <summary>
    /// Acute accent (e.g., á, é, ú).
    /// </summary>
    Acute = 0x02,

    /// <summary>
    /// Circumflex accent (e.g., â, ê, û).
    /// </summary>
    Circumflex = 0x04,

    /// <summary>
    /// Tilde accent (e.g., ã, ñ, õ).
    /// </summary>
    Tilde = 0x08,

    /// <summary>
    /// Umlaut or diaeresis (e.g., ä, ë, ü).
    /// </summary>
    Umlaut = 0x10,

    /// <summary>
    /// All accent types combined.
    /// </summary>
    All = Grave | Acute | Circumflex | Tilde | Umlaut,
}