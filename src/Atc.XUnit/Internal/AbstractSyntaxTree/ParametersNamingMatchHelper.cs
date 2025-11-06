// ReSharper disable ConvertIfStatementToReturnStatement
// ReSharper disable InvertIf
// ReSharper disable UseDeconstructionOnParameter
namespace Atc.XUnit.Internal.AbstractSyntaxTree;

internal static class ParametersNamingMatchHelper
{
    private static readonly char[] AllowedCharsBeforeParameterNameSpace = { ',' };
    private static readonly char[] AllowedCharsAfterParameterName = { ' ', ',', ')', ';' };

    internal static bool Regular(
        ParameterInfo[] parameters,
        Tuple<AstNode, List<AstNode>> astNodeForTestMethodAndParameters)
    {
        var astNodeForTestParameters = astNodeForTestMethodAndParameters.Item2;
        if (parameters.Length != astNodeForTestMethodAndParameters.Item2.Count)
        {
            astNodeForTestParameters = DecompilerMethodHelper.GetAstNodesForMethodParameters(astNodeForTestMethodAndParameters.Item1);
        }

        // Handle optional parameters - allow fewer arguments if remaining parameters are optional
        if (parameters.Length != astNodeForTestParameters.Count)
        {
            // Count required (non-optional) parameters
            var requiredParamCount = parameters.Count(p => !p.IsOptional);

            // If we have fewer arguments than required parameters, it's a mismatch
            if (astNodeForTestParameters.Count < requiredParamCount)
            {
                return false;
            }

            // If we have more arguments than total parameters, it's a mismatch
            if (astNodeForTestParameters.Count > parameters.Length)
            {
                return false;
            }

            // If all extra parameters (beyond what was passed) are optional, it's a match
            // Just check the parameters that were actually passed
        }

        // ReSharper disable once LoopCanBeConvertedToQuery
        for (var i = 0; i < astNodeForTestParameters.Count; i++)
        {
            var parameter = parameters[i];
            var pc = ParameterCheck(parameter, i, astNodeForTestParameters);
            if (!pc)
            {
                return false;
            }
        }

        return true;
    }

    internal static bool Extension(
        ParameterInfo[] parameters,
        MethodInfo testMethod,
        Tuple<AstNode, List<AstNode>> astNodeForTestMethodAndParameters)
    {
        var filteredParameters = parameters.Where(x => !x.IsOut).Skip(1).ToArray();
        if (filteredParameters.Length == 0 &&
            parameters.Count(x => x.IsOut) == astNodeForTestMethodAndParameters.Item2.Count)
        {
            return true;
        }

        var filteredAstParameters = astNodeForTestMethodAndParameters
            .Item2
            .TakeLast(filteredParameters.Length)
            .ToList();

        // Handle optional parameters in extension methods
        if (filteredParameters.Length != filteredAstParameters.Count)
        {
            // Count required (non-optional) parameters
            var requiredParamCount = filteredParameters.Count(p => !p.IsOptional);

            // If we have fewer arguments than required parameters, it's a mismatch
            if (filteredAstParameters.Count < requiredParamCount)
            {
                return false;
            }

            // If we have more arguments than total parameters, it's a mismatch
            if (filteredAstParameters.Count > filteredParameters.Length)
            {
                return false;
            }
        }

        // ReSharper disable once LoopCanBeConvertedToQuery
        for (var i = 0; i < filteredAstParameters.Count; i++)
        {
            var parameter = filteredParameters[i];
            var pc = ParameterCheck(parameter, i, filteredAstParameters);
            if (!pc)
            {
                return false;
            }
        }

        return true;
    }

    internal static bool Generic(
        ParameterInfo[] parameters,
        Tuple<AstNode, List<AstNode>> astNodeForTestMethodAndParameters)
    {
        for (var i = 0; i < astNodeForTestMethodAndParameters.Item2.Count; i++)
        {
            var pc = false;
            if (i < parameters.Length)
            {
                var parameter = parameters[i];
                if (parameter.ParameterType.IsGenericType)
                {
                    return true;
                }

                pc = ParameterCheck(parameter, i, astNodeForTestMethodAndParameters.Item2);
            }

            if (!pc)
            {
                return false;
            }
        }

        return true;
    }

