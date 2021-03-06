<div style='text-align: right'>

[References](Index.md)&nbsp;&nbsp;-&nbsp;&nbsp;[References extended](IndexExtended.md)
</div>

# Microsoft.AspNetCore.Http

<br />


## AnonymousAccessExtensions

```csharp
public static class AnonymousAccessExtensions
```

### Static Methods


#### AddAnonymousAccessForDevelopment

```csharp
IServiceCollection AddAnonymousAccessForDevelopment(this IServiceCollection services)
```

<br />


## HeaderDictionaryExtensions

```csharp
public static class HeaderDictionaryExtensions
```

### Static Methods


#### AddCorrelationId

```csharp
string AddCorrelationId(this IHeaderDictionary headers, string correlationId)
```
#### GetCallingOnBehalfOfIdentity

```csharp
string GetCallingOnBehalfOfIdentity(this IHeaderDictionary headers)
```
#### GetOrAddCorrelationId

```csharp
string GetOrAddCorrelationId(this IHeaderDictionary headers)
```
<p><b>Summary:</b> Gets the correlation id from header , if not found a new is added to the header and returned.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`headers`&nbsp;&nbsp;-&nbsp;&nbsp;The headers.<br />
<p><b>Returns:</b> Correlation id for request.</p>

#### GetOrAddRequestId

```csharp
string GetOrAddRequestId(this IHeaderDictionary headers)
```

<br />


## HttpContextExtensions

```csharp
public static class HttpContextExtensions
```

### Static Methods


#### GetCorrelationId

```csharp
string GetCorrelationId(this HttpContext context)
```
#### GetRequestId

```csharp
string GetRequestId(this HttpContext context)
```

<br />


## WellKnownHttpHeaders

```csharp
public static class WellKnownHttpHeaders
```

### Static Fields


#### CallingIdentity

```csharp
string CallingIdentity
```
#### Continuation

```csharp
string Continuation
```
#### CorrelationId

```csharp
string CorrelationId
```
#### ETag

```csharp
string ETag
```
#### Filename

```csharp
string Filename
```
#### IfMatch

```csharp
string IfMatch
```
#### IfNoneMatch

```csharp
string IfNoneMatch
```
#### MaxItemCount

```csharp
string MaxItemCount
```
#### OnBehalfOf

```csharp
string OnBehalfOf
```
#### RequestId

```csharp
string RequestId
```
#### ValueSeparator

```csharp
string ValueSeparator
```
<hr /><div style='text-align: right'><i>Generated by MarkdownCodeDoc version 1.2</i></div>
