namespace Atc.XUnit;

/// <summary>
/// CodeComplianceTestHelper.
/// </summary>
public static class CodeComplianceTestHelper
{
    /// <summary>
    /// Asserts the exported methods with missing tests.
    /// </summary>
    /// <param name="decompilerType">The decompiler type.</param>
    /// <param name="sourceType">Type of the source.</param>
    /// <param name="testType">Type of the test.</param>
    /// <param name="useFullName">if set to <c>true</c> [use full name].</param>
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
            sourceType.Assembly.GetName().Name,
            methodsWithMissingTests,
            useFullName);
    }

    /// <summary>
    /// Asserts the exported methods with missing tests.
    /// </summary>
    /// <param name="decompilerType">The decompiler type.</param>
    /// <param name="sourceType">Type of the source.</param>
    /// <param name="testAssembly">The test assembly.</param>
    /// <param name="useFullName">if set to <c>true</c> [use full name].</param>
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
            sourceType.Assembly.GetName().Name,
            methodsWithMissingTests,
            useFullName);
    }

    /// <summary>
    /// Asserts the exported methods with missing tests.
    /// </summary>
    /// <param name="decompilerType">The decompiler type.</param>
    /// <param name="sourceAssembly">The source assembly.</param>
    /// <param name="testAssembly">The test assembly.</param>
    /// <param name="excludeSourceTypes">The exclude source types.</param>
    /// <param name="useFullName">if set to <c>true</c> [use full name].</param>
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
            sourceAssembly.GetName().Name,
            methodsWithMissingTests,
            useFullName);
    }

    /// <summary>
    /// Collects the exported types with missing tests.
    /// </summary>
    /// <param name="decompilerType">The decompiler type.</param>
    /// <param name="sourceAssembly">The source assembly.</param>
    /// <param name="testAssembly">The test assembly.</param>
    /// <param name="excludeSourceTypes">The exclude source types.</param>
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
    /// Collects the exported types with missing tests and generate text.
    /// </summary>
    /// <param name="decompilerType">The decompiler type.</param>
    /// <param name="sourceAssembly">The source assembly.</param>
    /// <param name="testAssembly">The test assembly.</param>
    /// <param name="excludeSourceTypes">The exclude source types.</param>
    /// <param name="useFullName">if set to <c>true</c> [use full name].</param>
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
        sb.AppendLine(12, "{");
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
    /// Collects the exported methods with missing tests from assembly.
    /// </summary>
    /// <param name="decompilerType">The decompiler type.</param>
    /// <param name="sourceAssembly">The source assembly.</param>
    /// <param name="testAssembly">The test assembly.</param>
    /// <param name="excludeSourceTypes">The exclude source types.</param>
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
    /// Collects the exported methods with missing tests and generate text lines.
    /// </summary>
    /// <param name="decompilerType">The decompiler type.</param>
    /// <param name="sourceAssembly">The source assembly.</param>
    /// <param name="testAssembly">The test assembly.</param>
    /// <param name="excludeSourceTypes">The exclude source types.</param>
    /// <param name="useFullName">if set to <c>true</c> [use full name].</param>
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
    /// Collects the exported methods with missing tests and generate text.
    /// </summary>
    /// <param name="decompilerType">The decompiler type.</param>
    /// <param name="sourceAssembly">The source assembly.</param>
    /// <param name="testAssembly">The test assembly.</param>
    /// <param name="excludeSourceTypes">The exclude source types.</param>
    /// <param name="useFullName">if set to <c>true</c> [use full name].</param>
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
    /// Collects the exported methods with missing tests to excel.
    /// </summary>
    /// <param name="decompilerType">The decompiler type.</param>
    /// <param name="sourceAssembly">The source assembly.</param>
    /// <param name="testAssembly">The test assembly.</param>
    /// <param name="excludeSourceTypes">The exclude source types.</param>
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
    /// Collects the exported methods with missing tests to excel.
    /// </summary>
    /// <param name="decompilerType">The decompiler type.</param>
    /// <param name="reportDirectory">The report directory.</param>
    /// <param name="sourceAssembly">The source assembly.</param>
    /// <param name="testAssembly">The test assembly.</param>
    /// <param name="excludeSourceTypes">The exclude source types.</param>
    /// <exception cref="ArgumentNullException">reportDirectory.</exception>
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
            sourceAssembly.GetName().Name,
            methodsWithMissingTests);
    }
}