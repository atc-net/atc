namespace Atc.Rest.Extensions;

public class AllowAnonymousAccessForDevelopmentHandler : IAuthorizationHandler
{
    private readonly IWebHostEnvironment environment;
    private readonly RestApiOptions apiOptions;

    public AllowAnonymousAccessForDevelopmentHandler(
        IWebHostEnvironment environment,
        RestApiOptions apiOptions)
    {
        this.environment = environment ?? throw new ArgumentNullException(nameof(environment));
        this.apiOptions = apiOptions ?? throw new ArgumentNullException(nameof(apiOptions));
    }

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