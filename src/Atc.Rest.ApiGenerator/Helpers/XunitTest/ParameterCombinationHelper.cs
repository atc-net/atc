using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.OpenApi.Models;
// ReSharper disable ForeachCanBeConvertedToQueryUsingAnotherGetEnumerator
// ReSharper disable LoopCanBeConvertedToQuery

namespace Atc.Rest.ApiGenerator.Helpers.XunitTest
{
    public static class ParameterCombinationHelper
    {
        public static List<List<OpenApiParameter>> GetCombination(List<OpenApiParameter> parameters, bool useForBadRequest)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            var list = new List<List<OpenApiParameter>>();
            if (parameters.Count <= 0)
            {
                return list;
            }

            var totalNames = GetNames(parameters);
            var totalCombinationNames = totalNames.GetUniqueCombinations();
            var requiredNames = GetRequiredNames(parameters);
            if (requiredNames.Count > 0)
            {
                if (useForBadRequest)
                {
                }
                else
                {
                    var filteredCombinationNames = GetFilteredCombinationNames(totalCombinationNames, requiredNames);
                    foreach (var item in filteredCombinationNames)
                    {
                        var localParameters = item
                            .Select(name => parameters.Find(x => x.Name.Equals(name, StringComparison.Ordinal)))
                            .ToList();
                        list.Add(localParameters);
                    }
                }
            }
            else
            {
                if (useForBadRequest)
                {
                }
                else
                {
                    foreach (var item in totalCombinationNames)
                    {
                        var localParameters = item
                            .Select(name => parameters.Find(x => x.Name.Equals(name, StringComparison.Ordinal)))
                            .ToList();
                        list.Add(localParameters);
                    }
                }
            }

            return list;
        }

        private static List<List<string>> GetFilteredCombinationNames(IEnumerable<IEnumerable<string>> totalCombinationNames, List<string> requiredNames)
        {
            return totalCombinationNames
                .Select(totalCombinationName => totalCombinationName.ToList())
                .Where(item => requiredNames.Any(item.Contains))
                .ToList();
        }

        private static List<string> GetNames(List<OpenApiParameter> parameters)
        {
            return parameters.Select(x => x.Name).ToList();
        }

        private static List<string> GetRequiredNames(List<OpenApiParameter> parameters)
        {
            return parameters.Where(x => x.Required).Select(x => x.Name).ToList();
        }
    }
}