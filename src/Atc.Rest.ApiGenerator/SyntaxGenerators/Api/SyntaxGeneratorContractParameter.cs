using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using Atc.CodeAnalysis.CSharp;
using Atc.CodeAnalysis.CSharp.SyntaxFactories;
using Atc.Data.Models;
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
namespace Atc.Rest.ApiGenerator.SyntaxGenerators.Api
{
    public class SyntaxGeneratorContractParameter : ISyntaxOperationCodeGenerator
    {
        public SyntaxGeneratorContractParameter(
            ApiProjectOptions apiProjectOptions,
            IList<OpenApiParameter> globalPathParameters,
            OperationType apiOperationType,
            OpenApiOperation apiOperation,
            string focusOnSegmentName)
        {
            this.ApiProjectOptions = apiProjectOptions ?? throw new ArgumentNullException(nameof(apiProjectOptions));
            this.GlobalPathParameters = globalPathParameters ?? throw new ArgumentNullException(nameof(globalPathParameters));
            this.ApiOperationType = apiOperationType;
            this.ApiOperation = apiOperation ?? throw new ArgumentNullException(nameof(apiOperation));
            this.FocusOnSegmentName = focusOnSegmentName ?? throw new ArgumentNullException(nameof(focusOnSegmentName));
        }

        public ApiProjectOptions ApiProjectOptions { get; }

        public IList<OpenApiParameter> GlobalPathParameters { get; }

        public OperationType ApiOperationType { get; }

        public OpenApiOperation ApiOperation { get; }

        public string FocusOnSegmentName { get; }

        public CompilationUnitSyntax? Code { get; private set; }

        public bool GenerateCode()
        {
            var parameterTypeName = ApiOperation.GetOperationName() + NameConstants.ContractParameters;

            // Create compilationUnit
            var compilationUnit = SyntaxFactory.CompilationUnit();

            // Create a namespace
            var @namespace = SyntaxProjectFactory.CreateNamespace(
                ApiProjectOptions,
                NameConstants.Contracts,
                FocusOnSegmentName);

            // Create class
            var classDeclaration = SyntaxClassDeclarationFactory.Create(parameterTypeName)
                .AddGeneratedCodeAttribute(ApiProjectOptions.ToolName, ApiProjectOptions.ToolVersion.ToString())
                .WithLeadingTrivia(SyntaxDocumentationFactory.CreateForParameters(ApiOperation, FocusOnSegmentName));

            // Add properties to the class
            if (GlobalPathParameters.Any())
            {
                foreach (var parameter in GlobalPathParameters)
                {
                    var propertyDeclaration = SyntaxPropertyDeclarationFactory.CreateAuto(parameter, ApiProjectOptions.ApiOptions.Generator.UseNullableReferenceTypes)
                        .WithLeadingTrivia(SyntaxDocumentationFactory.CreateForParameter(parameter));
                    classDeclaration = classDeclaration.AddMembers(propertyDeclaration);
                }
            }

            if (ApiOperation.Parameters != null)
            {
                foreach (var parameter in ApiOperation.Parameters)
                {
                    var propertyDeclaration = SyntaxPropertyDeclarationFactory.CreateAuto(parameter, ApiProjectOptions.ApiOptions.Generator.UseNullableReferenceTypes)
                        .WithLeadingTrivia(SyntaxDocumentationFactory.CreateForParameter(parameter));
                    classDeclaration = classDeclaration.AddMembers(propertyDeclaration);
                }
            }

            if (ApiOperation.RequestBody?.Content != null)
            {
                foreach (var item in ApiOperation.RequestBody.Content.Values)
                {
                    if (item.Schema.Reference == null && item.Schema.Type != OpenApiDataTypeConstants.Array)
                    {
                        continue;
                    }

                    var requestBodyType = item.Schema.Reference != null
                        ? item.Schema.Reference.Id.EnsureFirstCharacterToUpper()
                        : item.Schema.Items.Reference.Id.EnsureFirstCharacterToUpper();

                    PropertyDeclarationSyntax propertyDeclaration;
                    if (item.Schema.Type == OpenApiDataTypeConstants.Array)
                    {
                        propertyDeclaration = SyntaxPropertyDeclarationFactory.CreateListAuto(
                            requestBodyType,
                            NameConstants.Request)
                            .AddFromBodyAttribute()
                            .AddValidationAttribute(new RequiredAttribute())
                            .WithLeadingTrivia(SyntaxDocumentationFactory.CreateForParameter(ApiOperation.RequestBody));
                    }
                    else
                    {
                        propertyDeclaration = SyntaxPropertyDeclarationFactory.CreateAuto(
                                null,
                                false,
                                true,
                                requestBodyType,
                                NameConstants.Request,
                                ApiProjectOptions.ApiOptions.Generator.UseNullableReferenceTypes,
                                null)
                            .AddFromBodyAttribute()
                            .AddValidationAttribute(new RequiredAttribute())
                            .WithLeadingTrivia(SyntaxDocumentationFactory.CreateForParameter(ApiOperation.RequestBody));
                    }

                    classDeclaration = classDeclaration.AddMembers(propertyDeclaration);
                }
            }

            var methodDeclaration = SyntaxMethodDeclarationFactory.CreateToStringMethod(GlobalPathParameters, ApiOperation.Parameters, ApiOperation.RequestBody);
            if (methodDeclaration != null)
            {
                methodDeclaration = methodDeclaration.WithLeadingTrivia(SyntaxDocumentationFactory.CreateForOverrideToString());
                classDeclaration = classDeclaration.AddMembers(methodDeclaration);
            }

            // Add using statement to compilationUnit
            compilationUnit = compilationUnit.AddUsingStatements(ProjectContractPropertyFactory.CreateUsingList(GlobalPathParameters, ApiOperation.Parameters, ApiOperation.RequestBody));

            // Add the class to the namespace.
            @namespace = @namespace.AddMembers(classDeclaration);

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
                return $"Syntax generate problem for contract-parameter for apiOperation: {ApiOperation}";
            }

            return Code
                .NormalizeWhitespace()
                .ToFullString()
                .FormatAutoPropertiesOnOneLine()
                .FormatPublicPrivateLines()
                .FormatDoubleLines();
        }

        public LogKeyValueItem ToFile()
        {
            var area = FocusOnSegmentName.EnsureFirstCharacterToUpper();
            var parameterName = ApiOperation.GetOperationName() + NameConstants.ContractParameters;
            var file = Util.GetCsFileNameForContract(ApiProjectOptions.PathForContracts, area, NameConstants.ContractParameters, parameterName);
            return TextFileHelper.Save(file, ToCodeAsString());
        }

        public void ToFile(FileInfo file)
        {
            if (file == null)
            {
                throw new ArgumentNullException(nameof(file));
            }

            TextFileHelper.Save(file, ToCodeAsString());
        }

        public override string ToString()
        {
            return $"OperationType: {ApiOperationType}, OperationName: {ApiOperation.GetOperationName()}, SegmentName: {FocusOnSegmentName}";
        }
    }
}