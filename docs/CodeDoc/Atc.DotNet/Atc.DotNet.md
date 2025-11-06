<div style='text-align: right'>

[References](Index.md)&nbsp;&nbsp;-&nbsp;&nbsp;[References extended](IndexExtended.md)
</div>

# Atc.DotNet

<br />

## AtcDotnetAssemblyTypeInitializer

>```csharp
>public static class AtcDotnetAssemblyTypeInitializer
>```


<br />

## DotnetBuildHelper
Provides helper methods for building .NET projects and solutions using the dotnet CLI.

>```csharp
>public static class DotnetBuildHelper
>```

### Static Methods

#### BuildAndCollectErrors
>```csharp
>Task<Dictionary<string, int>> BuildAndCollectErrors(DirectoryInfo rootPath, int? runNumber = null, FileInfo buildFile = null, bool useNugetRestore = True, bool useConfigurationReleaseMode = True, int timeoutInSec = 1200, string logPrefix = , CancellationToken cancellationToken = null)
>```
><b>Summary:</b> Builds a .NET project or solution and collects compilation errors grouped by error code.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`rootPath`&nbsp;&nbsp;-&nbsp;&nbsp;The root directory containing the project or solution to build.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`runNumber`&nbsp;&nbsp;-&nbsp;&nbsp;Optional run number for logging purposes.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`buildFile`&nbsp;&nbsp;-&nbsp;&nbsp;Optional specific solution or project file to build. If not specified, discovers the build file automatically.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`useNugetRestore`&nbsp;&nbsp;-&nbsp;&nbsp;Whether to perform NuGet restore before building. Default is true.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`useConfigurationReleaseMode`&nbsp;&nbsp;-&nbsp;&nbsp;Whether to build in Release mode. If false, builds in Debug mode. Default is true.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`timeoutInSec`&nbsp;&nbsp;-&nbsp;&nbsp;Build timeout in seconds. Default is 1200 seconds (20 minutes).<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`logPrefix`&nbsp;&nbsp;-&nbsp;&nbsp;Optional prefix for log messages.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`cancellationToken`&nbsp;&nbsp;-&nbsp;&nbsp;Token to cancel the build operation.<br />
>
><b>Returns:</b> A dictionary mapping error codes to their occurrence counts.
#### BuildAndCollectErrors
>```csharp
>Task<Dictionary<string, int>> BuildAndCollectErrors(ILogger logger, DirectoryInfo rootPath, int? runNumber = null, FileInfo buildFile = null, bool useNugetRestore = True, bool useConfigurationReleaseMode = True, int timeoutInSec = 1200, string logPrefix = , CancellationToken cancellationToken = null)
>```
><b>Summary:</b> Builds a .NET project or solution and collects compilation errors grouped by error code.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`rootPath`&nbsp;&nbsp;-&nbsp;&nbsp;The root directory containing the project or solution to build.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`runNumber`&nbsp;&nbsp;-&nbsp;&nbsp;Optional run number for logging purposes.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`buildFile`&nbsp;&nbsp;-&nbsp;&nbsp;Optional specific solution or project file to build. If not specified, discovers the build file automatically.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`useNugetRestore`&nbsp;&nbsp;-&nbsp;&nbsp;Whether to perform NuGet restore before building. Default is true.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`useConfigurationReleaseMode`&nbsp;&nbsp;-&nbsp;&nbsp;Whether to build in Release mode. If false, builds in Debug mode. Default is true.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`timeoutInSec`&nbsp;&nbsp;-&nbsp;&nbsp;Build timeout in seconds. Default is 1200 seconds (20 minutes).<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`logPrefix`&nbsp;&nbsp;-&nbsp;&nbsp;Optional prefix for log messages.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`cancellationToken`&nbsp;&nbsp;-&nbsp;&nbsp;Token to cancel the build operation.<br />
>
><b>Returns:</b> A dictionary mapping error codes to their occurrence counts.

<br />

## DotnetCsProjFileHelper
Provides helper methods for discovering and analyzing .NET C# project files (.csproj).

>```csharp
>public static class DotnetCsProjFileHelper
>```

### Static Methods

