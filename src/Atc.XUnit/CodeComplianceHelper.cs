namespace Atc.XUnit;

/// <summary>
/// CodeComplianceNamingHelper.
/// </summary>
public static class CodeComplianceHelper
{
    /// <summary>
    /// Asserts the exported types with wrong definitions.
    /// </summary>
    /// <param name="type">The type.</param>
    /// <param name="useFullName">if set to <see langword="true" /> [use full name].</param>
    public static void AssertExportedTypesWithWrongDefinitions(
        Type type,
        bool useFullName = false)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Asserts the exported types with wrong definitions.
    /// </summary>
    /// <param name="assembly">The assembly.</param>
    /// <param name="excludeTypes">The exclude types.</param>
    /// <param name="useFullName">if set to <see langword="true" /> [use full name].</param>
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
    /// Asserts the localization resources with missing translations or invalid keys with placeholders in value.
    /// </summary>
    /// <param name="assembly">The assembly.</param>
    /// <param name="cultureNames">The culture names.</param>
    /// <param name="allowSuffixTermsForKeySuffixWithPlaceholders">The allow suffix terms for key suffix with placeholders.</param>
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
    /// Asserts the localization resources with missing translations.
    /// </summary>
    /// <param name="assembly">The assembly.</param>
    /// <param name="cultureNames">The culture names.</param>
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
    /// Asserts the localization resources with invalid keys with placeholders in value.
    /// </summary>
    /// <param name="assembly">The assembly.</param>
    /// <param name="cultureNames">The culture names.</param>
    /// <param name="allowSuffixTermsForKeySuffixWithPlaceholders">The allow suffix terms for key suffix with placeholders.</param>
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