// ReSharper disable once CheckNamespace
namespace System.ComponentModel.DataAnnotations;

/// <summary>
/// Validates that a property or field contains a valid key string.
/// By default, excludes spaces, periods, at signs, and apostrophes, and disallows strings starting with underscores.
/// This attribute extends <see cref="StringAttribute"/> with key-specific validation rules.
/// </summary>
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
public sealed class KeyStringAttribute : StringAttribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="KeyStringAttribute"/> class with default key validation rules.
    /// Default settings: required, disallows ' ', '.', '@', '\'' characters and '_' prefix.
    /// </summary>
    public KeyStringAttribute()
    {
        Required = true;
        InvalidCharacters = new[] { ' ', '.', '@', '\'' };
        InvalidPrefixStrings = new[] { "_" };
        RegularExpression = string.Empty;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="KeyStringAttribute"/> class with specified length constraints.
    /// </summary>
    /// <param name="required">Indicates whether the key string value is required.</param>
    /// <param name="minLength">The minimum allowed length of the key string.</param>
    /// <param name="maxLength">The maximum allowed length of the key string.</param>
    public KeyStringAttribute(
        bool required,
        uint minLength,
        uint maxLength)
        : base(
            required,
            minLength,
            maxLength)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="KeyStringAttribute"/> class with custom invalid characters and prefixes.
    /// </summary>
    /// <param name="required">Indicates whether the key string value is required.</param>
    /// <param name="minLength">The minimum allowed length of the key string.</param>
    /// <param name="maxLength">The maximum allowed length of the key string.</param>
    /// <param name="invalidCharacters">An array of characters that are not allowed in the key string.</param>
    /// <param name="invalidPrefixStrings">An array of prefixes that the key string cannot start with.</param>
    public KeyStringAttribute(
        bool required,
        uint minLength,
        uint maxLength,
        char[] invalidCharacters,
        string[] invalidPrefixStrings)
        : base(
            required,
            minLength,
            maxLength,
            invalidCharacters,
            invalidPrefixStrings)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="KeyStringAttribute"/> class with a regular expression pattern.
    /// </summary>
    /// <param name="required">Indicates whether the key string value is required.</param>
    /// <param name="minLength">The minimum allowed length of the key string.</param>
    /// <param name="maxLength">The maximum allowed length of the key string.</param>
    /// <param name="regularExpression">A regular expression pattern that the key string must match.</param>
    public KeyStringAttribute(
        bool required,
        uint minLength,
        uint maxLength,
        string regularExpression)
        : base(
            required,
            minLength,
            maxLength,
            regularExpression)
    {
    }

    /// <summary>
    /// Attempts to validate the specified string as a key string using default validation settings.
    /// </summary>
    /// <param name="value">The string value to validate.</param>
    /// <param name="errorMessage">When validation fails, contains a message describing the validation error.</param>
    /// <returns><c>true</c> if the value is a valid key string; otherwise, <c>false</c>.</returns>
    public static new bool TryIsValid(
        string value,
        out string errorMessage)
    {
        var attribute = new KeyStringAttribute();
        return TryIsValid(value, attribute, out errorMessage);
    }

    /// <summary>
    /// Attempts to validate the specified string as a key string using the provided attribute configuration.
    /// </summary>
    /// <param name="value">The string value to validate.</param>
    /// <param name="attribute">The attribute instance containing validation settings.</param>
    /// <param name="errorMessage">When validation fails, contains a message describing the validation error.</param>
    /// <returns><c>true</c> if the value is valid according to the attribute settings; otherwise, <c>false</c>.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="attribute"/> is null.</exception>
    public static bool TryIsValid(
        string value,
        KeyStringAttribute attribute,
        out string errorMessage)
    {
        if (attribute is null)
        {
            throw new ArgumentNullException(nameof(attribute));
        }

        if (attribute.IsValid(value))
        {
            errorMessage = string.Empty;
            return true;
        }

        if (attribute.ErrorMessage is null)
        {
            errorMessage = "The value is not a valid KeyString.";
        }
        else
        {
            errorMessage = attribute.ErrorMessage
                .Replace("field {0}", "value", StringComparison.Ordinal)
                .Replace("{0} field", "value", StringComparison.Ordinal);
        }

        return false;
    }
}