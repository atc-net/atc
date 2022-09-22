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
| 64 | IosApp | Ios App |  | 
| 128 | UwpApp | Uwp App |  | 
| 256 | WebApp | Web App |  | 
| 512 | WpfApp | Wpf App |  | 
| 1024 | WinFormApp | Win Form App |  | 
| 2047 | Apps | Apps |  | 
| 2048 | Library | Library |  | 
| 4096 | RazorLibrary | Razor Library |  | 
| 8192 | UwpLibrary | Uwp Library |  | 
| 16384 | WpfLibrary | Wpf Library |  | 
| 30720 | Libraries | Libraries |  | 
| 32768 | Modules | Azure Iot Edge Module |  | 
| 32768 | AzureIotEdgeModule | Azure Iot Edge Module |  | 
| 65536 | VisualStudioExtension | Visual Studio Extension |  | 
| 131072 | WebApi | Web Api |  | 
| 262144 | WorkerService | Worker Service |  | 
| 393216 | Services | Services |  | 
| 524288 | BUnitTest | BUnit Test |  | 
| 1048576 | MsTest | Ms Test |  | 
| 2097152 | NUnitTest | NUnit Test |  | 
| 4194304 | XUnitTest | XUnit Test |  | 
| 7864320 | Tests | Tests |  | 



<br />

## VisualStudioSolutionFileHelper

>```csharp
>public static class VisualStudioSolutionFileHelper
>```

### Static Methods

#### FindAllInPath
>```csharp
>Collection<FileInfo> FindAllInPath(DirectoryInfo directoryInfo, SearchOption searchOption = AllDirectories)
>```
#### GetSolutionFileMetadata
>```csharp
>VisualStudioSolutionFileMetadata GetSolutionFileMetadata(FileInfo fileInfo)
>```
#### GetSolutionFileMetadata
>```csharp
>VisualStudioSolutionFileMetadata GetSolutionFileMetadata(string fileContent)
>```
<hr /><div style='text-align: right'><i>Generated by MarkdownCodeDoc version 1.2</i></div>
