// ReSharper disable ConvertIfStatementToReturnStatement
// ReSharper disable ConvertIfStatementToSwitchStatement
// ReSharper disable InvertIf
// ReSharper disable LoopCanBeConvertedToQuery
// ReSharper disable StringLiteralTypo
// ReSharper disable SuggestBaseTypeForParameter
namespace Atc.DotNet;

public static class DotnetCsProjFileHelper
{
    public static Collection<FileInfo> FindAllInPath(
        DirectoryInfo directoryInfo,
        SearchOption searchOption = SearchOption.AllDirectories)
    {
        if (directoryInfo is null)
        {
            throw new ArgumentNullException(nameof(directoryInfo));
        }

        var result = new Collection<FileInfo>();

        var csprojFiles = Directory
            .GetFiles(directoryInfo.FullName, "*.csproj", searchOption)
            .Select(x => new FileInfo(x));

        foreach (var file in csprojFiles)
        {
            result.Add(file);
        }

        return result;
    }

    public static Collection<(FileInfo CsProjFile, DotnetProjectType ProjectType)> FindAllInPathAndPredictProjectTypes(
        DirectoryInfo directoryInfo,
        SearchOption searchOption = SearchOption.AllDirectories)
    {
        if (directoryInfo is null)
        {
            throw new ArgumentNullException(nameof(directoryInfo));
        }

        var result = new Collection<(FileInfo, DotnetProjectType)>();

        var csprojFiles = Directory
            .GetFiles(directoryInfo.FullName, "*.csproj", searchOption)
            .Select(x => new FileInfo(x));

        foreach (var file in csprojFiles)
        {
            var predictProjectType = PredictProjectType(file);
            result.Add((file, predictProjectType));
        }

        return result;
    }

    public static DotnetProjectType PredictProjectType(
        FileInfo fileInfo)
    {
        var projectType = GetProjectType(fileInfo);
        if (projectType == DotnetProjectType.None)
        {
            return DotnetProjectType.None;
        }

        if (projectType == DotnetProjectType.WebApp)
        {
            var programCsFileInfo = new FileInfo(Path.Combine(fileInfo.Directory!.FullName, "Program.cs"));
            if (programCsFileInfo.Exists)
            {
                var programCsFileContent = File.ReadAllText(programCsFileInfo.FullName);
                if (programCsFileContent.Contains(".AddServerSideBlazor", StringComparison.Ordinal))
                {
                    return DotnetProjectType.BlazorServerApp;
                }
            }
        }

        return projectType;
    }

    public static DotnetProjectType GetProjectType(
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

        if (!fileInfo.Extension.Equals(".csproj", StringComparison.OrdinalIgnoreCase))
        {
            throw new FileNotFoundException();
        }

        var fileContent = File.ReadAllText(fileInfo.FullName);

        return GetProjectType(fileContent);
    }

    [SuppressMessage("Performance", "MA0031:Optimize Enumerable.Count() usage", Justification = "OK.")]
    public static DotnetProjectType GetProjectType(
        string fileContent)
    {
        if (string.IsNullOrEmpty(fileContent))
        {
            throw new ArgumentNullException(nameof(fileContent));
        }

        if (fileContent.Contains("WebAssembly", StringComparison.Ordinal))
        {
            return DotnetProjectType.BlazorWAsmApp;
        }

        try
        {
            var rootElement = XElement.Parse(fileContent);
            if (rootElement.Attributes("Sdk").Count() == 1)
            {
                return ProjectSdkElement(rootElement);
            }

            if (rootElement.Attributes("ToolsVersion").Count() == 1)
            {
                return ProjectElementForToolsVersion(rootElement);
            }
        }
        catch (XmlException)
        {
            // Dummy
        }

        return DotnetProjectType.None;
    }

    private static DotnetProjectType ProjectSdkElement(
        XElement rootElement)
    {
        if (rootElement.FirstAttribute.Value.Equals("Microsoft.NET.Sdk.BlazorWebAssembly", StringComparison.Ordinal))
        {
            return DotnetProjectType.BlazorWAsmApp;
        }

        if (rootElement.FirstAttribute.Value.Equals("Microsoft.NET.Sdk.Razor", StringComparison.Ordinal))
        {
            return DotnetProjectType.RazorLibrary;
        }

        if (rootElement.FirstAttribute.Value.Equals("Microsoft.NET.Sdk.Worker", StringComparison.Ordinal))
        {
            return DotnetProjectType.WorkerService;
        }

        var projectType = ProjectElementForSdkTest(rootElement);
        if (projectType != DotnetProjectType.None)
        {
            return projectType;
        }

        projectType = ProjectElementForSdkWeb(rootElement);
        if (projectType != DotnetProjectType.None)
        {
            return projectType;
        }

        projectType = ProjectElementForSdk(rootElement);
        if (projectType != DotnetProjectType.None)
        {
            return projectType;
        }

        return DotnetProjectType.None;
    }

