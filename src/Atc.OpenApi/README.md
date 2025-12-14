# Atc.OpenApi

**Target Framework:** `net9.0`, `net10.0`

Extensions and utilities for working with OpenAPI specifications using Microsoft.OpenApi. Provides helper methods for parsing, analyzing, and extracting information from OpenAPI documents and schemas.

## Why Use This Library?

Working with OpenAPI specifications programmatically requires extensive knowledge of the object model and common patterns. Atc.OpenApi simplifies this by providing:

- **OpenAPI Extension Methods**: Convenient extensions for common operations
- **Schema Helpers**: Extract and analyze schema information
- **Data Type Utilities**: Determine data types from OpenAPI schemas
- **Operation Analysis**: Get operation names and response schemas
- **Model Extraction**: Retrieve model schemas from responses
- **Type-Safe Parsing**: Strongly-typed access to OpenAPI components

Perfect for:
- API code generators
- OpenAPI documentation tools
- API client generators
- Schema validation tools
- API specification analyzers
- OpenAPI-first development workflows

## Installation

```bash
dotnet add package Atc.OpenApi
```

## Target Framework

- .NET 9.0

## Key Features

- Extension methods for `OpenApiOperation`
- Extension methods for `OpenApiSchema`
- Schema data type detection and extraction
- Operation name retrieval
- Model schema extraction from responses
- Support for complex schema analysis
- Integration with Microsoft.OpenApi.Readers

## Requirements

- [.NET 9](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)

## Key Dependencies

- Microsoft.OpenApi.Readers
- Atc (foundation library)

## Main Components

### OpenApiOperation Extensions

Work with OpenAPI operations:
- `GetOperationName()`: Extracts operation identifier
- `GetModelSchemaFromResponse()`: Gets the response model schema

### OpenApiSchema Extensions

Analyze OpenAPI schemas:
- `GetDataType()`: Determines the data type of a schema
- Schema property analysis
- Type detection and mapping

## Code documentation

[References](https://github.com/atc-net/atc/blob/main/docs/CodeDoc/Atc.OpenApi/Index.md)

[References extended](https://github.com/atc-net/atc/blob/main/docs/CodeDoc/Atc.OpenApi/IndexExtended.md)

## Usage Examples

### Working with OpenAPI Operations

```csharp
using Atc.OpenApi;
using Microsoft.OpenApi.Models;

// Get operation name
var operationName = openApiOperation.GetOperationName();
Console.WriteLine($"Operation: {operationName}");

// Get model schema from response
var modelSchema = openApiOperation.GetModelSchemaFromResponse();
if (modelSchema != null)
{
    Console.WriteLine($"Response Type: {modelSchema.Type}");
}
```

### Analyzing OpenAPI Schemas

```csharp
using Atc.OpenApi;
using Microsoft.OpenApi.Models;

OpenApiSchema schema = /* your schema */;

// Get data type information
var dataType = schema.GetDataType();
Console.WriteLine($"Data Type: {dataType}");

// Check schema properties
if (schema.Properties != null)
{
    foreach (var property in schema.Properties)
    {
        Console.WriteLine($"Property: {property.Key}, Type: {property.Value.Type}");
    }
}
```

### Reading and Analyzing OpenAPI Documents

```csharp
using Microsoft.OpenApi.Readers;
using Atc.OpenApi;

// Read OpenAPI document
var openApiDocument = new OpenApiStringReader().Read(yamlContent, out var diagnostic);

// Analyze operations
foreach (var path in openApiDocument.Paths)
{
    foreach (var operation in path.Value.Operations)
    {
        var operationName = operation.Value.GetOperationName();
        var responseSchema = operation.Value.GetModelSchemaFromResponse();

        Console.WriteLine($"Path: {path.Key}");
        Console.WriteLine($"Method: {operation.Key}");
        Console.WriteLine($"Operation: {operationName}");
    }
}
```

## Contributing

Contributions are welcome! Please see the main [repository README](../../README.md) for contribution guidelines.
