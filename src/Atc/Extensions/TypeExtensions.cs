// ReSharper disable once CheckNamespace
namespace System;

/// <summary>
/// Extensions for the <see cref="Type"/> class.
/// </summary>
public static class TypeExtensions
{
    private const string GenericSign = "`";

    /// <summary>
    /// Determines whether [has validation attributes].
    /// </summary>
    /// <param name="type">The type.</param>
    /// <returns>
    ///   <c>true</c> if [has validation attributes] [the specified type]; otherwise, <c>false</c>.
    /// </returns>
    /// <exception cref="ArgumentNullException">type.</exception>
    public static bool HasValidationAttributes(this Type type)
    {
        if (type is null)
        {
            throw new ArgumentNullException(nameof(type));
        }

        return
            type.IsInheritedFrom(typeof(DataTypeAttribute)) ||
            type.IsInheritedFrom(typeof(ValidationAttribute));
    }

    /// <summary>
    /// Determines whether this instance is delegate.
    /// </summary>
    /// <param name="type">The type.</param>
    /// <returns>
    ///   <c>true</c> if the specified type is delegate; otherwise, <c>false</c>.
    /// </returns>
    public static bool IsDelegate(this Type type)
    {
        if (type is null)
        {
            throw new ArgumentNullException(nameof(type));
        }

        return type.IsSubclassOf(typeof(Delegate)) || type == typeof(Delegate);
    }

    /// <summary>
    /// Determines whether this instance is nullable.
    /// </summary>
    /// <param name="type">The type.</param>
    /// <returns>
    ///   <c>true</c> if the specified type is nullable; otherwise, <c>false</c>.
    /// </returns>
    /// <exception cref="ArgumentNullException">type.</exception>
    public static bool IsNullable(this Type type)
    {
        if (type is null)
        {
            throw new ArgumentNullException(nameof(type));
        }

        if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
        {
            return true;
        }

        // ReSharper disable once ConvertIfStatementToReturnStatement
        if (type.IsByRef && type.Name.StartsWith("Nullable", StringComparison.Ordinal))
        {
            return true;
        }

        return false;
    }

