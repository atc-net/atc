using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Atc.CodeAnalysis.CSharp.SyntaxFactories;
using Atc.Data.Models;
using Atc.Rest.ApiGenerator.Factories;
using Atc.Rest.ApiGenerator.Helpers;
using Atc.Rest.ApiGenerator.Models;
using Atc.Rest.ApiGenerator.ProjectSyntaxFactories;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Hosting;

// ReSharper disable SuggestBaseTypeForParameter
// ReSharper disable ReturnTypeCanBeEnumerable.Local
namespace Atc.Rest.ApiGenerator.Generators
{
    public class ServerHostGenerator
    {
        private readonly HostProjectOptions projectOptions;

        public ServerHostGenerator(HostProjectOptions projectOptions)
        {
            this.projectOptions = projectOptions ?? throw new ArgumentNullException(nameof(projectOptions));
        }

        public List<LogKeyValueItem> Generate()
        {
            var logItems = new List<LogKeyValueItem>();

            logItems.AddRange(projectOptions.SetPropertiesAfterValidationsOfProjectReferencesPathAndFiles());
            if (logItems.Any(x => x.LogCategory == LogCategoryType.Error))
            {
                return logItems;
            }

            logItems.AddRange(ScaffoldSrc(projectOptions));
            if (projectOptions.PathForTestGenerate != null)
            {
                logItems.AddRange(ScaffoldTest(projectOptions));
            }

            return logItems;
        }

        private static List<LogKeyValueItem> ScaffoldSrc(HostProjectOptions hostProjectOptions)
        {
            if (hostProjectOptions == null)
            {
                throw new ArgumentNullException(nameof(hostProjectOptions));
            }

            if (!Directory.Exists(hostProjectOptions.PathForSrcGenerate.FullName))
            {
                Directory.CreateDirectory(hostProjectOptions.PathForSrcGenerate.FullName);
            }

            var logItems = new List<LogKeyValueItem>();

            if (hostProjectOptions.PathForSrcGenerate.Exists && hostProjectOptions.ProjectSrcCsProj.Exists)
            {
                var element = XElement.Load(hostProjectOptions.ProjectSrcCsProj.FullName);
                var originalNullableValue = SolutionAndProjectHelper.GetBoolFromNullableString(SolutionAndProjectHelper.GetNullableValueFromProject(element));

                bool hasUpdates = false;
                if (hostProjectOptions.ApiOptions.Generator.UseNullableReferenceTypes != originalNullableValue)
                {
                    var newNullableValue = SolutionAndProjectHelper.GetNullableStringFromBool(hostProjectOptions.ApiOptions.Generator.UseNullableReferenceTypes);
                    SolutionAndProjectHelper.SetNullableValueForProject(element, newNullableValue);
                    element.Save(hostProjectOptions.ProjectSrcCsProj.FullName);
                    logItems.Add(new LogKeyValueItem(LogCategoryType.Debug, "FileUpdate", "#", $"Update host csproj - Nullable value={newNullableValue}"));
                    hasUpdates = true;
                }

                if (!hasUpdates)
                {
                    logItems.Add(new LogKeyValueItem(LogCategoryType.Debug, "FileSkip", "#", "No updates for host csproj"));
                }
            }
            else
            {
                var projectReferences = new List<FileInfo>();
                if (hostProjectOptions.ApiProjectSrcCsProj != null)
                {
                    projectReferences.Add(hostProjectOptions.ApiProjectSrcCsProj);
                }

                if (hostProjectOptions.DomainProjectSrcCsProj != null)
                {
                    projectReferences.Add(hostProjectOptions.DomainProjectSrcCsProj);
                }

                logItems.Add(SolutionAndProjectHelper.ScaffoldProjFile(
                    hostProjectOptions.ProjectSrcCsProj,
                    true,
                    false,
                    hostProjectOptions.ProjectName,
                    hostProjectOptions.ApiOptions.Generator.UseNullableReferenceTypes,
                    null,
                    NugetPackageReferenceHelper.CreateForHostProject(hostProjectOptions.UseRestExtended),
                    projectReferences,
                    false));

                logItems.Add(ScaffoldPropertiesLaunchSettingsFile(
                    hostProjectOptions.PathForSrcGenerate,
                    hostProjectOptions.UseRestExtended));
                logItems.Add(ScaffoldProgramFile(hostProjectOptions));
                logItems.Add(ScaffoldStartupFile(hostProjectOptions));
            }

            return logItems;
        }

