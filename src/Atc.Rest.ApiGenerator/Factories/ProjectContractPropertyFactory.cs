using System.Collections.Generic;
using System.Linq;
using Microsoft.OpenApi.Models;

// ReSharper disable InvertIf
namespace Atc.Rest.ApiGenerator.Factories
{
    internal static class ProjectContractPropertyFactory
    {
        public static string[] CreateUsingList(IList<OpenApiParameter>? parameters, OpenApiRequestBody? requestBody)
        {
            var list = new List<string>();
            if (parameters != null)
            {
                if (parameters.HasFormatTypeFromSystemNamespace())
                {
                    list.Add("System");
                }

                if (parameters.Any(x => x.Required))
                {
                    list.Add("System.ComponentModel.DataAnnotations");
                }
                else if (parameters.HasFormatTypeFromDataAnnotationsNamespace())
                {
                    list.Add("System.ComponentModel.DataAnnotations");
                }

                list.Add("Microsoft.AspNetCore.Mvc");
            }

            if (requestBody != null && list.All(x => x != "System.ComponentModel.DataAnnotations"))
            {
                list.Add("System.ComponentModel.DataAnnotations");
            }

            return list.ToArray();
        }
    }
}