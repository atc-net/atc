<div style='text-align: right'>

[References](Index.md)&nbsp;&nbsp;-&nbsp;&nbsp;[References extended](IndexExtended.md)
</div>

# Atc.Helpers

<br />


## ArticleNumberHelper
BarcodeHelper.


```csharp
public static class ArticleNumberHelper
```

### Static Methods


#### GetArticleNumberType

```csharp
ArticleNumberType GetArticleNumberType(string articleNumber)
```
<p><b>Summary:</b> Get ArticleNumberType.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`articleNumber`&nbsp;&nbsp;-&nbsp;&nbsp;ASIN, EAN8, EAN13, GTIN, ISBN10, ISBN13, UPC.<br />
#### IsValidAsin

```csharp
bool IsValidAsin(string asin)
```
<p><b>Summary:</b> Validate ASIN.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`asin`&nbsp;&nbsp;-&nbsp;&nbsp;The asin.<br />
<p><b>Returns:</b> true if [is valid asin] [the specified asin]; otherwise, false.</p>

#### IsValidEan

```csharp
bool IsValidEan(string code)
```
<p><b>Summary:</b> Validate European Article Number.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`code`&nbsp;&nbsp;-&nbsp;&nbsp;The code.<br />
<p><b>Returns:</b> true if [is valid ean] [the specified code]; otherwise, false.</p>

#### IsValidGtin

```csharp
bool IsValidGtin(string code)
```
<p><b>Summary:</b> Validate Global Trade Item Number.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`code`&nbsp;&nbsp;-&nbsp;&nbsp;The code.<br />
<p><b>Returns:</b> true if [is valid gtin] [the specified code]; otherwise, false.</p>

#### IsValidIsbn10

```csharp
bool IsValidIsbn10(string isbn10)
```
<p><b>Summary:</b> Validate ISBN10.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`isbn10`&nbsp;&nbsp;-&nbsp;&nbsp;The isbn10.<br />
<p><b>Returns:</b> true if [is valid isbn10] [the specified isbn10]; otherwise, false.</p>

#### IsValidIsbn13

```csharp
bool IsValidIsbn13(string isbn13)
```
<p><b>Summary:</b> Validate ISBN13.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`isbn13`&nbsp;&nbsp;-&nbsp;&nbsp;The isbn13.<br />
<p><b>Returns:</b> true if [is valid isbn13] [the specified isbn13]; otherwise, false.</p>

#### IsValidIssn

```csharp
bool IsValidIssn(string code)
```
<p><b>Summary:</b> Validate ISSN.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`code`&nbsp;&nbsp;-&nbsp;&nbsp;The code.<br />
<p><b>Returns:</b> true if [is valid issn] [the specified code]; otherwise, false.</p>

#### IsValidUpc

```csharp
bool IsValidUpc(string code)
```
<p><b>Summary:</b> Validate a UPC.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`code`&nbsp;&nbsp;-&nbsp;&nbsp;The code.<br />
<p><b>Returns:</b> true if [is valid upc] [the specified code]; otherwise, false.</p>

#### TryConvertToGtin

```csharp
bool TryConvertToGtin(string code, out string gtin)
```
<p><b>Summary:</b> Attempts to convert a UPC or EAN13 to a GTIN.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`code`&nbsp;&nbsp;-&nbsp;&nbsp;The code.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`gtin`&nbsp;&nbsp;-&nbsp;&nbsp;The gtin.<br />

<br />


## CardinalDirectionTypeHelper
Enumeration Helper: CardinalDirectionTypeHelper.


```csharp
public static class CardinalDirectionTypeHelper
```

### Static Methods


#### GetByRotationNumberClockwiseUsingMedium

```csharp
CardinalDirectionType GetByRotationNumberClockwiseUsingMedium(int rotationNumber)
```
<p><b>Summary:</b> Gets the by rotation number clockwise using medium.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`rotationNumber`&nbsp;&nbsp;-&nbsp;&nbsp;The rotation number.<br />
<p><b>Remarks:</b> 0 => North
            1 => NorthEast
            2 => East
            3 => SouthEast
            4 => South
            5 => SouthWest
            6 => West
            7 => NorthWest.</p>

#### GetTargetCardinalDirectionByGridCells

