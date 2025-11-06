// ReSharper disable once CheckNamespace
namespace Atc.Units.DigitalInformation;

/// <summary>
/// Defines the suffix format for displaying byte sizes.
/// </summary>
[SuppressMessage("Naming", "CA1720:Identifier contains type name", Justification = "OK.")]
public enum ByteSizeSuffixType
{
    /// <summary>
    /// No suffix is appended to the numeric value.
    /// </summary>
    None,

    /// <summary>
    /// Short suffix format (e.g., "B", "KB", "MB", "GB").
    /// </summary>
    Short,

    /// <summary>
    /// Full suffix format (e.g., "byte", "Kilobyte", "Megabyte", "Gigabyte").
    /// </summary>
    Full,
}