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

## AssemblyHelper
The AssemblyHelper module contains procedures used to preform assembly operations.

>```csharp
>public static class AssemblyHelper
>```

### Static Methods

#### GetAssemblyInformations
>```csharp
>AssemblyInformation[] GetAssemblyInformations()
>```
><b>Summary:</b> Gets the assembly informations.
>
><b>Returns:</b> The array of `Atc.Data.Models.AssemblyInformation`.
#### GetAssemblyInformationsByStartsWith
>```csharp
>AssemblyInformation[] GetAssemblyInformationsByStartsWith(string value)
>```
><b>Summary:</b> Gets the assembly informations by assembly fullname should start with value.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
>
><b>Returns:</b> The array of `Atc.Data.Models.AssemblyInformation`.
#### GetAssemblyInformationsBySystem
>```csharp
>AssemblyInformation[] GetAssemblyInformationsBySystem()
>```
><b>Summary:</b> Gets the assembly informations by system.
>
><b>Returns:</b> The array of `Atc.Data.Models.AssemblyInformation`.
#### GetProjectRootDirectory
>```csharp
>DirectoryInfo GetProjectRootDirectory()
>```
><b>Summary:</b> Retrieves the project root directory by searching upwards from the current assembly's base directory. The method looks for a directory containing a .csproj or .sln file, which is commonly found in the root of a C# project.
>
><b>Returns:</b> A `System.IO.DirectoryInfo` object representing the project root directory, or the assembly's base directory if the project root cannot be determined.
>
><b>Remarks:</b> This method starts at the current assembly's base directory and moves up the directory tree until it finds a directory containing at least one .csproj or .sln file. This directory is considered the project root. If no such directory is found, the method defaults to returning the base directory of the application domain. This approach allows the method to be more adaptable to various project structures without relying on a fixed directory depth. However, it assumes that the project root will contain at least one .csproj or .sln file.
#### GetSystemLocation
>```csharp
>string GetSystemLocation()
>```
><b>Summary:</b> Gets the system location.
>
><b>Returns:</b> System location.
#### GetSystemLocationPath
>```csharp
>string GetSystemLocationPath()
>```
><b>Summary:</b> Gets the system location path.
>
><b>Returns:</b> System location path.
#### GetSystemName
>```csharp
>string GetSystemName()
>```
><b>Summary:</b> Gets the system name.
>
><b>Returns:</b> System name.
#### GetSystemNameAsKebabCasing
>```csharp
>string GetSystemNameAsKebabCasing()
>```
><b>Summary:</b> Gets the system name as kebab casing.
>
><b>Returns:</b> System name as kebab casing.
#### GetSystemVersion
>```csharp
>Version GetSystemVersion()
>```
><b>Summary:</b> Gets the system version.
>
><b>Returns:</b> System version.
#### Load
>```csharp
>Assembly Load(FileInfo assemblyFile)
>```
><b>Summary:</b> Load the specified assembly file, with a reference to memory and not the specified file.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`assemblyFile`&nbsp;&nbsp;-&nbsp;&nbsp;The assembly file.<br />
>
><b>Returns:</b> The Assembly that is loaded.
>
><b>Remarks:</b> The assembly is never directly loaded, to avoid holding a instance as "assembly = Assembly.Load(file)" do.
#### ReadAsBytes
>```csharp
>byte[] ReadAsBytes(FileInfo assemblyFile)
>```
><b>Summary:</b> Read the specified assembly file into a byte array.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`assemblyFile`&nbsp;&nbsp;-&nbsp;&nbsp;The assembly file.<br />
>
><b>Returns:</b> The Assembly in a byte array.

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
#### ToStringWithPrefix
>```csharp
>string ToStringWithPrefix(byte[] bytes)
>```
><b>Summary:</b> Converts a byte array to its hexadecimal string representation with a '0x' prefix for each byte and separated with ', '. <code>{ 0x1A, 0x2B, 0x3C }.ToStringWithPrefix() // Gives: "0x1A, 0x2B, 0x3C"</code>
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`bytes`&nbsp;&nbsp;-&nbsp;&nbsp;The byte array to be converted.<br />
>
><b>Returns:</b> A string representation of the byte array in hexadecimal format, prefixed with '0x' for each byte and separated with ', '.
>
><b>Code example:</b>
>```csharp
>byte[] exampleBytes = { 0x1A, 0x2B, 0x3C };
>string hex = ByteHelper.ToStringWithPrefix(exampleBytes);
>Console.WriteLine(hex); // Outputs: 0x1A, 0x2B, 0x3C
>```

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
#### GetCulturesForLanguages
>```csharp
>List<Culture> GetCulturesForLanguages()
>```
><b>Summary:</b> Gets the cultures for languages.
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
#### GetSupportedCultures
>```csharp
>IList<Culture> GetSupportedCultures(int displayLanguageLcid = 1033)
>```

