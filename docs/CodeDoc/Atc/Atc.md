<div style='text-align: right'>

[References](Index.md)&nbsp;&nbsp;-&nbsp;&nbsp;[References extended](IndexExtended.md)
</div>

# Atc

<br />

## AddressType
Flag-Enumeration: AddressType.

>```csharp
>public enum AddressType
>```


| Value | Name | Description | Summary | 
| --- | --- | --- | --- | 
| 0 | None | None | Default None. | 
| 1 | Address | Address | The address indicates that the returned result is a precise geocode for which we have location information accurate down to street address precision. - With floor and door, if specified. | 
| 2 | AccessAddress | Access Address | The access address indicates that the returned result is a precise geocode for which we have location information accurate down to street address precision. - No floor and door. | 
| 3 | AllRegularly | All Regularly | All regularly | 
| 4 | PreliminaryAddress | Preliminary Address | The preliminary address - same as AccessAddress, but preliminary. | 
| 8 | PreliminaryAccessAddress | Preliminary Access Address | The preliminary access address - same as Address, but preliminary. | 
| 12 | AllPreliminary | All Preliminary | All preliminary | 
| 15 | All | All | All | 
| 16 | RangeInterpolated | Range Interpolated | The range interpolated indicates that the returned result reflects an approximation (usually on a road) interpolated between two precise points (such as intersections). Interpolated results are generally returned when rooftop geocodes are unavailable for a street address. | 
| 32 | GeometricCenter | Geometric Center | The geometric center indicates that the returned result is the geometric center of a result such as a polyline (for example, a street) or polygon (region). | 
| 64 | Approximate | Approximate | The approximate indicates that the returned result is approximate. | 
| 128 | Partial | Partial | The partial indicates that this not an full-validated-address, but a more approximate address - based on country and city. | 



<br />

## ArticleNumberType
ArticleNumberType.

>```csharp
>public enum ArticleNumberType
>```


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

>```csharp
>public static class AtcAssemblyTypeInitializer
>```


<br />

## BooleanOperatorType
Enumeration: BooleanOperatorType.

>```csharp
>public enum BooleanOperatorType
>```


| Value | Name | Description | Summary | 
| --- | --- | --- | --- | 
| 0 | None | None | Default None, and it's not a BooleanOperator. | 
| 1 | AND | And | AND. | 
| 2 | OR | Or | OR. | 
| 3 | NOT | Not | NOT. | 
| 4 | NEAR | Near | NEAR. | 



<br />

## ByteArrayEqualityComparer
ByteArrayEqualityComparer.

>```csharp
>public class ByteArrayEqualityComparer : IEqualityComparer<byte[]>
>```

### Methods

#### Equals
>```csharp
>bool Equals(byte[] x, byte[] y)
>```
#### GetHashCode
>```csharp
>int GetHashCode(byte[] obj)
>```

<br />

## CardinalDirectionType
Flag-Enumeration: CardinalDirectionType.

>```csharp
>public enum CardinalDirectionType
>```


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

>```csharp
>public enum CasingStyle
>```


| Value | Name | Description | Summary | 
| --- | --- | --- | --- | 
| 0 | None | None | Default None. | 
| 1 | CamelCase | Camel Case | The camel case is formatted like this: "camelCase". | 
| 2 | KebabCase | Kebab Case | The kebab case is formatted like this: "kebab-case". | 
| 3 | PascalCase | Pascal Case | The pascal case is formatted like this: "PascalCase". | 
| 4 | SnakeCase | Snake Case | The snake case is formatted like this: "snake_case". | 



<br />

## CasingStyleDescriptionAttribute
CasingStyle Description Attribute.

>```csharp
>public class CasingStyleDescriptionAttribute : DescriptionAttribute
>```

### Properties

#### Default
>```csharp
>Default
>```
><b>Summary:</b> Gets or sets the default.
#### Description
>```csharp
>Description
>```
><b>Summary:</b> Gets the description stored in this attribute.
>
><b>Returns:</b> The description stored in this attribute.
#### Prefix
>```csharp
>Prefix
>```
><b>Summary:</b> Gets or sets the prefix.

