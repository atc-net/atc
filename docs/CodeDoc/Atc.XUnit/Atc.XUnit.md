<div style='text-align: right'>

[References](Index.md)&nbsp;&nbsp;-&nbsp;&nbsp;[References extended](IndexExtended.md)
</div>

# Atc.XUnit

<br />

## AtcXUnitAssemblyTypeInitializer

>```csharp
>public static class AtcXUnitAssemblyTypeInitializer
>```


<br />

## CodeComplianceDocumentationHelper
CodeComplianceDocumentationHelper.

>```csharp
>public static class CodeComplianceDocumentationHelper
>```

### Static Methods

#### AssertExportedTypeWithMissingComments
>```csharp
>void AssertExportedTypeWithMissingComments(Type type)
>```
><b>Summary:</b> Asserts the exported type with missing comments.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`type`&nbsp;&nbsp;-&nbsp;&nbsp;The type.<br />
#### AssertExportedTypesWithMissingComments
>```csharp
>void AssertExportedTypesWithMissingComments(Assembly assembly, List<Type> excludeTypes = null)
>```
><b>Summary:</b> Asserts the exported types with missing comments.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`assembly`&nbsp;&nbsp;-&nbsp;&nbsp;The assembly.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`excludeTypes`&nbsp;&nbsp;-&nbsp;&nbsp;The exclude types.<br />

<br />

## CodeComplianceHelper
CodeComplianceNamingHelper.

>```csharp
>public static class CodeComplianceHelper
>```

### Static Methods

#### AssertExportedTypesWithWrongDefinitions
>```csharp
>void AssertExportedTypesWithWrongDefinitions(Type type, bool useFullName = False)
>```
><b>Summary:</b> Asserts the exported types with wrong definitions.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`type`&nbsp;&nbsp;-&nbsp;&nbsp;The type.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`useFullName`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [use full name].<br />
#### AssertExportedTypesWithWrongDefinitions
>```csharp
>void AssertExportedTypesWithWrongDefinitions(Assembly assembly, List<Type> excludeTypes = null, bool useFullName = False)
>```
><b>Summary:</b> Asserts the exported types with wrong definitions.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`type`&nbsp;&nbsp;-&nbsp;&nbsp;The type.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`useFullName`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [use full name].<br />
#### AssertLocalizationResources
>```csharp
>void AssertLocalizationResources(Assembly assembly, IList<string> cultureNames, IList<string> allowSuffixTermsForKeySuffixWithPlaceholders = null)
>```
#### AssertLocalizationResourcesForInvalidKeysSuffixWithPlaceholders
>```csharp
>void AssertLocalizationResourcesForInvalidKeysSuffixWithPlaceholders(Assembly assembly, IList<string> cultureNames, IList<string> allowSuffixTermsForKeySuffixWithPlaceholders = null)
>```
#### AssertLocalizationResourcesForMissingTranslations
>```csharp
>void AssertLocalizationResourcesForMissingTranslations(Assembly assembly, IList<string> cultureNames)
>```

<br />

## CodeComplianceTestHelper
CodeComplianceTestHelper.

>```csharp
>public static class CodeComplianceTestHelper
>```

### Static Methods

