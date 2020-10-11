using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Xml.Linq;
using Atc.CodeAnalysis.CSharp.SyntaxFactories;
using Atc.Data.Models;
using Atc.Rest.ApiGenerator.Factories;
using Atc.Rest.ApiGenerator.Helpers;
using Atc.Rest.ApiGenerator.Models;
using Atc.Rest.ApiGenerator.ProjectSyntaxFactories;
using Atc.Rest.ApiGenerator.SyntaxFactories;
using Atc.Rest.ApiGenerator.SyntaxGenerators.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

// ReSharper disable SuggestBaseTypeForParameter
// ReSharper disable ReturnTypeCanBeEnumerable.Local
// ReSharper disable UseObjectOrCollectionInitializer
namespace Atc.Rest.ApiGenerator.Generators
{
    public class ServerApiGenerator
    {
        private readonly ApiProjectOptions projectOptions;

        public ServerApiGenerator(ApiProjectOptions projectOptions)
        {
            this.projectOptions = projectOptions ?? throw new ArgumentNullException(nameof(projectOptions));
        }

        public List<LogKeyValueItem> Generate()
        {
            var logItems = new List<LogKeyValueItem>();

            logItems.Add(ValidateVersioning(projectOptions));
            if (logItems.Any(x => x.LogCategory == LogCategoryType.Error))
            {
                return logItems;
            }

            logItems.AddRange(ScaffoldSrc(projectOptions));
            if (projectOptions.PathForTestGenerate != null)
            {
                logItems.AddRange(ScaffoldTest(projectOptions));
            }

            CopyApiSpecification(projectOptions);

            var operationSchemaMappings = OpenApiOperationSchemaMapHelper.CollectMappings(projectOptions.Document);
            logItems.AddRange(GenerateContracts(projectOptions, operationSchemaMappings));
            logItems.AddRange(GenerateEndpoints(projectOptions, operationSchemaMappings));
            logItems.AddRange(PerformCleanup(projectOptions, logItems));
            return logItems;
        }

        private static LogKeyValueItem ValidateVersioning(ApiProjectOptions apiProjectOptions)
        {
            if (apiProjectOptions == null)
            {
                throw new ArgumentNullException(nameof(apiProjectOptions));
            }

            if (!Directory.Exists(apiProjectOptions.PathForSrcGenerate.FullName))
            {
                return LogItemHelper.Create(LogCategoryType.Information, ValidationRuleNameConstants.ProjectApiGenerated01, "Old project don't exist.");
            }

            var apiGeneratedFile = Path.Combine(apiProjectOptions.PathForSrcGenerate.FullName, "ApiRegistration.cs");
            if (!File.Exists(apiGeneratedFile))
            {
                return LogItemHelper.Create(LogCategoryType.Information, ValidationRuleNameConstants.ProjectApiGenerated02, "Old ApiRegistration.cs in project don't exist.");
            }

            var lines = File.ReadLines(apiGeneratedFile).ToList();

            var executingAssembly = Assembly.GetExecutingAssembly();
            const string toolName = "ApiGenerator";
            var newVersion = executingAssembly.GetName().Version;

            foreach (var line in lines)
            {
                var indexOfToolName = line.IndexOf(toolName!, StringComparison.Ordinal);
                if (indexOfToolName == -1)
                {
                    continue;
                }

                var oldVersion = line.Substring(indexOfToolName + toolName!.Length);
                if (oldVersion.EndsWith('.'))
                {
                    oldVersion = oldVersion.Substring(0, oldVersion.Length - 1);
                }

                if (!Version.TryParse(oldVersion, out var oldVersionResult))
                {
                    return LogItemHelper.Create(LogCategoryType.Error, ValidationRuleNameConstants.ProjectApiGenerated03, "Existing project version is invalid.");
                }

                if (newVersion >= oldVersionResult)
                {
                    return LogItemHelper.Create(LogCategoryType.Information, ValidationRuleNameConstants.ProjectApiGenerated04, "The generate project version is the same or newer.");
                }

                return LogItemHelper.Create(LogCategoryType.Error, ValidationRuleNameConstants.ProjectApiGenerated05, "Existing project version is never than this tool version.");
            }

            return LogItemHelper.Create(LogCategoryType.Error, ValidationRuleNameConstants.ProjectApiGenerated06, "Existing project did not contain a version.");
        }

        private static List<LogKeyValueItem> ScaffoldSrc(ApiProjectOptions apiProjectOptions)
        {
            if (apiProjectOptions == null)
            {
                throw new ArgumentNullException(nameof(apiProjectOptions));
            }

            if (!Directory.Exists(apiProjectOptions.PathForSrcGenerate.FullName))
            {
                Directory.CreateDirectory(apiProjectOptions.PathForSrcGenerate.FullName);
            }

            var logItems = new List<LogKeyValueItem>();

            if (apiProjectOptions.PathForSrcGenerate.Exists && apiProjectOptions.ProjectSrcCsProj.Exists)
            {
                var element = XElement.Load(apiProjectOptions.ProjectSrcCsProj.FullName);
                var originalNullableValue = SolutionAndProjectHelper.GetBoolFromNullableString(SolutionAndProjectHelper.GetNullableValueFromProject(element));

                bool hasUpdates = false;
                if (apiProjectOptions.ApiOptions.Generator.UseNullableReferenceTypes != originalNullableValue)
                {
                    var newNullableValue = SolutionAndProjectHelper.GetNullableStringFromBool(apiProjectOptions.ApiOptions.Generator.UseNullableReferenceTypes);
                    SolutionAndProjectHelper.SetNullableValueForProject(element, newNullableValue);
                    element.Save(apiProjectOptions.ProjectSrcCsProj.FullName);
                    logItems.Add(new LogKeyValueItem(LogCategoryType.Debug, "FileUpdate", "#", $"Update API csproj - Nullable value={newNullableValue}"));
                    hasUpdates = true;
                }

                if (!hasUpdates)
                {
                    logItems.Add(new LogKeyValueItem(LogCategoryType.Debug, "FileSkip", "#", "No updates for API csproj"));
                }
            }
            else
            {
                logItems.Add(SolutionAndProjectHelper.ScaffoldProjFile(
                    apiProjectOptions.ProjectSrcCsProj,
                    false,
                    false,
                    apiProjectOptions.ProjectName,
                    apiProjectOptions.ApiOptions.Generator.UseNullableReferenceTypes,
                    new List<string> { "Microsoft.AspNetCore.App" },
                    null,
                    null,
                    true));
            }

            ScaffoldBasicFileApiGenerated(apiProjectOptions);
            ScaffoldBasicFileResultFactory(apiProjectOptions);
            ScaffoldBasicFilePagination(apiProjectOptions);

            return logItems;
        }