<br />

## CollectionActionType
Enumeration: CollectionActionType.

>```csharp
>public enum CollectionActionType
>```


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

## ConsoleExitStatusCodes

>```csharp
>public static class ConsoleExitStatusCodes
>```

### Static Fields

#### Failure
>```csharp
>int Failure
>```
#### Success
>```csharp
>int Success
>```

<br />

## DateTimeDiffCompareType
Enumeration: DateTimeDiffCompareType.

>```csharp
>public enum DateTimeDiffCompareType
>```


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

>```csharp
>public enum DropDownFirstItemType
>```


| Value | Name | Description | Summary | 
| --- | --- | --- | --- | 
| -4 | IncludeAll | -- All -- | IncludeAll. | 
| -3 | PleaseSelect | -- Select -- | PleaseSelect. | 
| -2 | Blank | Blank | Blank. | 
| -1 | None | None | Default None. | 



<br />

## Enum&lt;T&gt;
Extension methods for enums.

>```csharp
>public static class Enum&lt;T&gt;
>```

### Static Methods

#### GetEnumValue
>```csharp
>T GetEnumValue(string value, bool ignoreCase = True)
>```
><b>Summary:</b> Converts the string representation of the name or numeric value of one or more enumerated constants to an equivalent enumerated object.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;A string containing the name or value to convert.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`ignoreCase`&nbsp;&nbsp;-&nbsp;&nbsp;true to ignore case; false to regard case.<br />
>
><b>Returns:</b> If parsed successfully and defined as a valid enum value, the enum value is returned. Otherwise the default value is returned.
>
><b>Code usage:</b>
>```csharp
>DayOfWeek day = Enum<DayOfWeek>.GetEnumValue(value);
>```
>
><b>Code example:</b>
>```csharp
>Assert.Equal(DayOfWeek.Monday, Enum<DayOfWeek>.GetEnumValue("Monday"));
>Assert.Equal(DayOfWeek.Monday, Enum<DayOfWeek>.GetEnumValue("MONDAY"));
>```
#### HasFlag
>```csharp
>bool HasFlag(T value, T hasValue)
>```
><b>Summary:</b> Determines whether the specified value has flag.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`hasValue`&nbsp;&nbsp;-&nbsp;&nbsp;The has value.<br />
>
><b>Returns:</b> `true` if the specified value has flag; otherwise, `false`.
#### Parse
>```csharp
>T Parse(string value, bool ignoreCase = True)
>```
><b>Summary:</b> Converts the string representation of the name or numeric value of one or more enumerated constants to an equivalent enumerated object.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;A string containing the name or value to convert.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`ignoreCase`&nbsp;&nbsp;-&nbsp;&nbsp;true to ignore case; false to regard case.<br />
>
><b>Returns:</b> An object of type enumType whose value is represented by value.
>
><b>Code usage:</b>
>```csharp
>DayOfWeek day = Enum<DayOfWeek>.Parse(value);
>```
>
><b>Code example:</b>
>```csharp
>Assert.Equal(DayOfWeek.Monday, Enum<DayOfWeek>.Parse("Monday"));
>```
#### ToArray
>```csharp
>Array ToArray(DropDownFirstItemType dropDownFirstItemType = None, bool useDescriptionAttribute = True, bool includeDefault = True, SortDirectionType sortDirectionType = None, bool byFlagIncludeBase = True, bool byFlagIncludeCombined = True)
>```
><b>Summary:</b> Converts the enum to array.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`dropDownFirstItemType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the drop down first item.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`useDescriptionAttribute`&nbsp;&nbsp;-&nbsp;&nbsp;true to use the display/description/localizeddescription attribute value if exist, default value is name; false to just use the name value.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`includeDefault`&nbsp;&nbsp;-&nbsp;&nbsp;true to include the default enumeration value; false to skip it.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`sortDirectionType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the sort direction.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`byFlagIncludeBase`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [by flag include base].<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`byFlagIncludeCombined`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [by flag include combined].<br />
>
><b>Returns:</b> An array of names from the enum.
>
><b>Code usage:</b>
>```csharp
>Array array = Enum<DayOfWeek>.ToArray();
>```
>
><b>Code example:</b>
>```csharp
>Array array = Enum<DayOfWeek>.ToArray();
>Assert.Equal(7, array.Length);
>```
#### ToDictionary
>```csharp
>Dictionary<int, string> ToDictionary(DropDownFirstItemType dropDownFirstItemType = None, bool useDescriptionAttribute = True, bool includeDefault = True, SortDirectionType sortDirectionType = None, bool byFlagIncludeBase = True, bool byFlagIncludeCombined = True)
>```
><b>Summary:</b> Converts the enum to dictionary.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`dropDownFirstItemType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the drop down first item.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`useDescriptionAttribute`&nbsp;&nbsp;-&nbsp;&nbsp;true to use the display/description/localizeddescription attribute value if exist, default value is name; false to just use the name value.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`includeDefault`&nbsp;&nbsp;-&nbsp;&nbsp;true to include the default enumeration value; false to skip it.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`sortDirectionType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the sort direction.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`byFlagIncludeBase`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [by flag include base].<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`byFlagIncludeCombined`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [by flag include combined].<br />
>
><b>Returns:</b> An dictionary of enum values as int and names from the enum.
>
><b>Code usage:</b>
>```csharp
>Dictionary<int, string> dictionary = Enum<DayOfWeek>.ToDictionary();
>```
>
><b>Code example:</b>
>```csharp
>Dictionary<int, string> dictionary = Enum<DayOfWeek>.ToDictionary();
>Assert.Equal(7, dictionary.Count);
>```
#### ToDictionaryWithStringKey
>```csharp
>Dictionary<string, string> ToDictionaryWithStringKey(DropDownFirstItemType dropDownFirstItemType = None, bool useDescriptionAttribute = True, bool includeDefault = True, SortDirectionType sortDirectionType = None, bool byFlagIncludeBase = True, bool byFlagIncludeCombined = True)
>```
><b>Summary:</b> Converts the enum to dictionary with key as string.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`dropDownFirstItemType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the drop down first item.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`useDescriptionAttribute`&nbsp;&nbsp;-&nbsp;&nbsp;true to use the display/description/localizeddescription attribute value if exist, default value is name; false to just use the name value.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`includeDefault`&nbsp;&nbsp;-&nbsp;&nbsp;true to include the default enumeration value; false to skip it.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`sortDirectionType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the sort direction.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`byFlagIncludeBase`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [by flag include base].<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`byFlagIncludeCombined`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [by flag include combined].<br />
>
><b>Returns:</b> An dictionary of enum values as string and names from the enum.
>
><b>Code usage:</b>
>```csharp
>Dictionary<string, string> dictionary = Enum<DayOfWeek>.ToDictionaryWithStringKey();
>```
>
><b>Code example:</b>
>```csharp
>Dictionary<string, string> dictionary = Enum<DayOfWeek>.ToDictionaryWithStringKey();
>Assert.Equal(7, dictionary.Count);
>```
#### ToKeyValuePairs
>```csharp
>List<KeyValuePair<int, string>> ToKeyValuePairs(DropDownFirstItemType dropDownFirstItemType = None, bool useDescriptionAttribute = True, bool includeDefault = True, SortDirectionType sortDirectionType = None, bool byFlagIncludeBase = True, bool byFlagIncludeCombined = True)
>```
><b>Summary:</b> Converts the enum to list of key value pairs.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`dropDownFirstItemType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the drop down first item.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`useDescriptionAttribute`&nbsp;&nbsp;-&nbsp;&nbsp;true to use the display/description/localizeddescription attribute value if exist, default value is name; false to just use the name value.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`includeDefault`&nbsp;&nbsp;-&nbsp;&nbsp;true to include the default enumeration value; false to skip it.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`sortDirectionType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the sort direction.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`byFlagIncludeBase`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [by flag include base].<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`byFlagIncludeCombined`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [by flag include combined].<br />
>
><b>Returns:</b> An list of KeyValuePair of the enum with the key as int.
>
><b>Code usage:</b>
>```csharp
>List<KeyValuePair<int, string>> list = Enum<DayOfWeek>.ToKeyValuePairs();
>```
>
><b>Code example:</b>
>```csharp
>List<KeyValuePair<int, string>> list = Enum<DayOfWeek>.ToKeyValuePairs();
>Assert.Equal(7, list.Count);
>```
#### ToKeyValuePairsWithStringKey
>```csharp
>List<KeyValuePair<string, string>> ToKeyValuePairsWithStringKey(DropDownFirstItemType dropDownFirstItemType = None, bool useDescriptionAttribute = True, bool includeDefault = True, SortDirectionType sortDirectionType = None, bool byFlagIncludeBase = True, bool byFlagIncludeCombined = True)
>```
><b>Summary:</b> Converts the enum to list of key value pairs with key as string.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`dropDownFirstItemType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the drop down first item.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`useDescriptionAttribute`&nbsp;&nbsp;-&nbsp;&nbsp;true to use the display/description/localizeddescription attribute value if exist, default value is name; false to just use the name value.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`includeDefault`&nbsp;&nbsp;-&nbsp;&nbsp;true to include the default enumeration value; false to skip it.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`sortDirectionType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the sort direction.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`byFlagIncludeBase`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [by flag include base].<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`byFlagIncludeCombined`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [by flag include combined].<br />
>
><b>Returns:</b> An list of KeyValuePair of the enum with the key as string.
>
><b>Code usage:</b>
>```csharp
>List<KeyValuePair<string, string>> list = Enum<DayOfWeek>.ToKeyValuePairsWithStringKey();
>```
>
><b>Code example:</b>
>```csharp
>List<KeyValuePair<int, string>> list = Enum<DayOfWeek>.ToKeyValuePairsWithStringKey();
>Assert.Equal(7, list.Count);
>```
#### TryGetEnumValue
>```csharp
>bool TryGetEnumValue(string value, bool ignoreCase, out T returnedValue)
>```
><b>Summary:</b> Converts the string representation of the name or numeric value of one or more enumerated constants to an equivalent enumerated object.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;A string containing the name or value to convert.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`ignoreCase`&nbsp;&nbsp;-&nbsp;&nbsp;true to ignore case; false to regard case.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`returnedValue`&nbsp;&nbsp;-&nbsp;&nbsp;When this method returns, contains the enum value, if the conversion succeeded, or default enum if the conversion failed.<br />
>
><b>Returns:</b> If parsed successfully and defined as a valid enum value, the enum value is returned. Otherwise the default value is returned.
>
><b>Code usage:</b>
>```csharp
>bool isParsed = Enum<DayOfWeek>.TryGetEnumValue(value, ignoreCase, out var dayOfWeek);
>```
>
><b>Code example:</b>
>```csharp
>DayOfWeek expectedOut;
>bool isParsed = Enum<DayOfWeek>.TryGetEnumValue("Monday", true, out var dayOfWeek);
>Assert.True(isParsed);
>Assert.Equal(expectedOut, dayOfWeek);
>```
#### TryGetEnumValue
>```csharp
>bool TryGetEnumValue(Enum value, out T returnedValue)
>```
><b>Summary:</b> Converts the string representation of the name or numeric value of one or more enumerated constants to an equivalent enumerated object.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;A string containing the name or value to convert.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`ignoreCase`&nbsp;&nbsp;-&nbsp;&nbsp;true to ignore case; false to regard case.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`returnedValue`&nbsp;&nbsp;-&nbsp;&nbsp;When this method returns, contains the enum value, if the conversion succeeded, or default enum if the conversion failed.<br />
>
><b>Returns:</b> If parsed successfully and defined as a valid enum value, the enum value is returned. Otherwise the default value is returned.
>
><b>Code usage:</b>
>```csharp
>bool isParsed = Enum<DayOfWeek>.TryGetEnumValue(value, ignoreCase, out var dayOfWeek);
>```
>
><b>Code example:</b>
>```csharp
>DayOfWeek expectedOut;
>bool isParsed = Enum<DayOfWeek>.TryGetEnumValue("Monday", true, out var dayOfWeek);
>Assert.True(isParsed);
>Assert.Equal(expectedOut, dayOfWeek);
>```
#### TryParse
>```csharp
>bool TryParse(string value, out T returnedValue)
>```
><b>Summary:</b> Converts the string representation of a enum. A return value indicates whether the conversion succeeded.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;A string containing a enum to convert.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`returnedValue`&nbsp;&nbsp;-&nbsp;&nbsp;When this method returns, contains the enum value, if the conversion succeeded, or default enum if the conversion failed.<br />
>
><b>Returns:</b> true if the value was converted successfully; otherwise, false.
>
><b>Code usage:</b>
>```csharp
>bool isParsed = Enum<DayOfWeek>.TryParse(value, out var dayOfWeek);
>```
>
><b>Code example:</b>
>```csharp
>DayOfWeek expectedOut;
>bool isParsed = Enum<DayOfWeek>.TryParse("Monday", out var dayOfWeek);
>Assert.True(isParsed);
>Assert.Equal(expectedOut, dayOfWeek);
>```
#### TryParse
>```csharp
>bool TryParse(string value, bool ignoreCase, out T returnedValue)
>```
><b>Summary:</b> Converts the string representation of a enum. A return value indicates whether the conversion succeeded.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;A string containing a enum to convert.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`returnedValue`&nbsp;&nbsp;-&nbsp;&nbsp;When this method returns, contains the enum value, if the conversion succeeded, or default enum if the conversion failed.<br />
>
><b>Returns:</b> true if the value was converted successfully; otherwise, false.
>
><b>Code usage:</b>
>```csharp
>bool isParsed = Enum<DayOfWeek>.TryParse(value, out var dayOfWeek);
>```
>
><b>Code example:</b>
>```csharp
>DayOfWeek expectedOut;
>bool isParsed = Enum<DayOfWeek>.TryParse("Monday", out var dayOfWeek);
>Assert.True(isParsed);
>Assert.Equal(expectedOut, dayOfWeek);
>```

