namespace Atc.CodeAnalysis.CSharp.SyntaxFactories;

/// <summary>
/// Factory for creating <see cref="ThrowStatementSyntax"/> nodes.
/// </summary>
public static class SyntaxThrowStatementFactory
{
    /// <summary>
    /// Creates a throw statement for <see cref="NotImplementedException"/>.
    /// </summary>
    /// <param name="includeSystem">If <c>true</c>, includes the System namespace prefix.</param>
    /// <returns>A <see cref="ThrowStatementSyntax"/> node throwing NotImplementedException.</returns>
    public static ThrowStatementSyntax CreateNotImplementedException(bool includeSystem = true)
    {
        if (includeSystem)
        {
            return SyntaxFactory.ThrowStatement(
                SyntaxObjectCreationExpressionFactory.Create("System", "NotImplementedException")
                    .WithArgumentList(SyntaxFactory.ArgumentList()));
        }

        return SyntaxFactory.ThrowStatement(
            SyntaxObjectCreationExpressionFactory.Create("NotImplementedException")
                .WithArgumentList(SyntaxFactory.ArgumentList()));
    }

    /// <summary>
    /// Creates a throw statement for <see cref="ArgumentNullException"/> with a parameter name.
    /// </summary>
    /// <param name="parameterName">The name of the null parameter.</param>
    /// <param name="includeSystem">If <c>true</c>, includes the System namespace prefix.</param>
    /// <returns>A <see cref="ThrowStatementSyntax"/> node throwing ArgumentNullException.</returns>
    public static ThrowStatementSyntax CreateArgumentNullException(string parameterName, bool includeSystem = true)
    {
        if (includeSystem)
        {
            return SyntaxFactory.ThrowStatement(
                SyntaxObjectCreationExpressionFactory.Create("System", nameof(ArgumentNullException))
                    .WithArgumentList(
                        SyntaxFactory.ArgumentList(
                            SyntaxFactory.SingletonSeparatedList(
                                SyntaxFactory.Argument(
                                    SyntaxFactory.InvocationExpression(SyntaxFactory.IdentifierName("nameof"))
                                        .WithArgumentList(
                                            SyntaxArgumentListFactory.CreateWithOneItem(parameterName)))))));
        }

        return SyntaxFactory.ThrowStatement(
            SyntaxObjectCreationExpressionFactory.Create(nameof(ArgumentNullException))
                .WithArgumentList(
                    SyntaxFactory.ArgumentList(
                        SyntaxFactory.SingletonSeparatedList(
                            SyntaxFactory.Argument(
                                SyntaxFactory.InvocationExpression(SyntaxFactory.IdentifierName("nameof"))
                                    .WithArgumentList(
                                        SyntaxArgumentListFactory.CreateWithOneItem(parameterName)))))));
    }
}