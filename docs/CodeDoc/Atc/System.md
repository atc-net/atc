<div style='text-align: right'>

[References](Index.md)&nbsp;&nbsp;-&nbsp;&nbsp;[References extended](IndexExtended.md)
</div>

# System

<br />


## AppDomainExtensions
Extensions for the `System.AppDomain` class.


```csharp
public static class AppDomainExtensions
```

### Static Methods


#### GetAllExportedTypes

```csharp
Type[] GetAllExportedTypes(this AppDomain appDomain)
```
<p><b>Summary:</b> Gets all exported types.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`appDomain`&nbsp;&nbsp;-&nbsp;&nbsp;The application domain.<br />
#### GetCustomAssemblies

```csharp
Assembly[] GetCustomAssemblies(this AppDomain appDomain)
```
<p><b>Summary:</b> Gets the custom assemblies - excluding System, Microsoft etc.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`appDomain`&nbsp;&nbsp;-&nbsp;&nbsp;The application domain.<br />
#### GetExportedPropertyTypeByName

```csharp
Type GetExportedPropertyTypeByName(this AppDomain appDomain, string typeName, string propertyName)
```
<p><b>Summary:</b> Gets the name of the exported property type by.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`appDomain`&nbsp;&nbsp;-&nbsp;&nbsp;The application domain.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`typeName`&nbsp;&nbsp;-&nbsp;&nbsp;Name of the type.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`propertyName`&nbsp;&nbsp;-&nbsp;&nbsp;Name of the property.<br />
#### GetExportedTypeByName

```csharp
Type GetExportedTypeByName(this AppDomain appDomain, string typeName)
```
<p><b>Summary:</b> Gets the name of the exported type by.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`appDomain`&nbsp;&nbsp;-&nbsp;&nbsp;The application domain.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`typeName`&nbsp;&nbsp;-&nbsp;&nbsp;Name of the type.<br />

<br />


## ArgumentNullOrDefaultException
ArgumentNullOrDefaultException.


```csharp
public class ArgumentNullOrDefaultException : ArgumentException, ISerializable
```


<br />


## ArgumentNullOrDefaultPropertyException
ArgumentNullOrDefaultPropertyException.


```csharp
public class ArgumentNullOrDefaultPropertyException : ArgumentException, ISerializable
```


<br />


## ArgumentNullPropertyException
ArgumentNullPropertyException.


```csharp
public class ArgumentNullPropertyException : ArgumentException, ISerializable
```


<br />


## ArgumentPropertyException
ArgumentPropertyException.


```csharp
public class ArgumentPropertyException : ArgumentException, ISerializable
```


<br />


## ArgumentPropertyNullException
ArgumentPropertyNullException.


```csharp
public class ArgumentPropertyNullException : ArgumentException, ISerializable
```


<br />


## ArrayExtensions
Extensions for the `System.Array` class.


```csharp
public static class ArrayExtensions
```

### Static Methods


#### RemoveDuplicates

```csharp
Array RemoveDuplicates(this Array array)
```
<p><b>Summary:</b> Removes the duplicates.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`array`&nbsp;&nbsp;-&nbsp;&nbsp;The array.<br />
#### ToArray

```csharp
Array ToArray(this Array array, SortDirectionType sortDirectionType = None, bool removeDuplicates = False)
```
<p><b>Summary:</b> To the array.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`array`&nbsp;&nbsp;-&nbsp;&nbsp;The array.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`sortDirectionType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the sort direction.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`removeDuplicates`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [remove duplicates].<br />
#### ToList

```csharp
List<string> ToList(this Array array, SortDirectionType sortDirectionType = None, bool removeDuplicates = False)
```
<p><b>Summary:</b> To the list.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`array`&nbsp;&nbsp;-&nbsp;&nbsp;The array.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`sortDirectionType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the sort direction.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`removeDuplicates`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [remove duplicates].<br />

<br />


## BooleanExtensions
Extensions for the `System.Boolean` class.


```csharp
public static class BooleanExtensions
```

### Static Methods


#### IsEqual

```csharp
bool IsEqual(this bool? a, bool? b)
```
<p><b>Summary:</b> Determines whether the specified a is equal.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`a`&nbsp;&nbsp;-&nbsp;&nbsp;a.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`b`&nbsp;&nbsp;-&nbsp;&nbsp;The b.<br />
<p><b>Returns:</b> true if the specified a is equal; otherwise, false.</p>

#### ToInt

```csharp
int ToInt(this bool source)
```
<p><b>Summary:</b> Converts the string representation of a number to an integer.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`source`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [source].<br />
#### ToInt

```csharp
int ToInt(this bool? source)
```
<p><b>Summary:</b> Converts the string representation of a number to an integer.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`source`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [source].<br />

<br />


## ByteSizeExtensions

```csharp
public static class ByteSizeExtensions
```

### Static Methods


#### Bytes

```csharp
ByteSize Bytes(this decimal value)
```
<p><b>Summary:</b> Returns an instance of `Atc.Math.UnitOfDigitalInformation.ByteSize` that represents the specified size.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The size in bytes.<br />
<p><b>Returns:</b> An instance of  that represents the specified size.</p>

#### Bytes

```csharp
ByteSize Bytes(this double value)
```
<p><b>Summary:</b> Returns an instance of `Atc.Math.UnitOfDigitalInformation.ByteSize` that represents the specified size.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The size in bytes.<br />
<p><b>Returns:</b> An instance of  that represents the specified size.</p>

#### Bytes

```csharp
ByteSize Bytes(this float value)
```
<p><b>Summary:</b> Returns an instance of `Atc.Math.UnitOfDigitalInformation.ByteSize` that represents the specified size.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The size in bytes.<br />
<p><b>Returns:</b> An instance of  that represents the specified size.</p>

#### Bytes

```csharp
ByteSize Bytes(this int value)
```
<p><b>Summary:</b> Returns an instance of `Atc.Math.UnitOfDigitalInformation.ByteSize` that represents the specified size.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The size in bytes.<br />
<p><b>Returns:</b> An instance of  that represents the specified size.</p>

#### Bytes

```csharp
ByteSize Bytes(this uint value)
```
<p><b>Summary:</b> Returns an instance of `Atc.Math.UnitOfDigitalInformation.ByteSize` that represents the specified size.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The size in bytes.<br />
<p><b>Returns:</b> An instance of  that represents the specified size.</p>

#### Bytes

```csharp
ByteSize Bytes(this long value)
```
<p><b>Summary:</b> Returns an instance of `Atc.Math.UnitOfDigitalInformation.ByteSize` that represents the specified size.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The size in bytes.<br />
<p><b>Returns:</b> An instance of  that represents the specified size.</p>

#### Bytes

```csharp
ByteSize Bytes(this ulong value)
```
<p><b>Summary:</b> Returns an instance of `Atc.Math.UnitOfDigitalInformation.ByteSize` that represents the specified size.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The size in bytes.<br />
<p><b>Returns:</b> An instance of  that represents the specified size.</p>


<br />


## DateTimeExtensions
Extensions for the `System.DateTime` class.


```csharp
public static class DateTimeExtensions
```

### Static Methods


#### DateTimeDiff

```csharp
double DateTimeDiff(this DateTime startDate, DateTime endDate, DateTimeDiffCompareType howToCompare)
```
<p><b>Summary:</b> Find the diff between to DateTimes.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`startDate`&nbsp;&nbsp;-&nbsp;&nbsp;The start date.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`endDate`&nbsp;&nbsp;-&nbsp;&nbsp;The end date.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`howToCompare`&nbsp;&nbsp;-&nbsp;&nbsp;The how to compare.<br />
<p><b>Returns:</b> The number between start date and end date, depend on the DiffCompareType.</p>

#### GetPrettyTimeDiff