    private static DotnetProjectType ProjectElementForSdk(
        XElement rootElement)
    {
        if (!rootElement.FirstAttribute.Value.Equals("Microsoft.NET.Sdk", StringComparison.Ordinal))
        {
            return DotnetProjectType.None;
        }

        if (IsProjectCapabilityAzureIoTEdgeModule(rootElement) ||
            HasPackageReference(rootElement, "Microsoft.Azure.Devices.Client"))
        {
            return DotnetProjectType.AzureIotEdgeModule;
        }

        if (IsAzureFunction(rootElement))
        {
            return DotnetProjectType.AzureFunctionApp;
        }

        if (IsWinForms(rootElement))
        {
            return IsOutputType(rootElement, "WinExe")
                ? DotnetProjectType.WinFormApp
                : DotnetProjectType.Library;
        }

        if (IsMaui(rootElement))
        {
            return DotnetProjectType.MauiApp;
        }

        if (IsWpf(rootElement))
        {
            return IsOutputType(rootElement, "WinExe")
                ? DotnetProjectType.WpfApp
                : DotnetProjectType.WpfLibrary;
        }

        if (IsOutputType(rootElement, "Exe"))
        {
            return IsPackAsTool(rootElement)
                ? DotnetProjectType.CliApp
                : DotnetProjectType.ConsoleApp;
        }

        return IsOutputType(rootElement, "Library")
            ? DotnetProjectType.Library
            : DotnetProjectType.None;
    }

    private static DotnetProjectType ProjectElementForSdkTest(
        XElement rootElement)
    {
        if (!rootElement.FirstAttribute.Value.Equals("Microsoft.NET.Sdk", StringComparison.Ordinal))
        {
            return DotnetProjectType.None;
        }

        if (HasUnitTestLibrary(rootElement, "bunit"))
        {
            return DotnetProjectType.BUnitTest;
        }

        if (HasUnitTestLibrary(rootElement, "MSTest.TestAdapter"))
        {
            return DotnetProjectType.MsTest;
        }

        if (HasUnitTestLibrary(rootElement, "NUnit"))
        {
            return DotnetProjectType.NUnitTest;
        }

        if (HasUnitTestLibrary(rootElement, "xunit"))
        {
            return DotnetProjectType.XUnitTest;
        }

        return DotnetProjectType.None;
    }

    private static DotnetProjectType ProjectElementForSdkWeb(
        XElement rootElement)
    {
        if (!rootElement.FirstAttribute.Value.Equals("Microsoft.NET.Sdk.Web", StringComparison.Ordinal))
        {
            return DotnetProjectType.None;
        }

        if (HasPackageReference(rootElement, "Swashbuckle.AspNetCore") ||
            HasPackageReference(rootElement, "Atc.Rest.Extended") ||
            HasPackageReference(rootElement, "Atc.Rest"))
        {
            return DotnetProjectType.WebApi;
        }

        return DotnetProjectType.WebApp;
    }

    private static DotnetProjectType ProjectElementForToolsVersion(
        XElement rootElement)
    {
        if (IsAndroid(rootElement))
        {
            return DotnetProjectType.AndroidApp;
        }

        if (IsIos(rootElement))
        {
            return DotnetProjectType.IosApp;
        }

        if (IsUwp(rootElement))
        {
            return IsOutputType(rootElement, "AppContainerExe")
                ? DotnetProjectType.UwpApp
                : DotnetProjectType.UwpLibrary;
        }

        if (IsVisualStudioExtension(rootElement))
        {
            return DotnetProjectType.VisualStudioExtension;
        }

        if (IsOutputType(rootElement, "Library"))
        {
            return DotnetProjectType.Library;
        }

        return DotnetProjectType.None;
    }

    private static bool HasPackageReference(
        XElement rootElement,
        string packageReference)
    {
        var packageReferenceElement = rootElement
            .Elements()
            .Where(x => x.Name.LocalName == "ItemGroup")
            .Descendants()
            .FirstOrDefault(x =>
                x.Name.LocalName == "PackageReference" &&
                x.Attribute("Include") is not null &&
                x.Attribute("Include")!.Value.Equals(packageReference, StringComparison.Ordinal));

        return packageReferenceElement is not null;
    }

