using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using ICSharpCode.Decompiler.CSharp.Syntax;

namespace Atc.XUnit.Internal.AbstractSyntaxTree
{
    internal static class DecompilerMethodHelper
    {
        internal static Tuple<MethodInfo, MethodDeclaration>[] DebugFilterTypeNames(DebugLimitData debugLimitData, Tuple<MethodInfo, MethodDeclaration>[] testMethodsWithDeclaration)
        {
            if (!debugLimitData.HasClassNames)
            {
                return testMethodsWithDeclaration;
            }

            var list = new List<Tuple<MethodInfo, MethodDeclaration>>();
            foreach (var testMethodWithDeclaration in testMethodsWithDeclaration)
            {
                // ReSharper disable once ForeachCanBePartlyConvertedToQueryUsingAnotherGetEnumerator
                // ReSharper disable once UseDeconstruction
                foreach (var classMethodNames in debugLimitData.ClassMethodNames)
                {
                    if (!testMethodWithDeclaration.Item1.DeclaringType!.BeautifyName(false, false, true).StartsWith(classMethodNames.Item1, StringComparison.Ordinal))
                    {
                        continue;
                    }

                    if (classMethodNames.Item2 == null)
                    {
                        list.Add(testMethodWithDeclaration);
                    }
                    else
                    {
                        // ReSharper disable once ForeachCanBeConvertedToQueryUsingAnotherGetEnumerator
                        foreach (string methodName in classMethodNames.Item2)
                        {
                            var astNodeForMethod = GetAstNodeForMethod(testMethodWithDeclaration.Item2.Body, methodName);
                            if (astNodeForMethod != null)
                            {
                                list.Add(testMethodWithDeclaration);
                            }
                        }
                    }
                }
            }

            return list.ToArray();
        }

        [SuppressMessage("StyleCop.CSharp.SpacingRules", "SA1011:Closing square brackets should be spaced correctly", Justification = "OK.")]
        internal static Tuple<MethodInfo, MethodDeclaration>[]? DebugFilterMethod(DebugLimitData debugLimitData, MethodInfo method, Tuple<MethodInfo, MethodDeclaration>[] testMethodsWithDeclaration)
        {
            if (!debugLimitData.HasClassNames)
            {
                return testMethodsWithDeclaration;
            }

            var list = new List<Tuple<MethodInfo, MethodDeclaration>>();

            // ReSharper disable once UseDeconstruction
            foreach (var classMethodsNames in debugLimitData.ClassMethodNames)
            {
                foreach (var testMethodWithDeclaration in testMethodsWithDeclaration)
                {
                    if (!testMethodWithDeclaration.Item1.DeclaringType!.BeautifyName(false, false, true).StartsWith(classMethodsNames.Item1, StringComparison.Ordinal))
                    {
                        continue;
                    }

                    if (classMethodsNames.Item2 == null)
                    {
                        list.Add(testMethodWithDeclaration);
                    }
                    else
                    {
                        // ReSharper disable once ForeachCanBeConvertedToQueryUsingAnotherGetEnumerator
                        foreach (string methodName in classMethodsNames.Item2)
                        {
                            if (!methodName.Equals(method.Name, StringComparison.Ordinal))
                            {
                                continue;
                            }

                            var astNodeForMethod = GetAstNodeForMethod(testMethodWithDeclaration.Item2.Body, methodName);

                            // ReSharper disable once InvertIf
                            if (astNodeForMethod != null)
                            {
                                list.Add(testMethodWithDeclaration);
                            }
                        }
                    }
                }
            }

            return list.Count == 0
                ? null
                : list.ToArray();
        }