    private static bool ParameterCheck(
        ParameterInfo parameter,
        int astNodeForTestParameterIndex,
        IReadOnlyList<AstNode> astNodeForTestParameters)
    {
        // Check org-parameter-name in test-method-parameters
        var astNode = astNodeForTestParameters.FirstOrDefault(x => parameter.Name!.Equals(x.ToString(), StringComparison.Ordinal));
        if (astNode is not null)
        {
            return true;
        }

        astNode = astNodeForTestParameters[astNodeForTestParameterIndex];

        if (ParameterCheckForMemberReferenceExpression(parameter, astNode))
        {
            return true;
        }

        if (ParameterCheckForPrimitiveExpression(parameter, astNode))
        {
            return true;
        }

        if (ParameterCheckForNullReferenceExpression(parameter, astNode))
        {
            return true;
        }

        if (ParameterCheckForInvocationExpression(parameter, astNode))
        {
            return true;
        }

        if (ParameterCheckForObjectCreateExpression(parameter, astNode))
        {
            return true;
        }

        if (ParameterCheckForDirectionExpression(parameter, astNode))
        {
            return true;
        }

        if (ParameterCheckForCastExpression(parameter, astNode))
        {
            return true;
        }

        // Check for lambda expressions early, before other type checks
        // This handles Func<>, Action<>, and other delegate parameters
        var astNodeString = astNode.ToString();
        if (astNodeString.Contains("=>", StringComparison.Ordinal) && IsDelegateParameter(parameter))
        {
            return true;
        }

        return ParameterCheckForIdentifierWithTypeMatching(parameter, astNode, astNodeString);
    }

    private static bool ParameterCheckForIdentifierWithTypeMatching(
        ParameterInfo parameter,
        AstNode astNode,
        string astNodeName)
    {
        var typeName = FindTypeNameForIdentifierExpressionInTestMethodScope(astNode.Parent!, astNodeName) ??
                       FindTypeNameForIdentifierExpressionOutsideMethodScope(astNode.GetRoot(), astNodeName);

        return typeName is not null && HasParameterTypeNameMatch(parameter, typeName);
    }

    private static bool ParameterCheckForMemberReferenceExpression(
        ParameterInfo parameter,
        AstNode astNode)
    {
        if (!astNode.IsType(typeof(MemberReferenceExpression)))
        {
            return false;
        }

        var astNodeTypeReferenceExpression = astNode.GetFirstOrDefaultByExpressionType(typeof(TypeReferenceExpression));
        if (astNodeTypeReferenceExpression is null)
        {
            var astNodeIdentifierExpression = astNode.GetFirstOrDefaultByExpressionType(typeof(IdentifierExpression));
            if (astNodeIdentifierExpression is null)
            {
                return false;
            }

            var astNodeIdentifier = astNode.Children.First(x => x.IsType(typeof(Identifier)));
            var identifierTypeName =
                FindTypeNameForIdentifierExpressionInTestMethodScope(
                    astNodeIdentifierExpression.Parent!,
                    astNodeIdentifierExpression.ToString()) ??
                FindTypeNameForIdentifierExpressionOutsideMethodScope(
                    astNodeIdentifierExpression.GetRoot(),
                    astNodeIdentifierExpression.ToString());
            if (identifierTypeName is not null)
            {
                var propertyType = AppDomain.CurrentDomain.GetExportedPropertyTypeByName(
                    identifierTypeName,
                    astNodeIdentifier.ToString());
                if (propertyType is not null &&
                    parameter.ParameterType == propertyType)
                {
                    return true;
                }
            }
        }
        else
        {
            var astNodeTypeName = astNodeTypeReferenceExpression.ToString();
            if (parameter.ParameterType.Name.Equals(astNodeTypeName, StringComparison.Ordinal))
            {
                return true;
            }

            if (astNodeTypeName.Contains("Constants", StringComparison.Ordinal))
            {
                return true;
            }
        }

        return false;
    }

    private static bool ParameterCheckForPrimitiveExpression(
        ParameterInfo parameter,
        AstNode astNode)
    {
        if (!astNode.IsType(typeof(PrimitiveExpression)))
        {
            return false;
        }

        // For generic type parameters (like TKey, TValue), accept any primitive expression
        // since we can't determine the concrete type at compile time
        if (parameter.ParameterType.IsGenericParameter)
        {
            return true;
        }

        var astNodeName = astNode.ToString();
        if (parameter.ParameterType == typeof(bool) &&
            ("true".Equals(astNodeName, StringComparison.Ordinal) ||
             "false".Equals(astNodeName, StringComparison.Ordinal)))
        {
            return true;
        }

        if (parameter.ParameterType == typeof(string) &&
            astNodeName.StartsWith('"') &&
            astNodeName.EndsWith('"'))
        {
            return true;
        }

        // Handle numeric types (int, long, short, byte, uint, ulong, ushort, sbyte, decimal, float, double)
        if (parameter.ParameterType.IsPrimitive || parameter.ParameterType == typeof(decimal))
        {
            // For primitive numeric types, any numeric literal in the AST can match
            // We don't need to validate the actual value, just that it's a numeric literal
            return true;
        }

        return false;
    }

