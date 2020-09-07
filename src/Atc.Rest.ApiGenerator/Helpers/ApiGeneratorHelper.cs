using System;
using System.IO;
using Atc.Rest.ApiGenerator.Models;
using Atc.Rest.ApiGenerator.Models.ApiOptions;
using Microsoft.OpenApi.Models;
using Microsoft.OpenApi.Readers;

namespace Atc.Rest.ApiGenerator.Helpers
{
    public static class ApiGeneratorHelper
    {
        public static bool Create(
            string apiProjectName,
            DirectoryInfo apiOutputPath,
            Tuple<OpenApiDocument, OpenApiDiagnostic, FileInfo> apiYamlDoc,
            ApiOptions apiOptions)
        {
            if (apiProjectName == null)
            {
                throw new ArgumentNullException(nameof(apiProjectName));
            }

            if (apiOutputPath == null)
            {
                throw new ArgumentNullException(nameof(apiOutputPath));
            }

            if (apiYamlDoc == null)
            {
                throw new ArgumentNullException(nameof(apiYamlDoc));
            }

            if (apiOptions == null)
            {
                throw new ArgumentNullException(nameof(apiOptions));
            }

            if (!OpenApiDocumentHelper.Validate(apiYamlDoc))
            {
                return false;
            }

            var apiProjectOptions = new ApiProjectOptions(apiOutputPath, apiYamlDoc.Item1, apiYamlDoc.Item3, apiProjectName, apiOptions);

            if (!ProjectGenerateHelper.ValidateVersioning(apiProjectOptions))
            {
                return false;
            }

            if (apiOutputPath.Exists)
            {
                ProjectGenerateHelper.PerformCleanup(apiOutputPath);
            }

            ProjectGenerateHelper.Scaffold(apiProjectOptions);
            ProjectGenerateHelper.CopyApiSpecification(apiProjectOptions);
            ProjectGenerateHelper.GenerateContracts(apiProjectOptions);
            ProjectGenerateHelper.GenerateEndpoints(apiProjectOptions);
            return true;
        }
    }
}