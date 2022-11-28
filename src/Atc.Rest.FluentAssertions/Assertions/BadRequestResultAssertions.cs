// ReSharper disable ConstantConditionalAccessQualifier
// ReSharper disable once CheckNamespace
namespace Atc.Rest.FluentAssertions;

public class BadRequestResultAssertions : ErrorContentResultAssertions<BadRequestResultAssertions>
{
    public BadRequestResultAssertions(ContentResult subject)
        : base(subject)
    {
    }

    protected override string Identifier { get; } = "bad request result";

    protected override AndWhichConstraint<BadRequestResultAssertions, ContentResult> CreateAndWhichConstraint()
        => new(this, Subject);
}