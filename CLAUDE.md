# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Overview

ATC.Net is a monorepo containing common libraries for .NET development. It consists of 11 NuGet packages primarily targeting .NET 9.0. The repository uses the new Visual Studio .slnx solution format and follows strict code quality standards.

### Target Framework Summary
- **Atc**: `netstandard2.1`, `net9.0` (multi-targets for broad compatibility)
- **Atc.CodeAnalysis.CSharp**: `netstandard2.0`, `net9.0` (multi-targets for Roslyn compatibility)
- **All other packages**: `net9.0` (single target)

## Build and Test Commands

### Building the Solution
```bash
# Clean and restore
dotnet clean -c Release && dotnet nuget locals all --clear
dotnet restore

# Build all projects (Release mode)
dotnet build -c Release --no-restore

# Build netstandard2.1 target (Atc project only)
dotnet build -c Release --no-restore -f netstandard2.1 src/Atc/Atc.csproj
```

### Running Tests
```bash
# Run all unit tests (excludes integration tests)
dotnet test -c Release --no-build --filter "Category!=Integration"

# Run tests for a specific project
dotnet test test/Atc.Tests/Atc.Tests.csproj -c Release

# Run with code coverage
dotnet test -c Release --collect:"XPlat Code Coverage"
```

### Packaging
```bash
# Create NuGet packages
dotnet pack -c Release --no-restore -o ./packages
```

## Project Structure

### Core Libraries (src/)
- **Atc** (`netstandard2.1`, `net9.0`): Foundation library with common extensions, helpers, and utilities. Multi-targets for broad compatibility. Contains extensive extension methods for base types (String, Enum, DateTime, etc.), serialization helpers, and data structures.
- **Atc.Rest**: Basic ASP.NET Core WebApi functionality with middleware, filters, and result types. Foundation for REST API development.
- **Atc.Rest.Extended**: Advanced REST features including Swagger/OpenAPI, FluentValidation, API versioning, and JWT authentication. Builds on Atc.Rest.
- **Atc.Rest.FluentAssertions**: Testing helpers and custom assertions for REST APIs using FluentAssertions.
- **Atc.Rest.HealthChecks**: Health check implementations for ASP.NET Core applications.

### Code Analysis and Documentation (src/)
- **Atc.CodeAnalysis.CSharp** (`netstandard2.0`, `net9.0`): Roslyn-based code analysis utilities for working with C# syntax trees and semantic models. Multi-targets to support both .NET Framework 4.6.1+ and modern .NET.
- **Atc.CodeDocumentation** (`net9.0`): Markdown documentation generator from XML documentation comments and source code.

### Tooling Libraries (src/)
- **Atc.OpenApi**: Extensions and utilities for Microsoft.OpenApi, including schema extensions and data type handling.
- **Atc.Console.Spectre**: Wrappers and extensions for Spectre.Console to simplify CLI application development.
- **Atc.DotNet**: Programmatic interface to dotnet.exe for build automation and tooling.

### Testing (src/)
- **Atc.XUnit**: Test utilities and code compliance helpers for xUnit tests. Includes methods for ensuring documentation and test coverage.

### Test Projects (test/)
Each library has a corresponding test project (e.g., Atc.Tests, Atc.Rest.Tests) using xUnit v3 with:
- AutoFixture for test data generation
- FluentAssertions for readable assertions
- NSubstitute for mocking
- Atc.Test for shared test utilities

## Architecture Patterns

### Extension Method Organization
The codebase heavily uses extension methods organized by type:
- Extensions are in `Extensions/` folders within each project
- Named by pattern: `{Type}Extensions.cs` (e.g., StringExtensions.cs, EnumExtensions.cs)
- Further organized in subfolders by category (e.g., Extensions/BaseTypes/, Extensions/Reflection/)

### Project Dependencies
```
Atc (foundation)
  ├── Atc.Rest
  │     ├── Atc.Rest.Extended
  │     ├── Atc.Rest.FluentAssertions
  │     └── Atc.Rest.HealthChecks
  ├── Atc.OpenApi
  ├── Atc.CodeAnalysis.CSharp
  ├── Atc.CodeDocumentation
  ├── Atc.Console.Spectre
  ├── Atc.DotNet
  └── Atc.XUnit
```