```csharp
CardinalDirectionType GetTargetCardinalDirectionByGridCells(GridCell sourceGridCell, GridCell targetGridCell)
```
<p><b>Summary:</b> Gets the target cardinal direction by grid cells.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`sourceGridCell`&nbsp;&nbsp;-&nbsp;&nbsp;The source grid cell.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`targetGridCell`&nbsp;&nbsp;-&nbsp;&nbsp;The target grid cell.<br />
#### GetTargetCardinalDirectionByPoint2Ds

```csharp
CardinalDirectionType GetTargetCardinalDirectionByPoint2Ds(Point2D sourceGridCell, Point2D targetGridCell)
```
<p><b>Summary:</b> Gets the target cardinal direction by point2 ds.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`sourceGridCell`&nbsp;&nbsp;-&nbsp;&nbsp;The source grid cell.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`targetGridCell`&nbsp;&nbsp;-&nbsp;&nbsp;The target grid cell.<br />
#### GetTheClosestByAngle

```csharp
CardinalDirectionType GetTheClosestByAngle(CardinalDirectionType combinedCardinalDirectionType, double angle)
```
<p><b>Summary:</b> Gets the closest by angle.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`combinedCardinalDirectionType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the combined cardinal direction.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`angle`&nbsp;&nbsp;-&nbsp;&nbsp;The angle.<br />
#### GetWhenRotate180

```csharp
CardinalDirectionType GetWhenRotate180(CardinalDirectionType cardinalDirectionTypeToInclude, CardinalDirectionType cardinalDirectionType)
```
<p><b>Summary:</b> Gets the when rotate180.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`cardinalDirectionTypeToInclude`&nbsp;&nbsp;-&nbsp;&nbsp;The cardinal direction type to include.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`cardinalDirectionType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the cardinal direction.<br />
#### GetWhenRotateLeft

```csharp
CardinalDirectionType GetWhenRotateLeft(CardinalDirectionType cardinalDirectionTypeToInclude, CardinalDirectionType cardinalDirectionType, int rotationNumber)
```
<p><b>Summary:</b> Gets the when rotate left.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`cardinalDirectionTypeToInclude`&nbsp;&nbsp;-&nbsp;&nbsp;The cardinal direction type to include.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`cardinalDirectionType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the cardinal direction.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`rotationNumber`&nbsp;&nbsp;-&nbsp;&nbsp;The rotation number.<br />
#### GetWhenRotateLeft

```csharp
CardinalDirectionType GetWhenRotateLeft(CardinalDirectionType cardinalDirectionTypeToInclude, CardinalDirectionType cardinalDirectionType)
```
<p><b>Summary:</b> Gets the when rotate left.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`cardinalDirectionTypeToInclude`&nbsp;&nbsp;-&nbsp;&nbsp;The cardinal direction type to include.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`cardinalDirectionType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the cardinal direction.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`rotationNumber`&nbsp;&nbsp;-&nbsp;&nbsp;The rotation number.<br />
#### GetWhenRotateRight

```csharp
CardinalDirectionType GetWhenRotateRight(CardinalDirectionType cardinalDirectionTypeToInclude, CardinalDirectionType cardinalDirectionType, int rotationNumber)
```
<p><b>Summary:</b> Gets the when rotate right.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`cardinalDirectionTypeToInclude`&nbsp;&nbsp;-&nbsp;&nbsp;The cardinal direction type to include.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`cardinalDirectionType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the cardinal direction.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`rotationNumber`&nbsp;&nbsp;-&nbsp;&nbsp;The rotation number.<br />
#### GetWhenRotateRight

```csharp
CardinalDirectionType GetWhenRotateRight(CardinalDirectionType cardinalDirectionTypeToInclude, CardinalDirectionType cardinalDirectionType)
```
<p><b>Summary:</b> Gets the when rotate right.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`cardinalDirectionTypeToInclude`&nbsp;&nbsp;-&nbsp;&nbsp;The cardinal direction type to include.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`cardinalDirectionType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the cardinal direction.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`rotationNumber`&nbsp;&nbsp;-&nbsp;&nbsp;The rotation number.<br />

<br />


## CultureHelper
CultureHelper.


```csharp
public static class CultureHelper
```

### Static Methods


#### GetCountryNames

