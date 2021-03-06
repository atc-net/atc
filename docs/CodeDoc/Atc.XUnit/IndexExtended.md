<div style='text-align: right'>

[References](Index.md)

</div>


# References extended

## [Atc.XUnit](Atc.XUnit.md)

- [AtcXUnitAssemblyTypeInitializer](Atc.XUnit.md#atcxunitassemblytypeinitializer)
- [CodeComplianceDocumentationHelper](Atc.XUnit.md#codecompliancedocumentationhelper)
  -  Static Methods
     - AssertExportedTypesWithMissingComments(Assembly assembly, List&lt;Type&gt; excludeTypes = null)
     - AssertExportedTypeWithMissingComments(Type type)
- [CodeComplianceHelper](Atc.XUnit.md#codecompliancehelper)
  -  Static Methods
     - AssertExportedTypesWithWrongDefinitions(Assembly assembly, List&lt;Type&gt; excludeTypes = null, bool useFullName = False)
     - AssertExportedTypesWithWrongDefinitions(Type type, bool useFullName = False)
- [CodeComplianceTestHelper](Atc.XUnit.md#codecompliancetesthelper)
  -  Static Methods
     - AssertExportedMethodsWithMissingTests(DecompilerType decompilerType, Assembly sourceAssembly, Assembly testAssembly, List&lt;Type&gt; excludeSourceTypes = null, bool useFullName = False)
     - AssertExportedMethodsWithMissingTests(DecompilerType decompilerType, Type sourceType, Assembly testAssembly, bool useFullName = False)
     - AssertExportedMethodsWithMissingTests(DecompilerType decompilerType, Type sourceType, Type testType, bool useFullName = False)
     - CollectExportedMethodsWithMissingTestsAndGenerateText(DecompilerType decompilerType, Assembly sourceAssembly, Assembly testAssembly, List&lt;Type&gt; excludeSourceTypes = null, bool useFullName = False)
     - CollectExportedMethodsWithMissingTestsAndGenerateTextLines(DecompilerType decompilerType, Assembly sourceAssembly, Assembly testAssembly, List&lt;Type&gt; excludeSourceTypes = null, bool useFullName = False)
     - CollectExportedMethodsWithMissingTestsFromAssembly(DecompilerType decompilerType, Assembly sourceAssembly, Assembly testAssembly, List&lt;Type&gt; excludeSourceTypes = null)
     - CollectExportedMethodsWithMissingTestsToExcel(DecompilerType decompilerType, Assembly sourceAssembly, Assembly testAssembly, List&lt;Type&gt; excludeSourceTypes = null)
     - CollectExportedMethodsWithMissingTestsToExcel(DecompilerType decompilerType, DirectoryInfo reportDirectory, Assembly sourceAssembly, Assembly testAssembly, List&lt;Type&gt; excludeSourceTypes = null)
     - CollectExportedTypesWithMissingTests(DecompilerType decompilerType, Assembly sourceAssembly, Assembly testAssembly, List&lt;Type&gt; excludeSourceTypes = null)
     - CollectExportedTypesWithMissingTestsAndGenerateText(DecompilerType decompilerType, Assembly sourceAssembly, Assembly testAssembly, List&lt;Type&gt; excludeSourceTypes = null, bool useFullName = False)
- [DecompilerType](Atc.XUnit.md#decompilertype)
- [TestResult](Atc.XUnit.md#testresult)
  -  Properties
     - IndentLevel
     - IsError
     - SubLines
     - Text
  -  Methods
     - ToString()
- [TestResultHelper](Atc.XUnit.md#testresulthelper)
  -  Static Methods
     - AssertOnTestResults(IReadOnlyCollection&lt;TestResult&gt; testResults)
     - AssertOnTestResultsFromMethodsWithMissingTests(string assemblyName, MethodInfo[] methodsWithMissingTests, bool useFullName = False)
     - AssertOnTestResultsFromMethodsWithWrongDefinitions(string assemblyName, Dictionary&lt;MethodInfo, string&gt; methodsWithWrongNaming, bool useFullName = False)
     - ToExcelTestResultsFromMethodsWithMissingTests(DirectoryInfo reportDirectory, string assemblyName, MethodInfo[] methodsWithMissingTests)

<hr /><div style='text-align: right'><i>Generated by MarkdownCodeDoc version 1.2</i></div>

