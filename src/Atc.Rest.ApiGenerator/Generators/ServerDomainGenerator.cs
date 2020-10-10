using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Atc.CodeAnalysis.CSharp;
using Atc.CodeAnalysis.CSharp.SyntaxFactories;
using Atc.Data.Models;
using Atc.Rest.ApiGenerator.Helpers;
using Atc.Rest.ApiGenerator.Models;
using Atc.Rest.ApiGenerator.ProjectSyntaxFactories;
using Atc.Rest.ApiGenerator.SyntaxGenerators.Domain;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

// ReSharper disable InvertIf
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

            if (domainProjectOptions.PathForTestGenerate == null || domainProjectOptions.ProjectTestCsProj == null)
            {
                return logItems;
            }

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
                    projectReferences.Add(domainProjectOptions.ProjectSrcCsProj);
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
                    var pathGenerated = Path.Combine(Path.Combine(domainProjectOptions.PathForTestHandlers.FullName, area), "Generated");
                    var pathCustom = Path.Combine(domainProjectOptions.PathForTestHandlers.FullName, area);

                    if (!Directory.Exists(pathGenerated))
                    {
                        Directory.CreateDirectory(pathGenerated);
                    }

                    if (!Directory.Exists(pathCustom))
                    {
                        Directory.CreateDirectory(pathCustom);
                    }

                    var nsSrc = $"{domainProjectOptions.ProjectName}.{NameConstants.Handlers}.{area}";
                    var nsTest = $"{domainProjectOptions.ProjectName}.Api.Generated.{NameConstants.Handlers}";

                    var codeForGenerated = CreateGeneratedTestFile(domainProjectOptions, sgHandler, nsSrc, nsTest);
                    var fileGenerated = new FileInfo(Path.Combine(pathGenerated, $"{sgHandler.HandlerTypeName}GeneratedTests.cs"));
                    logItems.Add(TextFileHelper.Save(fileGenerated, codeForGenerated));

                    var codeForCustom = CreateCustomTestFile(sgHandler, nsSrc, nsTest);
                    var fileCustom = new FileInfo(Path.Combine(pathCustom, $"{sgHandler.HandlerTypeName}Tests.cs"));
                    logItems.Add(TextFileHelper.Save(fileCustom, codeForCustom, false));
                }
            }

            return logItems;
        }

        private static string CreateGeneratedTestFile(
            DomainProjectOptions domainProjectOptions,
            SyntaxGeneratorHandler sgHandler,
            string nsSrc,
            string nsTest)
        {
            var srcSyntaxNodeRoot = ReadCsFile(domainProjectOptions, sgHandler.FocusOnSegmentName, sgHandler);
            var usedInterfacesInConstructor = GetUsedInterfacesInConstructor(srcSyntaxNodeRoot);

            var usingStatements = GetUsedUsingStatements(
                srcSyntaxNodeRoot,
                nsSrc,
                usedInterfacesInConstructor.Count > 0);

            var sb = new StringBuilder();
            foreach (var item in usingStatements)
            {
                sb.AppendLine($"using {item};");
            }

            sb.AppendLine();
            sb.AppendLine("//------------------------------------------------------------------------------");
            sb.AppendLine($"// This code was auto-generated by {domainProjectOptions.ToolNameAndVersion}.");
            sb.AppendLine("//");
            sb.AppendLine("// Changes to this file may cause incorrect behavior and will be lost if");
            sb.AppendLine("// the code is regenerated.");
            sb.AppendLine("//------------------------------------------------------------------------------");
            sb.AppendLine("//");
            sb.AppendLine("// ReSharper disable once CheckNamespace");
            sb.AppendLine($"namespace {nsTest}.Tests");
            sb.AppendLine("{");
            sb.AppendLine($"    [GeneratedCode(\"{domainProjectOptions.ToolName}\", \"{domainProjectOptions.ToolVersion}\")]");
            sb.AppendLine($"    public class {sgHandler.HandlerTypeName}GeneratedTests");
            sb.AppendLine("    {");
            AppendInstantiateConstructor(sb, sgHandler, usedInterfacesInConstructor);
            if (sgHandler.HasParametersOrRequestBody)
            {
                sb.AppendLine();
                AppendParameterArgumentNullCheck(sb, sgHandler, usedInterfacesInConstructor);
            }

            sb.AppendLine("    }");
            sb.AppendLine("}");
            return sb.ToString();
        }

        private static void AppendInstantiateConstructor(
            StringBuilder sb,
            SyntaxGeneratorHandler sgHandler,
            List<Tuple<string, string>> usedInterfacesInConstructor)
        {
            sb.AppendLine("        [Fact]");
            sb.AppendLine("        public void InstantiateConstructor()");
            sb.AppendLine("        {");
            if (usedInterfacesInConstructor.Count > 0)
            {
                sb.AppendLine("            // Arrange");
                foreach (var item in usedInterfacesInConstructor)
                {
                    sb.AppendLine($"            var {item.Item2} = Substitute.For<{item.Item1}>();");
                }

                sb.AppendLine();
            }

            sb.AppendLine("            // Act");
            if (usedInterfacesInConstructor.Count > 0)
            {
                var parameters = string.Join(',', usedInterfacesInConstructor.Select(x => x.Item2));
                sb.AppendLine($"            var actual = new {sgHandler.HandlerTypeName}({parameters});");
            }
            else
            {
                sb.AppendLine($"            var actual = new {sgHandler.HandlerTypeName}();");
            }

            sb.AppendLine();
            sb.AppendLine("            // Assert");
            sb.AppendLine("            Assert.NotNull(actual);");
            sb.AppendLine("        }");
        }

        private static void AppendParameterArgumentNullCheck(
            StringBuilder sb,
            SyntaxGeneratorHandler sgHandler,
            List<Tuple<string, string>> usedInterfacesInConstructor)
        {
            sb.AppendLine("        [Fact]");
            sb.AppendLine("        public void ParameterArgumentNullCheck()");
            sb.AppendLine("        {");
            sb.AppendLine("            // Arrange");
            if (usedInterfacesInConstructor.Count > 0)
            {
                foreach (var item in usedInterfacesInConstructor)
                {
                    sb.AppendLine($"            var {item.Item2} = Substitute.For<{item.Item1}>();");
                }

                sb.AppendLine();

                var parameters = string.Join(',', usedInterfacesInConstructor.Select(x => x.Item2));
                sb.AppendLine($"            var sut = new {sgHandler.HandlerTypeName}({parameters});");
            }
            else
            {
                sb.AppendLine($"            var sut = new {sgHandler.HandlerTypeName}();");
            }

            sb.AppendLine();
            sb.AppendLine("            // Act & Assert");
            sb.AppendLine("            Assert.ThrowsAsync<ArgumentException>(() => sut.ExecuteAsync(null!));");
            sb.AppendLine("        }");
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
            sb.AppendLine($"    public class {sgHandler.HandlerTypeName}Tests");
            sb.AppendLine("    {");
            sb.AppendLine("        [Fact(Skip=\"Change this to a real test\")]");
            sb.AppendLine("        public void Sample()");
            sb.AppendLine("        {");
            sb.AppendLine("            // Arrange");
            sb.AppendLine();
            sb.AppendLine("            // Act");
            sb.AppendLine();
            sb.AppendLine("            // Assert");
            sb.AppendLine();
            sb.AppendLine("        }");
            sb.AppendLine("    }");
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
            var classDeclaration = SyntaxClassDeclarationFactory.Create("DomainRegistration")
                .AddGeneratedCodeAttribute(domainProjectOptions.ToolName, domainProjectOptions.ToolVersion.ToString());

            // Add class to namespace
            @namespace = @namespace.AddMembers(classDeclaration);

            // Add using statement to compilationUnit
            compilationUnit = compilationUnit.AddUsingStatements(new[] { "System.CodeDom.Compiler" });

            // Add namespace to compilationUnit
            compilationUnit = compilationUnit.AddMembers(@namespace);

            var codeAsString = compilationUnit
                .NormalizeWhitespace()
                .ToFullString();

            var file = new FileInfo(Path.Combine(domainProjectOptions.PathForSrcGenerate.FullName, "DomainRegistration.cs"));
            TextFileHelper.Save(file, codeAsString);
        }

        private static SyntaxNode ReadCsFile(DomainProjectOptions domainProjectOptions, string area, SyntaxGeneratorHandler sgHandler)
        {
            var csSrcFile = Util.GetCsFileNameForHandler(domainProjectOptions.PathForSrcHandlers!, area, sgHandler.HandlerTypeName);
            var csSrcCode = File.ReadAllText(csSrcFile);
            var tree = CSharpSyntaxTree.ParseText(csSrcCode);
            return tree.GetRoot();
        }

        private static List<string> GetUsedUsingStatements(SyntaxNode root, string nsSrc, bool useExtra)
        {
            var list = new List<string>
            {
                nsSrc,
                "System",
                "System.CodeDom.Compiler",
                "Xunit"
            };

            if (useExtra)
            {
                list.Add("NSubstitute");

                var usingDirective = GetUsedUsingStatements(root);
                foreach (var item in usingDirective)
                {
                    if (item.StartsWith("System", StringComparison.Ordinal))
                    {
                        continue;
                    }

                    list.Add(item);
                }
            }

            return list
                .OrderBy(x => x)
                .ToList();
        }

        private static List<string> GetUsedUsingStatements(SyntaxNode root)
        {
            return root
                .DescendantNodes()
                .OfType<UsingDirectiveSyntax>()
                .Select(x => x.Name.ToFullString())
                .ToList();
        }

        private static List<Tuple<string, string>> GetUsedInterfacesInConstructor(SyntaxNode root)
        {
            var constructorDeclarations = root
                .DescendantNodes()
                .OfType<ConstructorDeclarationSyntax>()
                .ToArray();

            if (constructorDeclarations.Length > 0)
            {
                var parameterListSyntax = constructorDeclarations
                    .First()
                    .ParameterList;

                var interfaceNames = parameterListSyntax
                    .DescendantNodes()
                    .OfType<IdentifierNameSyntax>()
                    .Select(x => x.Identifier.Text)
                    .ToArray();

                var interfaceGenericNames = parameterListSyntax
                    .DescendantNodes()
                    .OfType<GenericNameSyntax>()
                    .Select(x => x.GetText().ToString().Trim())
                    .ToArray();

                var names = parameterListSyntax
                    .DescendantNodes()
                    .OfType<ParameterSyntax>()
                    .Select(x => x.Identifier.Text)
                    .ToArray();

                if (interfaceNames.Length > 0 && interfaceNames.Length == names.Length)
                {
                    if (interfaceGenericNames.Length == 0)
                    {
                        return interfaceNames
                            .Select((t, i) => new Tuple<string, string>(t, names[i]))
                            .ToList();
                    }

                    var list = new List<Tuple<string, string>>();
                    for (int i = 0; i < interfaceNames.Length; i++)
                    {
                        var interfaceGenericName = interfaceGenericNames.FirstOrDefault(x => x.Contains($"<{interfaceNames[i]}>", StringComparison.Ordinal));
                        list.Add(string.IsNullOrEmpty(interfaceGenericName)
                            ? new Tuple<string, string>(interfaceNames[i], names[i])
                            : new Tuple<string, string>(interfaceGenericName, names[i]));
                    }

                    return list;
                }
            }

            return new List<Tuple<string, string>>();
        }
    }
}