```csharp
Dictionary<int, string> GetCountryNames(DropDownFirstItemType dropDownFirstItemType = None)
```
<p><b>Summary:</b> Gets the country names.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`dropDownFirstItemType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the drop down first item.<br />
#### GetCountryNames

```csharp
Dictionary<int, string> GetCountryNames(int displayLanguageLcid, DropDownFirstItemType dropDownFirstItemType = None)
```
<p><b>Summary:</b> Gets the country names.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`dropDownFirstItemType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the drop down first item.<br />
#### GetCountryNames

```csharp
Dictionary<int, string> GetCountryNames(List<int> includeOnlyLcids, DropDownFirstItemType dropDownFirstItemType = None)
```
<p><b>Summary:</b> Gets the country names.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`dropDownFirstItemType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the drop down first item.<br />
#### GetCountryNames

```csharp
Dictionary<int, string> GetCountryNames(int displayLanguageLcid, List<int> includeOnlyLcids, DropDownFirstItemType dropDownFirstItemType = None)
```
<p><b>Summary:</b> Gets the country names.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`dropDownFirstItemType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the drop down first item.<br />
#### GetCountryNames

```csharp
Dictionary<int, string> GetCountryNames(List<string> includeOnlyCultureNames, DropDownFirstItemType dropDownFirstItemType = None)
```
<p><b>Summary:</b> Gets the country names.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`dropDownFirstItemType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the drop down first item.<br />
#### GetCountryNames

```csharp
Dictionary<int, string> GetCountryNames(int displayLanguageLcid, List<string> includeOnlyCultureNames, DropDownFirstItemType dropDownFirstItemType = None)
```
<p><b>Summary:</b> Gets the country names.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`dropDownFirstItemType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the drop down first item.<br />
#### GetCultureByCountryCodeA2

```csharp
Culture GetCultureByCountryCodeA2(string value)
```
<p><b>Summary:</b> Gets the culture by country code a2.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
#### GetCultureByCountryCodeA2

```csharp
Culture GetCultureByCountryCodeA2(int displayLanguageLcid, string value)
```
<p><b>Summary:</b> Gets the culture by country code a2.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
#### GetCultureByLcid

```csharp
Culture GetCultureByLcid(int lcid)
```
<p><b>Summary:</b> Gets the culture by lcid.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`lcid`&nbsp;&nbsp;-&nbsp;&nbsp;The lcid.<br />
#### GetCultureByLcid

```csharp
Culture GetCultureByLcid(int displayLanguageLcid, int lcid)
```
<p><b>Summary:</b> Gets the culture by lcid.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`lcid`&nbsp;&nbsp;-&nbsp;&nbsp;The lcid.<br />
#### GetCultureFromValue

```csharp
Culture GetCultureFromValue(string value)
```
<p><b>Summary:</b> Gets the culture from value.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
#### GetCultureFromValue

```csharp
Culture GetCultureFromValue(int displayLanguageLcid, string value)
```
<p><b>Summary:</b> Gets the culture from value.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
#### GetCultureFromValue

```csharp
Culture GetCultureFromValue(int displayLanguageLcid, List<int> includeLcids, string value)
```
<p><b>Summary:</b> Gets the culture from value.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
#### GetCultureLcidsWhereCountryIsNotTranslated

```csharp
List<int> GetCultureLcidsWhereCountryIsNotTranslated(int displayLanguageLcid, List<int> includeOnlyLcids)
```
<p><b>Summary:</b> Gets the culture lcids where country is not translated.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`displayLanguageLcid`&nbsp;&nbsp;-&nbsp;&nbsp;The display language lcid.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`includeOnlyLcids`&nbsp;&nbsp;-&nbsp;&nbsp;The include only lcids.<br />
#### GetCultureLcidsWhereLanguageIsNotTranslated

```csharp
List<int> GetCultureLcidsWhereLanguageIsNotTranslated(int displayLanguageLcid, List<int> includeOnlyLcids)
```
<p><b>Summary:</b> Gets the culture lcids where language is not translated.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`displayLanguageLcid`&nbsp;&nbsp;-&nbsp;&nbsp;The display language lcid.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`includeOnlyLcids`&nbsp;&nbsp;-&nbsp;&nbsp;The include only lcids.<br />
#### GetCultures

