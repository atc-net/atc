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
    /// <returns>An <see cref="IAsyncEnumerable{T}"/> containing the single item.</returns>
    public static async IAsyncEnumerable<T> FromSingleItem<T>(T item)
    {
        yield return item;
        await Task.CompletedTask;
    }
}