<br />

## CultureInfoHelper

>```csharp
>public static class CultureInfoHelper
>```

### Static Methods

#### GetCulturesFromNames
>```csharp
>IList<CultureInfo> GetCulturesFromNames(IEnumerable<string> cultureNames)
>```

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

## DateTimeHelper
DateTimeHelper.

>```csharp
>public static class DateTimeHelper
>```

### Static Methods

#### TryParseShortDateUsingCurrentUiCulture
>```csharp
>bool TryParseShortDateUsingCurrentUiCulture(string value, out DateTime result)
>```
><b>Summary:</b> Tries to parse a string representation of a short date using the current UI culture's date format.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The string to parse.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`result`&nbsp;&nbsp;-&nbsp;&nbsp;
            When this method returns, contains the parsed DateTime,
            if the parse operation was successful; otherwise, contains the default DateTime.
            <br />
>
><b>Returns:</b> `true` if the parsing was successful; otherwise, `false`.
#### TryParseShortDateUsingSpecificCulture
>```csharp
>bool TryParseShortDateUsingSpecificCulture(string value, CultureInfo cultureInfo, out DateTime result)
>```
><b>Summary:</b> Tries to parse a string representation of a short date using a specific culture's date format.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The string to parse.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`cultureInfo`&nbsp;&nbsp;-&nbsp;&nbsp;The culture info to use for parsing.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`result`&nbsp;&nbsp;-&nbsp;&nbsp;
            When this method returns, contains the parsed DateTime,
            if the parse operation was successful; otherwise, contains the default DateTime.
            <br />
>
><b>Returns:</b> `true` if the parsing was successful; otherwise, `false`.
#### TryParseShortTimeUsingCurrentUiCulture
>```csharp
>bool TryParseShortTimeUsingCurrentUiCulture(string value, out DateTime result)
>```
><b>Summary:</b> Tries to parse a string representation of a short time using the current UI culture's time format (12-hour or 24-hour).
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The string to parse.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`result`&nbsp;&nbsp;-&nbsp;&nbsp;
            When this method returns, contains the parsed DateTime,
            if the parse operation was successful; otherwise, contains the default DateTime.
            <br />
>
><b>Returns:</b> `true` if the parsing was successful; otherwise, `false`.
#### TryParseShortTimeUsingCurrentUiCultureUtc
>```csharp
>bool TryParseShortTimeUsingCurrentUiCultureUtc(string value, out DateTime result)
>```
><b>Summary:</b> Tries to parse a string representation of a short UTC time using the current UI culture's time format (12-hour or 24-hour).
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The string to parse.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`result`&nbsp;&nbsp;-&nbsp;&nbsp;
            When this method returns, contains the parsed DateTime,
            if the parse operation was successful; otherwise, contains the default DateTime.
            <br />
>
><b>Returns:</b> `true` if the parsing was successful; otherwise, `false`.
#### TryParseShortTimeUsingSpecificCulture
>```csharp
>bool TryParseShortTimeUsingSpecificCulture(string value, CultureInfo cultureInfo, out DateTime result)
>```
><b>Summary:</b> Tries to parse a string representation of a short time using a specific culture's time format (12-hour or 24-hour).
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The string to parse.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`cultureInfo`&nbsp;&nbsp;-&nbsp;&nbsp;The culture info to use for parsing.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`result`&nbsp;&nbsp;-&nbsp;&nbsp;
            When this method returns, contains the parsed DateTime,
            if the parse operation was successful; otherwise, contains the default DateTime.
            <br />
