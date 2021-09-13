<div style='text-align: right'>

[References](Index.md)&nbsp;&nbsp;-&nbsp;&nbsp;[References extended](IndexExtended.md)
</div>

# Atc.XUnit

<br />


## AtcXUnitAssemblyTypeInitializer

```csharp
public class AtcXUnitAssemblyTypeInitializer
```


<br />


## CodeComplianceDocumentationHelper
CodeComplianceDocumentationHelper.


```csharp
public static class CodeComplianceDocumentationHelper
```

### Static Methods


#### AssertExportedTypesWithMissingComments

```csharp
void AssertExportedTypesWithMissingComments(Assembly assembly, List<Type> excludeTypes = null)
```
<p><b>Summary:</b> Asserts the exported types with missing comments.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`assembly`&nbsp;&nbsp;-&nbsp;&nbsp;The assembly.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`excludeTypes`&nbsp;&nbsp;-&nbsp;&nbsp;The exclude types.<br />
#### AssertExportedTypeWithMissingComments

```csharp
void AssertExportedTypeWithMissingComments(Type type)
```
<p><b>Summary:</b> Asserts the exported type with missing comments.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`type`&nbsp;&nbsp;-&nbsp;&nbsp;The type.<br />

<br />


## CodeComplianceHelper
CodeComplianceNamingHelper.


```csharp
public static class CodeComplianceHelper
```

### Static Methods


#### AssertExportedTypesWithWrongDefinitions

```csharp
void AssertExportedTypesWithWrongDefinitions(Type type, bool useFullName = False)
```
<p><b>Summary:</b> Asserts the exported types with wrong definitions.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`type`&nbsp;&nbsp;-&nbsp;&nbsp;The type.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`useFullName`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [use full name].<br />
#### AssertExportedTypesWithWrongDefinitions

```csharp
void AssertExportedTypesWithWrongDefinitions(Assembly assembly, List<Type> excludeTypes = null, bool useFullName = False)
```
<p><b>Summary:</b> Asserts the exported types with wrong definitions.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`type`&nbsp;&nbsp;-&nbsp;&nbsp;The type.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`useFullName`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [use full name].<br />

<br />


## CodeComplianceTestHelper
CodeComplianceTestHelper.


```csharp
public static class CodeComplianceTestHelper
```

### Static Methods


#### AssertExportedMethodsWithMissingTests

```csharp
void AssertExportedMethodsWithMissingTests(DecompilerType decompilerType, Type sourceType, Type testType, bool useFullName = False)
```
<p><b>Summary:</b> Asserts the exported methods with missing tests.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`decompilerType`&nbsp;&nbsp;-&nbsp;&nbsp;The decompiler type.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`sourceType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the source.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`testType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the test.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`useFullName`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [use full name].<br />
#### AssertExportedMethodsWithMissingTests

```csharp
void AssertExportedMethodsWithMissingTests(DecompilerType decompilerType, Type sourceType, Assembly testAssembly, bool useFullName = False)
```
<p><b>Summary:</b> Asserts the exported methods with missing tests.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`decompilerType`&nbsp;&nbsp;-&nbsp;&nbsp;The decompiler type.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`sourceType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the source.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`testType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the test.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`useFullName`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [use full name].<br />
#### AssertExportedMethodsWithMissingTests

```csharp
void AssertExportedMethodsWithMissingTests(DecompilerType decompilerType, Assembly sourceAssembly, Assembly testAssembly, List<Type> excludeSourceTypes = null, bool useFullName = False)
```
<p><b>Summary:</b> Asserts the exported methods with missing tests.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`decompilerType`&nbsp;&nbsp;-&nbsp;&nbsp;The decompiler type.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`sourceType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the source.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`testType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the test.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`useFullName`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [use full name].<br />
#### CollectExportedMethodsWithMissingTestsAndGenerateText

