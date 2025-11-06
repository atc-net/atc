// ReSharper disable ConstantConditionalAccessQualifier
namespace Atc.Rest.Extended.Filters;

/// <summary>
/// Swagger <see cref="IOperationFilter"/> that configures API version parameters in OpenAPI operations.
/// Sets default values and enumerates available versions for version parameters.
/// </summary>
public class ApiVersionOperationFilter : IOperationFilter
{
    /// <summary>
    /// Applies the filter to configure API version parameters in the operation.
    /// </summary>
    /// <param name="operation">The <see cref="OpenApiOperation"/> to modify.</param>
    /// <param name="context">The <see cref="OperationFilterContext"/> containing operation metadata.</param>
    public void Apply(
        OpenApiOperation operation,
        OperationFilterContext context)
    {
        ArgumentNullException.ThrowIfNull(operation);
        ArgumentNullException.ThrowIfNull(context);

        var apiVersionParameter = operation
            .Parameters
            .FirstOrDefault(p => string.Equals(p.Name, ApiVersionConstants.ApiVersionQueryParameter, StringComparison.Ordinal));

        if (apiVersionParameter is not null)
        {
            ConfigureApiVersion(apiVersionParameter, context);
        }
    }

    /// <summary>
    /// Configures the API version parameter with description, default value, and required flag.
    /// </summary>
    /// <param name="apiVersionParameter">The API version parameter to configure.</param>
    /// <param name="context">The <see cref="OperationFilterContext"/> containing parameter descriptions.</param>
    protected static void ConfigureApiVersion(
        OpenApiParameter apiVersionParameter,
        OperationFilterContext context)
    {
        ArgumentNullException.ThrowIfNull(apiVersionParameter);
        ArgumentNullException.ThrowIfNull(context);

        var description = context.ApiDescription
            .ParameterDescriptions
            .First(p => string.Equals(p.Name, apiVersionParameter.Name, StringComparison.Ordinal));

        apiVersionParameter.Description ??= description?.ModelMetadata?.Description;

        if (apiVersionParameter.Schema.Default is null && description is not null)
        {
            apiVersionParameter.Schema.Default = new OpenApiString(description.DefaultValue!.ToString());

            var openApiVersionList = new List<IOpenApiAny> { new OpenApiString(description.DefaultValue.ToString()) };
            apiVersionParameter.Schema.Enum = openApiVersionList;
        }

        if (description is not null)
        {
            apiVersionParameter.Required |= description.IsRequired;
        }
    }
}