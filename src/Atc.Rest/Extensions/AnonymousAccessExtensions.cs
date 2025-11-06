// ReSharper disable once CheckNamespace
namespace Microsoft.AspNetCore.Http;

/// <summary>
/// Extension methods for configuring anonymous access in development environments.
/// </summary>
public static class AnonymousAccessExtensions
{
    /// <summary>
    /// Registers an authorization handler that allows anonymous access to all endpoints in Development mode.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <returns>The service collection for method chaining.</returns>
    public static IServiceCollection AddAnonymousAccessForDevelopment(this IServiceCollection services)
    {
        services.AddSingleton<IAuthorizationHandler, AllowAnonymousAccessForDevelopmentHandler>();
        return services;
    }
}