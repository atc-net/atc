<div style='text-align: right'>

[References](Index.md)&nbsp;&nbsp;-&nbsp;&nbsp;[References extended](IndexExtended.md)
</div>

# System.ComponentModel.DataAnnotations

<br />

## IPAddressAttribute
Validates that a property, field, or parameter contains a valid IP address. Supports both IPv4 and IPv6 address formats.

>```csharp
>public class IPAddressAttribute : ValidationAttribute
>```

### Static Methods

#### TryIsValid
>```csharp
>bool TryIsValid(string value, out string errorMessage)
>```
><b>Summary:</b> Attempts to validate the specified string as an IP address using default validation settings.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The string value to validate.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`errorMessage`&nbsp;&nbsp;-&nbsp;&nbsp;When validation fails, contains a message describing the validation error.<br />
>
><b>Returns:</b> `true` if the value is a valid IP address; otherwise, `false`.
#### TryIsValid
>```csharp
>bool TryIsValid(string value, IPAddressAttribute attribute, out string errorMessage)
>```
><b>Summary:</b> Attempts to validate the specified string as an IP address using default validation settings.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The string value to validate.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`errorMessage`&nbsp;&nbsp;-&nbsp;&nbsp;When validation fails, contains a message describing the validation error.<br />
>
><b>Returns:</b> `true` if the value is a valid IP address; otherwise, `false`.
### Properties

#### Required
>```csharp
>Required
>```
><b>Summary:</b> Gets or sets a value indicating whether the IP address value is required.
### Methods

#### IsValid
>```csharp
>bool IsValid(object value)
>```

<br />

## IsoCurrencySymbolAttribute
Validates that a property, field, or parameter contains a valid ISO 4217 currency code. The value must be a three-character uppercase string (e.g., USD, EUR, GBP). Optionally validates against a specific set of allowed currency codes.

>```csharp
>public class IsoCurrencySymbolAttribute : ValidationAttribute
>```

### Properties

#### IsoCurrencySymbols
>```csharp
>IsoCurrencySymbols
>```
><b>Summary:</b> Gets or sets an optional array of specific ISO currency codes that are allowed. If empty, all valid ISO currency codes from available cultures are accepted.
#### Required
>```csharp
>Required
>```
><b>Summary:</b> Gets or sets a value indicating whether the currency code value is required.
### Methods

#### IsValid
>```csharp
>bool IsValid(object value)
>```

<br />

## KeyStringAttribute
Validates that a property or field contains a valid key string. By default, excludes spaces, periods, at signs, and apostrophes, and disallows strings starting with underscores. This attribute extends `System.ComponentModel.DataAnnotations.StringAttribute` with key-specific validation rules.

>```csharp
>public class KeyStringAttribute : StringAttribute
>```

### Static Methods

#### TryIsValid
>```csharp
>bool TryIsValid(string value, out string errorMessage)
>```
><b>Summary:</b> Attempts to validate the specified string as a key string using default validation settings.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The string value to validate.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`errorMessage`&nbsp;&nbsp;-&nbsp;&nbsp;When validation fails, contains a message describing the validation error.<br />
>
><b>Returns:</b> `true` if the value is a valid key string; otherwise, `false`.
#### TryIsValid
>```csharp
>bool TryIsValid(string value, KeyStringAttribute attribute, out string errorMessage)
>```
><b>Summary:</b> Attempts to validate the specified string as a key string using default validation settings.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The string value to validate.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`errorMessage`&nbsp;&nbsp;-&nbsp;&nbsp;When validation fails, contains a message describing the validation error.<br />
>
><b>Returns:</b> `true` if the value is a valid key string; otherwise, `false`.

<br />

## RegularExpressionAttributeExtensions
Extension methods for `System.ComponentModel.DataAnnotations.RegularExpressionAttribute`.

>```csharp
>public static class RegularExpressionAttributeExtensions
>```

### Static Methods

#### GetEscapedPattern
>```csharp
>string GetEscapedPattern(this RegularExpressionAttribute regularExpressionAttribute, bool ensureQuotes = True)
>```
><b>Summary:</b> Gets the escaped pattern from a `System.ComponentModel.DataAnnotations.RegularExpressionAttribute` suitable for code generation.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`regularExpressionAttribute`&nbsp;&nbsp;-&nbsp;&nbsp;The regular expression attribute.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`ensureQuotes`&nbsp;&nbsp;-&nbsp;&nbsp;If set to , ensures the result is wrapped in double quotes.<br />
>
><b>Returns:</b> The escaped pattern string.

<br />

