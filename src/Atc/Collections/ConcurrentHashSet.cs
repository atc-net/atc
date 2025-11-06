namespace Atc.Collections;

/// <summary>
/// Provides a thread-safe hash set implementation using reader-writer locks.
/// This collection allows multiple concurrent readers or a single writer at a time.
/// </summary>
/// <typeparam name="T">The type of elements in the hash set.</typeparam>
public class ConcurrentHashSet<T> : IEnumerable<T>, IDisposable
{
    private readonly ReaderWriterLockSlim readerWriterLock = new(LockRecursionPolicy.SupportsRecursion);
    private readonly HashSet<T> hashSet = new();

    /// <summary>
    /// Gets the number of elements contained in the hash set.
    /// This operation acquires a read lock.
    /// </summary>
    public int Count
    {
        get
        {
            readerWriterLock.EnterReadLock();

            try
            {
                return hashSet.Count;
            }
            finally
            {
                if (readerWriterLock.IsReadLockHeld)
                {
                    readerWriterLock.ExitReadLock();
                }
            }
        }
    }

    /// <inheritdoc />
    public IEnumerator<T> GetEnumerator()
    {
        readerWriterLock.EnterWriteLock();

        try
        {
            return hashSet.GetEnumerator();
        }
        finally
        {
            if (readerWriterLock.IsWriteLockHeld)
            {
                readerWriterLock.ExitWriteLock();
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    /// <summary>
    /// Attempts to add an element to the hash set in a thread-safe manner.
    /// This operation acquires a write lock.
    /// </summary>
    /// <param name="item">The element to add to the hash set.</param>
    /// <returns><c>true</c> if the element was added successfully; <c>false</c> if the element already exists.</returns>
    public bool TryAdd(T item)
    {
        readerWriterLock.EnterWriteLock();

        try
        {
            return hashSet.Add(item);
        }
        finally
        {
            if (readerWriterLock.IsWriteLockHeld)
            {
                readerWriterLock.ExitWriteLock();
            }
        }
    }

    /// <summary>
    /// Attempts to remove an element from the hash set in a thread-safe manner.
    /// This operation acquires a write lock.
    /// </summary>
    /// <param name="item">The element to remove from the hash set.</param>
    /// <returns><c>true</c> if the element was removed successfully; <c>false</c> if the element was not found.</returns>
    public bool TryRemove(T item)
    {
        readerWriterLock.EnterWriteLock();

        try
        {
            return hashSet.Remove(item);
        }
        finally
        {
            if (readerWriterLock.IsWriteLockHeld)
            {
                readerWriterLock.ExitWriteLock();
            }
        }
    }

    /// <summary>
    /// Determines whether the hash set contains the specified element.
    /// This operation acquires a read lock.
    /// </summary>
    /// <param name="item">The element to locate in the hash set.</param>
    /// <returns><c>true</c> if the hash set contains the specified element; otherwise, <c>false</c>.</returns>
    public bool Contains(T item)
    {
        readerWriterLock.EnterReadLock();

        try
        {
            return hashSet.Contains(item);
        }
        finally
        {
            if (readerWriterLock.IsReadLockHeld)
            {
                readerWriterLock.ExitReadLock();
            }
        }
    }

    /// <summary>
    /// Removes all elements from the hash set in a thread-safe manner.
    /// This operation acquires a write lock.
    /// </summary>
    public void Clear()
    {
        readerWriterLock.EnterWriteLock();

        try
        {
            hashSet.Clear();
        }
        finally
        {
            if (readerWriterLock.IsWriteLockHeld)
            {
                readerWriterLock.ExitWriteLock();
            }
        }
    }

    /// <summary>
    /// Returns the first element in the hash set that satisfies the specified condition, or a default value if no such element is found.
    /// This operation acquires a read lock.
    /// </summary>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <returns>The first element that satisfies the condition, or the default value for type <typeparamref name="T"/> if no such element is found.</returns>
    public T? FirstOrDefault(Func<T, bool> predicate)
    {
        readerWriterLock.EnterReadLock();

        try
        {
            return hashSet.FirstOrDefault(predicate);
        }
        finally
        {
            if (readerWriterLock.IsReadLockHeld)
            {
                readerWriterLock.ExitReadLock();
            }
        }
    }

    /// <inheritdoc />
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Releases unmanaged and - optionally - managed resources.
    /// </summary>
    /// <param name="disposing"><see langword="true" /> to release both managed and unmanaged resources; <see langword="false" /> to release only unmanaged resources.</param>
    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            readerWriterLock.Dispose();
        }
    }
}