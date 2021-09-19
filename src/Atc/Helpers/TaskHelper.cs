using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;

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
    }
}