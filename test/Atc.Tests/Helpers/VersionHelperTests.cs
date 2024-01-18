namespace Atc.Tests.Helpers;

public class VersionHelperTests
{
    [Theory]
    [InlineData(false, "1.0.0.0", "2.0.0.0")]
    [InlineData(true, "2.0.0.0", "1.0.0.0")]
    [InlineData(false, null, "1.0.0.0")]
    [InlineData(false, "1.0.0.0", null)]
    [InlineData(false, "1.0.0.0", "1.0.0.0")]
    public void IsSourceNewerThanDestination_StringVersions(bool expected, string source, string destination)
        => Assert.Equal(expected, VersionHelper.IsSourceNewerThanDestination(source, destination));

    [Theory]
    [InlineData(false, "1.0", "2.0")]
    [InlineData(true, "2.0", "1.0")]
    [InlineData(false, null, "1.0")]
    [InlineData(false, "1.0", null)]
    public void IsSourceNewerThanDestination_VersionObjects(bool expected, string? source, string? destination)
    {
        // Arrange
        var sourceVersion = source != null ? new Version(source) : null;
        var destinationVersion = destination != null ? new Version(destination) : null;

        // Act
        var result = VersionHelper.IsSourceNewerThanDestination(sourceVersion, destinationVersion);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(true, "1.0.0.0", "1.0.0.0")]
    [InlineData(false, "1.0.0.0", "2.0.0.0")]
    public void IsDefault(bool expected, string source, string destination)
    {
        // Arrange
        var sourceVersion = new Version(source);
        var destinationVersion = new Version(destination);

        // Atc
        var result = VersionHelper.IsDefault(sourceVersion, destinationVersion);

        // Assert
        Assert.Equal(expected, result);
    }
}