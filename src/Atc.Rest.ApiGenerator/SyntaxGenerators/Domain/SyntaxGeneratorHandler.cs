using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Atc.CodeAnalysis.CSharp.SyntaxFactories;
using Atc.Rest.ApiGenerator.Factories;
using Atc.Rest.ApiGenerator.Helpers;
using Atc.Rest.ApiGenerator.Models;
using Atc.Rest.ApiGenerator.ProjectSyntaxFactories;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.OpenApi.Models;

namespace Atc.Rest.ApiGenerator.SyntaxGenerators.Domain
{
    public class SyntaxGeneratorHandler
    {
        public SyntaxGeneratorHandler(
            DomainProjectOptions domainProjectOptions,
            OperationType apiOperationType,
            OpenApiOperation apiOperation,
            string focusOnSegmentName)
        {
            this.DomainProjectOptions = domainProjectOptions ?? throw new ArgumentNullException(nameof(domainProjectOptions));
            this.ApiOperationType = apiOperationType;
            this.ApiOperation = apiOperation ?? throw new ArgumentNullException(nameof(apiOperation));
            this.FocusOnSegmentName = focusOnSegmentName ?? throw new ArgumentNullException(nameof(focusOnSegmentName));
        }

        public DomainProjectOptions DomainProjectOptions { get; }

        public OperationType ApiOperationType { get; }

        public OpenApiOperation ApiOperation { get; }

        public string FocusOnSegmentName { get; }

        public CompilationUnitSyntax? Code { get; private set; }

        public bool GenerateCode()
        {
            var interfaceTypeName = "I" + ApiOperation.GetOperationName() + NameConstants.Handler;
            var parameterTypeName = ApiOperation.GetOperationName() + NameConstants.ContractParameters;
            var resultTypeName = ApiOperation.GetOperationName() + NameConstants.ContractResult;
            var handlerTypeName = ApiOperation.GetOperationName() + NameConstants.Handler;

            // Create compilationUnit
            var compilationUnit = SyntaxFactory.CompilationUnit();

            // Create a namespace
            var @namespace = SyntaxProjectFactory.CreateNamespace(
                DomainProjectOptions,
                NameConstants.Handlers,
                FocusOnSegmentName,
                false);

            // Create class
            var classDeclaration = SyntaxClassDeclarationFactory.CreateWithInterface(handlerTypeName, interfaceTypeName)
                .WithLeadingTrivia(SyntaxDocumentationFactory.CreateForHandlers(ApiOperation, FocusOnSegmentName));

            // Create members
            var memberDeclarations = CreateMembers(parameterTypeName, resultTypeName, ApiOperation.HasParametersOrRequestBody());

            // Add members to class
            classDeclaration = memberDeclarations.Aggregate(
                classDeclaration,
                (current, memberDeclaration) => current.AddMembers(memberDeclaration));

            // Add using statement to compilationUnit
            compilationUnit = compilationUnit.AddUsingStatements(ProjectHandlerFactory.CreateUsingList(
                DomainProjectOptions,
                FocusOnSegmentName));

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
                return $"Syntax generate problem for handler for apiOperation: {ApiOperation}";
            }

            return Code
                .NormalizeWhitespace()
                .ToFullString();
        }

        public void ToFile()
        {
            var area = FocusOnSegmentName.EnsureFirstCharacterToUpper();
            var handlerName = ApiOperation.GetOperationName() + NameConstants.Handler;
            var file = Util.GetCsFileNameForHandler(DomainProjectOptions.PathForHandlers, area, handlerName);
            if (!File.Exists(file))
            {
                FileHelper.Save(file, ToCodeAsString());
            }
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
            return $"OperationType: {ApiOperationType}, OperationName: {ApiOperation.GetOperationName()}, SegmentName: {FocusOnSegmentName}";
        }

        private List<MemberDeclarationSyntax> CreateMembers(string parameterTypeName, string resultTypeName, bool hasParameters)
        {
            var result = new List<MemberDeclarationSyntax>
            {
                CreateExecuteAsyncMethod(parameterTypeName, resultTypeName, hasParameters)
            };

            if (hasParameters)
            {
                result.Add(CreateInvokeExecuteAsyncMethod(parameterTypeName, resultTypeName, hasParameters));
            }

            return result;
        }

