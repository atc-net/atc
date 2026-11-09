namespace Atc.Tests.Nuget;

/// <summary>
/// The feed is read through a stub handler, so no test here touches the network
/// except the ones in the Integration category.
/// </summary>
[SuppressMessage("Reliability", "CA2000:Dispose objects before losing scope", Justification = "The HttpClient owns the stub handler; both live for the test only.")]
public sealed class NugetFeedClientTests
{
    private static readonly TimeSpan Budget = TimeSpan.FromSeconds(2);

    [Fact]
    public async Task GetLatestStableVersionAsync_NewestIsAPrerelease_ReturnsTheNewestStableVersion()
    {
        // Arrange
        var sut = CreateClient("""{ "versions": [ "1.0.341", "2.1.0", "2.10.0+build.7", "3.0.0-preview.1" ] }""");

        // Act
        var actual = await sut.GetLatestStableVersionAsync("Contoso.Package", TestContext.Current.CancellationToken);

        // Assert
        actual.Should().Be(new Version(2, 10, 0));
    }

    [Fact]
    public Task GetLatestStableVersionAsync_SingleStableVersion_ReturnsIt()
    {
        // Arrange
        var sut = CreateClient("""{ "versions": [ "1.2.3" ] }""");

        // Act
        var lookup = sut.GetLatestStableVersionAsync("Contoso.Package", TestContext.Current.CancellationToken);

        // Assert
        return AssertVersionAsync(lookup, new Version(1, 2, 3));
    }

    [Fact]
    public async Task GetLatestStableVersionAsync_OnlyPrereleases_ReturnsNull()
    {
        // Arrange
        var sut = CreateClient("""{ "versions": [ "3.0.0-preview.1", "3.0.0-rc.1" ] }""");

        // Act
        var actual = await sut.GetLatestStableVersionAsync("Contoso.Package", TestContext.Current.CancellationToken);

        // Assert
        actual.Should().BeNull();
    }

    [Fact]
    public async Task GetLatestStableVersionAsync_RequestsTheLowercaseIdFromTheFlatContainer()
    {
        // Arrange
        var handler = new StubHandler("""{ "versions": [ "1.2.3" ] }""");
        var sut = new NugetFeedClient(new HttpClient(handler));

        // Act
        await sut.GetLatestStableVersionAsync("Contoso.Package", TestContext.Current.CancellationToken);

        // Assert
        handler.RequestUris.Should().ContainSingle()
            .Which.AbsoluteUri.Should().Be("https://api.nuget.org/v3-flatcontainer/contoso.package/index.json");
    }

    [Theory]
    [InlineData("https://feed.example.com/flat")]
    [InlineData("https://feed.example.com/flat/")]
    public async Task GetLatestStableVersionAsync_WithAnotherFeed_RequestsThatFeed(
        string flatContainer)
    {
        // Arrange
        var handler = new StubHandler("""{ "versions": [ "1.2.3" ] }""");
        var sut = new NugetFeedClient(new HttpClient(handler), new Uri(flatContainer));

        // Act
        var actual = await sut.GetLatestStableVersionAsync("Contoso.Package", TestContext.Current.CancellationToken);

        // Assert
        actual.Should().Be(new Version(1, 2, 3));
        handler.RequestUris.Should().ContainSingle()
            .Which.AbsoluteUri.Should().Be("https://feed.example.com/flat/contoso.package/index.json");
    }

    [Fact]
    public async Task GetLatestStableVersionAsync_AskedAgain_AnswersFromTheCacheIgnoringCase()
    {
        // Arrange
        var handler = new StubHandler("""{ "versions": [ "1.2.3" ] }""");
        var sut = new NugetFeedClient(new HttpClient(handler));

        // Act
        var first = await sut.GetLatestStableVersionAsync("Contoso.Package", TestContext.Current.CancellationToken);
        var second = await sut.GetLatestStableVersionAsync("contoso.package", TestContext.Current.CancellationToken);

        // Assert
        first.Should().Be(new Version(1, 2, 3));
        second.Should().Be(first);
        handler.RequestUris.Should().HaveCount(1);
    }

    [Fact]
    public async Task GetLatestStableVersionAsync_AfterAFailure_TriesAgain()
    {
        // Arrange
        var handler = new StubHandler("boom", "text/plain", HttpStatusCode.ServiceUnavailable);
        var sut = new NugetFeedClient(new HttpClient(handler));

        // Act
        await sut.GetLatestStableVersionAsync("Contoso.Package", TestContext.Current.CancellationToken);
        await sut.GetLatestStableVersionAsync("Contoso.Package", TestContext.Current.CancellationToken);

        // Assert
        handler.RequestUris.Should().HaveCount(2);
    }