```csharp
string CollectExportedMethodsWithMissingTestsAndGenerateText(DecompilerType decompilerType, Assembly sourceAssembly, Assembly testAssembly, List<Type> excludeSourceTypes = null, bool useFullName = False)
```
<p><b>Summary:</b> Collects the exported methods with missing tests and generate text.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`decompilerType`&nbsp;&nbsp;-&nbsp;&nbsp;The decompiler type.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`sourceAssembly`&nbsp;&nbsp;-&nbsp;&nbsp;The source assembly.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`testAssembly`&nbsp;&nbsp;-&nbsp;&nbsp;The test assembly.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`excludeSourceTypes`&nbsp;&nbsp;-&nbsp;&nbsp;The exclude source types.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`useFullName`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [use full name].<br />
#### CollectExportedMethodsWithMissingTestsAndGenerateTextLines

```csharp
string[] CollectExportedMethodsWithMissingTestsAndGenerateTextLines(DecompilerType decompilerType, Assembly sourceAssembly, Assembly testAssembly, List<Type> excludeSourceTypes = null, bool useFullName = False)
```
<p><b>Summary:</b> Collects the exported methods with missing tests and generate text lines.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`decompilerType`&nbsp;&nbsp;-&nbsp;&nbsp;The decompiler type.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`sourceAssembly`&nbsp;&nbsp;-&nbsp;&nbsp;The source assembly.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`testAssembly`&nbsp;&nbsp;-&nbsp;&nbsp;The test assembly.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`excludeSourceTypes`&nbsp;&nbsp;-&nbsp;&nbsp;The exclude source types.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`useFullName`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [use full name].<br />
#### CollectExportedMethodsWithMissingTestsFromAssembly

```csharp
MethodInfo[] CollectExportedMethodsWithMissingTestsFromAssembly(DecompilerType decompilerType, Assembly sourceAssembly, Assembly testAssembly, List<Type> excludeSourceTypes = null)
```
<p><b>Summary:</b> Collects the exported methods with missing tests from assembly.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`decompilerType`&nbsp;&nbsp;-&nbsp;&nbsp;The decompiler type.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`sourceAssembly`&nbsp;&nbsp;-&nbsp;&nbsp;The source assembly.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`testAssembly`&nbsp;&nbsp;-&nbsp;&nbsp;The test assembly.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`excludeSourceTypes`&nbsp;&nbsp;-&nbsp;&nbsp;The exclude source types.<br />
#### CollectExportedMethodsWithMissingTestsToExcel

```csharp
void CollectExportedMethodsWithMissingTestsToExcel(DecompilerType decompilerType, Assembly sourceAssembly, Assembly testAssembly, List<Type> excludeSourceTypes = null)
```
<p><b>Summary:</b> Collects the exported methods with missing tests to excel.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`decompilerType`&nbsp;&nbsp;-&nbsp;&nbsp;The decompiler type.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`sourceAssembly`&nbsp;&nbsp;-&nbsp;&nbsp;The source assembly.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`testAssembly`&nbsp;&nbsp;-&nbsp;&nbsp;The test assembly.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`excludeSourceTypes`&nbsp;&nbsp;-&nbsp;&nbsp;The exclude source types.<br />
#### CollectExportedMethodsWithMissingTestsToExcel

```csharp
void CollectExportedMethodsWithMissingTestsToExcel(DecompilerType decompilerType, DirectoryInfo reportDirectory, Assembly sourceAssembly, Assembly testAssembly, List<Type> excludeSourceTypes = null)
```
<p><b>Summary:</b> Collects the exported methods with missing tests to excel.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`decompilerType`&nbsp;&nbsp;-&nbsp;&nbsp;The decompiler type.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`sourceAssembly`&nbsp;&nbsp;-&nbsp;&nbsp;The source assembly.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`testAssembly`&nbsp;&nbsp;-&nbsp;&nbsp;The test assembly.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`excludeSourceTypes`&nbsp;&nbsp;-&nbsp;&nbsp;The exclude source types.<br />
#### CollectExportedTypesWithMissingTests

