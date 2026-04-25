namespace Atc.Rest.Tests.Filters;

public class ErrorHandlingExceptionFilterAttributeTests
{
    [Fact]
    public void OnException_AbortedRequest_DoesNotComposeResponseBody()
    {
        // Arrange
        using var telemetryConfiguration = new TelemetryConfiguration();
        var telemetryClient = new TelemetryClient(telemetryConfiguration);
        var options = new RestApiOptions();
        var sut = new ErrorHandlingExceptionFilterAttribute(telemetryClient, options);

        var httpContext = new DefaultHttpContext();
        using var aborted = new CancellationTokenSource();
        aborted.Cancel();
        httpContext.RequestAborted = aborted.Token;

        var actionContext = new ActionContext(
            httpContext,
            new Microsoft.AspNetCore.Routing.RouteData(),
            new Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor());
        var exceptionContext = new ExceptionContext(
            actionContext,
            new List<IFilterMetadata>())
        {
            Exception = new InvalidOperationException("Should not be serialized"),
        };

        // Act
        sut.OnException(exceptionContext);

        // Assert
        Assert.True(exceptionContext.ExceptionHandled);
        Assert.Null(exceptionContext.Result);
    }

    [Fact]
    public void OnException_LiveRequest_ComposesResponseBody()
    {
        // Arrange
        using var telemetryConfiguration = new TelemetryConfiguration();
        var telemetryClient = new TelemetryClient(telemetryConfiguration);
        var options = new RestApiOptions();
        var sut = new ErrorHandlingExceptionFilterAttribute(telemetryClient, options);

        var httpContext = new DefaultHttpContext();

        var actionContext = new ActionContext(
            httpContext,
            new Microsoft.AspNetCore.Routing.RouteData(),
            new Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor());
        var exceptionContext = new ExceptionContext(
            actionContext,
            new List<IFilterMetadata>())
        {
            Exception = new InvalidOperationException("kapow"),
        };

        // Act
        sut.OnException(exceptionContext);

        // Assert
        Assert.True(exceptionContext.ExceptionHandled);
        Assert.NotNull(exceptionContext.Result);
        var content = Assert.IsType<ContentResult>(exceptionContext.Result);
        Assert.Equal((int)HttpStatusCode.Conflict, content.StatusCode);
    }
}