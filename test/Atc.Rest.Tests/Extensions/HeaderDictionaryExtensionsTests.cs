using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using Xunit;

namespace Atc.Rest.Tests.Extensions
{
    public class HeaderDictionaryExtensionsTests
    {
        [Fact]
        public void GetOrAddCorrelationId()
        {
            // Arrange
            var data = new HeaderDictionary
            {
                new KeyValuePair<string, StringValues>(
                    "x-correlation-id",
                    new StringValues(Guid.NewGuid().ToString())),
            };

            // Act
            var actual = data.GetOrAddCorrelationId();

            // Assert
            Assert.NotNull(actual);
            Assert.True(Guid.TryParse(actual, out _));
        }

        [Fact]
        public void AddCorrelationId()
        {
            // Arrange
            var data = new HeaderDictionary();
            var correlationId = Guid.NewGuid().ToString();

            // Act
            var actual = data.AddCorrelationId(correlationId);

            // Assert
            Assert.NotNull(actual);
            Assert.True(Guid.TryParse(actual, out _));
        }

        [Fact]
        public void GetOrAddRequestId()
        {
            // Arrange
            var data = new HeaderDictionary
            {
                new KeyValuePair<string, StringValues>(
                    "x-request-id",
                    new StringValues(Guid.NewGuid().ToString())),
            };

            // Act
            var actual = data.GetOrAddRequestId();

            // Assert
            Assert.NotNull(actual);
            Assert.True(Guid.TryParse(actual, out _));
        }

        [Fact]
        public void GetCallingOnBehalfOfIdentity()
        {
            // Arrange
            var data = new HeaderDictionary
            {
                new KeyValuePair<string, StringValues>(
                    "x-on-behalf-of",
                    new StringValues(Guid.NewGuid().ToString())),
            };

            // Act
            var actual = data.GetCallingOnBehalfOfIdentity();

            // Assert
            Assert.NotNull(actual);
            Assert.True(Guid.TryParse(actual, out _));
        }
    }
}