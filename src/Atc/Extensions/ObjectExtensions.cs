// ReSharper disable once CheckNamespace
namespace System;

/// <summary>
/// Extensions for the <see cref="object"/> class.
/// </summary>
public static class ObjectExtensions
{
    public static string GetTypeName(
        this object source)
    {
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        return source.GetType().Name;
    }

    public static string GetTypeFullName(
        this object source)
    {
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        return source.GetType().FullName;
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