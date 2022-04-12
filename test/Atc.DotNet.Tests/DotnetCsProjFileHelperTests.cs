// ReSharper disable StringLiteralTypo
// ReSharper disable SuggestBaseTypeForParameter
namespace Atc.DotNet.Tests;

[SuppressMessage("Major Code Smell", "S4144:Methods should not have identical implementations", Justification = "OK.")]
public class DotnetCsProjFileHelperTests : IAsyncLifetime
{
    private static readonly DirectoryInfo WorkingDirectory = new (Path.Combine(Path.GetTempPath(), "atc-integration-test-csproj-file-helper"));

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
    [InlineData(DotnetProjectType.AzureFunctionApp, DotnetProjectType.AzureFunctionApp)]
    [InlineData(DotnetProjectType.AndroidApp, DotnetProjectType.AndroidApp)]
    [InlineData(DotnetProjectType.ConsoleApp, DotnetProjectType.ConsoleApp)]
    [InlineData(DotnetProjectType.CliApp, DotnetProjectType.CliApp)]
    [InlineData(DotnetProjectType.BlazorServerApp, DotnetProjectType.BlazorServerApp)]
    [InlineData(DotnetProjectType.BlazorWAsmApp, DotnetProjectType.BlazorWAsmApp)]
    [InlineData(DotnetProjectType.IosApp, DotnetProjectType.IosApp)]
    [InlineData(DotnetProjectType.UwpApp, DotnetProjectType.UwpApp)]
    [InlineData(DotnetProjectType.WebApp, DotnetProjectType.WebApp)]
    [InlineData(DotnetProjectType.WpfApp, DotnetProjectType.WpfApp)]
    [InlineData(DotnetProjectType.WinFormApp, DotnetProjectType.WinFormApp)]
    [InlineData(DotnetProjectType.Library, DotnetProjectType.Library)]
    [InlineData(DotnetProjectType.RazorLibrary, DotnetProjectType.RazorLibrary)]
    [InlineData(DotnetProjectType.UwpLibrary, DotnetProjectType.UwpLibrary)]
    [InlineData(DotnetProjectType.WpfLibrary, DotnetProjectType.WpfLibrary)]
    [InlineData(DotnetProjectType.AzureIotEdgeModule, DotnetProjectType.AzureIotEdgeModule)]
    [InlineData(DotnetProjectType.VisualStudioExtension, DotnetProjectType.VisualStudioExtension)]
    [InlineData(DotnetProjectType.WebApi, DotnetProjectType.WebApi)]
    [InlineData(DotnetProjectType.WorkerService, DotnetProjectType.WorkerService)]
    [InlineData(DotnetProjectType.BUnitTest, DotnetProjectType.BUnitTest)]
    [InlineData(DotnetProjectType.MsTest, DotnetProjectType.MsTest)]
    [InlineData(DotnetProjectType.NUnitTest, DotnetProjectType.NUnitTest)]
    [InlineData(DotnetProjectType.XUnitTest, DotnetProjectType.XUnitTest)]
    public async Task PredictProjectType_FileInfo(
        DotnetProjectType expected,
        DotnetProjectType dotnetProjectTypeToCreate)
    {
        // Arrange
        await CreateCsProjFile(WorkingDirectory, "Test.csproj", dotnetProjectTypeToCreate);
        if (dotnetProjectTypeToCreate == DotnetProjectType.BlazorServerApp)
        {
            await CreateProgramCsFile(WorkingDirectory, "Program.cs", dotnetProjectTypeToCreate);
        }

        var file = new FileInfo(Path.Combine(WorkingDirectory.FullName, "Test.csproj"));

        // Atc
        var actual = DotnetCsProjFileHelper.PredictProjectType(file);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(DotnetProjectType.AzureFunctionApp, DotnetProjectType.AzureFunctionApp)]
    [InlineData(DotnetProjectType.AndroidApp, DotnetProjectType.AndroidApp)]
    [InlineData(DotnetProjectType.ConsoleApp, DotnetProjectType.ConsoleApp)]
    [InlineData(DotnetProjectType.CliApp, DotnetProjectType.CliApp)]
    [InlineData(DotnetProjectType.WebApp, DotnetProjectType.BlazorServerApp)]
    [InlineData(DotnetProjectType.BlazorWAsmApp, DotnetProjectType.BlazorWAsmApp)]
    [InlineData(DotnetProjectType.IosApp, DotnetProjectType.IosApp)]
    [InlineData(DotnetProjectType.UwpApp, DotnetProjectType.UwpApp)]
    [InlineData(DotnetProjectType.WebApp, DotnetProjectType.WebApp)]
    [InlineData(DotnetProjectType.WpfApp, DotnetProjectType.WpfApp)]
    [InlineData(DotnetProjectType.WinFormApp, DotnetProjectType.WinFormApp)]
    [InlineData(DotnetProjectType.Library, DotnetProjectType.Library)]
    [InlineData(DotnetProjectType.RazorLibrary, DotnetProjectType.RazorLibrary)]
    [InlineData(DotnetProjectType.UwpLibrary, DotnetProjectType.UwpLibrary)]
    [InlineData(DotnetProjectType.WpfLibrary, DotnetProjectType.WpfLibrary)]
    [InlineData(DotnetProjectType.AzureIotEdgeModule, DotnetProjectType.AzureIotEdgeModule)]
    [InlineData(DotnetProjectType.VisualStudioExtension, DotnetProjectType.VisualStudioExtension)]
    [InlineData(DotnetProjectType.WebApi, DotnetProjectType.WebApi)]
    [InlineData(DotnetProjectType.WorkerService, DotnetProjectType.WorkerService)]
    [InlineData(DotnetProjectType.BUnitTest, DotnetProjectType.BUnitTest)]
    [InlineData(DotnetProjectType.MsTest, DotnetProjectType.MsTest)]
    [InlineData(DotnetProjectType.NUnitTest, DotnetProjectType.NUnitTest)]
    [InlineData(DotnetProjectType.XUnitTest, DotnetProjectType.XUnitTest)]
    public async Task GetProjectType_FileInfo(
        DotnetProjectType expected,
        DotnetProjectType dotnetProjectTypeToCreate)
    {
        // Arrange
        await CreateCsProjFile(WorkingDirectory, "Test.csproj", dotnetProjectTypeToCreate);
        var file = new FileInfo(Path.Combine(WorkingDirectory.FullName, "Test.csproj"));

        // Atc
        var actual = DotnetCsProjFileHelper.GetProjectType(file);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(DotnetProjectType.AzureFunctionApp, DotnetProjectType.AzureFunctionApp)]
    [InlineData(DotnetProjectType.AndroidApp, DotnetProjectType.AndroidApp)]
    [InlineData(DotnetProjectType.ConsoleApp, DotnetProjectType.ConsoleApp)]
    [InlineData(DotnetProjectType.CliApp, DotnetProjectType.CliApp)]
    [InlineData(DotnetProjectType.WebApp, DotnetProjectType.BlazorServerApp)]
    [InlineData(DotnetProjectType.BlazorWAsmApp, DotnetProjectType.BlazorWAsmApp)]
    [InlineData(DotnetProjectType.IosApp, DotnetProjectType.IosApp)]
    [InlineData(DotnetProjectType.UwpApp, DotnetProjectType.UwpApp)]
    [InlineData(DotnetProjectType.WebApp, DotnetProjectType.WebApp)]
    [InlineData(DotnetProjectType.WpfApp, DotnetProjectType.WpfApp)]
    [InlineData(DotnetProjectType.WinFormApp, DotnetProjectType.WinFormApp)]
    [InlineData(DotnetProjectType.Library, DotnetProjectType.Library)]
    [InlineData(DotnetProjectType.RazorLibrary, DotnetProjectType.RazorLibrary)]
    [InlineData(DotnetProjectType.UwpLibrary, DotnetProjectType.UwpLibrary)]
    [InlineData(DotnetProjectType.WpfLibrary, DotnetProjectType.WpfLibrary)]
    [InlineData(DotnetProjectType.AzureIotEdgeModule, DotnetProjectType.AzureIotEdgeModule)]
    [InlineData(DotnetProjectType.VisualStudioExtension, DotnetProjectType.VisualStudioExtension)]
    [InlineData(DotnetProjectType.WebApi, DotnetProjectType.WebApi)]
    [InlineData(DotnetProjectType.WorkerService, DotnetProjectType.WorkerService)]
    [InlineData(DotnetProjectType.BUnitTest, DotnetProjectType.BUnitTest)]
    [InlineData(DotnetProjectType.MsTest, DotnetProjectType.MsTest)]
    [InlineData(DotnetProjectType.NUnitTest, DotnetProjectType.NUnitTest)]
    [InlineData(DotnetProjectType.XUnitTest, DotnetProjectType.XUnitTest)]
    public void GetProjectType_FileContent(
        DotnetProjectType expected,
        DotnetProjectType dotnetProjectTypeToCreate)
    {
        // Arrange
        var fileContent = CreateCsProjFile(dotnetProjectTypeToCreate);

        // Atc
        var actual = DotnetCsProjFileHelper.GetProjectType(fileContent);

        // Assert
        Assert.Equal(expected, actual);
    }

