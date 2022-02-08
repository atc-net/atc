namespace Atc.CodeAnalysis.CSharp.SyntaxFactories;

public static class SyntaxObjectCreationExpressionFactory
{
    public static ObjectCreationExpressionSyntax Create(string identifierName)
    {
        if (identifierName is null)
        {
            throw new ArgumentNullException(nameof(identifierName));
        }

        return SyntaxFactory.ObjectCreationExpression(SyntaxFactory.IdentifierName(identifierName));
    }

    public static ObjectCreationExpressionSyntax Create(string namespaceName, string identifierName)
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