        private static List<LogKeyValueItem> ScaffoldTest(ApiProjectOptions apiProjectOptions)
        {
            if (apiProjectOptions == null)
            {
                throw new ArgumentNullException(nameof(apiProjectOptions));
            }

            var logItems = new List<LogKeyValueItem>();

            if (apiProjectOptions.PathForTestGenerate == null || apiProjectOptions.ProjectTestCsProj == null)
            {
                return logItems;
            }

            if (apiProjectOptions.PathForTestGenerate.Exists && apiProjectOptions.ProjectTestCsProj.Exists)
            {
                logItems.Add(new LogKeyValueItem(LogCategoryType.Debug, "FileSkip", "#", "No updates for API test csproj"));
            }
            else
            {
                if (!Directory.Exists(apiProjectOptions.PathForTestGenerate.FullName))
                {
                    Directory.CreateDirectory(apiProjectOptions.PathForTestGenerate.FullName);
                }

                var projectReferences = new List<FileInfo>
                {
                    apiProjectOptions.ProjectSrcCsProj
                };

                logItems.Add(SolutionAndProjectHelper.ScaffoldProjFile(
                    apiProjectOptions.ProjectTestCsProj,
                    false,
                    true,
                    $"{apiProjectOptions.ProjectName}.Tests",
                    apiProjectOptions.ApiOptions.Generator.UseNullableReferenceTypes,
                    null,
                    NugetPackageReferenceHelper.CreateForTestProject(false),
                    projectReferences,
                    true));
            }

            return logItems;
        }

        private static void CopyApiSpecification(ApiProjectOptions apiProjectOptions)
        {
            if (apiProjectOptions == null)
            {
                throw new ArgumentNullException(nameof(apiProjectOptions));
            }

            var resourceFolder = new DirectoryInfo(Path.Combine(apiProjectOptions.PathForSrcGenerate.FullName, "Resources"));
            if (!resourceFolder.Exists)
            {
                Directory.CreateDirectory(resourceFolder.FullName);
            }

            var resourceFile = new FileInfo(Path.Combine(resourceFolder.FullName, "ApiSpecification.yaml"));
            if (File.Exists(resourceFile.FullName))
            {
                File.Delete(resourceFile.FullName);
            }

            File.Copy(apiProjectOptions.DocumentFile.FullName, resourceFile.FullName);
        }

        private static List<LogKeyValueItem> GenerateContracts(ApiProjectOptions apiProjectOptions, List<ApiOperationSchemaMap> operationSchemaMappings)
        {
            if (apiProjectOptions == null)
            {
                throw new ArgumentNullException(nameof(apiProjectOptions));
            }

            if (operationSchemaMappings == null)
            {
                throw new ArgumentNullException(nameof(operationSchemaMappings));
            }

            var sgContractModels = new List<SyntaxGeneratorContractModel>();
            var sgContractParameters = new List<SyntaxGeneratorContractParameter>();
            var sgContractResults = new List<SyntaxGeneratorContractResult>();
            var sgContractInterfaces = new List<SyntaxGeneratorContractInterface>();
            foreach (var basePathSegmentName in apiProjectOptions.BasePathSegmentNames)
            {
                var generatorModels = new SyntaxGeneratorContractModels(apiProjectOptions, operationSchemaMappings, basePathSegmentName);
                var generatedModels = generatorModels.GenerateSyntaxTrees();
                sgContractModels.AddRange(generatedModels);

                var generatorParameters = new SyntaxGeneratorContractParameters(apiProjectOptions, basePathSegmentName);
                var generatedParameters = generatorParameters.GenerateSyntaxTrees();
                sgContractParameters.AddRange(generatedParameters);

                var generatorResults = new SyntaxGeneratorContractResults(apiProjectOptions, basePathSegmentName);
                var generatedResults = generatorResults.GenerateSyntaxTrees();
                sgContractResults.AddRange(generatedResults);

                var generatorInterfaces = new SyntaxGeneratorContractInterfaces(apiProjectOptions, basePathSegmentName);
                var generatedInterfaces = generatorInterfaces.GenerateSyntaxTrees();
                sgContractInterfaces.AddRange(generatedInterfaces);
            }

            var missingOperationSchemaMappings = new List<ApiOperationSchemaMap>();
            foreach (var map in operationSchemaMappings)
            {
                if (sgContractModels.FirstOrDefault(x => x.ApiSchemaKey.Equals(map.SchemaKey, StringComparison.OrdinalIgnoreCase)) == null)
                {
                    missingOperationSchemaMappings.Add(map);
                }
            }

            foreach (var map in missingOperationSchemaMappings)
            {
                if (missingOperationSchemaMappings.Count(x => x.SchemaKey.Equals(map.SchemaKey, StringComparison.OrdinalIgnoreCase)) > 1)
                {
                    throw new NotImplementedException($"SchemaKey: {map.SchemaKey} is not generated and exist multiple times - location-calculation is missing.");
                }

                var generatorModel = new SyntaxGeneratorContractModel(
                    apiProjectOptions,
                    map.SchemaKey,
                    apiProjectOptions.Document.Components.Schemas.First(x => x.Key.Equals(map.SchemaKey, StringComparison.OrdinalIgnoreCase)).Value,
                    map.SegmentName);

                generatorModel.GenerateCode();
                sgContractModels.Add(generatorModel);
            }

            var logItems = new List<LogKeyValueItem>();
            foreach (var sg in sgContractModels)
            {
                logItems.Add(sg.ToFile());
            }

            foreach (var sg in sgContractParameters)
            {
                logItems.Add(sg.ToFile());
            }

            foreach (var sg in sgContractResults)
            {
                logItems.Add(sg.ToFile());
            }

            foreach (var sg in sgContractInterfaces)
            {
                logItems.Add(sg.ToFile());
            }

            return logItems;
        }

