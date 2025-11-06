namespace Atc.Rest.Extensions;

/// <summary>
/// Authorization handler that allows anonymous access to all endpoints in the Development environment.
/// </summary>
/// <remarks>
/// This handler bypasses authorization requirements when both the application is in Development mode
/// and <see cref="RestApiOptions.AllowAnonymousAccessForDevelopment"/> is enabled.
/// </remarks>
public class AllowAnonymousAccessForDevelopmentHandler : IAuthorizationHandler
{
    private readonly IWebHostEnvironment environment;
    private readonly RestApiOptions apiOptions;

    /// <summary>
    /// Initializes a new instance of the <see cref="AllowAnonymousAccessForDevelopmentHandler"/> class.
    /// </summary>
    /// <param name="environment">The web host environment.</param>
    /// <param name="apiOptions">The REST API configuration options.</param>
    public AllowAnonymousAccessForDevelopmentHandler(
        IWebHostEnvironment environment,
        RestApiOptions apiOptions)
    {
        this.environment = environment ?? throw new ArgumentNullException(nameof(environment));
        this.apiOptions = apiOptions ?? throw new ArgumentNullException(nameof(apiOptions));
    }

    /// <summary>
    /// Handles authorization by succeeding all pending requirements in Development mode.
    /// </summary>
    /// <param name="context">The authorization handler context.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public Task HandleAsync(AuthorizationHandlerContext context)
    {
        ArgumentNullException.ThrowIfNull(context);

        if (!apiOptions.AllowAnonymousAccessForDevelopment || !environment.IsDevelopment())
        {
            return Task.CompletedTask;
        }

        foreach (var requirement in context.PendingRequirements.ToList())
        {
            context.Succeed(requirement);
        }

        return Task.CompletedTask;
    }
}