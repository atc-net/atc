using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using Xunit.Sdk;

namespace Atc.Rest.FluentAssertions.Tests.Assertions
{
    public class ResultAssertionsTests
    {
        private class DummyResult : ActionResult { }

        [Fact]
        public void BeContentResult_Throws_When_Subject_Isnt_ContentResult()
        {
            // Arrange
            var target = new DummyResult();
            var sut = new ResultAssertions(target);

            // Act & Assert
            sut.Invoking(x => x.BeContentResult())
                .Should()
                .Throw<XunitException>()
                .WithMessage($"Expected type to be Microsoft.AspNetCore.Mvc.ContentResult, but found {target.GetType().FullName}.");
        }

        [Fact]
        public void BeContentResult_Passes_When_Subject_Is_ContentResult()
        {
            // Arrange
            var target = new ContentResult();
            var sut = new ResultAssertions(target);

            // Act & Assert
            sut.Invoking(x => x.BeContentResult())
                .Should()
                .NotThrow();
        }

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
        public void BeCreatedResult_Throws_When_Subject_Isnt_ContentResult()
        {
            // Arrange
            var target = new DummyResult();
            var sut = new ResultAssertions(target);

            // Act & Assert
            sut.Invoking(x => x.BeCreatedResult())
                .Should()
                .Throw<XunitException>()
                .WithMessage($"Expected result to be of type Microsoft.AspNetCore.Mvc.ContentResult, but found {target.GetType().FullName}.");
        }

        [Fact]
        public void BeCreatedResult_Throws_When_ContentResult_StatusCode_Isnt_202()
        {
            // Arrange
            var target = new ContentResult { StatusCode = 1337 };
            var sut = new ResultAssertions(target);

            // Act & Assert
            sut.Invoking(x => x.BeCreatedResult())
                .Should()
                .Throw<XunitException>()
                .WithMessage($"Expected status code from result to be 201, but found {target.StatusCode}.");
        }

        [Fact]
        public void BeCreatedResult_Passes_When_Subject_Is_ContentResult_With_StatusCode_202()
        {
            // Arrange
            var target = new ContentResult { StatusCode = 201 };
            var sut = new ResultAssertions(target);

            // Act & Assert
            sut.Invoking(x => x.BeCreatedResult())
                .Should()
                .NotThrow();
        }

        [Fact]
        public void BeAcceptedResult_Throws_When_Subject_Isnt_ContentResult()
        {
            // Arrange
            var target = new DummyResult();
            var sut = new ResultAssertions(target);

            // Act & Assert
            sut.Invoking(x => x.BeAcceptedResult())
                .Should()
                .Throw<XunitException>()
                .WithMessage($"Expected result to be of type Microsoft.AspNetCore.Mvc.ContentResult, but found {target.GetType().FullName}.");
        }

        [Fact]
        public void BeAcceptedResult_Throws_When_ContentResult_StatusCode_Isnt_202()
        {
            // Arrange
            var target = new ContentResult { StatusCode = 1337 };
            var sut = new ResultAssertions(target);

            // Act & Assert
            sut.Invoking(x => x.BeAcceptedResult())
                .Should()
                .Throw<XunitException>()
                .WithMessage($"Expected status code from result to be 202, but found {target.StatusCode}.");
        }

        [Fact]
        public void BeAcceptedResult_Passes_When_Subject_Is_ContentResult_With_StatusCode_202()
        {
            // Arrange
            var target = new ContentResult { StatusCode = 202 };
            var sut = new ResultAssertions(target);

            // Act & Assert
            sut.Invoking(x => x.BeAcceptedResult())
                .Should()
                .NotThrow();
        }

        [Fact]
        public void BeNoContentResult_Throws_When_Subject_Isnt_ContentResult()
        {
            // Arrange
            var target = new DummyResult();
            var sut = new ResultAssertions(target);

            // Act & Assert
            sut.Invoking(x => x.BeNoContentResult())
                .Should()
                .Throw<XunitException>()
                .WithMessage($"Expected result to be of type Microsoft.AspNetCore.Mvc.ContentResult, but found {target.GetType().FullName}.");
        }

