// ReSharper disable once CheckNamespace
namespace Atc;

/// <summary>
/// Defines the kind of a term parsed from a free-text search by <see cref="Helpers.SearchQueryHelper"/>.
/// </summary>
public enum SearchTermType
{
    /// <summary>
    /// A single word, typically matched as a case-insensitive substring of a text.
    /// </summary>
    Word,

    /// <summary>
    /// A phrase written in double quotes, typically matched as whole words of one text,
    /// so "Main Street 8" does not match "Main Street 81".
    /// </summary>
    Phrase,

    /// <summary>
    /// A full GUID, typically matched as an exact identifier rather than searched in the text.
    /// </summary>
    Identifier,
}