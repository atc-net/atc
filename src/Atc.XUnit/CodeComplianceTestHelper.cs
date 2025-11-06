namespace Atc.XUnit;

/// <summary>
/// Provides helper methods for asserting code compliance related to test coverage.
/// </summary>
public static class CodeComplianceTestHelper
{
    /// <summary>
    /// Asserts that all public methods in a source type have corresponding unit tests.
    /// Fails the test if any methods are missing test coverage.
    /// </summary>
    /// <param name="decompilerType">The <see cref="DecompilerType"/> to use for analyzing test method bodies.</param>
    /// <param name="sourceType">The source type to validate for test coverage.</param>
    /// <param name="testType">The test type containing unit tests for the source type.</param>
    /// <param name="useFullName">If set to <c>true</c>, use full type names in output.</param>
    public static void AssertExportedMethodsWithMissingTests(
        DecompilerType decompilerType,
        Type sourceType,
        Type testType,
        bool useFullName = false)
    {
        if (sourceType is null)
        {
            throw new ArgumentNullException(nameof(sourceType));
        }

        if (testType is null)
        {
            throw new ArgumentNullException(nameof(testType));
        }

        var methodsWithMissingTests = AssemblyTestHelper.CollectExportedMethodsWithMissingTests(
            decompilerType,
            sourceType,
            testType);
        TestResultHelper.AssertOnTestResultsFromMethodsWithMissingTests(
            sourceType.Assembly.GetName().Name!,
            methodsWithMissingTests,
            useFullName);
    }

    /// <summary>
    /// Asserts that all public methods in a source type have corresponding unit tests.
    /// Searches the entire test assembly for tests covering the source type.
    /// </summary>
    /// <param name="decompilerType">The <see cref="DecompilerType"/> to use for analyzing test method bodies.</param>
    /// <param name="sourceType">The source type to validate for test coverage.</param>
    /// <param name="testAssembly">The test assembly to search for unit tests.</param>
    /// <param name="useFullName">If set to <c>true</c>, use full type names in output.</param>
    public static void AssertExportedMethodsWithMissingTests(
        DecompilerType decompilerType,
        Type sourceType,
        Assembly testAssembly,
        bool useFullName = false)
    {
        if (sourceType is null)
        {
            throw new ArgumentNullException(nameof(sourceType));
        }

        var methodsWithMissingTests = AssemblyTestHelper.CollectExportedMethodsWithMissingTests(
            decompilerType,
            sourceType,
            testAssembly);
        TestResultHelper.AssertOnTestResultsFromMethodsWithMissingTests(
            sourceType.Assembly.GetName().Name!,
            methodsWithMissingTests,
            useFullName);
    }

    /// <summary>
    /// Asserts that all public methods in a source assembly have corresponding unit tests.
    /// Fails the test if any methods are missing test coverage.
    /// </summary>
    /// <param name="decompilerType">The <see cref="DecompilerType"/> to use for analyzing test method bodies.</param>
    /// <param name="sourceAssembly">The source assembly to validate for test coverage.</param>
    /// <param name="testAssembly">The test assembly containing unit tests.</param>
    /// <param name="excludeSourceTypes">Optional list of source types to exclude from validation.</param>
    /// <param name="useFullName">If set to <c>true</c>, use full type names in output.</param>
    public static void AssertExportedMethodsWithMissingTests(
        DecompilerType decompilerType,
        Assembly sourceAssembly,
        Assembly testAssembly,
        List<Type>? excludeSourceTypes = null,
        bool useFullName = false)
    {
        if (sourceAssembly is null)
        {
            throw new ArgumentNullException(nameof(sourceAssembly));
        }

        if (testAssembly is null)
        {
            throw new ArgumentNullException(nameof(testAssembly));
        }

        var methodsWithMissingTests = AssemblyTestHelper.CollectExportedMethodsWithMissingTests(
            decompilerType,
            sourceAssembly,
            testAssembly,
            excludeSourceTypes);
        TestResultHelper.AssertOnTestResultsFromMethodsWithMissingTests(
            sourceAssembly.GetName().Name!,
            methodsWithMissingTests,
            useFullName);
    }

    /// <summary>
    /// Collects all exported types that have at least one method missing test coverage.
    /// </summary>
    /// <param name="decompilerType">The <see cref="DecompilerType"/> to use for analyzing test method bodies.</param>
    /// <param name="sourceAssembly">The source assembly to analyze.</param>
    /// <param name="testAssembly">The test assembly to search for unit tests.</param>
    /// <param name="excludeSourceTypes">Optional list of source types to exclude from analysis.</param>
    /// <returns>An array of types that have methods missing test coverage.</returns>
    public static Type[] CollectExportedTypesWithMissingTests(
        DecompilerType decompilerType,
        Assembly sourceAssembly,
        Assembly testAssembly,
        List<Type>? excludeSourceTypes = null)
    {
        if (sourceAssembly is null)
        {
            throw new ArgumentNullException(nameof(sourceAssembly));
        }

        if (testAssembly is null)
        {
            throw new ArgumentNullException(nameof(testAssembly));
        }

        return AssemblyTestHelper.CollectExportedTypesWithMissingTests(
            decompilerType,
            sourceAssembly,
            testAssembly,
            excludeSourceTypes);
    }

