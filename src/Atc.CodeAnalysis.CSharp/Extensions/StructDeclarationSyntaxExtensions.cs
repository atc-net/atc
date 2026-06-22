// ReSharper disable once CheckNamespace
namespace Microsoft.CodeAnalysis.CSharp.Syntax;

/// <summary>
/// Extension methods for <see cref="StructDeclarationSyntax"/>.
/// </summary>
public static class StructDeclarationSyntaxExtensions
{
    /// <summary>
    /// Adds a <see cref="SuppressMessageAttribute"/> to the struct declaration.
    /// </summary>
    /// <param name="structDeclaration">The struct declaration to modify.</param>
    /// <param name="suppressMessage">The suppress message attribute to add.</param>
    /// <returns>A new <see cref="StructDeclarationSyntax"/> with the attribute added.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="structDeclaration"/> or <paramref name="suppressMessage"/> is null.</exception>
    /// <exception cref="ArgumentException">Thrown when the justification in <paramref name="suppressMessage"/> is invalid.</exception>
    public static StructDeclarationSyntax AddSuppressMessageAttribute(
        this StructDeclarationSyntax structDeclaration,
        SuppressMessageAttribute suppressMessage)
    {
        if (structDeclaration is null)
        {
            throw new ArgumentNullException(nameof(structDeclaration));
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
            SyntaxFactory.SeparatedList<AttributeArgumentSyntax>(
                SyntaxFactory.NodeOrTokenList(
                    SyntaxFactory.AttributeArgument(SyntaxLiteralExpressionFactory.Create(suppressMessage.Category)),
                    SyntaxTokenFactory.Comma(),
                    SyntaxFactory.AttributeArgument(SyntaxLiteralExpressionFactory.Create(suppressMessage.CheckId)),
                    SyntaxTokenFactory.Comma(),
                    SyntaxFactory
                        .AttributeArgument(SyntaxLiteralExpressionFactory.Create(suppressMessage.Justification!))
                        .WithNameEquals(
                        SyntaxNameEqualsFactory
                            .Create(nameof(SuppressMessageAttribute.Justification))
                            .WithEqualsToken(SyntaxTokenFactory.Equals())))));

        return structDeclaration
            .AddAttributeLists(SyntaxAttributeListFactory.Create(nameof(SuppressMessageAttribute), attributeArgumentList));
    }

    /// <summary>
    /// Adds a <see cref="GeneratedCodeAttribute"/> to the struct declaration.
    /// </summary>
    /// <param name="structDeclaration">The struct declaration to modify.</param>
    /// <param name="toolName">The name of the code generation tool.</param>
    /// <param name="version">The version of the code generation tool.</param>
    /// <returns>A new <see cref="StructDeclarationSyntax"/> with the attribute added.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="structDeclaration"/>, <paramref name="toolName"/>, or <paramref name="version"/> is null.</exception>
    public static StructDeclarationSyntax AddGeneratedCodeAttribute(
        this StructDeclarationSyntax structDeclaration,
        string toolName,
        string version)
    {
        if (structDeclaration is null)
        {
            throw new ArgumentNullException(nameof(structDeclaration));
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

        return structDeclaration
            .AddAttributeLists(SyntaxAttributeListFactory.Create(nameof(GeneratedCodeAttribute), attributeArgumentList));
    }
}