// ReSharper disable once CheckNamespace
namespace Microsoft.CodeAnalysis.CSharp.Syntax;

/// <summary>
/// Extension methods for <see cref="ClassDeclarationSyntax"/>.
/// </summary>
public static class ClassDeclarationSyntaxExtensions
{
    /// <summary>
    /// Adds a <see cref="SuppressMessageAttribute"/> to the class declaration.
    /// </summary>
    /// <param name="classDeclaration">The class declaration to modify.</param>
    /// <param name="suppressMessage">The suppress message attribute to add.</param>
    /// <returns>A new <see cref="ClassDeclarationSyntax"/> with the attribute added.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="classDeclaration"/> or <paramref name="suppressMessage"/> is null.</exception>
    /// <exception cref="ArgumentException">Thrown when the justification in <paramref name="suppressMessage"/> is invalid.</exception>
    public static ClassDeclarationSyntax AddSuppressMessageAttribute(
        this ClassDeclarationSyntax classDeclaration,
        SuppressMessageAttribute suppressMessage)
    {
        if (classDeclaration is null)
        {
            throw new ArgumentNullException(nameof(classDeclaration));
        }

        if (suppressMessage is null)
        {
            throw new ArgumentNullException(nameof(suppressMessage));
        }

        if (string.IsNullOrEmpty(suppressMessage.Justification))
        {
            throw new ArgumentException("Justification is invalid.", nameof(suppressMessage));
        }

        var attributeArgumentList = SyntaxFactory.AttributeArgumentList(
            SyntaxFactory.SeparatedList<AttributeArgumentSyntax>(SyntaxFactory.NodeOrTokenList(
                SyntaxFactory.AttributeArgument(SyntaxLiteralExpressionFactory.Create(suppressMessage.Category)),
                SyntaxTokenFactory.Comma(),
                SyntaxFactory.AttributeArgument(SyntaxLiteralExpressionFactory.Create(suppressMessage.CheckId)),
                SyntaxTokenFactory.Comma(),
                SyntaxFactory.AttributeArgument(SyntaxLiteralExpressionFactory.Create(suppressMessage.Justification!))
                    .WithNameEquals(
                        SyntaxNameEqualsFactory.Create(nameof(SuppressMessageAttribute.Justification))
                            .WithEqualsToken(SyntaxTokenFactory.Equals())))));

        return classDeclaration
            .AddAttributeLists(SyntaxAttributeListFactory.Create(nameof(SuppressMessageAttribute), attributeArgumentList));
    }

    /// <summary>
    /// Adds a <see cref="GeneratedCodeAttribute"/> to the class declaration.
    /// </summary>
    /// <param name="classDeclaration">The class declaration to modify.</param>
    /// <param name="toolName">The name of the code generation tool.</param>
    /// <param name="version">The version of the code generation tool.</param>
    /// <returns>A new <see cref="ClassDeclarationSyntax"/> with the attribute added.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="classDeclaration"/>, <paramref name="toolName"/>, or <paramref name="version"/> is null.</exception>
    public static ClassDeclarationSyntax AddGeneratedCodeAttribute(
        this ClassDeclarationSyntax classDeclaration,
        string toolName,
        string version)
    {
        if (classDeclaration is null)
        {
            throw new ArgumentNullException(nameof(classDeclaration));
        }

        if (toolName is null)
        {
            throw new ArgumentNullException(nameof(toolName));
        }

        if (version is null)
        {
            throw new ArgumentNullException(nameof(version));
        }

        var attributeArgumentList = SyntaxFactory.AttributeArgumentList(
            SyntaxFactory.SeparatedList<AttributeArgumentSyntax>(SyntaxFactory.NodeOrTokenList(
                SyntaxFactory.AttributeArgument(SyntaxLiteralExpressionFactory.Create(toolName)),
                SyntaxTokenFactory.Comma(),
                SyntaxFactory.AttributeArgument(SyntaxLiteralExpressionFactory.Create(version)))));

        return classDeclaration
            .AddAttributeLists(SyntaxAttributeListFactory.Create(nameof(GeneratedCodeAttribute), attributeArgumentList));
    }
}