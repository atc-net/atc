<div style='text-align: right'>

[References](Index.md)&nbsp;&nbsp;-&nbsp;&nbsp;[References extended](IndexExtended.md)
</div>

# Atc.Data

<br />

## AssemblyInformationFactory

>```csharp
>public static class AssemblyInformationFactory
>```

### Static Methods

#### Create
>```csharp
>AssemblyInformation Create(Assembly assembly)
>```

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

>```csharp
>public static class LogItemFactory
>```

### Static Methods

#### Create
>```csharp
>LogItem Create(LogCategoryType logCategoryType, string message)
>```
#### Create
>```csharp
>LogKeyValueItem Create(LogCategoryType logCategoryType, string key, string value)
>```
#### Create
>```csharp
>LogKeyValueItem Create(LogCategoryType logCategoryType, string key, string value, string description)
>```
#### CreateAudit
>```csharp
>LogItem CreateAudit(string message)
>```
#### CreateAudit
>```csharp
>LogKeyValueItem CreateAudit(string key, string value)
>```
#### CreateAudit
>```csharp
>LogKeyValueItem CreateAudit(string key, string value, string description)
>```
#### CreateCritical
>```csharp
>LogItem CreateCritical(string message)
>```
#### CreateCritical
>```csharp
>LogKeyValueItem CreateCritical(string key, string value)
>```
#### CreateCritical
>```csharp
>LogKeyValueItem CreateCritical(string key, string value, string description)
>```
#### CreateDebug
>```csharp
>LogItem CreateDebug(string message)
>```
#### CreateDebug
>```csharp
>LogKeyValueItem CreateDebug(string key, string value)
>```
#### CreateDebug
>```csharp
>LogKeyValueItem CreateDebug(string key, string value, string description)
>```
#### CreateError
>```csharp
>LogItem CreateError(string message)
>```
#### CreateError
>```csharp
>LogKeyValueItem CreateError(string key, string value)
>```
#### CreateError
>```csharp
>LogKeyValueItem CreateError(string key, string value, string description)
>```
#### CreateInformation
>```csharp
>LogItem CreateInformation(string message)
>```
#### CreateInformation
>```csharp
>LogKeyValueItem CreateInformation(string key, string value)
>```
#### CreateInformation
>```csharp
>LogKeyValueItem CreateInformation(string key, string value, string description)
>```
#### CreateSecurity
>```csharp
>LogItem CreateSecurity(string message)
>```
#### CreateSecurity
>```csharp
>LogKeyValueItem CreateSecurity(string key, string value)
>```
#### CreateSecurity
>```csharp
>LogKeyValueItem CreateSecurity(string key, string value, string description)
>```
#### CreateService
>```csharp
>LogItem CreateService(string message)
>```
#### CreateService
>```csharp
>LogKeyValueItem CreateService(string key, string value)
>```
#### CreateService
>```csharp
>LogKeyValueItem CreateService(string key, string value, string description)
>```
#### CreateTrace
>```csharp
>LogItem CreateTrace(string message)
>```
#### CreateTrace
>```csharp
>LogKeyValueItem CreateTrace(string key, string value)
>```
#### CreateTrace
>```csharp
>LogKeyValueItem CreateTrace(string key, string value, string description)
>```
#### CreateUi
>```csharp
>LogItem CreateUi(string message)
>```
#### CreateUi
>```csharp
>LogKeyValueItem CreateUi(string key, string value)
>```
#### CreateUi
>```csharp
>LogKeyValueItem CreateUi(string key, string value, string description)
>```
#### CreateWarning
>```csharp
>LogItem CreateWarning(string message)
>```
#### CreateWarning
>```csharp
>LogKeyValueItem CreateWarning(string key, string value)
>```
#### CreateWarning
>```csharp
>LogKeyValueItem CreateWarning(string key, string value, string description)
>```
<hr /><div style='text-align: right'><i>Generated by MarkdownCodeDoc version 1.2</i></div>
