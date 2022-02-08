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
    [LocalizedDescription("BooleanOperatorTypeAnd", typeof(EnumResources))]
    AND,

    /// <summary>
    /// OR.
    /// </summary>
    [LocalizedDescription("BooleanOperatorTypeOr", typeof(EnumResources))]
    OR,

    /// <summary>
    /// NOT.
    /// </summary>
    [LocalizedDescription("BooleanOperatorTypeNot", typeof(EnumResources))]
    NOT,

    /// <summary>
    /// NEAR.
    /// </summary>
    [LocalizedDescription("BooleanOperatorTypeNear", typeof(EnumResources))]
    NEAR,
}