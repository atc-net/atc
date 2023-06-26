namespace Atc.Data.SemVer;

internal static class PreReleaseVersion
{
    public static int Compare(string? a, string? b)
    {
        if (a == null && b == null)
        {
            return 0;
        }

        if (a == null)
        {
            return 1;
        }

        if (b == null)
        {
            return -1;
        }

        return IdentifierComparisons(Identifiers(a), Identifiers(b)).FirstOrDefault(c => c != 0);
    }

    public static string Build(string input)
    {
        var identifierStrings = Identifiers(input).Select(i => i.Clean());
        return string.Join('.', identifierStrings.ToArray());
    }

    private static IEnumerable<Identifier> Identifiers(string input)
        => input.Split('.').Select(identifier => new Identifier(identifier));

    private static IEnumerable<int> IdentifierComparisons(
            IEnumerable<Identifier> firstIdentifiers,
            IEnumerable<Identifier> secondIdentifiers)
    {
        foreach (var (a, b) in ZipIdentifiers(firstIdentifiers, secondIdentifiers))
        {
            if (a == b)
            {
                yield return 0;
            }
            else if (a == null)
            {
                yield return -1;
            }
            else if (b == null)
            {
                yield return 1;
            }
            else
            {
                yield return a.IsNumeric switch
                {
                    true when b.IsNumeric => a.IntValue.CompareTo(b.IntValue),
                    false when !b.IsNumeric => string.CompareOrdinal(a.Value, b.Value),
                    true when !b.IsNumeric => -1,
                    _ => 1,
                };
            }
        }
    }

    private static IEnumerable<Tuple<Identifier, Identifier>> ZipIdentifiers(
            IEnumerable<Identifier> firstIdentifiers,
            IEnumerable<Identifier> secondIdentifiers)
    {
        using var firstEnumerator = firstIdentifiers.GetEnumerator();
        using var secondEnumerator = secondIdentifiers.GetEnumerator();
        while (firstEnumerator.MoveNext())
        {
            if (secondEnumerator.MoveNext())
            {
                yield return Tuple.Create(firstEnumerator.Current, secondEnumerator.Current);
            }
            else
            {
                yield return Tuple.Create<Identifier, Identifier>(firstEnumerator.Current, null!);
            }
        }

        while (secondEnumerator.MoveNext())
        {
            yield return Tuple.Create<Identifier, Identifier>(null!, secondEnumerator.Current);
        }
    }
}