```csharp
List<Culture> GetCultures()
```
<p><b>Summary:</b> Gets cultures.</p>

#### GetCultures

```csharp
List<Culture> GetCultures(List<int> includeOnlyLcids)
```
<p><b>Summary:</b> Gets cultures.</p>

#### GetCultures

```csharp
List<Culture> GetCultures(List<string> includeOnlyCultureNames)
```
<p><b>Summary:</b> Gets cultures.</p>

#### GetCultures

```csharp
List<Culture> GetCultures(int displayLanguageLcid, List<int> includeOnlyLcids)
```
<p><b>Summary:</b> Gets cultures.</p>

#### GetCultures

```csharp
List<Culture> GetCultures(int displayLanguageLcid, List<string> includeOnlyCultureNames)
```
<p><b>Summary:</b> Gets cultures.</p>

#### GetCultures

```csharp
List<Culture> GetCultures(int displayLanguageLcid)
```
<p><b>Summary:</b> Gets cultures.</p>

#### GetCulturesByCountryCodeA2

```csharp
List<Culture> GetCulturesByCountryCodeA2(string value)
```
<p><b>Summary:</b> Gets the cultures by country code a2.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
#### GetCulturesByCountryCodeA2

```csharp
List<Culture> GetCulturesByCountryCodeA2(int displayLanguageLcid, string value)
```
<p><b>Summary:</b> Gets the cultures by country code a2.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
#### GetCulturesByLanguageCodeA2

```csharp
List<Culture> GetCulturesByLanguageCodeA2(string value)
```
<p><b>Summary:</b> Gets the cultures by language code a2.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
#### GetCulturesByLanguageCodeA2

```csharp
List<Culture> GetCulturesByLanguageCodeA2(int displayLanguageLcid, string value)
```
<p><b>Summary:</b> Gets the cultures by language code a2.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
#### GetCulturesForCountries

```csharp
List<Culture> GetCulturesForCountries()
```
<p><b>Summary:</b> Gets the cultures for countries.</p>

#### GetLanguageNames

```csharp
Dictionary<int, string> GetLanguageNames(DropDownFirstItemType dropDownFirstItemType = None)
```
<p><b>Summary:</b> Gets the language names.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`dropDownFirstItemType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the drop down first item.<br />
#### GetLanguageNames

```csharp
Dictionary<int, string> GetLanguageNames(int displayLanguageLcid, DropDownFirstItemType dropDownFirstItemType = None)
```
<p><b>Summary:</b> Gets the language names.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`dropDownFirstItemType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the drop down first item.<br />
#### GetLanguageNames

```csharp
Dictionary<int, string> GetLanguageNames(List<int> includeOnlyLcids, DropDownFirstItemType dropDownFirstItemType = None)
```
<p><b>Summary:</b> Gets the language names.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`dropDownFirstItemType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the drop down first item.<br />
#### GetLanguageNames

```csharp
Dictionary<int, string> GetLanguageNames(int displayLanguageLcid, List<int> includeOnlyLcids, DropDownFirstItemType dropDownFirstItemType = None)
```
<p><b>Summary:</b> Gets the language names.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`dropDownFirstItemType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the drop down first item.<br />
#### GetLanguageNames

```csharp
Dictionary<int, string> GetLanguageNames(List<string> includeOnlyCultureNames, DropDownFirstItemType dropDownFirstItemType = None)
```
<p><b>Summary:</b> Gets the language names.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`dropDownFirstItemType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the drop down first item.<br />
#### GetLanguageNames

```csharp
Dictionary<int, string> GetLanguageNames(int displayLanguageLcid, List<string> includeOnlyCultureNames, DropDownFirstItemType dropDownFirstItemType = None)
```
<p><b>Summary:</b> Gets the language names.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`dropDownFirstItemType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the drop down first item.<br />

<br />


## DayOfWeekHelper
DayOfWeekHelper.


```csharp
public static class DayOfWeekHelper
```

### Static Methods


#### GetDescription

```csharp
string GetDescription(DayOfWeek dayOfWeek, CultureInfo culture = null)
```
<p><b>Summary:</b> Gets the description.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`dayOfWeek`&nbsp;&nbsp;-&nbsp;&nbsp;The day of week.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`culture`&nbsp;&nbsp;-&nbsp;&nbsp;The culture.<br />
#### GetDescriptions

