namespace Atc.Rest.Middleware;

public class ExceptionTelemetryMiddleware
{
    private readonly RequestDelegate next;
    private readonly TelemetryClient client;

    public ExceptionTelemetryMiddleware(RequestDelegate next, TelemetryClient client)
    {
        this.next = next;
        this.client = client;
    }

    public Task InvokeAsync(HttpContext context)
    {
        ArgumentNullException.ThrowIfNull(context);

        return InternalInvokeAsync(context);
    }

    private async Task InternalInvokeAsync(HttpContext context)
    {
        var requestFailed = false;

        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            client.TrackException(ex);

            if (context.Response.HasStarted)
            {
                throw;
            }

            requestFailed = true;
        }

        if (requestFailed)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await context
                .Response
                .WriteAsync($"Something is broken. Please contact the development team with the value of the returned header named '{WellKnownHttpHeaders.CorrelationId}'");
        }
    }
}