<br />

## EnumGuidAttribute
Enum Guid Attribute.

>```csharp
>public class EnumGuidAttribute : Attribute
>```

### Properties

#### GlobalIdentifier
>```csharp
>GlobalIdentifier
>```
><b>Summary:</b> Gets the global identifier.

<br />

## FileSystemWatcherChangeType
Flag-Enumeration: FileSystemWatcherChangeType.

>```csharp
>public enum FileSystemWatcherChangeType
>```


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

>```csharp
>public enum ForwardReverseType
>```


| Value | Name | Description | Summary | 
| --- | --- | --- | --- | 
| 0 | None | None | Default None. | 
| 1 | Forward | Forward | Forward. | 
| 2 | Reverse | Reverse | Reverse. | 



<br />

## GlobalizationConstants
GlobalizationConstants.

>```csharp
>public static class GlobalizationConstants
>```

### Static Fields

#### DanishCultureInfo
>```csharp
>CultureInfo DanishCultureInfo
>```
#### DateTimeIso8601
>```csharp
>string DateTimeIso8601
>```
#### EnglishCultureInfo
>```csharp
>CultureInfo EnglishCultureInfo
>```

<br />

## GlobalizationLcidConstants
GlobalizationLcidConstants.

>```csharp
>public static class GlobalizationLcidConstants
>```

