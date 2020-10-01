<div style='text-align: right'>

[References](Index.md)&nbsp;&nbsp;-&nbsp;&nbsp;[References extended](IndexExtended.md)
</div>

# Atc.Rest.ApiGenerator.Helpers

<br />


## FileHelper

```csharp
public static class FileHelper
```

### Static Methods


#### Save

```csharp
void Save(string file, string text)
```
#### Save

```csharp
void Save(FileInfo fileInfo, string text)
```

<br />


## GenerateHelper

```csharp
public static class GenerateHelper
```

### Static Methods


#### GetBoolFromNullableString

```csharp
bool GetBoolFromNullableString(string value)
```
#### GetNullableStringFromBool

```csharp
string GetNullableStringFromBool(bool value)
```
#### GetNullableValueFromProject

```csharp
string GetNullableValueFromProject(XElement element)
```
#### ScaffoldProjFile

```csharp
void ScaffoldProjFile(DirectoryInfo projectSrcGeneratePath, string projectName, bool useNullableReferenceTypes, bool includeApiSpecification)
```
#### SetNullableValueForProject

```csharp
void SetNullableValueForProject(XElement element, string newNullableValue)
```

<br />


## GenerateServerApiHelper

```csharp
public static class GenerateServerApiHelper
```

### Static Methods


#### CopyApiSpecification

```csharp
void CopyApiSpecification(ApiProjectOptions apiProjectOptions)
```
#### GenerateContracts

```csharp
List<LogKeyValueItem> GenerateContracts(ApiProjectOptions apiProjectOptions, List<ApiOperationSchemaMap> operationSchemaMappings)
```
#### GenerateEndpoints

```csharp
List<LogKeyValueItem> GenerateEndpoints(ApiProjectOptions apiProjectOptions, List<ApiOperationSchemaMap> operationSchemaMappings)
```
#### PerformCleanup

```csharp
void PerformCleanup(DirectoryInfo projectSrcGeneratePath)
```
#### Scaffold

```csharp
void Scaffold(ApiProjectOptions apiProjectOptions)
```
#### ValidateVersioning

```csharp
LogKeyValueItem ValidateVersioning(ApiProjectOptions apiProjectOptions)
```

<br />


## GenerateServerDomainHelper

```csharp
public static class GenerateServerDomainHelper
```

### Static Methods


#### GenerateHandlers

```csharp
List<LogKeyValueItem> GenerateHandlers(DomainProjectOptions domainProjectOptions, List<ApiOperationSchemaMap> operationSchemaMappings)
```
#### Scaffold

```csharp
void Scaffold(DomainProjectOptions domainProjectOptions)
```
#### ValidateVersioning

```csharp
LogKeyValueItem ValidateVersioning(DomainProjectOptions domainProjectOptions)
```

<br />


## GenerateServerHostHelper

```csharp
public static class GenerateServerHostHelper
```

### Static Methods


#### ValidateVersioning

```csharp
LogKeyValueItem ValidateVersioning(HostProjectOptions hostProjectOptions)
```

<br />


## GeneratorHelper

```csharp
public static class GeneratorHelper
```

### Static Methods


#### GenerateServerApi

```csharp
List<LogKeyValueItem> GenerateServerApi(string projectPrefixName, DirectoryInfo outputPath, Tuple<OpenApiDocument, OpenApiDiagnostic, FileInfo> apiYamlDoc, ApiOptions apiOptions)
```
#### GenerateServerDomain

```csharp
List<LogKeyValueItem> GenerateServerDomain(string projectPrefixName, DirectoryInfo outputPath, Tuple<OpenApiDocument, OpenApiDiagnostic, FileInfo> apiYamlDoc, ApiOptions apiOptions, DirectoryInfo apiPath)
```
#### GenerateServerHost

```csharp
List<LogKeyValueItem> GenerateServerHost(string projectPrefixName, DirectoryInfo outputPath, Tuple<OpenApiDocument, OpenApiDiagnostic, FileInfo> apiYamlDoc, ApiOptions apiOptions, DirectoryInfo apiPath, DirectoryInfo domainPath)
```

<br />


