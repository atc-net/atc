namespace Atc.Rest.Helpers;

public static class ProblemDetailsHelper
{
    public static bool IsJsonWithProblemDetails(
        string value)
        => !string.IsNullOrEmpty(value) &&
           value.IsFormatJson() &&
           value.Contains(new[] { "Status", "Title", "Detail" });

    [SuppressMessage("Microsoft.Design", "CA1031:Do not catch general exception types", Justification = "OK.")]
    public static bool TrySerializedToProblemDetails(
        string value,
        out ProblemDetails? problemDetails)
    {
        if (IsJsonWithProblemDetails(value))
        {
            try
            {
                problemDetails = JsonSerializer.Deserialize<ProblemDetails>(value, JsonSerializerOptionsFactory.Create())!;
                return true;
            }
            catch
            {
                problemDetails = null;
                return false;
            }
        }

        problemDetails = null;
        return false;
    }

    public static bool TrySerializedToProblemDetailsAndGetDetails(
        string value,
        out string? detailValue)
    {
        if (TrySerializedToProblemDetails(value, out var problemDetails))
        {
            detailValue = problemDetails!.Detail;
            return true;
        }

        detailValue = null;
        return false;
    }

    public static bool TrySerializedToProblemDetailsAndGetStatusCode(string value, out HttpStatusCode? statusCodeValue)
    {
        if (TrySerializedToProblemDetails(value, out var problemDetails) &&
            problemDetails!.Status is not null)
        {
            statusCodeValue = (HttpStatusCode)problemDetails.Status;
            return true;
        }

        statusCodeValue = null;
        return false;
    }
}