// ReSharper disable InvertIf
// ReSharper disable StringLiteralTypo
// ReSharper disable IdentifierTypo
// ReSharper disable CommentTypo
// ReSharper disable GrammarMistakeInComment
namespace Atc.DotNet;

/// <summary>
/// Utilities for discovering Visual Studio solution files and extracting basic metadata
/// from both the classic text-based <c>.sln</c> format and the newer XML-based <c>.slnx</c> format.
/// </summary>
/// <remarks>
/// <para>
/// <b>.sln</b> files contain header lines that expose values such as:
/// <c>Microsoft Visual Studio Solution File, Format Version X.Y</c>,
/// <c># Visual Studio 17</c>, <c>VisualStudioVersion</c>, and <c>MinimumVisualStudioVersion</c>.
/// These are parsed directly from the text.
/// </para>
/// <para>
/// <b>.slnx</b> files are XML and typically do not include the same header fields. When available,
/// this helper reads Visual Studio–related properties under
/// <c>&lt;Properties Name="Visual Studio"&gt;</c>. In particular, an
/// optional <c>&lt;Property Name="OpenWith" Value="17" /&gt;</c> is interpreted as the
/// <see cref="VisualStudioSolutionFileMetadata.VisualStudioVersionNumber"/> (e.g., 17 for VS 2022/2025).
/// If an XML file omits these properties, the corresponding metadata fields remain at their defaults.
/// </para>
/// </remarks>
public static class VisualStudioSolutionFileHelper
{
    /// <summary>
    /// Recursively finds both <c>.sln</c> and <c>.slnx</c> files under the specified directory.
    /// </summary>
    /// <param name="directoryInfo">Root directory to search from.</param>
    /// <param name="searchOption">
    /// Search depth. Defaults to <see cref="SearchOption.AllDirectories"/> to recurse into subfolders.
    /// </param>
    /// <returns>
    /// A collection of <see cref="FileInfo"/> objects representing all matching solution files.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="directoryInfo"/> is <c>null</c>.</exception>
    /// <remarks>
    /// This method is resilient to <see cref="DirectoryNotFoundException"/> and
    /// <see cref="UnauthorizedAccessException"/> while traversing; such errors are swallowed and
    /// the offending paths are skipped.
    /// </remarks>
    public static Collection<FileInfo> FindAllInPath(
        DirectoryInfo directoryInfo,
        SearchOption searchOption = SearchOption.AllDirectories)
    {
        if (directoryInfo is null)
        {
            throw new ArgumentNullException(nameof(directoryInfo));
        }

        var result = new Collection<FileInfo>();

        var files = SafeEnumerate(directoryInfo.FullName, "*.sln", searchOption)
            .Concat(SafeEnumerate(directoryInfo.FullName, "*.slnx", searchOption))
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .OrderBy(p => p, StringComparer.OrdinalIgnoreCase);

        foreach (var file in files)
        {
            result.Add(new FileInfo(file));
        }

        return result;
    }

    /// <summary>
    /// Reads a <c>.sln</c> or <c>.slnx</c> file from disk and returns parsed metadata.
    /// </summary>
    /// <param name="fileInfo">A <see cref="FileInfo"/> pointing to the solution file.</param>
    /// <returns>Populated <see cref="VisualStudioSolutionFileMetadata"/> for the given file.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="fileInfo"/> is <c>null</c>.</exception>
    /// <exception cref="FileNotFoundException">
    /// The file does not exist, or the extension is not one of <c>.sln</c> or <c>.slnx</c>.
    /// </exception>
    /// <remarks>
    /// For <c>.slnx</c> (XML) solutions, only properties present in the XML are populated. If the
    /// <c>OpenWith</c> property is present under <c>&lt;Properties Name="Visual Studio"&gt;</c>, it is
    /// parsed as <see cref="VisualStudioSolutionFileMetadata.VisualStudioVersionNumber"/>.
    /// </remarks>
    public static VisualStudioSolutionFileMetadata GetSolutionFileMetadata(
        FileInfo fileInfo)
    {
        if (fileInfo is null)
        {
            throw new ArgumentNullException(nameof(fileInfo));
        }

        if (!fileInfo.Exists)
        {
            throw new FileNotFoundException();
        }

        var ext = fileInfo.Extension;
        if (!ext.Equals(".sln", StringComparison.OrdinalIgnoreCase) &&
            !ext.Equals(".slnx", StringComparison.OrdinalIgnoreCase))
        {
            throw new FileNotFoundException($"Unsupported solution file extension: {ext}");
        }

        var fileContent = File.ReadAllText(fileInfo.FullName);
        return GetSolutionFileMetadata(fileContent);
    }

