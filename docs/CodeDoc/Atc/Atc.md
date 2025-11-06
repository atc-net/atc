<div style='text-align: right'>

[References](Index.md)&nbsp;&nbsp;-&nbsp;&nbsp;[References extended](IndexExtended.md)
</div>

# Atc

<br />

## AddressType
Represents different types and precision levels of geocoded addresses. This is a flags enumeration that allows multiple address types to be combined.

>```csharp
>public enum AddressType
>```


| Value | Name | Description | Summary | 
| --- | --- | --- | --- | 
| 0 | None | None | No address type specified. | 
| 1 | Address | Address | The address indicates that the returned result is a precise geocode for which we have location information accurate down to street address precision. - With floor and door, if specified. | 
| 2 | AccessAddress | Access Address | The access address indicates that the returned result is a precise geocode for which we have location information accurate down to street address precision. - No floor and door. | 
| 3 | AllRegularly | All Regularly | Combines all regularly validated address types (Address and AccessAddress). | 
| 4 | PreliminaryAddress | Preliminary Address | The preliminary address - same as AccessAddress, but preliminary. | 
| 8 | PreliminaryAccessAddress | Preliminary Access Address | The preliminary access address - same as Address, but preliminary. | 
| 12 | AllPreliminary | All Preliminary | Combines all preliminary address types (PreliminaryAddress and PreliminaryAccessAddress). | 
| 15 | All | All | All address types combined (both regular and preliminary addresses). | 
| 16 | RangeInterpolated | Range Interpolated | The range interpolated indicates that the returned result reflects an approximation (usually on a road) interpolated between two precise points (such as intersections). Interpolated results are generally returned when rooftop geocodes are unavailable for a street address. | 
| 32 | GeometricCenter | Geometric Center | The geometric center indicates that the returned result is the geometric center of a result such as a polyline (for example, a street) or polygon (region). | 
| 64 | Approximate | Approximate | The approximate indicates that the returned result is approximate. | 
| 128 | Partial | Partial | The partial indicates that this not an full-validated-address, but a more approximate address - based on country and city. | 



<br />

## ArrowDirectionType
Represents directional arrows that can be combined using bitwise operations. This is a flags enumeration that allows multiple directions to be combined.

>```csharp
>public enum ArrowDirectionType
>```


| Value | Name | Description | Summary | 
| --- | --- | --- | --- | 
| 0 | None | None | No direction specified. | 
| 1 | Left | Left | Arrow pointing to the left. | 
| 2 | Up | Up | Arrow pointing upward. | 
| 4 | Right | Right | Arrow pointing to the right. | 
| 8 | Down | Down | Arrow pointing downward. | 



<br />

## ArticleNumberType
Represents different types of product identification numbers and barcodes used in commerce.

>```csharp
>public enum ArticleNumberType
>```


| Value | Name | Description | Summary | 
| --- | --- | --- | --- | 
| 0 | Unknown | Unknown | Unknown or unspecified article number type. | 
| 1 | ASIN | ASIN | Amazon Standard Identification Number - a 10-character alphanumeric unique identifier assigned by Amazon. | 
| 2 | EAN8 | EAN8 | European Article Number - 8-digit barcode standard for product identification. | 
| 3 | EAN13 | EAN13 | European Article Number - 13-digit barcode standard for product identification. | 
| 4 | GTIN | GTIN | Global Trade Item Number - international product identification standard (formerly EAN/UPC). | 
| 5 | ISBN10 | ISBN10 | International Standard Book Number - 10-digit unique identifier for books (legacy format). | 
| 6 | ISBN13 | ISBN13 | International Standard Book Number - 13-digit unique identifier for books (current format). | 
| 7 | SKU | SKU | Stock Keeping Unit - internal product identification number used for inventory management. | 
| 8 | UPC | UPC | Universal Product Code - 12-digit barcode standard primarily used in North America. | 
| 9 | ISSN | ISSN | International Standard Serial Number - 8-digit identifier for periodical publications. | 



