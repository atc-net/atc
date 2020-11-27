using System;
using System.Collections.Generic;
using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Atc.Rest.Extended.Filters
{
    /// <summary>
    /// Bad request as default response.
    /// </summary>
    /// <remarks>
    /// REF: https://github.com/domaindrivendev/Swashbuckle.AspNetCore/issues/1278 .
    /// </remarks>
    /// <seealso cref="Swashbuckle.AspNetCore.SwaggerGen.IOperationFilter" />
    public class DefaultResponseOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation == null)
            {
                throw new ArgumentNullException(nameof(operation));
            }

            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (operation.Responses == null)
            {
                operation.Responses = new OpenApiResponses();
            }

            if (!operation.Responses.ContainsKey("default"))
            {
                operation.Responses.Add("default", new OpenApiResponse
                {
                    Description = "Problem response",
                    Content = new Dictionary<string, OpenApiMediaType>
                    {
                        [MediaTypeNames.Application.Json] = new OpenApiMediaType
                        {
                            Schema = context.SchemaGenerator.GenerateSchema(typeof(ProblemDetails), context.SchemaRepository),
                        },
                    },
                });
            }
        }
    }
}