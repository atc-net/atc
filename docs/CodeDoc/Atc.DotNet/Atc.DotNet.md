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
| 65536 | Modules | Azure Iot Edge Module |  | 
| 65536 | AzureIotEdgeModule | Azure Iot Edge Module |  | 
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
