namespace Atc.Tests.Serialization;

public class JsonSerializerHelperTests
{
    private sealed record Person(string Name, int Age);

    [Fact]
    public async Task SerializeToStreamAsync_ThenDeserializeFromStreamAsync_RoundTrips()
    {
        // Arrange
        var original = new Person("Alice", 30);
        using var stream = new MemoryStream();

        // Act
        await JsonSerializerHelper.SerializeToStreamAsync(original, stream);
        stream.Position = 0;
        var result = await JsonSerializerHelper.DeserializeFromStreamAsync<Person>(stream);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(original.Name, result.Name);
        Assert.Equal(original.Age, result.Age);
    }

    [Fact]
    public async Task SerializeToStreamAsync_WithOptions_WritesJson()
    {
        // Arrange
        var original = new Person("Bob", 25);
        using var stream = new MemoryStream();
        var options = JsonSerializerOptionsFactory.Create(useCamelCase: false, writeIndented: false);

        // Act
        await JsonSerializerHelper.SerializeToStreamAsync(original, stream, options);
        stream.Position = 0;
        using var reader = new StreamReader(stream);
        var json = await reader.ReadToEndAsync();

        // Assert — PascalCase keys expected
        Assert.Contains("\"Name\"", json, StringComparison.Ordinal);
        Assert.Contains("\"Age\"", json, StringComparison.Ordinal);
    }

    [Fact]
    public async Task DeserializeFromStreamAsync_WithOptions_Deserializes()
    {
        // Arrange
        const string json = "{\"Name\":\"Carol\",\"Age\":22}";
        using var stream = new MemoryStream(Encoding.UTF8.GetBytes(json));
        var options = JsonSerializerOptionsFactory.Create(propertyNameCaseInsensitive: true, writeIndented: false);

        // Act
        var result = await JsonSerializerHelper.DeserializeFromStreamAsync<Person>(stream, options);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Carol", result.Name);
        Assert.Equal(22, result.Age);
    }

    [Fact]
    public Task SerializeToStreamAsync_NullStream_ThrowsArgumentNullException()
        => Assert.ThrowsAsync<ArgumentNullException>(
            () => JsonSerializerHelper.SerializeToStreamAsync<Person>(new Person("x", 1), null!));

    [Fact]
    public Task DeserializeFromStreamAsync_NullStream_ThrowsArgumentNullException()
        => Assert.ThrowsAsync<ArgumentNullException>(
            () => JsonSerializerHelper.DeserializeFromStreamAsync<Person>(null!));

    [Fact]
    public async Task SerializeToStreamAsync_Cancelled_ThrowsOperationCanceledException()
    {
        // Arrange
        using var stream = new MemoryStream();
        using var cts = new CancellationTokenSource();
        await cts.CancelAsync();

        // Act
        var ex = await Record.ExceptionAsync(
            () => JsonSerializerHelper.SerializeToStreamAsync(new Person("x", 1), stream, cts.Token));

        // Assert
        Assert.IsAssignableFrom<OperationCanceledException>(ex);
    }

    [Fact]
    public async Task DeserializeFromStreamAsync_Cancelled_ThrowsOperationCanceledException()
    {
        // Arrange
        const string json = "{\"Name\":\"x\",\"Age\":1}";
        using var stream = new MemoryStream(Encoding.UTF8.GetBytes(json));
        using var cts = new CancellationTokenSource();
        await cts.CancelAsync();

        // Act
        var ex = await Record.ExceptionAsync(
            () => (Task)JsonSerializerHelper.DeserializeFromStreamAsync<Person>(stream, cts.Token));

        // Assert
        Assert.IsAssignableFrom<OperationCanceledException>(ex);
    }
}