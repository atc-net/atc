// ReSharper disable LoopCanBeConvertedToQuery
// ReSharper disable ForeachCanBeConvertedToQueryUsingAnotherGetEnumerator
namespace Atc.XUnit.Internal;

internal static class AssemblyLocalizationResourcesHelper
{
    public static Dictionary<string, Dictionary<string, List<string>>> CollectMissingTranslations(
        Assembly assembly,
        IList<string> cultureNames)
    {
        var result = new Dictionary<string, Dictionary<string, List<string>>>(StringComparer.Ordinal);
        var resourceManagers = GetResourceManagersFromAssembly(assembly);
        foreach (var resourceManager in resourceManagers.OrderBy(x => x.BaseName, StringComparer.Ordinal))
        {
            result.Add(
                resourceManager.BaseName,
                CollectMissingTranslationsForResourceManager(
                    resourceManager,
                    cultureNames));
        }

        return result;
    }

    public static Dictionary<string, Dictionary<string, List<string>>> CollectInvalidKeySuffixWithPlaceholders(
        Assembly assembly,
        IList<string> cultureNames,
        IList<string>? allowSuffixTerms = null)
    {
        var result = new Dictionary<string, Dictionary<string, List<string>>>(StringComparer.Ordinal);
        var resourceManagers = GetResourceManagersFromAssembly(assembly);
        foreach (var resourceManager in resourceManagers.OrderBy(x => x.BaseName, StringComparer.Ordinal))
        {
            result.Add(
                resourceManager.BaseName,
                CollectInvalidKeySuffixWithPlaceholdersForResourceManager(
                    resourceManager,
                    cultureNames,
                    allowSuffixTerms));
        }

        return result;
    }

    private static IEnumerable<ResourceManager> GetResourceManagersFromAssembly(
        Assembly assembly)
    {
        var resourceTypes = assembly.GetTypes();
        var resourceManagers = new List<ResourceManager>();

        foreach (var type in resourceTypes)
        {
            var property = type.GetProperty("ResourceManager", BindingFlags.Public | BindingFlags.Static);
            if (property is null ||
                property.PropertyType != typeof(ResourceManager))
            {
                continue;
            }

            var resourceManager = (ResourceManager)property.GetValue(null)!;
            resourceManagers.Add(resourceManager);
        }

        return resourceManagers;
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
                    (string)dictionaryEntry.Value,
                    allowSuffixTerms))
            {
                invalidKeysInDefault.Add(key);
            }
        }

        return invalidKeysInDefault;
    }

    private static Dictionary<string, List<string>> CollectMissingTranslationsForResourceManagerSet(
        ResourceManager resourceManager,
        IList<string> cultureNames,
        ResourceSet resourceSet)
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

            foreach (var cultureName in cultureNames)
            {
                var cultureInfo = new CultureInfo(cultureName);
                var translatedValue = resourceManager.GetString(key, cultureInfo);

                if (!string.IsNullOrEmpty(translatedValue) &&
                    translatedValue != neutralValue)
                {
                    continue;
                }

                if (!result.ContainsKey(cultureName))
                {
                    result.Add(cultureName, new List<string>());
                }

                result[cultureName].Add(key);
            }
        }

        return result;
    }

    private static Dictionary<string, List<string>> CollectInvalidKeySuffixWithPlaceholdersForResourceManagerSet(
        ResourceManager resourceManager,
        IList<string> cultureNames,
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

            foreach (var cultureName in cultureNames)
            {
                var cultureInfo = new CultureInfo(cultureName);
                var translatedValue = resourceManager.GetString(key, cultureInfo);

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

                if (!result.ContainsKey(cultureName))
                {
                    result.Add(cultureName, new List<string>());
                }

                result[cultureName].Add(key);
            }
        }

        return result;
    }

    private static Dictionary<string, List<string>> CollectMissingTranslationsForResourceManager(
        ResourceManager resourceManager,
        IList<string> cultureNames)
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
            cultureNames,
            resourceSet);

        foreach (var item in resultForTranslations)
        {
            result.Add(item.Key, item.Value);
        }

        return result;
    }

    private static Dictionary<string, List<string>> CollectInvalidKeySuffixWithPlaceholdersForResourceManager(
        ResourceManager resourceManager,
        IList<string> cultureNames,
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
            cultureNames,
            resourceSet,
            allowSuffixTerms);

        foreach (var item in resultForTranslations)
        {
            result.Add(item.Key, item.Value);
        }

        return result;
    }

    internal static bool ValidateKeySuffixWithPlaceholders(
        string key,
        string value,
        IList<string>? allowSuffixTerms = null)
    {
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
        for (var i = 0; i < value.Length - 2; i++)
        {
            if (value[i] != '{' || !char.IsDigit(value[i + 1]) || value[i + 2] != '}')
            {
                continue;
            }

            var index = int.Parse(value[i + 1].ToString(), GlobalizationConstants.EnglishCultureInfo);
            maxIndex = System.Math.Max(maxIndex, index);
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
}