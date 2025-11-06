<div style='text-align: right'>

[References](Index.md)&nbsp;&nbsp;-&nbsp;&nbsp;[References extended](IndexExtended.md)
</div>

# Microsoft.AspNetCore.Http

<br />

## AnonymousAccessExtensions
Extension methods for configuring anonymous access in development environments.

>```csharp
>public static class AnonymousAccessExtensions
>```

### Static Methods

#### AddAnonymousAccessForDevelopment
>```csharp
>IServiceCollection AddAnonymousAccessForDevelopment(this IServiceCollection services)
>```
><b>Summary:</b> Registers an authorization handler that allows anonymous access to all endpoints in Development mode.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`services`&nbsp;&nbsp;-&nbsp;&nbsp;The service collection.<br />
>
><b>Returns:</b> The service collection for method chaining.

<br />

## FormFileExtensions
Extension methods for `Microsoft.AspNetCore.Http.IFormFile` to simplify file handling in ASP.NET Core.

>```csharp
>public static class FormFileExtensions
>```

### Static Methods

#### GetBytes
>```csharp
>Task<byte[]> GetBytes(this IFormFile formFile)
>```
><b>Summary:</b> Converts an uploaded form file to a byte array.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`formFile`&nbsp;&nbsp;-&nbsp;&nbsp;The form file to convert.<br />
>
><b>Returns:</b> A task representing the asynchronous operation, containing the file contents as a byte array.

<br />

## HeaderDictionaryExtensions
Extension methods for `Microsoft.AspNetCore.Http.IHeaderDictionary` to manage request correlation and identity headers.

>```csharp
>public static class HeaderDictionaryExtensions
>```

### Static Methods

#### AddCorrelationId
>```csharp
>string AddCorrelationId(this IHeaderDictionary headers, string correlationId)
>```
><b>Summary:</b> Adds a correlation ID to the header dictionary.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`headers`&nbsp;&nbsp;-&nbsp;&nbsp;The headers.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`correlationId`&nbsp;&nbsp;-&nbsp;&nbsp;The correlation ID to add.<br />
>
><b>Returns:</b> The correlation ID that was added.
#### GetCallingOnBehalfOfIdentity
>```csharp
>string GetCallingOnBehalfOfIdentity(this IHeaderDictionary headers)
>```
><b>Summary:</b> Gets the on-behalf-of identity from the x-on-behalf-of header.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`headers`&nbsp;&nbsp;-&nbsp;&nbsp;The headers.<br />
>
><b>Returns:</b> The on-behalf-of identity if present; otherwise, null.
>
><b>Remarks:</b> This header is used in scenarios where a service acts on behalf of a user or another service.
#### GetOrAddCorrelationId
>```csharp
>string GetOrAddCorrelationId(this IHeaderDictionary headers)
>```
><b>Summary:</b> Gets the correlation ID from the header, or generates and adds a new one if not found.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`headers`&nbsp;&nbsp;-&nbsp;&nbsp;The headers.<br />
>
><b>Returns:</b> The correlation ID for the request.
#### GetOrAddRequestId
>```csharp
>string GetOrAddRequestId(this IHeaderDictionary headers)
>```
><b>Summary:</b> Gets the request ID from the header, or generates and adds a new one if not found.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`headers`&nbsp;&nbsp;-&nbsp;&nbsp;The headers.<br />
>
><b>Returns:</b> The request ID for the request.

<br />

## HttpContextExExtensions
Extension methods for `Microsoft.AspNetCore.Http.HttpContext` to retrieve request correlation identifiers.

>```csharp
>public static class HttpContextExExtensions
>```

### Static Methods

#### GetCorrelationId
>```csharp
>string GetCorrelationId(this HttpContext context)
>```
><b>Summary:</b> Gets the correlation ID from the request headers.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`context`&nbsp;&nbsp;-&nbsp;&nbsp;The HTTP context.<br />
>
><b>Returns:</b> The correlation ID if present in the request headers; otherwise, null.
#### GetRequestId
>```csharp
>string GetRequestId(this HttpContext context)
>```
><b>Summary:</b> Gets the request ID from the request headers.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`context`&nbsp;&nbsp;-&nbsp;&nbsp;The HTTP context.<br />
>
><b>Returns:</b> The request ID if present in the request headers; otherwise, null.

<br />

## HttpRequestExExtensions
Extension methods for `Microsoft.AspNetCore.Http.HttpRequest` to retrieve raw request body content.

>```csharp
>public static class HttpRequestExExtensions
>```

### Static Methods

#### GetRawBodyBytesAsync
>```csharp
>Task<byte[]> GetRawBodyBytesAsync(this HttpRequest request)
>```
><b>Summary:</b> Retrieves the raw body as a byte array from the Request.Body stream.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`request`&nbsp;&nbsp;-&nbsp;&nbsp;The HTTP request instance.<br />
>
><b>Returns:</b> A task representing the asynchronous operation, containing the request body as a byte array.
#### GetRawBodyStringAsync
>```csharp
>Task<string> GetRawBodyStringAsync(this HttpRequest request, Encoding encoding = null)
>```
><b>Summary:</b> Retrieves the raw body as a string from the Request.Body stream.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`request`&nbsp;&nbsp;-&nbsp;&nbsp;The HTTP request instance.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`encoding`&nbsp;&nbsp;-&nbsp;&nbsp;The encoding to use for reading the stream. Defaults to UTF8 if not specified.<br />
>
><b>Returns:</b> A task representing the asynchronous operation, containing the request body as a string.

<br />

## WellKnownHttpHeaders
Defines well-known HTTP header names used throughout the REST API framework.
><b>Remarks:</b> These header names follow common conventions for distributed tracing, pagination, conditional requests, and identity propagation in microservice architectures.

>```csharp
>public static class WellKnownHttpHeaders
>```

### Static Fields

#### CallingIdentity
>```csharp
>string CallingIdentity
>```
><b>Summary:</b> The calling identity header name for tracking the authenticated user identity.
#### Continuation
>```csharp
>string Continuation
>```
><b>Summary:</b> The continuation token header name for cursor-based pagination.
#### CorrelationId
>```csharp
>string CorrelationId
>```
><b>Summary:</b> The correlation ID header name for distributed tracing across service boundaries.
#### ETag
>```csharp
>string ETag
>```
><b>Summary:</b> The ETag header name for entity versioning and caching.
#### Filename
>```csharp
>string Filename
>```
><b>Summary:</b> The filename header name for file download operations.
#### IfMatch
>```csharp
>string IfMatch
>```
><b>Summary:</b> The If-Match header name for conditional requests based on ETag.
#### IfNoneMatch
>```csharp
>string IfNoneMatch
>```
><b>Summary:</b> The If-None-Match header name for conditional requests based on ETag.
#### MaxItemCount
>```csharp
>string MaxItemCount
>```
><b>Summary:</b> The maximum item count header name for pagination requests.
#### OnBehalfOf
>```csharp
>string OnBehalfOf
>```
><b>Summary:</b> The on-behalf-of header name for identity delegation in service-to-service calls.
#### RequestId
>```csharp
>string RequestId
>```
><b>Summary:</b> The request ID header name for tracking individual requests.
#### ValueSeparator
>```csharp
>string ValueSeparator
>```
><b>Summary:</b> The standard separator for multiple header values.
<hr /><div style='text-align: right'><i>Generated by MarkdownCodeDoc version 1.2</i></div>
