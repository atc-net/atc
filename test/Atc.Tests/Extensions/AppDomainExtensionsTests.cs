namespace Atc.Tests.Extensions;

[Trait(Traits.Category, Traits.Categories.Integration)]
[Trait(Traits.Category, Traits.Categories.SkipWhenLiveUnitTesting)]
public class AppDomainExtensionsTests
{
    [Fact]
    public void GetAllExportedTypes()
    {
        // Act
        var actual = AppDomain.CurrentDomain.GetAllExportedTypes();

        // Assert
        Assert.NotNull(actual);
    }

    [Fact]
    public void GetExportedTypeByName()
    {
        // Act
        var actual = AppDomain.CurrentDomain.GetExportedTypeByName(nameof(UnexpectedTypeException));

        // Assert
        Assert.NotNull(actual);
        Assert.Equal(typeof(UnexpectedTypeException), actual);
    }

    [Fact]
    public void GetExportedPropertyTypeByName()
    {
        // Act
        var actual = AppDomain.CurrentDomain.GetExportedPropertyTypeByName(nameof(UnexpectedTypeException), nameof(UnexpectedTypeException.Message));

        // Assert
        Assert.NotNull(actual);
    }

    [Fact]
    public void GetCustomAssemblies()
    {
        // Act
        var assemblies = AppDomain.CurrentDomain.GetAssemblies();
        var customAssemblies = AppDomain.CurrentDomain.GetCustomAssemblies();

        // Assert
        Assert.NotNull(assemblies);
        Assert.NotNull(customAssemblies);

        assemblies.Should().HaveCountGreaterThan(customAssemblies.Length);
    }

    [Fact]
    public void GetAssemblyInformations()
    {
        // Act
        var actual = AppDomain.CurrentDomain.GetAssemblyInformations();

        // Assert
        Assert.NotNull(actual);

        var expectedCount = AppDomain
            .CurrentDomain
            .GetAssemblies()
            .Count(x => !x.IsDynamic);

        Assert.Equal(expectedCount, actual.Length);
    }

    [Fact]
    public void GetAssemblyInformationsBySystem()
    {
        // Act
        var actual = AppDomain.CurrentDomain.GetAssemblyInformationsBySystem();

        // Assert
        Assert.NotNull(actual);
    }

    [Fact]
    public void GetAssemblyInformationsByStartsWith()
    {
        // Act
        var actual = AppDomain.CurrentDomain.GetAssemblyInformationsByStartsWith("Atc");

        // Assert
        Assert.NotNull(actual);

        var expectedCount = AppDomain
            .CurrentDomain
            .GetAssemblies()
            .Count(x => x.FullName!.StartsWith("Atc", StringComparison.Ordinal));

        Assert.Equal(expectedCount, actual.Length);
    }

    [Fact]
    public void TryLoadAssemblyIfNeeded()
    {
        // Arrange - Use an already loaded assembly (Atc.dll)
        var dllFileName = "Atc.dll";

        // Act
        var actual = AppDomain.CurrentDomain.TryLoadAssemblyIfNeeded(dllFileName);

        // Assert
        Assert.True(actual);
    }
}