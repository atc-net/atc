<div style='text-align: right'>

[References](Index.md)&nbsp;&nbsp;-&nbsp;&nbsp;[References extended](IndexExtended.md)
</div>

# System

<br />

## AppDomainExtensions
Extensions for the `System.AppDomain` class.

>```csharp
>public static class AppDomainExtensions
>```

### Static Methods

#### GetAllExportedTypes
>```csharp
>Type[] GetAllExportedTypes(this AppDomain appDomain)
>```
><b>Summary:</b> Gets all exported types.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`appDomain`&nbsp;&nbsp;-&nbsp;&nbsp;The application domain.<br />
#### GetCustomAssemblies
>```csharp
>Assembly[] GetCustomAssemblies(this AppDomain appDomain)
>```
><b>Summary:</b> Gets the custom assemblies - excluding System, Microsoft etc.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`appDomain`&nbsp;&nbsp;-&nbsp;&nbsp;The application domain.<br />
#### GetExportedPropertyTypeByName
>```csharp
>Type GetExportedPropertyTypeByName(this AppDomain appDomain, string typeName, string propertyName)
>```
><b>Summary:</b> Gets the name of the exported property type by.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`appDomain`&nbsp;&nbsp;-&nbsp;&nbsp;The application domain.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`typeName`&nbsp;&nbsp;-&nbsp;&nbsp;Name of the type.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`propertyName`&nbsp;&nbsp;-&nbsp;&nbsp;Name of the property.<br />
#### GetExportedTypeByName
>```csharp
>Type GetExportedTypeByName(this AppDomain appDomain, string typeName)
>```
><b>Summary:</b> Gets the name of the exported type by.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`appDomain`&nbsp;&nbsp;-&nbsp;&nbsp;The application domain.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`typeName`&nbsp;&nbsp;-&nbsp;&nbsp;Name of the type.<br />
#### TryLoadAssemblyIfNeeded
>```csharp
>bool TryLoadAssemblyIfNeeded(this AppDomain appDomain, string dllFileName)
>```
><b>Summary:</b> Load the specified assembly file, with a reference to memory and not the specified file.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`appDomain`&nbsp;&nbsp;-&nbsp;&nbsp;The application domain.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`dllFileName`&nbsp;&nbsp;-&nbsp;&nbsp;The name for the assembly file.<br />
>
><b>Returns:</b> The Assembly that is loaded.
>
><b>Remarks:</b> The assembly is never directly loaded, to avoid holding a instance as "assembly = Assembly.Load(file)" do.

<br />

## ArgumentNullOrDefaultException
ArgumentNullOrDefaultException.

>```csharp
>public class ArgumentNullOrDefaultException : ArgumentException, ISerializable
>```


<br />

## ArgumentNullOrDefaultPropertyException
ArgumentNullOrDefaultPropertyException.

>```csharp
>public class ArgumentNullOrDefaultPropertyException : ArgumentException, ISerializable
>```


<br />

## ArgumentNullPropertyException
ArgumentNullPropertyException.

>```csharp
>public class ArgumentNullPropertyException : ArgumentException, ISerializable
>```


<br />

## ArgumentPropertyException
ArgumentPropertyException.

>```csharp
>public class ArgumentPropertyException : ArgumentException, ISerializable
>```


<br />

## ArgumentPropertyNullException
ArgumentPropertyNullException.

>```csharp
>public class ArgumentPropertyNullException : ArgumentException, ISerializable
>```


<br />

## ArrayExtensions
Extensions for the `System.Array` class.

>```csharp
>public static class ArrayExtensions
>```

### Static Methods

#### RemoveDuplicates
>```csharp
>Array RemoveDuplicates(this Array array)
>```
><b>Summary:</b> Removes the duplicates.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`array`&nbsp;&nbsp;-&nbsp;&nbsp;The array.<br />
#### ToArray
>```csharp
>Array ToArray(this Array array, SortDirectionType sortDirectionType = None, bool removeDuplicates = False)
>```
><b>Summary:</b> To the array.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`array`&nbsp;&nbsp;-&nbsp;&nbsp;The array.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`sortDirectionType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the sort direction.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`removeDuplicates`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [remove duplicates].<br />
#### ToList
>```csharp
>List<string> ToList(this Array array, SortDirectionType sortDirectionType = None, bool removeDuplicates = False)
>```
><b>Summary:</b> To the list.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`array`&nbsp;&nbsp;-&nbsp;&nbsp;The array.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`sortDirectionType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the sort direction.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`removeDuplicates`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [remove duplicates].<br />

<br />

## BooleanExtensions
Extensions for the `System.Boolean` class.

>```csharp
>public static class BooleanExtensions
>```

### Static Methods

#### IsEqual
>```csharp
>bool IsEqual(this bool? a, bool? b)
>```
><b>Summary:</b> Determines whether the specified a is equal.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`a`&nbsp;&nbsp;-&nbsp;&nbsp;a.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`b`&nbsp;&nbsp;-&nbsp;&nbsp;The b.<br />
>
><b>Returns:</b> `true` if the specified a is equal; otherwise, `false`.
#### ToInt
>```csharp
>int ToInt(this bool source)
>```
><b>Summary:</b> Converts the string representation of a number to an integer.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`source`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [source].<br />
#### ToInt
>```csharp
>int ToInt(this bool? source)
>```
><b>Summary:</b> Converts the string representation of a number to an integer.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`source`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [source].<br />

<br />

## ByteExtensions
Extensions for the byte class.

>```csharp
>public static class ByteExtensions
>```

### Static Methods

#### Split
>```csharp
>IEnumerable<byte[]> Split(this IEnumerable<byte> source, byte splitByte)
>```
><b>Summary:</b> Splits a byte array by a specific byte into multiple byte arrays.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`source`&nbsp;&nbsp;-&nbsp;&nbsp;The source byte array to split.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`splitByte`&nbsp;&nbsp;-&nbsp;&nbsp;The byte to split on.<br />
#### TakeBytes
>```csharp
>byte[] TakeBytes(this byte[] value, int startPosition = 0, int length = 0)
>```
><b>Summary:</b> Take some bytes from a given start position and for the given length.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`startPosition`&nbsp;&nbsp;-&nbsp;&nbsp;The start position.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`length`&nbsp;&nbsp;-&nbsp;&nbsp;The length.<br />
#### TakeBytesAndConvertToInt
>```csharp
>int TakeBytesAndConvertToInt(this byte[] value, int startPosition = 0, int length = 0)
>```
><b>Summary:</b> Take some bytes from a given start position and for the given length and convert to Int. and convert to a `System.Int32` value.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`startPosition`&nbsp;&nbsp;-&nbsp;&nbsp;The start position.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`length`&nbsp;&nbsp;-&nbsp;&nbsp;The length.<br />
#### TakeBytesAndConvertToLong
>```csharp
>long TakeBytesAndConvertToLong(this byte[] value, int startPosition = 0, int length = 0)
>```
><b>Summary:</b> Take some bytes from a given start position and for the given length and convert to Long. and convert to a `System.Int64` value.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`startPosition`&nbsp;&nbsp;-&nbsp;&nbsp;The start position.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`length`&nbsp;&nbsp;-&nbsp;&nbsp;The length.<br />
#### TakeRemainingBytes
>```csharp
>byte[] TakeRemainingBytes(this byte[] value, int startPosition = 0)
>```
><b>Summary:</b> Take the remaining bytes from a given start position.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`startPosition`&nbsp;&nbsp;-&nbsp;&nbsp;The start position.<br />

<br />

## ByteSizeExtensions

>```csharp
>public static class ByteSizeExtensions
>```

### Static Methods

#### Bytes
>```csharp
>ByteSize Bytes(this decimal value)
>```
><b>Summary:</b> Returns an instance of `Atc.Units.DigitalInformation.ByteSize` that represents the specified size.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The size in bytes.<br />
>
><b>Returns:</b> An instance of `Atc.Units.DigitalInformation.ByteSize` that represents the specified size.
#### Bytes
>```csharp
>ByteSize Bytes(this double value)
>```
><b>Summary:</b> Returns an instance of `Atc.Units.DigitalInformation.ByteSize` that represents the specified size.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The size in bytes.<br />
>
><b>Returns:</b> An instance of `Atc.Units.DigitalInformation.ByteSize` that represents the specified size.
#### Bytes
>```csharp
>ByteSize Bytes(this float value)
>```
><b>Summary:</b> Returns an instance of `Atc.Units.DigitalInformation.ByteSize` that represents the specified size.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The size in bytes.<br />
>
><b>Returns:</b> An instance of `Atc.Units.DigitalInformation.ByteSize` that represents the specified size.
#### Bytes
>```csharp
>ByteSize Bytes(this int value)
>```
><b>Summary:</b> Returns an instance of `Atc.Units.DigitalInformation.ByteSize` that represents the specified size.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The size in bytes.<br />
>
><b>Returns:</b> An instance of `Atc.Units.DigitalInformation.ByteSize` that represents the specified size.
#### Bytes
>```csharp
>ByteSize Bytes(this uint value)
>```
><b>Summary:</b> Returns an instance of `Atc.Units.DigitalInformation.ByteSize` that represents the specified size.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The size in bytes.<br />
>
><b>Returns:</b> An instance of `Atc.Units.DigitalInformation.ByteSize` that represents the specified size.
#### Bytes
>```csharp
>ByteSize Bytes(this long value)
>```
><b>Summary:</b> Returns an instance of `Atc.Units.DigitalInformation.ByteSize` that represents the specified size.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The size in bytes.<br />
>
><b>Returns:</b> An instance of `Atc.Units.DigitalInformation.ByteSize` that represents the specified size.
#### Bytes
>```csharp
>ByteSize Bytes(this ulong value)
>```
><b>Summary:</b> Returns an instance of `Atc.Units.DigitalInformation.ByteSize` that represents the specified size.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The size in bytes.<br />
>
><b>Returns:</b> An instance of `Atc.Units.DigitalInformation.ByteSize` that represents the specified size.

