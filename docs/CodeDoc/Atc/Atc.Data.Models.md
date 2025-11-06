<div style='text-align: right'>

[References](Index.md)&nbsp;&nbsp;-&nbsp;&nbsp;[References extended](IndexExtended.md)
</div>

# Atc.Data.Models

<br />

## AssemblyInformation
AssemblyInformation.

>```csharp
>public class AssemblyInformation
>```

### Properties

#### Copyright
>```csharp
>Copyright
>```
><b>Summary:</b> Gets or sets the copyright.
#### FullName
>```csharp
>FullName
>```
><b>Summary:</b> Gets or sets the full name.
#### IsDebugBuild
>```csharp
>IsDebugBuild
>```
><b>Summary:</b> Gets or sets the is debug build.
#### Name
>```csharp
>Name
>```
><b>Summary:</b> Gets or sets the name.
#### SourcePath
>```csharp
>SourcePath
>```
><b>Summary:</b> Gets or sets the source path.
#### TargetFrameworkDisplayName
>```csharp
>TargetFrameworkDisplayName
>```
><b>Summary:</b> Gets or sets the display name of the target framework.
#### TargetFrameworkName
>```csharp
>TargetFrameworkName
>```
><b>Summary:</b> Gets or sets the name of the target framework.
#### Version
>```csharp
>Version
>```
><b>Summary:</b> Gets or sets the version.
### Methods

#### ToString
>```csharp
>string ToString()
>```

<br />

## Culture
Represents culture information including country, language, currency, and formatting details.

>```csharp
>public class Culture
>```

### Properties

#### CountryCodeA2
>```csharp
>CountryCodeA2
>```
><b>Summary:</b> Gets or sets the country code a2.
#### CountryCodeA3
>```csharp
>CountryCodeA3
>```
><b>Summary:</b> Gets or sets the country code a3.
#### CountryDisplayName
>```csharp
>CountryDisplayName
>```
><b>Summary:</b> Gets or sets the display name of the country.
#### CountryEnglishName
>```csharp
>CountryEnglishName
>```
><b>Summary:</b> Gets or sets the name of the country english.
#### CurrencySymbol
>```csharp
>CurrencySymbol
>```
><b>Summary:</b> Gets or sets the currency symbol.
#### IsoCurrencySymbol
>```csharp
>IsoCurrencySymbol
>```
><b>Summary:</b> Gets or sets the ISO currency symbol.
#### LanguageCodeA2
>```csharp
>LanguageCodeA2
>```
><b>Summary:</b> Gets or sets the language code a2.
#### LanguageCodeA3
>```csharp
>LanguageCodeA3
>```
><b>Summary:</b> Gets or sets the language code a3.
#### LanguageDisplayName
>```csharp
>LanguageDisplayName
>```
><b>Summary:</b> Gets or sets the display name of the language.
#### LanguageEnglishName
>```csharp
>LanguageEnglishName
>```
><b>Summary:</b> Gets or sets the name of the language english.
#### Lcid
>```csharp
>Lcid
>```
><b>Summary:</b> Gets or sets the lcid.
#### LongTimePattern
>```csharp
>LongTimePattern
>```
><b>Summary:</b> Gets or sets the long time pattern.
#### Name
>```csharp
>Name
>```
><b>Summary:</b> Gets or sets the name.
#### NumberDecimalSeparator
>```csharp
>NumberDecimalSeparator
>```
><b>Summary:</b> Gets or sets the number decimal separator.
#### ShortDatePattern
>```csharp
>ShortDatePattern
>```
><b>Summary:</b> Gets or sets the short date pattern.
### Methods

#### ToString
>```csharp
>string ToString()
>```

<br />

## HttpClientRequestResult&lt;TData&gt;
Represents the result of an HTTP client request, including status, data, and error information.

>```csharp
>public class HttpClientRequestResult&lt;TData&gt;
>```

### Properties

#### CommunicationSucceeded
>```csharp
>CommunicationSucceeded
>```
><b>Summary:</b> Gets or sets a value indicating whether the communication succeeded.
#### Data
>```csharp
>Data
>```
><b>Summary:</b> Gets or sets the response data.
#### Exception
>```csharp
>Exception
>```
><b>Summary:</b> Gets or sets the exception that occurred during the request.
#### HasData
>```csharp
>HasData
>```
><b>Summary:</b> Gets a value indicating whether the result contains data.
#### HasException
>```csharp
>HasException
>```
><b>Summary:</b> Gets a value indicating whether the result contains an exception.
#### HasMessage
>```csharp
>HasMessage
>```
><b>Summary:</b> Gets a value indicating whether the result contains a message.
#### Message
>```csharp
>Message
>```
><b>Summary:</b> Gets or sets the result message.
#### StatusCode
>```csharp
>StatusCode
>```
><b>Summary:</b> Gets or sets the HTTP status code.
### Methods

#### GetErrorMessageOrMessage
>```csharp
>string GetErrorMessageOrMessage()
>```
><b>Summary:</b> Gets the error message from the exception, or the result message if no exception exists.
>
><b>Returns:</b> The error message or result message, or an empty string if neither exists.
#### ToString
>```csharp
>string ToString()
>```

<br />

## IdValueItem
Represents a key-value pair with a GUID identifier and a string value.

>```csharp
>public class IdValueItem
>```

### Properties

#### Id
>```csharp
>Id
>```
><b>Summary:</b> Gets or sets the unique identifier.
#### Value
>```csharp
>Value
>```
><b>Summary:</b> Gets or sets the value.
### Methods

#### ToString
>```csharp
>string ToString()
>```

<br />

## KeyValueItem
Represents a key-value pair with string key and value.

>```csharp
>public class KeyValueItem
>```

### Properties

#### Key
>```csharp
>Key
>```
><b>Summary:</b> Gets or sets the key.
#### Value
>```csharp
>Value
>```
><b>Summary:</b> Gets or sets the value.
### Methods

#### ToString
>```csharp
>string ToString()
>```

<br />

## LogItem
Represents a log entry with timestamp, severity, and message.

>```csharp
>public class LogItem
>```

### Properties

#### Message
>```csharp
>Message
>```
><b>Summary:</b> Gets or sets the message.
#### Severity
>```csharp
>Severity
>```
><b>Summary:</b> Gets or sets the severity.
#### TimeStamp
>```csharp
>TimeStamp
>```
><b>Summary:</b> Gets or sets the time stamp.
### Methods

#### ToString
>```csharp
>string ToString()
>```

<br />

## LogKeyValueItem
Represents a log entry with a key-value pair, log category, and optional description. Extends `Atc.Data.Models.KeyValueItem` to add logging-specific functionality.

>```csharp
>public class LogKeyValueItem : KeyValueItem
>```

### Properties

#### Description
>```csharp
>Description
>```
><b>Summary:</b> Gets or sets the description.
#### LogCategory
>```csharp
>LogCategory
>```
><b>Summary:</b> Gets or sets the log category.
### Methods

#### GetLogMessage
>```csharp
>string GetLogMessage(bool includeKey = True, bool includeDescription = True)
>```
><b>Summary:</b> Gets the log message.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`includeKey`&nbsp;&nbsp;-&nbsp;&nbsp;if set to  [include key].<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`includeDescription`&nbsp;&nbsp;-&nbsp;&nbsp;if set to  [include description].<br />
#### ToString
>```csharp
>string ToString()
>```
<hr /><div style='text-align: right'><i>Generated by MarkdownCodeDoc version 1.2</i></div>
