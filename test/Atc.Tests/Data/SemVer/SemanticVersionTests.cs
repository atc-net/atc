// ReSharper disable StringLiteralTypo
namespace Atc.Tests.Data.SemVer;

public class SemanticVersionTests
{
    [Theory]
    [InlineData(true, "1.2.3")]
    [InlineData(true, "1.2.3-beta01")]
    [InlineData(true, "[1.2.3]")]
    [InlineData(true, "(1.2.3)")]
    [InlineData(false, "")]
    [InlineData(false, "1")]
    [InlineData(false, "1.2")]
    [InlineData(false, "1.2.3.4")]
    [InlineData(false, "01.2.3")]
    [InlineData(false, "1.02.3")]
    [InlineData(false, "1.2.03")]
    [InlineData(false, "1.0.0-01")]
    [InlineData(false, "1.0.0-beta.01")]
    [InlineData(false, "1.0.0+é")]
    public void Constructor(bool expected, string version)
    {
        if (expected)
        {
            // Act
            var actual = new SemanticVersion(version);

            // Assert
            Assert.NotNull(actual);
        }
        else
        {
            // Act & Assert
            new Func<object>(()
                    => new SemanticVersion(version))
                .Should()
                .ThrowExactly<ArgumentException>();
        }
    }

    [Theory]
    [InlineData(true, "1.2.3", true)]
    [InlineData(true, "1.2.3-beta01", true)]
    [InlineData(true, "[1.2.3]", true)]
    [InlineData(true, "(1.2.3)", true)]
    [InlineData(false, "", true)]
    [InlineData(false, "1", true)]
    [InlineData(false, "1.2", true)]
    [InlineData(true, "1.2.3.4", true)]
    [InlineData(true, "01.2.3", true)]
    [InlineData(true, "1.02.3", true)]
    [InlineData(true, "1.2.03", true)]
    [InlineData(true, "1.0.0-01", true)]
    [InlineData(true, "1.0.0-beta.01", true)]
    [InlineData(false, "1.0.0+é", true)]
    [InlineData(true, "1.2.3", false)]
    [InlineData(true, "1.2.3-beta01", false)]
    [InlineData(false, "", false)]
    [InlineData(false, "1", false)]
    [InlineData(false, "1.2", false)]
    [InlineData(false, "1.2.3.4", false)]
    [InlineData(false, "01.2.3", false)]
    [InlineData(false, "1.02.3", false)]
    [InlineData(false, "1.2.03", false)]
    [InlineData(false, "1.0.0-01", false)]
    [InlineData(false, "1.0.0-beta.01", false)]
    [InlineData(false, "1.0.0+é", false)]
    public void Constructor_LooseMode(bool expected, string version, bool looseMode)
    {
        if (expected)
        {
            // Act
            var actual = new SemanticVersion(version, looseMode);

            // Assert
            Assert.NotNull(actual);
        }
        else
        {
            // Act & Assert
            new Func<object>(()
                    => new SemanticVersion(version, looseMode))
                .Should()
                .ThrowExactly<ArgumentException>();
        }
    }

    [Theory]
    [InlineData("1.2.3")]
    [InlineData("1.2.3-beta01")]
    [InlineData("[1.2.3]")]
    [InlineData("(1.2.3)")]
    public void SerializeAndDeserialize(string version)
        => SerializeAndDeserializeHelper.Assert<SemanticVersion>(new SemanticVersion(version));

    [Theory]
    [InlineData(false, "1.2.3")]
    [InlineData(true, "1.2.3-beta01")]
    public void IsPreRelease(bool expected, string version)
    {
        // Act
        var actual = new SemanticVersion(version);

        // Assert
        Assert.NotNull(actual);
        Assert.Equal(expected, actual.IsPreRelease);
    }

    [Theory]
    [InlineData(true, "1.2.3")]
    [InlineData(false, "1.2.3.4")]
    [InlineData(true, "01.2.3")]
    [InlineData(true, "1.02.3")]
    [InlineData(true, "1.2.03")]
    [InlineData(true, "1.0.0-01")]
    [InlineData(true, "1.0.0-beta.01")]
    [InlineData(true, "1.2.3-beta01")]
    public void IsStrictMode(bool expected, string version)
    {
        // Act
        var actual = new SemanticVersion(version, looseMode: true);

        // Assert
        Assert.NotNull(actual);
        Assert.Equal(expected, actual.IsStrictMode);
    }

