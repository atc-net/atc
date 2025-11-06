<div style='text-align: right'>

[References](Index.md)&nbsp;&nbsp;-&nbsp;&nbsp;[References extended](IndexExtended.md)
</div>

# Atc.XUnit

<br />

## AssemblyLocalizationResourcesHelper
Provides helper methods for validating localization resources in assemblies.

>```csharp
>public static class AssemblyLocalizationResourcesHelper
>```

### Static Methods

#### CollectInvalidKeySuffixWithPlaceholders
>```csharp
>Dictionary<string, Dictionary<string, List<string>>> CollectInvalidKeySuffixWithPlaceholders(Assembly assembly, IList<string> cultureNames, IList<string> allowSuffixTerms = null)
>```
><b>Summary:</b> Collects resource keys with invalid suffix patterns when placeholders are present. Validates that resource keys ending with numbers match the placeholder count in their values.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`assembly`&nbsp;&nbsp;-&nbsp;&nbsp;The assembly containing resource files to validate.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`cultureNames`&nbsp;&nbsp;-&nbsp;&nbsp;The list of culture names to check.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`allowSuffixTerms`&nbsp;&nbsp;-&nbsp;&nbsp;Optional list of suffix terms that are allowed to appear before numeric suffixes.<br />
>
><b>Returns:</b> A dictionary mapping resource manager names to dictionaries of culture names and their invalid keys.
#### CollectMissingTranslations
>```csharp
>Dictionary<string, Dictionary<string, List<string>>> CollectMissingTranslations(Assembly assembly, IList<string> cultureNames)
>```
><b>Summary:</b> Collects missing translations across specified cultures for all resource managers in an assembly.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`assembly`&nbsp;&nbsp;-&nbsp;&nbsp;The assembly containing resource files to validate.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`cultureNames`&nbsp;&nbsp;-&nbsp;&nbsp;The list of culture names (e.g., "en-US", "da-DK") to check for translations.<br />
>
><b>Returns:</b> A dictionary mapping resource manager names to dictionaries of culture names and their missing translation keys.
#### ValidateKeySuffixWithPlaceholders
>```csharp
>bool ValidateKeySuffixWithPlaceholders(string key, string value, IList<string> allowSuffixTerms = null)
>```
><b>Summary:</b> Validates that a resource key's numeric suffix matches the number of placeholders in its value. For example, "Message2" should have placeholders {0} and {1} in its value.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`key`&nbsp;&nbsp;-&nbsp;&nbsp;The resource key to validate.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The resource value containing placeholders.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`allowSuffixTerms`&nbsp;&nbsp;-&nbsp;&nbsp;Optional list of suffix terms that are allowed to appear before numeric suffixes.<br />
>
><b>Returns:</b> `true` if the key suffix is valid for the placeholders in the value; otherwise, `false`.

<br />

## AtcXUnitAssemblyTypeInitializer

>```csharp
>public static class AtcXUnitAssemblyTypeInitializer
>```


<br />

## CodeComplianceDocumentationHelper
Provides helper methods for asserting code compliance related to XML documentation comments.

>```csharp
>public static class CodeComplianceDocumentationHelper
>```

### Static Methods

#### AssertExportedTypeWithMissingComments
>```csharp
>void AssertExportedTypeWithMissingComments(Type type)
>```
><b>Summary:</b> Asserts that the specified exported type has XML documentation comments. Fails the test if comments are missing.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`type`&nbsp;&nbsp;-&nbsp;&nbsp;The type to validate for XML documentation.<br />
#### AssertExportedTypesWithMissingComments
>```csharp
>void AssertExportedTypesWithMissingComments(Assembly assembly, List<Type> excludeTypes = null)
>```
><b>Summary:</b> Asserts that all exported types in an assembly have XML documentation comments. Fails the test if any types are missing documentation.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`assembly`&nbsp;&nbsp;-&nbsp;&nbsp;The assembly to validate.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`excludeTypes`&nbsp;&nbsp;-&nbsp;&nbsp;Optional list of types to exclude from validation.<br />

<br />

## CodeComplianceHelper
Provides helper methods for asserting code compliance related to naming conventions and localization resources.

>```csharp
>public static class CodeComplianceHelper
>```