        private static List<LogKeyValueItem> ScaffoldTest(HostProjectOptions hostProjectOptions)
        {
            if (hostProjectOptions == null)
            {
                throw new ArgumentNullException(nameof(hostProjectOptions));
            }

            var logItems = new List<LogKeyValueItem>();

            if (hostProjectOptions.PathForTestGenerate != null && hostProjectOptions.ProjectTestCsProj != null)
            {
                if (hostProjectOptions.PathForTestGenerate.Exists && hostProjectOptions.ProjectTestCsProj.Exists)
                {
                    // Update
                }
                else
                {
                    if (!Directory.Exists(hostProjectOptions.PathForTestGenerate.FullName))
                    {
                        Directory.CreateDirectory(hostProjectOptions.PathForTestGenerate.FullName);
                    }

                    var projectReferences = new List<FileInfo>();
                    if (hostProjectOptions.ApiProjectSrcCsProj != null)
                    {
                        projectReferences.Add(hostProjectOptions.ApiProjectSrcCsProj);
                    }

                    if (hostProjectOptions.DomainProjectSrcCsProj != null)
                    {
                        projectReferences.Add(hostProjectOptions.DomainProjectSrcCsProj);
                    }

                    logItems.Add(SolutionAndProjectHelper.ScaffoldProjFile(
                        hostProjectOptions.ProjectTestCsProj,
                        false,
                        true,
                        $"{hostProjectOptions.ProjectName}.Tests",
                        hostProjectOptions.ApiOptions.Generator.UseNullableReferenceTypes,
                        null,
                        NugetPackageReferenceHelper.CreateForTestProject(),
                        projectReferences,
                        true));
                }
            }

            return logItems;
        }

        private static LogKeyValueItem ScaffoldPropertiesLaunchSettingsFile(DirectoryInfo pathForSrcGenerate, bool useExtended)
        {
            var propertiesPath = new DirectoryInfo(Path.Combine(pathForSrcGenerate.FullName, "Properties"));
            propertiesPath.Create();

            var resourceName = "Atc.Rest.ApiGenerator.Resources.launchSettings.json";
            if (useExtended)
            {
                resourceName = "Atc.Rest.ApiGenerator.Resources.launchSettingsExtended.json";
            }

            var resourceStream = typeof(ServerHostGenerator).Assembly.GetManifestResourceStream(resourceName);
            var json = resourceStream!.ToStringData();

            var file = new FileInfo(Path.Combine(propertiesPath.FullName, "launchSettings.json"));
            return File.Exists(file.FullName)
                ? new LogKeyValueItem(LogCategoryType.Debug, "FileSkip", "#", file.FullName)
                : TextFileHelper.Save(file, json);
        }

        private static LogKeyValueItem ScaffoldProgramFile(HostProjectOptions hostProjectOptions)
        {
            // Create compilationUnit
            var compilationUnit = SyntaxFactory.CompilationUnit();

            // Create a namespace
            var @namespace = SyntaxProjectFactory.CreateNamespace(hostProjectOptions, false);

            // Create class
            var classDeclaration = SyntaxClassDeclarationFactory.CreateAsPublicStatic("Program");

            // Create method
            var methodDeclarationMain = CreateProgramMain();
            var methodDeclarationHostBuilder = CreateProgramHostBuilder();

            // Add method to class
            classDeclaration = classDeclaration.AddMembers(methodDeclarationMain);
            classDeclaration = classDeclaration.AddMembers(methodDeclarationHostBuilder);

            // Add class to namespace
            @namespace = @namespace.AddMembers(classDeclaration);

            // Add namespace to compilationUnit
            compilationUnit = compilationUnit.AddMembers(@namespace);

            // Add using to compilationUnit
            compilationUnit = compilationUnit.AddUsingStatements(ProjectHostFactory.CreateUsingListForProgram());

            var codeAsString = compilationUnit
                .NormalizeWhitespace()
                .ToFullString();

            var file = new FileInfo(Path.Combine(hostProjectOptions.PathForSrcGenerate.FullName, "Program.cs"));
            return File.Exists(file.FullName)
                ? new LogKeyValueItem(LogCategoryType.Debug, "FileSkip", "#", file.FullName)
                : TextFileHelper.Save(file, codeAsString);
        }

