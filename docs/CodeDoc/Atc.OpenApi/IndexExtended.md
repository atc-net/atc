<div style='text-align: right'>

[References](Index.md)

</div>


# References extended

## [Atc.OpenApi](Atc.OpenApi.md)

- [AtcOpenApiAssemblyTypeInitializer](Atc.OpenApi.md#atcopenapiassemblytypeinitializer)

## [Microsoft.OpenApi.Models](Microsoft.OpenApi.Models.md)

- [NameConstants](Microsoft.OpenApi.Models.md#nameconstants)
  -  Static Fields
     - string List
     - string Pagination
- [OpenApiDataTypeConstants](Microsoft.OpenApi.Models.md#openapidatatypeconstants)
  -  Static Fields
     - string Array
     - string Boolean
     - string Integer
     - string Number
     - string Object
     - string String
- [OpenApiDocumentExtensions](Microsoft.OpenApi.Models.md#openapidocumentextensions)
  -  Static Methods
     - GetPathsByBasePathSegmentName(this OpenApiDocument document, string basePathSegmentName)
- [OpenApiFormatTypeConstants](Microsoft.OpenApi.Models.md#openapiformattypeconstants)
  -  Static Fields
     - string Byte
     - string Date
     - string DateTime
     - string Email
     - string Int32
     - string Int64
     - string Time
     - string Timestamp
     - string Uri
     - string Uuid
- [OpenApiMediaTypeExtensions](Microsoft.OpenApi.Models.md#openapimediatypeextensions)
  -  Static Methods
     - GetSchema(this IDictionary&lt;string, OpenApiMediaType&gt; content, string contentType = application/json)
- [OpenApiOperationExtensions](Microsoft.OpenApi.Models.md#openapioperationextensions)
  -  Static Methods
     - GetModelSchema(this OpenApiOperation openApiOperation)
     - GetOperationName(this OpenApiOperation openApiOperation)
     - HasDataTypeFromSystemCollectionGenericNamespace(this List&lt;OpenApiOperation&gt; apiOperations)
     - HasParametersOrRequestBody(this OpenApiOperation openApiOperation)
     - IsOperationReferencingSchema(this OpenApiOperation openApiOperation, string schemaKey)
- [OpenApiParameterExtensions](Microsoft.OpenApi.Models.md#openapiparameterextensions)
  -  Static Methods
     - GetAllFromHeader(this IList&lt;OpenApiParameter&gt; parameters)
     - GetAllFromQuery(this IList&lt;OpenApiParameter&gt; parameters)
     - GetAllFromRoute(this IList&lt;OpenApiParameter&gt; parameters)
     - HasFormatTypeFromDataAnnotationsNamespace(this IList&lt;OpenApiParameter&gt; parameters)
     - HasFormatTypeFromSystemNamespace(this IList&lt;OpenApiParameter&gt; parameters)
     - HasFormatTypeOfByte(this IList&lt;OpenApiParameter&gt; parameters)
     - HasFormatTypeOfDate(this IList&lt;OpenApiParameter&gt; parameters)
     - HasFormatTypeOfDateTime(this IList&lt;OpenApiParameter&gt; parameters)
     - HasFormatTypeOfEmail(this IList&lt;OpenApiParameter&gt; parameters)
     - HasFormatTypeOfInt32(this IList&lt;OpenApiParameter&gt; parameters)
     - HasFormatTypeOfInt64(this IList&lt;OpenApiParameter&gt; parameters)
     - HasFormatTypeOfTime(this IList&lt;OpenApiParameter&gt; parameters)
     - HasFormatTypeOfTimestamp(this IList&lt;OpenApiParameter&gt; parameters)
     - HasFormatTypeOfUri(this IList&lt;OpenApiParameter&gt; parameters)
     - HasFormatTypeOfUuid(this IList&lt;OpenApiParameter&gt; parameters)
- [OpenApiPathItemExtensions](Microsoft.OpenApi.Models.md#openapipathitemextensions)
  -  Static Methods
     - HasParameters(this OpenApiPathItem openApiOperation)
     - IsPathStartingSegmentName(this KeyValuePair&lt;string, OpenApiPathItem&gt; urlPath, string segmentName)
- [OpenApiPathsExtensions](Microsoft.OpenApi.Models.md#openapipathsextensions)
  -  Static Methods
     - GetPathsStartingWithSegmentName(this OpenApiPaths urlPaths, string segmentName)
- [OpenApiResponsesExtensions](Microsoft.OpenApi.Models.md#openapiresponsesextensions)
  -  Static Methods
     - GetHttpStatusCodes(this OpenApiResponses responses)
     - GetModelNameForStatusCode(this OpenApiResponses responses, HttpStatusCode httpStatusCode)
     - GetSchemaForStatusCode(this OpenApiResponses responses, HttpStatusCode httpStatusCode, string contentType = application/json)
     - HasSchemaTypeOfArray(this OpenApiResponses responses)
     - HasSchemaTypeOfHttpStatusCodeUsingAspNetCoreHttp(this OpenApiResponses responses)
     - HasSchemaTypeOfHttpStatusCodeUsingSystemNet(this OpenApiResponses responses)
     - IsSchemaTypeArrayForStatusCode(this OpenApiResponses responses, HttpStatusCode httpStatusCode)
     - IsSchemaTypePaginationForStatusCode(this OpenApiResponses responses, HttpStatusCode httpStatusCode)
     - IsSchemaTypeProblemDetailsForStatusCode(this OpenApiResponses responses, HttpStatusCode httpStatusCode)
- [OpenApiSchemaExtensions](Microsoft.OpenApi.Models.md#openapischemaextensions)
  -  Static Methods
     - GetDataType(this OpenApiSchema schema)
     - GetEnumSchema(this OpenApiSchema schema)
     - GetModelName(this OpenApiSchema schema, bool ensureFirstCharacterToUpper = True)
     - GetModelType(this OpenApiSchema schema)
     - GetTitleFromPropertyByPropertyKey(this OpenApiSchema schema, string propertyKey)
     - HasAnyProperties(this OpenApiSchema schema)
     - HasDataTypeFromSystemCollectionGenericNamespace(this IList&lt;OpenApiSchema&gt; schemas)
     - HasDataTypeFromSystemCollectionGenericNamespace(this OpenApiSchema schema)
     - HasDataTypeOfList(this IList&lt;OpenApiSchema&gt; schemas)
     - HasFormatType(this OpenApiSchema schema)
     - HasFormatTypeFromDataAnnotationsNamespace(this IList&lt;OpenApiSchema&gt; schemas)
     - HasFormatTypeFromDataAnnotationsNamespace(this OpenApiSchema schema)
     - HasFormatTypeFromSystemNamespace(this IList&lt;OpenApiSchema&gt; schemas)
     - HasFormatTypeFromSystemNamespace(this OpenApiSchema schema)
     - HasFormatTypeOfByte(this IList&lt;OpenApiSchema&gt; schemas)
     - HasFormatTypeOfDate(this IList&lt;OpenApiSchema&gt; schemas)
     - HasFormatTypeOfDateTime(this IList&lt;OpenApiSchema&gt; schemas)
     - HasFormatTypeOfEmail(this IList&lt;OpenApiSchema&gt; schemas)
     - HasFormatTypeOfInt32(this IList&lt;OpenApiSchema&gt; schemas)
     - HasFormatTypeOfInt64(this IList&lt;OpenApiSchema&gt; schemas)
     - HasFormatTypeOfTime(this IList&lt;OpenApiSchema&gt; schemas)
     - HasFormatTypeOfTimestamp(this IList&lt;OpenApiSchema&gt; schemas)
     - HasFormatTypeOfUri(this IList&lt;OpenApiSchema&gt; schemas)
     - HasFormatTypeOfUuid(this IList&lt;OpenApiSchema&gt; schemas)
     - IsArrayReferenceTypeDeclared(this OpenApiSchema schema)
     - IsDataTypeOfList(this OpenApiSchema schema)
     - IsFormatTypeOfByte(this OpenApiSchema schema)
     - IsFormatTypeOfDate(this OpenApiSchema schema)
     - IsFormatTypeOfDateTime(this OpenApiSchema schema)
     - IsFormatTypeOfEmail(this OpenApiSchema schema)
     - IsFormatTypeOfInt32(this OpenApiSchema schema)
     - IsFormatTypeOfInt64(this OpenApiSchema schema)
     - IsFormatTypeOfTime(this OpenApiSchema schema)
     - IsFormatTypeOfTimestamp(this OpenApiSchema schema)
     - IsFormatTypeOfUri(this OpenApiSchema schema)
     - IsFormatTypeOfUuid(this OpenApiSchema schema)
     - IsItemsOfSimpleDataType(this OpenApiSchema schema)
     - IsObjectReferenceTypeDeclared(this OpenApiSchema schema)
     - IsSchemaEnum(this OpenApiSchema schema)
     - IsSchemaEnumOrPropertyEnum(this OpenApiSchema schema)
     - IsSharedContract(this OpenApiSchema schema, OpenApiComponents openApiComponents)
     - IsSimpleDataType(this OpenApiSchema schema)

<hr /><div style='text-align: right'><i>Generated by MarkdownCodeDoc version 1.2</i></div>

