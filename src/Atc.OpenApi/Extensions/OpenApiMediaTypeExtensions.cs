using System;
using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Microsoft.OpenApi.Models
{
    public static class OpenApiMediaTypeExtensions
    {
        public static OpenApiSchema? GetSchema(this IDictionary<string, OpenApiMediaType> content, string contentType = "application/json")
        {
            if (content == null)
            {
                throw new ArgumentNullException(nameof(content));
            }

            var (key, value) = content.FirstOrDefault(x => x.Key == contentType);
            return key == null
                ? null
                : value.Schema;
        }
    }
}