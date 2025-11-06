<div style='text-align: right'>

[References](Index.md)&nbsp;&nbsp;-&nbsp;&nbsp;[References extended](IndexExtended.md)
</div>

# Atc.Rest.Results

<br />

## Pagination&lt;T&gt;
Represents a paginated collection of items with metadata for navigation.
><b>Remarks:</b> This class supports two pagination models: <list type="bullet"><item>Offset-based pagination using PageIndex and TotalCount</item><item>Cursor-based pagination using ContinuationToken</item></list>

>```csharp
>public class Pagination&lt;T&gt;
>```

### Properties

#### ContinuationToken
>```csharp
>ContinuationToken
>```
><b>Summary:</b> Gets or sets the continuation token for cursor-based pagination.
#### Count
>```csharp
>Count
>```
><b>Summary:</b> Gets the number of items in the current page.
#### Items
>```csharp
>Items
>```
><b>Summary:</b> Gets or sets the items for the current page.
#### PageIndex
>```csharp
>PageIndex
>```
><b>Summary:</b> Gets or sets the zero-based page index for offset-based pagination.
#### PageSize
>```csharp
>PageSize
>```
><b>Summary:</b> Gets or sets the number of items per page.
#### QueryString
>```csharp
>QueryString
>```
><b>Summary:</b> Gets or sets the original query string from the request.
#### TotalCount
>```csharp
>TotalCount
>```
><b>Summary:</b> Gets or sets the total number of items across all pages (for offset-based pagination).
#### TotalPages
>```csharp
>TotalPages
>```
><b>Summary:</b> Gets the total number of pages based on TotalCount and PageSize.
### Methods

#### ToString
>```csharp
>string ToString()
>```

<br />

## ResultBase
Base class for strongly-typed action result wrappers.
><b>Remarks:</b> This class provides implicit conversion to `Microsoft.AspNetCore.Mvc.ActionResult` allowing derived types to be returned directly from controller actions while maintaining type safety and encapsulation. Derived classes typically represent specific HTTP response patterns (success, error, validation failure, etc.).

>```csharp
>public abstract class ResultBase
>```


<br />

## ResultFactory
Factory methods for creating standardized HTTP response results.
><b>Remarks:</b> This factory provides methods for creating various types of action results including: <list type="bullet"><item>ProblemDetails responses (RFC 7807)</item><item>ValidationProblemDetails for validation errors</item><item>File download results</item><item>Plain content results</item></list>

>```csharp
>public static class ResultFactory
>```

### Static Methods

