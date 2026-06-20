namespace Atc.Rest.Tests.Options;

public class ConfigureApiBehaviorOptionsTests
{
    [Fact]
    public void Constructor_WithoutTelemetry_DoesNotThrow()
    {
        // TelemetryClient is optional; when App Insights is not registered, the class
        // must still be constructable so DI doesn't fail on startup.
        var exception = Record.Exception(() => new ConfigureApiBehaviorOptions());
        Assert.Null(exception);
    }

    [Fact]
    public void Configure_WithoutTelemetry_SetsExpectedBehaviorOptions()
    {
        var sut = new ConfigureApiBehaviorOptions();
        var options = new ApiBehaviorOptions();

        sut.Configure(options);

        Assert.True(options.SuppressInferBindingSourcesForParameters);
        Assert.NotNull(options.InvalidModelStateResponseFactory);
    }
}