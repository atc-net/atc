using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using Atc.Rest.Options;
using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Http;

// ReSharper disable InvertIf
// ReSharper disable once CheckNamespace
namespace Microsoft.AspNetCore.Mvc.Filters
{
    public sealed class ErrorHandlingExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private readonly TelemetryClient telemetryClient;
        private readonly bool includeException;
        private readonly bool useProblemDetailsAsResponseBody;

        private readonly Regex ensurePascalCaseAndSpacesBetweenWordsRegex =
            new Regex("(?<=[a-z])([A-Z])", RegexOptions.Compiled);

        public ErrorHandlingExceptionFilterAttribute(
            TelemetryClient telemetryClient,
            RestApiOptions options)
        {
            if (options is null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            this.telemetryClient = telemetryClient;
            includeException = options.ErrorHandlingExceptionFilter.IncludeExceptionDetails;
            useProblemDetailsAsResponseBody = options.ErrorHandlingExceptionFilter.UseProblemDetailsAsResponseBody;
        }

        public override void OnException(ExceptionContext context)
        {
            if (context is null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            HandleException(context);
            context.ExceptionHandled = true;

            telemetryClient.TrackException(context.Exception);
        }

        private static HttpStatusCode GetHttpStatusCodeByExceptionType(ExceptionContext context)
        {
            var statusCode = HttpStatusCode.InternalServerError;
            if (context.Exception is null)
            {
                return statusCode;
            }

            var exceptionType = context.Exception.GetType();
            if (exceptionType == typeof(ValidationException))
            {
                statusCode = HttpStatusCode.BadRequest;
            }
            else if (exceptionType == typeof(UnauthorizedAccessException))
            {
                statusCode = HttpStatusCode.Unauthorized;
            }
            else if (exceptionType == typeof(InvalidOperationException))
            {
                statusCode = HttpStatusCode.Conflict;
            }
            else if (exceptionType == typeof(NotImplementedException))
            {
                statusCode = HttpStatusCode.NotImplemented;
            }

            return statusCode;
        }

        private void HandleException(ExceptionContext context)
        {
            context.Result = new ContentResult
            {
                ContentType = MediaTypeNames.Application.Json,
                StatusCode = (int)GetHttpStatusCodeByExceptionType(context),
                Content = useProblemDetailsAsResponseBody
                    ? JsonSerializer.Serialize(CreateProblemDetails(context))
                    : CreateMessage(context),
            };
        }

        private string CreateMessage(ExceptionContext context)
        {
            var sb = new StringBuilder();

            var traceId = context.HttpContext.GetCorrelationId();
            if (!string.IsNullOrEmpty(traceId))
            {
                sb.Append($"TraceId: {traceId}");
            }

            if (includeException && context.Exception is not null)
            {
                sb.Append(" # ");
                sb.Append(context.Exception.GetMessage(includeInnerMessage: true, includeExceptionName: true));
            }

            return sb.ToString();
        }

        private ProblemDetails CreateProblemDetails(ExceptionContext context)
        {
            var statusCode = GetHttpStatusCodeByExceptionType(context);
            var title = ensurePascalCaseAndSpacesBetweenWordsRegex.Replace(statusCode.ToString(), " $1");

            return new ProblemDetails { Status = (int)statusCode, Title = title, Detail = CreateMessage(context) };
        }
    }
}