    private static bool ParameterCheckForNullReferenceExpression(
        ParameterInfo parameter,
        AstNode astNode)
    {
        if (!astNode.IsType(typeof(NullReferenceExpression)))
        {
            return false;
        }

        return parameter.ParameterType.IsNullable();
    }

    private static bool ParameterCheckForInvocationExpression(
        ParameterInfo parameter,
        AstNode astNode)
    {
        if (!astNode.IsType(typeof(InvocationExpression)))
        {
            return false;
        }

        // Accept invocation expressions (method calls) as valid parameters for complex reference types
        // This handles cases like SyntaxFactory.IdentifierName("foo") being passed as ExpressionSyntax parameter
        if (!parameter.ParameterType.IsPrimitive &&
            parameter.ParameterType != typeof(string) &&
            !parameter.ParameterType.IsValueType)
        {
            return true;
        }

        return false;
    }

    private static bool ParameterCheckForObjectCreateExpression(
        ParameterInfo parameter,
        AstNode astNode)
    {
        if (!astNode.IsType(typeof(ObjectCreateExpression)))
        {
            return false;
        }

        // Accept object creation expressions like new CultureInfo(...) for reference type parameters
        // This handles cases like new CultureInfo(cultureInfoLcid) being passed as CultureInfo parameter
        if (!parameter.ParameterType.IsPrimitive &&
            parameter.ParameterType != typeof(string) &&
            !parameter.ParameterType.IsValueType)
        {
            return true;
        }

        return false;
    }

    private static bool ParameterCheckForDirectionExpression(
        ParameterInfo parameter,
        AstNode astNode)
    {
        if (!astNode.IsType(typeof(DirectionExpression)))
        {
            return false;
        }

        // Accept direction expressions (out/ref parameters) for any parameter type
        // This handles cases like out _ or out var result
        return parameter.IsOut || parameter.ParameterType.IsByRef;
    }

    private static bool ParameterCheckForCastExpression(
        ParameterInfo parameter,
        AstNode astNode)
    {
        if (!astNode.IsType(typeof(CastExpression)))
        {
            return false;
        }

        // CastExpression might wrap a lambda, so check its content
        var astNodeString = astNode.ToString();
        if (astNodeString.Contains("=>", StringComparison.Ordinal) && IsDelegateParameter(parameter))
        {
            return true;
        }

        // Accept cast expressions for reference types
        return !parameter.ParameterType.IsPrimitive &&
               parameter.ParameterType != typeof(string) &&
               !parameter.ParameterType.IsValueType;
    }

    private static bool IsDelegateParameter(ParameterInfo parameter)
    {
        // Check if parameter is a delegate type
        // 1. Generic type parameters (might be delegates)
        if (parameter.ParameterType.IsGenericParameter)
        {
            return true;
        }

        // 2. Constructed generic types with generic type arguments (like Func<TKey, TValue>)
        if (parameter.ParameterType.IsGenericType)
        {
            var genericArgs = parameter.ParameterType.GetGenericArguments();
            if (genericArgs.Any(arg => arg.IsGenericParameter))
            {
                // This is a generic type like Func<TKey, TValue> where TKey/TValue are generic parameters
                var typeName = parameter.ParameterType.Name;
                if (typeName.StartsWith("Func`", StringComparison.Ordinal) ||
                    typeName.StartsWith("Action`", StringComparison.Ordinal))
                {
                    return true;
                }
            }
        }

        // 3. Func<> and Action<> types (check by name for generic delegates)
        var paramTypeName = parameter.ParameterType.Name;
        if (paramTypeName.StartsWith("Func`", StringComparison.Ordinal) ||
            paramTypeName.StartsWith("Action`", StringComparison.Ordinal) ||
            paramTypeName == "Func" ||
            paramTypeName == "Action")
        {
            return true;
        }

        // 4. Other delegate types
        if (typeof(Delegate).IsAssignableFrom(parameter.ParameterType))
        {
            return true;
        }

        return false;
    }

