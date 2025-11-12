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
        var (n, s, d, desc, data) = actual[0];

        n.Should().Be(name);
        s.Should().Be(status);
        d.Should().Be(duration);
        desc.Should().Be(description);
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
        var (n, s, d, desc, dataBag) = actual[0];

        n.Should().Be(name);
        s.Should().Be(status);
        d.Should().Be(duration);
        desc.Should().Be(description);

        dataBag
            .Should().NotBeNull()
            .And.HaveCount(1);
        dataBag!["failures"].Should().Be(3);
    }
}