#### AssertExportedMethodsWithMissingTests
>```csharp
>void AssertExportedMethodsWithMissingTests(DecompilerType decompilerType, Type sourceType, Type testType, bool useFullName = False)
>```
><b>Summary:</b> Asserts the exported methods with missing tests.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`decompilerType`&nbsp;&nbsp;-&nbsp;&nbsp;The decompiler type.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`sourceType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the source.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`testType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the test.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`useFullName`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [use full name].<br />
#### AssertExportedMethodsWithMissingTests
>```csharp
>void AssertExportedMethodsWithMissingTests(DecompilerType decompilerType, Type sourceType, Assembly testAssembly, bool useFullName = False)
>```
><b>Summary:</b> Asserts the exported methods with missing tests.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`decompilerType`&nbsp;&nbsp;-&nbsp;&nbsp;The decompiler type.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`sourceType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the source.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`testType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the test.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`useFullName`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [use full name].<br />
#### AssertExportedMethodsWithMissingTests
>```csharp
>void AssertExportedMethodsWithMissingTests(DecompilerType decompilerType, Assembly sourceAssembly, Assembly testAssembly, List<Type> excludeSourceTypes = null, bool useFullName = False)
>```
><b>Summary:</b> Asserts the exported methods with missing tests.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`decompilerType`&nbsp;&nbsp;-&nbsp;&nbsp;The decompiler type.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`sourceType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the source.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`testType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the test.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`useFullName`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [use full name].<br />
#### CollectExportedMethodsWithMissingTestsAndGenerateText
>```csharp
>string CollectExportedMethodsWithMissingTestsAndGenerateText(DecompilerType decompilerType, Assembly sourceAssembly, Assembly testAssembly, List<Type> excludeSourceTypes = null, bool useFullName = False)
>```
><b>Summary:</b> Collects the exported methods with missing tests and generate text.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`decompilerType`&nbsp;&nbsp;-&nbsp;&nbsp;The decompiler type.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`sourceAssembly`&nbsp;&nbsp;-&nbsp;&nbsp;The source assembly.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`testAssembly`&nbsp;&nbsp;-&nbsp;&nbsp;The test assembly.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`excludeSourceTypes`&nbsp;&nbsp;-&nbsp;&nbsp;The exclude source types.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`useFullName`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [use full name].<br />
#### CollectExportedMethodsWithMissingTestsAndGenerateTextLines
>```csharp
>string[] CollectExportedMethodsWithMissingTestsAndGenerateTextLines(DecompilerType decompilerType, Assembly sourceAssembly, Assembly testAssembly, List<Type> excludeSourceTypes = null, bool useFullName = False)
>```
><b>Summary:</b> Collects the exported methods with missing tests and generate text lines.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`decompilerType`&nbsp;&nbsp;-&nbsp;&nbsp;The decompiler type.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`sourceAssembly`&nbsp;&nbsp;-&nbsp;&nbsp;The source assembly.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`testAssembly`&nbsp;&nbsp;-&nbsp;&nbsp;The test assembly.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`excludeSourceTypes`&nbsp;&nbsp;-&nbsp;&nbsp;The exclude source types.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`useFullName`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [use full name].<br />
#### CollectExportedMethodsWithMissingTestsFromAssembly
>```csharp
>MethodInfo[] CollectExportedMethodsWithMissingTestsFromAssembly(DecompilerType decompilerType, Assembly sourceAssembly, Assembly testAssembly, List<Type> excludeSourceTypes = null)
>```
><b>Summary:</b> Collects the exported methods with missing tests from assembly.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`decompilerType`&nbsp;&nbsp;-&nbsp;&nbsp;The decompiler type.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`sourceAssembly`&nbsp;&nbsp;-&nbsp;&nbsp;The source assembly.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`testAssembly`&nbsp;&nbsp;-&nbsp;&nbsp;The test assembly.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`excludeSourceTypes`&nbsp;&nbsp;-&nbsp;&nbsp;The exclude source types.<br />
#### CollectExportedMethodsWithMissingTestsToExcel
>```csharp
>void CollectExportedMethodsWithMissingTestsToExcel(DecompilerType decompilerType, Assembly sourceAssembly, Assembly testAssembly, List<Type> excludeSourceTypes = null)
>```
><b>Summary:</b> Collects the exported methods with missing tests to excel.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`decompilerType`&nbsp;&nbsp;-&nbsp;&nbsp;The decompiler type.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`sourceAssembly`&nbsp;&nbsp;-&nbsp;&nbsp;The source assembly.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`testAssembly`&nbsp;&nbsp;-&nbsp;&nbsp;The test assembly.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`excludeSourceTypes`&nbsp;&nbsp;-&nbsp;&nbsp;The exclude source types.<br />
#### CollectExportedMethodsWithMissingTestsToExcel
>```csharp
>void CollectExportedMethodsWithMissingTestsToExcel(DecompilerType decompilerType, DirectoryInfo reportDirectory, Assembly sourceAssembly, Assembly testAssembly, List<Type> excludeSourceTypes = null)
>```
><b>Summary:</b> Collects the exported methods with missing tests to excel.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`decompilerType`&nbsp;&nbsp;-&nbsp;&nbsp;The decompiler type.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`sourceAssembly`&nbsp;&nbsp;-&nbsp;&nbsp;The source assembly.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`testAssembly`&nbsp;&nbsp;-&nbsp;&nbsp;The test assembly.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`excludeSourceTypes`&nbsp;&nbsp;-&nbsp;&nbsp;The exclude source types.<br />
#### CollectExportedTypesWithMissingTests
>```csharp
>Type[] CollectExportedTypesWithMissingTests(DecompilerType decompilerType, Assembly sourceAssembly, Assembly testAssembly, List<Type> excludeSourceTypes = null)
>```
><b>Summary:</b> Collects the exported types with missing tests.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`decompilerType`&nbsp;&nbsp;-&nbsp;&nbsp;The decompiler type.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`sourceAssembly`&nbsp;&nbsp;-&nbsp;&nbsp;The source assembly.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`testAssembly`&nbsp;&nbsp;-&nbsp;&nbsp;The test assembly.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`excludeSourceTypes`&nbsp;&nbsp;-&nbsp;&nbsp;The exclude source types.<br />
#### CollectExportedTypesWithMissingTestsAndGenerateText
>```csharp
>string CollectExportedTypesWithMissingTestsAndGenerateText(DecompilerType decompilerType, Assembly sourceAssembly, Assembly testAssembly, List<Type> excludeSourceTypes = null, bool useFullName = False)
>```
><b>Summary:</b> Collects the exported types with missing tests and generate text.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`decompilerType`&nbsp;&nbsp;-&nbsp;&nbsp;The decompiler type.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`sourceAssembly`&nbsp;&nbsp;-&nbsp;&nbsp;The source assembly.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`testAssembly`&nbsp;&nbsp;-&nbsp;&nbsp;The test assembly.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`excludeSourceTypes`&nbsp;&nbsp;-&nbsp;&nbsp;The exclude source types.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`useFullName`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [use full name].<br />

