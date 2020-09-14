<div style='text-align: right'>

[References](Index.md)&nbsp;&nbsp;-&nbsp;&nbsp;[References extended](IndexExtended.md)
</div>

# Atc

<br />


## AddressType
Flag-Enumeration: AddressType.


```csharp
public enum AddressType
```


| Value | Name | Description | Summary | 
| --- | --- | --- | --- | 
| 0 | None | None | Default None. | 
| 1 | Address | Address | The address indicates that the returned result is a precise geocode for which we have  location information accurate down to street address precision. - With floor and door, if specified. | 
| 2 | AccessAddress | Access Address | The access address indicates that the returned result is a precise geocode for which we have  location information accurate down to street address precision. - No floor and door. | 
| 3 | AllRegularly | All Regularly | All regularly | 
| 4 | PreliminaryAddress | Preliminary Address | The preliminary address - same as AccessAddress, but preliminary. | 
| 8 | PreliminaryAccessAddress | Preliminary Access Address | The preliminary access address - same as Address, but preliminary. | 
| 12 | AllPreliminary | All Preliminary | All preliminary | 
| 15 | All | All | All | 
| 16 | RangeInterpolated | Range Interpolated | The range interpolated indicates that the returned result reflects an approximation (usually on a road)  interpolated between two precise points (such as intersections).  Interpolated results are generally returned when rooftop geocodes are unavailable for a street address. | 
| 32 | GeometricCenter | Geometric Center | The geometric center indicates that the returned result is the geometric center  of a result such as a polyline (for example, a street) or polygon (region). | 
| 64 | Approximate | Approximate | The approximate indicates that the returned result is approximate. | 
| 128 | Partial | Partial | The partial indicates that this not an full-validated-address, but a more approximate address - based on country and city. | 



<br />


## ArticleNumberType
ArticleNumberType.


```csharp
public enum ArticleNumberType
```


| Value | Name | Description | Summary | 
| --- | --- | --- | --- | 
| 0 | Unknown | Unknown | Default Unknown. | 
| 1 | ASIN | ASIN | Amazon Standard Identification Number | 
| 2 | EAN8 | EAN8 | European Article Number | 
| 3 | EAN13 | EAN13 | European Article Number | 
| 4 | GTIN | GTIN | Global Trade Item Number (previously EAN - European Article Number) | 
| 5 | ISBN10 | ISBN10 | International Standard Book Number | 
| 6 | ISBN13 | ISBN13 | International Standard Book Number | 
| 7 | SKU | SKU | Stock keeping unit | 
| 8 | UPC | UPC | Universal Product Code | 
| 9 | ISSN | ISSN | International Standard Serial Number | 



<br />


## AtcAssemblyTypeInitializer

```csharp
public class AtcAssemblyTypeInitializer
```


<br />


## BooleanOperatorType
Enumeration: BooleanOperatorType.


```csharp
public enum BooleanOperatorType
```


| Value | Name | Description | Summary | 
| --- | --- | --- | --- | 
| 0 | None | None | Default None, and it's not a BooleanOperator. | 
| 1 | AND | And | AND. | 
| 2 | OR | Or | OR. | 
| 3 | NOT | Not | NOT. | 
| 4 | NEAR | Near | NEAR. | 



<br />


## CardinalDirectionType
Flag-Enumeration: CardinalDirectionType.


```csharp
public enum CardinalDirectionType
```


