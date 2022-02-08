namespace Atc.Rest.Extended.Options;

public class ConfigureApiVersioningOptions : IConfigureOptions<ApiVersioningOptions>
{
    private readonly TelemetryClient telemetry;

    public ConfigureApiVersioningOptions(TelemetryClient telemetry)
    {
        this.telemetry = telemetry;
    }

    public void Configure(ApiVersioningOptions options)
    {
        if (options is null)
        {
            throw new ArgumentNullException(nameof(options));
        }

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

        options.ErrorResponses = new VersionErrorResponseProvider(telemetry);
    }
}