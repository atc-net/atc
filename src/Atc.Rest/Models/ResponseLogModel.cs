namespace Atc.Rest.Models;

[SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "OK.")]
public sealed class ResponseLogModel
{
    public ResponseLogModel(
        HttpResponse response)
    {
        DateTimeUtc = DateTime.UtcNow;
        Status = response.StatusCode.ToString(GlobalizationConstants.EnglishCultureInfo);
        HeaderParameters = ExtractHeaderParameters(response.Headers);
        ContentType = response.ContentType;
    }

    public DateTime DateTimeUtc { get; init; }

    public string Status { get; init; }

    public IDictionary<string, string> HeaderParameters { get; init; }

    public string? ContentType { get; init; }

    public string? Body { get; set; }

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