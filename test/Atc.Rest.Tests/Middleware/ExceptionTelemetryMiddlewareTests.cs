using System.Net;
using System.Threading.Tasks;
using Atc.Rest.Middleware;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.AspNetCore.Http;
using Xunit;

namespace Atc.Rest.Tests.Middleware
{
    public class ExceptionTelemetryMiddlewareTests
    {
        [Fact]
        public async Task Invoke()
        {
            // Arrange
            using var telemetryConfiguration = new TelemetryConfiguration();
            var telemetryClient = new TelemetryClient(telemetryConfiguration);
            var middleware = new ExceptionTelemetryMiddleware(
                async (innerHttpContext) =>
                {
                    await innerHttpContext.Response.WriteAsync("test response body");
                },
                telemetryClient);
            var defaultHttpContext = new DefaultHttpContext();

            // Act
            await middleware.Invoke(defaultHttpContext);

            // Assert
            Assert.Equal((int)HttpStatusCode.OK, defaultHttpContext.Response.StatusCode);
        }
    }
}