    private static Task CreateCsProjFile(
        DirectoryInfo workingDirectory,
        string fileName,
        DotnetProjectType dotnetProjectType)
    {
        var file = new FileInfo(Path.Combine(workingDirectory.FullName, fileName));
        return File.WriteAllTextAsync(
            file.FullName,
            CreateCsProjFile(dotnetProjectType),
            Encoding.UTF8);
    }

    [SuppressMessage("Design", "MA0051:Method is too long", Justification = "OK.")]
    private static string CreateCsProjFile(
        DotnetProjectType dotnetProjectType)
    {
        var sb = new StringBuilder();
        switch (dotnetProjectType)
        {
            case DotnetProjectType.AzureFunctionApp:
                CreateCsProjFileAzureFunctionApp(sb);
                break;
            case DotnetProjectType.AndroidApp:
                CreateCsProjFileAndroidApp(sb);
                break;
            case DotnetProjectType.ConsoleApp:
                CreateCsProjFileConsoleApp(sb);
                break;
            case DotnetProjectType.CliApp:
                CreateCsProjFileCliApp(sb);
                break;
            case DotnetProjectType.BlazorServerApp:
                CreateCsProjFileBlazorServerApp(sb);
                break;
            case DotnetProjectType.BlazorWAsmApp:
                CreateCsProjFileBlazorWAsmApp(sb);
                break;
            case DotnetProjectType.IosApp:
                CreateCsProjFileIosApp(sb);
                break;
            case DotnetProjectType.UwpApp:
                CreateCsProjFileUwpApp(sb);
                break;
            case DotnetProjectType.WebApp:
                CreateCsProjFileWebApp(sb);
                break;
            case DotnetProjectType.WpfApp:
                CreateCsProjFileWpfApp(sb);
                break;
            case DotnetProjectType.WinFormApp:
                CreateCsProjFileWinFormApp(sb);
                break;
            case DotnetProjectType.Library:
                CreateCsProjFileLibrary(sb);
                break;
            case DotnetProjectType.RazorLibrary:
                CreateCsProjFileRazorLibrary(sb);
                break;
            case DotnetProjectType.UwpLibrary:
                CreateCsProjFileUwpLibrary(sb);
                break;
            case DotnetProjectType.WpfLibrary:
                CreateCsProjFileWpfLibrary(sb);
                break;
            case DotnetProjectType.AzureIotEdgeModule:
                CreateCsProjFileAzureIotEdgeModule(sb);
                break;
            case DotnetProjectType.VisualStudioExtension:
                CreateCsProjFileVisualStudioExtension(sb);
                break;
            case DotnetProjectType.WebApi:
                CreateCsProjFileWebApi(sb);
                break;
            case DotnetProjectType.WorkerService:
                CreateCsProjFileWorkerService(sb);
                break;
            case DotnetProjectType.BUnitTest:
                CreateCsProjFileTest(sb, "bunit");
                break;
            case DotnetProjectType.MsTest:
                CreateCsProjFileTest(sb, "MSTest.TestAdapter");
                break;
            case DotnetProjectType.NUnitTest:
                CreateCsProjFileTest(sb, "NUnit");
                break;
            case DotnetProjectType.XUnitTest:
                CreateCsProjFileTest(sb, "xunit");
                break;
            default:
                throw new SwitchCaseDefaultException(dotnetProjectType);
        }

        return sb.ToString();
    }

