<div style='text-align: right'>

[References](Index.md)&nbsp;&nbsp;-&nbsp;&nbsp;[References extended](IndexExtended.md)
</div>

# Atc.Rest.Options

<br />

## AssemblyPairOptions

>```csharp
>public class AssemblyPairOptions
>```

### Properties

#### ApiAssembly
>```csharp
>ApiAssembly
>```
#### DomainAssembly
>```csharp
>DomainAssembly
>```
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
#### ClientId
>```csharp
>ClientId
>```
#### Instance
>```csharp
>Instance
>```
#### Issuer
>```csharp
>Issuer
>```
#### TenantId
>```csharp
>TenantId
>```
#### ValidAudiences
>```csharp
>ValidAudiences
>```
#### ValidIssuers
>```csharp
>ValidIssuers
>```
### Methods

#### IsSecurityEnabled
>```csharp
>bool IsSecurityEnabled()
>```

<br />

## ConfigureApiBehaviorOptions

>```csharp
>public class ConfigureApiBehaviorOptions : IConfigureOptions<ApiBehaviorOptions>
>```

### Methods

#### Configure
>```csharp
>void Configure(ApiBehaviorOptions options)
>```

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

>```csharp
>public class RestApiOptions
>```

### Properties

#### AllowAnonymousAccessForDevelopment
>```csharp
>AllowAnonymousAccessForDevelopment
>```
#### AssemblyPairs
>```csharp
>AssemblyPairs
>```
#### Authorization
>```csharp
>Authorization
>```
#### EnableRequestResponseLogger
>```csharp
>EnableRequestResponseLogger
>```
#### ErrorHandlingExceptionFilter
>```csharp
>ErrorHandlingExceptionFilter
>```
#### JsonSerializerCasingStyle
>```csharp
>JsonSerializerCasingStyle
>```
#### RequestResponseLoggerOptions
>```csharp
>RequestResponseLoggerOptions
>```
#### UseApplicationInsights
>```csharp
>UseApplicationInsights
>```
#### UseAutoRegistrateServices
>```csharp
>UseAutoRegistrateServices
>```
#### UseEnumAsStringInSerialization
>```csharp
>UseEnumAsStringInSerialization
>```
#### UseHttpContextAccessor
>```csharp
>UseHttpContextAccessor
>```
#### UseJsonSerializerOptionsIgnoreNullValues
>```csharp
>UseJsonSerializerOptionsIgnoreNullValues
>```
#### UseRequireHttpsPermanent
>```csharp
>UseRequireHttpsPermanent
>```
#### UseValidateServiceRegistrations
>```csharp
>UseValidateServiceRegistrations
>```
### Methods

#### AddAssemblyPairs
>```csharp
>void AddAssemblyPairs(Assembly apiAssembly, Assembly domainAssembly)
>```

<br />

## RestApiOptionsErrorHandlingExceptionFilter

>```csharp
>public class RestApiOptionsErrorHandlingExceptionFilter
>```

### Properties

#### Enable
>```csharp
>Enable
>```
#### IncludeExceptionDetails
>```csharp
>IncludeExceptionDetails
>```
#### UseProblemDetailsAsResponseBody
>```csharp
>UseProblemDetailsAsResponseBody
>```
<hr /><div style='text-align: right'><i>Generated by MarkdownCodeDoc version 1.2</i></div>
