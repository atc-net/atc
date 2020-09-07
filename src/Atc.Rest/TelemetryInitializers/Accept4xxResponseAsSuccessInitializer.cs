using System.Net;
using Microsoft.ApplicationInsights.Channel;
using Microsoft.ApplicationInsights.DataContracts;

// ReSharper disable InconsistentNaming
// ReSharper disable once CheckNamespace
namespace Microsoft.ApplicationInsights.Extensibility
{
    public class Accept4xxResponseAsSuccessInitializer : ITelemetryInitializer
    {
        public void Initialize(ITelemetry telemetry)
        {
            if (!(telemetry is RequestTelemetry requestTelemetry) ||
                requestTelemetry.Success.GetValueOrDefault(false))
            {
                return;
            }

            if (!int.TryParse(requestTelemetry.ResponseCode, out var code))
            {
                return;
            }

            requestTelemetry.Success = code switch
            {
                (int)HttpStatusCode.BadRequest => true,
                (int)HttpStatusCode.NotFound => true,
                _ => requestTelemetry.Success
            };
        }
    }
}