<br />

## CertificateValidationException
The exception that is thrown when an certificate is not valid.

>```csharp
>public class CertificateValidationException : Exception, ISerializable
>```


<br />

## CharExtensions

>```csharp
>public static class CharExtensions
>```

### Static Methods

#### IsAscii
>```csharp
>bool IsAscii(this char value)
>```

<br />

## DateTimeExtensions
Extensions for the `System.DateTime` class.

>```csharp
>public static class DateTimeExtensions
>```

### Static Methods

#### DateTimeDiff
>```csharp
>double DateTimeDiff(this DateTime startDate, DateTime endDate, DateTimeDiffCompareType howToCompare)
>```
><b>Summary:</b> Find the diff between to DateTimes.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`startDate`&nbsp;&nbsp;-&nbsp;&nbsp;The start date.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`endDate`&nbsp;&nbsp;-&nbsp;&nbsp;The end date.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`howToCompare`&nbsp;&nbsp;-&nbsp;&nbsp;The how to compare.<br />
>
><b>Returns:</b> The number between start date and end date, depend on the DiffCompareType.
#### GetPrettyTimeDiff
>```csharp
>string GetPrettyTimeDiff(this DateTime startDate, int decimalPrecision = 3)
>```
><b>Summary:</b> Gets the pretty time difference.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`startDate`&nbsp;&nbsp;-&nbsp;&nbsp;The start date.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`decimalPrecision`&nbsp;&nbsp;-&nbsp;&nbsp;The decimal precision.<br />
#### GetPrettyTimeDiff
>```csharp
>string GetPrettyTimeDiff(this DateTime startDate, DateTime endDate, int decimalPrecision = 3)
>```
><b>Summary:</b> Gets the pretty time difference.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`startDate`&nbsp;&nbsp;-&nbsp;&nbsp;The start date.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`decimalPrecision`&nbsp;&nbsp;-&nbsp;&nbsp;The decimal precision.<br />
#### GetWeekNumber
>```csharp
>int GetWeekNumber(this DateTime date)
>```
><b>Summary:</b> Gets the week number from a given date.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`date`&nbsp;&nbsp;-&nbsp;&nbsp;The date.<br />
>
><b>Returns:</b> The week number from the given date.
#### IsBetween
>```csharp
>bool IsBetween(this DateTime date, DateTime startDate, DateTime endDate)
>```
><b>Summary:</b> Returns true if the date is between or equal to one of the two values.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`date`&nbsp;&nbsp;-&nbsp;&nbsp;DateTime Base, from where the calculation will be preformed.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`startDate`&nbsp;&nbsp;-&nbsp;&nbsp;Start date to check for.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`endDate`&nbsp;&nbsp;-&nbsp;&nbsp;End date to check for.<br />
>
><b>Returns:</b> boolean value indicating if the date is between or equal to one of the two values.
#### ToIso8601Date
>```csharp
>string ToIso8601Date(this DateTime dateTime)
>```
><b>Summary:</b> To the iso8601 date.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`dateTime`&nbsp;&nbsp;-&nbsp;&nbsp;The date time.<br />
>
><b>Code example:</b>
>```csharp
>string isoDate = DateTime.UtcNow.ToIso8601Date();
>```
#### ToIso8601UtcDate
>```csharp
>string ToIso8601UtcDate(this DateTime dateTime)
>```
><b>Summary:</b> To the iso8601 UTC date.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`dateTime`&nbsp;&nbsp;-&nbsp;&nbsp;The date time.<br />

<br />

## DateTimeOffsetExtensions
Extensions for the `System.DateTimeOffset` class.

>```csharp
>public static class DateTimeOffsetExtensions
>```

### Static Methods

#### IsBetween
>```csharp
>bool IsBetween(this DateTimeOffset dateTimeOffset, DateTimeOffset startDate, DateTimeOffset endDate)
>```
><b>Summary:</b> Returns true if the date time offset is between or equal to one of the two values.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`dateTimeOffset`&nbsp;&nbsp;-&nbsp;&nbsp;DateTime Base, from where the calculation will be preformed.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`startDate`&nbsp;&nbsp;-&nbsp;&nbsp;Start date to check for.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`endDate`&nbsp;&nbsp;-&nbsp;&nbsp;End date to check for.<br />
>
><b>Returns:</b> boolean value indicating if the date is between or equal to one of the two values.
#### ResetToStartOfCurrentHour
>```csharp
>DateTimeOffset ResetToStartOfCurrentHour(this DateTimeOffset dateTimeOffset)
>```
><b>Summary:</b> Resets to start of current hour.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`dateTimeOffset`&nbsp;&nbsp;-&nbsp;&nbsp;The date time offset.<br />
>
><b>Returns:</b> The dateTimeOffset with the seconds and milliseconds as 0.
#### SetHourAndMinutes
>```csharp
>DateTimeOffset SetHourAndMinutes(this DateTimeOffset dateTimeOffset, int hour, int minutes)
>```
><b>Summary:</b> Sets the hour and minutes.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`dateTimeOffset`&nbsp;&nbsp;-&nbsp;&nbsp;The date time offset.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`hour`&nbsp;&nbsp;-&nbsp;&nbsp;The hour.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`minutes`&nbsp;&nbsp;-&nbsp;&nbsp;The minutes.<br />
>
><b>Returns:</b> The dateTimeOffset with the specified hour and minutes.
#### ToIso8601Date
>```csharp
>string ToIso8601Date(this DateTimeOffset dateTimeOffset)
>```
><b>Summary:</b> Converts to ISO 8601 date.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`dateTimeOffset`&nbsp;&nbsp;-&nbsp;&nbsp;The date time offset.<br />
#### ToUnixTime
>```csharp
>long ToUnixTime(this DateTimeOffset dateTimeOffset)
>```
><b>Summary:</b> Converts the DateTimeOffset to a unix time - seconds starting from 1-1-1970.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`dateTimeOffset`&nbsp;&nbsp;-&nbsp;&nbsp;The date time offset.<br />
>
><b>Returns:</b> The long value from a DateTimeOffset.
>
><b>Code usage:</b>
>```csharp
>long unixTime = DateTimeOffset.ToUnixTime(value);
>```
>
><b>Code example:</b>
>```csharp
>DateTimeOffset dateTimeOffset = new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero);
>long unixTime = dateTimeOffset.ToUnixTime();
>```

<br />

## DecimalExtensions
Extensions for the `System.Decimal` class.

>```csharp
>public static class DecimalExtensions
>```

### Static Methods

#### CurrencyRounding
>```csharp
>decimal CurrencyRounding(this decimal value)
>```
><b>Summary:</b> Currencies the rounding.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
#### CurrencyRounding
>```csharp
>decimal CurrencyRounding(this decimal value, int digits)
>```
><b>Summary:</b> Currencies the rounding.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
#### CurrencyRoundingAsInteger
>```csharp
>int CurrencyRoundingAsInteger(this decimal value)
>```
><b>Summary:</b> Currencies the rounding as integer.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
#### IsEqual
>```csharp
>bool IsEqual(this decimal a, decimal b)
>```
><b>Summary:</b> Compare two values. Return `true` if they are equals.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`a`&nbsp;&nbsp;-&nbsp;&nbsp;The first value.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`b`&nbsp;&nbsp;-&nbsp;&nbsp;The second value.<br />
>
><b>Returns:</b> `true` if the two values are equals, `false` otherwise.
#### IsEqual
>```csharp
>bool IsEqual(this decimal? a, decimal? b)
>```
><b>Summary:</b> Compare two values. Return `true` if they are equals.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`a`&nbsp;&nbsp;-&nbsp;&nbsp;The first value.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`b`&nbsp;&nbsp;-&nbsp;&nbsp;The second value.<br />
>
><b>Returns:</b> `true` if the two values are equals, `false` otherwise.
#### IsEqual
>```csharp
>bool IsEqual(this decimal a, decimal b, int decimalPrecision)
>```
><b>Summary:</b> Compare two values. Return `true` if they are equals.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`a`&nbsp;&nbsp;-&nbsp;&nbsp;The first value.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`b`&nbsp;&nbsp;-&nbsp;&nbsp;The second value.<br />
>
><b>Returns:</b> `true` if the two values are equals, `false` otherwise.
#### IsEqual
>```csharp
>bool IsEqual(this decimal? a, decimal? b, int decimalPrecision)
>```
><b>Summary:</b> Compare two values. Return `true` if they are equals.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`a`&nbsp;&nbsp;-&nbsp;&nbsp;The first value.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`b`&nbsp;&nbsp;-&nbsp;&nbsp;The second value.<br />
>
><b>Returns:</b> `true` if the two values are equals, `false` otherwise.
#### RoundOff
>```csharp
>decimal RoundOff(this decimal value, int numberOfDecimals)
>```
><b>Summary:</b> Rounds the off.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`numberOfDecimals`&nbsp;&nbsp;-&nbsp;&nbsp;The number of decimals.<br />
#### RoundOff10
>```csharp
>decimal RoundOff10(this decimal value)
>```
><b>Summary:</b> Rounds the off10.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
#### RoundOff2
>```csharp
>decimal RoundOff2(this decimal value)
>```
><b>Summary:</b> Rounds the off2.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
#### RoundOffPercent
>```csharp
>decimal RoundOffPercent(this decimal percent)
>```
><b>Summary:</b> Rounds the off percent.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`percent`&nbsp;&nbsp;-&nbsp;&nbsp;The percent.<br />

