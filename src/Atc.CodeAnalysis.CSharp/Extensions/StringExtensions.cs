#pragma warning disable IDE0130
namespace System;
#pragma warning restore IDE0130

/// <summary>
/// Extension methods for <see cref="string"/>.
/// </summary>
public static class StringExtensions
{
#if NETSTANDARD2_0
    /// <summary>
    /// Polyfill for String.Replace(string, string, StringComparison) which is not available in .NET Standard 2.0.
    /// </summary>
    /// <param name="str">The string to operate on.</param>
    /// <param name="oldValue">The string to be replaced.</param>
    /// <param name="newValue">The string to replace all occurrences of oldValue.</param>
    /// <param name="comparisonType">The StringComparison to use when searching for oldValue.</param>
    public static string Replace(
        this string str,
        string oldValue,
        string newValue,
        StringComparison comparisonType)
    {
        if (str is null)
        {
            throw new ArgumentNullException(nameof(str));
        }

        if (oldValue is null)
        {
            throw new ArgumentNullException(nameof(oldValue));
        }

        if (oldValue.Length == 0)
        {
            throw new ArgumentException("String cannot be of zero length.", nameof(oldValue));
        }

        var sb = new System.Text.StringBuilder();
        var previousIndex = 0;
        var index = str.IndexOf(oldValue, comparisonType);

        while (index != -1)
        {
            sb.Append(str, previousIndex, index - previousIndex);
            sb.Append(newValue);
            index += oldValue.Length;

            previousIndex = index;
            index = str.IndexOf(oldValue, index, comparisonType);
        }

        sb.Append(str, previousIndex, str.Length - previousIndex);
        return sb.ToString();
    }
#endif
}