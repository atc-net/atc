namespace Atc.Helpers;

/// <summary>
/// Provides utility methods for detecting, controlling, and opening URLs in common internet browsers.
/// </summary>
/// <remarks>
/// Supports Brave, Firefox, Ghost Browser, Chrome, Edge, Internet Explorer, Opera, and Safari.
/// </remarks>
[ExcludeFromCodeCoverage]
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

    /// <summary>
    /// Gets a list of currently running internet browsers.
    /// </summary>
    /// <returns>A list of browser names that are currently running.</returns>
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

    /// <summary>
    /// Closes the main window on all running internet browser instances.
    /// </summary>
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

    /// <summary>
    /// Terminates all running internet browser processes.
    /// </summary>
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

    /// <summary>
    /// Determines whether Brave browser is currently running.
    /// </summary>
    /// <returns><see langword="true"/> if Brave is running; otherwise, <see langword="false"/>.</returns>
    public static bool IsBraveRunning()
        => IsProcessRunning(ProcessNameBrave);

    /// <summary>
    /// Determines whether Firefox browser is currently running.
    /// </summary>
    /// <returns><see langword="true"/> if Firefox is running; otherwise, <see langword="false"/>.</returns>
    public static bool IsFirefoxRunning()
        => IsProcessRunning(ProcessNameFirefox);

    /// <summary>
    /// Determines whether Ghost Browser is currently running.
    /// </summary>
    /// <returns><see langword="true"/> if Ghost Browser is running; otherwise, <see langword="false"/>.</returns>
    public static bool IsGhostBrowserRunning()
        => IsProcessRunning(ProcessNameGhostBrowser);

    /// <summary>
    /// Determines whether Google Chrome browser is currently running.
    /// </summary>
    /// <returns><see langword="true"/> if Google Chrome is running; otherwise, <see langword="false"/>.</returns>
    public static bool IsGoogleChromeRunning()
        => IsProcessRunning(ProcessNameChrome);

    /// <summary>
    /// Determines whether Microsoft Edge browser is currently running.
    /// </summary>
    /// <returns><see langword="true"/> if Microsoft Edge is running; otherwise, <see langword="false"/>.</returns>
    public static bool IsMicrosoftEdgeRunning()
        => IsProcessRunning(ProcessNameMicrosoftEdge);

    /// <summary>
    /// Determines whether Microsoft Internet Explorer is currently running.
    /// </summary>
    /// <returns><see langword="true"/> if Internet Explorer is running; otherwise, <see langword="false"/>.</returns>
    public static bool IsMicrosoftInternetExplorerRunning()
        => IsProcessRunning(ProcessNameMicrosoftInternetExplorer);

    /// <summary>
    /// Determines whether Opera browser is currently running.
    /// </summary>
    /// <returns><see langword="true"/> if Opera is running; otherwise, <see langword="false"/>.</returns>
    public static bool IsOperaRunning()
        => IsProcessRunning(ProcessNameOpera);

    /// <summary>
    /// Determines whether Safari browser is currently running.
    /// </summary>
    /// <returns><see langword="true"/> if Safari is running; otherwise, <see langword="false"/>.</returns>
    public static bool IsSafariRunning()
        => IsProcessRunning(ProcessNameSafari);

    /// <summary>
    /// Closes the main window on all running Brave browser instances.
    /// </summary>
    public static void CloseMainWindowOnRunningBraveInstances()
        => CloseMainWindowOnRunningInstances(ProcessNameBrave);

    /// <summary>
    /// Closes the main window on all running Firefox browser instances.
    /// </summary>
    public static void CloseMainWindowOnRunningFirefoxInstances()
        => CloseMainWindowOnRunningInstances(ProcessNameFirefox);

    /// <summary>
    /// Closes the main window on all running Ghost Browser instances.
    /// </summary>
    public static void CloseMainWindowOnRunningGhostBrowserInstances()
        => CloseMainWindowOnRunningInstances(ProcessNameGhostBrowser);

    /// <summary>
    /// Closes the main window on all running Google Chrome browser instances.
    /// </summary>
    public static void CloseMainWindowOnRunningGoogleChromeInstances()
        => CloseMainWindowOnRunningInstances(ProcessNameChrome);

    /// <summary>
    /// Closes the main window on all running Microsoft Edge browser instances.
    /// </summary>
    public static void CloseMainWindowOnRunningMicrosoftEdgeInstances()
        => CloseMainWindowOnRunningInstances(ProcessNameMicrosoftEdge);

    /// <summary>
    /// Closes the main window on all running Microsoft Internet Explorer instances.
    /// </summary>
    public static void CloseMainWindowOnRunningMicrosoftInternetExplorerInstances()
        => CloseMainWindowOnRunningInstances(ProcessNameMicrosoftInternetExplorer);

    /// <summary>
    /// Closes the main window on all running Opera browser instances.
    /// </summary>
    public static void CloseMainWindowOnRunningOperaInstances()
        => CloseMainWindowOnRunningInstances(ProcessNameOpera);

    /// <summary>
    /// Closes the main window on all running Safari browser instances.
    /// </summary>
    public static void CloseMainWindowOnRunningSafariInstances()
        => CloseMainWindowOnRunningInstances(ProcessNameSafari);

    /// <summary>
    /// Terminates all running Brave browser processes.
    /// </summary>
    public static void KillRunningBraveInstances()
        => KillRunningInstances(ProcessNameBrave);

    /// <summary>
    /// Terminates all running Firefox browser processes.
    /// </summary>
    public static void KillRunningFirefoxInstances()
        => KillRunningInstances(ProcessNameFirefox);

    /// <summary>
    /// Terminates all running Ghost Browser processes.
    /// </summary>
    public static void KillRunningGhostBrowserInstances()
        => KillRunningInstances(ProcessNameGhostBrowser);

    /// <summary>
    /// Terminates all running Google Chrome browser processes.
    /// </summary>
    public static void KillRunningGoogleChromeInstances()
        => KillRunningInstances(ProcessNameChrome);

    /// <summary>
    /// Terminates all running Microsoft Edge browser processes.
    /// </summary>
    public static void KillRunningMicrosoftEdgeInstances()
        => KillRunningInstances(ProcessNameMicrosoftEdge);

    /// <summary>
    /// Terminates all running Microsoft Internet Explorer processes.
    /// </summary>
    public static void KillRunningMicrosoftInternetExplorerInstances()
        => KillRunningInstances(ProcessNameMicrosoftInternetExplorer);

    /// <summary>
    /// Terminates all running Opera browser processes.
    /// </summary>
    public static void KillRunningOperaInstances()
        => KillRunningInstances(ProcessNameOpera);

    /// <summary>
    /// Terminates all running Safari browser processes.
    /// </summary>
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
    /// <returns>
    ///   <see langword="true" /> if the url is started in a browser; otherwise, <see langword="false" />.
    /// </returns>
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

    private static bool IsProcessRunning(string processName)
        => Process.GetProcessesByName(processName).Length > 0;

    private static void CloseMainWindowOnRunningInstances(string processName)
    {
        var instances = Process.GetProcessesByName(processName);
        foreach (var instance in instances)
        {
            instance.CloseMainWindow();
        }
    }

    private static void KillRunningInstances(string processName)
    {
        var instances = Process.GetProcessesByName(processName);
        foreach (var instance in instances)
        {
            instance.Kill();
        }
    }
}