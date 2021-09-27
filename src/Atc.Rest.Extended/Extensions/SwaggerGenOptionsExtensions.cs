using System;
using Atc.Rest.Extended.Filters;
using Microsoft.Extensions.DependencyInjection;

// ReSharper disable once CheckNamespace
namespace Swashbuckle.AspNetCore.SwaggerGen
{
    public static class SwaggerGenOptionsExtensions
    {
        public static void ApplyApiVersioningFilters(this SwaggerGenOptions options)
        {
            if (options is null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            options.OperationFilterDescriptors.RemoveAll(f => typeof(ApiVersionOperationFilter).IsAssignableFrom(f.Type));
            options.OperationFilter<ApiVersionOperationFilter>();

            options.DocumentFilter<ApiVersionDocumentFilter>();
        }

        public static void DefaultResponseForSecuredOperations(this SwaggerGenOptions options)
        {
            options.OperationFilter<AuthorizeResponseOperationFilter>();
        }

        public static void TreatBadRequestAsDefaultResponse(this SwaggerGenOptions options)
        {
            options.OperationFilter<DefaultResponseOperationFilter>();
        }
    }
}