```csharp
string GetPrettyTimeDiff(this DateTime startDate, int decimalPrecision = 3)
```
<p><b>Summary:</b> Gets the pretty time difference.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`startDate`&nbsp;&nbsp;-&nbsp;&nbsp;The start date.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`decimalPrecision`&nbsp;&nbsp;-&nbsp;&nbsp;The decimal precision.<br />
#### GetPrettyTimeDiff

```csharp
string GetPrettyTimeDiff(this DateTime startDate, DateTime endDate, int decimalPrecision = 3)
```
<p><b>Summary:</b> Gets the pretty time difference.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`startDate`&nbsp;&nbsp;-&nbsp;&nbsp;The start date.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`decimalPrecision`&nbsp;&nbsp;-&nbsp;&nbsp;The decimal precision.<br />
#### GetWeekNumber

```csharp
int GetWeekNumber(this DateTime date)
```
<p><b>Summary:</b> Gets the week number from a given date.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`date`&nbsp;&nbsp;-&nbsp;&nbsp;The date.<br />
<p><b>Returns:</b> The week number from the given date.</p>

#### IsBetween

```csharp
bool IsBetween(this DateTime date, DateTime startDate, DateTime endDate)
```
<p><b>Summary:</b> Returns true if the date is between or equal to one of the two values.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`date`&nbsp;&nbsp;-&nbsp;&nbsp;DateTime Base, from where the calculation will be preformed.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`startDate`&nbsp;&nbsp;-&nbsp;&nbsp;Start date to check for.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`endDate`&nbsp;&nbsp;-&nbsp;&nbsp;End date to check for.<br />
<p><b>Returns:</b> boolean value indicating if the date is between or equal to one of the two values.</p>

#### ToIso8601Date

```csharp
string ToIso8601Date(this DateTime dateTime)
```
<p><b>Summary:</b> To the iso8601 date.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`dateTime`&nbsp;&nbsp;-&nbsp;&nbsp;The date time.<br />
<b>Code example:</b>

```csharp
string isoDate = DateTime.UtcNow.ToIso8601Date()
```
#### ToIso8601UtcDate

```csharp
string ToIso8601UtcDate(this DateTime dateTime)
```
<p><b>Summary:</b> To the iso8601 UTC date.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`dateTime`&nbsp;&nbsp;-&nbsp;&nbsp;The date time.<br />

<br />


## DateTimeOffsetExtensions
Extensions for the `System.DateTimeOffset` class.


```csharp
public static class DateTimeOffsetExtensions
```

### Static Methods


#### IsBetween

```csharp
bool IsBetween(this DateTimeOffset dateTimeOffset, DateTimeOffset startDate, DateTimeOffset endDate)
```
<p><b>Summary:</b> Returns true if the date time offset is between or equal to one of the two values.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`dateTimeOffset`&nbsp;&nbsp;-&nbsp;&nbsp;DateTime Base, from where the calculation will be preformed.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`startDate`&nbsp;&nbsp;-&nbsp;&nbsp;Start date to check for.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`endDate`&nbsp;&nbsp;-&nbsp;&nbsp;End date to check for.<br />
<p><b>Returns:</b> boolean value indicating if the date is between or equal to one of the two values.</p>

#### ResetToStartOfCurrentHour

```csharp
DateTimeOffset ResetToStartOfCurrentHour(this DateTimeOffset dateTimeOffset)
```
<p><b>Summary:</b> Resets to start of current hour.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`dateTimeOffset`&nbsp;&nbsp;-&nbsp;&nbsp;The date time offset.<br />
<p><b>Returns:</b> The dateTimeOffset with the seconds and milliseconds as 0.</p>

#### SetHourAndMinutes

```csharp
DateTimeOffset SetHourAndMinutes(this DateTimeOffset dateTimeOffset, int hour, int minutes)
```
<p><b>Summary:</b> Sets the hour and minutes.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`dateTimeOffset`&nbsp;&nbsp;-&nbsp;&nbsp;The date time offset.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`hour`&nbsp;&nbsp;-&nbsp;&nbsp;The hour.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`minutes`&nbsp;&nbsp;-&nbsp;&nbsp;The minutes.<br />
<p><b>Returns:</b> The dateTimeOffset with the specified hour and minutes.</p>

#### ToIso8601Date

```csharp
string ToIso8601Date(this DateTimeOffset dateTimeOffset)
```
<p><b>Summary:</b> Converts to ISO 8601 date.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`dateTimeOffset`&nbsp;&nbsp;-&nbsp;&nbsp;The date time offset.<br />
#### ToUnixTime

```csharp
long ToUnixTime(this DateTimeOffset dateTimeOffset)
```
<p><b>Summary:</b> Converts the DateTimeOffset to a unix time - seconds stating from 1-1-1970.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`dateTimeOffset`&nbsp;&nbsp;-&nbsp;&nbsp;The date time offset.<br />
<p><b>Returns:</b> The long value from a DateTimeOffset.</p>

<b>Code usage:</b>

```csharp
long unixTime = DateTimeOffset.ToUnixTime(value);
```
<b>Code example:</b>

```csharp
DateTimeOffset dateTimeOffset = new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero);
long unixTime = dateTimeOffset.ToUnixTime();
```

<br />


## DecimalExtensions
Extensions for the `System.Decimal` class.


```csharp
public static class DecimalExtensions
```

### Static Methods


#### CurrencyRounding

```csharp
decimal CurrencyRounding(this decimal value)
```
<p><b>Summary:</b> Currencies the rounding.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
#### CurrencyRounding

```csharp
decimal CurrencyRounding(this decimal value, int digits)
```
<p><b>Summary:</b> Currencies the rounding.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
#### CurrencyRoundingAsInteger

```csharp
int CurrencyRoundingAsInteger(this decimal value)
```
<p><b>Summary:</b> Currencies the rounding as integer.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
#### IsEqual

```csharp
bool IsEqual(this decimal a, decimal b)
```
<p><b>Summary:</b> Compare two values. Return <c>true</c> if they are equals.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`a`&nbsp;&nbsp;-&nbsp;&nbsp;The first value.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`b`&nbsp;&nbsp;-&nbsp;&nbsp;The second value.<br />
<p><b>Returns:</b> true if the two values are equals, false otherwise.</p>

#### IsEqual

```csharp
bool IsEqual(this decimal? a, decimal? b)
```
<p><b>Summary:</b> Compare two values. Return <c>true</c> if they are equals.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`a`&nbsp;&nbsp;-&nbsp;&nbsp;The first value.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`b`&nbsp;&nbsp;-&nbsp;&nbsp;The second value.<br />
<p><b>Returns:</b> true if the two values are equals, false otherwise.</p>

#### IsEqual

```csharp
bool IsEqual(this decimal a, decimal b, int decimalPrecision)
```
<p><b>Summary:</b> Compare two values. Return <c>true</c> if they are equals.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`a`&nbsp;&nbsp;-&nbsp;&nbsp;The first value.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`b`&nbsp;&nbsp;-&nbsp;&nbsp;The second value.<br />
<p><b>Returns:</b> true if the two values are equals, false otherwise.</p>

#### IsEqual

```csharp
bool IsEqual(this decimal? a, decimal? b, int decimalPrecision)
```
<p><b>Summary:</b> Compare two values. Return <c>true</c> if they are equals.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`a`&nbsp;&nbsp;-&nbsp;&nbsp;The first value.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`b`&nbsp;&nbsp;-&nbsp;&nbsp;The second value.<br />
<p><b>Returns:</b> true if the two values are equals, false otherwise.</p>

#### RoundOff

```csharp
decimal RoundOff(this decimal value, int numberOfDecimals)
```
<p><b>Summary:</b> Rounds the off.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`numberOfDecimals`&nbsp;&nbsp;-&nbsp;&nbsp;The number of decimals.<br />
#### RoundOff10

