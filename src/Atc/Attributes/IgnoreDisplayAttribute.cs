// ReSharper disable once CheckNamespace
namespace Atc;

/// <summary>
/// Specifies that the decorated member should be excluded from display operations.
/// This attribute can be used to mark properties, fields, enums, interfaces, or delegates that should not be shown in user interfaces or documentation.
/// </summary>
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Enum | AttributeTargets.Interface | AttributeTargets.Delegate)]
public sealed class IgnoreDisplayAttribute : Attribute
{
}