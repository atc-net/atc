namespace Atc.CodeDocumentation.CodeComment;

public interface ICodeDocumentationTagsGenerator
{
    bool ShouldGenerateTags(
        CodeDocumentationTags codeDocumentationTags);

    string GenerateTags(
        ushort indentSpaces,
        CodeDocumentationTags codeDocumentationTags);
}