```csharp
decimal RoundOff10(this decimal value)
```
<p><b>Summary:</b> Rounds the off10.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
#### RoundOff2

```csharp
decimal RoundOff2(this decimal value)
```
<p><b>Summary:</b> Rounds the off2.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
#### RoundOffPercent

```csharp
decimal RoundOffPercent(this decimal percent)
```
<p><b>Summary:</b> Rounds the off percent.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`percent`&nbsp;&nbsp;-&nbsp;&nbsp;The percent.<br />

<br />


## DoubleExtensions
Extensions for the `System.Double` class.


```csharp
public static class DoubleExtensions
```

### Static Fields


#### DoubleEpsilon

```csharp
double DoubleEpsilon
```
<p><b>Summary:</b> The double epsilon.</p>

### Static Methods


#### AreClose

```csharp
bool AreClose(this double value1, double value2)
```
<p><b>Summary:</b> Ares the close.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value1`&nbsp;&nbsp;-&nbsp;&nbsp;The value1.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value2`&nbsp;&nbsp;-&nbsp;&nbsp;The value2.<br />
#### CountDecimalPoints

```csharp
int CountDecimalPoints(this double value)
```
<p><b>Summary:</b> Returns the numbers of decimal points in the value.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
#### CurrencyRounding

```csharp
double CurrencyRounding(this double value)
```
<p><b>Summary:</b> Currencies the rounding.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
#### CurrencyRounding

```csharp
double CurrencyRounding(this double value, int digits)
```
<p><b>Summary:</b> Currencies the rounding.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
#### CurrencyRoundingAsInteger

```csharp
int CurrencyRoundingAsInteger(this double value)
```
<p><b>Summary:</b> Currencies the rounding as integer.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
#### GreaterThanOrClose

```csharp
bool GreaterThanOrClose(this double value1, double value2)
```
<p><b>Summary:</b> Greater the than or close.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value1`&nbsp;&nbsp;-&nbsp;&nbsp;The value1.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value2`&nbsp;&nbsp;-&nbsp;&nbsp;The value2.<br />
#### IsEqual

```csharp
bool IsEqual(this double a, double b)
```
<p><b>Summary:</b> Compare two values. Return <c>true</c> if they are equals.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`a`&nbsp;&nbsp;-&nbsp;&nbsp;The first value.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`b`&nbsp;&nbsp;-&nbsp;&nbsp;The second value.<br />
<p><b>Returns:</b> true if the two values are equals, false otherwise.</p>

#### IsEqual

```csharp
bool IsEqual(this double? a, double? b)
```
<p><b>Summary:</b> Compare two values. Return <c>true</c> if they are equals.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`a`&nbsp;&nbsp;-&nbsp;&nbsp;The first value.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`b`&nbsp;&nbsp;-&nbsp;&nbsp;The second value.<br />
<p><b>Returns:</b> true if the two values are equals, false otherwise.</p>

#### IsEqual

```csharp
bool IsEqual(this double a, double b, int decimalPrecision)
```
<p><b>Summary:</b> Compare two values. Return <c>true</c> if they are equals.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`a`&nbsp;&nbsp;-&nbsp;&nbsp;The first value.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`b`&nbsp;&nbsp;-&nbsp;&nbsp;The second value.<br />
<p><b>Returns:</b> true if the two values are equals, false otherwise.</p>

#### IsEqual

```csharp
bool IsEqual(this double? a, double? b, int decimalPrecision)
```
<p><b>Summary:</b> Compare two values. Return <c>true</c> if they are equals.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`a`&nbsp;&nbsp;-&nbsp;&nbsp;The first value.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`b`&nbsp;&nbsp;-&nbsp;&nbsp;The second value.<br />
<p><b>Returns:</b> true if the two values are equals, false otherwise.</p>

#### IsZero

```csharp
bool IsZero(this double value)
```
<p><b>Summary:</b> Determines whether the specified value is zero.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
#### RoundOff

```csharp
double RoundOff(this double value, int numberOfDecimals)
```
<p><b>Summary:</b> Rounds the off.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`numberOfDecimals`&nbsp;&nbsp;-&nbsp;&nbsp;The number of decimals.<br />
#### RoundOff10

```csharp
double RoundOff10(this double value)
```
<p><b>Summary:</b> Rounds the off10.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
#### RoundOff2

```csharp
double RoundOff2(this double value)
```
<p><b>Summary:</b> Rounds the off2.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
#### RoundOffPercent

```csharp
double RoundOffPercent(this double percent)
```
<p><b>Summary:</b> Rounds the off percent.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`percent`&nbsp;&nbsp;-&nbsp;&nbsp;The percent.<br />

<br />


## EnumExtensions
Extension methods for enumerations.


```csharp
public static class EnumExtensions
```

### Static Methods


#### GetDescription

```csharp
string GetDescription(this Enum enumeration, bool useLocalizedIfPossible = True)
```
<p><b>Summary:</b> Gets the description from the enumeration.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`enumeration`&nbsp;&nbsp;-&nbsp;&nbsp;The enumeration.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`useLocalizedIfPossible`&nbsp;&nbsp;-&nbsp;&nbsp;true to use attribute for localized/description/display if possible, default is the name; false to just use the name.<br />
<p><b>Returns:</b> The description from the enumeration.</p>

<b>Code usage:</b>

```csharp
string day = value.GetDescription();
```
<b>Code example:</b>

```csharp
Assert.Equal("Monday", DayOfWeek.Monday.GetDescription());
```
#### GetName

```csharp
string GetName(this Enum enumeration)
```
<p><b>Summary:</b> Gets the name from the enumeration.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`enumeration`&nbsp;&nbsp;-&nbsp;&nbsp;The enumeration.<br />
<p><b>Returns:</b> The name from the enumeration.</p>

<b>Code usage:</b>

```csharp
string day = value.GetName();
```
<b>Code example:</b>

```csharp
Assert.Equal("Monday", DayOfWeek.Monday.GetName());
```
#### IsSet

```csharp
bool IsSet(this Enum enumeration, Enum matchTo)
```
<p><b>Summary:</b> Determines whether the specified enumeration match to another enumeration.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`enumeration`&nbsp;&nbsp;-&nbsp;&nbsp;The enumeration.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`matchTo`&nbsp;&nbsp;-&nbsp;&nbsp;The enumeration to match.<br />
<p><b>Returns:</b> true on match; otherwise false.</p>

<b>Code usage:</b>

```csharp
bool match = DayOfWeek.Monday.IsSet(DayOfWeek.Monday);
```
<b>Code example:</b>

```csharp
Assert.True(DayOfWeek.Monday.IsSet(DayOfWeek.Monday));
```

<br />


## ExceptionExtensions
Extension methods for the `System.Exception` class.


```csharp
public static class ExceptionExtensions
```

### Static Methods


#### Flatten

```csharp
string Flatten(this Exception exception, string message = , bool includeStackTrace = False)
```
<p><b>Summary:</b> Flattens the specified exception and inner exception data.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`exception`&nbsp;&nbsp;-&nbsp;&nbsp;The exception.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`message`&nbsp;&nbsp;-&nbsp;&nbsp;The message.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`includeStackTrace`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true include stack trace.<br />
<p><b>Returns:</b> The flatten message.</p>

#### GetLastInnerMessage

```csharp
string GetLastInnerMessage(this Exception exception, bool includeExceptionName = False)
```
<p><b>Summary:</b> Gets the last inner exception message.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`exception`&nbsp;&nbsp;-&nbsp;&nbsp;The exception.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`includeExceptionName`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [include exception name].<br />
#### GetMessage

```csharp
string GetMessage(this Exception exception, bool includeInnerMessage = False, bool includeExceptionName = False)
```
<p><b>Summary:</b> Gets the exception message.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`exception`&nbsp;&nbsp;-&nbsp;&nbsp;The exception.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`includeInnerMessage`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [include inner message].<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`includeExceptionName`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [include exception name].<br />
#### ToXml

