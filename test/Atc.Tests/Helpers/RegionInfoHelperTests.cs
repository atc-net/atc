namespace Atc.Tests.Helpers;

public class RegionInfoHelperTests
{
    [Theory]
    [InlineData(100)]
    public void GetAllRegionInfos(int expectedAtLeast)
    {
        // Act
        var actual = RegionInfoHelper.GetAllRegionInfos();

        // Assert
        actual.Should().NotBeNull()
            .And.BeOfType<List<RegionInfo>>()
            .And.HaveCountGreaterThan(expectedAtLeast);
    }

    [Theory]
    [InlineData("US", GlobalizationLcidConstants.UnitedStates)]
    [InlineData("GB", GlobalizationLcidConstants.GreatBritain)]
    [InlineData("DK", GlobalizationLcidConstants.Denmark)]
    [InlineData("DE", GlobalizationLcidConstants.Germany)]
    public void GetRegionInfoByLcid(
        string expected,
        int input)
    {
        // Act
        var actual = RegionInfoHelper.GetRegionInfoByLcid(input);

        // Assert
        actual.Should().NotBeNull()
            .And.BeOfType<RegionInfo>()
            .Subject.Name.Should().Be(expected);
    }

    [Theory]
    [InlineData("US", "USA")]
    [InlineData("GB", "GBR")]
    [InlineData("DK", "DNK")]
    [InlineData("DE", "DEU")]
    public void GetRegionInfoByIsoAlpha3(
        string expected,
        string input)
    {
        // Act
        var actual = RegionInfoHelper.GetRegionInfoByIsoAlpha3(input);

        // Assert
        actual.Should().NotBeNull()
            .And.BeOfType<RegionInfo>()
            .Subject.Name.Should().Be(expected);
    }

    [Theory]
    [InlineData("en-US", "USA")]
    [InlineData("en-GB", "GBR")]
    [InlineData("da-DK", "DNK")]
    [InlineData("de-DE", "DEU")]
    public void GetCultureInfoByIsoAlpha3(
        string expected,
        string input)
    {
        // Act
        var actual = RegionInfoHelper.GetCultureInfoByIsoAlpha3(input);

        // Assert
        actual.Should().NotBeNull()
            .And.BeOfType<CultureInfo>()
            .Subject.Name.Should().Be(expected);
    }

    [Theory]
    [InlineData(GlobalizationLcidConstants.UnitedStates, GlobalizationLcidConstants.UnitedStates)]
    [InlineData(GlobalizationLcidConstants.GreatBritain, GlobalizationLcidConstants.GreatBritain)]
    [InlineData(GlobalizationLcidConstants.Denmark, GlobalizationLcidConstants.Denmark)]
    [InlineData(GlobalizationLcidConstants.Germany, GlobalizationLcidConstants.Germany)]
    public void GetLcidFromRegionInfo(
        int expected,
        int input)
    {
        // Arrange
        var regionInfo = new RegionInfo(input);

        // Act
        var actual = RegionInfoHelper.GetLcidFromRegionInfo(regionInfo);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(100)]
    public void GetAllRegionInfosAsLcids(int expectedAtLeast)
    {
        // Act
        var actual = RegionInfoHelper.GetAllRegionInfosAsLcids();

        // Assert
        actual.Should().NotBeNull()
            .And.BeOfType<List<int>>()
            .And.HaveCountGreaterThan(expectedAtLeast);
    }
}