```csharp
Dictionary<DayOfWeek, string> GetDescriptions(CultureInfo culture = null)
```
<p><b>Summary:</b> Gets the descriptions.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`culture`&nbsp;&nbsp;-&nbsp;&nbsp;The culture.<br />
#### TryParseDescription

```csharp
bool TryParseDescription(string value, out DayOfWeek dayOfWeek, CultureInfo culture = null)
```
<p><b>Summary:</b> Tries the parse description.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`dayOfWeek`&nbsp;&nbsp;-&nbsp;&nbsp;The day of week.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`culture`&nbsp;&nbsp;-&nbsp;&nbsp;The culture.<br />

<br />


## DropDownFirstItemTypeHelper
Enumeration Helper: DropDownFirstItemTypeHelper.


```csharp
public static class DropDownFirstItemTypeHelper
```

### Static Methods


#### EnsureFirstItemType

```csharp
List<string> EnsureFirstItemType(List<string> list, DropDownFirstItemType dropDownFirstItemType)
```
<p><b>Summary:</b> Ensures the first type of the item.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`list`&nbsp;&nbsp;-&nbsp;&nbsp;The list.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`dropDownFirstItemType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the drop down first item.<br />
#### GetEnumGuid

```csharp
Guid GetEnumGuid(DropDownFirstItemType dropDownFirstItemType)
```
<p><b>Summary:</b> Gets the enumeration GUID.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`dropDownFirstItemType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the drop down first item.<br />
<p><b>Returns:</b> The .</p>

#### GetItemFromEnumGuid

```csharp
DropDownFirstItemType GetItemFromEnumGuid(Guid key)
```
<p><b>Summary:</b> Gets the item from enumeration GUID.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`key`&nbsp;&nbsp;-&nbsp;&nbsp;
            The key.
            <br />
<p><b>Returns:</b> The .</p>


<br />


## EnumHelper
Enumeration Helper: EnumHelper.


```csharp
public static class EnumHelper
```

### Static Methods


#### ConvertEnumToArray

```csharp
Array ConvertEnumToArray(Type enumType, DropDownFirstItemType dropDownFirstItemType = None, bool useDescriptionAttribute = False, bool includeDefault = True, SortDirectionType sortDirectionType = None, bool byFlagIncludeBase = True, bool byFlagIncludeCombined = True)
```
<p><b>Summary:</b> Converts the enum to array.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`enumType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the enum.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`dropDownFirstItemType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the drop down first item.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`useDescriptionAttribute`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [use description attribute].<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`includeDefault`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [include default].<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`sortDirectionType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the sort direction.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`byFlagIncludeBase`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [by flag include base].<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`byFlagIncludeCombined`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [by flag include combined].<br />
#### ConvertEnumToDictionary

```csharp
Dictionary<int, string> ConvertEnumToDictionary(Type enumType, DropDownFirstItemType dropDownFirstItemType = None, bool useDescriptionAttribute = False, bool includeDefault = True, SortDirectionType sortDirectionType = None, bool byFlagIncludeBase = True, bool byFlagIncludeCombined = True)
```
<p><b>Summary:</b> Converts the enum to dictionary.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`enumType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the enum.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`dropDownFirstItemType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the drop down first item.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`useDescriptionAttribute`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [use description attribute].<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`includeDefault`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [include default].<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`sortDirectionType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the sort direction.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`byFlagIncludeBase`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [by flag include base].<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`byFlagIncludeCombined`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [by flag include combined].<br />
#### ConvertEnumToDictionaryWithStringKey

