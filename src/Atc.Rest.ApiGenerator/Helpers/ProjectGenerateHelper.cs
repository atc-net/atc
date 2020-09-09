using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Xml.Linq;
using Atc.CodeAnalysis.CSharp.SyntaxFactories;
using Atc.Rest.ApiGenerator.Factories;
using Atc.Rest.ApiGenerator.Models;
using Atc.Rest.ApiGenerator.ProjectSyntaxFactories;
using Atc.Rest.ApiGenerator.SyntaxFactories;
using Atc.Rest.ApiGenerator.SyntaxGenerators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

// ReSharper disable LocalizableElement
// ReSharper disable ForeachCanBePartlyConvertedToQueryUsingAnotherGetEnumerator
// ReSharper disable ForeachCanBeConvertedToQueryUsingAnotherGetEnumerator
// ReSharper disable LoopCanBeConvertedToQuery
// ReSharper disable UseDeconstruction
namespace Atc.Rest.ApiGenerator.Helpers
{
    internal static class ProjectGenerateHelper
    {
        public static void Scaffold(ApiProjectOptions apiProjectOptions)
        {
            if (apiProjectOptions == null)
            {
                throw new ArgumentNullException(nameof(apiProjectOptions));
            }

            if (!Directory.Exists(apiProjectOptions.PathForSrcGenerate.FullName))
            {
                Directory.CreateDirectory(apiProjectOptions.PathForSrcGenerate.FullName);
            }

            var file = new FileInfo(Path.Combine(apiProjectOptions.PathForSrcGenerate.FullName, $"{apiProjectOptions.ProjectName}.Generated.csproj"));
            if (apiProjectOptions.PathForSrcGenerate.Exists && file.Exists)
            {
                var element = XElement.Load(file.FullName);
                var originalNullableValue = GetBoolFromNullableString(GetNullableValueFromProject(element));

                if (apiProjectOptions.ApiOptions.Generator.UseNullableReferenceTypes != originalNullableValue)
                {
                    var newNullableValue = GetNullableStringFromBool(apiProjectOptions.ApiOptions.Generator.UseNullableReferenceTypes);
                    SetNullableValueForProject(element, newNullableValue);
                    element.Save(file.FullName);
                }
            }
            else
            {
                ScaffoldProjFile(apiProjectOptions.PathForSrcGenerate, apiProjectOptions.ProjectName, apiProjectOptions.ApiOptions.Generator.UseNullableReferenceTypes);
            }

            ScaffoldBasicFileApiGenerated(apiProjectOptions);
            ScaffoldBasicFileResultFactory(apiProjectOptions);
            ScaffoldBasicFilePagination(apiProjectOptions);
        }

        public static void PerformCleanup(DirectoryInfo apiProjectSrcGeneratePath)
        {
            if (apiProjectSrcGeneratePath == null)
            {
                throw new ArgumentNullException(nameof(apiProjectSrcGeneratePath));
            }

            if (!apiProjectSrcGeneratePath.Exists)
            {
                return;
            }

            var contractsPath = new DirectoryInfo(Path.Combine(apiProjectSrcGeneratePath.FullName, "Contracts"));
            if (contractsPath.Exists)
            {
                Directory.Delete(contractsPath.FullName, true);
            }

            var endpointsPath = new DirectoryInfo(Path.Combine(apiProjectSrcGeneratePath.FullName, "Endpoints"));
            if (endpointsPath.Exists)
            {
                Directory.Delete(endpointsPath.FullName, true);
            }

            var fileResultFactory = new FileInfo(Path.Combine(apiProjectSrcGeneratePath.FullName, "ResultFactory.cs"));
            if (fileResultFactory.Exists)
            {
                fileResultFactory.Delete();
            }

            var filePagination = new FileInfo(Path.Combine(apiProjectSrcGeneratePath.FullName, $"{Microsoft.OpenApi.Models.NameConstants.Pagination}.cs"));
            if (filePagination.Exists)
            {
                filePagination.Delete();
            }
        }