    /// <summary>
    /// Detects the solution format from <paramref name="fileContent"/> and extracts metadata.
    /// </summary>
    /// <param name="fileContent">Raw file text of either a <c>.sln</c> or <c>.slnx</c> file.</param>
    /// <returns>
    /// A <see cref="VisualStudioSolutionFileMetadata"/> instance with any discoverable fields populated.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="fileContent"/> is <c>null</c>.</exception>
    /// <remarks>
    /// <para>
    /// If the content parses as XML and the root element is <c>Solution</c>, it is treated as <c>.slnx</c>
    /// and Visual Studio properties are read from the <c>&lt;Properties Name="Visual Studio"&gt;</c> node.
    /// </para>
    /// <para>
    /// Otherwise the content is treated as a classic <c>.sln</c> and the header lines are parsed:
    /// <c>Format Version</c>, <c># Visual Studio</c>, <c>VisualStudioVersion</c>, and
    /// <c>MinimumVisualStudioVersion</c>.
    /// </para>
    /// </remarks>
    public static VisualStudioSolutionFileMetadata GetSolutionFileMetadata(
        string fileContent)
    {
        if (fileContent is null)
        {
            throw new ArgumentNullException(nameof(fileContent));
        }

        // Try SLNX (XML) first – it won’t have the .sln header lines.
        if (TryParseSlnx(fileContent, out var xmlData))
        {
            return xmlData;
        }

        // Fallback: classic .sln text parsing (your original logic, with tiny hardening).
        var data = new VisualStudioSolutionFileMetadata();

        foreach (var rawLine in fileContent.EnsureEnvironmentNewLines().Split(Environment.NewLine))
        {
            var line = rawLine.Trim();

            if (data.FileFormatVersion.Major == 0 &&
                line.StartsWith("Microsoft Visual Studio Solution File, Format Version", StringComparison.Ordinal))
            {
                var s = line
                    .Replace("Microsoft Visual Studio Solution File, Format Version", string.Empty, StringComparison.Ordinal)
                    .Trim();

                if (Version.TryParse(s, out var version))
                {
                    data.FileFormatVersion = version;
                }
            }
            else if (data.VisualStudioVersionNumber == 0 &&
                     line.StartsWith("# Visual Studio", StringComparison.Ordinal))
            {
                var lastSpaceIndex = line.LastIndexOf(' ');
                if (lastSpaceIndex >= 0 && lastSpaceIndex < line.Length - 1)
                {
                    var s = line[(lastSpaceIndex + 1)..];
                    if (int.TryParse(s, NumberStyles.Any, GlobalizationConstants.EnglishCultureInfo, out var vsMajor))
                    {
                        data.VisualStudioVersionNumber = vsMajor;
                    }
                }
            }
            else if (data.VisualStudioVersion.Major == 0 &&
                     line.StartsWith("VisualStudioVersion", StringComparison.Ordinal))
            {
                var s = line
                    .Replace("VisualStudioVersion", string.Empty, StringComparison.Ordinal)
                    .Replace("=", string.Empty, StringComparison.Ordinal)
                    .Trim();

                if (Version.TryParse(s, out var version))
                {
                    data.VisualStudioVersion = version;
                }
            }
            else if (data.MinimumVisualStudioVersion.Major == 0 &&
                     line.StartsWith("MinimumVisualStudioVersion", StringComparison.Ordinal))
            {
                var s = line
                    .Replace("MinimumVisualStudioVersion", string.Empty, StringComparison.Ordinal)
                    .Replace("=", string.Empty, StringComparison.Ordinal)
                    .Trim();

                if (Version.TryParse(s, out var version))
                {
                    data.MinimumVisualStudioVersion = version;
                }
            }
        }

        return data;
    }

