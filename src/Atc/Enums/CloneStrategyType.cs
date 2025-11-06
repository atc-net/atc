// ReSharper disable once CheckNamespace
namespace Atc;

/// <summary>
/// Defines different strategies for cloning objects.
/// </summary>
public enum CloneStrategyType
{
    /// <summary>
    /// No cloning strategy specified.
    /// </summary>
    None,

    /// <summary>
    /// Uses JSON serialization and deserialization to create a deep copy of an object.
    /// </summary>
    Json,
}