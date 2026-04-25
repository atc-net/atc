namespace Atc.Tests.Helpers;

public class ProcessHelperStartInfoTests
{
    [Fact]
    public async Task ExecuteAsync_StartInfoOverload_NullStartInfo_Throws()
    {
        // Arrange
        ProcessStartInfo startInfo = null!;

        // Act
        var act = async () => await ProcessHelper.ExecuteAsync(startInfo);

        // Assert
        (await act.Should().ThrowAsync<ArgumentNullException>())
            .WithParameterName(nameof(startInfo));
    }

    [Fact]
    public async Task ExecuteAsync_StartInfoOverload_EmptyFileName_Throws()
    {
        // Arrange
        var startInfo = new ProcessStartInfo();

        // Act
        var act = async () => await ProcessHelper.ExecuteAsync(startInfo);

        // Assert
        (await act.Should().ThrowAsync<ArgumentException>())
            .WithParameterName(nameof(startInfo));
    }
}