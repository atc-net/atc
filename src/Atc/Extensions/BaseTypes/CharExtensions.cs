// ReSharper disable once CheckNamespace
namespace System;

/// <summary>
/// Extensions for the <see cref="char"/> type.
/// </summary>
public static class CharExtensions
{
    /// <summary>
    /// Determines whether the specified character is an ASCII character.
    /// </summary>
    /// <param name="value">The character to check.</param>
    /// <returns><see langword="true"/> if the character value is less than or equal to 127 (ASCII range); otherwise, <see langword="false"/>.</returns>
    public static bool IsAscii(this char value)
        => value <= sbyte.MaxValue;
}