<div style='text-align: right'>

[References](Index.md)

</div>


# References extended

## [Atc.Rest](Atc.Rest.md)

- [AtcRestAssemblyTypeInitializer](Atc.Rest.md#atcrestassemblytypeinitializer)
- [IRequestContext](Atc.Rest.md#irequestcontext)
  -  Properties
     - CallingIdentity
     - OnBehalfOfIdentity
     - RequestId
     - CorrelationId
     - RequestCancellationToken
- [RequestContext](Atc.Rest.md#requestcontext)
  -  Properties
     - CallingIdentity
     - OnBehalfOfIdentity
     - RequestId
     - CorrelationId
     - RequestCancellationToken

## [Atc.Rest.Extensions](Atc.Rest.Extensions.md)

- [EndpointRouteBuilderExtensions](Atc.Rest.Extensions.md#endpointroutebuilderextensions)
  -  Static Methods
     - MapApiSpecificationEndpoint(this IEndpointRouteBuilder endpoints, List&lt;AssemblyPairOptions&gt; assemblyPairs)

## [Atc.Rest.Middleware](Atc.Rest.Middleware.md)

- [ExceptionTelemetryMiddleware](Atc.Rest.Middleware.md#exceptiontelemetrymiddleware)
  -  Methods
     - Invoke(HttpContext context)
- [KeepAliveMiddleware](Atc.Rest.Middleware.md#keepalivemiddleware)
  -  Methods
     - Invoke(HttpContext context)
- [RequestCorrelationMiddleware](Atc.Rest.Middleware.md#requestcorrelationmiddleware)
  -  Methods
     - Invoke(HttpContext context)

## [Atc.Rest.Options](Atc.Rest.Options.md)

- [AssemblyPairOptions](Atc.Rest.Options.md#assemblypairoptions)
  -  Properties
     - ApiAssembly
     - DomainAssembly
  -  Methods
     - ToString()
- [ConfigureApiAnonymousDevelopmentOptions](Atc.Rest.Options.md#configureapianonymousdevelopmentoptions)
  -  Methods
     - Configure(MvcOptions options)
- [ConfigureApiBehaviorOptions](Atc.Rest.Options.md#configureapibehavioroptions)
  -  Methods
     - Configure(ApiBehaviorOptions options)
- [RestApiOptions](Atc.Rest.Options.md#restapioptions)
  -  Properties
     - AllowAnonymousAccessForDevelopment
     - UseApplicationInsights
     - UseAutoRegistrateServices
     - UseEnumAsStringInSerialization
     - ErrorHandlingExceptionFilter
     - UseRequireHttpsPermanent
     - UseJsonSerializerOptionsIgnoreNullValues
     - JsonSerializerCasingStyle
     - UseValidateServiceRegistrations
     - AssemblyPairs
  -  Methods
     - AddAssemblyPairs(Assembly apiAssembly, Assembly domainAssembly)
- [RestApiOptionsErrorHandlingExceptionFilter](Atc.Rest.Options.md#restapioptionserrorhandlingexceptionfilter)
  -  Properties
     - Enable
     - UseProblemDetailsAsResponseBody
     - IncludeExceptionDetails

## [Microsoft.ApplicationInsights.Extensibility](Microsoft.ApplicationInsights.Extensibility.md)

- [Accept4xxResponseAsSuccessInitializer](Microsoft.ApplicationInsights.Extensibility.md#accept4xxresponseassuccessinitializer)
  -  Methods
     - Initialize(ITelemetry telemetry)
- [CallingIdentityTelemetryInitializer](Microsoft.ApplicationInsights.Extensibility.md#callingidentitytelemetryinitializer)
  -  Methods
     - Initialize(ITelemetry telemetry)

## [Microsoft.AspNetCore.Builder](Microsoft.AspNetCore.Builder.md)

- [RestApiBuilderExtensions](Microsoft.AspNetCore.Builder.md#restapibuilderextensions)
  -  Static Methods
     - UseRestApi(this IApplicationBuilder app, IWebHostEnvironment env)
     - UseRestApi(this IApplicationBuilder app, IWebHostEnvironment env, RestApiOptions restApiOptions)
     - UseRestApi(this IApplicationBuilder app, IWebHostEnvironment env, RestApiOptions restApiOptions, Action&lt;IApplicationBuilder&gt; setupAction)

## [Microsoft.AspNetCore.Http](Microsoft.AspNetCore.Http.md)

- [AnonymousAccessExtensions](Microsoft.AspNetCore.Http.md#anonymousaccessextensions)
  -  Static Methods
     - AddAnonymousAccessForDevelopment(this IServiceCollection services)
- [HeaderDictionaryExtensions](Microsoft.AspNetCore.Http.md#headerdictionaryextensions)
  -  Static Methods
     - GetOrAddCorrelationId(this IHeaderDictionary headers)
     - AddCorrelationId(this IHeaderDictionary headers, string correlationId)
     - GetOrAddRequestId(this IHeaderDictionary headers)
     - GetCallingOnBehalfOfIdentity(this IHeaderDictionary headers)
- [HttpContextExtensions](Microsoft.AspNetCore.Http.md#httpcontextextensions)
  -  Static Methods
     - GetCorrelationId(this HttpContext context)
     - GetRequestId(this HttpContext context)
- [WellKnownHttpHeaders](Microsoft.AspNetCore.Http.md#wellknownhttpheaders)
  -  Static Fields
     - string CorrelationId
     - string RequestId
     - string OnBehalfOf
     - string CallingIdentity
     - string MaxItemCount
     - string Continuation
     - string Filename
     - string ValueSeparator
     - string IfMatch
     - string IfNoneMatch
     - string ETag

## [Microsoft.AspNetCore.Mvc.Filters](Microsoft.AspNetCore.Mvc.Filters.md)

- [ErrorHandlingExceptionFilterAttribute](Microsoft.AspNetCore.Mvc.Filters.md#errorhandlingexceptionfilterattribute)
  -  Methods
     - OnException(ExceptionContext context)

## [Microsoft.Extensions.DependencyInjection](Microsoft.Extensions.DependencyInjection.md)

- [ApplicationInsightsExtensions](Microsoft.Extensions.DependencyInjection.md#applicationinsightsextensions)
  -  Static Methods
     - AddCallingIdentityTelemetryInitializer(this IServiceCollection services)
- [RestApiExtensions](Microsoft.Extensions.DependencyInjection.md#restapiextensions)
  -  Static Methods
     - AddRestApi(this IServiceCollection services)
     - AddRestApi(this IServiceCollection services, RestApiOptions restApiOptions)
     - AddRestApi(this IServiceCollection services, Action&lt;IMvcBuilder&gt; setupMvcAction, RestApiOptions restApiOptions)
- [ServiceCollectionExtensions](Microsoft.Extensions.DependencyInjection.md#servicecollectionextensions)
  -  Static Methods
     - AutoRegistrateServices(this IServiceCollection services, Assembly apiAssembly, Assembly domainAssembly)
     - ValidateServiceRegistrations(this IServiceCollection services, Assembly apiAssembly)

## [System](System.md)

- [TypeExtensions](System.md#typeextensions)
  -  Static Methods
     - GetApiName(this Type type, bool removeLastVerb = False)

## [System.Reflection](System.Reflection.md)

- [AssemblyExtensions](System.Reflection.md#assemblyextensions)
  -  Static Methods
     - GetApiName(this Assembly assembly, bool removeLastVerb = False)

<hr /><div style='text-align: right'><i>Generated by MarkdownCodeDoc version 1.2</i></div>

