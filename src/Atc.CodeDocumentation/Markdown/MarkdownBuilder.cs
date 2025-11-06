namespace Atc.CodeDocumentation.Markdown;

/// <summary>
/// Provides a fluent API for building markdown-formatted documentation.
/// </summary>
internal sealed class MarkdownBuilder
{
    private readonly StringBuilder sb = new();

    /// <summary>
    /// Wraps the specified code text in markdown inline code formatting.
    /// </summary>
    /// <param name="code">The code text to format.</param>
    /// <returns>The code text wrapped in backticks.</returns>
    public static string MarkdownCodeQuote(string code)
    {
        return "`" + code + "`";
    }

    /// <summary>
    /// Appends text to the markdown output without adding a line break.
    /// </summary>
    /// <param name="text">The text to append.</param>
    public void Append(string text)
    {
        sb.Append(text);
    }

    /// <summary>
    /// Appends a line break to the markdown output.
    /// </summary>
    public void AppendLine()
    {
        sb.AppendLine();
    }

    /// <summary>
    /// Appends text with HTML non-breaking space indentation.
    /// </summary>
    /// <param name="indentSpaces">The number of non-breaking spaces to use for indentation.</param>
    /// <param name="text">The text to append.</param>
    public void AppendLine(
        int indentSpaces,
        string text)
    {
        var sbLocal = new StringBuilder();
        for (var i = 0; i < indentSpaces; i++)
        {
            sbLocal.Append("&nbsp;");
        }

        sb.AppendLine(sbLocal + text);
    }

    /// <summary>
    /// Appends a line of text to the markdown output.
    /// </summary>
    /// <param name="text">The text to append.</param>
    public void AppendLine(string text)
    {
        sb.AppendLine(text);
    }

    /// <summary>
    /// Appends a markdown header of the specified level.
    /// </summary>
    /// <param name="level">The header level (1-6, where 1 is largest).</param>
    /// <param name="text">The header text.</param>
    public void Header(
        int level,
        string text)
    {
        for (var i = 0; i < level; i++)
        {
            sb.Append('#');
        }

        sb.Append(' ');
        sb.AppendLine(text);
    }

    /// <summary>
    /// Appends a markdown header with inline code formatting.
    /// </summary>
    /// <param name="level">The header level (1-6, where 1 is largest).</param>
    /// <param name="code">The code text to display in the header.</param>
    public void HeaderWithCode(
        int level,
        string code)
    {
        for (var i = 0; i < level; i++)
        {
            sb.Append('#');
        }

        sb.Append(' ');
        CodeQuote(code);
        sb.AppendLine();
    }

    /// <summary>
    /// Appends a markdown header containing a hyperlink.
    /// </summary>
    /// <param name="level">The header level (1-6, where 1 is largest).</param>
    /// <param name="text">The link text to display.</param>
    /// <param name="url">The URL the link points to.</param>
    public void HeaderWithLink(
        int level,
        string text,
        string url)
    {
        for (var i = 0; i < level; i++)
        {
            sb.Append('#');
        }

        sb.Append(' ');
        Link(text, url);
        sb.AppendLine();
    }

    /// <summary>
    /// Appends a markdown hyperlink.
    /// </summary>
    /// <param name="text">The link text to display.</param>
    /// <param name="url">The URL the link points to.</param>
    public void Link(
        string text,
        string url)
    {
        sb.Append('[');
        sb.Append(text);
        sb.Append(']');
        sb.Append('(');
        sb.Append(url);
        sb.Append(')');
    }

    /// <summary>
    /// Appends a markdown image reference.
    /// </summary>
    /// <param name="altText">The alternative text for the image.</param>
    /// <param name="imageUrl">The URL of the image.</param>
    public void Image(
        string altText,
        string imageUrl)
    {
        sb.Append('!');
        Link(altText, imageUrl);
    }

    /// <summary>
    /// Appends a markdown code block with syntax highlighting for the specified language.
    /// </summary>
    /// <param name="language">The programming language for syntax highlighting.</param>
    /// <param name="code">The code content to display.</param>
    public void Code(
        string language,
        string code)
    {
        if (code.EndsWith('.'))
        {
            code = code[..^1];
        }

        if (code.EndsWith(Environment.NewLine, StringComparison.Ordinal))
        {
            code = code.Substring(0, code.Length - Environment.NewLine.Length);
        }

        code = code.Replace(Environment.NewLine, Environment.NewLine + ">", StringComparison.Ordinal);

        sb.Append(">```");
        sb.AppendLine(language);
        sb.Append('>');
        sb.AppendLine(code);
        sb.AppendLine(">```");
    }

    /// <summary>
    /// Appends inline code formatting with backticks.
    /// </summary>
    /// <param name="code">The code text to format.</param>
    public void CodeQuote(string code)
    {
        sb.Append('`');
        sb.Append(code);
        sb.Append('`');
    }

    /// <summary>
    /// Appends a markdown table with the specified headers and rows.
    /// </summary>
    /// <param name="headers">The column headers for the table.</param>
    /// <param name="items">The table rows, where each row is an array of cell values.</param>
    public void Table(
        string[] headers,
        List<string[]> items)
    {
        sb.Append("| ");
        foreach (var item in headers)
        {
            sb.Append(item);
            sb.Append(" | ");
        }

        sb.AppendLine();

        sb.Append("| ");
        foreach (var unused in headers)
        {
            sb.Append("---");
            sb.Append(" | ");
        }

        sb.AppendLine();

        foreach (var item in items)
        {
            sb.Append("| ");
            foreach (var item2 in item)
            {
                sb.Append(item2);
                sb.Append(" | ");
            }

            sb.AppendLine();
        }

        sb.AppendLine();
    }

    /// <summary>
    /// Appends an unordered list item (no nesting).
    /// </summary>
    /// <param name="text">The list item text.</param>
    public void List(string text) // nest zero
    {
        sb.Append("- ");
        sb.AppendLine(text);
    }

    /// <summary>
    /// Appends an unordered list item containing a hyperlink (no nesting).
    /// </summary>
    /// <param name="text">The link text to display.</param>
    /// <param name="url">The URL the link points to.</param>
    public void ListLink(
        string text,
        string url) // nest zero
    {
        sb.Append("- ");
        Link(text, url);
        sb.AppendLine();
    }

    /// <summary>
    /// Appends a nested sublist containing the members of the specified type.
    /// </summary>
    /// <param name="typeComments">The type comments containing member information to render as a sublist.</param>
    public void SubList(TypeComments typeComments)
    {
        var s = MarkdownHelper.RenderSubList(typeComments);
        if (!string.IsNullOrEmpty(s))
        {
            sb.Append(s);
        }
    }

    /// <inheritdoc/>
    public override string ToString()
    {
        return sb.ToString();
    }
}