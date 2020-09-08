[![NuGet](https://img.shields.io/nuget/v/Atc.OpenApi.svg?style=flat-square)](http://www.nuget.org/packages/Atc.OpenApi)
[![NuGet](https://img.shields.io/nuget/dt/Atc.OpenApi.svg?style=flat-square)](http://www.nuget.org/packages/Atc.OpenApi)

<div style='text-align: right'>

[References](Index.md)

</div>


# References extended

## [Atc.OpenApi](Atc.OpenApi.md)

- [AtcOpenApiAssemblyTypeInitializer](Atc.OpenApi.md#atcopenapiassemblytypeinitializer)

## [Microsoft.OpenApi.Models](Microsoft.OpenApi.Models.md)

- [NameConstants](Microsoft.OpenApi.Models.md#nameconstants)
  -  Static Fields
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
     - string Uuid
     - string Date
     - string Time
     - string Timestamp
     - string DateTime
     - string Byte
     - string Int32
     - string Int64
     - string Email
     - string Uri
- [OpenApiOperationExtensions](Microsoft.OpenApi.Models.md#openapioperationextensions)
  -  Static Methods
     - GetOperationName(this OpenApiOperation openApiOperation)
     - HasParametersOrRequestBody(this OpenApiOperation openApiOperation)
     - IsOperationReferencingSchema(this OpenApiOperation openApiOperation, string schemaKey)
     - HasDataTypeFromSystemCollectionGenericNamespace(this List&lt;OpenApiOperation&gt; apiOperations)
- [OpenApiParameterExtensions](Microsoft.OpenApi.Models.md#openapiparameterextensions)
  -  Static Methods
     - HasFormatTypeOfUuid(this IList&lt;OpenApiParameter&gt; parameters)
     - HasFormatTypeOfDate(this IList&lt;OpenApiParameter&gt; parameters)
     - HasFormatTypeOfTime(this IList&lt;OpenApiParameter&gt; parameters)
     - HasFormatTypeOfTimestamp(this IList&lt;OpenApiParameter&gt; parameters)
     - HasFormatTypeOfDateTime(this IList&lt;OpenApiParameter&gt; parameters)
     - HasFormatTypeOfEmail(this IList&lt;OpenApiParameter&gt; parameters)
     - HasFormatTypeOfUri(this IList&lt;OpenApiParameter&gt; parameters)
     - HasFormatTypeOfByte(this IList&lt;OpenApiParameter&gt; parameters)
     - HasFormatTypeFromSystemNamespace(this IList&lt;OpenApiParameter&gt; parameters)
     - HasFormatTypeFromDataAnnotationsNamespace(this IList&lt;OpenApiParameter&gt; parameters)
- [OpenApiPathItemExtensions](Microsoft.OpenApi.Models.md#openapipathitemextensions)
  -  Static Methods
     - IsPathStartingSegmentName(this KeyValuePair&lt;string, OpenApiPathItem&gt; urlPath, string segmentName)
     - HasParameters(this OpenApiPathItem openApiOperation)
- [OpenApiPathsExtensions](Microsoft.OpenApi.Models.md#openapipathsextensions)
  -  Static Methods
     - GetPathsStartingWithSegmentName(this OpenApiPaths paths, string segmentName)
- [OpenApiResponsesExtensions](Microsoft.OpenApi.Models.md#openapiresponsesextensions)
  -  Static Methods
     - GetHttpStatusCodes(this OpenApiResponses responses)
     - HasSchemaTypeOfArray(this OpenApiResponses responses)
     - HasSchemaTypeOfHttpStatusCodeUsingSystemNet(this OpenApiResponses responses)
     - GetSchemaForStatusCode(this OpenApiResponses responses, HttpStatusCode httpStatusCode)
     - GetModelNameForStatusCode(this OpenApiResponses responses, HttpStatusCode httpStatusCode)
     - IsSchemaTypeArrayForStatusCode(this OpenApiResponses responses, HttpStatusCode httpStatusCode)
     - IsSchemaTypePaginationForStatusCode(this OpenApiResponses responses, HttpStatusCode httpStatusCode)
     - IsSchemaTypeProblemDetailsForStatusCode(this OpenApiResponses responses, HttpStatusCode httpStatusCode)
- [OpenApiSchemaExtensions](Microsoft.OpenApi.Models.md#openapischemaextensions)
  -  Static Methods
     - HasDataTypeOfList(this IList&lt;OpenApiSchema&gt; schemas)
     - HasFormatTypeOfUuid(this IList&lt;OpenApiSchema&gt; schemas)
     - HasFormatTypeOfDate(this IList&lt;OpenApiSchema&gt; schemas)
     - HasFormatTypeOfTime(this IList&lt;OpenApiSchema&gt; schemas)
     - HasFormatTypeOfTimestamp(this IList&lt;OpenApiSchema&gt; schemas)
     - HasFormatTypeOfDateTime(this IList&lt;OpenApiSchema&gt; schemas)
     - HasFormatTypeOfByte(this IList&lt;OpenApiSchema&gt; schemas)
     - HasFormatTypeOfInt32(this IList&lt;OpenApiSchema&gt; schemas)
     - HasFormatTypeOfInt64(this IList&lt;OpenApiSchema&gt; schemas)
     - HasFormatTypeOfEmail(this IList&lt;OpenApiSchema&gt; schemas)
     - HasFormatTypeOfUri(this IList&lt;OpenApiSchema&gt; schemas)
     - HasFormatTypeFromSystemNamespace(this IList&lt;OpenApiSchema&gt; schemas)
     - IsSimpleDataType(this OpenApiSchema schema)
     - IsReferenceTypeDeclared(this OpenApiSchema schema)
     - IsItemsOfSimpleDataType(this OpenApiSchema schema)
     - HasDataTypeFromSystemCollectionGenericNamespace(this IList&lt;OpenApiSchema&gt; schemas)
     - HasFormatTypeFromDataAnnotationsNamespace(this IList&lt;OpenApiSchema&gt; schemas)
     - GetModelName(this OpenApiSchema schema)
     - GetDataType(this OpenApiSchema schema)
     - GetTitleFromPropertyByPropertyKey(this OpenApiSchema schema, string propertyKey)
     - IsHttpStatusCodeModelReference(this OpenApiSchema schema)
     - IsSchemaEnum(this OpenApiSchema schema)
     - IsSchemaEnumOrPropertyEnum(this OpenApiSchema schema)
     - IsSharedContract(this OpenApiSchema schema, OpenApiComponents openApiComponents)
     - GetEnumSchema(this OpenApiSchema schema)

<hr /><div style='text-align: right'><i>Generated by MarkdownCodeDoc version 1.2</i></div>

