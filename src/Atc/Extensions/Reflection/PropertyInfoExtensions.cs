// ReSharper disable once CheckNamespace
namespace System.Reflection;

/// <summary>
/// Extensions for the <see cref="PropertyInfo"/> class.
/// </summary>
public static class PropertyInfoExtensions
{
    /// <summary>
    /// Gets a beautified name of the property's type.
    /// </summary>
    /// <param name="propertyInfo">The property information.</param>
    /// <returns>A beautified string representation of the property's type.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="propertyInfo"/> is null.</exception>
    public static string BeautifyName(this PropertyInfo propertyInfo)
    {
        if (propertyInfo is null)
        {
            throw new ArgumentNullException(nameof(propertyInfo));
        }

        var underlyingType = Nullable.GetUnderlyingType(propertyInfo.PropertyType)!;
        if (underlyingType is not null)
        {
            return underlyingType.BeautifyTypeName() + "?";
        }

        // ReSharper disable once InvertIf
        if (propertyInfo.PropertyType.IsSimple())
        {
            // ReSharper disable once ConvertIfStatementToReturnStatement
            if (propertyInfo.PropertyType.IsEnum)
            {
                return typeof(int).BeautifyTypeName();
            }

            return propertyInfo.PropertyType.BeautifyTypeName();
        }

        return propertyInfo.PropertyType.ToString();
    }

    /// <summary>
    /// Gets the display name of the property from DisplayName, Display, or the property name itself.
    /// </summary>
    /// <param name="propertyInfo">The property information.</param>
    /// <returns>The display name of the property.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="propertyInfo"/> is null.</exception>
    public static string GetName(this PropertyInfo propertyInfo)
    {
        if (propertyInfo is null)
        {
            throw new ArgumentNullException(nameof(propertyInfo));
        }

        var attributeValue = GetAttributeValue<DisplayNameAttribute, string>(propertyInfo, arg => arg.DisplayName);
        if (string.IsNullOrEmpty(attributeValue))
        {
            attributeValue = GetAttributeValue<DisplayAttribute, string>(propertyInfo, arg => arg.Name!);
        }

        if (string.IsNullOrEmpty(attributeValue))
        {
            attributeValue = propertyInfo.Name;
        }

        return attributeValue;
    }

    /// <summary>
    /// Gets the description of the property from various description attributes or the property name.
    /// </summary>
    /// <param name="propertyInfo">The property information.</param>
    /// <param name="useLocalizedIfPossible">If set to <see langword="true"/>, attempts to use localized description first.</param>
    /// <returns>The description of the property.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="propertyInfo"/> is null.</exception>
    public static string GetDescription(
        this PropertyInfo propertyInfo,
        bool useLocalizedIfPossible = true)
    {
        if (propertyInfo is null)
        {
            throw new ArgumentNullException(nameof(propertyInfo));
        }

        string? attributeValue = null;
        if (useLocalizedIfPossible)
        {
            attributeValue = GetAttributeValue<LocalizedDescriptionAttribute, string>(propertyInfo, arg => arg.Description!);
        }

        if (string.IsNullOrEmpty(attributeValue))
        {
            attributeValue = GetAttributeValue<DescriptionAttribute, string>(propertyInfo, arg => arg.Description);
        }

        if (string.IsNullOrEmpty(attributeValue))
        {
            attributeValue = GetAttributeValue<DisplayNameAttribute, string>(propertyInfo, arg => arg.DisplayName);
        }

        if (string.IsNullOrEmpty(attributeValue))
        {
            attributeValue = GetAttributeValue<DisplayAttribute, string>(propertyInfo, arg => arg.Description ?? string.Empty);
        }

        if (string.IsNullOrEmpty(attributeValue))
        {
            attributeValue = propertyInfo.Name;
        }

        return attributeValue!;
    }

    /// <summary>
    /// Determines whether the property type is a nullable value type.
    /// </summary>
    /// <param name="propertyInfo">The property information.</param>
    /// <returns><see langword="true"/> if the property is a nullable value type; otherwise, <see langword="false"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="propertyInfo"/> is null.</exception>
    public static bool IsNullable(this PropertyInfo propertyInfo)
    {
        if (propertyInfo is null)
        {
            throw new ArgumentNullException(nameof(propertyInfo));
        }

        return Nullable.GetUnderlyingType(propertyInfo.PropertyType) is not null;
    }

    // ReSharper disable once SuggestBaseTypeForParameter
    private static TExpected GetAttributeValue<T, TExpected>(
        this PropertyInfo propertyInfo,
        Func<T, TExpected> expression)
        where T : Attribute
    {
        var attribute = propertyInfo
            .GetCustomAttributes(typeof(T), true)
            .Cast<T>()
            .SingleOrDefault();

        return (attribute is null
            ? default
            : expression(attribute))!;
    }
}