<br />

## DesignTimeUseOnlyException
The exception that is thrown when an user is not found.

>```csharp
>public class DesignTimeUseOnlyException : Exception, ISerializable
>```


<br />

## DoubleExtensions
Extensions for the `System.Double` class.

>```csharp
>public static class DoubleExtensions
>```

### Static Fields

#### DoubleEpsilon
>```csharp
>double DoubleEpsilon
>```
><b>Summary:</b> The double epsilon.
### Static Methods

#### AreClose
>```csharp
>bool AreClose(this double value1, double value2)
>```
><b>Summary:</b> Ares the close.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value1`&nbsp;&nbsp;-&nbsp;&nbsp;The value1.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value2`&nbsp;&nbsp;-&nbsp;&nbsp;The value2.<br />
#### CountDecimalPoints
>```csharp
>int CountDecimalPoints(this double value)
>```
><b>Summary:</b> Returns the numbers of decimal points in the value.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
#### CurrencyRounding
>```csharp
>double CurrencyRounding(this double value)
>```
><b>Summary:</b> Currencies the rounding.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
#### CurrencyRounding
>```csharp
>double CurrencyRounding(this double value, int digits)
>```
><b>Summary:</b> Currencies the rounding.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
#### CurrencyRoundingAsInteger
>```csharp
>int CurrencyRoundingAsInteger(this double value)
>```
><b>Summary:</b> Currencies the rounding as integer.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
#### GreaterThanOrClose
>```csharp
>bool GreaterThanOrClose(this double value1, double value2)
>```
><b>Summary:</b> Greater the than or close.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value1`&nbsp;&nbsp;-&nbsp;&nbsp;The value1.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value2`&nbsp;&nbsp;-&nbsp;&nbsp;The value2.<br />
#### IsEqual
>```csharp
>bool IsEqual(this double a, double b)
>```
><b>Summary:</b> Compare two values. Return `true` if they are equals.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`a`&nbsp;&nbsp;-&nbsp;&nbsp;The first value.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`b`&nbsp;&nbsp;-&nbsp;&nbsp;The second value.<br />
>
><b>Returns:</b> `true` if the two values are equals, `false` otherwise.
#### IsEqual
>```csharp
>bool IsEqual(this double? a, double? b)
>```
><b>Summary:</b> Compare two values. Return `true` if they are equals.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`a`&nbsp;&nbsp;-&nbsp;&nbsp;The first value.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`b`&nbsp;&nbsp;-&nbsp;&nbsp;The second value.<br />
>
><b>Returns:</b> `true` if the two values are equals, `false` otherwise.
#### IsEqual
>```csharp
>bool IsEqual(this double a, double b, int decimalPrecision)
>```
><b>Summary:</b> Compare two values. Return `true` if they are equals.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`a`&nbsp;&nbsp;-&nbsp;&nbsp;The first value.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`b`&nbsp;&nbsp;-&nbsp;&nbsp;The second value.<br />
>
><b>Returns:</b> `true` if the two values are equals, `false` otherwise.
#### IsEqual
>```csharp
>bool IsEqual(this double? a, double? b, int decimalPrecision)
>```
><b>Summary:</b> Compare two values. Return `true` if they are equals.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`a`&nbsp;&nbsp;-&nbsp;&nbsp;The first value.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`b`&nbsp;&nbsp;-&nbsp;&nbsp;The second value.<br />
>
><b>Returns:</b> `true` if the two values are equals, `false` otherwise.
#### IsZero
>```csharp
>bool IsZero(this double value)
>```
><b>Summary:</b> Determines whether the specified value is zero.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
#### RoundOff
>```csharp
>double RoundOff(this double value, int numberOfDecimals)
>```
><b>Summary:</b> Rounds the off.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`numberOfDecimals`&nbsp;&nbsp;-&nbsp;&nbsp;The number of decimals.<br />
#### RoundOff10
>```csharp
>double RoundOff10(this double value)
>```
><b>Summary:</b> Rounds the off10.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
#### RoundOff2
>```csharp
>double RoundOff2(this double value)
>```
><b>Summary:</b> Rounds the off2.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
#### RoundOffPercent
>```csharp
>double RoundOffPercent(this double percent)
>```
><b>Summary:</b> Rounds the off percent.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`percent`&nbsp;&nbsp;-&nbsp;&nbsp;The percent.<br />

<br />

## EntityStoreException
The exception that is thrown when an entity is not stored.

>```csharp
>public class EntityStoreException : Exception, ISerializable
>```


<br />

## EnumExtensions
Extension methods for enumerations.

>```csharp
>public static class EnumExtensions
>```

### Static Methods

#### GetDescription
>```csharp
>string GetDescription(this Enum enumeration, bool useLocalizedIfPossible = True)
>```
><b>Summary:</b> Gets the description from the enumeration.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`enumeration`&nbsp;&nbsp;-&nbsp;&nbsp;The enumeration.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`useLocalizedIfPossible`&nbsp;&nbsp;-&nbsp;&nbsp;true to use attribute for localized/description/display if possible, default is the name; false to just use the name.<br />
>
><b>Returns:</b> The description from the enumeration.
>
><b>Code usage:</b>
>```csharp
>string day = value.GetDescription();
>```
>
><b>Code example:</b>
>```csharp
>Assert.Equal("Monday", DayOfWeek.Monday.GetDescription());
>```
#### GetName
>```csharp
>string GetName(this Enum enumeration)
>```
><b>Summary:</b> Gets the name from the enumeration.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`enumeration`&nbsp;&nbsp;-&nbsp;&nbsp;The enumeration.<br />
>
><b>Returns:</b> The name from the enumeration.
>
><b>Code usage:</b>
>```csharp
>string day = value.GetName();
>```
>
><b>Code example:</b>
>```csharp
>Assert.Equal("Monday", DayOfWeek.Monday.GetName());
>```
#### IsSet
>```csharp
>bool IsSet(this Enum enumeration, Enum matchTo)
>```
><b>Summary:</b> Determines whether the specified enumeration match to another enumeration.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`enumeration`&nbsp;&nbsp;-&nbsp;&nbsp;The enumeration.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`matchTo`&nbsp;&nbsp;-&nbsp;&nbsp;The enumeration to match.<br />
>
><b>Returns:</b> true on match; otherwise false.
>
><b>Code usage:</b>
>```csharp
>bool match = DayOfWeek.Monday.IsSet(DayOfWeek.Monday);
>```
>
><b>Code example:</b>
>```csharp
>Assert.True(DayOfWeek.Monday.IsSet(DayOfWeek.Monday));
>```
#### ToStringLowerCase
>```csharp
>string ToStringLowerCase(this Enum enumeration)
>```
><b>Summary:</b> Converts the named constant to <see langword="string" /> in lower case.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`enumeration`&nbsp;&nbsp;-&nbsp;&nbsp;The enum.<br />
#### ToStringUpperCase
>```csharp
>string ToStringUpperCase(this Enum enumeration)
>```
><b>Summary:</b> Converts the named constant to <see langword="string" /> in upper case.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`enumeration`&nbsp;&nbsp;-&nbsp;&nbsp;The enum.<br />

<br />

## ExceptionExtensions
Extension methods for the `System.Exception` class.

>```csharp
>public static class ExceptionExtensions
>```

### Static Methods

#### Flatten
>```csharp
>string Flatten(this Exception exception, string message = , bool includeStackTrace = False)
>```
><b>Summary:</b> Flattens the specified exception and inner exception data.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`exception`&nbsp;&nbsp;-&nbsp;&nbsp;The exception.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`message`&nbsp;&nbsp;-&nbsp;&nbsp;The message.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`includeStackTrace`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true include stack trace.<br />
>
><b>Returns:</b> The flatten message.
#### GetLastInnerMessage
>```csharp
>string GetLastInnerMessage(this Exception exception, bool includeExceptionName = False)
>```
><b>Summary:</b> Gets the last inner exception message.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`exception`&nbsp;&nbsp;-&nbsp;&nbsp;The exception.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`includeExceptionName`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [include exception name].<br />
#### GetMessage
>```csharp
>string GetMessage(this Exception exception, bool includeInnerMessage = False, bool includeExceptionName = False)
>```
><b>Summary:</b> Gets the exception message.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`exception`&nbsp;&nbsp;-&nbsp;&nbsp;The exception.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`includeInnerMessage`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [include inner message].<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`includeExceptionName`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [include exception name].<br />
#### ToXml
>```csharp
>XDocument ToXml(this Exception exception)
>```
><b>Summary:</b> To the XML.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`exception`&nbsp;&nbsp;-&nbsp;&nbsp;The exception.<br />

<br />

