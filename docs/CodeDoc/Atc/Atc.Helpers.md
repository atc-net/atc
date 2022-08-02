<div style='text-align: right'>

[References](Index.md)&nbsp;&nbsp;-&nbsp;&nbsp;[References extended](IndexExtended.md)
</div>

# Atc.Helpers

<br />

## ArticleNumberHelper
BarcodeHelper.
><b>Remarks:</b> https://en.wikipedia.org/wiki/International_Article_Number.

>```csharp
>public static class ArticleNumberHelper
>```

### Static Methods

#### GetArticleNumberType
>```csharp
>ArticleNumberType GetArticleNumberType(string articleNumber)
>```
><b>Summary:</b> Get ArticleNumberType.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`articleNumber`&nbsp;&nbsp;-&nbsp;&nbsp;ASIN, EAN8, EAN13, GTIN, ISBN10, ISBN13, UPC.<br />
#### IsValidAsin
>```csharp
>bool IsValidAsin(string asin)
>```
><b>Summary:</b> Validate ASIN.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`asin`&nbsp;&nbsp;-&nbsp;&nbsp;The asin.<br />
>
><b>Returns:</b> `true` if [is valid asin] [the specified asin]; otherwise, `false`.
#### IsValidEan
>```csharp
>bool IsValidEan(string code)
>```
><b>Summary:</b> Validate European Article Number.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`code`&nbsp;&nbsp;-&nbsp;&nbsp;The code.<br />
>
><b>Returns:</b> `true` if [is valid ean] [the specified code]; otherwise, `false`.
#### IsValidGtin
>```csharp
>bool IsValidGtin(string code)
>```
><b>Summary:</b> Validate Global Trade Item Number.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`code`&nbsp;&nbsp;-&nbsp;&nbsp;The code.<br />
>
><b>Returns:</b> `true` if [is valid gtin] [the specified code]; otherwise, `false`.
#### IsValidIsbn10
>```csharp
>bool IsValidIsbn10(string isbn10)
>```
><b>Summary:</b> Validate ISBN10.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`isbn10`&nbsp;&nbsp;-&nbsp;&nbsp;The isbn10.<br />
>
><b>Returns:</b> `true` if [is valid isbn10] [the specified isbn10]; otherwise, `false`.
#### IsValidIsbn13
>```csharp
>bool IsValidIsbn13(string isbn13)
>```
><b>Summary:</b> Validate ISBN13.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`isbn13`&nbsp;&nbsp;-&nbsp;&nbsp;The isbn13.<br />
>
><b>Returns:</b> `true` if [is valid isbn13] [the specified isbn13]; otherwise, `false`.
#### IsValidIssn
>```csharp
>bool IsValidIssn(string code)
>```
><b>Summary:</b> Validate ISSN.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`code`&nbsp;&nbsp;-&nbsp;&nbsp;The code.<br />
>
><b>Returns:</b> `true` if [is valid issn] [the specified code]; otherwise, `false`.
#### IsValidUpc
>```csharp
>bool IsValidUpc(string code)
>```
><b>Summary:</b> Validate a UPC.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`code`&nbsp;&nbsp;-&nbsp;&nbsp;The code.<br />
>
><b>Returns:</b> `true` if [is valid upc] [the specified code]; otherwise, `false`.
#### TryConvertToGtin
>```csharp
>bool TryConvertToGtin(string code, out string gtin)
>```
><b>Summary:</b> Attempts to convert a UPC or EAN13 to a GTIN.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`code`&nbsp;&nbsp;-&nbsp;&nbsp;The code.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`gtin`&nbsp;&nbsp;-&nbsp;&nbsp;The gtin.<br />

<br />

## ByteHelper
ByteHelper.

>```csharp
>public static class ByteHelper
>```

### Static Methods

#### ConvertToFourBytes
>```csharp
>byte[] ConvertToFourBytes(int value)
>```
><b>Summary:</b> Convert the `System.Int32` value to four bytes.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
#### ConvertToTwoBytes
>```csharp
>byte[] ConvertToTwoBytes(int value)
>```
><b>Summary:</b> Convert the `System.Int32` value to two bytes.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
#### CreateZeroArray
>```csharp
>byte[] CreateZeroArray(int size)
>```
><b>Summary:</b> Create a array with the given size that only contains zeros.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`size`&nbsp;&nbsp;-&nbsp;&nbsp;The size.<br />
#### HasBit
>```csharp
>bool HasBit(byte value, byte checkValue)
>```
><b>Summary:</b> Determines whether the specified value has the bit set compared with the check-value.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`checkValue`&nbsp;&nbsp;-&nbsp;&nbsp;The check value.<br />
#### HasBit
>```csharp
>bool HasBit(byte value, int checkValue)
>```
><b>Summary:</b> Determines whether the specified value has the bit set compared with the check-value.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`checkValue`&nbsp;&nbsp;-&nbsp;&nbsp;The check value.<br />

<br />

## CardinalDirectionTypeHelper
Enumeration Helper: CardinalDirectionTypeHelper.

>```csharp
>public static class CardinalDirectionTypeHelper
>```

### Static Methods

