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

    [Fact]
    public void CreateJson_Serialization_With_Exception_Does_Not_Throw()
    {
        // Arrange
        const string applicationName = "MyTestApp";
        var exception = new InvalidOperationException("Cache connection failed");

        var entries = new Dictionary<string, HealthReportEntry>(StringComparer.Ordinal)
        {
            ["CacheHealthCheck"] = new(
                HealthStatus.Unhealthy,
                "Failed to set value in cache",
                TimeSpan.FromMilliseconds(150),
                exception,
                data: null),
        };

        var report = new HealthReport(entries, TimeSpan.FromMilliseconds(150));

        var response = new HealthCheckResponse(
            applicationName,
            report.Entries.ToHealthChecks(),
            report.Status,
            report.TotalDuration);

        var jsonOptions = JsonSerializerOptionsFactory.Create();

        // Act
        var json = System.Text.Json.JsonSerializer.Serialize(response, jsonOptions);

        // Assert
        json.Should().NotBeNullOrEmpty();
        json.Should().Contain("Cache connection failed");
        json.Should().Contain("Failed to set value in cache");
        json.Should().NotContain("TargetSite");
        json.Should().NotContain("MethodBase");
    }

    [Fact]
    public void CreateJson_Serialization_With_Exception_In_Data_Does_Not_Throw()
    {
        // Arrange
        const string applicationName = "MyTestApp";
        var exception = new InvalidOperationException("Redis timeout");

        var data = new Dictionary<string, object>(StringComparer.Ordinal)
        {
            ["error"] = exception,
            ["retries"] = 3,
        };

        var entries = new Dictionary<string, HealthReportEntry>(StringComparer.Ordinal)
        {
            ["CacheHealthCheck"] = new(
                HealthStatus.Unhealthy,
                "Cache is unreachable",
                TimeSpan.FromMilliseconds(200),
                exception: null,
                data),
        };

        var report = new HealthReport(entries, TimeSpan.FromMilliseconds(200));

        var response = new HealthCheckResponse(
            applicationName,
            report.Entries.ToHealthChecks(),
            report.Status,
            report.TotalDuration);

        var jsonOptions = JsonSerializerOptionsFactory.Create();

        // Act
        var json = System.Text.Json.JsonSerializer.Serialize(response, jsonOptions);

        // Assert
        json.Should().NotBeNullOrEmpty();
        json.Should().Contain("Redis timeout");
        json.Should().NotContain("TargetSite");
    }
}