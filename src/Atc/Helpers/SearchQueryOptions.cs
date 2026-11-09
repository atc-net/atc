namespace Atc.Helpers;

/// <summary>
/// Options for how <see cref="SearchQueryHelper.Parse"/> splits a free-text search into terms.
/// </summary>
public sealed class SearchQueryOptions
{
    /// <summary>
    /// Gets or sets the characters that separate words outside quotes, besides white space.
    /// Defaults to a comma, so "Main Street,8" is three words.
    /// </summary>
    public IReadOnlyList<char> WordSeparators { get; set; } = [','];

    /// <summary>
    /// Gets or sets the characters treated as word breaks inside a quoted phrase, besides white space.
    /// They become single spaces, so "Main Street 8, 7900" and "main street 8 7900" are the same phrase.
    /// A consumer that matches phrases elsewhere (e.g. in a database query) should normalize the
    /// searched text with the same characters.
    /// </summary>
    public IReadOnlyList<char> PhraseSeparators { get; set; } = [',', '.', ';', ':', '/', '-', '(', ')'];

    /// <summary>
    /// Gets or sets a value indicating whether a full GUID (quoted or not) becomes a
    /// <see cref="SearchTermType.Identifier"/> term. Defaults to <see langword="true"/>; when
    /// <see langword="false"/>, a GUID is an ordinary word or phrase.
    /// </summary>
    public bool DetectGuids { get; set; } = true;
}