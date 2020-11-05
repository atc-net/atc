using System.Text.Json;
using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using Microsoft.AspNetCore.Mvc;

// ReSharper disable ConstantConditionalAccessQualifier
// ReSharper disable once CheckNamespace
namespace Atc.Rest.FluentAssertions
{
    public class NotFoundResultAssertions : ReferenceTypeAssertions<ContentResult, NotFoundResultAssertions>
    {
        private readonly ContentResult subject;

        public NotFoundResultAssertions(ContentResult subject)
        {
            this.subject = subject;
        }

        protected override string Identifier => "not found result";

        public AndWhichConstraint<NotFoundResultAssertions, ContentResult> WithErrorMessage(string expectedErrorMessage, string because = "", params object[] becauseArgs)
        {
            using (new AssertionScope("error message of \"not found result\""))
            {
                var problemDetail = GetContentValueAs<ProblemDetails>()?.Detail ?? GetContentValueAs<string>();
                problemDetail.Should().Be(expectedErrorMessage, because, becauseArgs);
            }

            return new AndWhichConstraint<NotFoundResultAssertions, ContentResult>(this, subject);
        }

        public AndWhichConstraint<NotFoundResultAssertions, ContentResult> WithContent<T>(T expectedContent, string because = "", params object[] becauseArgs)
        {
            using (new AssertionScope(Identifier))
            {
                subject.ContentType.Should().Be("application/json");
                var content = GetContentValueAs<T>();
                content.Should().BeEquivalentTo(expectedContent, because, becauseArgs);
            }

            return new AndWhichConstraint<NotFoundResultAssertions, ContentResult>(this, subject);
        }

        private T GetContentValueAs<T>()
        {
            try
            {
                return JsonSerializer.Deserialize<T>(subject.Content);
            }
            catch (JsonException)
            {
                return subject.Content.As<T>();
            }
        }
    }
}