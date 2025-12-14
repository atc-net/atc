// ReSharper disable once CheckNamespace
namespace System.ComponentModel.DataAnnotations;

/// <summary>
/// Extension methods for <see cref="RegularExpressionAttribute"/>.
/// </summary>
public static class RegularExpressionAttributeExtensions
{
    /// <summary>
    /// Gets the escaped pattern from a <see cref="RegularExpressionAttribute"/> suitable for code generation.
    /// </summary>
    /// <param name="regularExpressionAttribute">The regular expression attribute.</param>
    /// <param name="ensureQuotes">If set to <see langword="true"/>, ensures the result is wrapped in double quotes.</param>
    /// <returns>The escaped pattern string.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="regularExpressionAttribute"/> is <see langword="null"/>.</exception>
    public static string GetEscapedPattern(
        this RegularExpressionAttribute regularExpressionAttribute,
        bool ensureQuotes = true)
    {
        if (regularExpressionAttribute is null)
        {
            throw new ArgumentNullException(nameof(regularExpressionAttribute));
        }

        if (!regularExpressionAttribute.Pattern.Contains(@"\\", StringComparison.Ordinal))
        {
            return FormatStringLiteral(regularExpressionAttribute.Pattern, quote: ensureQuotes);
        }

        if (ensureQuotes &&
            !regularExpressionAttribute.Pattern.StartsWith('"') &&
            !regularExpressionAttribute.Pattern.EndsWith('"'))
        {
            return $"\"{regularExpressionAttribute.Pattern}\"";
        }

        return regularExpressionAttribute.Pattern;
    }

    /// <summary>
    /// Formats a string as a C# string literal with proper escaping.
    /// Replacement for SymbolDisplay.FormatLiteral to avoid Roslyn dependency.
    /// </summary>
    private static string FormatStringLiteral(
        string value,
        bool quote)
    {
        var sb = new StringBuilder();

        if (quote)
        {
            sb.Append('"');
        }

        foreach (var c in value)
        {
            switch (c)
            {
                case '\\':
                    sb.Append(@"\\");
                    break;
                case '"':
                    sb.Append("\\\"");
                    break;
                case '\n':
                    sb.Append(@"\n");
                    break;
                case '\r':
                    sb.Append(@"\r");
                    break;
                case '\t':
                    sb.Append(@"\t");
                    break;
                case '\0':
                    sb.Append(@"\0");
                    break;
                default:
                    sb.Append(c);
                    break;
            }
        }

        if (quote)
        {
            sb.Append('"');
        }

        return sb.ToString();
    }
}