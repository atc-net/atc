namespace Atc.Rest.Extended.Options;

public class RestApiExtendedOptions : RestApiOptions
{
    public bool UseApiVersioning { get; set; } = true;

    public bool UseFluentValidation { get; set; } = true;

    public bool UseOpenApiSpec { get; set; } = true;

    public bool UseSwaggerUi { get; set; }

    public string? SwaggerUiTheme { get; set; } = "Dark";
}