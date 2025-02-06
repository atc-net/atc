using Atc.XUnit.Internal.AbstractSyntaxTree;

namespace Atc.XUnit.Internal;

internal static class AssemblyTestHelper
{
    private static readonly DebugLimitData? DebugLimitData;

    [SuppressMessage("Performance", "CA1810:Initialize reference type static fields inline", Justification = "OK.")]
    [SuppressMessage("Minor Code Smell", "S3963:\"static\" fields should be initialized inline", Justification = "OK.")]
    static AssemblyTestHelper()
    {
        DebugLimitData = null;
        ////var classMethodNames = new List<Tuple<string, List<string>>>
        ////{
        ////    // Add debug stuff....
        ////    new Tuple<string, List<string>>("DummyClassToFocusOn", new List<string>
        ////    {
        ////        "DummyMethodToFocusOn",
        ////    }),
        ////};

        ////DebugLimitData = new DebugLimitData(classMethodNames);
    }

    internal static Type[] CollectExportedTypesWithMissingTests(DecompilerType decompilerType, Assembly sourceAssembly, Assembly testAssembly, List<Type>? excludeSourceTypes)
    {
        var methodsWithMissingTests = CollectExportedMethodsWithMissingTests(decompilerType, sourceAssembly, testAssembly, excludeSourceTypes);

        var methodsWithMissingTestsGroups = methodsWithMissingTests
            .OrderBy(x => x.DeclaringType?.FullName, StringComparer.Ordinal)
            .GroupBy(x => x.DeclaringType)
            .ToArray();

        return methodsWithMissingTestsGroups
            .OrderBy(x => x.Key?.Name, StringComparer.Ordinal)
            .Select(item => item.Key!)
            .ToArray();
    }

    internal static MethodInfo[] CollectExportedMethodsWithMissingTests(DecompilerType decompilerType, Type sourceType, Type testType)
    {
        if (sourceType is null)
        {
            throw new ArgumentNullException(nameof(sourceType));
        }

        if (testType is null)
        {
            throw new ArgumentNullException(nameof(testType));
        }

        var sourceTypes = new[] { sourceType };
        var testTypes = new[] { testType };

        var testTypeMethods = TypeAndMethodAndParameterHelper.GetTypeMethodsWithTestAttributes(testTypes);
        switch (decompilerType)
        {
            case DecompilerType.AbstractSyntaxTree:
                var decompiler = DecompilerHelper.GetDecompiler(testType.Assembly);
                var testMethodsWithDecompiled = DecompilerHelper.GetTestMethodsWithDecompiled(decompiler, testTypeMethods);
                return AnalyzerHelper.GetSourceMethodsWithMissingTest(sourceTypes.ToArray(), testMethodsWithDecompiled, DebugLimitData);
            case DecompilerType.MonoReflection:
                var usedSourceMethods = MonoReflection.AnalyzerHelper.GetUsedSourceMethods(sourceTypes, testTypeMethods);
                return MonoReflection.AnalyzerHelper.GetSourceMethodsWithMissingTest(sourceTypes, usedSourceMethods, DebugLimitData);
            default:
                throw new ArgumentOutOfRangeException(nameof(decompilerType), decompilerType, message: null);
        }
    }

    internal static MethodInfo[] CollectExportedMethodsWithMissingTests(DecompilerType decompilerType, Type sourceType, Assembly testAssembly)
    {
        if (sourceType is null)
        {
            throw new ArgumentNullException(nameof(sourceType));
        }

        if (testAssembly is null)
        {
            throw new ArgumentNullException(nameof(testAssembly));
        }

        var sourceTypes = new[] { sourceType };
        var testTypes = testAssembly.ExportedTypes.ToArray();

        var testTypeMethods = TypeAndMethodAndParameterHelper.GetTypeMethodsWithTestAttributes(testTypes);
        switch (decompilerType)
        {
            case DecompilerType.AbstractSyntaxTree:
                var decompiler = DecompilerHelper.GetDecompiler(testAssembly);
                var testMethodsWithDecompiled = DecompilerHelper.GetTestMethodsWithDecompiled(decompiler, testTypeMethods);
                return AnalyzerHelper.GetSourceMethodsWithMissingTest(sourceTypes.ToArray(), testMethodsWithDecompiled, DebugLimitData);
            case DecompilerType.MonoReflection:
                var usedSourceMethods = MonoReflection.AnalyzerHelper.GetUsedSourceMethods(sourceTypes, testTypeMethods);
                return MonoReflection.AnalyzerHelper.GetSourceMethodsWithMissingTest(sourceTypes, usedSourceMethods, DebugLimitData);
            default:
                throw new ArgumentOutOfRangeException(nameof(decompilerType), decompilerType, message: null);
        }
    }