    /// <summary>
    /// Collects exported types with missing tests and generates a C# code snippet for an exclude list.
    /// Useful for generating initial exclude lists when adding test coverage validation.
    /// </summary>
    /// <param name="decompilerType">The <see cref="DecompilerType"/> to use for analyzing test method bodies.</param>
    /// <param name="sourceAssembly">The source assembly to analyze.</param>
    /// <param name="testAssembly">The test assembly to search for unit tests.</param>
    /// <param name="excludeSourceTypes">Optional list of source types to exclude from analysis.</param>
    /// <param name="useFullName">If set to <c>true</c>, use full type names in output.</param>
    /// <returns>A formatted C# code snippet containing a list of typeof() expressions for types missing tests.</returns>
    public static string CollectExportedTypesWithMissingTestsAndGenerateText(
        DecompilerType decompilerType,
        Assembly sourceAssembly,
        Assembly testAssembly,
        List<Type>? excludeSourceTypes = null,
        bool useFullName = false)
    {
        if (sourceAssembly is null)
        {
            throw new ArgumentNullException(nameof(sourceAssembly));
        }

        if (testAssembly is null)
        {
            throw new ArgumentNullException(nameof(testAssembly));
        }

        var typesWithMissingTests = AssemblyTestHelper.CollectExportedTypesWithMissingTests(
            decompilerType,
            sourceAssembly,
            testAssembly,
            excludeSourceTypes);

        var sb = new StringBuilder();
        sb.AppendLine(12, "var excludeTypes = new List<Type>");
        sb.AppendLine(12, '{');
        sb.AppendLine(12, "{    // TODO: Implement tests on the following types, and then remove the type from the exclude list.");
        for (var i = 0; i < typesWithMissingTests.Length; i++)
        {
            var type = typesWithMissingTests[i];
            if (i == typesWithMissingTests.Length - 1)
            {
                var text = useFullName
                    ? $"typeof(global::{type.BeautifyName(useFullName: true)})"
                    : $"typeof({type.BeautifyName()})";
                sb.AppendLine(16, text);
            }
            else
            {
                var text = useFullName
                    ? $"typeof(global::{type.BeautifyName(useFullName: true)}),"
                    : $"typeof({type.BeautifyName()}),";
                sb.AppendLine(16, text);
            }
        }

        sb.AppendLine(12, "}");
        return sb.ToString();
    }

    /// <summary>
    /// Collects all exported methods from an assembly that are missing test coverage.
    /// </summary>
    /// <param name="decompilerType">The <see cref="DecompilerType"/> to use for analyzing test method bodies.</param>
    /// <param name="sourceAssembly">The source assembly to analyze.</param>
    /// <param name="testAssembly">The test assembly to search for unit tests.</param>
    /// <param name="excludeSourceTypes">Optional list of source types to exclude from analysis.</param>
    /// <returns>An array of <see cref="MethodInfo"/> objects representing methods missing test coverage.</returns>
    public static MethodInfo[] CollectExportedMethodsWithMissingTestsFromAssembly(
        DecompilerType decompilerType,
        Assembly sourceAssembly,
        Assembly testAssembly,
        List<Type>? excludeSourceTypes = null)
    {
        if (sourceAssembly is null)
        {
            throw new ArgumentNullException(nameof(sourceAssembly));
        }

        if (testAssembly is null)
        {
            throw new ArgumentNullException(nameof(testAssembly));
        }

        return AssemblyTestHelper.CollectExportedMethodsWithMissingTests(decompilerType, sourceAssembly, testAssembly, excludeSourceTypes);
    }

    /// <summary>
    /// Collects exported methods with missing tests and generates an array of formatted method signatures.
    /// </summary>
    /// <param name="decompilerType">The <see cref="DecompilerType"/> to use for analyzing test method bodies.</param>
    /// <param name="sourceAssembly">The source assembly to analyze.</param>
    /// <param name="testAssembly">The test assembly to search for unit tests.</param>
    /// <param name="excludeSourceTypes">Optional list of source types to exclude from analysis.</param>
    /// <param name="useFullName">If set to <c>true</c>, use full type names in output.</param>
    /// <returns>An array of strings containing beautified method signatures.</returns>
    public static string[] CollectExportedMethodsWithMissingTestsAndGenerateTextLines(
        DecompilerType decompilerType,
        Assembly sourceAssembly,
        Assembly testAssembly,
        List<Type>? excludeSourceTypes = null,
        bool useFullName = false)
    {
        if (sourceAssembly is null)
        {
            throw new ArgumentNullException(nameof(sourceAssembly));
        }

        if (testAssembly is null)
        {
            throw new ArgumentNullException(nameof(testAssembly));
        }

        var methodsWithMissingTests = AssemblyTestHelper.CollectExportedMethodsWithMissingTests(decompilerType, sourceAssembly, testAssembly, excludeSourceTypes);
        return AssemblyTestHelper.GetMethodsAsRenderTextLines(methodsWithMissingTests, useFullName);
    }

