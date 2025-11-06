<div style='text-align: right'>

[References](Index.md)&nbsp;&nbsp;-&nbsp;&nbsp;[References extended](IndexExtended.md)
</div>

# Atc.Data

<br />

## AssemblyInformationFactory
Factory for creating `Atc.Data.Models.AssemblyInformation` instances from `System.Reflection.Assembly` objects.

>```csharp
>public static class AssemblyInformationFactory
>```

### Static Methods

#### Create
>```csharp
>AssemblyInformation Create(Assembly assembly)
>```
><b>Summary:</b> Creates an `Atc.Data.Models.AssemblyInformation` instance from the specified assembly.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`assembly`&nbsp;&nbsp;-&nbsp;&nbsp;The assembly to extract information from.<br />
>
><b>Returns:</b> An `Atc.Data.Models.AssemblyInformation` object containing assembly metadata.

<br />

## DataFactory
Data Helper.

>```csharp
>public static class DataFactory
>```

### Static Methods

#### CreateKeyValueDataTableOfGuidString
>```csharp
>DataTable CreateKeyValueDataTableOfGuidString(DropDownFirstItemType dropDownFirstItemType = None)
>```
><b>Summary:</b> Create the key/value data table of global identifier and string.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`dropDownFirstItemType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the dropdown first item.<br />
>
><b>Returns:</b> The `System.Data.DataTable`.
#### CreateKeyValueDataTableOfIntString
>```csharp
>DataTable CreateKeyValueDataTableOfIntString(DropDownFirstItemType dropDownFirstItemType = None)
>```
><b>Summary:</b> Create the key/value data table of integer and string.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`dropDownFirstItemType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the dropdown first item.<br />
>
><b>Returns:</b> The `System.Data.DataTable`.
#### CreateKeyValueDictionaryOfGuidString
>```csharp
>Dictionary<Guid, string> CreateKeyValueDictionaryOfGuidString(DropDownFirstItemType dropDownFirstItemType = None)
>```
><b>Summary:</b> Create the key/value dictionary of global identifier and string.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`dropDownFirstItemType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the dropdown first item.<br />
>
><b>Returns:</b> The Dictionary.
#### CreateKeyValueDictionaryOfIntString
>```csharp
>Dictionary<int, string> CreateKeyValueDictionaryOfIntString(DropDownFirstItemType dropDownFirstItemType = None)
>```
><b>Summary:</b> Create the key/value dictionary of integer and string.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`dropDownFirstItemType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the dropdown first item.<br />
>
><b>Returns:</b> The Dictionary.
#### CreateKeyValueDictionaryOfStringString
>```csharp
>Dictionary<string, string> CreateKeyValueDictionaryOfStringString(DropDownFirstItemType dropDownFirstItemType = None)
>```
><b>Summary:</b> Creates the key value dictionary of string string.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`dropDownFirstItemType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the dropdown first item.<br />
>
><b>Returns:</b> The Dictionary.

<br />

## LogItemFactory
Factory for creating `Atc.Data.Models.LogItem` and `Atc.Data.Models.LogKeyValueItem` instances. Provides convenient methods for creating log items with different severity levels.

>```csharp
>public static class LogItemFactory
>```

### Static Methods

#### Create
>```csharp
>LogItem Create(LogCategoryType logCategoryType, string message)
>```
><b>Summary:</b> Creates a new `Atc.Data.Models.LogItem` with the specified log category and message.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`logCategoryType`&nbsp;&nbsp;-&nbsp;&nbsp;The log category type.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`message`&nbsp;&nbsp;-&nbsp;&nbsp;The log message.<br />
>
><b>Returns:</b> A new `Atc.Data.Models.LogItem` instance.
#### Create
>```csharp
>LogKeyValueItem Create(LogCategoryType logCategoryType, string key, string value)
>```
><b>Summary:</b> Creates a new `Atc.Data.Models.LogItem` with the specified log category and message.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`logCategoryType`&nbsp;&nbsp;-&nbsp;&nbsp;The log category type.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`message`&nbsp;&nbsp;-&nbsp;&nbsp;The log message.<br />
>
><b>Returns:</b> A new `Atc.Data.Models.LogItem` instance.
#### Create
>```csharp
>LogKeyValueItem Create(LogCategoryType logCategoryType, string key, string value, string description)
>```
><b>Summary:</b> Creates a new `Atc.Data.Models.LogItem` with the specified log category and message.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`logCategoryType`&nbsp;&nbsp;-&nbsp;&nbsp;The log category type.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`message`&nbsp;&nbsp;-&nbsp;&nbsp;The log message.<br />
>
><b>Returns:</b> A new `Atc.Data.Models.LogItem` instance.
#### CreateAudit
>```csharp
>LogItem CreateAudit(string message)
>```
><b>Summary:</b> Creates a new `Atc.Data.Models.LogItem` with audit severity.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`message`&nbsp;&nbsp;-&nbsp;&nbsp;The log message.<br />
>
><b>Returns:</b> A new `Atc.Data.Models.LogItem` instance with audit severity.
#### CreateAudit
>```csharp
>LogKeyValueItem CreateAudit(string key, string value)
>```
><b>Summary:</b> Creates a new `Atc.Data.Models.LogItem` with audit severity.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`message`&nbsp;&nbsp;-&nbsp;&nbsp;The log message.<br />
>
><b>Returns:</b> A new `Atc.Data.Models.LogItem` instance with audit severity.
#### CreateAudit
>```csharp
>LogKeyValueItem CreateAudit(string key, string value, string description)
>```
><b>Summary:</b> Creates a new `Atc.Data.Models.LogItem` with audit severity.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`message`&nbsp;&nbsp;-&nbsp;&nbsp;The log message.<br />
>
><b>Returns:</b> A new `Atc.Data.Models.LogItem` instance with audit severity.
#### CreateCritical
>```csharp
>LogItem CreateCritical(string message)
>```
><b>Summary:</b> Creates a new `Atc.Data.Models.LogItem` with critical severity.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`message`&nbsp;&nbsp;-&nbsp;&nbsp;The log message.<br />
>
><b>Returns:</b> A new `Atc.Data.Models.LogItem` instance with critical severity.
#### CreateCritical
>```csharp
>LogKeyValueItem CreateCritical(string key, string value)
>```
><b>Summary:</b> Creates a new `Atc.Data.Models.LogItem` with critical severity.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`message`&nbsp;&nbsp;-&nbsp;&nbsp;The log message.<br />
>
><b>Returns:</b> A new `Atc.Data.Models.LogItem` instance with critical severity.
#### CreateCritical
>```csharp
>LogKeyValueItem CreateCritical(string key, string value, string description)
>```
><b>Summary:</b> Creates a new `Atc.Data.Models.LogItem` with critical severity.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`message`&nbsp;&nbsp;-&nbsp;&nbsp;The log message.<br />
>
><b>Returns:</b> A new `Atc.Data.Models.LogItem` instance with critical severity.
#### CreateDebug
>```csharp
>LogItem CreateDebug(string message)
>```
><b>Summary:</b> Creates a new `Atc.Data.Models.LogItem` with debug severity.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`message`&nbsp;&nbsp;-&nbsp;&nbsp;The log message.<br />
>
><b>Returns:</b> A new `Atc.Data.Models.LogItem` instance with debug severity.
#### CreateDebug
>```csharp
>LogKeyValueItem CreateDebug(string key, string value)
>```
><b>Summary:</b> Creates a new `Atc.Data.Models.LogItem` with debug severity.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`message`&nbsp;&nbsp;-&nbsp;&nbsp;The log message.<br />
>
><b>Returns:</b> A new `Atc.Data.Models.LogItem` instance with debug severity.
#### CreateDebug
>```csharp
>LogKeyValueItem CreateDebug(string key, string value, string description)
>```
><b>Summary:</b> Creates a new `Atc.Data.Models.LogItem` with debug severity.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`message`&nbsp;&nbsp;-&nbsp;&nbsp;The log message.<br />
>
><b>Returns:</b> A new `Atc.Data.Models.LogItem` instance with debug severity.
#### CreateError
>```csharp
>LogItem CreateError(string message)
>```
><b>Summary:</b> Creates a new `Atc.Data.Models.LogItem` with error severity.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`message`&nbsp;&nbsp;-&nbsp;&nbsp;The log message.<br />
>
><b>Returns:</b> A new `Atc.Data.Models.LogItem` instance with error severity.
#### CreateError
>```csharp
>LogKeyValueItem CreateError(string key, string value)
>```
><b>Summary:</b> Creates a new `Atc.Data.Models.LogItem` with error severity.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`message`&nbsp;&nbsp;-&nbsp;&nbsp;The log message.<br />
>
><b>Returns:</b> A new `Atc.Data.Models.LogItem` instance with error severity.
#### CreateError
>```csharp
>LogKeyValueItem CreateError(string key, string value, string description)
>```
><b>Summary:</b> Creates a new `Atc.Data.Models.LogItem` with error severity.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`message`&nbsp;&nbsp;-&nbsp;&nbsp;The log message.<br />
>
><b>Returns:</b> A new `Atc.Data.Models.LogItem` instance with error severity.
#### CreateInformation
>```csharp
>LogItem CreateInformation(string message)
>```
><b>Summary:</b> Creates a new `Atc.Data.Models.LogItem` with information severity.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`message`&nbsp;&nbsp;-&nbsp;&nbsp;The log message.<br />
>
><b>Returns:</b> A new `Atc.Data.Models.LogItem` instance with information severity.
#### CreateInformation
>```csharp
>LogKeyValueItem CreateInformation(string key, string value)
>```
><b>Summary:</b> Creates a new `Atc.Data.Models.LogItem` with information severity.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`message`&nbsp;&nbsp;-&nbsp;&nbsp;The log message.<br />
>
><b>Returns:</b> A new `Atc.Data.Models.LogItem` instance with information severity.
#### CreateInformation
>```csharp
>LogKeyValueItem CreateInformation(string key, string value, string description)
>```
><b>Summary:</b> Creates a new `Atc.Data.Models.LogItem` with information severity.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`message`&nbsp;&nbsp;-&nbsp;&nbsp;The log message.<br />
>
><b>Returns:</b> A new `Atc.Data.Models.LogItem` instance with information severity.
#### CreateSecurity
>```csharp
>LogItem CreateSecurity(string message)
>```
><b>Summary:</b> Creates a new `Atc.Data.Models.LogItem` with security severity.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`message`&nbsp;&nbsp;-&nbsp;&nbsp;The log message.<br />
>
><b>Returns:</b> A new `Atc.Data.Models.LogItem` instance with security severity.
#### CreateSecurity
>```csharp
>LogKeyValueItem CreateSecurity(string key, string value)
>```
><b>Summary:</b> Creates a new `Atc.Data.Models.LogItem` with security severity.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`message`&nbsp;&nbsp;-&nbsp;&nbsp;The log message.<br />
>
><b>Returns:</b> A new `Atc.Data.Models.LogItem` instance with security severity.
#### CreateSecurity
>```csharp
>LogKeyValueItem CreateSecurity(string key, string value, string description)
>```
><b>Summary:</b> Creates a new `Atc.Data.Models.LogItem` with security severity.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`message`&nbsp;&nbsp;-&nbsp;&nbsp;The log message.<br />
>
><b>Returns:</b> A new `Atc.Data.Models.LogItem` instance with security severity.
#### CreateService
>```csharp
>LogItem CreateService(string message)
>```
><b>Summary:</b> Creates a new `Atc.Data.Models.LogItem` with service severity.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`message`&nbsp;&nbsp;-&nbsp;&nbsp;The log message.<br />
>
><b>Returns:</b> A new `Atc.Data.Models.LogItem` instance with service severity.
#### CreateService
>```csharp
>LogKeyValueItem CreateService(string key, string value)
>```
><b>Summary:</b> Creates a new `Atc.Data.Models.LogItem` with service severity.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`message`&nbsp;&nbsp;-&nbsp;&nbsp;The log message.<br />
>
><b>Returns:</b> A new `Atc.Data.Models.LogItem` instance with service severity.
#### CreateService
>```csharp
>LogKeyValueItem CreateService(string key, string value, string description)
>```
><b>Summary:</b> Creates a new `Atc.Data.Models.LogItem` with service severity.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`message`&nbsp;&nbsp;-&nbsp;&nbsp;The log message.<br />
>
><b>Returns:</b> A new `Atc.Data.Models.LogItem` instance with service severity.
#### CreateTrace
>```csharp
>LogItem CreateTrace(string message)
>```
><b>Summary:</b> Creates a new `Atc.Data.Models.LogItem` with trace severity.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`message`&nbsp;&nbsp;-&nbsp;&nbsp;The log message.<br />
>
><b>Returns:</b> A new `Atc.Data.Models.LogItem` instance with trace severity.
#### CreateTrace
>```csharp
>LogKeyValueItem CreateTrace(string key, string value)
>```
><b>Summary:</b> Creates a new `Atc.Data.Models.LogItem` with trace severity.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`message`&nbsp;&nbsp;-&nbsp;&nbsp;The log message.<br />
>
><b>Returns:</b> A new `Atc.Data.Models.LogItem` instance with trace severity.
#### CreateTrace
>```csharp
>LogKeyValueItem CreateTrace(string key, string value, string description)
>```
><b>Summary:</b> Creates a new `Atc.Data.Models.LogItem` with trace severity.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`message`&nbsp;&nbsp;-&nbsp;&nbsp;The log message.<br />
>
><b>Returns:</b> A new `Atc.Data.Models.LogItem` instance with trace severity.
#### CreateUi
>```csharp
>LogItem CreateUi(string message)
>```
><b>Summary:</b> Creates a new `Atc.Data.Models.LogItem` with UI severity.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`message`&nbsp;&nbsp;-&nbsp;&nbsp;The log message.<br />
>
><b>Returns:</b> A new `Atc.Data.Models.LogItem` instance with UI severity.
#### CreateUi
>```csharp
>LogKeyValueItem CreateUi(string key, string value)
>```
><b>Summary:</b> Creates a new `Atc.Data.Models.LogItem` with UI severity.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`message`&nbsp;&nbsp;-&nbsp;&nbsp;The log message.<br />
>
><b>Returns:</b> A new `Atc.Data.Models.LogItem` instance with UI severity.
#### CreateUi
>```csharp
>LogKeyValueItem CreateUi(string key, string value, string description)
>```
><b>Summary:</b> Creates a new `Atc.Data.Models.LogItem` with UI severity.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`message`&nbsp;&nbsp;-&nbsp;&nbsp;The log message.<br />
>
><b>Returns:</b> A new `Atc.Data.Models.LogItem` instance with UI severity.
#### CreateWarning
>```csharp
>LogItem CreateWarning(string message)
>```
><b>Summary:</b> Creates a new `Atc.Data.Models.LogItem` with warning severity.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`message`&nbsp;&nbsp;-&nbsp;&nbsp;The log message.<br />
>
><b>Returns:</b> A new `Atc.Data.Models.LogItem` instance with warning severity.
#### CreateWarning
>```csharp
>LogKeyValueItem CreateWarning(string key, string value)
>```
><b>Summary:</b> Creates a new `Atc.Data.Models.LogItem` with warning severity.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`message`&nbsp;&nbsp;-&nbsp;&nbsp;The log message.<br />
>
><b>Returns:</b> A new `Atc.Data.Models.LogItem` instance with warning severity.
#### CreateWarning
>```csharp
>LogKeyValueItem CreateWarning(string key, string value, string description)
>```
><b>Summary:</b> Creates a new `Atc.Data.Models.LogItem` with warning severity.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`message`&nbsp;&nbsp;-&nbsp;&nbsp;The log message.<br />
>
><b>Returns:</b> A new `Atc.Data.Models.LogItem` instance with warning severity.
<hr /><div style='text-align: right'><i>Generated by MarkdownCodeDoc version 1.2</i></div>
