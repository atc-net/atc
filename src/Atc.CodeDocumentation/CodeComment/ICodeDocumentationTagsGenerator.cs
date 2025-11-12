namespace Atc.CodeDocumentation.CodeComment;

/// <summary>
/// Defines methods for generating XML documentation comment tags from structured documentation data.
/// </summary>
public interface ICodeDocumentationTagsGenerator
{
    /// <summary>
    /// Determines whether XML documentation tags should be generated for the specified documentation.
    /// </summary>
    /// <param name="codeDocumentationTags">The code documentation tags to evaluate.</param>
    /// <returns><see langword="true"/> if tags should be generated; otherwise, <see langword="false"/>.</returns>
    bool ShouldGenerateTags(CodeDocumentationTags codeDocumentationTags);

    /// <summary>
    /// Generates formatted XML documentation comment tags from the specified documentation data.
    /// </summary>
    /// <param name="indentSpaces">The number of spaces to use for indentation.</param>
    /// <param name="codeDocumentationTags">The code documentation tags to generate.</param>
    /// <returns>A string containing the formatted XML documentation comment tags.</returns>
    string GenerateTags(
        ushort indentSpaces,
        CodeDocumentationTags codeDocumentationTags);
}