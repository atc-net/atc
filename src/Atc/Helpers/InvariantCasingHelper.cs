namespace Atc.Helpers;

/// <summary>
/// Changes the case of text with the invariant culture, but keeps a letter as written when its cased form is not a
/// letter to the running .NET runtime.
/// </summary>
/// <remarks>
/// Case mapping follows the platform's Unicode data (ICU on Linux), which can be newer than the runtime's own Unicode
/// tables: a letter can then map to a character the runtime (and the C# compiler) does not know as a letter yet - for
/// example U+A7D3 upper-cases to U+A7D2 with Unicode 17. Keeping such a letter as written means the same input gives
/// the same output on every platform, and a valid identifier stays a valid identifier after casing.
/// </remarks>
public static class InvariantCasingHelper
{
    /// <summary>
    /// Upper-cases a character with the invariant culture, keeping a letter whose upper case is no letter to this runtime.
    /// </summary>
    /// <param name="value">The character.</param>
    /// <returns>The upper-case character, or <paramref name="value"/> itself.</returns>
    public static char ToUpper(char value)
        => Keep(value, char.ToUpperInvariant(value));

    /// <summary>
    /// Upper-cases a text with the invariant culture, keeping each letter whose upper case is no letter to this runtime.
    /// </summary>
    /// <param name="value">The text.</param>
    /// <returns>The upper-case text; <see langword="null"/> or empty text is returned as it is.</returns>
    public static string ToUpper(string value)
        => string.IsNullOrEmpty(value)
            ? value
            : Keep(value, value.ToUpperInvariant());

    /// <summary>
    /// Lower-cases a character with the invariant culture, keeping a letter whose lower case is no letter to this runtime.
    /// </summary>
    /// <param name="value">The character.</param>
    /// <returns>The lower-case character, or <paramref name="value"/> itself.</returns>
    public static char ToLower(char value)
        => Keep(value, char.ToLowerInvariant(value));

    /// <summary>
    /// Lower-cases a text with the invariant culture, keeping each letter whose lower case is no letter to this runtime.
    /// </summary>
    /// <param name="value">The text.</param>
    /// <returns>The lower-case text; <see langword="null"/> or empty text is returned as it is.</returns>
    [SuppressMessage("Microsoft.Globalization", "CA1308:NormalizeStringsToUppercase", Justification = "Lower case is the purpose.")]
    public static string ToLower(string value)
        => string.IsNullOrEmpty(value)
            ? value
            : Keep(value, value.ToLowerInvariant());

    /// <summary>
    /// Upper-cases the first character of a text and leaves the rest as it is.
    /// </summary>
    /// <param name="value">The text.</param>
    /// <returns>The text with its first character upper-cased; <see langword="null"/> or empty text is returned as it is.</returns>
    public static string ToUpperFirst(string value)
        => string.IsNullOrEmpty(value)
            ? value
            : ToUpper(value[0]) + value.Substring(1);

    /// <summary>
    /// Lower-cases the first character of a text and leaves the rest as it is.
    /// </summary>
    /// <param name="value">The text.</param>
    /// <returns>The text with its first character lower-cased; <see langword="null"/> or empty text is returned as it is.</returns>
    public static string ToLowerFirst(string value)
        => string.IsNullOrEmpty(value)
            ? value
            : ToLower(value[0]) + value.Substring(1);

    /// <summary>
    /// Returns the cased character, unless a letter was cased to a character this runtime does not know as a letter.
    /// </summary>
    /// <param name="original">The character before casing.</param>
    /// <param name="cased">The character after casing.</param>
    /// <returns><paramref name="cased"/>, or <paramref name="original"/> when only that one is a letter.</returns>
    public static char Keep(
        char original,
        char cased)
        => char.IsLetter(cased) || !char.IsLetter(original)
            ? cased
            : original;

    /// <summary>
    /// Returns the cased text, with each letter that was cased to a character this runtime does not know as a letter
    /// put back as it was. A letter of two code units (a surrogate pair) is checked as one.
    /// </summary>
    /// <param name="original">The text before casing.</param>
    /// <param name="cased">The text after casing (invariant casing keeps the length).</param>
    /// <returns>The cased text with such letters as they were; <paramref name="cased"/> when the lengths differ.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="original"/> or <paramref name="cased"/> is <see langword="null"/>.</exception>
    public static string Keep(
        string original,
        string cased)
    {
        if (original is null)
        {
            throw new ArgumentNullException(nameof(original));
        }

        if (cased is null)
        {
            throw new ArgumentNullException(nameof(cased));
        }

        if (original.Length != cased.Length)
        {
            return cased;
        }

        StringBuilder? sb = null;
        var i = 0;
        while (i < original.Length)
        {
            var width = char.IsSurrogatePair(original, i) && char.IsSurrogatePair(cased, i) ? 2 : 1;
            if (char.IsLetter(original, i) && !char.IsLetter(cased, i))
            {
                sb ??= new StringBuilder(cased);
                for (var j = i; j < i + width; j++)
                {
                    sb[j] = original[j];
                }
            }

            i += width;
        }

        return sb?.ToString() ?? cased;
    }
}