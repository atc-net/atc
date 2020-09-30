using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Atc.Rest.ApiGenerator.Helpers;
using Microsoft.OpenApi.Models;

namespace Atc.Rest.ApiGenerator.Models
{
    public abstract class BaseProjectOptions
    {
        protected BaseProjectOptions(
            DirectoryInfo projectSrcGeneratePath,
            OpenApiDocument openApiDocument,
            FileInfo openApiDocumentFile,
            string projectPrefixName,
            string projectSuffixName,
            ApiOptions.ApiOptions apiOptions)
        {
            PathForSrcGenerate = projectSrcGeneratePath ?? throw new ArgumentNullException(nameof(projectSrcGeneratePath));
            Document = openApiDocument ?? throw new ArgumentNullException(nameof(openApiDocument));
            DocumentFile = openApiDocumentFile ?? throw new ArgumentNullException(nameof(openApiDocumentFile));
            ProjectName = projectPrefixName ?? throw new ArgumentNullException(nameof(projectPrefixName));

            var executingAssembly = Assembly.GetExecutingAssembly();
            ToolNameAndProjectVersion = $"ApiGenerator {executingAssembly.GetName().Version}";
            ApiOptions = apiOptions;

            ApiVersion = GetApiVersion(openApiDocument);
            ProjectName = projectPrefixName
                .Replace(" ", ".", StringComparison.Ordinal)
                .Replace("-", ".", StringComparison.Ordinal)
                .Trim() + $".{projectSuffixName}";
            PathForSrcGenerate = new DirectoryInfo(Path.Combine(PathForSrcGenerate.FullName, ProjectName));
            BasePathSegmentNames = OpenApiDocumentHelper.GetBasePathSegmentNames(openApiDocument);
        }

        public string ToolNameAndProjectVersion { get; }

        public ApiOptions.ApiOptions ApiOptions { get; }

        public DirectoryInfo PathForSrcGenerate { get; }

        public OpenApiDocument Document { get; }

        public FileInfo DocumentFile { get; }

        public string ProjectName { get; }

        public string ApiVersion { get; }

        public List<string> BasePathSegmentNames { get; }

        private static string GetApiVersion(OpenApiDocument openApiDocument)
        {
            if (openApiDocument.Info?.Version != null)
            {
                return openApiDocument.Info.Version switch
                {
                    "1" => "v1",
                    "1.0" => "v1",
                    "v1" => "v1",
                    "v1.0" => "v1",
                    _ => openApiDocument.Info.Version.Replace(".", string.Empty, StringComparison.Ordinal)
                };
            }

            return "v1";
        }
    }
}