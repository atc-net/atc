// ReSharper disable RedundantArgumentDefaultValue
// ReSharper disable once CheckNamespace
namespace System;

/// <summary>
/// Extensions for the <see cref="Array"/> class.
/// </summary>
public static class ArrayExtensions
{
    /// <summary>
    /// Removes the duplicates.
    /// </summary>
    /// <param name="array">The array.</param>
    public static Array RemoveDuplicates(this Array array)
    {
        return ToList(array, SortDirectionType.None, removeDuplicates: true).ToArray();
    }

    /// <summary>
    /// To the array.
    /// </summary>
    /// <param name="array">The array.</param>
    /// <param name="sortDirectionType">Type of the sort direction.</param>
    /// <param name="removeDuplicates">if set to <see langword="true" /> [remove duplicates].</param>
    public static Array ToArray(this Array array, SortDirectionType sortDirectionType = SortDirectionType.None, bool removeDuplicates = false)
    {
        return ToList(array, sortDirectionType, removeDuplicates).ToArray();
    }

    /// <summary>
    /// To the list.
    /// </summary>
    /// <param name="array">The array.</param>
    /// <param name="sortDirectionType">Type of the sort direction.</param>
    /// <param name="removeDuplicates">if set to <see langword="true" /> [remove duplicates].</param>
    public static List<string> ToList(this Array array, SortDirectionType sortDirectionType = SortDirectionType.None, bool removeDuplicates = false)
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