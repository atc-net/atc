namespace Atc.CodeAnalysis.CSharp.SyntaxFactories;

/// <summary>
/// Factory for creating <see cref="ParameterSyntax"/> nodes.
/// </summary>
public static class SyntaxParameterFactory
{
    /// <summary>
    /// Creates a parameter with an optional generic list type.
    /// </summary>
    /// <param name="parameterTypeName">The type name of the parameter.</param>
    /// <param name="parameterName">The name of the parameter.</param>
    /// <param name="genericListTypeName">The generic list type name (e.g., "List", "IEnumerable").</param>
    /// <returns>A <see cref="ParameterSyntax"/> node.</returns>
    /// <exception cref="ArgumentNullException">Thrown when any parameter (except genericListTypeName) is null.</exception>
    public static ParameterSyntax Create(
        string parameterTypeName,
        string parameterName,
        string? genericListTypeName = null)
    {
        if (parameterTypeName is null)
        {
            throw new ArgumentNullException(nameof(parameterTypeName));
        }

        if (parameterName is null)
        {
            throw new ArgumentNullException(nameof(parameterName));
        }

        if (genericListTypeName is not null)
        {
            return SyntaxFactory
                .Parameter(SyntaxFactory.Identifier(parameterName))
                .WithType(
                    SyntaxFactory.GenericName(SyntaxFactory.Identifier(genericListTypeName))
                        .WithTypeArgumentList(
                            SyntaxFactory.TypeArgumentList(
                                SyntaxFactory.SingletonSeparatedList<TypeSyntax>(
                                    SyntaxFactory.IdentifierName(parameterTypeName)))));
        }

        return SyntaxFactory
            .Parameter(SyntaxFactory.Identifier(parameterName))
            .WithType(SyntaxFactory.IdentifierName(parameterTypeName));
    }

    /// <summary>
    /// Creates a parameter with an attribute.
    /// </summary>
    /// <param name="attributeTypeName">The type name of the attribute to apply.</param>
    /// <param name="parameterTypeName">The type name of the parameter.</param>
    /// <param name="parameterName">The name of the parameter.</param>
    /// <returns>A <see cref="ParameterSyntax"/> node with an attribute.</returns>
    /// <exception cref="ArgumentNullException">Thrown when any parameter is null.</exception>
    public static ParameterSyntax CreateWithAttribute(
        string attributeTypeName,
        string parameterTypeName,
        string parameterName)
    {
        if (attributeTypeName is null)
        {
            throw new ArgumentNullException(nameof(attributeTypeName));
        }

        if (parameterTypeName is null)
        {
            throw new ArgumentNullException(nameof(parameterTypeName));
        }

        if (parameterName is null)
        {
            throw new ArgumentNullException(nameof(parameterName));
        }

        return SyntaxFactory
            .Parameter(SyntaxFactory.Identifier(parameterName))
            .WithAttributeLists(
                SyntaxFactory.SingletonList(
                    SyntaxFactory.AttributeList(
                        SyntaxFactory.SingletonSeparatedList(
                            SyntaxAttributeFactory.Create(attributeTypeName)))))
            .WithType(SyntaxFactory.IdentifierName(parameterTypeName));
    }
}