<div style='text-align: right'>

[References](Index.md)&nbsp;&nbsp;-&nbsp;&nbsp;[References extended](IndexExtended.md)
</div>

# Atc.Serialization

<br />

## DynamicJson
DynamicJson can update a json document by adding or removing elements by dot annotation.
<b>Code example:</b>
>```csharp
>Load a json document and set a property value like the following:
>
>var dynamicJson = new DynamicJson(json);
>dynamicJson.SetValue("Property1.Property2", "StrValue2");
>json = dynamicJson.ToJson();
>```

>```csharp
>public class DynamicJson
>```

### Properties

#### JsonDictionary
>```csharp
>JsonDictionary
>```
><b>Summary:</b> Gets the underlying JSON dictionary representation.
### Methods

#### GetValue
>```csharp
>object GetValue(string path)
>```
><b>Summary:</b> Gets the value at the specified path in the JSON structure.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`path`&nbsp;&nbsp;-&nbsp;&nbsp;The dot-notation path to the value (e.g., "Property1.Property2" or "Array[0].Property").<br />
>
><b>Returns:</b> The value at the specified path, or null if the path does not exist.
#### RemovePath
>```csharp
>ValueTuple<bool, string> RemovePath(string path)
>```
><b>Summary:</b> Removes the property at the specified path from the JSON structure.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`path`&nbsp;&nbsp;-&nbsp;&nbsp;The dot-notation path to the property to remove (e.g., "Property1.Property2").<br />
>
><b>Returns:</b> A tuple indicating whether the operation succeeded and an error message if it failed.
#### SetValue
>```csharp
>ValueTuple<bool, string> SetValue(string path, object value, bool createKeyIfNotExist = True)
>```
><b>Summary:</b> Sets the value at the specified path in the JSON structure.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`path`&nbsp;&nbsp;-&nbsp;&nbsp;The dot-notation path to the value (e.g., "Property1.Property2" or "Array[0].Property").<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value to set at the specified path.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`createKeyIfNotExist`&nbsp;&nbsp;-&nbsp;&nbsp;If true, creates intermediate objects and properties as needed. Default is true.<br />
>
><b>Returns:</b> A tuple indicating whether the operation succeeded and an error message if it failed.
#### ToJson
>```csharp
>string ToJson(bool orderByKey = False)
>```
><b>Summary:</b> Converts the JSON structure to a JSON string representation.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`orderByKey`&nbsp;&nbsp;-&nbsp;&nbsp;If true, sorts the JSON properties alphabetically by key. Default is false.<br />
>
><b>Returns:</b> A JSON string representation of the structure.
#### ToJson
>```csharp
>string ToJson(JsonSerializerOptions serializerOptions, bool orderByKey = False)
>```
><b>Summary:</b> Converts the JSON structure to a JSON string representation.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`orderByKey`&nbsp;&nbsp;-&nbsp;&nbsp;If true, sorts the JSON properties alphabetically by key. Default is false.<br />
>
><b>Returns:</b> A JSON string representation of the structure.
#### ToString
>```csharp
>string ToString()
>```
#### ToString
>```csharp
>string ToString(JsonSerializerOptions serializerOptions)
>```

<br />

## JsonSerializerFactorySettings
Configuration settings for creating `System.Text.Json.JsonSerializerOptions` instances via `Atc.Serialization.JsonSerializerOptionsFactory`.
><b>Remarks:</b> This class provides a strongly-typed way to configure JSON serialization behavior including naming policies, null value handling, formatting, and custom converter registration. All settings have sensible defaults optimized for typical API scenarios.

>```csharp
>public class JsonSerializerFactorySettings
>```

### Properties

#### IgnoreNullValues
>```csharp
>IgnoreNullValues
>```
><b>Summary:</b> Gets or sets a value indicating whether to read/write properties and ignoring null values.
#### PropertyNameCaseInsensitive
>```csharp
>PropertyNameCaseInsensitive
>```
><b>Summary:</b> Gets or sets a value indicating whether to read/write properties and ignoring casing.
#### UseCamelCase
>```csharp
>UseCamelCase
>```
><b>Summary:</b> Gets or sets a value indicating whether to read/write properties using camelCase.
#### UseConverterDatetimeOffsetMinToNull
>```csharp
>UseConverterDatetimeOffsetMinToNull
>```
><b>Summary:</b> Gets or sets a value indicating whether to utilize datetimeOffsetMinToNullConverter.
#### UseConverterEnumAsString
>```csharp
>UseConverterEnumAsString
>```
><b>Summary:</b> Gets or sets a value indicating whether to utilize enumAsStringConverter.
#### UseConverterTimespan
>```csharp
>UseConverterTimespan
>```
><b>Summary:</b> Gets or sets a value indicating whether to utilize timespanConverter.
#### UseConverterUnixDatetimeOffset
>```csharp
>UseConverterUnixDatetimeOffset
>```
><b>Summary:</b> Gets or sets a value indicating whether to utilize UnixDateTimeOffsetConverter.
#### UseConverterVersion
>```csharp
>UseConverterVersion
>```
><b>Summary:</b> Gets or sets a value indicating whether to utilize VersionConverter.
#### WriteIndented
>```csharp
>WriteIndented
>```
><b>Summary:</b> Gets or sets a value indicating whether to read/write properties indented.

<br />

## JsonSerializerOptionsFactory
Factory class for creating preconfigured `System.Text.Json.JsonSerializerOptions` instances.
><b>Remarks:</b> This factory provides convenient methods to create `System.Text.Json.JsonSerializerOptions` with common settings and custom converters. It supports both parameter-based and settings-based configuration.

>```csharp
>public static class JsonSerializerOptionsFactory
>```

### Static Methods

#### Create
>```csharp
>JsonSerializerOptions Create(bool useCamelCase = True, bool ignoreNullValues = True, bool propertyNameCaseInsensitive = True, bool writeIndented = True)
>```
><b>Summary:</b> Creates a new `System.Text.Json.JsonSerializerOptions` instance with the specified parameters.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`useCamelCase`&nbsp;&nbsp;-&nbsp;&nbsp;If true, uses camelCase for property names. Default is true.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`ignoreNullValues`&nbsp;&nbsp;-&nbsp;&nbsp;If true, ignores null values during serialization. Default is true.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`propertyNameCaseInsensitive`&nbsp;&nbsp;-&nbsp;&nbsp;If true, property name matching is case-insensitive. Default is true.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`writeIndented`&nbsp;&nbsp;-&nbsp;&nbsp;If true, writes indented JSON output. Default is true.<br />
>
><b>Returns:</b> A configured `System.Text.Json.JsonSerializerOptions` instance.
#### Create
>```csharp
>JsonSerializerOptions Create(JsonSerializerFactorySettings settings)
>```
><b>Summary:</b> Creates a new `System.Text.Json.JsonSerializerOptions` instance with the specified parameters.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`useCamelCase`&nbsp;&nbsp;-&nbsp;&nbsp;If true, uses camelCase for property names. Default is true.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`ignoreNullValues`&nbsp;&nbsp;-&nbsp;&nbsp;If true, ignores null values during serialization. Default is true.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`propertyNameCaseInsensitive`&nbsp;&nbsp;-&nbsp;&nbsp;If true, property name matching is case-insensitive. Default is true.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`writeIndented`&nbsp;&nbsp;-&nbsp;&nbsp;If true, writes indented JSON output. Default is true.<br />
>
><b>Returns:</b> A configured `System.Text.Json.JsonSerializerOptions` instance.
<hr /><div style='text-align: right'><i>Generated by MarkdownCodeDoc version 1.2</i></div>
