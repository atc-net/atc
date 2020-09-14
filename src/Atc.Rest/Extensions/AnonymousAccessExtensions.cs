using Atc.Rest.Options;
using Microsoft.Extensions.DependencyInjection;

// ReSharper disable once CheckNamespace
namespace Microsoft.AspNetCore.Http
{
    public static class AnonymousAccessExtensions
    {
        public static IServiceCollection AddAnonymousAccessForDevelopment(this IServiceCollection services)
        {
            services.AddSingleton<AllowAnonymousAccessForDevelopmentHandler>();
            return services;
        }
    }
}