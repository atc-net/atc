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
    public static class GeneratorHelper
    {
        public static List<LogKeyValueItem> GenerateServerApi(
            string projectPrefixName,
            DirectoryInfo outputPath,
            Tuple<OpenApiDocument, OpenApiDiagnostic, FileInfo> apiYamlDoc,
            ApiOptions apiOptions)
        {
            if (projectPrefixName == null)
            {
                throw new ArgumentNullException(nameof(projectPrefixName));
            }

            if (outputPath == null)
            {
                throw new ArgumentNullException(nameof(outputPath));
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
            var apiProjectOptions = new ApiProjectOptions(outputPath, apiYamlDoc.Item1, apiYamlDoc.Item3, projectPrefixName, apiOptions);

            logItems.Add(GenerateServerApiHelper.ValidateVersioning(apiProjectOptions));
            if (logItems.Any(x => x.LogCategory == LogCategoryType.Error))
            {
                return logItems;
            }

            if (apiProjectOptions.PathForSrcGenerate.Exists)
            {
                GenerateServerApiHelper.PerformCleanup(apiProjectOptions.PathForSrcGenerate);
            }

            GenerateServerApiHelper.Scaffold(apiProjectOptions);
            GenerateServerApiHelper.CopyApiSpecification(apiProjectOptions);

            var operationSchemaMappings = OpenApiOperationSchemaMapHelper.CollectMappings(apiProjectOptions.Document);
            logItems.AddRange(GenerateServerApiHelper.GenerateContracts(apiProjectOptions, operationSchemaMappings));
            logItems.AddRange(GenerateServerApiHelper.GenerateEndpoints(apiProjectOptions, operationSchemaMappings));
            return logItems;
        }

        public static List<LogKeyValueItem> GenerateServerDomain(
            string projectPrefixName,
            DirectoryInfo outputPath,
            Tuple<OpenApiDocument, OpenApiDiagnostic, FileInfo> apiYamlDoc,
            ApiOptions apiOptions,
            DirectoryInfo apiPath)
        {
            if (projectPrefixName == null)
            {
                throw new ArgumentNullException(nameof(projectPrefixName));
            }

            if (outputPath == null)
            {
                throw new ArgumentNullException(nameof(outputPath));
            }

            if (apiYamlDoc == null)
            {
                throw new ArgumentNullException(nameof(apiYamlDoc));
            }

            if (apiOptions == null)
            {
                throw new ArgumentNullException(nameof(apiOptions));
            }

            if (apiPath == null)
            {
                throw new ArgumentNullException(nameof(apiPath));
            }

            var logItems = new List<LogKeyValueItem>();
            var domainProjectOptions = new DomainProjectOptions(outputPath, apiYamlDoc.Item1, apiYamlDoc.Item3, projectPrefixName, apiOptions, apiPath);

            logItems.Add(GenerateServerDomainHelper.ValidateVersioning(domainProjectOptions));
            if (logItems.Any(x => x.LogCategory == LogCategoryType.Error))
            {
                return logItems;
            }

            GenerateServerDomainHelper.Scaffold(domainProjectOptions);

            var operationSchemaMappings = OpenApiOperationSchemaMapHelper.CollectMappings(domainProjectOptions.Document);
            logItems.AddRange(GenerateServerDomainHelper.GenerateHandlers(domainProjectOptions, operationSchemaMappings));
            return logItems;
        }

        public static List<LogKeyValueItem> GenerateServerHost(
            string projectPrefixName,
            DirectoryInfo outputPath,
            Tuple<OpenApiDocument, OpenApiDiagnostic, FileInfo> apiYamlDoc,
            ApiOptions apiOptions,
            DirectoryInfo apiPath,
            DirectoryInfo domainPath)
        {
            if (projectPrefixName == null)
            {
                throw new ArgumentNullException(nameof(projectPrefixName));
            }

            if (outputPath == null)
            {
                throw new ArgumentNullException(nameof(outputPath));
            }

            if (apiYamlDoc == null)
            {
                throw new ArgumentNullException(nameof(apiYamlDoc));
            }

            if (apiOptions == null)
            {
                throw new ArgumentNullException(nameof(apiOptions));
            }

            if (apiPath == null)
            {
                throw new ArgumentNullException(nameof(apiPath));
            }

            if (domainPath == null)
            {
                throw new ArgumentNullException(nameof(domainPath));
            }

            var logItems = new List<LogKeyValueItem>();
            var hostProjectOptions = new HostProjectOptions(outputPath, apiYamlDoc.Item1, apiYamlDoc.Item3, projectPrefixName, apiOptions, apiPath, domainPath);

            logItems.Add(GenerateServerHostHelper.ValidateVersioning(hostProjectOptions));
            if (logItems.Any(x => x.LogCategory == LogCategoryType.Error))
            {
                return logItems;
            }

            logItems.Add(new LogKeyValueItem(LogCategoryType.Warning, "#", "Command for server-host is not implemented yet, sorry..."));
            return logItems;
        }
    }
}