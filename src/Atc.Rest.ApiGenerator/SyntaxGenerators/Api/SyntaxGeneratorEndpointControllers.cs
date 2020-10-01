using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Atc.CodeAnalysis.CSharp.SyntaxFactories;
using Atc.Data.Models;
using Atc.Rest.ApiGenerator.Factories;
using Atc.Rest.ApiGenerator.Helpers;
using Atc.Rest.ApiGenerator.Models;
using Atc.Rest.ApiGenerator.ProjectSyntaxFactories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.OpenApi.Models;

// ReSharper disable ForeachCanBePartlyConvertedToQueryUsingAnotherGetEnumerator
// ReSharper disable UseDeconstruction
namespace Atc.Rest.ApiGenerator.SyntaxGenerators.Api
{
    public class SyntaxGeneratorEndpointControllers : ISyntaxGeneratorEndpointControllers
    {
        public SyntaxGeneratorEndpointControllers(
            ApiProjectOptions apiProjectOptions,
            List<ApiOperationSchemaMap> operationSchemaMappings,
            string focusOnSegmentName)
        {
            this.ApiProjectOptions = apiProjectOptions ?? throw new ArgumentNullException(nameof(apiProjectOptions));
            this.OperationSchemaMappings = operationSchemaMappings ?? throw new ArgumentNullException(nameof(apiProjectOptions));
            this.FocusOnSegmentName = focusOnSegmentName ?? throw new ArgumentNullException(nameof(focusOnSegmentName));
        }

        private ApiProjectOptions ApiProjectOptions { get; }

        private List<ApiOperationSchemaMap> OperationSchemaMappings { get; }

        public string FocusOnSegmentName { get; }

        public CompilationUnitSyntax? Code { get; private set; }

        public bool GenerateCode()
        {
            var controllerTypeName = FocusOnSegmentName.EnsureFirstCharacterToUpper() + "Controller";

            // Create compilationUnit
            var compilationUnit = SyntaxFactory.CompilationUnit();

            // Create a namespace
            var @namespace = SyntaxProjectFactory.CreateNamespace(
                ApiProjectOptions,
                NameConstants.Endpoints);

            // Create class
            var classDeclaration = SyntaxClassDeclarationFactory.Create(controllerTypeName);
            if (ApiProjectOptions.ApiOptions.Generator.UseAuthorization)
            {
                classDeclaration =
                    classDeclaration.AddAttributeLists(
                        SyntaxAttributeListFactory.CreateWithOneItem(nameof(AuthorizeAttribute)));
            }

            classDeclaration =
                classDeclaration.AddAttributeLists(
                    SyntaxAttributeListFactory.CreateWithOneItem(nameof(ApiControllerAttribute)),
                    SyntaxAttributeListFactory.CreateWithOneItemWithOneArgument(nameof(RouteAttribute), $"api/{ApiProjectOptions.ApiVersion}/{FocusOnSegmentName}"))
                .AddBaseListTypes(SyntaxFactory.SimpleBaseType(SyntaxFactory.ParseTypeName(nameof(ControllerBase))))
                .WithLeadingTrivia(SyntaxDocumentationFactory.CreateForEndpoints(FocusOnSegmentName));

            // Create Methods
            var usedApiOperations = new List<OpenApiOperation>();
            foreach (var (key, value) in ApiProjectOptions.Document.GetPathsByBasePathSegmentName(FocusOnSegmentName))
            {
                foreach (var apiOperation in value.Operations)
                {
                    var methodDeclaration = CreateMembersForEndpoints(apiOperation, key, FocusOnSegmentName)
                        .WithLeadingTrivia(SyntaxDocumentationFactory.CreateForEndpointMethods(apiOperation, FocusOnSegmentName));
                    classDeclaration = classDeclaration.AddMembers(methodDeclaration);

                    usedApiOperations.Add(apiOperation.Value);
                }
            }

            foreach (var (_, value) in ApiProjectOptions.Document.GetPathsByBasePathSegmentName(FocusOnSegmentName))
            {
                foreach (var apiOperation in value.Operations)
                {
                    var methodDeclaration = CreateMembersForEndpointsPrivateHelper(apiOperation);
                    classDeclaration = classDeclaration.AddMembers(methodDeclaration);

                    usedApiOperations.Add(apiOperation.Value);
                }
            }

            // Add the class to the namespace.
            @namespace = @namespace.AddMembers(classDeclaration);

            // Add using statement to compilationUnit
            compilationUnit = compilationUnit.AddUsingStatements(ProjectEndpointsFactory.CreateUsingList(
                ApiProjectOptions,
                FocusOnSegmentName,
                usedApiOperations));

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
                return $"Syntax generate problem for endpoints-controller for: {FocusOnSegmentName}";
            }

            return Code
                .NormalizeWhitespace()
                .ToFullString();
        }

