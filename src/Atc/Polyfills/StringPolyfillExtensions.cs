#if NETSTANDARD2_0
#pragma warning disable SA1611 // The documentation for parameter is missing
#pragma warning disable ATC202 // Multi parameters should be broken down to separate lines

namespace System;

/// <summary>
/// Polyfill extension methods for String that are not available in netstandard2.0.
/// </summary>
internal static class StringPolyfillExtensions
{
    /// <summary>
    /// Returns a value indicating whether a specified character occurs within this string, using the specified comparison rules.
    /// </summary>
    public static bool Contains(this string str, char value, StringComparison comparisonType)
    {
        if (str == null)
        {
            throw new System.ArgumentNullException(nameof(str));
        }

        return str.IndexOf(value.ToString(), comparisonType) >= 0;
    }

    /// <summary>
    /// Returns a value indicating whether a specified string occurs within this string, using the specified comparison rules.
    /// </summary>
    public static bool Contains(this string str, string value, StringComparison comparisonType)
    {
        if (str == null)
        {
            throw new System.ArgumentNullException(nameof(str));
        }

        if (value == null)
        {
            throw new System.ArgumentNullException(nameof(value));
        }

        return str.IndexOf(value, comparisonType) >= 0;
    }

    /// <summary>
    /// Returns a new string in which all occurrences of a specified string are replaced with another specified string, using the provided comparison type.
    /// </summary>
    public static string Replace(this string str, string oldValue, string newValue, StringComparison comparisonType)
    {
        if (str == null)
        {
            throw new System.ArgumentNullException(nameof(str));
        }

        if (oldValue == null)
        {
            throw new System.ArgumentNullException(nameof(oldValue));
        }

        if (newValue == null)
        {
            throw new System.ArgumentNullException(nameof(newValue));
        }

        if (oldValue.Length == 0)
        {
            throw new ArgumentException("String cannot be of zero length.", nameof(oldValue));
        }

        if (comparisonType == StringComparison.Ordinal)
        {
            return str.Replace(oldValue, newValue);
        }

        var sb = new System.Text.StringBuilder();
        var previousIndex = 0;
        var index = str.IndexOf(oldValue, comparisonType);

        while (index != -1)
        {
            sb.Append(str.Substring(previousIndex, index - previousIndex));
            sb.Append(newValue);
            previousIndex = index + oldValue.Length;
            index = str.IndexOf(oldValue, previousIndex, comparisonType);
        }

        sb.Append(str.Substring(previousIndex));
        return sb.ToString();
    }

    /// <summary>
    /// Splits a string into substrings based on specified delimiting characters and options.
    /// </summary>
    public static string[] Split(this string str, char separator, StringSplitOptions options)
    {
        if (str == null)
        {
            throw new System.ArgumentNullException(nameof(str));
        }

        return str.Split(new[] { separator }, options);
    }

    /// <summary>
    /// Splits a string into substrings based on specified delimiting strings and options.
    /// </summary>
    public static string[] Split(this string str, string separator, StringSplitOptions options)
    {
        if (str == null)
        {
            throw new System.ArgumentNullException(nameof(str));
        }

        if (separator == null)
        {
            throw new System.ArgumentNullException(nameof(separator));
        }

        return str.Split(new[] { separator }, options);
    }

    /// <summary>
    /// Determines whether the end of this string instance matches the specified character.
    /// </summary>
    public static bool EndsWith(this string str, char value)
    {
        if (str == null)
        {
            throw new System.ArgumentNullException(nameof(str));
        }

        return str.Length > 0 && str[str.Length - 1] == value;
    }

    /// <summary>
    /// Determines whether the beginning of this string instance matches the specified character.
    /// </summary>
    public static bool StartsWith(this string str, char value)
    {
        if (str == null)
        {
            throw new System.ArgumentNullException(nameof(str));
        }

        return str.Length > 0 && str[0] == value;
    }
}
#endif