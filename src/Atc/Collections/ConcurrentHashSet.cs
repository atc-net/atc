namespace Atc.Collections;

/// <summary>
/// ConcurrentHashSet.
/// </summary>
/// <typeparam name="T">The generic type.</typeparam>
/// <seealso cref="System.Collections.Generic.IEnumerable{T}" />
/// <seealso cref="System.IDisposable" />
public class ConcurrentHashSet<T> : IEnumerable<T>, IDisposable
{
    private readonly ReaderWriterLockSlim readerWriterLock = new(LockRecursionPolicy.SupportsRecursion);
    private readonly HashSet<T> hashSet = new();

    /// <summary>
    /// Gets the count.
    /// </summary>
    /// <value>
    /// The count.
    /// </value>
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
    /// Tries the add.
    /// </summary>
    /// <param name="item">The item.</param>
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
    /// Tries the remove.
    /// </summary>
    /// <param name="item">The item.</param>
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
    /// Determines whether [contains] [the specified item].
    /// </summary>
    /// <param name="item">The item.</param>
    /// <returns>
    ///   <c>true</c> if [contains] [the specified item]; otherwise, <c>false</c>.
    /// </returns>
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
    /// Clears this instance.
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
    /// Firsts the or default.
    /// </summary>
    /// <param name="predicate">The predicate.</param>
    public T FirstOrDefault(Func<T, bool> predicate)
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
    /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            readerWriterLock.Dispose();
        }
    }
}