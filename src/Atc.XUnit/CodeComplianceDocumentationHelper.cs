namespace Atc.XUnit;

/// <summary>
/// CodeComplianceDocumentationHelper.
/// </summary>
public static class CodeComplianceDocumentationHelper
{
    /// <summary>
    /// Asserts the exported type with missing comments.
    /// </summary>
    /// <param name="type">The type.</param>
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
    /// Asserts the exported types with missing comments.
    /// </summary>
    /// <param name="assembly">The assembly.</param>
    /// <param name="excludeTypes">The exclude types.</param>
    public static void AssertExportedTypesWithMissingComments(
        Assembly assembly,
        List<Type>? excludeTypes = null)
    {
        if (assembly is null)
        {
            throw new ArgumentNullException(nameof(assembly));
        }

        // Due to some build issue with GenerateDocumentationFile=true and xml-file location, this hack is made for now.
        if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            return;
        }

        var typesWithMissingCommentsGroups = DocumentationHelper.CollectExportedTypesWithMissingCommentsFromAssembly(
                assembly,
                excludeTypes)
            .OrderBy(x => x.Type.FullName)
            .GroupBy(x => x.Type.BeautifyName(useFullName: true), StringComparer.Ordinal)
            .ToArray();

        var testResults = new List<TestResult>
        {
            new TestResult($"Assembly: {assembly.GetName()}"),
        };

        testResults.AddRange(typesWithMissingCommentsGroups.Select(item => new TestResult(isError: false, 1, $"Type: {item.Key}")));

        TestResultHelper.AssertOnTestResults(testResults);
    }
}