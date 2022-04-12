// ReSharper disable SuggestBaseTypeForParameter
namespace Atc.DotNet.Tests;

public class VisualStudioSolutionFileHelperTests : IAsyncLifetime
{
    private static readonly DirectoryInfo WorkingDirectory = new (Path.Combine(Path.GetTempPath(), "atc-integration-test-solution-file-helper"));

    public Task InitializeAsync()
    {
        if (Directory.Exists(WorkingDirectory.FullName))
        {
            Directory.Delete(WorkingDirectory.FullName, recursive: true);
        }

        Directory.CreateDirectory(WorkingDirectory.FullName);

        return Task.CompletedTask;
    }

    public Task DisposeAsync()
    {
        if (Directory.Exists(WorkingDirectory.FullName))
        {
            Directory.Delete(WorkingDirectory.FullName, recursive: true);
        }

        return Task.CompletedTask;
    }

    [Theory]
    [MemberData(nameof(TestClassDataForVisualStudioSolutionFileMetadata.GetSolutionFileMetadata), MemberType = typeof(TestClassDataForVisualStudioSolutionFileMetadata))]
    public async Task GetSolutionFileMetadata_FileInfo(
        VisualStudioSolutionFileMetadata expected,
        int visualStudioVersionNumber)
    {
        // Arrange
        await CreateSolutionFile(WorkingDirectory, "Test.sln", visualStudioVersionNumber);
        var file = new FileInfo(Path.Combine(WorkingDirectory.FullName, "Test.sln"));

        // Atc
        var actual = VisualStudioSolutionFileHelper.GetSolutionFileMetadata(file);

        // Assert
        actual.Should()
            .NotBeNull()
            .And.BeEquivalentTo(expected);
    }

    [Theory]
    [MemberData(nameof(TestClassDataForVisualStudioSolutionFileMetadata.GetSolutionFileMetadata), MemberType = typeof(TestClassDataForVisualStudioSolutionFileMetadata))]
    public void GetSolutionFileMetadata_FileContent(
        VisualStudioSolutionFileMetadata expected,
        int visualStudioVersionNumber)
    {
        // Arrange
        var fileContent = CreateSolutionFileContent(visualStudioVersionNumber);

        // Atc
        var actual = VisualStudioSolutionFileHelper.GetSolutionFileMetadata(fileContent);

        // Assert
        actual.Should()
            .NotBeNull()
            .And.BeEquivalentTo(expected);
    }

    private static Task CreateSolutionFile(
        DirectoryInfo workingDirectory,
        string fileName,
        int visualStudioVersionNumber)
    {
        var file = new FileInfo(Path.Combine(workingDirectory.FullName, fileName));
        return File.WriteAllTextAsync(
            file.FullName,
            CreateSolutionFileContent(visualStudioVersionNumber),
            Encoding.UTF8);
    }

    private static string CreateSolutionFileContent(int visualStudioVersionNumber)
    {
        var sb = new StringBuilder();
        sb.AppendLine(string.Empty);

        switch (visualStudioVersionNumber)
        {
            case 2019:
                sb.AppendLine("Microsoft Visual Studio Solution File, Format Version 12.00");
                sb.AppendLine("# Visual Studio Version 16");
                sb.AppendLine("VisualStudioVersion = 16.0.31019.35");
                sb.AppendLine("MinimumVisualStudioVersion = 10.0.40219.1");
                break;
            case 2022:
                sb.AppendLine("Microsoft Visual Studio Solution File, Format Version 12.00");
                sb.AppendLine("# Visual Studio Version 17");
                sb.AppendLine("VisualStudioVersion = 17.0.32112.339");
                sb.AppendLine("MinimumVisualStudioVersion = 10.0.40219.1");
                break;
            default:
                throw new NotImplementedException($"Content for {visualStudioVersionNumber}");
        }

        return sb.ToString();
    }
}