#### GetByRotationNumberClockwiseUsingMedium
>```csharp
>CardinalDirectionType GetByRotationNumberClockwiseUsingMedium(int rotationNumber)
>```
><b>Summary:</b> Gets the by rotation number clockwise using medium.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`rotationNumber`&nbsp;&nbsp;-&nbsp;&nbsp;The rotation number.<br />
>
><b>Remarks:</b> 0 =&gt; North 1 =&gt; NorthEast 2 =&gt; East 3 =&gt; SouthEast 4 =&gt; South 5 =&gt; SouthWest 6 =&gt; West 7 =&gt; NorthWest.
#### GetTargetCardinalDirectionByGridCells
>```csharp
>CardinalDirectionType GetTargetCardinalDirectionByGridCells(GridCell sourceGridCell, GridCell targetGridCell)
>```
><b>Summary:</b> Gets the target cardinal direction by grid cells.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`sourceGridCell`&nbsp;&nbsp;-&nbsp;&nbsp;The source grid cell.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`targetGridCell`&nbsp;&nbsp;-&nbsp;&nbsp;The target grid cell.<br />
#### GetTargetCardinalDirectionByPoint2Ds
>```csharp
>CardinalDirectionType GetTargetCardinalDirectionByPoint2Ds(Point2D sourceGridCell, Point2D targetGridCell)
>```
><b>Summary:</b> Gets the target cardinal direction by point2 ds.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`sourceGridCell`&nbsp;&nbsp;-&nbsp;&nbsp;The source grid cell.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`targetGridCell`&nbsp;&nbsp;-&nbsp;&nbsp;The target grid cell.<br />
#### GetTheClosestByAngle
>```csharp
>CardinalDirectionType GetTheClosestByAngle(CardinalDirectionType combinedCardinalDirectionType, double angle)
>```
><b>Summary:</b> Gets the closest by angle.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`combinedCardinalDirectionType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the combined cardinal direction.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`angle`&nbsp;&nbsp;-&nbsp;&nbsp;The angle.<br />
#### GetWhenRotate180
>```csharp
>CardinalDirectionType GetWhenRotate180(CardinalDirectionType cardinalDirectionTypeToInclude, CardinalDirectionType cardinalDirectionType)
>```
><b>Summary:</b> Gets the when rotate180.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`cardinalDirectionTypeToInclude`&nbsp;&nbsp;-&nbsp;&nbsp;The cardinal direction type to include.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`cardinalDirectionType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the cardinal direction.<br />
#### GetWhenRotateLeft
>```csharp
>CardinalDirectionType GetWhenRotateLeft(CardinalDirectionType cardinalDirectionTypeToInclude, CardinalDirectionType cardinalDirectionType, int rotationNumber)
>```
><b>Summary:</b> Gets the when rotate left.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`cardinalDirectionTypeToInclude`&nbsp;&nbsp;-&nbsp;&nbsp;The cardinal direction type to include.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`cardinalDirectionType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the cardinal direction.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`rotationNumber`&nbsp;&nbsp;-&nbsp;&nbsp;The rotation number.<br />
#### GetWhenRotateLeft
>```csharp
>CardinalDirectionType GetWhenRotateLeft(CardinalDirectionType cardinalDirectionTypeToInclude, CardinalDirectionType cardinalDirectionType)
>```
><b>Summary:</b> Gets the when rotate left.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`cardinalDirectionTypeToInclude`&nbsp;&nbsp;-&nbsp;&nbsp;The cardinal direction type to include.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`cardinalDirectionType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the cardinal direction.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`rotationNumber`&nbsp;&nbsp;-&nbsp;&nbsp;The rotation number.<br />
#### GetWhenRotateRight
>```csharp
>CardinalDirectionType GetWhenRotateRight(CardinalDirectionType cardinalDirectionTypeToInclude, CardinalDirectionType cardinalDirectionType, int rotationNumber)
>```
><b>Summary:</b> Gets the when rotate right.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`cardinalDirectionTypeToInclude`&nbsp;&nbsp;-&nbsp;&nbsp;The cardinal direction type to include.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`cardinalDirectionType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the cardinal direction.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`rotationNumber`&nbsp;&nbsp;-&nbsp;&nbsp;The rotation number.<br />
#### GetWhenRotateRight
>```csharp
>CardinalDirectionType GetWhenRotateRight(CardinalDirectionType cardinalDirectionTypeToInclude, CardinalDirectionType cardinalDirectionType)
>```
><b>Summary:</b> Gets the when rotate right.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`cardinalDirectionTypeToInclude`&nbsp;&nbsp;-&nbsp;&nbsp;The cardinal direction type to include.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`cardinalDirectionType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the cardinal direction.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`rotationNumber`&nbsp;&nbsp;-&nbsp;&nbsp;The rotation number.<br />

<br />

## CliHelper
CliHelper.

>```csharp
>public static class CliHelper
>```

### Static Methods

#### GetCurrentVersion
>```csharp
>Version GetCurrentVersion()
>```
><b>Summary:</b> Gets the current version from the executing assembly.
>
><b>Returns:</b> Return the `System.Version` of the CLI tool.

<br />

## CultureHelper
CultureHelper.

>```csharp
>public static class CultureHelper
>```

### Static Methods