| Value | Name | Description | Summary | 
| --- | --- | --- | --- | 
| 0 | None | None | Default None. | 
| 1 | North | North | North. | 
| 2 | NorthNorthEast | North North East | NorthNorthEast. | 
| 4 | NorthEast | North East | NorthEast. | 
| 8 | EastNorthEast | East North East | EastNorthEast. | 
| 16 | East | East | East. | 
| 32 | EastSouthEast | East South East | EastSouthEast. | 
| 64 | SouthEast | South East | SouthEast. | 
| 128 | SouthSouthEast | South South East | SouthSouthEast. | 
| 256 | SouthSouthWest | South South West | SouthSouthWest. | 
| 512 | South | South | South. | 
| 1024 | SouthWest | South West | SouthWest. | 
| 2048 | WestSouthWest | West South West | WestSouthWest. | 
| 4096 | West | West | West. | 
| 4625 | Simple | Simple | Simple = North | East | South | West. | 
| 8192 | WestNorthWest | West North West | WestNorthWest. | 
| 16384 | NorthWest | North West | NorthWest | 
| 22101 | Medium | Medium | Medium = North | NorthEast | East | SouthEast | South | SouthWest | West | NorthWest. | 
| 32768 | NorthNorthWest | North North West | NorthNorthWest. | 
| 65535 | Advanced | Advanced | Advanced = North | NorthNorthEast | NorthEast | EastNorthEast | East | EastSouthEast | SouthEast | SouthSouthEast | South | SouthSouthWest | SouthWest | WestSouthWest | West | WestNorthWest | NorthWest | NorthNorthWest. | 



<br />


## CasingStyle

```csharp
public enum CasingStyle
```


| Value | Name | Description | Summary | 
| --- | --- | --- | --- | 
| 0 | None | None | Default None. | 
| 1 | CamelCase | Camel Case | The camel case is formatted like this: "camelCase". | 
| 2 | KebabCase | Kebab Case | The kebab case is formatted like this: "kebab-case". | 
| 3 | PascalCase | Pascal Case | The pascal case is formatted like this: "PascalCase". | 
| 4 | SnakeCase | Snake Case | The snake case is formatted like this: "snake_case". | 



<br />


## CollectionActionType
Enumeration: CollectionActionType.


```csharp
public enum CollectionActionType
```


| Value | Name | Description | Summary | 
| --- | --- | --- | --- | 
| 0 | None | None | Default None. | 
| 1 | Added | Added | Added. | 
| 2 | Updated | Updated | Updated. | 
| 3 | Removed | Removed | Removed. | 
| 4 | Cleared | Cleared | Cleared. | 
| 5 | Saved | Saved | Saved. | 
| 6 | Loaded | Loaded | Loaded. | 



<br />


## DateTimeDiffCompareType
Enumeration: DateTimeDiffCompareType.


```csharp
public enum DateTimeDiffCompareType
```


| Value | Name | Description | Summary | 
| --- | --- | --- | --- | 
| 0 | Ticks | Ticks | Ticks. | 
| 1 | Milliseconds | Milliseconds | Milliseconds. | 
| 2 | Seconds | Seconds | Seconds. | 
| 3 | Minutes | Minutes | Minutes. | 
| 4 | Hours | Hours | Hours. | 
| 5 | Days | Days | Days. | 
| 6 | Year | Year | Year. | 
| 7 | Quartal | Quartal | Quartal. | 



<br />


## DropDownFirstItemType
Enumeration: DropDownFirstItemType.


```csharp
public enum DropDownFirstItemType
```


| Value | Name | Description | Summary | 
| --- | --- | --- | --- | 
| -4 | IncludeAll | -- All -- | IncludeAll. | 
| -3 | PleaseSelect | -- Select -- | PleaseSelect. | 
| -2 | Blank | Blank | Blank. | 
| -1 | None | None | Default None. | 



<br />


## Enum&lt;T&gt;
Extension methods for enums.


```csharp
public static class Enum&lt;T&gt;
```

### Static Methods


#### GetEnumValue

```csharp
T GetEnumValue(string value, bool ignoreCase = True)
```
<p><b>Summary:</b> Converts the string representation of the name or numeric value of one or more enumerated constants to an equivalent enumerated object.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;A string containing the name or value to convert.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`ignoreCase`&nbsp;&nbsp;-&nbsp;&nbsp;true to ignore case; false to regard case.<br />
<p><b>Returns:</b> If parsed successfully and defined as a valid enum value, the enum value is returned. Otherwise the default value is returned.</p>

<b>Code usage:</b>

```csharp
DayOfWeek day = Enum<DayOfWeek>.GetEnumValue(value);
```
<b>Code example:</b>

