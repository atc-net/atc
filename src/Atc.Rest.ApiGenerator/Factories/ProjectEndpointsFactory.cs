using System;
using System.Collections.Generic;
using Atc.Rest.ApiGenerator.Models;
using Microsoft.OpenApi.Models;

namespace Atc.Rest.ApiGenerator.Factories
{
    internal static class ProjectEndpointsFactory
    {
        public static string[] CreateUsingList(
            ApiProjectOptions apiProjectOptions,
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
                "System.CodeDom.Compiler",
                "System.Threading",
                "System.Threading.Tasks",
                $"{apiProjectOptions.ProjectName}.{NameConstants.Contracts}.{focusOnSegmentName.EnsureFirstCharacterToUpper()}",
                "Microsoft.AspNetCore.Http",
                "Microsoft.AspNetCore.Mvc",
            };

            if (apiOperations.HasDataTypeFromSystemCollectionGenericNamespace())
            {
                list.Add("System.Collections.Generic");
            }

            if (apiProjectOptions.ApiOptions.Generator.UseAuthorization)
            {
                list.Add("Microsoft.AspNetCore.Authorization");
            }

            return list.ToArray();
        }
    }
}