## StringAttribute
Validates that a property, field, or parameter contains a string value meeting specified constraints. Supports validation of length, invalid characters, invalid prefixes, and regular expression patterns.

>```csharp
>public class StringAttribute : ValidationAttribute
>```

### Static Methods

#### TryIsValid
>```csharp
>bool TryIsValid(string value, out string errorMessage)
>```
><b>Summary:</b> Attempts to validate the specified string using default validation settings.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The string value to validate.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`errorMessage`&nbsp;&nbsp;-&nbsp;&nbsp;When validation fails, contains a message describing the validation error.<br />
>
><b>Returns:</b> `true` if the value is valid; otherwise, `false`.
#### TryIsValid
>```csharp
>bool TryIsValid(string value, StringAttribute attribute, out string errorMessage)
>```
><b>Summary:</b> Attempts to validate the specified string using default validation settings.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The string value to validate.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`errorMessage`&nbsp;&nbsp;-&nbsp;&nbsp;When validation fails, contains a message describing the validation error.<br />
>
><b>Returns:</b> `true` if the value is valid; otherwise, `false`.
### Properties

#### InvalidCharacters
>```csharp
>InvalidCharacters
>```
><b>Summary:</b> Gets or sets an array of characters that are not allowed in the string.
#### InvalidPrefixStrings
>```csharp
>InvalidPrefixStrings
>```
><b>Summary:</b> Gets or sets an array of prefixes that the string cannot start with.
#### MaxLength
>```csharp
>MaxLength
>```
><b>Summary:</b> Gets or sets the maximum allowed length of the string.
#### MinLength
>```csharp
>MinLength
>```
><b>Summary:</b> Gets or sets the minimum allowed length of the string.
#### RegularExpression
>```csharp
>RegularExpression
>```
><b>Summary:</b> Gets or sets a regular expression pattern that the string must match. If set, the string will be validated against this pattern with a 2-second timeout.
#### Required
>```csharp
>Required
>```
><b>Summary:</b> Gets or sets a value indicating whether the string value is required.
### Methods

#### IsValid
>```csharp
>bool IsValid(object value)
>```

<br />

## UriAttribute
Validates that a property, field, or parameter contains a valid URI with an allowed scheme. Supports HTTP, HTTPS, FTP, FTPS, File, and OPC TCP schemes.

>```csharp
>public class UriAttribute : ValidationAttribute
>```

### Static Methods

#### TryIsValid
>```csharp
>bool TryIsValid(string value, out string errorMessage)
>```
><b>Summary:</b> Attempts to validate the specified string as a URI using default validation settings (all schemes allowed).
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The string value to validate.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`errorMessage`&nbsp;&nbsp;-&nbsp;&nbsp;When validation fails, contains a message describing the validation error.<br />
>
><b>Returns:</b> `true` if the value is a valid URI; otherwise, `false`.
#### TryIsValid
>```csharp
>bool TryIsValid(string value, UriAttribute attribute, out string errorMessage)
>```
><b>Summary:</b> Attempts to validate the specified string as a URI using default validation settings (all schemes allowed).
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The string value to validate.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`errorMessage`&nbsp;&nbsp;-&nbsp;&nbsp;When validation fails, contains a message describing the validation error.<br />
>
><b>Returns:</b> `true` if the value is a valid URI; otherwise, `false`.
### Properties

#### AllowFile
>```csharp
>AllowFile
>```
><b>Summary:</b> Gets or sets a value indicating whether the File scheme is allowed.
#### AllowFtp
>```csharp
>AllowFtp
>```
><b>Summary:</b> Gets or sets a value indicating whether the FTP scheme is allowed.
#### AllowFtps
>```csharp
>AllowFtps
>```
><b>Summary:</b> Gets or sets a value indicating whether the FTPS scheme is allowed.
#### AllowHttp
>```csharp
>AllowHttp
>```
><b>Summary:</b> Gets or sets a value indicating whether the HTTP scheme is allowed.
#### AllowHttps
>```csharp
>AllowHttps
>```
><b>Summary:</b> Gets or sets a value indicating whether the HTTPS scheme is allowed.
#### AllowOpcTcp
>```csharp
>AllowOpcTcp
>```
><b>Summary:</b> Gets or sets a value indicating whether the OPC TCP scheme is allowed.
#### Required
>```csharp
>Required
>```
><b>Summary:</b> Gets or sets a value indicating whether the URI value is required.
### Methods

#### IsValid
>```csharp
>bool IsValid(object value)
>```
<hr /><div style='text-align: right'><i>Generated by MarkdownCodeDoc version 1.2</i></div>
