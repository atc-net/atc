using System;
using System.IO;
using System.Text;
using System.Xml.Linq;

namespace Atc.Rest.ApiGenerator.Helpers
{
    public static class GenerateHelper
    {
        public static void ScaffoldProjFile(
            DirectoryInfo projectSrcGeneratePath,
            string projectName,
            bool useNullableReferenceTypes,
            bool includeApiSpecification)
        {
            if (projectSrcGeneratePath == null)
            {
                throw new ArgumentNullException(nameof(projectSrcGeneratePath));
            }

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

            sb.AppendLine(" <ItemGroup>");
            sb.AppendLine("     <FrameworkReference Include=\"Microsoft.AspNetCore.App\" />");
            sb.AppendLine(" </ItemGroup>");
            sb.AppendLine();
            sb.AppendLine("</Project>");
            var file = new FileInfo(Path.Combine(projectSrcGeneratePath.FullName, $"{projectName}.csproj"));
            FileHelper.Save(file, sb.ToString());
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