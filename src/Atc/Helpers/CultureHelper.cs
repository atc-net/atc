// ReSharper disable CommentTypo
// ReSharper disable IdentifierTypo
// ReSharper disable ForeachCanBePartlyConvertedToQueryUsingAnotherGetEnumerator
// ReSharper disable ForeachCanBeConvertedToQueryUsingAnotherGetEnumerator
namespace Atc.Helpers;

/// <summary>
/// CultureHelper.
/// </summary>
[SuppressMessage("Design", "CA1002:Do not expose generic lists", Justification = "OK.")]
[SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1615:Element return value should be documented", Justification = "OK.")]
public static class CultureHelper
{
    private const string ResourceBaseName = "Atc";
    private static readonly object Lock = new();
    private static Dictionary<int, List<Culture>>? allCultures;
    private static ResourceManager? resourceManagerCountry;
    private static ResourceManager? resourceManagerLanguage;

    /// <summary>
    /// Gets cultures.
    /// </summary>
    public static List<Culture> GetCultures()
    {
        lock (Lock)
        {
            if (allCultures is not null && allCultures.TryGetValue(Thread.CurrentThread.CurrentUICulture.LCID, out var cultures))
            {
                return cultures;
            }

            allCultures ??= new Dictionary<int, List<Culture>>();

            allCultures[Thread.CurrentThread.CurrentUICulture.LCID] = new List<Culture>();
            var culturesFromPlatform = GetCultureInfoFromPlatform();
            foreach (var cultureInfo in culturesFromPlatform)
            {
                var regionInfo = new RegionInfo(cultureInfo.LCID);
                var culture = new Culture
                {
                    Lcid = cultureInfo.LCID,
                    Name = cultureInfo.Name,
                    CountryEnglishName = ExtractCountryEnglishName(cultureInfo),
                    CountryCodeA2 = regionInfo.TwoLetterISORegionName.ToUpperInvariant(),
                    CountryCodeA3 = regionInfo.ThreeLetterISORegionName.ToUpperInvariant(),
                    LanguageCodeA2 = cultureInfo.TwoLetterISOLanguageName.ToUpperInvariant(),
                    LanguageCodeA3 = cultureInfo.ThreeLetterISOLanguageName.ToUpperInvariant(),
                    LanguageEnglishName = ExtractLanguageEnglishName(cultureInfo),
                    CurrencySymbol = regionInfo.CurrencySymbol,
                    IsoCurrencySymbol = regionInfo.ISOCurrencySymbol,
                    NumberDecimalSeparator = cultureInfo.NumberFormat.NumberDecimalSeparator,
                    ShortDatePattern = cultureInfo.DateTimeFormat.ShortDatePattern,
                    LongTimePattern = cultureInfo.DateTimeFormat.LongTimePattern,
                };

                culture.CountryDisplayName = TryTranslateCountryEnglishName(culture.CountryEnglishName);
                culture.LanguageDisplayName = TryTranslateLanguageEnglishName(culture.LanguageEnglishName);

                if (!allCultures[Thread.CurrentThread.CurrentUICulture.LCID].Contains(culture))
                {
                    allCultures[Thread.CurrentThread.CurrentUICulture.LCID].Add(culture);
                }
            }

            return allCultures[Thread.CurrentThread.CurrentUICulture.LCID];
        }
    }

    /// <summary>
    /// Gets the cultures.
    /// </summary>
    /// <param name="includeOnlyLcids">The include only lcids.</param>
    public static List<Culture> GetCultures(
        List<int> includeOnlyLcids)
        => GetCultures(
            Thread.CurrentThread.CurrentUICulture.LCID,
            includeOnlyLcids);

    /// <summary>
    /// Gets the cultures.
    /// </summary>
    /// <param name="includeOnlyCultureNames">The include only culture names.</param>
    public static List<Culture> GetCultures(
        List<string> includeOnlyCultureNames)
        => GetCultures(
            Thread.CurrentThread.CurrentUICulture.LCID,
            includeOnlyCultureNames);

    /// <summary>
    /// Gets the cultures.
    /// </summary>
    /// <param name="displayLanguageLcid">The display language lcid.</param>
    public static List<Culture> GetCultures(
        int displayLanguageLcid)
        => GetCultures(
            displayLanguageLcid,
            new List<string>()).ToList();

    /// <summary>
    /// Gets the cultures.
    /// </summary>
    /// <param name="displayLanguageLcid">The display language lcid.</param>
    /// <param name="includeOnlyLcids">The include only lcids.</param>
    public static List<Culture> GetCultures(
        int displayLanguageLcid,
        List<int>? includeOnlyLcids)
    {
        if (includeOnlyLcids is null || includeOnlyLcids.Count == default)
        {
            return GetCultures(displayLanguageLcid, new List<string>());
        }

        var includeOnlyCultureNames = includeOnlyLcids.Select(lcid => new CultureInfo(lcid).Name).ToList();
        return GetCultures(displayLanguageLcid, includeOnlyCultureNames);
    }

    /// <summary>
    /// Gets the cultures.
    /// </summary>
    /// <param name="displayLanguageLcid">The display language lcid.</param>
    /// <param name="includeOnlyCultureNames">The include only culture names.</param>
    public static List<Culture> GetCultures(
        int displayLanguageLcid,
        List<string>? includeOnlyCultureNames)
    {
        CultureInfo? backupCultureInfo = null;
        if (Thread.CurrentThread.CurrentUICulture.LCID != displayLanguageLcid)
        {
            backupCultureInfo = Thread.CurrentThread.CurrentUICulture;
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(displayLanguageLcid);
        }

        var cultures = GetCultures();
        if (backupCultureInfo is not null)
        {
            Thread.CurrentThread.CurrentUICulture = backupCultureInfo;
        }

        var data = new List<Culture>();
        foreach (var culture in cultures)
        {
            if (includeOnlyCultureNames is null ||
                includeOnlyCultureNames.Count == 0 ||
                includeOnlyCultureNames.Contains(culture.Name, StringComparer.OrdinalIgnoreCase))
            {
                data.Add(culture);
            }
        }

        return data;
    }

    /// <summary>
    /// Gets the cultures for countries.
    /// </summary>
    public static List<Culture> GetCulturesForCountries()
    {
        var data = new List<Culture>
        {
            // Ensure en-US
            GetCultures(new List<int> { GlobalizationLcidConstants.UnitedStates })[0],
        };

        foreach (var culture in GetCultures().OrderBy(x => x.CountryDisplayName, StringComparer.Ordinal))
        {
            if (data.Find(x => string.Equals(x.CountryCodeA2, culture.CountryCodeA2, StringComparison.Ordinal)) is null)
            {
                data.Add(culture);
            }
        }

        return data
            .OrderBy(x => x.CountryDisplayName, StringComparer.Ordinal)
            .ToList();
    }

    /// <summary>
    /// Gets the cultures for languages.
    /// </summary>
    public static List<Culture> GetCulturesForLanguages()
    {
        var languageNames = GetLanguageNames();

        var data = new List<Culture>();
        foreach (var item in languageNames)
        {
            var culture = GetCultureByLcid(item.Key);
            if (culture is not null)
            {
                data.Add(culture);
            }
        }

        return data;
    }

    /// <summary>
    /// Gets the culture by lcid.
    /// </summary>
    /// <param name="lcid">The lcid.</param>
    public static Culture? GetCultureByLcid(
        int lcid)
        => GetCultures().SingleOrDefault(x => x.Lcid == lcid);

    /// <summary>
    /// Gets the culture by lcid.
    /// </summary>
    /// <param name="displayLanguageLcid">The display language lcid.</param>
    /// <param name="lcid">The lcid.</param>
    public static Culture? GetCultureByLcid(
        int displayLanguageLcid,
        int lcid)
    {
        var cultures = GetCultures(displayLanguageLcid, new List<int> { lcid });
        return cultures.Count == 1
            ? cultures[0]
            : null;
    }

    /// <summary>
    /// Gets the culture by country code a2.
    /// </summary>
    /// <param name="value">The value.</param>
    public static Culture? GetCultureByCountryCodeA2(
        string value)
        => GetCultureByCountryCodeA2(
            Thread.CurrentThread.CurrentUICulture.LCID,
            value);

    /// <summary>
    /// Gets the culture by country code a2.
    /// </summary>
    /// <param name="displayLanguageLcid">The display language lcid.</param>
    /// <param name="value">The value.</param>
    public static Culture? GetCultureByCountryCodeA2(
        int displayLanguageLcid,
        string value)
    {
        if (value is null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        if (value.Length != 2)
        {
            throw new ArgumentPropertyException(nameof(value), "Length should be 2 letters");
        }

        return GetCultureFromValue(displayLanguageLcid, value);
    }

    /// <summary>
    /// Gets the cultures by country code a2.
    /// </summary>
    /// <param name="value">The value.</param>
    public static List<Culture> GetCulturesByCountryCodeA2(
        string value)
        => GetCulturesByCountryCodeA2(
            Thread.CurrentThread.CurrentUICulture.LCID,
            value);

    /// <summary>
    /// Gets the cultures by country code a2.
    /// </summary>
    /// <param name="displayLanguageLcid">The display language lcid.</param>
    /// <param name="value">The value.</param>
    public static List<Culture> GetCulturesByCountryCodeA2(
        int displayLanguageLcid,
        string value)
    {
        if (displayLanguageLcid == 0)
        {
            throw new ArgumentOutOfRangeException(nameof(displayLanguageLcid));
        }

        if (value is null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        if (value.Length != 2)
        {
            throw new ArgumentPropertyException(nameof(value), "Length should be 2 letters");
        }

        var tmp = value.ToUpperInvariant();
        return GetCultures(displayLanguageLcid)
            .Where(x => x.CountryCodeA2.Equals(tmp, StringComparison.Ordinal))
            .ToList();
    }

    /// <summary>
    /// Gets the cultures by language code a2.
    /// </summary>
    /// <param name="value">The value.</param>
    public static List<Culture> GetCulturesByLanguageCodeA2(
        string value)
        => GetCulturesByLanguageCodeA2(
            Thread.CurrentThread.CurrentUICulture.LCID,
            value);

    /// <summary>
    /// Gets the cultures by language code a2.
    /// </summary>
    /// <param name="displayLanguageLcid">The display language lcid.</param>
    /// <param name="value">The value.</param>
    public static List<Culture> GetCulturesByLanguageCodeA2(
        int displayLanguageLcid,
        string value)
    {
        if (displayLanguageLcid == default)
        {
            throw new ArgumentOutOfRangeException(nameof(displayLanguageLcid));
        }

        if (value is null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        if (value.Length != 2)
        {
            throw new ArgumentPropertyException(nameof(value), "Length should be 2 letters");
        }

        var tmp = value.ToUpperInvariant();
        return GetCultures(displayLanguageLcid)
            .Where(x => x.LanguageCodeA2.Equals(tmp, StringComparison.Ordinal))
            .ToList();
    }

    /// <summary>
    /// Gets the culture from value.
    /// </summary>
    /// <param name="value">The value.</param>
    public static Culture? GetCultureFromValue(
        string value)
        => GetCultureFromValue(
            Thread.CurrentThread.CurrentUICulture.LCID,
            value);

    /// <summary>
    /// Gets the culture from value.
    /// </summary>
    /// <param name="displayLanguageLcid">The display language lcid.</param>
    /// <param name="value">The value.</param>
    public static Culture? GetCultureFromValue(
        int displayLanguageLcid,
        string value)
    {
        var list = GetCultures().Select(culture => culture.Lcid).ToList();
        return GetCultureFromValue(displayLanguageLcid, list, value);
    }

    /// <summary>
    /// Gets the culture from value.
    /// </summary>
    /// <param name="displayLanguageLcid">The display language lcid.</param>
    /// <param name="includeLcids">The include lcids.</param>
    /// <param name="value">The value.</param>
    [SuppressMessage("Design", "MA0051:Method is too long", Justification = "OK.")]
    [SuppressMessage("Critical Code Smell", "S3776:Cognitive Complexity of methods should not be too high", Justification = "OK.")]
    public static Culture? GetCultureFromValue(
        int displayLanguageLcid,
        List<int> includeLcids,
        string value)
    {
        if (displayLanguageLcid == default)
        {
            throw new ArgumentOutOfRangeException(nameof(displayLanguageLcid));
        }

        if (includeLcids is null)
        {
            throw new ArgumentNullException(nameof(includeLcids));
        }

        if (value is null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        if (!includeLcids.Contains(displayLanguageLcid))
        {
            throw new ArgumentPropertyException(nameof(displayLanguageLcid), $"Display language (LCID={displayLanguageLcid}) must be included in include-lcid-list of {includeLcids.Count} items.");
        }

        var cultures = GetCultures(displayLanguageLcid, includeLcids);
        Culture? culture;
        switch (value.Length)
        {
            case 2:
            {
                var tmp = value.ToUpperInvariant();
                if ("EN".Equals(tmp, StringComparison.Ordinal) ||
                    "US".Equals(tmp, StringComparison.Ordinal))
                {
                    culture = cultures.Find(x => x.Lcid == GlobalizationLcidConstants.UnitedStates);
                    if (culture is not null)
                    {
                        return culture;
                    }
                }
                else if ("GB".Equals(tmp, StringComparison.Ordinal))
                {
                    culture = cultures.Find(x => x.Lcid == GlobalizationLcidConstants.GreatBritain);
                    if (culture is not null)
                    {
                        return culture;
                    }
                }

                culture = cultures.Find(x => x.CountryCodeA2.Equals(tmp, StringComparison.Ordinal));
                if (culture is not null)
                {
                    return culture;
                }

                culture = cultures.Find(x => x.LanguageCodeA2.Equals(tmp, StringComparison.Ordinal));
                if (culture is not null)
                {
                    return culture;
                }

                break;
            }

            case 3:
            {
                var tmp = value.ToUpperInvariant();
                culture = cultures.Find(x => x.CountryCodeA3.Equals(tmp, StringComparison.Ordinal));
                if (culture is not null)
                {
                    return culture;
                }

                culture = cultures.Find(x => x.LanguageCodeA3.Equals(tmp, StringComparison.Ordinal));
                if (culture is not null)
                {
                    return culture;
                }

                break;
            }

            case 5 when value.Contains('-', StringComparison.Ordinal):
            {
                culture = cultures.Find(x => x.Name.Equals(value, StringComparison.OrdinalIgnoreCase));
                if (culture is not null)
                {
                    return culture;
                }

                break;
            }
        }

        if (value.IsDigitOnly())
        {
            culture = cultures.Find(x => x.Lcid == int.Parse(value, NumberStyles.Any, GlobalizationConstants.EnglishCultureInfo));
            if (culture is not null)
            {
                return culture;
            }
        }

        // Try exact match
        culture = cultures.Find(x => x.CountryDisplayName.Equals(value, StringComparison.OrdinalIgnoreCase));
        if (culture is not null)
        {
            return culture;
        }

        culture = cultures.Find(x => x.LanguageDisplayName.Equals(value, StringComparison.OrdinalIgnoreCase));
        if (culture is not null)
        {
            return culture;
        }

        if (displayLanguageLcid != GlobalizationLcidConstants.UnitedStates)
        {
            culture = cultures.Find(x => x.CountryEnglishName.Equals(value, StringComparison.OrdinalIgnoreCase));
            if (culture is not null)
            {
                return culture;
            }

            culture = cultures.Find(x => x.LanguageEnglishName.Equals(value, StringComparison.OrdinalIgnoreCase));
            if (culture is not null)
            {
                return culture;
            }
        }

        // Try start match
        culture = cultures.Find(x => x.CountryDisplayName.StartsWith(value, StringComparison.OrdinalIgnoreCase));
        if (culture is not null)
        {
            return culture;
        }

        culture = cultures.Find(x => x.LanguageDisplayName.StartsWith(value, StringComparison.OrdinalIgnoreCase));
        if (culture is not null)
        {
            return culture;
        }

        // ReSharper disable once InvertIf
        if (displayLanguageLcid != GlobalizationLcidConstants.UnitedStates)
        {
            culture = cultures.Find(x => x.CountryEnglishName.StartsWith(value, StringComparison.OrdinalIgnoreCase));
            if (culture is not null)
            {
                return culture;
            }

            culture = cultures.Find(x => x.LanguageEnglishName.StartsWith(value, StringComparison.OrdinalIgnoreCase));
            if (culture is not null)
            {
                return culture;
            }
        }

        return null;
    }

    /// <summary>
    /// Gets the country names.
    /// </summary>
    /// <param name="dropDownFirstItemType">Type of the drop down first item.</param>
    public static Dictionary<int, string> GetCountryNames(
        DropDownFirstItemType dropDownFirstItemType = DropDownFirstItemType.None)
        => GetCountryNames(
            Thread.CurrentThread.CurrentUICulture.LCID,
            new List<string>(),
            dropDownFirstItemType);

    /// <summary>
    /// Gets the country names.
    /// </summary>
    /// <param name="displayLanguageLcid">The display language lcid.</param>
    /// <param name="dropDownFirstItemType">Type of the drop down first item.</param>
    public static Dictionary<int, string> GetCountryNames(
        int displayLanguageLcid,
        DropDownFirstItemType dropDownFirstItemType = DropDownFirstItemType.None)
        => GetCountryNames(
            displayLanguageLcid,
            new List<string>(),
            dropDownFirstItemType);

    /// <summary>
    /// Gets the country names.
    /// </summary>
    /// <param name="includeOnlyLcids">The include only lcids.</param>
    /// <param name="dropDownFirstItemType">Type of the drop down first item.</param>
    public static Dictionary<int, string> GetCountryNames(
        List<int> includeOnlyLcids,
        DropDownFirstItemType dropDownFirstItemType = DropDownFirstItemType.None)
        => GetCountryNames(
            Thread.CurrentThread.CurrentUICulture.LCID,
            includeOnlyLcids,
            dropDownFirstItemType);

    /// <summary>
    /// Gets the country names.
    /// </summary>
    /// <param name="displayLanguageLcid">The display language lcid.</param>
    /// <param name="includeOnlyLcids">The include only lcids.</param>
    /// <param name="dropDownFirstItemType">Type of the drop down first item.</param>
    public static Dictionary<int, string> GetCountryNames(
        int displayLanguageLcid,
        List<int>? includeOnlyLcids,
        DropDownFirstItemType dropDownFirstItemType = DropDownFirstItemType.None)
    {
        if (includeOnlyLcids is null || includeOnlyLcids.Count == default)
        {
            return GetCountryNames(displayLanguageLcid, dropDownFirstItemType);
        }

        var includeOnlyCultureNames = includeOnlyLcids.Select(lcid => new CultureInfo(lcid).Name).ToList();
        return GetCountryNames(displayLanguageLcid, includeOnlyCultureNames, dropDownFirstItemType);
    }

    /// <summary>
    /// Gets the country names.
    /// </summary>
    /// <param name="includeOnlyCultureNames">The include only culture names.</param>
    /// <param name="dropDownFirstItemType">Type of the drop down first item.</param>
    public static Dictionary<int, string> GetCountryNames(
        List<string> includeOnlyCultureNames,
        DropDownFirstItemType dropDownFirstItemType = DropDownFirstItemType.None)
        => GetCountryNames(
            Thread.CurrentThread.CurrentUICulture.LCID,
            includeOnlyCultureNames,
            dropDownFirstItemType);

    /// <summary>
    /// Gets the country names.
    /// </summary>
    /// <param name="displayLanguageLcid">The display language lcid.</param>
    /// <param name="includeOnlyCultureNames">The include only culture names.</param>
    /// <param name="dropDownFirstItemType">Type of the drop down first item.</param>
    [SuppressMessage("Critical Code Smell", "S3776:Cognitive Complexity of methods should not be too high", Justification = "OK.")]
    public static Dictionary<int, string> GetCountryNames(
        int displayLanguageLcid,
        List<string> includeOnlyCultureNames,
        DropDownFirstItemType dropDownFirstItemType = DropDownFirstItemType.None)
    {
        CultureInfo? backupCultureInfo = null;
        if (Thread.CurrentThread.CurrentUICulture.LCID != displayLanguageLcid)
        {
            backupCultureInfo = Thread.CurrentThread.CurrentUICulture;
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(displayLanguageLcid);
        }

        var cultures = GetCultures();
        var data = DataFactory.CreateKeyValueDictionaryOfIntString(dropDownFirstItemType);
        if (backupCultureInfo is not null)
        {
            Thread.CurrentThread.CurrentUICulture = backupCultureInfo;
        }

        var countryDisplayNameCount = new Dictionary<string, int>(StringComparer.Ordinal);
        foreach (var culture in cultures)
        {
            if (includeOnlyCultureNames is not null && includeOnlyCultureNames.Count > 0 && !includeOnlyCultureNames.Contains(culture.Name, StringComparer.OrdinalIgnoreCase))
            {
                continue;
            }

            if (!countryDisplayNameCount.TryAdd(culture.CountryDisplayName, 1))
            {
                countryDisplayNameCount[culture.CountryDisplayName]++;
            }
        }

        foreach (var culture in cultures.OrderBy(x => x.CountryDisplayName, StringComparer.Ordinal))
        {
            if (data.ContainsKey(culture.Lcid))
            {
                continue;
            }

            if (includeOnlyCultureNames is not null &&
                includeOnlyCultureNames.Count != 0 &&
                !includeOnlyCultureNames.Contains(culture.Name, StringComparer.OrdinalIgnoreCase))
            {
                continue;
            }

            var text = countryDisplayNameCount[culture.CountryDisplayName] > 1
                ? $"{culture.CountryDisplayName} ({culture.LanguageDisplayName})"
                : culture.CountryDisplayName;
            data.Add(culture.Lcid, text);
        }

        return data;
    }

    /// <summary>
    /// Gets the language names.
    /// </summary>
    /// <param name="dropDownFirstItemType">Type of the drop down first item.</param>
    public static Dictionary<int, string> GetLanguageNames(
        DropDownFirstItemType dropDownFirstItemType = DropDownFirstItemType.None)
        => GetLanguageNames(
            Thread.CurrentThread.CurrentUICulture.LCID,
            new List<string>(),
            dropDownFirstItemType);

    /// <summary>
    /// Gets the language names.
    /// </summary>
    /// <param name="displayLanguageLcid">The display language lcid.</param>
    /// <param name="dropDownFirstItemType">Type of the drop down first item.</param>
    public static Dictionary<int, string> GetLanguageNames(
        int displayLanguageLcid,
        DropDownFirstItemType dropDownFirstItemType = DropDownFirstItemType.None)
        => GetLanguageNames(
            displayLanguageLcid,
            new List<string>(),
            dropDownFirstItemType);

    /// <summary>
    /// Gets the language names.
    /// </summary>
    /// <param name="includeOnlyLcids">The include only lcids.</param>
    /// <param name="dropDownFirstItemType">Type of the drop down first item.</param>
    public static Dictionary<int, string> GetLanguageNames(
        List<int> includeOnlyLcids,
        DropDownFirstItemType dropDownFirstItemType = DropDownFirstItemType.None)
        => GetLanguageNames(
            Thread.CurrentThread.CurrentUICulture.LCID,
            includeOnlyLcids,
            dropDownFirstItemType);

    /// <summary>
    /// Gets the language names.
    /// </summary>
    /// <param name="displayLanguageLcid">The display language lcid.</param>
    /// <param name="includeOnlyLcids">The include only lcids.</param>
    /// <param name="dropDownFirstItemType">Type of the drop down first item.</param>
    public static Dictionary<int, string> GetLanguageNames(
        int displayLanguageLcid,
        List<int>? includeOnlyLcids,
        DropDownFirstItemType dropDownFirstItemType = DropDownFirstItemType.None)
    {
        if (includeOnlyLcids is null || includeOnlyLcids.Count == default)
        {
            return GetLanguageNames(displayLanguageLcid, dropDownFirstItemType);
        }

        var includeOnlyCultureNames = includeOnlyLcids.Select(lcid => new CultureInfo(lcid).Name).ToList();
        return GetLanguageNames(displayLanguageLcid, includeOnlyCultureNames, dropDownFirstItemType);
    }

    /// <summary>
    /// Gets the language names.
    /// </summary>
    /// <param name="includeOnlyCultureNames">The include only culture names.</param>
    /// <param name="dropDownFirstItemType">Type of the drop down first item.</param>
    public static Dictionary<int, string> GetLanguageNames(
        List<string> includeOnlyCultureNames,
        DropDownFirstItemType dropDownFirstItemType = DropDownFirstItemType.None)
        => GetLanguageNames(
            Thread.CurrentThread.CurrentUICulture.LCID,
            includeOnlyCultureNames,
            dropDownFirstItemType);

    /// <summary>
    /// Gets the language names.
    /// </summary>
    /// <param name="displayLanguageLcid">The display language lcid.</param>
    /// <param name="includeOnlyCultureNames">The include only culture names.</param>
    /// <param name="dropDownFirstItemType">Type of the drop down first item.</param>
    [SuppressMessage("Critical Code Smell", "S3776:Cognitive Complexity of methods should not be too high", Justification = "OK.")]
    public static Dictionary<int, string> GetLanguageNames(
        int displayLanguageLcid,
        List<string> includeOnlyCultureNames,
        DropDownFirstItemType dropDownFirstItemType = DropDownFirstItemType.None)
    {
        CultureInfo? backupCultureInfo = null;
        if (Thread.CurrentThread.CurrentUICulture.LCID != displayLanguageLcid)
        {
            backupCultureInfo = Thread.CurrentThread.CurrentUICulture;
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(displayLanguageLcid);
        }

        var cultures = GetCultures();
        var data = DataFactory.CreateKeyValueDictionaryOfIntString(dropDownFirstItemType);
        if (backupCultureInfo is not null)
        {
            Thread.CurrentThread.CurrentUICulture = backupCultureInfo;
        }

        var languageDisplayNameCount = new Dictionary<string, int>(StringComparer.Ordinal);
        foreach (var culture in cultures)
        {
            if (includeOnlyCultureNames is not null && includeOnlyCultureNames.Count > 0 && !includeOnlyCultureNames.Contains(culture.Name, StringComparer.OrdinalIgnoreCase))
            {
                continue;
            }

            if (!languageDisplayNameCount.TryAdd(culture.LanguageDisplayName, 1))
            {
                languageDisplayNameCount[culture.LanguageDisplayName]++;
            }
        }

        foreach (var culture in cultures.OrderBy(x => x.LanguageDisplayName, StringComparer.Ordinal))
        {
            if (data.ContainsKey(culture.Lcid))
            {
                continue;
            }

            if (includeOnlyCultureNames is not null &&
                includeOnlyCultureNames.Count != 0 &&
                !includeOnlyCultureNames.Contains(culture.Name, StringComparer.OrdinalIgnoreCase))
            {
                continue;
            }

            var text = languageDisplayNameCount[culture.LanguageDisplayName] > 1
                ? $"{culture.LanguageDisplayName} ({culture.CountryDisplayName})"
                : culture.LanguageDisplayName;
            data.Add(culture.Lcid, text);
        }

        return data;
    }

    /// <summary>
    /// Gets the culture lcids where country is not translated.
    /// </summary>
    /// <param name="displayLanguageLcid">The display language lcid.</param>
    /// <param name="includeOnlyLcids">The include only lcids.</param>
    public static List<int> GetCultureLcidsWhereCountryIsNotTranslated(
        int displayLanguageLcid,
        List<int>? includeOnlyLcids)
    {
        CultureInfo? backupCultureInfo = null;
        if (Thread.CurrentThread.CurrentUICulture.LCID != displayLanguageLcid)
        {
            backupCultureInfo = Thread.CurrentThread.CurrentUICulture;
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(displayLanguageLcid);
        }

        var culturesFromPlatform = GetCultureInfoFromPlatform();
        var data = (
                from cultureInfo
                    in culturesFromPlatform
                let countryEnglishName = ExtractCountryEnglishName(cultureInfo)
                let countryDisplayName = TryTranslateCountryEnglishName(countryEnglishName, useValueAsDefault: false)
                where countryDisplayName is null
                select cultureInfo.LCID)
            .ToList();

        if (backupCultureInfo is not null)
        {
            Thread.CurrentThread.CurrentUICulture = backupCultureInfo;
        }

        if (includeOnlyLcids is null || includeOnlyLcids.Count <= 0)
        {
            return data;
        }

        return includeOnlyLcids.Where(lcid => data.Contains(lcid)).ToList();
    }

    /// <summary>
    /// Gets the culture lcids where language is not translated.
    /// </summary>
    /// <param name="displayLanguageLcid">The display language lcid.</param>
    /// <param name="includeOnlyLcids">The include only lcids.</param>
    public static List<int> GetCultureLcidsWhereLanguageIsNotTranslated(
        int displayLanguageLcid,
        List<int>? includeOnlyLcids)
    {
        CultureInfo? backupCultureInfo = null;
        if (Thread.CurrentThread.CurrentUICulture.LCID != displayLanguageLcid)
        {
            backupCultureInfo = Thread.CurrentThread.CurrentUICulture;
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(displayLanguageLcid);
        }

        var culturesFromPlatform = GetCultureInfoFromPlatform();
        var data = (
                from cultureInfo
                    in culturesFromPlatform
                let languageEnglishName = ExtractLanguageEnglishName(cultureInfo)
                let languageDisplayName = TryTranslateLanguageEnglishName(languageEnglishName, useValueAsDefault: false)
                where languageDisplayName is null
                select cultureInfo.LCID)
            .ToList();

        if (backupCultureInfo is not null)
        {
            Thread.CurrentThread.CurrentUICulture = backupCultureInfo;
        }

        if (includeOnlyLcids is null || includeOnlyLcids.Count <= 0)
        {
            return data;
        }

        return includeOnlyLcids
            .Where(lcid => data.Contains(lcid))
            .ToList();
    }

    public static IList<Culture> GetSupportedCultures(
        int displayLanguageLcid = GlobalizationLcidConstants.UnitedStates)
    {
        var lcids = new List<int>
        {
            GlobalizationLcidConstants.Denmark,
            GlobalizationLcidConstants.Germany,
            GlobalizationLcidConstants.UnitedStates,
            GlobalizationLcidConstants.GreatBritain,
        };

        var cultures = new List<Culture>();
        foreach (var lcid in lcids)
        {
            var culture = GetCultureByLcid(displayLanguageLcid, lcid);
            if (culture is not null)
            {
                cultures.Add(culture);
            }
        }

        return cultures;
    }

    private static IEnumerable<CultureInfo> GetCultureInfoFromPlatform()
    {
        var data = new List<CultureInfo>();
        var cultureInfos = CultureInfo.GetCultures(CultureTypes.SpecificCultures);

        // ReSharper disable once LoopCanBeConvertedToQuery
        foreach (var cultureInfo in cultureInfos)
        {
            // ReSharper disable once ConvertIfStatementToSwitchStatement
            if (cultureInfo.LCID == 4096 || cultureInfo.LCID == 8192)
            {
                // Not a supported culture's in .NET
                continue;
            }

            if (cultureInfo.LCID == 1085)
            {
                // Yiddish is not a real language
                continue;
            }

            if (cultureInfo.LCID == 1142)
            {
                // Latin is not a real language
                continue;
            }

            if (cultureInfo.LCID == 1145 || cultureInfo.LCID == 7010 || cultureInfo.LCID == 7180 || cultureInfo.LCID == 9225 || cultureInfo.LCID == 22538)
            {
                // Languages with a 3char-number for countryCodeA2
                continue;
            }

            data.Add(cultureInfo);
        }

        return data;
    }

    private static string ExtractCountryEnglishName(
        CultureInfo cultureInfo)
    {
        var x = cultureInfo.EnglishName.IndexOf('(', StringComparison.Ordinal);
        return x == -1
            ? cultureInfo.EnglishName
            : cultureInfo.EnglishName[(x + 1)..].Replace(")", string.Empty, StringComparison.Ordinal);
    }

    private static string ExtractLanguageEnglishName(
        CultureInfo cultureInfo)
    {
        var x = cultureInfo.EnglishName.IndexOf('(', StringComparison.Ordinal);
        return x == -1
            ? cultureInfo.EnglishName
            : cultureInfo.EnglishName[..(x - 1)];
    }

    [SuppressMessage("Globalization", "CA1304:Specify CultureInfo", Justification = "OK.")]
    [SuppressMessage("Usage", "MA0011:IFormatProvider is missing", Justification = "OK.")]
    private static string TryTranslateCountryEnglishName(
        string value,
        bool useValueAsDefault = true)
    {
        if (value is null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        resourceManagerCountry ??= GetResourceManagerForResource("Country");

        var result = resourceManagerCountry.GetString(value.Replace(" ", string.Empty, StringComparison.Ordinal));
        if (useValueAsDefault)
        {
            return result ?? value;
        }

        return result ?? string.Empty;
    }

    [SuppressMessage("Globalization", "CA1304:Specify CultureInfo", Justification = "OK.")]
    [SuppressMessage("Usage", "MA0011:IFormatProvider is missing", Justification = "OK.")]
    private static string TryTranslateLanguageEnglishName(
        string value,
        bool useValueAsDefault = true)
    {
        resourceManagerLanguage ??= GetResourceManagerForResource("Language");

        var result = resourceManagerLanguage.GetString(value);
        if (useValueAsDefault)
        {
            return result ?? value;
        }

        return result ?? string.Empty;
    }

    private static ResourceManager GetResourceManagerForResource(
        string resource)
    {
        var assembly = AppDomain.CurrentDomain
            .GetAssemblies()
            .Single(x => x.FullName.StartsWith(ResourceBaseName + ", Version", StringComparison.Ordinal));
        return new ResourceManager($"{ResourceBaseName}.Resources.{resource}", assembly);
    }
}