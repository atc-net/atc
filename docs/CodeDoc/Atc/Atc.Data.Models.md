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
Culture.

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
HttpClientRequestResult.

>```csharp
>public class HttpClientRequestResult&lt;TData&gt;
>```

### Properties

#### CommunicationSucceeded
>```csharp
>CommunicationSucceeded
>```
#### Data
>```csharp
>Data
>```
#### Exception
>```csharp
>Exception
>```
#### HasData
>```csharp
>HasData
>```
#### HasException
>```csharp
>HasException
>```
#### HasMessage
>```csharp
>HasMessage
>```
#### Message
>```csharp
>Message
>```
#### StatusCode
>```csharp
>StatusCode
>```
### Methods

#### GetErrorMessageOrMessage
>```csharp
>string GetErrorMessageOrMessage()
>```
#### ToString
>```csharp
>string ToString()
>```

<br />

## IdValueItem
IdValueItem.

>```csharp
>public class IdValueItem
>```

### Properties

#### Id
>```csharp
>Id
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

## KeyValueItem
KeyValueItem.

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
LogKeyValueItem.

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
LogKeyValueItem.

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
