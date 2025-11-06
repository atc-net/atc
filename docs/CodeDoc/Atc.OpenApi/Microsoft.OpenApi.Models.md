<div style='text-align: right'>

[References](Index.md)&nbsp;&nbsp;-&nbsp;&nbsp;[References extended](IndexExtended.md)
</div>

# Microsoft.OpenApi.Models

<br />

## NameConstants
Provides constant name values commonly used in OpenAPI specifications.

>```csharp
>public static class NameConstants
>```

### Static Fields

#### List
>```csharp
>string List
>```
><b>Summary:</b> The name used for list/collection schemas in OpenAPI specifications.
#### Pagination
>```csharp
>string Pagination
>```
><b>Summary:</b> The name used for pagination wrapper schemas in OpenAPI specifications.

<br />

## OpenApiDataTypeConstants
Provides constant values for OpenAPI primitive data types as defined in the OpenAPI specification. See: https://swagger.io/docs/specification/data-models/data-types/

>```csharp
>public static class OpenApiDataTypeConstants
>```

### Static Fields

#### Array
>```csharp
>string Array
>```
><b>Summary:</b> Array data type for ordered collections of values.
#### Boolean
>```csharp
>string Boolean
>```
><b>Summary:</b> Boolean data type for true/false values.
#### Integer
>```csharp
>string Integer
>```
><b>Summary:</b> Integer data type for whole numbers.
#### Number
>```csharp
>string Number
>```
><b>Summary:</b> Number data type for numeric values (including decimals).
#### Object
>```csharp
>string Object
>```
><b>Summary:</b> Object data type for structured key-value pairs.
#### String
>```csharp
>string String
>```
><b>Summary:</b> String data type for text values.

<br />

## OpenApiDocumentExtensions
Extension methods for `Microsoft.OpenApi.Models.OpenApiDocument`.

>```csharp
>public static class OpenApiDocumentExtensions
>```

### Static Methods

#### GetPathsByBasePathSegmentName
>```csharp
>List<KeyValuePair<string, OpenApiPathItem>> GetPathsByBasePathSegmentName(this OpenApiDocument document, string basePathSegmentName)
>```
><b>Summary:</b> Retrieves all paths from the `Microsoft.OpenApi.Models.OpenApiDocument` that start with the specified base path segment name. The segment name is normalized to singular form before matching, and results are sorted alphabetically.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`document`&nbsp;&nbsp;-&nbsp;&nbsp;The  to search.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`basePathSegmentName`&nbsp;&nbsp;-&nbsp;&nbsp;The base path segment name to filter paths by.<br />
>
><b>Returns:</b> An ordered list of key-value pairs containing paths that start with the specified segment name.

<br />

## OpenApiFormatTypeConstants
Provides constant values for OpenAPI format types as defined in the OpenAPI specification. These format types provide additional semantic information about data types. See: https://swagger.io/docs/specification/data-models/data-types/

>```csharp
>public static class OpenApiFormatTypeConstants
>```

### Static Fields

#### Binary
>```csharp
>string Binary
>```
><b>Summary:</b> Binary format type for string data (any sequence of octets).
#### Byte
>```csharp
>string Byte
>```
><b>Summary:</b> Byte format type for string data (base64-encoded characters).
#### Date
>```csharp
>string Date
>```
><b>Summary:</b> Date format type for string data (full-date as defined by RFC 3339).
#### DateTime
>```csharp
>string DateTime
>```
><b>Summary:</b> Date-time format type for string data (date-time as defined by RFC 3339).
#### Double
>```csharp
>string Double
>```
><b>Summary:</b> Double format type for number data (double-precision floating point).
#### Email
>```csharp
>string Email
>```
><b>Summary:</b> Email format type for string data (email address).
#### Float
>```csharp
>string Float
>```
><b>Summary:</b> Float format type for number data (single-precision floating point).
#### Int32
>```csharp
>string Int32
>```
><b>Summary:</b> Int32 format type for integer data (signed 32-bit integer).
#### Int64
>```csharp
>string Int64
>```
><b>Summary:</b> Int64 format type for integer data (signed 64-bit integer).
#### Time
>```csharp
>string Time
>```
><b>Summary:</b> Time format type for string data (full-time as defined by RFC 3339).
#### Timestamp
>```csharp
>string Timestamp
>```
><b>Summary:</b> Timestamp format type for string data (legacy format).
#### Uri
>```csharp
>string Uri
>```
><b>Summary:</b> URI format type for string data (Uniform Resource Identifier).
#### Uuid
>```csharp
>string Uuid
>```
><b>Summary:</b> UUID format type for string data (universally unique identifier).

<br />

## OpenApiMediaTypeExtensions
Extension methods for `Microsoft.OpenApi.Models.OpenApiMediaType` dictionaries.

>```csharp
>public static class OpenApiMediaTypeExtensions
>```

### Static Methods

#### GetSchema
>```csharp
>OpenApiSchema GetSchema(this IDictionary<string, OpenApiMediaType> content, string contentType = application/json)
>```
><b>Summary:</b> Retrieves the `Microsoft.OpenApi.Models.OpenApiSchema` from the content dictionary for the specified content type.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`content`&nbsp;&nbsp;-&nbsp;&nbsp;The dictionary of media types and their schemas.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`contentType`&nbsp;&nbsp;-&nbsp;&nbsp;The content type to retrieve the schema for. Defaults to application/json.<br />
>
><b>Returns:</b> The `Microsoft.OpenApi.Models.OpenApiSchema` for the specified content type, or null if not found.
#### GetSchemaByFirstMediaType
>```csharp
>OpenApiSchema GetSchemaByFirstMediaType(this IDictionary<string, OpenApiMediaType> content)
>```
><b>Summary:</b> Retrieves the `Microsoft.OpenApi.Models.OpenApiSchema` from the first media type in the content dictionary.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`content`&nbsp;&nbsp;-&nbsp;&nbsp;The dictionary of media types and their schemas.<br />
>
><b>Returns:</b> The `Microsoft.OpenApi.Models.OpenApiSchema` from the first media type, or null if the dictionary is empty.

<br />

## OpenApiOperationExtensions
Extension methods for `Microsoft.OpenApi.Models.OpenApiOperation`.

>```csharp
>public static class OpenApiOperationExtensions
>```

### Static Methods