```csharp
Type[] CollectExportedTypesWithMissingTests(DecompilerType decompilerType, Assembly sourceAssembly, Assembly testAssembly, List<Type> excludeSourceTypes = null)
```
<p><b>Summary:</b> Collects the exported types with missing tests.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`decompilerType`&nbsp;&nbsp;-&nbsp;&nbsp;The decompiler type.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`sourceAssembly`&nbsp;&nbsp;-&nbsp;&nbsp;The source assembly.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`testAssembly`&nbsp;&nbsp;-&nbsp;&nbsp;The test assembly.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`excludeSourceTypes`&nbsp;&nbsp;-&nbsp;&nbsp;The exclude source types.<br />
#### CollectExportedTypesWithMissingTestsAndGenerateText

```csharp
string CollectExportedTypesWithMissingTestsAndGenerateText(DecompilerType decompilerType, Assembly sourceAssembly, Assembly testAssembly, List<Type> excludeSourceTypes = null, bool useFullName = False)
```
<p><b>Summary:</b> Collects the exported types with missing tests and generate text.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`decompilerType`&nbsp;&nbsp;-&nbsp;&nbsp;The decompiler type.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`sourceAssembly`&nbsp;&nbsp;-&nbsp;&nbsp;The source assembly.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`testAssembly`&nbsp;&nbsp;-&nbsp;&nbsp;The test assembly.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`excludeSourceTypes`&nbsp;&nbsp;-&nbsp;&nbsp;The exclude source types.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`useFullName`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [use full name].<br />

<br />


## DecompilerType
DecompilerType.


```csharp
public enum DecompilerType
```


| Value | Name | Description | Summary | 
| --- | --- | --- | --- | 
| 0 | AbstractSyntaxTree | Abstract Syntax Tree | The abstract syntax tree | 
| 1 | MonoReflection | Mono Reflection | The mono reflection | 



<br />


## IntegrationTestCliBase

```csharp
public abstract class IntegrationTestCliBase
```

### Methods


#### GetAppSettingsFileForCli

```csharp
FileInfo GetAppSettingsFileForCli(Type programTypeForCliExe, string pathFolderNameFilter)
```
<p><b>Summary:</b> Gets the filePath to CLI-Exe file's 'appsettings.json'.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`programTypeForCliExe`&nbsp;&nbsp;-&nbsp;&nbsp;The program type for the cli executable.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`pathFolderNameFilter`&nbsp;&nbsp;-&nbsp;&nbsp;Path should include this folder name.<br />
<p><b>Returns:</b> The filePath to CLI-Exe file's 'appsettings.json'.</p>

<p><b>Remarks:</b> This method will throw exceptions if the CLI-Exe file don't exist or
            finds too many locations. In case of "too many", please narrow down
            by using a more specific "searchFrom" path.</p>

<b>Code usage:</b>

```csharp
FileInfo appSettingsFile = GetAppSettingsFileForCli(programTypeForCliExe);
```
<b>Code example:</b>

```csharp
var appSettingsFile = GetAppSettingsFileForCli(typeof(global::Demo.Atc.Console.Spectre.Cli.Program));
```
#### GetAppSettingsFileForCli

```csharp
FileInfo GetAppSettingsFileForCli(Type programTypeForCliExe, string searchFromSubFolderName, string pathFolderNameFilter)
```
<p><b>Summary:</b> Gets the filePath to CLI-Exe file's 'appsettings.json'.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`programTypeForCliExe`&nbsp;&nbsp;-&nbsp;&nbsp;The program type for the cli executable.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`pathFolderNameFilter`&nbsp;&nbsp;-&nbsp;&nbsp;Path should include this folder name.<br />
<p><b>Returns:</b> The filePath to CLI-Exe file's 'appsettings.json'.</p>

<p><b>Remarks:</b> This method will throw exceptions if the CLI-Exe file don't exist or
            finds too many locations. In case of "too many", please narrow down
            by using a more specific "searchFrom" path.</p>

