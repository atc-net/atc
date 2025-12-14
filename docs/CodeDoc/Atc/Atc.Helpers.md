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
><b>Returns:</b> <see langword="true" /> if [is valid asin] [the specified asin]; otherwise, <see langword="false" />.
#### IsValidEan
>```csharp
>bool IsValidEan(string code)
>```
><b>Summary:</b> Validate European Article Number.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`code`&nbsp;&nbsp;-&nbsp;&nbsp;The code.<br />
>
><b>Returns:</b> <see langword="true" /> if [is valid ean] [the specified code]; otherwise, <see langword="false" />.
#### IsValidGtin
>```csharp
>bool IsValidGtin(string code)
>```
><b>Summary:</b> Validate Global Trade Item Number.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`code`&nbsp;&nbsp;-&nbsp;&nbsp;The code.<br />
>
><b>Returns:</b> <see langword="true" /> if [is valid gtin] [the specified code]; otherwise, <see langword="false" />.
#### IsValidIsbn10
>```csharp
>bool IsValidIsbn10(string isbn10)
>```
><b>Summary:</b> Validate ISBN10.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`isbn10`&nbsp;&nbsp;-&nbsp;&nbsp;The isbn10.<br />
>
><b>Returns:</b> <see langword="true" /> if [is valid isbn10] [the specified isbn10]; otherwise, <see langword="false" />.
#### IsValidIsbn13
>```csharp
>bool IsValidIsbn13(string isbn13)
>```
><b>Summary:</b> Validate ISBN13.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`isbn13`&nbsp;&nbsp;-&nbsp;&nbsp;The isbn13.<br />
>
><b>Returns:</b> <see langword="true" /> if [is valid isbn13] [the specified isbn13]; otherwise, <see langword="false" />.
#### IsValidIssn
>```csharp
>bool IsValidIssn(string code)
>```
><b>Summary:</b> Validate ISSN.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`code`&nbsp;&nbsp;-&nbsp;&nbsp;The code.<br />
>
><b>Returns:</b> <see langword="true" /> if [is valid issn] [the specified code]; otherwise, <see langword="false" />.
#### IsValidUpc
>```csharp
>bool IsValidUpc(string code)
>```
><b>Summary:</b> Validate a UPC.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`code`&nbsp;&nbsp;-&nbsp;&nbsp;The code.<br />
>
><b>Returns:</b> <see langword="true" /> if [is valid upc] [the specified code]; otherwise, <see langword="false" />.
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

## CSharpTypeHelper
Helper methods for C# type classification and checking.

>```csharp
>public static class CSharpTypeHelper
>```

### Static Methods

#### GetBaseType
>```csharp
>string GetBaseType(string typeName)
>```
><b>Summary:</b> Gets the base type by removing the nullable marker (?).
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`typeName`&nbsp;&nbsp;-&nbsp;&nbsp;The C# type name (e.g., "int?").<br />
>
><b>Returns:</b> The base type (e.g., "int").
#### IsBasicValueType
>```csharp
>bool IsBasicValueType(string typeName)
>```
><b>Summary:</b> Determines if a type is a basic value type (numeric + bool). Handles nullable types by checking the base type.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`typeName`&nbsp;&nbsp;-&nbsp;&nbsp;The C# type name (e.g., "int", "bool?").<br />
>
><b>Returns:</b> True if the type is a basic value type.
#### IsExtendedValueType
>```csharp
>bool IsExtendedValueType(string typeName)
>```
><b>Summary:</b> Determines if a type is an extended value type (includes Guid, DateTimeOffset). Handles nullable types by checking the base type.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`typeName`&nbsp;&nbsp;-&nbsp;&nbsp;The C# type name (e.g., "Guid", "DateTimeOffset?").<br />
>
><b>Returns:</b> True if the type is an extended value type.
#### IsNullable
>```csharp
>bool IsNullable(string typeName)
>```
><b>Summary:</b> Determines if a type is nullable (ends with ?).
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`typeName`&nbsp;&nbsp;-&nbsp;&nbsp;The C# type name.<br />
>
><b>Returns:</b> True if the type is nullable.
#### IsNumericType
>```csharp
>bool IsNumericType(string typeName)
>```
><b>Summary:</b> Determines if a type is a numeric type (int, long, float, double, decimal). Handles nullable types by checking the base type.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`typeName`&nbsp;&nbsp;-&nbsp;&nbsp;The C# type name (e.g., "int", "long?").<br />
>
><b>Returns:</b> True if the type is numeric.

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
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`dropDownFirstItemType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the dropdown first item.<br />
#### GetCountryNames
>```csharp
>Dictionary<int, string> GetCountryNames(int displayLanguageLcid, DropDownFirstItemType dropDownFirstItemType = None)
>```
><b>Summary:</b> Gets the country names.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`dropDownFirstItemType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the dropdown first item.<br />
#### GetCountryNames
>```csharp
>Dictionary<int, string> GetCountryNames(List<int> includeOnlyLcids, DropDownFirstItemType dropDownFirstItemType = None)
>```
><b>Summary:</b> Gets the country names.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`dropDownFirstItemType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the dropdown first item.<br />
#### GetCountryNames
>```csharp
>Dictionary<int, string> GetCountryNames(int displayLanguageLcid, List<int> includeOnlyLcids, DropDownFirstItemType dropDownFirstItemType = None)
>```
><b>Summary:</b> Gets the country names.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`dropDownFirstItemType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the dropdown first item.<br />
#### GetCountryNames
>```csharp
>Dictionary<int, string> GetCountryNames(List<string> includeOnlyCultureNames, DropDownFirstItemType dropDownFirstItemType = None)
>```
><b>Summary:</b> Gets the country names.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`dropDownFirstItemType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the dropdown first item.<br />
#### GetCountryNames
>```csharp
>Dictionary<int, string> GetCountryNames(int displayLanguageLcid, List<string> includeOnlyCultureNames, DropDownFirstItemType dropDownFirstItemType = None)
>```
><b>Summary:</b> Gets the country names.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`dropDownFirstItemType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the dropdown first item.<br />
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
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`dropDownFirstItemType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the dropdown first item.<br />
#### GetLanguageNames
>```csharp
>Dictionary<int, string> GetLanguageNames(int displayLanguageLcid, DropDownFirstItemType dropDownFirstItemType = None)
>```
><b>Summary:</b> Gets the language names.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`dropDownFirstItemType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the dropdown first item.<br />
#### GetLanguageNames
>```csharp
>Dictionary<int, string> GetLanguageNames(List<int> includeOnlyLcids, DropDownFirstItemType dropDownFirstItemType = None)
>```
><b>Summary:</b> Gets the language names.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`dropDownFirstItemType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the dropdown first item.<br />
#### GetLanguageNames
>```csharp
>Dictionary<int, string> GetLanguageNames(int displayLanguageLcid, List<int> includeOnlyLcids, DropDownFirstItemType dropDownFirstItemType = None)
>```
><b>Summary:</b> Gets the language names.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`dropDownFirstItemType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the dropdown first item.<br />
#### GetLanguageNames
>```csharp
>Dictionary<int, string> GetLanguageNames(List<string> includeOnlyCultureNames, DropDownFirstItemType dropDownFirstItemType = None)
>```
><b>Summary:</b> Gets the language names.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`dropDownFirstItemType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the dropdown first item.<br />
#### GetLanguageNames
>```csharp
>Dictionary<int, string> GetLanguageNames(int displayLanguageLcid, List<string> includeOnlyCultureNames, DropDownFirstItemType dropDownFirstItemType = None)
>```
><b>Summary:</b> Gets the language names.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`dropDownFirstItemType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the dropdown first item.<br />
#### GetSupportedCultures
>```csharp
>IList<Culture> GetSupportedCultures(int displayLanguageLcid = 1033)
>```

<br />

## CultureInfoHelper
Provides utility methods for working with `System.Globalization.CultureInfo` objects.

>```csharp
>public static class CultureInfoHelper
>```

### Static Methods

#### GetCulturesFromNames
>```csharp
>IList<CultureInfo> GetCulturesFromNames(IEnumerable<string> cultureNames)
>```
><b>Summary:</b> Creates a list of `System.Globalization.CultureInfo` objects from culture names or locale IDs (LCIDs).
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`cultureNames`&nbsp;&nbsp;-&nbsp;&nbsp;An enumerable collection of culture names (e.g., "en-US") or LCID strings (e.g., "1033").<br />
>
><b>Returns:</b> A list of `System.Globalization.CultureInfo` objects corresponding to the provided names or LCIDs.

<br />

## DataAnnotationHelper
Provides utility methods for validating objects using Data Annotations validation attributes.

