namespace Atc.Rest.Models;

/// <summary>
/// Represents logged information from an HTTP request.
/// </summary>
/// <remarks>
/// This model captures comprehensive request information including headers, query parameters,
/// body content, and client details for logging and debugging purposes.
/// </remarks>
[SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "OK.")]
public sealed class RequestLogModel
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RequestLogModel"/> class from an <see cref="HttpRequest"/>.
    /// </summary>
    /// <param name="request">The HTTP request to log.</param>
    /// <param name="includeQueryParameters">If true, includes query parameters in the log model.</param>
    /// <param name="includeHeaderParameters">If true, includes header parameters in the log model.</param>
    public RequestLogModel(
        HttpRequest request,
        bool includeQueryParameters = true,
        bool includeHeaderParameters = true)
    {
        DateTimeUtc = DateTime.UtcNow;
        RequestId = request.HttpContext.TraceIdentifier;
        ClientIp = request.HttpContext.Connection.RemoteIpAddress?.ToString();
        Method = request.Method;
        Scheme = request.Scheme;
        Host = request.Host.ToString();
        Path = request.Path;
        QueryString = request.QueryString.ToString();
        ContentType = request.ContentType;

        if (includeQueryParameters)
        {
            QueryParameters = ExtractQueryParameters(request.QueryString.ToString());
        }

        if (includeHeaderParameters)
        {
            HeaderParameters = ExtractHeaderParameters(request.Headers);
        }
    }

    /// <summary>
    /// Gets the UTC timestamp when the request was received.
    /// </summary>
    public DateTime DateTimeUtc { get; init; }

    /// <summary>
    /// Gets the unique identifier for the request from the trace identifier.
    /// </summary>
    public string RequestId { get; init; }

    /// <summary>
    /// Gets the client's IP address.
    /// </summary>
    public string? ClientIp { get; init; }

    /// <summary>
    /// Gets the HTTP method (GET, POST, PUT, etc.).
    /// </summary>
    public string Method { get; init; }

    /// <summary>
    /// Gets the request scheme (http or https).
    /// </summary>
    public string Scheme { get; init; }

    /// <summary>
    /// Gets the host header value.
    /// </summary>
    public string Host { get; init; }

    /// <summary>
    /// Gets the request path.
    /// </summary>
    public string Path { get; init; }

    /// <summary>
    /// Gets the query string including the leading '?' character.
    /// </summary>
    public string QueryString { get; init; }

    /// <summary>
    /// Gets the parsed query parameters as key-value pairs.
    /// </summary>
    public IList<KeyValuePair<string, string>>? QueryParameters { get; init; }

    /// <summary>
    /// Gets the request headers as key-value pairs.
    /// </summary>
    public IDictionary<string, string>? HeaderParameters { get; init; }

    /// <summary>
    /// Gets or sets the request body content.
    /// </summary>
    public string? Body { get; set; }

    /// <summary>
    /// Gets the Content-Type header value.
    /// </summary>
    public string? ContentType { get; init; }

    private static IList<KeyValuePair<string, string>> ExtractQueryParameters(
        string queryString)
    {
        var pairs = new List<KeyValuePair<string, string>>();

        foreach (var query in queryString
                     .TrimStart('?')
                     .Split("&"))
        {
            var items = query.Split("=", StringSplitOptions.RemoveEmptyEntries);
            if (items.Length == 2)
            {
                pairs.Add(new KeyValuePair<string, string>(items[0], items[1]));
            }
        }

        return pairs;
    }

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