    /// <summary>
    /// Determines whether this instance is simple.
    /// </summary>
    /// <param name="type">The type.</param>
    /// <returns>
    ///   <c>true</c> if the specified type is simple; otherwise, <c>false</c>.
    /// </returns>
    /// <exception cref="ArgumentNullException">type.</exception>
    public static bool IsSimple(this Type type)
    {
        if (type is null)
        {
            throw new ArgumentNullException(nameof(type));
        }

        while (true)
        {
            // ReSharper disable once InvertIf
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                type = type.GetGenericArguments()[0];
                continue;
            }

            return type.IsPrimitive || type.IsEnum || type == typeof(string) || type == typeof(decimal);
        }
    }

    /// <summary>
    /// Determines whether [is inherited from] [the specified inherit type].
    /// </summary>
    /// <param name="type">The type.</param>
    /// <param name="inheritType">Type of the inherit.</param>
    /// <returns>
    ///   <c>true</c> if [is inherited from] [the specified inherit type]; otherwise, <c>false</c>.
    /// </returns>
    public static bool IsInheritedFrom(this Type type, Type inheritType)
    {
        if (type is null)
        {
            throw new ArgumentNullException(nameof(type));
        }

        if (inheritType is null)
        {
            throw new ArgumentNullException(nameof(inheritType));
        }

        if (type.BaseType is null)
        {
            return false;
        }

        if (!type.BaseType.IsGenericType && !inheritType.IsGenericType)
        {
            return string.Equals(type.BaseType.FullName, inheritType.FullName, StringComparison.Ordinal) || type.BaseType.IsInheritedFrom(inheritType);
        }

        var baseTypeFullName = type.BaseType.FullName;
        if (baseTypeFullName is null)
        {
            return false;
        }

        if (type.BaseType.IsGenericType)
        {
            baseTypeFullName = baseTypeFullName.Substring(0, baseTypeFullName.IndexOf(GenericSign, StringComparison.Ordinal));
        }

        var inheritTypeFullName = inheritType.FullName;
        if (inheritTypeFullName is null)
        {
            return false;
        }

        if (inheritType.IsGenericType)
        {
            inheritTypeFullName = inheritTypeFullName.Substring(0, inheritTypeFullName.IndexOf(GenericSign, StringComparison.Ordinal));
        }

        return string.Equals(baseTypeFullName, inheritTypeFullName, StringComparison.OrdinalIgnoreCase) || type.BaseType.IsInheritedFrom(inheritType);
    }

    /// <summary>
    /// Determines whether [is inherited from generic with argument type] [the specified inherit type].
    /// </summary>
    /// <param name="type">The type.</param>
    /// <param name="inheritType">Type of the inherit.</param>
    /// <param name="argumentType">Type of the argument.</param>
    /// <param name="matchAlsoOnArgumentTypeInterface">if set to <c>true</c> [match also on argument type interface].</param>
    /// <returns>
    ///   <c>true</c> if [is inherited from generic with argument type] [the specified inherit type]; otherwise, <c>false</c>.
    /// </returns>
    public static bool IsInheritedFromGenericWithArgumentType(this Type type, Type inheritType, Type argumentType, bool matchAlsoOnArgumentTypeInterface = true)
    {
        if (type is null)
        {
            throw new ArgumentNullException(nameof(type));
        }

        if (inheritType is null)
        {
            throw new ArgumentNullException(nameof(inheritType));
        }

        if (argumentType is null)
        {
            throw new ArgumentNullException(nameof(argumentType));
        }

        if (type.BaseType is null)
        {
            return false;
        }

        if (!inheritType.IsGenericType)
        {
            return false;
        }

        var baseTypeFullName = type.BaseType.FullName;
        if (baseTypeFullName is null)
        {
            return false;
        }

        if (type.BaseType.IsGenericType)
        {
            baseTypeFullName = baseTypeFullName.Substring(0, baseTypeFullName.IndexOf(GenericSign, StringComparison.Ordinal));
        }

        var inheritTypeFullName = inheritType.FullName;
        if (inheritTypeFullName is null)
        {
            return false;
        }

        return IsInheritedFromGenericWithArgumentTypeHelper(
                   type,
                   inheritType,
                   argumentType,
                   matchAlsoOnArgumentTypeInterface,
                   inheritTypeFullName,
                   baseTypeFullName) ||
               type.BaseType.IsInheritedFromGenericWithArgumentType(inheritType, argumentType);
    }

    /// <summary>
    /// Gets the type of the base type generic argument.
    /// </summary>
    /// <param name="type">The type.</param>
    public static Type? GetBaseTypeGenericArgumentType(this Type type)
    {
        var types = GetBaseTypeGenericArgumentTypes(type);
        if (types is not null && types.Length == 1)
        {
            return types.First();
        }

        return null;
    }

    /// <summary>
    /// Gets the base type generic argument types.
    /// </summary>
    /// <param name="type">The type.</param>
    [SuppressMessage("StyleCop.CSharp.SpacingRules", "SA1011:Closing square brackets should be spaced correctly", Justification = "OK.")]
    [SuppressMessage("Major Code Smell", "S3358:Ternary operators should not be nested", Justification = "OK.")]
    public static Type[]? GetBaseTypeGenericArgumentTypes(this Type type)
    {
        if (type is null)
        {
            throw new ArgumentNullException(nameof(type));
        }

        return type.BaseType is null
            ? null
            : type.BaseType.IsGenericType &&
              type.BaseType.GetGenericArguments().Length == 1
                ? type.BaseType.GetGenericArguments()
                : null;
    }

    /// <summary>
    /// Gets the attribute.
    /// </summary>
    /// <typeparam name="T">The attribute type.</typeparam>
    /// <param name="type">The type.</param>
    public static T? GetAttribute<T>(this Type type)
        where T : Attribute
    {
        return GetAttributes<T>(type).FirstOrDefault();
    }

    /// <summary>
    /// Tries the get attribute.
    /// </summary>
    /// <typeparam name="T">The attribute type.</typeparam>
    /// <param name="type">The type.</param>
    [SuppressMessage("Microsoft.Design", "CA1031:Do not catch general exception types", Justification = "OK.")]
    public static T? TryGetAttribute<T>(this Type type)
        where T : Attribute
    {
        T? attribute = null;
        try
        {
            attribute = type.GetAttribute<T>();
        }
        catch
        {
            // ignored
        }

        return attribute;
    }

    /// <summary>
    /// Gets the attributes.
    /// </summary>
    /// <typeparam name="T">The attribute type.</typeparam>
    /// <param name="type">The type.</param>
    public static IEnumerable<T> GetAttributes<T>(this Type type)
        where T : Attribute
    {
        return CustomAttributeExtensions.GetCustomAttributes(type.GetTypeInfo(), typeof(T), false).Cast<T>();
    }

    /// <summary>
    /// Gets the public declared only methods.
    /// </summary>
    /// <param name="type">The type.</param>
    /// <exception cref="ArgumentNullException">type.</exception>
    /// <remarks>Use: BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly.</remarks>
    public static MethodInfo[] GetPublicDeclaredOnlyMethods(this Type type)
    {
        if (type is null)
        {
            throw new ArgumentNullException(nameof(type));
        }

        return type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly);
    }

    /// <summary>
    /// Gets the private declared only methods.
    /// </summary>
    /// <param name="type">The type.</param>
    /// <exception cref="ArgumentNullException">type.</exception>
    [SuppressMessage("Major Code Smell", "S3011:Reflection should not be used to increase accessibility of classes, methods, or fields", Justification = "OK.")]
    public static MethodInfo[] GetPrivateDeclaredOnlyMethods(this Type type)
    {
        if (type is null)
        {
            throw new ArgumentNullException(nameof(type));
        }

        return type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly);
    }

    /// <summary>
    /// Gets the private declared only method.
    /// </summary>
    /// <param name="type">The type.</param>
    /// <param name="name">The name.</param>
    /// <exception cref="ArgumentNullException">type.</exception>
    public static MethodInfo? GetPrivateDeclaredOnlyMethod(this Type type, string name)
    {
        if (type is null)
        {
            throw new ArgumentNullException(nameof(type));
        }

        return type.GetPrivateDeclaredOnlyMethods().FirstOrDefault(x => x.Name.Equals(name, StringComparison.Ordinal));
    }

    /// <summary>
    /// Get the name of the type without generic part.
    /// </summary>
    /// <param name="type">The type.</param>
    /// <param name="useFullName">if set to <c>true</c> [use full name].</param>
    /// <exception cref="ArgumentNullException">type.</exception>
    public static string? GetNameWithoutGenericType(this Type type, bool useFullName = false)
    {
        if (type is null)
        {
            throw new ArgumentNullException(nameof(type));
        }

        // ReSharper disable once InvertIf
        if (type.IsGenericType)
        {
            if (useFullName && type.FullName is not null)
            {
                var indexOfGeneric = type.FullName.IndexOf(GenericSign, StringComparison.Ordinal);
                return type.FullName.Substring(0, indexOfGeneric);
            }
            else
            {
                var indexOfGeneric = type.Name.IndexOf(GenericSign, StringComparison.Ordinal);
                return type.Name.Substring(0, indexOfGeneric);
            }
        }

        return useFullName
            ? type.FullName
            : type.Name;
    }

    /// <summary>
    /// Beautifies the name of the type of.
    /// </summary>
    /// <param name="type">The type.</param>
    /// <param name="useFullName">if set to <c>true</c> [use full name].</param>
    /// <param name="useHtmlFormat">if set to <c>true</c> [use HTML format].</param>
    public static string BeautifyTypeOfName(this Type type, bool useFullName = false, bool useHtmlFormat = false)
    {
        return $"typeof({type.BeautifyName(useFullName, useHtmlFormat)})";
    }

    /// <summary>
    /// Beautifies the name.
    /// </summary>
    /// <param name="type">The type.</param>
    /// <param name="useFullName">if set to <c>true</c> [use full name].</param>
    /// <param name="useHtmlFormat">if set to <c>true</c> [use HTML format].</param>
    /// <param name="useGenericParameterNamesAsT">if set to <c>true</c> [use generic parameter names as t].</param>
    /// <param name="useSuffixQuestionMarkForGeneric">if set to <c>true</c> [use suffix question mark for generic].</param>
    /// <exception cref="ArgumentNullException">type.</exception>
    [SuppressMessage("Major Code Smell", "S3358:Ternary operators should not be nested", Justification = "OK.")]
    public static string BeautifyName(this Type type, bool useFullName = false, bool useHtmlFormat = false, bool useGenericParameterNamesAsT = false, bool useSuffixQuestionMarkForGeneric = false)
    {
        if (type is null)
        {
            throw new ArgumentNullException(nameof(type));
        }

        string typeName = type.BeautifyTypeName(useFullName);
        if (!type.IsGenericType)
        {
            return typeName;
        }

        string genericArguments;
        if (useGenericParameterNamesAsT)
        {
            var sa = type.GetGenericArguments()
                .Select(x => x.BeautifyName(useFullName, useHtmlFormat, true))
                .ToArray();
            for (var i = 0; i < sa.Length; i++)
            {
                sa[0] = "T";
            }

            genericArguments = string.Join(", ", sa);
        }
        else
        {
            genericArguments = type
                .GetGenericArguments()
                .Select(x => x.BeautifyName(useFullName, useHtmlFormat))
                .Aggregate((a, b) => $"{a}, {b}");
        }

        var indexOfGeneric = typeName.IndexOf(GenericSign, StringComparison.Ordinal);
        return indexOfGeneric == -1
            ? typeName
            : useHtmlFormat
                ? $"{typeName.Substring(0, indexOfGeneric)}&lt;{genericArguments}&gt;"
                : useSuffixQuestionMarkForGeneric
                    ? $"{genericArguments}?"
                    : $"{typeName.Substring(0, indexOfGeneric)}<{genericArguments}>";
    }

    /// <summary>
    /// Beautifies the name of the type.
    /// </summary>
    /// <param name="type">The type.</param>
    /// <param name="useFullName">if set to <c>true</c> [use full name].</param>
    public static string BeautifyTypeName(this Type? type, bool useFullName = false)
    {
        if (type is null || "Object".Equals(type.Name, StringComparison.Ordinal))
        {
            return "object";
        }

        if (type == typeof(void))
        {
            return "void";
        }

        var workOnType = type;
        var isNullable = false;
        if (type.IsNullable() && type.GetGenericArguments().Length == 1)
        {
            isNullable = true;
            workOnType = type.GetGenericArguments()[0];
        }

        string? typeName;
        if (workOnType.IsByRef)
        {
            typeName = SimpleTypeHelper.GetBeautifyTypeNameByRef(workOnType);
        }
        else if (workOnType.IsArray)
        {
            typeName = SimpleTypeHelper.GetBeautifyArrayTypeName(workOnType);
        }
        else
        {
            typeName = SimpleTypeHelper.GetBeautifyTypeName(workOnType);
        }

        typeName ??= useFullName
            ? workOnType.FullName ?? workOnType.Name
            : workOnType.Name;

        if (isNullable &&
            workOnType != typeof(string))
        {
            typeName += "?";
        }

        if (workOnType.IsByRef &&
            typeName.Contains('&', StringComparison.Ordinal))
        {
            typeName += "&";
        }

        return typeName;
    }

    /// <summary>
    /// Try to extract the enum-type.
    /// </summary>
    /// <param name="type">The type.</param>
    /// <param name="enumType">Type of the enum.</param>
    [SuppressMessage("Critical Code Smell", "S3776:Cognitive Complexity of methods should not be too high", Justification = "OK.")]
    public static bool TryGetEnumType(this Type type, out Type enumType)
    {
        if (type is null)
        {
            throw new ArgumentNullException(nameof(type));
        }

        if (type.IsEnum)
        {
            enumType = type;
            return true;
        }

        if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
        {
            var underlyingType = Nullable.GetUnderlyingType(type);
            if (underlyingType is { IsEnum: true })
            {
                enumType = underlyingType;
                return true;
            }
        }
        else
        {
            var underlyingType = type.GetIEnumerableType();
            if (underlyingType is { IsEnum: true })
            {
                enumType = underlyingType;
                return true;
            }

            var interfaces = type.GetInterfaces();
            foreach (var interfaceType in interfaces)
            {
                underlyingType = interfaceType.GetIEnumerableType();
                if (underlyingType is not { IsEnum: true })
                {
                    continue;
                }

                enumType = underlyingType;
                return true;
            }
        }

        enumType = null!;
        return false;
    }

    /// <summary>
    /// Determines whether [is sub class of raw generic] [the specified derived type].
    /// </summary>
    /// <param name="baseType">Type of the base.</param>
    /// <param name="derivedType">Type of the derived.</param>
    /// <returns>
    ///   <c>true</c> if [is sub class of raw generic] [the specified derived type]; otherwise, <c>false</c>.
    /// </returns>
    public static bool IsSubClassOfRawGeneric(this Type baseType, Type derivedType)
    {
        while (derivedType is not null && derivedType != typeof(object))
        {
            var currentType = derivedType.IsGenericType
                ? derivedType.GetGenericTypeDefinition()
                : derivedType;
            if (baseType == currentType)
            {
                return true;
            }

            derivedType = derivedType.BaseType!;
        }

        return false;
    }

    private static Type GetIEnumerableType(this Type type)
    {
        if (type is null)
        {
            throw new ArgumentNullException(nameof(type));
        }

        if (!type.IsGenericType || type.GetGenericTypeDefinition() != typeof(IEnumerable<>))
        {
            return null!;
        }

        var underlyingType = type.GetGenericArguments()[0];
        return underlyingType.IsEnum
            ? underlyingType
            : null!;
    }

    private static bool IsInheritedFromGenericWithArgumentTypeHelper(Type type, Type inheritType, Type argumentType, bool matchAlsoOnArgumentTypeInterface, string inheritTypeFullName, string baseTypeFullName)
    {
        if (inheritType.IsGenericType)
        {
            inheritTypeFullName =
                inheritTypeFullName.Substring(0, inheritTypeFullName.IndexOf(GenericSign, StringComparison.Ordinal));
        }

        if (type.BaseType is null ||
            !type.BaseType.IsGenericType ||
            !string.Equals(baseTypeFullName, inheritTypeFullName, StringComparison.Ordinal))
        {
            return false;
        }

        var baseTypeGenericArgumentType = type.GetBaseTypeGenericArgumentType();
        if (baseTypeGenericArgumentType is null)
        {
            return false;
        }

        if (baseTypeGenericArgumentType.IsInterface)
        {
            if (!matchAlsoOnArgumentTypeInterface)
            {
                return false;
            }

            var interfaces = argumentType.GetInterfaces();
            if (interfaces.FirstOrDefault(x => string.Equals(x.FullName, baseTypeGenericArgumentType.FullName, StringComparison.Ordinal)) is not null)
            {
                return true;
            }
        }
        else if (string.Equals(baseTypeGenericArgumentType.FullName, argumentType.FullName, StringComparison.Ordinal))
        {
            return true;
        }

        return false;
    }
}