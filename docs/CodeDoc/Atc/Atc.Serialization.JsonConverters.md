<div style='text-align: right'>

[References](Index.md)&nbsp;&nbsp;-&nbsp;&nbsp;[References extended](IndexExtended.md)
</div>

# Atc.Serialization.JsonConverters

<br />

## CultureInfoToLcidJsonConverter
JSON converter that serializes `System.Globalization.CultureInfo` objects to and from their LCID (Locale ID) integer representation.
><b>Remarks:</b> This converter writes `System.Globalization.CultureInfo` as an integer LCID value (e.g., 1033 for en-US) and reads integer LCID values back into `System.Globalization.CultureInfo` objects. Null values are preserved during serialization and deserialization.

>```csharp
>public class CultureInfoToLcidJsonConverter : JsonConverter<CultureInfo>
>```

### Methods

#### Read
>```csharp
>CultureInfo Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
>```
#### Write
>```csharp
>void Write(Utf8JsonWriter writer, CultureInfo value, JsonSerializerOptions options)
>```

<br />

## CultureInfoToNameJsonConverter
JSON converter that serializes `System.Globalization.CultureInfo` objects to and from their culture name string representation.
><b>Remarks:</b> This converter writes `System.Globalization.CultureInfo` as its `System.Globalization.CultureInfo.Name` property value (e.g., "en-US", "da-DK") and reads culture name strings back into `System.Globalization.CultureInfo` objects. Null or empty values are preserved.

>```csharp
>public class CultureInfoToNameJsonConverter : JsonConverter<CultureInfo>
>```

### Methods

#### Read
>```csharp
>CultureInfo Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
>```
#### Write
>```csharp
>void Write(Utf8JsonWriter writer, CultureInfo value, JsonSerializerOptions options)
>```

<br />

## DateTimeOffsetMinToNullJsonConverter
JSON converter that serializes `System.DateTimeOffset` values to and from ISO 8601 string format, treating `System.DateTimeOffset.MinValue` as null.
><b>Remarks:</b> This converter writes `System.DateTimeOffset` values as ISO 8601 UTC strings. When reading or writing, `System.DateTimeOffset.MinValue` is treated as null and serialized as a JSON null value. All dates are normalized to UTC during serialization and deserialization.

>```csharp
>public class DateTimeOffsetMinToNullJsonConverter : JsonConverter<DateTimeOffset?>
>```

### Methods

#### Read
>```csharp
>DateTimeOffset? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
>```
#### Write
>```csharp
>void Write(Utf8JsonWriter writer, DateTimeOffset? value, JsonSerializerOptions options)
>```

<br />

## DirectoryInfoToFullNameJsonConverter
JSON converter that serializes `System.IO.DirectoryInfo` objects to and from their full directory path string representation.
><b>Remarks:</b> This converter writes `System.IO.DirectoryInfo` as its FullName property value and reads directory path strings back into `System.IO.DirectoryInfo` objects. Null or empty values are preserved.

>```csharp
>public class DirectoryInfoToFullNameJsonConverter : JsonConverter<DirectoryInfo>
>```

### Methods

#### Read
>```csharp
>DirectoryInfo Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
>```
#### Write
>```csharp
>void Write(Utf8JsonWriter writer, DirectoryInfo value, JsonSerializerOptions options)
>```

<br />

## ElementObjectJsonConverter
JSON converter that deserializes JSON elements into appropriate CLR object types (dictionaries, lists, primitives).
><b>Remarks:</b> This converter is used internally by `Atc.Serialization.DynamicJson` to convert JSON structures into dynamic objects. It maps JSON objects to `System.Collections.Generic.Dictionary`2`, JSON arrays to `System.Collections.Generic.List`1`, and JSON primitives to their corresponding CLR types. This converter only supports reading; writing is not supported.

>```csharp
>public class ElementObjectJsonConverter : JsonConverter<object>
>```

### Methods

#### Read
>```csharp
>object Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
>```
#### Write
>```csharp
>void Write(Utf8JsonWriter writer, object value, JsonSerializerOptions options)
>```

<br />

## FileInfoToFullNameJsonConverter
JSON converter that serializes `System.IO.FileInfo` objects to and from their full file path string representation.
><b>Remarks:</b> This converter writes `System.IO.FileInfo` as its FullName property value and reads file path strings back into `System.IO.FileInfo` objects. Null or empty values are preserved.

>```csharp
>public class FileInfoToFullNameJsonConverter : JsonConverter<FileInfo>
>```

### Methods

#### Read
>```csharp
>FileInfo Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
>```
#### Write
>```csharp
>void Write(Utf8JsonWriter writer, FileInfo value, JsonSerializerOptions options)
>```

<br />