### Static Methods

#### AssertExportedTypesWithWrongDefinitions
>```csharp
>void AssertExportedTypesWithWrongDefinitions(Type type, bool useFullName = False)
>```
><b>Summary:</b> Asserts that exported types have correct naming definitions. Currently not implemented.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`type`&nbsp;&nbsp;-&nbsp;&nbsp;The type to validate.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`useFullName`&nbsp;&nbsp;-&nbsp;&nbsp;If set to true, use full type names in output.<br />
#### AssertExportedTypesWithWrongDefinitions
>```csharp
>void AssertExportedTypesWithWrongDefinitions(Assembly assembly, List<Type> excludeTypes = null, bool useFullName = False)
>```
><b>Summary:</b> Asserts that exported types have correct naming definitions. Currently not implemented.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`type`&nbsp;&nbsp;-&nbsp;&nbsp;The type to validate.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`useFullName`&nbsp;&nbsp;-&nbsp;&nbsp;If set to true, use full type names in output.<br />
#### AssertLocalizationResources
>```csharp
>void AssertLocalizationResources(Assembly assembly, IList<string> cultureNames, IList<string> allowSuffixTermsForKeySuffixWithPlaceholders = null)
>```
><b>Summary:</b> Asserts that localization resources have all required translations and valid placeholder key suffixes. Validates both missing translations and invalid key suffix patterns for resources with placeholders.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`assembly`&nbsp;&nbsp;-&nbsp;&nbsp;The assembly containing localization resources.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`cultureNames`&nbsp;&nbsp;-&nbsp;&nbsp;The list of culture names to validate (e.g., "en-US", "da-DK").<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`allowSuffixTermsForKeySuffixWithPlaceholders`&nbsp;&nbsp;-&nbsp;&nbsp;Optional list of suffix terms allowed before numeric suffixes in keys with placeholders.<br />
#### AssertLocalizationResourcesForInvalidKeysSuffixWithPlaceholders
>```csharp
>void AssertLocalizationResourcesForInvalidKeysSuffixWithPlaceholders(Assembly assembly, IList<string> cultureNames, IList<string> allowSuffixTermsForKeySuffixWithPlaceholders = null)
>```
><b>Summary:</b> Asserts that localization resource keys with placeholders have valid numeric suffixes. Validates that keys like "Message2" have exactly 2 placeholders ({0} and {1}).
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`assembly`&nbsp;&nbsp;-&nbsp;&nbsp;The assembly containing localization resources.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`cultureNames`&nbsp;&nbsp;-&nbsp;&nbsp;The list of culture names to validate.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`allowSuffixTermsForKeySuffixWithPlaceholders`&nbsp;&nbsp;-&nbsp;&nbsp;Optional list of suffix terms allowed before numeric suffixes in keys with placeholders.<br />
#### AssertLocalizationResourcesForMissingTranslations
>```csharp
>void AssertLocalizationResourcesForMissingTranslations(Assembly assembly, IList<string> cultureNames)
>```
><b>Summary:</b> Asserts that localization resources have all required translations across specified cultures.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`assembly`&nbsp;&nbsp;-&nbsp;&nbsp;The assembly containing localization resources.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`cultureNames`&nbsp;&nbsp;-&nbsp;&nbsp;The list of culture names to validate.<br />

<br />

## CodeComplianceTestHelper
Provides helper methods for asserting code compliance related to test coverage.

>```csharp
>public static class CodeComplianceTestHelper
>```

### Static Methods

