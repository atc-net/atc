namespace Atc.Tests.Helpers;

public class CultureInfoHelperTests
{
    [Fact]
    public void GetCulturesFromNames()
    {
        // Arrange
        var cultureNames = new[]
        {
            "da-DK",
            "de-DE",
            "2057",
        };

        // Atc
        var actual = CultureInfoHelper.GetCulturesFromNames(cultureNames);

        // Assert
        actual
            .Should().NotBeNull()
            .And.HaveCount(3);
    }
}