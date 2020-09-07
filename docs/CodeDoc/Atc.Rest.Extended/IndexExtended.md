<div style='text-align: right'>

[References](Index.md)

</div>


# References extended

## [Atc.Rest.Extended](Atc.Rest.Extended.md)

- [AtcRestExtendedAssemblyTypeInitializer](Atc.Rest.Extended.md#atcrestextendedassemblytypeinitializer)

## [Atc.Rest.Extended.Filters](Atc.Rest.Extended.Filters.md)

- [ApiVersionDocumentFilter](Atc.Rest.Extended.Filters.md#apiversiondocumentfilter)
  -  Methods
     - Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
- [ApiVersionOperationFilter](Atc.Rest.Extended.Filters.md#apiversionoperationfilter)
  -  Methods
     - Apply(OpenApiOperation operation, OperationFilterContext context)
     - ConfigureApiVersion(OpenApiParameter apiVersionParameter, OperationFilterContext context)
- [AuthorizeResponseOperationFilter](Atc.Rest.Extended.Filters.md#authorizeresponseoperationfilter)
  -  Methods
     - Apply(OpenApiOperation operation, OperationFilterContext context)
- [DefaultResponseOperationFilter](Atc.Rest.Extended.Filters.md#defaultresponseoperationfilter)
  -  Methods
     - Apply(OpenApiOperation operation, OperationFilterContext context)
- [SecurityRequirementsOperationFilter](Atc.Rest.Extended.Filters.md#securityrequirementsoperationfilter)
  -  Methods
     - Apply(OpenApiOperation operation, OperationFilterContext context)
- [SwaggerEnumDescriptionsDocumentFilter](Atc.Rest.Extended.Filters.md#swaggerenumdescriptionsdocumentfilter)
  -  Methods
     - Apply(OpenApiDocument document, DocumentFilterContext context)

## [Atc.Rest.Extended.Options](Atc.Rest.Extended.Options.md)

- [ConfigureApiVersioningOptions](Atc.Rest.Extended.Options.md#configureapiversioningoptions)
  -  Methods
     - Configure(ApiVersioningOptions options)
- [RestApiExtendedOptions](Atc.Rest.Extended.Options.md#restapiextendedoptions)
  -  Properties
     - UseApiVersioning
     - UseFluentValidation
     - UseOpenApiSpec

## [Atc.Rest.Extended.Versioning](Atc.Rest.Extended.Versioning.md)

- [ApiVersionConstants](Atc.Rest.Extended.Versioning.md#apiversionconstants)
  -  Static Fields
     - string ApiVersionHeaderParameter
     - string ApiVersionMediaTypeParameter
     - string ApiVersionQueryParameter
     - string ApiVersionQueryParameterShort
- [VersionErrorResponseProvider](Atc.Rest.Extended.Versioning.md#versionerrorresponseprovider)
  -  Methods
     - CreateResponse(ErrorResponseContext context)

## [Microsoft.AspNetCore.Builder](Microsoft.AspNetCore.Builder.md)

- [OpenApiBuilderExtensions](Microsoft.AspNetCore.Builder.md#openapibuilderextensions)
  -  Static Methods
     - UseOpenApiSpec(this IApplicationBuilder app, IWebHostEnvironment env)
     - UseOpenApiSpec(this IApplicationBuilder app, IWebHostEnvironment env, RestApiExtendedOptions restApiOptions)
     - UseOpenApiSpec(this IApplicationBuilder app, IWebHostEnvironment env, RestApiExtendedOptions restApiOptions, Action&lt;SwaggerUIOptions&gt; setupAction)
- [RestApiExtendedBuilderExtensions](Microsoft.AspNetCore.Builder.md#restapiextendedbuilderextensions)
  -  Static Methods
     - UseRestApi(this IApplicationBuilder app, IWebHostEnvironment env)
     - UseRestApi(this IApplicationBuilder app, IWebHostEnvironment env, RestApiExtendedOptions restApiOptions)
     - UseRestApi(this IApplicationBuilder app, IWebHostEnvironment env, RestApiExtendedOptions restApiOptions, Action&lt;IApplicationBuilder&gt; setupAction)

## [Microsoft.Extensions.DependencyInjection](Microsoft.Extensions.DependencyInjection.md)

- [FluentValidationExtensions](Microsoft.Extensions.DependencyInjection.md#fluentvalidationextensions)
  -  Static Methods
     - AddFluentValidation(this IServiceCollection services, bool useAutoRegistrateServices, List&lt;AssemblyPairOptions&gt; assemblyPairs)
- [OpenApiExtensions](Microsoft.Extensions.DependencyInjection.md#openapiextensions)
  -  Static Methods
     - AddOpenApiSpec(this IServiceCollection services)
     - AddOpenApiSpec(this IServiceCollection services, RestApiExtendedOptions restApiOptions)
     - AddOpenApiSpec(this IServiceCollection services, RestApiExtendedOptions restApiOptions, Action&lt;SwaggerGenOptions&gt; setupAction)
- [RestApiExtendedExtensions](Microsoft.Extensions.DependencyInjection.md#restapiextendedextensions)
  -  Static Methods
     - AddRestApi(this IServiceCollection services)
     - AddRestApi(this IServiceCollection services, RestApiExtendedOptions restApiOptions)
     - AddRestApi(this IServiceCollection services, Action&lt;IMvcBuilder&gt; setupMvcAction, RestApiExtendedOptions restApiOptions)

## [Swashbuckle.AspNetCore.SwaggerGen](Swashbuckle.AspNetCore.SwaggerGen.md)

- [SwaggerGenOptionsExtensions](Swashbuckle.AspNetCore.SwaggerGen.md#swaggergenoptionsextensions)
  -  Static Methods
     - ApplyApiVersioningFilters(this SwaggerGenOptions options)
     - ApplyApiVersioningSwaggerDocuments(this SwaggerGenOptions options, IServiceCollection services, string title)
     - DefaultResponseForSecuredOperations(this SwaggerGenOptions options)
     - TreatBadRequestAsDefaultResponse(this SwaggerGenOptions options)

## [System.Reflection](System.Reflection.md)

- [AssemblyExtensions](System.Reflection.md#assemblyextensions)
  -  Static Methods
     - GetValidationTypes(this Assembly assembly)

<hr /><div style='text-align: right'><i>Generated by MarkdownCodeDoc version 1.2</i></div>

