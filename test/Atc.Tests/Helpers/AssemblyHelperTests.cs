namespace Atc.Tests.Helpers;

public class AssemblyHelperTests
{
    [Fact]
    public void GetProjectRootDirectory()
    {
        // Act
        var actual = AssemblyHelper.GetProjectRootDirectory();

        // Assert
        Assert.NotNull(actual);
        Assert.True(actual.Exists);
    }

    [Fact]
    public void Load()
    {
        // Arrange
        var assemblyFile = new FileInfo(typeof(AssemblyHelper).Assembly.Location);

        // Act
        var actual = AssemblyHelper.Load(assemblyFile);

        // Assert
        Assert.NotNull(actual);
    }

    [Fact]
    public void ReadAsBytes()
    {
        // Arrange
        var assemblyFile = new FileInfo(typeof(AssemblyHelper).Assembly.Location);

        // Act
        var actual = AssemblyHelper.ReadAsBytes(assemblyFile);

        // Assert
        Assert.NotNull(actual);
        Assert.NotEmpty(actual);
    }

    [Fact]
    public void GetSystemName()
    {
        // Act
        var actual = AssemblyHelper.GetSystemName();

        // Assert
        Assert.NotNull(actual);
        Assert.NotEmpty(actual);
    }

    [Fact]
    public void GetSystemNameAsKebabCasing()
    {
        // Act
        var actual = AssemblyHelper.GetSystemNameAsKebabCasing();

        // Assert
        Assert.NotNull(actual);
        Assert.NotEmpty(actual);
        Assert.Equal(actual.ToLower(GlobalizationConstants.EnglishCultureInfo), actual);
    }

    [Fact]
    public void GetSystemVersion()
    {
        // Act
        var actual = AssemblyHelper.GetSystemVersion();

        // Assert
        Assert.NotNull(actual);
    }

    [Fact]
    public void GetSystemLocation()
    {
        // Act
        var actual = AssemblyHelper.GetSystemLocation();

        // Assert
        Assert.NotNull(actual);
        Assert.NotEmpty(actual);
    }

    [Fact]
    public void GetSystemLocationPath()
    {
        // Act
        var actual = AssemblyHelper.GetSystemLocationPath();

        // Assert
        Assert.NotNull(actual);
        Assert.NotEmpty(actual);
    }

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