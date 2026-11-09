namespace Atc.Console.Spectre.Helpers;

/// <summary>
/// A start-up check that tells the user of a .NET tool when a newer stable version is on NuGet,
/// with the <c>dotnet tool update</c> command to get it.
/// </summary>
/// <remarks>
/// The check is opt-in and best effort: it never throws and never delays the tool by more than its time budget.
/// It is skipped for <c>-h</c>, <c>--help</c>, <c>-v</c> and <c>--version</c> (and when no arguments are given),
/// on a CI system (<c>CI=true</c>), when a tool-specific opt-out environment variable is set,
/// and for a development build (version 1.0.0.0).
/// </remarks>
/// <example>
/// <code>
/// await CliUpdateCheckHelper.CheckForUpdatesAsync(
///     args,
///     new CliUpdateCheckOptions("my-tool") { OptOutEnvironmentVariable = "MY_TOOL_NO_UPDATE_CHECK" });
/// </code>
/// </example>
[SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "The update check must never affect the command that runs after it.")]
public static class CliUpdateCheckHelper
{
    /// <summary>
    /// The environment variable that CI systems set to <c>true</c>; the check is skipped when it is set.
    /// </summary>
    public const string ContinuousIntegrationEnvironmentVariable = "CI";

    /// <summary>
    /// The default time the whole update check may take: 2 seconds.
    /// </summary>
    public static readonly TimeSpan DefaultBudget = TimeSpan.FromSeconds(2);

    private static readonly Version DevelopmentVersion = new(1, 0, 0, 0);

    private static readonly string[] ArgumentsWithoutUpdateCheck =
    [
        CommandConstants.ArgumentShortHelp,
        CommandConstants.ArgumentLongHelp,
        CommandConstants.ArgumentShortVersion,
        CommandConstants.ArgumentLongVersion,
    ];

    /// <summary>
    /// Tells whether the update check should run for the given command line. It is skipped when no arguments
    /// are given and for <c>-h</c>, <c>--help</c>, <c>-v</c> and <c>--version</c>, which must answer at once.
    /// </summary>
    /// <param name="args">The command-line arguments.</param>
    /// <returns><see langword="true"/> when the check should run; otherwise <see langword="false"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="args"/> is null.</exception>
    public static bool ShouldCheckForUpdates(string[] args)
    {
        ArgumentNullException.ThrowIfNull(args);

        return args.Length > 0 &&
               !args.Any(arg => ArgumentsWithoutUpdateCheck.Contains(arg, StringComparer.Ordinal));
    }

    /// <summary>
    /// Tells whether the environment turns the update check off: <c>CI</c> or the given opt-out variable
    /// is <c>1</c> or <c>true</c> (any casing).
    /// </summary>
    /// <param name="getEnvironmentVariable">Reads an environment variable by name, normally <see cref="Environment.GetEnvironmentVariable(string)"/>.</param>
    /// <param name="optOutEnvironmentVariable">The name of the tool's own opt-out variable, or <see langword="null"/> for none.</param>
    /// <returns><see langword="true"/> when the check should be skipped; otherwise <see langword="false"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="getEnvironmentVariable"/> is null.</exception>
    public static bool IsUpdateCheckDisabled(
        Func<string, string?> getEnvironmentVariable,
        string? optOutEnvironmentVariable)
    {
        ArgumentNullException.ThrowIfNull(getEnvironmentVariable);

        return IsSet(getEnvironmentVariable(ContinuousIntegrationEnvironmentVariable)) ||
               (!string.IsNullOrWhiteSpace(optOutEnvironmentVariable) &&
                IsSet(getEnvironmentVariable(optOutEnvironmentVariable!)));

        static bool IsSet(string? value)
        {
            var trimmed = value?.Trim();
            return trimmed is not null &&
                   (trimmed == "1" || trimmed.Equals("true", StringComparison.OrdinalIgnoreCase));
        }
    }

    /// <summary>
    /// Tells whether a version is the one a local development build gets (1.0.0.0, also written 1.0 or 1.0.0),
    /// for which the update check is skipped.
    /// </summary>
    /// <param name="version">The version of the running tool.</param>
    /// <returns><see langword="true"/> for a development build; otherwise <see langword="false"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="version"/> is null.</exception>
    public static bool IsDevelopmentVersion(Version version)
    {
        ArgumentNullException.ThrowIfNull(version);

        return Normalize(version) == DevelopmentVersion;
    }