## IntegerExtensions
Extensions for the `System.Int32` class.

>```csharp
>public static class IntegerExtensions
>```

### Static Methods

#### GetFirstDayOfWeekNumberByYear
>```csharp
>DateTime GetFirstDayOfWeekNumberByYear(this int year, int weekNumber)
>```
><b>Summary:</b> Get the date of the first day in the given year and week number.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`year`&nbsp;&nbsp;-&nbsp;&nbsp;The year.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`weekNumber`&nbsp;&nbsp;-&nbsp;&nbsp;The week number.<br />
>
><b>Returns:</b> The date of the first day in the given year and week number.
#### GetLastDayOfWeekNumberByYear
>```csharp
>DateTime GetLastDayOfWeekNumberByYear(this int year, int weekNumber)
>```
><b>Summary:</b> Get the date of the last day in the given year and week number.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`year`&nbsp;&nbsp;-&nbsp;&nbsp;The year.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`weekNumber`&nbsp;&nbsp;-&nbsp;&nbsp;The week number.<br />
>
><b>Returns:</b> The date of the last day in the given year and week number.
#### GetMonthNameByMonthNumber
>```csharp
>string GetMonthNameByMonthNumber(this int month, bool pascalCased = False)
>```
><b>Summary:</b> Gets the month name by month number.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`month`&nbsp;&nbsp;-&nbsp;&nbsp;The month.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`pascalCased`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [pascal cased].<br />
>
><b>Returns:</b> The name of the month.
#### GetNumberOfWeeksByYear
>```csharp
>int GetNumberOfWeeksByYear(this int year)
>```
><b>Summary:</b> Gets the number of weeks by year.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`year`&nbsp;&nbsp;-&nbsp;&nbsp;The year.<br />
>
><b>Returns:</b> The get number of weeks.
#### IsBinarySequence
>```csharp
>bool IsBinarySequence(this int number)
>```
><b>Summary:</b> Determines whether [is binary sequence] [the specified number].
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`number`&nbsp;&nbsp;-&nbsp;&nbsp;The number.<br />
>
><b>Returns:</b> `true` if [is binary sequence] [the specified number]; otherwise, `false`.
>
><b>Code usage:</b>
>```csharp
>bool value = number.IsBinarySequence();
>```
>
><b>Code example:</b>
>```csharp
>int number = 8;
>bool value = number.IsBinarySequence();
>```
#### IsEqual
>```csharp
>bool IsEqual(this int? a, int? b)
>```
><b>Summary:</b> Determines whether the specified a is equal.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`a`&nbsp;&nbsp;-&nbsp;&nbsp;a.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`b`&nbsp;&nbsp;-&nbsp;&nbsp;The b.<br />
>
><b>Returns:</b> `true` if the specified a is equal; otherwise, `false`.
#### IsEven
>```csharp
>bool IsEven(this int number)
>```
><b>Summary:</b> Determines whether the specified number is even.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`number`&nbsp;&nbsp;-&nbsp;&nbsp;The number.<br />
>
><b>Returns:</b> `true` if the specified number is even; otherwise, `false`.
#### IsOdd
>```csharp
>bool IsOdd(this int number)
>```
><b>Summary:</b> Determines whether the specified number is odd.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`number`&nbsp;&nbsp;-&nbsp;&nbsp;The number.<br />
>
><b>Returns:</b> `true` if the specified number is odd; otherwise, `false`.
#### IsPrime
>```csharp
>bool IsPrime(this int number)
>```
><b>Summary:</b> Determines whether the specified number is prime.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`number`&nbsp;&nbsp;-&nbsp;&nbsp;The number.<br />
>
><b>Returns:</b> `true` if the specified number is prime; otherwise, `false`.

<br />

## ItemNotFoundException
The exception that is thrown when an item is not found.

>```csharp
>public class ItemNotFoundException : Exception, ISerializable
>```


<br />

## LongExtensions
Extensions for the `System.Int64` class.

>```csharp
>public static class LongExtensions
>```

### Static Methods

#### FromUnixTime
>```csharp
>DateTimeOffset FromUnixTime(this long value)
>```
><b>Summary:</b> Converts a unix time to a DateTimeOffset.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;A long containing the value to convert.<br />
>
><b>Returns:</b> The DateTimeOffset value from a long.
>
><b>Code usage:</b>
>```csharp
>DateTimeOffset dateTimeOffset = value.FromUnixTimeSeconds(value);
>```
>
><b>Code example:</b>
>```csharp
>long unixTime = 0; // Equivalent to 1-1-1970
>DateTimeOffset dateTimeOffset = unixTime.FromUnixTimeSeconds();
>```

<br />

## NullException
The exception that is thrown when an value is null.

>```csharp
>public class NullException : Exception, ISerializable
>```


<br />

## ObjectExtensions
Extensions for the `System.Object` class.

>```csharp
>public static class ObjectExtensions
>```

### Static Methods

#### GetPropertyValue
>```csharp
>object GetPropertyValue(this object source, string propertyName)
>```
#### GetTypeFullName
>```csharp
>string GetTypeFullName(this object source)
>```
#### GetTypeName
>```csharp
>string GetTypeName(this object source)
>```

<br />

## PermissionException
The exception that is thrown when permission is not fulfilled.

>```csharp
>public class PermissionException : Exception, ISerializable
>```


<br />

## StringExtensions
Extensions for the string class.

>```csharp
>public static class StringExtensions
>```

### Static Methods

