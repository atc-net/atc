using System;
using System.Collections.Generic;
using Microsoft.OpenApi.Models;

namespace Atc.Rest.ApiGenerator.Factories
{
    internal static class ProjectEndpointsFactory
    {
        public static string[] CreateUsingList(
            string apiProjectName,
            string focusOnSegmentName,
            List<OpenApiOperation> apiOperations)
        {
            if (apiOperations == null)
            {
                throw new ArgumentNullException(nameof(apiOperations));
            }

            var list = new List<string>
            {
                "System",
                "System.Threading",
                "System.Threading.Tasks",
                $"{apiProjectName}.Generated.{NameConstants.Contracts}.{focusOnSegmentName.EnsureFirstLetterToUpper()}",
                "Microsoft.AspNetCore.Http",
                "Microsoft.AspNetCore.Mvc",
            };

            if (apiOperations.HasDataTypeFromSystemCollectionGenericNamespace())
            {
                list.Add("System.Collections.Generic");
            }

            return list.ToArray();
        }
    }
}