>
><b>Returns:</b> `true` if the parsing was successful; otherwise, `false`.
#### TryParseShortTimeUsingSpecificCultureUtc
>```csharp
>bool TryParseShortTimeUsingSpecificCultureUtc(string value, CultureInfo cultureInfo, out DateTime result)
>```
><b>Summary:</b> Tries to parse a string representation of a short UTC time using a specific culture's time format (12-hour or 24-hour).
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The string to parse.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`cultureInfo`&nbsp;&nbsp;-&nbsp;&nbsp;The culture info to use for parsing.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`result`&nbsp;&nbsp;-&nbsp;&nbsp;
            When this method returns, contains the parsed DateTime in UTC,
            if the parse operation was successful; otherwise, contains the default DateTime.
            <br />
>
><b>Returns:</b> `true` if the parsing was successful; otherwise, `false`.
#### TryParseUsingCurrentUiCulture
>```csharp
>bool TryParseUsingCurrentUiCulture(string value, out DateTime result)
>```
><b>Summary:</b> Tries to parse a string representation of a `DateTime` using the current UI culture's date and time format.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The string to parse.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`result`&nbsp;&nbsp;-&nbsp;&nbsp;
            When this method returns, contains the parsed DateTime,
            if the parse operation was successful; otherwise, contains the default DateTime.
            <br />
>
><b>Returns:</b> `true` if the parsing was successful; otherwise, `false`.
#### TryParseUsingSpecificCulture
>```csharp
>bool TryParseUsingSpecificCulture(string value, CultureInfo cultureInfo, out DateTime result)
>```
><b>Summary:</b> Tries to parse a string representation of a DateTime using a specific culture's date and time format.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The string to parse.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`cultureInfo`&nbsp;&nbsp;-&nbsp;&nbsp;The culture info to use for parsing.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`result`&nbsp;&nbsp;-&nbsp;&nbsp;
            When this method returns, contains the parsed DateTime,
            if the parse operation was successful; otherwise, contains the default DateTime.
            <br />
>
><b>Returns:</b> `true` if the parsing was successful; otherwise, `false`.

<br />

## DateTimeOffsetHelper
DateTimeOffsetHelper.

>```csharp
>public static class DateTimeOffsetHelper
>```

### Static Methods

#### TryParseShortDateUsingCurrentUiCulture
>```csharp
>bool TryParseShortDateUsingCurrentUiCulture(string value, out DateTime result)
>```
><b>Summary:</b> Tries to parse a string representation of a short date using the current UI culture's date format.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The string to parse.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`result`&nbsp;&nbsp;-&nbsp;&nbsp;
            When this method returns, contains the parsed DateTimeOffset,
            if the parse operation was successful; otherwise, contains the default DateTimeOffset.
            <br />
>
><b>Returns:</b> `true` if the parsing was successful; otherwise, `false`.
#### TryParseShortTimeUsingCurrentUiCulture
>```csharp
>bool TryParseShortTimeUsingCurrentUiCulture(string value, out DateTime result)
>```
><b>Summary:</b> Tries to parse a string representation of a short time using the current UI culture's time format (12-hour or 24-hour).
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The string to parse.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`result`&nbsp;&nbsp;-&nbsp;&nbsp;
            When this method returns, contains the parsed DateTimeOffset,
            if the parse operation was successful; otherwise, contains the default DateTimeOffset.
            <br />
>
><b>Returns:</b> `true` if the parsing was successful; otherwise, `false`.
#### TryParseShortTimeUsingCurrentUiCultureUtc
>```csharp
>bool TryParseShortTimeUsingCurrentUiCultureUtc(string value, out DateTime result)
>```
><b>Summary:</b> Tries to parse a string representation of a short UTC time using the current UI culture's time format (12-hour or 24-hour).
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The string to parse.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`result`&nbsp;&nbsp;-&nbsp;&nbsp;
            When this method returns, contains the parsed DateTimeOffset,
            if the parse operation was successful; otherwise, contains the default DateTimeOffset.
            <br />
