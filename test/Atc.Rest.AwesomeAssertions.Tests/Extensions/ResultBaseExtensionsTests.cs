namespace Atc.Rest.AwesomeAssertions.Tests.Extensions;

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

    [Fact]
    public void Chained_BeOkResult_WithContent_Throws_When_Content_Differs()
    {
        // Arrange - the headline chained API, where a single AssertionChain flows
        // through BeOkResult() (which succeeds) and into WithContent() (which fails).
        var target = new AtcOkResult("FOO");

        // Act & Assert
        target
            .Invoking(x => x.Should().BeOkResult().WithContent("BAR"))
            .Should()
            .Throw<XunitException>()
            .WithMessage("Expected content of OK result*");
    }

    [Fact]
    public void Chained_BeOkResult_WithContent_Does_Not_Throw_When_Content_Matches()
    {
        // Arrange
        var target = new AtcOkResult("FOO");

        // Act & Assert
        target
            .Invoking(x => x.Should().BeOkResult().WithContent("FOO"))
            .Should()
            .NotThrow();
    }

    [Fact]
    public void Chained_BeNotFoundResult_WithErrorMessage_Throws_When_Message_Differs()
    {
        // Arrange - chained path through an error result type (ErrorContentResultAssertions).
        var target = new AtcNotFoundResult("actual message");

        // Act & Assert
        target
            .Invoking(x => x.Should().BeNotFoundResult().WithErrorMessage("expected message"))
            .Should()
            .Throw<XunitException>()
            .WithMessage("Expected error message of not found result*");
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

    private sealed class AtcOkResult : ResultBase
    {
        public AtcOkResult(object content)
            : base(new OkObjectResult(content))
        {
        }
    }

    private sealed class AtcNotFoundResult : ResultBase
    {
        public AtcNotFoundResult(string errorMessage)
            : base(new ContentResult
            {
                StatusCode = StatusCodes.Status404NotFound,
                ContentType = MediaTypeNames.Application.Json,
                Content = TestJsonSerializer.Serialize(errorMessage),
            })
        {
        }
    }
}