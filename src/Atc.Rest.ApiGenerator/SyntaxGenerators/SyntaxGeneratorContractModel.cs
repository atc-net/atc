using System;
using System.IO;
using Atc.CodeAnalysis.CSharp.SyntaxFactories;
using Atc.Rest.ApiGenerator.Factories;
using Atc.Rest.ApiGenerator.Helpers;
using Atc.Rest.ApiGenerator.Models;
using Atc.Rest.ApiGenerator.ProjectSyntaxFactories;
using Atc.Rest.ApiGenerator.SyntaxFactories;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.OpenApi.Models;

// ReSharper disable LoopCanBeConvertedToQuery
// ReSharper disable ConvertIfStatementToConditionalTernaryExpression
// ReSharper disable UseDeconstruction
namespace Atc.Rest.ApiGenerator.SyntaxGenerators
{
    public class SyntaxGeneratorContractModel : ISyntaxSchemaCodeGenerator
    {
        public SyntaxGeneratorContractModel(
            ApiProjectOptions apiProjectOptions,
            string apiSchemaKey,
            OpenApiSchema apiSchema,
            string focusOnSegmentName)
        {
            this.ApiProjectOptions = apiProjectOptions ?? throw new ArgumentNullException(nameof(apiProjectOptions));
            this.ApiSchemaKey = apiSchemaKey ?? throw new ArgumentNullException(nameof(apiSchemaKey));
            this.ApiSchema = apiSchema ?? throw new ArgumentNullException(nameof(apiSchema));
            this.FocusOnSegmentName = focusOnSegmentName ?? throw new ArgumentNullException(nameof(focusOnSegmentName));
            if (this.FocusOnSegmentName == "#")
            {
                this.IsSharedContract = true;
            }
        }

        public ApiProjectOptions ApiProjectOptions { get; }

        public string ApiSchemaKey { get; }

        public OpenApiSchema ApiSchema { get; }

        public string FocusOnSegmentName { get; }

        public CompilationUnitSyntax? Code { get; private set; }

        public bool IsSharedContract { get; private set; }

        public bool IsEnum { get; private set; }

        public SchemaMapLocatedAreaType LocationArea { get; set; } = SchemaMapLocatedAreaType.Response;

        public bool GenerateCode()
        {
            // Create compilationUnit
            var compilationUnit = SyntaxFactory.CompilationUnit();

            NamespaceDeclarationSyntax @namespace;
            if (ApiSchema.IsSchemaEnumOrPropertyEnum())
            {
                IsEnum = true;

                // Create a namespace
                @namespace = SyntaxProjectFactory.CreateNamespace(
                    ApiProjectOptions,
                    NameConstants.Contracts);

                var apiEnumSchema = ApiSchema.GetEnumSchema();

                // Create an enum
                var enumDeclaration = SyntaxEnumFactory.Create(apiEnumSchema.Item1, apiEnumSchema.Item2);

                // Add the enum to the namespace.
                @namespace = @namespace.AddMembers(enumDeclaration);
            }
            else
            {
                if (IsSharedContract)
                {
                    IsSharedContract = true;
                    @namespace = SyntaxProjectFactory.CreateNamespace(
                        ApiProjectOptions,
                        NameConstants.Contracts);
                }
                else
                {
                    // Create a namespace
                    @namespace = SyntaxProjectFactory.CreateNamespace(
                        ApiProjectOptions,
                        NameConstants.Contracts,
                        FocusOnSegmentName);
                }

                // Create class
                var classDeclaration = SyntaxClassDeclarationFactory.Create(ApiSchemaKey)
                    .WithLeadingTrivia(SyntaxDocumentationFactory.Create(ApiSchema));

                // Create class-properties and add to class
                if (ApiSchema.Properties != null)
                {
                    if (ApiSchema.Type == OpenApiDataTypeConstants.Array)
                    {
                        var title = ApiProjectOptions.Document.Components.Schemas.ContainsKey(ApiSchema.Title)
                            ? $"{ApiSchema.Title.EnsureFirstLetterToUpperAndSingular()}List"
                            : ApiSchema.Title.EnsureFirstLetterToUpper();

                        var propertyDeclaration = SyntaxPropertyDeclarationFactory.CreateListAuto(ApiSchema.Items.Title, title)
                            .WithLeadingTrivia(SyntaxDocumentationFactory.CreateSummary($"A list of {ApiSchema.Items.Title}."));
                        classDeclaration = classDeclaration.AddMembers(propertyDeclaration);
                    }
                    else
                    {
                        foreach (var property in ApiSchema.Properties)
                        {
                            var propertyDeclaration = SyntaxPropertyDeclarationFactory.CreateAuto(
                                    LocationArea,
                                    property,
                                    ApiSchema.Required,
                                    ApiProjectOptions.ApiOptions.Generator.UseNullableReferenceTypes)
                                .WithLeadingTrivia(SyntaxDocumentationFactory.Create(property.Value));
                            classDeclaration = classDeclaration.AddMembers(propertyDeclaration);
                        }
                    }

                    var methodDeclaration = SyntaxMethodDeclarationFactory.CreateToStringMethod(ApiSchema.Properties);
                    if (methodDeclaration != null)
                    {
                        methodDeclaration = methodDeclaration.WithLeadingTrivia(SyntaxDocumentationFactory.CreateForOverrideToString());
                        classDeclaration = classDeclaration.AddMembers(methodDeclaration);
                    }
                }

                // Add using statement to compilationUnit
                compilationUnit = compilationUnit.AddUsingStatements(ProjectContractDataFactory.CreateUsingList(ApiSchema));

                // Add the class to the namespace.
                @namespace = @namespace.AddMembers(classDeclaration);
            }

            // Add namespace to compilationUnit
            compilationUnit = compilationUnit.AddMembers(@namespace);

            // Set code property
            Code = compilationUnit;
            return true;
        }

        public string ToCodeAsString()
        {
            if (Code == null)
            {
                GenerateCode();
            }

            if (Code == null)
            {
                return $"Syntax generate problem for contract-model for schema: {ApiSchemaKey}";
            }

            return Code
                .NormalizeWhitespace()
                .ToFullString()
                .FormatAutoPropertiesOnOneLine()
                .FormatPublicPrivateLines()
                .FormatDoubleLines();
        }

        public void ToFile()
        {
            var area = FocusOnSegmentName.EnsureFirstLetterToUpper();
            var modelName = ApiSchemaKey.EnsureFirstLetterToUpper();
            var file = IsEnum
                ? Util.GetCsFileNameForContractEnumTypes(ApiProjectOptions.PathForContracts, modelName)
                : IsSharedContract
                    ? Util.GetCsFileNameForContractShared(ApiProjectOptions.PathForContractsShared, modelName)
                    : Util.GetCsFileNameForContract(ApiProjectOptions.PathForContracts, area, NameConstants.ContractModels, modelName);
            FileHelper.Save(file, ToCodeAsString());
        }

        public void ToFile(FileInfo file)
        {
            if (file == null)
            {
                throw new ArgumentNullException(nameof(file));
            }

            FileHelper.Save(file, ToCodeAsString());
        }

        public override string ToString()
        {
            return $"{nameof(ApiSchemaKey)}: {ApiSchemaKey}, SegmentName: {FocusOnSegmentName}, IsShared: {IsSharedContract}, {nameof(IsEnum)}: {IsEnum}";
        }
    }
}