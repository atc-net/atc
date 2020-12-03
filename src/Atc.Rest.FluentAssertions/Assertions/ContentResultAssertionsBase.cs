using System.Diagnostics.CodeAnalysis;
using System.Net.Mime;
using System.Text.Json;
using System.Text.Json.Serialization;
using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using Microsoft.AspNetCore.Mvc;

// ReSharper disable ConstantConditionalAccessQualifier
// ReSharper disable once CheckNamespace
namespace Atc.Rest.FluentAssertions
{
    public abstract class ContentResultAssertionsBase<TAssertions> : ReferenceTypeAssertions<ContentResult, ContentResultAssertionsBase<TAssertions>>
    {
        [SuppressMessage("Major Code Smell", "S2743:Static fields should not be used in generic types", Justification = "This can safely be shared by all inherited types")]
        private static readonly JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            Converters = { new JsonStringEnumConverter() },
        };

        protected ContentResultAssertionsBase(ContentResult subject) : base(subject) { }

        public AndWhichConstraint<TAssertions, ContentResult> WithContent<T>(T expectedContent, string because = "", params object[] becauseArgs)
        {
            using (new AssertionScope(Identifier))
            {
                Subject.ContentType.Should().Be(MediaTypeNames.Application.Json);
                var content = GetContentValueAs<T>();
                content.Should().BeEquivalentTo(expectedContent, because, becauseArgs);
            }

            return CreateAndWhichConstraint();
        }

        protected abstract AndWhichConstraint<TAssertions, ContentResult> CreateAndWhichConstraint();

        protected T GetContentValueAs<T>()
        {
            try
            {
                return JsonSerializer.Deserialize<T>(Subject.Content, jsonSerializerOptions);
            }
            catch (JsonException)
            {
                return Subject.Content.As<T>();
            }
        }
    }
}