        private static List<LogKeyValueItem> GenerateEndpoints(ApiProjectOptions apiProjectOptions, List<ApiOperationSchemaMap> operationSchemaMappings)
        {
            if (apiProjectOptions == null)
            {
                throw new ArgumentNullException(nameof(apiProjectOptions));
            }

            if (operationSchemaMappings == null)
            {
                throw new ArgumentNullException(nameof(operationSchemaMappings));
            }

            var sgEndpoints = new List<SyntaxGeneratorEndpointControllers>();
            foreach (var segmentName in apiProjectOptions.BasePathSegmentNames)
            {
                var generator = new SyntaxGeneratorEndpointControllers(apiProjectOptions, operationSchemaMappings, segmentName);
                generator.GenerateCode();
                sgEndpoints.Add(generator);
            }

            var logItems = new List<LogKeyValueItem>();
            foreach (var sg in sgEndpoints)
            {
                logItems.Add(sg.ToFile());
            }

            return logItems;
        }

        private static List<LogKeyValueItem> PerformCleanup(ApiProjectOptions apiProjectOptions, List<LogKeyValueItem> orgLogItems)
        {
            if (apiProjectOptions == null)
            {
                throw new ArgumentNullException(nameof(apiProjectOptions));
            }

            if (orgLogItems == null)
            {
                throw new ArgumentNullException(nameof(orgLogItems));
            }

            var logItems = new List<LogKeyValueItem>();

            if (Directory.Exists(apiProjectOptions.PathForContracts.FullName))
            {
                var files = Directory.GetFiles(apiProjectOptions.PathForContracts.FullName, "*.*", SearchOption.AllDirectories);
                foreach (string file in files)
                {
                    if (orgLogItems.FirstOrDefault(x => x.Description == file) != null)
                    {
                        continue;
                    }

                    File.Delete(file);
                    logItems.Add(new LogKeyValueItem(LogCategoryType.Debug, "FileDelete", "#", file));
                }
            }

            if (Directory.Exists(apiProjectOptions.PathForEndpoints.FullName))
            {
                var files = Directory.GetFiles(apiProjectOptions.PathForEndpoints.FullName, "*.*", SearchOption.AllDirectories);
                foreach (string file in files)
                {
                    if (orgLogItems.FirstOrDefault(x => x.Description == file) != null)
                    {
                        continue;
                    }

                    File.Delete(file);
                    logItems.Add(new LogKeyValueItem(LogCategoryType.Debug, "FileDelete", "#", file));
                }
            }

            return logItems;
        }

        private static MethodDeclarationSyntax CreateResultFactoryProblemDetails()
        {
            // Issues for NormalizeWhitespace for linefeed in code block
            // https://github.com/dotnet/roslyn/issues/24827
            var codeBody = SyntaxFactory.Block(
                SyntaxFactory.LocalDeclarationStatement(SyntaxFactory.VariableDeclaration(SyntaxFactory.IdentifierName("var"))
                    .WithVariables(
                        SyntaxFactory.SingletonSeparatedList(SyntaxFactory.VariableDeclarator(SyntaxFactory.Identifier("result"))
                            .WithInitializer(
                                SyntaxFactory.EqualsValueClause(SyntaxObjectCreationExpressionFactory.Create(nameof(ProblemDetails))
                                    .WithArgumentList(SyntaxFactory.ArgumentList())))))),
                SyntaxFactory.ExpressionStatement(
                    SyntaxFactory.AssignmentExpression(
                        SyntaxKind.SimpleAssignmentExpression,
                        SyntaxMemberAccessExpressionFactory.Create("Status", "result"),
                        SyntaxFactory.CastExpression(
                            SyntaxFactory.PredefinedType(
                                SyntaxTokenFactory.IntKeyword()),
                            SyntaxFactory.IdentifierName("statusCode")))),
                SyntaxFactory.ExpressionStatement(
                    SyntaxFactory.AssignmentExpression(
                        SyntaxKind.SimpleAssignmentExpression,
                        SyntaxMemberAccessExpressionFactory.Create("Detail", "result"),
                        SyntaxFactory.IdentifierName("message"))),
                SyntaxFactory.ReturnStatement(SyntaxFactory.IdentifierName("result")));

            return SyntaxFactory.MethodDeclaration(
                    SyntaxFactory.IdentifierName(nameof(ProblemDetails)),
                    SyntaxFactory.Identifier("CreateProblemDetails"))
                .WithModifiers(SyntaxTokenListFactory.InternalStaticKeyword())
                .WithParameterList(
                    SyntaxFactory.ParameterList(
                        SyntaxFactory.SeparatedList<ParameterSyntax>(
                            new SyntaxNodeOrToken[]
                            {
                                SyntaxFactory.Parameter(SyntaxFactory.Identifier("statusCode"))
                                    .WithType(SyntaxFactory.IdentifierName(nameof(HttpStatusCode))),
                                SyntaxTokenFactory.Comma(),
                                SyntaxFactory.Parameter(SyntaxFactory.Identifier("message"))
                                    .WithType(SyntaxFactory.NullableType(
                                        SyntaxFactory.PredefinedType(SyntaxTokenFactory.StringKeyword())))
                            })))
                .WithBody(codeBody);
        }

