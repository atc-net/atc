// ReSharper disable CommentTypo
// ReSharper disable IdentifierTypo
// ReSharper disable StringLiteralTypo
// ReSharper disable SuggestBaseTypeForParameter
namespace Atc.DotNet.Tests;

public class VisualStudioSolutionFileHelperTests : IAsyncLifetime
{
    private static readonly DirectoryInfo WorkingDirectory = new(Path.Combine(Path.GetTempPath(), "atc-integration-test-solution-file-helper"));

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

    [Fact]
    public async Task GetSolutionFileMetadata_FileInfo_Slnx_Minimal_OpenWithOnly()
    {
        // Arrange
        var xml = CreateSlnxFileContent(
            openWithMajor: 17,
            visualStudioVersion: null,
            minimumVersion: null,
            fileFormatVersion: null);

        await CreateSlnxFile(WorkingDirectory, "TestMinimal.slnx", xml);
        var file = new FileInfo(Path.Combine(WorkingDirectory.FullName, "TestMinimal.slnx"));

        var expected = new VisualStudioSolutionFileMetadata
        {
            //// Only OpenWith is present in the XML → we only expect this to be populated.
            VisualStudioVersionNumber = 17,
            //// Other Version fields should remain at their defaults (as per your metadata type).
        };

        // Act
        var actual = VisualStudioSolutionFileHelper.GetSolutionFileMetadata(file);

        // Assert
        actual.Should()
            .NotBeNull()
            .And.BeEquivalentTo(expected);
    }

    [Fact]
    public void GetSolutionFileMetadata_FileContent_Slnx_AllVisualStudioProps()
    {
        // Arrange
        var expected = new VisualStudioSolutionFileMetadata
        {
            FileFormatVersion = new Version(12, 0),
            VisualStudioVersionNumber = 17,
            VisualStudioVersion = new Version(17, 0, 32112, 339),
            MinimumVisualStudioVersion = new Version(10, 0, 40219, 1),
        };

        var xml = CreateSlnxFileContent(
            openWithMajor: 17,
            visualStudioVersion: expected.VisualStudioVersion,
            minimumVersion: expected.MinimumVisualStudioVersion,
            fileFormatVersion: expected.FileFormatVersion);

        // Act
        var actual = VisualStudioSolutionFileHelper.GetSolutionFileMetadata(xml);

        // Assert
        actual.Should()
            .NotBeNull()
            .And.BeEquivalentTo(expected);
    }

    [Fact]
    public async Task FindAllInPath_Includes_Slnx_Files()
    {
        // Arrange
        await CreateSolutionFile(WorkingDirectory, "A.sln", 2022);
        await CreateSlnxFile(WorkingDirectory, "B.slnx", CreateSlnxFileContent(openWithMajor: 17));

        // Act
        var files = VisualStudioSolutionFileHelper.FindAllInPath(WorkingDirectory);

        // Assert
        files.Should().NotBeNull();
        files.Select(f => f.Extension)
             .Should().Contain(new[] { ".sln", ".slnx" });
        files.Should().HaveCount(2);
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

    private static Task CreateSlnxFile(
        DirectoryInfo workingDirectory,
        string fileName,
        string xmlContent)
    {
        var file = new FileInfo(Path.Combine(workingDirectory.FullName, fileName));
        return File.WriteAllTextAsync(file.FullName, xmlContent, Encoding.UTF8);
    }

    private static string CreateSlnxFileContent(
        int? openWithMajor,
        Version? visualStudioVersion = null,
        Version? minimumVersion = null,
        Version? fileFormatVersion = null)
    {
        var sbProps = new StringBuilder();
        if (openWithMajor.HasValue || visualStudioVersion is not null || minimumVersion is not null || fileFormatVersion is not null)
        {
            sbProps.AppendLine(2, "<Properties Name=\"Visual Studio\">");
            if (openWithMajor.HasValue)
            {
                sbProps.Append(4, "<Property Name=\"OpenWith\" Value=\"");
                sbProps.Append(openWithMajor.Value);
                sbProps.AppendLine("\" />");
            }

            if (visualStudioVersion is not null)
            {
                sbProps.Append(4, "<Property Name=\"VisualStudioVersion\" Value=\"");
                sbProps.Append(visualStudioVersion);
                sbProps.AppendLine("\" />");
            }

            if (minimumVersion is not null)
            {
                sbProps.Append(4, "<Property Name=\"MinimumVisualStudioVersion\" Value=\"");
                sbProps.Append(minimumVersion);
                sbProps.AppendLine("\" />");
            }

            if (fileFormatVersion is not null)
            {
                sbProps.Append(4, "<Property Name=\"FileFormatVersion\" Value=\"");
                sbProps.Append(fileFormatVersion);
                sbProps.AppendLine("\" />");
            }

            sbProps.AppendLine(2, "</Properties>");
        }

        var xml = $"""
                   <?xml version="1.0" encoding="utf-8"?>
                   <Solution>
                   {sbProps}
                     <Project Path="src\Sample\Sample.csproj" />
                   </Solution>
                   """;

        return xml;
    }
}