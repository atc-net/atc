namespace Atc.Rest.FluentAssertions.Tests.Extensions;

public class ResultBaseExtensionsTests
{
    [Fact]
    public void Should_Returns_ResultAssertion_With_Subject_Set_To_Subject()
    {
        // Arrange
        var target = new AtcDummyResult();

        // Act
        var actual = target.Should();

        // Assert
        actual
            .Invoking(x => x.BeOkResult())
            .Should()
            .Throw<XunitException>()
            .WithMessage($"*{typeof(DummyResult).FullName}*");
    }

    private sealed class DummyResult : ActionResult
    {
    }

    private sealed class AtcDummyResult : ResultBase
    {
        public AtcDummyResult()
            : base(new DummyResult())
        {
        }
    }
}