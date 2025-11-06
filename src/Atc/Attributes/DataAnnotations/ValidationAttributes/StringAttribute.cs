// ReSharper disable InvertIf
// ReSharper disable LocalizableElement
// ReSharper disable once CheckNamespace
namespace System.ComponentModel.DataAnnotations;

/// <summary>
/// Validates that a property, field, or parameter contains a string value meeting specified constraints.
/// Supports validation of length, invalid characters, invalid prefixes, and regular expression patterns.
/// </summary>
[ExcludeFromCodeCoverage]
[SuppressMessage("Design", "CA1019:Define accessors for attribute arguments", Justification = "OK.")]
[SuppressMessage("Performance", "CA1813:Avoid unsealed attributes", Justification = "OK.")]
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
public class StringAttribute : ValidationAttribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="StringAttribute"/> class with default validation rules.
    /// Default settings: not required, length between 1 and 256 characters.
    /// </summary>
    public StringAttribute()
        : base("The {0} field requires a value.")
    {
        Required = false;
        MinLength = 1;
        MaxLength = 256;
        InvalidCharacters = Array.Empty<char>();
        InvalidPrefixStrings = Array.Empty<string>();
        RegularExpression = string.Empty;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="StringAttribute"/> class with specified length constraints.
    /// </summary>
    /// <param name="required">Indicates whether the string value is required.</param>
    /// <param name="minLength">The minimum allowed length of the string.</param>
    /// <param name="maxLength">The maximum allowed length of the string.</param>
    public StringAttribute(
        bool required,
        uint minLength,
        uint maxLength)
        : this()
    {
        Required = required;
        MinLength = minLength;
        MaxLength = maxLength;
        InvalidCharacters = Array.Empty<char>();
        InvalidPrefixStrings = Array.Empty<string>();
        RegularExpression = string.Empty;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="StringAttribute"/> class with custom invalid characters and prefixes.
    /// </summary>
    /// <param name="required">Indicates whether the string value is required.</param>
    /// <param name="minLength">The minimum allowed length of the string.</param>
    /// <param name="maxLength">The maximum allowed length of the string.</param>
    /// <param name="invalidCharacters">An array of characters that are not allowed in the string.</param>
    /// <param name="invalidPrefixStrings">An array of prefixes that the string cannot start with.</param>
    public StringAttribute(
        bool required,
        uint minLength,
        uint maxLength,
        char[] invalidCharacters,
        string[] invalidPrefixStrings)
        : this()
    {
        Required = required;
        MinLength = minLength;
        MaxLength = maxLength;
        InvalidCharacters = invalidCharacters;
        InvalidPrefixStrings = invalidPrefixStrings;
        RegularExpression = string.Empty;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="StringAttribute"/> class with a regular expression pattern.
    /// </summary>
    /// <param name="required">Indicates whether the string value is required.</param>
    /// <param name="minLength">The minimum allowed length of the string.</param>
    /// <param name="maxLength">The maximum allowed length of the string.</param>
    /// <param name="regularExpression">A regular expression pattern that the string must match.</param>
    public StringAttribute(
        bool required,
        uint minLength,
        uint maxLength,
        string regularExpression)
        : this()
    {
        Required = required;
        MinLength = minLength;
        MaxLength = maxLength;
        InvalidCharacters = Array.Empty<char>();
        InvalidPrefixStrings = Array.Empty<string>();
        RegularExpression = regularExpression;
    }

    /// <summary>
    /// Gets or sets a value indicating whether the string value is required.
    /// </summary>
    public bool Required { get; set; }

    /// <summary>
    /// Gets or sets the minimum allowed length of the string.
    /// </summary>
    public uint MinLength { get; set; }

    /// <summary>
    /// Gets or sets the maximum allowed length of the string.
    /// </summary>
    public uint MaxLength { get; set; }

    /// <summary>
    /// Gets or sets an array of characters that are not allowed in the string.
    /// </summary>
    public char[] InvalidCharacters { get; set; }

    /// <summary>
    /// Gets or sets an array of prefixes that the string cannot start with.
    /// </summary>
    public string[] InvalidPrefixStrings { get; set; }

    /// <summary>
    /// Gets or sets a regular expression pattern that the string must match.
    /// If set, the string will be validated against this pattern with a 2-second timeout.
    /// </summary>
    public string RegularExpression { get; set; }

    public override bool IsValid(
        object? value)
    {
        if (Required &&
            value is null)
        {
            ErrorMessage = "The {0} field is required.";
            return false;
        }

        if (value is null)
        {
            return true;
        }

        var str = value.ToString()!;
        if (str.Length < MinLength ||
            str.Length > MaxLength)
        {
            ErrorMessage = $"The field {{0}} must be between {MinLength} and {MaxLength}.";
            return false;
        }

        if (InvalidCharacters.Any() &&
            InvalidCharacters.Any(x => str.Contains(x, StringComparison.Ordinal)))
        {
            ErrorMessage = $"The field {{0}} cannot contain: {string.Join(", ", InvalidCharacters)}.";
            return false;
        }

        if (InvalidPrefixStrings.Any() &&
            InvalidPrefixStrings.Any(x => str.StartsWith(x.ToString(GlobalizationConstants.EnglishCultureInfo), StringComparison.Ordinal)))
        {
            ErrorMessage = $"The field {{0}} cannot start with: {string.Join(", ", InvalidPrefixStrings)}.";
            return false;
        }

        if (!string.IsNullOrEmpty(RegularExpression))
        {
            var regEx = new Regex(
                RegularExpression,
                RegexOptions.Singleline,
                TimeSpan.FromSeconds(2));

            var match = regEx.Match(str);
            if (!match.Success)
            {
                ErrorMessage = $"The field {{0}} do not match with: {RegularExpression}.";
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// Attempts to validate the specified string using default validation settings.
    /// </summary>
    /// <param name="value">The string value to validate.</param>
    /// <param name="errorMessage">When validation fails, contains a message describing the validation error.</param>
    /// <returns><c>true</c> if the value is valid; otherwise, <c>false</c>.</returns>
    public static bool TryIsValid(
        string value,
        out string errorMessage)
    {
        var attribute = new StringAttribute();
        return TryIsValid(value, attribute, out errorMessage);
    }

    /// <summary>
    /// Attempts to validate the specified string using the provided attribute configuration.
    /// </summary>
    /// <param name="value">The string value to validate.</param>
    /// <param name="attribute">The attribute instance containing validation settings.</param>
    /// <param name="errorMessage">When validation fails, contains a message describing the validation error.</param>
    /// <returns><c>true</c> if the value is valid according to the attribute settings; otherwise, <c>false</c>.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="attribute"/> is null.</exception>
    public static bool TryIsValid(
        string value,
        StringAttribute attribute,
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
            errorMessage = "The value is invalid.";
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