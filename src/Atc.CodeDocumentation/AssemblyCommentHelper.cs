namespace Atc.CodeDocumentation;

internal static class AssemblyCommentHelper
{
    public static TypeComments? CollectExportedTypeWithComments(Type type)
    {
        if (type is null)
        {
            throw new ArgumentNullException(nameof(type));
        }

        var xmlFile = GetXmlFileForAssembly(type.Assembly);
        return CollectExportedTypesWithComments(type.Assembly, xmlFile, namespaceMatch: null, excludeSourceTypes: null)
            .FirstOrDefault(x => string.Equals(x.FullName, type.FullName, StringComparison.Ordinal));
    }

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
        return CollectExportedTypesWithMissingComments(assembly, xmlFile, namespaceMatch, excludeSourceTypes);
    }

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
        return CollectExportedTypesWithComments(assembly, xmlFile, namespaceMatch, excludeSourceTypes);
    }

    public static string GetTypesAsRenderText(TypeComments[] typesWithMissingComments, bool useFullName)
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
        var xmlFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, assembly.GetName().Name + ".xml");
        if (File.Exists(xmlFile))
        {
            return new FileInfo(xmlFile);
        }

        throw new IOException($"No xml document found for the assembly: {assembly.FullName}, expected file: {xmlFile}");
    }

    private static bool IsRequiredNamespace(Type type, Regex? regex)
    {
        return regex is null || regex.IsMatch(type.Namespace ?? string.Empty);
    }

    private static TypeComments[] CollectExportedTypesWithMissingComments(
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

        var collectExportedTypesWithComments = CollectExportedTypesWithComments(assembly, xmlPath, namespaceMatch, excludeSourceTypes);

        var collectExportedTypesWithMissingComments = collectExportedTypesWithComments
            .Where(x => !x.HasComments)
            .OrderBy(x => x.Type.FullName)
            .ToArray();

        return collectExportedTypesWithMissingComments;
    }

    private static TypeComments[] CollectExportedTypesWithComments(
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
            ? new Regex(namespaceMatch)
            : null;

        return types
            .Where(x => IsRequiredNamespace(x, namespaceRegex))
            .Select(x => new TypeComments(x, commentsLookup!))
            .OrderBy(x => x.FullName)
            .ToArray();
    }

    [SuppressMessage("Microsoft.Design", "CA1031:Do not catch general exception types", Justification = "OK.")]
    private static Type[] CollectFilteredAssemblyTypes(Assembly assembly, List<Type>? excludeTypes)
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
                        && !x.GetCustomAttributes<ObsoleteAttribute>().Any()
                        && !x.GetCustomAttributes<CompilerGeneratedAttribute>().Any()
                        && !excludeTypes.Contains(x))
            .OrderBy(x => x.FullName)
            .ToArray();

        return types;
    }
}