<br />

## AtcAssemblyTypeInitializer

>```csharp
>public static class AtcAssemblyTypeInitializer
>```


<br />

## BooleanOperatorType
Represents boolean operators commonly used in search queries and logical expressions.

>```csharp
>public enum BooleanOperatorType
>```


| Value | Name | Description | Summary | 
| --- | --- | --- | --- | 
| 0 | None | None | No boolean operator specified. | 
| 1 | AND | And | Logical AND operator requiring all conditions to be true. | 
| 2 | OR | Or | Logical OR operator requiring at least one condition to be true. | 
| 3 | NOT | Not | Logical NOT operator for negating a condition. | 
| 4 | NEAR | Near | Proximity operator for searching terms near each other. | 



<br />

## ByteArrayEqualityComparer
Provides equality comparison for byte arrays based on their content. Two byte arrays are considered equal if they have the same length and all corresponding bytes are equal.

>```csharp
>public class ByteArrayEqualityComparer : IEqualityComparer<byte[]>
>```

### Methods

#### Equals
>```csharp
>bool Equals(byte[] x, byte[] y)
>```
><b>Summary:</b> Determines whether two byte arrays are equal by comparing their contents.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`x`&nbsp;&nbsp;-&nbsp;&nbsp;The first byte array to compare.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`y`&nbsp;&nbsp;-&nbsp;&nbsp;The second byte array to compare.<br />
>
><b>Returns:</b> `true` if the byte arrays have the same length and all corresponding bytes are equal; otherwise, `false`.
#### GetHashCode
>```csharp
>int GetHashCode(byte[] obj)
>```
><b>Summary:</b> Returns a hash code for the specified byte array based on its content.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`obj`&nbsp;&nbsp;-&nbsp;&nbsp;The byte array for which to generate a hash code.<br />
>
><b>Returns:</b> A hash code for the byte array, or 0 if the array is null.

<br />

## CardinalDirectionType
Represents compass directions including the four cardinal points and intermediate directions. This is a flags enumeration that allows multiple directions to be combined.

>```csharp
>public enum CardinalDirectionType
>```


| Value | Name | Description | Summary | 
| --- | --- | --- | --- | 
| 0 | None | None | No direction specified. | 
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
| 16384 | NorthWest | North West | NorthWest. | 
| 22101 | Medium | Medium | Medium = North | NorthEast | East | SouthEast | South | SouthWest | West | NorthWest. | 
| 32768 | NorthNorthWest | North North West | NorthNorthWest. | 
| 65535 | Advanced | Advanced | Advanced = North | NorthNorthEast | NorthEast | EastNorthEast | East | EastSouthEast | SouthEast | SouthSouthEast | South | SouthSouthWest | SouthWest | WestSouthWest | West | WestNorthWest | NorthWest | NorthNorthWest. | 



<br />

## CasingStyle
Defines different text casing styles commonly used in programming and naming conventions.

>```csharp
>public enum CasingStyle
>```


| Value | Name | Description | Summary | 
| --- | --- | --- | --- | 
| 0 | None | None | No specific casing style specified. | 
| 1 | CamelCase | Camel Case | The camel case is formatted like this: "camelCase". | 
| 2 | KebabCase | Kebab Case | The kebab case is formatted like this: "kebab-case". | 
| 3 | PascalCase | Pascal Case | The pascal case is formatted like this: "PascalCase". | 
| 4 | SnakeCase | Snake Case | The snake case is formatted like this: "snake_case". | 



<br />

## CasingStyleDescriptionAttribute
Provides a description attribute that generates documentation text listing valid `Atc.CasingStyle` values. This attribute is useful for documenting properties that accept casing style values, showing all valid options with the default highlighted.

>```csharp
>public class CasingStyleDescriptionAttribute : DescriptionAttribute
>```

### Properties

