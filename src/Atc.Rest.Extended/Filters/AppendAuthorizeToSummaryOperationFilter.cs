namespace Atc.Rest.Extended.Filters;

/// <summary>
/// Swagger <see cref="IOperationFilter"/> that appends authorization information to operation summaries.
/// Adds roles and policies from <see cref="AuthorizeAttribute"/> to the operation summary for documentation purposes.
/// </summary>
internal sealed class AppendAuthorizeToSummaryOperationFilter : IOperationFilter
{
    /// <summary>
    /// Applies the filter to append authorization information to the operation summary.
    /// </summary>
    /// <param name="operation">The <see cref="OpenApiOperation"/> to modify.</param>
    /// <param name="context">The <see cref="OperationFilterContext"/> containing operation metadata.</param>
    public void Apply(
        OpenApiOperation operation,
        OperationFilterContext context)
    {
        ArgumentNullException.ThrowIfNull(operation);
        ArgumentNullException.ThrowIfNull(context);

        if (context.AnyControllerAndActionAttributes<AllowAnonymousAttribute>())
        {
            return;
        }

        var authorizeAttributes = context.GetControllerAndActionAttributesAsList<AuthorizeAttribute>();

        if (!authorizeAttributes.Any())
        {
            return;
        }

        AppendPoliciesAndRolesToSummaryIfAny(authorizeAttributes, operation);
    }

    private static void AppendPoliciesAndRolesToSummaryIfAny(
        IReadOnlyCollection<AuthorizeAttribute> authorizeAttributes,
        OpenApiOperation operation)
    {
        var policies = GetPolicies(authorizeAttributes).ToList();
        var roles = GetRoles(authorizeAttributes).ToList();

        if (!policies.Any() && !roles.Any())
        {
            return;
        }

        var authSummary = new StringBuilder(" (Auth");

        if (roles.Any())
        {
            authSummary.Append(GlobalizationConstants.EnglishCultureInfo, $" roles: {string.Join(", ", roles)};");
        }

        if (policies.Any())
        {
            authSummary.Append(GlobalizationConstants.EnglishCultureInfo, $" policies: {string.Join(", ", policies)};");
        }

        operation.Summary += authSummary
            .ToString()
            .TrimEnd(';') + ")";
    }

    private static IEnumerable<string?> GetPolicies(
        IEnumerable<AuthorizeAttribute> authAttributes)
        => authAttributes
            .Where(x => !string.IsNullOrEmpty(x.Policy))
            .Select(x => x.Policy);

    private static IEnumerable<string?> GetRoles(
        IEnumerable<AuthorizeAttribute> authAttributes)
        => authAttributes
            .Where(x => !string.IsNullOrEmpty(x.Roles))
            .Select(x => x.Roles);
}