namespace Atc.Rest.Tests.Middleware;

public class ExceptionTelemetryMiddlewareTests
{
    [Fact]
    public async Task InvokeAsync_WithTelemetryClient_ReturnsOk()
    {
        // Arrange
        var services = new ServiceCollection();
        using var telemetryConfiguration = new TelemetryConfiguration
        {
            ConnectionString = "InstrumentationKey=00000000-0000-0000-0000-000000000000",
        };
        services.AddSingleton(new TelemetryClient(telemetryConfiguration));
        var serviceProvider = services.BuildServiceProvider();

        var middleware = new ExceptionTelemetryMiddleware(
            async innerHttpContext => await innerHttpContext.Response.WriteAsync("test response body"));

        var defaultHttpContext = new DefaultHttpContext
        {
            RequestServices = serviceProvider,
        };

        // Act
        await middleware.InvokeAsync(defaultHttpContext);

        // Assert
        Assert.Equal((int)HttpStatusCode.OK, defaultHttpContext.Response.StatusCode);
    }

    [Fact]
    public async Task InvokeAsync_WithoutTelemetryClient_DoesNotThrowOnSuccess()
    {
        // Arrange — no TelemetryClient registered
        var services = new ServiceCollection();
        var serviceProvider = services.BuildServiceProvider();

        var middleware = new ExceptionTelemetryMiddleware(
            async innerHttpContext => await innerHttpContext.Response.WriteAsync("ok"));

        var defaultHttpContext = new DefaultHttpContext
        {
            RequestServices = serviceProvider,
        };

        // Act
        await middleware.InvokeAsync(defaultHttpContext);

        // Assert
        Assert.Equal((int)HttpStatusCode.OK, defaultHttpContext.Response.StatusCode);
    }

    [Fact]
    public async Task InvokeAsync_WithoutTelemetryClient_ExceptionYields500()
    {
        // Arrange — no TelemetryClient registered; pipeline throws
        var services = new ServiceCollection();
        var serviceProvider = services.BuildServiceProvider();

        var middleware = new ExceptionTelemetryMiddleware(
            _ => throw new InvalidOperationException("boom"));

        var defaultHttpContext = new DefaultHttpContext
        {
            RequestServices = serviceProvider,
        };

        // Act
        await middleware.InvokeAsync(defaultHttpContext);

        // Assert — 500 returned; no NRE from missing TelemetryClient
        Assert.Equal((int)HttpStatusCode.InternalServerError, defaultHttpContext.Response.StatusCode);
    }
}