        [SuppressMessage("StyleCop.CSharp.SpacingRules", "SA1011:Closing square brackets should be spaced correctly", Justification = "OK.")]
        internal static Tuple<MethodInfo, MethodDeclaration>[]? FilterTestMethods(MethodInfo method, Tuple<MethodInfo, MethodDeclaration>[]? testMethodsWithDeclaration)
        {
            if (method.DeclaringType == null ||
                testMethodsWithDeclaration == null ||
                testMethodsWithDeclaration.Length == 0)
            {
                return null;
            }

            Tuple<MethodInfo, MethodDeclaration>[] tuples;
            if (method.HasDeclaringTypeValidationAttributes())
            {
                tuples = testMethodsWithDeclaration
                    .Where(x => x.Item1.DeclaringType != null &&
                                x.Item1.DeclaringType.Name.EndsWith("AttributesTests", StringComparison.Ordinal))
                    .ToArray();
            }
            else
            {
                string mn = method.DeclaringType.BeautifyName().Replace("<T>", string.Empty, StringComparison.Ordinal);
                tuples = testMethodsWithDeclaration
                    .Where(x => x.Item1.DeclaringType != null &&
                                x.Item1.DeclaringType.Name.StartsWith(mn, StringComparison.Ordinal))
                    .ToArray();
            }

            return tuples;
        }

        internal static Tuple<AstNode, List<AstNode>>? GetAstNodeForMethod(MethodInfo method, MethodDeclaration declaration)
        {
            var astNodeForMethodWithParameters = GetAstNodeForMethodWithParameters(declaration.Body, method.Name);
            if (astNodeForMethodWithParameters == null)
            {
                return null;
            }

            var astNodeForMethodParameters = GetAstNodesForMethodParameters(astNodeForMethodWithParameters);
            return new Tuple<AstNode, List<AstNode>>(
                astNodeForMethodWithParameters,
                astNodeForMethodParameters);
        }

        internal static AstNode? GetAstNodeForMethod(AstNode astNode, string methodName)
        {
            return astNode.Descendants
                .Where(x => x.IsType(typeof(InvocationExpression)))
                .Select(node => node.Descendants.FirstOrDefault(x => x.IsType(typeof(Identifier)) && x.ToString() == methodName))
                .FirstOrDefault(x => x != null);
        }

        internal static AstNode? GetAstNodeForParameter(AstNode astNode, string parameterName)
        {
            return astNode.Descendants
                .Where(x => x.IsType(typeof(ParameterDeclaration)) ||
                            x.IsType(typeof(VariableInitializer)) ||
                            x.IsType(typeof(MemberReferenceExpression)))
                .Select(node => node.Descendants.FirstOrDefault(x => x.ToString() == parameterName))
                .FirstOrDefault(x => x != null);
        }

        internal static string? GetTestMethodCode(AstNode astNode)
        {
            return GetAstNodeForTestMethodCode(astNode)?.ToString();
        }

        internal static AstNode? GetAstNodeForTestMethodCode(AstNode astNode)
        {
            string s = astNode.ToString();
            bool stopRecursive = astNode.Parent == null ||
                                 s.StartsWith("[Fact]", StringComparison.Ordinal) ||
                                 s.StartsWith("[Theory]", StringComparison.Ordinal);
            if (stopRecursive)
            {
                return astNode;
            }

            return astNode.Parent == null
                ? null
                : GetAstNodeForTestMethodCode(astNode.Parent);
        }

        internal static AstNode? GetAstNodeForMethodWithParameters(AstNode astNode, string methodName)
        {
            return GetAstNodeForMethod(astNode, methodName)?.Parent.Parent;
        }

        internal static List<AstNode> GetAstNodesForMethodParameters(AstNode astNode)
        {
            if (astNode.ToString().EndsWith(" ()", StringComparison.Ordinal))
            {
                return new List<AstNode>();
            }

            return astNode.DescendantsAndSelf
                .Where(x => (x.IsType(typeof(IdentifierExpression)) ||
                             x.IsType(typeof(PrimitiveExpression)) ||
                             x.IsType(typeof(NullReferenceExpression)) ||
                             (x.IsType(typeof(MemberReferenceExpression)) && x != astNode.FirstChild)) &&
                            !x.Parent.ToString().StartsWith(x + ".", StringComparison.Ordinal))
                .ToList();
        }
    }
}