```csharp
XDocument ToXml(this Exception exception)
```
<p><b>Summary:</b> To the XML.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`exception`&nbsp;&nbsp;-&nbsp;&nbsp;The exception.<br />

<br />


## IntegerExtensions
Extensions for the `System.Int32` class.


```csharp
public static class IntegerExtensions
```

### Static Methods


#### GetFirstDayOfWeekNumberByYear

```csharp
DateTime GetFirstDayOfWeekNumberByYear(this int year, int weekNumber)
```
<p><b>Summary:</b> Get the date of the first day in the given year and week number.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`year`&nbsp;&nbsp;-&nbsp;&nbsp;The year.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`weekNumber`&nbsp;&nbsp;-&nbsp;&nbsp;The week number.<br />
<p><b>Returns:</b> The date of the first day in the given year and week number.</p>

#### GetLastDayOfWeekNumberByYear

```csharp
DateTime GetLastDayOfWeekNumberByYear(this int year, int weekNumber)
```
<p><b>Summary:</b> Get the date of the last day in the given year and week number.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`year`&nbsp;&nbsp;-&nbsp;&nbsp;The year.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`weekNumber`&nbsp;&nbsp;-&nbsp;&nbsp;The week number.<br />
<p><b>Returns:</b> The date of the last day in the given year and week number.</p>

#### GetMonthNameByMonthNumber

```csharp
string GetMonthNameByMonthNumber(this int month, bool pascalCased = False)
```
<p><b>Summary:</b> Gets the month name by month number.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`month`&nbsp;&nbsp;-&nbsp;&nbsp;The month.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`pascalCased`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [pascal cased].<br />
<p><b>Returns:</b> The name of the month.</p>

#### GetNumberOfWeeksByYear

```csharp
int GetNumberOfWeeksByYear(this int year)
```
<p><b>Summary:</b> Gets the number of weeks by year.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`year`&nbsp;&nbsp;-&nbsp;&nbsp;The year.<br />
<p><b>Returns:</b> The get number of weeks.</p>

#### IsBinarySequence

```csharp
bool IsBinarySequence(this int number)
```
<p><b>Summary:</b> Determines whether [is binary sequence] [the specified number].</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`number`&nbsp;&nbsp;-&nbsp;&nbsp;The number.<br />
<p><b>Returns:</b> true if [is binary sequence] [the specified number]; otherwise, false.</p>

<b>Code usage:</b>

```csharp
bool value = number.IsBinarySequence();
```
<b>Code example:</b>

```csharp
int number = 8;
bool value = number.IsBinarySequence();
```
#### IsEqual

```csharp
bool IsEqual(this int? a, int? b)
```
<p><b>Summary:</b> Determines whether the specified a is equal.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`a`&nbsp;&nbsp;-&nbsp;&nbsp;a.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`b`&nbsp;&nbsp;-&nbsp;&nbsp;The b.<br />
<p><b>Returns:</b> true if the specified a is equal; otherwise, false.</p>

#### IsEven

```csharp
bool IsEven(this int number)
```
<p><b>Summary:</b> Determines whether the specified number is even.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`number`&nbsp;&nbsp;-&nbsp;&nbsp;The number.<br />
<p><b>Returns:</b> true if the specified number is even; otherwise, false.</p>

#### IsOdd

```csharp
bool IsOdd(this int number)
```
<p><b>Summary:</b> Determines whether the specified number is odd.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`number`&nbsp;&nbsp;-&nbsp;&nbsp;The number.<br />
<p><b>Returns:</b> true if the specified number is odd; otherwise, false.</p>

#### IsPrime

```csharp
bool IsPrime(this int number)
```
<p><b>Summary:</b> Determines whether the specified number is prime.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`number`&nbsp;&nbsp;-&nbsp;&nbsp;The number.<br />
<p><b>Returns:</b> true if the specified number is prime; otherwise, false.</p>


<br />


## ItemNotFoundException
The exception that is thrown when an item is not found.


```csharp
public class ItemNotFoundException : Exception, ISerializable
```


<br />


## LongExtensions
Extensions for the `System.Int64` class.


```csharp
public static class LongExtensions
```

### Static Methods


#### FromUnixTime

```csharp
DateTimeOffset FromUnixTime(this long value)
```
<p><b>Summary:</b> Converts a unix time to a DateTimeOffset.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;A long containing the value to convert.<br />
<p><b>Returns:</b> The DateTimeOffset value from a long.</p>

<b>Code usage:</b>

```csharp
DateTimeOffset dateTimeOffset = value.FromUnixTimeSeconds(value);
```
<b>Code example:</b>

```csharp
long unixTime = 0; // Equivalent to 1-1-1970
DateTimeOffset dateTimeOffset = unixTime.FromUnixTimeSeconds();
```

<br />


## StringExtensions
Extensions for the string class.


```csharp
public static class StringExtensions
```

### Static Methods


#### Alphabetize

```csharp
string Alphabetize(this string value)
```
<p><b>Summary:</b> Sorts letters in the string alphabetically.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The string to work on.<br />
<p><b>Returns:</b> The string sorted alphabetically.</p>

#### Base64Decode

```csharp
string Base64Decode(this string base64EData)
```
<p><b>Summary:</b> Base64s the decode.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`base64EData`&nbsp;&nbsp;-&nbsp;&nbsp;The base64 e data.<br />
#### Base64Encode

```csharp
string Base64Encode(this string value)
```
<p><b>Summary:</b> Base64s the encode.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
#### CamelCase

```csharp
string CamelCase(this string value)
```
<p><b>Summary:</b> Gets as camel case.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The string to work on.<br />
<p><b>Returns:</b> The string with camel-case format.</p>

#### Contains

```csharp
bool Contains(this string value, string containsValue, bool ignoreCaseSensitive = True)
```
<p><b>Summary:</b> Determines whether a string contains a specified value.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The string to work on.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`containsValue`&nbsp;&nbsp;-&nbsp;&nbsp;The string to compare with.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`ignoreCaseSensitive`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true ignore case sensitive.<br />
<p><b>Returns:</b> true if a string contains a specified value; otherwise, false.</p>

#### Cut

```csharp
string Cut(this string value, int maxLength, string appendValue = ...)
```
<p><b>Summary:</b> Cuts the specified value.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`maxLength`&nbsp;&nbsp;-&nbsp;&nbsp;Length of the max.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`appendValue`&nbsp;&nbsp;-&nbsp;&nbsp;The append value.<br />
<p><b>Returns:</b> The string that is cutoff by the max-length and appended with the appendValue.</p>

#### EnsureEnvironmentNewLines

```csharp
string EnsureEnvironmentNewLines(this string value)
```
<p><b>Summary:</b> Ensure the newline characters are the platform dependent System.Environment.Newline.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
<p><b>Remarks:</b> This method transform Windows, Unix, Mac newline characters to
            the platform dependent System.Environment.Newline.
            "\r\n" (\u000D\u000A) for Windows
            "\n" (\u000A) for Unix
            "\r" (\u000D) for Mac</p>

#### EnsureFirstCharacterToLower

```csharp
string EnsureFirstCharacterToLower(this string value)
```
<p><b>Summary:</b> Ensures the first character to lower.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
#### EnsureFirstCharacterToUpper

```csharp
string EnsureFirstCharacterToUpper(this string value)
```
<p><b>Summary:</b> Ensures the first character to upper.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
#### EnsureFirstCharacterToUpperAndPlural

```csharp
string EnsureFirstCharacterToUpperAndPlural(this string value)
```
<p><b>Summary:</b> Ensures the first character to upper and plural.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
#### EnsureFirstCharacterToUpperAndSingular

```csharp
string EnsureFirstCharacterToUpperAndSingular(this string value)
```
<p><b>Summary:</b> Ensures the first character to upper and singular.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
#### EnsurePlural