#### GetCountryNames
>```csharp
>Dictionary<int, string> GetCountryNames(DropDownFirstItemType dropDownFirstItemType = None)
>```
><b>Summary:</b> Gets the country names.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`dropDownFirstItemType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the drop down first item.<br />
#### GetCountryNames
>```csharp
>Dictionary<int, string> GetCountryNames(int displayLanguageLcid, DropDownFirstItemType dropDownFirstItemType = None)
>```
><b>Summary:</b> Gets the country names.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`dropDownFirstItemType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the drop down first item.<br />
#### GetCountryNames
>```csharp
>Dictionary<int, string> GetCountryNames(List<int> includeOnlyLcids, DropDownFirstItemType dropDownFirstItemType = None)
>```
><b>Summary:</b> Gets the country names.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`dropDownFirstItemType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the drop down first item.<br />
#### GetCountryNames
>```csharp
>Dictionary<int, string> GetCountryNames(int displayLanguageLcid, List<int> includeOnlyLcids, DropDownFirstItemType dropDownFirstItemType = None)
>```
><b>Summary:</b> Gets the country names.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`dropDownFirstItemType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the drop down first item.<br />
#### GetCountryNames
>```csharp
>Dictionary<int, string> GetCountryNames(List<string> includeOnlyCultureNames, DropDownFirstItemType dropDownFirstItemType = None)
>```
><b>Summary:</b> Gets the country names.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`dropDownFirstItemType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the drop down first item.<br />
#### GetCountryNames
>```csharp
>Dictionary<int, string> GetCountryNames(int displayLanguageLcid, List<string> includeOnlyCultureNames, DropDownFirstItemType dropDownFirstItemType = None)
>```
><b>Summary:</b> Gets the country names.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`dropDownFirstItemType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the drop down first item.<br />
#### GetCultureByCountryCodeA2
>```csharp
>Culture GetCultureByCountryCodeA2(string value)
>```
><b>Summary:</b> Gets the culture by country code a2.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
#### GetCultureByCountryCodeA2
>```csharp
>Culture GetCultureByCountryCodeA2(int displayLanguageLcid, string value)
>```
><b>Summary:</b> Gets the culture by country code a2.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
#### GetCultureByLcid
>```csharp
>Culture GetCultureByLcid(int lcid)
>```
><b>Summary:</b> Gets the culture by lcid.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`lcid`&nbsp;&nbsp;-&nbsp;&nbsp;The lcid.<br />
#### GetCultureByLcid
>```csharp
>Culture GetCultureByLcid(int displayLanguageLcid, int lcid)
>```
><b>Summary:</b> Gets the culture by lcid.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`lcid`&nbsp;&nbsp;-&nbsp;&nbsp;The lcid.<br />
#### GetCultureFromValue
>```csharp
>Culture GetCultureFromValue(string value)
>```
><b>Summary:</b> Gets the culture from value.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
#### GetCultureFromValue
>```csharp
>Culture GetCultureFromValue(int displayLanguageLcid, string value)
>```
><b>Summary:</b> Gets the culture from value.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
#### GetCultureFromValue
>```csharp
>Culture GetCultureFromValue(int displayLanguageLcid, List<int> includeLcids, string value)
>```
><b>Summary:</b> Gets the culture from value.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
#### GetCultureLcidsWhereCountryIsNotTranslated
>```csharp
>List<int> GetCultureLcidsWhereCountryIsNotTranslated(int displayLanguageLcid, List<int> includeOnlyLcids)
>```
><b>Summary:</b> Gets the culture lcids where country is not translated.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`displayLanguageLcid`&nbsp;&nbsp;-&nbsp;&nbsp;The display language lcid.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`includeOnlyLcids`&nbsp;&nbsp;-&nbsp;&nbsp;The include only lcids.<br />
#### GetCultureLcidsWhereLanguageIsNotTranslated
>```csharp
>List<int> GetCultureLcidsWhereLanguageIsNotTranslated(int displayLanguageLcid, List<int> includeOnlyLcids)
>```
><b>Summary:</b> Gets the culture lcids where language is not translated.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`displayLanguageLcid`&nbsp;&nbsp;-&nbsp;&nbsp;The display language lcid.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`includeOnlyLcids`&nbsp;&nbsp;-&nbsp;&nbsp;The include only lcids.<br />
#### GetCultures
>```csharp
>List<Culture> GetCultures()
>```
><b>Summary:</b> Gets cultures.
#### GetCultures
>```csharp
>List<Culture> GetCultures(List<int> includeOnlyLcids)
>```
><b>Summary:</b> Gets cultures.
#### GetCultures
>```csharp
>List<Culture> GetCultures(List<string> includeOnlyCultureNames)
>```
><b>Summary:</b> Gets cultures.
#### GetCultures
>```csharp
>List<Culture> GetCultures(int displayLanguageLcid)
>```
><b>Summary:</b> Gets cultures.
#### GetCultures
>```csharp
>List<Culture> GetCultures(int displayLanguageLcid, List<int> includeOnlyLcids)
>```
><b>Summary:</b> Gets cultures.
#### GetCultures
>```csharp
>List<Culture> GetCultures(int displayLanguageLcid, List<string> includeOnlyCultureNames)
>```
><b>Summary:</b> Gets cultures.
#### GetCulturesByCountryCodeA2
>```csharp
>List<Culture> GetCulturesByCountryCodeA2(string value)
>```
><b>Summary:</b> Gets the cultures by country code a2.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
#### GetCulturesByCountryCodeA2
>```csharp
>List<Culture> GetCulturesByCountryCodeA2(int displayLanguageLcid, string value)
>```
><b>Summary:</b> Gets the cultures by country code a2.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
#### GetCulturesByLanguageCodeA2
>```csharp
>List<Culture> GetCulturesByLanguageCodeA2(string value)
>```
><b>Summary:</b> Gets the cultures by language code a2.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
#### GetCulturesByLanguageCodeA2
>```csharp
>List<Culture> GetCulturesByLanguageCodeA2(int displayLanguageLcid, string value)
>```
><b>Summary:</b> Gets the cultures by language code a2.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
#### GetCulturesForCountries
>```csharp
>List<Culture> GetCulturesForCountries()
>```
><b>Summary:</b> Gets the cultures for countries.
#### GetLanguageNames
>```csharp
>Dictionary<int, string> GetLanguageNames(DropDownFirstItemType dropDownFirstItemType = None)
>```
><b>Summary:</b> Gets the language names.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`dropDownFirstItemType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the drop down first item.<br />
#### GetLanguageNames
>```csharp
>Dictionary<int, string> GetLanguageNames(int displayLanguageLcid, DropDownFirstItemType dropDownFirstItemType = None)
>```
><b>Summary:</b> Gets the language names.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`dropDownFirstItemType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the drop down first item.<br />
#### GetLanguageNames
>```csharp
>Dictionary<int, string> GetLanguageNames(List<int> includeOnlyLcids, DropDownFirstItemType dropDownFirstItemType = None)
>```
><b>Summary:</b> Gets the language names.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`dropDownFirstItemType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the drop down first item.<br />
#### GetLanguageNames
>```csharp
>Dictionary<int, string> GetLanguageNames(int displayLanguageLcid, List<int> includeOnlyLcids, DropDownFirstItemType dropDownFirstItemType = None)
>```
><b>Summary:</b> Gets the language names.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`dropDownFirstItemType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the drop down first item.<br />
#### GetLanguageNames
>```csharp
>Dictionary<int, string> GetLanguageNames(List<string> includeOnlyCultureNames, DropDownFirstItemType dropDownFirstItemType = None)
>```
><b>Summary:</b> Gets the language names.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`dropDownFirstItemType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the drop down first item.<br />
#### GetLanguageNames
>```csharp
>Dictionary<int, string> GetLanguageNames(int displayLanguageLcid, List<string> includeOnlyCultureNames, DropDownFirstItemType dropDownFirstItemType = None)
>```
><b>Summary:</b> Gets the language names.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`dropDownFirstItemType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the drop down first item.<br />

