// ReSharper disable ConstantConditionalAccessQualifier
// ReSharper disable once CheckNamespace
namespace Atc.Rest.FluentAssertions;

public class NoContentResultAssertions : ContentResultAssertionsBase<NoContentResultAssertions>
{
    public NoContentResultAssertions(ContentResult subject)
        : base(subject)
    {
    }

    protected override string Identifier { get; } = "no content result";

    protected override AndWhichConstraint<NoContentResultAssertions, ContentResult> CreateAndWhichConstraint()
        => new(this, Subject);
}