    private static void CreateCsProjFileAzureIotEdgeModule(
        StringBuilder sb)
    {
        sb.AppendLine("<Project Sdk=\"Microsoft.NET.Sdk\">");
        AppendPropertyGroupFirst(
            sb,
            outputType: "Exe",
            packAsTool: false,
            useAzureFunction: false,
            useWinForm: false,
            useWpf: false);
        AppendItemGroupPackageReference(
            sb,
            new[] { "Atc", "Microsoft.Azure.Devices.Client" });
        sb.AppendLine();
        sb.AppendLine("</Project>");
    }

    private static void CreateCsProjFileAzureFunctionApp(
        StringBuilder sb)
    {
        sb.AppendLine("<Project Sdk=\"Microsoft.NET.Sdk\">");
        AppendPropertyGroupFirst(
            sb,
            outputType: "Library",
            packAsTool: false,
            useAzureFunction: true,
            useWinForm: false,
            useWpf: false);
        sb.AppendLine();
        sb.AppendLine("</Project>");
    }

    private static void CreateCsProjFileAndroidApp(
        StringBuilder sb)
    {
        sb.AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
        sb.AppendLine("<Project ToolsVersion=\"4.0\" DefaultTargets=\"Build\" xmlns=\"http://schemas.microsoft.com/developer/msbuild/2003\">");
        sb.AppendLine(2, "<PropertyGroup>");
        sb.AppendLine(4, "<ProjectGuid>{92037882-D710-4A9A-AFDB-64F231ADA142}</ProjectGuid>");
        sb.AppendLine(4, "<ProjectTypeGuids>{EFBA0AD7-5A72-4C68-AF49-83D382785DCF};{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}</ProjectTypeGuids>");
        sb.AppendLine(4, "<OutputType>Library</OutputType>");
        sb.AppendLine(4, "<AndroidApplication>True</AndroidApplication>");
        sb.AppendLine(2, "</PropertyGroup>");
        sb.AppendLine("</Project>");
    }