```csharp
string EnsurePlural(this string value)
```
<p><b>Summary:</b> Ensures the plural.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
#### EnsureSingular

```csharp
string EnsureSingular(this string value)
```
<p><b>Summary:</b> Ensures the singular.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
#### GetStringFormatParameterLiteralCount

```csharp
int GetStringFormatParameterLiteralCount(this string value)
```
<p><b>Summary:</b> Gets the string format parameter literal count.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
#### GetStringFormatParameterNumericCount

```csharp
int GetStringFormatParameterNumericCount(this string value)
```
<p><b>Summary:</b> Gets the string format parameter numeric count.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
#### GetStringFormatParameterTemplatePlaceholders

```csharp
List<string> GetStringFormatParameterTemplatePlaceholders(this string value)
```
<p><b>Summary:</b> Gets the string format parameter template placeholders.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
#### GetValueBetweenLessAndGreaterThanCharsIfExist

```csharp
string GetValueBetweenLessAndGreaterThanCharsIfExist(this string value)
```
<p><b>Summary:</b> Gets the value between less and greater than chars if exist.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
#### Humanize

```csharp
string Humanize(this string value)
```
<p><b>Summary:</b> Humanizes (make more human-readable) an identifier-style string in either camel case or snake case. For example, CamelCase will be converted to Camel Case and Snake_Case will be converted to Snake Case.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The identifier-style string.<br />
<p><b>Returns:</b> A  humanized.</p>

#### IndexersOf

```csharp
int[] IndexersOf(this string value, string pattern, bool ignoreCaseSensitive = True, bool useEndOfPatternToMatch = False)
```
<p><b>Summary:</b> Indexers the of.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`pattern`&nbsp;&nbsp;-&nbsp;&nbsp;The pattern.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`ignoreCaseSensitive`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [ignore case sensitive].<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`useEndOfPatternToMatch`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [use end of pattern to match].<br />
#### JavaScriptDecode

```csharp
string JavaScriptDecode(this string javaScript, bool htmlDecode)
```
<p><b>Summary:</b> Javas the script decode.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`javaScript`&nbsp;&nbsp;-&nbsp;&nbsp;The java script.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`htmlDecode`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [HTML decode].<br />
#### JavaScriptEncode

```csharp
string JavaScriptEncode(this string javaScript, bool htmlEncode)
```
<p><b>Summary:</b> Javas the script encode.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`javaScript`&nbsp;&nbsp;-&nbsp;&nbsp;The java script.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`htmlEncode`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [HTML encode].<br />
#### NormalizeAccents

```csharp
string NormalizeAccents(this string value)
```
<p><b>Summary:</b> Normalizes the accents.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
<p><b>Returns:</b> The string that is normalize for accent-letter.</p>

#### NormalizeAccents

```csharp
string NormalizeAccents(this string value, LetterAccentType letterAccentType, bool decode, bool forLower, bool forUpper)
```
<p><b>Summary:</b> Normalizes the accents.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
<p><b>Returns:</b> The string that is normalize for accent-letter.</p>

#### NormalizePascalCase

```csharp
string NormalizePascalCase(this string value)
```
<p><b>Summary:</b> Converts a string from camel case to a string where space is inserted before each capital letter.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
<p><b>Returns:</b> The string with space inserted before each capital letter.</p>

#### ParseDateFromIso8601

```csharp
DateTime ParseDateFromIso8601(this string value)
```
<p><b>Summary:</b> Parses the date from iso8601.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
#### PascalCase

```csharp
string PascalCase(this string value, bool removeSeparators = False)
```
<p><b>Summary:</b> Gets as pascal case.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The string to work on.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`removeSeparators`&nbsp;&nbsp;-&nbsp;&nbsp;If true, remove all separators.<br />
<p><b>Returns:</b> The string with pascal-case format.</p>

#### PascalCase

```csharp
string PascalCase(this string value, char[] separators, bool removeSeparators = False)
```
<p><b>Summary:</b> Gets as pascal case.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The string to work on.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`removeSeparators`&nbsp;&nbsp;-&nbsp;&nbsp;If true, remove all separators.<br />
<p><b>Returns:</b> The string with pascal-case format.</p>

#### RemoveDataCrap

```csharp
string RemoveDataCrap(this string value)
```
<p><b>Summary:</b> Removes the data crap.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The string to work on.<br />
<p><b>Returns:</b> The string without none readable chars.</p>

#### RemoveEnd

```csharp
string RemoveEnd(this string value, string endValue, bool ignoreCaseSensitive = True)
```
<p><b>Summary:</b> Remove a specified string from the string if occure in the end of the string.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The string to work on.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`endValue`&nbsp;&nbsp;-&nbsp;&nbsp;The string to compare with.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`ignoreCaseSensitive`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true ignore case sensitive.<br />
<p><b>Returns:</b> The string that remains after a specified string are removed from the end of the current string.</p>

#### RemoveEndingSlashIfExist

```csharp
string RemoveEndingSlashIfExist(this string value)
```
<p><b>Summary:</b> Removes the ending slash if exist.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
#### RemoveNewLines

```csharp
string RemoveNewLines(this string value)
```
<p><b>Summary:</b> Remove the newline characters with the string.Empty.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
<p><b>Remarks:</b> This method don't use the platform dependent System.Environment.Newline
            but instead works for all platforms as Windows, Unix and Mac.
            "\r\n" (\u000D\u000A) for Windows
            "\n" (\u000A) for Unix
            "\r" (\u000D) for Mac</p>

#### RemoveStart

```csharp
string RemoveStart(this string value, string startValue, bool ignoreCaseSensitive = True)
```
<p><b>Summary:</b> Remove a specified string from the string if occurs in the start of the string.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The string to work on.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`startValue`&nbsp;&nbsp;-&nbsp;&nbsp;The string to compare with.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`ignoreCaseSensitive`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true ignore case sensitive.<br />
<p><b>Returns:</b> The string that remains after a specified string are removed from the start of the current string.</p>

#### ReplaceAt

```csharp
string ReplaceAt(this string value, int index, char newChar)
```
<p><b>Summary:</b> Replaces at.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`index`&nbsp;&nbsp;-&nbsp;&nbsp;The index.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`newChar`&nbsp;&nbsp;-&nbsp;&nbsp;The new character.<br />
#### ReplaceMany

```csharp
string ReplaceMany(this string value, IDictionary<string, string> replacements)
```
<p><b>Summary:</b> Returns a new string in which all occurrences of specified strings are replaced by other specified strings.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The string to filter.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`replacements`&nbsp;&nbsp;-&nbsp;&nbsp;The replacements definition.<br />
<p><b>Returns:</b> The filtered string.</p>

#### ReplaceMany

```csharp
string ReplaceMany(this string value, char[] chars, char replacement)
```
<p><b>Summary:</b> Returns a new string in which all occurrences of specified strings are replaced by other specified strings.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The string to filter.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`replacements`&nbsp;&nbsp;-&nbsp;&nbsp;The replacements definition.<br />
<p><b>Returns:</b> The filtered string.</p>

#### ReplaceNewLines

```csharp
string ReplaceNewLines(this string value, string newValue)
```
<p><b>Summary:</b> Replace the newline characters with the newValue.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`newValue`&nbsp;&nbsp;-&nbsp;&nbsp;The new value for NewLine.<br />
<p><b>Remarks:</b> This method don't use the platform dependent System.Environment.Newline
            but instead works for all platforms as Windows, Unix and Mac.
            "\r\n" (\u000D\u000A) for Windows
            "\n" (\u000A) for Unix
            "\r" (\u000D) for Mac</p>

#### SetStringFormatParameterTemplatePlaceholders

