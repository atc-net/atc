// ReSharper disable once CheckNamespace
namespace Atc.Units.DigitalInformation;

/// <summary>
/// Enumeration: Format the suffix word.
/// </summary>
[SuppressMessage("Naming", "CA1720:Identifier contains type name", Justification = "OK.")]
public enum ByteSizeSuffixType
{
    None,

    /// <summary>
    /// Short like: KB, GB etc.
    /// </summary>
    Short,

    /// <summary>
    /// Full like: Kilobyte, Gigabyte etc.
    /// </summary>
    Full,
}