// ReSharper disable once CheckNamespace
namespace System.Collections.Generic;

/// <summary>
/// Provides extension methods for asynchronous enumeration of collections.
/// </summary>
public static class EnumerableExtensions
{
    /// <summary>
    /// Converts an <see cref="IEnumerable{T}"/> to an <see cref="IAsyncEnumerable{T}"/>.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the source sequence.</typeparam>
    /// <param name="source">The source sequence to convert.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for the asynchronous operation to complete.</param>
    /// <returns>An <see cref="IAsyncEnumerable{T}"/> that contains the elements from the input sequence.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the source sequence is null.</exception>
    [SuppressMessage("Design", "MA0050:Validate arguments correctly in iterator methods", Justification = "OK - False/Positive")]
    public static async IAsyncEnumerable<T> ToAsyncEnumerable<T>(
        this IEnumerable<T> source,
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        await foreach (var item in IterateAsync(source, cancellationToken).ConfigureAwait(false))
        {
            yield return item;
        }
    }

    private static async IAsyncEnumerable<T> IterateAsync<T>(
        IEnumerable<T> source,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        foreach (var item in source)
        {
            cancellationToken.ThrowIfCancellationRequested();
            yield return item;
            await Task.Yield();
        }
    }
}