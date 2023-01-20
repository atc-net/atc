namespace Atc.DotNet;

public static class DotnetGlobalUsingsHelper
{
    public static void CreateOrUpdate(
        DirectoryInfo directoryInfo,
        IReadOnlyList<string> requiredNamespaces,
        bool setSystemFirst = true,
        bool addNamespaceSeparator = true)
    {
        if (directoryInfo is null)
        {
            throw new ArgumentNullException(nameof(directoryInfo));
        }

        if (requiredNamespaces is null)
        {
            throw new ArgumentNullException(nameof(requiredNamespaces));
        }

        var content = GetNewContentByReadingExistingIfExistAndMergeWithRequired(
            directoryInfo,
            requiredNamespaces,
            setSystemFirst,
            addNamespaceSeparator);

        if (string.IsNullOrEmpty(content))
        {
            return;
        }

        var globalUsingFile = new FileInfo(
            Path.Combine(
                directoryInfo.FullName,
                "GlobalUsings.cs"));

        FileHelper.WriteAllText(globalUsingFile, content);
    }

    public static string GetNewContentByReadingExistingIfExistAndMergeWithRequired(
        DirectoryInfo directoryInfo,
        IReadOnlyList<string> requiredNamespaces,
        bool setSystemFirst = true,
        bool addNamespaceSeparator = true)
    {
        if (directoryInfo is null)
        {
            throw new ArgumentNullException(nameof(directoryInfo));
        }

        if (requiredNamespaces is null)
        {
            throw new ArgumentNullException(nameof(requiredNamespaces));
        }

        var existingNamespaces = new List<string>();

        var globalUsingFile = new FileInfo(
            Path.Combine(
                directoryInfo.FullName,
                "GlobalUsings.cs"));

        if (globalUsingFile.Exists)
        {
            var text = FileHelper.ReadAllTextToLines(globalUsingFile);
            existingNamespaces = ExtractNamespacesFromUsings(text);
        }

        if (!requiredNamespaces.Any())
        {
            return existingNamespaces.Any()
                ? ConvertNamespacesToGlobalUsings(
                    existingNamespaces,
                    setSystemFirst,
                    addNamespaceSeparator)
                : string.Empty;
        }

        var namespaces = MergeNamespaces(
            requiredNamespaces,
            existingNamespaces);

        return ConvertNamespacesToGlobalUsings(
            namespaces,
            setSystemFirst,
            addNamespaceSeparator);
    }

    private static string ConvertNamespacesToGlobalUsings(
        IReadOnlyCollection<string> namespaces,
        bool setSystemFirst,
        bool addNamespaceSeparator)
    {
        var sb = new StringBuilder();

        if (setSystemFirst)
        {
            var sortedSystemNamespaces = namespaces
                .Where(x => x.Equals("System", StringComparison.Ordinal) ||
                            x.StartsWith("System.", StringComparison.Ordinal))
                .OrderBy(x => x, StringComparer.OrdinalIgnoreCase)
                .ToList();

            var sortedOtherNamespaces = namespaces
                .Where(x => !x.Equals("System", StringComparison.Ordinal) &&
                            !x.StartsWith("System.", StringComparison.Ordinal))
                .OrderBy(x => x, StringComparer.OrdinalIgnoreCase)
                .ToList();

            foreach (var item in sortedSystemNamespaces)
            {
                sb.AppendLine($"global using {item};", GlobalizationConstants.EnglishCultureInfo);
            }

            if (addNamespaceSeparator &&
                sortedSystemNamespaces.Any() &&
                sortedOtherNamespaces.Any())
            {
                sb.AppendLine();
            }

            sb.Append(ConvertNamespacesToGlobalUsings(addNamespaceSeparator, sortedOtherNamespaces));
        }
        else
        {
            var sortedNamespaces = namespaces
                .OrderBy(x => x, StringComparer.OrdinalIgnoreCase)
                .ToList();

            sb.Append(ConvertNamespacesToGlobalUsings(addNamespaceSeparator, sortedNamespaces));
        }

        return sb.ToString();
    }

    private static string ConvertNamespacesToGlobalUsings(
        bool addNamespaceSeparator,
        List<string> namespaces)
    {
        var sb = new StringBuilder();
        if (addNamespaceSeparator)
        {
            sb.Append(ConvertNamespacesToGlobalUsings(namespaces));
        }
        else
        {
            foreach (var item in namespaces)
            {
                sb.AppendLine($"global using {item};", GlobalizationConstants.EnglishCultureInfo);
            }
        }

        return sb.ToString();
    }

    private static string ConvertNamespacesToGlobalUsings(
        List<string> namespaces)
    {
        var sb = new StringBuilder();
        var lastNamespacePrefix = string.Empty;
        foreach (var item in namespaces)
        {
            if (string.IsNullOrEmpty(lastNamespacePrefix))
            {
                lastNamespacePrefix = item.Split('.').First();
            }
            else
            {
                var namespacePrefix = item.Split('.').First();
                if (!lastNamespacePrefix.Equals(namespacePrefix, StringComparison.Ordinal))
                {
                    lastNamespacePrefix = namespacePrefix;
                    sb.AppendLine();
                }
            }

            sb.AppendLine($"global using {item};", GlobalizationConstants.EnglishCultureInfo);
        }

        return sb.ToString();
    }

    private static List<string> ExtractNamespacesFromUsings(
        IEnumerable<string> lines)
    {
        var result = new List<string>();

        foreach (var line in lines)
        {
            if (string.IsNullOrWhiteSpace(line) ||
                line.Contains("//", StringComparison.Ordinal))
            {
                continue;
            }

            var trimLine = line
                .Replace("global ", string.Empty, StringComparison.Ordinal)
                .Replace("using ", string.Empty, StringComparison.Ordinal)
                .Replace(";", string.Empty, StringComparison.Ordinal)
                .Trim();

            if (string.IsNullOrWhiteSpace(trimLine))
            {
                continue;
            }

            if (!result.Contains(trimLine, StringComparer.Ordinal))
            {
                result.Add(trimLine);
            }
        }

        return result;
    }

    private static List<string> MergeNamespaces(
        IEnumerable<string> requiredNamespaces,
        IEnumerable<string> existingNamespaces)
    {
        var result = new List<string>();

        foreach (var item in requiredNamespaces.Where(x => !result.Contains(x, StringComparer.Ordinal)))
        {
            result.Add(item);
        }

        foreach (var item in existingNamespaces.Where(x => !result.Contains(x, StringComparer.Ordinal)))
        {
            result.Add(item);
        }

        return result;
    }
}