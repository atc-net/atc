namespace Atc.XUnit;

public static class AssemblyLocalizationResourcesHelper
{
    private static readonly Lazy<Regex> ArgIndexCaptureRegex = new(() => new Regex(@"\{(\d+)", RegexOptions.Multiline, TimeSpan.FromMilliseconds(10)));

    public static Dictionary<string, Dictionary<string, List<string>>> CollectMissingTranslations(
        Assembly assembly,
        IList<string> cultureNames)
    {
        var resourceManagers = assembly.GetResourceManagers();

        var cultures = CultureInfoHelper.GetCulturesFromNames(cultureNames);

        var result = new Dictionary<string, Dictionary<string, List<string>>>(StringComparer.Ordinal);
        foreach (var resourceManager in resourceManagers)
        {
            result.Add(
                resourceManager.BaseName,
                CollectMissingTranslationsForResourceManager(
                    resourceManager,
                    cultures));
        }

        return result;
    }

    public static Dictionary<string, Dictionary<string, List<string>>> CollectInvalidKeySuffixWithPlaceholders(
        Assembly assembly,
        IList<string> cultureNames,
        IList<string>? allowSuffixTerms = null)
    {
        var resourceManagers = assembly.GetResourceManagers();

        var cultures = CultureInfoHelper.GetCulturesFromNames(cultureNames);

        var result = new Dictionary<string, Dictionary<string, List<string>>>(StringComparer.Ordinal);
        foreach (var resourceManager in resourceManagers)
        {
            result.Add(
                resourceManager.BaseName,
                CollectInvalidKeySuffixWithPlaceholdersForResourceManager(
                    resourceManager,
                    cultures,
                    allowSuffixTerms));
        }

        return result;
    }