    private static void CreateCsProjFileCliApp(
        StringBuilder sb)
    {
        sb.AppendLine("<Project Sdk=\"Microsoft.NET.Sdk\">");
        AppendPropertyGroupFirst(
            sb,
            outputType: "Exe",
            packAsTool: true,
            useAzureFunction: false,
            useWinForm: false,
            useWpf: false);
        sb.AppendLine();
        sb.AppendLine("</Project>");
    }

    private static void CreateCsProjFileConsoleApp(
        StringBuilder sb)
    {
        sb.AppendLine("<Project Sdk=\"Microsoft.NET.Sdk\">");
        AppendPropertyGroupFirst(
            sb,
            outputType: "Exe",
            packAsTool: false,
            useAzureFunction: false,
            useWinForm: false,
            useWpf: false);
        sb.AppendLine();
        sb.AppendLine("</Project>");
    }

    private static void CreateCsProjFileBlazorServerApp(
        StringBuilder sb)
    {
        sb.AppendLine("<Project Sdk=\"Microsoft.NET.Sdk.Web\">");
        AppendPropertyGroupFirst(
            sb,
            outputType: null,
            packAsTool: false,
            useAzureFunction: false,
            useWinForm: false,
            useWpf: false);
        sb.AppendLine();
        sb.AppendLine("</Project>");
    }

    private static void CreateCsProjFileBlazorWAsmApp(
        StringBuilder sb)
    {
        sb.AppendLine("<Project Sdk=\"Microsoft.NET.Sdk.BlazorWebAssembly\">");
        AppendPropertyGroupFirst(
            sb,
            outputType: null,
            packAsTool: false,
            useAzureFunction: false,
            useWinForm: false,
            useWpf: false);
        sb.AppendLine();
        sb.AppendLine("</Project>");
    }

