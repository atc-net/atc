// ReSharper disable once CheckNamespace
// ReSharper disable InconsistentNaming
namespace Atc;

/// <summary>
/// Represents boolean operators commonly used in search queries and logical expressions.
/// </summary>
public enum BooleanOperatorType
{
    /// <summary>
    /// No boolean operator specified.
    /// </summary>
    [LocalizedDescription(null, typeof(EnumResources))]
    None,

    /// <summary>
    /// Logical AND operator requiring all conditions to be true.
    /// </summary>
    [LocalizedDescription("BooleanOperatorTypeAnd", typeof(EnumResources))]
    AND,

    /// <summary>
    /// Logical OR operator requiring at least one condition to be true.
    /// </summary>
    [LocalizedDescription("BooleanOperatorTypeOr", typeof(EnumResources))]
    OR,

    /// <summary>
    /// Logical NOT operator for negating a condition.
    /// </summary>
    [LocalizedDescription("BooleanOperatorTypeNot", typeof(EnumResources))]
    NOT,

    /// <summary>
    /// Proximity operator for searching terms near each other.
    /// </summary>
    [LocalizedDescription("BooleanOperatorTypeNear", typeof(EnumResources))]
    NEAR,
}