```csharp
Dictionary<string, string> ConvertEnumToDictionaryWithStringKey(Type enumType, DropDownFirstItemType dropDownFirstItemType = None, bool useDescriptionAttribute = False, bool includeDefault = True, SortDirectionType sortDirectionType = None, bool byFlagIncludeBase = True, bool byFlagIncludeCombined = True)
```
<p><b>Summary:</b> Converts the enum to dictionary with string key.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`enumType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the enum.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`dropDownFirstItemType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the drop down first item.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`useDescriptionAttribute`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [use description attribute].<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`includeDefault`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [include default].<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`sortDirectionType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the sort direction.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`byFlagIncludeBase`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [by flag include base].<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`byFlagIncludeCombined`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [by flag include combined].<br />
#### GetDescription

```csharp
string GetDescription(Enum enumeration)
```
<p><b>Summary:</b> Gets the description.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`enumeration`&nbsp;&nbsp;-&nbsp;&nbsp;The enumeration.<br />
#### GetEnumValue

```csharp
T GetEnumValue(string value, bool ignoreCase = True)
```
<p><b>Summary:</b> Gets the enum value.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`ignoreCase`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [ignore case].<br />
<p><b>Returns:</b> If parsed successfully and defined as a valid enum value, the enum value is returned. Otherwise the default value is returned.</p>

#### GetName

```csharp
string GetName(Enum enumeration)
```
<p><b>Summary:</b> Gets the name.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`enumeration`&nbsp;&nbsp;-&nbsp;&nbsp;The enumeration.<br />
#### GetValueFromDescription

```csharp
T GetValueFromDescription(string description)
```
<p><b>Summary:</b> Gets the value from the description.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`description`&nbsp;&nbsp;-&nbsp;&nbsp;The description.<br />
<p><b>Returns:</b> The associated enumeration value.</p>


<br />


## MathHelper
The MathHelper module contains procedures used to preform math operations.


```csharp
public static class MathHelper
```

### Static Methods


#### Acos

```csharp
double Acos(double value)
```
<p><b>Summary:</b> Returns the angle whose cosine is the specified number.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;A number representing a cosine, where -1 ≤d≤ 1.<br />
#### Asin

```csharp
double Asin(double value)
```
<p><b>Summary:</b> Returns the angle whose sine is the specified number.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;A number representing a sine, where -1 ≤d≤ 1.<br />
#### Atan

```csharp
double Atan(double value)
```
<p><b>Summary:</b> Returns the angle whose tangent is the specified number.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;A number representing a tangent.<br />
#### CelsiusToFahrenheit

```csharp
double CelsiusToFahrenheit(double celsius)
```
<p><b>Summary:</b> Celsius to fahrenheit.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`celsius`&nbsp;&nbsp;-&nbsp;&nbsp;The celsius.<br />
#### Cos

```csharp
double Cos(double degrees)
```
<p><b>Summary:</b> Returns the cosine of the specified angle.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`degrees`&nbsp;&nbsp;-&nbsp;&nbsp;An angle, measured in degrees.<br />
#### DegreesToRadians

```csharp
double DegreesToRadians(double degrees)
```
<p><b>Summary:</b> This function converts degrees to radians.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`degrees`&nbsp;&nbsp;-&nbsp;&nbsp;An angle, measured in degrees.<br />
#### EnsureDegreesAreBetween0And360

```csharp
double EnsureDegreesAreBetween0And360(double degrees)
```
<p><b>Summary:</b> Returns the specified angle in the same angle between 0 and 360.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`degrees`&nbsp;&nbsp;-&nbsp;&nbsp;An angle, measured in degrees.<br />
#### EnsureDegreesAreBetween0And360

```csharp
Point2D EnsureDegreesAreBetween0And360(Point2D degrees)
```
<p><b>Summary:</b> Returns the specified angle in the same angle between 0 and 360.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`degrees`&nbsp;&nbsp;-&nbsp;&nbsp;An angle, measured in degrees.<br />
#### EnsureDegreesAreBetween0And360

```csharp
Point3D EnsureDegreesAreBetween0And360(Point3D degrees)
```
<p><b>Summary:</b> Returns the specified angle in the same angle between 0 and 360.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`degrees`&nbsp;&nbsp;-&nbsp;&nbsp;An angle, measured in degrees.<br />
#### FahrenheitToCelsius

```csharp
double FahrenheitToCelsius(double fahrenheit)
```
<p><b>Summary:</b> Fahrenheit to celsius.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`fahrenheit`&nbsp;&nbsp;-&nbsp;&nbsp;The fahrenheit.<br />
#### IsEquals

```csharp
bool IsEquals(double value1, double value2)
```
<p><b>Summary:</b> Determines whether the specified value1 is equals.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value1`&nbsp;&nbsp;-&nbsp;&nbsp;The value1.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value2`&nbsp;&nbsp;-&nbsp;&nbsp;The value2.<br />
<p><b>Returns:</b> true if the specified value1 is equals; otherwise, false.</p>

#### IsEqualToZero

```csharp
bool IsEqualToZero(double value)
```
<p><b>Summary:</b> Determines whether [is equal to zero] [the specified value].</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
<p><b>Returns:</b> true if [is equal to zero] [the specified value]; otherwise, false.</p>

#### Max

```csharp
int Max(int[] values)
```
<p><b>Summary:</b> Maxes the specified values.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`values`&nbsp;&nbsp;-&nbsp;&nbsp;The values.<br />
#### Max

```csharp
int Max(List<int> values)
```
<p><b>Summary:</b> Maxes the specified values.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`values`&nbsp;&nbsp;-&nbsp;&nbsp;The values.<br />
#### Max

```csharp
double Max(double[] values)
```
<p><b>Summary:</b> Maxes the specified values.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`values`&nbsp;&nbsp;-&nbsp;&nbsp;The values.<br />
#### Max

```csharp
double Max(List<double> values)
```
<p><b>Summary:</b> Maxes the specified values.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`values`&nbsp;&nbsp;-&nbsp;&nbsp;The values.<br />
#### Min

```csharp
int Min(int[] values)
```
<p><b>Summary:</b> Min the specified values.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`values`&nbsp;&nbsp;-&nbsp;&nbsp;The values.<br />
#### Min

```csharp
int Min(List<int> values)
```
<p><b>Summary:</b> Min the specified values.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`values`&nbsp;&nbsp;-&nbsp;&nbsp;The values.<br />
#### Min

```csharp
double Min(double[] values)
```
<p><b>Summary:</b> Min the specified values.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`values`&nbsp;&nbsp;-&nbsp;&nbsp;The values.<br />
#### Min

```csharp
double Min(List<double> values)
```
<p><b>Summary:</b> Min the specified values.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`values`&nbsp;&nbsp;-&nbsp;&nbsp;The values.<br />
#### Percentage

```csharp
double Percentage(double totalValue, double value, int digits = 2)
```
<p><b>Summary:</b> Percentages the specified total value.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`totalValue`&nbsp;&nbsp;-&nbsp;&nbsp;The total value.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`digits`&nbsp;&nbsp;-&nbsp;&nbsp;The digits.<br />
<p><b>Returns:</b> The calculated percentage.</p>

<b>Code usage:</b>

```csharp
double value = MathUtil.Percentage(totalValue, value);
```
<b>Code example:</b>

```csharp
double totalValue = 100;
double value = 10;
double procentage = MathUtil.Percentage(totalValue, value);
```
#### PercentageAsInteger

```csharp
int PercentageAsInteger(double totalValue, double value)
```
<p><b>Summary:</b> Percentages as integer.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`totalValue`&nbsp;&nbsp;-&nbsp;&nbsp;The total value.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
<p><b>Returns:</b> The calculated percentage.</p>

<b>Code usage:</b>

```csharp
int value = MathUtil.PercentageAsInteger(totalValue, value);
```
<b>Code example:</b>

```csharp
double totalValue = 100;
double value = 10;
int procentage = MathUtil.PercentageAsInteger(totalValue, value);
```
#### RadiansToDegrees

```csharp
double RadiansToDegrees(double radians)
```
<p><b>Summary:</b> This function converts radians to degrees.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`radians`&nbsp;&nbsp;-&nbsp;&nbsp;An angle, measured in radians.<br />
#### Sin

```csharp
double Sin(double degrees)
```
<p><b>Summary:</b> Returns the sine of the specified angle.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`degrees`&nbsp;&nbsp;-&nbsp;&nbsp;An angle, measured in degrees.<br />
#### Tan

```csharp
double Tan(double degrees)
```
<p><b>Summary:</b> Returns the tangent of the specified angle.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`degrees`&nbsp;&nbsp;-&nbsp;&nbsp;An angle, measured in degrees.<br />
#### TruncateToMaxPrecision

```csharp
double TruncateToMaxPrecision(double value, int decimalPrecision)
```
<p><b>Summary:</b> Truncates to maximum precision.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`decimalPrecision`&nbsp;&nbsp;-&nbsp;&nbsp;The decimal precision.<br />

<br />


## ReflectionHelper
ReflectionHelper.


```csharp
public static class ReflectionHelper
```

### Static Methods


#### SetPrivateField

```csharp
void SetPrivateField(object target, string fieldName, object value)
```
<p><b>Summary:</b> Sets the private field.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`target`&nbsp;&nbsp;-&nbsp;&nbsp;The target.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`fieldName`&nbsp;&nbsp;-&nbsp;&nbsp;Name of the field.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />

<br />


## RegionInfoHelper
RegionInfoHelper.


```csharp
public static class RegionInfoHelper
```

### Static Methods


#### GetAllRegionInfos

```csharp
List<RegionInfo> GetAllRegionInfos()
```
<p><b>Summary:</b> Gets all region infos.</p>

#### GetAllRegionInfosAsLcids

```csharp
List<int> GetAllRegionInfosAsLcids()
```
<p><b>Summary:</b> Gets all region infos as lcids.</p>

#### GetCultureInfoByIsoAlpha3

```csharp
CultureInfo GetCultureInfoByIsoAlpha3(string isoAlpha3Code)
```
<p><b>Summary:</b> Gets the culture information by iso alpha3.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`isoAlpha3Code`&nbsp;&nbsp;-&nbsp;&nbsp;The iso alpha3 code.<br />
#### GetLcidFromRegionInfo

```csharp
int GetLcidFromRegionInfo(RegionInfo regionInfo)
```
<p><b>Summary:</b> Gets the lcid from region information.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`regionInfo`&nbsp;&nbsp;-&nbsp;&nbsp;The region information.<br />
#### GetRegionInfoByIsoAlpha3

```csharp
RegionInfo GetRegionInfoByIsoAlpha3(string isoAlpha3Code)
```
<p><b>Summary:</b> Gets the region information by iso alpha3.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`isoAlpha3Code`&nbsp;&nbsp;-&nbsp;&nbsp;The iso alpha3 code.<br />
#### GetRegionInfoByLcid

```csharp
RegionInfo GetRegionInfoByLcid(int lcid)
```
<p><b>Summary:</b> Gets the region information by lcid.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`lcid`&nbsp;&nbsp;-&nbsp;&nbsp;The lcid.<br />

<br />


## SimpleTypeHelper
PrimitiveTypeHelper.


```csharp
public static class SimpleTypeHelper
```

### Static Fields


#### BeautifySimpleTypeArrayLookup

```csharp
Dictionary<Type, string> BeautifySimpleTypeArrayLookup
```
<p><b>Summary:</b> The beautify simple type array lookup.</p>

#### BeautifySimpleTypeLookup

```csharp
Dictionary<Type, string> BeautifySimpleTypeLookup
```
<p><b>Summary:</b> The beautify simple type lookup.</p>

#### PrimitiveTypes

```csharp
Type[] PrimitiveTypes
```
<p><b>Summary:</b> The primitive types.</p>

#### SimpleTypes

```csharp
Type[] SimpleTypes
```
<p><b>Summary:</b> The simple types.</p>

### Static Methods


#### GetBeautifyArrayTypeName

```csharp
string GetBeautifyArrayTypeName(Type type)
```
<p><b>Summary:</b> Gets the name of the beautify array type.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`type`&nbsp;&nbsp;-&nbsp;&nbsp;The type.<br />
#### GetBeautifyTypeName

```csharp
string GetBeautifyTypeName(Type type)
```
<p><b>Summary:</b> Gets the name of the beautify type.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`type`&nbsp;&nbsp;-&nbsp;&nbsp;The type.<br />
#### GetBeautifyTypeNameByRef

```csharp
string GetBeautifyTypeNameByRef(Type type)
```
<p><b>Summary:</b> Gets the beautify type name by reference.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`type`&nbsp;&nbsp;-&nbsp;&nbsp;The type.<br />

<br />


## ThreadHelper
ThreadHelper.


```csharp
public static class ThreadHelper
```

### Static Methods


#### GetParallelOptions

```csharp
ParallelOptions GetParallelOptions(int exemptProcessorCount = 2)
```
<p><b>Summary:</b> Gets the parallel options.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`exemptProcessorCount`&nbsp;&nbsp;-&nbsp;&nbsp;The exempt processor count.<br />
<hr /><div style='text-align: right'><i>Generated by MarkdownCodeDoc version 1.2</i></div>