    private static void CreateCsProjFileIosApp(
        StringBuilder sb)
    {
        sb.AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
        sb.AppendLine("<Project ToolsVersion=\"4.0\" DefaultTargets=\"Build\" xmlns=\"http://schemas.microsoft.com/developer/msbuild/2003\">");
        sb.AppendLine(2, "<PropertyGroup>");
        sb.AppendLine(4, "<ProjectGuid>{91316817-76BC-45D6-ABC5-B9824493DC56}</ProjectGuid>");
        sb.AppendLine(4, "<ProjectTypeGuids>{FEACFBD2-3405-455C-9665-78FE426C6842};{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}</ProjectTypeGuids>");
        sb.AppendLine(4, "<OutputType>Exe</OutputType>");
        sb.AppendLine(4, "<IPhoneResourcePrefix>Resources</IPhoneResourcePrefix>");
        sb.AppendLine(2, "</PropertyGroup>");
        sb.AppendLine("</Project>");
    }

    private static void CreateCsProjFileLibrary(
        StringBuilder sb)
    {
        sb.AppendLine("<Project Sdk=\"Microsoft.NET.Sdk\">");
        AppendPropertyGroupFirst(
            sb,
            outputType: "Library",
            packAsTool: false,
            useAzureFunction: false,
            useWinForm: false,
            useWpf: false);
        sb.AppendLine();
        sb.AppendLine("</Project>");
    }

    private static void CreateCsProjFileRazorLibrary(
        StringBuilder sb)
    {
        sb.AppendLine("<Project Sdk=\"Microsoft.NET.Sdk.Razor\">");
        AppendPropertyGroupFirst(
            sb,
            outputType: null,
            packAsTool: false,
            useAzureFunction: false,
            useWinForm: false,
            useWpf: false);
        sb.AppendLine();
        sb.AppendLine("</Project>");
    }

    private static void CreateCsProjFileUwpApp(
        StringBuilder sb)
    {
        sb.AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
        sb.AppendLine("<Project ToolsVersion=\"15.0\" DefaultTargets=\"Build\" xmlns=\"http://schemas.microsoft.com/developer/msbuild/2003\">");
        sb.AppendLine(2, "<PropertyGroup>");
        sb.AppendLine(4, "<ProjectGuid>{91316817-76BC-45D6-ABC5-B9824493DC56}</ProjectGuid>");
        sb.AppendLine(4, "<OutputType>AppContainerExe</OutputType>");
        sb.AppendLine(4, "<TargetPlatformIdentifier>UAP</TargetPlatformIdentifier>");
        sb.AppendLine(2, "</PropertyGroup>");
        sb.AppendLine("</Project>");
    }

    private static void CreateCsProjFileUwpLibrary(
        StringBuilder sb)
    {
        sb.AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
        sb.AppendLine("<Project ToolsVersion=\"15.0\" DefaultTargets=\"Build\" xmlns=\"http://schemas.microsoft.com/developer/msbuild/2003\">");
        sb.AppendLine(2, "<PropertyGroup>");
        sb.AppendLine(4, "<ProjectGuid>{91316817-76BC-45D6-ABC5-B9824493DC56}</ProjectGuid>");
        sb.AppendLine(4, "<OutputType>Library</OutputType>");
        sb.AppendLine(4, "<TargetPlatformIdentifier>UAP</TargetPlatformIdentifier>");
        sb.AppendLine(2, "</PropertyGroup>");
        sb.AppendLine("</Project>");
    }

    private static void CreateCsProjFileTest(
        StringBuilder sb,
        string testLibraryName)
    {
        sb.AppendLine("<Project Sdk=\"Microsoft.NET.Sdk\">");
        AppendPropertyGroupFirst(
            sb,
            outputType: null,
            packAsTool: false,
            useAzureFunction: false,
            useWinForm: false,
            useWpf: false);
        AppendItemGroupPackageReference(
            sb,
            new[] { "Atc", testLibraryName });
        sb.AppendLine();
        sb.AppendLine("</Project>");
    }

