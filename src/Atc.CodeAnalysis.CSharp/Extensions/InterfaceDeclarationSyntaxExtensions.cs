// ReSharper disable once CheckNamespace
namespace Microsoft.CodeAnalysis.CSharp.Syntax;

public static class InterfaceDeclarationSyntaxExtensions
{
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