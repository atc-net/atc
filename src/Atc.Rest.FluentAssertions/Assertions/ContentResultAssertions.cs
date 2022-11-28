// ReSharper disable ConstantConditionalAccessQualifier
// ReSharper disable once CheckNamespace
namespace Atc.Rest.FluentAssertions;

public class ContentResultAssertions : ContentResultAssertionsBase<ContentResultAssertions>
{
    public ContentResultAssertions(ContentResult subject)
        : base(subject)
    {
    }

    protected override string Identifier { get; } = "content result";

    public AndConstraint<ContentResultAssertions> WithStatusCode(HttpStatusCode expectedStatusCode, string because = "", params object[] becauseArgs)
        => WithStatusCode((int)expectedStatusCode, because, becauseArgs);

    public AndConstraint<ContentResultAssertions> WithStatusCode(int expectedStatusCode, string because = "", params object[] becauseArgs)
    {
        Execute.Assertion
            .BecauseOf(because, becauseArgs)
            .Given(() => Subject.StatusCode)
            .ForCondition(x => x == expectedStatusCode)
            .FailWith("Expected status code to be {0}{reason}, but found {1}.", expectedStatusCode, Subject.StatusCode);

        return new AndConstraint<ContentResultAssertions>(this);
    }

    protected override AndWhichConstraint<ContentResultAssertions, ContentResult> CreateAndWhichConstraint()
        => new(this, Subject);
}