#### AssertExportedMethodsWithMissingTests
>```csharp
>void AssertExportedMethodsWithMissingTests(DecompilerType decompilerType, Type sourceType, Type testType, bool useFullName = False)
>```
><b>Summary:</b> Asserts that all public methods in a source type have corresponding unit tests. Fails the test if any methods are missing test coverage.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`decompilerType`&nbsp;&nbsp;-&nbsp;&nbsp;The  to use for analyzing test method bodies.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`sourceType`&nbsp;&nbsp;-&nbsp;&nbsp;The source type to validate for test coverage.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`testType`&nbsp;&nbsp;-&nbsp;&nbsp;The test type containing unit tests for the source type.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`useFullName`&nbsp;&nbsp;-&nbsp;&nbsp;If set to true, use full type names in output.<br />
#### AssertExportedMethodsWithMissingTests
>```csharp
>void AssertExportedMethodsWithMissingTests(DecompilerType decompilerType, Type sourceType, Assembly testAssembly, bool useFullName = False)
>```
><b>Summary:</b> Asserts that all public methods in a source type have corresponding unit tests. Fails the test if any methods are missing test coverage.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`decompilerType`&nbsp;&nbsp;-&nbsp;&nbsp;The  to use for analyzing test method bodies.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`sourceType`&nbsp;&nbsp;-&nbsp;&nbsp;The source type to validate for test coverage.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`testType`&nbsp;&nbsp;-&nbsp;&nbsp;The test type containing unit tests for the source type.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`useFullName`&nbsp;&nbsp;-&nbsp;&nbsp;If set to true, use full type names in output.<br />
#### AssertExportedMethodsWithMissingTests
>```csharp
>void AssertExportedMethodsWithMissingTests(DecompilerType decompilerType, Assembly sourceAssembly, Assembly testAssembly, List<Type> excludeSourceTypes = null, bool useFullName = False)
>```
><b>Summary:</b> Asserts that all public methods in a source type have corresponding unit tests. Fails the test if any methods are missing test coverage.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`decompilerType`&nbsp;&nbsp;-&nbsp;&nbsp;The  to use for analyzing test method bodies.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`sourceType`&nbsp;&nbsp;-&nbsp;&nbsp;The source type to validate for test coverage.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`testType`&nbsp;&nbsp;-&nbsp;&nbsp;The test type containing unit tests for the source type.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`useFullName`&nbsp;&nbsp;-&nbsp;&nbsp;If set to true, use full type names in output.<br />
#### CollectExportedMethodsWithMissingTestsAndGenerateText
>```csharp
>string CollectExportedMethodsWithMissingTestsAndGenerateText(DecompilerType decompilerType, Assembly sourceAssembly, Assembly testAssembly, List<Type> excludeSourceTypes = null, bool useFullName = False)
>```
><b>Summary:</b> Collects exported methods with missing tests and generates a formatted text report.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`decompilerType`&nbsp;&nbsp;-&nbsp;&nbsp;The  to use for analyzing test method bodies.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`sourceAssembly`&nbsp;&nbsp;-&nbsp;&nbsp;The source assembly to analyze.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`testAssembly`&nbsp;&nbsp;-&nbsp;&nbsp;The test assembly to search for unit tests.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`excludeSourceTypes`&nbsp;&nbsp;-&nbsp;&nbsp;Optional list of source types to exclude from analysis.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`useFullName`&nbsp;&nbsp;-&nbsp;&nbsp;If set to true, use full type names in output.<br />
>
><b>Returns:</b> A multi-line string containing all method signatures missing tests.
#### CollectExportedMethodsWithMissingTestsAndGenerateTextLines
>```csharp
>string[] CollectExportedMethodsWithMissingTestsAndGenerateTextLines(DecompilerType decompilerType, Assembly sourceAssembly, Assembly testAssembly, List<Type> excludeSourceTypes = null, bool useFullName = False)
>```
><b>Summary:</b> Collects exported methods with missing tests and generates an array of formatted method signatures.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`decompilerType`&nbsp;&nbsp;-&nbsp;&nbsp;The  to use for analyzing test method bodies.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`sourceAssembly`&nbsp;&nbsp;-&nbsp;&nbsp;The source assembly to analyze.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`testAssembly`&nbsp;&nbsp;-&nbsp;&nbsp;The test assembly to search for unit tests.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`excludeSourceTypes`&nbsp;&nbsp;-&nbsp;&nbsp;Optional list of source types to exclude from analysis.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`useFullName`&nbsp;&nbsp;-&nbsp;&nbsp;If set to true, use full type names in output.<br />
>
><b>Returns:</b> An array of strings containing beautified method signatures.
#### CollectExportedMethodsWithMissingTestsFromAssembly
>```csharp
>MethodInfo[] CollectExportedMethodsWithMissingTestsFromAssembly(DecompilerType decompilerType, Assembly sourceAssembly, Assembly testAssembly, List<Type> excludeSourceTypes = null)
>```
><b>Summary:</b> Collects all exported methods from an assembly that are missing test coverage.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`decompilerType`&nbsp;&nbsp;-&nbsp;&nbsp;The  to use for analyzing test method bodies.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`sourceAssembly`&nbsp;&nbsp;-&nbsp;&nbsp;The source assembly to analyze.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`testAssembly`&nbsp;&nbsp;-&nbsp;&nbsp;The test assembly to search for unit tests.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`excludeSourceTypes`&nbsp;&nbsp;-&nbsp;&nbsp;Optional list of source types to exclude from analysis.<br />
>
><b>Returns:</b> An array of `System.Reflection.MethodInfo` objects representing methods missing test coverage.
#### CollectExportedMethodsWithMissingTestsToExcel
>```csharp
>void CollectExportedMethodsWithMissingTestsToExcel(DecompilerType decompilerType, Assembly sourceAssembly, Assembly testAssembly, List<Type> excludeSourceTypes = null)
>```
><b>Summary:</b> Collects exported methods with missing tests and exports them to an Excel file at C:\Temp.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`decompilerType`&nbsp;&nbsp;-&nbsp;&nbsp;The  to use for analyzing test method bodies.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`sourceAssembly`&nbsp;&nbsp;-&nbsp;&nbsp;The source assembly to analyze.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`testAssembly`&nbsp;&nbsp;-&nbsp;&nbsp;The test assembly to search for unit tests.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`excludeSourceTypes`&nbsp;&nbsp;-&nbsp;&nbsp;Optional list of source types to exclude from analysis.<br />
#### CollectExportedMethodsWithMissingTestsToExcel
>```csharp
>void CollectExportedMethodsWithMissingTestsToExcel(DecompilerType decompilerType, DirectoryInfo reportDirectory, Assembly sourceAssembly, Assembly testAssembly, List<Type> excludeSourceTypes = null)
>```
><b>Summary:</b> Collects exported methods with missing tests and exports them to an Excel file at C:\Temp.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`decompilerType`&nbsp;&nbsp;-&nbsp;&nbsp;The  to use for analyzing test method bodies.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`sourceAssembly`&nbsp;&nbsp;-&nbsp;&nbsp;The source assembly to analyze.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`testAssembly`&nbsp;&nbsp;-&nbsp;&nbsp;The test assembly to search for unit tests.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`excludeSourceTypes`&nbsp;&nbsp;-&nbsp;&nbsp;Optional list of source types to exclude from analysis.<br />
#### CollectExportedTypesWithMissingTests
>```csharp
>Type[] CollectExportedTypesWithMissingTests(DecompilerType decompilerType, Assembly sourceAssembly, Assembly testAssembly, List<Type> excludeSourceTypes = null)
>```
><b>Summary:</b> Collects all exported types that have at least one method missing test coverage.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`decompilerType`&nbsp;&nbsp;-&nbsp;&nbsp;The  to use for analyzing test method bodies.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`sourceAssembly`&nbsp;&nbsp;-&nbsp;&nbsp;The source assembly to analyze.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`testAssembly`&nbsp;&nbsp;-&nbsp;&nbsp;The test assembly to search for unit tests.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`excludeSourceTypes`&nbsp;&nbsp;-&nbsp;&nbsp;Optional list of source types to exclude from analysis.<br />
>
><b>Returns:</b> An array of types that have methods missing test coverage.
#### CollectExportedTypesWithMissingTestsAndGenerateText
>```csharp
>string CollectExportedTypesWithMissingTestsAndGenerateText(DecompilerType decompilerType, Assembly sourceAssembly, Assembly testAssembly, List<Type> excludeSourceTypes = null, bool useFullName = False)
>```
><b>Summary:</b> Collects exported types with missing tests and generates a C# code snippet for an exclude list. Useful for generating initial exclude lists when adding test coverage validation.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`decompilerType`&nbsp;&nbsp;-&nbsp;&nbsp;The  to use for analyzing test method bodies.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`sourceAssembly`&nbsp;&nbsp;-&nbsp;&nbsp;The source assembly to analyze.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`testAssembly`&nbsp;&nbsp;-&nbsp;&nbsp;The test assembly to search for unit tests.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`excludeSourceTypes`&nbsp;&nbsp;-&nbsp;&nbsp;Optional list of source types to exclude from analysis.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`useFullName`&nbsp;&nbsp;-&nbsp;&nbsp;If set to true, use full type names in output.<br />
>
><b>Returns:</b> A formatted C# code snippet containing a list of typeof() expressions for types missing tests.

