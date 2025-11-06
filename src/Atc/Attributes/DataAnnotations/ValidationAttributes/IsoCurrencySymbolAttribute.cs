// ReSharper disable InvertIf
// ReSharper disable LocalizableElement
// ReSharper disable once CheckNamespace
namespace System.ComponentModel.DataAnnotations;

/// <summary>
/// Validates that a property, field, or parameter contains a valid ISO 4217 currency code.
/// The value must be a three-character uppercase string (e.g., USD, EUR, GBP).
/// Optionally validates against a specific set of allowed currency codes.
/// </summary>
[ExcludeFromCodeCoverage]
[SuppressMessage("Performance", "CA1813:Avoid unsealed attributes", Justification = "OK.")]
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
public class IsoCurrencySymbolAttribute : ValidationAttribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="IsoCurrencySymbolAttribute"/> class with optional validation.
    /// </summary>
    public IsoCurrencySymbolAttribute()
        : base("The {0} field requires a ISO-Currency-Symbol value.")
    {
        Required = false;
        IsoCurrencySymbols = Array.Empty<string>();
    }

    /// <summary>
    /// Gets or sets a value indicating whether the currency code value is required.
    /// </summary>
    public bool Required { get; set; }

    /// <summary>
    /// Gets or sets an optional array of specific ISO currency codes that are allowed.
    /// If empty, all valid ISO currency codes from available cultures are accepted.
    /// </summary>
    public string[] IsoCurrencySymbols { get; set; }

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
        if (str!.Length != 3 ||
            !str.Equals(str.ToUpper(GlobalizationConstants.EnglishCultureInfo), StringComparison.Ordinal))
        {
            ErrorMessage = "The field {0} is not a valid ISO-Currency-Symbol, it should be in three upper-case letters.";
            return false;
        }

        if (IsoCurrencySymbols.Any())
        {
            if (!IsoCurrencySymbols.Any(x => str.Equals(x.ToUpper(GlobalizationConstants.EnglishCultureInfo), StringComparison.Ordinal)))
            {
                ErrorMessage = $"The field {{0}} do not match any: {string.Join(", ", IsoCurrencySymbols)}.";
                return false;
            }
        }
        else
        {
            var systemIsoCurrencySymbols = CultureHelper
                .GetCultures()
                .Select(x => x.IsoCurrencySymbol.ToUpper(GlobalizationConstants.EnglishCultureInfo))
                .OrderBy(x => x, StringComparer.Ordinal)
                .ToList();

            if (!systemIsoCurrencySymbols.Any(x => str.Equals(x, StringComparison.Ordinal)))
            {
                ErrorMessage = $"The field {{0}} do not match any: {string.Join(", ", systemIsoCurrencySymbols)}.";
                return false;
            }
        }

        return true;
    }
}