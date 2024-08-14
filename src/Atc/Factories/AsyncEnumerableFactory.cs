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
    public static async IAsyncEnumerable<T> Empty<T>()
    {
        await Task.CompletedTask;
        yield break;
    }
}