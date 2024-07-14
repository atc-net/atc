<div style='text-align: right'>

[References](Index.md)&nbsp;&nbsp;-&nbsp;&nbsp;[References extended](IndexExtended.md)
</div>

# Atc.Serialization.JsonConverters

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

## JsonCultureInfoToLcidConverter

>```csharp
>public class JsonCultureInfoToLcidConverter : JsonConverter<CultureInfo>
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

## JsonCultureInfoToNameConverter

>```csharp
>public class JsonCultureInfoToNameConverter : JsonConverter<CultureInfo>
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

## JsonDateTimeOffsetMinToNullConverter

>```csharp
>public class JsonDateTimeOffsetMinToNullConverter : JsonConverter<DateTimeOffset?>
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

## JsonDirectoryInfoToFullNameConverter

>```csharp
>public class JsonDirectoryInfoToFullNameConverter : JsonConverter<DirectoryInfo>
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

## JsonElementObjectConverter

>```csharp
>public class JsonElementObjectConverter : JsonConverter<object>
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

## JsonFileInfoToFullNameConverter

>```csharp
>public class JsonFileInfoToFullNameConverter : JsonConverter<FileInfo>
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

## JsonNumberToStringConverter

>```csharp
>public class JsonNumberToStringConverter : JsonConverter<object>
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

## JsonStringEnumMemberConverter&lt;T&gt;

>```csharp
>public class JsonStringEnumMemberConverter&lt;T&gt; : JsonConverter<T>
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

## JsonTimeSpanConverter

>```csharp
>public class JsonTimeSpanConverter : JsonConverter<TimeSpan>
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

## JsonTypeDiscriminatorConverter&lt;T&gt;

>```csharp
>public class JsonTypeDiscriminatorConverter&lt;T&gt; : JsonConverter<T>
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

## JsonUnixDateTimeOffsetConverter

>```csharp
>public class JsonUnixDateTimeOffsetConverter : JsonConverter<DateTimeOffset?>
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

## JsonUriToAbsoluteUriConverter

>```csharp
>public class JsonUriToAbsoluteUriConverter : JsonConverter<Uri>
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

## JsonVersionConverter

>```csharp
>public class JsonVersionConverter : JsonConverter<Version>
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
