using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using Microsoft.AspNetCore.Mvc;

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

                // TO-DO: Uncomment when issue https://github.com/atc-net/atc/issues/18 is fixed
                //// subject.ContentTypes.Should().OnlyContain(x => x == "application/json", because, becauseArgs);
            }

            return new AndWhichConstraint<OkResultAssertions, OkObjectResult>(this, subject);
        }
    }
}