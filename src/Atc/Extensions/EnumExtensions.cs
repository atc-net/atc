// ReSharper disable once CheckNamespace
namespace System;

/// <summary>
/// Extension methods for enumerations.
/// </summary>
public static class EnumExtensions
{
    /// <summary>
    /// Determines whether all specified flags of another enumeration are set in the current enumeration.
    /// </summary>
    /// <param name="enumeration">The enumeration to check for flags.</param>
    /// <param name="flags">The flags to verify within the enumeration.</param>
    /// <returns>True if all specified flags are set; otherwise, false.</returns>
    /// <example>
    /// <code>
    /// bool areFlagsSet = DayOfWeek.Monday.AreFlagsSet(DayOfWeek.Monday);
    /// Assert.True(areFlagsSet);
    /// </code>
    /// </example>
    public static bool AreFlagsSet(
        this Enum enumeration,
        Enum flags)
        => IsSet(enumeration, flags);

    /// <summary>Determines whether the specified enumeration match another enumeration.</summary>
    /// <param name="enumeration">The enumeration.</param>
    /// <param name="matchTo">The enumeration to match.</param>
    /// <returns>true on match; otherwise false.</returns>
    /// <code><![CDATA[bool match = DayOfWeek.Monday.IsSet(DayOfWeek.Monday);]]></code>
    /// <example><![CDATA[
    /// Assert.True(DayOfWeek.Monday.IsSet(DayOfWeek.Monday));
    /// ]]></example>
    public static bool IsSet(
        this Enum enumeration,
        Enum matchTo)
    {
        if (enumeration is null)
        {
            throw new ArgumentNullException(nameof(enumeration));
        }

        if (matchTo is null)
        {
            throw new ArgumentNullException(nameof(matchTo));
        }

        return (Convert.ToUInt32(enumeration, GlobalizationConstants.EnglishCultureInfo) & Convert.ToUInt32(matchTo, GlobalizationConstants.EnglishCultureInfo)) != 0;
    }

    /// <summary>Gets the name from the enumeration.</summary>
    /// <param name="enumeration">The enumeration.</param>
    /// <returns>The name from the enumeration.</returns>
    /// <code><![CDATA[string day = value.GetName();]]></code>
    /// <example><![CDATA[
    /// Assert.Equal("Monday", DayOfWeek.Monday.GetName());
    /// ]]></example>
    public static string GetName(this Enum enumeration)
    {
        if (enumeration is null)
        {
            throw new ArgumentNullException(nameof(enumeration));
        }

        var attributeValue = GetAttributeValue<DisplayNameAttribute, string>(enumeration, arg => arg.DisplayName);
        if (string.IsNullOrEmpty(attributeValue))
        {
            attributeValue = GetAttributeValue<DisplayAttribute, string>(enumeration, arg => arg.Name!);
        }

        if (string.IsNullOrEmpty(attributeValue))
        {
            attributeValue = enumeration.ToString();
        }

        return attributeValue;
    }

    /// <summary>Gets the description from the enumeration.</summary>
    /// <param name="enumeration">The enumeration.</param>
    /// <param name="useLocalizedIfPossible">true to use attribute for localized/description/display if possible, default is the name; false to just use the name.</param>
    /// <returns>The description from the enumeration.</returns>
    /// <code><![CDATA[string day = value.GetDescription();]]></code>
    /// <example><![CDATA[
    /// Assert.Equal("Monday", DayOfWeek.Monday.GetDescription());
    /// ]]></example>
    public static string GetDescription(
        this Enum enumeration,
        bool useLocalizedIfPossible = true)
    {
        if (enumeration is null)
        {
            throw new ArgumentNullException(nameof(enumeration));
        }

        string? attributeValue = null;
        if (useLocalizedIfPossible)
        {
            attributeValue = GetAttributeValue<LocalizedDescriptionAttribute, string>(enumeration, arg => arg.Description!);
        }

        if (string.IsNullOrEmpty(attributeValue))
        {
            attributeValue = GetAttributeValue<DescriptionAttribute, string>(enumeration, arg => arg.Description);
        }

        if (string.IsNullOrEmpty(attributeValue))
        {
            attributeValue = GetAttributeValue<DescriptionAttribute, string>(enumeration, arg => arg.Description);
        }

        if (string.IsNullOrEmpty(attributeValue))
        {
            attributeValue = GetAttributeValue<DisplayNameAttribute, string>(enumeration, arg => arg.DisplayName);
        }

        if (string.IsNullOrEmpty(attributeValue))
        {
            attributeValue = GetAttributeValue<DisplayAttribute, string>(enumeration, arg => arg.Description ?? string.Empty);
        }

        return string.IsNullOrEmpty(attributeValue)
            ? enumeration
                .ToString()
                .Humanize()
            : attributeValue!;
    }

    /// <summary>
    /// Converts the named constant to <see langword="string"/> in upper case.
    /// </summary>
    /// <param name="enumeration">The enum.</param>
    public static string ToStringUpperCase(this Enum enumeration)
    {
        if (enumeration is null)
        {
            throw new ArgumentNullException(nameof(enumeration));
        }

        return enumeration
            .ToString()
            .ToUpperInvariant();
    }

    /// <summary>
    /// Converts the named constant to <see langword="string"/> in lower case.
    /// </summary>
    /// <param name="enumeration">The enum.</param>
    [SuppressMessage("Globalization", "CA1308:Normalize strings to uppercase", Justification = "Triggers warnings, but is irrelevant for this case.")]
    public static string ToStringLowerCase(this Enum enumeration)
    {
        if (enumeration is null)
        {
            throw new ArgumentNullException(nameof(enumeration));
        }

        return enumeration
            .ToString()
            .ToLowerInvariant();
    }

    /// <summary>Gets the attribute value.</summary>
    /// <typeparam name="T">The type.</typeparam>
    /// <typeparam name="TExpected">The type of the expected.</typeparam>
    /// <param name="enumeration">The enumeration.</param>
    /// <param name="expression">The expression.</param>
    /// <returns>The string attribute value of the enumeration.</returns>
    private static TExpected GetAttributeValue<T, TExpected>(
        this Enum enumeration,
        Func<T, TExpected> expression)
        where T : Attribute
    {
        if (enumeration is null)
        {
            throw new ArgumentNullException(nameof(enumeration));
        }

        if (expression is null)
        {
            throw new ArgumentNullException(nameof(expression));
        }

        var attribute = enumeration
            .GetType()
            .GetMember(enumeration.ToString())[0]
            .GetCustomAttributes(typeof(T), true)
            .Cast<T>()
            .SingleOrDefault();

        return (attribute is null
            ? default
            : expression(attribute))!;
    }
}