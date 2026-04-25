namespace Atc.Rest.Helpers;

/// <summary>
/// Helper methods for working with <see cref="ProblemDetails"/> responses.
/// </summary>
/// <remarks>
/// This class provides utilities for detecting, parsing, and extracting information from ProblemDetails JSON.
/// ProblemDetails is a standardized format (RFC 7807) for returning error information from HTTP APIs.
/// </remarks>
public static class ProblemDetailsHelper
{
    /// <summary>
    /// Determines whether the specified string is a JSON-formatted ProblemDetails model
    /// containing at least one of the expected top-level properties (<c>status</c>, <c>title</c>,
    /// <c>detail</c>) — the comparison is case-insensitive on property names so it tolerates both
    /// PascalCase and camelCase serialization styles.
    /// </summary>
    /// <param name="value">The string to check.</param>
    /// <returns>
    /// <see langword="true"/> if the value is valid JSON whose root object exposes any of the
    /// ProblemDetails properties; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool IsFormatJsonAndProblemDetailsModel(string value)
    {
        if (string.IsNullOrEmpty(value) || !value.IsFormatJson())
        {
            return false;
        }

        try
        {
            using var document = JsonDocument.Parse(value);
            if (document.RootElement.ValueKind != JsonValueKind.Object)
            {
                return false;
            }

            foreach (var property in document.RootElement.EnumerateObject())
            {
                if (string.Equals(property.Name, "Status", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(property.Name, "Title", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(property.Name, "Detail", StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }
        catch (JsonException)
        {
            return false;
        }
    }

    /// <summary>
    /// Attempts to deserialize a JSON string to a <see cref="ProblemDetails"/> object.
    /// </summary>
    /// <param name="value">The JSON string to deserialize.</param>
    /// <param name="problemDetails">When this method returns, contains the deserialized ProblemDetails if successful; otherwise, null.</param>
    /// <returns>True if deserialization succeeded; otherwise, false.</returns>
    public static bool TrySerializeToProblemDetails(
        string value,
        out ProblemDetails? problemDetails)
    {
        if (IsFormatJsonAndProblemDetailsModel(value))
        {
            try
            {
                problemDetails = JsonSerializer.Deserialize<ProblemDetails>(value, JsonSerializerOptionsFactory.Create())!;
                return true;
            }
            catch (JsonException)
            {
                problemDetails = null;
                return false;
            }
        }

        problemDetails = null;
        return false;
    }

    /// <summary>
    /// Attempts to deserialize a JSON string to ProblemDetails and extract the HTTP status code.
    /// </summary>
    /// <param name="value">The JSON string to deserialize.</param>
    /// <param name="statusCodeValue">When this method returns, contains the HTTP status code if successful; otherwise, null.</param>
    /// <returns>True if deserialization succeeded and status code was extracted; otherwise, false.</returns>
    public static bool TrySerializeToProblemDetailsAndGetStatusCode(
        string value,
        out HttpStatusCode? statusCodeValue)
    {
        if (TrySerializeToProblemDetails(value, out var problemDetails) &&
            problemDetails!.Status is not null)
        {
            statusCodeValue = (HttpStatusCode)problemDetails.Status;
            return true;
        }

        statusCodeValue = null;
        return false;
    }

    /// <summary>
    /// Attempts to deserialize a JSON string to ProblemDetails and extract the title.
    /// </summary>
    /// <param name="value">The JSON string to deserialize.</param>
    /// <param name="titleValue">When this method returns, contains the title if successful; otherwise, null.</param>
    /// <returns>True if deserialization succeeded; otherwise, false.</returns>
    public static bool TrySerializeToProblemDetailsAndGetTitle(
        string value,
        out string? titleValue)
    {
        if (TrySerializeToProblemDetails(value, out var problemDetails))
        {
            titleValue = problemDetails!.Title;
            return true;
        }

        titleValue = null;
        return false;
    }

    /// <summary>
    /// Attempts to deserialize a JSON string to ProblemDetails and extract the detail message.
    /// </summary>
    /// <param name="value">The JSON string to deserialize.</param>
    /// <param name="detailValue">When this method returns, contains the detail message if successful; otherwise, null.</param>
    /// <returns>True if deserialization succeeded; otherwise, false.</returns>
    public static bool TrySerializeToProblemDetailsAndGetDetails(
        string value,
        out string? detailValue)
    {
        if (TrySerializeToProblemDetails(value, out var problemDetails))
        {
            detailValue = problemDetails!.Detail;
            return true;
        }

        detailValue = null;
        return false;
    }
}