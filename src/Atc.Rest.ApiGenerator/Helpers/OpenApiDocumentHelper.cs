using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using Atc.Rest.ApiGenerator.Models;
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
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Ok.")]
        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "Ok.")]
        public static Tuple<OpenApiDocument, OpenApiDiagnostic, FileInfo> CombineAndGetApiYamlDoc(string apiDesignPath)
        {
            if (apiDesignPath == null)
            {
                throw new ArgumentNullException(nameof(apiDesignPath));
            }

            FileInfo? apiYamlFile;
            if (apiDesignPath.EndsWith(".yaml", StringComparison.Ordinal))
            {
                apiYamlFile = new FileInfo(apiDesignPath);
                if (!apiYamlFile.Exists)
                {
                    throw new IOException("Api yaml file don't exist.");
                }
            }
            else
            {
                // Find all yaml files, except files starting with '.' as example '.spectral.yaml'
                var yamlFiles = Directory
                    .GetFiles(apiDesignPath, "*.yaml", SearchOption.AllDirectories)
                    .Where(x => !x.Contains("\\.", StringComparison.Ordinal))
                    .ToArray();

                apiYamlFile = yamlFiles.Length switch
                {
                    0 => throw new IOException("Api yaml file don't exist in folder."),
                    1 => new FileInfo(yamlFiles.First()),
                    _ => CreateCombineApiYamlDocFile(apiDesignPath)
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

        public static bool Validate(Tuple<OpenApiDocument, OpenApiDiagnostic, FileInfo> apiYamlDoc)
        {
            if (apiYamlDoc == null)
            {
                throw new ArgumentNullException(nameof(apiYamlDoc));
            }

            var isValid = true;
            foreach (var diagnosticError in apiYamlDoc.Item2.Errors)
            {
                if (diagnosticError.Message.EndsWith("#/components/schemas", StringComparison.Ordinal))
                {
                    continue;
                }

                Console.WriteLine(string.IsNullOrEmpty(diagnosticError.Pointer)
                    ? $"{diagnosticError.Message}"
                    : $"{diagnosticError.Message} <#> {diagnosticError.Pointer}");
                isValid = false;
            }

            return isValid && OpenApiDocumentValidationHelper.IsDocumentValid(apiYamlDoc.Item1);
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

        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Ok.")]
        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "Ok.")]
        private static List<OpenApiYamlDoc> GetAllYamlDocuments(DirectoryInfo apiDesignPath)
        {
            if (apiDesignPath == null)
            {
                throw new ArgumentNullException(nameof(apiDesignPath));
            }

            var result = new List<OpenApiYamlDoc>();
            var yamlFiles = Directory.GetFiles(apiDesignPath.FullName, "*.yaml", SearchOption.AllDirectories);

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

        private static FileInfo? CreateCombineApiYamlDocFile(string apiDesignPath)
        {
            var openApiYamlDocs = GetAllYamlDocuments(new DirectoryInfo(apiDesignPath));

            // TODO: Combine all yaml files into 1
            throw new NotImplementedException();
        }
    }
}