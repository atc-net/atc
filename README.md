[![NuGet Version](https://img.shields.io/nuget/v/atc.svg?logo=nuget&style=for-the-badge)](https://www.nuget.org/packages/atc)

# ATC.Net

This repository contains common libraries for .NET. Detailed information for each repository can be found below.

## Packages

### Core Libraries

#### [Atc](src/Atc) [![Nuget](https://img.shields.io/nuget/dt/Atc?logo=nuget&style=flat-square)](https://www.nuget.org/packages/Atc)

**Target Frameworks:** `netstandard2.0`, `netstandard2.1`, `net9.0`

The foundation library providing common utilities, extensions, and helpers for .NET development. Includes extensive extension methods for base types (String, DateTime, Enum, etc.), data structures, serialization, and more.

[**📖 Read more**](src/Atc/README.md) | [API Documentation](docs/CodeDoc/Atc/Index.md)

---

### REST API Development

#### [Atc.Rest](src/Atc.Rest) [![Nuget](https://img.shields.io/nuget/dt/Atc.Rest?logo=nuget&style=flat-square)](https://www.nuget.org/packages/Atc.Rest)

**Target Framework:** `net9.0`

Foundation for ASP.NET Core WebApi development with middleware, filters, exception handling, and service registration. Simplifies base setup with features like auto-registration, problem details, and serialization configuration.

[**📖 Read more**](src/Atc.Rest/README.md) | [API Documentation](docs/CodeDoc/Atc.Rest/Index.md)

#### [Atc.Rest.Extended](src/Atc.Rest.Extended) [![Nuget](https://img.shields.io/nuget/dt/Atc.Rest.Extended?logo=nuget&style=flat-square)](https://www.nuget.org/packages/Atc.Rest.Extended)

**Target Framework:** `net9.0`

Advanced REST features including Swagger/OpenAPI documentation, FluentValidation, API versioning, and JWT authentication. Builds on Atc.Rest for production-ready APIs.

[**📖 Read more**](src/Atc.Rest.Extended/README.md) | [API Documentation](docs/CodeDoc/Atc.Rest.Extended/Index.md)

#### [Atc.Rest.HealthChecks](src/Atc.Rest.HealthChecks) [![Nuget](https://img.shields.io/nuget/dt/Atc.Rest.HealthChecks?logo=nuget&style=flat-square)](https://www.nuget.org/packages/Atc.Rest.HealthChecks)

**Target Framework:** `net9.0`

Health check implementations and extensions for ASP.NET Core applications, providing monitoring and diagnostics capabilities.

[**📖 Read more**](src/Atc.Rest.HealthChecks/README.md) | [API Documentation](docs/CodeDoc/Atc.Rest.HealthChecks/Index.md)

---

### Code Generation & Analysis

#### [Atc.CodeAnalysis.CSharp](src/Atc.CodeAnalysis.CSharp) [![Nuget](https://img.shields.io/nuget/dt/Atc.CodeAnalysis.CSharp?logo=nuget&style=flat-square)](https://www.nuget.org/packages/Atc.CodeAnalysis.CSharp)

**Target Frameworks:** `netstandard2.0`, `net9.0`

Roslyn-based utilities for working with C# syntax trees and semantic models. Includes factories for generating syntax nodes, attributes, class declarations, and more programmatically.

[**📖 Read more**](src/Atc.CodeAnalysis.CSharp/README.md) | [API Documentation](docs/CodeDoc/Atc.CodeAnalysis.CSharp/Index.md)

#### [Atc.CodeDocumentation](src/Atc.CodeDocumentation) [![Nuget](https://img.shields.io/nuget/dt/Atc.CodeDocumentation?logo=nuget&style=flat-square)](https://www.nuget.org/packages/Atc.CodeDocumentation)

**Target Framework:** `net9.0`

Markdown documentation generator from XML documentation comments and source code. Automatically generates comprehensive API documentation from your codebase.

[**📖 Read more**](src/Atc.CodeDocumentation/README.md) | [API Documentation](docs/CodeDoc/Atc.CodeDocumentation/Index.md)

#### [Atc.OpenApi](src/Atc.OpenApi) [![Nuget](https://img.shields.io/nuget/dt/Atc.OpenApi?logo=nuget&style=flat-square)](https://www.nuget.org/packages/Atc.OpenApi)

**Target Framework:** `net9.0`

Extensions for Microsoft.OpenApi library, including schema extensions, data type handling, and utilities for working with OpenAPI specifications.

[**📖 Read more**](src/Atc.OpenApi/README.md) | [API Documentation](docs/CodeDoc/Atc.OpenApi/Index.md)

---

### Developer Tools

#### [Atc.Console.Spectre](src/Atc.Console.Spectre) [![Nuget](https://img.shields.io/nuget/dt/Atc.Console.Spectre?logo=nuget&style=flat-square)](https://www.nuget.org/packages/Atc.Console.Spectre)

**Target Framework:** `net9.0`

Wrappers and extensions for Spectre.Console to simplify building beautiful command-line applications with rich terminal UI.

[**📖 Read more**](src/Atc.Console.Spectre/README.md) | [API Documentation](docs/CodeDoc/Atc.Console.Spectre/Index.md)

#### [Atc.DotNet](src/Atc.DotNet) [![Nuget](https://img.shields.io/nuget/dt/Atc.DotNet?logo=nuget&style=flat-square)](https://www.nuget.org/packages/Atc.DotNet)

**Target Framework:** `net9.0`

Programmatic interface to dotnet.exe for build automation and tooling. Execute dotnet commands, parse project files, and manage .NET solutions programmatically.

[**📖 Read more**](src/Atc.DotNet/README.md) | [API Documentation](docs/CodeDoc/Atc.DotNet/Index.md)

---

### Testing

#### [Atc.XUnit](src/Atc.XUnit) [![Nuget](https://img.shields.io/nuget/dt/Atc.XUnit?logo=nuget&style=flat-square)](https://www.nuget.org/packages/Atc.XUnit)

**Target Framework:** `net9.0`

Testing utilities and code compliance helpers for xUnit tests. Includes methods for ensuring documentation coverage, test coverage, and custom test output helpers.

[**📖 Read more**](src/Atc.XUnit/README.md) | [API Documentation](docs/CodeDoc/Atc.XUnit/Index.md)

#### [Atc.Rest.FluentAssertions](src/Atc.Rest.FluentAssertions) [![Nuget](https://img.shields.io/nuget/dt/Atc.Rest.FluentAssertions?logo=nuget&style=flat-square)](https://www.nuget.org/packages/Atc.Rest.FluentAssertions)

**Target Framework:** `net9.0`

Custom FluentAssertions extensions for testing REST APIs and Atc types, providing expressive and readable test assertions.

[**📖 Read more**](src/Atc.Rest.FluentAssertions/README.md) | [API Documentation](docs/CodeDoc/Atc.Rest.FluentAssertions/Index.md)

## How to contribute

[Contribution Guidelines](https://atc-net.github.io/introduction/about-atc#how-to-contribute)

[Coding Guidelines](https://atc-net.github.io/introduction/about-atc#coding-guidelines)
