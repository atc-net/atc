using System.Net;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using Xunit.Sdk;

namespace Atc.Rest.FluentAssertions.Tests.Assertions
{
    public class ContentResultAssertionsTests : ContentResultAssertionsBaseFixture
    {
        [Fact]
        public void Ctor_Sets_Subject_On_Subject_Property()
        {
            // Arrange
            var expected = new ContentResult();

            // Act
            var sut = new ContentResultAssertions(expected);

            // Assert
            sut.Subject.Should().Be(expected);
        }

        [Theory]
        [InlineData("BAR", @"Expected content of content result to be System.String, but found System.Text.Json.JsonElement.")]
        [InlineData(42, @"Expected content of content result to be 42, but found FOO.")]
        public void WithContent_Throws_When_Content_Is_Not_Equivalent_To_Expected(object content, string expectedMessage)
        {
            // Arrange
            var target = CreateWithJsonContent("FOO");

            var sut = new ContentResultAssertions(target);

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

            var sut = new ContentResultAssertions(target);

            // Act & Assert
            sut.Invoking(x => x.WithContent("BAR", "Because of something"))
                .Should()
                .Throw<XunitException>()
                .WithMessage(@"Expected content of content result to be ""BAR"" Because of something, but ""FOO"" differs near ""FOO"" (index 0).");
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

            var sut = new ContentResultAssertions(target);

            // Act & Assert
            sut.Invoking(x => x.WithContent("FOO"))
                .Should()
                .Throw<XunitException>();
            //// TODO: Waiting for Github issue
            ////.WithMessage(@"Expected content type of content result to be ""application/json"", but found ""BAZ"".");
        }

        [Fact]
        public void WithContent_Does_Not_Throw_When_Expected_Match()
        {
            // Arrange
            var target = CreateWithJsonContent("FOO");

            var sut = new ContentResultAssertions(target);

            // Act & Assert
            sut.Invoking(x => x.WithContent("FOO"))
                .Should()
                .NotThrow();
        }

        [Fact]
        public void WithStatusCode_Throws_When_StatusCode_Is_Not_As_Expected()
        {
            // Arrange
            var target = new ContentResult
            {
                StatusCode = 100,
            };

            var sut = new ContentResultAssertions(target);

            // Act & Assert
            sut.Invoking(x => x.WithStatusCode(StatusCodes.Status200OK, "FOO {0}", "BAR"))
                .Should()
                .Throw<XunitException>()
                .WithMessage(@"Expected status code to be 200 because FOO BAR, but found 100.");

            sut.Invoking(x => x.WithStatusCode(HttpStatusCode.OK, "FOO {0}", "BAR"))
                .Should()
                .Throw<XunitException>()
                .WithMessage(@"Expected status code to be 200 because FOO BAR, but found 100.");
        }

        [Fact]
        public void WithStatusCode_Does_Not_Throws_When_StatusCode_Is_As_Expected()
        {
            // Arrange
            var target = new ContentResult
            {
                StatusCode = StatusCodes.Status200OK,
            };

            var sut = new ContentResultAssertions(target);

            // Act & Assert
            sut.Invoking(x => x.WithStatusCode(StatusCodes.Status200OK, "FOO", "BAR"))
                .Should()
                .NotThrow();

            sut.Invoking(x => x.WithStatusCode(HttpStatusCode.OK, "FOO", "BAR"))
                .Should()
                .NotThrow();
        }

        [Fact]
        public void WithContentOfType_Throws_When_Content_Is_Not_Expected_Type_With_BecauseMessage()
        {
            // Arrange
            var target = CreateWithJsonContent("FOO");

            var sut = new ContentResultAssertions(target);

            // Act & Assert
            sut.Invoking(x => x.WithContentOfType<int>("Because of something"))
                .Should()
                .Throw<XunitException>()
                .WithMessage(@"Expected type of content in content result to be System.Int32 Because of something, but found """"FOO"""".");
        }

        [Fact]
        public void WithContentOfType_Throws_When_Content_Is_Expected()
        {
            // Arrange
            var target = CreateWithJsonContent("FOO");

            var sut = new ContentResultAssertions(target);

            // Act & Assert
            sut.WithContentOfType<string>().Subject.Should().Be("FOO");
        }
    }
}