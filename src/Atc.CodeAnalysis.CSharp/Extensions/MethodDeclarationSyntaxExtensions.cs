// ReSharper disable once CheckNamespace
namespace Microsoft.CodeAnalysis.CSharp.Syntax;

public static class MethodDeclarationSyntaxExtensions
{
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