<b>Code usage:</b>

```csharp
FileInfo appSettingsFile = GetAppSettingsFileForCli(programTypeForCliExe);
```
<b>Code example:</b>

```csharp
var appSettingsFile = GetAppSettingsFileForCli(typeof(global::Demo.Atc.Console.Spectre.Cli.Program));
```
#### GetAppSettingsFileForCli

```csharp
FileInfo GetAppSettingsFileForCli(Type programTypeForCliExe, DirectoryInfo searchFromPath)
```
<p><b>Summary:</b> Gets the filePath to CLI-Exe file's 'appsettings.json'.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`programTypeForCliExe`&nbsp;&nbsp;-&nbsp;&nbsp;The program type for the cli executable.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`pathFolderNameFilter`&nbsp;&nbsp;-&nbsp;&nbsp;Path should include this folder name.<br />
<p><b>Returns:</b> The filePath to CLI-Exe file's 'appsettings.json'.</p>

<p><b>Remarks:</b> This method will throw exceptions if the CLI-Exe file don't exist or
            finds too many locations. In case of "too many", please narrow down
            by using a more specific "searchFrom" path.</p>

<b>Code usage:</b>

```csharp
FileInfo appSettingsFile = GetAppSettingsFileForCli(programTypeForCliExe);
```
<b>Code example:</b>

```csharp
var appSettingsFile = GetAppSettingsFileForCli(typeof(global::Demo.Atc.Console.Spectre.Cli.Program));
```
#### GetExecutableFileForCli

```csharp
FileInfo GetExecutableFileForCli(Type programTypeForCliExe, string pathFolderNameFilter)
```
<p><b>Summary:</b> Gets the filePath to CLI-Exe file.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`programTypeForCliExe`&nbsp;&nbsp;-&nbsp;&nbsp;The program type for the cli executable.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`pathFolderNameFilter`&nbsp;&nbsp;-&nbsp;&nbsp;Path should include this folder name.<br />
<p><b>Returns:</b> The filePath to CLI-Exe file.</p>

<p><b>Remarks:</b> This method will throw exceptions if the CLI-Exe file don't exist or
            finds too many locations. In case of "too many", please narrow down
            by using a more specific "searchFrom" path.</p>

<b>Code usage:</b>

```csharp
FileInfo cliFile = GetExecutableFileForCli(programTypeForCliExe);
```
<b>Code example:</b>

```csharp
var cliFile = GetExecutableFileForCli(typeof(global::Demo.Atc.Console.Spectre.Cli.Program));
```
#### GetExecutableFileForCli

```csharp
FileInfo GetExecutableFileForCli(Type programTypeForCliExe, string searchFromSubFolderName, string pathFolderNameFilter)
```
<p><b>Summary:</b> Gets the filePath to CLI-Exe file.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`programTypeForCliExe`&nbsp;&nbsp;-&nbsp;&nbsp;The program type for the cli executable.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`pathFolderNameFilter`&nbsp;&nbsp;-&nbsp;&nbsp;Path should include this folder name.<br />
<p><b>Returns:</b> The filePath to CLI-Exe file.</p>

<p><b>Remarks:</b> This method will throw exceptions if the CLI-Exe file don't exist or
            finds too many locations. In case of "too many", please narrow down
            by using a more specific "searchFrom" path.</p>

<b>Code usage:</b>

```csharp
FileInfo cliFile = GetExecutableFileForCli(programTypeForCliExe);
```
<b>Code example:</b>

```csharp
var cliFile = GetExecutableFileForCli(typeof(global::Demo.Atc.Console.Spectre.Cli.Program));
```
#### GetExecutableFileForCli

