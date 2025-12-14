# Atc.DotNet

**Target Framework:** `net9.0`, `net10.0`

Programmatic interface to dotnet.exe and utilities for parsing .NET project files. Provides helpers for executing dotnet commands, analyzing project structure, and extracting metadata from solution and project files.

## Why Use This Library?

Automating .NET build processes and analyzing project files requires executing dotnet.exe and parsing project XML. Atc.DotNet simplifies this by providing:

- **DotnetHelper**: Locate and execute dotnet.exe programmatically
- **DotnetBuildHelper**: Build projects and collect compilation errors
- **DotnetCsProjFileHelper**: Parse and analyze .csproj files
- **DotnetNugetHelper**: Extract NuGet package references
- **VisualStudioSolutionFileHelper**: Parse .sln files and extract metadata
- **Project Type Detection**: Identify console apps, libraries, test projects, etc.

Perfect for:
- Build automation tools
- Code generators analyzing project structure
- CI/CD pipeline utilities
- DevOps tooling for .NET projects
- Project scaffolding and templates
- Dependency analysis tools

## Installation

```bash
dotnet add package Atc.DotNet
```

## Target Framework

- .NET 9.0

## Key Features

- Locate dotnet.exe installation directory and executable
- Execute dotnet build with error collection
- Parse .csproj files and extract project type
- Extract NuGet package references from projects
- Parse Visual Studio solution files
- Detect project types (Console, Library, Web, Test, etc.)
- Analyze project dependencies
- Support for both file-based and content-based parsing

## Requirements

- [.NET 9](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)

## Key Dependencies

- Atc (foundation library)

## Main Components

### DotnetHelper

Utilities for locating and working with dotnet.exe:
- `GetDotnetDirectory()`: Finds the dotnet installation directory
- `GetDotnetExecutable()`: Gets the full path to dotnet.exe

### DotnetBuildHelper

Build automation and error collection:
- `BuildAndCollectErrors()`: Builds project and returns compilation errors

### DotnetCsProjFileHelper

Project file analysis:
- `PredictProjectType()`: Determines project type with file analytics
- `GetProjectType()`: Determines project type from .csproj content

### DotnetNugetHelper

NuGet package analysis:
- `GetAllPackageReferences()`: Extracts all package references from project

### VisualStudioSolutionFileHelper

Solution file parsing:
- `GetSolutionFileMetadata()`: Extracts metadata from .sln files

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

## Contributing

Contributions are welcome! Please see the main [repository README](../../README.md) for contribution guidelines.
