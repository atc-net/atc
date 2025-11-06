// ReSharper disable UseDeconstruction
namespace Atc.Rest.Extended.Filters;

/// <summary>
/// Swagger <see cref="IDocumentFilter"/> that removes API version parameters from the OpenAPI document.
/// Cleans up version parameters that appear in headers and query strings to avoid duplication.
/// </summary>
public class ApiVersionDocumentFilter : IDocumentFilter
{
    /// <summary>
    /// Applies the filter to remove API version parameters from the Swagger document.
    /// </summary>
    /// <param name="swaggerDoc">The <see cref="OpenApiDocument"/> to modify.</param>
    /// <param name="context">The <see cref="DocumentFilterContext"/> containing API descriptions.</param>
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