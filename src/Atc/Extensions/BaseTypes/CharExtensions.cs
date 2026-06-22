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

    /// <summary>
    /// Determines whether the specified character is an ASCII letter (A–Z or a–z).
    /// </summary>
    /// <param name="value">The character to check.</param>
    /// <returns><see langword="true"/> if the character is an ASCII letter; otherwise, <see langword="false"/>.</returns>
    public static bool IsAsciiLetter(this char value)
        => (value >= 'A' && value <= 'Z') || (value >= 'a' && value <= 'z');

    /// <summary>
    /// Determines whether the specified character is an ASCII decimal digit (0–9).
    /// </summary>
    /// <param name="value">The character to check.</param>
    /// <returns><see langword="true"/> if the character is a digit 0 through 9; otherwise, <see langword="false"/>.</returns>
    public static bool IsAsciiDigit(this char value)
        => value >= '0' && value <= '9';

    /// <summary>
    /// Determines whether the specified character is a hexadecimal digit (0–9, A–F, a–f).
    /// </summary>
    /// <param name="value">The character to check.</param>
    /// <returns><see langword="true"/> if the character is a valid hexadecimal digit; otherwise, <see langword="false"/>.</returns>
    public static bool IsHexDigit(this char value)
        => (value >= '0' && value <= '9')
        || (value >= 'A' && value <= 'F')
        || (value >= 'a' && value <= 'f');

    /// <summary>
    /// Determines whether the specified character is an ASCII vowel (A, E, I, O, U — case-insensitive).
    /// </summary>
    /// <param name="value">The character to check.</param>
    /// <returns><see langword="true"/> if the character is one of A, E, I, O, U (upper or lower case); otherwise, <see langword="false"/>.</returns>
    public static bool IsVowel(this char value)
        => value is 'A' or 'E' or 'I' or 'O' or 'U'
               or 'a' or 'e' or 'i' or 'o' or 'u';
}