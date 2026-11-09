namespace Atc.Console.Spectre.Tests.Helpers;

public class CliUpdateCheckHelperTests
{
    private const string PackageId = "contoso-tool";
    private const string OptOutVariable = "CONTOSO_TOOL_NO_UPDATE_CHECK";
    private static readonly TimeSpan Budget = TimeSpan.FromSeconds(2);

    [Theory]
    [InlineData("--help")]
    [InlineData("-h")]
    [InlineData("--version")]
    [InlineData("-v")]
    [InlineData("spec validate --help")]
    [InlineData("spec validate -s api.yaml -h")]
    [InlineData("")]
    public void ShouldCheckForUpdates_HelpVersionOrNoArguments_ReturnsFalse(
        string commandLine)
    {
        // Arrange
        var args = commandLine.Length == 0 ? [] : commandLine.Split(' ');

        // Act & Assert
        CliUpdateCheckHelper.ShouldCheckForUpdates(args).Should().BeFalse();
    }

    [Theory]
    [InlineData("spec validate -s api.yaml")]
    [InlineData("hello Phil --count 4")]
    public void ShouldCheckForUpdates_Command_ReturnsTrue(string commandLine)
        => CliUpdateCheckHelper.ShouldCheckForUpdates(commandLine.Split(' ')).Should().BeTrue();

    [Theory]
    [InlineData(null, null, false)]
    [InlineData("1", null, true)]
    [InlineData("true", null, true)]
    [InlineData("TRUE", null, true)]
    [InlineData("0", null, false)]
    [InlineData(null, "true", true)]
    [InlineData(null, " 1 ", true)]
    [InlineData(null, "false", false)]
    public void IsUpdateCheckDisabled_FromTheEnvironment(
        string? optOut,
        string? ci,
        bool expected)
    {
        // Arrange
        var environment = new Dictionary<string, string?>(StringComparer.Ordinal)
        {
            [OptOutVariable] = optOut,
            [CliUpdateCheckHelper.ContinuousIntegrationEnvironmentVariable] = ci,
        };

        Func<string, string?> getEnvironmentVariable = name => environment.GetValueOrDefault(name);
        var optOutEnvironmentVariable = OptOutVariable;

        // Act
        var actual = CliUpdateCheckHelper.IsUpdateCheckDisabled(getEnvironmentVariable, optOutEnvironmentVariable);

        // Assert
        actual.Should().Be(expected);
    }

    [Fact]
    public void IsUpdateCheckDisabled_WithoutOptOutVariable_OnlyCiCounts()
    {
        // Arrange
        var environment = new Dictionary<string, string?>(StringComparer.Ordinal)
        {
            [OptOutVariable] = "true",
        };

        // Act
        var actual = CliUpdateCheckHelper.IsUpdateCheckDisabled(name => environment.GetValueOrDefault(name), optOutEnvironmentVariable: null);

        // Assert
        actual.Should().BeFalse();
    }

    [Theory]
    [InlineData("1.0.0.0", true)]
    [InlineData("1.0.0", true)]
    [InlineData("1.0", true)]
    [InlineData("1.0.0.1", false)]
    [InlineData("1.2.3", false)]
    public void IsDevelopmentVersion_OnlyForOnePointZero(
        string version,
        bool expected)
        => CliUpdateCheckHelper.IsDevelopmentVersion(Version.Parse(version)).Should().Be(expected);

    [Fact]
    public Task TryGetNewerVersionAsync_NewerVersionOnTheFeed_ReturnsIt()
    {
        // Arrange
        var nugetFeedClient = new StubNugetFeedClient(new Version(9, 9, 9));
        var packageId = PackageId;
        var currentVersion = new Version(1, 2, 3);
        var budget = Budget;
        var cancellationToken = TestContext.Current.CancellationToken;

        // Act
        var lookup = CliUpdateCheckHelper.TryGetNewerVersionAsync(nugetFeedClient, packageId, currentVersion, budget, cancellationToken);

        // Assert
        return AssertVersionAndPackageAsync(lookup, new Version(9, 9, 9), nugetFeedClient);
    }

    [Theory]
    [InlineData("1.2.3")]
    [InlineData("1.2.3.0")]
    [InlineData("0.0.1")]
    [InlineData(null)]
    public async Task TryGetNewerVersionAsync_CurrentIsLatestOrLookupFails_ReturnsNull(
        string? published)
    {
        // Arrange
        var client = new StubNugetFeedClient(published is null ? null : Version.Parse(published));

        // Act
        var actual = await CliUpdateCheckHelper.TryGetNewerVersionAsync(client, PackageId, new Version(1, 2, 3, 0), Budget, TestContext.Current.CancellationToken);

        // Assert
        actual.Should().BeNull();
    }

    [Fact]
    public async Task TryGetNewerVersionAsync_LookupThrows_ReturnsNull()
    {
        // Arrange
        var client = new StubNugetFeedClient(new Version(9, 9, 9), throwOnLookup: true);

        // Act
        var actual = await CliUpdateCheckHelper.TryGetNewerVersionAsync(client, PackageId, new Version(1, 2, 3), Budget, TestContext.Current.CancellationToken);

        // Assert
        actual.Should().BeNull();
    }

    [Fact]
    public async Task TryGetNewerVersionAsync_LookupNeverCompletes_ReturnsNullWithinBudget()
    {
        // Arrange
        var lookup = TimeSpan.FromSeconds(30);
        var client = new StubNugetFeedClient(new Version(9, 9, 9), delay: lookup);
        var stopwatch = Stopwatch.StartNew();

        // Act
        var actual = await CliUpdateCheckHelper.TryGetNewerVersionAsync(client, PackageId, new Version(1, 2, 3), Budget, TestContext.Current.CancellationToken);

        // Assert
        stopwatch.Stop();
        actual.Should().BeNull();

        // The budget ended the wait, not the lookup - well short of it even on a loaded machine.
        stopwatch.Elapsed.Should().BeLessThan(lookup / 2);
    }

