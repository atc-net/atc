namespace Atc.Data.Models;

/// <summary>
/// Culture.
/// </summary>
[Serializable]
public class Culture
{
    public Culture()
    {
        Lcid = 0;
        Name = string.Empty;
        CountryEnglishName = string.Empty;
        CountryDisplayName = string.Empty;
        CountryCodeA2 = string.Empty;
        CountryCodeA3 = string.Empty;
        LanguageEnglishName = string.Empty;
        LanguageDisplayName = string.Empty;
        LanguageCodeA3 = string.Empty;
        LanguageCodeA2 = string.Empty;
        CurrencySymbol = string.Empty;
        IsoCurrencySymbol = string.Empty;
        NumberDecimalSeparator = string.Empty;
        ShortDatePattern = string.Empty;
        LongTimePattern = string.Empty;
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
        string isoCurrencySymbol,
        string numberDecimalSeparator,
        string shortDatePattern,
        string longTimePattern)
    {
        Lcid = lcid;
        Name = name;
        CountryEnglishName = countryEnglishName;
        CountryDisplayName = countryDisplayName;
        CountryCodeA2 = countryCodeA2;
        CountryCodeA3 = countryCodeA3;
        LanguageEnglishName = languageEnglishName;
        LanguageDisplayName = languageDisplayName;
        LanguageCodeA3 = languageCodeA3;
        LanguageCodeA2 = languageCodeA2;
        CurrencySymbol = currencySymbol;
        IsoCurrencySymbol = isoCurrencySymbol;
        NumberDecimalSeparator = numberDecimalSeparator;
        ShortDatePattern = shortDatePattern;
        LongTimePattern = longTimePattern;
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
    /// Gets or sets the ISO currency symbol.
    /// </summary>
    /// <value>
    /// The currency symbol.
    /// </value>
    public string IsoCurrencySymbol { get; set; }

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
        return $"{nameof(Lcid)}: {Lcid}, {nameof(Name)}: {Name}, {nameof(CountryEnglishName)}: {CountryEnglishName}, {nameof(CountryDisplayName)}: {CountryDisplayName}, {nameof(CountryCodeA2)}: {CountryCodeA2}, {nameof(CountryCodeA3)}: {CountryCodeA3}, {nameof(LanguageEnglishName)}: {LanguageEnglishName}, {nameof(LanguageDisplayName)}: {LanguageDisplayName}, {nameof(LanguageCodeA3)}: {LanguageCodeA3}, {nameof(LanguageCodeA2)}: {LanguageCodeA2}, {nameof(CurrencySymbol)}: {CurrencySymbol}, {nameof(IsoCurrencySymbol)}: {IsoCurrencySymbol}, {nameof(NumberDecimalSeparator)}: {NumberDecimalSeparator}, {nameof(ShortDatePattern)}: {ShortDatePattern}, {nameof(LongTimePattern)}: {LongTimePattern}";
    }
}