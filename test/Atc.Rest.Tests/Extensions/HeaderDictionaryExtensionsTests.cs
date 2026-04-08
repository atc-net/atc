namespace Atc.Rest.Tests.Extensions;

public class HeaderDictionaryExtensionsTests
{
    [Fact]
    public void GetOrAddCorrelationId()
    {
        // Arrange
        var data = new HeaderDictionary
        {
            new(
                "x-correlation-id",
                new StringValues(Guid.NewGuid().ToString())),
        };

        // Act
        var actual = data.GetOrAddCorrelationId();

        // Assert
        Assert.NotNull(actual);
        Assert.True(Guid.TryParse(actual, out _));
    }

    [Fact]
    public void GetOrAddCorrelationId_GeneratesNew_WhenMissing()
    {
        // Arrange
        var data = new HeaderDictionary();

        // Act
        var actual = data.GetOrAddCorrelationId();

        // Assert
        Assert.NotNull(actual);
        Assert.True(Guid.TryParse(actual, out _));
    }

    [Fact]
    public void GetOrAddCorrelationId_RejectsInvalidGuid()
    {
        // Arrange
        var data = new HeaderDictionary
        {
            new("x-correlation-id", new StringValues("not-a-guid")),
        };

        // Act
        var actual = data.GetOrAddCorrelationId();

        // Assert
        Assert.NotNull(actual);
        Assert.True(Guid.TryParse(actual, out _));
        Assert.NotEqual("not-a-guid", actual);
    }

    [Fact]
    public void GetOrAddCorrelationId_RejectsCrlfInjection()
    {
        // Arrange
        var data = new HeaderDictionary
        {
            new("x-correlation-id", new StringValues("value\r\ninjected-header: bad")),
        };

        // Act
        var actual = data.GetOrAddCorrelationId();

        // Assert
        Assert.NotNull(actual);
        Assert.True(Guid.TryParse(actual, out _));
        Assert.DoesNotContain("\r", actual, StringComparison.Ordinal);
        Assert.DoesNotContain("\n", actual, StringComparison.Ordinal);
    }

    [Fact]
    public void AddCorrelationId()
    {
        // Arrange
        var data = new HeaderDictionary();
        var correlationId = Guid.NewGuid().ToString();

        // Act
        var actual = data.AddCorrelationId(correlationId);

        // Assert
        Assert.NotNull(actual);
        Assert.True(Guid.TryParse(actual, out _));
    }

    [Fact]
    public void GetOrAddRequestId()
    {
        // Arrange
        var data = new HeaderDictionary
        {
            new(
                "x-request-id",
                new StringValues(Guid.NewGuid().ToString())),
        };

        // Act
        var actual = data.GetOrAddRequestId();

        // Assert
        Assert.NotNull(actual);
        Assert.True(Guid.TryParse(actual, out _));
    }

    [Fact]
    public void GetCallingOnBehalfOfIdentity()
    {
        // Arrange
        var data = new HeaderDictionary
        {
            new(
                "x-on-behalf-of",
                new StringValues(Guid.NewGuid().ToString())),
        };

        // Act
        var actual = data.GetCallingOnBehalfOfIdentity();

        // Assert
        Assert.NotNull(actual);
        Assert.True(Guid.TryParse(actual, out _));
    }
}