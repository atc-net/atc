namespace Atc.Rest.Extended.Filters;

/// <summary>
/// Swagger <see cref="IOperationFilter"/> that adds 401 and 403 response codes to operations requiring authorization.
/// Automatically documents authentication and authorization responses for secured endpoints.
/// </summary>
public class AuthorizeResponseOperationFilter : IOperationFilter
{
    /// <summary>
    /// Applies the filter to add authorization response codes to the operation.
    /// </summary>
    /// <param name="operation">The <see cref="OpenApiOperation"/> to modify.</param>
    /// <param name="context">The <see cref="OperationFilterContext"/> containing operation metadata.</param>
    public void Apply(
        OpenApiOperation operation,
        OperationFilterContext context)
    {
        ArgumentNullException.ThrowIfNull(operation);
        ArgumentNullException.ThrowIfNull(context);

        var controller = context.ApiDescription.ActionDescriptor as ControllerActionDescriptor;
        var attributes = controller?.ControllerTypeInfo.GetCustomAttributes(inherit: true);

        var controllerAuthorized = attributes?
            .OfType<AuthorizeAttribute>()
            .Any() ?? false;

        var actionAuthorized = context
            .MethodInfo
            .GetCustomAttributes(inherit: true)
            .OfType<AuthorizeAttribute>()
            .Any();

        var actionAllowAnonymous = context
            .MethodInfo
            .GetCustomAttributes(inherit: true)
            .OfType<AllowAnonymousAttribute>()
            .Any();

        if (actionAllowAnonymous || (!controllerAuthorized && !actionAuthorized))
        {
            return;
        }

        operation.Responses ??= new OpenApiResponses();
        operation.Responses["401"] = new OpenApiResponse { Description = "Request was valid but the calling user does not have the required role" };
        operation.Responses["403"] = new OpenApiResponse { Description = "The request was valid, but the server is refusing action. The user might not have the necessary permissions for a resource" };
    }
}