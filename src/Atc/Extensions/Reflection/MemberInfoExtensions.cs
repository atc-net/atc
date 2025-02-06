// ReSharper disable once CheckNamespace
namespace System.Reflection;

/// <summary>
/// Extensions for the <see cref="MemberInfo"/> class.
/// </summary>
public static class MemberInfoExtensions
{
    /// <summary>
    /// Determines whether [has exclude from code coverage attribute].
    /// </summary>
    /// <param name="memberInfo">The member information.</param>
    /// <returns>
    ///   <see langword="true" /> if [has exclude from code coverage attribute] [the specified member information]; otherwise, <see langword="false" />.
    /// </returns>
    /// <exception cref="ArgumentNullException">memberInfo.</exception>
    public static bool HasExcludeFromCodeCoverageAttribute(this MemberInfo memberInfo)
    {
        if (memberInfo is null)
        {
            throw new ArgumentNullException(nameof(memberInfo));
        }

        var attributeData = memberInfo.CustomAttributes.FirstOrDefault(x => x.AttributeType == typeof(ExcludeFromCodeCoverageAttribute));
        return attributeData is not null;
    }

    public static bool HasCompilerGeneratedAttribute(this MemberInfo memberInfo)
    {
        if (memberInfo is null)
        {
            throw new ArgumentNullException(nameof(memberInfo));
        }

        var attributeData = memberInfo.CustomAttributes.FirstOrDefault(x => x.AttributeType == typeof(CompilerGeneratedAttribute));
        return attributeData is not null;
    }

    /// <summary>
    /// Determines whether [has ignore display attribute].
    /// </summary>
    /// <param name="memberInfo">The member information.</param>
    /// <returns>
    ///   <see langword="true" /> if [has ignore display attribute] [the specified member information]; otherwise, <see langword="false" />.
    /// </returns>
    /// <exception cref="ArgumentNullException">memberInfo.</exception>
    public static bool HasIgnoreDisplayAttribute(this MemberInfo memberInfo)
    {
        if (memberInfo is null)
        {
            throw new ArgumentNullException(nameof(memberInfo));
        }

        var attributeData = memberInfo.CustomAttributes.FirstOrDefault(x => x.AttributeType == typeof(IgnoreDisplayAttribute));
        return attributeData is not null;
    }

    /// <summary>
    /// Determines whether [has required attribute].
    /// </summary>
    /// <param name="memberInfo">The member information.</param>
    /// <returns>
    ///   <see langword="true" /> if [has required attribute] [the specified member information]; otherwise, <see langword="false" />.
    /// </returns>
    /// <exception cref="ArgumentNullException">memberInfo.</exception>
    public static bool HasRequiredAttribute(this MemberInfo memberInfo)
    {
        if (memberInfo is null)
        {
            throw new ArgumentNullException(nameof(memberInfo));
        }

        var attributeData = memberInfo.CustomAttributes.FirstOrDefault(x => x.AttributeType == typeof(RequiredAttribute));
        return attributeData is not null;
    }

    /// <summary>
    /// Determines whether [is property with setter].
    /// </summary>
    /// <param name="member">The member.</param>
    public static bool IsPropertyWithSetter(this MemberInfo member)
    {
        var property = member as PropertyInfo;

        return property?.GetSetMethod(true) is not null;
    }

    /// <summary>
    /// Gets the type of the underlying.
    /// </summary>
    /// <param name="member">The member.</param>
    /// <exception cref="ArgumentNullException">member.</exception>
    /// <exception cref="ArgumentException">Input MemberInfo must be if type EventInfo, FieldInfo, MethodInfo, or PropertyInfo.</exception>
    public static Type GetUnderlyingType(this MemberInfo member)
    {
        if (member is null)
        {
            throw new ArgumentNullException(nameof(member));
        }

        return member.MemberType switch
        {
            MemberTypes.Event => ((EventInfo)member).EventHandlerType!,
            MemberTypes.Field => ((FieldInfo)member).FieldType,
            MemberTypes.Method => ((MethodInfo)member).ReturnType,
            MemberTypes.Property => ((PropertyInfo)member).PropertyType,
            _ => throw new UnexpectedTypeException("Input MemberInfo must be if type EventInfo, FieldInfo, MethodInfo, or PropertyInfo"),
        };
    }
}