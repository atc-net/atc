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
        this.Required = false;
        this.MinLength = 1;
        this.MaxLength = 256;
        this.InvalidCharacters = Array.Empty<char>();
        this.InvalidPrefixStrings = Array.Empty<string>();
        this.RegularExpression = string.Empty;
    }

    public StringAttribute(
        bool required,
        uint minLength,
        uint maxLength)
        : this()
    {
        this.Required = required;
        this.MinLength = minLength;
        this.MaxLength = maxLength;
        this.InvalidCharacters = Array.Empty<char>();
        this.InvalidPrefixStrings = Array.Empty<string>();
        this.RegularExpression = string.Empty;
    }

    public StringAttribute(
        bool required,
        uint minLength,
        uint maxLength,
        char[] invalidCharacters,
        string[] invalidPrefixStrings)
        : this()
    {
        this.Required = required;
        this.MinLength = minLength;
        this.MaxLength = maxLength;
        this.InvalidCharacters = invalidCharacters;
        this.InvalidPrefixStrings = invalidPrefixStrings;
        this.RegularExpression = string.Empty;
    }

    public StringAttribute(
        bool required,
        uint minLength,
        uint maxLength,
        string regularExpression)
        : this()
    {
        this.Required = required;
        this.MinLength = minLength;
        this.MaxLength = maxLength;
        this.InvalidCharacters = Array.Empty<char>();
        this.InvalidPrefixStrings = Array.Empty<string>();
        this.RegularExpression = regularExpression;
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
        if (this.Required &&
            value is null)
        {
            this.ErrorMessage = "The {0} field is required.";
            return false;
        }

        if (value is null)
        {
            return true;
        }

        var str = value.ToString();
        if (str.Length < this.MinLength ||
            str.Length > this.MaxLength)
        {
            this.ErrorMessage = $"The field {{0}} must be between {this.MinLength} and {this.MaxLength}.";
            return false;
        }

        if (this.InvalidCharacters.Any() &&
            this.InvalidCharacters.Any(x => str.Contains(x, StringComparison.Ordinal)))
        {
            this.ErrorMessage = $"The field {{0}} cannot contain: {string.Join(", ", this.InvalidCharacters)}.";
            return false;
        }

        if (this.InvalidPrefixStrings.Any() &&
            this.InvalidPrefixStrings.Any(x => str.StartsWith(x.ToString(GlobalizationConstants.EnglishCultureInfo), StringComparison.Ordinal)))
        {
            this.ErrorMessage = $"The field {{0}} cannot start with: {string.Join(", ", this.InvalidPrefixStrings)}.";
            return false;
        }

        if (!string.IsNullOrEmpty(this.RegularExpression))
        {
            var regEx = new Regex(
                this.RegularExpression,
                RegexOptions.Singleline,
                TimeSpan.FromSeconds(2));

            var match = regEx.Match(str);
            if (!match.Success)
            {
                this.ErrorMessage = $"The field {{0}} do not match with: {this.RegularExpression}.";
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