using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Atc.Data.Models;

// ReSharper disable SuggestBaseTypeForParameter
namespace Atc.Rest.ApiGenerator.Helpers
{
    public static class SolutionAndProjectHelper
    {
        public static LogKeyValueItem ScaffoldProjFile(
            FileInfo projectCsProjFile,
            bool createAsWeb,
            bool createAsTestProject,
            string projectName,
            bool useNullableReferenceTypes,
            List<string>? frameworkReferences,
            List<Tuple<string, string>>? packageReferences,
            List<FileInfo>? projectReferences,
            bool includeApiSpecification)
        {
            if (projectCsProjFile == null)
            {
                throw new ArgumentNullException(nameof(projectCsProjFile));
            }

            var sb = new StringBuilder();
            sb.AppendLine(createAsWeb
                ? "<Project Sdk=\"Microsoft.NET.Sdk.Web\">"
                : "<Project Sdk=\"Microsoft.NET.Sdk\">");
            sb.AppendLine();
            sb.AppendLine(" <PropertyGroup>");
            sb.AppendLine("     <TargetFramework>netcoreapp3.1</TargetFramework>");
            if (!createAsTestProject)
            {
                sb.AppendLine("     <IsPackable>false</IsPackable>");
            }

            sb.AppendLine(" </PropertyGroup>");
            sb.AppendLine();
            if (!createAsTestProject)
            {
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
                sb.AppendLine($"     <DocumentationFile>bin\\Debug\\netcoreapp3.1\\{projectName}.xml</DocumentationFile>");
                sb.AppendLine("     <NoWarn>1573;1591;1701;1702;1712;8618</NoWarn>");
                sb.AppendLine(" </PropertyGroup>");
                sb.AppendLine();

                if (includeApiSpecification)
                {
                    sb.AppendLine(" <ItemGroup>");
                    sb.AppendLine("     <None Remove=\"Resources\\ApiSpecification.yaml\" />");
                    sb.AppendLine("     <EmbeddedResource Include=\"Resources\\ApiSpecification.yaml\" />");
                    sb.AppendLine(" </ItemGroup>");
                    sb.AppendLine();
                }
            }

            if (frameworkReferences != null && frameworkReferences.Count > 0)
            {
                sb.AppendLine(" <ItemGroup>");
                foreach (var frameworkReference in frameworkReferences.OrderBy(x => x))
                {
                    sb.AppendLine($"     <FrameworkReference Include=\"{frameworkReference}\" />");
                }

                sb.AppendLine(" </ItemGroup>");
                sb.AppendLine();
            }

            if (packageReferences != null && packageReferences.Count > 0)
            {
                sb.AppendLine(" <ItemGroup>");
                foreach (var (package, version) in packageReferences.OrderBy(x => x.Item1))
                {
                    sb.AppendLine($"     <PackageReference Include=\"{package}\" Version=\"{version}\" />");
                }

                sb.AppendLine(" </ItemGroup>");
                sb.AppendLine();
            }

            if (projectReferences != null && projectReferences.Count > 0)
            {
                sb.AppendLine(" <ItemGroup>");
                foreach (var projectReference in projectReferences.OrderBy(x => x.Name))
                {
                    var packageReferenceValue = GetProjectReference(projectCsProjFile, projectReference);
                    sb.AppendLine($"     <ProjectReference Include=\"{packageReferenceValue}\" />");
                }

                sb.AppendLine(" </ItemGroup>");
                sb.AppendLine();
            }

            sb.AppendLine("</Project>");
            return TextFileHelper.Save(projectCsProjFile, sb.ToString());
        }

