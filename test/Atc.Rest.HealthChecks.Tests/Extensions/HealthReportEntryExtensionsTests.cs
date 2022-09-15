namespace Atc.Rest.HealthChecks.Tests.Extensions;

public class HealthReportEntryExtensionsTests
{
    [Fact]
    public void ToHealthCheck_Without_Data()
    {
        // Arrange
        const string myHealthCheckName = "MyTestHealthCheckName";
        const HealthStatus myHealthStatus = HealthStatus.Healthy;
        const string myDescription = "MyMessage";
        var myTimeSpan = TimeSpan.FromSeconds(1);

        var myHealthReport = new KeyValuePair<string, HealthReportEntry>(
            myHealthCheckName,
            new HealthReportEntry(
                myHealthStatus,
                myDescription,
                myTimeSpan,
                exception: null,
                data: null));

        // Act
        var actual = myHealthReport.ToHealthCheck();

        // Assert
        actual
            .Should().NotBeNull()
            .And.Subject.Should().BeAssignableTo<HealthCheck>();

        Assert.Empty(actual.Resources);
        Assert.Equal(myHealthCheckName, actual.Name);
        Assert.Equal(myHealthStatus, actual.Status);
        Assert.Equal(myTimeSpan, actual.Duration);
    }

    [Fact]
    public void ToHealthCheck_With_Data()
    {
        // Arrange
        const string myHealthCheckName = "MyTestHealthCheckName";
        const HealthStatus myHealthStatus = HealthStatus.Healthy;
        const string myDescription = "MyMessage";
        var myTimeSpan = TimeSpan.FromSeconds(1);

        var resourceHealthChecksInput = new List<ResourceHealthCheck>()
        {
            new(myHealthCheckName, myHealthStatus, myDescription, myTimeSpan),
        };

        var data = resourceHealthChecksInput.ToIReadOnlyDictionary();

        var myHealthReport = new KeyValuePair<string, HealthReportEntry>(
            myHealthCheckName,
            new HealthReportEntry(
                myHealthStatus,
                myDescription,
                myTimeSpan,
                exception: null,
                data));

        // Act
        var actual = myHealthReport.ToHealthCheck();

        // Assert
        actual
            .Should().NotBeNull()
            .And.Subject.Should().BeAssignableTo<HealthCheck>();

        Assert.Single(actual.Resources);

        Assert.Equal(myHealthCheckName, actual.Name);
        Assert.Equal(myHealthStatus, actual.Status);
        Assert.Equal(myTimeSpan, actual.Duration);

        var (healthCheckName, healthCheckStatus, message, duration) = actual.Resources.First();

        Assert.Equal(myHealthCheckName, healthCheckName);
        Assert.Equal(myHealthStatus, healthCheckStatus);
        Assert.Equal(myDescription, message);
        Assert.Equal(myTimeSpan, duration);
    }

    [Fact]
    public void ToHealthChecks_Without_Data()
    {
        // Arrange
        const string myReportName = "MyTestReportName";
        const HealthStatus myHealthStatus = HealthStatus.Healthy;
        const string myDescription = "MyMessage";
        var myTimeSpan = TimeSpan.FromSeconds(1);

        var myHealthReportEntries = new Dictionary<string, HealthReportEntry>(StringComparer.Ordinal)
        {
            [myReportName] = new(myHealthStatus, myDescription, myTimeSpan, exception: null, data: null),
        };

        // Act
        var actual = myHealthReportEntries.ToHealthChecks();

        // Assert
        actual
            .Should().NotBeNull()
            .And.Subject.Should().BeAssignableTo<IList<HealthCheck>>()
            .And.HaveCount(1);

        var (name, resourceHealthChecks, healthStatus, timeSpan) = actual.First();

        Assert.Empty(resourceHealthChecks);
        Assert.Equal(myReportName, name);
        Assert.Equal(myHealthStatus, healthStatus);
        Assert.Equal(myTimeSpan, timeSpan);
    }

    [Fact]
    public void ToHealthChecks_With_Data()
    {
        // Arrange
        const string myReportName = "MyTestReportName";
        const string myHealthCheckName = "MyTestHealthCheck";
        const HealthStatus myHealthStatus = HealthStatus.Healthy;
        const string myDescription = "MyDescription";
        var myTimeSpan = TimeSpan.FromSeconds(1);

        var resourceHealthChecksInput = new List<ResourceHealthCheck>()
        {
            new(myHealthCheckName, myHealthStatus, myDescription, myTimeSpan),
        };

        var data = resourceHealthChecksInput.ToIReadOnlyDictionary();

        var myHealthReportEntries = new Dictionary<string, HealthReportEntry>(StringComparer.Ordinal)
        {
            [myReportName] = new(myHealthStatus, myDescription, myTimeSpan, exception: null, data),
        };

        // Act
        var actual = myHealthReportEntries.ToHealthChecks();

        // Assert
        actual
            .Should().NotBeNull()
            .And.Subject.Should().BeAssignableTo<IList<HealthCheck>>()
            .And.HaveCount(1);

        var (name, resources, healthStatus, timeSpan) = actual.First();

        Assert.Equal(myReportName, name);
        Assert.Single(resources);
        Assert.Equal(myHealthStatus, healthStatus);
        Assert.Equal(myTimeSpan, timeSpan);

        var (healthCheckName, healthCheckStatus, message, duration) = resources.First();

        Assert.Equal(myHealthCheckName, healthCheckName);
        Assert.Equal(myHealthStatus, healthCheckStatus);
        Assert.Equal(myDescription, message);
        Assert.Equal(myTimeSpan, duration);
    }
}