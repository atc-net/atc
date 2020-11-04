using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Atc.Rest.FluentAssertions
{
    public class ResultAssertions : ReferenceTypeAssertions<ActionResult, ResultAssertions>
    {
        private readonly ActionResult subject;

        public ResultAssertions(ActionResult subject)
        {
            this.subject = subject;
        }

        protected override string Identifier => "result";

        public OkResultAssertions BeOkResult(string because = "", params object[] becauseArgs)
        {
            AssertIsResultTypeWithStatusCode<OkObjectResult>(200, because, becauseArgs);
            var okSubject = (OkObjectResult)subject;
            return new OkResultAssertions(okSubject);
        }

        public NotFoundResultAssertions BeNotFoundResult(string because = "", params object[] becauseArgs)
        {
            AssertIsResultTypeWithStatusCode<ContentResult>(404, because, becauseArgs);
            var notFoundSubject = (ContentResult)subject;
            return new NotFoundResultAssertions(notFoundSubject);
        }

        private void AssertIsResultTypeWithStatusCode<T>(int expectedStatusCode, string because, object[] becauseArgs) where T : class, IStatusCodeActionResult
        {
            Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .Given(() => subject as T)
                .ForCondition(x => !(x is null))
                .FailWith("Expected {context:result} to be of type {0}{reason}, but found {1}.", _ => typeof(T), x => subject.GetType())
                .Then
                .Given(x => x?.StatusCode)
                .ForCondition(x => x == expectedStatusCode)
                .FailWith("Expected status code from {context:result} to be {0}{reason}, but found {1}.", _ => expectedStatusCode, x => x);
        }
    }
}