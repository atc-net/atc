<div style='text-align: right'>

[References](Index.md)&nbsp;&nbsp;-&nbsp;&nbsp;[References extended](IndexExtended.md)
</div>

# Atc.Rest.FluentAssertions

<br />

## AcceptedResultAssertions
Provides FluentAssertions-style assertions for `Microsoft.AspNetCore.Mvc.ContentResult` objects with HTTP status code 202 (Accepted).

>```csharp
>public class AcceptedResultAssertions : ContentResultAssertionsBase<AcceptedResultAssertions>
>```


<br />

## AtcRestFluentAssertionsAssemblyTypeInitializer

>```csharp
>public static class AtcRestFluentAssertionsAssemblyTypeInitializer
>```


<br />

## BadRequestResultAssertions
Provides FluentAssertions-style assertions for `Microsoft.AspNetCore.Mvc.ContentResult` objects with HTTP status code 400 (Bad Request).

>```csharp
>public class BadRequestResultAssertions : ErrorContentResultAssertions<BadRequestResultAssertions>
>```


<br />

## ConflictResultAssertions
Provides FluentAssertions-style assertions for `Microsoft.AspNetCore.Mvc.ContentResult` objects with HTTP status code 409 (Conflict).

>```csharp
>public class ConflictResultAssertions : ErrorContentResultAssertions<ConflictResultAssertions>
>```


<br />

## ContentResultAssertions
Provides FluentAssertions-style assertions for `Microsoft.AspNetCore.Mvc.ContentResult` objects.

>```csharp
>public class ContentResultAssertions : ContentResultAssertionsBase<ContentResultAssertions>
>```

### Methods

#### WithStatusCode
>```csharp
>AndConstraint<ContentResultAssertions> WithStatusCode(HttpStatusCode expectedStatusCode, string because = , object[] becauseArgs)
>```
><b>Summary:</b> Asserts that the content result has the specified HTTP status code.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`expectedStatusCode`&nbsp;&nbsp;-&nbsp;&nbsp;The expected HTTP status code.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`because`&nbsp;&nbsp;-&nbsp;&nbsp;Optional explanation of why the assertion is needed.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`becauseArgs`&nbsp;&nbsp;-&nbsp;&nbsp;Optional formatting arguments for the  parameter.<br />
>
><b>Returns:</b> An `FluentAssertions.AndConstraint`1` for further assertions.
#### WithStatusCode
>```csharp
>AndConstraint<ContentResultAssertions> WithStatusCode(int expectedStatusCode, string because = , object[] becauseArgs)
>```
><b>Summary:</b> Asserts that the content result has the specified HTTP status code.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`expectedStatusCode`&nbsp;&nbsp;-&nbsp;&nbsp;The expected HTTP status code.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`because`&nbsp;&nbsp;-&nbsp;&nbsp;Optional explanation of why the assertion is needed.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`becauseArgs`&nbsp;&nbsp;-&nbsp;&nbsp;Optional formatting arguments for the  parameter.<br />
>
><b>Returns:</b> An `FluentAssertions.AndConstraint`1` for further assertions.

<br />

## ContentResultAssertionsBase&lt;TAssertions&gt;
Base class for content result assertions that provides common functionality for verifying `Microsoft.AspNetCore.Mvc.ContentResult` objects.

>```csharp
>public abstract class ContentResultAssertionsBase&lt;TAssertions&gt; : ReferenceTypeAssertions<ContentResult, ContentResultAssertionsBase<TAssertions>>
>```

### Methods

