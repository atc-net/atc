using Atc.Rest.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;

// ReSharper disable once CheckNamespace
namespace Microsoft.AspNetCore.Http
{
    public static class AnonymousAccessExtensions
    {
        public static IServiceCollection AddAnonymousAccessForDevelopment(this IServiceCollection services)
        {
            services.AddSingleton<IAuthorizationHandler, AllowAnonymousAccessForDevelopmentHandler>();
            return services;
        }
    }
}