namespace Atc.Helpers;

/// <summary>
/// Provides utility methods for checking network connectivity and retrieving network information.
/// </summary>
[SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "OK.")]
[SuppressMessage("Minor Code Smell", "S1075:URIs should not be hardcoded", Justification = "OK.")]
public static class NetworkInformationHelper
{
    /// <summary>
    /// Determines whether there is network connectivity by pinging Google's DNS server (8.8.8.8).
    /// </summary>
    /// <returns><see langword="true"/> if a ping response is received; otherwise, <see langword="false"/>.</returns>
    public static bool HasConnection()
    {
        const string googleDns = "8.8.8.8";
        return HasConnection(IPAddress.Parse(googleDns));
    }

    /// <summary>
    /// Determines whether there is network connectivity to a specified IP address.
    /// </summary>
    /// <param name="ipAddress">The IP address to ping.</param>
    /// <returns><see langword="true"/> if a ping response is received; otherwise, <see langword="false"/>.</returns>
    public static bool HasConnection(IPAddress ipAddress)
    {
        try
        {
            using var ping = new Ping();
            var buffer = new byte[32];

            const int timeout = 1000;
            var pingOptions = new PingOptions();

            var pingReply = ping.Send(ipAddress, timeout, buffer, pingOptions);

            return pingReply is not null &&
                   pingReply.Status == IPStatus.Success;
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// Determines whether there is HTTP connectivity by making a request to Google's website.
    /// </summary>
    /// <returns><see langword="true"/> if the HTTP request succeeds; otherwise, <see langword="false"/>.</returns>
    public static bool HasHttpConnection()
    {
        return HasHttpConnection(new Uri("https://www.google.com/"));
    }

    /// <summary>
    /// Determines whether there is HTTP connectivity to a specified URI.
    /// </summary>
    /// <param name="uri">The URI to request.</param>
    /// <returns><see langword="true"/> if the HTTP request succeeds; otherwise, <see langword="false"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="uri"/> is <see langword="null"/>.</exception>
    public static bool HasHttpConnection(Uri uri)
    {
        if (uri is null)
        {
            throw new ArgumentNullException(nameof(uri));
        }

        var result = false;
        TaskHelper.RunSync(async () =>
        {
            try
            {
                using HttpClient client = new HttpClient();
                await client
                    .GetStringAsync(uri)
                    .ConfigureAwait(false);

                result = true;
            }
            catch
            {
                // Do not touch response on exceptions
            }
        });

        return result;
    }

    /// <summary>
    /// Determines whether a TCP connection can be established to the specified IP address and port.
    /// </summary>
    /// <param name="ipAddress">The IP address to connect to.</param>
    /// <param name="port">The port number to connect to.</param>
    /// <returns><see langword="true"/> if the TCP connection succeeds; otherwise, <see langword="false"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="ipAddress"/> is <see langword="null"/>.</exception>
    public static bool HasTcpConnection(
        IPAddress ipAddress,
        int port)
    {
        if (ipAddress is null)
        {
            throw new ArgumentNullException(nameof(ipAddress));
        }

        try
        {
            using var client = new TcpClient(ipAddress.ToString(), port);
            return client.Connected;
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// Retrieves the public IP address of the current machine by querying an external service (api.ipify.org).
    /// </summary>
    /// <returns>The public <see cref="IPAddress"/> if retrieval succeeds; otherwise, <see langword="null"/>.</returns>
    [SuppressMessage("Bug", "S2583:Conditionally executed code should be reachable", Justification = "OK.")]
    public static IPAddress? GetPublicIpAddress()
    {
        string? response = null;
        TaskHelper.RunSync(async () =>
        {
            try
            {
                using var client = new HttpClient();
                response = await client
                    .GetStringAsync(new Uri("https://api.ipify.org"))
                    .ConfigureAwait(false);
            }
            catch
            {
                // Do not touch response on exceptions
            }
        });

        if (string.IsNullOrEmpty(response))
        {
            return null;
        }

        return IPAddress.TryParse(response, out var ipAddress)
            ? ipAddress
            : null;
    }
}