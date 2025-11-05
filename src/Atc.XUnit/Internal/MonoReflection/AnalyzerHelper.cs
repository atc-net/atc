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
                    ProcessInstruction(instruction, sourceTypes, list);
                }
            }
        }

        return list
            .OrderBy(x => x.DeclaringType?.Name, StringComparer.Ordinal)
            .ThenBy(x => x.Name, StringComparer.Ordinal)
            .ToArray();
    }

    private static void ProcessInstruction(
        Instruction instruction,
        Type[] sourceTypes,
        List<MethodInfo> list)
    {
        if (instruction.Operand is not MethodInfo usedMethodInTest)
        {
            return;
        }

        var type = usedMethodInTest.DeclaringType;
        if (type is null)
        {
            return;
        }

        // Check if this is a compiler-generated nested type (state machine for async iterators, iterators, async methods)
        // These types are nested within the actual source type and have compiler-generated names
        if (type.IsNested && type.DeclaringType is not null && sourceTypes.Contains(type.DeclaringType))
        {
            // Try to find the original method from the state machine
            var originalMethod = TryGetOriginalMethodFromStateMachine(type, sourceTypes);
            if (originalMethod is not null && !list.Contains(originalMethod))
            {
                list.Add(originalMethod);
                return;
            }
        }

        if (sourceTypes.FirstOrDefault(x => x.BeautifyName().Equals(type.BeautifyName(useFullName: false, useHtmlFormat: false, useGenericParameterNamesAsT: true), StringComparison.Ordinal)) is null)
        {
            return;
        }

        if (usedMethodInTest.Name.StartsWith("get_", StringComparison.Ordinal) ||
            usedMethodInTest.Name.StartsWith("set_", StringComparison.Ordinal))
        {
            return;
        }

        // For generic methods, get the generic method definition to match against source methods
        // This ensures Empty<int>(), Empty<string>(), etc. all resolve to Empty<T>()
        var methodToAdd = usedMethodInTest.IsGenericMethod
            ? usedMethodInTest.GetGenericMethodDefinition()
            : usedMethodInTest;

        if (!list.Contains(methodToAdd))
        {
            list.Add(methodToAdd);
        }
    }

    [SuppressMessage("Performance", "MA0009:Regular expressions should not be vulnerable to Denial of Service attacks", Justification = "OK - Simple pattern for compiler-generated names")]
    private static MethodInfo? TryGetOriginalMethodFromStateMachine(Type stateMachineType, Type[] sourceTypes)
    {
        // State machine types are nested within the declaring type
        var declaringType = stateMachineType.DeclaringType;
        if (declaringType is null)
        {
            return null;
        }

        // Extract method name from state machine type name
        // Compiler-generated state machines have names like: <MethodName>d__N (async/iterator) or <MethodName>d__N`M (generic)
        var stateMachineName = stateMachineType.Name;

        // Remove generic arity suffix if present (e.g., `1)
        var nameWithoutGenericSuffix = stateMachineName.Split('`')[0];

        // Match pattern: <MethodName>d__N
        var match = Regex.Match(nameWithoutGenericSuffix, @"^<(.+?)>d__\d+$");
        if (!match.Success)
        {
            return null;
        }

        var methodName = match.Groups[1].Value;

        // Find all methods with this name in the declaring type
        var methods = declaringType.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance);
        var candidateMethods = methods.Where(m => m.Name.Equals(methodName, StringComparison.Ordinal)).ToArray();

        if (candidateMethods.Length == 0)
        {
            return null;
        }

        // If there's only one match, return it
        if (candidateMethods.Length == 1)
        {
            return candidateMethods[0];
        }

        // If multiple overloads exist, try to match based on generic arity
        if (stateMachineType.IsGenericType)
        {
            var genericArgCount = stateMachineType.GetGenericArguments().Length;
            var matchingMethod = candidateMethods.FirstOrDefault(m =>
                m.IsGenericMethodDefinition && m.GetGenericArguments().Length == genericArgCount);
            if (matchingMethod is not null)
            {
                return matchingMethod;
            }
        }

        // Return the first public method as a fallback
        return candidateMethods.FirstOrDefault(m => m.IsPublic) ?? candidateMethods[0];
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

        if (IsMethodMatchedByDirectComparison(method, usedSourceMethods))
        {
            return true;
        }

        return IsMethodMatchedByParameterComparison(method, usedSourceMethods);
    }

    private static bool IsMethodMatchedByDirectComparison(
        MethodInfo method,
        MethodInfo[] usedSourceMethods)
    {
        return usedSourceMethods.Any(x =>
        {
            // Check if declaring types match
            if (!x.DeclaringType!.GetNameWithoutGenericType(useFullName: true)!.Equals(
                method.DeclaringType!.GetNameWithoutGenericType(useFullName: true),
                StringComparison.Ordinal))
            {
                return false;
            }

            // For generic methods, we need special handling
            if (method.IsGenericMethod && x.IsGenericMethod)
            {
                return AreGenericMethodsEqual(method, x);
            }

            // For non-generic methods, compare beautified names
            return x.BeautifyName().Equals(method.BeautifyName(), StringComparison.Ordinal);
        });
    }

    private static bool AreGenericMethodsEqual(MethodInfo method, MethodInfo usedMethod)
    {
        // Both should already be generic definitions from GetUsedSourceMethods and source reflection
        // Compare name and generic arity
        if (usedMethod.Name != method.Name)
        {
            return false;
        }

        var usedMethodGenericArgs = usedMethod.GetGenericArguments();
        var methodGenericArgs = method.GetGenericArguments();

        if (usedMethodGenericArgs.Length != methodGenericArgs.Length)
        {
            return false;
        }

        // Compare parameter count
        var usedMethodParams = usedMethod.GetParameters();
        var methodParams = method.GetParameters();

        return usedMethodParams.Length == methodParams.Length;
    }

    private static bool IsMethodMatchedByParameterComparison(
        MethodInfo method,
        MethodInfo[] usedSourceMethods)
    {
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

        return usedMethods.Any(usedMethod => DoParametersMatch(method, methodParameters, usedMethod));
    }

    private static bool DoParametersMatch(
        MethodInfo method,
        ParameterInfo[] methodParameters,
        MethodInfo usedMethod)
    {
        var usedMethodParameters = usedMethod.GetParameters();
        if (usedMethodParameters.Length != methodParameters.Length)
        {
            return false;
        }

        if (method.ReturnType.IsGenericParameter)
        {
            if (usedMethod.ReturnType == typeof(void))
            {
                return false;
            }
        }
        else if (usedMethod.ReturnType != method.ReturnType)
        {
            return false;
        }

        // For extension methods, skip comparing the first parameter name
        // because the IL contains the call-site variable name, not the method definition name
        var isExtensionMethod = method.IsDefined(typeof(ExtensionAttribute));
        var startIndex = isExtensionMethod ? 1 : 0;

        // Check if all parameters match (skipping first for extension methods)
        for (var i = startIndex; i < usedMethodParameters.Length; i++)
        {
            if (!usedMethodParameters[i].Name!.Equals(methodParameters[i].Name, StringComparison.Ordinal))
            {
                return false;
            }
        }

        return true;
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
                if (usedSourceMethods.Contains(method))
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