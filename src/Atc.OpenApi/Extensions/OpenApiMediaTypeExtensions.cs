// ReSharper disable once CheckNamespace
namespace Microsoft.OpenApi.Models;

/// <summary>
/// Extension methods for <see cref="OpenApiMediaType"/> dictionaries.
/// </summary>
public static class OpenApiMediaTypeExtensions
{
    /// <summary>
    /// Retrieves the <see cref="OpenApiSchema"/> from the content dictionary for the specified content type.
    /// </summary>
    /// <param name="content">The dictionary of media types and their schemas.</param>
    /// <param name="contentType">The content type to retrieve the schema for. Defaults to application/json.</param>
    /// <returns>The <see cref="OpenApiSchema"/> for the specified content type, or null if not found.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="content"/> is null.</exception>
    public static OpenApiSchema? GetSchema(this IDictionary<string, OpenApiMediaType> content, string contentType = MediaTypeNames.Application.Json)
    {
        if (content is null)
        {
            throw new ArgumentNullException(nameof(content));
        }

        var (key, value) = content.FirstOrDefault(x => string.Equals(x.Key, contentType, StringComparison.Ordinal));
        return key is null
            ? null
            : value.Schema;
    }

    /// <summary>
    /// Retrieves the <see cref="OpenApiSchema"/> from the first media type in the content dictionary.
    /// </summary>
    /// <param name="content">The dictionary of media types and their schemas.</param>
    /// <returns>The <see cref="OpenApiSchema"/> from the first media type, or null if the dictionary is empty.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="content"/> is null.</exception>
    public static OpenApiSchema? GetSchemaByFirstMediaType(this IDictionary<string, OpenApiMediaType> content)
    {
        if (content is null)
        {
            throw new ArgumentNullException(nameof(content));
        }

        var (key, value) = content.FirstOrDefault();
        return key is null
            ? null
            : value.Schema;
    }
}