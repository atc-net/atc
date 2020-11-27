using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;

// ReSharper disable once CheckNamespace
namespace Microsoft.OpenApi.Models
{
    public static class OpenApiMediaTypeExtensions
    {
        public static OpenApiSchema? GetSchema(this IDictionary<string, OpenApiMediaType> content, string contentType = MediaTypeNames.Application.Json)
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