// ReSharper disable once CheckNamespace
namespace Atc;

/// <summary>
/// Ignore Display Attribute.
/// </summary>
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Enum | AttributeTargets.Interface | AttributeTargets.Delegate)]
public sealed class IgnoreDisplayAttribute : Attribute
{
}