#### GetModelSchemaFromRequest
>```csharp
>OpenApiSchema GetModelSchemaFromRequest(this OpenApiOperation openApiOperation)
>```
><b>Summary:</b> Retrieves the model schema from the operation's request body.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`openApiOperation`&nbsp;&nbsp;-&nbsp;&nbsp;The  to extract the schema from.<br />
>
><b>Returns:</b> The `Microsoft.OpenApi.Models.OpenApiSchema` from the request body, or null if not found.
#### GetModelSchemaFromResponse
>```csharp
>OpenApiSchema GetModelSchemaFromResponse(this OpenApiOperation openApiOperation)
>```
><b>Summary:</b> Retrieves the model schema from the operation's response for successful status codes (OK or Created).
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`openApiOperation`&nbsp;&nbsp;-&nbsp;&nbsp;The  to extract the schema from.<br />
>
><b>Returns:</b> The `Microsoft.OpenApi.Models.OpenApiSchema` from the response, or null if not found.
#### GetOperationName
>```csharp
>string GetOperationName(this OpenApiOperation openApiOperation)
>```
><b>Summary:</b> Retrieves the operation name from the `Microsoft.OpenApi.Models.OpenApiOperation` in PascalCase format.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`openApiOperation`&nbsp;&nbsp;-&nbsp;&nbsp;The  to extract the name from.<br />
>
><b>Returns:</b> The operation name in PascalCase format, or an empty string if OperationId is null.
#### HasDataTypeFromSystemCollectionGenericNamespace
>```csharp
>bool HasDataTypeFromSystemCollectionGenericNamespace(this List<OpenApiOperation> apiOperations)
>```
><b>Summary:</b> Determines whether any operation in the collection has a response with array data type, requiring System.Collections.Generic namespace.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`apiOperations`&nbsp;&nbsp;-&nbsp;&nbsp;The collection of  to check.<br />
>
><b>Returns:</b> True if any operation response contains array data types; otherwise, false.
#### HasParametersOrRequestBody
>```csharp
>bool HasParametersOrRequestBody(this OpenApiOperation openApiOperation)
>```
><b>Summary:</b> Determines whether the operation has any parameters or a request body defined.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`openApiOperation`&nbsp;&nbsp;-&nbsp;&nbsp;The  to check.<br />
>
><b>Returns:</b> True if the operation has parameters or a request body; otherwise, false.
#### HasRequestBodyWithAnythingAsFormatTypeBinary
>```csharp
>bool HasRequestBodyWithAnythingAsFormatTypeBinary(this OpenApiOperation openApiOperation)
>```
><b>Summary:</b> Determines whether the operation's request body contains any binary format type data.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`openApiOperation`&nbsp;&nbsp;-&nbsp;&nbsp;The  to check.<br />
>
><b>Returns:</b> True if the request body contains binary format data; otherwise, false.
#### IsOperationIdPluralized
>```csharp
>bool IsOperationIdPluralized(this OpenApiOperation openApiOperation, OperationType operationType)
>```
><b>Summary:</b> Determines whether the operation ID is pluralized based on naming conventions. This is an alias for `Microsoft.OpenApi.Models.OpenApiOperationExtensions.IsOperationNamePluralized(Microsoft.OpenApi.Models.OpenApiOperation,Microsoft.OpenApi.Models.OperationType)`.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`openApiOperation`&nbsp;&nbsp;-&nbsp;&nbsp;The  to check.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`operationType`&nbsp;&nbsp;-&nbsp;&nbsp;The HTTP operation type (GET, POST, etc.) used to strip the verb prefix.<br />
>
><b>Returns:</b> True if the operation ID is pluralized; otherwise, false.
#### IsOperationNamePluralized
>```csharp
>bool IsOperationNamePluralized(this OpenApiOperation openApiOperation, OperationType operationType)
>```
><b>Summary:</b> Determines whether the operation name is pluralized based on naming conventions. This checks if the operation name ends with 's' or contains plural forms, excluding common exceptions like "Ids", "Identifiers", and "Status".
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`openApiOperation`&nbsp;&nbsp;-&nbsp;&nbsp;The  to check.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`operationType`&nbsp;&nbsp;-&nbsp;&nbsp;The HTTP operation type (GET, POST, etc.) used to strip the verb prefix.<br />
>
><b>Returns:</b> True if the operation name is pluralized; otherwise, false.
#### IsOperationReferencingSchema
>```csharp
>bool IsOperationReferencingSchema(this OpenApiOperation openApiOperation, string schemaKey)
>```
><b>Summary:</b> Determines whether the operation references the specified schema in its request body or responses.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`openApiOperation`&nbsp;&nbsp;-&nbsp;&nbsp;The  to check.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`schemaKey`&nbsp;&nbsp;-&nbsp;&nbsp;The schema reference ID to search for.<br />
>
><b>Returns:</b> True if the operation references the schema; otherwise, false.

<br />

## OpenApiParameterExtensions
Extension methods for `Microsoft.OpenApi.Models.OpenApiParameter` collections.

>```csharp
>public static class OpenApiParameterExtensions
>```

### Static Methods

