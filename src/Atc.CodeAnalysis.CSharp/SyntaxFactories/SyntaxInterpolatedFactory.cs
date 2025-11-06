namespace Atc.CodeAnalysis.CSharp.SyntaxFactories;

/// <summary>
/// Factory for creating <see cref="InterpolatedStringContentSyntax"/> nodes for interpolated strings.
/// </summary>
public static class SyntaxInterpolatedFactory
{
    /// <summary>
    /// Creates an interpolated string text content from a value.
    /// </summary>
    /// <param name="value">The text value to include in the interpolated string.</param>
    /// <returns>An <see cref="InterpolatedStringContentSyntax"/> representing the text.</returns>
    public static InterpolatedStringContentSyntax StringText(string value)
    {
        return SyntaxFactory.InterpolatedStringText()
            .WithTextToken(
                SyntaxFactory.Token(
                    SyntaxFactory.TriviaList(),
                    SyntaxKind.InterpolatedStringTextToken,
                    value,
                    value,
                    SyntaxFactory.TriviaList()));
    }

    /// <summary>
    /// Creates interpolated string text for a colon and space (": ").
    /// </summary>
    /// <returns>An <see cref="InterpolatedStringContentSyntax"/> representing ": ".</returns>
    public static InterpolatedStringContentSyntax StringTextColon()
    {
        return StringText(": ");
    }

    /// <summary>
    /// Creates interpolated string text for a comma and space (", ").
    /// </summary>
    /// <returns>An <see cref="InterpolatedStringContentSyntax"/> representing ", ".</returns>
    public static InterpolatedStringContentSyntax StringTextComma()
    {
        return StringText(", ");
    }

    /// <summary>
    /// Creates interpolated string text for ".Count: ".
    /// </summary>
    /// <returns>An <see cref="InterpolatedStringContentSyntax"/> representing ".Count: ".</returns>
    public static InterpolatedStringContentSyntax StringTextDotCountColon()
    {
        return StringText(".Count: ");
    }

    /// <summary>
    /// Creates interpolated string text for ": (".
    /// </summary>
    /// <returns>An <see cref="InterpolatedStringContentSyntax"/> representing ": (".</returns>
    public static InterpolatedStringContentSyntax StringTextColonAndParenthesesStart()
    {
        return StringText(": (");
    }

    /// <summary>
    /// Creates interpolated string text for ")".
    /// </summary>
    /// <returns>An <see cref="InterpolatedStringContentSyntax"/> representing ")".</returns>
    public static InterpolatedStringContentSyntax StringTextParenthesesEnd()
    {
        return StringText(")");
    }

    /// <summary>
    /// Creates an interpolated content node containing a nameof expression.
    /// </summary>
    /// <param name="argumentName">The name of the argument to use in the nameof expression.</param>
    /// <returns>An <see cref="InterpolatedStringContentSyntax"/> representing nameof(argumentName).</returns>
    public static InterpolatedStringContentSyntax CreateNameOf(string argumentName)
    {
        return SyntaxFactory.Interpolation(
            SyntaxFactory.InvocationExpression(SyntaxFactory.IdentifierName("nameof"))
                .WithArgumentList(
                    SyntaxFactory.ArgumentList(
                        SyntaxFactory.SingletonSeparatedList(
                            SyntaxFactory.Argument(SyntaxFactory.IdentifierName(argumentName))))));
    }
}