namespace Atc.CodeDocumentation;

/// <summary>
/// Provides helper methods for collecting and processing XML documentation comments from assemblies.
/// </summary>
internal static class AssemblyCommentHelper
{
    /// <summary>
    /// Collects XML documentation comments for a specific type.
    /// </summary>
    /// <param name="type">The type to collect documentation for.</param>
    /// <returns>The type comments, or <see langword="null"/> if the type was not found.</returns>
    public static TypeComments? CollectExportedTypeWithComments(Type type)
    {
        if (type is null)
        {
            throw new ArgumentNullException(nameof(type));
        }

        var xmlFile = GetXmlFileForAssembly(type.Assembly);
        return CollectExportedTypesWithCommentsCore(type.Assembly, xmlFile, namespaceMatch: null, excludeSourceTypes: null)
            .FirstOrDefault(x => string.Equals(x.FullName, type.FullName, StringComparison.Ordinal));
    }

    /// <summary>
    /// Collects XML documentation comments for a specific type using an explicit XML documentation file.
    /// </summary>
    /// <param name="type">The type to collect documentation for.</param>
    /// <param name="xmlDocPath">The explicit path to the XML documentation file.</param>
    /// <returns>The type comments, or <see langword="null"/> if the type was not found.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="type"/> or <paramref name="xmlDocPath"/> is null.</exception>
    public static TypeComments? CollectExportedTypeWithComments(
        Type type,
        FileInfo xmlDocPath)
    {
        if (type is null)
        {
            throw new ArgumentNullException(nameof(type));
        }

        if (xmlDocPath is null)
        {
            throw new ArgumentNullException(nameof(xmlDocPath));
        }

        return CollectExportedTypesWithCommentsCore(type.Assembly, xmlDocPath, namespaceMatch: null, excludeSourceTypes: null)
            .FirstOrDefault(x => string.Equals(x.FullName, type.FullName, StringComparison.Ordinal));
    }

    /// <summary>
    /// Collects all public types from an assembly that are missing XML documentation comments.
    /// </summary>
    /// <param name="assembly">The assembly to scan for types.</param>
    /// <param name="namespaceMatch">Optional regex pattern to filter types by namespace.</param>
    /// <param name="excludeSourceTypes">Optional list of types to exclude from the results.</param>
    /// <returns>An array of type comments for types missing documentation.</returns>
    public static TypeComments[] CollectExportedTypesWithMissingComments(
        Assembly assembly,
        string? namespaceMatch = null,
        List<Type>? excludeSourceTypes = null)
    {
        if (assembly is null)
        {
            throw new ArgumentNullException(nameof(assembly));
        }

        var xmlFile = GetXmlFileForAssembly(assembly);
        return CollectExportedTypesWithMissingCommentsCore(assembly, xmlFile, namespaceMatch, excludeSourceTypes);
    }

    /// <summary>
    /// Collects all public types from an assembly that are missing XML documentation comments,
    /// using an explicit XML documentation file path.
    /// </summary>
    /// <param name="assembly">The assembly to scan for types.</param>
    /// <param name="xmlDocPath">The explicit path to the XML documentation file.</param>
    /// <param name="namespaceMatch">Optional regex pattern to filter types by namespace.</param>
    /// <param name="excludeSourceTypes">Optional list of types to exclude from the results.</param>
    /// <returns>An array of type comments for types missing documentation.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="assembly"/> or <paramref name="xmlDocPath"/> is null.</exception>
    public static TypeComments[] CollectExportedTypesWithMissingComments(
        Assembly assembly,
        FileInfo xmlDocPath,
        string? namespaceMatch = null,
        List<Type>? excludeSourceTypes = null)
    {
        if (assembly is null)
        {
            throw new ArgumentNullException(nameof(assembly));
        }

        if (xmlDocPath is null)
        {
            throw new ArgumentNullException(nameof(xmlDocPath));
        }

        return CollectExportedTypesWithMissingCommentsCore(assembly, xmlDocPath, namespaceMatch, excludeSourceTypes);
    }

    /// <summary>
    /// Collects all public types from an assembly along with their XML documentation comments.
    /// </summary>
    /// <param name="assembly">The assembly to scan for types.</param>
    /// <param name="namespaceMatch">Optional regex pattern to filter types by namespace.</param>
    /// <param name="excludeSourceTypes">Optional list of types to exclude from the results.</param>
    /// <returns>An array of type comments for all matching types.</returns>
    public static TypeComments[] CollectExportedTypesWithComments(
        Assembly assembly,
        string? namespaceMatch = null,
        List<Type>? excludeSourceTypes = null)
    {
        if (assembly is null)
        {
            throw new ArgumentNullException(nameof(assembly));
        }

        var xmlFile = GetXmlFileForAssembly(assembly);
        return CollectExportedTypesWithCommentsCore(assembly, xmlFile, namespaceMatch, excludeSourceTypes);
    }