#### WithContent
>```csharp
>AndWhichConstraint<TAssertions, ContentResult> WithContent(T expectedContent, string because = , object[] becauseArgs)
>```
><b>Summary:</b> Asserts that the content result contains content equivalent to the specified expected content.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`expectedContent`&nbsp;&nbsp;-&nbsp;&nbsp;The expected content value to compare against.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`because`&nbsp;&nbsp;-&nbsp;&nbsp;Optional explanation of why the assertion is needed.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`becauseArgs`&nbsp;&nbsp;-&nbsp;&nbsp;Optional formatting arguments for the  parameter.<br />
>
><b>Returns:</b> An `FluentAssertions.AndWhichConstraint`2` for further assertions.
#### WithContentOfType
>```csharp
>AndWhichConstraint<ObjectAssertions, T> WithContentOfType(string because = , object[] becauseArgs)
>```
><b>Summary:</b> Asserts that the content result contains content of the specified type.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`because`&nbsp;&nbsp;-&nbsp;&nbsp;Optional explanation of why the assertion is needed.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`becauseArgs`&nbsp;&nbsp;-&nbsp;&nbsp;Optional formatting arguments for the  parameter.<br />
>
><b>Returns:</b> An `FluentAssertions.AndWhichConstraint`2` for further assertions on the typed content.

<br />

## CreatedResultAssertions
Provides FluentAssertions-style assertions for `Microsoft.AspNetCore.Mvc.ContentResult` objects with HTTP status code 201 (Created).

>```csharp
>public class CreatedResultAssertions : ContentResultAssertionsBase<CreatedResultAssertions>
>```


<br />

## ErrorContentResultAssertions&lt;TAssertions&gt;
Base class for error result assertions that provides functionality for verifying error messages in `Microsoft.AspNetCore.Mvc.ContentResult` objects.

>```csharp
>public abstract class ErrorContentResultAssertions&lt;TAssertions&gt; : ContentResultAssertionsBase<TAssertions>
>```

### Methods

