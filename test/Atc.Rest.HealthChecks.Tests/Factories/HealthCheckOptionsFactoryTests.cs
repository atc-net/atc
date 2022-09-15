namespace Atc.Rest.HealthChecks.Tests.Factories;

public class HealthCheckOptionsFactoryTests
{
    [Fact]
    public void CreateJson_Without_JsonSerializerOptions()
    {
        // Arrange
        const string applicationName = "MyTestApplicationName";

        // Act
        var healthCheckOptions = HealthCheckOptionsFactory.CreateJson(applicationName, null);

        // Assert
        Assert.NotNull(healthCheckOptions);
    }

    [Fact]
    public void CreateJson_With_JsonSerializerOptions()
    {
        // Arrange
        const string applicationName = "MyTestApplicationName";

        // Act
        var healthCheckOptions = HealthCheckOptionsFactory.CreateJson(applicationName, JsonSerializerOptionsFactory.Create());

        // Assert
        Assert.NotNull(healthCheckOptions);
    }
}