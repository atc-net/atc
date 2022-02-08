namespace Atc.Rest.Tests.Extensions;

public class FormFileExtensionsTests
{
    [Fact]
    public async Task GetBytes()
    {
        // Arrange
        var expected = Encoding.UTF8.GetBytes("HelloWorld");
        await using var stream = new MemoryStream(expected);
        var file = new FormFile(stream, 0, stream.Length, "file", "myFile.txt");

        // Act
        var actual = await file.GetBytes();

        // Assert
        Assert.NotNull(actual);
        Assert.Equal(expected, actual);
    }
}