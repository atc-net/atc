// ReSharper disable once CheckNamespace
namespace Microsoft.CodeAnalysis.CSharp.Syntax;

/// <summary>
/// Extension methods for <see cref="MethodDeclarationSyntax"/>.
/// </summary>
public static class MethodDeclarationSyntaxExtensions
{
    /// <summary>
    /// Adds a <see cref="SuppressMessageAttribute"/> to the method declaration.
    /// </summary>
    /// <param name="methodDeclaration">The method declaration to modify.</param>
    /// <param name="suppressMessage">The suppress message attribute to add.</param>
    /// <returns>A new <see cref="MethodDeclarationSyntax"/> with the attribute added.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="methodDeclaration"/> or <paramref name="suppressMessage"/> is null.</exception>
    /// <exception cref="ArgumentException">Thrown when the justification in <paramref name="suppressMessage"/> is invalid.</exception>
    public static MethodDeclarationSyntax AddSuppressMessageAttribute(this MethodDeclarationSyntax methodDeclaration, SuppressMessageAttribute suppressMessage)
    {
        if (methodDeclaration is null)
        {
            throw new ArgumentNullException(nameof(methodDeclaration));
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

        return methodDeclaration
            .AddAttributeLists(SyntaxAttributeListFactory.Create(nameof(SuppressMessageAttribute), attributeArgumentList));
    }
}