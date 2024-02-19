namespace Atc.Rest.Models;

[SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "OK.")]
public sealed class RequestLogModel
{
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

    public DateTime DateTimeUtc { get; init; }

    public string RequestId { get; init; }

    public string? ClientIp { get; init; }

    public string Method { get; init; }

    public string Scheme { get; init; }

    public string Host { get; init; }

    public string Path { get; init; }

    public string QueryString { get; init; }

    public IList<KeyValuePair<string, string>>? QueryParameters { get; init; }

    public IDictionary<string, string>? HeaderParameters { get; init; }

    public string? Body { get; set; }

    public string? ContentType { get; init; }

    private static IList<KeyValuePair<string, string>> ExtractQueryParameters(
        string queryString)
    {
        var pairs = new List<KeyValuePair<string, string>>();

        foreach (var query in queryString.TrimStart('?').Split("&"))
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
            pairs.Add(header.Key, header.Value);
        }

        return pairs;
    }
}