## HttpClientHelper

```csharp
public static class HttpClientHelper
```

### Static Methods


#### DownloadToTempFile

```csharp
FileInfo DownloadToTempFile(string apiDesignPath)
```

<br />


## LogItemHelper

```csharp
public static class LogItemHelper
```

### Static Methods


#### Create

```csharp
LogKeyValueItem Create(LogCategoryType logCategoryType, string ruleName, string description)
```

<br />


## OpenApiDocumentHelper

```csharp
public static class OpenApiDocumentHelper
```

### Static Methods


#### CombineAndGetApiYamlDoc

```csharp
Tuple<OpenApiDocument, OpenApiDiagnostic, FileInfo> CombineAndGetApiYamlDoc(string specificationPath)
```
#### GetBasePathSegmentNames

```csharp
List<string> GetBasePathSegmentNames(OpenApiDocument openApiYamlDoc)
```
#### Validate

```csharp
List<LogKeyValueItem> Validate(Tuple<OpenApiDocument, OpenApiDiagnostic, FileInfo> apiYamlDoc, ApiOptionsValidation validationOptions)
```

<br />


## OpenApiDocumentValidationHelper

```csharp
public static class OpenApiDocumentValidationHelper
```

### Static Methods


#### ValidateDocument

```csharp
List<LogKeyValueItem> ValidateDocument(OpenApiDocument apiDocument, ApiOptionsValidation validationOptions)
```

<br />


## OpenApiOperationSchemaMapHelper

```csharp
public static class OpenApiOperationSchemaMapHelper
```

### Static Methods


#### CollectMappings

```csharp
List<ApiOperationSchemaMap> CollectMappings(OpenApiDocument apiDocument)
```
#### GetSegmentName

```csharp
string GetSegmentName(string path)
```

<br />


## ValidatePathsAndOperationsHelper

```csharp
public static class ValidatePathsAndOperationsHelper
```

### Static Methods


#### ValidateGetOperations

```csharp
List<LogKeyValueItem> ValidateGetOperations(ApiOptionsValidation validationOptions, KeyValuePair<string, OpenApiPathItem> path)
```
<p><b>Summary:</b> Check for response types according to operation/global parameters.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`validationOptions`&nbsp;&nbsp;-&nbsp;&nbsp;The validation options.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`path`&nbsp;&nbsp;-&nbsp;&nbsp;The path.<br />
#### ValidateGlobalParameters

```csharp
List<LogKeyValueItem> ValidateGlobalParameters(ApiOptionsValidation validationOptions, IEnumerable<string> globalPathParameterNames, KeyValuePair<string, OpenApiPathItem> path)
```
<p><b>Summary:</b> Check global parameters.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`validationOptions`&nbsp;&nbsp;-&nbsp;&nbsp;The validation options.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`globalPathParameterNames`&nbsp;&nbsp;-&nbsp;&nbsp;The global path parameter names.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`path`&nbsp;&nbsp;-&nbsp;&nbsp;The path.<br />
#### ValidateMissingOperationParameters

```csharp
List<LogKeyValueItem> ValidateMissingOperationParameters(ApiOptionsValidation validationOptions, KeyValuePair<string, OpenApiPathItem> path)
```
<p><b>Summary:</b> Check for operations that are not defining parameters, which are present in the path.key.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`validationOptions`&nbsp;&nbsp;-&nbsp;&nbsp;The validation options.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`path`&nbsp;&nbsp;-&nbsp;&nbsp;The path.<br />
#### ValidateOperationsWithParametersNotPresentInPath

```csharp
List<LogKeyValueItem> ValidateOperationsWithParametersNotPresentInPath(ApiOptionsValidation validationOptions, KeyValuePair<string, OpenApiPathItem> path)
```
<p><b>Summary:</b> Check for operations with parameters, that are not present in the path.key.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`validationOptions`&nbsp;&nbsp;-&nbsp;&nbsp;The validation options.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`path`&nbsp;&nbsp;-&nbsp;&nbsp;The path.<br />
<hr /><div style='text-align: right'><i>Generated by MarkdownCodeDoc version 1.2</i></div>
