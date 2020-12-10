using System.Net;
using System.Net.Mime;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace Atc.Rest.Results
{
    public static class ResultFactory
    {
        public static ProblemDetails CreateProblemDetails(HttpStatusCode statusCode, string? message)
            => new ProblemDetails
            {
                Status = (int)statusCode,
                Detail = message,
            };

        public static ContentResult CreateContentResultWithProblemDetails(HttpStatusCode statusCode, string? message, string contentType = MediaTypeNames.Application.Json)
            => new ContentResult
            {
                ContentType = contentType,
                StatusCode = (int)statusCode,
                Content = JsonSerializer.Serialize(CreateProblemDetails(statusCode, message)),
            };

        public static ContentResult CreateContentResult(HttpStatusCode statusCode, string? message, string contentType = MediaTypeNames.Application.Json)
            => new ContentResult
            {
                ContentType = contentType,
                StatusCode = (int)statusCode,
                Content = JsonSerializer.Serialize(message),
            };
    }
}