namespace Atc.CodeAnalysis.CSharp.SyntaxFactories;

public static class SyntaxInterpolatedFactory
{
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

    public static InterpolatedStringContentSyntax StringTextColon()
    {
        return StringText(": ");
    }

    public static InterpolatedStringContentSyntax StringTextComma()
    {
        return StringText(", ");
    }

    public static InterpolatedStringContentSyntax StringTextDotCountColon()
    {
        return StringText(".Count: ");
    }

    public static InterpolatedStringContentSyntax StringTextColonAndParenthesesStart()
    {
        return StringText(": (");
    }

    public static InterpolatedStringContentSyntax StringTextParenthesesEnd()
    {
        return StringText(")");
    }

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