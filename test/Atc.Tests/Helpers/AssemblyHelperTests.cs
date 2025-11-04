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

        var nonDynamicAssemblies = AppDomain
            .CurrentDomain
            .GetAssemblies()
            .Where(x => !x.IsDynamic)
            .ToList();

        // Verify the count matches the number of non-dynamic assemblies in the current domain
        // Allow for minor discrepancies due to timing of assembly loads during test execution
        Assert.InRange(actual.Length, nonDynamicAssemblies.Count - 2, nonDynamicAssemblies.Count);

        // Verify at least some expected assemblies are present
        Assert.Contains(actual, x => x.Name.StartsWith("Atc", StringComparison.Ordinal));
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