```csharp
string SetStringFormatParameterTemplatePlaceholders(this string value, Dictionary<string, string> replacements)
```
<p><b>Summary:</b> Sets the string format parameter template placeholders.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`replacements`&nbsp;&nbsp;-&nbsp;&nbsp;The replacements.<br />
#### ToLines

```csharp
string[] ToLines(this string value)
```
<p><b>Summary:</b> Splits the specified text into r, n or rn separated lines.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
<p><b>Returns:</b> An array whose elements contain the substrings from this instance
            that are delimited by one or more characters in separator.</p>

#### ToStream

```csharp
Stream ToStream(this string value)
```
<p><b>Summary:</b> Converts to stream.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
#### ToStreamFromBase64

```csharp
Stream ToStreamFromBase64(this string base64Data)
```
<p><b>Summary:</b> Converts to stream from base64.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`base64Data`&nbsp;&nbsp;-&nbsp;&nbsp;The base64 data.<br />
#### TrimExtended

```csharp
string TrimExtended(this string value)
```
<p><b>Summary:</b> TrimExtended removes all leading and trailing white-space. and multi-space characters from the current System.String object.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
<p><b>Returns:</b> The string that remains after all white-space characters.
            are removed from the start and end and multi-space characters  of the current string.
            If no characters can be trimmed from the current instance, the method returns the current instance unchanged.</p>

#### TrimSpecial

```csharp
string TrimSpecial(this string value)
```
<p><b>Summary:</b> TrimSpecial removes some doubles chars and none readable chars.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The string to work on.<br />
<p><b>Returns:</b> The string without none readable chars etc.</p>

#### Truncate

```csharp
string Truncate(this string value, int maxLength, string appendValue = ...)
```
<p><b>Summary:</b> Truncates the specified maximum length.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`maxLength`&nbsp;&nbsp;-&nbsp;&nbsp;The maximum length.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`appendValue`&nbsp;&nbsp;-&nbsp;&nbsp;The append value.<br />
#### TryParseDate

```csharp
bool TryParseDate(this string value, out DateTime dateTime)
```
<p><b>Summary:</b> Tries the parse date.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`dateTime`&nbsp;&nbsp;-&nbsp;&nbsp;The date time.<br />
#### TryParseDate

```csharp
bool TryParseDate(this string value, out DateTime dateTime, CultureInfo cultureInfo, DateTimeStyles dateTimeStyles = None)
```
<p><b>Summary:</b> Tries the parse date.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`dateTime`&nbsp;&nbsp;-&nbsp;&nbsp;The date time.<br />
#### TryParseDateFromIso8601

```csharp
bool TryParseDateFromIso8601(this string value, out DateTime dateTime)
```
<p><b>Summary:</b> Tries the parse date from iso8601.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`dateTime`&nbsp;&nbsp;-&nbsp;&nbsp;The date time.<br />
#### WordCount

```csharp
int WordCount(this string value)
```
<p><b>Summary:</b> Words count.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The string to work on.<br />
<p><b>Returns:</b> The count of words in the string.</p>

#### XmlDecode

```csharp
string XmlDecode(this string xml)
```
<p><b>Summary:</b> XMLs the decode.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`xml`&nbsp;&nbsp;-&nbsp;&nbsp;The XML.<br />
#### XmlEncode

```csharp
string XmlEncode(this string xml)
```
<p><b>Summary:</b> XMLs the encode.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`xml`&nbsp;&nbsp;-&nbsp;&nbsp;The XML.<br />

<br />


## StringHasIsExtensions
StringHasIsExtensions.


```csharp
public static class StringHasIsExtensions
```

### Static Methods


#### HasHtmlTags

```csharp
bool HasHtmlTags(this string value)
```
<p><b>Summary:</b> Determines whether [has HTML tags] [the specified value].</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
<p><b>Returns:</b> true if [has HTML tags] [the specified value]; otherwise, false.</p>

#### IsAlphaNumericOnly

```csharp
bool IsAlphaNumericOnly(this string value)
```
<p><b>Summary:</b> Determines whether the specified value is alpha-numeric [a- z, A-Z, 0-9].</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The string to work on.<br />
<p><b>Returns:</b> true if the specified value is alpha-numeric [a- z, A-Z, 0-9]; otherwise, false.</p>

#### IsAlphaOnly

```csharp
bool IsAlphaOnly(this string value)
```
<p><b>Summary:</b> Determines whether the specified value is alpha [a-zA-Z].</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The string to work on.<br />
<p><b>Returns:</b> true if the specified value is alpha [a-zA-Z]; otherwise, false.</p>

#### IsCasingStyleValid

```csharp
bool IsCasingStyleValid(this string value, CasingStyle casingStyle)
```
<p><b>Summary:</b> Determines whether [is casing style valid] [the specified casing style].</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`casingStyle`&nbsp;&nbsp;-&nbsp;&nbsp;The casing style.<br />
<p><b>Returns:</b> true if [is casing style valid] [the specified casing style]; otherwise, false.</p>

#### IsCompanyCvrNumber

```csharp
bool IsCompanyCvrNumber(this string cvrNumber)
```
<p><b>Summary:</b> Determines whether the specified company CVR number is a valid number.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`cvrNumber`&nbsp;&nbsp;-&nbsp;&nbsp;The CVR number.<br />
<p><b>Returns:</b> true if the specified company CVR number is a valid number; otherwise, false.</p>

<p><b>Remarks:</b> This works only for Danish companies.</p>

#### IsCompanyPNumber

```csharp
bool IsCompanyPNumber(this string pNumber)
```
<p><b>Summary:</b> Determines whether the specified company P number is a valid number.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`pNumber`&nbsp;&nbsp;-&nbsp;&nbsp;The p number.<br />
<p><b>Returns:</b> true if the specified company P number is a valid number; otherwise, false.</p>

#### IsDate

```csharp
bool IsDate(this string value)
```
<p><b>Summary:</b> Determines whether the specified value is a date.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The string to work on.<br />
<p><b>Returns:</b> true if the specified value is a date; otherwise, false.</p>

#### IsDate

```csharp
bool IsDate(this string value, CultureInfo cultureInfo)
```
<p><b>Summary:</b> Determines whether the specified value is a date.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The string to work on.<br />
<p><b>Returns:</b> true if the specified value is a date; otherwise, false.</p>

#### IsDigitOnly

```csharp
bool IsDigitOnly(this string value)
```
<p><b>Summary:</b> Determines whether the specified value is digit [0-9].</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The string to work on.<br />
<p><b>Returns:</b> true if the specified value is digit [0-9]; otherwise, false.</p>

#### IsEmailAddress

```csharp
bool IsEmailAddress(this string value)
```
<p><b>Summary:</b> Determines whether the specified value is a valid email address.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The string to work on.<br />
<p><b>Returns:</b> true if the specified value is a valid email address; otherwise, false.</p>

#### IsEqual

```csharp
bool IsEqual(this string a, string b, StringComparison stringComparison = Ordinal, bool treatNullAsEmpty = True, bool useNormalizeAccents = False)
```
<p><b>Summary:</b> Determines whether the specified b is equal.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`a`&nbsp;&nbsp;-&nbsp;&nbsp;a.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`b`&nbsp;&nbsp;-&nbsp;&nbsp;The b.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`stringComparison`&nbsp;&nbsp;-&nbsp;&nbsp;The string comparison.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`treatNullAsEmpty`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [treat null as empty].<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`useNormalizeAccents`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [use normalize accents].<br />
<p><b>Returns:</b> true if the specified b is equal; otherwise, false.</p>

#### IsFalse

```csharp
bool IsFalse(this string value)
```
<p><b>Summary:</b> Determines whether the specified value is false.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
#### IsFirstCharacterLowerCase

```csharp
bool IsFirstCharacterLowerCase(this string value)
```
<p><b>Summary:</b> Determines whether [is first character lower case].</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
<p><b>Returns:</b> true if [is first character lower case] [the specified value]; otherwise, false.</p>