<br />

## DataAnnotationHelper

>```csharp
>public static class DataAnnotationHelper
>```

### Static Methods

#### TryValidate
>```csharp
>bool TryValidate(T data, out IList`1 validationResults, bool validateAllProperties = True)
>```
#### TryValidateOutToString
>```csharp
>bool TryValidateOutToString(T data, out string validationMessage, bool validateAllProperties = True)
>```
#### TryValidateOutToValidationException
>```csharp
>bool TryValidateOutToValidationException(T data, out ValidationException validationException, bool validateAllProperties = True)
>```

<br />

## DayOfWeekHelper
DayOfWeekHelper.

>```csharp
>public static class DayOfWeekHelper
>```

### Static Methods

#### GetDescription
>```csharp
>string GetDescription(DayOfWeek dayOfWeek, CultureInfo culture = null)
>```
><b>Summary:</b> Gets the description.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`dayOfWeek`&nbsp;&nbsp;-&nbsp;&nbsp;The day of week.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`culture`&nbsp;&nbsp;-&nbsp;&nbsp;The culture.<br />
#### GetDescriptions
>```csharp
>Dictionary<DayOfWeek, string> GetDescriptions(CultureInfo culture = null)
>```
><b>Summary:</b> Gets the descriptions.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`culture`&nbsp;&nbsp;-&nbsp;&nbsp;The culture.<br />
#### TryParseDescription
>```csharp
>bool TryParseDescription(string value, out DayOfWeek dayOfWeek, CultureInfo culture = null)
>```
><b>Summary:</b> Tries the parse description.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`dayOfWeek`&nbsp;&nbsp;-&nbsp;&nbsp;The day of week.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`culture`&nbsp;&nbsp;-&nbsp;&nbsp;The culture.<br />

<br />

## DropDownFirstItemTypeHelper
Enumeration Helper: DropDownFirstItemTypeHelper.

>```csharp
>public static class DropDownFirstItemTypeHelper
>```

### Static Methods

#### EnsureFirstItemType
>```csharp
>List<string> EnsureFirstItemType(List<string> list, DropDownFirstItemType dropDownFirstItemType)
>```
><b>Summary:</b> Ensures the first type of the item.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`list`&nbsp;&nbsp;-&nbsp;&nbsp;The list.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`dropDownFirstItemType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the drop down first item.<br />
#### GetEnumGuid
>```csharp
>Guid GetEnumGuid(DropDownFirstItemType dropDownFirstItemType)
>```
><b>Summary:</b> Gets the enumeration GUID.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`dropDownFirstItemType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the drop down first item.<br />
>
><b>Returns:</b> The `System.Guid`.
#### GetItemFromEnumGuid
>```csharp
>DropDownFirstItemType GetItemFromEnumGuid(Guid key)
>```
><b>Summary:</b> Gets the item from enumeration GUID.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`key`&nbsp;&nbsp;-&nbsp;&nbsp;
            The key.
            <br />
>
><b>Returns:</b> The `Atc.DropDownFirstItemType`.

<br />

## EnumHelper
Enumeration Helper: EnumHelper.

>```csharp
>public static class EnumHelper
>```

### Static Methods

#### ConvertEnumToArray
>```csharp
>Array ConvertEnumToArray(Type enumType, DropDownFirstItemType dropDownFirstItemType = None, bool useDescriptionAttribute = False, bool includeDefault = True, SortDirectionType sortDirectionType = None, bool byFlagIncludeBase = True, bool byFlagIncludeCombined = True)
>```
><b>Summary:</b> Converts the enum to array.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`enumType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the enum.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`dropDownFirstItemType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the drop down first item.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`useDescriptionAttribute`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [use description attribute].<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`includeDefault`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [include default].<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`sortDirectionType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the sort direction.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`byFlagIncludeBase`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [by flag include base].<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`byFlagIncludeCombined`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [by flag include combined].<br />
#### ConvertEnumToDictionary
>```csharp
>Dictionary<int, string> ConvertEnumToDictionary(Type enumType, DropDownFirstItemType dropDownFirstItemType = None, bool useDescriptionAttribute = False, bool includeDefault = True, SortDirectionType sortDirectionType = None, bool byFlagIncludeBase = True, bool byFlagIncludeCombined = True)
>```
><b>Summary:</b> Converts the enum to dictionary.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`enumType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the enum.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`dropDownFirstItemType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the drop down first item.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`useDescriptionAttribute`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [use description attribute].<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`includeDefault`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [include default].<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`sortDirectionType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the sort direction.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`byFlagIncludeBase`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [by flag include base].<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`byFlagIncludeCombined`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [by flag include combined].<br />
#### ConvertEnumToDictionaryWithStringKey
>```csharp
>Dictionary<string, string> ConvertEnumToDictionaryWithStringKey(Type enumType, DropDownFirstItemType dropDownFirstItemType = None, bool useDescriptionAttribute = False, bool includeDefault = True, SortDirectionType sortDirectionType = None, bool byFlagIncludeBase = True, bool byFlagIncludeCombined = True)
>```
><b>Summary:</b> Converts the enum to dictionary with string key.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`enumType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the enum.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`dropDownFirstItemType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the drop down first item.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`useDescriptionAttribute`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [use description attribute].<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`includeDefault`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [include default].<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`sortDirectionType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the sort direction.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`byFlagIncludeBase`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [by flag include base].<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`byFlagIncludeCombined`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [by flag include combined].<br />
#### GetDescription
>```csharp
>string GetDescription(Enum enumeration)
>```
><b>Summary:</b> Gets the description.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`enumeration`&nbsp;&nbsp;-&nbsp;&nbsp;The enumeration.<br />
#### GetEnumValue
>```csharp
>T GetEnumValue(string value, bool ignoreCase = True)
>```
><b>Summary:</b> Gets the enum value.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`ignoreCase`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [ignore case].<br />
>
><b>Returns:</b> If parsed successfully and defined as a valid enum value, the enum value is returned. Otherwise the default value is returned.
#### GetName
>```csharp
>string GetName(Enum enumeration)
>```
><b>Summary:</b> Gets the name.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`enumeration`&nbsp;&nbsp;-&nbsp;&nbsp;The enumeration.<br />
#### GetValueFromDescription
>```csharp
>T GetValueFromDescription(string description)
>```
><b>Summary:</b> Gets the value from the description.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`description`&nbsp;&nbsp;-&nbsp;&nbsp;The description.<br />
>
><b>Returns:</b> The associated enumeration value.

