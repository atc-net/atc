using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

// ReSharper disable UseDeconstruction
// ReSharper disable LoopCanBeConvertedToQuery
namespace Atc.Rest.Extended.Filters
{
    public class SwaggerEnumDescriptionsDocumentFilter : IDocumentFilter
    {
        public void Apply(OpenApiDocument document, DocumentFilterContext context)
        {
            if (document == null)
            {
                throw new ArgumentNullException(nameof(document));
            }

            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            // Add enum descriptions to result models
            foreach (var item in document.Components.Schemas.Where(x => x.Value?.Enum?.Count > 0))
            {
                var propertyEnums = item.Value.Enum;
                if (propertyEnums != null && propertyEnums.Count > 0)
                {
                    item.Value.Description += DescribeEnum(propertyEnums, item.Key);
                }
            }

            // Add enum descriptions to input parameters
            foreach (var item in document.Paths)
            {
                DescribeEnumParameters(item.Value.Operations, document, context.ApiDescriptions, item.Key);
            }
        }

        private static void DescribeEnumParameters(
            IDictionary<OperationType,
            OpenApiOperation> operations,
            OpenApiDocument document,
            IEnumerable<ApiDescription> apiDescriptions,
            string path)
        {
            path = path.Trim('/');
            if (operations == null)
            {
                return;
            }

            var pathDescriptions = apiDescriptions.Where(a => a.RelativePath == path).ToList();
            foreach (var operation in operations)
            {
                var operationDescription = pathDescriptions.FirstOrDefault(a => a.HttpMethod.Equals(operation.Key.ToString(), StringComparison.OrdinalIgnoreCase));
                foreach (var param in operation.Value.Parameters)
                {
                    var parameterDescription = operationDescription?.ParameterDescriptions.FirstOrDefault(a => a.Name == param.Name);

                    if (parameterDescription?.Type == null)
                    {
                        continue;
                    }

                    if (!parameterDescription.Type.TryGetEnumType(out var enumType))
                    {
                        continue;
                    }

                    var paramEnum = document.Components.Schemas.FirstOrDefault(x => x.Key == enumType.Name);
                    if (paramEnum.Value != null)
                    {
                        param.Description += DescribeEnum(paramEnum.Value.Enum, paramEnum.Key);
                    }
                }
            }
        }

        private static string DescribeEnum(IEnumerable<IOpenApiAny> enums, string propertyTypeName)
        {
            var enumDescriptions = new List<string>();
            var enumType = GetEnumTypeByName(propertyTypeName);
            if (enumType == null)
            {
                return null!;
            }

            foreach (var item in enums)
            {
                switch (item)
                {
                    case OpenApiInteger intItem:
                    {
                        var enumOption = intItem;
                        var enumInt = enumOption.Value;
                        enumDescriptions.Add($"{enumInt} = {Enum.GetName(enumType, enumInt)}");
                        break;
                    }

                    case OpenApiString stringItem:
                    {
                        var enumOption = stringItem;
                        var enumInt = (int)Enum.Parse(enumType, enumOption.Value);
                        enumDescriptions.Add($"{enumInt} = {enumOption.Value}");
                        break;
                    }
                }
            }

            return string.Join("<br />", enumDescriptions.ToArray());
        }

        private static Type GetEnumTypeByName(string enumTypeName)
        {
            return AppDomain.CurrentDomain
                .GetAssemblies()
                .SelectMany(x => x.GetTypes())
                .FirstOrDefault(x => x.Name == enumTypeName);
        }
    }
}