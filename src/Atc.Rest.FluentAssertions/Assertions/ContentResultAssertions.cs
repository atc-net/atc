using System.Text.Json;
using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using Microsoft.AspNetCore.Mvc;

// ReSharper disable ConstantConditionalAccessQualifier
// ReSharper disable once CheckNamespace
namespace Atc.Rest.FluentAssertions
{
    public abstract class ContentResultAssertions<TAssertions> : ReferenceTypeAssertions<ContentResult, ContentResultAssertions<TAssertions>>
    {
        protected ContentResultAssertions(ContentResult subject) : base(subject) { }

        public AndWhichConstraint<TAssertions, ContentResult> WithContent<T>(T expectedContent, string because = "", params object[] becauseArgs)
        {
            using (new AssertionScope(Identifier))
            {
                Subject.ContentType.Should().Be("application/json");
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
                return JsonSerializer.Deserialize<T>(Subject.Content);
            }
            catch (JsonException)
            {
                return Subject.Content.As<T>();
            }
        }
    }
}