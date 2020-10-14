using System.Collections.Generic;
using System.Linq;
using Microsoft.OpenApi.Models;

// ReSharper disable InvertIf
namespace Atc.Rest.ApiGenerator.Factories
{
    internal static class ProjectContractPropertyFactory
    {
        public static string[] CreateUsingList(
            IList<OpenApiParameter>? globalParameters,
            IList<OpenApiParameter>? parameters,
            OpenApiRequestBody? requestBody)
        {
            var list = new List<string>();

            if (globalParameters != null && ShouldUseDataAnnotationsNamespace(globalParameters))
            {
                list.Add("System.ComponentModel.DataAnnotations");
            }

            if (parameters != null)
            {
                if (parameters.HasFormatTypeFromSystemNamespace())
                {
                    list.Add("System");
                }

                list.Add("System.CodeDom.Compiler");

                if (ShouldUseDataAnnotationsNamespace(parameters) &&
                    list.All(x => x != "System.ComponentModel.DataAnnotations"))
                {
                    list.Add("System.ComponentModel.DataAnnotations");
                }

                list.Add("Microsoft.AspNetCore.Mvc");
            }

            if (requestBody != null &&
                list.All(x => x != "System.ComponentModel.DataAnnotations"))
            {
                list.Add("System.ComponentModel.DataAnnotations");
            }

            return list.ToArray();
        }

        private static bool ShouldUseDataAnnotationsNamespace(IList<OpenApiParameter> parameters)
            => parameters.Any(x => x.Required) || parameters.HasFormatTypeFromDataAnnotationsNamespace();
    }
}