#### FindAllInPath
>```csharp
>Collection<FileInfo> FindAllInPath(DirectoryInfo directoryInfo, SearchOption searchOption = AllDirectories)
>```
><b>Summary:</b> Finds all .csproj files within the specified directory.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`directoryInfo`&nbsp;&nbsp;-&nbsp;&nbsp;The directory to search in.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`searchOption`&nbsp;&nbsp;-&nbsp;&nbsp;Specifies whether to search the current directory only or all subdirectories. Default is .<br />
>
><b>Returns:</b> A collection of `System.IO.FileInfo` objects representing found .csproj files.
#### FindAllInPathAndPredictProjectTypes
>```csharp
>Collection<ValueTuple<FileInfo, DotnetProjectType>> FindAllInPathAndPredictProjectTypes(DirectoryInfo directoryInfo, SearchOption searchOption = AllDirectories)
>```
><b>Summary:</b> Finds all .csproj files within the specified directory and predicts their project types.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`directoryInfo`&nbsp;&nbsp;-&nbsp;&nbsp;The directory to search in.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`searchOption`&nbsp;&nbsp;-&nbsp;&nbsp;Specifies whether to search the current directory only or all subdirectories. Default is .<br />
>
><b>Returns:</b> A collection of tuples containing the .csproj file and its predicted `Atc.DotNet.DotnetProjectType`.
#### GetProjectType
>```csharp
>DotnetProjectType GetProjectType(FileInfo fileInfo)
>```
><b>Summary:</b> Determines the project type by analyzing the .csproj file content.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`fileInfo`&nbsp;&nbsp;-&nbsp;&nbsp;The .csproj file to analyze.<br />
>
><b>Returns:</b> The `Atc.DotNet.DotnetProjectType` determined from the project file.
#### GetProjectType
>```csharp
>DotnetProjectType GetProjectType(string fileContent)
>```
><b>Summary:</b> Determines the project type by analyzing the .csproj file content.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`fileInfo`&nbsp;&nbsp;-&nbsp;&nbsp;The .csproj file to analyze.<br />
>
><b>Returns:</b> The `Atc.DotNet.DotnetProjectType` determined from the project file.
#### PredictProjectType
>```csharp
>DotnetProjectType PredictProjectType(FileInfo fileInfo)
>```
><b>Summary:</b> Predicts the project type of a .csproj file by analyzing its content and related files.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`fileInfo`&nbsp;&nbsp;-&nbsp;&nbsp;The .csproj file to analyze.<br />
>
><b>Returns:</b> The predicted `Atc.DotNet.DotnetProjectType`.
>
><b>Remarks:</b> This method enhances `Atc.DotNet.DotnetCsProjFileHelper.GetProjectType(System.IO.FileInfo)` by examining additional context, such as checking for Blazor Server patterns in Program.cs files.

<br />

## DotnetGlobalUsingsHelper
Provides helper methods for creating and updating GlobalUsings.cs files in .NET projects.

>```csharp
>public static class DotnetGlobalUsingsHelper
>```

### Static Methods

#### CreateOrUpdate
>```csharp
>void CreateOrUpdate(DirectoryInfo directoryInfo, IReadOnlyList<string> requiredNamespaces, bool setSystemFirst = True, bool addNamespaceSeparator = True)
>```
><b>Summary:</b> Creates or updates a GlobalUsings.cs file in the specified directory with the required namespaces.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`directoryInfo`&nbsp;&nbsp;-&nbsp;&nbsp;The directory where GlobalUsings.cs should be created or updated.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`requiredNamespaces`&nbsp;&nbsp;-&nbsp;&nbsp;The list of namespaces to include in the global usings file.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`setSystemFirst`&nbsp;&nbsp;-&nbsp;&nbsp;Whether to place System namespaces before other namespaces. Default is true.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`addNamespaceSeparator`&nbsp;&nbsp;-&nbsp;&nbsp;Whether to add blank lines between namespace groups. Default is true.<br />
#### GetNewContentByReadingExistingIfExistAndMergeWithRequired
>```csharp
>string GetNewContentByReadingExistingIfExistAndMergeWithRequired(DirectoryInfo directoryInfo, IReadOnlyList<string> requiredNamespaces, bool setSystemFirst = True, bool addNamespaceSeparator = True)
>```
><b>Summary:</b> Generates global usings content by merging existing namespaces (if the file exists) with required namespaces.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`directoryInfo`&nbsp;&nbsp;-&nbsp;&nbsp;The directory to check for an existing GlobalUsings.cs file.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`requiredNamespaces`&nbsp;&nbsp;-&nbsp;&nbsp;The list of namespaces that must be included.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`setSystemFirst`&nbsp;&nbsp;-&nbsp;&nbsp;Whether to place System namespaces before other namespaces. Default is true.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`addNamespaceSeparator`&nbsp;&nbsp;-&nbsp;&nbsp;Whether to add blank lines between namespace groups. Default is true.<br />
>
><b>Returns:</b> The formatted global usings content ready to be written to a file.