<br />

## FileHelper
FileHelper.

>```csharp
>public static class FileHelper
>```

### Static Fields

#### LineBreaks
>```csharp
>string[] LineBreaks
>```
><b>Summary:</b> The line breaks.
### Static Methods

#### ReadAllText
>```csharp
>string ReadAllText(FileInfo fileInfo)
>```
><b>Summary:</b> Reads all text in the file with UTF8 encoding.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`fileInfo`&nbsp;&nbsp;-&nbsp;&nbsp;The file information.<br />
>
><b>Returns:</b> Return the content from the file, if the file don't exist a empty string will be returned.
#### ReadAllTextAsync
>```csharp
>Task<string> ReadAllTextAsync(FileInfo fileInfo, CancellationToken cancellationToken = null)
>```
><b>Summary:</b> Reads all text in the file with UTF8 encoding.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`fileInfo`&nbsp;&nbsp;-&nbsp;&nbsp;The file information.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`cancellationToken`&nbsp;&nbsp;-&nbsp;&nbsp;The cancellation token.<br />
>
><b>Returns:</b> Return the content from the file, if the file don't exist a empty string will be returned.
#### ReadAllTextToLines
>```csharp
>string[] ReadAllTextToLines(FileInfo fileInfo)
>```
><b>Summary:</b> Reads all text in the file with UTF8 encoding and split it to lines.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`fileInfo`&nbsp;&nbsp;-&nbsp;&nbsp;The file information.<br />
>
><b>Returns:</b> Return the content as lines from the file, if the file don't exist a empty string array will be returned.
#### ReadAllTextToLinesAsync
>```csharp
>Task<string[]> ReadAllTextToLinesAsync(FileInfo fileInfo, CancellationToken cancellationToken = null)
>```
><b>Summary:</b> Reads all text in the file with UTF8 encoding and split it to lines.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`fileInfo`&nbsp;&nbsp;-&nbsp;&nbsp;The file information.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`cancellationToken`&nbsp;&nbsp;-&nbsp;&nbsp;The cancellation token.<br />
>
><b>Returns:</b> Return the content as lines from the file, if the file don't exist a empty string array will be returned.
#### WriteAllText
>```csharp
>void WriteAllText(FileInfo fileInfo, string content)
>```
><b>Summary:</b> Writes all text to the file with UTF8 encoding.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`fileInfo`&nbsp;&nbsp;-&nbsp;&nbsp;The file information.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`content`&nbsp;&nbsp;-&nbsp;&nbsp;The content.<br />
#### WriteAllTextAsync
>```csharp
>Task WriteAllTextAsync(FileInfo fileInfo, string content, CancellationToken cancellationToken = null)
>```
><b>Summary:</b> Writes all text to the file with UTF8 encoding.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`fileInfo`&nbsp;&nbsp;-&nbsp;&nbsp;The file information.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`content`&nbsp;&nbsp;-&nbsp;&nbsp;The content.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`cancellationToken`&nbsp;&nbsp;-&nbsp;&nbsp;The cancellation token.<br />

<br />

## FileHelper&lt;T&gt;
FileHelper.

>```csharp
>public static class FileHelper&lt;T&gt;
>```

### Static Methods

#### ReadJsonFileAndDeserializeAsync
>```csharp
>Task<T> ReadJsonFileAndDeserializeAsync(FileInfo fileInfo)
>```
><b>Summary:</b> Read the json file and deserialize to the specified type.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`fileInfo`&nbsp;&nbsp;-&nbsp;&nbsp;The file.<br />
>
><b>Returns:</b> The model.
#### ReadJsonFileToModel
>```csharp
>T ReadJsonFileToModel(FileInfo fileInfo)
>```
><b>Summary:</b> Read the json file and deserialize to the specified type.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`fileInfo`&nbsp;&nbsp;-&nbsp;&nbsp;The file.<br />
>
><b>Returns:</b> The model.
#### WriteModelToJsonFile
>```csharp
>void WriteModelToJsonFile(FileInfo fileInfo, T model)
>```
><b>Summary:</b> Write the model to a json file.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`fileInfo`&nbsp;&nbsp;-&nbsp;&nbsp;The file information.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`model`&nbsp;&nbsp;-&nbsp;&nbsp;The model.<br />
#### WriteModelToJsonFileAsync
>```csharp
>Task WriteModelToJsonFileAsync(FileInfo fileInfo, T model)
>```
><b>Summary:</b> Write the model to a json file.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`fileInfo`&nbsp;&nbsp;-&nbsp;&nbsp;The file information.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`model`&nbsp;&nbsp;-&nbsp;&nbsp;The model.<br />

