// ReSharper disable ConvertIfStatementToReturnStatement
namespace Atc.XUnit.Internal;

internal static class TypeAndMethodAndParameterHelper
{
    private static readonly List<string> ListModuleScopeNamesToExclude = new()
    {
        typeof(Exception).Module.ScopeName,
    };

    internal static Type[] DebugFilterTypeNames(DebugLimitData debugLimitData, Type[] sourceTypes)
    {
        if (!debugLimitData.HasClassNames)
        {
            return sourceTypes;
        }

        return (from sourceType
                    in sourceTypes
                from classMethodNames
                    in debugLimitData.ClassMethodNames
                where sourceType.BeautifyName().Equals(classMethodNames.Item1, StringComparison.Ordinal)
                select sourceType)
            .OrderBy(x => x.Name, StringComparer.Ordinal)
            .ToArray();
    }

    [SuppressMessage("Design", "MA0051:Method is too long", Justification = "OK.")]
    internal static string GetDebugMethodInfo(MethodInfo method)
    {
        var debugMethodInfo = $"{method.DeclaringType?.BeautifyName()} # {method.BeautifyName(useFullName: false, useHtmlFormat: false, includeReturnType: true)}";
        var c1 = method.DeclaringType is not null && method.DeclaringType.IsGenericType;
        var c2 = method.DeclaringType is not null && method.DeclaringType.IsGenericTypeDefinition;
        var m1 = method.IsGenericMethod;
        var m2 = method.IsGenericMethodDefinition;
        int p1C = 0, p2C = 0, p3C = 0, p4C = 0, p5C = 0, p6C = 0;
        var parameters = method.GetParameters();
        if (parameters.Length > 0)
        {
            p1C = parameters.Count(x => x.IsIn);
            p2C = parameters.Count(x => x.IsOut);
            p3C = parameters.Count(x => x.IsRetval);
            p4C = parameters.Count(x => x.IsOptional);
            p5C = parameters.Count(x => x.ParameterType.IsAbstract);
            p6C = parameters.Count(x => x.ParameterType.IsInheritedFrom(typeof(Delegate)));
        }

        var sb = new StringBuilder();
        if (c1)
        {
            sb.Append(", GenericType");
        }

        if (c2)
        {
            sb.Append(", GenericTypeDefinition");
        }

        if (m1)
        {
            sb.Append(", GenericMethod");
        }

        if (m2)
        {
            sb.Append(", GenericMethodDefinition");
        }

        if (p1C > 0)
        {
            sb.Append(", In(");
            sb.Append(p1C.ToString(CultureInfo.InvariantCulture));
            sb.Append(')');
        }

        if (p2C > 0)
        {
            sb.Append(", Out(");
            sb.Append(p2C.ToString(CultureInfo.InvariantCulture));
            sb.Append(')');
        }

        if (p3C > 0)
        {
            sb.Append(", RetVal(");
            sb.Append(p3C.ToString(CultureInfo.InvariantCulture));
            sb.Append(')');
        }

        if (p4C > 0)
        {
            sb.Append(", Optional(");
            sb.Append(p4C.ToString(CultureInfo.InvariantCulture));
            sb.Append(')');
        }

        if (p5C > 0)
        {
            sb.Append(", IsAbstract(");
            sb.Append(p5C.ToString(CultureInfo.InvariantCulture));
            sb.Append(')');
        }

        if (p6C > 0)
        {
            sb.Append(", Delegate(");
            sb.Append(p6C.ToString(CultureInfo.InvariantCulture));
            sb.Append(')');
        }

        if (sb.Length > 0)
        {
            debugMethodInfo += sb;
        }

        return debugMethodInfo;
    }

    internal static Tuple<Type, MethodInfo[]>[] GetTypeMethodsWithTestAttributes(Type[] types)
    {
        return (
                from type
                    in types
                let methods = type.GetPublicDeclaredOnlyMethods()
                    .Where(x =>
                        x.IsDefined(typeof(FactAttribute)) ||
                        x.IsDefined(typeof(TheoryAttribute)))
                    .ToArray()
                where methods.Length > 0
                select new Tuple<Type, MethodInfo[]>(type, methods))
            .ToArray();
    }

    internal static bool ShouldMethodBeExcluded(MethodInfo method)
    {
        if (method.DeclaringType is not null &&
            ListModuleScopeNamesToExclude.Contains(method.DeclaringType.Module.ScopeName, StringComparer.OrdinalIgnoreCase))
        {
            return true;
        }

        if (method.HasExcludeFromCodeCoverageAttribute() ||
            method.HasCompilerGeneratedAttribute())
        {
            return true;
        }

        if (method.Name.StartsWith("get_", StringComparison.Ordinal) ||
            method.Name.StartsWith("set_", StringComparison.Ordinal) ||
            method.Name.StartsWith("op_", StringComparison.Ordinal) ||
            method.Name.StartsWith("add_", StringComparison.Ordinal) ||
            method.Name.StartsWith("remove_", StringComparison.Ordinal))
        {
            return true;
        }

        if ("Equals".Equals(method.Name, StringComparison.Ordinal) ||
            "GetHashCode".Equals(method.Name, StringComparison.Ordinal) ||
            "GetType".Equals(method.Name, StringComparison.Ordinal) ||
            "ToString".Equals(method.Name, StringComparison.Ordinal) ||
            "Dispose".Equals(method.Name, StringComparison.Ordinal))
        {
            return true;
        }

        return false;
    }

    internal static MethodInfo[] FilterMethodsWithMissingTests(Type[] sourceTypes, List<MethodInfo> methodsToExclude, List<MethodInfo> methodsWithTest)
    {
        var list = new List<MethodInfo>();

        // ReSharper disable once LoopCanBeConvertedToQuery
        foreach (var sourceType in sourceTypes.OrderBy(x => x.FullName, StringComparer.Ordinal))
        {
            // ReSharper disable once LoopCanBeConvertedToQuery
            foreach (var methodInfo in sourceType.GetPublicDeclaredOnlyMethods())
            {
                if (methodsToExclude.Contains(methodInfo) || methodsWithTest.Contains(methodInfo))
                {
                    continue;
                }

                list.Add(methodInfo);
            }
        }

        return list.ToArray();
    }
}