// ReSharper disable once CheckNamespace
namespace Atc.CodeAnalysis.CSharp;

/// <summary>
/// Extension methods for <see cref="IEnumerable{T}"/>.
/// </summary>
public static class EnumerableExtensions
{
    /// <summary>
    /// Copies the elements into an <see cref="EquatableArray{T}"/>, so a model holding them compares by value
    /// in an incremental source generator pipeline.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="source">The elements to copy.</param>
    /// <returns>An <see cref="EquatableArray{T}"/> with the elements in the same order.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source"/> is null.</exception>
    public static EquatableArray<T> ToEquatableArray<T>(
        this IEnumerable<T> source)
        where T : IEquatable<T>
    {
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        return new EquatableArray<T>(source.ToImmutableArray());
    }
}