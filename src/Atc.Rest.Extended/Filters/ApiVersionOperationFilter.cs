// ReSharper disable ConstantConditionalAccessQualifier
namespace Atc.Rest.Extended.Filters;

public class ApiVersionOperationFilter : IOperationFilter
{
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