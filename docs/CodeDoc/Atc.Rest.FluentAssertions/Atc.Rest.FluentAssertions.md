<div style='text-align: right'>

[References](Index.md)&nbsp;&nbsp;-&nbsp;&nbsp;[References extended](IndexExtended.md)
</div>

# Atc.Rest.FluentAssertions

<br />

## AcceptedResultAssertions

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

>```csharp
>public class BadRequestResultAssertions : ErrorContentResultAssertions<BadRequestResultAssertions>
>```


<br />

## ConflictResultAssertions

>```csharp
>public class ConflictResultAssertions : ErrorContentResultAssertions<ConflictResultAssertions>
>```


<br />

## ContentResultAssertions

>```csharp
>public class ContentResultAssertions : ContentResultAssertionsBase<ContentResultAssertions>
>```

### Methods

#### WithStatusCode
>```csharp
>AndConstraint<ContentResultAssertions> WithStatusCode(HttpStatusCode expectedStatusCode, string because = , object[] becauseArgs)
>```
#### WithStatusCode
>```csharp
>AndConstraint<ContentResultAssertions> WithStatusCode(int expectedStatusCode, string because = , object[] becauseArgs)
>```

<br />

## ContentResultAssertionsBase&lt;TAssertions&gt;

>```csharp
>public abstract class ContentResultAssertionsBase&lt;TAssertions&gt; : ReferenceTypeAssertions<ContentResult, ContentResultAssertionsBase<TAssertions>>
>```

### Methods

#### WithContent
>```csharp
>AndWhichConstraint<TAssertions, ContentResult> WithContent(T expectedContent, string because = , object[] becauseArgs)
>```
#### WithContentOfType
>```csharp
>AndWhichConstraint<ObjectAssertions, T> WithContentOfType(string because = , object[] becauseArgs)
>```

<br />

## CreatedResultAssertions

>```csharp
>public class CreatedResultAssertions : ContentResultAssertionsBase<CreatedResultAssertions>
>```


<br />

## ErrorContentResultAssertions&lt;TAssertions&gt;

>```csharp
>public abstract class ErrorContentResultAssertions&lt;TAssertions&gt; : ContentResultAssertionsBase<TAssertions>
>```

### Methods

#### WithErrorMessage
>```csharp
>AndWhichConstraint<TAssertions, ContentResult> WithErrorMessage(string expectedErrorMessage, string because = , object[] becauseArgs)
>```

<br />

## ForbiddenResultAssertions

>```csharp
>public class ForbiddenResultAssertions : ErrorContentResultAssertions<ForbiddenResultAssertions>
>```


<br />

## NoContentResultAssertions

>```csharp
>public class NoContentResultAssertions : ContentResultAssertionsBase<NoContentResultAssertions>
>```


<br />

## NotFoundResultAssertions

>```csharp
>public class NotFoundResultAssertions : ErrorContentResultAssertions<NotFoundResultAssertions>
>```


<br />

## OkResultAssertions

>```csharp
>public class OkResultAssertions : ReferenceTypeAssertions<OkObjectResult, OkResultAssertions>
>```

### Methods

#### WithContent
>```csharp
>AndWhichConstraint<OkResultAssertions, OkObjectResult> WithContent(T expectedContent, string because = , object[] becauseArgs)
>```
#### WithContentOfType
>```csharp
>AndWhichConstraint<ObjectAssertions, T> WithContentOfType(string because = , object[] becauseArgs)
>```

<br />

## ResultAssertions

>```csharp
>public class ResultAssertions : ReferenceTypeAssertions<ActionResult, ResultAssertions>
>```

### Methods

#### BeAcceptedResult
>```csharp
>AcceptedResultAssertions BeAcceptedResult(string because = , object[] becauseArgs)
>```
#### BeBadRequestResult
>```csharp
>BadRequestResultAssertions BeBadRequestResult(string because = , object[] becauseArgs)
>```
#### BeConflictResult
>```csharp
>ConflictResultAssertions BeConflictResult(string because = , object[] becauseArgs)
>```
#### BeContentResult
>```csharp
>ContentResultAssertions BeContentResult(string because = , object[] becauseArgs)
>```
#### BeCreatedResult
>```csharp
>CreatedResultAssertions BeCreatedResult(string because = , object[] becauseArgs)
>```
#### BeForbiddenResult
>```csharp
>ForbiddenResultAssertions BeForbiddenResult(string because = , object[] becauseArgs)
>```
#### BeNoContentResult
>```csharp
>NoContentResultAssertions BeNoContentResult(string because = , object[] becauseArgs)
>```
#### BeNotFoundResult
>```csharp
>NotFoundResultAssertions BeNotFoundResult(string because = , object[] becauseArgs)
>```
#### BeOkResult
>```csharp
>OkResultAssertions BeOkResult(string because = , object[] becauseArgs)
>```

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