        public LogKeyValueItem ToFile()
        {
            var controllerName = FocusOnSegmentName.EnsureFirstCharacterToUpper() + "Controller";
            var file = Util.GetCsFileNameForEndpoints(ApiProjectOptions.PathForEndpoints, controllerName);
            FileHelper.Save(file, ToCodeAsString());
            return new LogKeyValueItem(LogCategoryType.Debug, "SGCController", $"Created file {file}");
        }

        public void ToFile(FileInfo file)
        {
            if (file == null)
            {
                throw new ArgumentNullException(nameof(file));
            }

            FileHelper.Save(file, ToCodeAsString());
        }

        private MethodDeclarationSyntax CreateMembersForEndpoints(
            KeyValuePair<OperationType, OpenApiOperation> apiOperation,
            string urlPath,
            string area)
        {
            var operationName = apiOperation.Value.GetOperationName();
            var interfaceName = "I" + operationName + NameConstants.ContractHandler;
            var methodName = operationName + "Async";
            var helperMethodName = $"Invoke{operationName}Async";
            var parameterTypeName = operationName + NameConstants.ContractParameters;
            var resultTypeName = operationName + NameConstants.ContractResult;

            // Create method # use CreateParameterList & CreateCodeBlockReturnStatement
            var methodDeclaration = SyntaxFactory.MethodDeclaration(
                    SyntaxFactory.GenericName(SyntaxFactory.Identifier(nameof(Task)))
                        .WithTypeArgumentList(SyntaxTypeArgumentListFactory.CreateWithOneItem(nameof(ActionResult))),
                    SyntaxFactory.Identifier(methodName))
                .AddModifiers(SyntaxTokenFactory.PublicKeyword())
                .WithParameterList(CreateParameterList(apiOperation, parameterTypeName, interfaceName, true))
                .WithBody(
                    SyntaxFactory.Block(
                        SyntaxIfStatementFactory.CreateParameterArgumentNullCheck("handler"),
                        CreateCodeBlockReturnStatement(helperMethodName, apiOperation.Value.HasParametersOrRequestBody())));

            // Create and add Http-method-attribute
            var httpAttributeRoutePart = GetHttpAttributeRoutePart(urlPath);
            methodDeclaration = string.IsNullOrEmpty(httpAttributeRoutePart)
                ? methodDeclaration.AddAttributeLists(
                    SyntaxAttributeListFactory.CreateWithOneItem($"Http{apiOperation.Key}"))
                : methodDeclaration.AddAttributeLists(
                    SyntaxAttributeListFactory.CreateWithOneItemWithOneArgument(
                        $"Http{apiOperation.Key}",
                        httpAttributeRoutePart));

            // Create and add producesResponseTypes-attributes
            var producesResponseAttributeParts = apiOperation.Value.Responses.GetProducesResponseAttributeParts(
                resultTypeName,
                ApiProjectOptions.ApiOptions.Generator.Response.UseProblemDetailsAsDefaultBody,
                area,
                OperationSchemaMappings);

            return producesResponseAttributeParts
                .Aggregate(
                    methodDeclaration,
                    (current, producesResponseAttributePart) => current.AddAttributeLists(
                        SyntaxAttributeListFactory.CreateWithOneItem(producesResponseAttributePart)));
        }

        private static MethodDeclarationSyntax CreateMembersForEndpointsPrivateHelper(
            KeyValuePair<OperationType, OpenApiOperation> apiOperation)
        {
            var operationName = apiOperation.Value.GetOperationName();
            var interfaceName = "I" + operationName + NameConstants.ContractHandler;
            var methodName = $"Invoke{operationName}Async";
            var parameterTypeName = operationName + NameConstants.ContractParameters;

            // Create method # use CreateParameterList & CreateCodeBlockReturnStatement
            var methodDeclaration = SyntaxFactory.MethodDeclaration(
                    SyntaxFactory.GenericName(SyntaxFactory.Identifier(nameof(Task)))
                        .WithTypeArgumentList(SyntaxTypeArgumentListFactory.CreateWithOneItem(nameof(ActionResult))),
                    SyntaxFactory.Identifier(methodName))
                .AddModifiers(SyntaxTokenFactory.PrivateKeyword())
                .AddModifiers(SyntaxTokenFactory.StaticKeyword())
                .AddModifiers(SyntaxTokenFactory.AsyncKeyword())
                .WithParameterList(CreateParameterList(apiOperation, parameterTypeName, interfaceName, false))
                .WithBody(
                    SyntaxFactory.Block(
                        CreateCodeBlockReturnStatementForHelper(apiOperation.Value.HasParametersOrRequestBody())));

            return methodDeclaration;
        }

