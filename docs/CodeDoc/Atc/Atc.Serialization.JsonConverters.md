<div style='text-align: right'>

[References](Index.md)&nbsp;&nbsp;-&nbsp;&nbsp;[References extended](IndexExtended.md)
</div>

# Atc.Serialization.JsonConverters

<br />

## CultureInfoToLcidJsonConverter

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

>```csharp
>public interface ITypeDiscriminator
>```

### Properties

#### TypeDiscriminator
>```csharp
>TypeDiscriminator
>```

<br />

## InterfaceJsonConverter&lt;TInterface&gt;

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
