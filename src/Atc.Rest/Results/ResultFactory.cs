namespace Atc.Rest.Results;

/// <summary>
/// Factory methods for creating standardized HTTP response results.
/// </summary>
/// <remarks>
/// This factory provides methods for creating various types of action results including:
/// <list type="bullet">
/// <item>ProblemDetails responses (RFC 7807)</item>
/// <item>ValidationProblemDetails for validation errors</item>
/// <item>File download results</item>
/// <item>Plain content results</item>
/// </list>
/// </remarks>
public static class ResultFactory
{
    /// <summary>
    /// Creates a <see cref="ProblemDetails"/> object with the specified status code and message.
    /// </summary>
    /// <param name="statusCode">The HTTP status code.</param>
    /// <param name="message">The detail message describing the problem.</param>
    /// <returns>A configured <see cref="ProblemDetails"/> object.</returns>
    public static ProblemDetails CreateProblemDetails(
        HttpStatusCode statusCode,
        string? message)
        => new()
        {
            Status = (int)statusCode,
            Detail = message,
        };

    /// <summary>
    /// Creates a <see cref="ValidationProblemDetails"/> object with validation errors.
    /// </summary>
    /// <param name="statusCode">The HTTP status code.</param>
    /// <param name="errors">A dictionary of field names and their associated validation errors.</param>
    /// <param name="message">The detail message describing the validation failure.</param>
    /// <returns>A configured <see cref="ValidationProblemDetails"/> object.</returns>
    public static ValidationProblemDetails CreateValidationProblemDetails(
        HttpStatusCode statusCode,
        Dictionary<string, string[]> errors,
        string? message)
        => new(errors)
        {
            Status = (int)statusCode,
            Detail = message,
        };

    /// <summary>
    /// Creates a <see cref="ContentResult"/> containing serialized ProblemDetails.
    /// </summary>
    /// <param name="statusCode">The HTTP status code.</param>
    /// <param name="message">The detail message describing the problem.</param>
    /// <param name="contentType">The content type. Defaults to application/json.</param>
    /// <returns>A <see cref="ContentResult"/> with JSON-serialized ProblemDetails.</returns>
    public static ContentResult CreateContentResultWithProblemDetails(
        HttpStatusCode statusCode,
        string? message,
        string contentType = MediaTypeNames.Application.Json)
        => new()
        {
            ContentType = contentType,
            StatusCode = (int)statusCode,
            Content = JsonSerializer.Serialize(CreateProblemDetails(statusCode, message)),
        };

    /// <summary>
    /// Creates a <see cref="ContentResult"/> containing serialized ProblemDetails from an object value.
    /// </summary>
    /// <param name="statusCode">The HTTP status code.</param>
    /// <param name="value">The object to include as the detail message (serialized to string or JSON).</param>
    /// <param name="contentType">The content type. Defaults to application/json.</param>
    /// <returns>A <see cref="ContentResult"/> with JSON-serialized ProblemDetails.</returns>
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

        var beautifyTypeName = value
            .GetType()
            .BeautifyTypeName();

        var message = SimpleTypeHelper.IsSimpleType(beautifyTypeName)
            ? value.ToString()
            : JsonSerializer.Serialize(value);

        var problemDetails = CreateProblemDetails(statusCode, message);

        result.Content = JsonSerializer.Serialize(problemDetails);

        return result;
    }

    /// <summary>
    /// Creates a <see cref="ContentResult"/> containing serialized ValidationProblemDetails without specific field errors.
    /// </summary>
    /// <param name="statusCode">The HTTP status code.</param>
    /// <param name="message">The detail message describing the validation failure.</param>
    /// <param name="contentType">The content type. Defaults to application/json.</param>
    /// <returns>A <see cref="ContentResult"/> with JSON-serialized ValidationProblemDetails.</returns>
    public static ContentResult CreateContentResultWithValidationProblemDetails(
        HttpStatusCode statusCode,
        string? message,
        string contentType = MediaTypeNames.Application.Json)
        => new()
        {
            ContentType = contentType,
            StatusCode = (int)statusCode,
            Content = JsonSerializer.Serialize(CreateValidationProblemDetails(statusCode, new Dictionary<string, string[]>(StringComparer.Ordinal), message)),
        };

    /// <summary>
    /// Creates a <see cref="ContentResult"/> containing serialized ValidationProblemDetails with field-specific validation errors.
    /// </summary>
    /// <param name="statusCode">The HTTP status code.</param>
    /// <param name="errors">A dictionary of field names and their associated validation errors.</param>
    /// <param name="message">The detail message describing the validation failure.</param>
    /// <param name="contentType">The content type. Defaults to application/json.</param>
    /// <returns>A <see cref="ContentResult"/> with JSON-serialized ValidationProblemDetails.</returns>
    public static ContentResult CreateContentResultWithValidationProblemDetails(
        HttpStatusCode statusCode,
        Dictionary<string, string[]> errors,
        string? message,
        string contentType = MediaTypeNames.Application.Json)
        => new()
        {
            ContentType = contentType,
            StatusCode = (int)statusCode,
            Content = JsonSerializer.Serialize(CreateValidationProblemDetails(statusCode, errors, message)),
        };

    /// <summary>
    /// Creates a <see cref="ContentResult"/> with a JSON-serialized message.
    /// </summary>
    /// <param name="statusCode">The HTTP status code.</param>
    /// <param name="message">The message to serialize.</param>
    /// <param name="contentType">The content type. Defaults to application/json.</param>
    /// <returns>A <see cref="ContentResult"/> with the serialized message.</returns>
    public static ContentResult CreateContentResult(
        HttpStatusCode statusCode,
        string? message,
        string contentType = MediaTypeNames.Application.Json)
        => new()
        {
            ContentType = contentType,
            StatusCode = (int)statusCode,
            Content = JsonSerializer.Serialize(message),
        };

    /// <summary>
    /// Creates a <see cref="FileResult"/> for downloading binary content.
    /// </summary>
    /// <param name="bytes">The file content as a byte array.</param>
    /// <param name="fileName">The filename to use for the download.</param>
    /// <param name="contentType">The content type. Defaults to application/octet-stream.</param>
    /// <returns>A <see cref="FileResult"/> configured for file download.</returns>
    public static FileResult CreateFileContentResult(
        byte[] bytes,
        string fileName,
        string contentType = MediaTypeNames.Application.Octet)
        => new FileContentResult(bytes, contentType)
        {
            FileDownloadName = fileName,
        };
}