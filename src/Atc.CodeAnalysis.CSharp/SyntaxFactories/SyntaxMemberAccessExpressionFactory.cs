namespace Atc.CodeAnalysis.CSharp.SyntaxFactories;

public static class SyntaxMemberAccessExpressionFactory
{
    public static MemberAccessExpressionSyntax Create(string memberTypeName, string memberName)
    {
        return SyntaxFactory.MemberAccessExpression(
            SyntaxKind.SimpleMemberAccessExpression,
            SyntaxFactory.IdentifierName(memberName),
            SyntaxFactory.IdentifierName(memberTypeName));
    }
}