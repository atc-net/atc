using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Atc.Rest.ApiGenerator.Models;

namespace Atc.Rest.ApiGenerator.Helpers
{
    public static class OpenApiDocumentSchemaModelNameHelper
    {
        public static string EnsureModelNameNamespaceIfNeeded(
            string projectNamespace,
            string modelName,
            string contractArea,
            bool isShared)
        {
            if (string.IsNullOrEmpty(modelName))
            {
                return modelName;
            }

            var reservedModelNames = new List<string>
            {
                nameof(Task),
                "Event",
            };

            if (reservedModelNames.Contains(modelName))
            {
                return isShared
                    ? $"{NameConstants.Contracts}.{modelName}"
                    : $"{NameConstants.Contracts}.{contractArea.EnsureFirstCharacterToUpper()}.{modelName}";
            }

            if (isShared)
            {
                return $"{NameConstants.Contracts}.{modelName}";
            }

            if (string.IsNullOrEmpty(projectNamespace))
            {
                return modelName;
            }

            var sa = projectNamespace.Split('.', StringSplitOptions.RemoveEmptyEntries);
            return sa.Any(s => s.Equals(modelName, StringComparison.Ordinal))
                ? $"{NameConstants.Contracts}.{contractArea.EnsureFirstCharacterToUpper()}.{modelName}"
                : modelName;
        }

        public static string EnsureModelNameNamespaceIfNeeded(EndpointMethodMetadata endpointMethodMetadata, string modelName)
        {
            if (endpointMethodMetadata == null)
            {
                throw new ArgumentNullException(nameof(endpointMethodMetadata));
            }

            if (modelName == null)
            {
                throw new ArgumentNullException(nameof(modelName));
            }

            var resultModelName = EnsureModelNameNamespaceIfNeeded(
                endpointMethodMetadata.ProjectNamespace,
                modelName,
                endpointMethodMetadata.SegmentName,
                endpointMethodMetadata.IsSharedResponseModel);

            return resultModelName.Equals(modelName, StringComparison.Ordinal)
                ? modelName
                : $"{endpointMethodMetadata.ProjectNamespace}.{resultModelName}";
        }
    }
}