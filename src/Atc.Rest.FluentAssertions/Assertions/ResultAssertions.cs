// ReSharper disable CheckNamespace
namespace Atc.Rest.FluentAssertions;

/// <summary>
/// Provides FluentAssertions-style assertions for <see cref="ActionResult"/> objects.
/// </summary>
public class ResultAssertions : ReferenceTypeAssertions<ActionResult, ResultAssertions>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ResultAssertions"/> class.
    /// </summary>
    /// <param name="subject">The <see cref="ActionResult"/> to assert against.</param>
    public ResultAssertions(ActionResult subject)
        : base(subject)
    {
    }

    /// <inheritdoc />
    protected override string Identifier => "result";

    /// <summary>
    /// Asserts that the action result is a <see cref="ContentResult"/>.
    /// </summary>
    /// <param name="because">Optional explanation of why the assertion is needed.</param>
    /// <param name="becauseArgs">Optional formatting arguments for the <paramref name="because"/> parameter.</param>
    /// <returns>A <see cref="ContentResultAssertions"/> instance for further assertions.</returns>
    public ContentResultAssertions BeContentResult(string because = "", params object[] becauseArgs)
    {
        var contentResult = Subject.Should().BeOfType<ContentResult>(because, becauseArgs).Subject;
        return new ContentResultAssertions(contentResult);
    }

    /// <summary>
    /// Asserts that the action result is an <see cref="OkObjectResult"/> with HTTP status code 200 (OK).
    /// </summary>
    /// <param name="because">Optional explanation of why the assertion is needed.</param>
    /// <param name="becauseArgs">Optional formatting arguments for the <paramref name="because"/> parameter.</param>
    /// <returns>An <see cref="OkResultAssertions"/> instance for further assertions.</returns>
    public OkResultAssertions BeOkResult(string because = "", params object[] becauseArgs)
    {
        AssertIsResultTypeWithStatusCode<OkObjectResult>(HttpStatusCode.OK, because, becauseArgs);
        var okSubject = (OkObjectResult)Subject;
        return new OkResultAssertions(okSubject);
    }

    /// <summary>
    /// Asserts that the action result is a <see cref="ContentResult"/> with HTTP status code 201 (Created).
    /// </summary>
    /// <param name="because">Optional explanation of why the assertion is needed.</param>
    /// <param name="becauseArgs">Optional formatting arguments for the <paramref name="because"/> parameter.</param>
    /// <returns>A <see cref="CreatedResultAssertions"/> instance for further assertions.</returns>
    public CreatedResultAssertions BeCreatedResult(string because = "", params object[] becauseArgs)
    {
        AssertIsResultTypeWithStatusCode<ContentResult>(HttpStatusCode.Created, because, becauseArgs);
        var created = (ContentResult)Subject;
        return new CreatedResultAssertions(created);
    }

    /// <summary>
    /// Asserts that the action result is a <see cref="ContentResult"/> with HTTP status code 202 (Accepted).
    /// </summary>
    /// <param name="because">Optional explanation of why the assertion is needed.</param>
    /// <param name="becauseArgs">Optional formatting arguments for the <paramref name="because"/> parameter.</param>
    /// <returns>An <see cref="AcceptedResultAssertions"/> instance for further assertions.</returns>
    public AcceptedResultAssertions BeAcceptedResult(string because = "", params object[] becauseArgs)
    {
        AssertIsResultTypeWithStatusCode<ContentResult>(HttpStatusCode.Accepted, because, becauseArgs);
        var accepted = (ContentResult)Subject;
        return new AcceptedResultAssertions(accepted);
    }

    /// <summary>
    /// Asserts that the action result is a <see cref="ContentResult"/> with HTTP status code 204 (No Content).
    /// </summary>
    /// <param name="because">Optional explanation of why the assertion is needed.</param>
    /// <param name="becauseArgs">Optional formatting arguments for the <paramref name="because"/> parameter.</param>
    /// <returns>A <see cref="NoContentResultAssertions"/> instance for further assertions.</returns>
    public NoContentResultAssertions BeNoContentResult(string because = "", params object[] becauseArgs)
    {
        AssertIsResultTypeWithStatusCode<ContentResult>(HttpStatusCode.NoContent, because, becauseArgs);
        var noContent = (ContentResult)Subject;
        return new NoContentResultAssertions(noContent);
    }

    /// <summary>
    /// Asserts that the action result is a <see cref="ContentResult"/> with HTTP status code 400 (Bad Request).
    /// </summary>
    /// <param name="because">Optional explanation of why the assertion is needed.</param>
    /// <param name="becauseArgs">Optional formatting arguments for the <paramref name="because"/> parameter.</param>
    /// <returns>A <see cref="BadRequestResultAssertions"/> instance for further assertions.</returns>
    public BadRequestResultAssertions BeBadRequestResult(string because = "", params object[] becauseArgs)
    {
        AssertIsResultTypeWithStatusCode<ContentResult>(HttpStatusCode.BadRequest, because, becauseArgs);
        var badRequest = (ContentResult)Subject;
        return new BadRequestResultAssertions(badRequest);
    }

    /// <summary>
    /// Asserts that the action result is a <see cref="ContentResult"/> with HTTP status code 403 (Forbidden).
    /// </summary>
    /// <param name="because">Optional explanation of why the assertion is needed.</param>
    /// <param name="becauseArgs">Optional formatting arguments for the <paramref name="because"/> parameter.</param>
    /// <returns>A <see cref="ForbiddenResultAssertions"/> instance for further assertions.</returns>
    public ForbiddenResultAssertions BeForbiddenResult(string because = "", params object[] becauseArgs)
    {
        AssertIsResultTypeWithStatusCode<ContentResult>(HttpStatusCode.Forbidden, because, becauseArgs);
        var forbidden = (ContentResult)Subject;
        return new ForbiddenResultAssertions(forbidden);
    }

    /// <summary>
    /// Asserts that the action result is a <see cref="ContentResult"/> with HTTP status code 404 (Not Found).
    /// </summary>
    /// <param name="because">Optional explanation of why the assertion is needed.</param>
    /// <param name="becauseArgs">Optional formatting arguments for the <paramref name="because"/> parameter.</param>
    /// <returns>A <see cref="NotFoundResultAssertions"/> instance for further assertions.</returns>
    public NotFoundResultAssertions BeNotFoundResult(string because = "", params object[] becauseArgs)
    {
        AssertIsResultTypeWithStatusCode<ContentResult>(HttpStatusCode.NotFound, because, becauseArgs);
        var notFound = (ContentResult)Subject;
        return new NotFoundResultAssertions(notFound);
    }

    /// <summary>
    /// Asserts that the action result is a <see cref="ContentResult"/> with HTTP status code 409 (Conflict).
    /// </summary>
    /// <param name="because">Optional explanation of why the assertion is needed.</param>
    /// <param name="becauseArgs">Optional formatting arguments for the <paramref name="because"/> parameter.</param>
    /// <returns>A <see cref="ConflictResultAssertions"/> instance for further assertions.</returns>
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