        private static LogKeyValueItem ScaffoldStartupFile(HostProjectOptions hostProjectOptions)
        {
            // Create compilationUnit
            var compilationUnit = SyntaxFactory.CompilationUnit();

            // Create a namespace
            var @namespace = SyntaxProjectFactory.CreateNamespace(hostProjectOptions, false);

            // Create class
            var classDeclaration = SyntaxClassDeclarationFactory.Create("Startup");

            // Create method
            var methodDeclarationPropertyPrivateOptions = CreateStartupPropertyPrivateOptions(hostProjectOptions.UseRestExtended);
            var methodDeclarationConstructor = CreateStartupConstructor(hostProjectOptions.UseRestExtended);
            var methodDeclarationPropertyPublicConfiguration = CreateStartupPropertyPublicConfiguration();
            var methodDeclarationConfigureServices = CreateStartupConfigureServices(hostProjectOptions.UseRestExtended);
            var methodDeclarationConfigure = CreateStartupConfigure();

            // Add method to class
            classDeclaration = classDeclaration.AddMembers(methodDeclarationPropertyPrivateOptions);
            classDeclaration = classDeclaration.AddMembers(methodDeclarationConstructor);
            classDeclaration = classDeclaration.AddMembers(methodDeclarationPropertyPublicConfiguration);
            classDeclaration = classDeclaration.AddMembers(methodDeclarationConfigureServices);
            classDeclaration = classDeclaration.AddMembers(methodDeclarationConfigure);

            // Add class to namespace
            @namespace = @namespace.AddMembers(classDeclaration);

            // Add namespace to compilationUnit
            compilationUnit = compilationUnit.AddMembers(@namespace);

            // Add using to compilationUnit
            compilationUnit = compilationUnit.AddUsingStatements(ProjectHostFactory.CreateUsingListForStartup(
                hostProjectOptions.ProjectName,
                hostProjectOptions.UseRestExtended));

            var codeAsString = compilationUnit
                .NormalizeWhitespace()
                .ToFullString()
                .FormatAutoPropertiesOnOneLine()
                .FormatPublicPrivateLines();

            var file = new FileInfo(Path.Combine(hostProjectOptions.PathForSrcGenerate.FullName, "Startup.cs"));
            return File.Exists(file.FullName)
                ? new LogKeyValueItem(LogCategoryType.Debug, "FileSkip", "#", file.FullName)
                : TextFileHelper.Save(file, codeAsString);
        }

        private static MemberDeclarationSyntax CreateProgramMain()
        {
            var codeBody = SyntaxFactory.Block(
                SyntaxFactory.SingletonList<StatementSyntax>(
                    SyntaxFactory.ExpressionStatement(
                        SyntaxFactory.InvocationExpression(
                            SyntaxFactory.MemberAccessExpression(
                                SyntaxKind.SimpleMemberAccessExpression,
                                SyntaxFactory.InvocationExpression(
                                    SyntaxFactory.MemberAccessExpression(
                                        SyntaxKind.SimpleMemberAccessExpression,
                                        SyntaxFactory.InvocationExpression(
                                                SyntaxFactory.IdentifierName("CreateHostBuilder"))
                                            .WithArgumentList(
                                                SyntaxFactory.ArgumentList(
                                                    SyntaxFactory.SingletonSeparatedList(
                                                        SyntaxFactory.Argument(
                                                            SyntaxFactory.IdentifierName("args"))))),
                                        SyntaxFactory.IdentifierName("Build"))),
                                SyntaxFactory.IdentifierName("Run"))))));

            return SyntaxFactory.MethodDeclaration(
                    SyntaxFactory.PredefinedType(SyntaxFactory.Token(SyntaxKind.VoidKeyword)),
                    SyntaxFactory.Identifier("Main"))
                .WithModifiers(SyntaxTokenListFactory.PublicStaticKeyword())
                .WithParameterList(
                    SyntaxFactory.ParameterList(
                        SyntaxFactory.SingletonSeparatedList(
                            SyntaxFactory.Parameter(SyntaxFactory.Identifier("args"))
                                .WithType(
                                    SyntaxFactory.ArrayType(
                                        SyntaxFactory.PredefinedType(
                                            SyntaxTokenFactory.StringKeyword()))
                                    .WithRankSpecifiers(
                                        SyntaxFactory.SingletonList(
                                            SyntaxFactory.ArrayRankSpecifier(
                                                SyntaxFactory.SingletonSeparatedList<ExpressionSyntax>(
                                                    SyntaxFactory.OmittedArraySizeExpression()))))))))
                .WithBody(codeBody);
        }

