// ReSharper disable once CheckNamespace
namespace Atc.Rest.FluentAssertions;

public class OkResultAssertions : ReferenceTypeAssertions<OkObjectResult, OkResultAssertions>
{
    public OkResultAssertions(OkObjectResult subject)
        : base(subject)
    {
    }

    protected override string Identifier => "OK result";

    public AndWhichConstraint<ObjectAssertions, T> WithContentOfType<T>(string because = "", params object[] becauseArgs)
    {
        using (var scope = new AssertionScope($"content type of {Identifier}"))
        {
            return Subject.Value.Should().BeAssignableTo<T>(because, becauseArgs);
        }
    }

    public AndWhichConstraint<OkResultAssertions, OkObjectResult> WithContent<T>(T expectedContent, string because = "", params object[] becauseArgs)
    {
        using (var scope = new AssertionScope($"content of {Identifier}"))
        {
            WithContentOfType<T>(because, becauseArgs)
                .And.BeAssignableTo<T>(because, becauseArgs)
                .And.BeEquivalentTo(expectedContent, because, becauseArgs);

            var error = scope.Discard().FirstOrDefault();
            if (error is not null)
            {
                var fixedErrorMessage = error
                    .Replace("Subject.Value", $"content of {Identifier}", StringComparison.InvariantCulture)
                    .Replace("Expected root", $"Expected content of {Identifier}", StringComparison.InvariantCulture);
                Execute.Assertion.FailWith(fixedErrorMessage);
            }
        }

        return new AndWhichConstraint<OkResultAssertions, OkObjectResult>(this, Subject);
    }
}