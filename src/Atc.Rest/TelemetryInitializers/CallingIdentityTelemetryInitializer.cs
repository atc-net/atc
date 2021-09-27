using System;
using Atc.Rest;
using Microsoft.ApplicationInsights.Channel;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.AspNetCore.Http;

// ReSharper disable once CheckNamespace
namespace Microsoft.ApplicationInsights.Extensibility
{
    /// <summary>
    /// Responsible for adding per request property info to all telemetry.
    /// </summary>
    public class CallingIdentityTelemetryInitializer : ITelemetryInitializer
    {
        private readonly IRequestContext context;

        public CallingIdentityTelemetryInitializer(IRequestContext context)
        {
            this.context = context;
        }

        public void Initialize(ITelemetry telemetry)
        {
            if (telemetry is null)
            {
                throw new ArgumentNullException(nameof(telemetry));
            }

            telemetry.Context.User.AuthenticatedUserId = context.CallingIdentity;
            if (telemetry is not ISupportProperties sp)
            {
                return;
            }

            sp.Properties[WellKnownHttpHeaders.OnBehalfOf] = context.OnBehalfOfIdentity;
            sp.Properties[WellKnownHttpHeaders.CallingIdentity] = context.CallingIdentity;
            sp.Properties[WellKnownHttpHeaders.CorrelationId] = context.CorrelationId;
            sp.Properties[WellKnownHttpHeaders.RequestId] = context.RequestId;
        }
    }
}