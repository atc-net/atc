namespace Atc.Tests.Data;

public class AssemblyInformationFactoryTests
{
    [Fact]
    public void Create()
    {
        // Arrange
        var assembly = Assembly.GetAssembly(typeof(AssemblyInformationFactoryTests))!;

        // Act
        var actual = AssemblyInformationFactory.Create(assembly);

        // Assert
        Assert.NotNull(actual);
        Assert.Equal("Atc.Tests", actual.Name);
        Assert.Equal(new Version(1, 0, 0, 0), actual.Version);
    }
}