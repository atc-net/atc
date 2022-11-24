namespace Atc.Rest.Extended.Filters;

internal sealed class AppendAuthorizeToSummaryOperationFilter : IOperationFilter
{
    public void Apply(
        OpenApiOperation operation,
        OperationFilterContext context)
    {
        ArgumentNullException.ThrowIfNull(operation);
        ArgumentNullException.ThrowIfNull(context);

        if (context.GetControllerAndActionAttributes<AllowAnonymousAttribute>().Any())
        {
            return;
        }

        var authorizeAttributes = context.GetControllerAndActionAttributes<AuthorizeAttribute>().ToList();
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

        operation.Summary += authSummary.ToString().TrimEnd(';') + ")";
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