### Static Fields

#### Denmark
>```csharp
>int Denmark
>```
><b>Summary:</b> Denmark - 1030.
#### Germany
>```csharp
>int Germany
>```
><b>Summary:</b> Germany - 1031.
#### GreatBritain
>```csharp
>int GreatBritain
>```
><b>Summary:</b> Great Britain - 2057.
#### Invariant
>```csharp
>int Invariant
>```
><b>Summary:</b> The invariant.
#### UnitedStates
>```csharp
>int UnitedStates
>```
><b>Summary:</b> United States - 1033.

<br />

## GridCell
Represents an x- and y-coordinate point in 2-D grid.

>```csharp
>public struct GridCell : IEquatable<GridCell>
>```

### Properties

#### IsDefault
>```csharp
>IsDefault
>```
><b>Summary:</b> Gets a value indicating whether this instance is default.
>
><b>Returns:</b> `true` if this instance is default; otherwise, `false`.
#### X
>```csharp
>X
>```
#### Y
>```csharp
>Y
>```
### Methods

#### Deconstruct
>```csharp
>void Deconstruct(out int X, out int Y)
>```
#### Equals
>```csharp
>bool Equals(object obj)
>```
#### Equals
>```csharp
>bool Equals(GridCell other)
>```
#### GetHashCode
>```csharp
>int GetHashCode()
>```
#### ToString
>```csharp
>string ToString()
>```
#### ToStringShort
>```csharp
>string ToStringShort()
>```
><b>Summary:</b> To the string short.
>
><b>Returns:</b> Return a short format of x and y.

