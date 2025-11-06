namespace Atc.XUnit;

/// <summary>
/// Provides helper methods for asserting code compliance related to naming conventions and localization resources.
/// </summary>
public static class CodeComplianceHelper
{
    /// <summary>
    /// Asserts that exported types have correct naming definitions.
    /// Currently not implemented.
    /// </summary>
    /// <param name="type">The type to validate.</param>
    /// <param name="useFullName">If set to <c>true</c>, use full type names in output.</param>
    public static void AssertExportedTypesWithWrongDefinitions(
        Type type,
        bool useFullName = false)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Asserts that exported types in an assembly have correct naming definitions.
    /// Validates that extension methods follow proper naming conventions.
    /// </summary>
    /// <param name="assembly">The assembly to validate.</param>
    /// <param name="excludeTypes">Optional list of types to exclude from validation.</param>
    /// <param name="useFullName">If set to <c>true</c>, use full type names in output.</param>
    public static void AssertExportedTypesWithWrongDefinitions(
        Assembly assembly,
        List<Type>? excludeTypes = null,
        bool useFullName = false)
    {
        if (assembly is null)
        {
            throw new ArgumentNullException(nameof(assembly));
        }

        var methodsWithWrongNaming = AssemblyAnalyzerHelper.CollectExportedMethodsWithWrongNaming(
            assembly,
            excludeTypes);

        TestResultHelper.AssertOnTestResultsFromMethodsWithWrongDefinitions(
            assembly.GetName().Name!,
            methodsWithWrongNaming,
            useFullName);
    }

    /// <summary>
    /// Asserts that localization resources have all required translations and valid placeholder key suffixes.
    /// Validates both missing translations and invalid key suffix patterns for resources with placeholders.
    /// </summary>
    /// <param name="assembly">The assembly containing localization resources.</param>
    /// <param name="cultureNames">The list of culture names to validate (e.g., "en-US", "da-DK").</param>
    /// <param name="allowSuffixTermsForKeySuffixWithPlaceholders">Optional list of suffix terms allowed before numeric suffixes in keys with placeholders.</param>
    public static void AssertLocalizationResources(
        Assembly assembly,
        IList<string> cultureNames,
        IList<string>? allowSuffixTermsForKeySuffixWithPlaceholders = null)
    {
        if (assembly is null)
        {
            throw new ArgumentNullException(nameof(assembly));
        }

        var missingTranslations = AssemblyLocalizationResourcesHelper.CollectMissingTranslations(
            assembly,
            cultureNames);

        var invalidKeysSuffixWithPlaceholders = AssemblyLocalizationResourcesHelper.CollectInvalidKeySuffixWithPlaceholders(
            assembly,
            cultureNames,
            allowSuffixTermsForKeySuffixWithPlaceholders);

        TestResultHelper.AssertOnTestResultsFromMissingTranslationsAndInvalidKeysSuffixWithPlaceholders(
            assembly.GetName().Name!,
            missingTranslations,
            invalidKeysSuffixWithPlaceholders);
    }

    /// <summary>
    /// Asserts that localization resources have all required translations across specified cultures.
    /// </summary>
    /// <param name="assembly">The assembly containing localization resources.</param>
    /// <param name="cultureNames">The list of culture names to validate.</param>
    public static void AssertLocalizationResourcesForMissingTranslations(
        Assembly assembly,
        IList<string> cultureNames)
    {
        if (assembly is null)
        {
            throw new ArgumentNullException(nameof(assembly));
        }

        var missingTranslations = AssemblyLocalizationResourcesHelper.CollectMissingTranslations(
            assembly,
            cultureNames);

        TestResultHelper.AssertOnTestResultsFromMissingTranslationsAndInvalidKeysSuffixWithPlaceholders(
            assembly.GetName().Name!,
            missingTranslations,
            invalidKeysSuffixWithPlaceholders: null);
    }

    /// <summary>
    /// Asserts that localization resource keys with placeholders have valid numeric suffixes.
    /// Validates that keys like "Message2" have exactly 2 placeholders ({0} and {1}).
    /// </summary>
    /// <param name="assembly">The assembly containing localization resources.</param>
    /// <param name="cultureNames">The list of culture names to validate.</param>
    /// <param name="allowSuffixTermsForKeySuffixWithPlaceholders">Optional list of suffix terms allowed before numeric suffixes in keys with placeholders.</param>
    public static void AssertLocalizationResourcesForInvalidKeysSuffixWithPlaceholders(
        Assembly assembly,
        IList<string> cultureNames,
        IList<string>? allowSuffixTermsForKeySuffixWithPlaceholders = null)
    {
        if (assembly is null)
        {
            throw new ArgumentNullException(nameof(assembly));
        }

        var invalidKeysSuffixWithPlaceholders = AssemblyLocalizationResourcesHelper.CollectInvalidKeySuffixWithPlaceholders(
            assembly,
            cultureNames,
            allowSuffixTermsForKeySuffixWithPlaceholders);

        TestResultHelper.AssertOnTestResultsFromMissingTranslationsAndInvalidKeysSuffixWithPlaceholders(
            assembly.GetName().Name!,
            missingTranslations: null,
            invalidKeysSuffixWithPlaceholders);
    }
}