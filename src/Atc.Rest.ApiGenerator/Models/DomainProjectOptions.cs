using System;
using System.IO;
using Microsoft.OpenApi.Models;

namespace Atc.Rest.ApiGenerator.Models
{
    public class DomainProjectOptions : BaseProjectOptions
    {
        public DomainProjectOptions(
            DirectoryInfo projectSrcGeneratePath,
            OpenApiDocument openApiDocument,
            FileInfo openApiDocumentFile,
            string projectPrefixName,
            ApiOptions.ApiOptions apiOptions,
            DirectoryInfo apiProjectSrcPath)
            : base(
                projectSrcGeneratePath,
                openApiDocument,
                openApiDocumentFile,
                projectPrefixName,
                "Domain",
                apiOptions)
        {
            ApiProjectSrcPath = apiProjectSrcPath ?? throw new ArgumentNullException(nameof(apiProjectSrcPath));
            if (apiProjectSrcPath.Exists)
            {
                var files = Directory.GetFiles(apiProjectSrcPath.FullName, "ApiGenerated.cs", SearchOption.AllDirectories);
                if (files.Length == 1)
                {
                    ApiProjectSrcPath = new FileInfo(files[0]).Directory!;
                }
            }

            PathForHandlers = new DirectoryInfo(Path.Combine(PathForSrcGenerate.FullName, NameConstants.Handlers));
        }

        public DirectoryInfo ApiProjectSrcPath { get; }

        public DirectoryInfo PathForHandlers { get; set; }
    }
}