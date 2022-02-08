// ReSharper disable once CheckNamespace
namespace System.Text;

/// <summary>
/// Extensions for the <see cref="StringBuilder"/> class.
/// </summary>
public static class StringBuilderExtensions
{
    /// <summary>
    /// Appends a formatting options to the string builder.
    /// </summary>
    /// <param name="sb">The <see cref="StringBuilder"/>.</param>
    /// <param name="format">A composite format string.</param>
    /// <param name="args">An object array that contains zero or more objects to format.</param>
    public static void Append(this StringBuilder sb, string format, params object[] args)
    {
        if (sb is null)
        {
            throw new ArgumentNullException(nameof(sb));
        }

        if (format is null)
        {
            throw new ArgumentNullException(nameof(format));
        }

        if (args is null)
        {
            throw new ArgumentNullException(nameof(args));
        }

        sb.Append(string.Format(GlobalizationConstants.EnglishCultureInfo, format, args));
    }

    /// <summary>
    /// Appends a new line with formatting options to the string builder.
    /// </summary>
    /// <param name="sb">The <see cref="StringBuilder"/>.</param>
    /// <param name="format">A composite format string.</param>
    /// <param name="args">An object array that contains zero or more objects to format.</param>
    public static void AppendLine(this StringBuilder sb, string format, params object[] args)
    {
        if (sb is null)
        {
            throw new ArgumentNullException(nameof(sb));
        }

        if (format is null)
        {
            throw new ArgumentNullException(nameof(format));
        }

        if (args is null)
        {
            throw new ArgumentNullException(nameof(args));
        }

        sb.AppendLine(string.Format(GlobalizationConstants.EnglishCultureInfo, format, args));
    }

    /// <summary>
    /// Appends a new line with indented spaces to the string builder.
    /// </summary>
    /// <param name="sb">The sb.</param>
    /// <param name="indentSpaces">The indent spaces.</param>
    /// <param name="value">The value.</param>
    public static void AppendLine(this StringBuilder sb, int indentSpaces, string value)
    {
        if (sb is null)
        {
            throw new ArgumentNullException(nameof(sb));
        }

        if (indentSpaces < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(value));
        }

        if (value is null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        sb.AppendLine(value.PadLeft(value.Length + indentSpaces));
    }
}