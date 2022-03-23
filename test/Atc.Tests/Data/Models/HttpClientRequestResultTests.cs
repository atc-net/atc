namespace Atc.Tests.Data.Models;

public class HttpClientRequestResultTests
{
    [Fact]
    public void Constructor_StatusCode()
    {
        // Act
        var actual = new HttpClientRequestResult<int>(HttpStatusCode.Created);

        // Assert
        Assert.NotNull(actual);
        Assert.True(actual.HasCommunicationSucceeded);
        Assert.Equal(HttpStatusCode.Created, actual.StatusCode);
        Assert.Equal(default, actual.Data);
        Assert.Null(actual.Message);
        Assert.Null(actual.Exception);
    }

    [Fact]
    public void Constructor_StatusCode_Data()
    {
        // Act
        var actual = new HttpClientRequestResult<int>(HttpStatusCode.Created, 1);

        // Assert
        Assert.NotNull(actual);
        Assert.True(actual.HasCommunicationSucceeded);
        Assert.Equal(HttpStatusCode.Created, actual.StatusCode);
        Assert.Equal(1, actual.Data);
        Assert.Null(actual.Message);
        Assert.Null(actual.Exception);
    }

    [Fact]
    public void Constructor_StatusCode_ListData()
    {
        // Act
        var actual = new HttpClientRequestResult<int[]>(HttpStatusCode.Created, new[] { 1, 2, 3 });

        // Assert
        Assert.NotNull(actual);
        Assert.True(actual.HasCommunicationSucceeded);
        Assert.Equal(HttpStatusCode.Created, actual.StatusCode);
        Assert.Equal(new[] { 1, 2, 3 }, actual.Data);
        Assert.Null(actual.Message);
        Assert.Null(actual.Exception);
    }

    [Fact]
    public void Constructor_StatusCode_ListData_Message()
    {
        // Act
        var actual = new HttpClientRequestResult<int[]>(HttpStatusCode.Created, new[] { 1, 2, 3 }, "Hello World");

        // Assert
        Assert.NotNull(actual);
        Assert.True(actual.HasCommunicationSucceeded);
        Assert.Equal(HttpStatusCode.Created, actual.StatusCode);
        Assert.Equal(new[] { 1, 2, 3 }, actual.Data);
        Assert.Equal("Hello World", actual.Message);
        Assert.Null(actual.Exception);
    }

    [Fact]
    public void Constructor_Exception()
    {
        // Act
        var actual = new HttpClientRequestResult<int[]>(new HttpRequestException("Hello World"));

        // Assert
        Assert.NotNull(actual);
        Assert.False(actual.HasCommunicationSucceeded);
        Assert.Null(actual.StatusCode);
        Assert.Equal(default, actual.Data);
        Assert.Null(actual.Message);
        Assert.IsType<HttpRequestException>(actual.Exception);
    }
}