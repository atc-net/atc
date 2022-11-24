// ReSharper disable UseDeconstruction
namespace Atc.Rest.Extended.Filters;

public class ApiVersionDocumentFilter : IDocumentFilter
{
    public void Apply(
        OpenApiDocument swaggerDoc,
        DocumentFilterContext context)
    {
        ArgumentNullException.ThrowIfNull(swaggerDoc);
        ArgumentNullException.ThrowIfNull(context);

        RemoveParameter(swaggerDoc, context, BindingSource.Header, ApiVersionConstants.ApiVersionHeaderParameter);
        RemoveParameter(swaggerDoc, context, BindingSource.Query, ApiVersionConstants.ApiVersionQueryParameterShort);
    }

    private static void RemoveParameter(
        OpenApiDocument swaggerDoc,
        DocumentFilterContext context,
        BindingSource parameterBindingSource,
        string parameterName)
    {
        foreach (var apiDescription in context.ApiDescriptions)
        {
            var apiParameterDescription = apiDescription.ParameterDescriptions.FirstOrDefault(x =>
                x.Source == parameterBindingSource &&
                string.Equals(x.Name, parameterName, StringComparison.Ordinal));

            if (apiParameterDescription is not null)
            {
                apiDescription.ParameterDescriptions.Remove(apiParameterDescription);
            }
        }

        foreach (var swaggerDocPath in swaggerDoc.Paths)
        {
            foreach (var openApiOperation in swaggerDocPath.Value.Operations)
            {
                var operation = openApiOperation.Value.Parameters.FirstOrDefault(x => string.Equals(x.Name, parameterName, StringComparison.Ordinal));
                if (operation is not null)
                {
                    openApiOperation.Value.Parameters.Remove(operation);
                }
            }
        }
    }
}