// ReSharper disable once CheckNamespace
namespace System.Collections.Generic;

/// <summary>
/// Provides extension methods for asynchronous enumeration of collections.
/// </summary>
public static class EnumerableExtensions
{
    /// <summary>
    /// Projects each element of a sequence into a new form and returns the results as an array.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
    /// <typeparam name="TResult">The type of the elements in the result array.</typeparam>
    /// <param name="source">The sequence of elements to transform.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>An array containing the transformed elements from the source sequence.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source"/> or <paramref name="selector"/> is <see langword="null"/>.</exception>
    /// <remarks>This is a convenience method that combines <see cref="Enumerable.Select{TSource, TResult}(IEnumerable{TSource}, Func{TSource, TResult})"/> and <see cref="Enumerable.ToArray{TSource}(IEnumerable{TSource})"/>.</remarks>
    public static TResult[] SelectToArray<TSource, TResult>(
        this IEnumerable<TSource> source,
        Func<TSource, TResult> selector)
    {
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        if (selector is null)
        {
            throw new ArgumentNullException(nameof(selector));
        }

        return source
            .Select(selector)
            .ToArray();
    }

    /// <summary>
    /// Projects each element of a sequence into a new form and returns the results as a <see cref="List{T}"/>.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
    /// <typeparam name="TResult">The type of the elements in the result list.</typeparam>
    /// <param name="source">The sequence of elements to transform.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>A <see cref="List{T}"/> containing the transformed elements from the source sequence.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source"/> or <paramref name="selector"/> is <see langword="null"/>.</exception>
    /// <remarks>This is a convenience method that combines <see cref="Enumerable.Select{TSource, TResult}(IEnumerable{TSource}, Func{TSource, TResult})"/> and <see cref="Enumerable.ToList{TSource}(IEnumerable{TSource})"/>.</remarks>
    public static List<TResult> SelectToList<TSource, TResult>(
        this IEnumerable<TSource> source,
        Func<TSource, TResult> selector)
    {
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        if (selector is null)
        {
            throw new ArgumentNullException(nameof(selector));
        }

        return source
            .Select(selector)
            .ToList();
    }

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
    [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1312:Variable names should begin with lower-case letter", Justification = "False/Positive")]
    public static async Task<int> CountAsync<T>(
        this IEnumerable<T> source,
        CancellationToken cancellationToken = default)
    {
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        var count = 0;
        foreach (var _ in source)
        {
            cancellationToken.ThrowIfCancellationRequested();
            count++;
            await Task.Yield();
        }

        return count;
    }

    /// <summary>
    /// Asynchronously creates a <see cref="List{T}"/> from an <see cref="IEnumerable{T}"/>.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the source sequence.</typeparam>
    /// <param name="source">The source sequence to convert to a list.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for the asynchronous operation to complete.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a list with the elements from the input sequence.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the source sequence is null.</exception>
    public static async Task<List<T>> ToListAsync<T>(
        this IEnumerable<T> source,
        CancellationToken cancellationToken = default)
    {
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        var list = new List<T>();
        foreach (var item in source)
        {
            cancellationToken.ThrowIfCancellationRequested();
            list.Add(item);
            await Task.Yield();
        }

        return list;
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