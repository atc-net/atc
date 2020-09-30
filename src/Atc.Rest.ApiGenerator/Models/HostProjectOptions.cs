using System;
using System.IO;
using Microsoft.OpenApi.Models;

namespace Atc.Rest.ApiGenerator.Models
{
    public class HostProjectOptions : BaseProjectOptions
    {
        public HostProjectOptions(
            DirectoryInfo projectSrcGeneratePath,
            OpenApiDocument openApiDocument,
            FileInfo openApiDocumentFile,
            string projectPrefixName,
            ApiOptions.ApiOptions apiOptions,
            DirectoryInfo apiProjectSrcPath,
            DirectoryInfo domainProjectSrcPath)
            : base(
                projectSrcGeneratePath,
                openApiDocument,
                openApiDocumentFile,
                projectPrefixName,
                "Api",
                apiOptions)
        {
            ApiProjectSrcPath = apiProjectSrcPath ?? throw new ArgumentNullException(nameof(projectSrcGeneratePath));
            if (apiProjectSrcPath.Exists)
            {
                var files = Directory.GetFiles(apiProjectSrcPath.FullName, "ApiGenerated.cs", SearchOption.AllDirectories);
                if (files.Length == 1)
                {
                    ApiProjectSrcPath = new FileInfo(files[0]).Directory!;
                }
            }

            DomainProjectSrcPath = domainProjectSrcPath ?? throw new ArgumentNullException(nameof(domainProjectSrcPath));
            if (domainProjectSrcPath.Exists)
            {
                var files = Directory.GetFiles(domainProjectSrcPath.FullName, "DomainRegistration.cs", SearchOption.AllDirectories);
                if (files.Length == 1)
                {
                    DomainProjectSrcPath = new FileInfo(files[0]).Directory!;
                }
            }
        }

        public DirectoryInfo ApiProjectSrcPath { get; }

        public DirectoryInfo DomainProjectSrcPath { get; }
    }
}