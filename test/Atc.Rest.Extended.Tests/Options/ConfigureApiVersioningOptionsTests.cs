namespace Atc.Rest.Extended.Tests.Options;

public class ConfigureApiVersioningOptionsTests
{
    [Fact]
    public void Constructor_WithoutTelemetry_DoesNotThrow()
    {
        // TelemetryClient was injected but never used, causing DI failure for consumers
        // without App Insights. ConfigureApiVersioningOptions must be instantiable without it.
        var exception = Record.Exception(() => new ConfigureApiVersioningOptions());
        Assert.Null(exception);
    }

    [Fact]
    public void Implements_IConfigureOptions_ApiVersioningOptions()
        => typeof(ConfigureApiVersioningOptions)
            .Should().Implement<IConfigureOptions<ApiVersioningOptions>>();
}