>```csharp
>public static class DataAnnotationHelper
>```

### Static Methods

#### TryValidate
>```csharp
>bool TryValidate(T data, out IList`1 validationResults, bool validateAllProperties = True)
>```
><b>Summary:</b> Attempts to validate an object using Data Annotations and returns the validation results.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`data`&nbsp;&nbsp;-&nbsp;&nbsp;The object to validate.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`validationResults`&nbsp;&nbsp;-&nbsp;&nbsp;When this method returns, contains the validation results if validation failed; otherwise, an empty list.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`validateAllProperties`&nbsp;&nbsp;-&nbsp;&nbsp;If , validates all properties; otherwise, validates only required properties.<br />
>
><b>Returns:</b> <see langword="true" /> if validation succeeded; otherwise, <see langword="false" />.
#### TryValidateOutToString
>```csharp
>bool TryValidateOutToString(T data, out string validationMessage, bool validateAllProperties = True)
>```
><b>Summary:</b> Attempts to validate an object and returns a formatted string of validation error messages.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`data`&nbsp;&nbsp;-&nbsp;&nbsp;The object to validate.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`validationMessage`&nbsp;&nbsp;-&nbsp;&nbsp;When this method returns, contains a formatted string of error messages if validation failed; otherwise, an empty string.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`validateAllProperties`&nbsp;&nbsp;-&nbsp;&nbsp;If , validates all properties; otherwise, validates only required properties.<br />
>
><b>Returns:</b> <see langword="true" /> if validation succeeded; otherwise, <see langword="false" />.
#### TryValidateOutToValidationException
>```csharp
>bool TryValidateOutToValidationException(T data, out ValidationException validationException, bool validateAllProperties = True)
>```
><b>Summary:</b> Attempts to validate an object and returns a `System.ComponentModel.DataAnnotations.ValidationException` containing error messages if validation fails.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`data`&nbsp;&nbsp;-&nbsp;&nbsp;The object to validate.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`validationException`&nbsp;&nbsp;-&nbsp;&nbsp;When this method returns, contains a  with error messages if validation failed; otherwise, an empty exception.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`validateAllProperties`&nbsp;&nbsp;-&nbsp;&nbsp;If , validates all properties; otherwise, validates only required properties.<br />
>
><b>Returns:</b> <see langword="true" /> if validation succeeded; otherwise, <see langword="false" />.

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
><b>Returns:</b> <see langword="true" /> if the parsing was successful; otherwise, <see langword="false" />.
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
><b>Returns:</b> <see langword="true" /> if the parsing was successful; otherwise, <see langword="false" />.
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
><b>Returns:</b> <see langword="true" /> if the parsing was successful; otherwise, <see langword="false" />.
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
><b>Returns:</b> <see langword="true" /> if the parsing was successful; otherwise, <see langword="false" />.
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
><b>Returns:</b> <see langword="true" /> if the parsing was successful; otherwise, <see langword="false" />.
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
><b>Returns:</b> <see langword="true" /> if the parsing was successful; otherwise, <see langword="false" />.
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
><b>Returns:</b> <see langword="true" /> if the parsing was successful; otherwise, <see langword="false" />.
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
><b>Returns:</b> <see langword="true" /> if the parsing was successful; otherwise, <see langword="false" />.

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
><b>Returns:</b> <see langword="true" /> if the parsing was successful; otherwise, <see langword="false" />.
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
><b>Returns:</b> <see langword="true" /> if the parsing was successful; otherwise, <see langword="false" />.
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
><b>Returns:</b> <see langword="true" /> if the parsing was successful; otherwise, <see langword="false" />.
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
><b>Returns:</b> <see langword="true" /> if the parsing was successful; otherwise, <see langword="false" />.

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
Provides utility methods for working with `System.IO.DirectoryInfo` objects.

>```csharp
>public static class DirectoryInfoHelper
>```

### Static Methods

#### GetTempPath
>```csharp
>DirectoryInfo GetTempPath()
>```
><b>Summary:</b> Gets a `System.IO.DirectoryInfo` object representing the system's temporary folder.
>
><b>Returns:</b> A `System.IO.DirectoryInfo` for the temp path.
#### GetTempPathWithSubFolder
>```csharp
>DirectoryInfo GetTempPathWithSubFolder(string folderName)
>```
><b>Summary:</b> Gets a `System.IO.DirectoryInfo` object representing a subfolder within the system's temporary folder.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`folderName`&nbsp;&nbsp;-&nbsp;&nbsp;The name of the subfolder within the temp directory.<br />
>
><b>Returns:</b> A `System.IO.DirectoryInfo` for the temp path with the specified subfolder.

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
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`dropDownFirstItemType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the dropdown first item.<br />
#### GetEnumGuid
>```csharp
>Guid GetEnumGuid(DropDownFirstItemType dropDownFirstItemType)
>```
><b>Summary:</b> Gets the enumeration GUID.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`dropDownFirstItemType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the dropdown first item.<br />
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
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`dropDownFirstItemType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the dropdown first item.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`useDescriptionAttribute`&nbsp;&nbsp;-&nbsp;&nbsp;if set to  [use description attribute].<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`includeDefault`&nbsp;&nbsp;-&nbsp;&nbsp;if set to  [include default].<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`sortDirectionType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the sort direction.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`byFlagIncludeBase`&nbsp;&nbsp;-&nbsp;&nbsp;if set to  [by flag include base].<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`byFlagIncludeCombined`&nbsp;&nbsp;-&nbsp;&nbsp;if set to  [by flag include combined].<br />
#### ConvertEnumToDictionary
>```csharp
>Dictionary<int, string> ConvertEnumToDictionary(Type enumType, DropDownFirstItemType dropDownFirstItemType = None, bool useDescriptionAttribute = False, bool includeDefault = True, SortDirectionType sortDirectionType = None, bool byFlagIncludeBase = True, bool byFlagIncludeCombined = True)
>```
><b>Summary:</b> Converts the enum to dictionary.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`enumType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the enum.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`dropDownFirstItemType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the dropdown first item.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`useDescriptionAttribute`&nbsp;&nbsp;-&nbsp;&nbsp;if set to  [use description attribute].<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`includeDefault`&nbsp;&nbsp;-&nbsp;&nbsp;if set to  [include default].<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`sortDirectionType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the sort direction.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`byFlagIncludeBase`&nbsp;&nbsp;-&nbsp;&nbsp;if set to  [by flag include base].<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`byFlagIncludeCombined`&nbsp;&nbsp;-&nbsp;&nbsp;if set to  [by flag include combined].<br />
#### ConvertEnumToDictionaryWithStringKey
>```csharp
>Dictionary<string, string> ConvertEnumToDictionaryWithStringKey(Type enumType, DropDownFirstItemType dropDownFirstItemType = None, bool useDescriptionAttribute = False, bool includeDefault = True, SortDirectionType sortDirectionType = None, bool byFlagIncludeBase = True, bool byFlagIncludeCombined = True)
>```
><b>Summary:</b> Converts the enum to dictionary with string key.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`enumType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the enum.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`dropDownFirstItemType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the dropdown first item.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`useDescriptionAttribute`&nbsp;&nbsp;-&nbsp;&nbsp;if set to  [use description attribute].<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`includeDefault`&nbsp;&nbsp;-&nbsp;&nbsp;if set to  [include default].<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`sortDirectionType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the sort direction.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`byFlagIncludeBase`&nbsp;&nbsp;-&nbsp;&nbsp;if set to  [by flag include base].<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`byFlagIncludeCombined`&nbsp;&nbsp;-&nbsp;&nbsp;if set to  [by flag include combined].<br />
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
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`ignoreCase`&nbsp;&nbsp;-&nbsp;&nbsp;if set to  [ignore case].<br />
>
><b>Returns:</b> If parsed successfully and defined as a valid enum value, the enum value is returned; Otherwise the default value is returned.
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
File-related helper methods with safe wrappers around common I/O operations.
><b>Remarks:</b> - All text read/write operations use UTF-8 encoding. - Methods that read from a non-existing file return an empty result rather than throwing. - `Atc.Helpers.FileHelper.GetFiles(System.String,System.String,System.IO.SearchOption)` and its overload delegate to an extension method `GetFilesForAuthorizedAccess` that skips folders/files where access is unauthorized.
<b>Code example:</b>
>```csharp
> var dir = new DirectoryInfo(@"C:\Logs");
> var files = FileHelper.GetFiles(dir, "*.log");
>
> foreach (var file in files)
> {
>     var lines = await FileHelper.ReadAllTextToLinesAsync(file, cancellationToken);
>     // process lines…
> }
>
> var output = new FileInfo(@"C:\out\data.txt");
> await FileHelper.WriteAllTextAsync(output, "Hello", cancellationToken);
>```

>```csharp
>public static class FileHelper
>```

### Static Fields

#### LineBreaks
>```csharp
>string[] LineBreaks
>```
><b>Summary:</b> Line-break tokens recognized when splitting text into lines.
### Static Methods

#### GetFiles
>```csharp
>FileInfo[] GetFiles(string path, string searchPattern = *.*, SearchOption searchOption = AllDirectories)
>```
><b>Summary:</b> Gets files under `path` that match `searchPattern`, recursively if `searchOption` is `System.IO.SearchOption.AllDirectories`, skipping any files or directories where access is unauthorized.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`path`&nbsp;&nbsp;-&nbsp;&nbsp;The root directory path.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`searchPattern`&nbsp;&nbsp;-&nbsp;&nbsp;The search pattern. Default is *.*.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`searchOption`&nbsp;&nbsp;-&nbsp;&nbsp;
            The directory search option. Default is .
            <br />
>
><b>Returns:</b> Matching files with inaccessible paths skipped.
#### GetFiles
>```csharp
>FileInfo[] GetFiles(DirectoryInfo path, string searchPattern = *.*, SearchOption searchOption = AllDirectories)
>```
><b>Summary:</b> Gets files under `path` that match `searchPattern`, recursively if `searchOption` is `System.IO.SearchOption.AllDirectories`, skipping any files or directories where access is unauthorized.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`path`&nbsp;&nbsp;-&nbsp;&nbsp;The root directory path.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`searchPattern`&nbsp;&nbsp;-&nbsp;&nbsp;The search pattern. Default is *.*.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`searchOption`&nbsp;&nbsp;-&nbsp;&nbsp;
            The directory search option. Default is .
            <br />
>
><b>Returns:</b> Matching files with inaccessible paths skipped.
#### ReadAllText
>```csharp
>string ReadAllText(FileInfo fileInfo)
>```
><b>Summary:</b> Reads the entire file as UTF-8 text.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`fileInfo`&nbsp;&nbsp;-&nbsp;&nbsp;The file to read.<br />
>
><b>Returns:</b> The file contents. If the file does not exist, returns `System.String.Empty`.
#### ReadAllTextAsync
>```csharp
>Task<string> ReadAllTextAsync(FileInfo fileInfo, CancellationToken cancellationToken = null)
>```
><b>Summary:</b> Asynchronously reads the entire file as UTF-8 text.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`fileInfo`&nbsp;&nbsp;-&nbsp;&nbsp;The file to read.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`cancellationToken`&nbsp;&nbsp;-&nbsp;&nbsp;A token to cancel the operation.<br />
>
><b>Returns:</b> A task producing the file contents. If the file does not exist, the task returns `System.String.Empty`.
#### ReadAllTextToLines
>```csharp
>string[] ReadAllTextToLines(FileInfo fileInfo)
>```
><b>Summary:</b> Reads the entire file as UTF-8 text and splits it into lines, preserving empty lines and original line-breaks boundaries.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`fileInfo`&nbsp;&nbsp;-&nbsp;&nbsp;The file to read.<br />
>
><b>Returns:</b> An array of lines. If the file does not exist, returns `System.Array.Empty``1`.
#### ReadAllTextToLinesAsync
>```csharp
>Task<string[]> ReadAllTextToLinesAsync(FileInfo fileInfo, CancellationToken cancellationToken = null)
>```
><b>Summary:</b> Asynchronously reads the entire file as UTF-8 text and splits it into lines, preserving empty lines and original line-breaks boundaries.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`fileInfo`&nbsp;&nbsp;-&nbsp;&nbsp;The file to read.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`cancellationToken`&nbsp;&nbsp;-&nbsp;&nbsp;A token to cancel the operation.<br />
>
><b>Returns:</b> A task producing an array of lines. If the file does not exist, returns `System.Array.Empty``1`.
#### ReadToByteArray
>```csharp
>byte[] ReadToByteArray(FileInfo fileInfo)
>```
><b>Summary:</b> Reads the file into a byte array.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`fileInfo`&nbsp;&nbsp;-&nbsp;&nbsp;The file to read.<br />
>
><b>Returns:</b> The file contents as a byte array.
#### ReadToByteArrayAsync
>```csharp
>Task<byte[]> ReadToByteArrayAsync(FileInfo fileInfo, CancellationToken cancellationToken = null)
>```
><b>Summary:</b> Asynchronously reads the file into a byte array.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`fileInfo`&nbsp;&nbsp;-&nbsp;&nbsp;The file to read.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`cancellationToken`&nbsp;&nbsp;-&nbsp;&nbsp;A token to cancel the operation.<br />
>
><b>Returns:</b> A task producing the file contents as a byte array.
#### ReadToMemoryStream
>```csharp
>MemoryStream ReadToMemoryStream(FileInfo fileInfo)
>```
><b>Summary:</b> Reads the file into a `System.IO.MemoryStream`.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`fileInfo`&nbsp;&nbsp;-&nbsp;&nbsp;The file to read.<br />
>
><b>Returns:</b> A `System.IO.MemoryStream` containing the file contents.
#### ReadToMemoryStreamAsync
>```csharp
>Task<MemoryStream> ReadToMemoryStreamAsync(FileInfo fileInfo, CancellationToken cancellationToken = null)
>```
><b>Summary:</b> Asynchronously reads the file into a `System.IO.MemoryStream`.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`fileInfo`&nbsp;&nbsp;-&nbsp;&nbsp;The file to read.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`cancellationToken`&nbsp;&nbsp;-&nbsp;&nbsp;A token to cancel the operation.<br />
>
><b>Returns:</b> A task producing a `System.IO.MemoryStream` containing the file contents.
#### WriteAllText
>```csharp
>void WriteAllText(FileInfo fileInfo, string content)
>```
><b>Summary:</b> Writes `content` to `fileInfo` using UTF-8 encoding. Creates the file if it does not exist, and overwrites if it does.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`fileInfo`&nbsp;&nbsp;-&nbsp;&nbsp;The destination file.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`content`&nbsp;&nbsp;-&nbsp;&nbsp;The content to write.<br />
#### WriteAllTextAsync
>```csharp
>Task WriteAllTextAsync(FileInfo fileInfo, string content, CancellationToken cancellationToken = null)
>```
><b>Summary:</b> Asynchronously writes `content` to `fileInfo` using UTF-8 encoding. Creates the file if it does not exist, and overwrites if it does.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`fileInfo`&nbsp;&nbsp;-&nbsp;&nbsp;The destination file.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`content`&nbsp;&nbsp;-&nbsp;&nbsp;The content to write.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`cancellationToken`&nbsp;&nbsp;-&nbsp;&nbsp;A token to cancel the operation.<br />
>
><b>Returns:</b> A task that completes when the write has finished.
#### WriteModelToJsonFile
>```csharp
>void WriteModelToJsonFile(FileInfo fileInfo, T model)
>```
><b>Summary:</b> Writes `model` to `fileInfo` as JSON using default serializer options. Delegates to `Atc.Helpers.FileHelper`1.WriteModelToJsonFile(System.IO.FileInfo,`0)`.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`fileInfo`&nbsp;&nbsp;-&nbsp;&nbsp;The destination JSON file.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`model`&nbsp;&nbsp;-&nbsp;&nbsp;The model instance to serialize.<br />
#### WriteModelToJsonFile
>```csharp
>void WriteModelToJsonFile(FileInfo fileInfo, T model, JsonSerializerOptions serializeOptions)
>```
><b>Summary:</b> Writes `model` to `fileInfo` as JSON using default serializer options. Delegates to `Atc.Helpers.FileHelper`1.WriteModelToJsonFile(System.IO.FileInfo,`0)`.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`fileInfo`&nbsp;&nbsp;-&nbsp;&nbsp;The destination JSON file.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`model`&nbsp;&nbsp;-&nbsp;&nbsp;The model instance to serialize.<br />
#### WriteModelToJsonFile
>```csharp
>void WriteModelToJsonFile(Stream utf8Json, T model)
>```
><b>Summary:</b> Writes `model` to `fileInfo` as JSON using default serializer options. Delegates to `Atc.Helpers.FileHelper`1.WriteModelToJsonFile(System.IO.FileInfo,`0)`.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`fileInfo`&nbsp;&nbsp;-&nbsp;&nbsp;The destination JSON file.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`model`&nbsp;&nbsp;-&nbsp;&nbsp;The model instance to serialize.<br />
#### WriteModelToJsonFile
>```csharp
>void WriteModelToJsonFile(Stream utf8Json, T model, JsonSerializerOptions serializeOptions)
>```
><b>Summary:</b> Writes `model` to `fileInfo` as JSON using default serializer options. Delegates to `Atc.Helpers.FileHelper`1.WriteModelToJsonFile(System.IO.FileInfo,`0)`.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`fileInfo`&nbsp;&nbsp;-&nbsp;&nbsp;The destination JSON file.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`model`&nbsp;&nbsp;-&nbsp;&nbsp;The model instance to serialize.<br />
#### WriteModelToJsonFileAsync
>```csharp
>Task WriteModelToJsonFileAsync(FileInfo fileInfo, T model, CancellationToken cancellationToken = null)
>```
><b>Summary:</b> Asynchronously writes `model` to `fileInfo` as JSON using default serializer options. Delegates to `Atc.Helpers.FileHelper`1.WriteModelToJsonFileAsync(System.IO.FileInfo,`0,System.Threading.CancellationToken)`.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`fileInfo`&nbsp;&nbsp;-&nbsp;&nbsp;The destination JSON file.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`model`&nbsp;&nbsp;-&nbsp;&nbsp;The model instance to serialize.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`cancellationToken`&nbsp;&nbsp;-&nbsp;&nbsp;A token to cancel the operation.<br />
>
><b>Returns:</b> A task that completes when the write has finished.
#### WriteModelToJsonFileAsync
>```csharp
>Task WriteModelToJsonFileAsync(FileInfo fileInfo, T model, JsonSerializerOptions serializeOptions, CancellationToken cancellationToken = null)
>```
><b>Summary:</b> Asynchronously writes `model` to `fileInfo` as JSON using default serializer options. Delegates to `Atc.Helpers.FileHelper`1.WriteModelToJsonFileAsync(System.IO.FileInfo,`0,System.Threading.CancellationToken)`.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`fileInfo`&nbsp;&nbsp;-&nbsp;&nbsp;The destination JSON file.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`model`&nbsp;&nbsp;-&nbsp;&nbsp;The model instance to serialize.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`cancellationToken`&nbsp;&nbsp;-&nbsp;&nbsp;A token to cancel the operation.<br />
>
><b>Returns:</b> A task that completes when the write has finished.
#### WriteModelToJsonFileAsync
>```csharp
>Task WriteModelToJsonFileAsync(Stream utf8Json, T model, CancellationToken cancellationToken = null)
>```
><b>Summary:</b> Asynchronously writes `model` to `fileInfo` as JSON using default serializer options. Delegates to `Atc.Helpers.FileHelper`1.WriteModelToJsonFileAsync(System.IO.FileInfo,`0,System.Threading.CancellationToken)`.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`fileInfo`&nbsp;&nbsp;-&nbsp;&nbsp;The destination JSON file.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`model`&nbsp;&nbsp;-&nbsp;&nbsp;The model instance to serialize.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`cancellationToken`&nbsp;&nbsp;-&nbsp;&nbsp;A token to cancel the operation.<br />
>
><b>Returns:</b> A task that completes when the write has finished.
#### WriteModelToJsonFileAsync
>```csharp
>Task WriteModelToJsonFileAsync(Stream utf8Json, T model, JsonSerializerOptions serializeOptions, CancellationToken cancellationToken = null)
>```
><b>Summary:</b> Asynchronously writes `model` to `fileInfo` as JSON using default serializer options. Delegates to `Atc.Helpers.FileHelper`1.WriteModelToJsonFileAsync(System.IO.FileInfo,`0,System.Threading.CancellationToken)`.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`fileInfo`&nbsp;&nbsp;-&nbsp;&nbsp;The destination JSON file.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`model`&nbsp;&nbsp;-&nbsp;&nbsp;The model instance to serialize.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`cancellationToken`&nbsp;&nbsp;-&nbsp;&nbsp;A token to cancel the operation.<br />
>
><b>Returns:</b> A task that completes when the write has finished.

<br />

## FileHelper&lt;T&gt;
JSON file helper for reading/writing a model of type `T`.
><b>Remarks:</b> - Uses `System.Text.Json.JsonSerializer`. - Default overloads obtain options from `JsonSerializerOptionsFactory.Create()`. - Read methods require the file to exist; otherwise a `System.IO.FileNotFoundException` is thrown. - Write methods overwrite the destination file if it exists. - Text I/O uses UTF-8 encoding.
<b>Code example:</b>
>```csharp
> var fi = new FileInfo("settings.json");
> var settings = FileHelper<AppSettings>.ReadJsonFileToModel(fi);
>
> // Modify and save
> FileHelper<AppSettings>.WriteModelToJsonFile(fi, settings);
>```

>```csharp
>public static class FileHelper&lt;T&gt;
>```

### Static Methods

#### ReadJsonFileToModel
>```csharp
>T ReadJsonFileToModel(FileInfo fileInfo)
>```
><b>Summary:</b> Reads the JSON file and deserializes it to `T` using default serializer options.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`fileInfo`&nbsp;&nbsp;-&nbsp;&nbsp;The JSON file to read.<br />
>
><b>Returns:</b> The deserialized model, or <see langword="null" /> if the payload is JSON <see langword="null" /> .
#### ReadJsonFileToModel
>```csharp
>T ReadJsonFileToModel(FileInfo fileInfo, JsonSerializerOptions serializeOptions)
>```
><b>Summary:</b> Reads the JSON file and deserializes it to `T` using default serializer options.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`fileInfo`&nbsp;&nbsp;-&nbsp;&nbsp;The JSON file to read.<br />
>
><b>Returns:</b> The deserialized model, or <see langword="null" /> if the payload is JSON <see langword="null" /> .
#### ReadJsonFileToModel
>```csharp
>T ReadJsonFileToModel(Stream utf8Json)
>```
><b>Summary:</b> Reads the JSON file and deserializes it to `T` using default serializer options.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`fileInfo`&nbsp;&nbsp;-&nbsp;&nbsp;The JSON file to read.<br />
>
><b>Returns:</b> The deserialized model, or <see langword="null" /> if the payload is JSON <see langword="null" /> .
#### ReadJsonFileToModel
>```csharp
>T ReadJsonFileToModel(Stream utf8Json, JsonSerializerOptions serializeOptions)
>```
><b>Summary:</b> Reads the JSON file and deserializes it to `T` using default serializer options.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`fileInfo`&nbsp;&nbsp;-&nbsp;&nbsp;The JSON file to read.<br />
>
><b>Returns:</b> The deserialized model, or <see langword="null" /> if the payload is JSON <see langword="null" /> .
#### ReadJsonFileToModelAsync
>```csharp
>Task<T> ReadJsonFileToModelAsync(FileInfo fileInfo, CancellationToken cancellationToken = null)
>```
><b>Summary:</b> Asynchronously reads the JSON file and deserializes it to `T` using default serializer options.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`fileInfo`&nbsp;&nbsp;-&nbsp;&nbsp;The JSON file to read.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`cancellationToken`&nbsp;&nbsp;-&nbsp;&nbsp;A token to cancel the operation.<br />
>
><b>Returns:</b> A task whose result is the deserialized model, or <see langword="null" /> if the payload is JSON <see langword="null" /> .
#### ReadJsonFileToModelAsync
>```csharp
>Task<T> ReadJsonFileToModelAsync(FileInfo fileInfo, JsonSerializerOptions serializeOptions, CancellationToken cancellationToken = null)
>```
><b>Summary:</b> Asynchronously reads the JSON file and deserializes it to `T` using default serializer options.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`fileInfo`&nbsp;&nbsp;-&nbsp;&nbsp;The JSON file to read.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`cancellationToken`&nbsp;&nbsp;-&nbsp;&nbsp;A token to cancel the operation.<br />
>
><b>Returns:</b> A task whose result is the deserialized model, or <see langword="null" /> if the payload is JSON <see langword="null" /> .
#### ReadJsonFileToModelAsync
>```csharp
>Task<T> ReadJsonFileToModelAsync(Stream utf8Json, CancellationToken cancellationToken = null)
>```
><b>Summary:</b> Asynchronously reads the JSON file and deserializes it to `T` using default serializer options.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`fileInfo`&nbsp;&nbsp;-&nbsp;&nbsp;The JSON file to read.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`cancellationToken`&nbsp;&nbsp;-&nbsp;&nbsp;A token to cancel the operation.<br />
>
><b>Returns:</b> A task whose result is the deserialized model, or <see langword="null" /> if the payload is JSON <see langword="null" /> .
#### ReadJsonFileToModelAsync
>```csharp
>Task<T> ReadJsonFileToModelAsync(Stream utf8Json, JsonSerializerOptions serializeOptions, CancellationToken cancellationToken = null)
>```
><b>Summary:</b> Asynchronously reads the JSON file and deserializes it to `T` using default serializer options.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`fileInfo`&nbsp;&nbsp;-&nbsp;&nbsp;The JSON file to read.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`cancellationToken`&nbsp;&nbsp;-&nbsp;&nbsp;A token to cancel the operation.<br />
>
><b>Returns:</b> A task whose result is the deserialized model, or <see langword="null" /> if the payload is JSON <see langword="null" /> .
#### WriteModelToJsonFile
>```csharp
>void WriteModelToJsonFile(FileInfo fileInfo, T model)
>```
><b>Summary:</b> Writes `model` to `fileInfo` as JSON using default serializer options.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`fileInfo`&nbsp;&nbsp;-&nbsp;&nbsp;The destination JSON file.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`model`&nbsp;&nbsp;-&nbsp;&nbsp;The model instance to serialize.<br />
#### WriteModelToJsonFile
>```csharp
>void WriteModelToJsonFile(FileInfo fileInfo, T model, JsonSerializerOptions serializeOptions)
>```
><b>Summary:</b> Writes `model` to `fileInfo` as JSON using default serializer options.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`fileInfo`&nbsp;&nbsp;-&nbsp;&nbsp;The destination JSON file.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`model`&nbsp;&nbsp;-&nbsp;&nbsp;The model instance to serialize.<br />
#### WriteModelToJsonFile
>```csharp
>void WriteModelToJsonFile(Stream utf8Json, T model)
>```
><b>Summary:</b> Writes `model` to `fileInfo` as JSON using default serializer options.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`fileInfo`&nbsp;&nbsp;-&nbsp;&nbsp;The destination JSON file.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`model`&nbsp;&nbsp;-&nbsp;&nbsp;The model instance to serialize.<br />
#### WriteModelToJsonFile
>```csharp
>void WriteModelToJsonFile(Stream utf8Json, T model, JsonSerializerOptions serializeOptions)
>```
><b>Summary:</b> Writes `model` to `fileInfo` as JSON using default serializer options.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`fileInfo`&nbsp;&nbsp;-&nbsp;&nbsp;The destination JSON file.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`model`&nbsp;&nbsp;-&nbsp;&nbsp;The model instance to serialize.<br />
#### WriteModelToJsonFileAsync
>```csharp
>Task WriteModelToJsonFileAsync(FileInfo fileInfo, T model, CancellationToken cancellationToken = null)
>```
><b>Summary:</b> Asynchronously writes `model` to `fileInfo` as JSON using default serializer options.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`fileInfo`&nbsp;&nbsp;-&nbsp;&nbsp;The destination JSON file.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`model`&nbsp;&nbsp;-&nbsp;&nbsp;The model instance to serialize.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`cancellationToken`&nbsp;&nbsp;-&nbsp;&nbsp;A token to cancel the operation.<br />
>
><b>Returns:</b> A task that completes when the write has finished.
#### WriteModelToJsonFileAsync
>```csharp
>Task WriteModelToJsonFileAsync(FileInfo fileInfo, T model, JsonSerializerOptions serializeOptions, CancellationToken cancellationToken = null)
>```
><b>Summary:</b> Asynchronously writes `model` to `fileInfo` as JSON using default serializer options.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`fileInfo`&nbsp;&nbsp;-&nbsp;&nbsp;The destination JSON file.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`model`&nbsp;&nbsp;-&nbsp;&nbsp;The model instance to serialize.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`cancellationToken`&nbsp;&nbsp;-&nbsp;&nbsp;A token to cancel the operation.<br />
>
><b>Returns:</b> A task that completes when the write has finished.
#### WriteModelToJsonFileAsync
>```csharp
>Task WriteModelToJsonFileAsync(Stream utf8Json, T model, CancellationToken cancellationToken = null)
>```
><b>Summary:</b> Asynchronously writes `model` to `fileInfo` as JSON using default serializer options.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`fileInfo`&nbsp;&nbsp;-&nbsp;&nbsp;The destination JSON file.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`model`&nbsp;&nbsp;-&nbsp;&nbsp;The model instance to serialize.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`cancellationToken`&nbsp;&nbsp;-&nbsp;&nbsp;A token to cancel the operation.<br />
>
><b>Returns:</b> A task that completes when the write has finished.
#### WriteModelToJsonFileAsync
>```csharp
>Task WriteModelToJsonFileAsync(Stream utf8Json, T model, JsonSerializerOptions serializeOptions, CancellationToken cancellationToken = null)
>```
><b>Summary:</b> Asynchronously writes `model` to `fileInfo` as JSON using default serializer options.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`fileInfo`&nbsp;&nbsp;-&nbsp;&nbsp;The destination JSON file.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`model`&nbsp;&nbsp;-&nbsp;&nbsp;The model instance to serialize.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`cancellationToken`&nbsp;&nbsp;-&nbsp;&nbsp;A token to cancel the operation.<br />
>
><b>Returns:</b> A task that completes when the write has finished.

<br />

## InternetBrowserHelper
Provides utility methods for detecting, controlling, and opening URLs in common internet browsers.
><b>Remarks:</b> Supports Brave, Firefox, Ghost Browser, Chrome, Edge, Internet Explorer, Opera, and Safari.

>```csharp
>public static class InternetBrowserHelper
>```

### Static Methods

#### CloseMainWindowOnAllRunningInternetBrowsers
>```csharp
>void CloseMainWindowOnAllRunningInternetBrowsers()
>```
><b>Summary:</b> Closes the main window on all running internet browser instances.
#### CloseMainWindowOnRunningBraveInstances
>```csharp
>void CloseMainWindowOnRunningBraveInstances()
>```
><b>Summary:</b> Closes the main window on all running Brave browser instances.
#### CloseMainWindowOnRunningFirefoxInstances
>```csharp
>void CloseMainWindowOnRunningFirefoxInstances()
>```
><b>Summary:</b> Closes the main window on all running Firefox browser instances.
#### CloseMainWindowOnRunningGhostBrowserInstances
>```csharp
>void CloseMainWindowOnRunningGhostBrowserInstances()
>```
><b>Summary:</b> Closes the main window on all running Ghost Browser instances.
#### CloseMainWindowOnRunningGoogleChromeInstances
>```csharp
>void CloseMainWindowOnRunningGoogleChromeInstances()
>```
><b>Summary:</b> Closes the main window on all running Google Chrome browser instances.
#### CloseMainWindowOnRunningMicrosoftEdgeInstances
>```csharp
>void CloseMainWindowOnRunningMicrosoftEdgeInstances()
>```
><b>Summary:</b> Closes the main window on all running Microsoft Edge browser instances.
#### CloseMainWindowOnRunningMicrosoftInternetExplorerInstances
>```csharp
>void CloseMainWindowOnRunningMicrosoftInternetExplorerInstances()
>```
><b>Summary:</b> Closes the main window on all running Microsoft Internet Explorer instances.
#### CloseMainWindowOnRunningOperaInstances
>```csharp
>void CloseMainWindowOnRunningOperaInstances()
>```
><b>Summary:</b> Closes the main window on all running Opera browser instances.
#### CloseMainWindowOnRunningSafariInstances
>```csharp
>void CloseMainWindowOnRunningSafariInstances()
>```
><b>Summary:</b> Closes the main window on all running Safari browser instances.
#### GetRunningInternetBrowsers
>```csharp
>IList<string> GetRunningInternetBrowsers()
>```
><b>Summary:</b> Gets a list of currently running internet browsers.
>
><b>Returns:</b> A list of browser names that are currently running.
#### IsBraveRunning
>```csharp
>bool IsBraveRunning()
>```
><b>Summary:</b> Determines whether Brave browser is currently running.
>
><b>Returns:</b> <see langword="true" /> if Brave is running; otherwise, <see langword="false" />.
#### IsFirefoxRunning
>```csharp
>bool IsFirefoxRunning()
>```
><b>Summary:</b> Determines whether Firefox browser is currently running.
>
><b>Returns:</b> <see langword="true" /> if Firefox is running; otherwise, <see langword="false" />.
#### IsGhostBrowserRunning
>```csharp
>bool IsGhostBrowserRunning()
>```
><b>Summary:</b> Determines whether Ghost Browser is currently running.
>
><b>Returns:</b> <see langword="true" /> if Ghost Browser is running; otherwise, <see langword="false" />.
#### IsGoogleChromeRunning
>```csharp
>bool IsGoogleChromeRunning()
>```
><b>Summary:</b> Determines whether Google Chrome browser is currently running.
>
><b>Returns:</b> <see langword="true" /> if Google Chrome is running; otherwise, <see langword="false" />.
#### IsMicrosoftEdgeRunning
>```csharp
>bool IsMicrosoftEdgeRunning()
>```
><b>Summary:</b> Determines whether Microsoft Edge browser is currently running.
>
><b>Returns:</b> <see langword="true" /> if Microsoft Edge is running; otherwise, <see langword="false" />.
#### IsMicrosoftInternetExplorerRunning
>```csharp
>bool IsMicrosoftInternetExplorerRunning()
>```
><b>Summary:</b> Determines whether Microsoft Internet Explorer is currently running.
>
><b>Returns:</b> <see langword="true" /> if Internet Explorer is running; otherwise, <see langword="false" />.
#### IsOperaRunning
>```csharp
>bool IsOperaRunning()
>```
><b>Summary:</b> Determines whether Opera browser is currently running.
>
><b>Returns:</b> <see langword="true" /> if Opera is running; otherwise, <see langword="false" />.
#### IsSafariRunning
>```csharp
>bool IsSafariRunning()
>```
><b>Summary:</b> Determines whether Safari browser is currently running.
>
><b>Returns:</b> <see langword="true" /> if Safari is running; otherwise, <see langword="false" />.
#### KillAllRunningInternetBrowsers
>```csharp
>void KillAllRunningInternetBrowsers()
>```
><b>Summary:</b> Terminates all running internet browser processes.
#### KillRunningBraveInstances
>```csharp
>void KillRunningBraveInstances()
>```
><b>Summary:</b> Terminates all running Brave browser processes.
#### KillRunningFirefoxInstances
>```csharp
>void KillRunningFirefoxInstances()
>```
><b>Summary:</b> Terminates all running Firefox browser processes.
#### KillRunningGhostBrowserInstances
>```csharp
>void KillRunningGhostBrowserInstances()
>```
><b>Summary:</b> Terminates all running Ghost Browser processes.
#### KillRunningGoogleChromeInstances
>```csharp
>void KillRunningGoogleChromeInstances()
>```
><b>Summary:</b> Terminates all running Google Chrome browser processes.
#### KillRunningMicrosoftEdgeInstances
>```csharp
>void KillRunningMicrosoftEdgeInstances()
>```
><b>Summary:</b> Terminates all running Microsoft Edge browser processes.
#### KillRunningMicrosoftInternetExplorerInstances
>```csharp
>void KillRunningMicrosoftInternetExplorerInstances()
>```
><b>Summary:</b> Terminates all running Microsoft Internet Explorer processes.
#### KillRunningOperaInstances
>```csharp
>void KillRunningOperaInstances()
>```
><b>Summary:</b> Terminates all running Opera browser processes.
#### KillRunningSafariInstances
>```csharp
>void KillRunningSafariInstances()
>```
><b>Summary:</b> Terminates all running Safari browser processes.
#### OpenUrl
>```csharp
>bool OpenUrl(string url)
>```
><b>Summary:</b> Open the given url in the default browser on the machine.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`url`&nbsp;&nbsp;-&nbsp;&nbsp;The URL.<br />
>
><b>Returns:</b> <see langword="true" /> if the url is started in a browser; otherwise, <see langword="false" />.
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
><b>Returns:</b> <see langword="true" /> if the url is started in a browser; otherwise, <see langword="false" />.
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
><b>Returns:</b> <see langword="true" /> if [is equal to zero] [the specified value]; otherwise, <see langword="false" />.
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
><b>Returns:</b> <see langword="true" /> if the specified value1 is equals; otherwise, <see langword="false" />.
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
Provides utility methods for checking network connectivity and retrieving network information.

>```csharp
>public static class NetworkInformationHelper
>```

### Static Methods

#### GetPublicIpAddress
>```csharp
>IPAddress GetPublicIpAddress()
>```
><b>Summary:</b> Retrieves the public IP address of the current machine by querying an external service (api.ipify.org).
>
><b>Returns:</b> The public `System.Net.IPAddress` if retrieval succeeds; otherwise, <see langword="null" />.
#### HasConnection
>```csharp
>bool HasConnection()
>```
><b>Summary:</b> Determines whether there is network connectivity by pinging Google's DNS server (8.8.8.8).
>
><b>Returns:</b> <see langword="true" /> if a ping response is received; otherwise, <see langword="false" />.
#### HasConnection
>```csharp
>bool HasConnection(IPAddress ipAddress)
>```
><b>Summary:</b> Determines whether there is network connectivity by pinging Google's DNS server (8.8.8.8).
>
><b>Returns:</b> <see langword="true" /> if a ping response is received; otherwise, <see langword="false" />.
#### HasHttpConnection
>```csharp
>bool HasHttpConnection()
>```
><b>Summary:</b> Determines whether there is HTTP connectivity by making a request to Google's website.
>
><b>Returns:</b> <see langword="true" /> if the HTTP request succeeds; otherwise, <see langword="false" />.
#### HasHttpConnection
>```csharp
>bool HasHttpConnection(Uri uri)
>```
><b>Summary:</b> Determines whether there is HTTP connectivity by making a request to Google's website.
>
><b>Returns:</b> <see langword="true" /> if the HTTP request succeeds; otherwise, <see langword="false" />.
#### HasTcpConnection
>```csharp
>bool HasTcpConnection(IPAddress ipAddress, int port)
>```
><b>Summary:</b> Determines whether a TCP connection can be established to the specified IP address and port.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`ipAddress`&nbsp;&nbsp;-&nbsp;&nbsp;The IP address to connect to.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`port`&nbsp;&nbsp;-&nbsp;&nbsp;The port number to connect to.<br />
>
><b>Returns:</b> <see langword="true" /> if the TCP connection succeeds; otherwise, <see langword="false" />.

<br />

## NumberHelper
Provides utility methods for parsing and validating numeric string values across different cultures.
><b>Remarks:</b> This helper supports parsing to int, decimal, double, and float types with optional culture-specific formatting.

>```csharp
>public static class NumberHelper
>```

### Static Methods

#### IsDecimal
>```csharp
>bool IsDecimal(string value)
>```
><b>Summary:</b> Determines whether the specified string can be parsed as a decimal.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The string to validate.<br />
>
><b>Returns:</b> <see langword="true" /> if the value can be parsed as a decimal; otherwise, <see langword="false" />.
#### IsDecimal
>```csharp
>bool IsDecimal(string value, bool useUiCulture)
>```
><b>Summary:</b> Determines whether the specified string can be parsed as a decimal.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The string to validate.<br />
>
><b>Returns:</b> <see langword="true" /> if the value can be parsed as a decimal; otherwise, <see langword="false" />.
#### IsDecimal
>```csharp
>bool IsDecimal(string value, CultureInfo cultureInfo)
>```
><b>Summary:</b> Determines whether the specified string can be parsed as a decimal.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The string to validate.<br />
>
><b>Returns:</b> <see langword="true" /> if the value can be parsed as a decimal; otherwise, <see langword="false" />.
#### IsDouble
>```csharp
>bool IsDouble(string value)
>```
><b>Summary:</b> Determines whether the specified string can be parsed as a double.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The string to validate.<br />
>
><b>Returns:</b> <see langword="true" /> if the value can be parsed as a double; otherwise, <see langword="false" />.
#### IsDouble
>```csharp
>bool IsDouble(string value, bool useUiCulture)
>```
><b>Summary:</b> Determines whether the specified string can be parsed as a double.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The string to validate.<br />
>
><b>Returns:</b> <see langword="true" /> if the value can be parsed as a double; otherwise, <see langword="false" />.
#### IsDouble
>```csharp
>bool IsDouble(string value, CultureInfo cultureInfo)
>```
><b>Summary:</b> Determines whether the specified string can be parsed as a double.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The string to validate.<br />
>
><b>Returns:</b> <see langword="true" /> if the value can be parsed as a double; otherwise, <see langword="false" />.
#### IsFloat
>```csharp
>bool IsFloat(string value)
>```
><b>Summary:</b> Determines whether the specified string can be parsed as a float.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The string to validate.<br />
>
><b>Returns:</b> <see langword="true" /> if the value can be parsed as a float; otherwise, <see langword="false" />.
#### IsFloat
>```csharp
>bool IsFloat(string value, bool useUiCulture)
>```
><b>Summary:</b> Determines whether the specified string can be parsed as a float.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The string to validate.<br />
>
><b>Returns:</b> <see langword="true" /> if the value can be parsed as a float; otherwise, <see langword="false" />.
#### IsFloat
>```csharp
>bool IsFloat(string value, CultureInfo cultureInfo)
>```
><b>Summary:</b> Determines whether the specified string can be parsed as a float.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The string to validate.<br />
>
><b>Returns:</b> <see langword="true" /> if the value can be parsed as a float; otherwise, <see langword="false" />.
#### IsInt
>```csharp
>bool IsInt(string value)
>```
><b>Summary:</b> Determines whether the specified string can be parsed as an integer.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The string to validate.<br />
>
><b>Returns:</b> <see langword="true" /> if the value can be parsed as an integer; otherwise, <see langword="false" />.
#### IsNumber
>```csharp
>bool IsNumber(string value)
>```
><b>Summary:</b> Determines whether the specified string can be parsed as any numeric type (int, decimal, double, or float).
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The string to validate.<br />
>
><b>Returns:</b> <see langword="true" /> if the value can be parsed as a number; otherwise, <see langword="false" />.
#### IsNumber
>```csharp
>bool IsNumber(string value, bool useUiCulture)
>```
><b>Summary:</b> Determines whether the specified string can be parsed as any numeric type (int, decimal, double, or float).
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The string to validate.<br />
>
><b>Returns:</b> <see langword="true" /> if the value can be parsed as a number; otherwise, <see langword="false" />.
#### IsNumber
>```csharp
>bool IsNumber(string value, CultureInfo cultureInfo)
>```
><b>Summary:</b> Determines whether the specified string can be parsed as any numeric type (int, decimal, double, or float).
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The string to validate.<br />
>
><b>Returns:</b> <see langword="true" /> if the value can be parsed as a number; otherwise, <see langword="false" />.
#### ParseToDecimal
>```csharp
>decimal ParseToDecimal(string value)
>```
><b>Summary:</b> Parses the specified string to a decimal.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The string to parse.<br />
>
><b>Returns:</b> The parsed decimal value, or -1 if parsing fails.
#### ParseToDecimal
>```csharp
>decimal ParseToDecimal(string value, bool useUiCulture)
>```
><b>Summary:</b> Parses the specified string to a decimal.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The string to parse.<br />
>
><b>Returns:</b> The parsed decimal value, or -1 if parsing fails.
#### ParseToDecimal
>```csharp
>decimal ParseToDecimal(string value, CultureInfo cultureInfo)
>```
><b>Summary:</b> Parses the specified string to a decimal.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The string to parse.<br />
>
><b>Returns:</b> The parsed decimal value, or -1 if parsing fails.
#### ParseToDouble
>```csharp
>double ParseToDouble(string value)
>```
><b>Summary:</b> Parses the specified string to a double.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The string to parse.<br />
>
><b>Returns:</b> The parsed double value, or -1 if parsing fails.
#### ParseToDouble
>```csharp
>double ParseToDouble(string value, bool useUiCulture)
>```
><b>Summary:</b> Parses the specified string to a double.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The string to parse.<br />
>
><b>Returns:</b> The parsed double value, or -1 if parsing fails.
#### ParseToDouble
>```csharp
>double ParseToDouble(string value, CultureInfo cultureInfo)
>```
><b>Summary:</b> Parses the specified string to a double.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The string to parse.<br />
>
><b>Returns:</b> The parsed double value, or -1 if parsing fails.
#### ParseToFloat
>```csharp
>float ParseToFloat(string value)
>```
><b>Summary:</b> Parses the specified string to a float.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The string to parse.<br />
>
><b>Returns:</b> The parsed float value, or -1 if parsing fails.
#### ParseToFloat
>```csharp
>float ParseToFloat(string value, bool useUiCulture)
>```
><b>Summary:</b> Parses the specified string to a float.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The string to parse.<br />
>
><b>Returns:</b> The parsed float value, or -1 if parsing fails.
#### ParseToFloat
>```csharp
>float ParseToFloat(string value, CultureInfo cultureInfo)
>```
><b>Summary:</b> Parses the specified string to a float.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The string to parse.<br />
>
><b>Returns:</b> The parsed float value, or -1 if parsing fails.
#### ParseToInt
>```csharp
>int ParseToInt(string value)
>```
><b>Summary:</b> Parses the specified string to an integer.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The string to parse.<br />
>
><b>Returns:</b> The parsed integer value, or -1 if parsing fails.
#### TryParseToDecimal
>```csharp
>bool TryParseToDecimal(string value, out decimal result)
>```
><b>Summary:</b> Tries to parse the specified string to a decimal using CurrentCulture.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The string to parse.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`result`&nbsp;&nbsp;-&nbsp;&nbsp;When this method returns, contains the parsed decimal value if successful; otherwise, 0.<br />
>
><b>Returns:</b> <see langword="true" /> if parsing succeeded; otherwise, <see langword="false" />.
#### TryParseToDecimal
>```csharp
>bool TryParseToDecimal(string value, bool useUiCulture, out decimal result)
>```
><b>Summary:</b> Tries to parse the specified string to a decimal using CurrentCulture.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The string to parse.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`result`&nbsp;&nbsp;-&nbsp;&nbsp;When this method returns, contains the parsed decimal value if successful; otherwise, 0.<br />
>
><b>Returns:</b> <see langword="true" /> if parsing succeeded; otherwise, <see langword="false" />.
#### TryParseToDecimal
>```csharp
>bool TryParseToDecimal(string value, CultureInfo cultureInfo, out decimal result)
>```
><b>Summary:</b> Tries to parse the specified string to a decimal using CurrentCulture.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The string to parse.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`result`&nbsp;&nbsp;-&nbsp;&nbsp;When this method returns, contains the parsed decimal value if successful; otherwise, 0.<br />
>
><b>Returns:</b> <see langword="true" /> if parsing succeeded; otherwise, <see langword="false" />.
#### TryParseToDouble
>```csharp
>bool TryParseToDouble(string value, out double result)
>```
><b>Summary:</b> Tries to parse the specified string to a double using CurrentCulture.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The string to parse.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`result`&nbsp;&nbsp;-&nbsp;&nbsp;When this method returns, contains the parsed double value if successful; otherwise, 0.<br />
>
><b>Returns:</b> <see langword="true" /> if parsing succeeded; otherwise, <see langword="false" />.
#### TryParseToDouble
>```csharp
>bool TryParseToDouble(string value, bool useUiCulture, out double result)
>```
><b>Summary:</b> Tries to parse the specified string to a double using CurrentCulture.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The string to parse.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`result`&nbsp;&nbsp;-&nbsp;&nbsp;When this method returns, contains the parsed double value if successful; otherwise, 0.<br />
>
><b>Returns:</b> <see langword="true" /> if parsing succeeded; otherwise, <see langword="false" />.
#### TryParseToDouble
>```csharp
>bool TryParseToDouble(string value, CultureInfo cultureInfo, out double result)
>```
><b>Summary:</b> Tries to parse the specified string to a double using CurrentCulture.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The string to parse.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`result`&nbsp;&nbsp;-&nbsp;&nbsp;When this method returns, contains the parsed double value if successful; otherwise, 0.<br />
>
><b>Returns:</b> <see langword="true" /> if parsing succeeded; otherwise, <see langword="false" />.
#### TryParseToFloat
>```csharp
>bool TryParseToFloat(string value, out float result)
>```
><b>Summary:</b> Tries to parse the specified string to a float using CurrentCulture.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The string to parse.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`result`&nbsp;&nbsp;-&nbsp;&nbsp;When this method returns, contains the parsed float value if successful; otherwise, 0.<br />
>
><b>Returns:</b> <see langword="true" /> if parsing succeeded; otherwise, <see langword="false" />.
#### TryParseToFloat
>```csharp
>bool TryParseToFloat(string value, bool useUiCulture, out float result)
>```
><b>Summary:</b> Tries to parse the specified string to a float using CurrentCulture.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The string to parse.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`result`&nbsp;&nbsp;-&nbsp;&nbsp;When this method returns, contains the parsed float value if successful; otherwise, 0.<br />
>
><b>Returns:</b> <see langword="true" /> if parsing succeeded; otherwise, <see langword="false" />.
#### TryParseToFloat
>```csharp
>bool TryParseToFloat(string value, CultureInfo cultureInfo, out float result)
>```
><b>Summary:</b> Tries to parse the specified string to a float using CurrentCulture.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The string to parse.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`result`&nbsp;&nbsp;-&nbsp;&nbsp;When this method returns, contains the parsed float value if successful; otherwise, 0.<br />
>
><b>Returns:</b> <see langword="true" /> if parsing succeeded; otherwise, <see langword="false" />.
#### TryParseToInt
>```csharp
>bool TryParseToInt(string value, out int result)
>```
><b>Summary:</b> Tries to parse the specified string to an integer using English culture.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The string to parse.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`result`&nbsp;&nbsp;-&nbsp;&nbsp;When this method returns, contains the parsed integer value if successful; otherwise, 0.<br />
>
><b>Returns:</b> <see langword="true" /> if parsing succeeded; otherwise, <see langword="false" />.

<br />

## ProcessHelper
Provides utility methods for executing external processes, managing process lifecycles, and handling process termination.
><b>Remarks:</b> Supports executing processes with timeouts, capturing output, running as administrator, and killing processes by ID or name.

>```csharp
>public static class ProcessHelper
>```

### Static Methods

#### Execute
>```csharp
>Task<ValueTuple<bool, string>> Execute(FileInfo fileInfo, string arguments, bool runAsAdministrator = False, ushort timeoutInSec = 30, CancellationToken cancellationToken = null)
>```
><b>Summary:</b> Executes a process with the specified file and arguments, with an optional timeout.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`fileInfo`&nbsp;&nbsp;-&nbsp;&nbsp;The executable file to run.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`arguments`&nbsp;&nbsp;-&nbsp;&nbsp;The command-line arguments to pass to the executable.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`runAsAdministrator`&nbsp;&nbsp;-&nbsp;&nbsp;If , attempts to run the process with elevated privileges.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`timeoutInSec`&nbsp;&nbsp;-&nbsp;&nbsp;The maximum time in seconds to wait for the process to complete. Default is 30 seconds.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`cancellationToken`&nbsp;&nbsp;-&nbsp;&nbsp;A token to cancel the operation.<br />
>
><b>Returns:</b> A task that returns a tuple containing success status and output/error messages.
#### Execute
>```csharp
>Task<ValueTuple<bool, string>> Execute(DirectoryInfo workingDirectory, FileInfo fileInfo, string arguments, bool runAsAdministrator = False, ushort timeoutInSec = 30, CancellationToken cancellationToken = null)
>```
><b>Summary:</b> Executes a process with the specified file and arguments, with an optional timeout.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`fileInfo`&nbsp;&nbsp;-&nbsp;&nbsp;The executable file to run.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`arguments`&nbsp;&nbsp;-&nbsp;&nbsp;The command-line arguments to pass to the executable.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`runAsAdministrator`&nbsp;&nbsp;-&nbsp;&nbsp;If , attempts to run the process with elevated privileges.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`timeoutInSec`&nbsp;&nbsp;-&nbsp;&nbsp;The maximum time in seconds to wait for the process to complete. Default is 30 seconds.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`cancellationToken`&nbsp;&nbsp;-&nbsp;&nbsp;A token to cancel the operation.<br />
>
><b>Returns:</b> A task that returns a tuple containing success status and output/error messages.
#### ExecuteAndIgnoreOutput
>```csharp
>Task<bool> ExecuteAndIgnoreOutput(FileInfo fileInfo, string arguments, bool runAsAdministrator = False, ushort timeoutInSec = 30, CancellationToken cancellationToken = null)
>```
><b>Summary:</b> Executes a process without capturing its output, returning only success status.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`fileInfo`&nbsp;&nbsp;-&nbsp;&nbsp;The executable file to run.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`arguments`&nbsp;&nbsp;-&nbsp;&nbsp;The command-line arguments to pass to the executable.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`runAsAdministrator`&nbsp;&nbsp;-&nbsp;&nbsp;If , attempts to run the process with elevated privileges.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`timeoutInSec`&nbsp;&nbsp;-&nbsp;&nbsp;The maximum time in seconds to wait for the process to complete. Default is 30 seconds.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`cancellationToken`&nbsp;&nbsp;-&nbsp;&nbsp;A token to cancel the operation.<br />
>
><b>Returns:</b> A task that returns <see langword="true" /> if the process executed successfully; otherwise, <see langword="false" />.
#### ExecuteAndIgnoreOutput
>```csharp
>Task<bool> ExecuteAndIgnoreOutput(DirectoryInfo workingDirectory, FileInfo fileInfo, string arguments, bool runAsAdministrator = False, ushort timeoutInSec = 30, CancellationToken cancellationToken = null)
>```
><b>Summary:</b> Executes a process without capturing its output, returning only success status.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`fileInfo`&nbsp;&nbsp;-&nbsp;&nbsp;The executable file to run.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`arguments`&nbsp;&nbsp;-&nbsp;&nbsp;The command-line arguments to pass to the executable.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`runAsAdministrator`&nbsp;&nbsp;-&nbsp;&nbsp;If , attempts to run the process with elevated privileges.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`timeoutInSec`&nbsp;&nbsp;-&nbsp;&nbsp;The maximum time in seconds to wait for the process to complete. Default is 30 seconds.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`cancellationToken`&nbsp;&nbsp;-&nbsp;&nbsp;A token to cancel the operation.<br />
>
><b>Returns:</b> A task that returns <see langword="true" /> if the process executed successfully; otherwise, <see langword="false" />.
#### ExecutePrompt
>```csharp
>Task<ValueTuple<bool, string>> ExecutePrompt(DirectoryInfo workingDirectory, FileInfo fileInfo, string arguments, string[] inputLines, bool runAsAdministrator = False, ushort timeoutInSec = 1, CancellationToken cancellationToken = null)
>```
><b>Summary:</b> Executes a process that requires interactive input, sending the specified input lines to standard input.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`workingDirectory`&nbsp;&nbsp;-&nbsp;&nbsp;The working directory for the process.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`fileInfo`&nbsp;&nbsp;-&nbsp;&nbsp;The executable file to run.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`arguments`&nbsp;&nbsp;-&nbsp;&nbsp;The command-line arguments to pass to the executable.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`inputLines`&nbsp;&nbsp;-&nbsp;&nbsp;The lines of input to send to the process's standard input stream.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`runAsAdministrator`&nbsp;&nbsp;-&nbsp;&nbsp;If , attempts to run the process with elevated privileges.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`timeoutInSec`&nbsp;&nbsp;-&nbsp;&nbsp;The maximum time in seconds to wait for the process to complete. Default is 1 second.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`cancellationToken`&nbsp;&nbsp;-&nbsp;&nbsp;A token to cancel the operation.<br />
>
><b>Returns:</b> A task that returns a tuple containing success status and output/error messages.
#### KillById
>```csharp
>ValueTuple<bool, string> KillById(int processId, int timeoutInSec = 30)
>```
><b>Summary:</b> Terminates a process by its process ID.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`processId`&nbsp;&nbsp;-&nbsp;&nbsp;The process ID of the process to terminate.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`timeoutInSec`&nbsp;&nbsp;-&nbsp;&nbsp;The maximum time in seconds to wait for the process to terminate. Default is 30 seconds.<br />
>
><b>Returns:</b> A tuple containing success status and a descriptive message.
#### KillByName
>```csharp
>ValueTuple<bool, string> KillByName(string processName, bool allowMultiKill = True, int timeoutInSec = 30)
>```
><b>Summary:</b> Terminates processes by their process name.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`processName`&nbsp;&nbsp;-&nbsp;&nbsp;The name of the process(es) to terminate (without .exe extension).<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`allowMultiKill`&nbsp;&nbsp;-&nbsp;&nbsp;If , allows terminating multiple processes with the same name; otherwise, fails if more than one match is found.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`timeoutInSec`&nbsp;&nbsp;-&nbsp;&nbsp;The maximum time in seconds to wait for each process to terminate. Default is 30 seconds.<br />
>
><b>Returns:</b> A tuple containing success status and a descriptive message.
#### KillEntryCaller
>```csharp
>ValueTuple<bool, string> KillEntryCaller(int timeoutInSec = 30)
>```
><b>Summary:</b> Terminates the entry assembly's process (the current application).
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`timeoutInSec`&nbsp;&nbsp;-&nbsp;&nbsp;The maximum time in seconds to wait for the process to terminate. Default is 30 seconds.<br />
>
><b>Returns:</b> A tuple containing success status and a descriptive message.

<br />

## ReflectionHelper
ReflectionHelper.

>```csharp
>public static class ReflectionHelper
>```

### Static Methods

#### GetPrivateField
>```csharp
>T GetPrivateField(object target, string fieldName)
>```
><b>Summary:</b> Gets the value of a private field from the specified target object.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`target`&nbsp;&nbsp;-&nbsp;&nbsp;The target object containing the private field.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`fieldName`&nbsp;&nbsp;-&nbsp;&nbsp;The name of the private field to retrieve.<br />
>
><b>Returns:</b> The value of the private field, cast to the specified type.
#### SetPrivateField
>```csharp
>void SetPrivateField(object target, string fieldName, object value)
>```
><b>Summary:</b> Sets the value of a private field on the specified target object.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`target`&nbsp;&nbsp;-&nbsp;&nbsp;The target object containing the private field.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`fieldName`&nbsp;&nbsp;-&nbsp;&nbsp;The name of the private field to set.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value to set on the private field.<br />

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