>
><b>Returns:</b> `true` if the parsing was successful; otherwise, `false`.
#### TryParseUsingCurrentUiCulture
>```csharp
>bool TryParseUsingCurrentUiCulture(string value, out DateTime result)
>```
><b>Summary:</b> Tries to parse a string representation of a `DateTimeOffset` using the current UI culture's date and time format.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The string to parse.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`result`&nbsp;&nbsp;-&nbsp;&nbsp;
            When this method returns, contains the parsed DateTimeOffset,
            if the parse operation was successful; otherwise, contains the default DateTimeOffset.
            <br />
>
><b>Returns:</b> `true` if the parsing was successful; otherwise, `false`.

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

## DirectoryInfoHelper

>```csharp
>public static class DirectoryInfoHelper
>```

### Static Methods

#### GetTempPath
>```csharp
>DirectoryInfo GetTempPath()
>```
#### GetTempPathWithSubFolder
>```csharp
>DirectoryInfo GetTempPathWithSubFolder(string folderName)
>```

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
#### GetIndividualValues
>```csharp
>IList<T> GetIndividualValues(bool includeDefault = True)
>```
><b>Summary:</b> Retrieves individual flag values from a enum.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`includeDefault`&nbsp;&nbsp;-&nbsp;&nbsp;Includes the default '0' value if true.<br />
>
><b>Returns:</b> A list of individual values.
#### GetIndividualValuesByCombinedValueFromFlagEnum
>```csharp
>IList<T> GetIndividualValuesByCombinedValueFromFlagEnum(T combinedValue, bool includeDefault = True)
>```
><b>Summary:</b> Extracts and returns individual flags from a combined flag value.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`combinedValue`&nbsp;&nbsp;-&nbsp;&nbsp;The aggregate value of flags.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`includeDefault`&nbsp;&nbsp;-&nbsp;&nbsp;Includes the default '0' value if true.<br />
>
><b>Returns:</b> A list of matching individual flags.
#### GetIndividualValuesFromEnum
>```csharp
>IList<T> GetIndividualValuesFromEnum(bool includeDefault = True)
>```
><b>Summary:</b> Retrieves values from a regular (non-flag) enum.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`includeDefault`&nbsp;&nbsp;-&nbsp;&nbsp;Includes the default '0' value if true.<br />
>
><b>Returns:</b> A list of enum values.
#### GetIndividualValuesFromFlagEnum
>```csharp
>IList<T> GetIndividualValuesFromFlagEnum(bool includeDefault = True)
>```
><b>Summary:</b> Retrieves individual flag values from a flag-based enum.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`includeDefault`&nbsp;&nbsp;-&nbsp;&nbsp;Includes the default '0' value if true.<br />
>
><b>Returns:</b> A list of individual flag values.
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

#### GetFiles
>```csharp
>FileInfo[] GetFiles(string path, string searchPattern = *.*, SearchOption searchOption = AllDirectories)
>```
><b>Summary:</b> Gets the files as GetFiles, but skip files and folders with unauthorized access.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`path`&nbsp;&nbsp;-&nbsp;&nbsp;The directory.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`searchPattern`&nbsp;&nbsp;-&nbsp;&nbsp;The search pattern.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`searchOption`&nbsp;&nbsp;-&nbsp;&nbsp;The search option.<br />
#### GetFiles
>```csharp
>FileInfo[] GetFiles(DirectoryInfo path, string searchPattern = *.*, SearchOption searchOption = AllDirectories)
>```
><b>Summary:</b> Gets the files as GetFiles, but skip files and folders with unauthorized access.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`path`&nbsp;&nbsp;-&nbsp;&nbsp;The directory.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`searchPattern`&nbsp;&nbsp;-&nbsp;&nbsp;The search pattern.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`searchOption`&nbsp;&nbsp;-&nbsp;&nbsp;The search option.<br />
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
#### ReadToByteArray
>```csharp
>byte[] ReadToByteArray(FileInfo fileInfo)
>```
><b>Summary:</b> Reads to byte array.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`fileInfo`&nbsp;&nbsp;-&nbsp;&nbsp;The file information.<br />
>
><b>Returns:</b> Return a byte array from the file
#### ReadToByteArrayAsync
>```csharp
>Task<byte[]> ReadToByteArrayAsync(FileInfo fileInfo, CancellationToken cancellationToken = null)
>```
><b>Summary:</b> Reads to byte array.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`fileInfo`&nbsp;&nbsp;-&nbsp;&nbsp;The file information.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`cancellationToken`&nbsp;&nbsp;-&nbsp;&nbsp;The cancellation token.<br />
>
><b>Returns:</b> Return a byte array from the file
#### ReadToMemoryStream
>```csharp
>MemoryStream ReadToMemoryStream(FileInfo fileInfo)
>```
><b>Summary:</b> Reads to `System.IO.MemoryStream`.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`fileInfo`&nbsp;&nbsp;-&nbsp;&nbsp;The file information.<br />
>
><b>Returns:</b> Return a `System.IO.MemoryStream` from the file
#### ReadToMemoryStreamAsync
>```csharp
>Task<MemoryStream> ReadToMemoryStreamAsync(FileInfo fileInfo, CancellationToken cancellationToken = null)
>```
><b>Summary:</b> Reads to `System.IO.MemoryStream`.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`fileInfo`&nbsp;&nbsp;-&nbsp;&nbsp;The file information.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`cancellationToken`&nbsp;&nbsp;-&nbsp;&nbsp;The cancellation token.<br />
>
><b>Returns:</b> Return a `System.IO.MemoryStream` from the file
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