        private static MethodDeclarationSyntax CreateResultFactoryContentResultWithProblemDetails(string contentType = "application/json")
        {
            var codeBody = SyntaxFactory.Block(
                SyntaxFactory.SingletonList<StatementSyntax>(
                    SyntaxFactory.ReturnStatement(
                        SyntaxFactory.ObjectCreationExpression(SyntaxFactory.IdentifierName(nameof(ContentResult)))
                        .WithInitializer(
                            SyntaxFactory.InitializerExpression(
                                SyntaxKind.ObjectInitializerExpression,
                                SyntaxFactory.SeparatedList<ExpressionSyntax>(
                                    new SyntaxNodeOrToken[]
                                    {
                                        SyntaxFactory.AssignmentExpression(
                                            SyntaxKind.SimpleAssignmentExpression,
                                            SyntaxFactory.IdentifierName("ContentType"),
                                            SyntaxFactory.IdentifierName("contentType")),
                                        SyntaxTokenFactory.Comma(),
                                        SyntaxFactory.AssignmentExpression(
                                            SyntaxKind.SimpleAssignmentExpression,
                                            SyntaxFactory.IdentifierName("StatusCode"),
                                            SyntaxFactory.CastExpression(
                                                SyntaxFactory.PredefinedType(SyntaxTokenFactory.IntKeyword()),
                                                SyntaxFactory.IdentifierName("statusCode"))),
                                        SyntaxTokenFactory.Comma(),
                                        SyntaxFactory.AssignmentExpression(
                                            SyntaxKind.SimpleAssignmentExpression,
                                            SyntaxFactory.IdentifierName("Content"),
                                            SyntaxFactory.InvocationExpression(
                                                SyntaxFactory.MemberAccessExpression(
                                                    SyntaxKind.SimpleMemberAccessExpression,
                                                    SyntaxFactory.IdentifierName("JsonSerializer"),
                                                    SyntaxFactory.IdentifierName("Serialize")))
                                            .WithArgumentList(
                                                SyntaxFactory.ArgumentList(
                                                    SyntaxFactory.SingletonSeparatedList(
                                                        SyntaxFactory.Argument(SyntaxFactory.InvocationExpression(SyntaxFactory.IdentifierName("CreateProblemDetails"))
                                                            .WithArgumentList(
                                                                SyntaxFactory.ArgumentList(
                                                                    SyntaxFactory.SeparatedList<ArgumentSyntax>(
                                                                        new SyntaxNodeOrToken[]
                                                                        {
                                                                            SyntaxFactory.Argument(SyntaxFactory.IdentifierName("statusCode")),
                                                                            SyntaxTokenFactory.Comma(),
                                                                            SyntaxFactory.Argument(SyntaxFactory.IdentifierName("message"))
                                                                        }))))))))
                                    }))))));

            return SyntaxFactory.MethodDeclaration(SyntaxFactory.IdentifierName(nameof(ContentResult)), SyntaxFactory.Identifier("CreateContentResultWithProblemDetails"))
                .WithModifiers(SyntaxTokenListFactory.InternalStaticKeyword())
                .WithParameterList(
                    SyntaxFactory.ParameterList(
                        SyntaxFactory.SeparatedList<ParameterSyntax>(
                            new SyntaxNodeOrToken[]
                            {
                                SyntaxFactory.Parameter(SyntaxFactory.Identifier("statusCode"))
                                    .WithType(SyntaxFactory.IdentifierName(nameof(HttpStatusCode))),
                                SyntaxTokenFactory.Comma(),
                                SyntaxFactory.Parameter(SyntaxFactory.Identifier("message"))
                                    .WithType(SyntaxFactory.NullableType(SyntaxFactory.PredefinedType(SyntaxTokenFactory.StringKeyword()))),
                                SyntaxTokenFactory.Comma(),
                                SyntaxFactory.Parameter(SyntaxFactory.Identifier("contentType"))
                                    .WithType(SyntaxFactory.PredefinedType(SyntaxTokenFactory.StringKeyword()))
                                    .WithDefault(
                                        SyntaxFactory.EqualsValueClause(
                                            SyntaxFactory.LiteralExpression(
                                                SyntaxKind.StringLiteralExpression,
                                                SyntaxFactory.Literal(contentType))))
                            })))
                .WithBody(codeBody);
        }

