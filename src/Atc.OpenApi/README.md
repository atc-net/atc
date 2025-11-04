# Atc.OpenApi

**Target Framework:** `net9.0`

This library contains extensions to the Microsoft.OpenApi library.

## Code documentation

[References](https://github.com/atc-net/atc/blob/main/docs/CodeDoc/Atc.OpenApi/Index.md)

[References extended](https://github.com/atc-net/atc/blob/main/docs/CodeDoc/Atc.OpenApi/IndexExtended.md)

## `OpenApiOperation` examples

### Using `GetOperationName()` to get the operation name

```csharp
var operationName = openApiOperation.GetOperationName();
```

### Using `GetModelSchemaFromResponse()` to get the model schema from the response

```csharp
var modelSchema = openApiOperation.GetModelSchemaFromResponse();
```