#### CreateContentResult
>```csharp
>ContentResult CreateContentResult(HttpStatusCode statusCode, string message, string contentType = application/json)
>```
><b>Summary:</b> Creates a `Microsoft.AspNetCore.Mvc.ContentResult` with a JSON-serialized message.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`statusCode`&nbsp;&nbsp;-&nbsp;&nbsp;The HTTP status code.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`message`&nbsp;&nbsp;-&nbsp;&nbsp;The message to serialize.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`contentType`&nbsp;&nbsp;-&nbsp;&nbsp;The content type. Defaults to application/json.<br />
>
><b>Returns:</b> A `Microsoft.AspNetCore.Mvc.ContentResult` with the serialized message.
#### CreateContentResultWithProblemDetails
>```csharp
>ContentResult CreateContentResultWithProblemDetails(HttpStatusCode statusCode, string message, string contentType = application/json)
>```
><b>Summary:</b> Creates a `Microsoft.AspNetCore.Mvc.ContentResult` containing serialized ProblemDetails.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`statusCode`&nbsp;&nbsp;-&nbsp;&nbsp;The HTTP status code.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`message`&nbsp;&nbsp;-&nbsp;&nbsp;The detail message describing the problem.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`contentType`&nbsp;&nbsp;-&nbsp;&nbsp;The content type. Defaults to application/json.<br />
>
><b>Returns:</b> A `Microsoft.AspNetCore.Mvc.ContentResult` with JSON-serialized ProblemDetails.
#### CreateContentResultWithProblemDetails
>```csharp
>ContentResult CreateContentResultWithProblemDetails(HttpStatusCode statusCode, object value, string contentType = application/json)
>```
><b>Summary:</b> Creates a `Microsoft.AspNetCore.Mvc.ContentResult` containing serialized ProblemDetails.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`statusCode`&nbsp;&nbsp;-&nbsp;&nbsp;The HTTP status code.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`message`&nbsp;&nbsp;-&nbsp;&nbsp;The detail message describing the problem.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`contentType`&nbsp;&nbsp;-&nbsp;&nbsp;The content type. Defaults to application/json.<br />
>
><b>Returns:</b> A `Microsoft.AspNetCore.Mvc.ContentResult` with JSON-serialized ProblemDetails.
#### CreateContentResultWithValidationProblemDetails
>```csharp
>ContentResult CreateContentResultWithValidationProblemDetails(HttpStatusCode statusCode, string message, string contentType = application/json)
>```
><b>Summary:</b> Creates a `Microsoft.AspNetCore.Mvc.ContentResult` containing serialized ValidationProblemDetails without specific field errors.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`statusCode`&nbsp;&nbsp;-&nbsp;&nbsp;The HTTP status code.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`message`&nbsp;&nbsp;-&nbsp;&nbsp;The detail message describing the validation failure.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`contentType`&nbsp;&nbsp;-&nbsp;&nbsp;The content type. Defaults to application/json.<br />
>
><b>Returns:</b> A `Microsoft.AspNetCore.Mvc.ContentResult` with JSON-serialized ValidationProblemDetails.
#### CreateContentResultWithValidationProblemDetails
>```csharp
>ContentResult CreateContentResultWithValidationProblemDetails(HttpStatusCode statusCode, Dictionary<string, string[]> errors, string message, string contentType = application/json)
>```
><b>Summary:</b> Creates a `Microsoft.AspNetCore.Mvc.ContentResult` containing serialized ValidationProblemDetails without specific field errors.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`statusCode`&nbsp;&nbsp;-&nbsp;&nbsp;The HTTP status code.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`message`&nbsp;&nbsp;-&nbsp;&nbsp;The detail message describing the validation failure.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`contentType`&nbsp;&nbsp;-&nbsp;&nbsp;The content type. Defaults to application/json.<br />
>
><b>Returns:</b> A `Microsoft.AspNetCore.Mvc.ContentResult` with JSON-serialized ValidationProblemDetails.
#### CreateFileContentResult
>```csharp
>FileResult CreateFileContentResult(byte[] bytes, string fileName, string contentType = application/octet-stream)
>```
><b>Summary:</b> Creates a `Microsoft.AspNetCore.Mvc.FileResult` for downloading binary content.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`bytes`&nbsp;&nbsp;-&nbsp;&nbsp;The file content as a byte array.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`fileName`&nbsp;&nbsp;-&nbsp;&nbsp;The filename to use for the download.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`contentType`&nbsp;&nbsp;-&nbsp;&nbsp;The content type. Defaults to application/octet-stream.<br />
>
><b>Returns:</b> A `Microsoft.AspNetCore.Mvc.FileResult` configured for file download.
#### CreateProblemDetails
>```csharp
>ProblemDetails CreateProblemDetails(HttpStatusCode statusCode, string message)
>```
><b>Summary:</b> Creates a `Microsoft.AspNetCore.Mvc.ProblemDetails` object with the specified status code and message.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`statusCode`&nbsp;&nbsp;-&nbsp;&nbsp;The HTTP status code.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`message`&nbsp;&nbsp;-&nbsp;&nbsp;The detail message describing the problem.<br />
>
><b>Returns:</b> A configured `Microsoft.AspNetCore.Mvc.ProblemDetails` object.
#### CreateValidationProblemDetails
>```csharp
>ValidationProblemDetails CreateValidationProblemDetails(HttpStatusCode statusCode, Dictionary<string, string[]> errors, string message)
>```
><b>Summary:</b> Creates a `Microsoft.AspNetCore.Mvc.ValidationProblemDetails` object with validation errors.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`statusCode`&nbsp;&nbsp;-&nbsp;&nbsp;The HTTP status code.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`errors`&nbsp;&nbsp;-&nbsp;&nbsp;A dictionary of field names and their associated validation errors.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`message`&nbsp;&nbsp;-&nbsp;&nbsp;The detail message describing the validation failure.<br />
>
><b>Returns:</b> A configured `Microsoft.AspNetCore.Mvc.ValidationProblemDetails` object.
<hr /><div style='text-align: right'><i>Generated by MarkdownCodeDoc version 1.2</i></div>
