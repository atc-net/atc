# Atc.DotNet

This library contains extensions to wrap the usage of `dotnet.exe` from .NET code, extract metadata from `.sln` and `.csproj` files.

### Requirements

* [.NET 6](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)

### DotnetHelper examples

```csharp
var buildErrors = await DotnetBuildHelper.BuildAndCollectErrors(workingDirectory);
```

```csharp
DirectoryInfo dotnetDirectory =DotnetHelper.GetDotnetDirectory();
```

```csharp
FileInfo dotnetFile = DotnetHelper.GetDotnetExecutable();
```

### DotnetBuildHelper examples

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

### DotnetNugetHelper examples

```csharp
var file = new FileInfo(@"c:\code\myproject\mylib.csproj"),

List<DotnetNugetPackageMetadataBase> packages = DotnetNugetHelper.GetAllPackageReferences(file);
```

### Usage - VisualStudioSolutionFileHelper
```csharp
var file = new FileInfo(@"c:\code\myproject\mylib.sln"),

VisualStudioSolutionFileMetadata metadata = VisualStudioSolutionFileHelper.GetSolutionFileMetadata(file);
```
