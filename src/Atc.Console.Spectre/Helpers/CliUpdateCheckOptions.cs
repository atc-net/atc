namespace Atc.Console.Spectre.Helpers;

/// <summary>
/// Settings for the start-up update check of a CLI tool that is installed as a .NET tool,
/// used by <see cref="CliUpdateCheckHelper.CheckForUpdatesAsync(string[], CliUpdateCheckOptions, CancellationToken)"/>.
/// </summary>
public sealed class CliUpdateCheckOptions
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CliUpdateCheckOptions"/> class.
    /// </summary>
    /// <param name="packageId">The NuGet package id of the tool, for example <c>atc-rest-api-gen</c>.</param>
    /// <exception cref="ArgumentException">Thrown when <paramref name="packageId"/> is null, empty or white space.</exception>
    public CliUpdateCheckOptions(string packageId)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(packageId);

        PackageId = packageId;
    }

    /// <summary>
    /// Gets the NuGet package id of the tool, which is looked up on the feed and shown in the update command.
    /// </summary>
    public string PackageId { get; }

    /// <summary>
    /// Gets or sets the version of the running tool.
    /// When <see langword="null"/> (the default), the version of the entry assembly is used.
    /// </summary>
    public Version? CurrentVersion { get; set; }

    /// <summary>
    /// Gets or sets the name of an environment variable that turns the check off when it is <c>1</c> or <c>true</c>,
    /// for example <c>MY_TOOL_NO_UPDATE_CHECK</c>. The check is always off when <c>CI</c> is set the same way.
    /// </summary>
    public string? OptOutEnvironmentVariable { get; set; }

    /// <summary>
    /// Gets or sets the time the whole check may take before the tool goes on without it.
    /// Defaults to <see cref="CliUpdateCheckHelper.DefaultBudget"/> (2 seconds).
    /// </summary>
    public TimeSpan Budget { get; set; } = CliUpdateCheckHelper.DefaultBudget;

    /// <summary>
    /// Gets or sets the client the latest version is looked up with.
    /// When <see langword="null"/> (the default), a <see cref="Atc.Nuget.NugetFeedClient"/> for nuget.org is used.
    /// </summary>
    public INugetFeedClient? NugetFeedClient { get; set; }

    /// <summary>
    /// Gets or sets the console the update notice is written to.
    /// When <see langword="null"/> (the default), <see cref="AnsiConsole.Console"/> is used.
    /// </summary>
    public IAnsiConsole? Console { get; set; }

    /// <summary>
    /// Gets or sets the function that reads an environment variable by name.
    /// Defaults to <see cref="Environment.GetEnvironmentVariable(string)"/>; replace it to control the environment in tests.
    /// </summary>
    public Func<string, string?> GetEnvironmentVariable { get; set; } = Environment.GetEnvironmentVariable;
}