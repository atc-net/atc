using System;
using System.Linq;
using Atc.Rest.Extended.Versioning;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

// ReSharper disable UseDeconstruction
namespace Atc.Rest.Extended.Filters
{
    public class ApiVersionDocumentFilter : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            if (swaggerDoc == null)
            {
                throw new ArgumentNullException(nameof(swaggerDoc));
            }

            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            RemoveParameter(swaggerDoc, context, BindingSource.Header, ApiVersionConstants.ApiVersionHeaderParameter);
            RemoveParameter(swaggerDoc, context, BindingSource.Query, ApiVersionConstants.ApiVersionQueryParameterShort);
        }

        private static void RemoveParameter(
            OpenApiDocument swaggerDoc,
            DocumentFilterContext context,
            BindingSource parameterBindingSource,
            string parameterName)
        {
            foreach (var apiDescription in context.ApiDescriptions)
            {
                var apiParameterDescription = apiDescription.ParameterDescriptions.FirstOrDefault(
                    x => x.Source == parameterBindingSource &&
                         x.Name == parameterName);
                if (apiParameterDescription != null)
                {
                    apiDescription.ParameterDescriptions.Remove(apiParameterDescription);
                }
            }

            foreach (var swaggerDocPath in swaggerDoc.Paths)
            {
                foreach (var openApiOperation in swaggerDocPath.Value.Operations)
                {
                    var operation = openApiOperation.Value.Parameters.FirstOrDefault(x => x.Name == parameterName);
                    if (operation != null)
                    {
                        openApiOperation.Value.Parameters.Remove(operation);
                    }
                }
            }
        }
    }
}