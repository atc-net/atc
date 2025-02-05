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

        if (parameters.Length != astNodeForTestParameters.Count)
        {
            return false;
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

        if (filteredParameters.Length != filteredAstParameters.Count)
        {
            return false;
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

        var astNodeName = astNode.ToString();
        var typeName = FindTypeNameForIdentifierExpressionInTestMethodScope(astNode.Parent!, astNodeName) ??
                       FindTypeNameForIdentifierExpressionOutsideMethodScope(astNode.GetRoot(), astNodeName);

        if (typeName is not null &&
            HasParameterTypeNameMatch(parameter, typeName))
        {
            return true;
        }

        return false;
    }

    private static bool ParameterCheckForMemberReferenceExpression(ParameterInfo parameter, AstNode astNode)
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

    private static bool ParameterCheckForPrimitiveExpression(ParameterInfo parameter, AstNode astNode)
    {
        if (!astNode.IsType(typeof(PrimitiveExpression)))
        {
            return false;
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

        return false;
    }

    private static bool ParameterCheckForNullReferenceExpression(ParameterInfo parameter, AstNode astNode)
    {
        if (!astNode.IsType(typeof(NullReferenceExpression)))
        {
            return false;
        }

        return parameter.ParameterType.IsNullable();
    }

    private static string? FindTypeNameForIdentifierExpressionInTestMethodScope(AstNode astNode, string parameterName)
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

    private static string? FindTypeNameForIdentifierExpressionOutsideMethodScope(AstNode astNode, string parameterName)
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

    private static bool HasParameterTypeNameMatch(ParameterInfo methodParameter, string testParameterTypeName)
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
            return methodParameterTypeName.Equals("I" + testParameterTypeName, StringComparison.Ordinal);
        }

        if (methodParameter.ParameterType.IsAbstract)
        {
            return testParameterTypeName.EndsWith(methodParameterTypeName, StringComparison.Ordinal);
        }

        if (methodParameterTypeName.Equals(testParameterTypeName, StringComparison.Ordinal) ||
            methodParameter.ParameterType.FullName!.Equals(testParameterTypeName, StringComparison.Ordinal))
        {
            return true;
        }

        return false;
    }
}