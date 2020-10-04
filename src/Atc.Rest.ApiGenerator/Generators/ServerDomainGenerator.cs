using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Atc.CodeAnalysis.CSharp.SyntaxFactories;
using Atc.Data.Models;
using Atc.Rest.ApiGenerator.Helpers;
using Atc.Rest.ApiGenerator.Models;
using Atc.Rest.ApiGenerator.ProjectSyntaxFactories;
using Atc.Rest.ApiGenerator.SyntaxGenerators.Domain;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

// ReSharper disable SuggestBaseTypeForParameter
// ReSharper disable ReturnTypeCanBeEnumerable.Local
namespace Atc.Rest.ApiGenerator.Generators
{
    public class ServerDomainGenerator
    {
        private readonly DomainProjectOptions projectOptions;

        public ServerDomainGenerator(DomainProjectOptions projectOptions)
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

            logItems.AddRange(GenerateSrcHandlers(projectOptions, out List<SyntaxGeneratorHandler> sgHandlers));
            if (projectOptions.PathForTestGenerate != null)
            {
                logItems.AddRange(GenerateTestHandlers(projectOptions, sgHandlers));
            }

            return logItems;
        }

        private static List<LogKeyValueItem> ScaffoldSrc(DomainProjectOptions domainProjectOptions)
        {
            if (domainProjectOptions == null)
            {
                throw new ArgumentNullException(nameof(domainProjectOptions));
            }

            if (!Directory.Exists(domainProjectOptions.PathForSrcGenerate.FullName))
            {
                Directory.CreateDirectory(domainProjectOptions.PathForSrcGenerate.FullName);
            }

            var logItems = new List<LogKeyValueItem>();

            if (domainProjectOptions.PathForSrcGenerate.Exists && domainProjectOptions.ProjectSrcCsProj.Exists)
            {
                var element = XElement.Load(domainProjectOptions.ProjectSrcCsProj.FullName);
                var originalNullableValue = SolutionAndProjectHelper.GetBoolFromNullableString(SolutionAndProjectHelper.GetNullableValueFromProject(element));

                bool hasUpdates = false;
                if (domainProjectOptions.ApiOptions.Generator.UseNullableReferenceTypes != originalNullableValue)
                {
                    var newNullableValue = SolutionAndProjectHelper.GetNullableStringFromBool(domainProjectOptions.ApiOptions.Generator.UseNullableReferenceTypes);
                    SolutionAndProjectHelper.SetNullableValueForProject(element, newNullableValue);
                    element.Save(domainProjectOptions.ProjectSrcCsProj.FullName);
                    logItems.Add(new LogKeyValueItem(LogCategoryType.Debug, "FileUpdate", "#", $"Update domain csproj - Nullable value={newNullableValue}"));
                    hasUpdates = true;
                }

                if (!hasUpdates)
                {
                    logItems.Add(new LogKeyValueItem(LogCategoryType.Debug, "FileSkip", "#", "No updates for domain csproj"));
                }
            }
            else
            {
                var projectReferences = new List<FileInfo>();
                if (domainProjectOptions.ApiProjectSrcCsProj != null)
                {
                    projectReferences.Add(domainProjectOptions.ApiProjectSrcCsProj);
                }

                logItems.Add(SolutionAndProjectHelper.ScaffoldProjFile(
                    domainProjectOptions.ProjectSrcCsProj,
                    false,
                    false,
                    domainProjectOptions.ProjectName,
                    domainProjectOptions.ApiOptions.Generator.UseNullableReferenceTypes,
                    new List<string> { "Microsoft.AspNetCore.App" },
                    null,
                    projectReferences,
                    false));
            }

            ScaffoldBasicFileDomainRegistration(domainProjectOptions);

            return logItems;
        }

