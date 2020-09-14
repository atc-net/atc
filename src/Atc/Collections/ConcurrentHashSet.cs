using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading;

namespace Atc.Collections
{
    /// <summary>
    /// ConcurrentHashSet.
    /// </summary>
    /// <typeparam name="T">The generic type.</typeparam>
    /// <seealso cref="System.Collections.Generic.IEnumerable{T}" />
    /// <seealso cref="System.IDisposable" />
    [SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix", Justification = "OK.")]
    public class ConcurrentHashSet<T> : IEnumerable<T>, IDisposable
    {
        private readonly ReaderWriterLockSlim readerWriterLock = new ReaderWriterLockSlim(LockRecursionPolicy.SupportsRecursion);
        private readonly HashSet<T> hashSet = new HashSet<T>();

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
                this.readerWriterLock.EnterReadLock();

                try
                {
                    return this.hashSet.Count;
                }
                finally
                {
                    if (this.readerWriterLock.IsReadLockHeld)
                    {
                        this.readerWriterLock.ExitReadLock();
                    }
                }
            }
        }

        /// <inheritdoc />
        public IEnumerator<T> GetEnumerator()
        {
            this.readerWriterLock.EnterWriteLock();

            try
            {
                return this.hashSet.GetEnumerator();
            }
            finally
            {
                if (this.readerWriterLock.IsWriteLockHeld)
                {
                    this.readerWriterLock.ExitWriteLock();
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        /// <summary>
        /// Tries the add.
        /// </summary>
        /// <param name="item">The item.</param>
        public bool TryAdd(T item)
        {
            this.readerWriterLock.EnterWriteLock();

            try
            {
                return this.hashSet.Add(item);
            }
            finally
            {
                if (this.readerWriterLock.IsWriteLockHeld)
                {
                    this.readerWriterLock.ExitWriteLock();
                }
            }
        }

        /// <summary>
        /// Tries the remove.
        /// </summary>
        /// <param name="item">The item.</param>
        public bool TryRemove(T item)
        {
            this.readerWriterLock.EnterWriteLock();

            try
            {
                return this.hashSet.Remove(item);
            }
            finally
            {
                if (this.readerWriterLock.IsWriteLockHeld)
                {
                    this.readerWriterLock.ExitWriteLock();
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
            this.readerWriterLock.EnterReadLock();

            try
            {
                return this.hashSet.Contains(item);
            }
            finally
            {
                if (this.readerWriterLock.IsReadLockHeld)
                {
                    this.readerWriterLock.ExitReadLock();
                }
            }
        }

        /// <summary>
        /// Clears this instance.
        /// </summary>
        public void Clear()
        {
            this.readerWriterLock.EnterWriteLock();

            try
            {
                this.hashSet.Clear();
            }
            finally
            {
                if (this.readerWriterLock.IsWriteLockHeld)
                {
                    this.readerWriterLock.ExitWriteLock();
                }
            }
        }

        /// <summary>
        /// Firsts the or default.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        public T FirstOrDefault(Func<T, bool> predicate)
        {
            this.readerWriterLock.EnterReadLock();

            try
            {
                return this.hashSet.FirstOrDefault(predicate);
            }
            finally
            {
                if (this.readerWriterLock.IsReadLockHeld)
                {
                    this.readerWriterLock.ExitReadLock();
                }
            }
        }

        /// <inheritdoc />
        public void Dispose()
        {
            this.Dispose(true);
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
                this.readerWriterLock.Dispose();
            }
        }
    }
}