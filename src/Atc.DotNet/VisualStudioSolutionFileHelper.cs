// ReSharper disable InvertIf
namespace Atc.DotNet;

public static class VisualStudioSolutionFileHelper
{
    public static Collection<FileInfo> SearchAllForElement(
        DirectoryInfo directoryInfo,
        SearchOption searchOption = SearchOption.AllDirectories)
    {
        if (directoryInfo is null)
        {
            throw new ArgumentNullException(nameof(directoryInfo));
        }

        var result = new Collection<FileInfo>();
        var files = Directory.GetFiles(directoryInfo.FullName, "*.sln", searchOption);
        foreach (var file in files)
        {
            result.Add(new FileInfo(file));
        }

        return result;
    }

    public static VisualStudioSolutionFileMetadata GetSolutionFileMetadata(FileInfo fileInfo)
    {
        if (fileInfo is null)
        {
            throw new ArgumentNullException(nameof(fileInfo));
        }

        if (!fileInfo.Exists)
        {
            throw new FileNotFoundException();
        }

        if (!fileInfo.Extension.Equals(".sln", StringComparison.OrdinalIgnoreCase))
        {
            throw new FileNotFoundException();
        }

        var fileContent = File.ReadAllText(fileInfo.FullName);
        return GetSolutionFileMetadata(fileContent);
    }

    public static VisualStudioSolutionFileMetadata GetSolutionFileMetadata(string fileContent)
    {
        if (fileContent is null)
        {
            throw new ArgumentNullException(nameof(fileContent));
        }

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
                int lastSpaceIndex = line.LastIndexOf(' ');
                var s = line.Substring(lastSpaceIndex);
                if (int.TryParse(s, NumberStyles.Any, GlobalizationConstants.EnglishCultureInfo, out var version))
                {
                    data.VisualStudioVersionNumber = version;
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
}