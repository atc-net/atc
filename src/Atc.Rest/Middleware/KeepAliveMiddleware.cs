using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Atc.Rest.Middleware
{
    /// <summary>
    /// Middleware responsible for handling the App service keep alive ping on http://{host-endpoint}.
    /// If not enabled the application insights will report a failed request as the goes to http and not https.
    /// </summary>
    public class KeepAliveMiddleware
    {
        private readonly RequestDelegate next;

        public KeepAliveMiddleware(RequestDelegate next)
        {
            this.next = next;
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
            if (IsKeepAlivePing(context.Request))
            {
                context.Response.StatusCode = (int)HttpStatusCode.OK;
                await context.Response.WriteAsync(HttpStatusCode.OK.ToString());
                return;
            }

            await next(context);
        }

        private static bool IsKeepAlivePing(HttpRequest request)
        {
            return request.Path == "/" && request.Method == "GET" && !request.PathBase.HasValue;
        }
    }
}