```csharp
Assert.Equal(DayOfWeek.Monday, Enum<DayOfWeek>.GetEnumValue("Monday"));
Assert.Equal(DayOfWeek.Monday, Enum<DayOfWeek>.GetEnumValue("MONDAY"));
```
#### Parse

```csharp
T Parse(string value, bool ignoreCase = True)
```
<p><b>Summary:</b> Converts the string representation of the name or numeric value of one or more enumerated constants to an equivalent enumerated object.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;A string containing the name or value to convert.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`ignoreCase`&nbsp;&nbsp;-&nbsp;&nbsp;true to ignore case; false to regard case.<br />
<p><b>Returns:</b> An object of type enumType whose value is represented by value.</p>

<b>Code usage:</b>

```csharp
DayOfWeek day = Enum<DayOfWeek>.Parse(value);
```
<b>Code example:</b>

```csharp
Assert.Equal(DayOfWeek.Monday, Enum<DayOfWeek>.Parse("Monday"));
```
#### ToArray

```csharp
Array ToArray(DropDownFirstItemType dropDownFirstItemType = None, bool useDescriptionAttribute = True, bool includeDefault = True, SortDirectionType sortDirectionType = None, bool byFlagIncludeBase = True, bool byFlagIncludeCombined = True)
```
<p><b>Summary:</b> Converts the enum to array.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`dropDownFirstItemType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the drop down first item.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`useDescriptionAttribute`&nbsp;&nbsp;-&nbsp;&nbsp;true to use the display/description/localizeddescription attribute value if exist, default value is name; false to just use the name value.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`includeDefault`&nbsp;&nbsp;-&nbsp;&nbsp;true to include the default enumeration value; false to skip it.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`sortDirectionType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the sort direction.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`byFlagIncludeBase`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [by flag include base].<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`byFlagIncludeCombined`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [by flag include combined].<br />
<p><b>Returns:</b> An array of names from the enum.</p>

<b>Code usage:</b>

```csharp
Array array = Enum<DayOfWeek>.ToArray();
```
<b>Code example:</b>

```csharp
Array array = Enum<DayOfWeek>.ToArray();
Assert.Equal(7, array.Length);
```
#### ToDictionary

```csharp
Dictionary<int, string> ToDictionary(DropDownFirstItemType dropDownFirstItemType = None, bool useDescriptionAttribute = True, bool includeDefault = True, SortDirectionType sortDirectionType = None, bool byFlagIncludeBase = True, bool byFlagIncludeCombined = True)
```
<p><b>Summary:</b> Converts the enum to dictionary.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`dropDownFirstItemType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the drop down first item.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`useDescriptionAttribute`&nbsp;&nbsp;-&nbsp;&nbsp;true to use the display/description/localizeddescription attribute value if exist, default value is name; false to just use the name value.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`includeDefault`&nbsp;&nbsp;-&nbsp;&nbsp;true to include the default enumeration value; false to skip it.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`sortDirectionType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the sort direction.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`byFlagIncludeBase`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [by flag include base].<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`byFlagIncludeCombined`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [by flag include combined].<br />
<p><b>Returns:</b> An dictionary of enum values as int and names from the enum.</p>

<b>Code usage:</b>

```csharp
Dictionary<int, string> dictionary = Enum<DayOfWeek>.ToDictionary();
```
<b>Code example:</b>

```csharp
Dictionary<int, string> dictionary = Enum<DayOfWeek>.ToDictionary();
Assert.Equal(7, dictionary.Count);
```
#### ToDictionaryWithStringKey

