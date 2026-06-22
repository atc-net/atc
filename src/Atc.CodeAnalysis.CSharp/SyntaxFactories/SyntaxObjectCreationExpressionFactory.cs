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

    /// <summary>
    /// Creates an object creation expression for a type with an explicit argument list.
    /// </summary>
    /// <param name="identifierName">The name of the type to instantiate.</param>
    /// <param name="argumentList">The argument list to pass to the constructor.</param>
    /// <returns>An <see cref="ObjectCreationExpressionSyntax"/> node with the given arguments.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="identifierName"/> or <paramref name="argumentList"/> is null.</exception>
    public static ObjectCreationExpressionSyntax Create(
        string identifierName,
        ArgumentListSyntax argumentList)
    {
        if (identifierName is null)
        {
            throw new ArgumentNullException(nameof(identifierName));
        }

        if (argumentList is null)
        {
            throw new ArgumentNullException(nameof(argumentList));
        }

        return SyntaxFactory.ObjectCreationExpression(SyntaxFactory.IdentifierName(identifierName))
            .WithArgumentList(argumentList);
    }

    /// <summary>
    /// Creates an object creation expression for a qualified type name with an explicit argument list.
    /// </summary>
    /// <param name="namespaceName">The namespace containing the type.</param>
    /// <param name="identifierName">The name of the type to instantiate.</param>
    /// <param name="argumentList">The argument list to pass to the constructor.</param>
    /// <returns>An <see cref="ObjectCreationExpressionSyntax"/> node with the given arguments.</returns>
    /// <exception cref="ArgumentNullException">Thrown when any parameter is null.</exception>
    public static ObjectCreationExpressionSyntax Create(
        string namespaceName,
        string identifierName,
        ArgumentListSyntax argumentList)
    {
        if (namespaceName is null)
        {
            throw new ArgumentNullException(nameof(namespaceName));
        }

        if (identifierName is null)
        {
            throw new ArgumentNullException(nameof(identifierName));
        }

        if (argumentList is null)
        {
            throw new ArgumentNullException(nameof(argumentList));
        }

        return SyntaxFactory.ObjectCreationExpression(
            SyntaxFactory.QualifiedName(
                SyntaxFactory.IdentifierName(namespaceName),
                SyntaxFactory.IdentifierName(identifierName)))
            .WithArgumentList(argumentList);
    }

    /// <summary>
    /// Creates a generic object creation expression (e.g. <c>new List&lt;T&gt;()</c>).
    /// </summary>
    /// <param name="identifierName">The name of the generic type to instantiate.</param>
    /// <param name="typeArgumentList">The type argument list (e.g. <c>&lt;T&gt;</c>).</param>
    /// <returns>An <see cref="ObjectCreationExpressionSyntax"/> node for the generic type.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="identifierName"/> or <paramref name="typeArgumentList"/> is null.</exception>
    public static ObjectCreationExpressionSyntax CreateGeneric(
        string identifierName,
        TypeArgumentListSyntax typeArgumentList)
    {
        if (identifierName is null)
        {
            throw new ArgumentNullException(nameof(identifierName));
        }

        if (typeArgumentList is null)
        {
            throw new ArgumentNullException(nameof(typeArgumentList));
        }

        return SyntaxFactory.ObjectCreationExpression(
            SyntaxFactory.GenericName(
                SyntaxFactory.Identifier(identifierName))
            .WithTypeArgumentList(typeArgumentList));
    }

    /// <summary>
    /// Creates a generic object creation expression with a single named type argument (e.g. <c>new List&lt;MyType&gt;()</c>).
    /// </summary>
    /// <param name="identifierName">The name of the generic type to instantiate.</param>
    /// <param name="typeArgumentName">The name of the single type argument.</param>
    /// <returns>An <see cref="ObjectCreationExpressionSyntax"/> node for the generic type.</returns>
    /// <exception cref="ArgumentNullException">Thrown when any parameter is null.</exception>
    public static ObjectCreationExpressionSyntax CreateGeneric(
        string identifierName,
        string typeArgumentName)
    {
        if (identifierName is null)
        {
            throw new ArgumentNullException(nameof(identifierName));
        }

        if (typeArgumentName is null)
        {
            throw new ArgumentNullException(nameof(typeArgumentName));
        }

        return CreateGeneric(identifierName, SyntaxTypeArgumentListFactory.CreateWithOneItem(typeArgumentName));
    }

    /// <summary>
    /// Creates a generic object creation expression with an explicit argument list (e.g. <c>new Dictionary&lt;K,V&gt;(capacity)</c>).
    /// </summary>
    /// <param name="identifierName">The name of the generic type to instantiate.</param>
    /// <param name="typeArgumentList">The type argument list.</param>
    /// <param name="argumentList">The argument list to pass to the constructor.</param>
    /// <returns>An <see cref="ObjectCreationExpressionSyntax"/> node for the generic type with arguments.</returns>
    /// <exception cref="ArgumentNullException">Thrown when any parameter is null.</exception>
    public static ObjectCreationExpressionSyntax CreateGeneric(
        string identifierName,
        TypeArgumentListSyntax typeArgumentList,
        ArgumentListSyntax argumentList)
    {
        if (identifierName is null)
        {
            throw new ArgumentNullException(nameof(identifierName));
        }

        if (typeArgumentList is null)
        {
            throw new ArgumentNullException(nameof(typeArgumentList));
        }

        if (argumentList is null)
        {
            throw new ArgumentNullException(nameof(argumentList));
        }

        return SyntaxFactory.ObjectCreationExpression(
            SyntaxFactory.GenericName(
                SyntaxFactory.Identifier(identifierName))
            .WithTypeArgumentList(typeArgumentList))
            .WithArgumentList(argumentList);
    }

    /// <summary>
    /// Creates a generic object creation expression with a single named type argument and an argument list.
    /// </summary>
    /// <param name="identifierName">The name of the generic type to instantiate.</param>
    /// <param name="typeArgumentName">The name of the single type argument.</param>
    /// <param name="argumentList">The argument list to pass to the constructor.</param>
    /// <returns>An <see cref="ObjectCreationExpressionSyntax"/> node for the generic type with arguments.</returns>
    /// <exception cref="ArgumentNullException">Thrown when any parameter is null.</exception>
    public static ObjectCreationExpressionSyntax CreateGeneric(
        string identifierName,
        string typeArgumentName,
        ArgumentListSyntax argumentList)
    {
        if (identifierName is null)
        {
            throw new ArgumentNullException(nameof(identifierName));
        }

        if (typeArgumentName is null)
        {
            throw new ArgumentNullException(nameof(typeArgumentName));
        }

        if (argumentList is null)
        {
            throw new ArgumentNullException(nameof(argumentList));
        }

        return CreateGeneric(identifierName, SyntaxTypeArgumentListFactory.CreateWithOneItem(typeArgumentName), argumentList);
    }
}