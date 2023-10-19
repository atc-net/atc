<div style='text-align: right'>
[References](Index.md)
</div>

# References extended

## [Atc.XUnit](Atc.XUnit.md)

- [AtcXUnitAssemblyTypeInitializer](Atc.XUnit.md#atcxunitassemblytypeinitializer)
- [CodeComplianceDocumentationHelper](Atc.XUnit.md#codecompliancedocumentationhelper)
  -  Static Methods
     - AssertExportedTypeWithMissingComments(Type type)
     - AssertExportedTypesWithMissingComments(Assembly assembly, List&lt;Type&gt; excludeTypes = null)
- [CodeComplianceHelper](Atc.XUnit.md#codecompliancehelper)
  -  Static Methods
     - AssertExportedTypesWithWrongDefinitions(Assembly assembly, List&lt;Type&gt; excludeTypes = null, bool useFullName = False)
     - AssertExportedTypesWithWrongDefinitions(Type type, bool useFullName = False)
     - AssertLocalizationResources(Assembly assembly, IList&lt;string&gt; cultureNames, IList&lt;string&gt; allowSuffixTermsForKeySuffixWithPlaceholders = null)
     - AssertLocalizationResourcesForInvalidKeysSuffixWithPlaceholders(Assembly assembly, IList&lt;string&gt; cultureNames, IList&lt;string&gt; allowSuffixTermsForKeySuffixWithPlaceholders = null)
     - AssertLocalizationResourcesForMissingTranslations(Assembly assembly, IList&lt;string&gt; cultureNames)
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
- [IntegrationTestCliBase](Atc.XUnit.md#integrationtestclibase)
  -  Static Methods
     - GetAppSettingsFileForCli(Type programTypeForCliExe, DirectoryInfo searchFromPath)
     - GetAppSettingsFileForCli(Type programTypeForCliExe, string pathFolderNameFilter)
     - GetAppSettingsFileForCli(Type programTypeForCliExe, string searchFromSubFolderName, string pathFolderNameFilter)
     - GetExecutableFileForCli(Type programTypeForCliExe, DirectoryInfo searchFromPath, string pathFolderNameFilter)
     - GetExecutableFileForCli(Type programTypeForCliExe, string pathFolderNameFilter)
     - GetExecutableFileForCli(Type programTypeForCliExe, string searchFromSubFolderName, string pathFolderNameFilter)
- [SerializeAndDeserializeHelper](Atc.XUnit.md#serializeanddeserializehelper)
  -  Static Methods
     - Assert(object obj)
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
     - AssertOnTestResultsFromMethodsWithWrongDefinitions(string assemblyName, IDictionary&lt;MethodInfo, string&gt; methodsWithWrongNaming, bool useFullName = False)
     - AssertOnTestResultsFromMissingTranslationsAndInvalidKeysSuffixWithPlaceholders(string assemblyName, IDictionary&lt;string, Dictionary&lt;string, List&lt;string&gt;&gt;&gt; missingTranslations, IDictionary&lt;string, Dictionary&lt;string, List&lt;string&gt;&gt;&gt; invalidKeysSuffixWithPlaceholders)
     - ToExcelTestResultsFromMethodsWithMissingTests(DirectoryInfo reportDirectory, string assemblyName, MethodInfo[] methodsWithMissingTests)
- [Traits](Atc.XUnit.md#traits)
  -  Static Fields
     - string Category

## [Atc.XUnit.Logging](Atc.XUnit.Logging.md)

- [XUnitLogger](Atc.XUnit.Logging.md#xunitlogger)
  -  Static Methods
     - Create(ITestOutputHelper testOutputHelper)
     - Create(ITestOutputHelper testOutputHelper)
  -  Methods
     - BeginScope(TState state)
     - IsEnabled(LogLevel logLevel)
     - Log(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func&lt;TState, Exception, string&gt; formatter)
- [XUnitLoggerProvider](Atc.XUnit.Logging.md#xunitloggerprovider)
  -  Methods
     - CreateLogger(string categoryName)
     - Dispose()
- [XUnitLogger&lt;T&gt;](Atc.XUnit.Logging.md#xunitlogger&lt;t&gt;)

<hr /><div style='text-align: right'><i>Generated by MarkdownCodeDoc version 1.2</i></div>