```csharp
Dictionary<string, string> ToDictionaryWithStringKey(DropDownFirstItemType dropDownFirstItemType = None, bool useDescriptionAttribute = True, bool includeDefault = True, SortDirectionType sortDirectionType = None, bool byFlagIncludeBase = True, bool byFlagIncludeCombined = True)
```
<p><b>Summary:</b> Converts the enum to dictionary with key as string.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`dropDownFirstItemType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the drop down first item.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`useDescriptionAttribute`&nbsp;&nbsp;-&nbsp;&nbsp;true to use the display/description/localizeddescription attribute value if exist, default value is name; false to just use the name value.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`includeDefault`&nbsp;&nbsp;-&nbsp;&nbsp;true to include the default enumeration value; false to skip it.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`sortDirectionType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the sort direction.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`byFlagIncludeBase`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [by flag include base].<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`byFlagIncludeCombined`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [by flag include combined].<br />
<p><b>Returns:</b> An dictionary of enum values as string and names from the enum.</p>

<b>Code usage:</b>

```csharp
Dictionary<string, string> dictionary = Enum<DayOfWeek>.ToDictionaryWithStringKey();
```
<b>Code example:</b>

```csharp
Dictionary<string, string> dictionary = Enum<DayOfWeek>.ToDictionaryWithStringKey();
Assert.Equal(7, dictionary.Count);
```
#### ToKeyValuePairs

```csharp
List<KeyValuePair<int, string>> ToKeyValuePairs(DropDownFirstItemType dropDownFirstItemType = None, bool useDescriptionAttribute = True, bool includeDefault = True, SortDirectionType sortDirectionType = None, bool byFlagIncludeBase = True, bool byFlagIncludeCombined = True)
```
<p><b>Summary:</b> Converts the enum to list of key value pairs.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`dropDownFirstItemType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the drop down first item.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`useDescriptionAttribute`&nbsp;&nbsp;-&nbsp;&nbsp;true to use the display/description/localizeddescription attribute value if exist, default value is name; false to just use the name value.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`includeDefault`&nbsp;&nbsp;-&nbsp;&nbsp;true to include the default enumeration value; false to skip it.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`sortDirectionType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the sort direction.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`byFlagIncludeBase`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [by flag include base].<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`byFlagIncludeCombined`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [by flag include combined].<br />
<p><b>Returns:</b> An list of KeyValuePair of the enum with the key as int.</p>

<b>Code usage:</b>

```csharp
List<KeyValuePair<int, string>> list = Enum<DayOfWeek>.ToKeyValuePairs();
```
<b>Code example:</b>

```csharp
List<KeyValuePair<int, string>> list = Enum<DayOfWeek>.ToKeyValuePairs();
Assert.Equal(7, list.Count);
```
#### ToKeyValuePairsWithStringKey

```csharp
List<KeyValuePair<string, string>> ToKeyValuePairsWithStringKey(DropDownFirstItemType dropDownFirstItemType = None, bool useDescriptionAttribute = True, bool includeDefault = True, SortDirectionType sortDirectionType = None, bool byFlagIncludeBase = True, bool byFlagIncludeCombined = True)
```
<p><b>Summary:</b> Converts the enum to list of key value pairs with key as string.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`dropDownFirstItemType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the drop down first item.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`useDescriptionAttribute`&nbsp;&nbsp;-&nbsp;&nbsp;true to use the display/description/localizeddescription attribute value if exist, default value is name; false to just use the name value.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`includeDefault`&nbsp;&nbsp;-&nbsp;&nbsp;true to include the default enumeration value; false to skip it.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`sortDirectionType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the sort direction.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`byFlagIncludeBase`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [by flag include base].<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`byFlagIncludeCombined`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [by flag include combined].<br />
<p><b>Returns:</b> An list of KeyValuePair of the enum with the key as string.</p>

<b>Code usage:</b>

```csharp
List<KeyValuePair<string, string>> list = Enum<DayOfWeek>.ToKeyValuePairsWithStringKey();
```
<b>Code example:</b>

```csharp
List<KeyValuePair<int, string>> list = Enum<DayOfWeek>.ToKeyValuePairsWithStringKey();
Assert.Equal(7, list.Count);
```
#### TryGetEnumValue