<br />

## IdentityRoleType
Flag-Enumeration: IdentityRoleType.

>```csharp
>public enum IdentityRoleType
>```


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

>```csharp
>public class IgnoreDisplayAttribute : Attribute
>```


<br />

## InsertRemoveType
Enumeration: InsertRemoveType.

>```csharp
>public enum InsertRemoveType
>```


| Value | Name | Description | Summary | 
| --- | --- | --- | --- | 
| 0 | None | None | Default None. | 
| 1 | Insert | Insert | Insert. | 
| 2 | Remove | Remove | Remove. | 



<br />

## LeftRightType
Enumeration: LeftRightType.

>```csharp
>public enum LeftRightType
>```


| Value | Name | Description | Summary | 
| --- | --- | --- | --- | 
| 0 | None | None | Default None | 
| 1 | Left | Left | Left | 
| 2 | Right | Right | Right | 



<br />

## LetterAccentType
Flag-Enumeration: LetterAccentType.

>```csharp
>public enum LetterAccentType
>```


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

>```csharp
>public class LocalizedDescriptionAttribute : DescriptionAttribute
>```

### Properties

#### Description
>```csharp
>Description
>```
><b>Summary:</b> Gets the description stored in this attribute.
>
><b>Returns:</b> The description stored in this attribute.