#### Default
>```csharp
>Default
>```
><b>Summary:</b> Gets or sets the default casing style to be indicated in the generated description. The default value is `Atc.CasingStyle.CamelCase`.
#### Description
>```csharp
>Description
>```
><b>Summary:</b> Gets the generated description listing all valid `Atc.CasingStyle` values (excluding None) with the default value marked. If a prefix is set, it will be prepended to the description.
#### Prefix
>```csharp
>Prefix
>```
><b>Summary:</b> Gets or sets an optional prefix to prepend to the generated description text.

<br />

## CloneStrategyType
Defines different strategies for cloning objects.

>```csharp
>public enum CloneStrategyType
>```


| Value | Name | Description | Summary | 
| --- | --- | --- | --- | 
| 0 | None | None | No cloning strategy specified. | 
| 1 | Json | Json | Uses JSON serialization and deserialization to create a deep copy of an object. | 



<br />

## CollectionActionType
Represents actions that can be performed on a collection of items.

>```csharp
>public enum CollectionActionType
>```


| Value | Name | Description | Summary | 
| --- | --- | --- | --- | 
| 0 | None | None | No action specified. | 
| 1 | Added | Added | An item was added to the collection. | 
| 2 | Updated | Updated | An item in the collection was updated. | 
| 3 | Removed | Removed | An item was removed from the collection. | 
| 4 | Cleared | Cleared | All items were removed from the collection. | 
| 5 | Saved | Saved | The collection was saved to persistent storage. | 
| 6 | Loaded | Loaded | The collection was loaded from persistent storage. | 



<br />

## ConsoleExitStatusCodes
Defines standard exit status codes for console applications.

>```csharp
>public static class ConsoleExitStatusCodes
>```

### Static Fields

#### Failure
>```csharp
>int Failure
>```
><b>Summary:</b> Exit code indicating program execution failed.
#### Success
>```csharp
>int Success
>```
><b>Summary:</b> Exit code indicating successful program execution.

<br />

## DateTimeDiffCompareType
Defines the unit of time used for comparing or calculating differences between DateTime values.

>```csharp
>public enum DateTimeDiffCompareType
>```


| Value | Name | Description | Summary | 
| --- | --- | --- | --- | 
| 0 | Ticks | Ticks | Compare using ticks (100 nanosecond intervals). | 
| 1 | Milliseconds | Milliseconds | Compare using milliseconds. | 
| 2 | Seconds | Seconds | Compare using seconds. | 
| 3 | Minutes | Minutes | Compare using minutes. | 
| 4 | Hours | Hours | Compare using hours. | 
| 5 | Days | Days | Compare using days. | 
| 6 | Year | Year | Compare using years. | 
| 7 | Quartal | Quartal | Compare using quarters (three-month periods). | 



<br />

## DropDownFirstItemType
Defines the type of placeholder item to display as the first option in a dropdown list.

>```csharp
>public enum DropDownFirstItemType
>```


| Value | Name | Description | Summary | 
| --- | --- | --- | --- | 
| -4 | IncludeAll | -- All -- | Display "Include All" as the first item to allow selecting all options. | 
| -3 | PleaseSelect | -- Select -- | Display "Please Select" as the first item prompting user to make a selection. | 
| -2 | Blank | Blank | Display a blank/empty first item in the dropdown. | 
| -1 | None | None | No first item placeholder specified. | 



<br />

## EnumGuidAttribute
Associates a globally unique identifier (GUID) with an enum value, property, field, interface, or delegate. This attribute is useful for assigning stable, unique identifiers to enum values that persist across code changes.

>```csharp
>public class EnumGuidAttribute : Attribute
>```

### Properties