```csharp
bool TryGetEnumValue(string value, bool ignoreCase, out T returnedValue)
```
<p><b>Summary:</b> Converts the string representation of the name or numeric value of one or more enumerated constants to an equivalent enumerated object.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;A string containing the name or value to convert.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`ignoreCase`&nbsp;&nbsp;-&nbsp;&nbsp;true to ignore case; false to regard case.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`returnedValue`&nbsp;&nbsp;-&nbsp;&nbsp;When this method returns, contains the enum value, if the conversion succeeded, or default enum if the conversion failed.<br />
<p><b>Returns:</b> If parsed successfully and defined as a valid enum value, the enum value is returned. Otherwise the default value is returned.</p>

<b>Code usage:</b>

```csharp
bool isParsed = Enum<DayOfWeek>.TryGetEnumValue(value, ignoreCase, out var dayOfWeek);
```
<b>Code example:</b>

```csharp
DayOfWeek expectedOut;
bool isParsed = Enum<DayOfWeek>.TryGetEnumValue("Monday", true, out var dayOfWeek);
Assert.True(isParsed);
Assert.Equal(expectedOut, dayOfWeek);
```
#### TryGetEnumValue

```csharp
bool TryGetEnumValue(Enum value, out T returnedValue)
```
<p><b>Summary:</b> Converts the string representation of the name or numeric value of one or more enumerated constants to an equivalent enumerated object.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;A string containing the name or value to convert.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`ignoreCase`&nbsp;&nbsp;-&nbsp;&nbsp;true to ignore case; false to regard case.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`returnedValue`&nbsp;&nbsp;-&nbsp;&nbsp;When this method returns, contains the enum value, if the conversion succeeded, or default enum if the conversion failed.<br />
<p><b>Returns:</b> If parsed successfully and defined as a valid enum value, the enum value is returned. Otherwise the default value is returned.</p>

<b>Code usage:</b>

```csharp
bool isParsed = Enum<DayOfWeek>.TryGetEnumValue(value, ignoreCase, out var dayOfWeek);
```
<b>Code example:</b>

```csharp
DayOfWeek expectedOut;
bool isParsed = Enum<DayOfWeek>.TryGetEnumValue("Monday", true, out var dayOfWeek);
Assert.True(isParsed);
Assert.Equal(expectedOut, dayOfWeek);
```
#### TryParse

```csharp
bool TryParse(string value, out T returnedValue)
```
<p><b>Summary:</b> Converts the string representation of a enum. A return value indicates whether the conversion succeeded.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;A string containing a enum to convert.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`returnedValue`&nbsp;&nbsp;-&nbsp;&nbsp;When this method returns, contains the enum value, if the conversion succeeded, or default enum if the conversion failed.<br />
<p><b>Returns:</b> true if the value was converted successfully; otherwise, false.</p>

<b>Code usage:</b>

```csharp
bool isParsed = Enum<DayOfWeek>.TryParse(value, out var dayOfWeek);
```
<b>Code example:</b>

```csharp
DayOfWeek expectedOut;
bool isParsed = Enum<DayOfWeek>.TryParse("Monday", out var dayOfWeek);
Assert.True(isParsed);
Assert.Equal(expectedOut, dayOfWeek);
```
#### TryParse

```csharp
bool TryParse(string value, bool ignoreCase, out T returnedValue)
```
<p><b>Summary:</b> Converts the string representation of a enum. A return value indicates whether the conversion succeeded.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;A string containing a enum to convert.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`returnedValue`&nbsp;&nbsp;-&nbsp;&nbsp;When this method returns, contains the enum value, if the conversion succeeded, or default enum if the conversion failed.<br />
<p><b>Returns:</b> true if the value was converted successfully; otherwise, false.</p>

<b>Code usage:</b>

```csharp
bool isParsed = Enum<DayOfWeek>.TryParse(value, out var dayOfWeek);
```
<b>Code example:</b>

```csharp
DayOfWeek expectedOut;
bool isParsed = Enum<DayOfWeek>.TryParse("Monday", out var dayOfWeek);
Assert.True(isParsed);
Assert.Equal(expectedOut, dayOfWeek);
```

<br />


## EnumGuidAttribute
Enum Guid Attribute.


