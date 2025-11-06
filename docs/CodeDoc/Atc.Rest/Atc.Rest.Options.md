<div style='text-align: right'>

[References](Index.md)&nbsp;&nbsp;-&nbsp;&nbsp;[References extended](IndexExtended.md)
</div>

# Atc.Rest.Options

<br />

## AssemblyPairOptions
Represents a pair of assemblies for API and domain layer service registration.
><b>Remarks:</b> This class is used to group an API assembly (containing interfaces) with its corresponding domain assembly (containing implementations) for automatic service registration. It also facilitates loading embedded OpenAPI specification resources.

>```csharp
>public class AssemblyPairOptions
>```

### Properties

#### ApiAssembly
>```csharp
>ApiAssembly
>```
><b>Summary:</b> Gets the API assembly containing interfaces and API specifications.
#### DomainAssembly
>```csharp
>DomainAssembly
>```
><b>Summary:</b> Gets the domain assembly containing service implementations.
### Methods

#### ToString
>```csharp
>string ToString()
>```

<br />

## AuthorizationOptions
Copy and fill out the AzureAd section into the project User Secrets.
><b>Code usage:</b>
>```csharp
>{
>"Authorization": {
>/*
>This will be used to set the Authority on the JWT bearer options
>- 'https://login.microsoftonline.com' (For Azure AD)
>- 'https://adfs1.some.organization.com' (For on-prem ADFS)
>*/
>"Instance": "https://login.microsoftonline.com",
>"ClientId": "[Application ID of the Azure AD App Registration]",
>/*
>You need specify the TenantId only if you want to accept access tokens from a single tenant
>(line-of-business app).
>Otherwise, you can leave them set to common.
>This can be:
>- A GUID (Tenant ID = Directory ID)
>- 'common' (any organization and personal accounts)
>- 'organizations' (any organization)
>- 'consumers' (Microsoft personal accounts)
>- 'adfs' (For on-prem ADFS)
>*/
>"TenantId": "common",
>"Audience": "[App Identifier URI of the Azure AD App Registration]"
>"Issuer": "[The token iss claim also specified as the access_token_issuer from the OpenID configuration]"
>"ValidAudiences": ["A", "collection", "of", "app", "identifier", "URIs"]
>}
>}
>```

>```csharp
>public class AuthorizationOptions
>```

### Static Fields

#### ConfigurationSectionName
>```csharp
>string ConfigurationSectionName
>```
### Properties