### GlobalUsings Pattern
Each project defines common usings in a `GlobalUsings.cs` file to reduce boilerplate and ensure consistency across the project.

## Code Standards

### Compiler and Analyzer Settings
- **Nullable**: Enabled for source projects, annotations-only for tests
- **LangVersion**: C# 11.0
- **ImplicitUsings**: Enabled
- **AnalysisMode**: AllEnabledByDefault with latest analysis level
- **TreatWarningsAsErrors**: True in Release builds

### Active Analyzers
The solution uses comprehensive static analysis:
- AsyncFixer: Async/await best practices
- Asyncify: Synchronous to async method suggestions
- Meziantou.Analyzer: General C# best practices
- SecurityCodeScan: Security vulnerability detection
- StyleCop.Analyzers: Code style enforcement
- SonarAnalyzer.CSharp: Code quality and bug detection

### EditorConfig
The repository follows ATC Coding Rules v1.0.1 (https://github.com/atc-net/atc-coding-rules):
- Indent: 4 spaces
- Charset: UTF-8
- Line endings: Consistent (no final newline)
- Trim trailing whitespace (except in .md files)

### XML Documentation Standards
All 399 source files across the 11 projects have comprehensive XML documentation. Every public class, method, property, field, and enum value is documented following these standards:

**Required Documentation Elements:**
- `/// <summary>`: Required for all public types and members. Should clearly explain the purpose and behavior, not just restate the name.
- `/// <param>`: Required for all method parameters. Describe the parameter's purpose and any constraints.
- `/// <returns>`: Required for methods with return values. Explain what is returned and under what conditions.
- `/// <exception>`: Required when methods throw exceptions. Document the exception type and conditions that trigger it.
- `/// <typeparam>`: Required for generic type parameters. Explain the type parameter's purpose and constraints.
- `/// <inheritdoc />`: Use for overridden members or interface implementations when documentation is identical to the base.

**Documentation Quality Guidelines:**
- Avoid redundant documentation that merely restates the member name (e.g., "Gets or sets the X. The X.")
- Provide context about when to use the member and any important behavioral notes
- Document edge cases, special return values (null, empty collections), and validation rules
- Use `<see cref="Type"/>` and `<paramref name="param"/>` for cross-references
- For record types, document parameters in the type's summary using `<param>` tags

**Examples of Good Documentation:**

```csharp
/// <summary>
/// Converts a string to an integer, returning null if the conversion fails.
/// </summary>
/// <param name="value">The string value to parse.</param>
/// <returns>The parsed integer, or <see langword="null"/> if parsing fails.</returns>
public static int? TryParseToInt(string value)

/// <summary>
/// Validates that a string value meets specified criteria including minimum/maximum length,
/// allowed/disallowed characters, and optional regex pattern matching.
/// </summary>
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
public sealed class StringAttribute : ValidationAttribute

/// <summary>
/// Represents the result of a single health check execution.
/// </summary>
/// <param name="Name">The name of the health check.</param>
/// <param name="Status">The status of the health check (Healthy, Degraded, or Unhealthy).</param>
/// <param name="Duration">The time taken to execute the health check.</param>
public sealed record HealthCheck(
    string Name,
    HealthStatus Status,
    TimeSpan Duration)
```

**Maintaining Documentation Quality:**
- When adding new public members, always include comprehensive XML documentation
- When modifying existing APIs, update documentation to reflect changes
- Run `dotnet build` to catch missing documentation warnings (CS1591)
- Use IDE tools (IntelliSense) to verify documentation appears correctly
- Each project's README.md file provides library-specific documentation and usage examples

## Important Conventions

### Multi-Targeting Strategy
- **Atc** library multi-targets `netstandard2.1` and `net9.0` for broad compatibility
- **Atc.CodeAnalysis.CSharp** multi-targets `netstandard2.0` and `net9.0` for Roslyn/source generator compatibility
- All other libraries target `net9.0` only
- When building multi-targeted projects for a specific framework, use the explicit `-f` flag:
  ```bash
  dotnet build -f netstandard2.1 src/Atc/Atc.csproj
  dotnet build -f netstandard2.0 src/Atc.CodeAnalysis.CSharp/Atc.CodeAnalysis.CSharp.csproj
  ```

### Testing Philosophy
- Tests use xUnit v3 with Microsoft Testing Platform
- Unit tests are distinguished from integration tests using `[Trait("Category", "Integration")]`
- CI/CD pipelines exclude integration tests: `--filter "Category!=Integration"`
- Tests leverage AutoFixture for data-driven scenarios

### Documentation Standards
**XML Documentation:**
All 399 source files across the 11 projects have comprehensive XML documentation comments. Every public class, method, property, field, and enum value is thoroughly documented following the standards outlined in the "XML Documentation Standards" section under "Code Standards".

**Auto-Generated API Documentation:**
The repository auto-generates API documentation in `docs/CodeDoc/` using Atc.CodeDocumentation. These markdown files are generated from XML documentation comments and are checked into source control, updated as part of the build process.

**Project README Files:**
Each library in `src/` has a comprehensive README.md file that includes:
- Project description and purpose
- "Why Use This Library?" section highlighting key benefits
- Installation instructions with NuGet package information
- Target framework details
- Key features overview
- Dependencies list
- Usage examples and code snippets
- Links to contributing guidelines

These README files serve as the primary entry point for developers learning about each library.

### Resource Localization
The Atc library includes localized resources (.resx files) for multiple languages:
- English (default)
- Danish (da-DK)
- German (de-DE)
Resource files use PublicResXFileCodeGenerator for code generation.

## CI/CD Workflows

### Pre-Integration (Pull Requests)
- Runs on ubuntu-latest, macos-latest, windows-latest
- Clean, restore, build (Release + netstandard2.1)
- Run unit tests (excluding integration tests)

### Post-Integration (main branch)
- Build and test on ubuntu-latest
- Merge to stable branch with fast-forward only
- Generate pre-release NuGet packages
- Push to GitHub Package Registry
- Uses Nerdbank.GitVersioning (version.json) for semantic versioning

### Release Workflow
- Triggered on release branch
- Creates official NuGet packages
- Publishes to nuget.org

## Common Development Tasks

### Adding a New Library
1. Create project in `src/` following naming: `Atc.{Domain}`
2. Add corresponding test project in `test/` as `Atc.{Domain}.Tests`
3. Update `Atc.slnx` to include new projects
4. Add project reference to dependent libraries
5. Include package metadata (PackageId, PackageTags, Description) in .csproj
6. Create comprehensive README.md with installation, usage examples, and key features
7. Ensure all public members have XML documentation comments following the documentation standards
8. Update post-integration.yml and release.yml to include in NuGet push steps

### Running Single Test
```bash
# Run specific test method
dotnet test --filter "FullyQualifiedName~Namespace.ClassName.MethodName"

# Run all tests in a class
dotnet test --filter "FullyQualifiedName~Namespace.ClassName"
```

### Updating Code Documentation
After making changes to public APIs, regenerate documentation:
```bash
# This is typically done by the Atc.CodeDocumentation tool
# Run from repository root
dotnet run --project src/Atc.CodeDocumentation -- generate
```

## Key Files

- **Directory.Build.props** (root): Shared MSBuild properties for all source projects
- **test/Directory.Build.props**: Test-specific properties (imports root props)
- **Atc.slnx**: Solution file in XML format (Visual Studio 2022+)
- **version.json**: Nerdbank.GitVersioning configuration for semantic versioning
- **.editorconfig**: ATC Coding Rules style enforcement
- **global.json**: SDK version constraints (rollForward: latestMajor)

## Additional Notes

- The repository recently upgraded from .NET 8 to .NET 9
- Tests use xUnit v3 with Microsoft Testing Platform runner
- The main branch is the primary development branch; stable branch is for verified releases
- Analyzer warnings are strictly enforced in Release builds
- All 399 source files have been comprehensively documented with XML documentation comments, replacing legacy GhostDoc-generated documentation with high-quality, meaningful descriptions
