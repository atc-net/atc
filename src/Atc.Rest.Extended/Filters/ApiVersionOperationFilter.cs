using System;
using System.Collections.Generic;
using System.Linq;
using Atc.Rest.Extended.Versioning;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Atc.Rest.Extended.Filters
{
    public class ApiVersionOperationFilter : IOperationFilter
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

            var apiVersionParameter = operation
                .Parameters
                .FirstOrDefault(p => string.Equals(p.Name, ApiVersionConstants.ApiVersionQueryParameter, StringComparison.Ordinal));

            if (apiVersionParameter != null)
            {
                ConfigureApiVersion(apiVersionParameter, context);
            }
        }

        protected void ConfigureApiVersion(OpenApiParameter apiVersionParameter, OperationFilterContext context)
        {
            if (apiVersionParameter == null)
            {
                throw new ArgumentNullException(nameof(apiVersionParameter));
            }

            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var description = context.ApiDescription
                .ParameterDescriptions
                .First(p => string.Equals(p.Name, apiVersionParameter.Name, StringComparison.Ordinal));

            if (apiVersionParameter.Description == null)
            {
                apiVersionParameter.Description = description?.ModelMetadata?.Description;
            }

            if (apiVersionParameter.Schema.Default == null && description != null)
            {
                apiVersionParameter.Schema.Default = new OpenApiString(description.DefaultValue.ToString());

                var openApiVersionList = new List<IOpenApiAny> { new OpenApiString(description.DefaultValue.ToString()) };
                apiVersionParameter.Schema.Enum = openApiVersionList;
            }

            if (description != null)
            {
                apiVersionParameter.Required |= description.IsRequired;
            }
        }
    }
}