// ReSharper disable once CheckNamespace
namespace System.Reflection;

/// <summary>
/// Extensions for the <see cref="ConstructorInfo"/> class.
/// </summary>
public static class ConstructorInfoExtensions
{
    /// <summary>
    /// Returns a human-readable representation of the constructor signature, optionally using full type names
    /// and HTML formatting for the parameter types.
    /// </summary>
    /// <param name="constructorInfo">The constructor information.</param>
    /// <param name="useFullName">If <see langword="true"/>, parameter types are rendered with their fully-qualified names.</param>
    /// <param name="useHtmlFormat">If <see langword="true"/>, parameter type names are wrapped in HTML tags.</param>
    /// <returns>A string of the form <c>.ctor(TypeA paramA, TypeB paramB)</c>.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="constructorInfo"/> is null.</exception>
    public static string BeautifyName(
        this ConstructorInfo constructorInfo,
        bool useFullName = false,
        bool useHtmlFormat = false)
    {
        ArgumentNullException.ThrowIfNull(constructorInfo);

        var seq = constructorInfo
            .GetParameters()
            .Select(x =>
            {
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

                return typeName + " " + x.Name;
            });

        return $".ctor({string.Join(", ", seq)})";
    }
}