// ReSharper disable once CheckNamespace
namespace Microsoft.CodeAnalysis.CSharp.Syntax;

/// <summary>
/// Extension methods for <see cref="InterfaceDeclarationSyntax"/>.
/// </summary>
public static class InterfaceDeclarationSyntaxExtensions
{
    /// <summary>
    /// Adds a <see cref="GeneratedCodeAttribute"/> to the interface declaration.
    /// </summary>
    /// <param name="interfaceDeclaration">The interface declaration to modify.</param>
    /// <param name="toolName">The name of the code generation tool.</param>
    /// <param name="version">The version of the code generation tool.</param>
    /// <returns>A new <see cref="InterfaceDeclarationSyntax"/> with the attribute added.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="interfaceDeclaration"/>, <paramref name="toolName"/>, or <paramref name="version"/> is null.</exception>
    public static InterfaceDeclarationSyntax AddGeneratedCodeAttribute(this InterfaceDeclarationSyntax interfaceDeclaration, string toolName, string version)
    {
        if (interfaceDeclaration is null)
        {
            throw new ArgumentNullException(nameof(interfaceDeclaration));
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

        return interfaceDeclaration
            .AddAttributeLists(SyntaxAttributeListFactory.Create(nameof(GeneratedCodeAttribute), attributeArgumentList));
    }
}