<br />

## DecompilerType
Specifies the decompiler strategy to use for analyzing test method bodies.

>```csharp
>public enum DecompilerType
>```


| Value | Name | Description | Summary | 
| --- | --- | --- | --- | 
| 0 | AbstractSyntaxTree | Abstract Syntax Tree | Uses ICSharpCode.Decompiler to build an Abstract Syntax Tree (AST) for analyzing method calls. Provides more detailed analysis but may be slower. | 
| 1 | MonoReflection | Mono Reflection | Uses Mono.Reflection to analyze IL instructions directly. Faster but provides less detailed analysis than AST-based approach. | 



<br />

## IntegrationTestCliBase

>```csharp
>public abstract class IntegrationTestCliBase
>```

### Static Methods

#### GetAppSettingsFileForCli
>```csharp
>FileInfo GetAppSettingsFileForCli(Type programTypeForCliExe, string pathFolderNameFilter)
>```
><b>Summary:</b> Gets the filePath to CLI-Exe file's 'appsettings.json'.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`programTypeForCliExe`&nbsp;&nbsp;-&nbsp;&nbsp;The program type for the cli executable.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`pathFolderNameFilter`&nbsp;&nbsp;-&nbsp;&nbsp;Path should include this folder name.<br />
>
><b>Returns:</b> The filePath to CLI-Exe file's 'appsettings.json'.
>
><b>Remarks:</b> This method will throw exceptions if the CLI-Exe file don't exist or finds too many locations. In case of "too many", please narrow down by using a more specific "searchFrom" path.
>
><b>Code usage:</b>
>```csharp
>FileInfo appSettingsFile = GetAppSettingsFileForCli(programTypeForCliExe);
>```
>
><b>Code example:</b>
>```csharp
>var appSettingsFile = GetAppSettingsFileForCli(typeof(global::Demo.Atc.Console.Spectre.Cli.Program));
>```
#### GetAppSettingsFileForCli
>```csharp
>FileInfo GetAppSettingsFileForCli(Type programTypeForCliExe, string searchFromSubFolderName, string pathFolderNameFilter)
>```
><b>Summary:</b> Gets the filePath to CLI-Exe file's 'appsettings.json'.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`programTypeForCliExe`&nbsp;&nbsp;-&nbsp;&nbsp;The program type for the cli executable.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`pathFolderNameFilter`&nbsp;&nbsp;-&nbsp;&nbsp;Path should include this folder name.<br />
>
><b>Returns:</b> The filePath to CLI-Exe file's 'appsettings.json'.
>
><b>Remarks:</b> This method will throw exceptions if the CLI-Exe file don't exist or finds too many locations. In case of "too many", please narrow down by using a more specific "searchFrom" path.
>
><b>Code usage:</b>
>```csharp
>FileInfo appSettingsFile = GetAppSettingsFileForCli(programTypeForCliExe);
>```
>
><b>Code example:</b>
>```csharp
>var appSettingsFile = GetAppSettingsFileForCli(typeof(global::Demo.Atc.Console.Spectre.Cli.Program));
>```
#### GetAppSettingsFileForCli
>```csharp
>FileInfo GetAppSettingsFileForCli(Type programTypeForCliExe, DirectoryInfo searchFromPath)
>```
><b>Summary:</b> Gets the filePath to CLI-Exe file's 'appsettings.json'.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`programTypeForCliExe`&nbsp;&nbsp;-&nbsp;&nbsp;The program type for the cli executable.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`pathFolderNameFilter`&nbsp;&nbsp;-&nbsp;&nbsp;Path should include this folder name.<br />
>
><b>Returns:</b> The filePath to CLI-Exe file's 'appsettings.json'.
>
><b>Remarks:</b> This method will throw exceptions if the CLI-Exe file don't exist or finds too many locations. In case of "too many", please narrow down by using a more specific "searchFrom" path.
>
><b>Code usage:</b>
>```csharp
>FileInfo appSettingsFile = GetAppSettingsFileForCli(programTypeForCliExe);
>```
>
><b>Code example:</b>
>```csharp
>var appSettingsFile = GetAppSettingsFileForCli(typeof(global::Demo.Atc.Console.Spectre.Cli.Program));
>```
#### GetExecutableFileForCli
>```csharp
>FileInfo GetExecutableFileForCli(Type programTypeForCliExe, string pathFolderNameFilter)
>```
><b>Summary:</b> Gets the filePath to CLI-Exe file.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`programTypeForCliExe`&nbsp;&nbsp;-&nbsp;&nbsp;The program type for the cli executable.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`pathFolderNameFilter`&nbsp;&nbsp;-&nbsp;&nbsp;Path should include this folder name.<br />
>
><b>Returns:</b> The filePath to CLI-Exe file.
>
><b>Remarks:</b> This method will throw exceptions if the CLI-Exe file don't exist or finds too many locations. In case of "too many", please narrow down by using a more specific "searchFrom" path.
>
><b>Code usage:</b>
>```csharp
>FileInfo cliFile = GetExecutableFileForCli(programTypeForCliExe);
>```
>
><b>Code example:</b>
>```csharp
>var cliFile = GetExecutableFileForCli(typeof(global::Demo.Atc.Console.Spectre.Cli.Program));
>```
#### GetExecutableFileForCli
>```csharp
>FileInfo GetExecutableFileForCli(Type programTypeForCliExe, string searchFromSubFolderName, string pathFolderNameFilter)
>```
><b>Summary:</b> Gets the filePath to CLI-Exe file.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`programTypeForCliExe`&nbsp;&nbsp;-&nbsp;&nbsp;The program type for the cli executable.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`pathFolderNameFilter`&nbsp;&nbsp;-&nbsp;&nbsp;Path should include this folder name.<br />
>
><b>Returns:</b> The filePath to CLI-Exe file.
>
><b>Remarks:</b> This method will throw exceptions if the CLI-Exe file don't exist or finds too many locations. In case of "too many", please narrow down by using a more specific "searchFrom" path.
>
><b>Code usage:</b>
>```csharp
>FileInfo cliFile = GetExecutableFileForCli(programTypeForCliExe);
>```
>
><b>Code example:</b>
>```csharp
>var cliFile = GetExecutableFileForCli(typeof(global::Demo.Atc.Console.Spectre.Cli.Program));
>```
#### GetExecutableFileForCli
>```csharp
>FileInfo GetExecutableFileForCli(Type programTypeForCliExe, DirectoryInfo searchFromPath, string pathFolderNameFilter)
>```
><b>Summary:</b> Gets the filePath to CLI-Exe file.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`programTypeForCliExe`&nbsp;&nbsp;-&nbsp;&nbsp;The program type for the cli executable.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`pathFolderNameFilter`&nbsp;&nbsp;-&nbsp;&nbsp;Path should include this folder name.<br />
>
><b>Returns:</b> The filePath to CLI-Exe file.
>
><b>Remarks:</b> This method will throw exceptions if the CLI-Exe file don't exist or finds too many locations. In case of "too many", please narrow down by using a more specific "searchFrom" path.
>
><b>Code usage:</b>
>```csharp
>FileInfo cliFile = GetExecutableFileForCli(programTypeForCliExe);
>```
>
><b>Code example:</b>
>```csharp
>var cliFile = GetExecutableFileForCli(typeof(global::Demo.Atc.Console.Spectre.Cli.Program));
>```

