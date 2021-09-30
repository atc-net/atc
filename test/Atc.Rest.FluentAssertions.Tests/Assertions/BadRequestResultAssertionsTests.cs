using Atc.Rest.FluentAssertions.Tests.XUnitTestData;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using Xunit.Sdk;

namespace Atc.Rest.FluentAssertions.Tests.Assertions
{
    public class BadRequestResultAssertionsTests : ContentResultAssertionsBaseFixture
    {
        [Fact]
        public void Ctor_Sets_Subject_On_Subject_Property()
        {
            // Arrange
            var expected = new ContentResult();

            // Act
            var sut = new BadRequestResultAssertions(expected);

            // Assert
            sut.Subject.Should().Be(expected);
        }

        [Theory]
        [InlineData("BAR", @"Expected content of bad request result to be System.String, but found System.Text.Json.JsonElement.")]
        [InlineData(42, @"Expected content of bad request result to be 42, but found FOO.")]
        public void WithContent_Throws_When_Content_Is_Not_Equivalent_To_Expected(object content, string expectedMessage)
        {
            // Arrange
            var target = CreateWithJsonContent("FOO");

            var sut = new BadRequestResultAssertions(target);

            // Act & Assert
            sut.Invoking(x => x.WithContent(content))
                .Should()
                .Throw<XunitException>()
                .WithMessage(expectedMessage);
        }

        [Fact]
        public void WithContent_Throws_When_Content_Is_Not_Equivalent_To_Expected_WithBecauseMessage()
        {
            // Arrange
            var target = CreateWithJsonContent("FOO");

            var sut = new BadRequestResultAssertions(target);

            // Act & Assert
            sut.Invoking(x => x.WithContent("BAR", "Because of something"))
                .Should()
                .Throw<XunitException>()
                .WithMessage(@"Expected content of bad request result to be ""BAR"" Because of something, but ""FOO"" differs near ""FOO"" (index 0).");
        }

        [Fact]
        public void WithContent_Throws_When_ContentTypes_Isnt_Json()
        {
            // Arrange
            var target = new ContentResult
            {
                Content = "FOO",
                ContentType = "BAZ",
            };

            var sut = new BadRequestResultAssertions(target);

            // Act & Assert
            sut.Invoking(x => x.WithContent("FOO"))
                .Should()
                .Throw<XunitException>()
                .WithMessage(@"Expected content type of bad request result to be ""application/json"", but found ""BAZ"".");
        }

        [Fact]
        public void WithContent_Does_Not_Throw_When_Expected_Match()
        {
            // Arrange
            var target = CreateWithJsonContent("FOO");

            var sut = new BadRequestResultAssertions(target);

            // Act & Assert
            sut.Invoking(x => x.WithContent("FOO"))
                .Should()
                .NotThrow();
        }

        [Theory]
        [MemberData(nameof(TestDataAssertions.ErrorMessageContent), MemberType = typeof(TestDataAssertions))]
        public void WithErrorMessage_Throws_When_Content_Doenst_Match_Expected(object content)
        {
            // Arrange
            var target = CreateWithJsonContent(content);
            var sut = new BadRequestResultAssertions(target);

            // Act & Assert
            sut.Invoking(x => x.WithErrorMessage("BAR"))
                .Should()
                .Throw<XunitException>()
                .WithMessage(@"Expected error message of bad request result to be ""BAR"", but found ""FOO"".");
        }

        [Theory]
        [MemberData(nameof(TestDataAssertions.ErrorMessageContent), MemberType = typeof(TestDataAssertions))]
        public void WithErrorMessage_Does_Not_Throw_When_Expected_Match(object content)
        {
            // Arrange
            var target = CreateWithJsonContent(content);
            var sut = new BadRequestResultAssertions(target);

            // Act & Assert
            sut.Invoking(x => x.WithErrorMessage("FOO"))
                .Should()
                .NotThrow();
        }
    }
}