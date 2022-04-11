# Atc.DotNet

This library contains extensions to wrap the usage of `dotnet.exe` from .NET code, extract metadata from `.sln` and `.csproj` files.

## Code documentation

[References](https://github.com/atc-net/atc/blob/main/docs/CodeDoc/Atc.DotNet/Index.md)

[References extended](https://github.com/atc-net/atc/blob/main/docs/CodeDoc/Atc.DotNet/IndexExtended.md)

## `DotnetHelper` examples

### Using `GetDotnetDirectory()` to find the directory path of dotnet.exe / dotnet - depends on the operating system

```csharp
DirectoryInfo dotnetDirectory = DotnetHelper.GetDotnetDirectory();
```

### Using `GetDotnetExecutable()` to find the file path of dotnet.exe / dotnet - depends on the operating system

```csharp
FileInfo dotnetFile = DotnetHelper.GetDotnetExecutable();
```

## `DotnetBuildHelper` examples

### Using `BuildAndCollectErrors(..)` to build and collect errors

This method build and collect errors if any - 0 errors is the same as a successful build.

```csharp
Dictionary<string, int> buildErrors = await DotnetBuildHelper.BuildAndCollectErrors(workingDirectory);
```

```csharp
var workingDirectory = new DirectoryInfo(@"c:\code\myproject");
var runNumber = 5;
var buildFile = new FileInfo(@"c:\code\myproject\mylib.csproj"),
var useNugetRestore = true,
var useConfigurationReleaseMode = true,
var timeoutInSec = 20,
var logPrefix = "BUILD-PREFIX";
var cancellationToken = CancellationToken.None;

Dictionary<string, int> buildErrors = await DotnetBuildHelper.BuildAndCollectErrors(
    workingDirectory,
    runNumber,
    buildFile,
    useNugetRestore,
    useConfigurationReleaseMode,
    timeoutInSec,
    logPrefix,
    cancellationToken);
```

## `DotnetCsProjFileHelper` examples

### Using `PredictProjectType(..)` to find the DotnetProjectType in a file

```csharp
var file = new FileInfo(@"c:\code\myproject\mylib.csproj"),

DotnetProjectType projectType = DotnetCsProjFileHelper.PredictProjectType(file);
```

**Note:** `PredictProjectType` use `GetProjectType` but extend the determinations with surrounded files analytics as looking into the `Program.cs`.

### Using `GetProjectType(..)` to find the DotnetProjectType in a file or file-content

```csharp
var file = new FileInfo(@"c:\code\myproject\mylib.csproj"),

DotnetProjectType projectType = DotnetCsProjFileHelper.GetProjectType(file);
```

## `DotnetNugetHelper` examples

### Using `GetAllPackageReferences(..)` to find package-references in a file or file-content

```csharp
var file = new FileInfo(@"c:\code\myproject\mylib.csproj"),

List<DotnetNugetPackageMetadataBase> packages = DotnetNugetHelper.GetAllPackageReferences(file);
```

```csharp
var file = new FileInfo(@"c:\code\myproject\mylib.csproj"),
var fileContent = File.ReadAllText(file.FullName);

List<DotnetNugetPackageMetadataBase> packages = DotnetNugetHelper.GetAllPackageReferences(fileContent);
```

## `VisualStudioSolutionFileHelper` examples

### Using `GetSolutionFileMetadata(..)` to find VisualStudio metadata in a file or file-content

```csharp
var file = new FileInfo(@"c:\code\myproject\mylib.sln"),

VisualStudioSolutionFileMetadata metadata = VisualStudioSolutionFileHelper.GetSolutionFileMetadata(file);
```

```csharp
var file = new FileInfo(@"c:\code\myproject\mylib.sln"),
var fileContent = File.ReadAllText(file.FullName);

VisualStudioSolutionFileMetadata metadata = VisualStudioSolutionFileHelper.GetSolutionFileMetadata(file);
```
