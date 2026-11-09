namespace Atc.Helpers;

/// <summary>
/// Splits a free-text search, as a user types it into a search box, into terms that a list
/// or a database query can match against.
/// </summary>
/// <remarks>
/// <para>The rules:</para>
/// <list type="bullet">
///   <item><description>The search is trimmed; a blank search has no terms.</description></item>
///   <item><description>Outside quotes, the text splits into words on white space and <see cref="SearchQueryOptions.WordSeparators"/>.</description></item>
///   <item><description>Text in double quotes is one phrase; an unclosed quote runs to the end, so a half-typed phrase still works. Inside a phrase, white space and <see cref="SearchQueryOptions.PhraseSeparators"/> fold into single spaces.</description></item>
///   <item><description>A full GUID, quoted or not, is a <see cref="SearchTermType.Identifier"/> term (unless <see cref="SearchQueryOptions.DetectGuids"/> is off); part of a GUID is an ordinary word.</description></item>
/// </list>
/// <para>
/// The helper only parses; how terms match is up to the caller. A common choice is that every
/// term must match: a word anywhere in a text, a phrase as whole words of one text, and a GUID
/// as an exact identifier.
/// </para>
/// </remarks>
public static class SearchQueryHelper
{
    private const char Quote = '"';

    /// <summary>
    /// Parses a free-text search into its terms, in the order they were typed.
    /// </summary>
    /// <param name="search">The search as typed; may be <see langword="null"/>.</param>
    /// <param name="options">How to split the search; <see langword="null"/> uses the defaults.</param>
    /// <returns>The terms; an empty list when <paramref name="search"/> is <see langword="null"/> or blank.</returns>
    /// <example>
    /// <code>
    /// SearchQueryHelper.Parse("\"Main Street 8\" Springfield");
    /// // [ Phrase "Main Street 8", Word "Springfield" ]
    /// </code>
    /// </example>
    public static IReadOnlyList<SearchTerm> Parse(
        string? search,
        SearchQueryOptions? options = null)
    {
        options ??= new SearchQueryOptions();
        var terms = new List<SearchTerm>();
        var text = search.TrimToNull();
        if (text is null)
        {
            return terms;
        }

        var position = 0;
        while (position < text.Length)
        {
            var c = text[position];
            if (c == Quote)
            {
                var close = text.IndexOf(Quote, position + 1);
                var end = close < 0 ? text.Length : close;
                AddPhrase(terms, text.Substring(position + 1, end - position - 1), options);
                position = end + 1;
            }
            else if (IsWordBreak(c, options))
            {
                position++;
            }
            else
            {
                var end = position;
                while (end < text.Length && text[end] != Quote && !IsWordBreak(text[end], options))
                {
                    end++;
                }

                AddWord(terms, text.Substring(position, end - position), options);
                position = end;
            }
        }

        return terms;
    }

    private static bool IsWordBreak(
        char c,
        SearchQueryOptions options)
        => char.IsWhiteSpace(c) || options.WordSeparators.Contains(c);

    private static void AddWord(
        List<SearchTerm> terms,
        string word,
        SearchQueryOptions options)
    {
        terms.Add(TryParseGuid(word, options, out var guid)
            ? new SearchTerm(SearchTermType.Identifier, guid)
            : new SearchTerm(SearchTermType.Word, word));
    }

    private static void AddPhrase(
        List<SearchTerm> terms,
        string text,
        SearchQueryOptions options)
    {
        if (TryParseGuid(text.Trim(), options, out var guid))
        {
            terms.Add(new SearchTerm(SearchTermType.Identifier, guid));
            return;
        }

        var words = new List<string>();
        var current = new StringBuilder();
        foreach (var c in text)
        {
            if (char.IsWhiteSpace(c) || options.PhraseSeparators.Contains(c))
            {
                FlushWord(words, current);
            }
            else
            {
                current.Append(c);
            }
        }

        FlushWord(words, current);
        if (words.Count > 0)
        {
            terms.Add(new SearchTerm(SearchTermType.Phrase, string.Join(" ", words)));
        }
    }

    private static void FlushWord(
        List<string> words,
        StringBuilder current)
    {
        if (current.Length == 0)
        {
            return;
        }

        words.Add(current.ToString());
        current.Clear();
    }

    private static bool TryParseGuid(
        string text,
        SearchQueryOptions options,
        out string guid)
    {
        if (options.DetectGuids && Guid.TryParseExact(text, "D", out var parsed))
        {
            guid = parsed.ToString("D");
            return true;
        }

        guid = string.Empty;
        return false;
    }
}