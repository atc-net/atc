using System;
using System.Reflection;
using Atc.Rest.ApiGenerator.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Atc.Rest.ApiGenerator.ProjectSyntaxFactories
{
    internal static class SyntaxProjectFactory
    {
        public static NamespaceDeclarationSyntax CreateNamespace(ApiProjectOptions apiProjectOptions)
        {
            if (apiProjectOptions == null)
            {
                throw new ArgumentNullException(nameof(apiProjectOptions));
            }

            return SyntaxNamespaceDeclarationFactory.Create(
                GetGeneratedByToolAndVersion(),
                $"{apiProjectOptions.ProjectName}.Generated");
        }

        public static NamespaceDeclarationSyntax CreateNamespace(ApiProjectOptions apiProjectOptions, string namespacePart)
        {
            if (apiProjectOptions == null)
            {
                throw new ArgumentNullException(nameof(apiProjectOptions));
            }

            if (namespacePart == null)
            {
                throw new ArgumentNullException(nameof(namespacePart));
            }

            return SyntaxNamespaceDeclarationFactory.Create(
                GetGeneratedByToolAndVersion(),
                $"{apiProjectOptions.ProjectName}.Generated.{namespacePart}");
        }

        public static NamespaceDeclarationSyntax CreateNamespace(ApiProjectOptions apiProjectOptions, string namespacePart, string focusOnSegmentName)
        {
            if (apiProjectOptions == null)
            {
                throw new ArgumentNullException(nameof(apiProjectOptions));
            }

            if (namespacePart == null)
            {
                throw new ArgumentNullException(nameof(namespacePart));
            }

            if (focusOnSegmentName == null)
            {
                throw new ArgumentNullException(nameof(focusOnSegmentName));
            }

            return SyntaxNamespaceDeclarationFactory.Create(
                GetGeneratedByToolAndVersion(),
                $"{apiProjectOptions.ProjectName}.Generated.{namespacePart}.{focusOnSegmentName.EnsureFirstLetterToUpper()}");
        }

        private static string GetGeneratedByToolAndVersion()
        {
            var assemblyName = Assembly.GetExecutingAssembly().GetName();
            return $"{assemblyName.Name} {assemblyName.Version}";
        }
    }
}