    private static string? FindTypeNameForIdentifierExpressionInTestMethodScope(
        AstNode astNode,
        string parameterName)
    {
        var s = astNode.ToString();
        var stopRecursive = astNode.Parent is null ||
                            s.StartsWith("[Fact]", StringComparison.Ordinal) ||
                            s.StartsWith("[Theory]", StringComparison.Ordinal);

        var index = s.IndexOf(" " + parameterName, StringComparison.Ordinal);
        if (index != -1 &&
            (index <= parameterName.Length + 1 ||
             !AllowedCharsBeforeParameterNameSpace.Contains(s[index - 1])))
        {
            var ix = index + 1 + parameterName.Length;
            if (ix < s.Length)
            {
                var c = s[ix];
                if (AllowedCharsAfterParameterName.Contains(c))
                {
                    var astNodeForParameter = DecompilerMethodHelper.GetAstNodeForParameter(astNode, parameterName);
                    if (astNodeForParameter is not null)
                    {
                        var tmp = astNodeForParameter.Parent?.FirstChild?.ToString().Trim() ?? string.Empty;
                        if (tmp.StartsWith('[') && tmp.EndsWith(']'))
                        {
                            // FirstChild is a DataAnnotation attribute, then take the next one
                            tmp = astNodeForParameter.Parent!.Children.ToArray()[1].ToString().Trim();
                        }
                        else if (string.Equals(tmp, parameterName, StringComparison.Ordinal))
                        {
                            tmp = astNodeForParameter.Parent!.Parent!.FirstChild!.ToString().Trim();
                        }

                        return tmp;
                    }
                }
            }
        }

        if (stopRecursive)
        {
            return null;
        }

        if (astNode.Parent is null)
        {
            return null;
        }

        return FindTypeNameForIdentifierExpressionInTestMethodScope(astNode.Parent, parameterName);
    }

    private static string? FindTypeNameForIdentifierExpressionOutsideMethodScope(
        AstNode astNode,
        string parameterName)
    {
        var foundAstNode = astNode.Descendants
            .FirstOrDefault(x =>
                x.IsType(typeof(VariableInitializer)) &&
                string.Equals((x as VariableInitializer)?.Name, parameterName, StringComparison.Ordinal));
        if (foundAstNode?.Parent is not null)
        {
            var sa = foundAstNode.Parent.Children.Select(x => x.ToString()).ToArray();
            for (var i = 1; i < sa.Length; i++)
            {
                if (string.Equals(sa[i], parameterName, StringComparison.Ordinal))
                {
                    return sa[i - 1];
                }
            }
        }

        return null;
    }

    private static bool HasParameterTypeNameMatch(
        ParameterInfo methodParameter,
        string testParameterTypeName)
    {
        if (methodParameter.Member.DeclaringType is not null && methodParameter.Member.DeclaringType.IsGenericType)
        {
            return !methodParameter.ParameterType.IsGenericType;
        }

        var methodParameterTypeName = methodParameter.ParameterType.BeautifyName();
        if ("T".Equals(methodParameterTypeName, StringComparison.Ordinal) ||
            "Enum".Equals(methodParameterTypeName, StringComparison.Ordinal))
        {
            return true;
        }

        if (methodParameter.ParameterType.IsNullable())
        {
            methodParameterTypeName = methodParameter.ParameterType.GetGenericArguments()[0].BeautifyName();
        }

        if (methodParameter.ParameterType.IsInterface)
        {
            // For generic interfaces, try exact match first
            if (methodParameterTypeName.Equals(testParameterTypeName, StringComparison.Ordinal))
            {
                return true;
            }

            // For non-generic interfaces, check if method param starts with "I" and matches test param
            return methodParameterTypeName.Equals("I" + testParameterTypeName, StringComparison.Ordinal);
        }

        if (methodParameter.ParameterType.IsAbstract)
        {
            return testParameterTypeName.EndsWith(methodParameterTypeName, StringComparison.Ordinal);
        }

        if (methodParameterTypeName.Equals(testParameterTypeName, StringComparison.Ordinal) ||
            (methodParameter.ParameterType.FullName is not null &&
             methodParameter.ParameterType.FullName.Equals(testParameterTypeName, StringComparison.Ordinal)))
        {
            return true;
        }

        return false;
    }
}