        private static List<LogKeyValueItem> ScaffoldTest(DomainProjectOptions domainProjectOptions)
        {
            if (domainProjectOptions == null)
            {
                throw new ArgumentNullException(nameof(domainProjectOptions));
            }

            var logItems = new List<LogKeyValueItem>();

            if (domainProjectOptions.PathForTestGenerate != null && domainProjectOptions.ProjectTestCsProj != null)
            {
                if (domainProjectOptions.PathForTestGenerate.Exists && domainProjectOptions.ProjectTestCsProj.Exists)
                {
                    // Update
                }
                else
                {
                    if (!Directory.Exists(domainProjectOptions.PathForTestGenerate.FullName))
                    {
                        Directory.CreateDirectory(domainProjectOptions.PathForTestGenerate.FullName);
                    }

                    var projectReferences = new List<FileInfo>();
                    if (domainProjectOptions.ApiProjectSrcCsProj != null)
                    {
                        projectReferences.Add(domainProjectOptions.ApiProjectSrcCsProj);
                    }

                    logItems.Add(SolutionAndProjectHelper.ScaffoldProjFile(
                        domainProjectOptions.ProjectTestCsProj,
                        false,
                        true,
                        $"{domainProjectOptions.ProjectName}.Tests",
                        domainProjectOptions.ApiOptions.Generator.UseNullableReferenceTypes,
                        null,
                        NugetPackageReferenceHelper.CreateForTestProject(),
                        projectReferences,
                        true));
                }
            }

            return logItems;
        }

        private static List<LogKeyValueItem> GenerateSrcHandlers(DomainProjectOptions domainProjectOptions, out List<SyntaxGeneratorHandler> sgHandlers)
        {
            if (domainProjectOptions == null)
            {
                throw new ArgumentNullException(nameof(domainProjectOptions));
            }

            var logItems = new List<LogKeyValueItem>();
            sgHandlers = new List<SyntaxGeneratorHandler>();
            foreach (var basePathSegmentName in domainProjectOptions.BasePathSegmentNames)
            {
                var generatorHandlers = new SyntaxGeneratorHandlers(domainProjectOptions, basePathSegmentName);
                var generatedHandlers = generatorHandlers.GenerateSyntaxTrees();
                sgHandlers.AddRange(generatedHandlers);
            }

            foreach (var sg in sgHandlers)
            {
                logItems.Add(sg.ToFile());
            }

            return logItems;
        }

        private static List<LogKeyValueItem> GenerateTestHandlers(DomainProjectOptions domainProjectOptions, List<SyntaxGeneratorHandler> sgHandlers)
        {
            if (domainProjectOptions == null)
            {
                throw new ArgumentNullException(nameof(domainProjectOptions));
            }

            if (sgHandlers == null)
            {
                throw new ArgumentNullException(nameof(sgHandlers));
            }

            var logItems = new List<LogKeyValueItem>();

            if (domainProjectOptions.PathForTestHandlers != null)
            {
                foreach (var sgHandler in sgHandlers)
                {
                    var area = sgHandler.FocusOnSegmentName.EnsureFirstCharacterToUpper();
                    var path = Path.Combine(domainProjectOptions.PathForTestHandlers.FullName, area);
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    var nsSrc = $"{domainProjectOptions.ProjectName}.{NameConstants.Handlers}.{area}";
                    var nsTest = $"{domainProjectOptions.ProjectName}.Api.Generated.{NameConstants.Handlers}";

                    var codeForAuto = CreateAutoTestFile(domainProjectOptions, sgHandler, nsSrc, nsTest);
                    var fileAuto = new FileInfo(Path.Combine(path, $"{sgHandler.HandlerTypeName}Tests.cs"));
                    logItems.Add(TextFileHelper.Save(fileAuto, codeForAuto));

                    var codeForCustom = CreateCustomTestFile(sgHandler, nsSrc, nsTest);
                    var fileCustom = new FileInfo(Path.Combine(path, $"{sgHandler.HandlerTypeName}CustomTests.cs"));
                    logItems.Add(TextFileHelper.Save(fileCustom, codeForCustom, false));
                }
            }

            return logItems;
        }