#### GetAllFromHeader
>```csharp
>List<OpenApiParameter> GetAllFromHeader(this IList<OpenApiParameter> parameters)
>```
><b>Summary:</b> Retrieves all parameters from the collection that are located in the header.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`parameters`&nbsp;&nbsp;-&nbsp;&nbsp;The collection of  to filter.<br />
>
><b>Returns:</b> A list of parameters that are header parameters.
#### GetAllFromQuery
>```csharp
>List<OpenApiParameter> GetAllFromQuery(this IList<OpenApiParameter> parameters)
>```
><b>Summary:</b> Retrieves all parameters from the collection that are located in the query string.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`parameters`&nbsp;&nbsp;-&nbsp;&nbsp;The collection of  to filter.<br />
>
><b>Returns:</b> A list of parameters that are query parameters.
#### GetAllFromRoute
>```csharp
>List<OpenApiParameter> GetAllFromRoute(this IList<OpenApiParameter> parameters)
>```
><b>Summary:</b> Retrieves all parameters from the collection that are located in the route (path).
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`parameters`&nbsp;&nbsp;-&nbsp;&nbsp;The collection of  to filter.<br />
>
><b>Returns:</b> A list of parameters that are path parameters.
#### HasFormatTypeByte
>```csharp
>bool HasFormatTypeByte(this IList<OpenApiParameter> parameters)
>```
><b>Summary:</b> Determines whether any parameter in the collection has a byte format type.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`parameters`&nbsp;&nbsp;-&nbsp;&nbsp;The collection of  to check.<br />
>
><b>Returns:</b> True if any parameter has byte format type; otherwise, false.
#### HasFormatTypeDate
>```csharp
>bool HasFormatTypeDate(this IList<OpenApiParameter> parameters)
>```
><b>Summary:</b> Determines whether any parameter in the collection has a date format type.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`parameters`&nbsp;&nbsp;-&nbsp;&nbsp;The collection of  to check.<br />
>
><b>Returns:</b> True if any parameter has date format type; otherwise, false.
#### HasFormatTypeDateTime
>```csharp
>bool HasFormatTypeDateTime(this IList<OpenApiParameter> parameters)
>```
><b>Summary:</b> Determines whether any parameter in the collection has a date-time format type.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`parameters`&nbsp;&nbsp;-&nbsp;&nbsp;The collection of  to check.<br />
>
><b>Returns:</b> True if any parameter has date-time format type; otherwise, false.
#### HasFormatTypeEmail
>```csharp
>bool HasFormatTypeEmail(this IList<OpenApiParameter> parameters)
>```
><b>Summary:</b> Determines whether any parameter in the collection has an email format type.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`parameters`&nbsp;&nbsp;-&nbsp;&nbsp;The collection of  to check.<br />
>
><b>Returns:</b> True if any parameter has email format type; otherwise, false.
#### HasFormatTypeFromDataAnnotationsNamespace
>```csharp
>bool HasFormatTypeFromDataAnnotationsNamespace(this IList<OpenApiParameter> parameters)
>```
><b>Summary:</b> Determines whether any parameter in the collection has a format type that maps to a type in the System.ComponentModel.DataAnnotations namespace. This includes email and URI format types.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`parameters`&nbsp;&nbsp;-&nbsp;&nbsp;The collection of  to check.<br />
>
><b>Returns:</b> True if any parameter has a DataAnnotations namespace format type; otherwise, false.
#### HasFormatTypeFromSystemNamespace
>```csharp
>bool HasFormatTypeFromSystemNamespace(this IList<OpenApiParameter> parameters)
>```
><b>Summary:</b> Determines whether any parameter in the collection has a format type that maps to a type in the System namespace. This includes UUID, date, date-time, time, timestamp, and URI format types.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`parameters`&nbsp;&nbsp;-&nbsp;&nbsp;The collection of  to check.<br />
>
><b>Returns:</b> True if any parameter has a System namespace format type; otherwise, false.
#### HasFormatTypeInt32
>```csharp
>bool HasFormatTypeInt32(this IList<OpenApiParameter> parameters)
>```
><b>Summary:</b> Determines whether any parameter in the collection has an int32 format type.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`parameters`&nbsp;&nbsp;-&nbsp;&nbsp;The collection of  to check.<br />
>
><b>Returns:</b> True if any parameter has int32 format type; otherwise, false.
#### HasFormatTypeInt64
>```csharp
>bool HasFormatTypeInt64(this IList<OpenApiParameter> parameters)
>```
><b>Summary:</b> Determines whether any parameter in the collection has an int64 format type.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`parameters`&nbsp;&nbsp;-&nbsp;&nbsp;The collection of  to check.<br />
>
><b>Returns:</b> True if any parameter has int64 format type; otherwise, false.
#### HasFormatTypeTime
>```csharp
>bool HasFormatTypeTime(this IList<OpenApiParameter> parameters)
>```
><b>Summary:</b> Determines whether any parameter in the collection has a time format type.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`parameters`&nbsp;&nbsp;-&nbsp;&nbsp;The collection of  to check.<br />
>
><b>Returns:</b> True if any parameter has time format type; otherwise, false.
#### HasFormatTypeTimestamp
>```csharp
>bool HasFormatTypeTimestamp(this IList<OpenApiParameter> parameters)
>```
><b>Summary:</b> Determines whether any parameter in the collection has a timestamp format type.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`parameters`&nbsp;&nbsp;-&nbsp;&nbsp;The collection of  to check.<br />
>
><b>Returns:</b> True if any parameter has timestamp format type; otherwise, false.
#### HasFormatTypeUri
>```csharp
>bool HasFormatTypeUri(this IList<OpenApiParameter> parameters)
>```
><b>Summary:</b> Determines whether any parameter in the collection has a URI format type.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`parameters`&nbsp;&nbsp;-&nbsp;&nbsp;The collection of  to check.<br />
>
><b>Returns:</b> True if any parameter has URI format type; otherwise, false.
#### HasFormatTypeUuid
>```csharp
>bool HasFormatTypeUuid(this IList<OpenApiParameter> parameters)
>```
><b>Summary:</b> Determines whether any parameter in the collection has a UUID format type.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`parameters`&nbsp;&nbsp;-&nbsp;&nbsp;The collection of  to check.<br />
>
><b>Returns:</b> True if any parameter has UUID format type; otherwise, false.

<br />

## OpenApiPathItemExtensions
Extension methods for `Microsoft.OpenApi.Models.OpenApiPathItem`.

>```csharp
>public static class OpenApiPathItemExtensions
>```

### Static Methods

#### HasParameters
>```csharp
>bool HasParameters(this OpenApiPathItem openApiPathItem)
>```
><b>Summary:</b> Determines whether the `Microsoft.OpenApi.Models.OpenApiPathItem` has any parameters defined.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`openApiPathItem`&nbsp;&nbsp;-&nbsp;&nbsp;The  to check.<br />
>
><b>Returns:</b> True if the path item has one or more parameters; otherwise, false.
#### IsPathStartingSegmentName
>```csharp
>bool IsPathStartingSegmentName(this KeyValuePair<string, OpenApiPathItem> urlPath, string segmentName)
>```
><b>Summary:</b> Determines whether the path starts with the specified segment name. The comparison is case-insensitive and handles singular/plural forms and hyphenated names.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`urlPath`&nbsp;&nbsp;-&nbsp;&nbsp;The path key-value pair to check.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`segmentName`&nbsp;&nbsp;-&nbsp;&nbsp;The segment name to match against the first path segment.<br />
>
><b>Returns:</b> True if the path starts with the specified segment name; otherwise, false.

<br />

## OpenApiPathsExtensions
Extension methods for `Microsoft.OpenApi.Models.OpenApiPaths`.

>```csharp
>public static class OpenApiPathsExtensions
>```

### Static Methods

#### GetPathsStartingWithSegmentName
>```csharp
>List<KeyValuePair<string, OpenApiPathItem>> GetPathsStartingWithSegmentName(this OpenApiPaths urlPaths, string segmentName)
>```
><b>Summary:</b> Retrieves all paths from the `Microsoft.OpenApi.Models.OpenApiPaths` collection that start with the specified segment name.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`urlPaths`&nbsp;&nbsp;-&nbsp;&nbsp;The  collection to filter.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`segmentName`&nbsp;&nbsp;-&nbsp;&nbsp;The segment name to match at the beginning of paths.<br />
>
><b>Returns:</b> A list of key-value pairs containing paths that start with the specified segment name.

<br />

## OpenApiResponsesExtensions
Extension methods for `Microsoft.OpenApi.Models.OpenApiResponses`.

>```csharp
>public static class OpenApiResponsesExtensions
>```

### Static Methods