#### GlobalIdentifier
>```csharp
>GlobalIdentifier
>```
><b>Summary:</b> Gets the globally unique identifier associated with this attribute.

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
><b>Returns:</b> <see langword="true" /> if the specified value has flag; otherwise, <see langword="false" />.
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
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`dropDownFirstItemType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the dropdown first item.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`useDescriptionAttribute`&nbsp;&nbsp;-&nbsp;&nbsp;true to use the display/description/localizeddescription attribute value if exist, default value is name; false to just use the name value.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`includeDefault`&nbsp;&nbsp;-&nbsp;&nbsp;true to include the default enumeration value; false to skip it.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`sortDirectionType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the sort direction.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`byFlagIncludeBase`&nbsp;&nbsp;-&nbsp;&nbsp;if set to  [by flag include base].<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`byFlagIncludeCombined`&nbsp;&nbsp;-&nbsp;&nbsp;if set to  [by flag include combined].<br />
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
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`dropDownFirstItemType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the dropdown first item.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`useDescriptionAttribute`&nbsp;&nbsp;-&nbsp;&nbsp;true to use the display/description/localizeddescription attribute value if exist, default value is name; false to just use the name value.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`includeDefault`&nbsp;&nbsp;-&nbsp;&nbsp;true to include the default enumeration value; false to skip it.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`sortDirectionType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the sort direction.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`byFlagIncludeBase`&nbsp;&nbsp;-&nbsp;&nbsp;if set to  [by flag include base].<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`byFlagIncludeCombined`&nbsp;&nbsp;-&nbsp;&nbsp;if set to  [by flag include combined].<br />
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
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`dropDownFirstItemType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the dropdown first item.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`useDescriptionAttribute`&nbsp;&nbsp;-&nbsp;&nbsp;true to use the display/description/localizeddescription attribute value if exist, default value is name; false to just use the name value.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`includeDefault`&nbsp;&nbsp;-&nbsp;&nbsp;true to include the default enumeration value; false to skip it.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`sortDirectionType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the sort direction.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`byFlagIncludeBase`&nbsp;&nbsp;-&nbsp;&nbsp;if set to  [by flag include base].<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`byFlagIncludeCombined`&nbsp;&nbsp;-&nbsp;&nbsp;if set to  [by flag include combined].<br />
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
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`dropDownFirstItemType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the dropdown first item.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`useDescriptionAttribute`&nbsp;&nbsp;-&nbsp;&nbsp;true to use the display/description/localizeddescription attribute value if exist, default value is name; false to just use the name value.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`includeDefault`&nbsp;&nbsp;-&nbsp;&nbsp;true to include the default enumeration value; false to skip it.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`sortDirectionType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the sort direction.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`byFlagIncludeBase`&nbsp;&nbsp;-&nbsp;&nbsp;if set to  [by flag include base].<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`byFlagIncludeCombined`&nbsp;&nbsp;-&nbsp;&nbsp;if set to  [by flag include combined].<br />
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
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`dropDownFirstItemType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the dropdown first item.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`useDescriptionAttribute`&nbsp;&nbsp;-&nbsp;&nbsp;true to use the display/description/localizeddescription attribute value if exist, default value is name; false to just use the name value.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`includeDefault`&nbsp;&nbsp;-&nbsp;&nbsp;true to include the default enumeration value; false to skip it.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`sortDirectionType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the sort direction.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`byFlagIncludeBase`&nbsp;&nbsp;-&nbsp;&nbsp;if set to  [by flag include base].<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`byFlagIncludeCombined`&nbsp;&nbsp;-&nbsp;&nbsp;if set to  [by flag include combined].<br />
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

## FileSystemWatcherChangeType
Represents the types of changes that can occur to files and directories in the file system. This is a flags enumeration that allows multiple change types to be combined.

>```csharp
>public enum FileSystemWatcherChangeType
>```


| Value | Name | Description | Summary | 
| --- | --- | --- | --- | 
| 0 | None | None | No change type specified. | 
| 1 | Added | Added | A file or directory was added to the file system. | 
| 2 | Deleted | Deleted | A file or directory was deleted from the file system. | 
| 4 | Renamed | Renamed | A file or directory was renamed in the file system. | 
| 8 | Changed | Changed | A file or directory's contents or attributes were changed. | 
| 15 | All | All | All change types combined (Added, Deleted, Renamed, and Changed). | 