#### Audience
>```csharp
>Audience
>```
><b>Summary:</b> Gets or sets the expected audience for token validation (typically the App ID URI).
#### ClientId
>```csharp
>ClientId
>```
><b>Summary:</b> Gets or sets the Azure AD Application (client) ID.
#### Instance
>```csharp
>Instance
>```
><b>Summary:</b> Gets or sets the authentication authority instance URL (e.g., https://login.microsoftonline.com for Azure AD).
#### Issuer
>```csharp
>Issuer
>```
><b>Summary:</b> Gets or sets the expected token issuer for validation.
#### TenantId
>```csharp
>TenantId
>```
><b>Summary:</b> Gets or sets the Azure AD Tenant ID or special values (common, organizations, consumers, adfs).
#### ValidAudiences
>```csharp
>ValidAudiences
>```
><b>Summary:</b> Gets or sets a collection of valid audiences for token validation.
#### ValidIssuers
>```csharp
>ValidIssuers
>```
><b>Summary:</b> Gets or sets a collection of valid issuers for token validation.
### Methods

#### IsSecurityEnabled
>```csharp
>bool IsSecurityEnabled()
>```
><b>Summary:</b> Determines whether any security settings are configured.
>
><b>Returns:</b> True if at least one security setting is configured; otherwise, false.

<br />

## ConfigureApiBehaviorOptions
Configures ASP.NET Core API behavior options for model validation and error responses.
><b>Remarks:</b> This class customizes the default API behavior to: <list type="bullet"><item>Suppress automatic binding source inference for better control</item><item>Return ValidationProblemDetails for invalid model state</item><item>Include correlation ID in validation error responses</item><item>Track validation errors in Application Insights telemetry</item></list>

>```csharp
>public class ConfigureApiBehaviorOptions : IConfigureOptions<ApiBehaviorOptions>
>```

### Methods

#### Configure
>```csharp
>void Configure(ApiBehaviorOptions options)
>```
><b>Summary:</b> Configures the API behavior options.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`options`&nbsp;&nbsp;-&nbsp;&nbsp;The API behavior options to configure.<br />

<br />

## RequestResponseLoggerOptions

>```csharp
>public class RequestResponseLoggerOptions
>```

### Properties

#### DefaultLogLevel
>```csharp
>DefaultLogLevel
>```
><b>Summary:</b> Gets or sets the default log level for the logger.
#### IncludeRequestHeaderParameters
>```csharp
>IncludeRequestHeaderParameters
>```
><b>Summary:</b> Gets or sets a value indicating whether request header parameters should be included in logs.
#### IncludeRequestQueryParameters
>```csharp
>IncludeRequestQueryParameters
>```
><b>Summary:</b> Gets or sets a value indicating whether request query parameters should be included in logs.
#### IncludeResponseBody
>```csharp
>IncludeResponseBody
>```
><b>Summary:</b> Gets or sets a value indicating whether the response body should be logged.
>
><b>Remarks:</b> Logging the response body can be useful for debugging responses but may increase the size of log files.
#### IncludeResponseHeaderParameters
>```csharp
>IncludeResponseHeaderParameters
>```
><b>Summary:</b> Gets or sets a value indicating whether response header parameters should be included in logs.
#### SkipSignalrRequests
>```csharp
>SkipSignalrRequests
>```
><b>Summary:</b> Gets or sets a value indicating whether SignalR requests should be exempt from logging.
>
><b>Remarks:</b> Skipping SignalR requests can reduce noise in logs from real-time communications.
#### SkipSwaggerRequests
>```csharp
>SkipSwaggerRequests
>```
><b>Summary:</b> Gets or sets a value indicating whether Swagger requests should be exempt from logging.
>
><b>Remarks:</b> Skipping Swagger requests can reduce noise in logs from automated or development-time API exploration.
### Methods

#### ToString
>```csharp
>string ToString()
>```

<br />

## RestApiOptions
Configuration options for the REST API framework.
><b>Remarks:</b> This class provides comprehensive configuration for REST API services including: <list type="bullet"><item>Authentication and authorization</item><item>Application Insights telemetry</item><item>Service auto-registration</item><item>JSON serialization behavior</item><item>Error handling and logging</item><item>HTTPS requirements</item></list>

>```csharp
>public class RestApiOptions
>```

### Properties

#### AllowAnonymousAccessForDevelopment
>```csharp
>AllowAnonymousAccessForDevelopment
>```
><b>Summary:</b> Gets or sets a value indicating whether to allow anonymous access in Development environment.
#### AssemblyPairs
>```csharp
>AssemblyPairs
>```
><b>Summary:</b> Gets or sets the collection of assembly pairs for service registration and API specification loading.
#### Authorization
>```csharp
>Authorization
>```
><b>Summary:</b> Gets or sets the authorization configuration for JWT authentication.
#### EnableRequestResponseLogger
>```csharp
>EnableRequestResponseLogger
>```
><b>Summary:</b> Gets or sets a value indicating whether to enable request/response logging middleware.
#### ErrorHandlingExceptionFilter
>```csharp
>ErrorHandlingExceptionFilter
>```
><b>Summary:</b> Gets or sets the error handling exception filter configuration.
#### JsonSerializerCasingStyle
>```csharp
>JsonSerializerCasingStyle
>```
><b>Summary:</b> Gets or sets the JSON property naming convention (CamelCase or PascalCase).
#### RequestResponseLoggerOptions
>```csharp
>RequestResponseLoggerOptions
>```
><b>Summary:</b> Gets or sets the request/response logger configuration options.
#### UseApplicationInsights
>```csharp
>UseApplicationInsights
>```
><b>Summary:</b> Gets or sets a value indicating whether to enable Application Insights telemetry.
#### UseAutoRegistrateServices
>```csharp
>UseAutoRegistrateServices
>```
><b>Summary:</b> Gets or sets a value indicating whether to automatically register services from assembly pairs.
#### UseEnumAsStringInSerialization
>```csharp
>UseEnumAsStringInSerialization
>```
><b>Summary:</b> Gets or sets a value indicating whether to serialize enums as strings instead of integers.
#### UseHttpContextAccessor
>```csharp
>UseHttpContextAccessor
>```
><b>Summary:</b> Gets or sets a value indicating whether to register `Microsoft.AspNetCore.Http.IHttpContextAccessor` for accessing HTTP context.
#### UseJsonSerializerOptionsIgnoreNullValues
>```csharp
>UseJsonSerializerOptionsIgnoreNullValues
>```
><b>Summary:</b> Gets or sets a value indicating whether to ignore null values during JSON serialization.
#### UseRequireHttpsPermanent
>```csharp
>UseRequireHttpsPermanent
>```
><b>Summary:</b> Gets or sets a value indicating whether to require HTTPS permanently (adds HSTS header).
#### UseValidateServiceRegistrations
>```csharp
>UseValidateServiceRegistrations
>```
><b>Summary:</b> Gets or sets a value indicating whether to validate that all interfaces in API assemblies are registered.
### Methods

#### AddAssemblyPairs
>```csharp
>void AddAssemblyPairs(Assembly apiAssembly, Assembly domainAssembly)
>```
><b>Summary:</b> Adds an assembly pair to the collection for service registration.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`apiAssembly`&nbsp;&nbsp;-&nbsp;&nbsp;The API assembly containing interfaces.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`domainAssembly`&nbsp;&nbsp;-&nbsp;&nbsp;The domain assembly containing implementations.<br />

<br />

## RestApiOptionsErrorHandlingExceptionFilter
Configuration options for the error handling exception filter.
><b>Remarks:</b> These settings control how unhandled exceptions are converted to HTTP error responses.

>```csharp
>public class RestApiOptionsErrorHandlingExceptionFilter
>```

### Properties

#### Enable
>```csharp
>Enable
>```
><b>Summary:</b> Gets or sets a value indicating whether to enable the error handling exception filter.
#### IncludeExceptionDetails
>```csharp
>IncludeExceptionDetails
>```
><b>Summary:</b> Gets or sets a value indicating whether to include exception details in error responses.
>
><b>Remarks:</b> When true, includes exception messages in the response. Set to false in production environments to avoid exposing internal implementation details.
#### UseProblemDetailsAsResponseBody
>```csharp
>UseProblemDetailsAsResponseBody
>```
><b>Summary:</b> Gets or sets a value indicating whether to format error responses as RFC 7807 ProblemDetails.
>
><b>Remarks:</b> When true, returns structured ProblemDetails JSON. When false, returns plain text error messages.
<hr /><div style='text-align: right'><i>Generated by MarkdownCodeDoc version 1.2</i></div>
