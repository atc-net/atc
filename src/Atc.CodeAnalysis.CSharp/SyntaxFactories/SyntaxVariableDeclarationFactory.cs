namespace Atc.CodeAnalysis.CSharp.SyntaxFactories;

public static class SyntaxVariableDeclarationFactory
{
    public static VariableDeclarationSyntax Create(
        string identifierTypeName,
        string identifierName)
    {
        return SyntaxFactory.VariableDeclaration(
                SyntaxFactory.IdentifierName(
                    SyntaxFactory.Identifier(SyntaxTriviaList.Empty, identifierTypeName, new SyntaxTriviaList(SyntaxFactory.Space))))
            .WithVariables(
                SyntaxFactory.SingletonSeparatedList(
                    SyntaxFactory.VariableDeclarator(SyntaxFactory.Identifier(identifierName))));
    }
}