<br />

## ForwardReverseType
Represents a direction of movement or traversal (forward or reverse/backward).

>```csharp
>public enum ForwardReverseType
>```


| Value | Name | Description | Summary | 
| --- | --- | --- | --- | 
| 0 | None | None | No direction specified. | 
| 1 | Forward | Forward | Forward direction or normal sequence. | 
| 2 | Reverse | Reverse | Reverse direction or backward sequence. | 



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
><b>Summary:</b> Gets a value indicating whether this instance represents the default (origin) position at coordinates (0, 0).
>
><b>Returns:</b> <see langword="true" /> if both X and Y are zero; otherwise, <see langword="false" />.
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
><b>Summary:</b> Returns a short string representation of the grid cell in the format "x, y".
>
><b>Returns:</b> A comma-separated string containing the X and Y coordinates.

<br />

## IdentityRoleType
Represents different user roles and privilege levels in an identity/authentication system. This is a flags enumeration that allows multiple roles to be combined.

>```csharp
>public enum IdentityRoleType
>```


| Value | Name | Description | Summary | 
| --- | --- | --- | --- | 
| 0 | None | None | No role specified. | 
| 1 | Anonymous | Anonymous | Anonymous user with no authenticated identity. | 
| 2 | User | User | Standard authenticated user with basic privileges. | 
| 4 | SuperUser | Super User | User with elevated privileges beyond a standard user. | 
| 8 | Admin | Administrator | Administrator with management and configuration privileges. | 
| 16 | SuperAdmin | Super Administrator | Super administrator with full system access and highest-level privileges. | 



<br />

## IgnoreDisplayAttribute
Specifies that the decorated member should be excluded from display operations. This attribute can be used to mark properties, fields, enums, interfaces, or delegates that should not be shown in user interfaces or documentation.

>```csharp
>public class IgnoreDisplayAttribute : Attribute
>```


<br />

## InsertRemoveType
Represents an operation to insert or remove an item.

>```csharp
>public enum InsertRemoveType
>```


| Value | Name | Description | Summary | 
| --- | --- | --- | --- | 
| 0 | None | None | No operation specified. | 
| 1 | Insert | Insert | Insert operation to add an item. | 
| 2 | Remove | Remove | Remove operation to delete an item. | 



<br />

## LeftRightType
Represents a horizontal direction or position (left or right).

>```csharp
>public enum LeftRightType
>```


| Value | Name | Description | Summary | 
| --- | --- | --- | --- | 
| 0 | None | None | No direction specified. | 
| 1 | Left | Left | Left direction or position. | 
| 2 | Right | Right | Right direction or position. | 



<br />

## LeftTopRightBottomType
Represents a position or alignment relative to a rectangle (left, top, right, or bottom).

>```csharp
>public enum LeftTopRightBottomType
>```


| Value | Name | Description | Summary | 
| --- | --- | --- | --- | 
| 0 | None | None | No position specified. | 
| 1 | Left | Left | Left side position. | 
| 2 | Top | Top | Top position. | 
| 3 | Right | Right | Right side position. | 
| 4 | Bottom | Bottom | Bottom position. | 



<br />

## LeftUpRightDownType
Represents a directional position in four cardinal directions (left, up, right, or down).

>```csharp
>public enum LeftUpRightDownType
>```


| Value | Name | Description | Summary | 
| --- | --- | --- | --- | 
| 0 | None | None | No direction specified. | 
| 1 | Left | Left | Left direction. | 
| 2 | Up | Up | Upward direction. | 
| 3 | Right | Right | Right direction. | 
| 4 | Down | Down | Downward direction. | 



<br />

## LetterAccentType
Represents different types of diacritical marks (accents) that can be applied to letters. This is a flags enumeration that allows multiple accent types to be combined.

>```csharp
>public enum LetterAccentType
>```


