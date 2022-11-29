// ReSharper disable SuggestBaseTypeForParameter
namespace Atc.DotNet.Tests;

public class DotnetNugetHelperTests : IAsyncLifetime
{
    private static readonly DirectoryInfo WorkingDirectory = new(
        Path.Combine(Path.GetTempPath(), "atc-integration-test-dotnet-nuget-helper"));

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

    [Fact]
    public async Task GetAllPackageReferences_FileInfo()
    {
        // Arrange
        await CreateCsprojFile(WorkingDirectory, "Test.csproj");
        var file = new FileInfo(Path.Combine(WorkingDirectory.FullName, "Test.csproj"));

        // Atc
        var actual = DotnetNugetHelper.GetAllPackageReferences(file);

        // Assert
        actual.Should()
            .NotBeEmpty()
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
        actual.Should()
            .NotBeEmpty()
            .And.HaveCount(3);
    }

    private static Task CreateCsprojFile(DirectoryInfo workingDirectory, string fileName)
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
        sb.AppendLine(4, "<TargetFramework>net6.0</TargetFramework>");
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
}