## ITypeDiscriminator
Defines a contract for objects that expose a type discriminator property for polymorphic JSON serialization.
><b>Remarks:</b> Types implementing this interface can be used with `Atc.Serialization.JsonConverters.TypeDiscriminatorJsonConverter`1` to enable deserialization of polymorphic objects based on a discriminator field in the JSON payload.

>```csharp
>public interface ITypeDiscriminator
>```

### Properties

#### TypeDiscriminator
>```csharp
>TypeDiscriminator
>```
><b>Summary:</b> Gets the type discriminator value used to identify the concrete type during deserialization.

<br />

## InterfaceJsonConverter&lt;TInterface&gt;
JSON converter that enables deserialization of interface types by using the runtime type information provided during deserialization.
><b>Remarks:</b> This converter allows JSON payloads to be deserialized into interface types by determining the concrete type at runtime. During serialization, it reflects over the runtime type's properties to write all public readable properties to JSON.

>```csharp
>public class InterfaceJsonConverter&lt;TInterface&gt; : JsonConverter<TInterface>
>```

### Methods

#### Read
>```csharp
>TInterface Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
>```
#### Write
>```csharp
>void Write(Utf8JsonWriter writer, TInterface value, JsonSerializerOptions options)
>```

<br />

## NumberToStringJsonConverter
JSON converter that converts numeric values to string representation and vice versa.
><b>Remarks:</b> This converter handles conversion between JSON numbers and strings, allowing numeric values in JSON to be read as strings. During deserialization, JSON numbers are converted to their string representation using the current thread's culture. During serialization, any object is converted to its string representation.

>```csharp
>public class NumberToStringJsonConverter : JsonConverter<object>
>```

### Methods

#### CanConvert
>```csharp
>bool CanConvert(Type typeToConvert)
>```
#### Read
>```csharp
>object Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
>```
#### Write
>```csharp
>void Write(Utf8JsonWriter writer, object value, JsonSerializerOptions options)
>```

<br />

## StringEnumMemberJsonConverter&lt;TEnum&gt;
JSON converter that serializes enum values to and from their string representation, respecting `System.Runtime.Serialization.EnumMemberAttribute` values.
><b>Remarks:</b> This converter reads enum values from their string representation and respects `System.Runtime.Serialization.EnumMemberAttribute` values if present. During serialization, it writes the `System.Runtime.Serialization.EnumMemberAttribute.Value` if present, otherwise the enum's name. The casing of the output string respects the `System.Text.Json.JsonSerializerOptions.PropertyNamingPolicy`.

>```csharp
>public class StringEnumMemberJsonConverter&lt;TEnum&gt; : JsonConverter<TEnum>
>```

### Methods

#### Read
>```csharp
>TEnum Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
>```
#### Write
>```csharp
>void Write(Utf8JsonWriter writer, TEnum value, JsonSerializerOptions options)
>```

<br />

## TimeSpanJsonConverter
JSON converter that serializes `System.TimeSpan` values to and from their string representation.
><b>Remarks:</b> This converter writes `System.TimeSpan` values as culture-invariant strings and reads string values back into `System.TimeSpan` objects using `System.Globalization.CultureInfo.InvariantCulture` for parsing.

>```csharp
>public class TimeSpanJsonConverter : JsonConverter<TimeSpan>
>```

### Methods

#### Read
>```csharp
>TimeSpan Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
>```
#### Write
>```csharp
>void Write(Utf8JsonWriter writer, TimeSpan value, JsonSerializerOptions options)
>```

<br />

## TypeDiscriminatorJsonConverter&lt;T&gt;
JSON converter that enables polymorphic deserialization based on a type discriminator property.
><b>Remarks:</b> This converter enables deserialization of polymorphic types by reading a discriminator property from the JSON payload and matching it to concrete types in the current application domain. All concrete types implementing `T` are discovered at runtime and used for type resolution based on the TypeDiscriminator property value.

>```csharp
>public class TypeDiscriminatorJsonConverter&lt;T&gt; : JsonConverter<T>
>```

### Methods

#### Read
>```csharp
>T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
>```
#### Write
>```csharp
>void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
>```

<br />

## UnixDateTimeOffsetJsonConverter
JSON converter that serializes `System.DateTimeOffset` values to and from Unix timestamp (seconds since epoch) representation.
><b>Remarks:</b> This converter writes `System.DateTimeOffset` values as Unix timestamps (64-bit integers representing seconds since 1970-01-01T00:00:00Z) and reads Unix timestamp integers back into `System.DateTimeOffset` objects. `System.DateTimeOffset.MinValue` is treated as null.

>```csharp
>public class UnixDateTimeOffsetJsonConverter : JsonConverter<DateTimeOffset?>
>```

### Methods

#### Read
>```csharp
>DateTimeOffset? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
>```
#### Write
>```csharp
>void Write(Utf8JsonWriter writer, DateTimeOffset? value, JsonSerializerOptions options)
>```

<br />

## UriToAbsoluteUriJsonConverter
JSON converter that serializes `System.Uri` objects to and from their absolute URI string representation.
><b>Remarks:</b> This converter writes `System.Uri` objects as their `System.Uri.AbsoluteUri` property value and reads absolute URI strings back into `System.Uri` objects. Null or empty values are preserved.

>```csharp
>public class UriToAbsoluteUriJsonConverter : JsonConverter<Uri>
>```

### Methods

#### Read
>```csharp
>Uri Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
>```
#### Write
>```csharp
>void Write(Utf8JsonWriter writer, Uri value, JsonSerializerOptions options)
>```

<br />

## VersionJsonConverter
JSON converter that serializes `System.Version` objects to and from their string representation.
><b>Remarks:</b> This converter supports reading `System.Version` from both string format (e.g., "1.2.3.4") and object format with internal fields (_Major, _Minor, _Build, _Revision). During writing, `System.Version` is always serialized as a string. If parsing fails, a default empty `System.Version` is returned.

>```csharp
>public class VersionJsonConverter : JsonConverter<Version>
>```

### Methods

#### Read
>```csharp
>Version Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
>```
#### Write
>```csharp
>void Write(Utf8JsonWriter writer, Version value, JsonSerializerOptions options)
>```
<hr /><div style='text-align: right'><i>Generated by MarkdownCodeDoc version 1.2</i></div>
