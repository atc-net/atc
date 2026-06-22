namespace Atc.Helpers;

/// <summary>
/// Provides utility methods for checking network connectivity and retrieving network information.
/// </summary>
[SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "OK.")]
[SuppressMessage("Minor Code Smell", "S1075:URIs should not be hardcoded", Justification = "OK.")]
public static class NetworkInformationHelper
{
    private static readonly HttpClient SharedHttpClient = new();

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
        => HasHttpConnection(new Uri("https://www.google.com/"));

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
                await SharedHttpClient
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

        var client = new TcpClient();
        try
        {
            return client.ConnectAsync(ipAddress, port).Wait(5_000) && client.Connected;
        }
        catch
        {
            return false;
        }
        finally
        {
            client.Dispose();
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
                response = await SharedHttpClient
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

    /// <summary>
    /// Asynchronously determines whether there is network connectivity by pinging Google's DNS server (8.8.8.8).
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns><see langword="true"/> if a ping response is received; otherwise, <see langword="false"/>.</returns>
    public static Task<bool> HasConnectionAsync(
        CancellationToken cancellationToken = default)
    {
        const string googleDns = "8.8.8.8";
        return HasConnectionAsync(IPAddress.Parse(googleDns), cancellationToken);
    }

    /// <summary>
    /// Asynchronously determines whether there is network connectivity to a specified IP address.
    /// </summary>
    /// <param name="ipAddress">The IP address to ping.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns><see langword="true"/> if a ping response is received; otherwise, <see langword="false"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="ipAddress"/> is <see langword="null"/>.</exception>
    public static async Task<bool> HasConnectionAsync(
        IPAddress ipAddress,
        CancellationToken cancellationToken = default)
    {
        if (ipAddress is null)
        {
            throw new ArgumentNullException(nameof(ipAddress));
        }

        try
        {
            using var ping = new Ping();
            var buffer = new byte[32];

            const int timeout = 1000;
            var pingOptions = new PingOptions();

#if NET7_0_OR_GREATER
            var pingReply = await ping.SendPingAsync(
                ipAddress,
                TimeSpan.FromMilliseconds(timeout),
                buffer,
                pingOptions,
                cancellationToken).ConfigureAwait(false);
#else
            cancellationToken.ThrowIfCancellationRequested();
            var pingReply = await ping.SendPingAsync(ipAddress, timeout, buffer, pingOptions).ConfigureAwait(false);
#endif

            return pingReply is not null &&
                   pingReply.Status == IPStatus.Success;
        }
        catch (OperationCanceledException)
        {
            throw;
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// Asynchronously determines whether there is HTTP connectivity by making a request to Google's website.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns><see langword="true"/> if the HTTP request succeeds; otherwise, <see langword="false"/>.</returns>
    public static Task<bool> HasHttpConnectionAsync(
        CancellationToken cancellationToken = default)
        => HasHttpConnectionAsync(new Uri("https://www.google.com/"), cancellationToken);

    /// <summary>
    /// Asynchronously determines whether there is HTTP connectivity to a specified URI.
    /// </summary>
    /// <param name="uri">The URI to request.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns><see langword="true"/> if the HTTP request succeeds; otherwise, <see langword="false"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="uri"/> is <see langword="null"/>.</exception>
    public static async Task<bool> HasHttpConnectionAsync(
        Uri uri,
        CancellationToken cancellationToken = default)
    {
        if (uri is null)
        {
            throw new ArgumentNullException(nameof(uri));
        }

        try
        {
            using var response = await SharedHttpClient
                .GetAsync(uri, HttpCompletionOption.ResponseHeadersRead, cancellationToken)
                .ConfigureAwait(false);

            response.EnsureSuccessStatusCode();
            return true;
        }
        catch (OperationCanceledException)
        {
            throw;
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// Asynchronously determines whether a TCP connection can be established to the specified IP address and port.
    /// A connection timeout of 5 seconds is applied; pass a pre-cancelled token to impose a shorter deadline.
    /// </summary>
    /// <param name="ipAddress">The IP address to connect to.</param>
    /// <param name="port">The port number to connect to.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns><see langword="true"/> if the TCP connection succeeds within the timeout; otherwise, <see langword="false"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="ipAddress"/> is <see langword="null"/>.</exception>
    public static async Task<bool> HasTcpConnectionAsync(
        IPAddress ipAddress,
        int port,
        CancellationToken cancellationToken = default)
    {
        if (ipAddress is null)
        {
            throw new ArgumentNullException(nameof(ipAddress));
        }

        var client = new TcpClient();
        try
        {
#if NET5_0_OR_GREATER
            using var cts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
            cts.CancelAfter(5_000);
            await client.ConnectAsync(ipAddress, port, cts.Token).ConfigureAwait(false);
#else
            var connectTask = client.ConnectAsync(ipAddress, port);
            await Task.WhenAny(connectTask, Task.Delay(5_000, CancellationToken.None)).ConfigureAwait(false);
            cancellationToken.ThrowIfCancellationRequested();
#endif
            return client.Connected;
        }
        catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
        {
            throw;
        }
        catch
        {
            return false;
        }
        finally
        {
            client.Dispose();
        }
    }

    /// <summary>
    /// Asynchronously retrieves the public IP address of the current machine by querying an external service (api.ipify.org).
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>The public <see cref="IPAddress"/> if retrieval succeeds; otherwise, <see langword="null"/>.</returns>
    public static async Task<IPAddress?> GetPublicIpAddressAsync(
        CancellationToken cancellationToken = default)
    {
        try
        {
            using var response = await SharedHttpClient
                .GetAsync(new Uri("https://api.ipify.org"), cancellationToken)
                .ConfigureAwait(false);

            response.EnsureSuccessStatusCode();
#if NET5_0_OR_GREATER
            var responseBody = await response.Content
                .ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
#else
            var responseBody = await response.Content
                .ReadAsStringAsync()
                .ConfigureAwait(false);
#endif

            if (string.IsNullOrEmpty(responseBody))
            {
                return null;
            }

            return IPAddress.TryParse(responseBody, out var ipAddress)
                ? ipAddress
                : null;
        }
        catch (OperationCanceledException)
        {
            throw;
        }
        catch
        {
            return null;
        }
    }
}