#### Alphabetize
>```csharp
>string Alphabetize(this string value)
>```
><b>Summary:</b> Sorts letters in the string alphabetically.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The string to work on.<br />
>
><b>Returns:</b> The string sorted alphabetically.
#### Base64Decode
>```csharp
>string Base64Decode(this string base64EncodedData)
>```
><b>Summary:</b> Decodes the `base64EncodedData`<see langword="string" /> using UTF8.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`base64EncodedData`&nbsp;&nbsp;-&nbsp;&nbsp;The Base64 encoded data.<br />
#### Base64Decode
>```csharp
>string Base64Decode(this string base64EncodedData, Encoding encoding)
>```
><b>Summary:</b> Decodes the `base64EncodedData`<see langword="string" /> using UTF8.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`base64EncodedData`&nbsp;&nbsp;-&nbsp;&nbsp;The Base64 encoded data.<br />
#### Base64Encode
>```csharp
>string Base64Encode(this string value)
>```
><b>Summary:</b> Encodes the `value` to Base64 in UTF8.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The string value to encode<br />
#### Base64Encode
>```csharp
>string Base64Encode(this string value, Encoding encoding)
>```
><b>Summary:</b> Encodes the `value` to Base64 in UTF8.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The string value to encode<br />
#### CamelCase
>```csharp
>string CamelCase(this string value)
>```
><b>Summary:</b> Gets as camel case.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The string to work on.<br />
>
><b>Returns:</b> The string with camel-case format.
#### Contains
>```csharp
>bool Contains(this string value, string containsValue, bool ignoreCaseSensitive = True)
>```
><b>Summary:</b> Determines whether a string contains a specified value.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The string to work on.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`containsValue`&nbsp;&nbsp;-&nbsp;&nbsp;The string to compare with.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`ignoreCaseSensitive`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true ignore case sensitive.<br />
>
><b>Returns:</b> `true` if input string contains a value from specified value; otherwise, `false`.
#### Contains
>```csharp
>bool Contains(this string value, char[] containsValues, bool ignoreCaseSensitive = True)
>```
><b>Summary:</b> Determines whether a string contains a specified value.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The string to work on.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`containsValue`&nbsp;&nbsp;-&nbsp;&nbsp;The string to compare with.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`ignoreCaseSensitive`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true ignore case sensitive.<br />
>
><b>Returns:</b> `true` if input string contains a value from specified value; otherwise, `false`.
#### Contains
>```csharp
>bool Contains(this string value, string[] containsValues, bool ignoreCaseSensitive = True)
>```
><b>Summary:</b> Determines whether a string contains a specified value.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The string to work on.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`containsValue`&nbsp;&nbsp;-&nbsp;&nbsp;The string to compare with.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`ignoreCaseSensitive`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true ignore case sensitive.<br />
>
><b>Returns:</b> `true` if input string contains a value from specified value; otherwise, `false`.
#### Cut
>```csharp
>string Cut(this string value, int maxLength, string appendValue = ...)
>```
><b>Summary:</b> Cuts the specified value.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`maxLength`&nbsp;&nbsp;-&nbsp;&nbsp;Length of the max.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`appendValue`&nbsp;&nbsp;-&nbsp;&nbsp;The append value.<br />
>
><b>Returns:</b> The string that is cutoff by the max-length and appended with the appendValue.
#### EnsureEnvironmentNewLines
>```csharp
>string EnsureEnvironmentNewLines(this string value)
>```
><b>Summary:</b> Ensure the newline characters are the platform dependent System.Environment.Newline.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
>
><b>Remarks:</b> This method transform Windows, Unix, Mac newline characters to the platform dependent System.Environment.Newline. "\r\n" (\u000D\u000A) for Windows "\n" (\u000A) for Unix "\r" (\u000D) for Mac
#### EnsureFirstCharacterToLower
>```csharp
>string EnsureFirstCharacterToLower(this string value)
>```
><b>Summary:</b> Ensures the first character to lower.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
#### EnsureFirstCharacterToUpper
>```csharp
>string EnsureFirstCharacterToUpper(this string value)
>```
><b>Summary:</b> Ensures the first character to upper.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
#### EnsureFirstCharacterToUpperAndPlural
>```csharp
>string EnsureFirstCharacterToUpperAndPlural(this string value)
>```
><b>Summary:</b> Ensures the first character to upper and plural.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
#### EnsureFirstCharacterToUpperAndSingular
>```csharp
>string EnsureFirstCharacterToUpperAndSingular(this string value)
>```
><b>Summary:</b> Ensures the first character to upper and singular.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
#### EnsurePlural
>```csharp
>string EnsurePlural(this string value)
>```
><b>Summary:</b> Ensures the plural.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
#### EnsureSingular
>```csharp
>string EnsureSingular(this string value)
>```
><b>Summary:</b> Ensures the singular.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
#### GetStringFormatParameterLiteralCount
>```csharp
>int GetStringFormatParameterLiteralCount(this string value)
>```
><b>Summary:</b> Gets the string format parameter literal count.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
#### GetStringFormatParameterNumericCount
>```csharp
>int GetStringFormatParameterNumericCount(this string value)
>```
><b>Summary:</b> Gets the string format parameter numeric count.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
#### GetStringFormatParameterTemplatePlaceholders
>```csharp
>List<string> GetStringFormatParameterTemplatePlaceholders(this string value)
>```
><b>Summary:</b> Gets the string format parameter template placeholders.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
#### GetValueBetweenLessAndGreaterThanCharsIfExist
>```csharp
>string GetValueBetweenLessAndGreaterThanCharsIfExist(this string value)
>```
><b>Summary:</b> Gets the value between less and greater than chars if exist.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
#### Humanize
>```csharp
>string Humanize(this string value)
>```
><b>Summary:</b> Humanizes (make more human-readable) an identifier-style string in either camel case or snake case. For example, CamelCase will be converted to Camel Case and Snake_Case will be converted to Snake Case.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The identifier-style string.<br />
>
><b>Returns:</b> A `System.String` humanized.
#### IndexersOf
>```csharp
>int[] IndexersOf(this string value, string pattern, bool ignoreCaseSensitive = True, bool useEndOfPatternToMatch = False)
>```
><b>Summary:</b> Indexers the of.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`pattern`&nbsp;&nbsp;-&nbsp;&nbsp;The pattern.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`ignoreCaseSensitive`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [ignore case sensitive].<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`useEndOfPatternToMatch`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [use end of pattern to match].<br />
#### JavaScriptDecode
>```csharp
>string JavaScriptDecode(this string javaScript, bool htmlDecode)
>```
><b>Summary:</b> Javas the script decode.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`javaScript`&nbsp;&nbsp;-&nbsp;&nbsp;The java script.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`htmlDecode`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [HTML decode].<br />
#### JavaScriptEncode
>```csharp
>string JavaScriptEncode(this string javaScript, bool htmlEncode)
>```
><b>Summary:</b> Javas the script encode.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`javaScript`&nbsp;&nbsp;-&nbsp;&nbsp;The java script.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`htmlEncode`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [HTML encode].<br />
#### NormalizeAccents
>```csharp
>string NormalizeAccents(this string value)
>```
><b>Summary:</b> Normalizes the accents.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
>
><b>Returns:</b> The string that is normalize for accent-letter.
#### NormalizeAccents
>```csharp
>string NormalizeAccents(this string value, LetterAccentType letterAccentType, bool decode, bool forLower, bool forUpper)
>```
><b>Summary:</b> Normalizes the accents.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
>
><b>Returns:</b> The string that is normalize for accent-letter.
#### NormalizePascalCase
>```csharp
>string NormalizePascalCase(this string value)
>```
><b>Summary:</b> Converts a string from camel case to a string where space is inserted before each capital letter.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
>
><b>Returns:</b> The string with space inserted before each capital letter.
#### ParseDateFromIso8601
>```csharp
>DateTime ParseDateFromIso8601(this string value)
>```
><b>Summary:</b> Parses the date from iso8601.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
#### PascalCase
>```csharp
>string PascalCase(this string value, bool removeSeparators = False)
>```
><b>Summary:</b> Gets as pascal case.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The string to work on.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`removeSeparators`&nbsp;&nbsp;-&nbsp;&nbsp;If true, remove all separators.<br />
>
><b>Returns:</b> The string with pascal-case format.
#### PascalCase
>```csharp
>string PascalCase(this string value, char[] separators, bool removeSeparators = False)
>```
><b>Summary:</b> Gets as pascal case.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The string to work on.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`removeSeparators`&nbsp;&nbsp;-&nbsp;&nbsp;If true, remove all separators.<br />
>
><b>Returns:</b> The string with pascal-case format.
#### RemoveDataCrap
>```csharp
>string RemoveDataCrap(this string value)
>```
><b>Summary:</b> Removes the data crap.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The string to work on.<br />
>
><b>Returns:</b> The string without non-printable character.
#### RemoveEnd
>```csharp
>string RemoveEnd(this string value, string endValue, bool ignoreCaseSensitive = True)
>```
><b>Summary:</b> Remove a specified string from the string if occure in the end of the string.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The string to work on.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`endValue`&nbsp;&nbsp;-&nbsp;&nbsp;The string to compare with.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`ignoreCaseSensitive`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true ignore case sensitive.<br />
>
><b>Returns:</b> The string that remains after a specified string are removed from the end of the current string.
#### RemoveEndingSlashIfExist
>```csharp
>string RemoveEndingSlashIfExist(this string value)
>```
><b>Summary:</b> Removes the ending slash if exist.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
#### RemoveNewLines
>```csharp
>string RemoveNewLines(this string value)
>```
><b>Summary:</b> Remove the newline characters with the string.Empty.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
>
><b>Remarks:</b> This method don't use the platform dependent System.Environment.Newline but instead works for all platforms as Windows, Unix and Mac. "\r\n" (\u000D\u000A) for Windows "\n" (\u000A) for Unix "\r" (\u000D) for Mac
#### RemoveNonPrintableCharacter
>```csharp
>string RemoveNonPrintableCharacter(this string value)
>```
><b>Summary:</b> Removes the non-printable character.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The string to work on.<br />
>
><b>Returns:</b> The string without non-printable character.
#### RemoveStart
>```csharp
>string RemoveStart(this string value, string startValue, bool ignoreCaseSensitive = True)
>```
><b>Summary:</b> Remove a specified string from the string if occurs in the start of the string.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The string to work on.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`startValue`&nbsp;&nbsp;-&nbsp;&nbsp;The string to compare with.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`ignoreCaseSensitive`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true ignore case sensitive.<br />
>
><b>Returns:</b> The string that remains after a specified string are removed from the start of the current string.
#### ReplaceAt
>```csharp
>string ReplaceAt(this string value, int index, char newChar)
>```
><b>Summary:</b> Replaces at.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`index`&nbsp;&nbsp;-&nbsp;&nbsp;The index.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`newChar`&nbsp;&nbsp;-&nbsp;&nbsp;The new character.<br />
#### ReplaceMany
>```csharp
>string ReplaceMany(this string value, IDictionary<string, string> replacements)
>```
><b>Summary:</b> Returns a new string in which all occurrences of specified strings are replaced by other specified strings.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The string to filter.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`replacements`&nbsp;&nbsp;-&nbsp;&nbsp;The replacements definition.<br />
>
><b>Returns:</b> The filtered string.
#### ReplaceMany
>```csharp
>string ReplaceMany(this string value, char[] chars, char replacement)
>```
><b>Summary:</b> Returns a new string in which all occurrences of specified strings are replaced by other specified strings.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The string to filter.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`replacements`&nbsp;&nbsp;-&nbsp;&nbsp;The replacements definition.<br />
>
><b>Returns:</b> The filtered string.
#### ReplaceNewLines
>```csharp
>string ReplaceNewLines(this string value, string newValue)
>```
><b>Summary:</b> Replace the newline characters with the newValue.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`newValue`&nbsp;&nbsp;-&nbsp;&nbsp;The new value for NewLine.<br />
>
><b>Remarks:</b> This method don't use the platform dependent System.Environment.Newline but instead works for all platforms as Windows, Unix and Mac. "\r\n" (\u000D\u000A) for Windows "\n" (\u000A) for Unix "\r" (\u000D) for Mac
#### SetStringFormatParameterTemplatePlaceholders
>```csharp
>string SetStringFormatParameterTemplatePlaceholders(this string value, Dictionary<string, string> replacements)
>```
><b>Summary:</b> Sets the string format parameter template placeholders.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`replacements`&nbsp;&nbsp;-&nbsp;&nbsp;The replacements.<br />
#### ToLines
>```csharp
>string[] ToLines(this string value)
>```
><b>Summary:</b> Splits the specified text into r, n or rn separated lines.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
>
><b>Returns:</b> An array whose elements contain the substrings from this instance that are delimited by one or more characters in separator.
#### ToStream
>```csharp
>Stream ToStream(this string value)
>```
><b>Summary:</b> Converts to stream.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
#### ToStreamFromBase64
>```csharp
>Stream ToStreamFromBase64(this string base64Data)
>```
><b>Summary:</b> Converts to stream from base64.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`base64Data`&nbsp;&nbsp;-&nbsp;&nbsp;The base64 data.<br />
#### TrimExtended
>```csharp
>string TrimExtended(this string value)
>```
><b>Summary:</b> TrimExtended removes all leading and trailing white-space. and multi-space characters from the current System.String object.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
>
><b>Returns:</b> The string that remains after all white-space characters. are removed from the start and end and multi-space characters of the current string. If no characters can be trimmed from the current instance, the method returns the current instance unchanged.
#### TrimSpecial
>```csharp
>string TrimSpecial(this string value)
>```
><b>Summary:</b> TrimSpecial removes some doubles chars and none readable chars.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The string to work on.<br />
>
><b>Returns:</b> The string without none readable chars etc.
#### Truncate
>```csharp
>string Truncate(this string value, int maxLength, string appendValue = ...)
>```
><b>Summary:</b> Truncates the specified maximum length.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`maxLength`&nbsp;&nbsp;-&nbsp;&nbsp;The maximum length.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`appendValue`&nbsp;&nbsp;-&nbsp;&nbsp;The append value.<br />
#### TryParseDate
>```csharp
>bool TryParseDate(this string value, out DateTime dateTime)
>```
><b>Summary:</b> Tries the parse date.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`dateTime`&nbsp;&nbsp;-&nbsp;&nbsp;The date time.<br />
#### TryParseDate
>```csharp
>bool TryParseDate(this string value, out DateTime dateTime, CultureInfo cultureInfo, DateTimeStyles dateTimeStyles = None)
>```
><b>Summary:</b> Tries the parse date.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`dateTime`&nbsp;&nbsp;-&nbsp;&nbsp;The date time.<br />
#### TryParseDateFromIso8601
>```csharp
>bool TryParseDateFromIso8601(this string value, out DateTime dateTime)
>```
><b>Summary:</b> Tries the parse date from iso8601.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`dateTime`&nbsp;&nbsp;-&nbsp;&nbsp;The date time.<br />
#### WordCount
>```csharp
>int WordCount(this string value)
>```
><b>Summary:</b> Words count.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The string to work on.<br />
>
><b>Returns:</b> The count of words in the string.
#### XmlDecode
>```csharp
>string XmlDecode(this string xml)
>```
><b>Summary:</b> XMLs the decode.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`xml`&nbsp;&nbsp;-&nbsp;&nbsp;The XML.<br />
#### XmlEncode
>```csharp
>string XmlEncode(this string xml)
>```
><b>Summary:</b> XMLs the encode.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`xml`&nbsp;&nbsp;-&nbsp;&nbsp;The XML.<br />