<br />

## LogCategoryType
Enumeration: LogCategoryType categories available for logging.

>```csharp
>public enum LogCategoryType
>```


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

## LoggerExtensions

>```csharp
>public static class LoggerExtensions
>```

### Static Methods

#### LogKeyValueItem
>```csharp
>void LogKeyValueItem(this ILogger logger, LogKeyValueItem logKeyValueItem, bool includeKey = True, bool includeDescription = True)
>```
><b>Summary:</b> Logs the key value item.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`logger`&nbsp;&nbsp;-&nbsp;&nbsp;The logger.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`logKeyValueItem`&nbsp;&nbsp;-&nbsp;&nbsp;The log key value item.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`includeKey`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [include key].<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`includeDescription`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [include description].<br />
#### LogKeyValueItems
>```csharp
>void LogKeyValueItems(this ILogger logger, List<LogKeyValueItem> logKeyValueItems, bool includeKey = True, bool includeDescription = True)
>```
><b>Summary:</b> Logs the key value items.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`logger`&nbsp;&nbsp;-&nbsp;&nbsp;The logger.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`logKeyValueItems`&nbsp;&nbsp;-&nbsp;&nbsp;The log key value items.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`includeKey`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [include key].<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`includeDescription`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [include description].<br />

<br />

## NumericAlphaComparer
NumericAlphaComparer.

>```csharp
>public class NumericAlphaComparer : IComparer<string>
>```

### Methods

#### Compare
>```csharp
>int Compare(string x, string y)
>```

<br />

## OnOffType
Enumeration: OnOffType.

>```csharp
>public enum OnOffType
>```


| Value | Name | Description | Summary | 
| --- | --- | --- | --- | 
| 0 | None | None | Default None. | 
| 1 | Off | Off | Off. | 
| 2 | On | On | ON. | 



<br />

## Point2D
Represents an x- and y-coordinate point in 2-D space.

>```csharp
>public struct Point2D : IEquatable<Point2D>
>```

### Properties

#### IsDefault
>```csharp
>IsDefault
>```
><b>Summary:</b> Gets a value indicating whether this instance is default.
#### X
>```csharp
>X
>```
#### Y
>```csharp
>Y
>```
### Methods

