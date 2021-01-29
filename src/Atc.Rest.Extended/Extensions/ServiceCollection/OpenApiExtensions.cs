using System;
using System.IO;
using Atc.Rest.Extended.Filters;
using Atc.Rest.Extended.Options;
using Microsoft.AspNetCore.Mvc.Controllers;
using Swashbuckle.AspNetCore.SwaggerGen;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection
{
    public static class OpenApiExtensions
    {
        [Obsolete]
        public static IServiceCollection AddOpenApiSpec<TStartup>(this IServiceCollection services)
        {
            return services;
        }

        [Obsolete]
        public static IServiceCollection AddOpenApiSpec<TStartup>(
            this IServiceCollection services,
            RestApiExtendedOptions restApiOptions)
        {
            return services;
        }

        [Obsolete]
        public static IServiceCollection AddOpenApiSpec<TStartup>(
            this IServiceCollection services,
            RestApiExtendedOptions restApiOptions,
            Action<SwaggerGenOptions> setupAction)
        {
            return services;
        }
    }
}