<br />

## StringHasIsExtensions
StringHasIsExtensions.

>```csharp
>public static class StringHasIsExtensions
>```

### Static Methods

#### HasHtmlTags
>```csharp
>bool HasHtmlTags(this string value)
>```
><b>Summary:</b> Determines whether [has HTML tags] [the specified value].
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
>
><b>Returns:</b> `true` if [has HTML tags] [the specified value]; otherwise, `false`.
#### IsAlphaNumericOnly
>```csharp
>bool IsAlphaNumericOnly(this string value)
>```
><b>Summary:</b> Determines whether the specified value is alpha-numeric [a- z, A-Z, 0-9].
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The string to work on.<br />
>
><b>Returns:</b> `true` if the specified value is alpha-numeric [a- z, A-Z, 0-9]; otherwise, `false`.
#### IsAlphaOnly
>```csharp
>bool IsAlphaOnly(this string value)
>```
><b>Summary:</b> Determines whether the specified value is alpha [a-zA-Z].
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The string to work on.<br />
>
><b>Returns:</b> `true` if the specified value is alpha [a-zA-Z]; otherwise, `false`.
#### IsCasingStyleValid
>```csharp
>bool IsCasingStyleValid(this string value, CasingStyle casingStyle)
>```
><b>Summary:</b> Determines whether [is casing style valid] [the specified casing style].
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`casingStyle`&nbsp;&nbsp;-&nbsp;&nbsp;The casing style.<br />
>
><b>Returns:</b> `true` if [is casing style valid] [the specified casing style]; otherwise, `false`.
#### IsCompanyCvrNumber
>```csharp
>bool IsCompanyCvrNumber(this string cvrNumber)
>```
><b>Summary:</b> Determines whether the specified company CVR number is a valid number.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`cvrNumber`&nbsp;&nbsp;-&nbsp;&nbsp;The CVR number.<br />
>
><b>Returns:</b> `true` if the specified company CVR number is a valid number; otherwise, `false`.
>
><b>Remarks:</b> This works only for Danish companies.
#### IsCompanyPNumber
>```csharp
>bool IsCompanyPNumber(this string pNumber)
>```
><b>Summary:</b> Determines whether the specified company P number is a valid number.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`pNumber`&nbsp;&nbsp;-&nbsp;&nbsp;The p number.<br />
>
><b>Returns:</b> `true` if the specified company P number is a valid number; otherwise, `false`.
#### IsDate
>```csharp
>bool IsDate(this string value)
>```
><b>Summary:</b> Determines whether the specified value is a date.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The string to work on.<br />
>
><b>Returns:</b> `true` if the specified value is a date; otherwise, `false`.
#### IsDate
>```csharp
>bool IsDate(this string value, CultureInfo cultureInfo)
>```
><b>Summary:</b> Determines whether the specified value is a date.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The string to work on.<br />
>
><b>Returns:</b> `true` if the specified value is a date; otherwise, `false`.
#### IsDigitOnly
>```csharp
>bool IsDigitOnly(this string value)
>```
><b>Summary:</b> Determines whether the specified value is digit [0-9].
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The string to work on.<br />
>
><b>Returns:</b> `true` if the specified value is digit [0-9]; otherwise, `false`.
#### IsEmailAddress
>```csharp
>bool IsEmailAddress(this string value)
>```
><b>Summary:</b> Determines whether the specified value is a valid email address.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The string to work on.<br />
>
><b>Returns:</b> `true` if the specified value is a valid email address; otherwise, `false`.
#### IsEqual
>```csharp
>bool IsEqual(this string a, string b, StringComparison comparison = Ordinal, bool treatNullAsEmpty = True, bool useNormalizeAccents = False)
>```
><b>Summary:</b> Determines whether the specified b is equal.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`a`&nbsp;&nbsp;-&nbsp;&nbsp;a.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`b`&nbsp;&nbsp;-&nbsp;&nbsp;The b.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`comparison`&nbsp;&nbsp;-&nbsp;&nbsp;The string comparison - default is 'Ordinal'.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`treatNullAsEmpty`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [treat null as empty].<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`useNormalizeAccents`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [use normalize accents].<br />
>
><b>Returns:</b> `true` if the specified b is equal; otherwise, `false`.
#### IsFalse
>```csharp
>bool IsFalse(this string value)
>```
><b>Summary:</b> Determines whether the specified value is false.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
#### IsFirstCharacterLowerCase
>```csharp
>bool IsFirstCharacterLowerCase(this string value)
>```
><b>Summary:</b> Determines whether [is first character lower case].
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
>
><b>Returns:</b> `true` if [is first character lower case] [the specified value]; otherwise, `false`.
#### IsFirstCharacterUpperCase
>```csharp
>bool IsFirstCharacterUpperCase(this string value)
>```
><b>Summary:</b> Determines whether [is first character upper case].
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
>
><b>Returns:</b> `true` if [is first character upper case] [the specified value]; otherwise, `false`.
#### IsFormatJson
>```csharp
>bool IsFormatJson(this string value)
>```
><b>Summary:</b> Determines whether [is format json].
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
>
><b>Returns:</b> `true` if [is format json] [the specified value]; otherwise, `false`.
#### IsFormatXml
>```csharp
>bool IsFormatXml(this string value)
>```
><b>Summary:</b> Determines whether [is format XML].
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
>
><b>Returns:</b> `true` if [is format XML] [the specified value]; otherwise, `false`.
#### IsGuid
>```csharp
>bool IsGuid(this string value)
>```
><b>Summary:</b> Determines whether the specified string is a System.Guid.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The string to work on.<br />
>
><b>Returns:</b> `true` if the specified string is a System.Guid; otherwise, `false`.
#### IsGuid
>```csharp
>bool IsGuid(this string value, out Guid output)
>```
><b>Summary:</b> Determines whether the specified string is a System.Guid.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The string to work on.<br />
>
><b>Returns:</b> `true` if the specified string is a System.Guid; otherwise, `false`.
#### IsKey
>```csharp
>bool IsKey(this string value)
>```
><b>Summary:</b> Determines whether the specified value is key.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
>
><b>Returns:</b> `true` if the specified value is key; otherwise, `false`.
#### IsLengthEven
>```csharp
>bool IsLengthEven(this string value)
>```
><b>Summary:</b> Determines whether the specified string length is even.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The string to work on.<br />
>
><b>Returns:</b> `true` if the specified string length is even; otherwise, `false`.
#### IsNumericOnly
>```csharp
>bool IsNumericOnly(this string value)
>```
><b>Summary:</b> Determines whether the specified value is numeric [0-9].
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The string to work on.<br />
>
><b>Returns:</b> `true` if the specified value is numeric [0-9]; otherwise, `false`.
#### IsPersonCprNumber
>```csharp
>bool IsPersonCprNumber(this string cprNumber)
>```
><b>Summary:</b> Determines whether the specified person CPR number is a valid number.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`cprNumber`&nbsp;&nbsp;-&nbsp;&nbsp;The CPR number.<br />
>
><b>Returns:</b> `true` if the specified person CPR number is a valid number; otherwise, `false`.
#### IsSentence
>```csharp
>bool IsSentence(this string value)
>```
><b>Summary:</b> Determines whether the specified value is sentence.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
>
><b>Returns:</b> `true` if the specified value is sentence; otherwise, `false`.
#### IsStringFormatParametersBalanced
>```csharp
>bool IsStringFormatParametersBalanced(this string value, bool isNumeric = True)
>```
><b>Summary:</b> Determines whether [is string format parameters balanced] [the specified value].
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`isNumeric`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [is numeric].<br />
>
><b>Returns:</b> `true` if [is string format parameters balanced] [the specified value]; otherwise, `false`.
#### IsTrue
>```csharp
>bool IsTrue(this string value)
>```
><b>Summary:</b> Determines whether the specified value is true.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
#### IsWord
>```csharp
>bool IsWord(this string value)
>```
><b>Summary:</b> Determines whether the specified value is word.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
>
><b>Returns:</b> `true` if the specified value is word; otherwise, `false`.

