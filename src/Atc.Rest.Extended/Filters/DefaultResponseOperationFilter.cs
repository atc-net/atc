namespace Atc.Rest.Extended.Filters;

/// <summary>
/// Bad request as default response.
/// </summary>
/// <remarks>
/// REF: https://github.com/domaindrivendev/Swashbuckle.AspNetCore/issues/1278 .
/// </remarks>
/// <seealso cref="Swashbuckle.AspNetCore.SwaggerGen.IOperationFilter" />
public class DefaultResponseOperationFilter : IOperationFilter
{
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