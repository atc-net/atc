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


#### Binary

```csharp
string Binary
```
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
#### Double

```csharp
string Double
```
#### Email

```csharp
string Email
```
#### Float

```csharp
string Float
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
#### GetSchemaByFirstMediaType

```csharp
OpenApiSchema GetSchemaByFirstMediaType(this IDictionary<string, OpenApiMediaType> content)
```

<br />


## OpenApiOperationExtensions

```csharp
public static class OpenApiOperationExtensions
```

### Static Methods


#### GetModelSchemaFromRequest

```csharp
OpenApiSchema GetModelSchemaFromRequest(this OpenApiOperation openApiOperation)
```
#### GetModelSchemaFromResponse

```csharp
OpenApiSchema GetModelSchemaFromResponse(this OpenApiOperation openApiOperation)
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
#### HasRequestBodyWithAnythingAsFormatTypeBinary

```csharp
bool HasRequestBodyWithAnythingAsFormatTypeBinary(this OpenApiOperation openApiOperation)
```
#### IsOperationIdPluralized

```csharp
bool IsOperationIdPluralized(this OpenApiOperation openApiOperation, OperationType operationType)
```
#### IsOperationNamePluralized

```csharp
bool IsOperationNamePluralized(this OpenApiOperation openApiOperation, OperationType operationType)
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
#### HasFormatTypeByte

```csharp
bool HasFormatTypeByte(this IList<OpenApiParameter> parameters)
```
#### HasFormatTypeDate

```csharp
bool HasFormatTypeDate(this IList<OpenApiParameter> parameters)
```
#### HasFormatTypeDateTime

```csharp
bool HasFormatTypeDateTime(this IList<OpenApiParameter> parameters)
```
#### HasFormatTypeEmail

```csharp
bool HasFormatTypeEmail(this IList<OpenApiParameter> parameters)
```
#### HasFormatTypeFromDataAnnotationsNamespace

```csharp
bool HasFormatTypeFromDataAnnotationsNamespace(this IList<OpenApiParameter> parameters)
```
#### HasFormatTypeFromSystemNamespace

```csharp
bool HasFormatTypeFromSystemNamespace(this IList<OpenApiParameter> parameters)
```
#### HasFormatTypeInt32

```csharp
bool HasFormatTypeInt32(this IList<OpenApiParameter> parameters)
```
#### HasFormatTypeInt64

```csharp
bool HasFormatTypeInt64(this IList<OpenApiParameter> parameters)
```
#### HasFormatTypeTime

```csharp
bool HasFormatTypeTime(this IList<OpenApiParameter> parameters)
```
#### HasFormatTypeTimestamp

```csharp
bool HasFormatTypeTimestamp(this IList<OpenApiParameter> parameters)
```
#### HasFormatTypeUri

```csharp
bool HasFormatTypeUri(this IList<OpenApiParameter> parameters)
```
#### HasFormatTypeUuid

```csharp
bool HasFormatTypeUuid(this IList<OpenApiParameter> parameters)
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


#### GetDataTypeForStatusCode

```csharp
string GetDataTypeForStatusCode(this OpenApiResponses responses, HttpStatusCode httpStatusCode)
```
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
#### HasSchemaHttpStatusCodeUsingAspNetCoreHttp

```csharp
bool HasSchemaHttpStatusCodeUsingAspNetCoreHttp(this OpenApiResponses responses)
```
#### HasSchemaHttpStatusCodeUsingSystemNet

```csharp
bool HasSchemaHttpStatusCodeUsingSystemNet(this OpenApiResponses responses)
```
#### HasSchemaTypeArray