#### IsFirstCharacterUpperCase

```csharp
bool IsFirstCharacterUpperCase(this string value)
```
<p><b>Summary:</b> Determines whether [is first character upper case].</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
<p><b>Returns:</b> true if [is first character upper case] [the specified value]; otherwise, false.</p>

#### IsFormatJson

```csharp
bool IsFormatJson(this string value)
```
<p><b>Summary:</b> Determines whether [is format json].</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
<p><b>Returns:</b> true if [is format json] [the specified value]; otherwise, false.</p>

#### IsFormatXml

```csharp
bool IsFormatXml(this string value)
```
<p><b>Summary:</b> Determines whether [is format XML].</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
<p><b>Returns:</b> true if [is format XML] [the specified value]; otherwise, false.</p>

#### IsGuid

```csharp
bool IsGuid(this string value)
```
<p><b>Summary:</b> Determines whether the specified string is a System.Guid.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The string to work on.<br />
<p><b>Returns:</b> true if the specified string is a System.Guid; otherwise, false.</p>

#### IsGuid

```csharp
bool IsGuid(this string value, out Guid output)
```
<p><b>Summary:</b> Determines whether the specified string is a System.Guid.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The string to work on.<br />
<p><b>Returns:</b> true if the specified string is a System.Guid; otherwise, false.</p>

#### IsKey

```csharp
bool IsKey(this string value)
```
<p><b>Summary:</b> Determines whether the specified value is key.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
<p><b>Returns:</b> true if the specified value is key; otherwise, false.</p>

#### IsLengthEven

```csharp
bool IsLengthEven(this string value)
```
<p><b>Summary:</b> Determines whether the specified string length is even.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The string to work on.<br />
<p><b>Returns:</b> true if the specified string length is even; otherwise, false.</p>

#### IsNumericOnly

```csharp
bool IsNumericOnly(this string value)
```
<p><b>Summary:</b> Determines whether the specified value is numeric [0-9].</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The string to work on.<br />
<p><b>Returns:</b> true if the specified value is numeric [0-9]; otherwise, false.</p>

#### IsPersonCprNumber

```csharp
bool IsPersonCprNumber(this string cprNumber)
```
<p><b>Summary:</b> Determines whether the specified person CPR number is a valid number.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`cprNumber`&nbsp;&nbsp;-&nbsp;&nbsp;The CPR number.<br />
<p><b>Returns:</b> true if the specified person CPR number is a valid number; otherwise, false.</p>

#### IsSentence

```csharp
bool IsSentence(this string value)
```
<p><b>Summary:</b> Determines whether the specified value is sentence.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
<p><b>Returns:</b> true if the specified value is sentence; otherwise, false.</p>

#### IsStringFormatParametersBalanced

```csharp
bool IsStringFormatParametersBalanced(this string value, bool isNumeric = True)
```
<p><b>Summary:</b> Determines whether [is string format parameters balanced] [the specified value].</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`isNumeric`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [is numeric].<br />
<p><b>Returns:</b> true if [is string format parameters balanced] [the specified value]; otherwise, false.</p>

#### IsTrue

```csharp
bool IsTrue(this string value)
```
<p><b>Summary:</b> Determines whether the specified value is true.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
#### IsWord

```csharp
bool IsWord(this string value)
```
<p><b>Summary:</b> Determines whether the specified value is word.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
<p><b>Returns:</b> true if the specified value is word; otherwise, false.</p>


<br />


## SwitchCaseDefaultException
The exception.


```csharp
public class SwitchCaseDefaultException : Exception, ISerializable
```


<br />


## TaskExtensions
Extensions for the `System.Threading.Tasks.Task` class.


```csharp
public static class TaskExtensions
```

### Static Methods


#### StartAndWaitAllThrottled

```csharp
void StartAndWaitAllThrottled(this IEnumerable<Task> tasksToRun, int maxTasksToRunInParallel, CancellationToken cancellationToken = null)
```
<p><b>Summary:</b> Starts the given tasks and waits for them to complete. This will run, at most, the specified number of tasks in parallel. <para>NOTE: If one of the given tasks has already been started, an exception will be thrown.</para></p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`tasksToRun`&nbsp;&nbsp;-&nbsp;&nbsp;The tasks to run.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`maxTasksToRunInParallel`&nbsp;&nbsp;-&nbsp;&nbsp;The maximum number of tasks to run in parallel.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`cancellationToken`&nbsp;&nbsp;-&nbsp;&nbsp;The cancellation token.<br />
#### StartAndWaitAllThrottled

```csharp
void StartAndWaitAllThrottled(this IEnumerable<Task> tasksToRun, int maxTasksToRunInParallel, int timeoutInMilliseconds, CancellationToken cancellationToken = null)
```
<p><b>Summary:</b> Starts the given tasks and waits for them to complete. This will run, at most, the specified number of tasks in parallel. <para>NOTE: If one of the given tasks has already been started, an exception will be thrown.</para></p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`tasksToRun`&nbsp;&nbsp;-&nbsp;&nbsp;The tasks to run.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`maxTasksToRunInParallel`&nbsp;&nbsp;-&nbsp;&nbsp;The maximum number of tasks to run in parallel.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`cancellationToken`&nbsp;&nbsp;-&nbsp;&nbsp;The cancellation token.<br />

<br />


## TimeSpanExtensions
Extensions for the `System.TimeSpan` class.


```csharp
public static class TimeSpanExtensions
```

### Static Methods


#### GetPrettyTime

```csharp
string GetPrettyTime(this TimeSpan timeSpan, int decimalPrecision = 3)
```
<p><b>Summary:</b> Gets the pretty time.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`timeSpan`&nbsp;&nbsp;-&nbsp;&nbsp;The timeSpan.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`decimalPrecision`&nbsp;&nbsp;-&nbsp;&nbsp;The decimal precision.<br />
#### Max

```csharp
TimeSpan Max(this TimeSpan t1, TimeSpan t2)
```
<p><b>Summary:</b> Maximums the specified t1.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`t1`&nbsp;&nbsp;-&nbsp;&nbsp;The t1.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`t2`&nbsp;&nbsp;-&nbsp;&nbsp;The t2.<br />
#### Min

```csharp
TimeSpan Min(this TimeSpan t1, TimeSpan t2)
```
<p><b>Summary:</b> Minimums the specified t1.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`t1`&nbsp;&nbsp;-&nbsp;&nbsp;The t1.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`t2`&nbsp;&nbsp;-&nbsp;&nbsp;The t2.<br />
#### RemoveMilliseconds

```csharp
TimeSpan RemoveMilliseconds(this TimeSpan timeSpan)
```
<p><b>Summary:</b> Removes the millisecond part of the timeSpan.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`timeSpan`&nbsp;&nbsp;-&nbsp;&nbsp;The timeSpan.<br />
#### SecondsNotZero

```csharp
bool SecondsNotZero(this TimeSpan timeSpan)
```
<p><b>Summary:</b> Determines whether the seconds part of the datetime is zero.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`timeSpan`&nbsp;&nbsp;-&nbsp;&nbsp;The timeSpan.<br />
<p><b>Returns:</b> true if [is seconds is zero] otherwise, false.</p>


<br />


## TypeExtensions
Extensions for the `System.Type` class.


```csharp
public static class TypeExtensions
```

### Static Methods


#### BeautifyName

```csharp
string BeautifyName(this Type type, bool useFullName = False, bool useHtmlFormat = False, bool useGenericParameterNamesAsT = False, bool useSuffixQuestionMarkForGeneric = False)
```
<p><b>Summary:</b> Beautifies the name.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`type`&nbsp;&nbsp;-&nbsp;&nbsp;The type.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`useFullName`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [use full name].<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`useHtmlFormat`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [use HTML format].<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`useGenericParameterNamesAsT`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [use generic parameter names as t].<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`useSuffixQuestionMarkForGeneric`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [use suffix question mark for generic].<br />
#### BeautifyTypeName