    [Theory]
    [InlineData(0, "1.2.3", "1.2.3")]
    [InlineData(1, "2.2.3", "1.2.3")]
    [InlineData(-1, "1.2.3", "2.2.3")]
    [InlineData(0, "1.2.3-beta01", "1.2.3-beta01")]
    [InlineData(1, "2.2.3-beta01", "1.2.3-beta01")]
    [InlineData(-1, "1.2.3-beta01", "2.2.3-beta01")]
    [InlineData(1, "1.2.3-beta02", "1.2.3-beta01")]
    [InlineData(-1, "1.2.3-beta01", "1.2.3-beta02")]
    public void CompareTo(int expected, string versionA, string versionB)
    {
        // Arrange
        var objA = new SemanticVersion(versionA);
        var objB = new SemanticVersion(versionB);

        // Act
        var actual = objA.CompareTo(objB);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(true, "1.2.3", "1.2.3")]
    [InlineData(true, "1.2.3-beta01", "1.2.3-beta01")]
    [InlineData(true, "1.2.3", "[1.2.3]")]
    [InlineData(true, "[1.2.3]", "1.2.3")]
    [InlineData(true, "1.2.3", "(1.2.3)")]
    [InlineData(true, "(1.2.3)", "1.2.3")]
    public void Override_Equals(bool expected, string versionA, string versionB)
    {
        // Arrange
        var objA = new SemanticVersion(versionA);
        var objB = new SemanticVersion(versionB);

        // Act
        var actual = objA.Equals(objB);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(438153817, "1.2.3")]
    public void OverrideGetHashCode(int expected, string version)
    {
        // Arrange
        var obj = new SemanticVersion(version);

        // Act
        var actual = obj.GetHashCode();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(false, "1.2.0-beta406", "1.2.0-beta406")]
    [InlineData(true, "1.2.0-beta406", "1.2.0-beta376")]
    [InlineData(false, "1.2.0-beta376", "1.2.0-beta406")]
    [InlineData(true, "1.2.0-alfa406", "1.2.0-beta376")]
    [InlineData(false, "1.2.0-beta376", "1.2.0-alfa406")]
    [InlineData(true, "1.2.0-alfa406", "1.1.118")]
    [InlineData(true, "1.2.1", "1.2.0-alfa406")]
    [InlineData(false, "1.2.0-alfa406", "1.2.1")]
    [InlineData(false, "1.2.0-alfa406", "1.2.0-alfa406")]
    public void GreaterThan(bool expected, string versionA, string versionB)
    {
        // Arrange
        var objA = new SemanticVersion(versionA, looseMode: true);
        var objB = new SemanticVersion(versionB, looseMode: true);

        // Act
        var actual = objA.GreaterThan(objB, significantParts: 4, startingPart: 1, looseMode: true);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(true, "1.2.0-beta406", "1.2.0-beta376")]
    [InlineData(false, "1.2.0-beta376", "1.2.0-beta406")]
    [InlineData(true, "1.2.0-alfa406", "1.2.0-beta376")]
    [InlineData(false, "1.2.0-beta376", "1.2.0-alfa406")]
    [InlineData(true, "1.2.0-alfa406", "1.1.118")]
    [InlineData(true, "1.2.1", "1.2.0-alfa406")]
    [InlineData(false, "1.2.0-alfa406", "1.2.1")]
    [InlineData(true, "1.2.0-alfa406", "1.2.0-alfa406")]
    public void GreaterThanOrEqualTo(bool expected, string versionA, string versionB)
    {
        // Arrange
        var objA = new SemanticVersion(versionA, looseMode: true);
        var objB = new SemanticVersion(versionB, looseMode: true);

        // Act
        var actual = objA.GreaterThanOrEqualTo(objB, significantParts: 4, startingPart: 1);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(true, "4.8.8.0", "4.5.3.3")]
    [InlineData(true, "4.5.8.0", "4.5.3.3")]
    [InlineData(true, "4.8.3.0", "4.5.3.3")]
    [InlineData(true, "4.5.4.0", "4.5.3.3")]
    [InlineData(false, "4.5.3.0", "4.5.3.3")]
    [InlineData(true, "5.8.8.0", "4.5.3.3")]
    [InlineData(false, "3.8.8.0", "4.5.3.3")]
    [InlineData(true, "1.2.0-beta.406", "1.2.0-beta.376")]
    [InlineData(false, "1.2.0-beta.376", "1.2.0-beta.406")]
    [InlineData(true, "1.2.0-alfa.406", "1.2.0-beta.376")]
    [InlineData(false, "1.2.0-beta.376", "1.2.0-alfa.406")]
    [InlineData(true, "1.2.0-alfa.406", "1.1.118")]
    [InlineData(true, "1.2.1", "1.2.0-alfa.406")]
    [InlineData(false, "1.2.0-alfa.406", "1.2.1")]
    [InlineData(false, "1.2.0-alfa.406", "1.2.0-alfa.406")]

