namespace Atc.Data.Models;

/// <summary>
/// Culture.
/// </summary>
[Serializable]
public class Culture
{
    public Culture()
    {
        this.Lcid = 0;
        this.Name = string.Empty;
        this.CountryEnglishName = string.Empty;
        this.CountryDisplayName = string.Empty;
        this.CountryCodeA2 = string.Empty;
        this.CountryCodeA3 = string.Empty;
        this.LanguageEnglishName = string.Empty;
        this.LanguageDisplayName = string.Empty;
        this.LanguageCodeA3 = string.Empty;
        this.LanguageCodeA2 = string.Empty;
        this.CurrencySymbol = string.Empty;
        this.NumberDecimalSeparator = string.Empty;
        this.ShortDatePattern = string.Empty;
        this.LongTimePattern = string.Empty;
    }

    [SuppressMessage("Major Code Smell", "S107:Methods should not have too many parameters", Justification = "OK.")]
    public Culture(
        int lcid,
        string name,
        string countryEnglishName,
        string countryDisplayName,
        string countryCodeA2,
        string countryCodeA3,
        string languageEnglishName,
        string languageDisplayName,
        string languageCodeA3,
        string languageCodeA2,
        string currencySymbol,
        string numberDecimalSeparator,
        string shortDatePattern,
        string longTimePattern)
    {
        this.Lcid = lcid;
        this.Name = name;
        this.CountryEnglishName = countryEnglishName;
        this.CountryDisplayName = countryDisplayName;
        this.CountryCodeA2 = countryCodeA2;
        this.CountryCodeA3 = countryCodeA3;
        this.LanguageEnglishName = languageEnglishName;
        this.LanguageDisplayName = languageDisplayName;
        this.LanguageCodeA3 = languageCodeA3;
        this.LanguageCodeA2 = languageCodeA2;
        this.CurrencySymbol = currencySymbol;
        this.NumberDecimalSeparator = numberDecimalSeparator;
        this.ShortDatePattern = shortDatePattern;
        this.LongTimePattern = longTimePattern;
    }

    /// <summary>
    /// Gets or sets the lcid.
    /// </summary>
    /// <value>
    /// The lcid.
    /// </value>
    public int Lcid { get; set; }

    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    /// <value>
    /// The name.
    /// </value>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the name of the country english.
    /// </summary>
    /// <value>
    /// The name of the country english.
    /// </value>
    public string CountryEnglishName { get; set; }

    /// <summary>
    /// Gets or sets the display name of the country.
    /// </summary>
    /// <value>
    /// The display name of the country.
    /// </value>
    public string CountryDisplayName { get; set; }

    /// <summary>
    /// Gets or sets the country code a2.
    /// </summary>
    /// <value>
    /// The country code a2.
    /// </value>
    public string CountryCodeA2 { get; set; }

    /// <summary>
    /// Gets or sets the country code a3.
    /// </summary>
    /// <value>
    /// The country code a3.
    /// </value>
    public string CountryCodeA3 { get; set; }

    /// <summary>
    /// Gets or sets the name of the language english.
    /// </summary>
    /// <value>
    /// The name of the language english.
    /// </value>
    public string LanguageEnglishName { get; set; }

    /// <summary>
    /// Gets or sets the display name of the language.
    /// </summary>
    /// <value>
    /// The display name of the language.
    /// </value>
    public string LanguageDisplayName { get; set; }

    /// <summary>
    /// Gets or sets the language code a3.
    /// </summary>
    /// <value>
    /// The language code a3.
    /// </value>
    public string LanguageCodeA3 { get; set; }

    /// <summary>
    /// Gets or sets the language code a2.
    /// </summary>
    /// <value>
    /// The language code a2.
    /// </value>
    public string LanguageCodeA2 { get; set; }

    /// <summary>
    /// Gets or sets the currency symbol.
    /// </summary>
    /// <value>
    /// The currency symbol.
    /// </value>
    public string CurrencySymbol { get; set; }

    /// <summary>
    /// Gets or sets the number decimal separator.
    /// </summary>
    /// <value>
    /// The number decimal separator.
    /// </value>
    public string NumberDecimalSeparator { get; set; }

    /// <summary>
    /// Gets or sets the short date pattern.
    /// </summary>
    /// <value>
    /// The short date pattern.
    /// </value>
    public string ShortDatePattern { get; set; }

    /// <summary>
    /// Gets or sets the long time pattern.
    /// </summary>
    /// <value>
    /// The long time pattern.
    /// </value>
    public string LongTimePattern { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return $"{nameof(this.Lcid)}: {this.Lcid}, {nameof(this.Name)}: {this.Name}, {nameof(this.CountryEnglishName)}: {this.CountryEnglishName}, {nameof(this.CountryDisplayName)}: {this.CountryDisplayName}, {nameof(this.CountryCodeA2)}: {this.CountryCodeA2}, {nameof(this.CountryCodeA3)}: {this.CountryCodeA3}, {nameof(this.LanguageEnglishName)}: {this.LanguageEnglishName}, {nameof(this.LanguageDisplayName)}: {this.LanguageDisplayName}, {nameof(this.LanguageCodeA3)}: {this.LanguageCodeA3}, {nameof(this.LanguageCodeA2)}: {this.LanguageCodeA2}, {nameof(this.CurrencySymbol)}: {this.CurrencySymbol}, {nameof(this.NumberDecimalSeparator)}: {this.NumberDecimalSeparator}, {nameof(this.ShortDatePattern)}: {this.ShortDatePattern}, {nameof(this.LongTimePattern)}: {this.LongTimePattern}";
    }
}