| Value | Name | Description | Summary | 
| --- | --- | --- | --- | 
| 0 | None | None | No accent type specified. | 
| 1 | Grave | Grave | Grave accent (e.g., à, è, ù). | 
| 2 | Acute | Acute | Acute accent (e.g., á, é, ú). | 
| 4 | Circumflex | Circumflex | Circumflex accent (e.g., â, ê, û). | 
| 8 | Tilde | Tilde | Tilde accent (e.g., ã, ñ, õ). | 
| 16 | Umlaut | Umlaut | Umlaut or diaeresis (e.g., ä, ë, ü). | 
| 31 | All | All | All accent types combined. | 



<br />

## LocalizedDescriptionAttribute
Provides a description attribute that retrieves localized text from resource files based on the current UI culture. This attribute extends `System.ComponentModel.DescriptionAttribute` to support internationalization.

>```csharp
>public class LocalizedDescriptionAttribute : DescriptionAttribute
>```

### Properties

#### Description
>```csharp
>Description
>```
><b>Summary:</b> Gets the localized description text based on the current UI culture. Returns an empty string if the resource key is null, empty, or the localized text cannot be found.

<br />

## LogCategoryType
Defines different categories of log messages for classification and filtering purposes.

>```csharp
>public enum LogCategoryType
>```


| Value | Name | Description | Summary | 
| --- | --- | --- | --- | 
| 0 | Critical | Critical | Critical issues that require immediate attention and may cause system failure. | 
| 1 | Error | Error | Error conditions that prevent normal operation but don't cause system failure. | 
| 2 | Warning | Warning | Warning messages about potentially problematic situations. | 
| 3 | Security | Security | Security-related events such as authentication or authorization issues. | 
| 4 | Audit | Audit | Audit trail entries for compliance and tracking purposes. | 
| 5 | Service | Service | Service-level events and operations. | 
| 6 | UI | UI | User interface related events and interactions. | 
| 7 | Information | Information | General informational messages about normal operations. | 
| 8 | Debug | Debug | Detailed debugging information for development purposes. | 
| 9 | Trace | Trace | Very detailed diagnostic information for tracing execution flow. | 



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
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`includeKey`&nbsp;&nbsp;-&nbsp;&nbsp;if set to  [include key].<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`includeDescription`&nbsp;&nbsp;-&nbsp;&nbsp;if set to  [include description].<br />
#### LogKeyValueItems
>```csharp
>void LogKeyValueItems(this ILogger logger, List<LogKeyValueItem> logKeyValueItems, bool includeKey = True, bool includeDescription = True)
>```
><b>Summary:</b> Logs the key value items.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`logger`&nbsp;&nbsp;-&nbsp;&nbsp;The logger.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`logKeyValueItems`&nbsp;&nbsp;-&nbsp;&nbsp;The log key value items.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`includeKey`&nbsp;&nbsp;-&nbsp;&nbsp;if set to  [include key].<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`includeDescription`&nbsp;&nbsp;-&nbsp;&nbsp;if set to  [include description].<br />

<br />

## NumericAlphaComparer
Provides natural sorting comparison for strings containing both numeric and alphabetic characters. Numbers are compared numerically rather than alphabetically (e.g., "file2" comes before "file10").

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
Represents a binary on/off state.

>```csharp
>public enum OnOffType
>```


| Value | Name | Description | Summary | 
| --- | --- | --- | --- | 
| 0 | None | None | No state specified. | 
| 1 | Off | Off | Off state (disabled or inactive). | 
| 2 | On | On | On state (enabled or active). | 



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
><b>Summary:</b> Gets a value indicating whether this instance represents the default (origin) position at coordinates (0, 0).
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
><b>Summary:</b> Returns a short string representation of the point in the format "x, y".
>
><b>Returns:</b> A comma-separated string containing the X and Y coordinates.

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
><b>Summary:</b> Gets a value indicating whether this instance represents the default (origin) position at coordinates (0, 0, 0).
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
><b>Summary:</b> Returns a short string representation of the point in the format "x, y, z".
>
><b>Returns:</b> A comma-separated string containing the X, Y, and Z coordinates.