    /// <summary>
    /// Collects all public types from an assembly along with their XML documentation comments,
    /// using an explicit XML documentation file path.
    /// </summary>
    /// <param name="assembly">The assembly to scan for types.</param>
    /// <param name="xmlDocPath">The explicit path to the XML documentation file.</param>
    /// <param name="namespaceMatch">Optional regex pattern to filter types by namespace.</param>
    /// <param name="excludeSourceTypes">Optional list of types to exclude from the results.</param>
    /// <returns>An array of type comments for all matching types.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="assembly"/> or <paramref name="xmlDocPath"/> is null.</exception>
    public static TypeComments[] CollectExportedTypesWithComments(
        Assembly assembly,
        FileInfo xmlDocPath,
        string? namespaceMatch = null,
        List<Type>? excludeSourceTypes = null)
    {
        if (assembly is null)
        {
            throw new ArgumentNullException(nameof(assembly));
        }

        if (xmlDocPath is null)
        {
            throw new ArgumentNullException(nameof(xmlDocPath));
        }

        return CollectExportedTypesWithCommentsCore(assembly, xmlDocPath, namespaceMatch, excludeSourceTypes);
    }

    /// <summary>
    /// Converts an array of type comments to a formatted text string, one type per line.
    /// </summary>
    /// <param name="typesWithMissingComments">The array of type comments to render.</param>
    /// <param name="useFullName">If <see langword="true"/>, uses fully qualified type names; otherwise uses simple names.</param>
    /// <returns>A string containing one type name per line.</returns>
    public static string GetTypesAsRenderText(
        TypeComments[] typesWithMissingComments,
        bool useFullName)
    {
        var sb = new StringBuilder();
        foreach (var item in typesWithMissingComments)
        {
            sb.AppendLine(item.Type.BeautifyTypeName(useFullName));
        }

        return sb.ToString();
    }

    private static FileInfo GetXmlFileForAssembly(Assembly assembly)
    {
        var assemblyDir = string.IsNullOrEmpty(assembly.Location)
            ? AppDomain.CurrentDomain.BaseDirectory
            : Path.GetDirectoryName(assembly.Location) ?? AppDomain.CurrentDomain.BaseDirectory;

        var xmlFile = Path.Combine(assemblyDir, assembly.GetName().Name + ".xml");
        if (File.Exists(xmlFile))
        {
            return new FileInfo(xmlFile);
        }

        var fallback = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, assembly.GetName().Name + ".xml");
        if (File.Exists(fallback))
        {
            return new FileInfo(fallback);
        }

        throw new IOException($"No xml document found for the assembly: {assembly.FullName}, expected file: {xmlFile}");
    }

    private static bool IsRequiredNamespace(
        Type type,
        Regex? regex)
        => regex is null ||
           regex.IsMatch(type.Namespace ?? string.Empty);

    private static TypeComments[] CollectExportedTypesWithMissingCommentsCore(
        Assembly assembly,
        FileSystemInfo xmlPath,
        string? namespaceMatch,
        List<Type>? excludeSourceTypes)
    {
        if (xmlPath is null)
        {
            throw new ArgumentNullException(nameof(xmlPath));
        }

        if (assembly is null)
        {
            throw new ArgumentNullException(nameof(assembly));
        }

        if (!xmlPath.Exists)
        {
            throw new IOException($"File don't exist: {xmlPath.FullName}");
        }

        var collectExportedTypesWithComments = CollectExportedTypesWithCommentsCore(assembly, xmlPath, namespaceMatch, excludeSourceTypes);

        var collectExportedTypesWithMissingComments = collectExportedTypesWithComments
            .Where(x => !x.HasComments)
            .OrderBy(x => x.Type.FullName, StringComparer.Ordinal)
            .ToArray();

        return collectExportedTypesWithMissingComments;
    }

    private static TypeComments[] CollectExportedTypesWithCommentsCore(
        Assembly assembly,
        FileSystemInfo xmlPath,
        string? namespaceMatch,
        List<Type>? excludeSourceTypes)
    {
        var types = CollectFilteredAssemblyTypes(assembly, excludeSourceTypes);

        var text = File.ReadAllText(xmlPath.FullName);
        var xDocument = XDocument.Parse(text);
        var comments = XmlDocumentCommentParser.ParseXmlComment(xDocument, namespaceMatch);
        var commentsLookup = comments.ToLookup(x => x!.ClassName, StringComparer.Ordinal);

        var namespaceRegex = !string.IsNullOrEmpty(namespaceMatch)
            ? new Regex(namespaceMatch, RegexOptions.None, TimeSpan.FromSeconds(1))
            : null;

        return types
            .Where(x => IsRequiredNamespace(x, namespaceRegex))
            .Select(x => new TypeComments(x, commentsLookup!))
            .OrderBy(x => x.FullName, StringComparer.Ordinal)
            .ToArray();
    }

    [SuppressMessage("Microsoft.Design", "CA1031:Do not catch general exception types", Justification = "OK.")]
    private static Type[] CollectFilteredAssemblyTypes(
        Assembly assembly,
        List<Type>? excludeTypes)
    {
        excludeTypes ??= new List<Type>();

        var types = new[] { assembly }
            .SelectMany(x =>
            {
                try
                {
                    return x.GetTypes();
                }
                catch (ReflectionTypeLoadException ex)
                {
                    return ex.Types.Where(t => t is not null);
                }
                catch
                {
                    return Type.EmptyTypes;
                }
            })
            .Where(x => x is not null
                        && x.IsPublic
                        && !x.AnyCustomAttributes<ObsoleteAttribute>()
                        && !x.AnyCustomAttributes<CompilerGeneratedAttribute>()
                        && !excludeTypes.Contains(x))
            .OrderBy(x => x!.FullName!, StringComparer.Ordinal)
            .ToArray();

        return types!;
    }
}