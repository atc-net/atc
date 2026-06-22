// ReSharper disable InvertIf
namespace Atc.CodeAnalysis.CSharp.SyntaxFactories;

/// <summary>
/// Factory for creating <see cref="LiteralExpressionSyntax"/> nodes.
/// </summary>
public static class SyntaxLiteralExpressionFactory
{
    /// <summary>
    /// Creates a literal expression from a string value with the specified syntax kind.
    /// </summary>
    /// <param name="value">The value for the literal expression.</param>
    /// <param name="syntaxKind">The syntax kind for the literal (string or numeric).</param>
    /// <returns>A <see cref="LiteralExpressionSyntax"/> node.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="value"/> is null.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when value cannot be parsed as a numeric literal when syntaxKind is NumericLiteralExpression.</exception>
    public static LiteralExpressionSyntax Create(
        string value,
        SyntaxKind syntaxKind = SyntaxKind.StringLiteralExpression)
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

            // Support European decimal notation (comma as decimal separator): "12,345" → 12.345.
            // Thousands-separator values (e.g. "1,000") are not supported — they would silently
            // become 1.0, so callers must normalise such values before passing them in.
            var normalised = value.Replace(',', '.');
            if (double.TryParse(normalised, NumberStyles.Float, CultureInfo.InvariantCulture, out var parsedDouble))
            {
                return SyntaxFactory.LiteralExpression(syntaxKind, SyntaxFactory.Literal(parsedDouble));
            }

            // Value cannot be parsed as number.
            throw new ArgumentOutOfRangeException(nameof(value), "Cannot parse value as number");
        }

        return SyntaxFactory.LiteralExpression(syntaxKind, SyntaxFactory.Literal(value));
    }

    /// <summary>
    /// Creates a numeric literal expression from an integer value.
    /// </summary>
    /// <param name="value">The integer value for the literal expression.</param>
    /// <returns>A <see cref="LiteralExpressionSyntax"/> node representing the integer.</returns>
    public static LiteralExpressionSyntax Create(int value)
        => SyntaxFactory.LiteralExpression(SyntaxKind.NumericLiteralExpression, SyntaxFactory.Literal(value));
}