    private static void CreateCsProjFileVisualStudioExtension(
        StringBuilder sb)
    {
        sb.AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
        sb.AppendLine("<Project ToolsVersion=\"15.0\" DefaultTargets=\"Build\" xmlns=\"http://schemas.microsoft.com/developer/msbuild/2003\">");
        sb.AppendLine(2, "<PropertyGroup>");
        sb.AppendLine(4, "<MinimumVisualStudioVersion>16.0</MinimumVisualStudioVersion>");
        sb.AppendLine(2, "</PropertyGroup>");
        sb.AppendLine(2, "<PropertyGroup>");
        sb.AppendLine(4, "<ProjectTypeGuids>{82b43b9b-a64c-4715-b499-d71e9ca2bd60};{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}</ProjectTypeGuids>");
        sb.AppendLine(4, "<OutputType>Library</OutputType>");
        sb.AppendLine(4, "<IncludeAssemblyInVSIXContainer>true</IncludeAssemblyInVSIXContainer>");
        sb.AppendLine(2, "</PropertyGroup>");
        sb.AppendLine("</Project>");
    }

    private static void CreateCsProjFileWebApi(
        StringBuilder sb)
    {
        sb.AppendLine("<Project Sdk=\"Microsoft.NET.Sdk.Web\">");
        AppendPropertyGroupFirst(
            sb,
            outputType: null,
            packAsTool: false,
            useAzureFunction: false,
            useWinForm: false,
            useWpf: false);
        AppendItemGroupPackageReference(
            sb,
            new[] { "Atc", "Swashbuckle.AspNetCore" });
        sb.AppendLine();
        sb.AppendLine("</Project>");
    }

    private static void CreateCsProjFileWebApp(
        StringBuilder sb)
    {
        sb.AppendLine("<Project Sdk=\"Microsoft.NET.Sdk.Web\">");
        AppendPropertyGroupFirst(
            sb,
            outputType: null,
            packAsTool: false,
            useAzureFunction: false,
            useWinForm: false,
            useWpf: false);
        sb.AppendLine();
        sb.AppendLine("</Project>");
    }

    private static void CreateCsProjFileWorkerService(
         StringBuilder sb)
    {
        sb.AppendLine("<Project Sdk=\"Microsoft.NET.Sdk.Worker\">");
        AppendPropertyGroupFirst(
            sb,
            outputType: null,
            packAsTool: false,
            useAzureFunction: false,
            useWinForm: false,
            useWpf: false);
        sb.AppendLine();
        sb.AppendLine("</Project>");
    }

    private static void CreateCsProjFileWinFormApp(
        StringBuilder sb)
    {
        sb.AppendLine("<Project Sdk=\"Microsoft.NET.Sdk\">");
        AppendPropertyGroupFirst(
            sb,
            outputType: "WinExe",
            packAsTool: false,
            useAzureFunction: false,
            useWinForm: true,
            useWpf: false);
        sb.AppendLine();
        sb.AppendLine("</Project>");
    }

    private static void CreateCsProjFileWpfApp(
        StringBuilder sb)
    {
        sb.AppendLine("<Project Sdk=\"Microsoft.NET.Sdk\">");
        AppendPropertyGroupFirst(
            sb,
            outputType: "WinExe",
            packAsTool: false,
            useAzureFunction: false,
            useWinForm: false,
            useWpf: true);
        sb.AppendLine();
        sb.AppendLine("</Project>");
    }

    private static void CreateCsProjFileWpfLibrary(
        StringBuilder sb)
    {
        sb.AppendLine("<Project Sdk=\"Microsoft.NET.Sdk\">");
        AppendPropertyGroupFirst(
            sb,
            outputType: null,
            packAsTool: false,
            useAzureFunction: false,
            useWinForm: false,
            useWpf: true);
        sb.AppendLine();
        sb.AppendLine("</Project>");
    }

    private static Task CreateProgramCsFile(
        DirectoryInfo workingDirectory,
        string fileName,
        DotnetProjectType dotnetProjectType)
    {
        var file = new FileInfo(Path.Combine(workingDirectory.FullName, fileName));
        return File.WriteAllTextAsync(
            file.FullName,
            CreateProgramCsFile(dotnetProjectType),
            Encoding.UTF8);
    }

