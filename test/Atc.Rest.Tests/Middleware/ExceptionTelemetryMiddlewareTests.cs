namespace Atc.Rest.Tests.Middleware;

public class ExceptionTelemetryMiddlewareTests
{
    [Fact]
    public async Task InvokeAsync()
    {
        // Arrange
        using var telemetryConfiguration = new TelemetryConfiguration();
        var telemetryClient = new TelemetryClient(telemetryConfiguration);
        var middleware = new ExceptionTelemetryMiddleware(
            async innerHttpContext =>
            {
                await innerHttpContext.Response.WriteAsync("test response body");
            },
            telemetryClient);
        var defaultHttpContext = new DefaultHttpContext();

        // Act
        await middleware.InvokeAsync(defaultHttpContext);

        // Assert
        Assert.Equal((int)HttpStatusCode.OK, defaultHttpContext.Response.StatusCode);
    }
}