namespace Atc.CodeAnalysis.CSharp.SyntaxFactories;

/// <summary>
/// Factory for creating <see cref="ObjectCreationExpressionSyntax"/> nodes.
/// </summary>
public static class SyntaxObjectCreationExpressionFactory
{
    /// <summary>
    /// Creates an object creation expression for a type.
    /// </summary>
    /// <param name="identifierName">The name of the type to instantiate.</param>
    /// <returns>An <see cref="ObjectCreationExpressionSyntax"/> node.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="identifierName"/> is null.</exception>
    public static ObjectCreationExpressionSyntax Create(string identifierName)
    {
        if (identifierName is null)
        {
            throw new ArgumentNullException(nameof(identifierName));
        }

        return SyntaxFactory.ObjectCreationExpression(SyntaxFactory.IdentifierName(identifierName));
    }

    /// <summary>
    /// Creates an object creation expression for a qualified type name (namespace.type).
    /// </summary>
    /// <param name="namespaceName">The namespace containing the type.</param>
    /// <param name="identifierName">The name of the type to instantiate.</param>
    /// <returns>An <see cref="ObjectCreationExpressionSyntax"/> node.</returns>
    /// <exception cref="ArgumentNullException">Thrown when any parameter is null.</exception>
    public static ObjectCreationExpressionSyntax Create(
        string namespaceName,
        string identifierName)
    {
        if (namespaceName is null)
        {
            throw new ArgumentNullException(nameof(namespaceName));
        }

        if (identifierName is null)
        {
            throw new ArgumentNullException(nameof(identifierName));
        }

        return SyntaxFactory.ObjectCreationExpression(
            SyntaxFactory.QualifiedName(
                SyntaxFactory.IdentifierName(namespaceName),
                SyntaxFactory.IdentifierName(identifierName)));
    }
}