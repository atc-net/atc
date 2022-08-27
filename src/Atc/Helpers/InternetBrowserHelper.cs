namespace Atc.Helpers;

public static class InternetBrowserHelper
{
    /// <summary>
    /// Open the given url in the default browser on the machine.
    /// </summary>
    /// <param name="url">The URL.</param>
    /// <remarks>
    /// Only url with the http or https protocol is supported.
    /// </remarks>
    public static bool OpenUrl(string url)
    {
        if (url is null)
        {
            throw new ArgumentNullException(nameof(url));
        }

        return OpenUrl(new Uri(url));
    }

    /// <summary>
    /// Open the given url in the default browser on the machine.
    /// </summary>
    /// <param name="uri">The URL.</param>
    /// <remarks>
    /// Only url with the http or https protocol is supported.
    /// </remarks>
    public static bool OpenUrl(Uri uri)
    {
        if (uri is null)
        {
            throw new ArgumentNullException(nameof(uri));
        }

        return ProcessStartOpenUrl(uri);
    }

    [SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "OK.")]
    private static bool ProcessStartOpenUrl(Uri uri)
    {
        if (uri is null)
        {
            throw new ArgumentNullException(nameof(uri));
        }

        if (!uri.Scheme.StartsWith("http", StringComparison.OrdinalIgnoreCase))
        {
            throw new ArgumentException("Only supported protocols: http or https", nameof(uri));
        }

        try
        {
            var url = uri.AbsoluteUri.Replace("&", "^&", StringComparison.Ordinal);
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Process.Start(
                    new ProcessStartInfo("cmd", $"/c start {url}")
                    {
                        CreateNoWindow = true,
                    });
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                Process.Start("xdg-open", url);
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                Process.Start("open", url);
            }

            return true;
        }
        catch
        {
            return false;
        }
    }
}