```csharp
public class EnumGuidAttribute : Attribute
```

### Properties


#### GlobalIdentifier

```csharp
GlobalIdentifier
```
<p><b>Summary:</b> Gets the global identifier.</p>


<br />


## FileSystemWatcherChangeType
Flag-Enumeration: FileSystemWatcherChangeType.


```csharp
public enum FileSystemWatcherChangeType
```


| Value | Name | Description | Summary | 
| --- | --- | --- | --- | 
| 0 | None | None | Default None. | 
| 1 | Added | Added | Added. | 
| 2 | Deleted | Deleted | Deleted. | 
| 4 | Renamed | Renamed | Renamed. | 
| 8 | Changed | Changed | Changed. | 
| 15 | All | All | All = Added | Deleted | Renamed | Changed. | 



<br />


## ForwardReverseType
Enumeration: ForwardReverseType.


```csharp
public enum ForwardReverseType
```


| Value | Name | Description | Summary | 
| --- | --- | --- | --- | 
| 0 | None | None | Default None. | 
| 1 | Forward | Forward | Forward. | 
| 2 | Reverse | Reverse | Reverse. | 



<br />


## GlobalizationConstants
GlobalizationConstants.


```csharp
public static class GlobalizationConstants
```

### Static Fields


#### DanishCultureInfo

```csharp
CultureInfo DanishCultureInfo
```
#### DateTimeIso8601

```csharp
string DateTimeIso8601
```
#### EnglishCultureInfo

```csharp
CultureInfo EnglishCultureInfo
```

<br />


## GlobalizationLcidConstants
GlobalizationLcidConstants.


```csharp
public static class GlobalizationLcidConstants
```

### Static Fields


#### Denmark

```csharp
int Denmark
```
<p><b>Summary:</b> Denmark - 1030.</p>

#### Germany

```csharp
int Germany
```
<p><b>Summary:</b> Germany - 1031.</p>

#### GreatBritain

```csharp
int GreatBritain
```
<p><b>Summary:</b> Great Britain - 2057.</p>

#### Invariant

```csharp
int Invariant
```
<p><b>Summary:</b> The invariant.</p>

#### UnitedStates

```csharp
int UnitedStates
```
<p><b>Summary:</b> United States - 1033.</p>


<br />


## GridCell
Represents an x- and y-coordinate point in 2-D grid.


```csharp
public struct GridCell : ICloneable, IEquatable&lt;GridCell&gt;
```

### Properties


#### IsDefault

```csharp
IsDefault
```
<p><b>Summary:</b> Determines whether this instance is default.</p>

<p><b>Returns:</b> true if this instance is default; otherwise, false.</p>

#### X

```csharp
X
```
<p><b>Summary:</b> Gets or sets the X.</p>

#### Y

```csharp
Y
```
<p><b>Summary:</b> Gets or sets the Y.</p>

### Methods


#### Clone

```csharp
object Clone()
```
#### Equals

```csharp
bool Equals(GridCell other)
```
<p><b>Summary:</b> Equals the specified other.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`other`&nbsp;&nbsp;-&nbsp;&nbsp;The other.<br />
#### Equals

```csharp
bool Equals(object obj)
```
<p><b>Summary:</b> Equals the specified other.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`other`&nbsp;&nbsp;-&nbsp;&nbsp;The other.<br />
#### GetHashCode

```csharp
int GetHashCode()
```
#### ToString

```csharp
string ToString()
```
#### ToStringShort

```csharp
string ToStringShort()
```
<p><b>Summary:</b> To the string short.</p>

<p><b>Returns:</b> Return a short format of x and y.</p>


<br />


## IdentityRoleType
Flag-Enumeration: IdentityRoleType.


```csharp
public enum IdentityRoleType
```


