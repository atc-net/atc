using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Atc.Data.Models;
using Atc.Rest.ApiGenerator.Models;
using Atc.Rest.ApiGenerator.Models.ApiOptions;
using Microsoft.OpenApi.Models;
using Microsoft.OpenApi.Readers;

namespace Atc.Rest.ApiGenerator.Helpers
{
    public static class ApiGeneratorHelper
    {
        public static List<LogKeyValueItem> Create(
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

            var logItems = new List<LogKeyValueItem>();
            logItems.AddRange(OpenApiDocumentHelper.Validate(apiYamlDoc, apiOptions.Validation));
            if (logItems.Any(x => x.LogCategory == LogCategoryType.Error))
            {
                return logItems;
            }

            var apiProjectOptions = new ApiProjectOptions(apiOutputPath, apiYamlDoc.Item1, apiYamlDoc.Item3, apiProjectName, apiOptions);

            logItems.Add(ProjectGenerateHelper.ValidateVersioning(apiProjectOptions));
            if (logItems.Any(x => x.LogCategory == LogCategoryType.Error))
            {
                return logItems;
            }

            if (apiOutputPath.Exists)
            {
                ProjectGenerateHelper.PerformCleanup(apiOutputPath);
            }

            ProjectGenerateHelper.Scaffold(apiProjectOptions);
            ProjectGenerateHelper.CopyApiSpecification(apiProjectOptions);

            var operationSchemaMappings = OpenApiOperationSchemaMapHelper.CollectMappings(apiProjectOptions.Document);
            ProjectGenerateHelper.GenerateContracts(apiProjectOptions, operationSchemaMappings);
            ProjectGenerateHelper.GenerateEndpoints(apiProjectOptions, operationSchemaMappings);
            return logItems;
        }
    }
}