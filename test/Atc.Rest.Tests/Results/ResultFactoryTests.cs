using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mime;
using System.Text;
using Atc.Rest.Results;
using Microsoft.AspNetCore.Mvc;
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
        public void CreateValidationProblemDetails_Message(HttpStatusCode statusCode, string? message)
        {
            // Act
            var actual = ResultFactory.CreateValidationProblemDetails(statusCode, new Dictionary<string, string[]>(StringComparer.Ordinal), message);

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
                Assert.Equal(MediaTypeNames.Application.Json, actual.ContentType);
                Assert.Equal($"{{\"status\":{(int)statusCode},\"detail\":\"{message}\"}}", actual.Content);
            }
        }

        [Theory]
        [InlineData(HttpStatusCode.OK, null)]
        [InlineData(HttpStatusCode.OK, "Hallo World")]
        public void CreateContentResultWithValidationProblemDetails_Message(HttpStatusCode statusCode, string? message)
        {
            // Act
            var actual = ResultFactory.CreateContentResultWithValidationProblemDetails(statusCode, message);

            // Assert
            Assert.NotNull(actual);
            Assert.Equal((int)statusCode, actual.StatusCode);
            if (message != null)
            {
                Assert.NotNull(actual.Content);
                Assert.Equal(MediaTypeNames.Application.Json, actual.ContentType);
                Assert.Equal($"{{\"title\":\"One or more validation errors occurred.\",\"status\":{(int)statusCode},\"detail\":\"{message}\",\"errors\":{{}}}}", actual.Content);
            }
        }

        [Theory]
        [InlineData(HttpStatusCode.OK, null)]
        [InlineData(HttpStatusCode.OK, "Hallo World")]
        public void CreateContentResultWithValidationProblemDetails_Message_Errors(HttpStatusCode statusCode, string? message)
        {
            // Arrange
            var errors = new Dictionary<string, string[]>(StringComparer.Ordinal) { { "firstName", new[] { "length" } } };

            // Act
            var actual = ResultFactory.CreateContentResultWithValidationProblemDetails(statusCode, errors, message);

            // Assert
            Assert.NotNull(actual);
            Assert.Equal((int)statusCode, actual.StatusCode);
            if (message != null)
            {
                Assert.NotNull(actual.Content);
                Assert.Equal(MediaTypeNames.Application.Json, actual.ContentType);
                Assert.Equal($"{{\"title\":\"One or more validation errors occurred.\",\"status\":{(int)statusCode},\"detail\":\"{message}\",\"errors\":{{\"firstName\":[\"length\"]}}}}", actual.Content);
            }
        }

        [Theory]
        [InlineData(HttpStatusCode.OK, null, MediaTypeNames.Application.Json)]
        [InlineData(HttpStatusCode.OK, "Hallo World", MediaTypeNames.Application.Json)]
        [InlineData(HttpStatusCode.OK, "Hallo World", MediaTypeNames.Text.Html)]
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
        [InlineData(HttpStatusCode.OK, null, MediaTypeNames.Application.Json)]
        [InlineData(HttpStatusCode.OK, "Hallo World", MediaTypeNames.Application.Json)]
        [InlineData(HttpStatusCode.OK, "Hallo World", MediaTypeNames.Text.Html)]
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

        [Theory]
        [InlineData("Hallo World", "dummy.txt")]
        public void CreateFileContentResult(string data, string fileName)
        {
            // Arrange
            var bytes = Encoding.UTF8.GetBytes(data);

            // Act
            var actual = ResultFactory.CreateFileContentResult(bytes, fileName);

            // Assert
            Assert.NotNull(actual);
            Assert.Equal(fileName, actual.FileDownloadName);

            var fileContentResult = actual as FileContentResult;
            Assert.NotNull(fileContentResult);
            Assert.Equal(bytes.Length, fileContentResult.FileContents.Length);
            Assert.Equal(data, Encoding.UTF8.GetString(fileContentResult.FileContents));
        }
    }
}