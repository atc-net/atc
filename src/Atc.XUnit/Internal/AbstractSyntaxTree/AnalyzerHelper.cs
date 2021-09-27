// ReSharper disable SuggestBaseTypeForParameter
// ReSharper disable ParameterTypeCanBeEnumerable.Local

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using ICSharpCode.Decompiler.CSharp.Syntax;

namespace Atc.XUnit.Internal.AbstractSyntaxTree
{
    internal static class AnalyzerHelper
    {
        internal static MethodInfo[] GetSourceMethodsWithMissingTest(
            Type[] sourceTypes,
            Tuple<MethodInfo, MethodDeclaration>[] testMethodsWithDeclaration,
            DebugLimitData? debugLimitData)
        {
            if (debugLimitData is not null)
            {
                sourceTypes = TypeAndMethodAndParameterHelper.DebugFilterTypeNames(debugLimitData, sourceTypes);
                testMethodsWithDeclaration = DecompilerMethodHelper.DebugFilterTypeNames(debugLimitData, testMethodsWithDeclaration);
            }

            var methodsWithTest = new List<MethodInfo>();
            var methodsToExclude = new List<MethodInfo>();

            // ReSharper disable once InvertIf
            if (testMethodsWithDeclaration.Length > 0)
            {
                foreach (var sourceType in sourceTypes)
                {
                    if (sourceType.HasValidationAttributes())
                    {
                        HandleSourceTypeWithValidationAttribute(sourceType, testMethodsWithDeclaration, methodsWithTest, methodsToExclude, debugLimitData);
                    }
                    else
                    {
                        foreach (var method in sourceType.GetPublicDeclaredOnlyMethods())
                        {
                            if (TypeAndMethodAndParameterHelper.ShouldMethodBeExcluded(method))
                            {
                                methodsToExclude.Add(method);
                                continue;
                            }

                            if (IsMethodUsed(method, testMethodsWithDeclaration, debugLimitData))
                            {
                                methodsWithTest.Add(method);
                            }
                            else if (debugLimitData is not null)
                            {
                                // Dummy for breakpoint
                                throw new Exception("Whoops..");
                            }
                        }
                    }
                }
            }
            else
            {
                foreach (var sourceType in sourceTypes)
                {
                    if (!sourceType.HasValidationAttributes())
                    {
                        methodsToExclude.AddRange(sourceType.GetPublicDeclaredOnlyMethods().Where(TypeAndMethodAndParameterHelper.ShouldMethodBeExcluded));
                    }
                }
            }

            return TypeAndMethodAndParameterHelper.FilterMethodsWithMissingTests(sourceTypes, methodsToExclude, methodsWithTest);
        }

        private static void HandleSourceTypeWithValidationAttribute(
            Type sourceType,
            Tuple<MethodInfo, MethodDeclaration>[] testMethodsWithDeclaration,
            ICollection<MethodInfo> methodsWithTest,
            ICollection<MethodInfo> methodsToExclude,
            DebugLimitData? debugLimitData)
        {
            var methods = sourceType.GetPublicDeclaredOnlyMethods();
            foreach (var method in methods)
            {
                if (method.Name.Equals("IsValid", StringComparison.Ordinal))
                {
                    if (IsMethodUsed(method, testMethodsWithDeclaration, debugLimitData))
                    {
                        methodsWithTest.Add(method);
                    }
                }
                else
                {
                    methodsToExclude.Add(method);
                }
            }
        }

        [SuppressMessage("StyleCop.CSharp.SpacingRules", "SA1011:Closing square brackets should be spaced correctly", Justification = "OK.")]
        private static bool IsMethodUsed(
            MethodInfo method,
            Tuple<MethodInfo, MethodDeclaration>[]? testMethodsWithDeclaration,
            DebugLimitData? debugLimitData)
        {
            testMethodsWithDeclaration = DecompilerMethodHelper.FilterTestMethods(method, testMethodsWithDeclaration);
            if (testMethodsWithDeclaration is null)
            {
                return false;
            }

            // ReSharper disable once InvertIf
            if (debugLimitData is not null)
            {
                testMethodsWithDeclaration = DecompilerMethodHelper.DebugFilterMethod(debugLimitData, method, testMethodsWithDeclaration);
                if (testMethodsWithDeclaration is null)
                {
                    return true;
                }
            }

            return IsMethodUsedByAnyTestMethods(method, testMethodsWithDeclaration);
        }

        private static bool IsMethodUsedByAnyTestMethods(
            MethodInfo method,
            Tuple<MethodInfo, MethodDeclaration>[] testMethodsWithDeclaration)
        {
            // ReSharper disable once LoopCanBeConvertedToQuery
            foreach (var tuple in testMethodsWithDeclaration)
            {
                var astNodeForTestMethod = DecompilerMethodHelper.GetAstNodeForMethod(method, tuple.Item2);
                if (astNodeForTestMethod is null)
                {
                    continue;
                }

                if (IsMethodUsedByTestMethod(method, astNodeForTestMethod, testMethodsWithDeclaration))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool IsMethodUsedByTestMethod(
            MethodInfo method,
            Tuple<AstNode, List<AstNode>> astNodeForTestMethodAndParameters,
            Tuple<MethodInfo, MethodDeclaration>[] testMethodsWithDeclaration)
        {
            if (method.DeclaringType is null)
            {
                throw new Exception("method.DeclaringType is null...");
            }

            var parameters = method.GetParameters();
            if (parameters.Any())
            {
                if (method.IsDefined(typeof(ExtensionAttribute)))
                {
                    return ParametersNamingMatchHelper.Extension(parameters, astNodeForTestMethodAndParameters);
                }

                if (method.DeclaringType is not null && method.DeclaringType.IsGenericType)
                {
                    return ParametersNamingMatchHelper.Generic(parameters, astNodeForTestMethodAndParameters);
                }

                return ParametersNamingMatchHelper.Regular(parameters, astNodeForTestMethodAndParameters);
            }

            // ReSharper disable once LoopCanBeConvertedToQuery
            foreach (var tuple in testMethodsWithDeclaration)
            {
                var astNodeForMethod = DecompilerMethodHelper.GetAstNodeForMethod(tuple.Item2.Body, method.Name);
                if (astNodeForMethod is not null)
                {
                    return true;
                }
            }

            return false;
        }
    }
}