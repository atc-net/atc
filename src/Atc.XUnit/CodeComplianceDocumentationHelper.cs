namespace Atc.XUnit;

/// <summary>
/// Provides helper methods for asserting code compliance related to XML documentation comments.
/// </summary>
public static class CodeComplianceDocumentationHelper
{
    /// <summary>
    /// Asserts that the specified exported type has XML documentation comments.
    /// Fails the test if comments are missing.
    /// </summary>
    /// <param name="type">The type to validate for XML documentation.</param>
    public static void AssertExportedTypeWithMissingComments(Type type)
    {
        var typeComments = DocumentationHelper.CollectExportedTypeWithCommentsFromType(type);

        var testResults = new List<TestResult>();
        if (typeComments is not null && !typeComments.HasComments)
        {
            testResults.Add(new TestResult(isError: true, 0, $"Type: {typeComments.Type.BeautifyTypeName(useFullName: true)}"));
        }

        TestResultHelper.AssertOnTestResults(testResults);
    }

    /// <summary>
    /// Asserts that all exported types in an assembly have XML documentation comments,
    /// using an explicit XML documentation file path instead of relying on automatic path resolution.
    /// Use this overload when the XML documentation file is not located next to the assembly or in
    /// <see cref="AppDomain.CurrentDomain"/> base directory.
    /// </summary>
    /// <param name="assembly">The assembly to validate.</param>
    /// <param name="xmlDocPath">The explicit path to the XML documentation file for <paramref name="assembly"/>.</param>
    /// <param name="excludeTypes">Optional list of types to exclude from validation.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="assembly"/> or <paramref name="xmlDocPath"/> is null.</exception>
    public static void AssertExportedTypesWithMissingComments(
        Assembly assembly,
        FileInfo xmlDocPath,
        List<Type>? excludeTypes = null)
    {
        if (assembly is null)
        {
            throw new ArgumentNullException(nameof(assembly));
        }

        if (xmlDocPath is null)
        {
            throw new ArgumentNullException(nameof(xmlDocPath));
        }

        // Due to some build issue with GenerateDocumentationFile=true and xml-file location, this hack is made for now.
        if (!OperatingSystem.IsWindows())
        {
            return;
        }

        var typesWithMissingCommentsGroups = DocumentationHelper
            .CollectExportedTypesWithMissingCommentsFromAssembly(assembly, xmlDocPath, excludeTypes)
            .OrderBy(x => x.Type.FullName, StringComparer.Ordinal)
            .GroupBy(x => x.Type.BeautifyName(useFullName: true), StringComparer.Ordinal)
            .ToArray();

        var testResults = new List<TestResult>
        {
            new($"Assembly: {assembly.GetName()}"),
        };

        testResults.AddRange(typesWithMissingCommentsGroups.Select(item => new TestResult(isError: false, 1, $"Type: {item.Key}")));

        TestResultHelper.AssertOnTestResults(testResults);
    }

    /// <summary>
    /// Asserts that all exported types in an assembly have XML documentation comments.
    /// Fails the test if any types are missing documentation.
    /// </summary>
    /// <param name="assembly">The assembly to validate.</param>
    /// <param name="excludeTypes">Optional list of types to exclude from validation.</param>
    public static void AssertExportedTypesWithMissingComments(
        Assembly assembly,
        List<Type>? excludeTypes = null)
    {
        if (assembly is null)
        {
            throw new ArgumentNullException(nameof(assembly));
        }

        // Due to some build issue with GenerateDocumentationFile=true and xml-file location, this hack is made for now.
        if (!OperatingSystem.IsWindows())
        {
            return;
        }

        var typesWithMissingCommentsGroups = DocumentationHelper
            .CollectExportedTypesWithMissingCommentsFromAssembly(assembly, excludeTypes)
            .OrderBy(x => x.Type.FullName, StringComparer.Ordinal)
            .GroupBy(x => x.Type.BeautifyName(useFullName: true), StringComparer.Ordinal)
            .ToArray();

        var testResults = new List<TestResult>
        {
            new($"Assembly: {assembly.GetName()}"),
        };

        testResults.AddRange(typesWithMissingCommentsGroups.Select(item => new TestResult(isError: false, 1, $"Type: {item.Key}")));

        TestResultHelper.AssertOnTestResults(testResults);
    }
}