        private static MemberDeclarationSyntax CreateProgramHostBuilder()
        {
            var codeBody = SyntaxFactory.Block(
                SyntaxFactory.LocalDeclarationStatement(
                    SyntaxFactory.VariableDeclaration(
                        SyntaxFactory.IdentifierName("var"))
                    .WithVariables(
                        SyntaxFactory.SingletonSeparatedList(
                            SyntaxFactory.VariableDeclarator(
                                SyntaxFactory.Identifier("builder"))
                            .WithInitializer(
                                SyntaxFactory.EqualsValueClause(
                                    SyntaxFactory.InvocationExpression(
                                        SyntaxFactory.MemberAccessExpression(
                                            SyntaxKind.SimpleMemberAccessExpression,
                                            SyntaxFactory.InvocationExpression(
                                                SyntaxFactory.MemberAccessExpression(
                                                    SyntaxKind.SimpleMemberAccessExpression,
                                                    SyntaxFactory.IdentifierName("Host"),
                                                    SyntaxFactory.IdentifierName("CreateDefaultBuilder")))
                                            .WithArgumentList(
                                                SyntaxFactory.ArgumentList(
                                                    SyntaxFactory.SingletonSeparatedList(
                                                        SyntaxFactory.Argument(
                                                            SyntaxFactory.IdentifierName("args"))))),
                                            SyntaxFactory.IdentifierName("ConfigureWebHostDefaults")))
                                    .WithArgumentList(
                                        SyntaxFactory.ArgumentList(
                                            SyntaxFactory.SingletonSeparatedList(
                                                SyntaxFactory.Argument(
                                                    SyntaxFactory.SimpleLambdaExpression(
                                                        SyntaxFactory.Parameter(
                                                            SyntaxFactory.Identifier("webBuilder")))
                                                    .WithBlock(
                                                        SyntaxFactory.Block(
                                                            SyntaxFactory.SingletonList<StatementSyntax>(
                                                                SyntaxFactory.ExpressionStatement(
                                                                    SyntaxFactory.InvocationExpression(
                                                                        SyntaxFactory.MemberAccessExpression(
                                                                            SyntaxKind.SimpleMemberAccessExpression,
                                                                            SyntaxFactory.IdentifierName("webBuilder"),
                                                                            SyntaxFactory.GenericName(
                                                                                SyntaxFactory.Identifier("UseStartup"))
                                                                            .WithTypeArgumentList(
                                                                                SyntaxFactory.TypeArgumentList(
                                                                                    SyntaxFactory.SingletonSeparatedList<TypeSyntax>(
                                                                                        SyntaxFactory.IdentifierName("Startup"))))))))))))))))))),
                SyntaxFactory.ReturnStatement(SyntaxFactory.IdentifierName("builder")));

            return SyntaxFactory.MethodDeclaration(
                    SyntaxFactory.IdentifierName(nameof(IHostBuilder)),
                    SyntaxFactory.Identifier("CreateHostBuilder"))
                .WithModifiers(SyntaxTokenListFactory.PublicStaticKeyword())
                .WithParameterList(
                    SyntaxFactory.ParameterList(
                        SyntaxFactory.SingletonSeparatedList(
                            SyntaxFactory.Parameter(SyntaxFactory.Identifier("args"))
                                .WithType(
                                    SyntaxFactory.ArrayType(
                                            SyntaxFactory.PredefinedType(
                                                SyntaxTokenFactory.StringKeyword()))
                                        .WithRankSpecifiers(
                                            SyntaxFactory.SingletonList(
                                                SyntaxFactory.ArrayRankSpecifier(
                                                    SyntaxFactory.SingletonSeparatedList<ExpressionSyntax>(
                                                        SyntaxFactory.OmittedArraySizeExpression()))))))))
                .WithBody(codeBody);
        }

        private static MemberDeclarationSyntax CreateStartupPropertyPrivateOptions(in bool useRestExtended)
        {
            var optionTypeName = "RestApiOptions";
            if (useRestExtended)
            {
                optionTypeName = "RestApiExtendedOptions";
            }

            return SyntaxFactory.FieldDeclaration(
                    SyntaxFactory.VariableDeclaration(
                            SyntaxFactory.IdentifierName(optionTypeName))
                        .WithVariables(
                            SyntaxFactory.SingletonSeparatedList(
                                SyntaxFactory.VariableDeclarator(
                                    SyntaxFactory.Identifier("restApiOptions")))))
                .WithModifiers(SyntaxTokenListFactory.PrivateReadonlyKeyword());
        }