    [Theory]
    [InlineData("<html><body>Sign in</body></html>", "text/html")]
    [InlineData("""{ "versions": [ 1, 2 ] }""", "application/json")]
    [InlineData("""{ "versions": "1.2.3" }""", "application/json")]
    [InlineData("""[ "1.2.3" ]""", "application/json")]
    [InlineData("""{ "versions": [] }""", "application/json")]
    [InlineData("""{ }""", "application/json")]
    public async Task GetLatestStableVersionAsync_UnexpectedContent_ReturnsNullWithoutThrowing(
        string content,
        string mediaType)
    {
        // Arrange
        var sut = CreateClient(content, mediaType);

        // Act
        var actual = await sut.GetLatestStableVersionAsync("Contoso.Package", TestContext.Current.CancellationToken);

        // Assert
        actual.Should().BeNull();
    }

    [Theory]
    [InlineData(HttpStatusCode.NotFound)]
    [InlineData(HttpStatusCode.InternalServerError)]
    public async Task GetLatestStableVersionAsync_NonSuccessStatus_ReturnsNull(
        HttpStatusCode statusCode)
    {
        // Arrange
        var sut = new NugetFeedClient(new HttpClient(new StubHandler("""{ "versions": [ "1.2.3" ] }""", statusCode: statusCode)));

        // Act
        var actual = await sut.GetLatestStableVersionAsync("Contoso.Package", TestContext.Current.CancellationToken);

        // Assert
        actual.Should().BeNull();
    }

    [Fact]
    public async Task GetLatestStableVersionAsync_HandlerThrows_ReturnsNull()
    {
        // Arrange
        var sut = new NugetFeedClient(new HttpClient(new ThrowingHandler()));

        // Act
        var actual = await sut.GetLatestStableVersionAsync("Contoso.Package", TestContext.Current.CancellationToken);

        // Assert
        actual.Should().BeNull();
    }

    [Fact]
    public async Task GetLatestStableVersionAsync_ResponseNeverCompletes_ReturnsNullWhenCancelled()
    {
        // Arrange
        var sut = new NugetFeedClient(new HttpClient(new HangingHandler()));
        using var cts = new CancellationTokenSource(Budget);
        var stopwatch = Stopwatch.StartNew();

        // Act
        var actual = await sut.GetLatestStableVersionAsync("Contoso.Package", cts.Token);

        // Assert
        stopwatch.Stop();
        actual.Should().BeNull();

        // The token ended the wait, not the hang - well short of it even on a loaded machine.
        stopwatch.Elapsed.Should().BeLessThan(HangingHandler.Hang / 2);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("  ")]
    public Task GetLatestStableVersionAsync_InvalidPackageId_Throws(
        string? packageId)
    {
        // Arrange
        var sut = CreateClient("""{ "versions": [ "1.2.3" ] }""");

        // Act
        var act = () => sut.GetLatestStableVersionAsync(packageId!, TestContext.Current.CancellationToken);

        // Assert
        return act.Should().ThrowAsync<ArgumentException>();
    }

    [Fact]
    public void Constructor_RelativeFlatContainerUri_Throws()
    {
        // Act
        var act = () => new NugetFeedClient(new HttpClient(), new Uri("flat", UriKind.Relative));

        // Assert
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    [Trait("Category", "Integration")]
    public async Task GetLatestStableVersionAsync_FromNugetOrg_ReturnsAVersion()
    {
        // Arrange
        var sut = new NugetFeedClient();

        // Act
        var actual = await sut.GetLatestStableVersionAsync("Atc", TestContext.Current.CancellationToken);

        // Assert
        actual.Should().NotBeNull();
        actual!.Major.Should().BeGreaterThan(1);
    }

    private static async Task AssertVersionAsync(
        Task<Version?> lookup,
        Version expected)
        => (await lookup).Should().Be(expected);

    private static NugetFeedClient CreateClient(
        string content,
        string mediaType = "application/json")
        => new(new HttpClient(new StubHandler(content, mediaType)));

    private sealed class StubHandler(
        string content,
        string mediaType = "application/json",
        HttpStatusCode statusCode = HttpStatusCode.OK) : HttpMessageHandler
    {
        public List<Uri> RequestUris { get; } = [];

        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            RequestUris.Add(request.RequestUri!);
            return Task.FromResult(new HttpResponseMessage(statusCode)
            {
                Content = new StringContent(content, Encoding.UTF8, mediaType),
            });
        }
    }

    private sealed class ThrowingHandler : HttpMessageHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
            => throw new HttpRequestException("offline");
    }

    private sealed class HangingHandler : HttpMessageHandler
    {
        public static readonly TimeSpan Hang = TimeSpan.FromSeconds(30);

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            await Task.Delay(Hang, cancellationToken);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}