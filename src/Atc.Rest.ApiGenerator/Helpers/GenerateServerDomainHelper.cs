using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using Atc.CodeAnalysis.CSharp.SyntaxFactories;
using Atc.Data.Models;
using Atc.Rest.ApiGenerator.Models;
using Atc.Rest.ApiGenerator.ProjectSyntaxFactories;
using Atc.Rest.ApiGenerator.SyntaxGenerators.Domain;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace Atc.Rest.ApiGenerator.Helpers
{
    public static class GenerateServerDomainHelper
    {
        public static LogKeyValueItem ValidateVersioning(DomainProjectOptions domainProjectOptions)
        {
            if (domainProjectOptions == null)
            {
                throw new ArgumentNullException(nameof(domainProjectOptions));
            }

            var apiFile = new FileInfo(Path.Combine(domainProjectOptions.ApiProjectSrcPath.FullName, "ApiRegistration.cs"));
            if (!File.Exists(apiFile.FullName))
            {
                return LogItemHelper.Create(LogCategoryType.Error, ValidationRuleNameConstants.ProjectDomainGenerated01, $"Can't find API project in folder '{domainProjectOptions.ApiProjectSrcPath.FullName}'");
            }

            if (!Directory.Exists(domainProjectOptions.PathForSrcGenerate.FullName))
            {
                return LogItemHelper.Create(LogCategoryType.Information, ValidationRuleNameConstants.ProjectDomainGenerated02, "Old project don't exist.");
            }

            var domainRegistrationFile =
                Path.Combine(domainProjectOptions.PathForSrcGenerate.FullName, "DomainRegistration.cs");
            if (!File.Exists(domainRegistrationFile))
            {
                return LogItemHelper.Create(LogCategoryType.Information, ValidationRuleNameConstants.ProjectDomainGenerated03, "Old DomainRegistration.cs in project don't exist.");
            }

            var lines = File.ReadLines(domainRegistrationFile).ToList();

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
                    return LogItemHelper.Create(LogCategoryType.Error, ValidationRuleNameConstants.ProjectDomainGenerated04, "Existing project version is invalid.");
                }

                if (newVersion >= oldVersionResult)
                {
                    return LogItemHelper.Create(LogCategoryType.Information, ValidationRuleNameConstants.ProjectDomainGenerated05, "The generate project version is the same or newer.");
                }

                return LogItemHelper.Create(LogCategoryType.Error, ValidationRuleNameConstants.ProjectDomainGenerated06, "Existing project version is never than this tool version.");
            }

            return LogItemHelper.Create(LogCategoryType.Error, ValidationRuleNameConstants.ProjectDomainGenerated07, "Existing project did not contain a version.");
        }

        public static void Scaffold(DomainProjectOptions domainProjectOptions)
        {
            if (domainProjectOptions == null)
            {
                throw new ArgumentNullException(nameof(domainProjectOptions));
            }

            if (!Directory.Exists(domainProjectOptions.PathForSrcGenerate.FullName))
            {
                Directory.CreateDirectory(domainProjectOptions.PathForSrcGenerate.FullName);
            }

            var file = new FileInfo(Path.Combine(domainProjectOptions.PathForSrcGenerate.FullName, $"{domainProjectOptions.ProjectName}.csproj"));
            if (domainProjectOptions.PathForSrcGenerate.Exists && file.Exists)
            {
                var element = XElement.Load(file.FullName);
                var originalNullableValue = GenerateHelper.GetBoolFromNullableString(GenerateHelper.GetNullableValueFromProject(element));

                if (domainProjectOptions.ApiOptions.Generator.UseNullableReferenceTypes != originalNullableValue)
                {
                    var newNullableValue = GenerateHelper.GetNullableStringFromBool(domainProjectOptions.ApiOptions.Generator.UseNullableReferenceTypes);
                    GenerateHelper.SetNullableValueForProject(element, newNullableValue);
                    element.Save(file.FullName);
                }
            }
            else
            {
                GenerateHelper.ScaffoldProjFile(
                    domainProjectOptions.PathForSrcGenerate,
                    domainProjectOptions.ProjectName,
                    domainProjectOptions.ApiOptions.Generator.UseNullableReferenceTypes,
                    false);
            }

            ScaffoldBasicFileDomainRegistration(domainProjectOptions);
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
            FileHelper.Save(file, codeAsString);
        }

        public static List<LogKeyValueItem> GenerateHandlers(DomainProjectOptions domainProjectOptions, List<ApiOperationSchemaMap> operationSchemaMappings)
        {
            if (domainProjectOptions == null)
            {
                throw new ArgumentNullException(nameof(domainProjectOptions));
            }

            if (operationSchemaMappings == null)
            {
                throw new ArgumentNullException(nameof(operationSchemaMappings));
            }

            var logItems = new List<LogKeyValueItem>();
            var sgHandlers = new List<SyntaxGeneratorHandler>();
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
    }
}