        private MemberDeclarationSyntax CreateExecuteAsyncMethod(string parameterTypeName, string resultTypeName, bool hasParameters)
        {
            var arguments = hasParameters
                ? new SyntaxNodeOrToken[]
                {
                    SyntaxParameterFactory.Create(parameterTypeName, "parameters"),
                    SyntaxTokenFactory.Comma(),
                    SyntaxParameterFactory.Create(nameof(CancellationToken), nameof(CancellationToken).EnsureFirstCharacterToLower())
                        .WithDefault(SyntaxFactory.EqualsValueClause(
                            SyntaxFactory.LiteralExpression(SyntaxKind.DefaultLiteralExpression, SyntaxTokenFactory.DefaultKeyword())))
                }
                : new SyntaxNodeOrToken[]
                {
                    SyntaxParameterFactory.Create(nameof(CancellationToken), nameof(CancellationToken).EnsureFirstCharacterToLower())
                        .WithDefault(SyntaxFactory.EqualsValueClause(
                            SyntaxFactory.LiteralExpression(SyntaxKind.DefaultLiteralExpression, SyntaxTokenFactory.DefaultKeyword())))
                };

            var codeBody = hasParameters
                ? SyntaxFactory.Block(
                    SyntaxIfStatementFactory.CreateParameterArgumentNullCheck("parameters"),
                    SyntaxThrowStatementFactory.CreateNotImplementedException())
                : SyntaxFactory.Block(
                    SyntaxThrowStatementFactory.CreateNotImplementedException());

            return SyntaxFactory.MethodDeclaration(
                    SyntaxFactory.GenericName(SyntaxFactory.Identifier(nameof(Task)))
                        .WithTypeArgumentList(SyntaxTypeArgumentListFactory.CreateWithOneItem(resultTypeName)),
                    SyntaxFactory.Identifier("ExecuteAsync"))
                .WithModifiers(SyntaxTokenListFactory.PublicAsyncKeyword())
                .WithParameterList(SyntaxFactory.ParameterList(SyntaxFactory.SeparatedList<ParameterSyntax>(arguments)))
                .WithBody(codeBody);
        }

        private MemberDeclarationSyntax CreateInvokeExecuteAsyncMethod(string parameterTypeName, string resultTypeName, bool hasParameters)
        {
            var arguments = hasParameters
                ? new SyntaxNodeOrToken[]
                {
                    SyntaxParameterFactory.Create(parameterTypeName, "parameters"),
                    SyntaxTokenFactory.Comma(),
                    SyntaxParameterFactory.Create(nameof(CancellationToken), nameof(CancellationToken).EnsureFirstCharacterToLower())
                        .WithDefault(SyntaxFactory.EqualsValueClause(
                            SyntaxFactory.LiteralExpression(SyntaxKind.DefaultLiteralExpression, SyntaxTokenFactory.DefaultKeyword())))
                }
                : new SyntaxNodeOrToken[]
                {
                    SyntaxParameterFactory.Create(nameof(CancellationToken), nameof(CancellationToken).EnsureFirstCharacterToLower())
                        .WithDefault(SyntaxFactory.EqualsValueClause(
                            SyntaxFactory.LiteralExpression(SyntaxKind.DefaultLiteralExpression, SyntaxTokenFactory.DefaultKeyword())))
                };

            return SyntaxFactory.MethodDeclaration(
                    SyntaxFactory.GenericName(SyntaxFactory.Identifier(nameof(Task)))
                        .WithTypeArgumentList(SyntaxTypeArgumentListFactory.CreateWithOneItem(resultTypeName)),
                    SyntaxFactory.Identifier("InvokeExecuteAsync"))
                .WithModifiers(SyntaxTokenListFactory.PublicAsyncKeyword())
                .WithParameterList(SyntaxFactory.ParameterList(SyntaxFactory.SeparatedList<ParameterSyntax>(arguments)))
                .WithBody(SyntaxFactory.Block(SyntaxThrowStatementFactory.CreateNotImplementedException()));
        }
    }
}