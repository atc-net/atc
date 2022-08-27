// ReSharper disable ConstantConditionalAccessQualifier
// ReSharper disable once CheckNamespace
namespace Atc.Rest.FluentAssertions;

public class ForbiddenResultAssertions : ErrorContentResultAssertions<ForbiddenResultAssertions>
{
    public ForbiddenResultAssertions(ContentResult subject)
        : base(subject)
    {
    }

    protected override string Identifier => "forbidden result";

    protected override AndWhichConstraint<ForbiddenResultAssertions, ContentResult> CreateAndWhichConstraint()
        => new AndWhichConstraint<ForbiddenResultAssertions, ContentResult>(this, Subject);
}
