// ReSharper disable CheckNamespace
namespace System;

/// <summary>
/// Extensions for the <see cref="Guid"/> struct.
/// </summary>
public static class GuidExtensions
{
    /// <summary>
    /// Converts a GUID to its lowercase string representation in the format "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx".
    /// </summary>
    /// <param name="value">The GUID value to convert.</param>
    /// <returns>A lowercase string representation of the GUID using the "D" format specifier (32 digits separated by hyphens).</returns>
    public static string ToStringLower(this Guid value)
        => value.ToString("D");

    /// <summary>
    /// Converts a GUID to its uppercase string representation in the format "XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX".
    /// </summary>
    /// <param name="value">The GUID value to convert.</param>
    /// <returns>An uppercase string representation of the GUID using the "D" format specifier (32 digits separated by hyphens).</returns>
    public static string ToStringUpper(this Guid value)
        => value
            .ToString("D")
            .ToUpperInvariant();
}