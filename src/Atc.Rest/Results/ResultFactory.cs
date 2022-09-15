using Atc.Helpers;

namespace Atc.Rest.Results;

public static class ResultFactory
{
    public static ProblemDetails CreateProblemDetails(
        HttpStatusCode statusCode,
        string? message)
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

    public static ContentResult CreateContentResultWithProblemDetails(
        HttpStatusCode statusCode,
        object? value,
        string contentType = MediaTypeNames.Application.Json)
    {
        var result = new ContentResult
        {
            ContentType = contentType,
            StatusCode = (int)statusCode,
        };

        if (value is null)
        {
            return result;
        }

        var message = SimpleTypeHelper.IsSimpleType(value.GetType().BeautifyTypeName())
            ? value.ToString()
            : JsonSerializer.Serialize(value);

        var problemDetails = CreateProblemDetails(statusCode, message);

        result.Content = JsonSerializer.Serialize(problemDetails);

        return result;
    }

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

    public static FileResult CreateFileContentResult(
        byte[] bytes,
        string fileName,
        string contentType = MediaTypeNames.Application.Octet)
        => new FileContentResult(bytes, contentType)
        {
            FileDownloadName = fileName,
        };
}