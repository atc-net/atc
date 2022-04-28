// ReSharper disable InvertIf
// ReSharper disable LocalizableElement
// ReSharper disable once CheckNamespace
namespace System.ComponentModel.DataAnnotations;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
public sealed class StringAttribute : ValidationAttribute
{
    public StringAttribute()
        : base("The {0} field requires a Name value.")
    {
        this.Required = false;
        this.MinLength = 1;
        this.MaxLength = 256;
        this.InvalidCharacters = new[] { ' ', '.', '@', '\'' };
        this.InvalidPrefixStrings = new[] { "_" };
    }

    public bool Required { get; set; }

    public int MinLength { get; set; }

    public int MaxLength { get; set; }

    public char[] InvalidCharacters { get; set; }

    public string[] InvalidPrefixStrings { get; set; }

    public override bool IsValid(object? value)
    {
        if (this.Required && value is null)
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
            this.ErrorMessage = "The field {0} must be between 1 and 256.";
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

        return true;
    }
}