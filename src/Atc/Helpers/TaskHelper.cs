using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using Exception = System.Exception;

namespace Atc.Helpers
{
    /// <summary>
    /// TaskHelper.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class TaskHelper
    {
        /// <summary>
        /// Executes the specified task with a timeout.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="taskToRun">The task to run.</param>
        /// <param name="timeout">The timeout.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public static async Task<TResult> Execute<TResult>(
            Func<CancellationToken, Task<TResult>> taskToRun,
            TimeSpan timeout,
            CancellationToken cancellationToken = default)
        {
            using var timeoutCancellation = new CancellationTokenSource();
            using var combinedCancellation = CancellationTokenSource
                .CreateLinkedTokenSource(cancellationToken, timeoutCancellation.Token);
            var originalTask = taskToRun(combinedCancellation.Token);
            var delayTask = Task.Delay(timeout, timeoutCancellation.Token);
            var completedTask = await Task
                .WhenAny(originalTask, delayTask)
                .ConfigureAwait(false);

            timeoutCancellation.Cancel();
            if (completedTask == originalTask)
            {
                return await originalTask.ConfigureAwait(false);
            }

            throw new TimeoutException();
        }

        /// <summary>
        /// This method wraps the built-in Task.WhenAll method, but
        /// correctly await`s tasks and gets an AggregateException back.
        /// </summary>
        /// <typeparam name="T">The type of tasks</typeparam>
        /// <param name="tasks">The tasks.</param>
        /// <remarks>
        /// This method gives us an AggregateException and not only the first exception occurrence,
        /// in case of an exception thrown from one of the tasks.
        /// </remarks>
        public static async Task<IEnumerable<T>> WhenAll<T>(params Task<T>[] tasks)
        {
            var allTasks = Task.WhenAll(tasks);

            try
            {
                return await allTasks;
            }
            catch (Exception)
            {
                // Ignore
            }

            throw allTasks.Exception ?? throw new Exception("Could not get AggregateException from tasks!");
        }
    }
}