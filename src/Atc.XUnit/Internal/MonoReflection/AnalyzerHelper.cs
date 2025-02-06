namespace Atc.XUnit.Internal.MonoReflection;

internal static class AnalyzerHelper
{
    [SuppressMessage("Usage", "CA2201:Do not raise reserved exception types", Justification = "OK.")]
    public static MethodInfo[] GetSourceMethodsWithMissingTest(
        Type[] sourceTypes,
        MethodInfo[] usedSourceMethods,
        DebugLimitData? debugLimitData)
    {
        if (debugLimitData is not null)
        {
            sourceTypes = TypeAndMethodAndParameterHelper.DebugFilterTypeNames(debugLimitData, sourceTypes);
            usedSourceMethods = DebugFilterTypeNames(debugLimitData, usedSourceMethods);
        }

        var methodsWithTest = new List<MethodInfo>();
        var methodsToExclude = new List<MethodInfo>();

        // ReSharper disable once InvertIf
        if (usedSourceMethods.Length > 0)
        {
            foreach (var sourceType in sourceTypes)
            {
                if (sourceType.HasValidationAttributes())
                {
                    HandleSourceTypeWithValidationAttribute(sourceType, usedSourceMethods, methodsWithTest, methodsToExclude);
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

                        if (IsMethodUsed(method, usedSourceMethods, debugLimitData))
                        {
                            methodsWithTest.Add(method);
                        }
                        else if (debugLimitData is not null)
                        {
                            // Dummy for breakpoint
                            throw new Exception("Ups..");
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

    internal static MethodInfo[] GetUsedSourceMethods(
        Type[] sourceTypes,
        Tuple<Type, MethodInfo[]>[] testTypeMethods)
    {
        var list = new List<MethodInfo>();
        foreach (var tuple in testTypeMethods)
        {
            foreach (var method in tuple.Item2)
            {
                var instructions = method.GetInstructions();
                foreach (var instruction in instructions)
                {
                    if (instruction.Operand is not MethodInfo usedMethodInTest)
                    {
                        continue;
                    }

                    var type = usedMethodInTest.DeclaringType;
                    if (sourceTypes.FirstOrDefault(x => x.BeautifyName().Equals(type!.BeautifyName(useFullName: false, useHtmlFormat: false, useGenericParameterNamesAsT: true), StringComparison.Ordinal)) is null)
                    {
                        continue;
                    }

                    if (usedMethodInTest.Name.StartsWith("get_", StringComparison.Ordinal) ||
                        usedMethodInTest.Name.StartsWith("set_", StringComparison.Ordinal))
                    {
                        continue;
                    }

                    if (!list.Contains(usedMethodInTest))
                    {
                        list.Add(usedMethodInTest);
                    }
                }
            }
        }

        return list
            .OrderBy(x => x.DeclaringType?.Name, StringComparer.Ordinal)
            .ThenBy(x => x.Name, StringComparer.Ordinal)
            .ToArray();
    }

    private static bool IsMethodUsed(
        MethodInfo method,
        MethodInfo[] usedSourceMethods,
        DebugLimitData? debugLimitData)
    {
        // ReSharper disable once InvertIf
        if (debugLimitData is not null && debugLimitData.HasClassNames)
        {
            var notFound = debugLimitData.ClassMethodNames
                .Where(x => x.Item2 is not null)
                .All(x => !x.Item2.Exists(m => method.BeautifyName().Equals(m, StringComparison.Ordinal)));

            if (notFound)
            {
                return true;
            }
        }

        var isEqual = usedSourceMethods.Any(x =>
            x.DeclaringType!.GetNameWithoutGenericType(useFullName: true)!.Equals(
                method.DeclaringType!.GetNameWithoutGenericType(useFullName: true),
                StringComparison.Ordinal) &&
            x.BeautifyName().Equals(method.BeautifyName(), StringComparison.Ordinal));
        if (isEqual)
        {
            return true;
        }

        var methodParameters = method.GetParameters();
        var usedMethodsByDeclaredType = usedSourceMethods
            .Where(x => string.Equals(
                x.DeclaringType!.BeautifyName(useFullName: false, useHtmlFormat: false, useGenericParameterNamesAsT: true),
                method.DeclaringType!.BeautifyName(useGenericParameterNamesAsT: true),
                StringComparison.Ordinal))
            .ToList();
        if (usedMethodsByDeclaredType.Count == 0)
        {
            return false;
        }

        var usedMethods = usedMethodsByDeclaredType.Where(x => x.Name.Equals(method.Name, StringComparison.Ordinal)).ToList();
        if (usedMethods.Count == 0)
        {
            return false;
        }

        // ReSharper disable once ForeachCanBeConvertedToQueryUsingAnotherGetEnumerator
        foreach (var usedMethod in usedMethods)
        {
            var usedMethodParameters = usedMethod.GetParameters();
            if (((method.ReturnType.IsGenericParameter && usedMethod.ReturnType != typeof(void)) ||
                 usedMethod.ReturnType == method.ReturnType) &&
                usedMethodParameters.Length == methodParameters.Length)
            {
                return !usedMethodParameters.Where((t, i) => !t.Name!.Equals(methodParameters[i].Name, StringComparison.Ordinal)).Any();
            }
        }

        return false;
    }

    private static MethodInfo[] DebugFilterTypeNames(DebugLimitData debugLimitData, MethodInfo[] usedSourceMethods)
    {
        if (!debugLimitData.HasClassNames)
        {
            return usedSourceMethods;
        }

        var list = new List<MethodInfo>();
        foreach (var usedSourceMethod in usedSourceMethods)
        {
            // ReSharper disable once ForeachCanBePartlyConvertedToQueryUsingAnotherGetEnumerator
            // ReSharper disable once UseDeconstruction
            foreach (var classMethodNames in debugLimitData.ClassMethodNames)
            {
                if (!usedSourceMethod.DeclaringType!
                        .BeautifyName(useFullName: false, useHtmlFormat: false, useGenericParameterNamesAsT: true)
                        .Equals(classMethodNames.Item1, StringComparison.Ordinal))
                {
                    continue;
                }

                if (classMethodNames.Item2 is null)
                {
                    list.Add(usedSourceMethod);
                }
                else
                {
                    // ReSharper disable once ForeachCanBeConvertedToQueryUsingAnotherGetEnumerator
                    foreach (var methodName in classMethodNames.Item2)
                    {
                        if (usedSourceMethod.BeautifyName().Equals(methodName, StringComparison.Ordinal))
                        {
                            list.Add(usedSourceMethod);
                        }
                    }
                }
            }
        }

        return list.ToArray();
    }

    private static void HandleSourceTypeWithValidationAttribute(
        Type sourceType,
        MethodInfo[] usedSourceMethods,
        ICollection<MethodInfo> methodsWithTest,
        ICollection<MethodInfo> methodsToExclude)
    {
        var methods = sourceType.GetPublicDeclaredOnlyMethods();
        foreach (var method in methods)
        {
            if (method.Name.Equals("IsValid", StringComparison.Ordinal))
            {
                if (!usedSourceMethods.Contains(method))
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
}