        public static void CopyApiSpecification(ApiProjectOptions apiProjectOptions)
        {
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

        public static void GenerateContracts(ApiProjectOptions apiProjectOptions)
        {
            if (apiProjectOptions == null)
            {
                throw new ArgumentNullException(nameof(apiProjectOptions));
            }

            var operationSchemaMappings = OpenApiOperationSchemaMapHelper.CollectMappings(apiProjectOptions.Document);
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

                if (map.LocatedArea == SchemaMapLocatedAreaType.RequestBody)
                {
                    generatorModel.LocationArea = SchemaMapLocatedAreaType.RequestBody;
                }

                generatorModel.GenerateCode();
                sgContractModels.Add(generatorModel);
            }

            foreach (var sg in sgContractModels)
            {
                sg.ToFile();
            }

            foreach (var sg in sgContractParameters)
            {
                sg.ToFile();
            }

            foreach (var sg in sgContractResults)
            {
                sg.ToFile();
            }

            foreach (var sg in sgContractInterfaces)
            {
                sg.ToFile();
            }
        }

        public static void GenerateEndpoints(ApiProjectOptions apiProjectOptions)
        {
            if (apiProjectOptions == null)
            {
                throw new ArgumentNullException(nameof(apiProjectOptions));
            }

            var sgEndpoints = new List<SyntaxGeneratorEndpointControllers>();
            foreach (var segmentName in apiProjectOptions.BasePathSegmentNames)
            {
                var generator = new SyntaxGeneratorEndpointControllers(apiProjectOptions, segmentName);
                generator.GenerateCode();
                sgEndpoints.Add(generator);
            }

            foreach (var sg in sgEndpoints)
            {
                sg.ToFile();
            }
        }

        public static bool ValidateVersioning(ApiProjectOptions apiProjectOptions)
        {
            if (!Directory.Exists(apiProjectOptions.PathForSrcGenerate.FullName))
            {
                return true;
            }

            var apiGeneratedFile = Path.Combine(apiProjectOptions.PathForSrcGenerate.FullName, "ApiGenerated.cs");
            if (!File.Exists(apiGeneratedFile))
            {
                return true;
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
                    Console.WriteLine("Existing project version is invalid.");
                    return false;
                }

                if (newVersion >= oldVersionResult)
                {
                    return true;
                }

                Console.WriteLine("Existing project version is never than this tool version.");
                return false;
            }

            Console.WriteLine("Existing project did not contain a version.");
            return false;
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
            var classDeclaration = SyntaxClassDeclarationFactory.Create("ApiGenerated");

            // Add class to namespace
            @namespace = @namespace.AddMembers(classDeclaration);

            // Add namespace to compilationUnit
            compilationUnit = compilationUnit.AddMembers(@namespace);

            var codeAsString = compilationUnit
                .NormalizeWhitespace()
                .ToFullString();

            var file = new FileInfo(Path.Combine(apiProjectOptions.PathForSrcGenerate.FullName, "ApiGenerated.cs"));
            FileHelper.Save(file, codeAsString);
        }

        private static void ScaffoldBasicFileResultFactory(ApiProjectOptions apiProjectOptions)
        {
            // Create compilationUnit
            var compilationUnit = SyntaxFactory.CompilationUnit();

            // Create a namespace
            var @namespace = SyntaxProjectFactory.CreateNamespace(apiProjectOptions);

            // Create class
            var classDeclaration = SyntaxClassDeclarationFactory.CreateAsInternalStatic("ResultFactory");

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
            FileHelper.Save(file, codeAsString);
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
                                    SyntaxIfStatementFactory.CreateParameterArgumentNullCheck("items"),
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
                                    SyntaxIfStatementFactory.CreateParameterArgumentNullCheck("items"),
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
            FileHelper.Save(file, codeAsString);
        }