    [SuppressMessage("Performance", "MA0020:Use direct methods instead of LINQ methods", Justification = "OK.")]
    internal static MethodInfo[] CollectExportedMethodsWithMissingTests(DecompilerType decompilerType, Assembly sourceAssembly, Assembly testAssembly, List<Type>? excludeSourceTypes)
    {
        if (sourceAssembly is null)
        {
            throw new ArgumentNullException(nameof(sourceAssembly));
        }

        if (testAssembly is null)
        {
            throw new ArgumentNullException(nameof(testAssembly));
        }

        var sourceTypes = sourceAssembly.ExportedTypes
            .Where(x => !x.IsInterface &&
                        !x.IsNested &&
                        !(x.IsAbstract && !x.IsSealed) &&
                        !x.IsDelegate() &&
                        !x.HasExcludeFromCodeCoverageAttribute() &&
                        !x.HasCompilerGeneratedAttribute())
            .OrderBy(x => x.Name, StringComparer.Ordinal)
            .ToArray();

        if (excludeSourceTypes is { Count: > 0 })
        {
            sourceTypes = sourceTypes
                .Where(sourceType => excludeSourceTypes
                    .FirstOrDefault(x => string.Equals(x.BeautifyName(useFullName: true, useHtmlFormat: false, useGenericParameterNamesAsT: true), sourceType.BeautifyName(useFullName: true, useHtmlFormat: false, useGenericParameterNamesAsT: true), StringComparison.Ordinal)) is null)
                .OrderBy(x => x.Name, StringComparer.Ordinal)
                .ToArray();
        }

        var testTypes = testAssembly.ExportedTypes.ToArray();
        var testTypeMethods = TypeAndMethodAndParameterHelper.GetTypeMethodsWithTestAttributes(testTypes);
        switch (decompilerType)
        {
            case DecompilerType.AbstractSyntaxTree:
                var decompiler = DecompilerHelper.GetDecompiler(testAssembly);
                var testMethodsWithDecompiled = DecompilerHelper.GetTestMethodsWithDecompiled(decompiler, testTypeMethods);
                return AnalyzerHelper.GetSourceMethodsWithMissingTest(sourceTypes, testMethodsWithDecompiled, DebugLimitData);
            case DecompilerType.MonoReflection:
                var usedSourceMethods = MonoReflection.AnalyzerHelper.GetUsedSourceMethods(sourceAssembly.ExportedTypes.ToArray(), testTypeMethods);
                return MonoReflection.AnalyzerHelper.GetSourceMethodsWithMissingTest(sourceTypes, usedSourceMethods, DebugLimitData);
            default:
                throw new ArgumentOutOfRangeException(nameof(decompilerType), decompilerType, message: null);
        }
    }

    internal static string[] GetMethodsAsRenderTextLines(MethodInfo[] methods, bool useFullName)
    {
        return methods
            .OrderBy(x => x.DeclaringType?.FullName, StringComparer.Ordinal)
            .ThenBy(x => x.Name, StringComparer.Ordinal)
            .ThenBy(x => x.GetParameters().Length)
            .Select(method => method.BeautifyName(useFullName))
            .ToArray();
    }

    internal static string GetMethodsAsRenderText(MethodInfo[] methods, bool useFullName)
    {
        var methodsAsRenderTextItems = GetMethodsAsRenderTextLines(methods, useFullName);
        var sb = new StringBuilder();
        foreach (var item in methodsAsRenderTextItems)
        {
            sb.AppendLine(item);
        }

        return sb.ToString();
    }
}