<br />

## DotnetHelper
Provides helper methods for working with the .NET SDK and runtime.

>```csharp
>public static class DotnetHelper
>```

### Static Methods

#### GetDotnetDirectory
>```csharp
>DirectoryInfo GetDotnetDirectory()
>```
><b>Summary:</b> Get the directory of the .NET runtime.
>
><b>Remarks:</b> This method is platform independent.<br>The default location on Windows is C:\Program Files\dotnet.<br>The default location on Linux and macOS is /usr/share/dotnet.<br>On Linux it varies from distribution to distribution and method of installation.
#### GetDotnetExecutable
>```csharp
>FileInfo GetDotnetExecutable()
>```
><b>Summary:</b> Get the dotnet executable file from the OS.
>
><b>Remarks:</b> This method is platform independent.
#### GetDotnetVersion
>```csharp
>Task<Version> GetDotnetVersion()
>```
><b>Summary:</b> Get the dotnet version.
>
><b>Remarks:</b> This method is platform independent.

<br />

## DotnetNugetHelper
Provides helper methods for extracting NuGet package references from .NET project files.

>```csharp
>public static class DotnetNugetHelper
>```

### Static Methods

#### GetAllPackageReferences
>```csharp
>List<DotnetNugetPackageMetadataBase> GetAllPackageReferences(FileInfo fileInfo)
>```
><b>Summary:</b> Extracts all PackageReference elements from a .csproj or similar project file.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`fileInfo`&nbsp;&nbsp;-&nbsp;&nbsp;The project file to parse.<br />
>
><b>Returns:</b> A sorted list of `Atc.DotNet.Models.DotnetNugetPackageMetadataBase` containing package IDs and versions.
#### GetAllPackageReferences
>```csharp
>List<DotnetNugetPackageMetadataBase> GetAllPackageReferences(string fileContent)
>```
><b>Summary:</b> Extracts all PackageReference elements from a .csproj or similar project file.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`fileInfo`&nbsp;&nbsp;-&nbsp;&nbsp;The project file to parse.<br />
>
><b>Returns:</b> A sorted list of `Atc.DotNet.Models.DotnetNugetPackageMetadataBase` containing package IDs and versions.

<br />

## DotnetProjectType
Defines the types of .NET projects. This enum uses flags to allow combining multiple project types.

>```csharp
>public enum DotnetProjectType
>```


| Value | Name | Description | Summary | 
| --- | --- | --- | --- | 
| 0 | None | None |  | 
| 1 | AzureFunctionApp | Azure Function App |  | 
| 2 | AndroidApp | Android App |  | 
| 4 | ConsoleApp | Console App |  | 
| 8 | CliApp | Cli App |  | 
| 16 | BlazorServerApp | Blazor Server App |  | 
| 32 | BlazorWAsmApp | Blazor WAsm App |  | 
| 64 | MauiApp | Maui App |  | 
| 128 | IosApp | Ios App |  | 
| 256 | UwpApp | Uwp App |  | 
| 512 | WebApp | Web App |  | 
| 1024 | WpfApp | Wpf App |  | 
| 2048 | WinFormApp | Win Form App |  | 
| 4095 | Apps | Apps |  | 
| 4096 | Library | Library |  | 
| 8192 | RazorLibrary | Razor Library |  | 
| 16384 | UwpLibrary | Uwp Library |  | 
| 32768 | WpfLibrary | Wpf Library |  | 
| 61440 | Libraries | Libraries |  | 
| 65536 | AzureIotEdgeModule | Modules |  | 
| 65536 | Modules | Modules |  | 
| 131072 | VisualStudioExtension | Visual Studio Extension |  | 
| 262144 | WebApi | Web Api |  | 
| 524288 | WorkerService | Worker Service |  | 
| 786432 | Services | Services |  | 
| 1048576 | BUnitTest | BUnit Test |  | 
| 2097152 | MsTest | Ms Test |  | 
| 4194304 | NUnitTest | NUnit Test |  | 
| 8388608 | XUnitTest | XUnit Test |  | 
| 15728640 | Tests | Tests |  | 



