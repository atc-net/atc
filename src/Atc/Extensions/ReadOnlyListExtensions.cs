// ReSharper disable once CheckNamespace
namespace System.Collections.Generic;

[ExcludeFromCodeCoverage]
public static class ReadOnlyListExtensions
{
    public static IEnumerable<IEnumerable<string>> GetUniqueCombinations(this IReadOnlyList<string> list)
    {
        if (list is null)
        {
            throw new ArgumentNullException(nameof(list));
        }

        var result = new List<List<string>>();
        var uniqueCombinations = GetUniqueCombinationsAsCommaSeparated(list);
        foreach (var uniqueCombination in uniqueCombinations)
        {
            var combinations = new List<string>();
            combinations.AddRange(uniqueCombination.Split(','));
            result.Add(combinations);
        }

        return result;
    }

    public static IEnumerable<string> GetUniqueCombinationsAsCommaSeparated(this IReadOnlyList<string> list)
    {
        if (list is null)
        {
            throw new ArgumentNullException(nameof(list));
        }

        return GetPowerSet(list)
            .Select(subset => string.Join(",", subset.ToArray()))
            .Where(x => x.Length > 0)
            .ToList();
    }

    public static IEnumerable<IEnumerable<T>> GetPowerSet<T>(this IReadOnlyList<T> list)
    {
        if (list is null)
        {
            throw new ArgumentNullException(nameof(list));
        }

        return from m in Enumerable.Range(0, 1 << list.Count)
            select
                from i in Enumerable.Range(0, list.Count)
                where (m & (1 << i)) != 0
                select list[i];
    }
}