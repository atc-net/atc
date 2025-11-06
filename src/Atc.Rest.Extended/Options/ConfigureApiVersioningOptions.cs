namespace Atc.Rest.Extended.Options;

/// <summary>
/// Configures API versioning options for ASP.NET Core API versioning.
/// Sets up version readers for header, media type, query string, and URL segment versioning.
/// </summary>
public class ConfigureApiVersioningOptions : IConfigureOptions<ApiVersioningOptions>
{
    private readonly TelemetryClient telemetry;

    /// <summary>
    /// Initializes a new instance of the <see cref="ConfigureApiVersioningOptions"/> class.
    /// </summary>
    /// <param name="telemetry">The Application Insights telemetry client.</param>
    public ConfigureApiVersioningOptions(TelemetryClient telemetry)
    {
        this.telemetry = telemetry;
    }

    /// <summary>
    /// Configures the API versioning options with multiple version reading strategies.
    /// </summary>
    /// <param name="options">The <see cref="ApiVersioningOptions"/> to configure.</param>
    public void Configure(ApiVersioningOptions options)
    {
        ArgumentNullException.ThrowIfNull(options);

        // Specify the default API Version
        options.DefaultApiVersion = new ApiVersion(1, 0);

        // If the client hasn't specified the API version in the request, use the default API version number
        options.AssumeDefaultVersionWhenUnspecified = true;

        // Advertise the API versions supported for the particular endpoint
        options.ReportApiVersions = true;

        //// DEFAULT Version reader is QueryStringApiVersionReader();
        //// clients request the specific version using the x-api-version header
        //// Supporting multiple versioning scheme
        options.ApiVersionReader = ApiVersionReader.Combine(
            new HeaderApiVersionReader(ApiVersionConstants.ApiVersionHeaderParameter),
            new MediaTypeApiVersionReader(ApiVersionConstants.ApiVersionMediaTypeParameter),
            new QueryStringApiVersionReader(ApiVersionConstants.ApiVersionQueryParameter),
            new QueryStringApiVersionReader(ApiVersionConstants.ApiVersionQueryParameterShort),
            new UrlSegmentApiVersionReader());
    }
}