        private static MemberDeclarationSyntax CreateStartupConstructor(bool useRestExtended)
        {
            var optionTypeName = "RestApiOptions";
            if (useRestExtended)
            {
                optionTypeName = "RestApiExtendedOptions";
            }

            var codeBody = SyntaxFactory.Block(
                SyntaxFactory.ExpressionStatement(
                    SyntaxFactory.AssignmentExpression(
                        SyntaxKind.SimpleAssignmentExpression,
                        SyntaxFactory.IdentifierName("Configuration"),
                        SyntaxFactory.IdentifierName("configuration"))),
                SyntaxFactory.ExpressionStatement(
                    SyntaxFactory.AssignmentExpression(
                        SyntaxKind.SimpleAssignmentExpression,
                        SyntaxFactory.IdentifierName("restApiOptions"),
                        SyntaxFactory.ObjectCreationExpression(
                            SyntaxFactory.IdentifierName(optionTypeName))
                        .WithInitializer(
                            SyntaxFactory.InitializerExpression(
                                SyntaxKind.ObjectInitializerExpression)))),
                SyntaxFactory.ExpressionStatement(
                    SyntaxFactory.InvocationExpression(
                        SyntaxFactory.MemberAccessExpression(
                            SyntaxKind.SimpleMemberAccessExpression,
                            SyntaxFactory.IdentifierName("restApiOptions"),
                            SyntaxFactory.IdentifierName("AddAssemblyPairs")))
                    .WithArgumentList(
                        SyntaxFactory.ArgumentList(
                            SyntaxFactory.SeparatedList<ArgumentSyntax>(
                                new SyntaxNodeOrToken[]
                                {
                                    SyntaxFactory.Argument(
                                        SyntaxFactory.InvocationExpression(
                                            SyntaxFactory.MemberAccessExpression(
                                                SyntaxKind.SimpleMemberAccessExpression,
                                                SyntaxFactory.IdentifierName("Assembly"),
                                                SyntaxFactory.IdentifierName("GetAssembly")))
                                        .WithArgumentList(
                                            SyntaxFactory.ArgumentList(
                                                SyntaxFactory.SingletonSeparatedList(
                                                    SyntaxFactory.Argument(
                                                        SyntaxFactory.TypeOfExpression(
                                                            SyntaxFactory.IdentifierName("ApiRegistration"))))))),
                                    SyntaxFactory.Token(SyntaxKind.CommaToken),
                                    SyntaxFactory.Argument(
                                        SyntaxFactory.InvocationExpression(
                                            SyntaxFactory.MemberAccessExpression(
                                                SyntaxKind.SimpleMemberAccessExpression,
                                                SyntaxFactory.IdentifierName("Assembly"),
                                                SyntaxFactory.IdentifierName("GetAssembly")))
                                        .WithArgumentList(
                                            SyntaxFactory.ArgumentList(
                                                SyntaxFactory.SingletonSeparatedList(
                                                    SyntaxFactory.Argument(
                                                        SyntaxFactory.TypeOfExpression(
                                                            SyntaxFactory.IdentifierName("DomainRegistration")))))))
                                })))));

            return SyntaxFactory.MethodDeclaration(
                    SyntaxFactory.IdentifierName("Startup"),
                    SyntaxFactory.MissingToken(SyntaxKind.IdentifierToken))
                .WithModifiers(SyntaxTokenListFactory.PublicKeyword())
                .WithParameterList(
                    SyntaxFactory.ParameterList(
                        SyntaxFactory.SingletonSeparatedList(
                            SyntaxFactory.Parameter(
                                    SyntaxFactory.Identifier("configuration"))
                                .WithType(
                                    SyntaxFactory.IdentifierName("IConfiguration")))))
                .WithBody(codeBody);
        }

        private static MemberDeclarationSyntax CreateStartupPropertyPublicConfiguration()
        {
            return SyntaxFactory.PropertyDeclaration(
                    SyntaxFactory.IdentifierName("IConfiguration"),
                    SyntaxFactory.Identifier("Configuration"))
                .WithModifiers(
                    SyntaxFactory.TokenList(
                        SyntaxFactory.Token(SyntaxKind.PublicKeyword)))
                .WithAccessorList(
                    SyntaxFactory.AccessorList(
                        SyntaxFactory.SingletonList(
                            SyntaxFactory.AccessorDeclaration(
                                    SyntaxKind.GetAccessorDeclaration)
                                .WithSemicolonToken(
                                    SyntaxTokenFactory.Semicolon()))));
        }

