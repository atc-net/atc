namespace Atc.CodeAnalysis.CSharp.SyntaxFactories;

/// <summary>
/// Factory for creating <see cref="MemberAccessExpressionSyntax"/> nodes.
/// </summary>
public static class SyntaxMemberAccessExpressionFactory
{
    /// <summary>
    /// Creates a simple member access expression (e.g., <c>memberName.memberTypeName</c>).
    /// </summary>
    /// <param name="memberTypeName">The name of the member being accessed.</param>
    /// <param name="memberName">The name of the object containing the member.</param>
    /// <returns>A <see cref="MemberAccessExpressionSyntax"/> node.</returns>
    public static MemberAccessExpressionSyntax Create(
        string memberTypeName,
        string memberName)
    {
        return SyntaxFactory.MemberAccessExpression(
            SyntaxKind.SimpleMemberAccessExpression,
            SyntaxFactory.IdentifierName(memberName),
            SyntaxFactory.IdentifierName(memberTypeName));
    }
}