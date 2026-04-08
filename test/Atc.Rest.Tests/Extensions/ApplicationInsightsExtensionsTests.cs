namespace Atc.Rest.Tests.Extensions;

public class ApplicationInsightsExtensionsTests
{
    [Fact]
    public void GetApiName()
    {
        // Arrange
        var serviceCollection = new ServiceCollection();
        var initialCount = serviceCollection.Count;

        // Act
        var actual = serviceCollection.AddCallingIdentityTelemetryInitializer();

        // Assert
        Assert.NotNull(actual);
        Assert.True(actual.Count > initialCount);
    }
}