namespace Atc.Tests.Extensions;

public class GuidExtensionsTests
{
    [Fact]
    public void ToStringLower()
    {
        // Arrange
        var sut = new Guid("A1B2C3D4-E5F6-47A8-B9C0-D1E2F3A4B5C6");

        // Act
        var actual = sut.ToStringLower();

        // Assert
        Assert.Equal("a1b2c3d4-e5f6-47a8-b9c0-d1e2f3a4b5c6", actual);
    }

    [Fact]
    public void ToStringLower_EmptyGuid()
    {
        // Arrange
        var sut = Guid.Empty;

        // Act
        var actual = sut.ToStringLower();

        // Assert
        Assert.Equal("00000000-0000-0000-0000-000000000000", actual);
    }

    [Fact]
    public void ToStringUpper()
    {
        // Arrange
        var sut = new Guid("a1b2c3d4-e5f6-47a8-b9c0-d1e2f3a4b5c6");

        // Act
        var actual = sut.ToStringUpper();

        // Assert
        Assert.Equal("A1B2C3D4-E5F6-47A8-B9C0-D1E2F3A4B5C6", actual);
    }

    [Fact]
    public void ToStringUpper_EmptyGuid()
    {
        // Arrange
        var sut = Guid.Empty;

        // Act
        var actual = sut.ToStringUpper();

        // Assert
        Assert.Equal("00000000-0000-0000-0000-000000000000", actual);
    }
}