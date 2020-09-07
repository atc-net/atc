<div style='text-align: right'>

[References](Index.md)&nbsp;&nbsp;-&nbsp;&nbsp;[References extended](IndexExtended.md)
</div>

# Microsoft.OpenApi.Models

<br />


## NameConstants

```csharp
public static class NameConstants
```

### Static Fields


#### Pagination

```csharp
string Pagination
```

<br />


## OpenApiDataTypeConstants

```csharp
public static class OpenApiDataTypeConstants
```

### Static Fields


#### Array

```csharp
string Array
```
#### Boolean

```csharp
string Boolean
```
#### Integer

```csharp
string Integer
```
#### Number

```csharp
string Number
```
#### Object

```csharp
string Object
```
#### String

```csharp
string String
```

<br />


## OpenApiDocumentExtensions

```csharp
public static class OpenApiDocumentExtensions
```

### Static Methods


#### GetPathsByBasePathSegmentName

```csharp
List<KeyValuePair<string, OpenApiPathItem>> GetPathsByBasePathSegmentName(this OpenApiDocument document, string basePathSegmentName)
```

<br />


## OpenApiFormatTypeConstants

```csharp
public static class OpenApiFormatTypeConstants
```

### Static Fields


#### Byte

```csharp
string Byte
```
#### Date

```csharp
string Date
```
#### DateTime

```csharp
string DateTime
```
#### Email

```csharp
string Email
```
#### Int32

```csharp
string Int32
```
#### Int64

```csharp
string Int64
```
#### Time

```csharp
string Time
```
#### Timestamp

```csharp
string Timestamp
```
#### Uri

```csharp
string Uri
```
#### Uuid

```csharp
string Uuid
```

<br />


## OpenApiOperationExtensions

```csharp
public static class OpenApiOperationExtensions
```

### Static Methods


#### GetOperationName

```csharp
string GetOperationName(this OpenApiOperation openApiOperation)
```
#### HasDataTypeFromSystemCollectionGenericNamespace

```csharp
bool HasDataTypeFromSystemCollectionGenericNamespace(this List<OpenApiOperation> apiOperations)
```
#### HasParametersOrRequestBody

```csharp
bool HasParametersOrRequestBody(this OpenApiOperation openApiOperation)
```
#### IsOperationReferencingSchema

```csharp
bool IsOperationReferencingSchema(this OpenApiOperation openApiOperation, string schemaKey)
```

<br />


## OpenApiParameterExtensions

```csharp
public static class OpenApiParameterExtensions
```

### Static Methods


#### HasFormatTypeFromDataAnnotationsNamespace

```csharp
bool HasFormatTypeFromDataAnnotationsNamespace(this IList<OpenApiParameter> parameters)
```
#### HasFormatTypeFromSystemNamespace

```csharp
bool HasFormatTypeFromSystemNamespace(this IList<OpenApiParameter> parameters)
```
#### HasFormatTypeOfByte

```csharp
bool HasFormatTypeOfByte(this IList<OpenApiParameter> parameters)
```
#### HasFormatTypeOfDate

```csharp
bool HasFormatTypeOfDate(this IList<OpenApiParameter> parameters)
```
#### HasFormatTypeOfDateTime

```csharp
bool HasFormatTypeOfDateTime(this IList<OpenApiParameter> parameters)
```
#### HasFormatTypeOfEmail

```csharp
bool HasFormatTypeOfEmail(this IList<OpenApiParameter> parameters)
```
#### HasFormatTypeOfTime

```csharp
bool HasFormatTypeOfTime(this IList<OpenApiParameter> parameters)
```
#### HasFormatTypeOfTimestamp

```csharp
bool HasFormatTypeOfTimestamp(this IList<OpenApiParameter> parameters)
```
#### HasFormatTypeOfUri

```csharp
bool HasFormatTypeOfUri(this IList<OpenApiParameter> parameters)
```
#### HasFormatTypeOfUuid

```csharp
bool HasFormatTypeOfUuid(this IList<OpenApiParameter> parameters)
```

<br />


## OpenApiPathItemExtensions

```csharp
public static class OpenApiPathItemExtensions
```

### Static Methods


#### HasParameters

```csharp
bool HasParameters(this OpenApiPathItem openApiOperation)
```
#### IsPathStartingSegmentName

```csharp
bool IsPathStartingSegmentName(this KeyValuePair<string, OpenApiPathItem> urlPath, string segmentName)
```

<br />


## OpenApiPathsExtensions

```csharp
public static class OpenApiPathsExtensions
```

### Static Methods


#### GetPathsStartingWithSegmentName

```csharp
List<KeyValuePair<string, OpenApiPathItem>> GetPathsStartingWithSegmentName(this OpenApiPaths paths, string segmentName)
```

<br />


## OpenApiResponsesExtensions

```csharp
public static class OpenApiResponsesExtensions
```

### Static Methods


#### GetHttpStatusCodes

```csharp
List<HttpStatusCode> GetHttpStatusCodes(this OpenApiResponses responses)
```
#### GetModelNameForStatusCode

