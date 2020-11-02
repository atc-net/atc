#nullable enable
using System.Net;
using Atc.Rest.Results;
using Xunit;

namespace Atc.Rest.Tests.Results
{
    public class ResultFactoryTests
    {
        [Theory]
        [InlineData(HttpStatusCode.OK, null)]
        [InlineData(HttpStatusCode.OK, "Hallo World")]
        public void CreateProblemDetails_Message(HttpStatusCode statusCode, string? message)
        {
            // Act
            var actual = ResultFactory.CreateProblemDetails(statusCode, message);

            // Assert
            Assert.NotNull(actual);
            Assert.Equal((int)statusCode, actual.Status);
            if (message != null)
            {
                Assert.NotNull(actual.Detail);
                Assert.Equal(message, actual.Detail);
            }
        }

        [Theory]
        [InlineData(HttpStatusCode.OK, null)]
        [InlineData(HttpStatusCode.OK, "Hallo World")]
        public void CreateContentResultWithProblemDetails_Message(HttpStatusCode statusCode, string? message)
        {
            // Act
            var actual = ResultFactory.CreateContentResultWithProblemDetails(statusCode, message);

            // Assert
            Assert.NotNull(actual);
            Assert.Equal((int)statusCode, actual.StatusCode);
            if (message != null)
            {
                Assert.NotNull(actual.Content);
                Assert.Equal("application/json", actual.ContentType);
                Assert.Equal($"{{\"status\":{(int)statusCode},\"detail\":\"{message}\"}}", actual.Content);
            }
        }

        [Theory]
        [InlineData(HttpStatusCode.OK, null, "application/json")]
        [InlineData(HttpStatusCode.OK, "Hallo World", "application/json")]
        [InlineData(HttpStatusCode.OK, "Hallo World", "text/html")]
        public void CreateContentResultWithProblemDetails_Message_ContentType(HttpStatusCode statusCode, string? message, string contentType)
        {
            // Act
            var actual = ResultFactory.CreateContentResultWithProblemDetails(statusCode, message, contentType);

            // Assert
            Assert.NotNull(actual);
            Assert.Equal((int)statusCode, actual.StatusCode);
            if (message != null)
            {
                Assert.NotNull(actual.Content);
                Assert.Equal(contentType, actual.ContentType);
                Assert.Equal($"{{\"status\":{(int)statusCode},\"detail\":\"{message}\"}}", actual.Content);
            }
        }

        [Theory]
        [InlineData(HttpStatusCode.OK, null)]
        [InlineData(HttpStatusCode.OK, "Hallo World")]
        public void CreateContentResult_Message(HttpStatusCode statusCode, string? message)
        {
            // Act
            var actual = ResultFactory.CreateContentResult(statusCode, message);

            // Assert
            Assert.NotNull(actual);
            Assert.Equal((int)statusCode, actual.StatusCode);
            if (message != null)
            {
                Assert.NotNull(actual.Content);
                Assert.Equal($"\"{message}\"", actual.Content);
            }
        }

        [Theory]
        [InlineData(HttpStatusCode.OK, null, "application/json")]
        [InlineData(HttpStatusCode.OK, "Hallo World", "application/json")]
        [InlineData(HttpStatusCode.OK, "Hallo World", "text/html")]
        public void CreateContentResult_Message_ContentType(HttpStatusCode statusCode, string? message, string contentType)
        {
            // Act
            var actual = ResultFactory.CreateContentResult(statusCode, message, contentType);

            // Assert
            Assert.NotNull(actual);
            Assert.Equal((int)statusCode, actual.StatusCode);
            if (message != null)
            {
                Assert.NotNull(actual.Content);
                Assert.Equal(contentType, actual.ContentType);
                Assert.Equal($"\"{message}\"", actual.Content);
            }
        }
    }
}