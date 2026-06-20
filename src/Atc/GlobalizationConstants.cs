namespace Atc;

/// <summary>
/// GlobalizationConstants.
/// </summary>
public static class GlobalizationConstants
{
    /// <summary>
    /// DateTimeIso8601.
    /// </summary>
    public const string DateTimeIso8601 = "s";

    /// <summary>
    /// EnglishCultureInfo.
    /// </summary>
    public static readonly CultureInfo EnglishCultureInfo = CultureInfo.ReadOnly(new CultureInfo("en-US"));

    /// <summary>
    /// DanishCultureInfo.
    /// </summary>
    public static readonly CultureInfo DanishCultureInfo = CultureInfo.ReadOnly(new CultureInfo("da-DK"));
}