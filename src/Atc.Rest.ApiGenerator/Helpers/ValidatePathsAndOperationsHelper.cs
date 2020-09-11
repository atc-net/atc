using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.OpenApi.Models;

// ReSharper disable LoopCanBeConvertedToQuery
namespace Atc.Rest.ApiGenerator.Helpers
{
    public static class ValidatePathsAndOperationsHelper
    {
        /// <summary>
        /// Check global parameters.
        /// </summary>
        /// <param name="globalPathParameterNames">The global path parameter names.</param>
        /// <param name="path">The path.</param>
        public static List<string> ValidateGlobalParameters(IEnumerable<string> globalPathParameterNames, KeyValuePair<string, OpenApiPathItem> path)
        {
            if (globalPathParameterNames == null)
            {
                throw new ArgumentNullException(nameof(globalPathParameterNames));
            }

            var result = new List<string>();
            foreach (var pathParameterName in globalPathParameterNames)
            {
                if (!path.Key.Contains(pathParameterName, StringComparison.OrdinalIgnoreCase))
                {
                    result.Add($"Operation - Defined global path parameter '{pathParameterName}' does not exist in route '{path.Key}'.");
                }
            }

            return result;
        }

        /// <summary>
        /// Check for operations that are not defining parameters, which are present in the path.key.
        /// </summary>
        /// <param name="path">The path.</param>
        public static List<string> ValidateMissingOperationParameters(KeyValuePair<string, OpenApiPathItem> path)
        {
            var result = new List<string>();
            if (!path.Key.Contains('{', StringComparison.Ordinal) ||
                !path.Key.IsStringFormatParametersBalanced(false))
            {
                return result;
            }

            var parameterNamesToCheckAgainst = GetParameterListFromPathKey(path.Key);
            var allOperationsParametersFromPath = GetAllOperationsParametersFromPath(path.Value.Operations);
            var distinctOperations = allOperationsParametersFromPath
                .Select(x => x.Item1)
                .Distinct()
                .ToList();

            foreach (var parameterName in parameterNamesToCheckAgainst)
            {
                var allOperationWithTheMatchingParameterName = allOperationsParametersFromPath
                    .Where(x => x.Item2.Equals(parameterName, StringComparison.OrdinalIgnoreCase))
                    .ToList();

                if (distinctOperations.Count != allOperationWithTheMatchingParameterName.Count)
                {
                    var operationsWithMissingParameter = allOperationsParametersFromPath
                        .Where(x => string.IsNullOrEmpty(x.Item2))
                        .Select(x => x.Item1)
                        .ToList();

                    result.Add($"Operation - The operations '{string.Join(',', operationsWithMissingParameter)}' in path '{path.Key}' does not define a parameter named '{parameterName}'.");
                }
            }

            return result;
        }

        /// <summary>
        /// Check for operations with parameters, that are not present in the path.key.
        /// </summary>
        /// <param name="path">The path.</param>
        public static List<string> ValidateOperationsWithParametersNotPresentInPath(KeyValuePair<string, OpenApiPathItem> path)
        {
            var result = new List<string>();
            var openApiOperationsWithPathParameter = path.Value.Operations.Values
                .Where(x => x.Parameters.Any(p => p.In == ParameterLocation.Path))
                .ToList();

            if (!openApiOperationsWithPathParameter.Any())
            {
                return result;
            }

            var operationPathParameterNames = new List<string>();
            foreach (var openApiOperation in openApiOperationsWithPathParameter)
            {
                operationPathParameterNames.AddRange(openApiOperation.Parameters
                    .Where(x => x.In == ParameterLocation.Path)
                    .Select(openApiParameter => openApiParameter.Name));
            }

            if (!operationPathParameterNames.Any())
            {
                return result;
            }

            foreach (var operationParameterName in operationPathParameterNames)
            {
                if (!path.Key.Contains(operationParameterName, StringComparison.OrdinalIgnoreCase))
                {
                    result.Add($"Operation - Defined path parameter '{operationParameterName}' does not exist in route '{path.Key}'.");
                }
            }

            return result;
        }

        /// <summary>
        /// Check for response types according to operation/global parameters.
        /// </summary>
        /// <param name="path">The path.</param>
        public static List<string> ValidateGetOperations(KeyValuePair<string, OpenApiPathItem> path)
        {
            var result = new List<string>();
            foreach (var (key, value) in path.Value.Operations)
            {
                if (key != OperationType.Get || (path.Value.Parameters.All(x => x.In != ParameterLocation.Path) &&
                                                 value.Parameters.All(x => x.In != ParameterLocation.Path)))
                {
                    continue;
                }

                var httpStatusCodes = value.Responses.GetHttpStatusCodes();
                if (!httpStatusCodes.Contains(HttpStatusCode.NotFound))
                {
                    result.Add($"Operation - Missing NotFound response type for operation '{value.GetOperationName()}', required by url parameter.");
                }
            }

            return result;
        }

        private static IEnumerable<string> GetParameterListFromPathKey(string pathKey)
        {
            var sa = pathKey
                .Split('{', StringSplitOptions.RemoveEmptyEntries)
                .Where(x => x.Contains('}', StringComparison.Ordinal))
                .ToList();

            return sa
                .Select(item => item.Substring(0, item.IndexOf('}', StringComparison.Ordinal)))
                .ToList();
        }

        private static List<Tuple<string, string>> GetAllOperationsParametersFromPath(IDictionary<OperationType, OpenApiOperation> apiOperations)
        {
            var list = new List<Tuple<string, string>>();
            foreach (var apiOperation in apiOperations.Values)
            {
                if (apiOperation.Parameters.Any())
                {
                    foreach (var apiOperationParameter in apiOperation.Parameters)
                    {
                        list.Add(Tuple.Create(apiOperation.GetOperationName(), apiOperationParameter.Name));
                    }
                }
                else
                {
                    list.Add(Tuple.Create(apiOperation.GetOperationName(), string.Empty));
                }
            }

            return list;
        }
    }
}