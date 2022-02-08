// ReSharper disable once CheckNamespace
namespace Microsoft.AspNetCore.Http;

public static class AnonymousAccessExtensions
{
    public static IServiceCollection AddAnonymousAccessForDevelopment(this IServiceCollection services)
    {
        services.AddSingleton<IAuthorizationHandler, AllowAnonymousAccessForDevelopmentHandler>();
        return services;
    }
}