<br />

## SortDirectionType
Defines the direction for sorting data (ascending or descending).

>```csharp
>public enum SortDirectionType
>```


| Value | Name | Description | Summary | 
| --- | --- | --- | --- | 
| 0 | None | None | No sort direction specified. | 
| 1 | Ascending | Ascending | Sort in ascending order (smallest to largest, A to Z). | 
| 2 | Descending | Descending | Sort in descending order (largest to smallest, Z to A). | 



<br />

## StringCaseFormatter
Provides custom string formatting based on specified case formatting options.<br /><br /> Supported formats: <list type="table"><item><term>U</term><description>Converts the entire string to uppercase.</description></item><item><term>u</term><description>Capitalizes the first character of the string.</description></item><item><term>L</term><description>Converts the entire string to lowercase.</description></item><item><term>l</term><description>Converts the first character of the string to lowercase.</description></item><item><term>Ul</term><description>Converts the string to uppercase with the first character in lowercase.</description></item><item><term>Lu</term><description>Converts the string to lowercase with the first character capitalized.</description></item><item><term>[Format]:</term><description>Applies the specified format and appends a colon ´<b>:</b>´ to the end.</description></item><item><term>[Format].</term><description>Applies the specified format and appends a period ´<b>.</b>´ to the end.</description></item></list> Examples: <code>string.Format(StringCaseFormatter.Default, "{0:U} {1:u} {2:L} {3:l}", .... 4 parameters );</code><code>string.Format(StringCaseFormatter.Default, "{0:U.} {1:u.} {2:L:} {3:l:}", .... 4 parameters );</code><code>string.Format(StringCaseFormatter.Default, "{0:Ul:} {1:Lu:}", ... 2 parameters );</code><code>string.Format(new StringCaseFormatter(), "{0:U} {1:u} {2:L} {3:l}", ... 4 parameters );</code>

>```csharp
>public class StringCaseFormatter : IFormatProvider, ICustomFormatter
>```

### Static Fields

#### Default
>```csharp
>StringCaseFormatter Default
>```
><b>Summary:</b> Static `Atc.StringCaseFormatter` using `System.Globalization.CultureInfo.CurrentCulture`.
### Static Methods

#### Format
>```csharp
>string Format(string format, object[] args)
>```
><b>Summary:</b> Converts the value of a specified object to an equivalent string representation using specified format and culture-specific formatting information.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`format`&nbsp;&nbsp;-&nbsp;&nbsp;A format string containing formatting specifications.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`arg`&nbsp;&nbsp;-&nbsp;&nbsp;The object to format.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`formatProvider`&nbsp;&nbsp;-&nbsp;&nbsp;An object that supplies format information about the current instance.
            This parameter is ignored in this implementation.<br />
>
><b>Returns:</b> The string representation of the value of `arg`, formatted as specified by `format` and `formatProvider`.
### Methods

#### Format
>```csharp
>string Format(string format, object arg, IFormatProvider formatProvider)
>```
><b>Summary:</b> Converts the value of a specified object to an equivalent string representation using specified format and culture-specific formatting information.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`format`&nbsp;&nbsp;-&nbsp;&nbsp;A format string containing formatting specifications.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`arg`&nbsp;&nbsp;-&nbsp;&nbsp;The object to format.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`formatProvider`&nbsp;&nbsp;-&nbsp;&nbsp;An object that supplies format information about the current instance.
            This parameter is ignored in this implementation.<br />
>
><b>Returns:</b> The string representation of the value of `arg`, formatted as specified by `format` and `formatProvider`.
#### GetFormat
>```csharp
>object GetFormat(Type formatType)
>```
><b>Summary:</b> Returns an object that provides formatting services for the specified type.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`formatType`&nbsp;&nbsp;-&nbsp;&nbsp;An object that specifies the type of format object to return.<br />
>
><b>Returns:</b> An instance of the object specified by `formatType`, if the `System.ICustomFormatter` interface is requested; otherwise, null.

