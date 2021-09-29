using System.Diagnostics.CodeAnalysis;
using System.Net;
using Microsoft.ApplicationInsights.Channel;
using Microsoft.ApplicationInsights.DataContracts;

// ReSharper disable InconsistentNaming
// ReSharper disable once CheckNamespace
namespace Microsoft.ApplicationInsights.Extensibility
{
    [SuppressMessage("Minor Code Smell", "S101:Types should be named in PascalCase", Justification = "OK.")]
    public class Accept4xxResponseAsSuccessInitializer : ITelemetryInitializer
    {
        public void Initialize(ITelemetry telemetry)
        {
            if (!(telemetry is RequestTelemetry requestTelemetry) ||
                requestTelemetry.Success.GetValueOrDefault(defaultValue: false))
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