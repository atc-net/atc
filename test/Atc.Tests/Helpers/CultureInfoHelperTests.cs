namespace Atc.Tests.Helpers;

[Trait(Traits.Category, Traits.Categories.Integration)]
[Trait(Traits.Category, Traits.Categories.SkipWhenLiveUnitTesting)]
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