## InternetBrowserHelper

>```csharp
>public static class InternetBrowserHelper
>```

### Static Methods

#### CloseMainWindowOnAllRunningInternetBrowsers
>```csharp
>void CloseMainWindowOnAllRunningInternetBrowsers()
>```
#### CloseMainWindowOnRunningBraveInstances
>```csharp
>void CloseMainWindowOnRunningBraveInstances()
>```
#### CloseMainWindowOnRunningFirefoxInstances
>```csharp
>void CloseMainWindowOnRunningFirefoxInstances()
>```
#### CloseMainWindowOnRunningGhostBrowserInstances
>```csharp
>void CloseMainWindowOnRunningGhostBrowserInstances()
>```
#### CloseMainWindowOnRunningGoogleChromeInstances
>```csharp
>void CloseMainWindowOnRunningGoogleChromeInstances()
>```
#### CloseMainWindowOnRunningMicrosoftEdgeInstances
>```csharp
>void CloseMainWindowOnRunningMicrosoftEdgeInstances()
>```
#### CloseMainWindowOnRunningMicrosoftInternetExplorerInstances
>```csharp
>void CloseMainWindowOnRunningMicrosoftInternetExplorerInstances()
>```
#### CloseMainWindowOnRunningOperaInstances
>```csharp
>void CloseMainWindowOnRunningOperaInstances()
>```
#### CloseMainWindowOnRunningSafariInstances
>```csharp
>void CloseMainWindowOnRunningSafariInstances()
>```
#### GetRunningInternetBrowsers
>```csharp
>IList<string> GetRunningInternetBrowsers()
>```
#### IsBraveRunning
>```csharp
>bool IsBraveRunning()
>```
#### IsFirefoxRunning
>```csharp
>bool IsFirefoxRunning()
>```
#### IsGhostBrowserRunning
>```csharp
>bool IsGhostBrowserRunning()
>```
#### IsGoogleChromeRunning
>```csharp
>bool IsGoogleChromeRunning()
>```
#### IsMicrosoftEdgeRunning
>```csharp
>bool IsMicrosoftEdgeRunning()
>```
#### IsMicrosoftInternetExplorerRunning
>```csharp
>bool IsMicrosoftInternetExplorerRunning()
>```
#### IsOperaRunning
>```csharp
>bool IsOperaRunning()
>```
#### IsSafariRunning
>```csharp
>bool IsSafariRunning()
>```
#### KillAllRunningInternetBrowsers
>```csharp
>void KillAllRunningInternetBrowsers()
>```
#### KillRunningBraveInstances
>```csharp
>void KillRunningBraveInstances()
>```
#### KillRunningFirefoxInstances
>```csharp
>void KillRunningFirefoxInstances()
>```
#### KillRunningGhostBrowserInstances
>```csharp
>void KillRunningGhostBrowserInstances()
>```
#### KillRunningGoogleChromeInstances
>```csharp
>void KillRunningGoogleChromeInstances()
>```
#### KillRunningMicrosoftEdgeInstances
>```csharp
>void KillRunningMicrosoftEdgeInstances()
>```
#### KillRunningMicrosoftInternetExplorerInstances
>```csharp
>void KillRunningMicrosoftInternetExplorerInstances()
>```
#### KillRunningOperaInstances
>```csharp
>void KillRunningOperaInstances()
>```
#### KillRunningSafariInstances
>```csharp
>void KillRunningSafariInstances()
>```
#### OpenUrl
>```csharp
>bool OpenUrl(string url)
>```
><b>Summary:</b> Open the given url in the default browser on the machine.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`url`&nbsp;&nbsp;-&nbsp;&nbsp;The URL.<br />
>
><b>Returns:</b> `true` if the url is started in a browser; otherwise, `false`.
>
><b>Remarks:</b> Only url with the http or https protocol is supported.
#### OpenUrl
>```csharp
>bool OpenUrl(Uri uri)
>```
><b>Summary:</b> Open the given url in the default browser on the machine.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`url`&nbsp;&nbsp;-&nbsp;&nbsp;The URL.<br />
>
><b>Returns:</b> `true` if the url is started in a browser; otherwise, `false`.
>
><b>Remarks:</b> Only url with the http or https protocol is supported.

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
>double Percentage(double totalValue, double value, int digits = 2, bool limit0To100 = False)
>```
><b>Summary:</b> Percentages the specified total value.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`totalValue`&nbsp;&nbsp;-&nbsp;&nbsp;The total value.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`digits`&nbsp;&nbsp;-&nbsp;&nbsp;The digits.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`limit0To100`&nbsp;&nbsp;-&nbsp;&nbsp;If set, the calculated percentage will be round up/down to min 0 or max 100.<br />
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

## NumberHelper

>```csharp
>public static class NumberHelper
>```

### Static Methods

#### IsDecimal
>```csharp
>bool IsDecimal(string value)
>```
#### IsDecimal
>```csharp
>bool IsDecimal(string value, bool useUiCulture)
>```
#### IsDecimal
>```csharp
>bool IsDecimal(string value, CultureInfo cultureInfo)
>```
#### IsDouble
>```csharp
>bool IsDouble(string value)
>```
#### IsDouble
>```csharp
>bool IsDouble(string value, bool useUiCulture)
>```
#### IsDouble
>```csharp
>bool IsDouble(string value, CultureInfo cultureInfo)
>```
#### IsFloat
>```csharp
>bool IsFloat(string value)
>```
#### IsFloat
>```csharp
>bool IsFloat(string value, bool useUiCulture)
>```
#### IsFloat
>```csharp
>bool IsFloat(string value, CultureInfo cultureInfo)
>```
#### IsInt
>```csharp
>bool IsInt(string value)
>```
#### IsNumber
>```csharp
>bool IsNumber(string value)
>```
#### IsNumber
>```csharp
>bool IsNumber(string value, bool useUiCulture)
>```
#### IsNumber
>```csharp
>bool IsNumber(string value, CultureInfo cultureInfo)
>```
#### ParseToDecimal
>```csharp
>decimal ParseToDecimal(string value)
>```
#### ParseToDecimal
>```csharp
>decimal ParseToDecimal(string value, bool useUiCulture)
>```
#### ParseToDecimal
>```csharp
>decimal ParseToDecimal(string value, CultureInfo cultureInfo)
>```
#### ParseToDouble
>```csharp
>double ParseToDouble(string value)
>```
#### ParseToDouble
>```csharp
>double ParseToDouble(string value, bool useUiCulture)
>```
#### ParseToDouble
>```csharp
>double ParseToDouble(string value, CultureInfo cultureInfo)
>```
#### ParseToFloat
>```csharp
>float ParseToFloat(string value)
>```
#### ParseToFloat
>```csharp
>float ParseToFloat(string value, bool useUiCulture)
>```
#### ParseToFloat
>```csharp
>float ParseToFloat(string value, CultureInfo cultureInfo)
>```
#### ParseToInt
>```csharp
>int ParseToInt(string value)
>```
#### TryParseToDecimal
>```csharp
>bool TryParseToDecimal(string value, out decimal result)
>```
#### TryParseToDecimal
>```csharp
>bool TryParseToDecimal(string value, bool useUiCulture, out decimal result)
>```
#### TryParseToDecimal
>```csharp
>bool TryParseToDecimal(string value, CultureInfo cultureInfo, out decimal result)
>```
#### TryParseToDouble
>```csharp
>bool TryParseToDouble(string value, out double result)
>```
#### TryParseToDouble
>```csharp
>bool TryParseToDouble(string value, bool useUiCulture, out double result)
>```
#### TryParseToDouble
>```csharp
>bool TryParseToDouble(string value, CultureInfo cultureInfo, out double result)
>```
#### TryParseToFloat
>```csharp
>bool TryParseToFloat(string value, out float result)
>```
#### TryParseToFloat
>```csharp
>bool TryParseToFloat(string value, bool useUiCulture, out float result)
>```
#### TryParseToFloat
>```csharp
>bool TryParseToFloat(string value, CultureInfo cultureInfo, out float result)
>```
#### TryParseToInt
>```csharp
>bool TryParseToInt(string value, out int result)
>```

<br />

## ProcessHelper

>```csharp
>public static class ProcessHelper
>```

### Static Methods

#### Execute
>```csharp
>Task<ValueTuple<bool, string>> Execute(FileInfo fileInfo, string arguments, bool runAsAdministrator = False, ushort timeoutInSec = 30, CancellationToken cancellationToken = null)
>```
#### Execute
>```csharp
>Task<ValueTuple<bool, string>> Execute(DirectoryInfo workingDirectory, FileInfo fileInfo, string arguments, bool runAsAdministrator = False, ushort timeoutInSec = 30, CancellationToken cancellationToken = null)
>```
#### ExecuteAndIgnoreOutput
>```csharp
>Task<bool> ExecuteAndIgnoreOutput(FileInfo fileInfo, string arguments, bool runAsAdministrator = False, ushort timeoutInSec = 30, CancellationToken cancellationToken = null)
>```
#### ExecuteAndIgnoreOutput
>```csharp
>Task<bool> ExecuteAndIgnoreOutput(DirectoryInfo workingDirectory, FileInfo fileInfo, string arguments, bool runAsAdministrator = False, ushort timeoutInSec = 30, CancellationToken cancellationToken = null)
>```
#### ExecutePrompt
>```csharp
>Task<ValueTuple<bool, string>> ExecutePrompt(DirectoryInfo workingDirectory, FileInfo fileInfo, string arguments, string[] inputLines, bool runAsAdministrator = False, ushort timeoutInSec = 1, CancellationToken cancellationToken = null)
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