    private static string CreateProgramCsFile(
        DotnetProjectType dotnetProjectType)
    {
        var sb = new StringBuilder();
        switch (dotnetProjectType)
        {
            case DotnetProjectType.AzureFunctionApp:
                break;
            case DotnetProjectType.AndroidApp:
                break;
            case DotnetProjectType.ConsoleApp:
                break;
            case DotnetProjectType.CliApp:
                break;
            case DotnetProjectType.BlazorServerApp:
                CreateProgramCsFileBlazorServerApp(sb);
                break;
            case DotnetProjectType.BlazorWAsmApp:
                break;
            case DotnetProjectType.IosApp:
                break;
            case DotnetProjectType.UwpApp:
                break;
            case DotnetProjectType.WebApp:
                break;
            case DotnetProjectType.WpfApp:
                break;
            case DotnetProjectType.WinFormApp:
                break;
            case DotnetProjectType.Library:
                break;
            case DotnetProjectType.RazorLibrary:
                break;
            case DotnetProjectType.UwpLibrary:
                break;
            case DotnetProjectType.WpfLibrary:
                break;
            case DotnetProjectType.AzureIotEdgeModule:
                break;
            case DotnetProjectType.WebApi:
                break;
            case DotnetProjectType.WorkerService:
                break;
            case DotnetProjectType.BUnitTest:
                break;
            case DotnetProjectType.MsTest:
                break;
            case DotnetProjectType.NUnitTest:
                break;
            case DotnetProjectType.XUnitTest:
                break;
            default:
                throw new SwitchCaseDefaultException(dotnetProjectType);
        }

        return sb.ToString();
    }

    private static void CreateProgramCsFileBlazorServerApp(
        StringBuilder sb)
    {
        sb.AppendLine("using BlazorServerApp1.Data;");
        sb.AppendLine("using Microsoft.AspNetCore.Components;");
        sb.AppendLine("using Microsoft.AspNetCore.Components.Web;");
        sb.AppendLine();
        sb.AppendLine("var builder = WebApplication.CreateBuilder(args);");
        sb.AppendLine("builder.Services.AddRazorPages();");
        sb.AppendLine("builder.Services.AddServerSideBlazor();");
        sb.AppendLine("builder.Services.AddSingleton<WeatherForecastService>();");
        sb.AppendLine();
        sb.AppendLine("var app = builder.Build();");
        sb.AppendLine("if (!app.Environment.IsDevelopment())");
        sb.AppendLine("{");
        sb.AppendLine("    app.UseExceptionHandler(\"/Error\");");
        sb.AppendLine("    app.UseHsts();");
        sb.AppendLine("}");
        sb.AppendLine();
        sb.AppendLine("app.UseHttpsRedirection();");
        sb.AppendLine("app.UseStaticFiles();");
        sb.AppendLine("app.UseRouting();");
        sb.AppendLine("app.MapBlazorHub();");
        sb.AppendLine("app.MapFallbackToPage(\"/_Host\");");
        sb.AppendLine();
        sb.AppendLine("app.Run();");
    }

    private static void AppendPropertyGroupFirst(
        StringBuilder sb,
        string? outputType,
        bool packAsTool,
        bool useAzureFunction,
        bool useWinForm,
        bool useWpf)
    {
        sb.AppendLine();
        sb.AppendLine(2, "<PropertyGroup>");
        if (outputType is not null)
        {
            sb.Append(4, "<OutputType>");
            sb.Append(outputType);
            sb.AppendLine("</OutputType>");
        }

        if (packAsTool)
        {
            sb.AppendLine("<PackAsTool>true</PackAsTool>");
        }

        if (useAzureFunction)
        {
            sb.AppendLine("<AzureFunctionsVersion>v4</AzureFunctionsVersion>");
        }

        if (useWinForm)
        {
            sb.AppendLine("<UseWindowsForms>true</UseWindowsForms>");
        }

        if (useWpf)
        {
            sb.AppendLine("<UseWPF>true</UseWPF>");
        }

        sb.AppendLine(4, "<TargetFramework>net6.0</TargetFramework>");
        sb.AppendLine(2, "</PropertyGroup>");
    }

    private static void AppendItemGroupPackageReference(
        StringBuilder sb,
        IEnumerable<string> packageReferences)
    {
        sb.AppendLine();
        sb.AppendLine(2, "<ItemGroup>");
        foreach (var packageReference in packageReferences)
        {
            sb.Append(4, "<PackageReference Include=\"");
            sb.Append(packageReference);
            sb.AppendLine("\" Version=\"1.2.3\" />");
        }

        sb.AppendLine(2, "</ItemGroup>");
    }
}