    /// <summary>
    /// Collects exported methods with missing tests and generates a formatted text report.
    /// </summary>
    /// <param name="decompilerType">The <see cref="DecompilerType"/> to use for analyzing test method bodies.</param>
    /// <param name="sourceAssembly">The source assembly to analyze.</param>
    /// <param name="testAssembly">The test assembly to search for unit tests.</param>
    /// <param name="excludeSourceTypes">Optional list of source types to exclude from analysis.</param>
    /// <param name="useFullName">If set to <c>true</c>, use full type names in output.</param>
    /// <returns>A multi-line string containing all method signatures missing tests.</returns>
    public static string CollectExportedMethodsWithMissingTestsAndGenerateText(
        DecompilerType decompilerType,
        Assembly sourceAssembly,
        Assembly testAssembly,
        List<Type>? excludeSourceTypes = null,
        bool useFullName = false)
    {
        if (sourceAssembly is null)
        {
            throw new ArgumentNullException(nameof(sourceAssembly));
        }

        if (testAssembly is null)
        {
            throw new ArgumentNullException(nameof(testAssembly));
        }

        var methodsWithMissingTests = AssemblyTestHelper.CollectExportedMethodsWithMissingTests(decompilerType, sourceAssembly, testAssembly, excludeSourceTypes);
        return AssemblyTestHelper.GetMethodsAsRenderText(methodsWithMissingTests, useFullName);
    }

    /// <summary>
    /// Collects exported methods with missing tests and exports them to an Excel file at C:\Temp.
    /// </summary>
    /// <param name="decompilerType">The <see cref="DecompilerType"/> to use for analyzing test method bodies.</param>
    /// <param name="sourceAssembly">The source assembly to analyze.</param>
    /// <param name="testAssembly">The test assembly to search for unit tests.</param>
    /// <param name="excludeSourceTypes">Optional list of source types to exclude from analysis.</param>
    public static void CollectExportedMethodsWithMissingTestsToExcel(
        DecompilerType decompilerType,
        Assembly sourceAssembly,
        Assembly testAssembly,
        List<Type>? excludeSourceTypes = null)
    {
        if (sourceAssembly is null)
        {
            throw new ArgumentNullException(nameof(sourceAssembly));
        }

        if (testAssembly is null)
        {
            throw new ArgumentNullException(nameof(testAssembly));
        }

        CollectExportedMethodsWithMissingTestsToExcel(
            decompilerType,
            new DirectoryInfo(@"C:\Temp"),
            sourceAssembly,
            testAssembly,
            excludeSourceTypes);
    }

    /// <summary>
    /// Collects exported methods with missing tests and exports them to an Excel file in the specified directory.
    /// </summary>
    /// <param name="decompilerType">The <see cref="DecompilerType"/> to use for analyzing test method bodies.</param>
    /// <param name="reportDirectory">The directory where the Excel report will be saved.</param>
    /// <param name="sourceAssembly">The source assembly to analyze.</param>
    /// <param name="testAssembly">The test assembly to search for unit tests.</param>
    /// <param name="excludeSourceTypes">Optional list of source types to exclude from analysis.</param>
    public static void CollectExportedMethodsWithMissingTestsToExcel(
        DecompilerType decompilerType,
        DirectoryInfo reportDirectory,
        Assembly sourceAssembly,
        Assembly testAssembly,
        List<Type>? excludeSourceTypes = null)
    {
        if (reportDirectory is null)
        {
            throw new ArgumentNullException(nameof(reportDirectory));
        }

        if (sourceAssembly is null)
        {
            throw new ArgumentNullException(nameof(sourceAssembly));
        }

        if (testAssembly is null)
        {
            throw new ArgumentNullException(nameof(testAssembly));
        }

        var methodsWithMissingTests = AssemblyTestHelper.CollectExportedMethodsWithMissingTests(
            decompilerType,
            sourceAssembly,
            testAssembly,
            excludeSourceTypes);
        TestResultHelper.ToExcelTestResultsFromMethodsWithMissingTests(
            reportDirectory,
            sourceAssembly.GetName().Name!,
            methodsWithMissingTests);
    }
}