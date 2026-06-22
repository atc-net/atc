// ReSharper disable SuggestBaseTypeForParameter
namespace Atc.DotNet.Tests;

public class DotnetBuildHelperTests : IAsyncLifetime
{
    private static readonly DirectoryInfo WorkingDirectory = new(
        Path.Combine(Path.GetTempPath(), "atc-integration-test-dotnet-build-helper"));

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

    [Fact]
    public void ParseErrors_CompilerError_WithProjectSuffix_Counted()
    {
        const string output = "Program.cs(13,13): error CS0246: The type 'Foo' could not be found [Test.csproj]";

        var errors = DotnetBuildHelper.ParseErrors(output);

        Assert.Single(errors);
        Assert.Equal(1, errors["CS0246"]);
    }

    [Fact]
    public void ParseErrors_CompilerError_WithoutProjectSuffix_Counted()
    {
        const string output = "Program.cs(13,13): error CS0246: The type 'Foo' could not be found";

        var errors = DotnetBuildHelper.ParseErrors(output);

        Assert.Single(errors);
        Assert.Equal(1, errors["CS0246"]);
    }

    [Fact]
    public void ParseErrors_MSBuildError_Counted()
    {
        const string output = "MSBUILD : error MSB1003: Specify a project or solution file.";

        var errors = DotnetBuildHelper.ParseErrors(output);

        Assert.Single(errors);
        Assert.Equal(1, errors["MSB1003"]);
    }

    [Fact]
    public void ParseErrors_NuGetError_Counted()
    {
        const string output = "Test.csproj : error NU1101: Unable to find package SomePackage.";

        var errors = DotnetBuildHelper.ParseErrors(output);

        Assert.Single(errors);
        Assert.Equal(1, errors["NU1101"]);
    }

    [Fact]
    public void ParseErrors_MultipleErrors_AggregatedByCode()
    {
        const string output = """
            Program.cs(5,5): error CS0246: Missing type [Test.csproj]
            Program.cs(6,5): error CS0246: Missing type [Test.csproj]
            Program.cs(7,5): error CS0103: Name not found [Test.csproj]
            """;

        var errors = DotnetBuildHelper.ParseErrors(output);

        Assert.Equal(2, errors.Count);
        Assert.Equal(2, errors["CS0246"]);
        Assert.Equal(1, errors["CS0103"]);
    }

    [Fact]
    public void ParseErrors_EmptyOutput_ReturnsEmpty()
    {
        var errors = DotnetBuildHelper.ParseErrors(string.Empty);

        Assert.Empty(errors);
    }

    [Fact]
    public void ParseWarnings_CompilerWarning_WithProjectSuffix_Counted()
    {
        const string output = "Program.cs(5,13): warning CS0168: The variable 'x' is declared but never used [Test.csproj]";

        var warnings = DotnetBuildHelper.ParseWarnings(output);

        Assert.Single(warnings);
        Assert.Equal(1, warnings["CS0168"]);
    }

    [Fact]
    public void ParseWarnings_CompilerWarning_WithoutProjectSuffix_Counted()
    {
        const string output = "Program.cs(5,13): warning CS0168: The variable 'x' is declared but never used";

        var warnings = DotnetBuildHelper.ParseWarnings(output);

        Assert.Single(warnings);
        Assert.Equal(1, warnings["CS0168"]);
    }

    [Fact]
    public void ParseWarnings_MSBuildWarning_Counted()
    {
        const string output = "MSBUILD : warning MSB3277: Found conflicts between different versions of assembly.";

        var warnings = DotnetBuildHelper.ParseWarnings(output);

        Assert.Single(warnings);
        Assert.Equal(1, warnings["MSB3277"]);
    }

    [Fact]
    public void ParseWarnings_NuGetWarning_Counted()
    {
        const string output = "Test.csproj : warning NU1701: Package 'OldPkg 1.0.0' was restored using net472.";

        var warnings = DotnetBuildHelper.ParseWarnings(output);

        Assert.Single(warnings);
        Assert.Equal(1, warnings["NU1701"]);
    }

    [Fact]
    public void ParseWarnings_MultipleWarnings_AggregatedByCode()
    {
        const string output = """
            Program.cs(5,5): warning CS0168: Unused var [Test.csproj]
            Program.cs(6,5): warning CS0168: Unused var [Test.csproj]
            Program.cs(7,5): warning CS0219: Value assigned but never used [Test.csproj]
            """;

        var warnings = DotnetBuildHelper.ParseWarnings(output);

        Assert.Equal(2, warnings.Count);
        Assert.Equal(2, warnings["CS0168"]);
        Assert.Equal(1, warnings["CS0219"]);
    }

    [Fact]
    public void ParseWarnings_EmptyOutput_ReturnsEmpty()
    {
        var warnings = DotnetBuildHelper.ParseWarnings(string.Empty);

        Assert.Empty(warnings);
    }

    [Fact]
    public void ParseWarnings_DoesNotMatchErrors()
    {
        const string output = "Program.cs(13,13): error CS0246: The type 'Foo' could not be found";

        var warnings = DotnetBuildHelper.ParseWarnings(output);

        Assert.Empty(warnings);
    }

    private static Task CreateCsprojFile(DirectoryInfo workingDirectory)
    {
        var file = new FileInfo(Path.Combine(workingDirectory.FullName, "Test.csproj"));

        var sb = new StringBuilder();
        sb.AppendLine("<Project Sdk=\"Microsoft.NET.Sdk\">");
        sb.AppendLine(2, "<PropertyGroup>");
        sb.AppendLine(4, "<OutputType>Exe</OutputType>");
        sb.AppendLine(4, "<TargetFramework>net9.0</TargetFramework>");
        sb.AppendLine(2, "</PropertyGroup>");
        sb.AppendLine("</Project>");

        return File.WriteAllTextAsync(file.FullName, sb.ToString(), Encoding.UTF8);
    }

    private static Task CreateProgramFile(
        DirectoryInfo workingDirectory,
        bool withError = false)
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