```csharp
bool HasSchemaTypeArray(this OpenApiResponses responses)
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
#### IsSchemaUsingBinaryFormatForOkResponse

```csharp
bool IsSchemaUsingBinaryFormatForOkResponse(this OpenApiResponses responses)
```

<br />


## OpenApiSchemaExtensions

```csharp
public static class OpenApiSchemaExtensions
```

### Static Methods


#### ExtractPropertyNameWhenHasAnyPropertiesOfArrayWithFormatTypeBinary

```csharp
string ExtractPropertyNameWhenHasAnyPropertiesOfArrayWithFormatTypeBinary(this OpenApiSchema apiSchema)
```
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
#### GetSchemaByModelName

```csharp
OpenApiSchema GetSchemaByModelName(this IDictionary<string, OpenApiSchema> componentSchemas, string modelName)
```
#### GetTitleFromPropertyByPropertyKey

```csharp
string GetTitleFromPropertyByPropertyKey(this OpenApiSchema schema, string propertyKey)
```
#### HasAnyProperties

```csharp
bool HasAnyProperties(this OpenApiSchema schema)
```
#### HasAnyPropertiesAsArrayWithFormatTypeBinary

```csharp
bool HasAnyPropertiesAsArrayWithFormatTypeBinary(this OpenApiSchema schema)
```
#### HasAnyPropertiesFormatTypeFromSystemCollectionGenericNamespace

```csharp
bool HasAnyPropertiesFormatTypeFromSystemCollectionGenericNamespace(this OpenApiSchema schema, IDictionary<string, OpenApiSchema> componentSchemas)
```
#### HasAnyPropertiesFormatTypeFromSystemNamespace

```csharp
bool HasAnyPropertiesFormatTypeFromSystemNamespace(this OpenApiSchema schema)
```
#### HasAnyPropertiesFormatTypeFromSystemNamespace

```csharp
bool HasAnyPropertiesFormatTypeFromSystemNamespace(this OpenApiSchema schema, IDictionary<string, OpenApiSchema> componentSchemas)
```
#### HasAnyPropertiesWithFormatTypeBinary

```csharp
bool HasAnyPropertiesWithFormatTypeBinary(this OpenApiSchema schema)
```
#### HasAnythingAsFormatTypeBinary

```csharp
bool HasAnythingAsFormatTypeBinary(this OpenApiSchema schema)
```
#### HasDataTypeFromSystemCollectionGenericNamespace

```csharp
bool HasDataTypeFromSystemCollectionGenericNamespace(this OpenApiSchema schema)
```
#### HasDataTypeFromSystemCollectionGenericNamespace

```csharp
bool HasDataTypeFromSystemCollectionGenericNamespace(this IList<OpenApiSchema> schemas)
```
#### HasDataTypeList

```csharp
bool HasDataTypeList(this IList<OpenApiSchema> schemas)
```
#### HasFormatType

```csharp
bool HasFormatType(this OpenApiSchema schema)
```
#### HasFormatTypeByte

```csharp
bool HasFormatTypeByte(this IList<OpenApiSchema> schemas)
```
#### HasFormatTypeDate

```csharp
bool HasFormatTypeDate(this IList<OpenApiSchema> schemas)
```
#### HasFormatTypeDateTime

```csharp
bool HasFormatTypeDateTime(this IList<OpenApiSchema> schemas)
```
#### HasFormatTypeEmail

```csharp
bool HasFormatTypeEmail(this IList<OpenApiSchema> schemas)
```
#### HasFormatTypeFromAspNetCoreHttpNamespace

```csharp
bool HasFormatTypeFromAspNetCoreHttpNamespace(this OpenApiSchema schema)
```
#### HasFormatTypeFromAspNetCoreHttpNamespace

```csharp
bool HasFormatTypeFromAspNetCoreHttpNamespace(this IList<OpenApiSchema> schemas)
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
#### HasFormatTypeInt32

```csharp
bool HasFormatTypeInt32(this IList<OpenApiSchema> schemas)
```
#### HasFormatTypeInt64

```csharp
bool HasFormatTypeInt64(this IList<OpenApiSchema> schemas)
```
#### HasFormatTypeTime

```csharp
bool HasFormatTypeTime(this IList<OpenApiSchema> schemas)
```
#### HasFormatTypeTimestamp

```csharp
bool HasFormatTypeTimestamp(this IList<OpenApiSchema> schemas)
```
#### HasFormatTypeUri

```csharp
bool HasFormatTypeUri(this IList<OpenApiSchema> schemas)
```
#### HasFormatTypeUuid

```csharp
bool HasFormatTypeUuid(this IList<OpenApiSchema> schemas)
```
#### HasItemsWithFormatTypeBinary

```csharp
bool HasItemsWithFormatTypeBinary(this OpenApiSchema schema)
```
#### HasItemsWithSimpleDataType

```csharp
bool HasItemsWithSimpleDataType(this OpenApiSchema schema)
```
#### HasModelNameOrAnyPropertiesWithModelName

```csharp
bool HasModelNameOrAnyPropertiesWithModelName(this OpenApiSchema schema, string modelName)
```
#### IsArrayReferenceTypeDeclared

```csharp
bool IsArrayReferenceTypeDeclared(this OpenApiSchema schema)
```
#### IsFormatTypeBinary

```csharp
bool IsFormatTypeBinary(this OpenApiSchema schema)
```
#### IsFormatTypeByte

```csharp
bool IsFormatTypeByte(this OpenApiSchema schema)
```
#### IsFormatTypeDate

```csharp
bool IsFormatTypeDate(this OpenApiSchema schema)
```
#### IsFormatTypeDateTime

```csharp
bool IsFormatTypeDateTime(this OpenApiSchema schema)
```
#### IsFormatTypeEmail

```csharp
bool IsFormatTypeEmail(this OpenApiSchema schema)
```
#### IsFormatTypeInt32

```csharp
bool IsFormatTypeInt32(this OpenApiSchema schema)
```
#### IsFormatTypeInt64

```csharp
bool IsFormatTypeInt64(this OpenApiSchema schema)
```
#### IsFormatTypeTime

```csharp
bool IsFormatTypeTime(this OpenApiSchema schema)
```
#### IsFormatTypeTimestamp

```csharp
bool IsFormatTypeTimestamp(this OpenApiSchema schema)
```
#### IsFormatTypeUri

```csharp
bool IsFormatTypeUri(this OpenApiSchema schema)
```
#### IsFormatTypeUuid

```csharp
bool IsFormatTypeUuid(this OpenApiSchema schema)
```
#### IsObjectReferenceTypeDeclared

```csharp
bool IsObjectReferenceTypeDeclared(this OpenApiSchema schema)
```
#### IsRuleValidationNumber

```csharp
bool IsRuleValidationNumber(this OpenApiSchema schema)
```
#### IsRuleValidationString

```csharp
bool IsRuleValidationString(this OpenApiSchema schema)
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
#### IsTypeArray

```csharp
bool IsTypeArray(this OpenApiSchema schema)
```
<hr /><div style='text-align: right'><i>Generated by MarkdownCodeDoc version 1.2</i></div>