```csharp
string BeautifyTypeName(this Type type, bool useFullName = False)
```
<p><b>Summary:</b> Beautifies the name of the type.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`type`&nbsp;&nbsp;-&nbsp;&nbsp;The type.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`useFullName`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [use full name].<br />
#### BeautifyTypeOfName

```csharp
string BeautifyTypeOfName(this Type type, bool useFullName = False, bool useHtmlFormat = False)
```
<p><b>Summary:</b> Beautifies the name of the type of.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`type`&nbsp;&nbsp;-&nbsp;&nbsp;The type.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`useFullName`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [use full name].<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`useHtmlFormat`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [use HTML format].<br />
#### GetAttribute

```csharp
T GetAttribute(this Type type)
```
<p><b>Summary:</b> Gets the attribute.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`type`&nbsp;&nbsp;-&nbsp;&nbsp;The type.<br />
#### GetAttributes

```csharp
IEnumerable<T> GetAttributes(this Type type)
```
<p><b>Summary:</b> Gets the attributes.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`type`&nbsp;&nbsp;-&nbsp;&nbsp;The type.<br />
#### GetBaseTypeGenericArgumentType

```csharp
Type GetBaseTypeGenericArgumentType(this Type type)
```
<p><b>Summary:</b> Gets the type of the base type generic argument.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`type`&nbsp;&nbsp;-&nbsp;&nbsp;The type.<br />
#### GetBaseTypeGenericArgumentTypes

```csharp
Type[] GetBaseTypeGenericArgumentTypes(this Type type)
```
<p><b>Summary:</b> Gets the base type generic argument types.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`type`&nbsp;&nbsp;-&nbsp;&nbsp;The type.<br />
#### GetNameWithoutGenericType

```csharp
string GetNameWithoutGenericType(this Type type, bool useFullName = False)
```
<p><b>Summary:</b> Get the name of the type without generic part.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`type`&nbsp;&nbsp;-&nbsp;&nbsp;The type.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`useFullName`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [use full name].<br />
#### GetPrivateDeclaredOnlyMethod

```csharp
MethodInfo GetPrivateDeclaredOnlyMethod(this Type type, string name)
```
<p><b>Summary:</b> Gets the private declared only method.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`type`&nbsp;&nbsp;-&nbsp;&nbsp;The type.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`name`&nbsp;&nbsp;-&nbsp;&nbsp;The name.<br />
#### GetPrivateDeclaredOnlyMethods

```csharp
MethodInfo[] GetPrivateDeclaredOnlyMethods(this Type type)
```
<p><b>Summary:</b> Gets the private declared only methods.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`type`&nbsp;&nbsp;-&nbsp;&nbsp;The type.<br />
#### GetPublicDeclaredOnlyMethods

```csharp
MethodInfo[] GetPublicDeclaredOnlyMethods(this Type type)
```
<p><b>Summary:</b> Gets the public declared only methods.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`type`&nbsp;&nbsp;-&nbsp;&nbsp;The type.<br />
<p><b>Remarks:</b> Use: BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly.</p>

#### HasValidationAttributes

```csharp
bool HasValidationAttributes(this Type type)
```
<p><b>Summary:</b> Determines whether [has validation attributes].</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`type`&nbsp;&nbsp;-&nbsp;&nbsp;The type.<br />
<p><b>Returns:</b> true if [has validation attributes] [the specified type]; otherwise, false.</p>

#### IsDelegate

```csharp
bool IsDelegate(this Type type)
```
<p><b>Summary:</b> Determines whether this instance is delegate.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`type`&nbsp;&nbsp;-&nbsp;&nbsp;The type.<br />
<p><b>Returns:</b> true if the specified type is delegate; otherwise, false.</p>

#### IsInheritedFrom

```csharp
bool IsInheritedFrom(this Type type, Type inheritType)
```
<p><b>Summary:</b> Determines whether [is inherited from] [the specified inherit type].</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`type`&nbsp;&nbsp;-&nbsp;&nbsp;The type.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`inheritType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the inherit.<br />
<p><b>Returns:</b> true if [is inherited from] [the specified inherit type]; otherwise, false.</p>

#### IsInheritedFromGenericWithArgumentType

```csharp
bool IsInheritedFromGenericWithArgumentType(this Type type, Type inheritType, Type argumentType, bool matchAlsoOnArgumentTypeInterface = True)
```
<p><b>Summary:</b> Determines whether [is inherited from generic with argument type] [the specified inherit type].</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`type`&nbsp;&nbsp;-&nbsp;&nbsp;The type.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`inheritType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the inherit.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`argumentType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the argument.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`matchAlsoOnArgumentTypeInterface`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [match also on argument type interface].<br />
<p><b>Returns:</b> true if [is inherited from generic with argument type] [the specified inherit type]; otherwise, false.</p>

#### IsNullable

```csharp
bool IsNullable(this Type type)
```
<p><b>Summary:</b> Determines whether this instance is nullable.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`type`&nbsp;&nbsp;-&nbsp;&nbsp;The type.<br />
<p><b>Returns:</b> true if the specified type is nullable; otherwise, false.</p>

#### IsSimple

```csharp
bool IsSimple(this Type type)
```
<p><b>Summary:</b> Determines whether this instance is simple.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`type`&nbsp;&nbsp;-&nbsp;&nbsp;The type.<br />
<p><b>Returns:</b> true if the specified type is simple; otherwise, false.</p>

#### IsSubClassOfRawGeneric

```csharp
bool IsSubClassOfRawGeneric(this Type baseType, Type derivedType)
```
<p><b>Summary:</b> Determines whether [is sub class of raw generic] [the specified derived type].</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`baseType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the base.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`derivedType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the derived.<br />
<p><b>Returns:</b> true if [is sub class of raw generic] [the specified derived type]; otherwise, false.</p>

#### TryGetAttribute

```csharp
T TryGetAttribute(this Type type)
```
<p><b>Summary:</b> Tries the get attribute.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`type`&nbsp;&nbsp;-&nbsp;&nbsp;The type.<br />
#### TryGetEnumType

```csharp
bool TryGetEnumType(this Type type, out Type enumType)
```
<p><b>Summary:</b> Try to extract the enum-type.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`type`&nbsp;&nbsp;-&nbsp;&nbsp;The type.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`enumType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the enum.<br />

<br />


## UnexpectedTypeException
The exception that is thrown when actual type differs from expected type.


```csharp
public class UnexpectedTypeException : Exception, ISerializable
```


<br />


## VersionExtensions

```csharp
public static class VersionExtensions
```

### Static Methods


#### CompareTo

```csharp
int CompareTo(this Version version, Version otherVersion, int significantParts)
```
<p><b>Summary:</b> Is 'version' greater then the 'otherVersion', where the significantParts is the stop part. Example significantParts=2, then only Major and Minor wil be taken into consideration.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`version`&nbsp;&nbsp;-&nbsp;&nbsp;The version.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`otherVersion`&nbsp;&nbsp;-&nbsp;&nbsp;The other version.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`significantParts`&nbsp;&nbsp;-&nbsp;&nbsp;The significant parts.<br />
<p><b>Returns:</b> -1, 0 or 1.</p>

#### GreaterThan

```csharp
bool GreaterThan(this Version version, Version otherVersion)
```
<p><b>Summary:</b> Is 'version' greater then the 'otherVersion'.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`version`&nbsp;&nbsp;-&nbsp;&nbsp;The version.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`otherVersion`&nbsp;&nbsp;-&nbsp;&nbsp;The other version.<br />
<p><b>Returns:</b> true if 'otherVersion' is greater then the current 'version'; otherwise, false.</p>

<hr /><div style='text-align: right'><i>Generated by MarkdownCodeDoc version 1.2</i></div>
