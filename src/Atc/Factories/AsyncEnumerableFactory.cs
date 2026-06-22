namespace Atc.Factories;

/// <summary>
/// Provides factory methods for creating instances of <see cref="IAsyncEnumerable{T}"/>.
/// </summary>
public static class AsyncEnumerableFactory
{
    /// <summary>
    /// Returns an empty <see cref="IAsyncEnumerable{T}"/>.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the sequence.</typeparam>
    /// <returns>An empty <see cref="IAsyncEnumerable{T}"/>.</returns>
    public static IAsyncEnumerable<T> Empty<T>()
        => EmptyAsyncEnumerable<T>.Instance;

    private static class EmptyAsyncEnumerable<T>
    {
        internal static readonly IAsyncEnumerable<T> Instance = CreateEmpty();

        private static async IAsyncEnumerable<T> CreateEmpty()
        {
            await Task.CompletedTask.ConfigureAwait(false);
            yield break;
        }
    }

    /// <summary>
    /// Converts a single item into an <see cref="IAsyncEnumerable{T}"/>.
    /// </summary>
    /// <typeparam name="T">The type of the item.</typeparam>
    /// <param name="item">The item to convert.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous iteration.</param>
    /// <returns>An <see cref="IAsyncEnumerable{T}"/> containing the single item.</returns>
    public static async IAsyncEnumerable<T> FromSingleItem<T>(
        T item,
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        yield return item;
        await Task.CompletedTask;
    }

    /// <summary>
    /// Wraps an array of items as an <see cref="IAsyncEnumerable{T}"/>, yielding each item in order.
    /// </summary>
    /// <typeparam name="T">The type of the elements.</typeparam>
    /// <param name="items">The items to yield.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous iteration; checked before each item is yielded.</param>
    /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields each element of <paramref name="items"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="items"/> is <see langword="null"/>.</exception>
    public static IAsyncEnumerable<T> FromItems<T>(
        T[] items,
        CancellationToken cancellationToken = default)
    {
        if (items is null)
        {
            throw new ArgumentNullException(nameof(items));
        }

        return FromItemsCore(items, cancellationToken);
    }

    /// <summary>
    /// Wraps an <see cref="IEnumerable{T}"/> as an <see cref="IAsyncEnumerable{T}"/>, yielding each element in order.
    /// </summary>
    /// <typeparam name="T">The type of the elements.</typeparam>
    /// <param name="source">The synchronous sequence to wrap.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous iteration; checked before each element is yielded.</param>
    /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields each element of <paramref name="source"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source"/> is <see langword="null"/>.</exception>
    public static IAsyncEnumerable<T> FromEnumerable<T>(
        IEnumerable<T> source,
        CancellationToken cancellationToken = default)
    {
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        return FromEnumerableCore(source, cancellationToken);
    }

    /// <summary>
    /// Creates an <see cref="IAsyncEnumerable{T}"/> that awaits the specified task and yields its result as a single element.
    /// </summary>
    /// <typeparam name="T">The type of the task result.</typeparam>
    /// <param name="task">The task whose result will be yielded.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation before the task is awaited.</param>
    /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields the single result of <paramref name="task"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="task"/> is <see langword="null"/>.</exception>
    public static IAsyncEnumerable<T> FromTask<T>(
        Task<T> task,
        CancellationToken cancellationToken = default)
    {
        if (task is null)
        {
            throw new ArgumentNullException(nameof(task));
        }

        return FromTaskCore(task, cancellationToken);
    }

    private static async IAsyncEnumerable<T> FromItemsCore<T>(
        T[] items,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        foreach (var item in items)
        {
            cancellationToken.ThrowIfCancellationRequested();
            yield return item;
        }

        await Task.CompletedTask;
    }

    private static async IAsyncEnumerable<T> FromEnumerableCore<T>(
        IEnumerable<T> source,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        foreach (var item in source)
        {
            cancellationToken.ThrowIfCancellationRequested();
            yield return item;
        }

        await Task.CompletedTask;
    }

    private static async IAsyncEnumerable<T> FromTaskCore<T>(
        Task<T> task,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        yield return await task.ConfigureAwait(false);
    }
}