<br />

## DecompilerType
DecompilerType.

>```csharp
>public enum DecompilerType
>```


| Value | Name | Description | Summary | 
| --- | --- | --- | --- | 
| 0 | AbstractSyntaxTree | Abstract Syntax Tree | The abstract syntax tree | 
| 1 | MonoReflection | Mono Reflection | The mono reflection | 



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

>```csharp
>public static class SerializeAndDeserializeHelper
>```

### Static Methods

#### Assert
>```csharp
>void Assert(object obj)
>```

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
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`useFullName`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [use full name].<br />
#### AssertOnTestResultsFromMethodsWithWrongDefinitions
>```csharp
>void AssertOnTestResultsFromMethodsWithWrongDefinitions(string assemblyName, IDictionary<MethodInfo, string> methodsWithWrongNaming, bool useFullName = False)
>```
><b>Summary:</b> Asserts the on test results from methods with wrong definitions.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`assemblyName`&nbsp;&nbsp;-&nbsp;&nbsp;Name of the assembly.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`methodsWithWrongNaming`&nbsp;&nbsp;-&nbsp;&nbsp;The methods with wrong naming.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`useFullName`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [use full name].<br />
#### AssertOnTestResultsFromMissingTranslationsAndInvalidKeysSuffixWithPlaceholders
>```csharp
>void AssertOnTestResultsFromMissingTranslationsAndInvalidKeysSuffixWithPlaceholders(string assemblyName, IDictionary<string, Dictionary<string, List<string>>> missingTranslations, IDictionary<string, Dictionary<string, List<string>>> invalidKeysSuffixWithPlaceholders)
>```
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

>```csharp
>public static class Traits
>```

### Static Fields

#### Category
>```csharp
>string Category
>```
<hr /><div style='text-align: right'><i>Generated by MarkdownCodeDoc version 1.2</i></div>
