namespace Atc.Rest.Models;

/// <summary>
/// Represents logged information from an HTTP response.
/// </summary>
/// <remarks>
/// This model captures comprehensive response information including status code, headers,
/// body content, and content type for logging and debugging purposes.
/// </remarks>
[SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "OK.")]
public sealed class ResponseLogModel
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ResponseLogModel"/> class from an <see cref="HttpResponse"/>.
    /// </summary>
    /// <param name="response">The HTTP response to log.</param>
    /// <param name="includeHeaderParameters">If true, includes header parameters in the log model.</param>
    public ResponseLogModel(
        HttpResponse response,
        bool includeHeaderParameters = true)
    {
        DateTimeUtc = DateTime.UtcNow;
        Status = response.StatusCode.ToString(GlobalizationConstants.EnglishCultureInfo);
        ContentType = response.ContentType;

        if (includeHeaderParameters)
        {
            HeaderParameters = ExtractHeaderParameters(response.Headers);
        }
    }

    /// <summary>
    /// Gets the UTC timestamp when the response was sent.
    /// </summary>
    public DateTime DateTimeUtc { get; init; }

    /// <summary>
    /// Gets the HTTP status code as a string.
    /// </summary>
    public string Status { get; init; }

    /// <summary>
    /// Gets or sets the response headers as key-value pairs.
    /// </summary>
    public IDictionary<string, string>? HeaderParameters { get; set; }

    /// <summary>
    /// Gets the Content-Type header value.
    /// </summary>
    public string? ContentType { get; init; }

    /// <summary>
    /// Gets or sets the response body content.
    /// </summary>
    public string? Body { get; set; }

    private static Dictionary<string, string> ExtractHeaderParameters(
        IHeaderDictionary headers)
    {
        var pairs = new Dictionary<string, string>(StringComparer.Ordinal);
        foreach (var header in headers)
        {
            pairs.Add(header.Key, header.Value!);
        }

        return pairs;
    }
}