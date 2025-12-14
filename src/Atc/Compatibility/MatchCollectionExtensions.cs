#if NETSTANDARD2_0
// ReSharper disable once CheckNamespace
namespace System.Text.RegularExpressions;

/// <summary>
/// Polyfill extensions for <see cref="MatchCollection"/> for netstandard2.0 compatibility.
/// Enables LINQ operations on MatchCollection which doesn't implement IEnumerable{Match} in netstandard2.0.
/// </summary>
internal static class MatchCollectionExtensions
{
    /// <summary>
    /// Projects each <see cref="Match"/> in the collection into a new form.
    /// </summary>
    /// <typeparam name="TResult">The type of the value returned by the selector.</typeparam>
    /// <param name="matches">The match collection to project.</param>
    /// <param name="selector">A transform function to apply to each match.</param>
    /// <returns>An enumerable whose elements are the result of invoking the transform function on each match.</returns>
    public static Collections.Generic.IEnumerable<TResult> Select<TResult>(
        this MatchCollection matches,
        Func<Match, TResult> selector)
    {
        foreach (Match match in matches)
        {
            yield return selector(match);
        }
    }
}
#endif