    [Fact]
    public void WriteUpdateAvailable_WritesBothVersionsAndTheUpdateCommand()
    {
        // Arrange
        using var testConsole = new TestConsole();
        var console = testConsole.Console;
        var packageId = PackageId;
        var currentVersion = new Version(1, 2, 3);
        var latestVersion = new Version(2, 0, 0);

        // Act
        CliUpdateCheckHelper.WriteUpdateAvailable(console, packageId, currentVersion, latestVersion);

        // Assert
        testConsole.Output.Should().Contain("Update available")
            .And.Contain("1.2.3")
            .And.Contain("2.0.0")
            .And.Contain("dotnet tool update -g contoso-tool");
    }

    [Fact]
    public Task CheckForUpdatesAsync_NewerVersion_WritesThePanelAndReturnsTheVersion()
    {
        // Arrange
        var testConsole = new TestConsole();
        string[] args = ["generate"];
        var options = CreateOptions(testConsole, new StubNugetFeedClient(new Version(2, 0, 0)));
        var cancellationToken = TestContext.Current.CancellationToken;

        // Act
        var check = CliUpdateCheckHelper.CheckForUpdatesAsync(args, options, cancellationToken);

        // Assert
        return AssertAnnouncedAsync(check, new Version(2, 0, 0), testConsole);
    }

    [Theory]
    [InlineData("--help", null, null, "1.2.3")]
    [InlineData("generate", "true", null, "1.2.3")]
    [InlineData("generate", null, "1", "1.2.3")]
    [InlineData("generate", null, null, "1.0.0.0")]
    [InlineData("generate", null, null, "2.0.0")]
    public async Task CheckForUpdatesAsync_Skipped_WritesNothingAndDoesNotLookUp(
        string argument,
        string? ci,
        string? optOut,
        string currentVersion)
    {
        // Arrange
        using var testConsole = new TestConsole();
        var client = new StubNugetFeedClient(new Version(2, 0, 0));
        var environment = new Dictionary<string, string?>(StringComparer.Ordinal)
        {
            [CliUpdateCheckHelper.ContinuousIntegrationEnvironmentVariable] = ci,
            [OptOutVariable] = optOut,
        };
        var options = CreateOptions(testConsole, client);
        options.CurrentVersion = Version.Parse(currentVersion);
        options.GetEnvironmentVariable = name => environment.GetValueOrDefault(name);

        // Act
        var actual = await CliUpdateCheckHelper.CheckForUpdatesAsync([argument], options, TestContext.Current.CancellationToken);

        // Assert
        actual.Should().BeNull();
        testConsole.Output.Should().BeEmpty();
    }

    [Fact]
    public Task CheckForUpdatesAsync_PackageIdOverload_HelpArgument_ReturnsNullWithoutLookup()
    {
        // Arrange
        string[] args = [CommandConstants.ArgumentLongHelp];
        var packageId = PackageId;
        var cancellationToken = TestContext.Current.CancellationToken;

        // Act
        var check = CliUpdateCheckHelper.CheckForUpdatesAsync(args, packageId, cancellationToken);

        // Assert
        return AssertNullAsync(check);
    }

    [Fact]
    public void CliUpdateCheckOptions_HasTheDefaults()
    {
        // Act
        var options = new CliUpdateCheckOptions(PackageId);

        // Assert
        options.PackageId.Should().Be(PackageId);
        options.Budget.Should().Be(CliUpdateCheckHelper.DefaultBudget);
        options.CurrentVersion.Should().BeNull();
        options.NugetFeedClient.Should().BeNull();
        options.Console.Should().BeNull();
        options.OptOutEnvironmentVariable.Should().BeNull();
    }

    private static async Task AssertVersionAndPackageAsync(
        Task<Version?> lookup,
        Version expected,
        StubNugetFeedClient nugetFeedClient)
    {
        (await lookup).Should().Be(expected);
        nugetFeedClient.RequestedPackageId.Should().Be(PackageId);
    }

    private static async Task AssertAnnouncedAsync(
        Task<Version?> check,
        Version expected,
        TestConsole testConsole)
    {
        using (testConsole)
        {
            (await check).Should().Be(expected);
            testConsole.Output.Should().Contain("dotnet tool update -g contoso-tool");
        }
    }

    private static async Task AssertNullAsync(Task<Version?> check)
        => (await check).Should().BeNull();

    private static CliUpdateCheckOptions CreateOptions(
        TestConsole testConsole,
        INugetFeedClient client)
        => new(PackageId)
        {
            CurrentVersion = new Version(1, 2, 3),
            OptOutEnvironmentVariable = OptOutVariable,
            NugetFeedClient = client,
            Console = testConsole.Console,
            GetEnvironmentVariable = _ => null,
            Budget = Budget,
        };

    private sealed class StubNugetFeedClient(
        Version? latestVersion,
        bool throwOnLookup = false,
        TimeSpan? delay = null) : INugetFeedClient
    {
        public string? RequestedPackageId { get; private set; }

        public async Task<Version?> GetLatestStableVersionAsync(
            string packageId,
            CancellationToken cancellationToken)
        {
            RequestedPackageId = packageId;
            if (throwOnLookup)
            {
                throw new InvalidOperationException("The feed answered nonsense.");
            }

            if (delay is { } wait)
            {
                // Ignores the token on purpose: the budget must hold even when the lookup does not cooperate.
                await Task.Delay(wait, CancellationToken.None);
            }

            return latestVersion;
        }
    }
}