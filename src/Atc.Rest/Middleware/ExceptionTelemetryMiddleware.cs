using System;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Threading.Tasks;
using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Http;

namespace Atc.Rest.Middleware
{
    [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Reviewed.")]
    public class ExceptionTelemetryMiddleware
    {
        private readonly RequestDelegate next;
        private readonly TelemetryClient client;

        public ExceptionTelemetryMiddleware(RequestDelegate next, TelemetryClient client)
        {
            this.next = next;
            this.client = client;
        }

        public Task Invoke(HttpContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

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
}