    /// <summary>
    /// Gets the stable version on the feed that is newer than <paramref name="currentVersion"/>, within the given time budget.
    /// Missing version parts count as 0, so 1.2.3 on the feed is not newer than a running 1.2.3.0.
    /// </summary>
    /// <param name="nugetFeedClient">The client the latest version is looked up with.</param>
    /// <param name="packageId">The NuGet package id of the tool.</param>
    /// <param name="currentVersion">The version of the running tool.</param>
    /// <param name="budget">The time the lookup may take; when it runs out, the result is <see langword="null"/>
    /// even when the client does not honour cancellation.</param>
    /// <param name="cancellationToken">A token that cancels the lookup.</param>
    /// <returns>
    /// The newer version, or <see langword="null"/> when the current version is the latest, the lookup fails or throws,
    /// the budget runs out, or the token is cancelled. Never throws for those cases.
    /// </returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="nugetFeedClient"/> or <paramref name="currentVersion"/> is null.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="packageId"/> is null, empty or white space.</exception>
    public static async Task<Version?> TryGetNewerVersionAsync(
        INugetFeedClient nugetFeedClient,
        string packageId,
        Version currentVersion,
        TimeSpan budget,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(nugetFeedClient);
        ArgumentException.ThrowIfNullOrWhiteSpace(packageId);
        ArgumentNullException.ThrowIfNull(currentVersion);

        try
        {
            using var cts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
            cts.CancelAfter(budget);

            var latestVersion = await nugetFeedClient
                .GetLatestStableVersionAsync(packageId, cts.Token)
                .WaitAsync(cts.Token)
                .ConfigureAwait(false);

            return latestVersion is not null && Normalize(latestVersion) > Normalize(currentVersion)
                ? latestVersion
                : null;
        }
        catch (Exception)
        {
            return null;
        }
    }

    /// <summary>
    /// Writes the "Update available" panel with the current and the latest version and the
    /// <c>dotnet tool update -g &lt;package&gt;</c> command.
    /// </summary>
    /// <param name="console">The console the panel is written to.</param>
    /// <param name="packageId">The NuGet package id of the tool.</param>
    /// <param name="currentVersion">The version of the running tool.</param>
    /// <param name="latestVersion">The newer version on the feed.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="console"/>, <paramref name="currentVersion"/> or <paramref name="latestVersion"/> is null.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="packageId"/> is null, empty or white space.</exception>
    public static void WriteUpdateAvailable(
        IAnsiConsole console,
        string packageId,
        Version currentVersion,
        Version latestVersion)
    {
        ArgumentNullException.ThrowIfNull(console);
        ArgumentException.ThrowIfNullOrWhiteSpace(packageId);
        ArgumentNullException.ThrowIfNull(currentVersion);
        ArgumentNullException.ThrowIfNull(latestVersion);

        var content = Markup.FromInterpolated(
            CultureInfo.InvariantCulture,
            $"[yellow]A new version is available![/]\n\n  Current: [dim]{currentVersion}[/]\n  Latest:  [green]{latestVersion}[/]\n\n[blue]dotnet tool update -g {packageId}[/]");

        console.WriteLine();
        console.Write(
            new Panel(content)
                .Header("[yellow] Update available [/]")
                .BorderColor(Color.Yellow)
                .Padding(1, 0, 1, 0));
        console.WriteLine();
    }

    /// <summary>
    /// Runs the update check with default settings for the given tool package: nuget.org, a 2 second budget,
    /// the entry assembly version and <see cref="AnsiConsole.Console"/>.
    /// </summary>
    /// <param name="args">The command-line arguments of the tool.</param>
    /// <param name="packageId">The NuGet package id of the tool.</param>
    /// <param name="cancellationToken">A token that cancels the check.</param>
    /// <returns>The newer version that was announced, or <see langword="null"/> when nothing was written.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="args"/> is null.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="packageId"/> is null, empty or white space.</exception>
    public static Task<Version?> CheckForUpdatesAsync(
        string[] args,
        string packageId,
        CancellationToken cancellationToken = default)
        => CheckForUpdatesAsync(args, new CliUpdateCheckOptions(packageId), cancellationToken);

    /// <summary>
    /// Runs the update check: unless the command line, the environment or a development build says to skip it,
    /// looks up the latest stable version within the budget and, when it is newer than the running version,
    /// writes the "Update available" panel (see <see cref="WriteUpdateAvailable"/>).
    /// </summary>
    /// <param name="args">The command-line arguments of the tool.</param>
    /// <param name="options">The settings of the check.</param>
    /// <param name="cancellationToken">A token that cancels the check.</param>
    /// <returns>The newer version that was announced, or <see langword="null"/> when nothing was written.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="args"/> or <paramref name="options"/> is null.</exception>
    public static async Task<Version?> CheckForUpdatesAsync(
        string[] args,
        CliUpdateCheckOptions options,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(args);
        ArgumentNullException.ThrowIfNull(options);

        try
        {
            if (!ShouldCheckForUpdates(args) ||
                IsUpdateCheckDisabled(options.GetEnvironmentVariable, options.OptOutEnvironmentVariable))
            {
                return null;
            }

            var currentVersion = options.CurrentVersion ?? Assembly.GetEntryAssembly()?.GetName().Version;
            if (currentVersion is null || IsDevelopmentVersion(currentVersion))
            {
                return null;
            }

            var nugetFeedClient = options.NugetFeedClient ?? new NugetFeedClient();
            var latestVersion = await TryGetNewerVersionAsync(
                    nugetFeedClient,
                    options.PackageId,
                    currentVersion,
                    options.Budget,
                    cancellationToken)
                .ConfigureAwait(false);

            if (latestVersion is null)
            {
                return null;
            }

            WriteUpdateAvailable(options.Console ?? AnsiConsole.Console, options.PackageId, currentVersion, latestVersion);
            return latestVersion;
        }
        catch (Exception)
        {
            // Nothing about the update check may stop the command.
            return null;
        }
    }

    private static Version Normalize(Version version)
        => new(
            version.Major,
            version.Minor,
            System.Math.Max(version.Build, 0),
            System.Math.Max(version.Revision, 0));
}