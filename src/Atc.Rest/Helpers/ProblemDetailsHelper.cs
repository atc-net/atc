namespace Atc.Rest.Helpers;

public static class ProblemDetailsHelper
{
    public static bool IsFormatJsonAndProblemDetailsModel(
        string value)
        => !string.IsNullOrEmpty(value) &&
           value.IsFormatJson() &&
           value.Contains(new[] { "Status", "Title", "Detail" });

    [SuppressMessage("Microsoft.Design", "CA1031:Do not catch general exception types", Justification = "OK.")]
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
            catch
            {
                problemDetails = null;
                return false;
            }
        }

        problemDetails = null;
        return false;
    }

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