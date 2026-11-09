// ReSharper disable once CheckNamespace
namespace Atc.CodeAnalysis.CSharp;

/// <summary>
/// Extension methods for <see cref="ImmutableArray{T}"/>.
/// </summary>
public static class ImmutableArrayExtensions
{
    /// <summary>
    /// Wraps the array in an <see cref="EquatableArray{T}"/> without copying it, so a model holding it compares by value
    /// in an incremental source generator pipeline. A default (uninitialized) array becomes empty.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="source">The array to wrap.</param>
    /// <returns>An <see cref="EquatableArray{T}"/> over the same elements.</returns>
    public static EquatableArray<T> ToEquatableArray<T>(
        this ImmutableArray<T> source)
        where T : IEquatable<T>
        => new(source);
}