<br />

## StringNullOrEmptyException
The exception that is thrown when an value is null or empty.

>```csharp
>public class StringNullOrEmptyException : Exception, ISerializable
>```


<br />

## SwitchCaseDefaultException
The exception.

>```csharp
>public class SwitchCaseDefaultException : Exception, ISerializable
>```


<br />

## TaskExtensions
Extensions for the `System.Threading.Tasks.Task` class.

>```csharp
>public static class TaskExtensions
>```

### Static Methods

#### StartAndWaitAllThrottled
>```csharp
>void StartAndWaitAllThrottled(this IEnumerable<Task> tasksToRun, int maxTasksToRunInParallel, CancellationToken cancellationToken = null)
>```
><b>Summary:</b> Starts the given tasks and waits for them to complete. This will run, at most, the specified number of tasks in parallel. NOTE: If one of the given tasks has already been started, an exception will be thrown.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`tasksToRun`&nbsp;&nbsp;-&nbsp;&nbsp;The tasks to run.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`maxTasksToRunInParallel`&nbsp;&nbsp;-&nbsp;&nbsp;The maximum number of tasks to run in parallel.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`cancellationToken`&nbsp;&nbsp;-&nbsp;&nbsp;The cancellation token.<br />
#### StartAndWaitAllThrottled
>```csharp
>void StartAndWaitAllThrottled(this IEnumerable<Task> tasksToRun, int maxTasksToRunInParallel, int timeoutInMilliseconds, CancellationToken cancellationToken = null)
>```
><b>Summary:</b> Starts the given tasks and waits for them to complete. This will run, at most, the specified number of tasks in parallel. NOTE: If one of the given tasks has already been started, an exception will be thrown.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`tasksToRun`&nbsp;&nbsp;-&nbsp;&nbsp;The tasks to run.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`maxTasksToRunInParallel`&nbsp;&nbsp;-&nbsp;&nbsp;The maximum number of tasks to run in parallel.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`cancellationToken`&nbsp;&nbsp;-&nbsp;&nbsp;The cancellation token.<br />

<br />

## TcpException
The exception that is thrown when a TCP error occurred.

>```csharp
>public class TcpException : Exception, ISerializable
>```


<br />

## TimeSpanExtensions
Extensions for the `System.TimeSpan` class.

>```csharp
>public static class TimeSpanExtensions
>```

### Static Methods

#### GetPrettyTime
>```csharp
>string GetPrettyTime(this TimeSpan timeSpan, int decimalPrecision = 3)
>```
><b>Summary:</b> Gets the pretty time.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`timeSpan`&nbsp;&nbsp;-&nbsp;&nbsp;The timeSpan.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`decimalPrecision`&nbsp;&nbsp;-&nbsp;&nbsp;The decimal precision.<br />
#### Max
>```csharp
>TimeSpan Max(this TimeSpan t1, TimeSpan t2)
>```
><b>Summary:</b> Maximums the specified t1.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`t1`&nbsp;&nbsp;-&nbsp;&nbsp;The t1.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`t2`&nbsp;&nbsp;-&nbsp;&nbsp;The t2.<br />
#### Min
>```csharp
>TimeSpan Min(this TimeSpan t1, TimeSpan t2)
>```
><b>Summary:</b> Minimums the specified t1.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`t1`&nbsp;&nbsp;-&nbsp;&nbsp;The t1.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`t2`&nbsp;&nbsp;-&nbsp;&nbsp;The t2.<br />
#### RemoveMilliseconds
>```csharp
>TimeSpan RemoveMilliseconds(this TimeSpan timeSpan)
>```
><b>Summary:</b> Removes the millisecond part of the timeSpan.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`timeSpan`&nbsp;&nbsp;-&nbsp;&nbsp;The timeSpan.<br />
#### SecondsNotZero
>```csharp
>bool SecondsNotZero(this TimeSpan timeSpan)
>```
><b>Summary:</b> Determines whether the seconds part of the datetime is zero.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`timeSpan`&nbsp;&nbsp;-&nbsp;&nbsp;The timeSpan.<br />
>
><b>Returns:</b> `true` if [is seconds is zero] otherwise, `false`.

<br />

## TypeExtensions
Extensions for the `System.Type` class.

>```csharp
>public static class TypeExtensions
>```

### Static Methods