## StackTraceHelper
Provides utility methods for working with stack traces.

>```csharp
>public static class StackTraceHelper
>```

### Static Methods

#### ContainsConstructor
>```csharp
>bool ContainsConstructor()
>```
><b>Summary:</b> Checks if the current stack trace contains a constructor call.
>
><b>Returns:</b> True if a constructor call is found; otherwise, false.
#### ContainsConstructor
>```csharp
>bool ContainsConstructor(int drillDownFrameMax)
>```
><b>Summary:</b> Checks if the current stack trace contains a constructor call.
>
><b>Returns:</b> True if a constructor call is found; otherwise, false.
#### ContainsPropertyGetterName
>```csharp
>bool ContainsPropertyGetterName(string propertyName)
>```
><b>Summary:</b> Checks if the current stack trace contains a property getter call for a specified property name.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`propertyName`&nbsp;&nbsp;-&nbsp;&nbsp;The name of the property to check.<br />
>
><b>Returns:</b> True if a getter call is found for the specified property; otherwise, false.
#### ContainsPropertyGetterName
>```csharp
>bool ContainsPropertyGetterName(string propertyName, int drillDownFrameMax)
>```
><b>Summary:</b> Checks if the current stack trace contains a property getter call for a specified property name.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`propertyName`&nbsp;&nbsp;-&nbsp;&nbsp;The name of the property to check.<br />
>
><b>Returns:</b> True if a getter call is found for the specified property; otherwise, false.
#### ContainsPropertyName
>```csharp
>bool ContainsPropertyName(string propertyName)
>```
><b>Summary:</b> Checks if the current stack trace contains a property call for a specified property name.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`propertyName`&nbsp;&nbsp;-&nbsp;&nbsp;The name of the property to check.<br />
>
><b>Returns:</b> True if a call is found for the specified property; otherwise, false.
#### ContainsPropertyName
>```csharp
>bool ContainsPropertyName(string propertyName, int drillDownFrameMax)
>```
><b>Summary:</b> Checks if the current stack trace contains a property call for a specified property name.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`propertyName`&nbsp;&nbsp;-&nbsp;&nbsp;The name of the property to check.<br />
>
><b>Returns:</b> True if a call is found for the specified property; otherwise, false.
#### ContainsPropertySetterName
>```csharp
>bool ContainsPropertySetterName(string propertyName)
>```
><b>Summary:</b> Checks if the current stack trace contains a property setter call for a specified property name.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`propertyName`&nbsp;&nbsp;-&nbsp;&nbsp;The name of the property to check.<br />
>
><b>Returns:</b> True if a setter call is found for the specified property; otherwise, false.
#### ContainsPropertySetterName
>```csharp
>bool ContainsPropertySetterName(string propertyName, int drillDownFrameMax)
>```
><b>Summary:</b> Checks if the current stack trace contains a property setter call for a specified property name.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`propertyName`&nbsp;&nbsp;-&nbsp;&nbsp;The name of the property to check.<br />
>
><b>Returns:</b> True if a setter call is found for the specified property; otherwise, false.

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
#### FireAndForget
>```csharp
>void FireAndForget(Action action)
>```
><b>Summary:</b> Executes the provided action on a background thread, ignoring its completion status. This method is intended for fire-and-forget scenarios where the action is non-critical and does not need to be awaited or monitored.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`action`&nbsp;&nbsp;-&nbsp;&nbsp;The action to execute asynchronously.<br />
#### FireAndForget
>```csharp
>void FireAndForget(Task task)
>```
><b>Summary:</b> Executes the provided action on a background thread, ignoring its completion status. This method is intended for fire-and-forget scenarios where the action is non-critical and does not need to be awaited or monitored.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`action`&nbsp;&nbsp;-&nbsp;&nbsp;The action to execute asynchronously.<br />
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