#### GetDataTypeForStatusCode
>```csharp
>string GetDataTypeForStatusCode(this OpenApiResponses responses, HttpStatusCode httpStatusCode)
>```
><b>Summary:</b> Retrieves the data type from the schema associated with the specified HTTP status code.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`responses`&nbsp;&nbsp;-&nbsp;&nbsp;The  collection to search.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`httpStatusCode`&nbsp;&nbsp;-&nbsp;&nbsp;The HTTP status code to retrieve the data type for.<br />
>
><b>Returns:</b> The data type of the response schema, or an empty string if not found.
#### GetHttpStatusCodes
>```csharp
>List<HttpStatusCode> GetHttpStatusCodes(this OpenApiResponses responses)
>```
><b>Summary:</b> Extracts all HTTP status codes defined in the `Microsoft.OpenApi.Models.OpenApiResponses` collection.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`responses`&nbsp;&nbsp;-&nbsp;&nbsp;The  collection to process.<br />
>
><b>Returns:</b> A list of `System.Net.HttpStatusCode` values parsed from the response keys.
#### GetModelNameForStatusCode
>```csharp
>string GetModelNameForStatusCode(this OpenApiResponses responses, HttpStatusCode httpStatusCode)
>```
><b>Summary:</b> Retrieves the model name from the schema associated with the specified HTTP status code.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`responses`&nbsp;&nbsp;-&nbsp;&nbsp;The  collection to search.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`httpStatusCode`&nbsp;&nbsp;-&nbsp;&nbsp;The HTTP status code to retrieve the model name for.<br />
>
><b>Returns:</b> The model name of the response schema, or an empty string if not found.
#### GetSchemaForStatusCode
>```csharp
>OpenApiSchema GetSchemaForStatusCode(this OpenApiResponses responses, HttpStatusCode httpStatusCode, string contentType = application/json)
>```
><b>Summary:</b> Retrieves the `Microsoft.OpenApi.Models.OpenApiSchema` for the specified HTTP status code and content type.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`responses`&nbsp;&nbsp;-&nbsp;&nbsp;The  collection to search.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`httpStatusCode`&nbsp;&nbsp;-&nbsp;&nbsp;The HTTP status code to retrieve the schema for.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`contentType`&nbsp;&nbsp;-&nbsp;&nbsp;The content type to retrieve the schema for. Defaults to application/json.<br />
>
><b>Returns:</b> The `Microsoft.OpenApi.Models.OpenApiSchema` for the specified status code and content type, or null if not found.
#### HasSchemaHttpStatusCodeUsingAspNetCoreHttp
>```csharp
>bool HasSchemaHttpStatusCodeUsingAspNetCoreHttp(this OpenApiResponses responses)
>```
><b>Summary:</b> Determines whether the responses contain any HTTP status codes that require the Microsoft.AspNetCore.Http namespace. Currently checks for the Created (201) status code.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`responses`&nbsp;&nbsp;-&nbsp;&nbsp;The  collection to check.<br />
>
><b>Returns:</b> True if any response uses an ASP.NET Core HTTP status code; otherwise, false.
#### HasSchemaHttpStatusCodeUsingSystemNet
>```csharp
>bool HasSchemaHttpStatusCodeUsingSystemNet(this OpenApiResponses responses)
>```
><b>Summary:</b> Determines whether the responses contain any HTTP status codes that require the System.Net namespace. These include error status codes like BadRequest, InternalServerError, etc.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`responses`&nbsp;&nbsp;-&nbsp;&nbsp;The  collection to check.<br />
>
><b>Returns:</b> True if any response uses a System.Net HTTP status code; otherwise, false.
#### HasSchemaTypeArray
>```csharp
>bool HasSchemaTypeArray(this OpenApiResponses responses)
>```
><b>Summary:</b> Determines whether any response in the collection has a schema with array type.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`responses`&nbsp;&nbsp;-&nbsp;&nbsp;The  collection to check.<br />
>
><b>Returns:</b> True if any response schema is an array type; otherwise, false.
#### IsSchemaTypeArrayForStatusCode
>```csharp
>bool IsSchemaTypeArrayForStatusCode(this OpenApiResponses responses, HttpStatusCode httpStatusCode)
>```
><b>Summary:</b> Determines whether the schema for the specified HTTP status code is an array type.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`responses`&nbsp;&nbsp;-&nbsp;&nbsp;The  collection to check.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`httpStatusCode`&nbsp;&nbsp;-&nbsp;&nbsp;The HTTP status code to check the schema type for.<br />
>
><b>Returns:</b> True if the response schema is an array type; otherwise, false.
#### IsSchemaTypePaginationForStatusCode
>```csharp
>bool IsSchemaTypePaginationForStatusCode(this OpenApiResponses responses, HttpStatusCode httpStatusCode)
>```
><b>Summary:</b> Determines whether the schema for the specified HTTP status code is a pagination wrapper type. A pagination type is identified by having two allOf schemas where one references "Pagination".
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`responses`&nbsp;&nbsp;-&nbsp;&nbsp;The  collection to check.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`httpStatusCode`&nbsp;&nbsp;-&nbsp;&nbsp;The HTTP status code to check the schema type for.<br />
>
><b>Returns:</b> True if the response schema is a pagination type; otherwise, false.
#### IsSchemaTypeProblemDetailsForStatusCode
>```csharp
>bool IsSchemaTypeProblemDetailsForStatusCode(this OpenApiResponses responses, HttpStatusCode httpStatusCode)
>```
><b>Summary:</b> Determines whether the schema for the specified HTTP status code references ProblemDetails.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`responses`&nbsp;&nbsp;-&nbsp;&nbsp;The  collection to check.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`httpStatusCode`&nbsp;&nbsp;-&nbsp;&nbsp;The HTTP status code to check the schema type for.<br />
>
><b>Returns:</b> True if the response schema references ProblemDetails; otherwise, false.
#### IsSchemaUsingBinaryFormatForOkResponse
>```csharp
>bool IsSchemaUsingBinaryFormatForOkResponse(this OpenApiResponses responses)
>```
><b>Summary:</b> Determines whether the OK (200) response uses a binary format type schema.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`responses`&nbsp;&nbsp;-&nbsp;&nbsp;The  collection to check.<br />
>
><b>Returns:</b> True if the OK response schema uses binary format; otherwise, false.

<br />

## OpenApiSchemaExtensions
Extension methods for `Microsoft.OpenApi.Models.OpenApiSchema`. Provides utilities for working with OpenAPI schemas including type checking, format validation, model name extraction, and data type conversion. See: https://swagger.io/docs/specification/data-models/

>```csharp
>public static class OpenApiSchemaExtensions
>```

### Static Methods

