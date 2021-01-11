### General Project Info
[![Github top language](https://img.shields.io/github/languages/top/atc-net/atc)](https://github.com/atc-net/atc)
[![Github stars](https://img.shields.io/github/stars/atc-net/atc)](https://github.com/atc-net/atc)
[![Github forks](https://img.shields.io/github/forks/atc-net/atc)](https://github.com/atc-net/atc)
[![Github size](https://img.shields.io/github/repo-size/atc-net/atc)](https://github.com/atc-net/atc)
[![Issues Open](https://img.shields.io/github/issues/atc-net/atc.svg?logo=github)](https://github.com/atc-net/atc/issues)

### Packages
[![Github Version](https://img.shields.io/static/v1?logo=github&color=blue&label=github&message=latest)](https://github.com/orgs/atc-net/packages?repo_name=atc)
[![NuGet Version](https://img.shields.io/nuget/v/atc.svg?logo=nuget)](https://www.nuget.org/profiles/atc-net)

### Build Status
![Build](https://github.com/atc-net/atc/workflows/Pre-Integration/badge.svg)
![Build](https://github.com/atc-net/atc/workflows/Post-Integration/badge.svg)
![Build](https://github.com/atc-net/atc/workflows/Release/badge.svg)

### Code Quality
[![Maintainability Rating](https://sonarcloud.io/api/project_badges/measure?project=atc&metric=sqale_rating)](https://sonarcloud.io/dashboard?id=atc)
[![Reliability Rating](https://sonarcloud.io/api/project_badges/measure?project=atc&metric=reliability_rating)](https://sonarcloud.io/dashboard?id=atc)
[![Security Rating](https://sonarcloud.io/api/project_badges/measure?project=atc&metric=security_rating)](https://sonarcloud.io/dashboard?id=atc)
[![Bugs](https://sonarcloud.io/api/project_badges/measure?project=atc&metric=bugs)](https://sonarcloud.io/dashboard?id=atc)
[![Vulnerabilities](https://sonarcloud.io/api/project_badges/measure?project=atc&metric=vulnerabilities)](https://sonarcloud.io/dashboard?id=atc)

# ATC.Net

## Projects in the repository

|Project|Target Framework|Description|Docs|Nuget Download Link|
|---|---|---|---|---|
|[Atc](src/Atc)|netstandard2.1|Atc is a collection of classes and extension methods for common functionality.|[References](docs/CodeDoc/Atc/Index.md)<br/>[References extended](docs/CodeDoc/Atc/IndexExtended.md)|[![Nuget](https://img.shields.io/nuget/dt/Atc?logo=nuget&style=flat-square)](https://www.nuget.org/packages/Atc)|
|[Atc.CodeAnalysis.CSharp](src/Atc.CodeAnalysis.CSharp)|netstandard2.1|Atc.CodeAnalysis.CSharp is a collection of classes and extension methods for Microsoft.CodeAnalysis.CSharp.|[References](docs/CodeDoc/Atc.CodeAnalysis.CSharp/Index.md)<br/>[References extended](docs/CodeDoc/Atc.CodeAnalysis.CSharp/IndexExtended.md)|[![Nuget](https://img.shields.io/nuget/dt/Atc.CodeAnalysis.CSharp?logo=nuget&style=flat-square)](https://www.nuget.org/packages/Atc.CodeAnalysis.CSharp)|
|[Atc.CodeDocumentation](src/Atc.CodeDocumentation)|netstandard2.1|Atc.CodeDocumentation is a markdown generator for source code.|[References](docs/CodeDoc/Atc.CodeDocumentation/Index.md)<br/>[References extended](docs/CodeDoc/Atc.CodeDocumentation/IndexExtended.md)|[![Nuget](https://img.shields.io/nuget/dt/Atc.CodeDocumentation?logo=nuget&style=flat-square)](https://www.nuget.org/packages/Atc.CodeDocumentation)|
|[Atc.OpenApi](src/Atc.OpenApi)|netstandard2.1|Atc.OpenApi is a collection of classes and extension methods for Microsoft.OpenApi.|[References](docs/CodeDoc/Atc.OpenApi/Index.md)<br/>[References extended](docs/CodeDoc/Atc.OpenApi/IndexExtended.md)|[![Nuget](https://img.shields.io/nuget/dt/Atc.OpenApi?logo=nuget&style=flat-square)](https://www.nuget.org/packages/Atc.OpenApi)|
|[Atc.Rest](src/Atc.Rest)|netcoreapp3.1|Atc.Rest is a basic collection of classes and extension methods for ASP.NET Core WebApi.|[References](docs/CodeDoc/Atc.Rest/Index.md)<br/>[References extended](docs/CodeDoc/Atc.Rest/IndexExtended.md)|[![Nuget](https://img.shields.io/nuget/dt/Atc.Rest?logo=nuget&style=flat-square)](https://www.nuget.org/packages/Atc.Rest)|
|[Atc.Rest.Extended](src/Atc.Rest.Extended)|netcoreapp3.1|Atc.Rest.Extended is a collection of classes and extension methods for Atc.Rest, that contains SwaggerUI, FluentValidation Versioning etc.|[References](docs/CodeDoc/Atc.Rest.Extended/Index.md)<br/>[References extended](docs/CodeDoc/Atc.Rest.Extended/IndexExtended.md)|[![Nuget](https://img.shields.io/nuget/dt/Atc.Rest.Extended?logo=nuget&style=flat-square)](https://www.nuget.org/packages/Atc.Rest.Extended)|
|[Atc.Rest.FluentAssertions](src/Atc.Rest.FluentAssertions)|netcoreapp3.1|Atc.Rest.FluentAssertions is a collection of assertion helpers for writing tests of Atc types.|[References](docs/CodeDoc/Atc.Rest.FluentAssertions/Index.md)<br/>[References extended](docs/CodeDoc/Atc.Rest.FluentAssertions/IndexExtended.md)|[![Nuget](https://img.shields.io/nuget/dt/Atc.Rest.FluentAssertions?logo=nuget&style=flat-square)](https://www.nuget.org/packages/Atc.Rest.FluentAssertions)|
|[Atc.XUnit](src/Atc.XUnit)|netstandard2.1|Atc.XUnit is a collection of helper method for code compliance of documentation and tests.|[References](docs/CodeDoc/Atc.XUnit/Index.md)<br/>[References extended](docs/CodeDoc/Atc.XUnit/IndexExtended.md)|[![Nuget](https://img.shields.io/nuget/dt/Atc.XUnit?logo=nuget&style=flat-square)](https://www.nuget.org/packages/Atc.XUnit)|

## CLI Tools

REST API generator, please go to [Atc.Rest.ApiGenerator.CLI](https://github.com/atc-net/atc-rest-api-generator/src/Atc.Rest.ApiGenerator.CLI)

# The workflow setup for this repository
[Read more on Git-Flow](docs/GitFlow.md)

# Contributing

Please refer to each project's style and contribution guidelines for submitting patches and additions. In general, we follow the "fork-and-pull" Git workflow. [Read more here](https://gist.github.com/Chaser324/ce0505fbed06b947d962).

 1. **Fork** the repo on GitHub
 2. **Clone** the project to your own machine
 3. **Commit** changes to your own branch
 4. **Push** your work back up to your fork
 5. Submit a **Pull request** so that we can review your changes

NOTE: Be sure to merge the latest from "upstream" before making a pull request!

# Coding Guidelines

This repository is adapting the [ATC-Coding-Rules](https://github.com/atc-net/atc-coding-rules) which is defined and based on .editorconfig's and a range of Roslyn Analyzers.