    /// <summary>
    /// Attempts to parse <paramref name="content"/> as an XML-based <c>.slnx</c> solution and extract metadata.
    /// </summary>
    /// <param name="content">Raw XML text for a <c>.slnx</c> file.</param>
    /// <param name="data">
    /// When this method returns, contains the parsed metadata if the operation succeeded; otherwise the default value.
    /// </param>
    /// <returns>
    /// <see langword="true"/> if <paramref name="content"/> was recognized as a <c>.slnx</c> solution and parsed;
    /// otherwise <see langword="false"/>.
    /// </returns>
    /// <remarks>
    /// A file is recognized as <c>.slnx</c> when it parses as XML and its root element is <c>&lt;Solution&gt;</c>.
    /// The method looks for a <c>&lt;Properties Name="Visual Studio"&gt;</c> element and reads properties beneath it:
    /// <list type="bullet">
    /// <item>
    /// <description><c>OpenWith</c> → <see cref="VisualStudioSolutionFileMetadata.VisualStudioVersionNumber"/></description>
    /// </item>
    /// <item>
    /// <description><c>VisualStudioVersion</c> (if present) → <see cref="VisualStudioSolutionFileMetadata.VisualStudioVersion"/></description>
    /// </item>
    /// <item>
    /// <description><c>MinimumVisualStudioVersion</c> (if present) → <see cref="VisualStudioSolutionFileMetadata.MinimumVisualStudioVersion"/></description>
    /// </item>
    /// <item>
    /// <description><c>FileFormatVersion</c> (if present) → <see cref="VisualStudioSolutionFileMetadata.FileFormatVersion"/></description>
    /// </item>
    /// </list>
    /// </remarks>
    [SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "OK.")]
    private static bool TryParseSlnx(
        string content,
        out VisualStudioSolutionFileMetadata data)
    {
        var result = new VisualStudioSolutionFileMetadata();

        var trimmedSpan = content
            .AsSpan()
            .TrimStart();

        if (trimmedSpan.Length == 0 || trimmedSpan[0] != '<')
        {
            data = result;
            return false;
        }

        var toParse = trimmedSpan.ToString();

        XDocument doc;

        try
        {
            doc = XDocument.Parse(toParse, LoadOptions.PreserveWhitespace | LoadOptions.SetLineInfo);
        }
        catch
        {
            data = result;
            return false;
        }

        var root = doc.Root;
        if (root is null || !root.Name.LocalName.Equals("Solution", StringComparison.Ordinal))
        {
            data = result;
            return false;
        }

        var vsProps = root.Elements()
            .FirstOrDefault(e => e.Name.LocalName.Equals("Properties", StringComparison.Ordinal) &&
                                 string.Equals((string?)e.Attribute("Name"), "Visual Studio", StringComparison.Ordinal));

        if (vsProps is not null)
        {
            var openWith = vsProps.Elements().FirstOrDefault(e =>
                e.Name.LocalName.Equals("Property", StringComparison.Ordinal) &&
                string.Equals((string?)e.Attribute("Name"), "OpenWith", StringComparison.Ordinal));

            var value = (string?)openWith?.Attribute("Value");
            if (!string.IsNullOrWhiteSpace(value) &&
                int.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out var vsMajor))
            {
                result.VisualStudioVersionNumber = vsMajor;
            }

            TrySetVersionFromProperty(vsProps, "VisualStudioVersion", v => result.VisualStudioVersion = v);
            TrySetVersionFromProperty(vsProps, "MinimumVisualStudioVersion", v => result.MinimumVisualStudioVersion = v);
            TrySetVersionFromProperty(vsProps, "FileFormatVersion", v => result.FileFormatVersion = v);
        }

        data = result;
        return true;
    }

    /// <summary>
    /// Looks for a <c>&lt;Property /&gt;</c> element with the given <paramref name="propertyName"/> and,
    /// if present and parsable as a <see cref="Version"/>, invokes <paramref name="setter"/>.
    /// </summary>
    /// <param name="propsElement">The parent <c>&lt;Properties /&gt;</c> element.</param>
    /// <param name="propertyName">Name of the property to read (e.g., <c>VisualStudioVersion</c>).</param>
    /// <param name="setter">Callback that receives the parsed <see cref="Version"/>.</param>
    private static void TrySetVersionFromProperty(
        XElement propsElement,
        string propertyName,
        Action<Version> setter)
    {
        var node = propsElement
            .Elements()
            .FirstOrDefault(e =>
                e.Name.LocalName.Equals("Property", StringComparison.Ordinal) &&
                string.Equals((string?)e.Attribute("Name"), propertyName, StringComparison.Ordinal));

        var str = (string?)node?.Attribute("Value");
        if (!string.IsNullOrWhiteSpace(str) &&
            Version.TryParse(str, out var ver))
        {
            setter(ver);
        }
    }

    /// <summary>
    /// Enumerates files matching <paramref name="pattern"/> while suppressing
    /// <see cref="DirectoryNotFoundException"/> and <see cref="UnauthorizedAccessException"/>.
    /// </summary>
    /// <param name="root">Root directory path to search in.</param>
    /// <param name="pattern">Search pattern (e.g., <c>"*.sln"</c>).</param>
    /// <param name="searchOption">Search depth.</param>
    /// <returns>An enumerable of file paths, or an empty sequence if access errors occur.</returns>
    private static IEnumerable<string> SafeEnumerate(
        string root,
        string pattern,
        SearchOption searchOption)
    {
        try
        {
            return Directory.EnumerateFiles(root, pattern, searchOption);
        }
        catch (DirectoryNotFoundException)
        {
            return Enumerable.Empty<string>();
        }
        catch (UnauthorizedAccessException)
        {
            return Enumerable.Empty<string>();
        }
    }
}