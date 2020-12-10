using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
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
            where T : notnull
        {
            var expectedType = WithContentOfType<T>();
            using (new AssertionScope($"content of {Identifier}"))
            {
                expectedType.And.BeEquivalentTo(expectedContent, because, becauseArgs);
                return CreateAndWhichConstraint();
            }
        }

        public AndWhichConstraint<ObjectAssertions, T> WithContentOfType<T>(string because = "", params object[] becauseArgs)
            where T : notnull
        {
            var expectedType = typeof(T);

            Execute.Assertion
                .ForCondition(Subject.Content != null)
                .BecauseOf(because, becauseArgs)
                .WithDefaultIdentifier($"type of content in {Identifier}")
                .FailWith("Expected {context} to be {0}{reason}, but found <null>.", expectedType);

            Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .WithDefaultIdentifier($"content type of {Identifier}")
                .Given(() => Subject.ContentType)
                .ForCondition(contentType => contentType.Equals(MediaTypeNames.Application.Json, StringComparison.Ordinal))
                .FailWith("Expected {context} to be {0}{reason}, but found {1}.", _ => MediaTypeNames.Application.Json, x => x);

            var parseSuccess = TryContentValueAs<T>(out var content);

            Execute.Assertion
                .ForCondition(parseSuccess)
                .BecauseOf(because, becauseArgs)
                .WithDefaultIdentifier($"type of content in {Identifier}")
                .FailWith("Expected {context} to be {0}{reason}, but found {1}.", expectedType, Subject.Content);

            return new AndWhichConstraint<ObjectAssertions, T>(new ObjectAssertions(content), content!);
        }

        protected abstract AndWhichConstraint<TAssertions, ContentResult> CreateAndWhichConstraint();

        [SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "By design.")]
        protected bool TryContentValueAs<T>([NotNullWhen(true)] out T? content)
            where T : notnull
        {
            content = default!;

            if (Subject.Content is null)
            {
                return false;
            }

            var type = typeof(T);

            if (type.IsPrimitive)
            {
                try
                {
                    var contentAsString = JsonSerializer.Deserialize<string>(Subject.Content, jsonSerializerOptions);
                    if (Convert.ChangeType(contentAsString, type, CultureInfo.InvariantCulture) is T convertedContent)
                    {
                        content = convertedContent;
                        return true;
                    }
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                try
                {
                    content = JsonSerializer.Deserialize<T>(Subject.Content, jsonSerializerOptions)!;
                    return true;
                }
                catch
                {
                    return false;
                }
            }

            return false;
        }
    }
}