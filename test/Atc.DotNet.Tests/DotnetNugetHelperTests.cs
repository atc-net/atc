// ReSharper disable SuggestBaseTypeForParameter
namespace Atc.DotNet.Tests;

public class DotnetNugetHelperTests : IAsyncLifetime
{
    private static readonly DirectoryInfo WorkingDirectory = new(
        Path.Combine(Path.GetTempPath(), "atc-integration-test-dotnet-nuget-helper"));

    public ValueTask InitializeAsync()
    {
        if (Directory.Exists(WorkingDirectory.FullName))
        {
            Directory.Delete(WorkingDirectory.FullName, recursive: true);
        }

        Directory.CreateDirectory(WorkingDirectory.FullName);

        return ValueTask.CompletedTask;
    }

    public ValueTask DisposeAsync()
    {
        if (Directory.Exists(WorkingDirectory.FullName))
        {
            Directory.Delete(WorkingDirectory.FullName, recursive: true);
        }

        return ValueTask.CompletedTask;
    }

    [Fact]
    public async Task GetAllPackageReferences_FileInfo()
    {
        // Arrange
        await CreateCsprojFile(WorkingDirectory, "Test.csproj");
        var file = new FileInfo(Path.Combine(WorkingDirectory.FullName, "Test.csproj"));

        // Atc
        var actual = DotnetNugetHelper.GetAllPackageReferences(file);

        // Assert
        actual
            .Should().NotBeEmpty()
            .And.HaveCount(3);
    }

    [Fact]
    public void GetAllPackageReferences_FileContent()
    {
        // Arrange
        var fileContent = CreateCsprojFileContent();

        // Atc
        var actual = DotnetNugetHelper.GetAllPackageReferences(fileContent);

        // Assert
        actual
            .Should().NotBeEmpty()
            .And.HaveCount(3);
    }

    [Fact]
    public void GetAllPackageReferences_FileContent_WithLegacyMsBuildNamespace()
    {
        // Arrange
        var fileContent = CreateDirectoryBuildPropsFileContentWithLegacyMsBuildNamespace();

        // Atc
        var actual = DotnetNugetHelper.GetAllPackageReferences(fileContent);

        // Assert
        actual
            .Should().NotBeEmpty()
            .And.HaveCount(3);

        actual[0].PackageId.Should().Be("AsyncFixer");
        actual[0].Version.Should().Be("2.1.0");
        actual[1].PackageId.Should().Be("Meziantou.Analyzer");
        actual[1].Version.Should().Be("3.0.54");
        actual[2].PackageId.Should().Be("SonarAnalyzer.CSharp");
        actual[2].Version.Should().Be("10.24.0.138807");
    }

    [Theory]
    [InlineData("\r\n")]
    [InlineData("  ")]
    [InlineData("\r\n    \r\n")]
    public void GetAllPackageReferences_FileContent_WithLeadingWhitespace(
        string leadingWhitespace)
    {
        // Arrange
        var fileContent = leadingWhitespace + CreateCsprojFileContent();

        // Atc
        var actual = DotnetNugetHelper.GetAllPackageReferences(fileContent);

        // Assert
        actual
            .Should().NotBeEmpty()
            .And.HaveCount(3);
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData("Not xml at all")]
    public void GetAllPackageReferences_FileContent_ThrowsDataException_WhenContentIsNotXml(
        string fileContent)
    {
        // Atc & Assert
        Assert.Throws<System.Data.DataException>(
            () => DotnetNugetHelper.GetAllPackageReferences(fileContent));
    }

    private static Task CreateCsprojFile(
        DirectoryInfo workingDirectory,
        string fileName)
    {
        var file = new FileInfo(Path.Combine(workingDirectory.FullName, fileName));
        return File.WriteAllTextAsync(
            file.FullName,
            CreateCsprojFileContent(),
            Encoding.UTF8);
    }

    private static string CreateCsprojFileContent()
    {
        var sb = new StringBuilder();
        sb.AppendLine("<Project Sdk=\"Microsoft.NET.Sdk\">");
        sb.AppendLine(2, "<PropertyGroup>");
        sb.AppendLine(4, "<OutputType>Exe</OutputType>");
        sb.AppendLine(4, "<TargetFramework>net9.0</TargetFramework>");
        sb.AppendLine(2, "</PropertyGroup>");
        sb.AppendLine(2, "<ItemGroup>");
        sb.AppendLine(4, "<PackageReference Include=\"Microsoft.NET.Test.Sdk\" Version=\"16.11.0\" />");
        sb.AppendLine(4, "<PackageReference Include=\"xunit\" Version=\"2.4.1\" />");
        sb.AppendLine(4, "<PackageReference Include=\"xunit.runner.visualstudio\" Version=\"2.4.3\">");
        sb.AppendLine(6, "<PrivateAssets>all</PrivateAssets>");
        sb.AppendLine(6, "<IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>");
        sb.AppendLine(4, "</PackageReference>");
        sb.AppendLine(2, "</ItemGroup>");
        sb.AppendLine("</Project>");
        return sb.ToString();
    }

    private static string CreateDirectoryBuildPropsFileContentWithLegacyMsBuildNamespace()
    {
        var sb = new StringBuilder();
        sb.AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
        sb.AppendLine("<Project xmlns=\"http://schemas.microsoft.com/developer/msbuild/2003\">");
        sb.AppendLine(2, "<ItemGroup Label=\"Code Analyzers\">");
        sb.AppendLine(4, "<PackageReference Include=\"AsyncFixer\" Version=\"2.1.0\" PrivateAssets=\"All\" />");
        sb.AppendLine(4, "<PackageReference Include=\"Meziantou.Analyzer\" Version=\"3.0.54\" PrivateAssets=\"All\" />");
        sb.AppendLine(4, "<PackageReference Include=\"SonarAnalyzer.CSharp\">");
        sb.AppendLine(6, "<Version>10.24.0.138807</Version>");
        sb.AppendLine(4, "</PackageReference>");
        sb.AppendLine(2, "</ItemGroup>");
        sb.AppendLine("</Project>");
        return sb.ToString();
    }
}