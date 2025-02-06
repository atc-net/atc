// ReSharper disable SuggestBaseTypeForParameter
namespace Atc.DotNet.Tests;

public class DotnetBuildHelperTests : IAsyncLifetime
{
    private static readonly DirectoryInfo WorkingDirectory = new(
        Path.Combine(Path.GetTempPath(), "atc-integration-test-dotnet-build-helper"));

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
    public async Task Create_ConsoleApp_GoodCase()
    {
        await CreateCsprojFile(WorkingDirectory);
        await CreateProgramFile(WorkingDirectory, withError: false);

        var buildErrors = await DotnetBuildHelper.BuildAndCollectErrors(WorkingDirectory);

        Assert.Empty(buildErrors);
    }

    [Fact]
    public async Task Create_ConsoleApp_BadCase()
    {
        await CreateCsprojFile(WorkingDirectory);
        await CreateProgramFile(WorkingDirectory, withError: true);

        var buildErrors = await DotnetBuildHelper.BuildAndCollectErrors(WorkingDirectory);

        Assert.Single(buildErrors);
    }

    private static Task CreateCsprojFile(DirectoryInfo workingDirectory)
    {
        var file = new FileInfo(Path.Combine(workingDirectory.FullName, "Test.csproj"));

        var sb = new StringBuilder();
        sb.AppendLine("<Project Sdk=\"Microsoft.NET.Sdk\">");
        sb.AppendLine(2, "<PropertyGroup>");
        sb.AppendLine(4, "<OutputType>Exe</OutputType>");
        sb.AppendLine(4, "<TargetFramework>net8.0</TargetFramework>");
        sb.AppendLine(2, "</PropertyGroup>");
        sb.AppendLine("</Project>");

        return File.WriteAllTextAsync(file.FullName, sb.ToString(), Encoding.UTF8);
    }

    private static Task CreateProgramFile(DirectoryInfo workingDirectory, bool withError = false)
    {
        var file = new FileInfo(Path.Combine(workingDirectory.FullName, "Program.cs"));

        var sb = new StringBuilder();
        sb.AppendLine("using System;");
        sb.AppendLine();
        sb.AppendLine("namespace Test");
        sb.AppendLine('{');
        sb.AppendLine(4, "class Program");
        sb.AppendLine(4, '{');
        sb.AppendLine(8, "static void Main(string[] args)");
        sb.AppendLine(8, '{');
        sb.AppendLine(12, withError ? "QQConsole.WriteLine(\"Hello World!\");" : "Console.WriteLine(\"Hello World!\");");
        sb.AppendLine(8, '}');
        sb.AppendLine(4, '}');
        sb.AppendLine('}');

        return File.WriteAllTextAsync(file.FullName, sb.ToString(), Encoding.UTF8);
    }
}