<br />

## MathHelper
The MathHelper module contains procedures used to preform math operations.

>```csharp
>public static class MathHelper
>```

### Static Methods

#### Acos
>```csharp
>double Acos(double value)
>```
><b>Summary:</b> Returns the angle whose cosine is the specified number.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;A number representing a cosine, where -1 ≤d≤ 1.<br />
#### Asin
>```csharp
>double Asin(double value)
>```
><b>Summary:</b> Returns the angle whose sine is the specified number.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;A number representing a sine, where -1 ≤d≤ 1.<br />
#### Atan
>```csharp
>double Atan(double value)
>```
><b>Summary:</b> Returns the angle whose tangent is the specified number.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;A number representing a tangent.<br />
#### CelsiusToFahrenheit
>```csharp
>double CelsiusToFahrenheit(double celsius)
>```
><b>Summary:</b> Celsius to fahrenheit.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`celsius`&nbsp;&nbsp;-&nbsp;&nbsp;The celsius.<br />
#### Cos
>```csharp
>double Cos(double degrees)
>```
><b>Summary:</b> Returns the cosine of the specified angle.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`degrees`&nbsp;&nbsp;-&nbsp;&nbsp;An angle, measured in degrees.<br />
#### DegreesToRadians
>```csharp
>double DegreesToRadians(double degrees)
>```
><b>Summary:</b> This function converts degrees to radians.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`degrees`&nbsp;&nbsp;-&nbsp;&nbsp;An angle, measured in degrees.<br />
#### EnsureDegreesAreBetween0And360
>```csharp
>double EnsureDegreesAreBetween0And360(double degrees)
>```
><b>Summary:</b> Returns the specified angle in the same angle between 0 and 360.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`degrees`&nbsp;&nbsp;-&nbsp;&nbsp;An angle, measured in degrees.<br />
#### EnsureDegreesAreBetween0And360
>```csharp
>Point2D EnsureDegreesAreBetween0And360(Point2D degrees)
>```
><b>Summary:</b> Returns the specified angle in the same angle between 0 and 360.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`degrees`&nbsp;&nbsp;-&nbsp;&nbsp;An angle, measured in degrees.<br />
#### EnsureDegreesAreBetween0And360
>```csharp
>Point3D EnsureDegreesAreBetween0And360(Point3D degrees)
>```
><b>Summary:</b> Returns the specified angle in the same angle between 0 and 360.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`degrees`&nbsp;&nbsp;-&nbsp;&nbsp;An angle, measured in degrees.<br />
#### FahrenheitToCelsius
>```csharp
>double FahrenheitToCelsius(double fahrenheit)
>```
><b>Summary:</b> Fahrenheit to celsius.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`fahrenheit`&nbsp;&nbsp;-&nbsp;&nbsp;The fahrenheit.<br />
#### IsEquals
>```csharp
>bool IsEquals(double value1, double value2)
>```
><b>Summary:</b> Determines whether the specified value1 is equals.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value1`&nbsp;&nbsp;-&nbsp;&nbsp;The value1.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value2`&nbsp;&nbsp;-&nbsp;&nbsp;The value2.<br />
>
><b>Returns:</b> `true` if the specified value1 is equals; otherwise, `false`.
#### IsEqualToZero
>```csharp
>bool IsEqualToZero(double value)
>```
><b>Summary:</b> Determines whether [is equal to zero] [the specified value].
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
>
><b>Returns:</b> `true` if [is equal to zero] [the specified value]; otherwise, `false`.
#### Max
>```csharp
>int Max(int[] values)
>```
><b>Summary:</b> Maxes the specified values.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`values`&nbsp;&nbsp;-&nbsp;&nbsp;The values.<br />
#### Max
>```csharp
>int Max(List<int> values)
>```
><b>Summary:</b> Maxes the specified values.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`values`&nbsp;&nbsp;-&nbsp;&nbsp;The values.<br />
#### Max
>```csharp
>double Max(double[] values)
>```
><b>Summary:</b> Maxes the specified values.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`values`&nbsp;&nbsp;-&nbsp;&nbsp;The values.<br />
#### Max
>```csharp
>double Max(List<double> values)
>```
><b>Summary:</b> Maxes the specified values.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`values`&nbsp;&nbsp;-&nbsp;&nbsp;The values.<br />
#### Min
>```csharp
>int Min(int[] values)
>```
><b>Summary:</b> Min the specified values.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`values`&nbsp;&nbsp;-&nbsp;&nbsp;The values.<br />
#### Min
>```csharp
>int Min(List<int> values)
>```
><b>Summary:</b> Min the specified values.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`values`&nbsp;&nbsp;-&nbsp;&nbsp;The values.<br />
#### Min
>```csharp
>double Min(double[] values)
>```
><b>Summary:</b> Min the specified values.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`values`&nbsp;&nbsp;-&nbsp;&nbsp;The values.<br />
#### Min
>```csharp
>double Min(List<double> values)
>```
><b>Summary:</b> Min the specified values.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`values`&nbsp;&nbsp;-&nbsp;&nbsp;The values.<br />
#### Percentage
>```csharp
>double Percentage(double totalValue, double value, int digits = 2)
>```
><b>Summary:</b> Percentages the specified total value.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`totalValue`&nbsp;&nbsp;-&nbsp;&nbsp;The total value.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`digits`&nbsp;&nbsp;-&nbsp;&nbsp;The digits.<br />
>
><b>Returns:</b> The calculated percentage.
>
><b>Code usage:</b>
>```csharp
>double value = MathUtil.Percentage(totalValue, value);
>```
>
><b>Code example:</b>
>```csharp
>double totalValue = 100;
>double value = 10;
>double procentage = MathUtil.Percentage(totalValue, value);
>```
#### PercentageAsInteger
>```csharp
>int PercentageAsInteger(double totalValue, double value)
>```
><b>Summary:</b> Percentages as integer.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`totalValue`&nbsp;&nbsp;-&nbsp;&nbsp;The total value.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
>
><b>Returns:</b> The calculated percentage.
>
><b>Code usage:</b>
>```csharp
>int value = MathUtil.PercentageAsInteger(totalValue, value);
>```
>
><b>Code example:</b>
>```csharp
>double totalValue = 100;
>double value = 10;
>int procentage = MathUtil.PercentageAsInteger(totalValue, value);
>```
#### RadiansToDegrees
>```csharp
>double RadiansToDegrees(double radians)
>```
><b>Summary:</b> This function converts radians to degrees.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`radians`&nbsp;&nbsp;-&nbsp;&nbsp;An angle, measured in radians.<br />
#### Sin
>```csharp
>double Sin(double degrees)
>```
><b>Summary:</b> Returns the sine of the specified angle.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`degrees`&nbsp;&nbsp;-&nbsp;&nbsp;An angle, measured in degrees.<br />
#### Tan
>```csharp
>double Tan(double degrees)
>```
><b>Summary:</b> Returns the tangent of the specified angle.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`degrees`&nbsp;&nbsp;-&nbsp;&nbsp;An angle, measured in degrees.<br />
#### TruncateToMaxPrecision
>```csharp
>double TruncateToMaxPrecision(double value, int decimalPrecision)
>```
><b>Summary:</b> Truncates to maximum precision.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`decimalPrecision`&nbsp;&nbsp;-&nbsp;&nbsp;The decimal precision.<br />

