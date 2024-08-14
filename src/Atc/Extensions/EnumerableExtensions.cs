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

    /// <summary>
    /// Asynchronously counts the elements in a sequence.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the source sequence.</typeparam>
    /// <param name="source">The source sequence to count.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for the asynchronous operation to complete.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the number of elements in the sequence.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the source sequence is null.</exception>
    public static Task<int> CountAsync<T>(
        this IEnumerable<T> source,
        CancellationToken cancellationToken = default)
    {
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        return Task.Run(source.Count, cancellationToken);
    }

    /// <summary>
    /// Asynchronously creates a <see cref="List{T}"/> from an <see cref="IEnumerable{T}"/>.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the source sequence.</typeparam>
    /// <param name="source">The source sequence to convert to a list.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for the asynchronous operation to complete.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a list with the elements from the input sequence.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the source sequence is null.</exception>
    public static Task<List<T>> ToListAsync<T>(
        this IEnumerable<T> source,
        CancellationToken cancellationToken = default)
    {
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        return Task.Run(source.ToList, cancellationToken);
    }

    /// <summary>
    /// Iterates asynchronously over the elements of a source sequence.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the source sequence.</typeparam>
    /// <param name="source">The source sequence to iterate over.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while iterating over the sequence.</param>
    /// <returns>An <see cref="IAsyncEnumerable{T}"/> that contains the elements from the input sequence.</returns>
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