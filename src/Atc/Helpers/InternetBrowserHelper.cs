namespace Atc.Helpers;

public static class InternetBrowserHelper
{
    private const string ProcessNameBrave = "brave";
    private const string ProcessNameFirefox = "firefox";
    private const string ProcessNameGhostBrowser = "ghost";
    private const string ProcessNameChrome = "chrome";
    private const string ProcessNameMicrosoftEdge = "msedge";
    private const string ProcessNameMicrosoftInternetExplorer = "iexplore";
    private const string ProcessNameOpera = "opera";
    private const string ProcessNameSafari = "safari";

    public static IList<string> GetRunningInternetBrowsers()
    {
        var result = new List<string>();

        if (IsBraveRunning())
        {
            result.Add("Brave");
        }

        if (IsFirefoxRunning())
        {
            result.Add("Firefox");
        }

        if (IsGhostBrowserRunning())
        {
            result.Add("Ghost Browser");
        }

        if (IsGoogleChromeRunning())
        {
            result.Add("Google Chrome");
        }

        if (IsMicrosoftEdgeRunning())
        {
            result.Add("Microsoft Edge");
        }

        if (IsMicrosoftInternetExplorerRunning())
        {
            result.Add("Microsoft Internet Explorer");
        }

        if (IsOperaRunning())
        {
            result.Add("Opera");
        }

        if (IsSafariRunning())
        {
            result.Add("Safari");
        }

        return result;
    }

    public static void CloseMainWindowOnAllRunningInternetBrowsers()
    {
        CloseMainWindowOnRunningBraveInstances();
        CloseMainWindowOnRunningFirefoxInstances();
        CloseMainWindowOnRunningGhostBrowserInstances();
        CloseMainWindowOnRunningGoogleChromeInstances();
        CloseMainWindowOnRunningMicrosoftEdgeInstances();
        CloseMainWindowOnRunningMicrosoftInternetExplorerInstances();
        CloseMainWindowOnRunningOperaInstances();
        CloseMainWindowOnRunningSafariInstances();
    }

    public static void KillAllRunningInternetBrowsers()
    {
        KillRunningBraveInstances();
        KillRunningFirefoxInstances();
        KillRunningGhostBrowserInstances();
        KillRunningGoogleChromeInstances();
        KillRunningMicrosoftEdgeInstances();
        KillRunningMicrosoftInternetExplorerInstances();
        KillRunningOperaInstances();
        KillRunningSafariInstances();
    }

    public static bool IsBraveRunning()
        => IsProcessRunning(ProcessNameBrave);

    public static bool IsFirefoxRunning()
        => IsProcessRunning(ProcessNameFirefox);

    public static bool IsGhostBrowserRunning()
        => IsProcessRunning(ProcessNameGhostBrowser);

    public static bool IsGoogleChromeRunning()
        => IsProcessRunning(ProcessNameChrome);

    public static bool IsMicrosoftEdgeRunning()
        => IsProcessRunning(ProcessNameMicrosoftEdge);

    public static bool IsMicrosoftInternetExplorerRunning()
        => IsProcessRunning(ProcessNameMicrosoftInternetExplorer);

    public static bool IsOperaRunning()
        => IsProcessRunning(ProcessNameOpera);

    public static bool IsSafariRunning()
        => IsProcessRunning(ProcessNameSafari);

    public static void CloseMainWindowOnRunningBraveInstances()
        => CloseMainWindowOnRunningInstances(ProcessNameBrave);

    public static void CloseMainWindowOnRunningFirefoxInstances()
        => CloseMainWindowOnRunningInstances(ProcessNameFirefox);

    public static void CloseMainWindowOnRunningGhostBrowserInstances()
        => CloseMainWindowOnRunningInstances(ProcessNameGhostBrowser);

    public static void CloseMainWindowOnRunningGoogleChromeInstances()
        => CloseMainWindowOnRunningInstances(ProcessNameChrome);

