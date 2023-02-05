namespace Atc.Tests.Helpers;

public class AssemblyHelperTests
{
    [Fact]
    public void GetAssemblyInformations()
    {
        // Act
        var actual = AssemblyHelper.GetAssemblyInformations();

        // Assert
        Assert.NotNull(actual);

        var expectedCount = AppDomain
            .CurrentDomain
            .GetAssemblies().Count(x => !x.IsDynamic);

        Assert.Equal(expectedCount, actual.Length);
    }

    [Fact]
    public void GetAssemblyInformationsBySystem()
    {
        // Act
        var actual = AssemblyHelper.GetAssemblyInformationsBySystem();

        // Assert
        Assert.NotNull(actual);
    }

    [Fact]
    public void GetAssemblyInformationsByStartsWith()
    {
        // Act
        var actual = AssemblyHelper.GetAssemblyInformationsByStartsWith("Atc");

        // Assert
        Assert.NotNull(actual);

        var expectedCount = AppDomain
            .CurrentDomain
            .GetAssemblies()
            .Count(x => x.FullName!.StartsWith("Atc", StringComparison.Ordinal));

        Assert.Equal(expectedCount, actual.Length);
    }
}