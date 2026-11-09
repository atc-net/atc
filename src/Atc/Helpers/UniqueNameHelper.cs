namespace Atc.Helpers;

/// <summary>
/// Hands out unique names within a scope by numbering repeats: <c>name</c>, <c>name2</c>, <c>name3</c>, ...
/// </summary>
/// <remarks>
/// Useful for code generators where every source item needs its own name and none may be dropped, e.g. two
/// parameters that both become <c>id</c> after sanitizing.
/// </remarks>
public static class UniqueNameHelper
{
    /// <summary>
    /// Takes the first of <paramref name="name"/>, <c>name2</c>, <c>name3</c>, ... that is not in
    /// <paramref name="taken"/> yet, and adds it to <paramref name="taken"/>.
    /// </summary>
    /// <param name="taken">The names already used in the scope; the claimed name is added to it. Its comparer decides
    /// whether names differing only in case collide.</param>
    /// <param name="name">The name wanted.</param>
    /// <returns>The name claimed.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="taken"/> or <paramref name="name"/> is <see langword="null"/>.</exception>
    /// <example>
    /// <code>
    /// var taken = new HashSet&lt;string&gt;(StringComparer.Ordinal);
    /// UniqueNameHelper.Claim(taken, "id"); // "id"
    /// UniqueNameHelper.Claim(taken, "id"); // "id2"
    /// </code>
    /// </example>
    public static string Claim(
        ISet<string> taken,
        string name)
    {
        if (taken is null)
        {
            throw new ArgumentNullException(nameof(taken));
        }

        if (name is null)
        {
            throw new ArgumentNullException(nameof(name));
        }

        var unique = name;
        var number = 1;
        while (!taken.Add(unique))
        {
            number++;
            unique = name + number.ToString(CultureInfo.InvariantCulture);
        }

        return unique;
    }
}