#### Deconstruct
>```csharp
>void Deconstruct(out double X, out double Y)
>```
#### Equals
>```csharp
>bool Equals(object obj)
>```
#### Equals
>```csharp
>bool Equals(Point2D other)
>```
#### GetHashCode
>```csharp
>int GetHashCode()
>```
#### ToString
>```csharp
>string ToString()
>```
#### ToStringShort
>```csharp
>string ToStringShort()
>```
><b>Summary:</b> To the string short.
>
><b>Returns:</b> Return a short format of x and y.

<br />

## Point3D
Represents an x-, y-, and z-coordinate point in 3-D space.

>```csharp
>public struct Point3D : IEquatable<Point3D>
>```

### Properties

#### IsDefault
>```csharp
>IsDefault
>```
><b>Summary:</b> Gets a value indicating whether this instance is default.
#### X
>```csharp
>X
>```
#### Y
>```csharp
>Y
>```
#### Z
>```csharp
>Z
>```
### Methods

#### Deconstruct
>```csharp
>void Deconstruct(out double X, out double Y, out double Z)
>```
#### Equals
>```csharp
>bool Equals(object obj)
>```
#### Equals
>```csharp
>bool Equals(Point3D other)
>```
#### GetHashCode
>```csharp
>int GetHashCode()
>```
#### ToString
>```csharp
>string ToString()
>```
#### ToStringShort
>```csharp
>string ToStringShort()
>```
><b>Summary:</b> To the string short.
>
><b>Returns:</b> Return a short format of x, y, and z.

<br />

## SortDirectionType
Enumeration: SortDirectionType.

>```csharp
>public enum SortDirectionType
>```


| Value | Name | Description | Summary | 
| --- | --- | --- | --- | 
| 0 | None | None | Default None. | 
| 1 | Ascending | Ascending | Ascending. | 
| 2 | Descending | Descending | Descending. | 



<br />

## TriggerActionType
Enumeration: TriggerActionType.

>```csharp
>public enum TriggerActionType
>```


| Value | Name | Description | Summary | 
| --- | --- | --- | --- | 
| 0 | None | None | Default None. | 
| 1 | Insert | Insert | Insert. | 
| 2 | Update | Update | Update. | 
| 3 | Delete | Delete | Delete. | 



<br />

## TupleEqualityComparer&lt;T1, T2&gt;
TupleEqualityComparer.

>```csharp
>public class TupleEqualityComparer&lt;T1, T2&gt; : EqualityComparer<Tuple<T1, T2>>, IEqualityComparer, IEqualityComparer<Tuple<T1, T2>>
>```

### Methods

#### Equals
>```csharp
>bool Equals(Tuple<T1, T2> x, Tuple<T1, T2> y)
>```
><b>Summary:</b> When overridden in a derived class, determines whether two objects of type are equal.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`x`&nbsp;&nbsp;-&nbsp;&nbsp;The first object to compare.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`y`&nbsp;&nbsp;-&nbsp;&nbsp;The second object to compare.<br />
>
><b>Returns:</b> true if the specified objects are equal; otherwise, false.
#### GetHashCode
>```csharp
>int GetHashCode(Tuple<T1, T2> obj)
>```
><b>Summary:</b> Returns a hash code for this instance.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`obj`&nbsp;&nbsp;-&nbsp;&nbsp;The object.<br />
>
><b>Returns:</b> A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.

<br />

## UpDownType
Enumeration: UpDownType.

>```csharp
>public enum UpDownType
>```


| Value | Name | Description | Summary | 
| --- | --- | --- | --- | 
| 0 | None | None | Default None. | 
| 1 | Up | Up | Up. | 
| 2 | Down | Down | Down. | 



<br />

## YesNoType
Enumeration: YesNoType.

>```csharp
>public enum YesNoType
>```


| Value | Name | Description | Summary | 
| --- | --- | --- | --- | 
| 0 | None | None | Default None. | 
| 1 | No | No | No. | 
| 2 | Yes | Yes | Yes. | 


<hr /><div style='text-align: right'><i>Generated by MarkdownCodeDoc version 1.2</i></div>
