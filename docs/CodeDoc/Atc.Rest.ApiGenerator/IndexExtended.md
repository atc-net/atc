[![NuGet](https://img.shields.io/nuget/v/Atc.Rest.ApiGenerator.svg?style=flat-square)](http://www.nuget.org/packages/Atc.Rest.ApiGenerator)
[![NuGet](https://img.shields.io/nuget/dt/Atc.Rest.ApiGenerator.svg?style=flat-square)](http://www.nuget.org/packages/Atc.Rest.ApiGenerator)

<div style='text-align: right'>

[References](Index.md)

</div>


# References extended

## [Atc.Rest.ApiGenerator](Atc.Rest.ApiGenerator.md)

- [AtcRestApiGeneratorAssemblyTypeInitializer](Atc.Rest.ApiGenerator.md#atcrestapigeneratorassemblytypeinitializer)
- [Util](Atc.Rest.ApiGenerator.md#util)
  -  Static Methods
     - GetProjectPath()
     - GetCsFileNameForEndpoints(DirectoryInfo pathForEndpoints, string modelName)
     - GetCsFileNameForContract(DirectoryInfo pathForContracts, string area, string subArea, string modelName)
     - GetCsFileNameForContractEnumTypes(DirectoryInfo pathForContracts, string modelName)
     - GetCsFileNameForContractShared(DirectoryInfo pathForContracts, string modelName)

## [Atc.Rest.ApiGenerator.Helpers](Atc.Rest.ApiGenerator.Helpers.md)

- [ApiGeneratorHelper](Atc.Rest.ApiGenerator.Helpers.md#apigeneratorhelper)
  -  Static Methods
     - Create(string apiProjectName, DirectoryInfo apiOutputPath, Tuple&lt;OpenApiDocument, OpenApiDiagnostic, FileInfo&gt; apiYamlDoc, ApiOptions apiOptions)
- [FileHelper](Atc.Rest.ApiGenerator.Helpers.md#filehelper)
  -  Static Methods
     - Save(string file, string text)
     - Save(FileInfo fileInfo, string text)
- [OpenApiDocumentHelper](Atc.Rest.ApiGenerator.Helpers.md#openapidocumenthelper)
  -  Static Methods
     - CombineAndGetApiYamlDoc(string apiDesignPath)
     - Validate(Tuple&lt;OpenApiDocument, OpenApiDiagnostic, FileInfo&gt; apiYamlDoc)
     - GetBasePathSegmentNames(OpenApiDocument openApiYamlDoc)
- [OpenApiDocumentValidationHelper](Atc.Rest.ApiGenerator.Helpers.md#openapidocumentvalidationhelper)
  -  Static Methods
     - IsDocumentValid(OpenApiDocument apiDocument)
- [OpenApiOperationSchemaMapHelper](Atc.Rest.ApiGenerator.Helpers.md#openapioperationschemamaphelper)
  -  Static Methods
     - GetSegmentName(string path)
     - CollectMappings(OpenApiDocument apiDocument)

## [Atc.Rest.ApiGenerator.Models](Atc.Rest.ApiGenerator.Models.md)

- [ApiOperationSchemaMap](Atc.Rest.ApiGenerator.Models.md#apioperationschemamap)
  -  Properties
     - SchemaKey
     - LocatedArea
     - SegmentName
     - Path
     - OperationType
     - ParentSchemaKey
  -  Methods
     - ToString()
- [ApiProjectOptions](Atc.Rest.ApiGenerator.Models.md#apiprojectoptions)
  -  Properties
     - ToolNameAndProjectVersion
     - ApiOptions
     - PathForSrcGenerate
     - PathForEndpoints
     - PathForContracts
     - PathForContractsEnumerationTypes
     - PathForContractsShared
     - Document
     - DocumentFile
     - ProjectName
     - ApiVersion
     - BasePathSegmentNames
- [SchemaMapLocatedAreaType](Atc.Rest.ApiGenerator.Models.md#schemamaplocatedareatype)

## [Atc.Rest.ApiGenerator.Models.ApiOptions](Atc.Rest.ApiGenerator.Models.ApiOptions.md)

- [ApiOptions](Atc.Rest.ApiGenerator.Models.ApiOptions.md#apioptions)
  -  Properties
     - Generator
     - Validation
- [ApiOptionsGenerator](Atc.Rest.ApiGenerator.Models.ApiOptions.md#apioptionsgenerator)
  -  Properties
     - UseNullableReferenceTypes
     - Request
     - Response
- [ApiOptionsGeneratorRequest](Atc.Rest.ApiGenerator.Models.ApiOptions.md#apioptionsgeneratorrequest)
- [ApiOptionsGeneratorResponse](Atc.Rest.ApiGenerator.Models.ApiOptions.md#apioptionsgeneratorresponse)
  -  Properties
     - UseProblemDetailsAsDefaultBody
- [ApiOptionsValidation](Atc.Rest.ApiGenerator.Models.ApiOptions.md#apioptionsvalidation)

## [Atc.Rest.ApiGenerator.SyntaxGenerators](Atc.Rest.ApiGenerator.SyntaxGenerators.md)

- [ISyntaxCodeGenerator](Atc.Rest.ApiGenerator.SyntaxGenerators.md#isyntaxcodegenerator)
  -  Properties
     - FocusOnSegmentName
     - Code
  -  Methods
     - GenerateCode()
     - ToCodeAsString()
     - ToFile()
     - ToFile(FileInfo file)
- [ISyntaxGeneratorContract](Atc.Rest.ApiGenerator.SyntaxGenerators.md#isyntaxgeneratorcontract)
  -  Properties
     - ApiProjectOptions
     - FocusOnSegmentName
- [ISyntaxGeneratorContractInterfaces](Atc.Rest.ApiGenerator.SyntaxGenerators.md#isyntaxgeneratorcontractinterfaces)
  -  Methods
     - GenerateSyntaxTrees()
- [ISyntaxGeneratorContractModels](Atc.Rest.ApiGenerator.SyntaxGenerators.md#isyntaxgeneratorcontractmodels)
  -  Properties
     - OperationSchemaMappings
  -  Methods
     - GenerateSyntaxTrees()
- [ISyntaxGeneratorContractParameters](Atc.Rest.ApiGenerator.SyntaxGenerators.md#isyntaxgeneratorcontractparameters)
  -  Methods
     - GenerateSyntaxTrees()
- [ISyntaxGeneratorContractResults](Atc.Rest.ApiGenerator.SyntaxGenerators.md#isyntaxgeneratorcontractresults)
  -  Methods
     - GenerateSyntaxTrees()
- [ISyntaxGeneratorEndpointControllers](Atc.Rest.ApiGenerator.SyntaxGenerators.md#isyntaxgeneratorendpointcontrollers)
- [ISyntaxOperationCodeGenerator](Atc.Rest.ApiGenerator.SyntaxGenerators.md#isyntaxoperationcodegenerator)
  -  Properties
     - ApiProjectOptions
     - ApiOperationType
     - ApiOperation
- [ISyntaxSchemaCodeGenerator](Atc.Rest.ApiGenerator.SyntaxGenerators.md#isyntaxschemacodegenerator)
  -  Properties
     - ApiSchemaKey
     - ApiSchema
- [SyntaxGeneratorContractInterface](Atc.Rest.ApiGenerator.SyntaxGenerators.md#syntaxgeneratorcontractinterface)
  -  Properties
     - ApiProjectOptions
     - ApiOperationType
     - ApiOperation
     - FocusOnSegmentName
     - Code
  -  Methods
     - GenerateCode()
     - ToCodeAsString()
     - ToFile()
     - ToFile(FileInfo file)
     - ToString()
- [SyntaxGeneratorContractInterfaces](Atc.Rest.ApiGenerator.SyntaxGenerators.md#syntaxgeneratorcontractinterfaces)
  -  Properties
     - ApiProjectOptions
     - FocusOnSegmentName
  -  Methods
     - GenerateSyntaxTrees()
- [SyntaxGeneratorContractModel](Atc.Rest.ApiGenerator.SyntaxGenerators.md#syntaxgeneratorcontractmodel)
  -  Properties
     - ApiProjectOptions
     - ApiSchemaKey
     - ApiSchema
     - FocusOnSegmentName
     - Code
     - IsSharedContract
     - IsEnum
     - LocationArea
  -  Methods
     - GenerateCode()
     - ToCodeAsString()
     - ToFile()
     - ToFile(FileInfo file)
     - ToString()
- [SyntaxGeneratorContractModels](Atc.Rest.ApiGenerator.SyntaxGenerators.md#syntaxgeneratorcontractmodels)
  -  Properties
     - ApiProjectOptions
     - OperationSchemaMappings
     - FocusOnSegmentName
  -  Methods
     - GenerateSyntaxTrees()
- [SyntaxGeneratorContractParameter](Atc.Rest.ApiGenerator.SyntaxGenerators.md#syntaxgeneratorcontractparameter)
  -  Properties
     - ApiProjectOptions
     - ApiOperationType
     - ApiOperation
     - FocusOnSegmentName
     - Code
  -  Methods
     - GenerateCode()
     - ToCodeAsString()
     - ToFile()
     - ToFile(FileInfo file)
     - ToString()
- [SyntaxGeneratorContractParameters](Atc.Rest.ApiGenerator.SyntaxGenerators.md#syntaxgeneratorcontractparameters)
  -  Properties
     - ApiProjectOptions
     - FocusOnSegmentName
  -  Methods
     - GenerateSyntaxTrees()
- [SyntaxGeneratorContractResult](Atc.Rest.ApiGenerator.SyntaxGenerators.md#syntaxgeneratorcontractresult)
  -  Properties
     - ApiProjectOptions
     - ApiOperationType
     - ApiOperation
     - FocusOnSegmentName
     - Code
  -  Methods
     - GenerateCode()
     - ToCodeAsString()
     - ToFile()
     - ToFile(FileInfo file)
     - ToString()
- [SyntaxGeneratorContractResults](Atc.Rest.ApiGenerator.SyntaxGenerators.md#syntaxgeneratorcontractresults)
  -  Properties
     - ApiProjectOptions
     - FocusOnSegmentName
  -  Methods
     - GenerateSyntaxTrees()
- [SyntaxGeneratorEndpointControllers](Atc.Rest.ApiGenerator.SyntaxGenerators.md#syntaxgeneratorendpointcontrollers)
  -  Properties
     - ApiProjectOptions
     - FocusOnSegmentName
     - Code
  -  Methods
     - GenerateCode()
     - ToCodeAsString()
     - ToFile()
     - ToFile(FileInfo file)

<hr /><div style='text-align: right'><i>Generated by MarkdownCodeDoc version 1.2</i></div>

