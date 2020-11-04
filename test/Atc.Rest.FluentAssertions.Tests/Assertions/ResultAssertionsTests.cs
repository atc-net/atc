using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using Xunit.Sdk;

namespace Atc.Rest.FluentAssertions.Tests.Assertions
{
    public class ResultAssertionsTests
    {
        class DummyResult : ActionResult { }

        [Fact]
        public void BeOkResult_Throws_When_Subject_Isnt_OkObjectResult()
        {
            // Arrange
            var target = new DummyResult();
            var sut = new ResultAssertions(target);

            // Act & Assert
            sut.Invoking(x => x.BeOkResult())
                .Should()
                .Throw<XunitException>()
                .WithMessage($"Expected result to be of type Microsoft.AspNetCore.Mvc.OkObjectResult, but found {target.GetType().FullName}.");
        }

        [Fact]
        public void BeOkResult_Throws_When_OkObjectResult_StatusCode_Isnt_200()
        {
            // Arrange
            var target = new OkObjectResult(string.Empty) { StatusCode = 201 };
            var sut = new ResultAssertions(target);

            // Act & Assert
            sut.Invoking(x => x.BeOkResult())
                .Should()
                .Throw<XunitException>()
                .WithMessage($"Expected status code from result to be 200, but found {target.StatusCode}.");
        }

        [Fact]
        public void BeOkResult_Passes_When_Subject_Is_OkObjectResult_With_StatusCode_200()
        {
            // Arrange
            var target = new OkObjectResult(string.Empty);
            var sut = new ResultAssertions(target);

            // Act & Assert
            sut.Invoking(x => x.BeOkResult())
                .Should()
                .NotThrow();
        }

        [Fact]
        public void BeNotFoundResult_Throws_When_Subject_Isnt_ContentResult()
        {
            // Arrange
            var target = new DummyResult();
            var sut = new ResultAssertions(target);

            // Act & Assert
            sut.Invoking(x => x.BeNotFoundResult())
                .Should()
                .Throw<XunitException>()
                .WithMessage($"Expected result to be of type Microsoft.AspNetCore.Mvc.ContentResult, but found {target.GetType().FullName}.");
        }

        [Fact]
        public void BeNotFoundResult_Throws_When_ContentResult_StatusCode_Isnt_404()
        {
            // Arrange
            var target = new ContentResult() { StatusCode = 400 };
            var sut = new ResultAssertions(target);

            // Act & Assert
            sut.Invoking(x => x.BeNotFoundResult())
                .Should()
                .Throw<XunitException>()
                .WithMessage($"Expected status code from result to be 404, but found {target.StatusCode}.");
        }

        [Fact]
        public void BeNotFoundResult_Passes_When_Subject_Is_OkObjectResult_With_StatusCode_200()
        {
            // Arrange
            var target = new ContentResult() { StatusCode = 404 };
            var sut = new ResultAssertions(target);

            // Act & Assert
            sut.Invoking(x => x.BeNotFoundResult())
                .Should()
                .NotThrow();
        }
    }
}