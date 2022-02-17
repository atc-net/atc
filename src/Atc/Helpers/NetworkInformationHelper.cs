namespace Atc.Helpers;

[SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "OK.")]
[SuppressMessage("Minor Code Smell", "S1075:URIs should not be hardcoded", Justification = "OK.")]
public static class NetworkInformationHelper
{
    public static bool HasConnection()
    {
        try
        {
            using var ping = new Ping();
            var buffer = new byte[32];

            const string googleDns = "8.8.8.8";
            const int timeout = 1000;
            var pingOptions = new PingOptions();

            var pingReply = ping.Send(googleDns, timeout, buffer, pingOptions);

            return pingReply is not null &&
                   pingReply.Status == IPStatus.Success;
        }
        catch
        {
            return false;
        }
    }

    public static IPAddress? GetPublicIpAddress()
    {
        if (!HasConnection())
        {
            return null;
        }

        string? response = null;
        TaskHelper.RunSync(async () =>
        {
            try
            {
                using HttpClient client = new HttpClient();
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