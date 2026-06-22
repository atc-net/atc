namespace Atc.CodeDocumentation;

/// <summary>
/// Provides public API methods for collecting and analyzing XML documentation comments from assemblies and types.
/// </summary>
public static class DocumentationHelper
{
    /// <summary>
    /// Collects XML documentation comments for a specific type from its assembly.
    /// </summary>
    /// <param name="type">The type to collect documentation for.</param>
    /// <returns>The type comments, or <see langword="null"/> if the type was not found.</returns>
    public static TypeComments? CollectExportedTypeWithCommentsFromType(
        Type type)
        => AssemblyCommentHelper.CollectExportedTypeWithComments(type);

    /// <summary>
    /// Collects XML documentation comments for a specific type using an explicit XML documentation file.
    /// </summary>
    /// <param name="type">The type to collect documentation for.</param>
    /// <param name="xmlDocPath">The explicit path to the XML documentation file.</param>
    /// <returns>The type comments, or <see langword="null"/> if the type was not found.</returns>
    public static TypeComments? CollectExportedTypeWithCommentsFromType(
        Type type,
        FileInfo xmlDocPath)
        => AssemblyCommentHelper.CollectExportedTypeWithComments(type, xmlDocPath);

    /// <summary>
    /// Collects all public types from an assembly that are missing XML documentation comments.
    /// </summary>
    /// <param name="assembly">The assembly to scan for types.</param>
    /// <param name="excludeTypes">Optional list of types to exclude from the results.</param>
    /// <returns>An array of type comments for types missing documentation.</returns>
    public static TypeComments[] CollectExportedTypesWithMissingCommentsFromAssembly(
        Assembly assembly,
        List<Type>? excludeTypes = null)
        => AssemblyCommentHelper.CollectExportedTypesWithMissingComments(
            assembly,
            namespaceMatch: null,
            excludeTypes);

    /// <summary>
    /// Collects all public types from an assembly that are missing XML documentation comments,
    /// using an explicit XML documentation file path.
    /// </summary>
    /// <param name="assembly">The assembly to scan for types.</param>
    /// <param name="xmlDocPath">The explicit path to the XML documentation file.</param>
    /// <param name="excludeTypes">Optional list of types to exclude from the results.</param>
    /// <returns>An array of type comments for types missing documentation.</returns>
    public static TypeComments[] CollectExportedTypesWithMissingCommentsFromAssembly(
        Assembly assembly,
        FileInfo xmlDocPath,
        List<Type>? excludeTypes = null)
        => AssemblyCommentHelper.CollectExportedTypesWithMissingComments(
            assembly,
            xmlDocPath,
            namespaceMatch: null,
            excludeTypes);

    /// <summary>
    /// Collects all public types from an assembly that are missing XML documentation and generates a formatted text report.
    /// </summary>
    /// <param name="assembly">The assembly to scan for types.</param>
    /// <param name="excludeTypes">Optional list of types to exclude from the results.</param>
    /// <param name="useFullName">If <see langword="true"/>, uses fully qualified type names in the output; otherwise uses simple names.</param>
    /// <returns>A string containing one type name per line for all types missing documentation.</returns>
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
    /// Collects all public types from an assembly that are missing XML documentation and generates an array of type names.
    /// </summary>
    /// <param name="assembly">The assembly to scan for types.</param>
    /// <param name="excludeTypes">Optional list of types to exclude from the results.</param>
    /// <param name="useFullName">If <see langword="true"/>, uses fully qualified type names in the output; otherwise uses simple names.</param>
    /// <returns>An array of type name strings, one per type missing documentation.</returns>
    public static string[] CollectExportedTypesWithMissingCommentsFromAssemblyAndGenerateTextLines(
        Assembly assembly,
        List<Type>? excludeTypes = null,
        bool useFullName = false)
    {
        if (assembly is null)
        {
            throw new ArgumentNullException(nameof(assembly));
        }

        return AssemblyCommentHelper
            .CollectExportedTypesWithMissingComments(
                assembly,
                namespaceMatch: null,
                excludeTypes)
            .Select(x => x.Type.BeautifyTypeName(useFullName))
            .ToArray();
    }
}