        public static LogKeyValueItem ScaffoldSlnFile(
            FileInfo slnFile,
            string projectName,
            DirectoryInfo apiPath,
            DirectoryInfo domainPath,
            DirectoryInfo hostPath,
            DirectoryInfo? apiTestPath = null,
            DirectoryInfo? domainTestPath = null,
            DirectoryInfo? hostTestPath = null)
        {
            if (slnFile == null)
            {
                throw new ArgumentNullException(nameof(slnFile));
            }

            if (apiPath == null)
            {
                throw new ArgumentNullException(nameof(apiPath));
            }

            if (domainPath == null)
            {
                throw new ArgumentNullException(nameof(domainPath));
            }

            if (hostPath == null)
            {
                throw new ArgumentNullException(nameof(hostPath));
            }

            var slnId = Guid.NewGuid().ToString();
            var apiId = Guid.NewGuid().ToString();
            var domainId = Guid.NewGuid().ToString();
            var hostId = Guid.NewGuid().ToString();
            var apiTestId = Guid.NewGuid().ToString();
            var domainTestId = Guid.NewGuid().ToString();
            var hostTestId = Guid.NewGuid().ToString();

            var apiPrefixPath = GetProjectReference(slnFile, apiPath, projectName);
            var domainPrefixPath = GetProjectReference(slnFile, domainPath, projectName);
            var hostPrefixPath = GetProjectReference(slnFile, hostPath, projectName);

            var sb = new StringBuilder();
            sb.AppendLine();
            sb.AppendLine("Microsoft Visual Studio Solution File, Format Version 12.00");
            sb.AppendLine("# Visual Studio Version 16");
            sb.AppendLine("VisualStudioVersion = 16.0.30523.141");
            sb.AppendLine("MinimumVisualStudioVersion = 10.0.40219.1");
            sb.AppendLine($"Project(\"{{9A19103F-16F7-4668-BE54-9A1E7A4F7556}}\") = \"{projectName}.Api.Generated\", \"{apiPrefixPath}{projectName}.Api.Generated\\{projectName}.Api.Generated.csproj\", \"{{{apiId}}}\"");
            sb.AppendLine("EndProject");
            sb.AppendLine($"Project(\"{{9A19103F-16F7-4668-BE54-9A1E7A4F7556}}\") = \"{projectName}.Domain\", \"{domainPrefixPath}{projectName}.Domain\\{projectName}.Domain.csproj\", \"{{{domainId}}}\"");
            sb.AppendLine("EndProject");
            sb.AppendLine($"Project(\"{{9A19103F-16F7-4668-BE54-9A1E7A4F7556}}\") = \"{projectName}.Api\", \"{hostPrefixPath}{projectName}.Api\\{projectName}.Api.csproj\", \"{{{hostId}}}\"");
            sb.AppendLine("EndProject");
            if (apiTestPath != null)
            {
                var apiTestPrefixPath = GetProjectReference(slnFile, apiTestPath, projectName);
                sb.AppendLine($"Project(\"{{9A19103F-16F7-4668-BE54-9A1E7A4F7556}}\") = \"{projectName}.Api.Generated.Tests\", \"{apiTestPrefixPath}{projectName}.Api.Generated.Tests\\{projectName}.Api.Generated.Tests.csproj\", \"{{{hostTestId}}}\"");
                sb.AppendLine("EndProject");
            }

            if (domainTestPath != null)
            {
                var domainTestPrefixPath = GetProjectReference(slnFile, domainTestPath, projectName);
                sb.AppendLine($"Project(\"{{9A19103F-16F7-4668-BE54-9A1E7A4F7556}}\") = \"{projectName}.Domain.Tests\", \"{domainTestPrefixPath}{projectName}.Domain.Tests\\{projectName}.Domain.Tests.csproj\", \"{{{hostTestId}}}\"");
                sb.AppendLine("EndProject");
            }

            if (hostTestPath != null)
            {
                var hostTestPrefixPath = GetProjectReference(slnFile, hostTestPath, projectName);
                sb.AppendLine($"Project(\"{{9A19103F-16F7-4668-BE54-9A1E7A4F7556}}\") = \"{projectName}.Api.Tests\", \"{hostTestPrefixPath}{projectName}.Api.Tests\\{projectName}.Api.Tests.csproj\", \"{{{hostTestId}}}\"");
                sb.AppendLine("EndProject");
            }

            sb.AppendLine("Global");
            sb.AppendLine("\tGlobalSection(SolutionConfigurationPlatforms) = preSolution");
            sb.AppendLine("\t\tDebug|Any CPU = Debug|Any CPU");
            sb.AppendLine("\t\tRelease|Any CPU = Release|Any CPU");
            sb.AppendLine("\tEndGlobalSection");
            sb.AppendLine("\tGlobalSection(ProjectConfigurationPlatforms) = postSolution");
            sb.AppendLine($"\t\t{{{apiId}}}.Debug | Any CPU.ActiveCfg = Debug | Any CPU");
            sb.AppendLine($"\t\t{{{apiId}}}.Debug | Any CPU.Build.0 = Debug | Any CPU");
            sb.AppendLine($"\t\t{{{apiId}}}.Release | Any CPU.ActiveCfg = Release | Any CPU");
            sb.AppendLine($"\t\t{{{apiId}}}.Release | Any CPU.Build.0 = Release | Any CPU");
            sb.AppendLine($"\t\t{{{domainId}}}.Debug | Any CPU.ActiveCfg = Debug | Any CPU");
            sb.AppendLine($"\t\t{{{domainId}}}.Debug | Any CPU.Build.0 = Debug | Any CPU");
            sb.AppendLine($"\t\t{{{domainId}}}.Release | Any CPU.ActiveCfg = Release | Any CPU");
            sb.AppendLine($"\t\t{{{domainId}}}.Release | Any CPU.Build.0 = Release | Any CPU");
            sb.AppendLine($"\t\t{{{hostId}}}.Debug | Any CPU.ActiveCfg = Debug | Any CPU");
            sb.AppendLine($"\t\t{{{hostId}}}.Debug | Any CPU.Build.0 = Debug | Any CPU");
            sb.AppendLine($"\t\t{{{hostId}}}.Release | Any CPU.ActiveCfg = Release | Any CPU");
            sb.AppendLine($"\t\t{{{hostId}}}.Release | Any CPU.Build.0 = Release | Any CPU");
            if (apiTestPath != null)
            {
                sb.AppendLine($"\t\t{{{apiTestId}}}.Debug | Any CPU.ActiveCfg = Debug | Any CPU");
                sb.AppendLine($"\t\t{{{apiTestId}}}.Debug | Any CPU.Build.0 = Debug | Any CPU");
                sb.AppendLine($"\t\t{{{apiTestId}}}.Release | Any CPU.ActiveCfg = Release | Any CPU");
                sb.AppendLine($"\t\t{{{apiTestId}}}.Release | Any CPU.Build.0 = Release | Any CPU");
            }

            if (domainTestPath != null)
            {
                sb.AppendLine($"\t\t{{{domainTestId}}}.Debug | Any CPU.ActiveCfg = Debug | Any CPU");
                sb.AppendLine($"\t\t{{{domainTestId}}}.Debug | Any CPU.Build.0 = Debug | Any CPU");
                sb.AppendLine($"\t\t{{{domainTestId}}}.Release | Any CPU.ActiveCfg = Release | Any CPU");
                sb.AppendLine($"\t\t{{{domainTestId}}}.Release | Any CPU.Build.0 = Release | Any CPU");
            }

            if (hostTestPath != null)
            {
                sb.AppendLine($"\t\t{{{hostTestId}}}.Debug | Any CPU.ActiveCfg = Debug | Any CPU");
                sb.AppendLine($"\t\t{{{hostTestId}}}.Debug | Any CPU.Build.0 = Debug | Any CPU");
                sb.AppendLine($"\t\t{{{hostTestId}}}.Release | Any CPU.ActiveCfg = Release | Any CPU");
                sb.AppendLine($"\t\t{{{hostTestId}}}.Release | Any CPU.Build.0 = Release | Any CPU");
            }

            sb.AppendLine("\tEndGlobalSection");
            sb.AppendLine("\tGlobalSection(SolutionProperties) = preSolution");
            sb.AppendLine("\t\tHideSolutionNode = FALSE");
            sb.AppendLine("\tEndGlobalSection");
            sb.AppendLine("\tGlobalSection(ExtensibilityGlobals) = postSolution");
            sb.AppendLine($"\t\tSolutionGuid = {{{slnId}}}");
            sb.AppendLine("\tEndGlobalSection");
            sb.AppendLine("EndGlobal");
            return TextFileHelper.Save(slnFile, sb.ToString(), false);
        }