    [InlineData(true, "1.2.0-beta406", "1.2.0-beta376")]
    [InlineData(false, "1.2.0-beta376", "1.2.0-beta406")]
    [InlineData(true, "1.2.0-alfa406", "1.2.0-beta376")]
    [InlineData(false, "1.2.0-beta376", "1.2.0-alfa406")]
    [InlineData(true, "1.2.0-alfa406", "1.1.118")]
    [InlineData(true, "1.2.1", "1.2.0-alfa406")]
    [InlineData(false, "1.2.0-alfa406", "1.2.1")]
    [InlineData(false, "1.2.0-alfa406", "1.2.0-alfa406")]
    public void IsNewerThan(bool expected, string versionA, string versionB)
    {
        // Arrange
        var objA = new SemanticVersion(versionA, looseMode: true);
        var objB = new SemanticVersion(versionB, looseMode: true);

        // Act
        var actual = objA.IsNewerThan(objB, withinMinorReleaseOnly: false, looseMode: true);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(true, "4.8.8.0", "4.5.3.3", false)]
    [InlineData(true, "4.5.8.0", "4.5.3.3", false)]
    [InlineData(true, "4.8.3.0", "4.5.3.3", false)]
    [InlineData(true, "4.5.4.0", "4.5.3.3", false)]
    [InlineData(false, "4.5.3.0", "4.5.3.3", false)]
    [InlineData(true, "5.8.8.0", "4.5.3.3", false)]
    [InlineData(false, "3.8.8.0", "4.5.3.3", false)]
    [InlineData(true, "4.8.8.0", "4.5.3.3", true)]
    [InlineData(true, "4.5.8.0", "4.5.3.3", true)]
    [InlineData(true, "4.8.3.0", "4.5.3.3", true)]
    [InlineData(true, "4.5.4.0", "4.5.3.3", true)]
    [InlineData(false, "4.5.3.0", "4.5.3.3", true)]
    [InlineData(false, "5.8.8.0", "4.5.3.3", true)]
    [InlineData(false, "3.8.8.0", "4.5.3.3", true)]
    public void IsNewerThan_WithinMinorReleaseOnly(bool expected, string versionA, string versionB, bool withinMinorReleaseOnly)
    {
        // Arrange
        var objA = new SemanticVersion(versionA, looseMode: true);
        var objB = new SemanticVersion(versionB, looseMode: true);

        // Act
        var actual = objA.IsNewerThan(objB, withinMinorReleaseOnly, looseMode: true);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(true, "1.2.3")]
    [InlineData(true, "1.2.3-beta01")]
    [InlineData(true, "[1.2.3]")]
    [InlineData(true, "(1.2.3)")]
    [InlineData(false, "")]
    [InlineData(false, "1")]
    [InlineData(false, "1.2")]
    [InlineData(false, "1.2.3.4")]
    [InlineData(false, "01.2.3")]
    [InlineData(false, "1.02.3")]
    [InlineData(false, "1.2.03")]
    [InlineData(false, "1.0.0-01")]
    [InlineData(false, "1.0.0-beta.01")]
    [InlineData(false, "1.0.0+é")]
    public void Parse(bool expected, string version)
    {
        if (expected)
        {
            // Act
            var actual = SemanticVersion.Parse(version);

            // Assert
            Assert.NotNull(actual);
        }
        else
        {
            // Act & Assert
            new Func<object>(()
                => SemanticVersion.Parse(version))
                .Should()
                .ThrowExactly<ArgumentException>();
        }
    }

