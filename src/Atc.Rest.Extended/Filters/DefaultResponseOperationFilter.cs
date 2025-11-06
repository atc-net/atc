namespace Atc.Rest.Extended.Filters;

/// <summary>
/// Swagger <see cref="IOperationFilter"/> that adds a default response with <see cref="ProblemDetails"/> to operations.
/// Ensures all operations have a documented error response format.
/// </summary>
/// <remarks>
/// Reference: https://github.com/domaindrivendev/Swashbuckle.AspNetCore/issues/1278.
/// </remarks>
public class DefaultResponseOperationFilter : IOperationFilter
{
    /// <summary>
    /// Applies the filter to add a default response to the operation if not already present.
    /// </summary>
    /// <param name="operation">The <see cref="OpenApiOperation"/> to modify.</param>
    /// <param name="context">The <see cref="OperationFilterContext"/> containing operation metadata.</param>
    public void Apply(
        OpenApiOperation operation,
        OperationFilterContext context)
    {
        ArgumentNullException.ThrowIfNull(operation);
        ArgumentNullException.ThrowIfNull(context);

        operation.Responses ??= new OpenApiResponses();

        if (!operation.Responses.ContainsKey("default"))
        {
            operation.Responses.Add("default", new OpenApiResponse
            {
                Description = "Problem response",
                Content = new Dictionary<string, OpenApiMediaType>(StringComparer.Ordinal)
                {
                    [MediaTypeNames.Application.Json] = new()
                    {
                        Schema = context.SchemaGenerator.GenerateSchema(typeof(ProblemDetails), context.SchemaRepository),
                    },
                },
            });
        }
    }
}