<br />

## TemplatePatternType
Defines template placeholder patterns that can be used for string replacement and templating. This is a flags enumeration that allows multiple pattern types to be combined.

>```csharp
>public enum TemplatePatternType
>```


| Value | Name | Description | Summary | 
| --- | --- | --- | --- | 
| 0 | None | None | No template pattern specified. | 
| 1 | SingleHardBrackets | Single Hard Brackets | The single hard brackets pattern: [ * ] | 
| 2 | DoubleHardBrackets | Double Hard Brackets | The double hard brackets pattern: [[ * ]] | 
| 3 | HardBrackets | Hard Brackets | Combines both single and double hard bracket patterns: [ * ] or [[ * ]] | 
| 4 | SingleCurlyBraces | Single Curly Braces | The single curly braces: { * } | 
| 8 | DoubleCurlyBraces | Double Curly Braces | The double curly braces pattern: {{ * }} | 
| 12 | CurlyBraces | Curly Braces | Combines both single and double curly brace patterns: { * } or {{ * }} | 
| 15 | All | All | All template patterns combined. | 



<br />

## TriggerActionType
Represents database trigger actions (insert, update, delete).

>```csharp
>public enum TriggerActionType
>```


| Value | Name | Description | Summary | 
| --- | --- | --- | --- | 
| 0 | None | None | No trigger action specified. | 
| 1 | Insert | Insert | Insert action when a new record is added. | 
| 2 | Update | Update | Update action when an existing record is modified. | 
| 3 | Delete | Delete | Delete action when a record is removed. | 



<br />

## TupleEqualityComparer&lt;T1, T2&gt;
Provides equality comparison for tuples by comparing both items. Two tuples are considered equal if both Item1 and Item2 are equal.

>```csharp
>public class TupleEqualityComparer&lt;T1, T2&gt; : EqualityComparer<Tuple<T1, T2>>, IEqualityComparer, IEqualityComparer<Tuple<T1, T2>>
>```

### Methods

#### Equals
>```csharp
>bool Equals(Tuple<T1, T2> x, Tuple<T1, T2> y)
>```
><b>Summary:</b> Determines whether two tuples are equal by comparing both items.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`x`&nbsp;&nbsp;-&nbsp;&nbsp;The first tuple to compare.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`y`&nbsp;&nbsp;-&nbsp;&nbsp;The second tuple to compare.<br />
>
><b>Returns:</b> `true` if both Item1 and Item2 of the tuples are equal; otherwise, `false`.
#### GetHashCode
>```csharp
>int GetHashCode(Tuple<T1, T2> obj)
>```
><b>Summary:</b> Returns a hash code for the specified tuple by combining the hash codes of both items.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`obj`&nbsp;&nbsp;-&nbsp;&nbsp;The tuple for which to generate a hash code.<br />
>
><b>Returns:</b> A hash code calculated from both items in the tuple.

<br />

## UpDownType
Represents a vertical direction or position (up or down).

>```csharp
>public enum UpDownType
>```


| Value | Name | Description | Summary | 
| --- | --- | --- | --- | 
| 0 | None | None | No direction specified. | 
| 1 | Up | Up | Upward direction or position. | 
| 2 | Down | Down | Downward direction or position. | 



<br />

## YesNoType
Represents a binary yes/no choice or answer.

>```csharp
>public enum YesNoType
>```


| Value | Name | Description | Summary | 
| --- | --- | --- | --- | 
| 0 | None | None | No answer specified. | 
| 1 | No | No | Negative response (No). | 
| 2 | Yes | Yes | Affirmative response (Yes). | 


<hr /><div style='text-align: right'><i>Generated by MarkdownCodeDoc version 1.2</i></div>
