namespace Atc.Helpers;

/// <summary>
/// Matches paths against glob patterns, such as <c>/api/**/users/*</c> or <c>src/**/*.cs</c>.
/// </summary>
/// <remarks>
/// <para>
/// Paths and patterns are split into segments at <c>/</c> and <c>\</c>. In a pattern:
/// </para>
/// <list type="bullet">
/// <item><description>a segment <c>**</c> matches zero or more whole segments;</description></item>
/// <item><description><c>*</c> inside a segment matches any characters within that segment (a segment of just <c>*</c> matches any one segment);</description></item>
/// <item><description><c>?</c> matches exactly one character within a segment;</description></item>
/// <item><description>anything else matches literally.</description></item>
/// </list>
/// <para>
/// A leading separator is ignored, so <c>pets/*</c> and <c>/pets/*</c> are the same pattern. Matching runs in time
/// proportional to the product of the segment counts, so patterns such as <c>/**/a/**/b/**/c</c> do not backtrack
/// exponentially.
/// </para>
/// </remarks>
public static class GlobHelper
{
    private static readonly char[] Separators = { '/', '\\' };

    /// <summary>
    /// Determines whether a path matches a glob pattern.
    /// </summary>
    /// <param name="path">The path, e.g. <c>/api/v1/users/42</c> or <c>src\Atc\Helpers\GlobHelper.cs</c>.</param>
    /// <param name="pattern">The glob pattern, e.g. <c>/api/**/users/*</c>.</param>
    /// <param name="ignoreCase">Whether letters match regardless of case.</param>
    /// <returns><see langword="true"/> when the whole path matches the pattern; otherwise <see langword="false"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="path"/> or <paramref name="pattern"/> is <see langword="null"/>.</exception>
    /// <example>
    /// <code>
    /// GlobHelper.IsMatch("/api/v1/users/42", "/api/**/users/*"); // true
    /// GlobHelper.IsMatch("src/a/b/Program.cs", "src/**/*.cs");   // true
    /// GlobHelper.IsMatch("/pets", "/pets/*");                    // false
    /// </code>
    /// </example>
    [SuppressMessage("Performance", "CA1814:Prefer jagged arrays over multidimensional", Justification = "Dense lookup table with small dimensions.")]
    public static bool IsMatch(
        string path,
        string pattern,
        bool ignoreCase = true)
    {
        if (path is null)
        {
            throw new ArgumentNullException(nameof(path));
        }

        if (pattern is null)
        {
            throw new ArgumentNullException(nameof(pattern));
        }

        var pathSegments = SplitSegments(path);
        var patternSegments = SplitSegments(pattern);
        var p = pathSegments.Length;
        var q = patternSegments.Length;

        // matches[i, j] is true when pathSegments[i..] matches patternSegments[j..]
        var matches = new bool[p + 1, q + 1];
        matches[p, q] = true;

        for (var j = q - 1; j >= 0; j--)
        {
            var patternSegment = patternSegments[j];
            if (string.Equals(patternSegment, "**", StringComparison.Ordinal))
            {
                for (var i = p; i >= 0; i--)
                {
                    matches[i, j] = matches[i, j + 1] || (i < p && matches[i + 1, j]);
                }
            }
            else
            {
                for (var i = p - 1; i >= 0; i--)
                {
                    matches[i, j] = matches[i + 1, j + 1] &&
                                    IsSegmentMatch(pathSegments[i], patternSegment, ignoreCase);
                }
            }
        }

        return matches[0, 0];
    }

    /// <summary>
    /// Determines whether a path matches any of the glob patterns.
    /// </summary>
    /// <param name="path">The path.</param>
    /// <param name="patterns">The glob patterns (see <see cref="IsMatch(string, string, bool)"/>).</param>
    /// <param name="ignoreCase">Whether letters match regardless of case.</param>
    /// <returns><see langword="true"/> when the path matches at least one pattern; otherwise <see langword="false"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="path"/> or <paramref name="patterns"/> is <see langword="null"/>.</exception>
    public static bool IsMatchAny(
        string path,
        IEnumerable<string> patterns,
        bool ignoreCase = true)
    {
        if (patterns is null)
        {
            throw new ArgumentNullException(nameof(patterns));
        }

        return patterns.Any(pattern => IsMatch(path, pattern, ignoreCase));
    }

    private static string[] SplitSegments(string value)
        => value
            .TrimStart(Separators)
            .Split(Separators);

    // Matches one segment with '*' (any run of characters) and '?' (one character), backtracking only to the last '*'
    private static bool IsSegmentMatch(
        string text,
        string pattern,
        bool ignoreCase)
    {
        var t = 0;
        var s = 0;
        var starPattern = -1;
        var starText = 0;
        while (t < text.Length)
        {
            if (s < pattern.Length && (pattern[s] == '?' || CharEquals(pattern[s], text[t], ignoreCase)))
            {
                t++;
                s++;
            }
            else if (s < pattern.Length && pattern[s] == '*')
            {
                starPattern = s++;
                starText = t;
            }
            else if (starPattern >= 0)
            {
                s = starPattern + 1;
                t = ++starText;
            }
            else
            {
                return false;
            }
        }

        while (s < pattern.Length && pattern[s] == '*')
        {
            s++;
        }

        return s == pattern.Length;
    }

    private static bool CharEquals(
        char a,
        char b,
        bool ignoreCase)
        => a == b ||
           (ignoreCase && char.ToUpperInvariant(a) == char.ToUpperInvariant(b));
}