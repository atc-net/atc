using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading;

namespace Atc.Collections
{
    /// <summary>
    /// ConcurrentList.
    /// </summary>
    /// <typeparam name="T">The generic type.</typeparam>
    /// <seealso cref="IDisposable" />
    /// <seealso cref="System.Collections.Generic.IList{T}" />
    [SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix", Justification = "Reviewed.")]
    public class ConcurrentList<T> : IList<T>, IDisposable
    {
        private readonly ReaderWriterLockSlim readerWriterLock = new ReaderWriterLockSlim(LockRecursionPolicy.SupportsRecursion);
        private readonly List<T> list = new List<T>();

        /// <inheritdoc />
        public int Count
        {
            get
            {
                this.readerWriterLock.EnterReadLock();

                try
                {
                    return this.list.Count;
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
        public bool IsReadOnly => false;

        /// <inheritdoc />
        public T this[int index]
        {
            get
            {
                this.readerWriterLock.EnterReadLock();

                try
                {
                    return this.list[index];
                }
                finally
                {
                    if (this.readerWriterLock.IsReadLockHeld)
                    {
                        this.readerWriterLock.ExitReadLock();
                    }
                }
            }

            set => throw new NotSupportedException();
        }

        /// <inheritdoc />
        public IEnumerator<T> GetEnumerator()
        {
            this.readerWriterLock.EnterWriteLock();

            try
            {
                return this.list.GetEnumerator();
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

        /// <inheritdoc />
        public void Add(T item)
        {
            this.readerWriterLock.EnterWriteLock();

            try
            {
                this.list.Add(item);
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
        /// Adds the range.
        /// </summary>
        /// <param name="items">The items.</param>
        public void AddRange(IEnumerable<T> items)
        {
            this.readerWriterLock.EnterWriteLock();

            try
            {
                this.list.AddRange(items);
            }
            finally
            {
                if (this.readerWriterLock.IsWriteLockHeld)
                {
                    this.readerWriterLock.ExitWriteLock();
                }
            }
        }

        /// <inheritdoc />
        public void Clear()
        {
            this.readerWriterLock.EnterWriteLock();

            try
            {
                this.list.Clear();
            }
            finally
            {
                if (this.readerWriterLock.IsWriteLockHeld)
                {
                    this.readerWriterLock.ExitWriteLock();
                }
            }
        }

        /// <inheritdoc />
        public bool Contains(T item)
        {
            this.readerWriterLock.EnterReadLock();

            try
            {
                return this.list.Contains(item);
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
        public void CopyTo(T[] array, int arrayIndex)
        {
            this.readerWriterLock.EnterWriteLock();

            try
            {
                this.list.CopyTo(array, arrayIndex);
            }
            finally
            {
                if (this.readerWriterLock.IsWriteLockHeld)
                {
                    this.readerWriterLock.ExitWriteLock();
                }
            }
        }

        /// <inheritdoc />
        public bool Remove(T item)
        {
            this.readerWriterLock.EnterWriteLock();

            try
            {
                return this.list.Remove(item);
            }
            finally
            {
                if (this.readerWriterLock.IsWriteLockHeld)
                {
                    this.readerWriterLock.ExitWriteLock();
                }
            }
        }

        /// <inheritdoc />
        public int IndexOf(T item)
        {
            this.readerWriterLock.EnterReadLock();

            try
            {
                return this.list.IndexOf(item);
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
        public void Insert(int index, T item)
        {
            this.readerWriterLock.EnterWriteLock();

            try
            {
                this.list.Insert(index, item);
            }
            finally
            {
                if (this.readerWriterLock.IsWriteLockHeld)
                {
                    this.readerWriterLock.ExitWriteLock();
                }
            }
        }

        /// <inheritdoc />
        public void RemoveAt(int index)
        {
            this.readerWriterLock.EnterWriteLock();

            try
            {
                this.list.RemoveAt(index);
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
                return this.list.FirstOrDefault(predicate);
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