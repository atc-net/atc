namespace Atc.Rest.HealthChecks.Tests.Extensions;

public class HealthReportEntryExtensionsTests
{
    [Fact]
    public void ToHealthCheck_Without_Data()
    {
        // Arrange
        const string name = "MyHealthCheck";
        const string description = "No data";
        var duration = TimeSpan.FromSeconds(1);
        const HealthStatus status = HealthStatus.Healthy;

        var entry = new KeyValuePair<string, HealthReportEntry>(
            name,
            new HealthReportEntry(
                status,
                description,
                duration,
                exception: null,
                data: null));

        // Act
        var actual = entry.ToHealthCheck();

        // Assert
        actual.Should().NotBeNull();
        actual.Name.Should().Be(name);
        actual.Status.Should().Be(status);
        actual.Duration.Should().Be(duration);
        actual.Description.Should().Be(description);
        actual.Data.Should().BeNull();
    }

    [Fact]
    public void ToHealthCheck_With_Data()
    {
        // Arrange
        const string name = "MyHealthCheck";
        const string description = "Has data";
        var duration = TimeSpan.FromSeconds(1);
        const HealthStatus status = HealthStatus.Degraded;

        var data = new Dictionary<string, object>(StringComparer.Ordinal)
        {
            ["isRunning"] = true,
            ["duration"] = duration,
        };

        var entry = new KeyValuePair<string, HealthReportEntry>(
            name,
            new HealthReportEntry(
                status,
                description,
                duration,
                exception: null,
                data));

        // Act
        var actual = entry.ToHealthCheck();

        // Assert
        actual.Name.Should().Be(name);
        actual.Status.Should().Be(status);
        actual.Duration.Should().Be(duration);
        actual.Description.Should().Be(description);

        actual.Data.Should().NotBeNull();
        actual
            .Data.Should().HaveCount(2)
            .And.ContainKey("isRunning")
            .And.ContainKey("duration");

        actual.Data!["isRunning"].Should().Be(true);
        actual.Data!["duration"].Should().Be(duration);
    }

    [Fact]
    public void ToHealthCheck_With_Exception()
    {
        // Arrange
        const string name = "MyHealthCheck";
        const string description = "Failed";
        var duration = TimeSpan.FromSeconds(1);
        const HealthStatus status = HealthStatus.Unhealthy;
        var exception = new InvalidOperationException("Something went wrong");

        var entry = new KeyValuePair<string, HealthReportEntry>(
            name,
            new HealthReportEntry(
                status,
                description,
                duration,
                exception,
                data: null));

        // Act
        var actual = entry.ToHealthCheck();

        // Assert
        actual.Should().NotBeNull();
        actual.Name.Should().Be(name);
        actual.Status.Should().Be(status);
        actual.Duration.Should().Be(duration);
        actual.Description.Should().Be(description);
        actual.ExceptionMessage.Should().Be("Something went wrong");
        actual.Data.Should().BeNull();
    }

    [Fact]
    public void ToHealthCheck_Sanitizes_Exception_In_Data()
    {
        // Arrange
        const string name = "MyHealthCheck";
        var duration = TimeSpan.FromSeconds(1);
        const HealthStatus status = HealthStatus.Unhealthy;
        var exception = new InvalidOperationException("Cache connection failed");

        var data = new Dictionary<string, object>(StringComparer.Ordinal)
        {
            ["error"] = exception,
            ["retries"] = 3,
        };

        var entry = new KeyValuePair<string, HealthReportEntry>(
            name,
            new HealthReportEntry(
                status,
                "Has exception in data",
                duration,
                exception: null,
                data));

        // Act
        var actual = entry.ToHealthCheck();

        // Assert
        actual.Data.Should().NotBeNull().And.HaveCount(2);
        actual.Data!["error"].Should().Be("Cache connection failed");
        actual.Data!["retries"].Should().Be(3);
    }