```csharp
string GetModelNameForStatusCode(this OpenApiResponses responses, HttpStatusCode httpStatusCode)
```
#### GetSchemaForStatusCode

```csharp
OpenApiSchema GetSchemaForStatusCode(this OpenApiResponses responses, HttpStatusCode httpStatusCode)
```
#### HasSchemaTypeOfArray

```csharp
bool HasSchemaTypeOfArray(this OpenApiResponses responses)
```
#### HasSchemaTypeOfHttpStatusCodeUsingSystemNet

```csharp
bool HasSchemaTypeOfHttpStatusCodeUsingSystemNet(this OpenApiResponses responses)
```
#### IsSchemaTypeArrayForStatusCode

```csharp
bool IsSchemaTypeArrayForStatusCode(this OpenApiResponses responses, HttpStatusCode httpStatusCode)
```
#### IsSchemaTypePaginationForStatusCode

```csharp
bool IsSchemaTypePaginationForStatusCode(this OpenApiResponses responses, HttpStatusCode httpStatusCode)
```
#### IsSchemaTypeProblemDetailsForStatusCode

```csharp
bool IsSchemaTypeProblemDetailsForStatusCode(this OpenApiResponses responses, HttpStatusCode httpStatusCode)
```

<br />


## OpenApiSchemaExtensions

```csharp
public static class OpenApiSchemaExtensions
```

### Static Methods


#### GetDataType

```csharp
string GetDataType(this OpenApiSchema schema)
```
#### GetEnumSchema

```csharp
Tuple<string, OpenApiSchema> GetEnumSchema(this OpenApiSchema schema)
```
#### GetModelName

```csharp
string GetModelName(this OpenApiSchema schema)
```
#### GetTitleFromPropertyByPropertyKey

```csharp
string GetTitleFromPropertyByPropertyKey(this OpenApiSchema schema, string propertyKey)
```
#### HasDataTypeFromSystemCollectionGenericNamespace

```csharp
bool HasDataTypeFromSystemCollectionGenericNamespace(this IList<OpenApiSchema> schemas)
```
#### HasDataTypeOfList

```csharp
bool HasDataTypeOfList(this IList<OpenApiSchema> schemas)
```
#### HasFormatTypeFromDataAnnotationsNamespace

```csharp
bool HasFormatTypeFromDataAnnotationsNamespace(this IList<OpenApiSchema> schemas)
```
#### HasFormatTypeFromSystemNamespace

```csharp
bool HasFormatTypeFromSystemNamespace(this IList<OpenApiSchema> schemas)
```
#### HasFormatTypeOfByte

```csharp
bool HasFormatTypeOfByte(this IList<OpenApiSchema> schemas)
```
#### HasFormatTypeOfDate

```csharp
bool HasFormatTypeOfDate(this IList<OpenApiSchema> schemas)
```
#### HasFormatTypeOfDateTime

```csharp
bool HasFormatTypeOfDateTime(this IList<OpenApiSchema> schemas)
```
#### HasFormatTypeOfEmail

```csharp
bool HasFormatTypeOfEmail(this IList<OpenApiSchema> schemas)
```
#### HasFormatTypeOfInt32

```csharp
bool HasFormatTypeOfInt32(this IList<OpenApiSchema> schemas)
```
#### HasFormatTypeOfInt64

```csharp
bool HasFormatTypeOfInt64(this IList<OpenApiSchema> schemas)
```
#### HasFormatTypeOfTime

```csharp
bool HasFormatTypeOfTime(this IList<OpenApiSchema> schemas)
```
#### HasFormatTypeOfTimestamp

```csharp
bool HasFormatTypeOfTimestamp(this IList<OpenApiSchema> schemas)
```
#### HasFormatTypeOfUri

```csharp
bool HasFormatTypeOfUri(this IList<OpenApiSchema> schemas)
```
#### HasFormatTypeOfUuid

```csharp
bool HasFormatTypeOfUuid(this IList<OpenApiSchema> schemas)
```
#### IsHttpStatusCodeModelReference

```csharp
bool IsHttpStatusCodeModelReference(this OpenApiSchema schema)
```
#### IsItemsOfSimpleDataType

```csharp
bool IsItemsOfSimpleDataType(this OpenApiSchema schema)
```
#### IsReferenceTypeDeclared

```csharp
bool IsReferenceTypeDeclared(this OpenApiSchema schema)
```
#### IsSchemaEnum

```csharp
bool IsSchemaEnum(this OpenApiSchema schema)
```
#### IsSchemaEnumOrPropertyEnum

```csharp
bool IsSchemaEnumOrPropertyEnum(this OpenApiSchema schema)
```
#### IsSharedContract

```csharp
bool IsSharedContract(this OpenApiSchema schema, OpenApiComponents openApiComponents)
```
#### IsSimpleDataType

```csharp
bool IsSimpleDataType(this OpenApiSchema schema)
```
<hr /><div style='text-align: right'><i>Generated by MarkdownCodeDoc version 1.2</i></div>
