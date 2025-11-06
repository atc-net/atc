namespace Atc.Rest.Extended.Options;

/// <summary>
/// Extended options for configuring REST API features including API versioning, OpenAPI/Swagger, and FluentValidation.
/// Extends <see cref="RestApiOptions"/> with additional configuration for extended features.
/// </summary>
public class RestApiExtendedOptions : RestApiOptions
{
    /// <summary>
    /// Gets or sets a value indicating whether API versioning should be enabled.
    /// Default is true.
    /// </summary>
    public bool UseApiVersioning { get; set; } = true;

    /// <summary>
    /// Gets or sets a value indicating whether FluentValidation should be enabled.
    /// Default is true.
    /// </summary>
    public bool UseFluentValidation { get; set; } = true;

    /// <summary>
    /// Gets or sets a value indicating whether OpenAPI specification generation should be enabled.
    /// Default is true.
    /// </summary>
    public bool UseOpenApiSpec { get; set; } = true;

    /// <summary>
    /// Gets or sets a value indicating whether Swagger UI should be enabled.
    /// Default is false.
    /// </summary>
    public bool UseSwaggerUi { get; set; }

    /// <summary>
    /// Gets or sets the Swagger UI theme to use. Can be "Light", "Dark", or a custom CSS file path.
    /// Default is "Dark".
    /// </summary>
    public string? SwaggerUiTheme { get; set; } = "Dark";
}