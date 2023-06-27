// ReSharper disable InvertIf
namespace Atc.CodeAnalysis.CSharp.SyntaxFactories;

public static class SyntaxLiteralExpressionFactory
{
    public static LiteralExpressionSyntax Create(string value, SyntaxKind syntaxKind = SyntaxKind.StringLiteralExpression)
    {
        if (value is null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        if (syntaxKind == SyntaxKind.NumericLiteralExpression)
        {
            if (int.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out var parsedInt))
            {
                return SyntaxFactory.LiteralExpression(syntaxKind, SyntaxFactory.Literal(parsedInt));
            }

            value = value.Replace(',', '.');
            if (double.TryParse(value, NumberStyles.Float, CultureInfo.InvariantCulture, out var parsedDouble))
            {
                return SyntaxFactory.LiteralExpression(syntaxKind, SyntaxFactory.Literal(parsedDouble));
            }

            // Value cannot be parsed as number.
            throw new ArgumentOutOfRangeException(nameof(value), "Cannot parse value as number");
        }

        return SyntaxFactory.LiteralExpression(syntaxKind, SyntaxFactory.Literal(value));
    }

    public static LiteralExpressionSyntax Create(int value)
    {
        return SyntaxFactory.LiteralExpression(SyntaxKind.NumericLiteralExpression, SyntaxFactory.Literal(value));
    }
}