namespace Atc.DotNet;

public static class DotnetNugetHelper
{
    /// <summary>
    /// Get all PackageReferences from file.
    /// </summary>
    /// <param name="fileInfo">The file.</param>
    public static List<DotnetNugetPackageMetadataBase> GetAllPackageReferences(FileInfo fileInfo)
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
    /// Get all PackageReferences from file-content.
    /// </summary>
    /// <param name="fileContent">The file as text.</param>
    public static List<DotnetNugetPackageMetadataBase> GetAllPackageReferences(string fileContent)
    {
        if (fileContent is null)
        {
            throw new ArgumentNullException(nameof(fileContent));
        }

        if (!fileContent.StartsWith('<'))
        {
            throw new UnsupportedContentTypeException("Expect xml content");
        }

        var data = new List<DotnetNugetPackageMetadataBase>();
        foreach (var line in fileContent.EnsureEnvironmentNewLines().Split(Environment.NewLine))
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
            .OrderBy(x => x.PackageId)
            .ToList();
    }
}