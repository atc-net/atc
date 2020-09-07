using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Atc.Rest.ApiGenerator.Helpers;
using Microsoft.OpenApi.Models;

namespace Atc.Rest.ApiGenerator.Models
{
    public class ApiProjectOptions
    {
        public ApiProjectOptions(
            DirectoryInfo apiProjectSrcGeneratePath,
            OpenApiDocument openApiDocument,
            FileInfo openApiDocumentFile,
            string apiProjectName,
            ApiOptions.ApiOptions apiOptions)
        {
            var executingAssembly = Assembly.GetExecutingAssembly();
            ToolNameAndProjectVersion = executingAssembly.GetName().Name + " - " + executingAssembly.GetName().Version;
            ApiOptions = apiOptions;
            PathForSrcGenerate = apiProjectSrcGeneratePath ?? throw new ArgumentNullException(nameof(apiProjectSrcGeneratePath));
            Document = openApiDocument ?? throw new ArgumentNullException(nameof(openApiDocument));
            DocumentFile = openApiDocumentFile ?? throw new ArgumentNullException(nameof(openApiDocumentFile));
            ProjectName = apiProjectName ?? throw new ArgumentNullException(nameof(apiProjectName));
            ApiVersion = GetApiVersion(openApiDocument);
            ProjectName = ProjectName
                .Replace(" ", ".", StringComparison.Ordinal)
                .Replace("-", ".", StringComparison.Ordinal)
                .Trim();
            PathForEndpoints = new DirectoryInfo(Path.Combine(apiProjectSrcGeneratePath.FullName, NameConstants.Endpoints));
            PathForContracts = new DirectoryInfo(Path.Combine(apiProjectSrcGeneratePath.FullName, NameConstants.Contracts));
            PathForContractsEnumerationTypes = new DirectoryInfo(Path.Combine(PathForContracts.FullName, NameConstants.ContractsEnumerationTypes));
            PathForContractsShared = new DirectoryInfo(Path.Combine(PathForContracts.FullName, NameConstants.ContractsSharedModels));
            BasePathSegmentNames = OpenApiDocumentHelper.GetBasePathSegmentNames(openApiDocument);
        }

        public string ToolNameAndProjectVersion { get; }

        public ApiOptions.ApiOptions ApiOptions { get; }

        public DirectoryInfo PathForSrcGenerate { get; }

        public DirectoryInfo PathForEndpoints { get; }

        public DirectoryInfo PathForContracts { get; }

        public DirectoryInfo PathForContractsEnumerationTypes { get; }

        public DirectoryInfo PathForContractsShared { get; }

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