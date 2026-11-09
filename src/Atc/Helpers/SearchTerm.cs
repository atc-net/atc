namespace Atc.Helpers;

/// <summary>
/// Represents one term of a free-text search, as parsed by <see cref="SearchQueryHelper.Parse"/>.
/// </summary>
/// <param name="Type">The kind of term: a word, a quoted phrase or a full GUID.</param>
/// <param name="Value">
/// The word as typed; the phrase with its separators folded into single spaces; or the GUID in
/// lower-case "D" format (e.g. "5b1eba26-8b25-f111-8341-7c1e52fbbe51").
/// </param>
public sealed record SearchTerm(
    SearchTermType Type,
    string Value);