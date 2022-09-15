// ReSharper disable InvertIf
// ReSharper disable LocalizableElement
// ReSharper disable once CheckNamespace
namespace System.ComponentModel.DataAnnotations;

[SuppressMessage("Design", "CA1019:Define accessors for attribute arguments", Justification = "OK.")]
[SuppressMessage("Performance", "CA1813:Avoid unsealed attributes", Justification = "OK.")]
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
public class StringAttribute : ValidationAttribute
{
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

    public bool Required { get; set; }

    public uint MinLength { get; set; }

    public uint MaxLength { get; set; }

    public char[] InvalidCharacters { get; set; }

    public string[] InvalidPrefixStrings { get; set; }

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

        var str = value.ToString();
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

    public static bool TryIsValid(
        string value,
        out string errorMessage)
    {
        var attribute = new StringAttribute();
        return TryIsValid(value, attribute, out errorMessage);
    }

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

        errorMessage = attribute.ErrorMessage
            .Replace("field {0}", "value", StringComparison.Ordinal)
            .Replace("{0} field", "value", StringComparison.Ordinal);

        return false;
    }
}