#### ExtractPropertyNameWhenHasAnyPropertiesOfArrayWithFormatTypeBinary
>```csharp
>string ExtractPropertyNameWhenHasAnyPropertiesOfArrayWithFormatTypeBinary(this OpenApiSchema apiSchema)
>```
><b>Summary:</b> Extracts the property name of the first array property found in the schema, with the first character converted to uppercase. Returns empty string if no array properties are found.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`apiSchema`&nbsp;&nbsp;-&nbsp;&nbsp;The  to search.<br />
>
><b>Returns:</b> The property name with first character uppercase, or empty string if no array properties exist.
#### GetDataType
>```csharp
>string GetDataType(this OpenApiSchema schema)
>```
><b>Summary:</b> Gets the .NET data type for the schema, converting OpenAPI types and formats to their corresponding .NET types. Examples: "number" with "int32" format becomes "int", "string" with "uuid" format becomes "Guid", "string" with "binary" format becomes "IFormFile", etc.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`schema`&nbsp;&nbsp;-&nbsp;&nbsp;The  to get the data type from.<br />
>
><b>Returns:</b> The .NET data type as a string, or empty string if no type can be determined.
#### GetEnumSchema
>```csharp
>Tuple<string, OpenApiSchema> GetEnumSchema(this OpenApiSchema schema)
>```
><b>Summary:</b> Extracts the enum schema from the schema, either from the schema itself or from its first enum property. Returns a tuple containing the enum name and the enum schema.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`schema`&nbsp;&nbsp;-&nbsp;&nbsp;The  to extract the enum from.<br />
>
><b>Returns:</b> A tuple containing the enum name and the enum schema.
#### GetModelName
>```csharp
>string GetModelName(this OpenApiSchema schema, bool ensureFirstCharacterToUpper = True)
>```
><b>Summary:</b> Extracts the model name from the schema. For reference types, returns the reference ID (optionally PascalCased). For pagination types, extracts the model name from the non-pagination allOf element. For arrays of objects, returns the item's model name. For inline objects, returns "object". For primitives, returns empty string.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`schema`&nbsp;&nbsp;-&nbsp;&nbsp;The  to extract the model name from.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`ensureFirstCharacterToUpper`&nbsp;&nbsp;-&nbsp;&nbsp;If true, ensures the model name is PascalCased; otherwise returns as-is.<br />
>
><b>Returns:</b> The model name, or empty string if the schema doesn't represent a model.
#### GetModelType
>```csharp
>string GetModelType(this OpenApiSchema schema)
>```
><b>Summary:</b> Extracts the model type from the schema. For pagination types, extracts the type from the non-pagination allOf element. For regular schemas, returns the Type property.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`schema`&nbsp;&nbsp;-&nbsp;&nbsp;The  to extract the model type from.<br />
>
><b>Returns:</b> The model type, or null if not available.
#### GetSchemaByModelName
>```csharp
>OpenApiSchema GetSchemaByModelName(this IDictionary<string, OpenApiSchema> componentSchemas, string modelName)
>```
><b>Summary:</b> Gets the schema from component schemas by model name (case-insensitive).
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`componentSchemas`&nbsp;&nbsp;-&nbsp;&nbsp;The dictionary of component schemas.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`modelName`&nbsp;&nbsp;-&nbsp;&nbsp;The model name to search for.<br />
>
><b>Returns:</b> The matching schema.
#### GetSimpleDataTypeFromArray
>```csharp
>string GetSimpleDataTypeFromArray(this OpenApiSchema schema)
>```
><b>Summary:</b> Extracts the simple data type from an array schema's items. Returns empty string if the schema is not an array or doesn't have simple data type items.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`schema`&nbsp;&nbsp;-&nbsp;&nbsp;The  to extract the data type from.<br />
>
><b>Returns:</b> The simple data type of the array items, or empty string if not applicable.
#### GetSimpleDataTypeFromPagination
>```csharp
>string GetSimpleDataTypeFromPagination(this OpenApiSchema schema)
>```
><b>Summary:</b> Extracts the simple data type from a pagination schema's items. Returns empty string if the schema is not a pagination type.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`schema`&nbsp;&nbsp;-&nbsp;&nbsp;The  to extract the data type from.<br />
>
><b>Returns:</b> The simple data type of the paginated items, or empty string if not a pagination type.
#### GetTitleFromPropertyByPropertyKey
>```csharp
>string GetTitleFromPropertyByPropertyKey(this OpenApiSchema schema, string propertyKey)
>```
><b>Summary:</b> Gets the title of a property by its property key (name).
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`schema`&nbsp;&nbsp;-&nbsp;&nbsp;The  containing the properties.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`propertyKey`&nbsp;&nbsp;-&nbsp;&nbsp;The property key to search for.<br />
>
><b>Returns:</b> The title of the property.
#### HasAnyProperties
>```csharp
>bool HasAnyProperties(this OpenApiSchema schema)
>```
><b>Summary:</b> Determines whether the schema has any properties defined. This includes properties in the schema itself or in a single oneOf composition.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`schema`&nbsp;&nbsp;-&nbsp;&nbsp;The  to check.<br />
>
><b>Returns:</b> True if the schema has any properties; otherwise, false.
#### HasAnyPropertiesAsArrayWithFormatTypeBinary
>```csharp
>bool HasAnyPropertiesAsArrayWithFormatTypeBinary(this OpenApiSchema schema)
>```
><b>Summary:</b> Determines whether the schema has any properties that are arrays with binary format type items. This is used to detect array properties containing file uploads or binary data.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`schema`&nbsp;&nbsp;-&nbsp;&nbsp;The  to check.<br />
>
><b>Returns:</b> True if any property is an array with binary format type items; otherwise, false.
#### HasAnyPropertiesFormatTypeFromSystemCollectionGenericNamespace
>```csharp
>bool HasAnyPropertiesFormatTypeFromSystemCollectionGenericNamespace(this OpenApiSchema schema, IDictionary<string, OpenApiSchema> componentSchemas)
>```
><b>Summary:</b> Determines whether the schema has any properties with format types from the System.Collections.Generic namespace, recursively checking nested schemas using component schemas for reference resolution. This includes array types and collection properties.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`schema`&nbsp;&nbsp;-&nbsp;&nbsp;The  to check.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`componentSchemas`&nbsp;&nbsp;-&nbsp;&nbsp;The dictionary of component schemas from the OpenAPI document.<br />
>
><b>Returns:</b> True if any property uses System.Collections.Generic types; otherwise, false.
#### HasAnyPropertiesFormatTypeFromSystemNamespace
>```csharp
>bool HasAnyPropertiesFormatTypeFromSystemNamespace(this OpenApiSchema schema)
>```
><b>Summary:</b> Determines whether the schema has any properties with format types from the System namespace. This includes UUID (Guid), date/time types, and URI types.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`schema`&nbsp;&nbsp;-&nbsp;&nbsp;The  to check.<br />
>
><b>Returns:</b> True if any property has a System namespace format type; otherwise, false.
#### HasAnyPropertiesFormatTypeFromSystemNamespace
>```csharp
>bool HasAnyPropertiesFormatTypeFromSystemNamespace(this OpenApiSchema schema, IDictionary<string, OpenApiSchema> componentSchemas)
>```
><b>Summary:</b> Determines whether the schema has any properties with format types from the System namespace. This includes UUID (Guid), date/time types, and URI types.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`schema`&nbsp;&nbsp;-&nbsp;&nbsp;The  to check.<br />
>
><b>Returns:</b> True if any property has a System namespace format type; otherwise, false.
#### HasAnyPropertiesWithFormatTypeBinary
>```csharp
>bool HasAnyPropertiesWithFormatTypeBinary(this OpenApiSchema schema)
>```
><b>Summary:</b> Determines whether the schema has any properties with binary format type. Binary format is typically used for file uploads and binary data.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`schema`&nbsp;&nbsp;-&nbsp;&nbsp;The  to check.<br />
>
><b>Returns:</b> True if any property has binary format type; otherwise, false.
#### HasAnythingAsFormatTypeBinary
>```csharp
>bool HasAnythingAsFormatTypeBinary(this OpenApiSchema schema)
>```
><b>Summary:</b> Determines whether the schema has any binary format type in itself, its items, its properties, or array properties. This comprehensive check covers all possible locations where binary format could appear in the schema.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`schema`&nbsp;&nbsp;-&nbsp;&nbsp;The  to check.<br />
>
><b>Returns:</b> True if any aspect of the schema has binary format type; otherwise, false.
#### HasArrayItemsWithSimpleDataType
>```csharp
>bool HasArrayItemsWithSimpleDataType(this OpenApiSchema schema)
>```
><b>Summary:</b> Determines whether the schema is an array type with simple data type items. Simple data types include primitives like boolean, integer, number, and string.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`schema`&nbsp;&nbsp;-&nbsp;&nbsp;The  to check.<br />
>
><b>Returns:</b> True if the schema is an array with simple data type items; otherwise, false.
#### HasDataTypeFromSystemCollectionGenericNamespace
>```csharp
>bool HasDataTypeFromSystemCollectionGenericNamespace(this OpenApiSchema schema, IDictionary<string, OpenApiSchema> componentSchemas)
>```
><b>Summary:</b> Determines whether the schema uses data types from the System.Collections.Generic namespace. This includes array types and oneOf compositions with collection properties.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`schema`&nbsp;&nbsp;-&nbsp;&nbsp;The  to check.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`componentSchemas`&nbsp;&nbsp;-&nbsp;&nbsp;The dictionary of component schemas from the OpenAPI document.<br />
>
><b>Returns:</b> True if the schema uses System.Collections.Generic types; otherwise, false.
#### HasDataTypeFromSystemCollectionGenericNamespace
>```csharp
>bool HasDataTypeFromSystemCollectionGenericNamespace(this IList<OpenApiSchema> schemas, IDictionary<string, OpenApiSchema> componentSchemas)
>```
><b>Summary:</b> Determines whether the schema uses data types from the System.Collections.Generic namespace. This includes array types and oneOf compositions with collection properties.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`schema`&nbsp;&nbsp;-&nbsp;&nbsp;The  to check.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`componentSchemas`&nbsp;&nbsp;-&nbsp;&nbsp;The dictionary of component schemas from the OpenAPI document.<br />
>
><b>Returns:</b> True if the schema uses System.Collections.Generic types; otherwise, false.
#### HasDataTypeList
>```csharp
>bool HasDataTypeList(this IList<OpenApiSchema> schemas)
>```
><b>Summary:</b> Determines whether any schema in the collection has an array data type.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`schemas`&nbsp;&nbsp;-&nbsp;&nbsp;The collection of  to check.<br />
>
><b>Returns:</b> True if any schema is an array type; otherwise, false.
#### HasFormatType
>```csharp
>bool HasFormatType(this OpenApiSchema schema)
>```
><b>Summary:</b> Determines whether the schema has a format type specified.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`schema`&nbsp;&nbsp;-&nbsp;&nbsp;The  to check.<br />
>
><b>Returns:</b> True if the schema has a format type; otherwise, false.
#### HasFormatTypeByte
>```csharp
>bool HasFormatTypeByte(this IList<OpenApiSchema> schemas)
>```
><b>Summary:</b> Determines whether any schema in the collection has a byte format type.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`schemas`&nbsp;&nbsp;-&nbsp;&nbsp;The collection of  to check.<br />
>
><b>Returns:</b> True if any schema has byte format type; otherwise, false.
#### HasFormatTypeDate
>```csharp
>bool HasFormatTypeDate(this IList<OpenApiSchema> schemas)
>```
><b>Summary:</b> Determines whether any schema in the collection has a date format type.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`schemas`&nbsp;&nbsp;-&nbsp;&nbsp;The collection of  to check.<br />
>
><b>Returns:</b> True if any schema has date format type; otherwise, false.
#### HasFormatTypeDateTime
>```csharp
>bool HasFormatTypeDateTime(this IList<OpenApiSchema> schemas)
>```
><b>Summary:</b> Determines whether any schema in the collection has a date-time format type.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`schemas`&nbsp;&nbsp;-&nbsp;&nbsp;The collection of  to check.<br />
>
><b>Returns:</b> True if any schema has date-time format type; otherwise, false.
#### HasFormatTypeEmail
>```csharp
>bool HasFormatTypeEmail(this IList<OpenApiSchema> schemas)
>```
><b>Summary:</b> Determines whether any schema in the collection has an email format type.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`schemas`&nbsp;&nbsp;-&nbsp;&nbsp;The collection of  to check.<br />
>
><b>Returns:</b> True if any schema has email format type; otherwise, false.
#### HasFormatTypeFromAspNetCoreHttpNamespace
>```csharp
>bool HasFormatTypeFromAspNetCoreHttpNamespace(this OpenApiSchema schema)
>```
><b>Summary:</b> Determines whether the schema uses format types from the Microsoft.AspNetCore.Http namespace. This includes binary format types that map to IFormFile for file uploads.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`schema`&nbsp;&nbsp;-&nbsp;&nbsp;The  to check.<br />
>
><b>Returns:</b> True if the schema uses AspNetCore.Http format types; otherwise, false.
#### HasFormatTypeFromAspNetCoreHttpNamespace
>```csharp
>bool HasFormatTypeFromAspNetCoreHttpNamespace(this IList<OpenApiSchema> schemas)
>```
><b>Summary:</b> Determines whether the schema uses format types from the Microsoft.AspNetCore.Http namespace. This includes binary format types that map to IFormFile for file uploads.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`schema`&nbsp;&nbsp;-&nbsp;&nbsp;The  to check.<br />
>
><b>Returns:</b> True if the schema uses AspNetCore.Http format types; otherwise, false.
#### HasFormatTypeFromDataAnnotationsNamespace
>```csharp
>bool HasFormatTypeFromDataAnnotationsNamespace(this OpenApiSchema schema)
>```
><b>Summary:</b> Determines whether the schema uses format types or validation rules from the System.ComponentModel.DataAnnotations namespace. This includes email format, URI format, string validation rules (length), and number validation rules (min/max).
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`schema`&nbsp;&nbsp;-&nbsp;&nbsp;The  to check.<br />
>
><b>Returns:</b> True if the schema uses DataAnnotations format types or validation rules; otherwise, false.
#### HasFormatTypeFromDataAnnotationsNamespace
>```csharp
>bool HasFormatTypeFromDataAnnotationsNamespace(this IList<OpenApiSchema> schemas)
>```
><b>Summary:</b> Determines whether the schema uses format types or validation rules from the System.ComponentModel.DataAnnotations namespace. This includes email format, URI format, string validation rules (length), and number validation rules (min/max).
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`schema`&nbsp;&nbsp;-&nbsp;&nbsp;The  to check.<br />
>
><b>Returns:</b> True if the schema uses DataAnnotations format types or validation rules; otherwise, false.
#### HasFormatTypeFromSystemNamespace
>```csharp
>bool HasFormatTypeFromSystemNamespace(this OpenApiSchema schema)
>```
><b>Summary:</b> Determines whether the schema uses format types from the System namespace. This includes UUID (Guid), date/time types, URI, and arrays containing such types.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`schema`&nbsp;&nbsp;-&nbsp;&nbsp;The  to check.<br />
>
><b>Returns:</b> True if the schema uses System namespace format types; otherwise, false.
#### HasFormatTypeFromSystemNamespace
>```csharp
>bool HasFormatTypeFromSystemNamespace(this IList<OpenApiSchema> schemas)
>```
><b>Summary:</b> Determines whether the schema uses format types from the System namespace. This includes UUID (Guid), date/time types, URI, and arrays containing such types.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`schema`&nbsp;&nbsp;-&nbsp;&nbsp;The  to check.<br />
>
><b>Returns:</b> True if the schema uses System namespace format types; otherwise, false.
#### HasFormatTypeInt32
>```csharp
>bool HasFormatTypeInt32(this IList<OpenApiSchema> schemas)
>```
><b>Summary:</b> Determines whether any schema in the collection has an int32 format type.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`schemas`&nbsp;&nbsp;-&nbsp;&nbsp;The collection of  to check.<br />
>
><b>Returns:</b> True if any schema has int32 format type; otherwise, false.
#### HasFormatTypeInt64
>```csharp
>bool HasFormatTypeInt64(this IList<OpenApiSchema> schemas)
>```
><b>Summary:</b> Determines whether any schema in the collection has an int64 format type.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`schemas`&nbsp;&nbsp;-&nbsp;&nbsp;The collection of  to check.<br />
>
><b>Returns:</b> True if any schema has int64 format type; otherwise, false.
#### HasFormatTypeTime
>```csharp
>bool HasFormatTypeTime(this IList<OpenApiSchema> schemas)
>```
><b>Summary:</b> Determines whether any schema in the collection has a time format type.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`schemas`&nbsp;&nbsp;-&nbsp;&nbsp;The collection of  to check.<br />
>
><b>Returns:</b> True if any schema has time format type; otherwise, false.
#### HasFormatTypeTimestamp
>```csharp
>bool HasFormatTypeTimestamp(this IList<OpenApiSchema> schemas)
>```
><b>Summary:</b> Determines whether any schema in the collection has a timestamp format type.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`schemas`&nbsp;&nbsp;-&nbsp;&nbsp;The collection of  to check.<br />
>
><b>Returns:</b> True if any schema has timestamp format type; otherwise, false.
#### HasFormatTypeUri
>```csharp
>bool HasFormatTypeUri(this IList<OpenApiSchema> schemas)
>```
><b>Summary:</b> Determines whether any schema in the collection has a URI format type.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`schemas`&nbsp;&nbsp;-&nbsp;&nbsp;The collection of  to check.<br />
>
><b>Returns:</b> True if any schema has URI format type; otherwise, false.
#### HasFormatTypeUuid
>```csharp
>bool HasFormatTypeUuid(this IList<OpenApiSchema> schemas)
>```
><b>Summary:</b> Determines whether any schema in the collection has a UUID format type.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`schemas`&nbsp;&nbsp;-&nbsp;&nbsp;The collection of  to check.<br />
>
><b>Returns:</b> True if any schema has UUID format type; otherwise, false.
#### HasItemsWithFormatTypeBinary
>```csharp
>bool HasItemsWithFormatTypeBinary(this OpenApiSchema schema)
>```
><b>Summary:</b> Determines whether the schema has items with binary format type. Binary format is typically used for file uploads and binary data.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`schema`&nbsp;&nbsp;-&nbsp;&nbsp;The  to check.<br />
>
><b>Returns:</b> True if the schema has items with binary format type; otherwise, false.
#### HasItemsWithSimpleDataType
>```csharp
>bool HasItemsWithSimpleDataType(this OpenApiSchema schema)
>```
><b>Summary:</b> Determines whether the schema has items with simple data types. Simple data types include primitives like boolean, integer, number, and string.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`schema`&nbsp;&nbsp;-&nbsp;&nbsp;The  to check.<br />
>
><b>Returns:</b> True if the schema has items with simple data types; otherwise, false.
#### HasModelNameOrAnyPropertiesWithModelName
>```csharp
>bool HasModelNameOrAnyPropertiesWithModelName(this OpenApiSchema schema, string modelName)
>```
><b>Summary:</b> Determines whether the schema itself or any of its properties (including nested properties and oneOf compositions) has the specified model name. This method recursively searches through the schema hierarchy to find matching model names.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`schema`&nbsp;&nbsp;-&nbsp;&nbsp;The  to check.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`modelName`&nbsp;&nbsp;-&nbsp;&nbsp;The model name to search for.<br />
>
><b>Returns:</b> True if the schema or any of its properties has the specified model name; otherwise, false.
#### HasPaginationItemsWithSimpleDataType
>```csharp
>bool HasPaginationItemsWithSimpleDataType(this OpenApiSchema schema)
>```
><b>Summary:</b> Determines whether the schema is a pagination type with simple data type items. Pagination schemas are composed using allOf with a Pagination reference and an items schema.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`schema`&nbsp;&nbsp;-&nbsp;&nbsp;The  to check.<br />
>
><b>Returns:</b> True if the schema is a pagination type with simple data type items; otherwise, false.
#### IsArrayReferenceTypeDeclared
>```csharp
>bool IsArrayReferenceTypeDeclared(this OpenApiSchema schema)
>```
><b>Summary:</b> Determines whether the schema is an array type with items that are reference types (have a $ref).
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`schema`&nbsp;&nbsp;-&nbsp;&nbsp;The  to check.<br />
>
><b>Returns:</b> True if the schema is an array with reference type items; otherwise, false.
#### IsFormatTypeBinary
>```csharp
>bool IsFormatTypeBinary(this OpenApiSchema schema)
>```
><b>Summary:</b> Determines whether the schema has a binary format type (any sequence of octets). This typically maps to IFormFile in ASP.NET Core for file uploads.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`schema`&nbsp;&nbsp;-&nbsp;&nbsp;The  to check.<br />
>
><b>Returns:</b> True if the schema has binary format type; otherwise, false.
#### IsFormatTypeByte
>```csharp
>bool IsFormatTypeByte(this OpenApiSchema schema)
>```
><b>Summary:</b> Determines whether the schema has a byte format type (base64 encoded characters).
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`schema`&nbsp;&nbsp;-&nbsp;&nbsp;The  to check.<br />
>
><b>Returns:</b> True if the schema has byte format type; otherwise, false.
#### IsFormatTypeDate
>```csharp
>bool IsFormatTypeDate(this OpenApiSchema schema)
>```
><b>Summary:</b> Determines whether the schema has a date format type (full-date per RFC 3339).
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`schema`&nbsp;&nbsp;-&nbsp;&nbsp;The  to check.<br />
>
><b>Returns:</b> True if the schema has date format type; otherwise, false.
#### IsFormatTypeDateTime
>```csharp
>bool IsFormatTypeDateTime(this OpenApiSchema schema)
>```
><b>Summary:</b> Determines whether the schema has a date-time format type (date-time per RFC 3339).
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`schema`&nbsp;&nbsp;-&nbsp;&nbsp;The  to check.<br />
>
><b>Returns:</b> True if the schema has date-time format type; otherwise, false.
#### IsFormatTypeEmail
>```csharp
>bool IsFormatTypeEmail(this OpenApiSchema schema)
>```
><b>Summary:</b> Determines whether the schema has an email format type (email address per RFC 5322).
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`schema`&nbsp;&nbsp;-&nbsp;&nbsp;The  to check.<br />
>
><b>Returns:</b> True if the schema has email format type; otherwise, false.
#### IsFormatTypeInt32
>```csharp
>bool IsFormatTypeInt32(this OpenApiSchema schema)
>```
><b>Summary:</b> Determines whether the schema has an int32 format type (signed 32-bit integer).
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`schema`&nbsp;&nbsp;-&nbsp;&nbsp;The  to check.<br />
>
><b>Returns:</b> True if the schema has int32 format type; otherwise, false.
#### IsFormatTypeInt64
>```csharp
>bool IsFormatTypeInt64(this OpenApiSchema schema)
>```
><b>Summary:</b> Determines whether the schema has an int64 format type (signed 64-bit integer).
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`schema`&nbsp;&nbsp;-&nbsp;&nbsp;The  to check.<br />
>
><b>Returns:</b> True if the schema has int64 format type; otherwise, false.
#### IsFormatTypeTime
>```csharp
>bool IsFormatTypeTime(this OpenApiSchema schema)
>```
><b>Summary:</b> Determines whether the schema has a time format type (partial-time per RFC 3339).
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`schema`&nbsp;&nbsp;-&nbsp;&nbsp;The  to check.<br />
>
><b>Returns:</b> True if the schema has time format type; otherwise, false.
#### IsFormatTypeTimestamp
>```csharp
>bool IsFormatTypeTimestamp(this OpenApiSchema schema)
>```
><b>Summary:</b> Determines whether the schema has a timestamp format type.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`schema`&nbsp;&nbsp;-&nbsp;&nbsp;The  to check.<br />
>
><b>Returns:</b> True if the schema has timestamp format type; otherwise, false.
#### IsFormatTypeUri
>```csharp
>bool IsFormatTypeUri(this OpenApiSchema schema)
>```
><b>Summary:</b> Determines whether the schema has a URI format type (URI per RFC 3986).
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`schema`&nbsp;&nbsp;-&nbsp;&nbsp;The  to check.<br />
>
><b>Returns:</b> True if the schema has URI format type; otherwise, false.
#### IsFormatTypeUuid
>```csharp
>bool IsFormatTypeUuid(this OpenApiSchema schema)
>```
><b>Summary:</b> Determines whether the schema has a UUID format type, which maps to System.Guid in .NET.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`schema`&nbsp;&nbsp;-&nbsp;&nbsp;The  to check.<br />
>
><b>Returns:</b> True if the schema has UUID format type; otherwise, false.
#### IsObjectReferenceTypeDeclared
>```csharp
>bool IsObjectReferenceTypeDeclared(this OpenApiSchema schema)
>```
><b>Summary:</b> Determines whether the schema is an object reference type (has a $ref).
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`schema`&nbsp;&nbsp;-&nbsp;&nbsp;The  to check.<br />
>
><b>Returns:</b> True if the schema is a reference type; otherwise, false.
#### IsRuleValidationNumber
>```csharp
>bool IsRuleValidationNumber(this OpenApiSchema schema)
>```
><b>Summary:</b> Determines whether the schema has number validation rules (minimum or maximum value).
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`schema`&nbsp;&nbsp;-&nbsp;&nbsp;The  to check.<br />
>
><b>Returns:</b> True if the schema has number validation rules; otherwise, false.
#### IsRuleValidationString
>```csharp
>bool IsRuleValidationString(this OpenApiSchema schema)
>```
><b>Summary:</b> Determines whether the schema has string validation rules (minimum or maximum length).
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`schema`&nbsp;&nbsp;-&nbsp;&nbsp;The  to check.<br />
>
><b>Returns:</b> True if the schema has string validation rules; otherwise, false.
#### IsSchemaEnum
>```csharp
>bool IsSchemaEnum(this OpenApiSchema schema)
>```
><b>Summary:</b> Determines whether the schema is an enumeration type (has enum values defined).
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`schema`&nbsp;&nbsp;-&nbsp;&nbsp;The  to check.<br />
>
><b>Returns:</b> True if the schema is an enum type; otherwise, false.
#### IsSchemaEnumOrPropertyEnum
>```csharp
>bool IsSchemaEnumOrPropertyEnum(this OpenApiSchema schema)
>```
><b>Summary:</b> Determines whether the schema is an enumeration type or has a single property that is an enum.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`schema`&nbsp;&nbsp;-&nbsp;&nbsp;The  to check.<br />
>
><b>Returns:</b> True if the schema is an enum or has a single enum property; otherwise, false.
#### IsSharedContract
>```csharp
>bool IsSharedContract(this OpenApiSchema schema, OpenApiComponents openApiComponents)
>```
><b>Summary:</b> Determines whether the schema is a shared contract, meaning it is referenced by multiple different schemas in the OpenAPI components. A schema is considered shared if it is referenced as a property in at least two different parent schemas.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`schema`&nbsp;&nbsp;-&nbsp;&nbsp;The  to check.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`openApiComponents`&nbsp;&nbsp;-&nbsp;&nbsp;The OpenAPI components containing all schemas.<br />
>
><b>Returns:</b> True if the schema is shared across multiple parent schemas; otherwise, false.
#### IsSimpleDataType
>```csharp
>bool IsSimpleDataType(this OpenApiSchema schema)
>```
><b>Summary:</b> Determines whether the schema represents a simple (primitive) data type. Simple data types include boolean, integer, number, string, and their .NET equivalents (bool, int, long, double, float, Guid).
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`schema`&nbsp;&nbsp;-&nbsp;&nbsp;The  to check.<br />
>
><b>Returns:</b> True if the schema is a simple data type; otherwise, false.
#### IsTypeArray
>```csharp
>bool IsTypeArray(this OpenApiSchema schema)
>```
><b>Summary:</b> Determines whether the schema is an array type.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`schema`&nbsp;&nbsp;-&nbsp;&nbsp;The  to check.<br />
>
><b>Returns:</b> True if the schema is an array type; otherwise, false.
#### IsTypeArrayOrPagination
>```csharp
>bool IsTypeArrayOrPagination(this OpenApiSchema schema)
>```
><b>Summary:</b> Determines whether the schema is either an array type or a pagination type.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`schema`&nbsp;&nbsp;-&nbsp;&nbsp;The  to check.<br />
>
><b>Returns:</b> True if the schema is an array or pagination type; otherwise, false.
#### IsTypePagination
>```csharp
>bool IsTypePagination(this OpenApiSchema schema)
>```
><b>Summary:</b> Determines whether the schema is a pagination type. Pagination schemas are composed using allOf with exactly two elements, one of which references the Pagination schema.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`schema`&nbsp;&nbsp;-&nbsp;&nbsp;The  to check.<br />
>
><b>Returns:</b> True if the schema is a pagination type; otherwise, false.
<hr /><div style='text-align: right'><i>Generated by MarkdownCodeDoc version 1.2</i></div>
