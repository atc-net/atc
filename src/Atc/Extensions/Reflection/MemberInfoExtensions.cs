// ReSharper disable once CheckNamespace
namespace System.Reflection;

/// <summary>
/// Extensions for the <see cref="MemberInfo"/> class.
/// </summary>
public static class MemberInfoExtensions
{
    /// <summary>
    /// Determines whether the member has any custom attributes of the specified type.
    /// </summary>
    /// <typeparam name="T">The attribute type to check for. Must derive from <see cref="Attribute"/>.</typeparam>
    /// <param name="element">The member to check for custom attributes.</param>
    /// <returns><see langword="true"/> if the member has one or more custom attributes of type <typeparamref name="T"/>; otherwise, <see langword="false"/>.</returns>
    [SuppressMessage("", "CA2263:Prefer the generic overload", Justification = "OK")]
    public static bool AnyCustomAttributes<T>(this MemberInfo element)
        where T : Attribute
        => element
            .GetCustomAttributes(typeof(T))
            .Any();

    /// <summary>
    /// Determines whether [has exclude from code coverage attribute].
    /// </summary>
    /// <param name="memberInfo">The member information.</param>
    /// <returns>
    ///   <see langword="true" /> if [has exclude from code coverage attribute] [the specified member information]; otherwise, <see langword="false" />.
    /// </returns>
    /// <exception cref="ArgumentNullException">memberInfo.</exception>
    public static bool HasExcludeFromCodeCoverageAttribute(
        this MemberInfo memberInfo)
    {
        if (memberInfo is null)
        {
            throw new ArgumentNullException(nameof(memberInfo));
        }

        var attributeData = memberInfo.CustomAttributes.FirstOrDefault(x => x.AttributeType == typeof(ExcludeFromCodeCoverageAttribute));
        return attributeData is not null;
    }

    /// <summary>
    /// Determines whether the member has the CompilerGenerated attribute.
    /// </summary>
    /// <param name="memberInfo">The member information to check.</param>
    /// <returns><see langword="true"/> if the member has the CompilerGenerated attribute; otherwise, <see langword="false"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="memberInfo"/> is null.</exception>
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
    /// Determines whether the member is a property with a setter method.
    /// </summary>
    /// <param name="member">The member to check.</param>
    /// <returns><see langword="true"/> if the member is a property with a setter; otherwise, <see langword="false"/>.</returns>
    public static bool IsPropertyWithSetter(this MemberInfo member)
    {
        var property = member as PropertyInfo;

        return property?.GetSetMethod(true) is not null;
    }

    /// <summary>
    /// Gets the underlying type of the member (event, field, method return, or property type).
    /// </summary>
    /// <param name="member">The member whose underlying type to retrieve.</param>
    /// <returns>The underlying type of the member.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="member"/> is null.</exception>
    /// <exception cref="UnexpectedTypeException">Thrown when the member is not an EventInfo, FieldInfo, MethodInfo, or PropertyInfo.</exception>
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