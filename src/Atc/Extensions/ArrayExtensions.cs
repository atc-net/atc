// ReSharper disable RedundantArgumentDefaultValue
// ReSharper disable once CheckNamespace
namespace System;

/// <summary>
/// Extensions for the <see cref="Array"/> class.
/// </summary>
public static class ArrayExtensions
{
    /// <summary>
    /// Removes duplicate elements from the array.
    /// </summary>
    /// <param name="array">The array to process.</param>
    /// <returns>An array with duplicate elements removed.</returns>
    public static Array RemoveDuplicates(this Array array)
    {
        return ToList(array, SortDirectionType.None, removeDuplicates: true).ToArray();
    }

    /// <summary>
    /// Converts the array to a sorted array, optionally removing duplicates.
    /// </summary>
    /// <param name="array">The source array.</param>
    /// <param name="sortDirectionType">The sort direction (None, Ascending, or Descending).</param>
    /// <param name="removeDuplicates">If set to <see langword="true"/>, removes duplicate elements.</param>
    /// <returns>A new array with the specified sorting and duplicate removal applied.</returns>
    public static Array ToArray(
        this Array array,
        SortDirectionType sortDirectionType = SortDirectionType.None,
        bool removeDuplicates = false)
    {
        return ToList(array, sortDirectionType, removeDuplicates).ToArray();
    }

    /// <summary>
    /// Converts the array to a list of strings, optionally sorting and removing duplicates.
    /// </summary>
    /// <param name="array">The source array.</param>
    /// <param name="sortDirectionType">The sort direction (None, Ascending, or Descending).</param>
    /// <param name="removeDuplicates">If set to <see langword="true"/>, removes duplicate elements.</param>
    /// <returns>A list of strings with the specified sorting and duplicate removal applied.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="array"/> is null.</exception>
    public static List<string> ToList(
        this Array array,
        SortDirectionType sortDirectionType = SortDirectionType.None,
        bool removeDuplicates = false)
    {
        if (array is null)
        {
            throw new ArgumentNullException(nameof(array));
        }

        var list = new List<string>(array.Length);
        for (var i = 0; i < array.Length; i++)
        {
            var s = array.GetValue(i)?.ToString() ?? string.Empty;
            if (removeDuplicates)
            {
                if (!list.Contains(s, StringComparer.OrdinalIgnoreCase))
                {
                    list.Add(s);
                }
            }
            else
            {
                list.Add(s);
            }
        }

        return sortDirectionType switch
        {
            SortDirectionType.None => list,
            SortDirectionType.Ascending => list.OrderBy(x => x, StringComparer.Ordinal).ToList(),
            SortDirectionType.Descending => list.OrderByDescending(x => x, StringComparer.Ordinal).ToList(),
            _ => throw new SwitchCaseDefaultException(sortDirectionType),
        };
    }
}