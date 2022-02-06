// ReSharper disable once CheckNamespace
// ReSharper disable InconsistentNaming
namespace Atc;

/// <summary>
/// Enumeration: BooleanOperatorType.
/// </summary>
public enum BooleanOperatorType
{
    /// <summary>
    /// Default None, and it's not a BooleanOperator.
    /// </summary>
    [LocalizedDescription(null, typeof(EnumResources))]
    None,

    /// <summary>
    /// AND.
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "AND", Justification = "OK.")]
    [LocalizedDescription("BooleanOperatorTypeAnd", typeof(EnumResources))]
    AND,

    /// <summary>
    /// OR.
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "OR", Justification = "OK.")]
    [LocalizedDescription("BooleanOperatorTypeOr", typeof(EnumResources))]
    OR,

    /// <summary>
    /// NOT.
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "NOT", Justification = "OK.")]
    [LocalizedDescription("BooleanOperatorTypeNot", typeof(EnumResources))]
    NOT,

    /// <summary>
    /// NEAR.
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "NEAR", Justification = "OK.")]
    [LocalizedDescription("BooleanOperatorTypeNear", typeof(EnumResources))]
    NEAR,
}