    private static bool HasUnitTestLibrary(
        XElement rootElement,
        string testLibraryName)
    {
        var isTestProjectElement = rootElement
            .Elements()
            .Where(x => x.Name.LocalName == "PropertyGroup")
            .Descendants()
            .FirstOrDefault(x => x.Name.LocalName == "IsTestProject");

        return (isTestProjectElement is null || !isTestProjectElement.Value.IsFalse()) &&
               HasPackageReference(rootElement, testLibraryName);
    }

    private static bool IsPackAsTool(
        XElement rootElement)
    {
        var element = rootElement
            .Elements()
            .Where(x => x.Name.LocalName == "PropertyGroup")
            .Descendants()
            .FirstOrDefault(x => x.Name.LocalName == "PackAsTool");

        return element is not null &&
               element.Value.IsTrue();
    }

    private static bool IsAndroid(
        XElement rootElement)
    {
        var element = rootElement
            .Elements()
            .Where(x => x.Name.LocalName == "PropertyGroup")
            .Descendants()
            .FirstOrDefault(x => x.Name.LocalName == "AndroidApplication");

        return element is not null &&
               element.Value.IsTrue();
    }

    private static bool IsAzureFunction(
        XElement rootElement)
    {
        var element = rootElement
            .Elements()
            .Where(x => x.Name.LocalName == "PropertyGroup")
            .Descendants()
            .FirstOrDefault(x => x.Name.LocalName == "AzureFunctionsVersion");

        return element is not null;
    }

    private static bool IsIos(
        XElement rootElement)
    {
        var element = rootElement
            .Elements()
            .Where(x => x.Name.LocalName == "PropertyGroup")
            .Descendants()
            .FirstOrDefault(x => x.Name.LocalName == "IPhoneResourcePrefix");

        return element is not null &&
               element.Value.Equals("Resources", StringComparison.Ordinal);
    }

    private static bool IsVisualStudioExtension(
        XElement rootElement)
    {
        var element = rootElement
            .Elements()
            .Where(x => x.Name.LocalName == "PropertyGroup")
            .Descendants()
            .FirstOrDefault(x => x.Name.LocalName == "IncludeAssemblyInVSIXContainer");

        return element is not null &&
               element.Value.IsTrue();
    }

    private static bool IsUwp(
        XElement rootElement)
    {
        var element = rootElement
            .Elements()
            .Where(x => x.Name.LocalName == "PropertyGroup")
            .Descendants()
            .FirstOrDefault(x => x.Name.LocalName == "TargetPlatformIdentifier");

        return element is not null &&
               element.Value.Equals("UAP", StringComparison.Ordinal);
    }

    private static bool IsWinForms(
        XElement rootElement)
    {
        var element = rootElement
            .Elements()
            .Where(x => x.Name.LocalName == "PropertyGroup")
            .Descendants()
            .FirstOrDefault(x => x.Name.LocalName == "UseWindowsForms");

        return element is not null &&
               element.Value.IsTrue();
    }

    private static bool IsMaui(
        XElement rootElement)
    {
        var element = rootElement
            .Elements()
            .Where(x => x.Name.LocalName == "PropertyGroup")
            .Descendants()
            .FirstOrDefault(x => x.Name.LocalName == "UseMaui");

        return element is not null &&
               element.Value.IsTrue();
    }

    private static bool IsWpf(
        XElement rootElement)
    {
        var element = rootElement
            .Elements()
            .Where(x => x.Name.LocalName == "PropertyGroup")
            .Descendants()
            .FirstOrDefault(x => x.Name.LocalName == "UseWPF");

        return element is not null &&
               element.Value.IsTrue();
    }

    private static bool IsProjectCapabilityAzureIoTEdgeModule(
        XElement rootElement)
    {
        var elements = rootElement
            .Elements()
            .Where(x => x.Name.LocalName == "ItemGroup")
            .Descendants()
            .Where(x => x.Name.LocalName == "ProjectCapability");

        foreach (var element in elements)
        {
            var attribute = element.Attribute("Include");
            if (attribute is not null &&
                attribute.Value == "AzureIoTEdgeModule")
            {
                return true;
            }
        }

        return false;
    }

    private static bool IsOutputType(
            XElement rootElement,
            string value)
    {
        var element = rootElement
            .Elements()
            .Where(x => x.Name.LocalName == "PropertyGroup")
            .Descendants()
            .FirstOrDefault(x => x.Name.LocalName == "OutputType");

        if (element is null &&
            "Library".Equals(value, StringComparison.Ordinal))
        {
            return true;
        }

        return element is not null &&
               element.Value.Equals(value, StringComparison.Ordinal);
    }
}