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


#### List

```csharp
string List
```
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


## OpenApiMediaTypeExtensions

```csharp
public static class OpenApiMediaTypeExtensions
```

### Static Methods


#### GetSchema

```csharp
OpenApiSchema GetSchema(this IDictionary<string, OpenApiMediaType> content, string contentType = application/json)
```

<br />


## OpenApiOperationExtensions

```csharp
public static class OpenApiOperationExtensions
```

### Static Methods


#### GetModelSchema

```csharp
OpenApiSchema GetModelSchema(this OpenApiOperation openApiOperation)
```
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


#### GetAllFromHeader

```csharp
List<OpenApiParameter> GetAllFromHeader(this IList<OpenApiParameter> parameters)
```
#### GetAllFromQuery

```csharp
List<OpenApiParameter> GetAllFromQuery(this IList<OpenApiParameter> parameters)
```
#### GetAllFromRoute

```csharp
List<OpenApiParameter> GetAllFromRoute(this IList<OpenApiParameter> parameters)
```
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
#### HasFormatTypeOfInt32

```csharp
bool HasFormatTypeOfInt32(this IList<OpenApiParameter> parameters)
```
#### HasFormatTypeOfInt64

```csharp
bool HasFormatTypeOfInt64(this IList<OpenApiParameter> parameters)
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
List<KeyValuePair<string, OpenApiPathItem>> GetPathsStartingWithSegmentName(this OpenApiPaths urlPaths, string segmentName)
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
OpenApiSchema GetSchemaForStatusCode(this OpenApiResponses responses, HttpStatusCode httpStatusCode, string contentType = application/json)
```
#### HasSchemaTypeOfArray

```csharp
bool HasSchemaTypeOfArray(this OpenApiResponses responses)
```
#### HasSchemaTypeOfHttpStatusCodeUsingAspNetCoreHttp

```csharp
bool HasSchemaTypeOfHttpStatusCodeUsingAspNetCoreHttp(this OpenApiResponses responses)
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
string GetModelName(this OpenApiSchema schema, bool ensureFirstCharacterToUpper = True)
```
#### GetModelType

```csharp
string GetModelType(this OpenApiSchema schema)
```
#### GetTitleFromPropertyByPropertyKey

```csharp
string GetTitleFromPropertyByPropertyKey(this OpenApiSchema schema, string propertyKey)
```
#### HasAnyProperties

```csharp
bool HasAnyProperties(this OpenApiSchema schema)
```
#### HasDataTypeFromSystemCollectionGenericNamespace

```csharp
bool HasDataTypeFromSystemCollectionGenericNamespace(this OpenApiSchema schema)
```
#### HasDataTypeFromSystemCollectionGenericNamespace

```csharp
bool HasDataTypeFromSystemCollectionGenericNamespace(this IList<OpenApiSchema> schemas)
```
#### HasDataTypeOfList

```csharp
bool HasDataTypeOfList(this IList<OpenApiSchema> schemas)
```
#### HasFormatType

```csharp
bool HasFormatType(this OpenApiSchema schema)
```
#### HasFormatTypeFromDataAnnotationsNamespace

```csharp
bool HasFormatTypeFromDataAnnotationsNamespace(this OpenApiSchema schema)
```
#### HasFormatTypeFromDataAnnotationsNamespace

```csharp
bool HasFormatTypeFromDataAnnotationsNamespace(this IList<OpenApiSchema> schemas)
```
#### HasFormatTypeFromSystemNamespace

```csharp
bool HasFormatTypeFromSystemNamespace(this OpenApiSchema schema)
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
#### IsArrayReferenceTypeDeclared

```csharp
bool IsArrayReferenceTypeDeclared(this OpenApiSchema schema)
```
#### IsDataTypeOfList

```csharp
bool IsDataTypeOfList(this OpenApiSchema schema)
```
#### IsFormatTypeOfByte

```csharp
bool IsFormatTypeOfByte(this OpenApiSchema schema)
```
#### IsFormatTypeOfDate

```csharp
bool IsFormatTypeOfDate(this OpenApiSchema schema)
```
#### IsFormatTypeOfDateTime

```csharp
bool IsFormatTypeOfDateTime(this OpenApiSchema schema)
```
#### IsFormatTypeOfEmail

```csharp
bool IsFormatTypeOfEmail(this OpenApiSchema schema)
```
#### IsFormatTypeOfInt32

```csharp
bool IsFormatTypeOfInt32(this OpenApiSchema schema)
```
#### IsFormatTypeOfInt64

```csharp
bool IsFormatTypeOfInt64(this OpenApiSchema schema)
```
#### IsFormatTypeOfTime

```csharp
bool IsFormatTypeOfTime(this OpenApiSchema schema)
```
#### IsFormatTypeOfTimestamp

```csharp
bool IsFormatTypeOfTimestamp(this OpenApiSchema schema)
```
#### IsFormatTypeOfUri

```csharp
bool IsFormatTypeOfUri(this OpenApiSchema schema)
```
#### IsFormatTypeOfUuid

```csharp
bool IsFormatTypeOfUuid(this OpenApiSchema schema)
```
#### IsItemsOfSimpleDataType

```csharp
bool IsItemsOfSimpleDataType(this OpenApiSchema schema)
```
#### IsObjectReferenceTypeDeclared

```csharp
bool IsObjectReferenceTypeDeclared(this OpenApiSchema schema)
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
