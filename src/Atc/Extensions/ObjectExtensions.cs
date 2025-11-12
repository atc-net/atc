// ReSharper disable once CheckNamespace
namespace System;

/// <summary>
/// Extensions for the <see cref="object"/> class.
/// </summary>
public static class ObjectExtensions
{
    public static string GetTypeName(this object source)
    {
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        return source.GetType().Name;
    }

    public static string GetTypeFullName(this object source)
    {
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        return source.GetType().FullName!;
    }

    public static object? GetPropertyValue(
        this object source,
        string propertyName)
    {
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        return source
            .GetType()
            .GetProperty(propertyName)?
            .GetValue(source, index: null);
    }

    /// <summary>
    /// Converts an object to its string representation with normalized line endings.
    /// </summary>
    /// <param name="value">The object to convert. Can be <see langword="null"/>.</param>
    /// <returns>A string representation of the object with environment-specific line endings, or <see cref="string.Empty"/> if the value or its string representation is <see langword="null"/>.</returns>
    /// <remarks>This method ensures that all line endings in the resulting string are normalized to <see cref="Environment.NewLine"/>.</remarks>
    public static string ToStringNormalized(this object? value)
    {
        if (value is null)
        {
            return string.Empty;
        }

        var text = value.ToString();
        return text is null
            ? string.Empty
            : text.EnsureEnvironmentNewLines();
    }

    /// <summary>
    /// Converts an object to its string representation with leading and trailing whitespace removed.
    /// </summary>
    /// <param name="source">The object to convert. Can be <see langword="null"/>.</param>
    /// <returns>A trimmed string representation of the object, or <see cref="string.Empty"/> if the source or its string representation is <see langword="null"/>.</returns>
    public static string ToStringTrimmed(this object source)
    {
        if (source is null)
        {
            return string.Empty;
        }

        return source
            .ToString()?
            .Trim() ?? string.Empty;
    }

    public static T Clone<T>(
        this T source,
        CloneStrategyType strategy = CloneStrategyType.Json)
    {
        switch (strategy)
        {
            case CloneStrategyType.None:
            case CloneStrategyType.Json:
                var serialized = JsonSerializer.Serialize(source);
                return JsonSerializer.Deserialize<T>(serialized)!;
            default:
                throw new SwitchCaseDefaultException(strategy);
        }
    }
}