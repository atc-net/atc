namespace Atc.Nuget;

/// <summary>
/// Looks up package versions in the flat container (package base address) resource of a NuGet v3 feed,
/// by default the one on nuget.org (<c>https://api.nuget.org/v3-flatcontainer</c>).
/// </summary>
/// <remarks>
/// <para>
/// The latest stable version of a package is read from <c>{base}/{package-id-lowercase}/index.json</c>.
/// A version found is cached per instance and package id, so asking again costs no request;
/// a failed lookup is not cached and is tried again next time.
/// </para>
/// <para>
/// Every failure - no network, a non-success status, a captive portal's HTML page, an index of another shape,
/// a timeout or a cancellation - gives <see langword="null"/>; nothing is thrown except for an invalid package id.
/// </para>
/// </remarks>
/// <example>
/// <code>
/// var client = new NugetFeedClient();
/// var latest = await client.GetLatestStableVersionAsync("Atc", cancellationToken);
/// </code>
/// </example>
[SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "A version lookup is best effort: any failure means 'unknown', never a crash.")]
public sealed class NugetFeedClient : INugetFeedClient
{
    /// <summary>
    /// The flat container (package base address) resource of nuget.org.
    /// </summary>
    [SuppressMessage("", "S1075:Refactor your code not to use hardcoded absolute paths or URIs.", Justification = "OK - the public nuget.org endpoint is the default.")]
    public static readonly Uri NugetOrgFlatContainerUri = new("https://api.nuget.org/v3-flatcontainer/");

    private static readonly Lazy<HttpClient> SharedHttpClient = new(CreateSharedHttpClient);

    private readonly ConcurrentDictionary<string, Version> versionCache = new(StringComparer.OrdinalIgnoreCase);
    private readonly HttpClient httpClient;
    private readonly string flatContainerBaseAddress;

    /// <summary>
    /// Initializes a new instance of the <see cref="NugetFeedClient"/> class that reads nuget.org
    /// through an <see cref="HttpClient"/> shared by all instances created this way (10 second timeout).
    /// </summary>
    public NugetFeedClient()
        : this(SharedHttpClient.Value, NugetOrgFlatContainerUri)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="NugetFeedClient"/> class that reads nuget.org
    /// through the given <see cref="HttpClient"/>, for example one from <c>IHttpClientFactory</c>
    /// or one over a test handler.
    /// </summary>
    /// <param name="httpClient">The client the feed is read with. It is not disposed by this instance.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="httpClient"/> is null.</exception>
    public NugetFeedClient(HttpClient httpClient)
        : this(httpClient, NugetOrgFlatContainerUri)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="NugetFeedClient"/> class that reads the flat container
    /// resource of another NuGet v3 feed, such as a private feed.
    /// </summary>
    /// <param name="httpClient">The client the feed is read with. It is not disposed by this instance.</param>
    /// <param name="flatContainerUri">
    /// The absolute address of the feed's flat container (<c>PackageBaseAddress/3.0.0</c>) resource.
    /// </param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="httpClient"/> or <paramref name="flatContainerUri"/> is null.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="flatContainerUri"/> is not an absolute URI.</exception>
    public NugetFeedClient(
        HttpClient httpClient,
        Uri flatContainerUri)
    {
        ArgumentNullException.ThrowIfNull(httpClient);
        ArgumentNullException.ThrowIfNull(flatContainerUri);

        if (!flatContainerUri.IsAbsoluteUri)
        {
            throw new ArgumentException("The flat container address must be an absolute URI.", nameof(flatContainerUri));
        }

        this.httpClient = httpClient;
        flatContainerBaseAddress = flatContainerUri.AbsoluteUri.TrimEnd('/');
    }

    /// <inheritdoc />
    [SuppressMessage("Globalization", "CA1308:Normalize strings to uppercase", Justification = "The flat container resource requires lowercase package ids.")]
    public async Task<Version?> GetLatestStableVersionAsync(
        string packageId,
        CancellationToken cancellationToken)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(packageId);

        var id = packageId.Trim();
        if (versionCache.TryGetValue(id, out var cached))
        {
            return cached;
        }

        try
        {
            var uri = new Uri($"{flatContainerBaseAddress}/{Uri.EscapeDataString(id.ToLowerInvariant())}/index.json");

            // The default completion option buffers the body within the call, so the token also covers reading it.
            using var response = await httpClient
                .GetAsync(uri, cancellationToken)
                .ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var json = await response.Content
#if NET5_0_OR_GREATER
                .ReadAsStringAsync(cancellationToken)
#else
                .ReadAsStringAsync()
#endif
                .ConfigureAwait(false);

            var version = ParseLatestStableVersion(json);
            if (version is not null)
            {
                versionCache.TryAdd(id, version);
            }

            return version;
        }
        catch (Exception)
        {
            return null;
        }
    }

    private static Version? ParseLatestStableVersion(string json)
    {
        if (JsonNode.Parse(json) is not JsonObject root ||
            root["versions"] is not JsonArray versions)
        {
            return null;
        }

        // A prerelease ("3.0.0-preview.1") is never the latest stable version, build metadata ("+abc") is ignored,
        // and an entry that is not a version string is skipped.
        return versions
            .Select(node => node is JsonValue value && value.TryGetValue<string>(out var text) ? text : null)
            .Where(text => text is not null && !text.Contains('-', StringComparison.Ordinal))
            .Select(text => Version.TryParse(StripBuildMetadata(text!), out var parsed) ? parsed : null)
            .Where(parsed => parsed is not null)
            .Max();
    }

    private static string StripBuildMetadata(string version)
    {
        var index = version.IndexOf('+', StringComparison.Ordinal);
        return index < 0
            ? version
            : version.Substring(0, index);
    }

    private static HttpClient CreateSharedHttpClient()
    {
        var client = new HttpClient
        {
            Timeout = TimeSpan.FromSeconds(10),
        };

        client.DefaultRequestHeaders.UserAgent.ParseAdd("Atc");
        return client;
    }
}