        private static string CreateAutoTestFile(
            DomainProjectOptions domainProjectOptions,
            SyntaxGeneratorHandler sgHandler,
            string nsSrc,
            string nsTest)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"using {nsSrc};");
            sb.AppendLine("using Xunit;");
            sb.AppendLine();
            sb.AppendLine("//------------------------------------------------------------------------------");
            sb.AppendLine($"// This code was auto-generated by {domainProjectOptions.ToolNameAndProjectVersion}.");
            sb.AppendLine("//");
            sb.AppendLine("// Changes to this file may cause incorrect behavior and will be lost if");
            sb.AppendLine("// the code is regenerated.");
            sb.AppendLine("//------------------------------------------------------------------------------");
            sb.AppendLine("//");
            sb.AppendLine("// ReSharper disable once CheckNamespace");
            sb.AppendLine($"namespace {nsTest}.Tests");
            sb.AppendLine("{");
            sb.AppendLine($"\tpublic partial class {sgHandler.HandlerTypeName}Tests");
            sb.AppendLine("\t{");
            sb.AppendLine("\t\t[Fact]");
            sb.AppendLine("\t\tpublic void InstantiateConstructor()");
            sb.AppendLine("\t\t{");
            sb.AppendLine("\t\t\t// Act");
            sb.AppendLine($"\t\t\tvar actual = new {sgHandler.HandlerTypeName}();");
            sb.AppendLine();
            sb.AppendLine("\t\t\t// Assert");
            sb.AppendLine("\t\t\tAssert.NotNull(actual);");
            sb.AppendLine("\t\t}");
            sb.AppendLine("\t}");
            sb.AppendLine("}");
            return sb.ToString();
        }

        private static string CreateCustomTestFile(
            SyntaxGeneratorHandler sgHandler,
            string nsSrc,
            string nsTest)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"using {nsSrc};");
            sb.AppendLine("using Xunit;");
            sb.AppendLine();
            sb.AppendLine("// ReSharper disable once CheckNamespace");
            sb.AppendLine($"namespace {nsTest}.Tests");
            sb.AppendLine("{");
            sb.AppendLine($"\tpublic partial class {sgHandler.HandlerTypeName}Tests");
            sb.AppendLine("\t{");
            sb.AppendLine("\t\t[Fact(Skip=\"Change this to a real test\")]");
            sb.AppendLine("\t\tpublic void Sample()");
            sb.AppendLine("\t\t{");
            sb.AppendLine("\t\t\t// Arrange");
            sb.AppendLine();
            sb.AppendLine("\t\t\t// Act");
            sb.AppendLine();
            sb.AppendLine("\t\t\t// Assert");
            sb.AppendLine();
            sb.AppendLine("\t\t}");
            sb.AppendLine("\t}");
            sb.AppendLine("}");
            return sb.ToString();
        }

        private static void ScaffoldBasicFileDomainRegistration(DomainProjectOptions domainProjectOptions)
        {
            // Create compilationUnit
            var compilationUnit = SyntaxFactory.CompilationUnit();

            // Create a namespace
            var @namespace = SyntaxProjectFactory.CreateNamespace(domainProjectOptions);

            // Create class
            var classDeclaration = SyntaxClassDeclarationFactory.Create("DomainRegistration");

            // Add class to namespace
            @namespace = @namespace.AddMembers(classDeclaration);

            // Add namespace to compilationUnit
            compilationUnit = compilationUnit.AddMembers(@namespace);

            var codeAsString = compilationUnit
                .NormalizeWhitespace()
                .ToFullString();

            var file = new FileInfo(Path.Combine(domainProjectOptions.PathForSrcGenerate.FullName, "DomainRegistration.cs"));
            TextFileHelper.Save(file, codeAsString);
        }
    }
}