        private static void ScaffoldProjFile(
            DirectoryInfo apiProjectSrcGeneratePath,
            string apiProjectName,
            bool useNullableReferenceTypes)
        {
            var sb = new StringBuilder();
            sb.AppendLine("<Project Sdk=\"Microsoft.NET.Sdk\">");
            sb.AppendLine();
            sb.AppendLine(" <PropertyGroup>");
            sb.AppendLine("     <TargetFramework>netcoreapp3.1</TargetFramework>");
            sb.AppendLine(" </PropertyGroup>");
            sb.AppendLine();
            sb.AppendLine(" <PropertyGroup>");
            if (useNullableReferenceTypes)
            {
                sb.AppendLine("     <Nullable>enable</Nullable>");
            }

            sb.AppendLine("     <LangVersion>8.0</LangVersion>");
            sb.AppendLine(" </PropertyGroup>");
            sb.AppendLine();
            sb.AppendLine(" <PropertyGroup>");
            sb.AppendLine("     <GenerateDocumentationFile>true</GenerateDocumentationFile>");
            sb.AppendLine(" </PropertyGroup>");
            sb.AppendLine();
            sb.AppendLine(" <PropertyGroup>");
            sb.AppendLine($"     <DocumentationFile>bin\\Debug\\netcoreapp3.1\\{apiProjectName}.Generated.xml</DocumentationFile>");
            sb.AppendLine("     <NoWarn>1573;1591;1701;1702;1712;8618</NoWarn>");
            sb.AppendLine(" </PropertyGroup>");
            sb.AppendLine();
            sb.AppendLine(" <ItemGroup>");
            sb.AppendLine("     <None Remove=\"Resources\\ApiSpecification.yaml\" />");
            sb.AppendLine("     <EmbeddedResource Include=\"Resources\\ApiSpecification.yaml\" />");
            sb.AppendLine(" </ItemGroup>");
            sb.AppendLine();
            sb.AppendLine(" <ItemGroup>");
            sb.AppendLine("     <FrameworkReference Include=\"Microsoft.AspNetCore.App\" />");
            sb.AppendLine(" </ItemGroup>");
            sb.AppendLine();
            sb.AppendLine("</Project>");
            var file = new FileInfo(Path.Combine(apiProjectSrcGeneratePath.FullName, $"{apiProjectName}.Generated.csproj"));
            FileHelper.Save(file, sb.ToString());
        }

        private static string GetNullableValueFromProject(XElement element)
        {
            foreach (var propertyGroup in element.Descendants("PropertyGroup"))
            {
                foreach (var propertyGroupElement in propertyGroup.Elements())
                {
                    if (propertyGroupElement.Name == "Nullable")
                    {
                        return propertyGroupElement.Value;
                    }
                }
            }

            return string.Empty;
        }

        private static void SetNullableValueForProject(XElement element, string newNullableValue)
        {
            var isUpdated = false;
            var hasLanguageVersion = false;

            foreach (var propertyGroup in element.Descendants("PropertyGroup"))
            {
                foreach (var propertyGroupElement in propertyGroup.Elements())
                {
                    if (propertyGroupElement.Name != "Nullable")
                    {
                        continue;
                    }

                    propertyGroupElement.Value = newNullableValue;
                    isUpdated = true;
                }
            }

            foreach (var propertyGroup in element.Descendants("PropertyGroup"))
            {
                foreach (var propertyGroupElement in propertyGroup.Elements())
                {
                    if (propertyGroupElement.Name == "LangVersion")
                    {
                        hasLanguageVersion = true;
                    }
                }
            }

            if (isUpdated)
            {
                return;
            }

            var nullabilityRoot = XElement.Parse(hasLanguageVersion
                ? @"<PropertyGroup><Nullable>enable</Nullable></PropertyGroup>"
                : @"<PropertyGroup><Nullable>enable</Nullable><LangVersion>8.0</LangVersion></PropertyGroup>");

            element.Add(nullabilityRoot);
        }

        private static bool GetBoolFromNullableString(string value) => value == "enable";

        private static string GetNullableStringFromBool(bool value) => value ? "enable" : "disable";
    }
}