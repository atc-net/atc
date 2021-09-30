using System.Net;
using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

// ReSharper disable CheckNamespace
namespace Atc.Rest.FluentAssertions
{
    public class ResultAssertions : ReferenceTypeAssertions<ActionResult, ResultAssertions>
    {
        public ResultAssertions(ActionResult subject)
            : base(subject)
        {
        }

        protected override string Identifier => "result";

        public ContentResultAssertions BeContentResult(string because = "", params object[] becauseArgs)
        {
            var contentResult = Subject.Should().BeOfType<ContentResult>(because, becauseArgs).Subject;
            return new ContentResultAssertions(contentResult);
        }

        public OkResultAssertions BeOkResult(string because = "", params object[] becauseArgs)
        {
            AssertIsResultTypeWithStatusCode<OkObjectResult>(HttpStatusCode.OK, because, becauseArgs);
            var okSubject = (OkObjectResult)Subject;
            return new OkResultAssertions(okSubject);
        }

        public CreatedResultAssertions BeCreatedResult(string because = "", params object[] becauseArgs)
        {
            AssertIsResultTypeWithStatusCode<ContentResult>(HttpStatusCode.Created, because, becauseArgs);
            var created = (ContentResult)Subject;
            return new CreatedResultAssertions(created);
        }

        public AcceptedResultAssertions BeAcceptedResult(string because = "", params object[] becauseArgs)
        {
            AssertIsResultTypeWithStatusCode<ContentResult>(HttpStatusCode.Accepted, because, becauseArgs);
            var accepted = (ContentResult)Subject;
            return new AcceptedResultAssertions(accepted);
        }

        public NoContentResultAssertions BeNoContentResult(string because = "", params object[] becauseArgs)
        {
            AssertIsResultTypeWithStatusCode<ContentResult>(HttpStatusCode.NoContent, because, becauseArgs);
            var noContent = (ContentResult)Subject;
            return new NoContentResultAssertions(noContent);
        }

        public BadRequestResultAssertions BeBadRequestResult(string because = "", params object[] becauseArgs)
        {
            AssertIsResultTypeWithStatusCode<ContentResult>(HttpStatusCode.BadRequest, because, becauseArgs);
            var badRequest = (ContentResult)Subject;
            return new BadRequestResultAssertions(badRequest);
        }

        public NotFoundResultAssertions BeNotFoundResult(string because = "", params object[] becauseArgs)
        {
            AssertIsResultTypeWithStatusCode<ContentResult>(HttpStatusCode.NotFound, because, becauseArgs);
            var notFound = (ContentResult)Subject;
            return new NotFoundResultAssertions(notFound);
        }

        public ConflictResultAssertions BeConflictResult(string because = "", params object[] becauseArgs)
        {
            AssertIsResultTypeWithStatusCode<ContentResult>(HttpStatusCode.Conflict, because, becauseArgs);
            var conflict = (ContentResult)Subject;
            return new ConflictResultAssertions(conflict);
        }

        private void AssertIsResultTypeWithStatusCode<T>(HttpStatusCode expectedStatusCode, string because, object[] becauseArgs)
            where T : class, IStatusCodeActionResult
        {
            Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .Given(() => Subject as T)
                .ForCondition(x => !(x is null))
                .FailWith("Expected result to be of type {0}{reason}, but found {1}.", _ => typeof(T), x => Subject.GetType())
                .Then
                .Given(x => x?.StatusCode)
                .ForCondition(x => x == (int)expectedStatusCode)
                .FailWith("Expected status code from result to be {0}{reason}, but found {1}.", _ => (int)expectedStatusCode, x => x);
        }
    }
}