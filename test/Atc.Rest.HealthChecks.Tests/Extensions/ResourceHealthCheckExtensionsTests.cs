namespace Atc.Rest.HealthChecks.Tests.Extensions;

public class ResourceHealthCheckExtensionsTests
{
    [Fact]
    public void ToIReadOnlyDictionary()
    {
        // Arrange
        const string myHealthCheckName = "MyTestHealthCheck";
        const HealthStatus myHealthStatus = HealthStatus.Healthy;
        const string myMessage = "MyMessage";
        var myTimeSpan = TimeSpan.FromSeconds(1);

        var resourceHealthChecks = new List<ResourceHealthCheck>()
        {
            new(myHealthCheckName, myHealthStatus, myMessage, myTimeSpan),
        };

        // Act
        var actual = resourceHealthChecks.ToIReadOnlyDictionary();

        // Assert
        actual
            .Should().NotBeNull()
            .And.Subject.Should().BeAssignableTo<IReadOnlyDictionary<string, object>>()
            .And.HaveCount(1);

        var objects = actual.Values.ToList();
        var (name, healthStatus, message, timeSpan) = (ResourceHealthCheck)objects[0];

        Assert.Equal(myHealthCheckName, name);
        Assert.Equal(myHealthStatus, healthStatus);
        Assert.Equal(myMessage, message);
        Assert.Equal(myTimeSpan, timeSpan);
    }
}