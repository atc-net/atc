using System;
using System.Collections.Generic;
using System.Text.Json;
using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;

namespace Atc.Rest.Extended.Versioning
{
    public class VersionErrorResponseProvider : IErrorResponseProvider
    {
        private readonly TelemetryClient telemetry;

        public VersionErrorResponseProvider(TelemetryClient telemetry)
        {
            this.telemetry = telemetry;
        }

        public IActionResult CreateResponse(ErrorResponseContext context)
        {
            if (context is null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var detail = new ValidationProblemDetails(
                new Dictionary<string, string[]>(StringComparer.Ordinal)
                {
                    { context.ErrorCode, new[] { context.Message } },
                });

            telemetry.TrackTrace(
                "BadVersion",
                new Dictionary<string, string>(StringComparer.Ordinal)
                {
                    { "Response.Body", JsonSerializer.Serialize(detail) },
                });

            return new BadRequestObjectResult(detail);
        }
    }
}