    public static void CloseMainWindowOnRunningMicrosoftEdgeInstances()
        => CloseMainWindowOnRunningInstances(ProcessNameMicrosoftEdge);

    public static void CloseMainWindowOnRunningMicrosoftInternetExplorerInstances()
        => CloseMainWindowOnRunningInstances(ProcessNameMicrosoftInternetExplorer);

    public static void CloseMainWindowOnRunningOperaInstances()
        => CloseMainWindowOnRunningInstances(ProcessNameOpera);

    public static void CloseMainWindowOnRunningSafariInstances()
        => CloseMainWindowOnRunningInstances(ProcessNameSafari);

    public static void KillRunningBraveInstances()
        => KillRunningInstances(ProcessNameBrave);

    public static void KillRunningFirefoxInstances()
        => KillRunningInstances(ProcessNameFirefox);

    public static void KillRunningGhostBrowserInstances()
        => KillRunningInstances(ProcessNameGhostBrowser);

    public static void KillRunningGoogleChromeInstances()
        => KillRunningInstances(ProcessNameChrome);

    public static void KillRunningMicrosoftEdgeInstances()
        => KillRunningInstances(ProcessNameMicrosoftEdge);

    public static void KillRunningMicrosoftInternetExplorerInstances()
        => KillRunningInstances(ProcessNameMicrosoftInternetExplorer);

    public static void KillRunningOperaInstances()
        => KillRunningInstances(ProcessNameOpera);

    public static void KillRunningSafariInstances()
        => KillRunningInstances(ProcessNameSafari);

    /// <summary>
    /// Open the given url in the default browser on the machine.
    /// </summary>
    /// <param name="url">The URL.</param>
    /// <remarks>
    /// Only url with the http or https protocol is supported.
    /// </remarks>
    /// <returns>
    ///   <see langword="true" /> if the url is started in a browser; otherwise, <see langword="false" />.
    /// </returns>
    public static bool OpenUrl(
        string url)
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
    /// <returns>
    ///   <see langword="true" /> if the url is started in a browser; otherwise, <see langword="false" />.
    /// </returns>
    public static bool OpenUrl(
        Uri uri)
    {
        if (uri is null)
        {
            throw new ArgumentNullException(nameof(uri));
        }

        return ProcessStartOpenUrl(uri);
    }

    [SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "OK.")]
    private static bool ProcessStartOpenUrl(
        Uri uri)
    {
        if (uri is null)
        {
            throw new ArgumentNullException(nameof(uri));
        }

        if (!uri.Scheme.StartsWith("http", StringComparison.OrdinalIgnoreCase))
        {
            throw new ArgumentException("Only supports protocols: http or https", nameof(uri));
        }

        try
        {
            var url = uri.AbsoluteUri.Replace("&", "^&", StringComparison.Ordinal);

#if NETSTANDARD2_1
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
#else
            if (OperatingSystem.IsWindows())
            {
                Process.Start(
                    new ProcessStartInfo("cmd", $"/c start {url}")
                    {
                        CreateNoWindow = true,
                    });
            }
            else if (OperatingSystem.IsLinux())
            {
                Process.Start("xdg-open", url);
            }
            else if (OperatingSystem.IsMacOS())
            {
                Process.Start("open", url);
            }
#endif

            return true;
        }
        catch
        {
            return false;
        }
    }

    private static bool IsProcessRunning(
        string processName)
        => Process.GetProcessesByName(processName).Length > 0;

    private static void CloseMainWindowOnRunningInstances(
        string processName)
    {
        var instances = Process.GetProcessesByName(processName);
        foreach (var instance in instances)
        {
            instance.CloseMainWindow();
        }
    }

    private static void KillRunningInstances(
        string processName)
    {
        var instances = Process.GetProcessesByName(processName);
        foreach (var instance in instances)
        {
            instance.Kill();
        }
    }
}