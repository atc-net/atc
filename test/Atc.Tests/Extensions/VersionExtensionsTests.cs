namespace Atc.Tests.Extensions;

public class VersionExtensionsTests
{
    [Theory]
    [InlineData(0, new[] { 1, 0, 0, 0 }, new[] { 1, 0, 0, 0 }, 4)]
    [InlineData(1, new[] { 2, 0, 0, 0 }, new[] { 1, 0, 0, 0 }, 4)]
    [InlineData(1, new[] { 1, 1, 0, 0 }, new[] { 1, 0, 0, 0 }, 4)]
    [InlineData(1, new[] { 1, 0, 1, 0 }, new[] { 1, 0, 0, 0 }, 4)]
    [InlineData(1, new[] { 1, 0, 0, 1 }, new[] { 1, 0, 0, 0 }, 4)]
    [InlineData(-1, new[] { 1, 0, 0, 0 }, new[] { 2, 0, 0, 0 }, 4)]
    [InlineData(-1, new[] { 1, 0, 0, 0 }, new[] { 1, 1, 0, 0 }, 4)]
    [InlineData(-1, new[] { 1, 0, 0, 0 }, new[] { 1, 0, 1, 0 }, 4)]
    [InlineData(-1, new[] { 1, 0, 0, 0 }, new[] { 1, 0, 0, 1 }, 4)]
    [InlineData(0, new[] { 1, 0, 0, 0 }, new[] { 1, 0, 0, 0 }, 3)]
    [InlineData(1, new[] { 2, 0, 0, 0 }, new[] { 1, 0, 0, 0 }, 3)]
    [InlineData(1, new[] { 1, 1, 0, 0 }, new[] { 1, 0, 0, 0 }, 3)]
    [InlineData(1, new[] { 1, 0, 1, 0 }, new[] { 1, 0, 0, 0 }, 3)]
    [InlineData(0, new[] { 1, 0, 0, 1 }, new[] { 1, 0, 0, 0 }, 3)]
    [InlineData(-1, new[] { 1, 0, 0, 0 }, new[] { 2, 0, 0, 0 }, 3)]
    [InlineData(-1, new[] { 1, 0, 0, 0 }, new[] { 1, 1, 0, 0 }, 3)]
    [InlineData(-1, new[] { 1, 0, 0, 0 }, new[] { 1, 0, 1, 0 }, 3)]
    [InlineData(0, new[] { 1, 0, 0, 0 }, new[] { 1, 0, 0, 1 }, 3)]
    [InlineData(0, new[] { 1, 0, 0, 0 }, new[] { 1, 0, 0, 0 }, 2)]
    [InlineData(1, new[] { 2, 0, 0, 0 }, new[] { 1, 0, 0, 0 }, 2)]
    [InlineData(1, new[] { 1, 1, 0, 0 }, new[] { 1, 0, 0, 0 }, 2)]
    [InlineData(0, new[] { 1, 0, 1, 0 }, new[] { 1, 0, 0, 0 }, 2)]
    [InlineData(0, new[] { 1, 0, 0, 1 }, new[] { 1, 0, 0, 0 }, 2)]
    [InlineData(-1, new[] { 1, 0, 0, 0 }, new[] { 2, 0, 0, 0 }, 2)]
    [InlineData(-1, new[] { 1, 0, 0, 0 }, new[] { 1, 1, 0, 0 }, 2)]
    [InlineData(0, new[] { 1, 0, 0, 0 }, new[] { 1, 0, 1, 0 }, 2)]
    [InlineData(0, new[] { 1, 0, 0, 0 }, new[] { 1, 0, 0, 1 }, 2)]
    [InlineData(0, new[] { 1, 0, 0, 0 }, new[] { 1, 0, 0, 0 }, 1)]
    [InlineData(1, new[] { 2, 0, 0, 0 }, new[] { 1, 0, 0, 0 }, 1)]
    [InlineData(0, new[] { 1, 1, 0, 0 }, new[] { 1, 0, 0, 0 }, 1)]
    [InlineData(0, new[] { 1, 0, 1, 0 }, new[] { 1, 0, 0, 0 }, 1)]
    [InlineData(0, new[] { 1, 0, 0, 1 }, new[] { 1, 0, 0, 0 }, 1)]
    [InlineData(-1, new[] { 1, 0, 0, 0 }, new[] { 2, 0, 0, 0 }, 1)]
    [InlineData(0, new[] { 1, 0, 0, 0 }, new[] { 1, 1, 0, 0 }, 1)]
    [InlineData(0, new[] { 1, 0, 0, 0 }, new[] { 1, 0, 1, 0 }, 1)]
    [InlineData(0, new[] { 1, 0, 0, 0 }, new[] { 1, 0, 0, 1 }, 1)]
    public void CompareTo(
        int expected,
        int[] inputA,
        int[] inputB,
        int significantParts)
    {
        // Arrange
        var versionA = new Version(inputA[0], inputA[1], inputA[2], inputA[3]);
        var versionB = new Version(inputB[0], inputB[1], inputB[2], inputB[3]);

        // Act
        var actual = versionA.CompareTo(versionB, significantParts);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(false, new[] { 1, 0, 0, 0 }, new[] { 1, 0, 0, 0 })]
    [InlineData(true, new[] { 2, 0, 0, 0 }, new[] { 1, 0, 0, 0 })]
    [InlineData(true, new[] { 1, 1, 0, 0 }, new[] { 1, 0, 0, 0 })]
    [InlineData(true, new[] { 1, 0, 1, 0 }, new[] { 1, 0, 0, 0 })]
    [InlineData(true, new[] { 1, 0, 0, 1 }, new[] { 1, 0, 0, 0 })]
    [InlineData(false, new[] { 1, 0, 0, 0 }, new[] { 2, 0, 0, 0 })]
    [InlineData(false, new[] { 1, 0, 0, 0 }, new[] { 1, 1, 0, 0 })]
    [InlineData(false, new[] { 1, 0, 0, 0 }, new[] { 1, 0, 1, 0 })]
    [InlineData(false, new[] { 1, 0, 0, 0 }, new[] { 1, 0, 0, 1 })]
    public void GreaterThan(
        bool expected,
        int[] inputA,
        int[] inputB)
    {
        // Arrange
        var versionA = new Version(inputA[0], inputA[1], inputA[2], inputA[3]);
        var versionB = new Version(inputB[0], inputB[1], inputB[2], inputB[3]);

        // Act
        var actual = versionA.GreaterThan(versionB);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(false, new[] { 1, 1, 1, 1 }, new[] { 1, 1, 1, 1 }, 4)]
    [InlineData(true, new[] { 2, 1, 1, 1 }, new[] { 1, 1, 1, 1 }, 4)]
    [InlineData(true, new[] { 2, 1, 1, 1 }, new[] { 1, 2, 1, 1 }, 4)]
    [InlineData(false, new[] { 1, 1, 1, 1 }, new[] { 2, 1, 1, 1 }, 4)]
    [InlineData(false, new[] { 1, 1, 1, 1 }, new[] { 2, 2, 1, 1 }, 4)]
    public void GreaterThan_SignificantParts(
        bool expected,
        int[] inputA,
        int[] inputB,
        int significantParts)
    {
        // Arrange
        var versionA = new Version(inputA[0], inputA[1], inputA[2], inputA[3]);
        var versionB = new Version(inputB[0], inputB[1], inputB[2], inputB[3]);

        // Act
        var actual = versionA.GreaterThan(versionB, significantParts);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(false, new[] { 1, 1, 1, 1 }, new[] { 1, 1, 1, 1 }, 4, 1)]
    [InlineData(true, new[] { 2, 1, 1, 1 }, new[] { 1, 1, 1, 1 }, 4, 1)]
    [InlineData(false, new[] { 2, 1, 1, 1 }, new[] { 1, 1, 1, 1 }, 4, 2)]
    [InlineData(false, new[] { 2, 1, 1, 1 }, new[] { 1, 2, 1, 1 }, 4, 2)]
    [InlineData(false, new[] { 1, 1, 1, 1 }, new[] { 2, 1, 1, 1 }, 4, 2)]
    [InlineData(false, new[] { 1, 2, 1, 1 }, new[] { 1, 3, 1, 1 }, 4, 2)]
    [InlineData(false, new[] { 2, 2, 1, 1 }, new[] { 1, 3, 1, 1 }, 4, 2)]
    [InlineData(true, new[] { 1, 3, 1, 1 }, new[] { 1, 2, 1, 1 }, 4, 2)]
    public void GreaterThan_SignificantParts_StartingParts(
        bool expected,
        int[] inputA,
        int[] inputB,
        int significantParts,
        int startingPart)
    {
        // Arrange
        var versionA = new Version(inputA[0], inputA[1], inputA[2], inputA[3]);
        var versionB = new Version(inputB[0], inputB[1], inputB[2], inputB[3]);

        // Act
        var actual = versionA.GreaterThan(versionB, significantParts, startingPart);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(true, new[] { 1, 0, 0, 0 }, new[] { 1, 0, 0, 0 })]
    [InlineData(true, new[] { 2, 0, 0, 0 }, new[] { 1, 0, 0, 0 })]
    [InlineData(true, new[] { 1, 1, 0, 0 }, new[] { 1, 0, 0, 0 })]
    [InlineData(true, new[] { 1, 0, 1, 0 }, new[] { 1, 0, 0, 0 })]
    [InlineData(true, new[] { 1, 0, 0, 1 }, new[] { 1, 0, 0, 0 })]
    [InlineData(false, new[] { 1, 0, 0, 0 }, new[] { 2, 0, 0, 0 })]
    [InlineData(false, new[] { 1, 0, 0, 0 }, new[] { 1, 1, 0, 0 })]
    [InlineData(false, new[] { 1, 0, 0, 0 }, new[] { 1, 0, 1, 0 })]
    [InlineData(false, new[] { 1, 0, 0, 0 }, new[] { 1, 0, 0, 1 })]
    public void GreaterThanOrEqualTo(
        bool expected,
        int[] inputA,
        int[] inputB)
    {
        // Arrange
        var versionA = new Version(inputA[0], inputA[1], inputA[2], inputA[3]);
        var versionB = new Version(inputB[0], inputB[1], inputB[2], inputB[3]);

        // Act
        var actual = versionA.GreaterThanOrEqualTo(versionB);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(true, new[] { 1, 1, 1, 1 }, new[] { 1, 1, 1, 1 }, 4)]
    [InlineData(true, new[] { 2, 1, 1, 1 }, new[] { 1, 1, 1, 1 }, 4)]
    [InlineData(true, new[] { 2, 1, 1, 1 }, new[] { 1, 2, 1, 1 }, 4)]
    [InlineData(false, new[] { 1, 1, 1, 1 }, new[] { 2, 1, 1, 1 }, 4)]
    [InlineData(false, new[] { 1, 1, 1, 1 }, new[] { 2, 2, 1, 1 }, 4)]
    public void GreaterThanOrEqualTo_SignificantParts(
        bool expected,
        int[] inputA,
        int[] inputB,
        int significantParts)
    {
        // Arrange
        var versionA = new Version(inputA[0], inputA[1], inputA[2], inputA[3]);
        var versionB = new Version(inputB[0], inputB[1], inputB[2], inputB[3]);

        // Act
        var actual = versionA.GreaterThanOrEqualTo(versionB, significantParts);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(true, new[] { 1, 1, 1, 1 }, new[] { 1, 1, 1, 1 }, 4, 1)]
    [InlineData(true, new[] { 2, 1, 1, 1 }, new[] { 1, 1, 1, 1 }, 4, 1)]
    [InlineData(true, new[] { 2, 1, 1, 1 }, new[] { 1, 1, 1, 1 }, 4, 2)]
    [InlineData(false, new[] { 2, 1, 1, 1 }, new[] { 1, 2, 1, 1 }, 4, 2)]
    [InlineData(true, new[] { 1, 1, 1, 1 }, new[] { 2, 1, 1, 1 }, 4, 2)]
    [InlineData(false, new[] { 1, 2, 1, 1 }, new[] { 1, 3, 1, 1 }, 4, 2)]
    [InlineData(false, new[] { 2, 2, 1, 1 }, new[] { 1, 3, 1, 1 }, 4, 2)]
    [InlineData(true, new[] { 1, 3, 1, 1 }, new[] { 1, 2, 1, 1 }, 4, 2)]
    public void GreaterThanOrEqualTo_SignificantParts_StartingParts(
        bool expected,
        int[] inputA,
        int[] inputB,
        int significantParts,
        int startingPart)
    {
        // Arrange
        var versionA = new Version(inputA[0], inputA[1], inputA[2], inputA[3]);
        var versionB = new Version(inputB[0], inputB[1], inputB[2], inputB[3]);

        // Act
        var actual = versionA.GreaterThanOrEqualTo(versionB, significantParts, startingPart);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(true, new[] { 4, 8, 8, 0 }, new[] { 4, 5, 3, 3 })]
    [InlineData(true, new[] { 4, 5, 8, 0 }, new[] { 4, 5, 3, 3 })]
    [InlineData(true, new[] { 4, 8, 3, 0 }, new[] { 4, 5, 3, 3 })]
    [InlineData(true, new[] { 4, 5, 4, 0 }, new[] { 4, 5, 3, 3 })]
    [InlineData(false, new[] { 4, 5, 3, 0 }, new[] { 4, 5, 3, 3 })]
    [InlineData(true, new[] { 5, 8, 8, 0 }, new[] { 4, 5, 3, 3 })]
    [InlineData(false, new[] { 3, 8, 8, 0 }, new[] { 4, 5, 3, 3 })]
    public void IsNewerThan(
        bool expected,
        int[] inputA,
        int[] inputB)
    {
        // Arrange
        var versionA = new Version(inputA[0], inputA[1], inputA[2], inputA[3]);
        var versionB = new Version(inputB[0], inputB[1], inputB[2], inputB[3]);

        // Act
        var actual = versionA.IsNewerThan(versionB);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(true, new[] { 4, 8, 8, 0 }, new[] { 4, 5, 3, 3 }, false)]
    [InlineData(true, new[] { 4, 5, 8, 0 }, new[] { 4, 5, 3, 3 }, false)]
    [InlineData(true, new[] { 4, 8, 3, 0 }, new[] { 4, 5, 3, 3 }, false)]
    [InlineData(true, new[] { 4, 5, 4, 0 }, new[] { 4, 5, 3, 3 }, false)]
    [InlineData(false, new[] { 4, 5, 3, 0 }, new[] { 4, 5, 3, 3 }, false)]
    [InlineData(true, new[] { 5, 8, 8, 0 }, new[] { 4, 5, 3, 3 }, false)]
    [InlineData(false, new[] { 3, 8, 8, 0 }, new[] { 4, 5, 3, 3 }, false)]
    [InlineData(true, new[] { 4, 8, 8, 0 }, new[] { 4, 5, 3, 3 }, true)]
    [InlineData(true, new[] { 4, 5, 8, 0 }, new[] { 4, 5, 3, 3 }, true)]
    [InlineData(true, new[] { 4, 8, 3, 0 }, new[] { 4, 5, 3, 3 }, true)]
    [InlineData(true, new[] { 4, 5, 4, 0 }, new[] { 4, 5, 3, 3 }, true)]
    [InlineData(false, new[] { 4, 5, 3, 0 }, new[] { 4, 5, 3, 3 }, true)]
    [InlineData(false, new[] { 5, 8, 8, 0 }, new[] { 4, 5, 3, 3 }, true)]
    [InlineData(false, new[] { 3, 8, 8, 0 }, new[] { 4, 5, 3, 3 }, true)]
    public void IsNewerThan_WithinMinorReleaseOnly(
        bool expected,
        int[] inputA,
        int[] inputB,
        bool withinMinorReleaseOnly)
    {
        // Arrange
        var versionA = new Version(inputA[0], inputA[1], inputA[2], inputA[3]);
        var versionB = new Version(inputB[0], inputB[1], inputB[2], inputB[3]);

        // Act
        var actual = versionA.IsNewerThan(versionB, withinMinorReleaseOnly);

        // Assert
        Assert.Equal(expected, actual);
    }
}