        private static MemberDeclarationSyntax CreateStartupConfigureServices(in bool useRestExtended)
        {
            ArgumentListSyntax argumentList;
            if (useRestExtended)
            {
                argumentList = SyntaxFactory.ArgumentList(
                    SyntaxFactory.SeparatedList<ArgumentSyntax>(
                        new SyntaxNodeOrToken[]
                        {
                            SyntaxFactory.Argument(SyntaxFactory.IdentifierName("restApiOptions")),
                            SyntaxTokenFactory.Comma(),
                            SyntaxFactory.Argument(SyntaxFactory.IdentifierName("Configuration"))
                        }));
            }
            else
            {
                argumentList = SyntaxFactory.ArgumentList(
                    SyntaxFactory.SingletonSeparatedList(
                        SyntaxFactory.Argument(
                            SyntaxFactory.IdentifierName("restApiOptions"))));
            }

            return SyntaxFactory.MethodDeclaration(
                SyntaxFactory.PredefinedType(SyntaxFactory.Token(SyntaxKind.VoidKeyword)),
                SyntaxFactory.Identifier("ConfigureServices"))
            .WithModifiers(
                SyntaxFactory.TokenList(SyntaxTokenFactory.PublicKeyword()))
            .WithParameterList(
                SyntaxFactory.ParameterList(
                    SyntaxFactory.SingletonSeparatedList(
                        SyntaxFactory.Parameter(SyntaxFactory.Identifier("services"))
                            .WithType(SyntaxFactory.IdentifierName("IServiceCollection")))))
            .WithBody(
                SyntaxFactory.Block(
                    SyntaxFactory.SingletonList<StatementSyntax>(
                        SyntaxFactory.ExpressionStatement(
                            SyntaxFactory.InvocationExpression(
                                SyntaxFactory.MemberAccessExpression(
                                    SyntaxKind.SimpleMemberAccessExpression,
                                    SyntaxFactory.IdentifierName("services"),
                                    SyntaxFactory.GenericName(SyntaxFactory.Identifier("AddRestApi"))
                                        .WithTypeArgumentList(
                                            SyntaxFactory.TypeArgumentList(
                                                SyntaxFactory.SingletonSeparatedList<TypeSyntax>(
                                                    SyntaxFactory.IdentifierName("Startup"))))))
                                .WithArgumentList(argumentList)))));
        }

        private static MemberDeclarationSyntax CreateStartupConfigure()
        {
            return SyntaxFactory.MethodDeclaration(
                SyntaxFactory.PredefinedType(SyntaxFactory.Token(SyntaxKind.VoidKeyword)),
                SyntaxFactory.Identifier("Configure"))
            .WithModifiers(SyntaxTokenList.Create(SyntaxTokenFactory.PublicKeyword()))
            .WithParameterList(
                SyntaxFactory.ParameterList(
                    SyntaxFactory.SeparatedList<ParameterSyntax>(
                        new SyntaxNodeOrToken[]
                        {
                            SyntaxFactory.Parameter(SyntaxFactory.Identifier("app"))
                                .WithType(SyntaxFactory.IdentifierName("IApplicationBuilder")),
                            SyntaxFactory.Token(SyntaxKind.CommaToken),
                            SyntaxFactory.Parameter(SyntaxFactory.Identifier("env"))
                                .WithType(SyntaxFactory.IdentifierName("IWebHostEnvironment"))
                        })))
            .WithBody(
                SyntaxFactory.Block(
                    SyntaxFactory.SingletonList<StatementSyntax>(
                        SyntaxFactory.ExpressionStatement(
                            SyntaxFactory.InvocationExpression(
                                SyntaxFactory.MemberAccessExpression(
                                    SyntaxKind.SimpleMemberAccessExpression,
                                    SyntaxFactory.IdentifierName("app"),
                                    SyntaxFactory.IdentifierName("ConfigureRestApi")))
                            .WithArgumentList(
                                SyntaxFactory.ArgumentList(
                                    SyntaxFactory.SeparatedList<ArgumentSyntax>(
                                        new SyntaxNodeOrToken[]
                                        {
                                            SyntaxFactory.Argument(SyntaxFactory.IdentifierName("env")),
                                            SyntaxTokenFactory.Comma(),
                                            SyntaxFactory.Argument(SyntaxFactory.IdentifierName("restApiOptions"))
                                        })))))));
        }
    }
}