        [Fact]
        public void BeNoContentResult_Throws_When_ContentResult_StatusCode_Isnt_204()
        {
            // Arrange
            var target = new ContentResult { StatusCode = 1337 };
            var sut = new ResultAssertions(target);

            // Act & Assert
            sut.Invoking(x => x.BeNoContentResult())
                .Should()
                .Throw<XunitException>()
                .WithMessage($"Expected status code from result to be 204, but found {target.StatusCode}.");
        }

        [Fact]
        public void BeNoContentResult_Passes_When_Subject_Is_ContentResult_With_StatusCode_204()
        {
            // Arrange
            var target = new ContentResult { StatusCode = 204 };
            var sut = new ResultAssertions(target);

            // Act & Assert
            sut.Invoking(x => x.BeNoContentResult())
                .Should()
                .NotThrow();
        }

        [Fact]
        public void BeBadRequestResult_Throws_When_Subject_Isnt_ContentResult()
        {
            // Arrange
            var target = new DummyResult();
            var sut = new ResultAssertions(target);

            // Act & Assert
            sut.Invoking(x => x.BeBadRequestResult())
                .Should()
                .Throw<XunitException>()
                .WithMessage($"Expected result to be of type Microsoft.AspNetCore.Mvc.ContentResult, but found {target.GetType().FullName}.");
        }

        [Fact]
        public void BeBadRequestResult_Throws_When_ContentResult_StatusCode_Isnt_400()
        {
            // Arrange
            var target = new ContentResult { StatusCode = 1337 };
            var sut = new ResultAssertions(target);

            // Act & Assert
            sut.Invoking(x => x.BeBadRequestResult())
                .Should()
                .Throw<XunitException>()
                .WithMessage($"Expected status code from result to be 400, but found {target.StatusCode}.");
        }

        [Fact]
        public void BeBadRequestResult_Passes_When_Subject_Is_ContentResult_With_StatusCode_400()
        {
            // Arrange
            var target = new ContentResult { StatusCode = 400 };
            var sut = new ResultAssertions(target);

            // Act & Assert
            sut.Invoking(x => x.BeBadRequestResult())
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
            var target = new ContentResult { StatusCode = 1337 };
            var sut = new ResultAssertions(target);

            // Act & Assert
            sut.Invoking(x => x.BeNotFoundResult())
                .Should()
                .Throw<XunitException>()
                .WithMessage($"Expected status code from result to be 404, but found {target.StatusCode}.");
        }

        [Fact]
        public void BeNotFoundResult_Passes_When_Subject_Is_ContentResult_With_StatusCode_404()
        {
            // Arrange
            var target = new ContentResult { StatusCode = 404 };
            var sut = new ResultAssertions(target);

            // Act & Assert
            sut.Invoking(x => x.BeNotFoundResult())
                .Should()
                .NotThrow();
        }

        [Fact]
        public void BeConflictResult_Throws_When_Subject_Isnt_ContentResult()
        {
            // Arrange
            var target = new DummyResult();
            var sut = new ResultAssertions(target);

            // Act & Assert
            sut.Invoking(x => x.BeConflictResult())
                .Should()
                .Throw<XunitException>()
                .WithMessage($"Expected result to be of type Microsoft.AspNetCore.Mvc.ContentResult, but found {target.GetType().FullName}.");
        }

        [Fact]
        public void BeConflictResult_Throws_When_ContentResult_StatusCode_Isnt_409()
        {
            // Arrange
            var target = new ContentResult { StatusCode = 1337 };
            var sut = new ResultAssertions(target);

            // Act & Assert
            sut.Invoking(x => x.BeConflictResult())
                .Should()
                .Throw<XunitException>()
                .WithMessage($"Expected status code from result to be 409, but found {target.StatusCode}.");
        }

        [Fact]
        public void BeConflictResult_Passes_When_Subject_Is_ContentResult_With_StatusCode_404()
        {
            // Arrange
            var target = new ContentResult { StatusCode = 409 };
            var sut = new ResultAssertions(target);

            // Act & Assert
            sut.Invoking(x => x.BeConflictResult())
                .Should()
                .NotThrow();
        }
    }
}