<br />

## SerializeAndDeserializeHelper
Provides helper methods for testing JSON serialization and deserialization.

>```csharp
>public static class SerializeAndDeserializeHelper
>```

### Static Methods

#### Assert
>```csharp
>void Assert(object obj)
>```
><b>Summary:</b> Asserts that an object can be serialized to JSON and deserialized back to the original type with equal values.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`obj`&nbsp;&nbsp;-&nbsp;&nbsp;The object to serialize and deserialize.<br />

<br />

## TestResult
TestResult.

>```csharp
>public class TestResult
>```

### Properties

#### IndentLevel
>```csharp
>IndentLevel
>```
><b>Summary:</b> Gets the indent level.
#### IsError
>```csharp
>IsError
>```
><b>Summary:</b> Gets a value indicating whether this instance is error.
#### SubLines
>```csharp
>SubLines
>```
><b>Summary:</b> Gets the sub lines.
#### Text
>```csharp
>Text
>```
><b>Summary:</b> Gets the text.
### Methods

#### ToString
>```csharp
>string ToString()
>```
><b>Summary:</b> Converts to string.
>
><b>Returns:</b> A string that represents this instance.

<br />

## TestResultHelper
TestResultHelper.

>```csharp
>public static class TestResultHelper
>```

### Static Methods

