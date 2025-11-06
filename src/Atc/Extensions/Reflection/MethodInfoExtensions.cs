// ReSharper disable once CheckNamespace
namespace System.Reflection;

/// <summary>
/// Extensions for the <see cref="MethodInfo"/> class.
/// </summary>
public static class MethodInfoExtensions
{
    /// <summary>
    /// Determines whether this instance is override.
    /// </summary>
    /// <param name="methodInfo">The method information.</param>
    /// <returns>
    ///   <see langword="true" /> if the specified method information is override; otherwise, <see langword="false" />.
    /// </returns>
    /// <exception cref="ArgumentNullException">methodInfo.</exception>
    public static bool IsOverride(this MethodInfo methodInfo)
    {
        if (methodInfo is null)
        {
            throw new ArgumentNullException(nameof(methodInfo));
        }

        return methodInfo.GetBaseDefinition().DeclaringType != methodInfo.DeclaringType;
    }

    /// <summary>
    /// Determines whether [has declaring type validation attributes].
    /// </summary>
    /// <param name="methodInfo">The method information.</param>
    /// <returns>
    ///   <see langword="true" /> if [has declaring type validation attributes] [the specified method information]; otherwise, <see langword="false" />.
    /// </returns>
    /// <exception cref="ArgumentNullException">methodInfo.</exception>
    public static bool HasDeclaringTypeValidationAttributes(this MethodInfo methodInfo)
    {
        if (methodInfo is null)
        {
            throw new ArgumentNullException(nameof(methodInfo));
        }

        if (methodInfo.DeclaringType is null)
        {
            return false;
        }

        return
            methodInfo.DeclaringType.IsInheritedFrom(typeof(DataTypeAttribute)) ||
            methodInfo.DeclaringType.IsInheritedFrom(typeof(ValidationAttribute));
    }

    /// <summary>
    /// Determines whether [has generic parameters].
    /// </summary>
    /// <param name="methodInfo">The method information.</param>
    /// <returns>
    ///   <see langword="true" /> if [has generic parameters] [the specified method information]; otherwise, <see langword="false" />.
    /// </returns>
    /// <exception cref="ArgumentNullException">methodInfo.</exception>
    public static bool HasGenericParameters(this MethodInfo methodInfo)
    {
        if (methodInfo is null)
        {
            throw new ArgumentNullException(nameof(methodInfo));
        }

        return methodInfo.GetParameters().Any(parameterInfo => parameterInfo.ParameterType.IsGenericParameter);
    }

    /// <summary>
    /// Beautifies the name.
    /// </summary>
    /// <param name="methodInfo">The method information.</param>
    /// <param name="useFullName">if set to <see langword="true" /> [use full name].</param>
    /// <param name="useHtmlFormat">if set to <see langword="true" /> [use HTML format].</param>
    /// <param name="includeReturnType">if set to <see langword="true" /> [include return type].</param>
    /// <exception cref="ArgumentNullException">methodInfo.</exception>
    public static string BeautifyName(
        this MethodInfo methodInfo,
        bool useFullName = false,
        bool useHtmlFormat = false,
        bool includeReturnType = false)
    {
        if (methodInfo is null)
        {
            throw new ArgumentNullException(nameof(methodInfo));
        }

        var seq = methodInfo.GetParameters().Select(x =>
        {
            var suffix = x.HasDefaultValue
                ? " = " + (x.DefaultValue ?? "null")
                : string.Empty;
            var typeName = x.ParameterType.BeautifyName(useFullName, useHtmlFormat);

            // ReSharper disable once InvertIf
            if (x.ParameterType.Name.EndsWith('&'))
            {
                if (x.IsIn)
                {
                    typeName = "in " + typeName.Replace("&", string.Empty, StringComparison.Ordinal);
                }
                else if (x.IsOut)
                {
                    typeName = "out " + typeName.Replace("&", string.Empty, StringComparison.Ordinal);
                }
                else
                {
                    typeName = "ref " + typeName.Replace("&", string.Empty, StringComparison.Ordinal);
                }
            }

            return typeName + " " + x.Name + suffix;
        });

        var isExtension = methodInfo.GetCustomAttributes<ExtensionAttribute>(false).Any();
        var text = isExtension
            ? $"{methodInfo.Name}(this {string.Join(", ", seq)})"
            : $"{methodInfo.Name}({string.Join(", ", seq)})";

        return includeReturnType
            ? $"{methodInfo.ReturnType.BeautifyName(useFullName, useHtmlFormat)} {text}"
            : text;
    }
}