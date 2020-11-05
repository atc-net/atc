using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using Microsoft.AspNetCore.Mvc;

// ReSharper disable once CheckNamespace
namespace Atc.Rest.FluentAssertions
{
    public class OkResultAssertions : ReferenceTypeAssertions<OkObjectResult, OkResultAssertions>
    {
        private readonly OkObjectResult subject;

        public OkResultAssertions(OkObjectResult subject)
        {
            this.subject = subject;
        }

        protected override string Identifier => "OK result";

        public AndWhichConstraint<OkResultAssertions, OkObjectResult> WithContent<T>(T expectedContent, string because = "", params object[] becauseArgs)
        {
            using (new AssertionScope(Identifier))
            {
                subject.Value
                    .Should()
                    .BeOfType<T>()
                    .And
                    .Subject
                    .Should()
                    .BeEquivalentTo(expectedContent, because, becauseArgs);
            }

            return new AndWhichConstraint<OkResultAssertions, OkObjectResult>(this, subject);
        }
    }
}