    [Theory]
    [InlineData(true, "1.2.3")]
    [InlineData(true, "1.2.3-beta01")]
    [InlineData(true, "[1.2.3]")]
    [InlineData(true, "(1.2.3)")]
    [InlineData(false, "")]
    [InlineData(false, "1")]
    [InlineData(false, "1.2")]
    [InlineData(false, "1.2.3.4")]
    [InlineData(false, "01.2.3")]
    [InlineData(false, "1.02.3")]
    [InlineData(false, "1.2.03")]
    [InlineData(false, "1.0.0-01")]
    [InlineData(false, "1.0.0-beta.01")]
    [InlineData(false, "1.0.0+é")]
    public void TryParse(bool expected, string version)
    {
        // Act
        var actual = SemanticVersion.TryParse(version, out _);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(true, "1.2.3", true)]
    [InlineData(true, "1.2.3-beta01", true)]
    [InlineData(true, "[1.2.3]", true)]
    [InlineData(true, "(1.2.3)", true)]
    [InlineData(false, "", true)]
    [InlineData(false, "1", true)]
    [InlineData(false, "1.2", true)]
    [InlineData(true, "1.2.3.4", true)]
    [InlineData(true, "01.2.3", true)]
    [InlineData(true, "1.02.3", true)]
    [InlineData(true, "1.2.03", true)]
    [InlineData(true, "1.0.0-01", true)]
    [InlineData(true, "1.0.0-beta.01", true)]
    [InlineData(false, "1.0.0+é", true)]
    [InlineData(true, "1.2.3", false)]
    [InlineData(true, "1.2.3-beta01", false)]
    [InlineData(false, "", false)]
    [InlineData(false, "1", false)]
    [InlineData(false, "1.2", false)]
    [InlineData(false, "1.2.3.4", false)]
    [InlineData(false, "01.2.3", false)]
    [InlineData(false, "1.02.3", false)]
    [InlineData(false, "1.2.03", false)]
    [InlineData(false, "1.0.0-01", false)]
    [InlineData(false, "1.0.0-beta.01", false)]
    [InlineData(false, "1.0.0+é", false)]
    public void TryParse_LooseMode(bool expected, string version, bool looseMode)
    {
        // Act
        var actual = SemanticVersion.TryParse(version, looseMode, out _);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("1.2.3", "1.2.3", true)]
    [InlineData("1.2.3-beta01", "1.2.3-beta01", true)]
    [InlineData("1.2.3.4", "1.2.3.4", true)]
    [InlineData("1.2.3", "01.2.3", true)]
    [InlineData("1.2.3", "1.02.3", true)]
    [InlineData("1.2.3", "1.2.03", true)]
    [InlineData("1.0.0-1", "1.0.0-01", true)]
    [InlineData("1.0.0-beta.1", "1.0.0-beta.01", true)]
    [InlineData("1.2.3", "1.2.3", false)]
    [InlineData("1.2.3-beta01", "1.2.3-beta01", false)]
    public void Override_ToString(string expected, string version, bool looseMode)
    {
        // Arrange
        var semanticVersion = new SemanticVersion(version, looseMode);

        // Act
        var actual = semanticVersion.ToString();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("1.2.3", "1.2.3", true)]
    [InlineData("1.2.3", "1.2.3-beta01", true)]
    [InlineData("1.2.3.4", "1.2.3.4", true)]
    [InlineData("1.2.3", "01.2.3", true)]
    [InlineData("1.2.3", "1.02.3", true)]
    [InlineData("1.2.3", "1.2.03", true)]
    [InlineData("1.0.0", "1.0.0-01", true)]
    [InlineData("1.0.0", "1.0.0-beta.01", true)]
    [InlineData("1.2.3", "1.2.3", false)]
    [InlineData("1.2.3", "1.2.3-beta01", false)]
    public void ToVersion(string expected, string version, bool looseMode)
    {
        // Arrange
        var semanticVersion = new SemanticVersion(version, looseMode);

        // Act
        var actual = semanticVersion.ToVersion();

        // Assert
        Assert.Equal(expected, actual.ToString());
    }
}