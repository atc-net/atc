using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using Atc.Data.Models;
using Atc.Rest.ApiGenerator.Models;
using Atc.Rest.ApiGenerator.Models.ApiOptions;
using Microsoft.OpenApi;
using Microsoft.OpenApi.Models;
using Microsoft.OpenApi.Readers;

// ReSharper disable ForeachCanBeConvertedToQueryUsingAnotherGetEnumerator
// ReSharper disable InvertIf
// ReSharper disable LoopCanBeConvertedToQuery
// ReSharper disable ReturnTypeCanBeEnumerable.Local
namespace Atc.Rest.ApiGenerator.Helpers
{
    public static class OpenApiDocumentHelper
    {
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "OK.")]
        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "OK.")]
        public static Tuple<OpenApiDocument, OpenApiDiagnostic, FileInfo> CombineAndGetApiYamlDoc(string specificationPath)
        {
            if (specificationPath == null)
            {
                throw new ArgumentNullException(nameof(specificationPath));
            }

            FileInfo? apiYamlFile;
            if (specificationPath.EndsWith(".yaml", StringComparison.Ordinal))
            {
                apiYamlFile = specificationPath.StartsWith("http", StringComparison.CurrentCultureIgnoreCase)
                    ? HttpClientHelper.DownloadToTempFile(specificationPath)
                    : new FileInfo(specificationPath);

                if (apiYamlFile == null || !apiYamlFile.Exists)
                {
                    throw new IOException("Api yaml file don't exist.");
                }
            }
            else
            {
                // Find all yaml files, except files starting with '.' as example '.spectral.yaml'
                var yamlFiles = Directory
                    .GetFiles(specificationPath, "*.yaml", SearchOption.AllDirectories)
                    .Where(x => !x.Contains("\\.", StringComparison.Ordinal))
                    .ToArray();

                apiYamlFile = yamlFiles.Length switch
                {
                    0 => throw new IOException("Api yaml file don't exist in folder."),
                    1 => new FileInfo(yamlFiles.First()),
                    _ => CreateCombineApiYamlDocFile(specificationPath)
                };
            }

            if (apiYamlFile == null || !apiYamlFile.Exists)
            {
                throw new IOException("Api yaml file don't exist");
            }

            var openApiStreamReader = new OpenApiStreamReader();
            var openApiDocument = openApiStreamReader.Read(File.OpenRead(apiYamlFile.FullName), out var diagnostic);
            return new Tuple<OpenApiDocument, OpenApiDiagnostic, FileInfo>(openApiDocument, diagnostic, new FileInfo(apiYamlFile.FullName));
        }

        public static List<LogKeyValueItem> Validate(Tuple<OpenApiDocument, OpenApiDiagnostic, FileInfo> apiYamlDoc, ApiOptionsValidation validationOptions)
        {
            if (apiYamlDoc == null)
            {
                throw new ArgumentNullException(nameof(apiYamlDoc));
            }

            if (validationOptions == null)
            {
                throw new ArgumentNullException(nameof(validationOptions));
            }

            var logItems = new List<LogKeyValueItem>();
            if (apiYamlDoc.Item2.SpecificationVersion == OpenApiSpecVersion.OpenApi2_0)
            {
                logItems.Add(LogItemHelper.Create(LogCategoryType.Error, "#", "OpenApi 2.x is not supported."));
                return logItems;
            }

            foreach (var diagnosticError in apiYamlDoc.Item2.Errors)
            {
                if (diagnosticError.Message.EndsWith("#/components/schemas", StringComparison.Ordinal))
                {
                    continue;
                }

                var description = string.IsNullOrEmpty(diagnosticError.Pointer)
                    ? $"{diagnosticError.Message}"
                    : $"{diagnosticError.Message} <#> {diagnosticError.Pointer}";
                logItems.Add(LogItemHelper.Create(LogCategoryType.Error, ValidationRuleNameConstants.OpenApiCore, description));
            }

            logItems.AddRange(OpenApiDocumentValidationHelper.ValidateDocument(apiYamlDoc.Item1, validationOptions));
            return logItems;
        }

        public static List<string> GetBasePathSegmentNames(OpenApiDocument openApiYamlDoc)
        {
            if (openApiYamlDoc == null)
            {
                throw new ArgumentNullException(nameof(openApiYamlDoc));
            }

            var names = new List<string>();
            if (openApiYamlDoc.Paths?.Keys == null)
            {
                return names.ToList();
            }

            foreach (var name in openApiYamlDoc.Paths.Keys
                    .Select(x => x.Split('/', StringSplitOptions.RemoveEmptyEntries))
                    .Where(sa => sa.Length != 0)
                    .Select(sa => sa[0].ToLower(CultureInfo.CurrentCulture)).Where(name => !names.Contains(name)))
            {
                names.Add(name);
            }

            return names
                .OrderBy(x => x)
                .ToList()!;
        }

        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "OK.")]
        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "OK.")]
        private static List<OpenApiYamlDoc> GetAllYamlDocuments(DirectoryInfo specificationPath)
        {
            if (specificationPath == null)
            {
                throw new ArgumentNullException(nameof(specificationPath));
            }

            var result = new List<OpenApiYamlDoc>();
            var yamlFiles = Directory.GetFiles(specificationPath.FullName, "*.yaml", SearchOption.AllDirectories);

            foreach (var yamlFile in yamlFiles)
            {
                var text = File.ReadAllText(yamlFile);
                try
                {
                    var openApiStreamReader = new OpenApiStreamReader();
                    var document = openApiStreamReader.Read(File.OpenRead(yamlFile), out var diagnostic);
                    result.Add(
                        new OpenApiYamlDoc(
                            new FileInfo(yamlFile),
                            text,
                            document,
                            diagnostic));
                }
                catch (Exception ex)
                {
                    result.Add(
                        new OpenApiYamlDoc(
                            new FileInfo(yamlFile),
                            text,
                            ex));
                }
            }

            return result;
        }

        [SuppressMessage("Info Code Smell", "S1135:Track uses of \"TODO\" tags", Justification = "Allow TODO here.")]
        [SuppressMessage("Minor Code Smell", "S1481:Unused local variables should be removed", Justification = "OK for now.")]
        private static FileInfo? CreateCombineApiYamlDocFile(string specificationPath)
        {
            var openApiYamlDocs = GetAllYamlDocuments(new DirectoryInfo(specificationPath));

            // TODO: Combine all yaml files into 1
            throw new NotImplementedException();
        }
    }
}