#### BeautifyName
>```csharp
>string BeautifyName(this Type type, bool useFullName = False, bool useHtmlFormat = False, bool useGenericParameterNamesAsT = False, bool useSuffixQuestionMarkForGeneric = False)
>```
><b>Summary:</b> Beautifies the name.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`type`&nbsp;&nbsp;-&nbsp;&nbsp;The type.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`useFullName`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [use full name].<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`useHtmlFormat`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [use HTML format].<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`useGenericParameterNamesAsT`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [use generic parameter names as t].<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`useSuffixQuestionMarkForGeneric`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [use suffix question mark for generic].<br />
#### BeautifyTypeName
>```csharp
>string BeautifyTypeName(this Type type, bool useFullName = False)
>```
><b>Summary:</b> Beautifies the name of the type.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`type`&nbsp;&nbsp;-&nbsp;&nbsp;The type.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`useFullName`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [use full name].<br />
#### BeautifyTypeOfName
>```csharp
>string BeautifyTypeOfName(this Type type, bool useFullName = False, bool useHtmlFormat = False)
>```
><b>Summary:</b> Beautifies the name of the type of.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`type`&nbsp;&nbsp;-&nbsp;&nbsp;The type.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`useFullName`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [use full name].<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`useHtmlFormat`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [use HTML format].<br />
#### GetAttribute
>```csharp
>T GetAttribute(this Type type)
>```
><b>Summary:</b> Gets the attribute.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`type`&nbsp;&nbsp;-&nbsp;&nbsp;The type.<br />
#### GetAttributes
>```csharp
>IEnumerable<T> GetAttributes(this Type type)
>```
><b>Summary:</b> Gets the attributes.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`type`&nbsp;&nbsp;-&nbsp;&nbsp;The type.<br />
#### GetBaseTypeGenericArgumentType
>```csharp
>Type GetBaseTypeGenericArgumentType(this Type type)
>```
><b>Summary:</b> Gets the type of the base type generic argument.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`type`&nbsp;&nbsp;-&nbsp;&nbsp;The type.<br />
#### GetBaseTypeGenericArgumentTypes
>```csharp
>Type[] GetBaseTypeGenericArgumentTypes(this Type type)
>```
><b>Summary:</b> Gets the base type generic argument types.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`type`&nbsp;&nbsp;-&nbsp;&nbsp;The type.<br />
#### GetNameWithoutGenericType
>```csharp
>string GetNameWithoutGenericType(this Type type, bool useFullName = False)
>```
><b>Summary:</b> Get the name of the type without generic part.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`type`&nbsp;&nbsp;-&nbsp;&nbsp;The type.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`useFullName`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [use full name].<br />
#### GetPrivateDeclaredOnlyMethod
>```csharp
>MethodInfo GetPrivateDeclaredOnlyMethod(this Type type, string name)
>```
><b>Summary:</b> Gets the private declared only method.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`type`&nbsp;&nbsp;-&nbsp;&nbsp;The type.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`name`&nbsp;&nbsp;-&nbsp;&nbsp;The name.<br />
#### GetPrivateDeclaredOnlyMethods
>```csharp
>MethodInfo[] GetPrivateDeclaredOnlyMethods(this Type type)
>```
><b>Summary:</b> Gets the private declared only methods.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`type`&nbsp;&nbsp;-&nbsp;&nbsp;The type.<br />
#### GetPrivateDeclaredOnlyProperties
>```csharp
>PropertyInfo[] GetPrivateDeclaredOnlyProperties(this Type type)
>```
><b>Summary:</b> Gets the private declared only properties.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`type`&nbsp;&nbsp;-&nbsp;&nbsp;The type.<br />
#### GetPrivateDeclaredOnlyProperty
>```csharp
>PropertyInfo GetPrivateDeclaredOnlyProperty(this Type type, string name)
>```
><b>Summary:</b> Gets the private declared only property.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`type`&nbsp;&nbsp;-&nbsp;&nbsp;The type.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`name`&nbsp;&nbsp;-&nbsp;&nbsp;The name.<br />
#### GetPublicDeclaredOnlyMethods
>```csharp
>MethodInfo[] GetPublicDeclaredOnlyMethods(this Type type)
>```
><b>Summary:</b> Gets the public declared only methods.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`type`&nbsp;&nbsp;-&nbsp;&nbsp;The type.<br />
>
><b>Remarks:</b> Uses: BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly.
#### GetPublicDeclaredOnlyProperties
>```csharp
>PropertyInfo[] GetPublicDeclaredOnlyProperties(this Type type)
>```
><b>Summary:</b> Gets the public declared only properties.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`type`&nbsp;&nbsp;-&nbsp;&nbsp;The type.<br />
>
><b>Remarks:</b> Uses: BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly.
#### GetPublicDeclaredOnlyPropertyValue
>```csharp
>object GetPublicDeclaredOnlyPropertyValue(this Type type, string name)
>```
><b>Summary:</b> Gets the public declared only property value.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`type`&nbsp;&nbsp;-&nbsp;&nbsp;The type.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`name`&nbsp;&nbsp;-&nbsp;&nbsp;The name.<br />
#### GetPublicProperties
>```csharp
>PropertyInfo[] GetPublicProperties(this Type type)
>```
><b>Summary:</b> Gets the public properties.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`type`&nbsp;&nbsp;-&nbsp;&nbsp;The type.<br />
>
><b>Remarks:</b> Uses: BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static.
#### HasValidationAttributes
>```csharp
>bool HasValidationAttributes(this Type type)
>```
><b>Summary:</b> Determines whether [has validation attributes].
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`type`&nbsp;&nbsp;-&nbsp;&nbsp;The type.<br />
>
><b>Returns:</b> `true` if [has validation attributes] [the specified type]; otherwise, `false`.
#### IsDelegate
>```csharp
>bool IsDelegate(this Type type)
>```
><b>Summary:</b> Determines whether this instance is delegate.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`type`&nbsp;&nbsp;-&nbsp;&nbsp;The type.<br />
>
><b>Returns:</b> `true` if the specified type is delegate; otherwise, `false`.
#### IsInheritedFrom
>```csharp
>bool IsInheritedFrom(this Type type, Type inheritType)
>```
><b>Summary:</b> Determines whether [is inherited from] [the specified inherit type].
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`type`&nbsp;&nbsp;-&nbsp;&nbsp;The type.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`inheritType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the inherit.<br />
>
><b>Returns:</b> `true` if [is inherited from] [the specified inherit type]; otherwise, `false`.
#### IsInheritedFromGenericWithArgumentType
>```csharp
>bool IsInheritedFromGenericWithArgumentType(this Type type, Type inheritType, Type argumentType, bool matchAlsoOnArgumentTypeInterface = True)
>```
><b>Summary:</b> Determines whether [is inherited from generic with argument type] [the specified inherit type].
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`type`&nbsp;&nbsp;-&nbsp;&nbsp;The type.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`inheritType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the inherit.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`argumentType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the argument.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`matchAlsoOnArgumentTypeInterface`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [match also on argument type interface].<br />
>
><b>Returns:</b> `true` if [is inherited from generic with argument type] [the specified inherit type]; otherwise, `false`.
#### IsNullable
>```csharp
>bool IsNullable(this Type type)
>```
><b>Summary:</b> Determines whether this instance is nullable.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`type`&nbsp;&nbsp;-&nbsp;&nbsp;The type.<br />
>
><b>Returns:</b> `true` if the specified type is nullable; otherwise, `false`.
#### IsSimple
>```csharp
>bool IsSimple(this Type type)
>```
><b>Summary:</b> Determines whether this instance is simple.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`type`&nbsp;&nbsp;-&nbsp;&nbsp;The type.<br />
>
><b>Returns:</b> `true` if the specified type is simple; otherwise, `false`.
#### IsSubClassOfRawGeneric
>```csharp
>bool IsSubClassOfRawGeneric(this Type baseType, Type derivedType)
>```
><b>Summary:</b> Determines whether [is sub class of raw generic] [the specified derived type].
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`baseType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the base.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`derivedType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the derived.<br />
>
><b>Returns:</b> `true` if [is sub class of raw generic] [the specified derived type]; otherwise, `false`.
#### TryGetAttribute
>```csharp
>T TryGetAttribute(this Type type)
>```
><b>Summary:</b> Tries the get attribute.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`type`&nbsp;&nbsp;-&nbsp;&nbsp;The type.<br />
#### TryGetEnumType
>```csharp
>bool TryGetEnumType(this Type type, out Type enumType)
>```
><b>Summary:</b> Try to extract the enum-type.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`type`&nbsp;&nbsp;-&nbsp;&nbsp;The type.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`enumType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the enum.<br />

<br />

## UnexpectedTypeException
The exception that is thrown when actual type differs from expected type.

>```csharp
>public class UnexpectedTypeException : Exception, ISerializable
>```


<br />

## UserNotFoundException
The exception that is thrown when an user is not found.

>```csharp
>public class UserNotFoundException : Exception, ISerializable
>```


<br />

## VersionExtensions

>```csharp
>public static class VersionExtensions
>```

### Static Methods

#### CompareTo
>```csharp
>int CompareTo(this Version version, Version otherVersion, int significantParts = 4, int startingPart = 1)
>```
><b>Summary:</b> Is 'version' greater than the 'otherVersion', where the significantParts is the stop part. Example significantParts=2, then only Major and Minor wil be taken into consideration.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`version`&nbsp;&nbsp;-&nbsp;&nbsp;The version.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`otherVersion`&nbsp;&nbsp;-&nbsp;&nbsp;The other version.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`significantParts`&nbsp;&nbsp;-&nbsp;&nbsp;The significant parts (default is 4 which means [major.minor.build.revision] ).<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`startingPart`&nbsp;&nbsp;-&nbsp;&nbsp;The starting parts (default is 1 which means all 4 significant parts).<br />
>
><b>Returns:</b> -1, 0 or 1.
>
><b>Code example:</b>
>```csharp
>- Set significantParts = 4 and startingPart 1 => [major.minor.build.revision]
>- Set significantParts = 4 and startingPart 2 => major.[minor.build.revision]
>- Set significantParts = 3 and startingPart 1 => [major.minor.build]
>- Set significantParts = 3 and startingPart 2 => major.[minor.build]
>```
#### GreaterThan
>```csharp
>bool GreaterThan(this Version version, Version otherVersion, int significantParts = 4, int startingPart = 1)
>```
><b>Summary:</b> Is 'version' greater than the 'otherVersion'.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`version`&nbsp;&nbsp;-&nbsp;&nbsp;The version.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`otherVersion`&nbsp;&nbsp;-&nbsp;&nbsp;The other version.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`significantParts`&nbsp;&nbsp;-&nbsp;&nbsp;The significant parts.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`startingPart`&nbsp;&nbsp;-&nbsp;&nbsp;The starting parts.<br />
>
><b>Returns:</b> `true` if 'otherVersion' is greater than the current 'version'; otherwise, `false`.
#### GreaterThanOrEqualTo
>```csharp
>bool GreaterThanOrEqualTo(this Version version, Version otherVersion, int significantParts = 4, int startingPart = 1)
>```
><b>Summary:</b> Is 'version' greater than or equal to the 'otherVersion'.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`version`&nbsp;&nbsp;-&nbsp;&nbsp;The version.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`otherVersion`&nbsp;&nbsp;-&nbsp;&nbsp;The other version.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`significantParts`&nbsp;&nbsp;-&nbsp;&nbsp;The significant parts.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`startingPart`&nbsp;&nbsp;-&nbsp;&nbsp;The starting parts.<br />
>
><b>Returns:</b> `true` if 'otherVersion' is greater than or equal to the current 'version'; otherwise, `false`.
#### IsNewerThan
>```csharp
>bool IsNewerThan(this Version version, Version otherVersion, bool withinMinorReleaseOnly = False)
>```
><b>Summary:</b> Determines whether 'version' is newer than the 'otherVersion'.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`version`&nbsp;&nbsp;-&nbsp;&nbsp;The version.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`otherVersion`&nbsp;&nbsp;-&nbsp;&nbsp;The other version.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`withinMinorReleaseOnly`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true Than major has to be the same or smaller.<br />
>
><b>Returns:</b> `true` if 'otherVersion' is newer than the 'version'; otherwise, `false`.
>
><b>Code example:</b>
>```csharp
>   For withinMinorReleaseOnly = true:
>     4.8.8.0 is newer than 4.5.3.3
>     4.5.8.0 is newer than 4.5.3.3
>     4.8.3.0 is newer than 4.5.3.3
>     4.5.4.0 is newer than 4.5.3.3
>     4.5.3.0 is NOT newer than 4.5.3.3
>     5.8.8.0 is NOT newer than 4.5.3.3
>
>   For withinMinorReleaseOnly = false:
>     4.8.8.0 is newer than 4.5.3.3
>     4.5.8.0 is newer than 4.5.3.3
>     4.8.3.0 is newer than 4.5.3.3
>     4.5.4.0 is newer than 4.5.3.3
>     4.5.3.0 is NOT newer than 4.5.3.3
>     5.8.8.0 is newer than 4.5.3.3
>```

<br />

## ViewModelException
The exception that is thrown when an ViewModel is not as expected.

>```csharp
>public class ViewModelException : Exception, ISerializable
>```

<hr /><div style='text-align: right'><i>Generated by MarkdownCodeDoc version 1.2</i></div>