<br />

## VisualStudioSolutionFileHelper
Utilities for discovering Visual Studio solution files and extracting basic metadata from both the classic text-based `.sln` format and the newer XML-based `.slnx` format.
><b>Remarks:</b> <b>.sln</b> files contain header lines that expose values such as: `Microsoft Visual Studio Solution File, Format Version X.Y`, `# Visual Studio 17`, `VisualStudioVersion`, and `MinimumVisualStudioVersion`. These are parsed directly from the text.<br><b>.slnx</b> files are XML and typically do not include the same header fields. When available, this helper reads Visual Studio–related properties under `&lt;Properties Name="Visual Studio"&gt;`. In particular, an optional `&lt;Property Name="OpenWith" Value="17" /&gt;` is interpreted as the `Atc.DotNet.Models.VisualStudioSolutionFileMetadata.VisualStudioVersionNumber` (e.g., 17 for VS 2022/2025). If an XML file omits these properties, the corresponding metadata fields remain at their defaults.

>```csharp
>public static class VisualStudioSolutionFileHelper
>```

### Static Methods

#### FindAllInPath
>```csharp
>Collection<FileInfo> FindAllInPath(DirectoryInfo directoryInfo, SearchOption searchOption = AllDirectories)
>```
><b>Summary:</b> Recursively finds both `.sln` and `.slnx` files under the specified directory.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`directoryInfo`&nbsp;&nbsp;-&nbsp;&nbsp;Root directory to search from.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`searchOption`&nbsp;&nbsp;-&nbsp;&nbsp;
            Search depth. Defaults to  to recurse into subfolders.
            <br />
>
><b>Returns:</b> A collection of `System.IO.FileInfo` objects representing all matching solution files.
>
><b>Remarks:</b> This method is resilient to `System.IO.DirectoryNotFoundException` and `System.UnauthorizedAccessException` while traversing; such errors are swallowed and the offending paths are skipped.
#### GetSolutionFileMetadata
>```csharp
>VisualStudioSolutionFileMetadata GetSolutionFileMetadata(FileInfo fileInfo)
>```
><b>Summary:</b> Reads a `.sln` or `.slnx` file from disk and returns parsed metadata.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`fileInfo`&nbsp;&nbsp;-&nbsp;&nbsp;A  pointing to the solution file.<br />
>
><b>Returns:</b> Populated `Atc.DotNet.Models.VisualStudioSolutionFileMetadata` for the given file.
>
><b>Remarks:</b> For `.slnx` (XML) solutions, only properties present in the XML are populated. If the `OpenWith` property is present under `&lt;Properties Name="Visual Studio"&gt;`, it is parsed as `Atc.DotNet.Models.VisualStudioSolutionFileMetadata.VisualStudioVersionNumber`.
#### GetSolutionFileMetadata
>```csharp
>VisualStudioSolutionFileMetadata GetSolutionFileMetadata(string fileContent)
>```
><b>Summary:</b> Reads a `.sln` or `.slnx` file from disk and returns parsed metadata.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`fileInfo`&nbsp;&nbsp;-&nbsp;&nbsp;A  pointing to the solution file.<br />
>
><b>Returns:</b> Populated `Atc.DotNet.Models.VisualStudioSolutionFileMetadata` for the given file.
>
><b>Remarks:</b> For `.slnx` (XML) solutions, only properties present in the XML are populated. If the `OpenWith` property is present under `&lt;Properties Name="Visual Studio"&gt;`, it is parsed as `Atc.DotNet.Models.VisualStudioSolutionFileMetadata.VisualStudioVersionNumber`.
<hr /><div style='text-align: right'><i>Generated by MarkdownCodeDoc version 1.2</i></div>