        private static MethodDeclarationSyntax CreateResultFactoryContentResultWithMessage(string contentType = "application/json")
        {
            var codeBody = SyntaxFactory.Block(
                SyntaxFactory.SingletonList<StatementSyntax>(
                    SyntaxFactory.ReturnStatement(
                        SyntaxFactory.ObjectCreationExpression(SyntaxFactory.IdentifierName(nameof(ContentResult)))
                            .WithInitializer(
                                SyntaxFactory.InitializerExpression(
                                    SyntaxKind.ObjectInitializerExpression,
                                    SyntaxFactory.SeparatedList<ExpressionSyntax>(
                                        new SyntaxNodeOrToken[]
                                        {
                                            SyntaxFactory.AssignmentExpression(
                                                SyntaxKind.SimpleAssignmentExpression,
                                                SyntaxFactory.IdentifierName("ContentType"),
                                                SyntaxFactory.IdentifierName("contentType")),
                                            SyntaxTokenFactory.Comma(),
                                            SyntaxFactory.AssignmentExpression(
                                                SyntaxKind.SimpleAssignmentExpression,
                                                SyntaxFactory.IdentifierName("StatusCode"),
                                                SyntaxFactory.CastExpression(
                                                    SyntaxFactory.PredefinedType(
                                                        SyntaxTokenFactory.IntKeyword()),
                                                    SyntaxFactory.IdentifierName("statusCode"))),
                                            SyntaxTokenFactory.Comma(),
                                            SyntaxFactory.AssignmentExpression(
                                                SyntaxKind.SimpleAssignmentExpression,
                                                SyntaxFactory.IdentifierName("Content"),
                                                SyntaxFactory.InvocationExpression(
                                                        SyntaxFactory.MemberAccessExpression(
                                                            SyntaxKind.SimpleMemberAccessExpression,
                                                            SyntaxFactory.IdentifierName("JsonSerializer"),
                                                            SyntaxFactory.IdentifierName("Serialize")))
                                                    .WithArgumentList(
                                                        SyntaxFactory.ArgumentList(
                                                            SyntaxFactory.SingletonSeparatedList(
                                                                SyntaxFactory.Argument(SyntaxFactory.IdentifierName("message"))))))
                                        }))))));

            return SyntaxFactory.MethodDeclaration(SyntaxFactory.IdentifierName(nameof(ContentResult)), SyntaxFactory.Identifier("CreateContentResult"))
                .WithModifiers(SyntaxFactory.TokenList(SyntaxTokenListFactory.InternalStaticKeyword()))
                .WithParameterList(
                    SyntaxFactory.ParameterList(
                        SyntaxFactory.SeparatedList<ParameterSyntax>(
                            new SyntaxNodeOrToken[]
                            {
                                SyntaxFactory.Parameter(SyntaxFactory.Identifier("statusCode"))
                                    .WithType(SyntaxFactory.IdentifierName(nameof(HttpStatusCode))),
                                SyntaxTokenFactory.Comma(),
                                SyntaxFactory.Parameter(SyntaxFactory.Identifier("message"))
                                    .WithType(SyntaxFactory.NullableType(SyntaxFactory.PredefinedType(SyntaxTokenFactory.StringKeyword()))),
                                SyntaxTokenFactory.Comma(),
                                SyntaxFactory.Parameter(SyntaxFactory.Identifier("contentType"))
                                    .WithType(SyntaxFactory.PredefinedType(SyntaxTokenFactory.StringKeyword()))
                                    .WithDefault(
                                        SyntaxFactory.EqualsValueClause(
                                            SyntaxFactory.LiteralExpression(
                                                SyntaxKind.StringLiteralExpression,
                                                SyntaxFactory.Literal(contentType))))
                            })))
                .WithBody(codeBody);
        }

        private static void ScaffoldBasicFileApiGenerated(ApiProjectOptions apiProjectOptions)
        {
            // Create compilationUnit
            var compilationUnit = SyntaxFactory.CompilationUnit();

            // Create a namespace
            var @namespace = SyntaxProjectFactory.CreateNamespace(apiProjectOptions);

            // Create class
            var classDeclaration = SyntaxClassDeclarationFactory.Create("ApiRegistration")
                .AddGeneratedCodeAttribute(apiProjectOptions.ToolName, apiProjectOptions.ToolVersion.ToString());

            // Add class to namespace
            @namespace = @namespace.AddMembers(classDeclaration);

            // Add using statement to compilationUnit
            compilationUnit = compilationUnit.AddUsingStatements(new[] { "System.CodeDom.Compiler" });

            // Add namespace to compilationUnit
            compilationUnit = compilationUnit.AddMembers(@namespace);

            var codeAsString = compilationUnit
                .NormalizeWhitespace()
                .ToFullString();

            var file = new FileInfo(Path.Combine(apiProjectOptions.PathForSrcGenerate.FullName, "ApiRegistration.cs"));
            TextFileHelper.Save(file, codeAsString);
        }

        private static void ScaffoldBasicFileResultFactory(ApiProjectOptions apiProjectOptions)
        {
            // Create compilationUnit
            var compilationUnit = SyntaxFactory.CompilationUnit();

            // Create a namespace
            var @namespace = SyntaxProjectFactory.CreateNamespace(apiProjectOptions);

            // Create class
            var classDeclaration = SyntaxClassDeclarationFactory.CreateAsInternalStatic("ResultFactory")
                .AddGeneratedCodeAttribute(apiProjectOptions.ToolName, apiProjectOptions.ToolVersion.ToString());

            // Add using statement to compilationUnit
            compilationUnit = compilationUnit.AddUsingStatements(ProjectScaffoldFactory.CreateUsingListForResultFactory());

            // Create method
            var methodDeclarationProblemDetails = CreateResultFactoryProblemDetails();
            var methodDeclarationContentResultWithProblemDetails = CreateResultFactoryContentResultWithProblemDetails();
            var methodDeclarationContentResultWithMessage = CreateResultFactoryContentResultWithMessage();

            // Add method to class
            classDeclaration = classDeclaration.AddMembers(methodDeclarationProblemDetails);
            classDeclaration = classDeclaration.AddMembers(methodDeclarationContentResultWithProblemDetails);
            classDeclaration = classDeclaration.AddMembers(methodDeclarationContentResultWithMessage);

            // Add class to namespace
            @namespace = @namespace.AddMembers(classDeclaration);

            // Add namespace to compilationUnit
            compilationUnit = compilationUnit.AddMembers(@namespace);

            var codeAsString = compilationUnit
                .NormalizeWhitespace()
                .ToFullString()
                .FormatBracketSpacing();

            var file = new FileInfo(Path.Combine(apiProjectOptions.PathForSrcGenerate.FullName, "ResultFactory.cs"));
            TextFileHelper.Save(file, codeAsString);
        }

