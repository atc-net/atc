<div style='text-align: right'>

[References](Index.md)&nbsp;&nbsp;-&nbsp;&nbsp;[References extended](IndexExtended.md)
</div>

# Atc.Units.DigitalInformation

<br />

## ByteSize
Represents a size in bytes.

>```csharp
>public struct ByteSize : IEquatable<ByteSize>, IComparable<ByteSize>, IComparable
>```

### Static Methods

#### Parse
>```csharp
>ByteSize Parse(string value)
>```
><b>Summary:</b> Parses a string of digits into a `Atc.Units.DigitalInformation.ByteSize`.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The string to parse. Must represent a valid  value.<br />
>
><b>Returns:</b> A `Atc.Units.DigitalInformation.ByteSize` with the parsed byte count.
#### TryParse
>```csharp
>bool TryParse(string value, out byte result)
>```
><b>Summary:</b> Tries to parse a string into a `Atc.Units.DigitalInformation.ByteSize`.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The string to parse, or .<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`result`&nbsp;&nbsp;-&nbsp;&nbsp;
            When this method returns, contains the parsed 
            if parsing succeeded; otherwise, .
            <br />
>
><b>Returns:</b> <see langword="true" /> if parsing succeeded; otherwise, <see langword="false" />.
### Properties

#### Value
>```csharp
>Value
>```
><b>Summary:</b> Gets the size in bytes.
### Methods

#### CompareTo
>```csharp
>int CompareTo(ByteSize other)
>```
><b>Summary:</b> Compares this instance to another `Atc.Units.DigitalInformation.ByteSize` value.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`other`&nbsp;&nbsp;-&nbsp;&nbsp;The other value to compare to.<br />
>
><b>Returns:</b> A negative number if this instance is less than `other`; zero if they are equal; a positive number if this instance is greater.
#### CompareTo
>```csharp
>int CompareTo(object obj)
>```
><b>Summary:</b> Compares this instance to another `Atc.Units.DigitalInformation.ByteSize` value.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`other`&nbsp;&nbsp;-&nbsp;&nbsp;The other value to compare to.<br />
>
><b>Returns:</b> A negative number if this instance is less than `other`; zero if they are equal; a positive number if this instance is greater.
#### Equals
>```csharp
>bool Equals(ByteSize other)
>```
><b>Summary:</b> Equals the specified other.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`other`&nbsp;&nbsp;-&nbsp;&nbsp;The other.<br />
#### Equals
>```csharp
>bool Equals(object obj)
>```
><b>Summary:</b> Equals the specified other.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`other`&nbsp;&nbsp;-&nbsp;&nbsp;The other.<br />
#### Format
>```csharp
>string Format()
>```
><b>Summary:</b> Returns a `System.String` that represents this instance.
>
><b>Returns:</b> A `System.String` that represents this instance.
>
><b>Remarks:</b> The size is formatted to a human readable format using the default formatter (`Atc.Units.DigitalInformation.ByteSizeFormatter.Default`).
#### Format
>```csharp
>string Format(ByteSizeFormatter formatter)
>```
><b>Summary:</b> Returns a `System.String` that represents this instance.
>
><b>Returns:</b> A `System.String` that represents this instance.
>
><b>Remarks:</b> The size is formatted to a human readable format using the default formatter (`Atc.Units.DigitalInformation.ByteSizeFormatter.Default`).
#### GetHashCode
>```csharp
>int GetHashCode()
>```
#### ToString
>```csharp
>string ToString()
>```
><b>Summary:</b> Returns a `System.String` that represents this instance.
>
><b>Returns:</b> A `System.String` that represents this instance.
>
><b>Remarks:</b> The size is formatted to a human readable format using the default formatter (`Atc.Units.DigitalInformation.ByteSizeFormatter.Default`).
#### ToString
>```csharp
>string ToString(ByteSizeFormatter formatter)
>```
><b>Summary:</b> Returns a `System.String` that represents this instance.
>
><b>Returns:</b> A `System.String` that represents this instance.
>
><b>Remarks:</b> The size is formatted to a human readable format using the default formatter (`Atc.Units.DigitalInformation.ByteSizeFormatter.Default`).

<br />

## ByteSizeFormatter
A formatter that converts a byte size to a human readable string.

>```csharp
>public class ByteSizeFormatter
>```

### Static Properties

#### Default
>```csharp
>Default
>```
><b>Summary:</b> Returns a default instance of ByteSizeFormatter. This formatter will be used by the ByteSize.ToString() method.
### Properties

#### MaxUnit
>```csharp
>MaxUnit
>```
><b>Summary:</b> Gets or sets the largest unit used by the formatter.
#### MinUnit
>```csharp
>MinUnit
>```
><b>Summary:</b> Gets or sets the smallest unit used by the formatter.
#### NumberFormatInfo
>```csharp
>NumberFormatInfo
>```
><b>Summary:</b> Gets or sets the number format information.
#### NumberOfDecimals
>```csharp
>NumberOfDecimals
>```
><b>Summary:</b> Gets or sets the number of decimals.
#### RoundingRule
>```csharp
>RoundingRule
>```
><b>Summary:</b> Gets or sets the rounding rule.
#### SuffixFormat
>```csharp
>SuffixFormat
>```
><b>Summary:</b> Gets or sets a value indicating whether the suffix format should be short or full wording.
### Methods

#### Format
>```csharp
>string Format(long size)
>```
><b>Summary:</b> Formats the specified size.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`size`&nbsp;&nbsp;-&nbsp;&nbsp;The size to format.<br />
>
><b>Returns:</b> The formatted size.

<br />

## ByteSizeRoundingRuleType
Defines rounding rules for byte sizes

>```csharp
>public enum ByteSizeRoundingRuleType
>```


| Value | Name | Description | Summary | 
| --- | --- | --- | --- | 
| 0 | Closest | Closest | Rounded to the closest value | 
| 1 | Down | Down | Rounded to the lower value | 
| 2 | Up | Up | Rounded to the upper value | 



<br />

## ByteSizeSuffixType
Defines the suffix format for displaying byte sizes.

>```csharp
>public enum ByteSizeSuffixType
>```


| Value | Name | Description | Summary | 
| --- | --- | --- | --- | 
| 0 | None | None | No suffix is appended to the numeric value. | 
| 1 | Short | Short | Short suffix format (e.g., "B", "KB", "MB", "GB"). | 
| 2 | Full | Full | Full suffix format (e.g., "byte", "Kilobyte", "Megabyte", "Gigabyte"). | 
| 3 | ShortBinary | Short Binary | Short IEC binary suffix format (e.g., "B", "KiB", "MiB", "GiB"). Uses IEC 80000-13 notation to distinguish 1024-based units from SI decimal units. | 



<br />

## ByteSizeUnitType
Enumeration: Defines units for byte sizes.

>```csharp
>public enum ByteSizeUnitType
>```


| Value | Name | Description | Summary | 
| --- | --- | --- | --- | 
| 0 | Byte | Byte | Byte. | 
| 1 | Kilobyte | Kilobyte | Kilobyte. | 
| 2 | Megabyte | Megabyte | Megabyte. | 
| 3 | Gigabyte | Gigabyte | Gigabyte. | 
| 4 | Terabyte | Terabyte | Terabyte. | 
| 5 | Petabyte | Petabyte | Petabyte. | 
| 6 | Exabyte | Exabyte | Exabyte. | 


<hr /><div style='text-align: right'><i>Generated by MarkdownCodeDoc version 1.2</i></div>
