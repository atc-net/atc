namespace Atc.DotNet;

/// <summary>
/// Provides helper methods for extracting NuGet package references from .NET project files.
/// </summary>
public static class DotnetNugetHelper
{
    /// <summary>
    /// Extracts all PackageReference elements from a .csproj or similar project file.
    /// </summary>
    /// <param name="fileInfo">The project file to parse.</param>
    /// <returns>A sorted list of <see cref="DotnetNugetPackageMetadataBase"/> containing package IDs and versions.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="fileInfo"/> is null.</exception>
    /// <exception cref="FileNotFoundException">Thrown when the file does not exist.</exception>
    public static List<DotnetNugetPackageMetadataBase> GetAllPackageReferences(
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

        var fileContent = File.ReadAllText(fileInfo.FullName);
        return GetAllPackageReferences(fileContent);
    }

    /// <summary>
    /// Extracts all PackageReference elements from project file content.
    /// </summary>
    /// <param name="fileContent">The XML content of a project file.</param>
    /// <returns>A sorted list of <see cref="DotnetNugetPackageMetadataBase"/> containing package IDs and versions.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="fileContent"/> is null.</exception>
    /// <exception cref="DataException">Thrown when the content is not valid XML (does not start with '&lt;').</exception>
    public static List<DotnetNugetPackageMetadataBase> GetAllPackageReferences(
        string fileContent)
    {
        if (fileContent is null)
        {
            throw new ArgumentNullException(nameof(fileContent));
        }

        if (!fileContent.StartsWith('<'))
        {
            throw new DataException("Expect xml content");
        }

        var data = new List<DotnetNugetPackageMetadataBase>();
        foreach (var line in fileContent.EnsureEnvironmentNewLinesAndSplit())
        {
            if (!line.Contains("<PackageReference ", StringComparison.Ordinal) ||
                !line.Contains("Include=", StringComparison.Ordinal) ||
                !line.Contains("Version=", StringComparison.Ordinal))
            {
                continue;
            }

            var attributes = line
                .Replace("<PackageReference ", string.Empty, StringComparison.Ordinal)
                .Replace("/>", string.Empty, StringComparison.Ordinal)
                .Replace(">", string.Empty, StringComparison.Ordinal)
                .Trim()
                .Split(' ');

            var packageId = string.Empty;
            var version = string.Empty;

            foreach (var attribute in attributes)
            {
                if (attribute.StartsWith("Include=", StringComparison.Ordinal))
                {
                    packageId = attribute
                        .Replace("Include=", string.Empty, StringComparison.Ordinal)
                        .Replace("\"", string.Empty, StringComparison.Ordinal);
                }
                else if (attribute.StartsWith("Version=", StringComparison.Ordinal))
                {
                    version = attribute
                        .Replace("Version=", string.Empty, StringComparison.Ordinal)
                        .Replace("\"", string.Empty, StringComparison.Ordinal);
                }
            }

            if (!string.IsNullOrEmpty(packageId) &&
                !string.IsNullOrEmpty(version))
            {
                data.Add(new DotnetNugetPackageMetadataBase(packageId, version));
            }
        }

        return data
            .OrderBy(x => x.PackageId, StringComparer.Ordinal)
            .ToList();
    }
}