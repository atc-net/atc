namespace Atc.Rest.FluentAssertions.Tests.Assertions;

public class OkResultAssertionsTests
{
    [Fact]
    public void Ctor_Sets_Subject_On_Subject_Property()
    {
        // Arrange
        var expected = new OkObjectResult("FOO");

        // Act
        var sut = new OkResultAssertions(expected);

        // Assert
        sut.Subject.Should().Be(expected);
    }

    [Theory]
    [InlineData("BAR", @"Expected content of OK result to be ""BAR"", but ""FOO"" differs near ""FOO"" (index 0).")]
    [InlineData(42, @"Expected content of OK result to be 42, but found ""FOO"".")]
    public void WithContent_Throws_When_Content_Is_Not_Equivalent_To_Expected(
        object content,
        string expectedMessage)
    {
        // Arrange
        var target = new OkObjectResult("FOO");
        target.ContentTypes.Add(MediaTypeHeaderValue.Parse(MediaTypeNames.Application.Json));
        var sut = new OkResultAssertions(target);

        // Act & Assert
        sut.Invoking(x => x.WithContent(content))
            .Should()
            .Throw<XunitException>()
            .WithMessage(expectedMessage + "*");
    }

    [Fact]
    public void WithContent_Throws_When_Content_Is_Not_Equivalent_To_Expected_WithBecauseMessage()
    {
        // Arrange
        var target = new OkObjectResult("FOO");
        target.ContentTypes.Add(MediaTypeHeaderValue.Parse(MediaTypeNames.Application.Json));
        var sut = new OkResultAssertions(target);

        // Act & Assert
        sut.Invoking(x => x.WithContent("BAR", "Because of something"))
            .Should()
            .Throw<XunitException>()
            .WithMessage(@"Expected content of OK result to be ""BAR"" Because of something, but ""FOO"" differs near ""FOO"" (index 0)." + "*");
    }

    [Fact]
    public void WithContentOfType_Throws_When_Content_Is_Not_Expected_Type_With_BecauseMessage()
    {
        // Arrange
        var target = new OkObjectResult("FOO");
        var sut = new OkResultAssertions(target);

        // Act & Assert
        sut.Invoking(x => x.WithContentOfType<List<string>>("Because of something"))
            .Should()
            .Throw<XunitException>()
            .WithMessage(@"Expected content type of OK result to be assignable to System.Collections.Generic.List`1[System.String] Because of something, but System.String is not.");
    }

    [Fact]
    public void WithContent_Does_Not_Throw_When_Expected_Match()
    {
        // Arrange
        var target = new OkObjectResult("FOO");
        target.ContentTypes.Add(MediaTypeHeaderValue.Parse(MediaTypeNames.Application.Json));
        var sut = new OkResultAssertions(target);

        // Act & Assert
        sut.Invoking(x => x.WithContent("FOO"))
            .Should()
            .NotThrow();
    }
}