#### AssertOnTestResults
>```csharp
>void AssertOnTestResults(IReadOnlyCollection<TestResult> testResults)
>```
><b>Summary:</b> Asserts the on test results.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`testResults`&nbsp;&nbsp;-&nbsp;&nbsp;The test results.<br />
#### AssertOnTestResultsFromMethodsWithMissingTests
>```csharp
>void AssertOnTestResultsFromMethodsWithMissingTests(string assemblyName, MethodInfo[] methodsWithMissingTests, bool useFullName = False)
>```
><b>Summary:</b> Asserts the on test results from methods with missing tests.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`assemblyName`&nbsp;&nbsp;-&nbsp;&nbsp;Name of the assembly.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`methodsWithMissingTests`&nbsp;&nbsp;-&nbsp;&nbsp;The methods with missing tests.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`useFullName`&nbsp;&nbsp;-&nbsp;&nbsp;if set to  [use full name].<br />
#### AssertOnTestResultsFromMethodsWithWrongDefinitions
>```csharp
>void AssertOnTestResultsFromMethodsWithWrongDefinitions(string assemblyName, IDictionary<MethodInfo, string> methodsWithWrongNaming, bool useFullName = False)
>```
><b>Summary:</b> Asserts the on test results from methods with wrong definitions.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`assemblyName`&nbsp;&nbsp;-&nbsp;&nbsp;Name of the assembly.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`methodsWithWrongNaming`&nbsp;&nbsp;-&nbsp;&nbsp;The methods with wrong naming.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`useFullName`&nbsp;&nbsp;-&nbsp;&nbsp;if set to  [use full name].<br />
#### AssertOnTestResultsFromMissingTranslationsAndInvalidKeysSuffixWithPlaceholders
>```csharp
>void AssertOnTestResultsFromMissingTranslationsAndInvalidKeysSuffixWithPlaceholders(string assemblyName, IDictionary<string, Dictionary<string, List<string>>> missingTranslations, IDictionary<string, Dictionary<string, List<string>>> invalidKeysSuffixWithPlaceholders)
>```
><b>Summary:</b> Asserts on test results from missing translations and invalid resource keys with placeholder suffix issues.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`assemblyName`&nbsp;&nbsp;-&nbsp;&nbsp;Name of the assembly.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`missingTranslations`&nbsp;&nbsp;-&nbsp;&nbsp;Dictionary of resource managers with missing translations by culture.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`invalidKeysSuffixWithPlaceholders`&nbsp;&nbsp;-&nbsp;&nbsp;Dictionary of resource managers with invalid key suffixes for placeholders.<br />
#### ToExcelTestResultsFromMethodsWithMissingTests
>```csharp
>void ToExcelTestResultsFromMethodsWithMissingTests(DirectoryInfo reportDirectory, string assemblyName, MethodInfo[] methodsWithMissingTests)
>```
><b>Summary:</b> To Excel with the test results from methods with missing tests.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`reportDirectory`&nbsp;&nbsp;-&nbsp;&nbsp;The report directory.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`assemblyName`&nbsp;&nbsp;-&nbsp;&nbsp;Name of the assembly.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`methodsWithMissingTests`&nbsp;&nbsp;-&nbsp;&nbsp;The methods with missing tests.<br />

<br />

## Traits
Provides constants for xUnit test trait names and values.

>```csharp
>public static class Traits
>```

### Static Fields

#### Category
>```csharp
>string Category
>```
><b>Summary:</b> The "Category" trait name used to categorize tests.
<hr /><div style='text-align: right'><i>Generated by MarkdownCodeDoc version 1.2</i></div>