        private static void ScaffoldBasicFilePagination(ApiProjectOptions apiProjectOptions)
        {
            var (key, _) = apiProjectOptions.Document.Components.Schemas.FirstOrDefault(x => x.Key.Equals(Microsoft.OpenApi.Models.NameConstants.Pagination, StringComparison.OrdinalIgnoreCase));
            if (key == null)
            {
                return;
            }

            // Create compilationUnit
            var compilationUnit = SyntaxFactory.CompilationUnit();

            // Create a namespace
            var @namespace = SyntaxProjectFactory.CreateNamespace(apiProjectOptions);

            // Add using statement to compilationUnit
            compilationUnit = compilationUnit.AddUsingStatements(ProjectScaffoldFactory.CreateUsingListForPagination());

            // Create class
            var classDeclaration = SyntaxFactory
                .ClassDeclaration(Microsoft.OpenApi.Models.NameConstants.Pagination)
                .AddGeneratedCodeAttribute(apiProjectOptions.ToolName, apiProjectOptions.ToolVersion.ToString())
                .WithModifiers(SyntaxFactory.TokenList(SyntaxTokenFactory.PublicKeyword()))
                .WithTypeParameterList(
                    SyntaxFactory.TypeParameterList(
                        SyntaxFactory.SingletonSeparatedList(
                            SyntaxFactory.TypeParameter(SyntaxFactory.Identifier("T")))))
                .WithMembers(
                    SyntaxFactory.List(
                        new MemberDeclarationSyntax[]
                        {
                            SyntaxFactory.ConstructorDeclaration(SyntaxFactory.Identifier(Microsoft.OpenApi.Models.NameConstants.Pagination))
                                .WithModifiers(SyntaxFactory.TokenList(SyntaxTokenFactory.PublicKeyword()))
                                .WithBody(
                                    SyntaxFactory.Block()
                                        .WithCloseBraceToken(
                                            SyntaxFactory.Token(
                                                SyntaxFactory.TriviaList(SyntaxFactory.Comment("    // Dummy for serialization.")),
                                                SyntaxKind.CloseBraceToken,
                                                SyntaxFactory.TriviaList()))),
                            SyntaxFactory.ConstructorDeclaration(SyntaxFactory.Identifier(Microsoft.OpenApi.Models.NameConstants.Pagination))
                                .WithModifiers(SyntaxFactory.TokenList(SyntaxTokenFactory.PublicKeyword()))
                                .WithParameterList(
                                    SyntaxFactory.ParameterList(
                                        SyntaxFactory.SeparatedList<ParameterSyntax>(
                                            new SyntaxNodeOrToken[]
                                            {
                                                SyntaxFactory.Parameter(SyntaxFactory.Identifier("items"))
                                                    .WithType(SyntaxFactory.GenericName(SyntaxFactory.Identifier("List"))
                                                        .WithTypeArgumentList(
                                                            SyntaxFactory.TypeArgumentList(
                                                                SyntaxFactory.SingletonSeparatedList<TypeSyntax>(
                                                                    SyntaxFactory.IdentifierName("T"))))),
                                                SyntaxTokenFactory.Comma(),
                                                SyntaxFactory.Parameter(SyntaxFactory.Identifier("pageSize"))
                                                    .WithType(SyntaxFactory.PredefinedType(SyntaxTokenFactory.IntKeyword())),
                                                SyntaxTokenFactory.Comma(),
                                                SyntaxFactory.Parameter(SyntaxFactory.Identifier("queryString"))
                                                    .WithType(SyntaxFactory.NullableType(SyntaxFactory.PredefinedType(SyntaxTokenFactory.StringKeyword()))),
                                                SyntaxTokenFactory.Comma(),
                                                SyntaxFactory.Parameter(SyntaxFactory.Identifier("pageIndex"))
                                                    .WithType(SyntaxFactory.PredefinedType(SyntaxTokenFactory.IntKeyword())),
                                                SyntaxTokenFactory.Comma(),
                                                SyntaxFactory.Parameter(SyntaxFactory.Identifier("totalCount"))
                                                    .WithType(SyntaxFactory.PredefinedType(SyntaxTokenFactory.IntKeyword()))
                                            })))
                            .WithBody(
                                SyntaxFactory.Block(
                                    SyntaxIfStatementFactory.CreateParameterArgumentNullCheck("items", false),
                                    SyntaxFactory.ExpressionStatement(
                                        SyntaxFactory.AssignmentExpression(
                                            SyntaxKind.SimpleAssignmentExpression,
                                            SyntaxFactory.IdentifierName("Items"),
                                            SyntaxFactory.ObjectCreationExpression(SyntaxFactory.GenericName(SyntaxFactory.Identifier("List"))
                                                .WithTypeArgumentList(SyntaxFactory.TypeArgumentList(SyntaxFactory.SingletonSeparatedList<TypeSyntax>(SyntaxFactory.IdentifierName("T")))))
                                            .WithArgumentList(SyntaxFactory.ArgumentList(SyntaxFactory.SingletonSeparatedList(SyntaxFactory.Argument(SyntaxFactory.IdentifierName("items"))))))),
                                    SyntaxFactory.ExpressionStatement(SyntaxAssignmentExpressionFactory.CreateSimple("PageSize", "pageSize")),
                                    SyntaxFactory.ExpressionStatement(SyntaxAssignmentExpressionFactory.CreateSimple("QueryString", "queryString")),
                                    SyntaxFactory.ExpressionStatement(SyntaxAssignmentExpressionFactory.CreateSimple("PageIndex", "pageIndex")),
                                    SyntaxFactory.ExpressionStatement(SyntaxAssignmentExpressionFactory.CreateSimple("TotalCount", "totalCount")),
                                    SyntaxFactory.ExpressionStatement(
                                        SyntaxFactory.AssignmentExpression(
                                            SyntaxKind.SimpleAssignmentExpression,
                                            SyntaxFactory.IdentifierName("TotalPages"),
                                            SyntaxFactory.CastExpression(
                                                SyntaxFactory.PredefinedType(
                                                    SyntaxTokenFactory.IntKeyword()),
                                                SyntaxFactory.InvocationExpression(
                                                    SyntaxFactory.MemberAccessExpression(
                                                        SyntaxKind.SimpleMemberAccessExpression,
                                                        SyntaxFactory.IdentifierName("Math"),
                                                        SyntaxFactory.IdentifierName("Ceiling")))
                                                .WithArgumentList(
                                                    SyntaxFactory.ArgumentList(
                                                        SyntaxFactory.SingletonSeparatedList(
                                                            SyntaxFactory.Argument(
                                                                SyntaxFactory.BinaryExpression(
                                                                    SyntaxKind.DivideExpression,
                                                                    SyntaxFactory.IdentifierName("totalCount"),
                                                                    SyntaxFactory.CastExpression(
                                                                        SyntaxFactory.PredefinedType(SyntaxTokenFactory.DoubleKeyword()),
                                                                        SyntaxFactory.IdentifierName("pageSize")))))))))))),
                            SyntaxFactory.ConstructorDeclaration(SyntaxFactory.Identifier(Microsoft.OpenApi.Models.NameConstants.Pagination))
                                .WithModifiers(SyntaxFactory.TokenList(SyntaxTokenFactory.PublicKeyword()))
                                .WithParameterList(
                                    SyntaxFactory.ParameterList(
                                        SyntaxFactory.SeparatedList<ParameterSyntax>(
                                            new SyntaxNodeOrToken[]
                                            {
                                                SyntaxFactory.Parameter(SyntaxFactory.Identifier("items"))
                                                    .WithType(
                                                        SyntaxFactory.GenericName(SyntaxFactory.Identifier("List"))
                                                        .WithTypeArgumentList(
                                                            SyntaxFactory.TypeArgumentList(
                                                                SyntaxFactory.SingletonSeparatedList<TypeSyntax>(
                                                                    SyntaxFactory.IdentifierName("T"))))),
                                                SyntaxTokenFactory.Comma(),
                                                SyntaxFactory.Parameter(SyntaxFactory.Identifier("pageSize"))
                                                    .WithType(SyntaxFactory.PredefinedType(SyntaxTokenFactory.IntKeyword())),
                                                SyntaxTokenFactory.Comma(),
                                                SyntaxFactory.Parameter(SyntaxFactory.Identifier("queryString"))
                                                    .WithType(SyntaxFactory.NullableType(SyntaxFactory.PredefinedType(SyntaxTokenFactory.StringKeyword()))),
                                                SyntaxTokenFactory.Comma(),
                                                SyntaxFactory.Parameter(SyntaxFactory.Identifier("continuationToken"))
                                                    .WithType(SyntaxFactory.NullableType(SyntaxFactory.PredefinedType(SyntaxTokenFactory.StringKeyword())))
                                            })))
                            .WithBody(
                                SyntaxFactory.Block(
                                    SyntaxIfStatementFactory.CreateParameterArgumentNullCheck("items", false),
                                    SyntaxFactory.ExpressionStatement(
                                        SyntaxFactory.AssignmentExpression(
                                            SyntaxKind.SimpleAssignmentExpression,
                                            SyntaxFactory.IdentifierName("Items"),
                                            SyntaxFactory.ObjectCreationExpression(
                                                SyntaxFactory.GenericName(SyntaxFactory.Identifier("List"))
                                                .WithTypeArgumentList(
                                                    SyntaxFactory.TypeArgumentList(
                                                        SyntaxFactory.SingletonSeparatedList<TypeSyntax>(SyntaxFactory.IdentifierName("T")))))
                                            .WithArgumentList(
                                                SyntaxFactory.ArgumentList(
                                                    SyntaxFactory.SingletonSeparatedList(
                                                        SyntaxFactory.Argument(SyntaxFactory.IdentifierName("items"))))))),
                                    SyntaxFactory.ExpressionStatement(SyntaxAssignmentExpressionFactory.CreateSimple("PageSize", "pageSize")),
                                    SyntaxFactory.ExpressionStatement(SyntaxAssignmentExpressionFactory.CreateSimple("QueryString", "queryString")),
                                    SyntaxFactory.ExpressionStatement(SyntaxAssignmentExpressionFactory.CreateSimple("ContinuationToken", "continuationToken")))),
                            SyntaxPropertyDeclarationFactory.CreateAuto("int", "PageSize"),
                            SyntaxPropertyDeclarationFactory.CreateAuto("int?", "PageIndex"),
                            SyntaxPropertyDeclarationFactory.CreateAuto("string?", "QueryString"),
                            SyntaxPropertyDeclarationFactory.CreateAuto("string?", "ContinuationToken"),
                            SyntaxFactory.PropertyDeclaration(
                                    SyntaxFactory.PredefinedType(SyntaxTokenFactory.IntKeyword()),
                                    SyntaxFactory.Identifier("Count"))
                                .WithModifiers(SyntaxFactory.TokenList(SyntaxTokenFactory.PublicKeyword()))
                                .WithExpressionBody(
                                    SyntaxFactory.ArrowExpressionClause(
                                        SyntaxFactory.BinaryExpression(
                                            SyntaxKind.CoalesceExpression,
                                            SyntaxFactory.ConditionalAccessExpression(SyntaxFactory.IdentifierName("Items"), SyntaxFactory.MemberBindingExpression(SyntaxFactory.IdentifierName("Count"))),
                                            SyntaxFactory.LiteralExpression(SyntaxKind.NumericLiteralExpression, SyntaxFactory.Literal(0)))))
                                .WithSemicolonToken(SyntaxTokenFactory.Semicolon()),
                            SyntaxPropertyDeclarationFactory.CreateAuto("int?", "TotalCount"),
                            SyntaxPropertyDeclarationFactory.CreateAuto("int?", "TotalPages"),
                            SyntaxPropertyDeclarationFactory.CreateListAuto("T", "Items"),
                            SyntaxFactory.MethodDeclaration(
                                SyntaxFactory.PredefinedType(SyntaxTokenFactory.StringKeyword()),
                                SyntaxFactory.Identifier("ToString"))
                            .WithModifiers(SyntaxTokenListFactory.PublicOverrideKeyword())
                            .WithBody(
                                SyntaxFactory.Block(
                                    SyntaxFactory.SingletonList<StatementSyntax>(
                                        SyntaxFactory.ReturnStatement(
                                            SyntaxFactory.InterpolatedStringExpression(SyntaxFactory.Token(SyntaxKind.InterpolatedStringStartToken))
                                            .WithContents(
                                                SyntaxFactory.List(
                                                    new[]
                                                    {
                                                        SyntaxFactory.Interpolation(
                                                            SyntaxFactory.InvocationExpression(SyntaxFactory.IdentifierName("nameof"))
                                                            .WithArgumentList(
                                                                SyntaxFactory.ArgumentList(
                                                                    SyntaxFactory.SingletonSeparatedList(
                                                                        SyntaxFactory.Argument(
                                                                            SyntaxFactory.IdentifierName("Items")))))),
                                                        SyntaxInterpolatedFactory.StringTextDotCountColon(),
                                                        SyntaxFactory.Interpolation(
                                                            SyntaxFactory.MemberAccessExpression(
                                                                SyntaxKind.SimpleMemberAccessExpression,
                                                                SyntaxFactory.IdentifierName("Items"),
                                                                SyntaxFactory.IdentifierName("Count"))),
                                                        SyntaxInterpolatedFactory.StringTextComma(),
                                                        SyntaxFactory.Interpolation(SyntaxFactory.InvocationExpression(SyntaxFactory.IdentifierName("nameof"))
                                                                .WithArgumentList(
                                                                    SyntaxFactory.ArgumentList(
                                                                        SyntaxFactory.SingletonSeparatedList(
                                                                            SyntaxFactory.Argument(
                                                                                SyntaxFactory.IdentifierName("PageSize")))))),
                                                        SyntaxInterpolatedFactory.StringTextColon(),
                                                        SyntaxFactory.Interpolation(SyntaxFactory.IdentifierName("PageSize")),
                                                        SyntaxInterpolatedFactory.StringTextComma(),
                                                        SyntaxFactory.Interpolation(SyntaxFactory.InvocationExpression(SyntaxFactory.IdentifierName("nameof"))
                                                                .WithArgumentList(
                                                                    SyntaxFactory.ArgumentList(
                                                                        SyntaxFactory.SingletonSeparatedList(
                                                                            SyntaxFactory.Argument(
                                                                                SyntaxFactory.IdentifierName("PageIndex")))))),
                                                        SyntaxInterpolatedFactory.StringTextColon(),
                                                        SyntaxFactory.Interpolation(SyntaxFactory.IdentifierName("PageIndex")),
                                                        SyntaxInterpolatedFactory.StringTextComma(),

                                                        SyntaxFactory.Interpolation(
                                                            SyntaxFactory.InvocationExpression(SyntaxFactory.IdentifierName("nameof"))
                                                                .WithArgumentList(
                                                                    SyntaxFactory.ArgumentList(
                                                                        SyntaxFactory.SingletonSeparatedList(
                                                                            SyntaxFactory.Argument(
                                                                                SyntaxFactory.IdentifierName("QueryString")))))),
                                                        SyntaxInterpolatedFactory.StringTextColon(),
                                                        SyntaxFactory.Interpolation(SyntaxFactory.IdentifierName("QueryString")),
                                                        SyntaxInterpolatedFactory.StringTextComma(),
                                                        SyntaxInterpolatedFactory.StringTextComma(),
                                                        SyntaxFactory.Interpolation(
                                                            SyntaxFactory.InvocationExpression(SyntaxFactory.IdentifierName("nameof"))
                                                                .WithArgumentList(
                                                                    SyntaxFactory.ArgumentList(
                                                                        SyntaxFactory.SingletonSeparatedList(
                                                                            SyntaxFactory.Argument(
                                                                                SyntaxFactory.IdentifierName("ContinuationToken")))))),
                                                        SyntaxInterpolatedFactory.StringTextColon(),
                                                        SyntaxFactory.Interpolation(SyntaxFactory.IdentifierName("ContinuationToken")),
                                                        SyntaxInterpolatedFactory.StringTextComma(),
                                                        SyntaxFactory.Interpolation(
                                                            SyntaxFactory.InvocationExpression(
                                                                SyntaxFactory.IdentifierName("nameof"))
                                                            .WithArgumentList(
                                                                SyntaxFactory.ArgumentList(
                                                                    SyntaxFactory.SingletonSeparatedList(
                                                                        SyntaxFactory.Argument(
                                                                            SyntaxFactory.IdentifierName("TotalCount")))))),
                                                        SyntaxInterpolatedFactory.StringTextColon(),
                                                        SyntaxFactory.Interpolation(SyntaxFactory.IdentifierName("TotalCount")),
                                                        SyntaxInterpolatedFactory.StringTextComma(),
                                                        SyntaxFactory.Interpolation(
                                                            SyntaxFactory.InvocationExpression(SyntaxFactory.IdentifierName("nameof"))
                                                            .WithArgumentList(
                                                                SyntaxFactory.ArgumentList(
                                                                    SyntaxFactory.SingletonSeparatedList(
                                                                        SyntaxFactory.Argument(
                                                                            SyntaxFactory.IdentifierName("TotalPages")))))),
                                                        SyntaxInterpolatedFactory.StringTextColon(),
                                                        SyntaxFactory.Interpolation(SyntaxFactory.IdentifierName("TotalPages"))
                                                    }))))))
                        }));

            // Add class to namespace
            @namespace = @namespace.AddMembers(classDeclaration);

            // Add namespace to compilationUnit
            compilationUnit = compilationUnit.AddMembers(@namespace);

            var codeAsString = compilationUnit
                .NormalizeWhitespace()
                .ToFullString()
                .FormatAutoPropertiesOnOneLine()
                .FormatPublicPrivateLines();

            var file = new FileInfo(Path.Combine(apiProjectOptions.PathForSrcGenerate.FullName, $"{Microsoft.OpenApi.Models.NameConstants.Pagination}.cs"));
            TextFileHelper.Save(file, codeAsString);
        }
    }
}