<br />

## VersionHelper
Provides utility methods for comparing and handling version strings and Version objects.

>```csharp
>public static class VersionHelper
>```

### Static Methods

#### IsDefault
>```csharp
>bool IsDefault(Version sourceVersion, Version destinationVersion)
>```
><b>Summary:</b> Determines whether both source and destination versions are the default version ("1.0.0.0").
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`sourceVersion`&nbsp;&nbsp;-&nbsp;&nbsp;The source version as a Version object.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`destinationVersion`&nbsp;&nbsp;-&nbsp;&nbsp;The destination version as a Version object.<br />
>
><b>Returns:</b> True if both versions are "1.0.0.0"; otherwise, false.
#### IsSourceNewerThanDestination
>```csharp
>bool IsSourceNewerThanDestination(string sourceVersion, string destinationVersion)
>```
><b>Summary:</b> Compares two version strings to determine if the source version is newer than the destination version.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`sourceVersion`&nbsp;&nbsp;-&nbsp;&nbsp;The source version as a string.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`destinationVersion`&nbsp;&nbsp;-&nbsp;&nbsp;The destination version as a string.<br />
>
><b>Returns:</b> True if the source version is newer than the destination version; otherwise, false.
>
><b>Remarks:</b> If either version string is null, or if they are equal, the method returns false. If the version strings cannot be parsed into System.Version, a lexical comparison is performed.
#### IsSourceNewerThanDestination
>```csharp
>bool IsSourceNewerThanDestination(Version sourceVersion, Version destinationVersion)
>```
><b>Summary:</b> Compares two version strings to determine if the source version is newer than the destination version.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`sourceVersion`&nbsp;&nbsp;-&nbsp;&nbsp;The source version as a string.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`destinationVersion`&nbsp;&nbsp;-&nbsp;&nbsp;The destination version as a string.<br />
>
><b>Returns:</b> True if the source version is newer than the destination version; otherwise, false.
>
><b>Remarks:</b> If either version string is null, or if they are equal, the method returns false. If the version strings cannot be parsed into System.Version, a lexical comparison is performed.
<hr /><div style='text-align: right'><i>Generated by MarkdownCodeDoc version 1.2</i></div>
