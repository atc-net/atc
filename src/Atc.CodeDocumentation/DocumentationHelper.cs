namespace Atc.CodeDocumentation;

/// <summary>
/// DocumentationHelper.
/// </summary>
public static class DocumentationHelper
{
    /// <summary>
    /// Collects the type of the exported type with comments from.
    /// </summary>
    /// <param name="type">The type.</param>
    public static TypeComments? CollectExportedTypeWithCommentsFromType(Type type)
    {
        return AssemblyCommentHelper.CollectExportedTypeWithComments(type);
    }

    /// <summary>
    /// Collects the exported types with missing comments from assembly.
    /// </summary>
    /// <param name="assembly">The assembly.</param>
    /// <param name="excludeTypes">The exclude types.</param>
    public static TypeComments[] CollectExportedTypesWithMissingCommentsFromAssembly(
        Assembly assembly,
        List<Type>? excludeTypes = null)
    {
        return AssemblyCommentHelper.CollectExportedTypesWithMissingComments(
            assembly,
            namespaceMatch: null,
            excludeTypes);
    }

    /// <summary>
    /// Collects the exported types with missing comments from assembly and generate text.
    /// </summary>
    /// <param name="assembly">The assembly.</param>
    /// <param name="excludeTypes">The exclude types.</param>
    /// <param name="useFullName">if set to <see langword="true" /> [use full name].</param>
    public static string CollectExportedTypesWithMissingCommentsFromAssemblyAndGenerateText(
        Assembly assembly,
        List<Type>? excludeTypes = null,
        bool useFullName = false)
    {
        var typesWithMissingComments = AssemblyCommentHelper.CollectExportedTypesWithMissingComments(
            assembly,
            namespaceMatch: null,
            excludeTypes);
        return AssemblyCommentHelper.GetTypesAsRenderText(typesWithMissingComments, useFullName);
    }

    /// <summary>
    /// Collects the exported types with missing comments from assembly and generate text lines.
    /// </summary>
    /// <param name="assembly">The assembly.</param>
    /// <param name="excludeTypes">The exclude types.</param>
    /// <param name="useFullName">if set to <see langword="true" /> [use full name].</param>
    public static string[] CollectExportedTypesWithMissingCommentsFromAssemblyAndGenerateTextLines(
        Assembly assembly,
        List<Type>? excludeTypes = null,
        bool useFullName = false)
    {
        if (assembly is null)
        {
            throw new ArgumentNullException(nameof(assembly));
        }

        return AssemblyCommentHelper.CollectExportedTypesWithMissingComments(
                assembly,
                namespaceMatch: null,
                excludeTypes)
            .Select(x => x.Type.BeautifyTypeName(useFullName))
            .ToArray();
    }
}