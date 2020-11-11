using System;
using System.Linq;
using Atc.Rest.ApiGenerator.Models;

namespace Atc.Rest.ApiGenerator.Helpers
{
    public static class OpenApiDocumentSchemaModelNameHelper
    {
        public static string GetRawModelName(string modelName)
        {
            if (string.IsNullOrEmpty(modelName))
            {
                return string.Empty;
            }

            var strippedModelName = modelName
                .Replace(Microsoft.OpenApi.Models.NameConstants.Pagination, string.Empty, StringComparison.Ordinal)
                .Replace(Microsoft.OpenApi.Models.NameConstants.List, string.Empty, StringComparison.Ordinal)
                .Replace("<", string.Empty, StringComparison.Ordinal)
                .Replace(">", string.Empty, StringComparison.Ordinal);

            if (strippedModelName.Contains('.', StringComparison.Ordinal))
            {
                strippedModelName = strippedModelName.Split('.', StringSplitOptions.RemoveEmptyEntries).Last();
            }

            return strippedModelName;
        }

        public static string EnsureModelNameWithNamespaceIfNeeded(EndpointMethodMetadata endpointMethodMetadata, string modelName)
        {
            if (endpointMethodMetadata == null)
            {
                throw new ArgumentNullException(nameof(endpointMethodMetadata));
            }

            return EnsureModelNameWithNamespaceIfNeeded(
                endpointMethodMetadata.ProjectName,
                endpointMethodMetadata.SegmentName,
                modelName);
        }

        public static string EnsureModelNameWithNamespaceIfNeeded(string projectName, string segmentName, string modelName, bool isShared = false)
        {
            if (string.IsNullOrEmpty(modelName))
            {
                return string.Empty;
            }

            var isModelNameInNamespace = HasNamespaceRawModelName($"{projectName}.{segmentName}", modelName);

            if (isModelNameInNamespace)
            {
                return $"{projectName}.{NameConstants.Contracts}.{segmentName}.{modelName}";
            }

            if (isShared)
            {
                // TO-DO: Maybe use it?..
            }

            return modelName;
        }

        private static bool HasNamespaceRawModelName(string namespacePart, string rawModelName)
        {
            return namespacePart
                .Split('.', StringSplitOptions.RemoveEmptyEntries)
                .Any(s => s.Equals(rawModelName, StringComparison.Ordinal));
        }
    }
}