#### WithErrorMessage
>```csharp
>AndWhichConstraint<TAssertions, ContentResult> WithErrorMessage(string expectedErrorMessage, string because = , object[] becauseArgs)
>```
><b>Summary:</b> Asserts that the error result contains the specified error message. The error message is extracted from either a `Microsoft.AspNetCore.Mvc.ProblemDetails` object's Detail property or a string content.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`expectedErrorMessage`&nbsp;&nbsp;-&nbsp;&nbsp;The expected error message.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`because`&nbsp;&nbsp;-&nbsp;&nbsp;Optional explanation of why the assertion is needed.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`becauseArgs`&nbsp;&nbsp;-&nbsp;&nbsp;Optional formatting arguments for the  parameter.<br />
>
><b>Returns:</b> An `FluentAssertions.AndWhichConstraint`2` for further assertions.

<br />

## ForbiddenResultAssertions
Provides FluentAssertions-style assertions for `Microsoft.AspNetCore.Mvc.ContentResult` objects with HTTP status code 403 (Forbidden).

>```csharp
>public class ForbiddenResultAssertions : ErrorContentResultAssertions<ForbiddenResultAssertions>
>```


<br />

## NoContentResultAssertions
Provides FluentAssertions-style assertions for `Microsoft.AspNetCore.Mvc.ContentResult` objects with HTTP status code 204 (No Content).

>```csharp
>public class NoContentResultAssertions : ContentResultAssertionsBase<NoContentResultAssertions>
>```


<br />

## NotFoundResultAssertions
Provides FluentAssertions-style assertions for `Microsoft.AspNetCore.Mvc.ContentResult` objects with HTTP status code 404 (Not Found).

>```csharp
>public class NotFoundResultAssertions : ErrorContentResultAssertions<NotFoundResultAssertions>
>```


<br />

## OkResultAssertions
Provides FluentAssertions-style assertions for `Microsoft.AspNetCore.Mvc.OkObjectResult` objects with HTTP status code 200 (OK).

>```csharp
>public class OkResultAssertions : ReferenceTypeAssertions<OkObjectResult, OkResultAssertions>
>```

### Methods

#### WithContent
>```csharp
>AndWhichConstraint<OkResultAssertions, OkObjectResult> WithContent(T expectedContent, string because = , object[] becauseArgs)
>```
><b>Summary:</b> Asserts that the OK result contains content equivalent to the specified expected content.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`expectedContent`&nbsp;&nbsp;-&nbsp;&nbsp;The expected content value to compare against.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`because`&nbsp;&nbsp;-&nbsp;&nbsp;Optional explanation of why the assertion is needed.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`becauseArgs`&nbsp;&nbsp;-&nbsp;&nbsp;Optional formatting arguments for the  parameter.<br />
>
><b>Returns:</b> An `FluentAssertions.AndWhichConstraint`2` for further assertions.
#### WithContentOfType
>```csharp
>AndWhichConstraint<ObjectAssertions, T> WithContentOfType(string because = , object[] becauseArgs)
>```
><b>Summary:</b> Asserts that the OK result contains content of the specified type.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`because`&nbsp;&nbsp;-&nbsp;&nbsp;Optional explanation of why the assertion is needed.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`becauseArgs`&nbsp;&nbsp;-&nbsp;&nbsp;Optional formatting arguments for the  parameter.<br />
>
><b>Returns:</b> An `FluentAssertions.AndWhichConstraint`2` for further assertions on the typed content.

<br />

## ResultAssertions
Provides FluentAssertions-style assertions for `Microsoft.AspNetCore.Mvc.ActionResult` objects.

>```csharp
>public class ResultAssertions : ReferenceTypeAssertions<ActionResult, ResultAssertions>
>```

### Methods

#### BeAcceptedResult
>```csharp
>AcceptedResultAssertions BeAcceptedResult(string because = , object[] becauseArgs)
>```
><b>Summary:</b> Asserts that the action result is a `Microsoft.AspNetCore.Mvc.ContentResult` with HTTP status code 202 (Accepted).
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`because`&nbsp;&nbsp;-&nbsp;&nbsp;Optional explanation of why the assertion is needed.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`becauseArgs`&nbsp;&nbsp;-&nbsp;&nbsp;Optional formatting arguments for the  parameter.<br />
>
><b>Returns:</b> An `Atc.Rest.FluentAssertions.AcceptedResultAssertions` instance for further assertions.
#### BeBadRequestResult
>```csharp
>BadRequestResultAssertions BeBadRequestResult(string because = , object[] becauseArgs)
>```
><b>Summary:</b> Asserts that the action result is a `Microsoft.AspNetCore.Mvc.ContentResult` with HTTP status code 400 (Bad Request).
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`because`&nbsp;&nbsp;-&nbsp;&nbsp;Optional explanation of why the assertion is needed.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`becauseArgs`&nbsp;&nbsp;-&nbsp;&nbsp;Optional formatting arguments for the  parameter.<br />
>
><b>Returns:</b> A `Atc.Rest.FluentAssertions.BadRequestResultAssertions` instance for further assertions.
#### BeConflictResult
>```csharp
>ConflictResultAssertions BeConflictResult(string because = , object[] becauseArgs)
>```
><b>Summary:</b> Asserts that the action result is a `Microsoft.AspNetCore.Mvc.ContentResult` with HTTP status code 409 (Conflict).
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`because`&nbsp;&nbsp;-&nbsp;&nbsp;Optional explanation of why the assertion is needed.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`becauseArgs`&nbsp;&nbsp;-&nbsp;&nbsp;Optional formatting arguments for the  parameter.<br />
>
><b>Returns:</b> A `Atc.Rest.FluentAssertions.ConflictResultAssertions` instance for further assertions.
#### BeContentResult
>```csharp
>ContentResultAssertions BeContentResult(string because = , object[] becauseArgs)
>```
><b>Summary:</b> Asserts that the action result is a `Microsoft.AspNetCore.Mvc.ContentResult`.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`because`&nbsp;&nbsp;-&nbsp;&nbsp;Optional explanation of why the assertion is needed.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`becauseArgs`&nbsp;&nbsp;-&nbsp;&nbsp;Optional formatting arguments for the  parameter.<br />
>
><b>Returns:</b> A `Atc.Rest.FluentAssertions.ContentResultAssertions` instance for further assertions.
#### BeCreatedResult
>```csharp
>CreatedResultAssertions BeCreatedResult(string because = , object[] becauseArgs)
>```
><b>Summary:</b> Asserts that the action result is a `Microsoft.AspNetCore.Mvc.ContentResult` with HTTP status code 201 (Created).
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`because`&nbsp;&nbsp;-&nbsp;&nbsp;Optional explanation of why the assertion is needed.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`becauseArgs`&nbsp;&nbsp;-&nbsp;&nbsp;Optional formatting arguments for the  parameter.<br />
>
><b>Returns:</b> A `Atc.Rest.FluentAssertions.CreatedResultAssertions` instance for further assertions.
#### BeForbiddenResult
>```csharp
>ForbiddenResultAssertions BeForbiddenResult(string because = , object[] becauseArgs)
>```
><b>Summary:</b> Asserts that the action result is a `Microsoft.AspNetCore.Mvc.ContentResult` with HTTP status code 403 (Forbidden).
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`because`&nbsp;&nbsp;-&nbsp;&nbsp;Optional explanation of why the assertion is needed.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`becauseArgs`&nbsp;&nbsp;-&nbsp;&nbsp;Optional formatting arguments for the  parameter.<br />
>
><b>Returns:</b> A `Atc.Rest.FluentAssertions.ForbiddenResultAssertions` instance for further assertions.
#### BeNoContentResult
>```csharp
>NoContentResultAssertions BeNoContentResult(string because = , object[] becauseArgs)
>```
><b>Summary:</b> Asserts that the action result is a `Microsoft.AspNetCore.Mvc.ContentResult` with HTTP status code 204 (No Content).
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`because`&nbsp;&nbsp;-&nbsp;&nbsp;Optional explanation of why the assertion is needed.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`becauseArgs`&nbsp;&nbsp;-&nbsp;&nbsp;Optional formatting arguments for the  parameter.<br />
>
><b>Returns:</b> A `Atc.Rest.FluentAssertions.NoContentResultAssertions` instance for further assertions.
#### BeNotFoundResult
>```csharp
>NotFoundResultAssertions BeNotFoundResult(string because = , object[] becauseArgs)
>```
><b>Summary:</b> Asserts that the action result is a `Microsoft.AspNetCore.Mvc.ContentResult` with HTTP status code 404 (Not Found).
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`because`&nbsp;&nbsp;-&nbsp;&nbsp;Optional explanation of why the assertion is needed.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`becauseArgs`&nbsp;&nbsp;-&nbsp;&nbsp;Optional formatting arguments for the  parameter.<br />
>
><b>Returns:</b> A `Atc.Rest.FluentAssertions.NotFoundResultAssertions` instance for further assertions.
#### BeOkResult
>```csharp
>OkResultAssertions BeOkResult(string because = , object[] becauseArgs)
>```
><b>Summary:</b> Asserts that the action result is an `Microsoft.AspNetCore.Mvc.OkObjectResult` with HTTP status code 200 (OK).
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`because`&nbsp;&nbsp;-&nbsp;&nbsp;Optional explanation of why the assertion is needed.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`becauseArgs`&nbsp;&nbsp;-&nbsp;&nbsp;Optional formatting arguments for the  parameter.<br />
>
><b>Returns:</b> An `Atc.Rest.FluentAssertions.OkResultAssertions` instance for further assertions.

<br />

## ResultBaseExtensions
Extensions for FluentAssertions that make testing Atc Rest handlers easier.

>```csharp
>public static class ResultBaseExtensions
>```

### Static Methods

#### Should
>```csharp
>ResultAssertions Should(this ResultBase subject)
>```
><b>Summary:</b> Returns an `Atc.Rest.FluentAssertions.ResultAssertions` object that can be used to assert the current `subject`.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`subject`&nbsp;&nbsp;-&nbsp;&nbsp;The subject to assert against.<br />
>
><b>Returns:</b> A `Atc.Rest.FluentAssertions.ResultAssertions`.
<hr /><div style='text-align: right'><i>Generated by MarkdownCodeDoc version 1.2</i></div>
