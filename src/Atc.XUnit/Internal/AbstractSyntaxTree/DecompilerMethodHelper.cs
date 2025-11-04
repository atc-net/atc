namespace Atc.XUnit.Internal.AbstractSyntaxTree;

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
                if (!testMethodWithDeclaration.Item1.DeclaringType!
                        .BeautifyName(useFullName: false, useHtmlFormat: false, useGenericParameterNamesAsT: true)
                        .StartsWith(classMethodNames.Item1, StringComparison.Ordinal))
                {
                    continue;
                }

                if (classMethodNames.Item2 is null)
                {
                    list.Add(testMethodWithDeclaration);
                }
                else
                {
                    // ReSharper disable once ForeachCanBeConvertedToQueryUsingAnotherGetEnumerator
                    foreach (var methodName in classMethodNames.Item2)
                    {
                        var astNodeForMethod = GetAstNodeForMethod(testMethodWithDeclaration.Item2.Body, methodName);
                        if (astNodeForMethod is not null)
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
                if (!testMethodWithDeclaration.Item1.DeclaringType!
                        .BeautifyName(useFullName: false, useHtmlFormat: false, useGenericParameterNamesAsT: true)
                        .StartsWith(classMethodsNames.Item1, StringComparison.Ordinal))
                {
                    continue;
                }

                if (classMethodsNames.Item2 is null)
                {
                    list.Add(testMethodWithDeclaration);
                }
                else
                {
                    // ReSharper disable once ForeachCanBeConvertedToQueryUsingAnotherGetEnumerator
                    foreach (var methodName in classMethodsNames.Item2)
                    {
                        if (!methodName.Equals(method.Name, StringComparison.Ordinal))
                        {
                            continue;
                        }

                        var astNodeForMethod = GetAstNodeForMethod(testMethodWithDeclaration.Item2.Body, methodName);

                        // ReSharper disable once InvertIf
                        if (astNodeForMethod is not null)
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
        if (method.DeclaringType is null ||
            testMethodsWithDeclaration is null ||
            testMethodsWithDeclaration.Length == 0)
        {
            return null;
        }

        Tuple<MethodInfo, MethodDeclaration>[] tuples;
        if (method.HasDeclaringTypeValidationAttributes())
        {
            tuples = testMethodsWithDeclaration
                .Where(x => x.Item1.DeclaringType is not null &&
                            x.Item1.DeclaringType.Name.EndsWith("AttributesTests", StringComparison.Ordinal))
                .ToArray();
        }
        else
        {
            var mn = method.DeclaringType.BeautifyName().Replace("<T>", string.Empty, StringComparison.Ordinal);
            tuples = testMethodsWithDeclaration
                .Where(x => x.Item1.DeclaringType is not null &&
                            x.Item1.DeclaringType.Name.StartsWith(mn, StringComparison.Ordinal))
                .ToArray();

            // If no exact match found, try without common suffixes like "Factory", "Helper", etc.
            if (tuples.Length == 0)
            {
                var mnWithoutSuffix = mn.Replace("Factory", string.Empty, StringComparison.Ordinal)
                                        .Replace("Helper", string.Empty, StringComparison.Ordinal);
                if (mnWithoutSuffix != mn)
                {
                    tuples = testMethodsWithDeclaration
                        .Where(x => x.Item1.DeclaringType is not null &&
                                    x.Item1.DeclaringType.Name.StartsWith(mnWithoutSuffix, StringComparison.Ordinal))
                        .ToArray();
                }
            }
        }

        return tuples;
    }

    internal static Tuple<AstNode, List<AstNode>>? GetAstNodeForMethod(MethodInfo method, MethodDeclaration declaration)
    {
        var astNodeForMethodWithParameters = GetAstNodeForMethodWithParameters(declaration.Body, method.Name);
        if (astNodeForMethodWithParameters is null)
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
            .Select(node => node.Descendants.FirstOrDefault(x => x.IsType(typeof(Identifier)) && string.Equals(x.ToString(), methodName, StringComparison.Ordinal)))
            .FirstOrDefault(x => x is not null);
    }

    internal static AstNode? GetAstNodeForParameter(AstNode astNode, string parameterName)
    {
        return astNode.Descendants
            .Where(x => x.IsType(typeof(ParameterDeclaration)) ||
                        x.IsType(typeof(VariableInitializer)) ||
                        x.IsType(typeof(MemberReferenceExpression)))
            .Select(node => node.Descendants.FirstOrDefault(x => string.Equals(x.ToString(), parameterName, StringComparison.Ordinal)))
            .FirstOrDefault(x => x is not null);
    }

    internal static string? GetTestMethodCode(AstNode astNode)
    {
        return GetAstNodeForTestMethodCode(astNode)?.ToString();
    }

    internal static AstNode? GetAstNodeForTestMethodCode(AstNode astNode)
    {
        var s = astNode.ToString();
        var stopRecursive = astNode.Parent is null ||
                            s.StartsWith("[Fact]", StringComparison.Ordinal) ||
                            s.StartsWith("[Theory]", StringComparison.Ordinal);
        if (stopRecursive)
        {
            return astNode;
        }

        return astNode.Parent is null
            ? null
            : GetAstNodeForTestMethodCode(astNode.Parent);
    }

    internal static AstNode? GetAstNodeForMethodWithParameters(AstNode astNode, string methodName)
    {
        return GetAstNodeForMethod(astNode, methodName)?.Parent?.Parent;
    }

    internal static List<AstNode> GetAstNodesForMethodParameters(AstNode astNode)
    {
        if (astNode.ToString().EndsWith(" ()", StringComparison.Ordinal))
        {
            return new List<AstNode>();
        }

        // Check if there are complex expressions (DirectionExpression or ObjectCreateExpression) as direct children
        // If so, we need to extract from direct children to get these nodes properly
        var hasComplexExpressions = astNode.Children
            .Any(x => x.IsType(typeof(DirectionExpression)) || x.IsType(typeof(ObjectCreateExpression)));

        if (hasComplexExpressions)
        {
            // Extract all direct child arguments (both complex and simple)
            // Skip the first child which is the method reference (MemberReferenceExpression)
            var directArguments = astNode.Children
                .Skip(1)
                .Where(x => x.IsType(typeof(InvocationExpression)) ||
                            x.IsType(typeof(ObjectCreateExpression)) ||
                            x.IsType(typeof(DirectionExpression)) ||
                            x.IsType(typeof(IdentifierExpression)) ||
                            x.IsType(typeof(PrimitiveExpression)) ||
                            x.IsType(typeof(NullReferenceExpression)) ||
                            x.IsType(typeof(MemberReferenceExpression)))
                .ToList();

            if (directArguments.Count > 0)
            {
                return directArguments;
            }
        }

        // Original logic: Extract simple parameters from descendants, avoiding nested invocations
        var potentialParams = astNode.DescendantsAndSelf
            .Where(x => (x.IsType(typeof(IdentifierExpression)) ||
                         x.IsType(typeof(PrimitiveExpression)) ||
                         x.IsType(typeof(NullReferenceExpression)) ||
                         (x.IsType(typeof(MemberReferenceExpression)) && x != astNode.FirstChild)) &&
                        (x.Parent is not null && !x.Parent.ToString().StartsWith(x + ".", StringComparison.Ordinal)))
            .ToList();

        // If we didn't find simple parameters, check if the arguments are invocation expressions
        if (potentialParams.Count == 0 || AllParamsArePartOfInvocations(potentialParams))
        {
            // Find top-level invocation expressions or complex expressions that are direct arguments
            // Skip the first child which is typically the method reference
            var complexExpressions = astNode.Children
                .Skip(1) // Skip the method reference
                .Where(x => x.IsType(typeof(InvocationExpression)) ||
                            x.IsType(typeof(ObjectCreateExpression)) ||
                            x.IsType(typeof(DirectionExpression)))
                .ToList();

            if (complexExpressions.Count > 0)
            {
                return complexExpressions;
            }
        }

        return potentialParams;
    }

    private static bool AllParamsArePartOfInvocations(List<AstNode> parameters)
    {
        // Check if all parameters are part of invocation expressions
        // This indicates the parameters are method call results
        return parameters.All(p => p.Ancestors.Any(a => a.IsType(typeof(InvocationExpression))));
    }
}