| Value | Name | Description | Summary | 
| --- | --- | --- | --- | 
| 0 | None | None | Default None. | 
| 1 | Anonymous | Anonymous | Indicates that the identity role is anonymous. | 
| 2 | User | User | Indicates that the identity role is a normal user. | 
| 4 | SuperUser | Super User | Indicates that the identity role is a normal user. | 
| 8 | Admin | Administrator | Indicates that the identity role is administrator. | 
| 16 | SuperAdmin | Super Administrator | Indicates that the identity role is super administrator. | 



<br />


## IgnoreDisplayAttribute
Ignore Display Attribute.


```csharp
public class IgnoreDisplayAttribute : Attribute
```


<br />


## InsertRemoveType
Enumeration: InsertRemoveType.


```csharp
public enum InsertRemoveType
```


| Value | Name | Description | Summary | 
| --- | --- | --- | --- | 
| 0 | None | None | Default None. | 
| 1 | Insert | Insert | Insert. | 
| 2 | Remove | Remove | Remove. | 



<br />


## LeftRightType
Enumeration: LeftRightType.


```csharp
public enum LeftRightType
```


| Value | Name | Description | Summary | 
| --- | --- | --- | --- | 
| 0 | None | None | Default None | 
| 1 | Left | Left | Left | 
| 2 | Right | Right | Right | 



<br />


## LetterAccentType
Flag-Enumeration: LetterAccentType.


```csharp
public enum LetterAccentType
```


| Value | Name | Description | Summary | 
| --- | --- | --- | --- | 
| 0 | None | None | Default None. | 
| 1 | Grave | Grave | Grave. | 
| 2 | Acute | Acute | Acute. | 
| 4 | Circumflex | Circumflex | Circumflex. | 
| 8 | Tilde | Tilde | Tilde. | 
| 16 | Umlaut | Umlaut | Umlaut. | 
| 31 | All | All | All. | 



<br />


## LocalizedDescriptionAttribute
Localized Description Attribute.


```csharp
public class LocalizedDescriptionAttribute : DescriptionAttribute
```

### Properties


#### Description

```csharp
Description
```
<p><b>Summary:</b> Gets the description stored in this attribute.</p>

<p><b>Returns:</b> The description stored in this attribute.</p>


<br />


## LogCategoryType
Enumeration: LogCategoryType categories available for logging.


```csharp
public enum LogCategoryType
```


| Value | Name | Description | Summary | 
| --- | --- | --- | --- | 
| 0 | Critical | Critical | Critical. | 
| 1 | Error | Error | Error. | 
| 2 | Warning | Warning | Warning. | 
| 3 | Security | Security | Security. | 
| 4 | Audit | Audit | Audit. | 
| 5 | Service | Service | Service. | 
| 6 | UI | UI | UI. | 
| 7 | Information | Information | Information. | 
| 8 | Debug | Debug | Debug. | 
| 9 | Trace | Trace | Trace. | 



<br />


## NumericAlphaComparer
NumericAlphaComparer.


```csharp
public class NumericAlphaComparer : IComparer&lt;string&gt;
```

### Methods


#### Compare

```csharp
int Compare(string x, string y)
```

<br />


## OnOffType
Enumeration: OnOffType.


```csharp
public enum OnOffType
```


| Value | Name | Description | Summary | 
| --- | --- | --- | --- | 
| 0 | None | None | Default None. | 
| 1 | Off | Off | Off. | 
| 2 | On | On | ON. | 



<br />


## Point2D
Represents an x- and y-coordinate point in 2-D space.


```csharp
public struct Point2D : IEquatable&lt;Point2D&gt;
```

### Properties


#### IsDefault

```csharp
IsDefault
```
<p><b>Summary:</b> Gets a value indicating whether this instance is default.</p>

#### X

```csharp
X
```
<p><b>Summary:</b> Gets or sets the X.</p>

#### Y

```csharp
Y
```
<p><b>Summary:</b> Gets or sets the Y.</p>

### Methods


#### Equals

```csharp
bool Equals(Point2D other)
```
<p><b>Summary:</b> Equals the specified other.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`other`&nbsp;&nbsp;-&nbsp;&nbsp;The other.<br />
#### Equals