```csharp
FileInfo GetExecutableFileForCli(Type programTypeForCliExe, DirectoryInfo searchFromPath, string pathFolderNameFilter)
```
<p><b>Summary:</b> Gets the filePath to CLI-Exe file.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`programTypeForCliExe`&nbsp;&nbsp;-&nbsp;&nbsp;The program type for the cli executable.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`pathFolderNameFilter`&nbsp;&nbsp;-&nbsp;&nbsp;Path should include this folder name.<br />
<p><b>Returns:</b> The filePath to CLI-Exe file.</p>

<p><b>Remarks:</b> This method will throw exceptions if the CLI-Exe file don't exist or
            finds too many locations. In case of "too many", please narrow down
            by using a more specific "searchFrom" path.</p>

<b>Code usage:</b>

```csharp
FileInfo cliFile = GetExecutableFileForCli(programTypeForCliExe);
```
<b>Code example:</b>

```csharp
var cliFile = GetExecutableFileForCli(typeof(global::Demo.Atc.Console.Spectre.Cli.Program));
```

<br />


## TestResult
TestResult.


```csharp
public class TestResult
```

### Properties


#### IndentLevel

```csharp
IndentLevel
```
<p><b>Summary:</b> Gets the indent level.</p>

#### IsError

```csharp
IsError
```
<p><b>Summary:</b> Gets a value indicating whether this instance is error.</p>

#### SubLines

```csharp
SubLines
```
<p><b>Summary:</b> Gets the sub lines.</p>

#### Text

```csharp
Text
```
<p><b>Summary:</b> Gets the text.</p>

### Methods


#### ToString

```csharp
string ToString()
```
<p><b>Summary:</b> Converts to string.</p>

<p><b>Returns:</b> A string that represents this instance.</p>


<br />


## TestResultHelper
TestResultHelper.


```csharp
public static class TestResultHelper
```

### Static Methods


#### AssertOnTestResults

```csharp
void AssertOnTestResults(IReadOnlyCollection<TestResult> testResults)
```
<p><b>Summary:</b> Asserts the on test results.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`testResults`&nbsp;&nbsp;-&nbsp;&nbsp;The test results.<br />
#### AssertOnTestResultsFromMethodsWithMissingTests

```csharp
void AssertOnTestResultsFromMethodsWithMissingTests(string assemblyName, MethodInfo[] methodsWithMissingTests, bool useFullName = False)
```
<p><b>Summary:</b> Asserts the on test results from methods with missing tests.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`assemblyName`&nbsp;&nbsp;-&nbsp;&nbsp;Name of the assembly.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`methodsWithMissingTests`&nbsp;&nbsp;-&nbsp;&nbsp;The methods with missing tests.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`useFullName`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [use full name].<br />
#### AssertOnTestResultsFromMethodsWithWrongDefinitions

```csharp
void AssertOnTestResultsFromMethodsWithWrongDefinitions(string assemblyName, Dictionary<MethodInfo, string> methodsWithWrongNaming, bool useFullName = False)
```
<p><b>Summary:</b> Asserts the on test results from methods with wrong definitions.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`assemblyName`&nbsp;&nbsp;-&nbsp;&nbsp;Name of the assembly.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`methodsWithWrongNaming`&nbsp;&nbsp;-&nbsp;&nbsp;The methods with wrong naming.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`useFullName`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [use full name].<br />
#### ToExcelTestResultsFromMethodsWithMissingTests

```csharp
void ToExcelTestResultsFromMethodsWithMissingTests(DirectoryInfo reportDirectory, string assemblyName, MethodInfo[] methodsWithMissingTests)
```
<p><b>Summary:</b> To Excel with the test results from methods with missing tests.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`reportDirectory`&nbsp;&nbsp;-&nbsp;&nbsp;The report directory.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`assemblyName`&nbsp;&nbsp;-&nbsp;&nbsp;Name of the assembly.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`methodsWithMissingTests`&nbsp;&nbsp;-&nbsp;&nbsp;The methods with missing tests.<br />
<hr /><div style='text-align: right'><i>Generated by MarkdownCodeDoc version 1.2</i></div>