<br />

## NetworkInformationHelper

>```csharp
>public static class NetworkInformationHelper
>```

### Static Methods

#### GetPublicIpAddress
>```csharp
>IPAddress GetPublicIpAddress()
>```
#### HasConnection
>```csharp
>bool HasConnection()
>```
#### HasConnection
>```csharp
>bool HasConnection(IPAddress ipAddress)
>```
#### HasHttpConnection
>```csharp
>bool HasHttpConnection()
>```
#### HasHttpConnection
>```csharp
>bool HasHttpConnection(Uri uri)
>```
#### HasTcpConnection
>```csharp
>bool HasTcpConnection(IPAddress ipAddress, int port)
>```

<br />

## ProcessHelper

>```csharp
>public static class ProcessHelper
>```

### Static Methods

#### Execute
>```csharp
>Task<ValueTuple<bool, string>> Execute(FileInfo fileInfo, string arguments)
>```
#### Execute
>```csharp
>Task<ValueTuple<bool, string>> Execute(DirectoryInfo workingDirectory, FileInfo fileInfo, string arguments)
>```
#### Execute
>```csharp
>Task<ValueTuple<bool, string>> Execute(FileInfo fileInfo, string arguments, int timeoutInSec, CancellationToken cancellationToken = null)
>```
#### Execute
>```csharp
>Task<ValueTuple<bool, string>> Execute(DirectoryInfo workingDirectory, FileInfo fileInfo, string arguments, int timeoutInSec, CancellationToken cancellationToken = null)
>```
#### ExecuteAndIgnoreOutput
>```csharp
>Task<bool> ExecuteAndIgnoreOutput(FileInfo fileInfo, string arguments)
>```
#### ExecuteAndIgnoreOutput
>```csharp
>Task<bool> ExecuteAndIgnoreOutput(DirectoryInfo workingDirectory, FileInfo fileInfo, string arguments)
>```
#### ExecuteAndIgnoreOutput
>```csharp
>Task<bool> ExecuteAndIgnoreOutput(FileInfo fileInfo, string arguments, int timeoutInSec, CancellationToken cancellationToken = null)
>```
#### ExecuteAndIgnoreOutput
>```csharp
>Task<bool> ExecuteAndIgnoreOutput(DirectoryInfo workingDirectory, FileInfo fileInfo, string arguments, int timeoutInSec, CancellationToken cancellationToken = null)
>```
#### KillById
>```csharp
>ValueTuple<bool, string> KillById(int processId, int timeoutInSec = 30)
>```
#### KillByName
>```csharp
>ValueTuple<bool, string> KillByName(string processName, bool allowMultiKill = True, int timeoutInSec = 30)
>```
#### KillEntryCaller
>```csharp
>ValueTuple<bool, string> KillEntryCaller(int timeoutInSec = 30)
>```

<br />

## ReflectionHelper
ReflectionHelper.

>```csharp
>public static class ReflectionHelper
>```

### Static Methods

#### SetPrivateField
>```csharp
>void SetPrivateField(object target, string fieldName, object value)
>```
><b>Summary:</b> Sets the private field.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`target`&nbsp;&nbsp;-&nbsp;&nbsp;The target.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`fieldName`&nbsp;&nbsp;-&nbsp;&nbsp;Name of the field.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />

<br />

## RegionInfoHelper
RegionInfoHelper.

>```csharp
>public static class RegionInfoHelper
>```

### Static Methods

#### GetAllRegionInfos
>```csharp
>List<RegionInfo> GetAllRegionInfos()
>```
><b>Summary:</b> Gets all region infos.
#### GetAllRegionInfosAsLcids
>```csharp
>List<int> GetAllRegionInfosAsLcids()
>```
><b>Summary:</b> Gets all region infos as lcids.
#### GetCultureInfoByIsoAlpha3
>```csharp
>CultureInfo GetCultureInfoByIsoAlpha3(string isoAlpha3Code)
>```
><b>Summary:</b> Gets the culture information by iso alpha3.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`isoAlpha3Code`&nbsp;&nbsp;-&nbsp;&nbsp;The iso alpha3 code.<br />
#### GetLcidFromRegionInfo
>```csharp
>int GetLcidFromRegionInfo(RegionInfo regionInfo)
>```
><b>Summary:</b> Gets the lcid from region information.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`regionInfo`&nbsp;&nbsp;-&nbsp;&nbsp;The region information.<br />
#### GetRegionInfoByIsoAlpha3
>```csharp
>RegionInfo GetRegionInfoByIsoAlpha3(string isoAlpha3Code)
>```
><b>Summary:</b> Gets the region information by iso alpha3.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`isoAlpha3Code`&nbsp;&nbsp;-&nbsp;&nbsp;The iso alpha3 code.<br />
#### GetRegionInfoByLcid
>```csharp
>RegionInfo GetRegionInfoByLcid(int lcid)
>```
><b>Summary:</b> Gets the region information by lcid.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`lcid`&nbsp;&nbsp;-&nbsp;&nbsp;The lcid.<br />

