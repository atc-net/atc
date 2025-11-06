namespace Atc.CodeAnalysis.CSharp.SyntaxFactories;

/// <summary>
/// Factory for creating <see cref="AssignmentExpressionSyntax"/> nodes.
/// </summary>
public static class SyntaxAssignmentExpressionFactory
{
    /// <summary>
    /// Creates a simple assignment expression (e.g., <c>toIdentifierName = fromIdentifierName</c>).
    /// </summary>
    /// <param name="toIdentifierName">The identifier name on the left side of the assignment.</param>
    /// <param name="fromIdentifierName">The identifier name on the right side of the assignment.</param>
    /// <returns>An <see cref="AssignmentExpressionSyntax"/> node representing the simple assignment.</returns>
    public static AssignmentExpressionSyntax CreateSimple(
        string toIdentifierName,
        string fromIdentifierName)
    {
        return SyntaxFactory.AssignmentExpression(
            SyntaxKind.SimpleAssignmentExpression,
            SyntaxFactory.IdentifierName(toIdentifierName),
            SyntaxFactory.IdentifierName(fromIdentifierName));
    }
}