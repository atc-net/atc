<div style='text-align: right'>
[References](Index.md)
</div>

# References extended

## [Atc.Rest.Extended](Atc.Rest.Extended.md)

- [AtcRestExtendedAssemblyTypeInitializer](Atc.Rest.Extended.md#atcrestextendedassemblytypeinitializer)

## [Atc.Rest.Extended.Extensions](Atc.Rest.Extended.Extensions.md)

- [OperationFilterContextExtensions](Atc.Rest.Extended.Extensions.md#operationfiltercontextextensions)
  -  Static Methods
     - GetControllerAndActionAttributes(this OperationFilterContext context)

## [Atc.Rest.Extended.Filters](Atc.Rest.Extended.Filters.md)

- [ApiVersionDocumentFilter](Atc.Rest.Extended.Filters.md#apiversiondocumentfilter)
  -  Methods
     - Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
- [ApiVersionOperationFilter](Atc.Rest.Extended.Filters.md#apiversionoperationfilter)
  -  Methods
     - Apply(OpenApiOperation operation, OperationFilterContext context)
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
     - Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)

## [Atc.Rest.Extended.Options](Atc.Rest.Extended.Options.md)

- [ConfigureApiVersioningOptions](Atc.Rest.Extended.Options.md#configureapiversioningoptions)
  -  Methods
     - Configure(ApiVersioningOptions options)
- [ConfigureAuthorizationOptions](Atc.Rest.Extended.Options.md#configureauthorizationoptions)
  -  Methods
     - PostConfigure(string name, AuthenticationOptions options)
     - PostConfigure(string name, JwtBearerOptions options)
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
     - UseOpenApiSpec(this IApplicationBuilder app, IWebHostEnvironment env, RestApiExtendedOptions restApiOptions)
     - UseOpenApiSpec(this IApplicationBuilder app, IWebHostEnvironment env)
- [RestApiExtendedBuilderExtensions](Microsoft.AspNetCore.Builder.md#restapiextendedbuilderextensions)
  -  Static Methods
     - ConfigureRestApi(this IApplicationBuilder app, IWebHostEnvironment env, RestApiExtendedOptions restApiOptions, Action&lt;IApplicationBuilder&gt; setupAction)
     - ConfigureRestApi(this IApplicationBuilder app, IWebHostEnvironment env, RestApiExtendedOptions restApiOptions)
     - ConfigureRestApi(this IApplicationBuilder app, IWebHostEnvironment env)

## [Microsoft.Extensions.DependencyInjection](Microsoft.Extensions.DependencyInjection.md)

- [FluentValidationExtensions](Microsoft.Extensions.DependencyInjection.md#fluentvalidationextensions)
  -  Static Methods
     - AddFluentValidation(this IServiceCollection services, bool useAutoRegistrateServices, List&lt;AssemblyPairOptions&gt; assemblyPairs)
- [RestApiExtendedExtensions](Microsoft.Extensions.DependencyInjection.md#restapiextendedextensions)
  -  Static Methods
     - AddRestApi(this IServiceCollection services, Action&lt;IMvcBuilder&gt; setupMvcAction, RestApiExtendedOptions restApiOptions, IConfiguration configuration)
     - AddRestApi(this IServiceCollection services, RestApiExtendedOptions restApiOptions, IConfiguration configuration)
     - AddRestApi(this IServiceCollection services)

## [Swashbuckle.AspNetCore.SwaggerGen](Swashbuckle.AspNetCore.SwaggerGen.md)

- [SwaggerGenOptionsExtensions](Swashbuckle.AspNetCore.SwaggerGen.md#swaggergenoptionsextensions)
  -  Static Methods
     - ApplyApiVersioningFilters(this SwaggerGenOptions options)
     - DefaultResponseForSecuredOperations(this SwaggerGenOptions options)
     - TreatBadRequestAsDefaultResponse(this SwaggerGenOptions options)

## [System.Reflection](System.Reflection.md)

- [AssemblyExtensions](System.Reflection.md#assemblyextensions)
  -  Static Methods
     - GetValidationTypes(this Assembly assembly)

<hr /><div style='text-align: right'><i>Generated by MarkdownCodeDoc version 1.2</i></div>