```csharp
bool Equals(object obj)
```
<p><b>Summary:</b> Equals the specified other.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`other`&nbsp;&nbsp;-&nbsp;&nbsp;The other.<br />
#### GetHashCode

```csharp
int GetHashCode()
```
#### ToString

```csharp
string ToString()
```

<br />


## Point3D
Represents an x-, y-, and z-coordinate point in 3-D space.


```csharp
public struct Point3D : IEquatable&lt;Point3D&gt;
```

### Properties


#### IsDefault

```csharp
IsDefault
```
<p><b>Summary:</b> Gets a value indicating whether this instance is default.</p>

#### X

```csharp
X
```
<p><b>Summary:</b> Gets or sets the X.</p>

#### Y

```csharp
Y
```
<p><b>Summary:</b> Gets or sets the Y.</p>

#### Z

```csharp
Z
```
<p><b>Summary:</b> Gets or sets the Z.</p>

### Methods


#### Equals

```csharp
bool Equals(Point3D other)
```
<p><b>Summary:</b> Equals the specified other.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`other`&nbsp;&nbsp;-&nbsp;&nbsp;The other.<br />
#### Equals

```csharp
bool Equals(object obj)
```
<p><b>Summary:</b> Equals the specified other.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`other`&nbsp;&nbsp;-&nbsp;&nbsp;The other.<br />
#### GetHashCode

```csharp
int GetHashCode()
```
#### ToString

```csharp
string ToString()
```

<br />


## SortDirectionType
Enumeration: SortDirectionType.


```csharp
public enum SortDirectionType
```


| Value | Name | Description | Summary | 
| --- | --- | --- | --- | 
| 0 | None | None | Default None. | 
| 1 | Ascending | Ascending | Ascending. | 
| 2 | Descending | Descending | Descending. | 



<br />


## TriggerActionType
Enumeration: TriggerActionType.


```csharp
public enum TriggerActionType
```


| Value | Name | Description | Summary | 
| --- | --- | --- | --- | 
| 0 | None | None | Default None. | 
| 1 | Insert | Insert | Insert. | 
| 2 | Update | Update | Update. | 
| 3 | Delete | Delete | Delete. | 



<br />


## TupleEqualityComparer&lt;T1, T2&gt;
TupleEqualityComparer.


```csharp
public class TupleEqualityComparer&lt;T1, T2&gt; : EqualityComparer&lt;Tuple&lt;T1, T2&gt;&gt;, IEqualityComparer, IEqualityComparer&lt;Tuple&lt;T1, T2&gt;&gt;
```

### Methods


#### Equals

```csharp
bool Equals(Tuple<T1, T2> x, Tuple<T1, T2> y)
```
<p><b>Summary:</b> When overridden in a derived class, determines whether two objects of type are equal.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`x`&nbsp;&nbsp;-&nbsp;&nbsp;The first object to compare.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`y`&nbsp;&nbsp;-&nbsp;&nbsp;The second object to compare.<br />
<p><b>Returns:</b> true if the specified objects are equal; otherwise, false.</p>

#### GetHashCode

```csharp
int GetHashCode(Tuple<T1, T2> obj)
```
<p><b>Summary:</b> Returns a hash code for this instance.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`obj`&nbsp;&nbsp;-&nbsp;&nbsp;The object.<br />
<p><b>Returns:</b> A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</p>


<br />


## UpDownType
Enumeration: UpDownType.


```csharp
public enum UpDownType
```


| Value | Name | Description | Summary | 
| --- | --- | --- | --- | 
| 0 | None | None | Default None. | 
| 1 | Up | Up | Up. | 
| 2 | Down | Down | Down. | 



<br />


## YesNoType
Enumeration: YesNoType.


```csharp
public enum YesNoType
```


| Value | Name | Description | Summary | 
| --- | --- | --- | --- | 
| 0 | None | None | Default None. | 
| 1 | No | No | No. | 
| 2 | Yes | Yes | Yes. | 


<hr /><div style='text-align: right'><i>Generated by MarkdownCodeDoc version 1.2</i></div>
