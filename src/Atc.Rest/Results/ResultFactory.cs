using System;
using System.Collections.Generic;
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

        public static ValidationProblemDetails CreateValidationProblemDetails(
            HttpStatusCode statusCode,
            Dictionary<string, string[]> errors,
            string? message)
            => new ValidationProblemDetails(errors)
            {
                Status = (int)statusCode,
                Detail = message,
            };

        public static ContentResult CreateContentResultWithProblemDetails(
            HttpStatusCode statusCode,
            string? message,
            string contentType = MediaTypeNames.Application.Json)
            => new ContentResult
            {
                ContentType = contentType,
                StatusCode = (int)statusCode,
                Content = JsonSerializer.Serialize(CreateProblemDetails(statusCode, message)),
            };

        public static ContentResult CreateContentResultWithValidationProblemDetails(
            HttpStatusCode statusCode,
            string? message,
            string contentType = MediaTypeNames.Application.Json)
            => new ContentResult
            {
                ContentType = contentType,
                StatusCode = (int)statusCode,
                Content = JsonSerializer.Serialize(CreateValidationProblemDetails(statusCode, new Dictionary<string, string[]>(StringComparer.Ordinal), message)),
            };

        public static ContentResult CreateContentResultWithValidationProblemDetails(
            HttpStatusCode statusCode,
            Dictionary<string, string[]> errors,
            string? message,
            string contentType = MediaTypeNames.Application.Json)
            => new ContentResult
            {
                ContentType = contentType,
                StatusCode = (int)statusCode,
                Content = JsonSerializer.Serialize(CreateValidationProblemDetails(statusCode, errors, message)),
            };

        public static ContentResult CreateContentResult(
            HttpStatusCode statusCode,
            string? message,
            string contentType = MediaTypeNames.Application.Json)
            => new ContentResult
            {
                ContentType = contentType,
                StatusCode = (int)statusCode,
                Content = JsonSerializer.Serialize(message),
            };
    }
}