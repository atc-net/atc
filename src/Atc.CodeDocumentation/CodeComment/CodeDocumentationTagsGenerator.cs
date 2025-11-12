// ReSharper disable ConvertIfStatementToConditionalTernaryExpression
namespace Atc.CodeDocumentation.CodeComment;

/// <summary>
/// Generates formatted XML documentation comment tags from structured code documentation data.
/// </summary>
public class CodeDocumentationTagsGenerator : ICodeDocumentationTagsGenerator
{
    /// <inheritdoc/>
    public bool ShouldGenerateTags(CodeDocumentationTags codeDocumentationTags)
    {
        if (codeDocumentationTags is null)
        {
            throw new ArgumentNullException(nameof(codeDocumentationTags));
        }

        if (codeDocumentationTags.Parameters is not null ||
            codeDocumentationTags.Remark is not null ||
            codeDocumentationTags.Code is not null ||
            codeDocumentationTags.Example is not null ||
            codeDocumentationTags.Exceptions is not null ||
            codeDocumentationTags.Return is not null)
        {
            return true;
        }

        return !string.IsNullOrEmpty(codeDocumentationTags.Summary) &&
               !codeDocumentationTags.Summary.StartsWith(Constants.UndefinedDescription, StringComparison.Ordinal);
    }

    /// <inheritdoc/>
    public string GenerateTags(
        ushort indentSpaces,
        CodeDocumentationTags codeDocumentationTags)
    {
        if (codeDocumentationTags is null)
        {
            throw new ArgumentNullException(nameof(codeDocumentationTags));
        }

        if (!ShouldGenerateTags(codeDocumentationTags))
        {
            return string.Empty;
        }

        var sb = new StringBuilder();
        sb.Append(GenerateSummary(indentSpaces, codeDocumentationTags.Summary));

        if (codeDocumentationTags.Parameters is not null &&
            codeDocumentationTags.Parameters.Any())
        {
            sb.Append(GenerateParameters(indentSpaces, codeDocumentationTags.Parameters));
        }

        if (!string.IsNullOrEmpty(codeDocumentationTags.Remark))
        {
            sb.Append(GenerateRemarks(indentSpaces, codeDocumentationTags.Remark));
        }

        //// TODO: Append 'Code' if needed.

        //// TODO: Append 'Example' if needed.

        //// TODO: Append 'Exception' if needed.

        if (!string.IsNullOrEmpty(codeDocumentationTags.Return))
        {
            sb.Append(GenerateReturns(indentSpaces, codeDocumentationTags.Return));
        }

        return sb.ToString();
    }

    private static string GenerateSummary(
        ushort indentSpaces,
        string value)
        => GenerateTag(indentSpaces, "summary", value);

    private static string GenerateParameters(
        ushort indentSpaces,
        IReadOnlyDictionary<string, string> parameters)
    {
        var sb = new StringBuilder();
        foreach (var (name, description) in parameters)
        {
            sb.AppendLine(indentSpaces, $"/// <param name=\"{name}\">{description.EnsureEndsWithDot()}</param>");
        }

        return sb.ToString();
    }

    private static string GenerateRemarks(
        ushort indentSpaces,
        string value)
        => GenerateTag(indentSpaces, "remarks", value);

    private static string GenerateReturns(
        ushort indentSpaces,
        string value)
        => GenerateTag(indentSpaces, "returns", value);

    private static string GenerateTag(
        ushort indentSpaces,
        string tag,
        string value)
    {
        var sb = new StringBuilder();
        sb.AppendLine(indentSpaces, $"/// <{tag}>");

        var lines = value
            .EnsureEnvironmentNewLines()
            .Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

        for (var i = 0; i < lines.Length; i++)
        {
            var line = lines[i];
            if (i == lines.Length - 1)
            {
                sb.AppendLine(indentSpaces, $"/// {line.EnsureEndsWithDot()}");
            }
            else
            {
                sb.AppendLine(indentSpaces, $"/// {line}");
            }
        }

        sb.AppendLine(indentSpaces, $"/// </{tag}>");
        return sb.ToString();
    }
}