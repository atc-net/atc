// ReSharper disable once CheckNamespace
namespace Swashbuckle.AspNetCore.SwaggerGen;

/// <summary>
/// Extension methods for <see cref="SwaggerGenOptions"/> to apply common operation filters.
/// </summary>
public static class SwaggerGenOptionsExtensions
{
    /// <summary>
    /// Applies API versioning filters to Swagger generation, including operation and document filters.
    /// Removes any existing <see cref="ApiVersionOperationFilter"/> before adding the custom one.
    /// </summary>
    /// <param name="options">The <see cref="SwaggerGenOptions"/> instance.</param>
    public static void ApplyApiVersioningFilters(this SwaggerGenOptions options)
    {
        ArgumentNullException.ThrowIfNull(options);

        options.OperationFilterDescriptors.RemoveAll(f => typeof(ApiVersionOperationFilter).IsAssignableFrom(f.Type));
        options.OperationFilter<ApiVersionOperationFilter>();
        options.DocumentFilter<ApiVersionDocumentFilter>();
    }

    /// <summary>
    /// Adds default 401 and 403 response codes to operations that require authorization.
    /// </summary>
    /// <param name="options">The <see cref="SwaggerGenOptions"/> instance.</param>
    public static void DefaultResponseForSecuredOperations(
        this SwaggerGenOptions options)
        => options.OperationFilter<AuthorizeResponseOperationFilter>();

    /// <summary>
    /// Adds a default response with <see cref="ProblemDetails"/> schema for operations that don't have one.
    /// </summary>
    /// <param name="options">The <see cref="SwaggerGenOptions"/> instance.</param>
    public static void TreatBadRequestAsDefaultResponse(
        this SwaggerGenOptions options)
        => options.OperationFilter<DefaultResponseOperationFilter>();
}