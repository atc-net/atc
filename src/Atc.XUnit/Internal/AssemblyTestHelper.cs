using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Atc.XUnit.Internal
{
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
            ////        "DummyMethodToFocusOn"
            ////    })
            ////};

            ////DebugLimitData = new DebugLimitData(classMethodNames);
        }

        internal static Type[] CollectExportedTypesWithMissingTests(DecompilerType decompilerType, Assembly sourceAssembly, Assembly testAssembly, List<Type>? excludeSourceTypes)
        {
            var methodsWithMissingTests = CollectExportedMethodsWithMissingTests(decompilerType, sourceAssembly, testAssembly, excludeSourceTypes);

            var methodsWithMissingTestsGroups = methodsWithMissingTests
                .OrderBy(x => x.DeclaringType?.FullName)
                .GroupBy(x => x.DeclaringType)
                .ToArray();

            return methodsWithMissingTestsGroups
                .OrderBy(x => x.Key?.Name)
                .Select(item => item.Key)
                .ToArray();
        }

        internal static MethodInfo[] CollectExportedMethodsWithMissingTests(DecompilerType decompilerType, Type sourceType, Type testType)
        {
            if (sourceType == null)
            {
                throw new ArgumentNullException(nameof(sourceType));
            }

            if (testType == null)
            {
                throw new ArgumentNullException(nameof(testType));
            }

            var sourceTypes = new[] { sourceType };
            var testTypes = new[] { testType };

            var testTypeMethods = TypeAndMethodAndParameterHelper.GetTypeMethodsWithTestAttributes(testTypes);
            switch (decompilerType)
            {
                case DecompilerType.AbstractSyntaxTree:
                    var decompiler = AbstractSyntaxTree.DecompilerHelper.GetDecompiler(testType.Assembly);
                    var testMethodsWithDecompiled = AbstractSyntaxTree.DecompilerHelper.GetTestMethodsWithDecompiled(decompiler, testTypeMethods);
                    return AbstractSyntaxTree.AnalyzerHelper.GetSourceMethodsWithMissingTest(sourceTypes.ToArray(), testMethodsWithDecompiled, DebugLimitData);
                case DecompilerType.MonoReflection:
                    var usedSourceMethods = MonoReflection.AnalyzerHelper.GetUsedSourceMethods(sourceTypes, testTypeMethods);
                    return MonoReflection.AnalyzerHelper.GetSourceMethodsWithMissingTest(sourceTypes, usedSourceMethods, DebugLimitData);
                default:
                    throw new ArgumentOutOfRangeException(nameof(decompilerType), decompilerType, null);
            }
        }

        internal static MethodInfo[] CollectExportedMethodsWithMissingTests(DecompilerType decompilerType, Type sourceType, Assembly testAssembly)
        {
            if (sourceType == null)
            {
                throw new ArgumentNullException(nameof(sourceType));
            }

            if (testAssembly == null)
            {
                throw new ArgumentNullException(nameof(testAssembly));
            }

            var sourceTypes = new[] { sourceType };
            var testTypes = testAssembly.ExportedTypes.ToArray();

            var testTypeMethods = TypeAndMethodAndParameterHelper.GetTypeMethodsWithTestAttributes(testTypes);
            switch (decompilerType)
            {
                case DecompilerType.AbstractSyntaxTree:
                    var decompiler = AbstractSyntaxTree.DecompilerHelper.GetDecompiler(testAssembly);
                    var testMethodsWithDecompiled = AbstractSyntaxTree.DecompilerHelper.GetTestMethodsWithDecompiled(decompiler, testTypeMethods);
                    return AbstractSyntaxTree.AnalyzerHelper.GetSourceMethodsWithMissingTest(sourceTypes.ToArray(), testMethodsWithDecompiled, DebugLimitData);
                case DecompilerType.MonoReflection:
                    var usedSourceMethods = MonoReflection.AnalyzerHelper.GetUsedSourceMethods(sourceTypes, testTypeMethods);
                    return MonoReflection.AnalyzerHelper.GetSourceMethodsWithMissingTest(sourceTypes, usedSourceMethods, DebugLimitData);
                default:
                    throw new ArgumentOutOfRangeException(nameof(decompilerType), decompilerType, null);
            }
        }

        internal static MethodInfo[] CollectExportedMethodsWithMissingTests(DecompilerType decompilerType, Assembly sourceAssembly, Assembly testAssembly, List<Type>? excludeSourceTypes)
        {
            if (sourceAssembly == null)
            {
                throw new ArgumentNullException(nameof(sourceAssembly));
            }

            if (testAssembly == null)
            {
                throw new ArgumentNullException(nameof(testAssembly));
            }

            var sourceTypes = sourceAssembly.ExportedTypes
                .Where(x => !x.IsInterface &&
                            !x.IsNested &&
                            !(x.IsAbstract && !x.IsSealed) &&
                            !x.IsDelegate() &&
                            !x.HasExcludeFromCodeCoverageAttribute())
                .OrderBy(x => x.Name)
                .ToArray();

            if (excludeSourceTypes != null && excludeSourceTypes.Count > 0)
            {
                sourceTypes = sourceTypes
                    .Where(sourceType => excludeSourceTypes.FirstOrDefault(x => string.Equals(x.BeautifyName(true, false, true), sourceType.BeautifyName(true, false, true), StringComparison.Ordinal)) == null)
                    .OrderBy(x => x.Name)
                    .ToArray();
            }

            var testTypes = testAssembly.ExportedTypes.ToArray();
            var testTypeMethods = TypeAndMethodAndParameterHelper.GetTypeMethodsWithTestAttributes(testTypes);
            switch (decompilerType)
            {
                case DecompilerType.AbstractSyntaxTree:
                    var decompiler = AbstractSyntaxTree.DecompilerHelper.GetDecompiler(testAssembly);
                    var testMethodsWithDecompiled = AbstractSyntaxTree.DecompilerHelper.GetTestMethodsWithDecompiled(decompiler, testTypeMethods);
                    return AbstractSyntaxTree.AnalyzerHelper.GetSourceMethodsWithMissingTest(sourceTypes, testMethodsWithDecompiled, DebugLimitData);
                case DecompilerType.MonoReflection:
                    var usedSourceMethods = MonoReflection.AnalyzerHelper.GetUsedSourceMethods(sourceAssembly.ExportedTypes.ToArray(), testTypeMethods);
                    return MonoReflection.AnalyzerHelper.GetSourceMethodsWithMissingTest(sourceTypes, usedSourceMethods, DebugLimitData);
                default:
                    throw new ArgumentOutOfRangeException(nameof(decompilerType), decompilerType, null);
            }
        }

        internal static string[] GetMethodsAsRenderTextLines(MethodInfo[] methods, bool useFullName)
        {
            return methods
                .OrderBy(x => x.DeclaringType?.FullName)
                .ThenBy(x => x.Name)
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
}