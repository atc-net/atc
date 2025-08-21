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

>```csharp
>public static class DotnetBuildHelper
>```

### Static Methods

#### BuildAndCollectErrors
>```csharp
>Task<Dictionary<string, int>> BuildAndCollectErrors(DirectoryInfo rootPath, int? runNumber = null, FileInfo buildFile = null, bool useNugetRestore = True, bool useConfigurationReleaseMode = True, int timeoutInSec = 1200, string logPrefix = , CancellationToken cancellationToken = null)
>```
#### BuildAndCollectErrors
>```csharp
>Task<Dictionary<string, int>> BuildAndCollectErrors(ILogger logger, DirectoryInfo rootPath, int? runNumber = null, FileInfo buildFile = null, bool useNugetRestore = True, bool useConfigurationReleaseMode = True, int timeoutInSec = 1200, string logPrefix = , CancellationToken cancellationToken = null)
>```

<br />

## DotnetCsProjFileHelper

>```csharp
>public static class DotnetCsProjFileHelper
>```

### Static Methods

#### FindAllInPath
>```csharp
>Collection<FileInfo> FindAllInPath(DirectoryInfo directoryInfo, SearchOption searchOption = AllDirectories)
>```
#### FindAllInPathAndPredictProjectTypes
>```csharp
>Collection<ValueTuple<FileInfo, DotnetProjectType>> FindAllInPathAndPredictProjectTypes(DirectoryInfo directoryInfo, SearchOption searchOption = AllDirectories)
>```
#### GetProjectType
>```csharp
>DotnetProjectType GetProjectType(FileInfo fileInfo)
>```
#### GetProjectType
>```csharp
>DotnetProjectType GetProjectType(string fileContent)
>```
#### PredictProjectType
>```csharp
>DotnetProjectType PredictProjectType(FileInfo fileInfo)
>```

<br />

## DotnetGlobalUsingsHelper

>```csharp
>public static class DotnetGlobalUsingsHelper
>```

### Static Methods

#### CreateOrUpdate
>```csharp
>void CreateOrUpdate(DirectoryInfo directoryInfo, IReadOnlyList<string> requiredNamespaces, bool setSystemFirst = True, bool addNamespaceSeparator = True)
>```
#### GetNewContentByReadingExistingIfExistAndMergeWithRequired
>```csharp
>string GetNewContentByReadingExistingIfExistAndMergeWithRequired(DirectoryInfo directoryInfo, IReadOnlyList<string> requiredNamespaces, bool setSystemFirst = True, bool addNamespaceSeparator = True)
>```

<br />

## DotnetHelper

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

>```csharp
>public static class DotnetNugetHelper
>```

### Static Methods

#### GetAllPackageReferences
>```csharp
>List<DotnetNugetPackageMetadataBase> GetAllPackageReferences(FileInfo fileInfo)
>```
><b>Summary:</b> Get all PackageReferences from file.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`fileInfo`&nbsp;&nbsp;-&nbsp;&nbsp;The file.<br />
#### GetAllPackageReferences
>```csharp
>List<DotnetNugetPackageMetadataBase> GetAllPackageReferences(string fileContent)
>```
><b>Summary:</b> Get all PackageReferences from file.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`fileInfo`&nbsp;&nbsp;-&nbsp;&nbsp;The file.<br />

<br />

## DotnetProjectType

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