        private static string GetProjectReference(FileSystemInfo source, FileSystemInfo destination, string projectName)
        {
            var sa1 = source.FullName.Split('\\');
            var sa2 = destination.FullName.Split('\\');
            int diffIndex = sa1.Where((t, i) => i < sa2.Length && t == sa2[i]).Count();

            int goForward = 0;
            for (int i = diffIndex; i < sa2.Length; i++)
            {
                if (sa2[i].StartsWith(projectName, StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }

                goForward++;
            }

            var sb = new StringBuilder();
            for (int i = 0; i < goForward; i++)
            {
                sb.Append(@$"{sa2[diffIndex + i]}\");
            }

            return sb.ToString();
        }

        private static string GetProjectReference(FileInfo source, FileInfo destination)
        {
            var sa1 = source.FullName.Split('\\');
            var sa2 = destination.FullName.Split('\\');
            int diffIndex = sa1.Where((t, i) => i < sa2.Length && t == sa2[i]).Count();

            int goBack = 0;
            for (int i = diffIndex; i < sa2.Length; i++)
            {
                if (sa2[i].EndsWith(".csproj", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }

                goBack++;
            }

            var sb1 = new StringBuilder();
            for (int i = 0; i < goBack; i++)
            {
                sb1.Append(@"..\");
            }

            var sb2 = new StringBuilder();
            for (int i = diffIndex; i < sa2.Length; i++)
            {
                if (sb2.Length != 0)
                {
                    sb2.Append('\\');
                }

                sb2.Append(sa2[i]);
            }

            return $"{sb1}{sb2}";
        }

        public static string GetNullableValueFromProject(XElement element)
        {
            if (element == null)
            {
                throw new ArgumentNullException(nameof(element));
            }

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

        public static void SetNullableValueForProject(XElement element, string newNullableValue)
        {
            if (element == null)
            {
                throw new ArgumentNullException(nameof(element));
            }

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

        public static bool GetBoolFromNullableString(string value) => value == "enable";

        public static string GetNullableStringFromBool(bool value) => value ? "enable" : "disable";
    }
}