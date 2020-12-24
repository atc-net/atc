using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using Microsoft.AspNetCore.Mvc;

// ReSharper disable once CheckNamespace
namespace Atc.Rest.FluentAssertions
{
    public class OkResultAssertions : ReferenceTypeAssertions<OkObjectResult, OkResultAssertions>
    {
        public OkResultAssertions(OkObjectResult subject)
            : base(subject)
        {
        }

        protected override string Identifier => "OK result";

        public AndWhichConstraint<ObjectAssertions, T> WithContentOfType<T>(string because = "", params object[] becauseArgs)
            => Subject.Value.Should().BeOfType<T>(because, becauseArgs);

        public AndWhichConstraint<OkResultAssertions, OkObjectResult> WithContent<T>(T expectedContent, string because = "", params object[] becauseArgs)
        {
            using (new AssertionScope($"content of {Identifier}"))
            {
                WithContentOfType<T>(because, becauseArgs)
                    .And
                    .Subject
                    .Should()
                    .BeEquivalentTo(expectedContent, because, becauseArgs);

                return new AndWhichConstraint<OkResultAssertions, OkObjectResult>(this, Subject);
            }
        }
    }
}