        private static string GetHttpAttributeRoutePart(string urlPath)
        {
            var urlPathParts = urlPath.Split('/', StringSplitOptions.RemoveEmptyEntries);
            if (urlPathParts.Length <= 1)
            {
                return string.Empty;
            }

            var sb = new StringBuilder();
            for (var i = 1; i < urlPathParts.Length; i++)
            {
                if (i != 1)
                {
                    sb.Append('/');
                }

                sb.Append(urlPathParts[i]);
            }

            return sb.ToString();
        }

        private static ParameterListSyntax CreateParameterList(
            KeyValuePair<OperationType, OpenApiOperation> apiOperation,
            string parameterTypeName,
            string interfaceName,
            bool useFromServicesAttributeOnInterface)
        {
            ParameterListSyntax parameterList;
            if (apiOperation.Value.HasParametersOrRequestBody())
            {
                if (useFromServicesAttributeOnInterface)
                {
                    parameterList = SyntaxFactory.ParameterList(
                        SyntaxFactory.SeparatedList<ParameterSyntax>(
                            new SyntaxNodeOrToken[]
                            {
                                SyntaxParameterFactory.Create(parameterTypeName, "parameters"),
                                SyntaxTokenFactory.Comma(),
                                SyntaxParameterFactory.CreateWithAttribute(nameof(FromServicesAttribute), interfaceName, "handler"),
                                SyntaxTokenFactory.Comma(),
                                SyntaxParameterFactory.Create(nameof(CancellationToken), nameof(CancellationToken).EnsureFirstCharacterToLower())
                            }));
                }
                else
                {
                    parameterList = SyntaxFactory.ParameterList(
                        SyntaxFactory.SeparatedList<ParameterSyntax>(
                            new SyntaxNodeOrToken[]
                            {
                                SyntaxParameterFactory.Create(parameterTypeName, "parameters"),
                                SyntaxTokenFactory.Comma(),
                                SyntaxParameterFactory.Create(interfaceName, "handler"),
                                SyntaxTokenFactory.Comma(),
                                SyntaxParameterFactory.Create(nameof(CancellationToken), nameof(CancellationToken).EnsureFirstCharacterToLower())
                            }));
                }
            }
            else
            {
                parameterList = SyntaxFactory.ParameterList(
                    SyntaxFactory.SeparatedList<ParameterSyntax>(
                        new SyntaxNodeOrToken[]
                        {
                            SyntaxParameterFactory.CreateWithAttribute(nameof(FromServicesAttribute), interfaceName, "handler"),
                            SyntaxTokenFactory.Comma(),
                            SyntaxParameterFactory.Create(nameof(CancellationToken), nameof(CancellationToken).EnsureFirstCharacterToLower())
                        }));
            }

            return parameterList;
        }

        private static ReturnStatementSyntax CreateCodeBlockReturnStatement(string helperMethodName, bool hasParameters)
        {
            var arguments = hasParameters
                ? new SyntaxNodeOrToken[]
                {
                    SyntaxArgumentFactory.Create("parameters"),
                    SyntaxTokenFactory.Comma(),
                    SyntaxArgumentFactory.Create("handler"),
                    SyntaxTokenFactory.Comma(),
                    SyntaxArgumentFactory.Create("cancellationToken")
                }
                : new SyntaxNodeOrToken[]
                {
                    SyntaxArgumentFactory.Create("handler"),
                    SyntaxTokenFactory.Comma(),
                    SyntaxArgumentFactory.Create("cancellationToken")
                };

            return SyntaxFactory.ReturnStatement(
                SyntaxFactory.InvocationExpression(SyntaxFactory.IdentifierName(helperMethodName))
                    .WithArgumentList(
                        SyntaxFactory.ArgumentList(
                            SyntaxFactory.SeparatedList<ArgumentSyntax>(arguments))));
        }

        private static ReturnStatementSyntax CreateCodeBlockReturnStatementForHelper(bool hasParameters)
        {
            var arguments = hasParameters
                ? new SyntaxNodeOrToken[]
                {
                    SyntaxArgumentFactory.Create("parameters"),
                    SyntaxTokenFactory.Comma(),
                    SyntaxArgumentFactory.Create("cancellationToken")
                }
                : new SyntaxNodeOrToken[]
                {
                    SyntaxArgumentFactory.Create("cancellationToken")
                };

            return SyntaxFactory.ReturnStatement(
                SyntaxFactory.AwaitExpression(
                    SyntaxFactory.InvocationExpression(
                            SyntaxFactory.MemberAccessExpression(
                                SyntaxKind.SimpleMemberAccessExpression,
                                SyntaxFactory.IdentifierName("handler"),
                                SyntaxFactory.IdentifierName("ExecuteAsync")))
                        .WithArgumentList(
                            SyntaxFactory.ArgumentList(
                                SyntaxFactory.SeparatedList<ArgumentSyntax>(arguments)))));
        }
    }
}