    [SuppressMessage("Design", "MA0051:Method is too long", Justification = "OK.")]
    public static bool ValidateKeySuffixWithPlaceholders(
        string key,
        string value,
        IList<string>? allowSuffixTerms = null)
    {
        if (key is null)
        {
            throw new ArgumentNullException(nameof(key));
        }

        if (value is null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        var suffix = string.Empty;
        for (var i = key.Length - 1; i >= 0; i--)
        {
            if (char.IsDigit(key[i]))
            {
                suffix = key[i] + suffix;
            }
            else
            {
                break;
            }
        }

        if (string.IsNullOrEmpty(suffix) &&
            value.Contains('{', StringComparison.Ordinal) &&
            value.Contains('}', StringComparison.Ordinal))
        {
            return false;
        }

        if (allowSuffixTerms is not null &&
            allowSuffixTerms.Any(allowSuffixTerm => key.EndsWith(allowSuffixTerm + suffix, StringComparison.Ordinal)))
        {
            return true;
        }

        var maxIndex = -1;
        var formatArgsIndex = ArgIndexCaptureRegex.Value
            .Matches(value)
            .Select(x => x.Groups[1].Value)
            .ToList();

        foreach (var indexString in formatArgsIndex)
        {
            if (NumberHelper.TryParseToInt(indexString, out var index))
            {
                maxIndex = System.Math.Max(maxIndex, index);
            }
            else
            {
                return false;
            }
        }

        if (string.IsNullOrEmpty(suffix))
        {
            return maxIndex == -1;
        }

        return int.TryParse(
            suffix,
            NumberStyles.Any,
            GlobalizationConstants.EnglishCultureInfo,
            out var numericSuffix) && numericSuffix == maxIndex + 1;
    }

    private static List<string> GetMissingKeysInDefault(
        HashSet<string> allKnownKeys,
        List<DictionaryEntry> defaultDictionaryEntries)
    {
        var missingKeysInDefault = new List<string>();
        foreach (var key in allKnownKeys)
        {
            var dictionaryEntry = defaultDictionaryEntries.Find(x => (string)x.Key == key);
            if (string.IsNullOrEmpty((string)dictionaryEntry.Value!))
            {
                missingKeysInDefault.Add(key);
            }
        }

        return missingKeysInDefault;
    }

    private static List<string> GetInvalidKeySuffixWithPlaceholdersInDefault(
        HashSet<string> allKnownKeys,
        List<DictionaryEntry> defaultDictionaryEntries,
        IList<string>? allowSuffixTerms = null)
    {
        var invalidKeysInDefault = new List<string>();
        foreach (var key in allKnownKeys)
        {
            var dictionaryEntry = defaultDictionaryEntries.Find(x => (string)x.Key == key);
            if (!ValidateKeySuffixWithPlaceholders(
                    (string)dictionaryEntry.Key,
                    dictionaryEntry.Value?.ToString() ?? string.Empty,
                    allowSuffixTerms))
            {
                invalidKeysInDefault.Add(key);
            }
        }

        return invalidKeysInDefault;
    }

    private static Dictionary<string, List<string>> CollectMissingTranslationsForResourceManagerSet(
        ResourceManager resourceManager,
        IList<CultureInfo> cultures,
        ResourceSet resourceSet)
    {
        var result = new Dictionary<string, List<string>>(StringComparer.Ordinal);
        foreach (DictionaryEntry entry in resourceSet)
        {
            if (entry.Key is not string key)
            {
                continue;
            }

            foreach (var culture in cultures)
            {
                var resourceSetForCulture = resourceManager.GetResourceSet(
                    culture,
                    createIfNotExists: true,
                    tryParents: false);

                if (resourceSetForCulture is null)
                {
                    continue;
                }

                var translatedValue = resourceSetForCulture.GetString(key);
                if (translatedValue is not null)
                {
                    continue;
                }

                if (!result.ContainsKey(culture.Name))
                {
                    result.Add(culture.Name, new List<string>());
                }

                result[culture.Name].Add(key);
            }
        }

        return result;
    }

    private static Dictionary<string, List<string>> CollectInvalidKeySuffixWithPlaceholdersForResourceManagerSet(
        ResourceManager resourceManager,
        IList<CultureInfo> cultures,
        ResourceSet resourceSet,
        IList<string>? allowSuffixTerms = null)
    {
        var result = new Dictionary<string, List<string>>(StringComparer.Ordinal);
        foreach (DictionaryEntry entry in resourceSet)
        {
            if (entry.Key is not string key)
            {
                continue;
            }

            if (entry.Value is not string neutralValue)
            {
                continue;
            }

            foreach (var culture in cultures)
            {
                var translatedValue = resourceManager.GetString(key, culture);

                if (string.IsNullOrEmpty(translatedValue) ||
                    translatedValue == neutralValue)
                {
                    continue;
                }

                if (ValidateKeySuffixWithPlaceholders(
                        key,
                        translatedValue,
                        allowSuffixTerms))
                {
                    continue;
                }

                if (!result.ContainsKey(culture.Name))
                {
                    result.Add(culture.Name, new List<string>());
                }

                result[culture.Name].Add(key);
            }
        }

        return result;
    }

    private static Dictionary<string, List<string>> CollectMissingTranslationsForResourceManager(
        ResourceManager resourceManager,
        IList<CultureInfo> cultures)
    {
        var resourceSet = resourceManager.GetResourceSet(
            CultureInfo.InvariantCulture,
            createIfNotExists: true,
            tryParents: true)!;

        var defaultDictionaryEntries = resourceSet
            .Cast<DictionaryEntry>()
            .ToList();

        var allKnownKeys = defaultDictionaryEntries
            .Select(entry => (string)entry.Key)
            .ToHashSet(StringComparer.Ordinal);

        var missingKeysInDefault = GetMissingKeysInDefault(
            allKnownKeys,
            defaultDictionaryEntries);

        var result = new Dictionary<string, List<string>>(StringComparer.Ordinal);

        if (missingKeysInDefault.Count > 0)
        {
            result.Add("Default", missingKeysInDefault);
        }

        var resultForTranslations = CollectMissingTranslationsForResourceManagerSet(
            resourceManager,
            cultures,
            resourceSet);

        foreach (var item in resultForTranslations)
        {
            result.Add(item.Key, item.Value);
        }

        return result;
    }

    private static Dictionary<string, List<string>> CollectInvalidKeySuffixWithPlaceholdersForResourceManager(
        ResourceManager resourceManager,
        IList<CultureInfo> cultures,
        IList<string>? allowSuffixTerms = null)
    {
        var resourceSet = resourceManager.GetResourceSet(
            CultureInfo.InvariantCulture,
            createIfNotExists: true,
            tryParents: true)!;

        var defaultDictionaryEntries = resourceSet
            .Cast<DictionaryEntry>()
            .ToList();

        var allKnownKeys = defaultDictionaryEntries
            .Select(entry => (string)entry.Key)
            .ToHashSet(StringComparer.Ordinal);

        var invalidKeysInDefault = GetInvalidKeySuffixWithPlaceholdersInDefault(
            allKnownKeys,
            defaultDictionaryEntries,
            allowSuffixTerms);

        var result = new Dictionary<string, List<string>>(StringComparer.Ordinal);

        if (invalidKeysInDefault.Count > 0)
        {
            result.Add("Default", invalidKeysInDefault);
        }

        var resultForTranslations = CollectInvalidKeySuffixWithPlaceholdersForResourceManagerSet(
            resourceManager,
            cultures,
            resourceSet,
            allowSuffixTerms);

        foreach (var item in resultForTranslations)
        {
            result.Add(item.Key, item.Value);
        }

        return result;
    }
}