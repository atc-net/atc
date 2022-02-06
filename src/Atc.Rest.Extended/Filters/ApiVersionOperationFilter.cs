namespace Atc.Rest.Extended.Filters;

public class ApiVersionOperationFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        if (operation is null)
        {
            throw new ArgumentNullException(nameof(operation));
        }

        if (context is null)
        {
            throw new ArgumentNullException(nameof(context));
        }

        var apiVersionParameter = operation
            .Parameters
            .FirstOrDefault(p => string.Equals(p.Name, ApiVersionConstants.ApiVersionQueryParameter, StringComparison.Ordinal));

        if (apiVersionParameter is not null)
        {
            ConfigureApiVersion(apiVersionParameter, context);
        }
    }

    protected void ConfigureApiVersion(OpenApiParameter apiVersionParameter, OperationFilterContext context)
    {
        if (apiVersionParameter is null)
        {
            throw new ArgumentNullException(nameof(apiVersionParameter));
        }

        if (context is null)
        {
            throw new ArgumentNullException(nameof(context));
        }

        var description = context.ApiDescription
            .ParameterDescriptions
            .First(p => string.Equals(p.Name, apiVersionParameter.Name, StringComparison.Ordinal));

        if (apiVersionParameter.Description is null)
        {
            apiVersionParameter.Description = description?.ModelMetadata?.Description;
        }

        if (apiVersionParameter.Schema.Default is null && description is not null)
        {
            apiVersionParameter.Schema.Default = new OpenApiString(description.DefaultValue.ToString());

            var openApiVersionList = new List<IOpenApiAny> { new OpenApiString(description.DefaultValue.ToString()) };
            apiVersionParameter.Schema.Enum = openApiVersionList;
        }

        if (description is not null)
        {
            apiVersionParameter.Required |= description.IsRequired;
        }
    }
}