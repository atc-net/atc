using System;
using Atc.Rest.Extended.Filters;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

// ReSharper disable once CheckNamespace
namespace Swashbuckle.AspNetCore.SwaggerGen
{
    public static class SwaggerGenOptionsExtensions
    {
        public static void ApplyApiVersioningFilters(this SwaggerGenOptions options)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            options.OperationFilterDescriptors.RemoveAll(f => typeof(ApiVersionOperationFilter).IsAssignableFrom(f.Type));
            options.OperationFilter<ApiVersionOperationFilter>();

            options.DocumentFilter<ApiVersionDocumentFilter>();
        }

        public static void ApplyApiVersioningSwaggerDocuments(this SwaggerGenOptions options, IServiceCollection services, string title)
        {
            var provider = services.BuildServiceProvider().GetRequiredService<IApiVersionDescriptionProvider>();
            foreach (var description in provider.ApiVersionDescriptions)
            {
                var info = new OpenApiInfo
                {
                    Title = title,
                    Version = description.ApiVersion.ToString(),
                };

                options.SwaggerDoc(description.GroupName, info);
            }
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