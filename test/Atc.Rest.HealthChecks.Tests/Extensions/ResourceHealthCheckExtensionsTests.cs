namespace Atc.Rest.HealthChecks.Tests.Extensions;

public class ResourceHealthCheckExtensionsTests
{
    [Fact]
    public void ToIReadOnlyDictionary_SingleItem()
    {
        // Arrange
        const string name = "MyTestHealthCheck";
        const string description = "MyMessage";
        var duration = TimeSpan.FromSeconds(1);
        const HealthStatus status = HealthStatus.Healthy;

        var resourceHealthChecks = new List<ResourceHealthCheck>
        {
            new(name, status, description, duration),
        };

        // Act
        var dict = resourceHealthChecks.ToIReadOnlyDictionary();

        // Assert
        dict.Should().NotBeNull()
            .And.BeAssignableTo<IReadOnlyDictionary<string, object>>()
            .And.HaveCount(1)
            .And.ContainKey(name);

        var value = dict[name];

        value.Should().BeEquivalentTo(new
        {
            Status = status,
            Duration = duration,
            Description = description,
        });
    }

    [Fact]
    public void ToIReadOnlyDictionary_MultipleItems()
    {
        // Arrange
        var checks = new[]
        {
            new ResourceHealthCheck("One", HealthStatus.Healthy,   "Running",  TimeSpan.FromMilliseconds(5)),
            new ResourceHealthCheck("Two", HealthStatus.Unhealthy, "Stopped",  TimeSpan.FromMilliseconds(7)),
        };

        // Act
        var dict = checks.ToIReadOnlyDictionary();

        // Assert
        dict.Should().HaveCount(2);
        dict.Keys.Should().BeEquivalentTo("One", "Two");

        dict["Two"].Should().BeEquivalentTo(new
        {
            Status = HealthStatus.Unhealthy,
            Duration = TimeSpan.FromMilliseconds(7),
            Description = "Stopped",
        });
    }
}