<br />

## SimpleTypeHelper
PrimitiveTypeHelper.

>```csharp
>public static class SimpleTypeHelper
>```

### Static Fields

#### BeautifySimpleTypeArrayLookup
>```csharp
>Dictionary<Type, string> BeautifySimpleTypeArrayLookup
>```
><b>Summary:</b> The beautify simple type array lookup.
#### BeautifySimpleTypeLookup
>```csharp
>Dictionary<Type, string> BeautifySimpleTypeLookup
>```
><b>Summary:</b> The beautify simple type lookup.
#### PrimitiveTypes
>```csharp
>Type[] PrimitiveTypes
>```
><b>Summary:</b> The primitive types.
#### SimpleTypes
>```csharp
>Type[] SimpleTypes
>```
><b>Summary:</b> The simple types.
### Static Methods

#### GetBeautifyArrayTypeName
>```csharp
>string GetBeautifyArrayTypeName(Type type)
>```
><b>Summary:</b> Gets the name of the beautify array type.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`type`&nbsp;&nbsp;-&nbsp;&nbsp;The type.<br />
#### GetBeautifyTypeName
>```csharp
>string GetBeautifyTypeName(Type type)
>```
><b>Summary:</b> Gets the name of the beautify type.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`type`&nbsp;&nbsp;-&nbsp;&nbsp;The type.<br />
#### GetBeautifyTypeNameByRef
>```csharp
>string GetBeautifyTypeNameByRef(Type type)
>```
><b>Summary:</b> Gets the beautify type name by reference.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`type`&nbsp;&nbsp;-&nbsp;&nbsp;The type.<br />
#### IsSimpleType
>```csharp
>bool IsSimpleType(string value, StringComparison comparison = Ordinal)
>```
><b>Summary:</b> Determines whether the value is nameof a type that is simple / build-in.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`comparison`&nbsp;&nbsp;-&nbsp;&nbsp;The string comparison - default is 'Ordinal'.<br />

<br />

## TaskHelper
TaskHelper.

>```csharp
>public static class TaskHelper
>```

### Static Methods

#### Execute
>```csharp
>Task<TResult> Execute(Func<CancellationToken, Task<TResult>> taskToRun, TimeSpan timeout, CancellationToken cancellationToken = null)
>```
><b>Summary:</b> Executes the specified task with a timeout.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`taskToRun`&nbsp;&nbsp;-&nbsp;&nbsp;The task to run.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`timeout`&nbsp;&nbsp;-&nbsp;&nbsp;The timeout.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`cancellationToken`&nbsp;&nbsp;-&nbsp;&nbsp;The cancellation token.<br />
#### RunSync
>```csharp
>void RunSync(Func<Task> func)
>```
><b>Summary:</b> Runs a Task function synchronous.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`func`&nbsp;&nbsp;-&nbsp;&nbsp;The Task function.<br />
#### RunSync
>```csharp
>TResult RunSync(Func<Task<TResult>> func)
>```
><b>Summary:</b> Runs a Task function synchronous.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`func`&nbsp;&nbsp;-&nbsp;&nbsp;The Task function.<br />
#### WhenAll
>```csharp
>Task WhenAll(IEnumerable<Task> tasks)
>```
><b>Summary:</b> This method wraps the built-in Task.WhenAll method, but correctly await`s tasks and gets an AggregateException back.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`tasks`&nbsp;&nbsp;-&nbsp;&nbsp;The tasks.<br />
>
><b>Remarks:</b> This method gives us an AggregateException and not only the first exception occurrence, in case of an exception thrown from one of the tasks.
#### WhenAll
>```csharp
>Task<IEnumerable<T>> WhenAll(IEnumerable<Task<T>> tasks)
>```
><b>Summary:</b> This method wraps the built-in Task.WhenAll method, but correctly await`s tasks and gets an AggregateException back.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`tasks`&nbsp;&nbsp;-&nbsp;&nbsp;The tasks.<br />
>
><b>Remarks:</b> This method gives us an AggregateException and not only the first exception occurrence, in case of an exception thrown from one of the tasks.
#### WhenAll
>```csharp
>Task<IEnumerable<T>> WhenAll(Task`1[] tasks)
>```
><b>Summary:</b> This method wraps the built-in Task.WhenAll method, but correctly await`s tasks and gets an AggregateException back.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`tasks`&nbsp;&nbsp;-&nbsp;&nbsp;The tasks.<br />
>
><b>Remarks:</b> This method gives us an AggregateException and not only the first exception occurrence, in case of an exception thrown from one of the tasks.

<br />

## ThreadHelper
ThreadHelper.

>```csharp
>public static class ThreadHelper
>```

### Static Properties

#### ProcessorCount
>```csharp
>ProcessorCount
>```
><b>Summary:</b> Gets the processor count.
### Static Methods

#### GetParallelOptions
>```csharp
>ParallelOptions GetParallelOptions(int exemptProcessorCount = 2)
>```
><b>Summary:</b> Gets the parallel options.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`exemptProcessorCount`&nbsp;&nbsp;-&nbsp;&nbsp;The exempt processor count.<br />
<hr /><div style='text-align: right'><i>Generated by MarkdownCodeDoc version 1.2</i></div>
