namespace Atc.CodeAnalysis.CSharp.SyntaxFactories;

/// <summary>
/// Factory for creating <see cref="IfStatementSyntax"/> nodes.
/// </summary>
public static class SyntaxIfStatementFactory
{
    /// <summary>
    /// Creates an if statement that checks if a parameter is null and throws <see cref="ArgumentNullException"/>.
    /// </summary>
    /// <param name="parameterName">The name of the parameter to check for null.</param>
    /// <param name="includeSystem">If <c>true</c>, includes the System namespace prefix for ArgumentNullException.</param>
    /// <returns>A <see cref="StatementSyntax"/> representing the null check.</returns>
    public static StatementSyntax CreateParameterArgumentNullCheck(
        string parameterName,
        bool includeSystem = true)
    {
        return SyntaxFactory.IfStatement(
            SyntaxFactory.IsPatternExpression(
                SyntaxFactory.IdentifierName(parameterName),
                SyntaxFactory.ConstantPattern(
                    SyntaxFactory.LiteralExpression(SyntaxKind.NullLiteralExpression))),
            SyntaxFactory.Block(
                SyntaxFactory.SingletonList<StatementSyntax>(
                    SyntaxThrowStatementFactory.CreateArgumentNullException(parameterName, includeSystem))));
    }
}