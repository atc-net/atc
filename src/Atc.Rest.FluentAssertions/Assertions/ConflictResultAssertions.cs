// ReSharper disable ConstantConditionalAccessQualifier
// ReSharper disable once CheckNamespace
namespace Atc.Rest.FluentAssertions;

public class ConflictResultAssertions : ErrorContentResultAssertions<ConflictResultAssertions>
{
    public ConflictResultAssertions(ContentResult subject)
        : base(subject)
    {
    }

    protected override string Identifier => "conflict result";

    protected override AndWhichConstraint<ConflictResultAssertions, ContentResult> CreateAndWhichConstraint()
        => new AndWhichConstraint<ConflictResultAssertions, ContentResult>(this, Subject);
}