    [Fact]
    public void ToHealthCheck_Preserves_NonException_Objects_In_Data()
    {
        // Arrange
        const string name = "MyHealthCheck";
        var duration = TimeSpan.FromSeconds(1);
        const HealthStatus status = HealthStatus.Degraded;

        var data = new Dictionary<string, object>(StringComparer.Ordinal)
        {
            ["label"] = "healthy",
            ["flag"] = true,
            ["count"] = 42,
            ["duration"] = TimeSpan.FromMilliseconds(500),
        };

        var entry = new KeyValuePair<string, HealthReportEntry>(
            name,
            new HealthReportEntry(
                status,
                "Mixed data types",
                duration,
                exception: null,
                data));

        // Act
        var actual = entry.ToHealthCheck();

        // Assert
        actual.Data.Should().NotBeNull().And.HaveCount(4);
        actual.Data!["label"].Should().Be("healthy");
        actual.Data!["flag"].Should().Be(true);
        actual.Data!["count"].Should().Be(42);
        actual.Data!["duration"].Should().Be(TimeSpan.FromMilliseconds(500));
    }

    [Fact]
    public void ToHealthCheck_Preserves_ResourceHealthCheck_In_Data()
    {
        // Arrange
        const string name = "MyHealthCheck";
        var duration = TimeSpan.FromSeconds(1);
        const HealthStatus status = HealthStatus.Healthy;

        var resource = new ResourceHealthCheck("redis", HealthStatus.Healthy, "OK", TimeSpan.FromMilliseconds(5));
        var data = new Dictionary<string, object>(StringComparer.Ordinal)
        {
            ["redis"] = resource,
        };

        var entry = new KeyValuePair<string, HealthReportEntry>(
            name,
            new HealthReportEntry(
                status,
                "Has resource",
                duration,
                exception: null,
                data));

        // Act
        var actual = entry.ToHealthCheck();

        // Assert
        actual.Data.Should().NotBeNull().And.HaveCount(1);
        actual.Data!["redis"].Should().Be(resource);
    }

    [Fact]
    public void ToHealthChecks_Without_Data()
    {
        // Arrange
        const string name = "Report1";
        const string description = "No data";
        var duration = TimeSpan.FromSeconds(1);
        const HealthStatus status = HealthStatus.Healthy;

        var entries = new Dictionary<string, HealthReportEntry>(StringComparer.Ordinal)
        {
            [name] = new(status, description, duration, exception: null, data: null),
        };

        // Act
        var actual = entries.ToHealthChecks();

        // Assert
        actual.Should().HaveCount(1);
        var (n, s, d, desc, exMsg, data) = actual[0];

        n.Should().Be(name);
        s.Should().Be(status);
        d.Should().Be(duration);
        desc.Should().Be(description);
        exMsg.Should().BeNull();
        data.Should().BeNull();
    }

    [Fact]
    public void ToHealthChecks_With_Data()
    {
        // Arrange
        const string name = "Report1";
        const string description = "With data";
        var duration = TimeSpan.FromSeconds(1);
        const HealthStatus status = HealthStatus.Unhealthy;

        var data = new Dictionary<string, object>(StringComparer.Ordinal)
        {
            ["failures"] = 3,
        };

        var entries = new Dictionary<string, HealthReportEntry>(StringComparer.Ordinal)
        {
            [name] = new(status, description, duration, exception: null, data),
        };

        // Act
        var actual = entries.ToHealthChecks();

        // Assert
        actual.Should().HaveCount(1);
        var (n, s, d, desc, exMsg, dataBag) = actual[0];

        n.Should().Be(name);
        s.Should().Be(status);
        d.Should().Be(duration);
        desc.Should().Be(description);
        exMsg.Should().BeNull();

        dataBag
            .Should().NotBeNull()
            .And.HaveCount(1);
        dataBag!["failures"].Should().Be(3);
    }
}