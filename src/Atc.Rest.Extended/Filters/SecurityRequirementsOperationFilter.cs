using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Atc.Rest.Extended.Filters
{
    public class SecurityRequirementsOperationFilter : IOperationFilter
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

            // Policy names map to scopes
            var requiredScopes = context.MethodInfo
                .GetCustomAttributes(true)
                .OfType<AuthorizeAttribute>()
                .Select(attr => attr.Policy)
                .Distinct()
                .ToList();

            if (!requiredScopes.Any())
            {
                return;
            }

            operation.Responses.Add("401", new OpenApiResponse { Description = "Unauthorized - Request was valid but the calling user does not have the required role" });
            operation.Responses.Add("403", new OpenApiResponse { Description = "Forbidden - The request was valid, but the server is refusing action. The user might not have the necessary permissions for a resource" });

            var oAuthScheme = new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "oauth2",
                },
            };

            operation.Security = new List<OpenApiSecurityRequirement>
            {
                new OpenApiSecurityRequirement
                {
                    [oAuthScheme] = requiredScopes,
                },
            };
        }
    }
}