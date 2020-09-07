using System;
using System.IO;
using Microsoft.OpenApi.Models;
using Microsoft.OpenApi.Readers;

namespace Atc.Rest.ApiGenerator.Models
{
    internal class OpenApiYamlDoc
    {
        public OpenApiYamlDoc(FileInfo yamlFile, string yamlText, OpenApiDocument openApiDocument, OpenApiDiagnostic openApiDiagnostic)
        {
            YamlFile = yamlFile;
            YamlText = yamlText;
            Document = openApiDocument;
            Diagnostic = openApiDiagnostic;
        }

        public OpenApiYamlDoc(FileInfo yamlFile, string yamlText, Exception exception)
        {
            YamlFile = yamlFile;
            YamlText = yamlText;
            Exception = exception;
        }

        public FileInfo YamlFile { get; }

        public string YamlText { get; }

        public OpenApiDocument? Document { get; }

        public OpenApiDiagnostic? Diagnostic { get; }

        public Exception? Exception { get; }

        public override string ToString()
        {
            return Exception == null
                ? $"{nameof(YamlFile)}: {YamlFile}, ErrorCount: {Diagnostic?.Errors.Count}"
                : $"{nameof(YamlFile)}: {YamlFile}, Exception: {Exception.Message}";
        }
    }
}