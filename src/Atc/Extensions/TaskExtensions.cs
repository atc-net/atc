using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

// ReSharper disable AccessToDisposedClosure
// ReSharper disable once CheckNamespace
namespace System
{
    /// <summary>
    /// Extensions for the <see cref="Task"/> class.
    /// </summary>
    public static class TaskExtensions
    {
        /// <summary>
        /// Starts the given tasks and waits for them to complete. This will run, at most, the specified number of tasks in parallel.
        /// <para>NOTE: If one of the given tasks has already been started, an exception will be thrown.</para>
        /// </summary>
        /// <param name="tasksToRun">The tasks to run.</param>
        /// <param name="maxTasksToRunInParallel">The maximum number of tasks to run in parallel.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public static void StartAndWaitAllThrottled(this IEnumerable<Task> tasksToRun, int maxTasksToRunInParallel, CancellationToken cancellationToken = default)
        {
            StartAndWaitAllThrottled(tasksToRun, maxTasksToRunInParallel, -1, cancellationToken);
        }

        /// <summary>
        /// Starts the given tasks and waits for them to complete. This will run, at most, the specified number of tasks in parallel.
        /// <para>NOTE: If one of the given tasks has already been started, an exception will be thrown.</para>
        /// </summary>
        /// <param name="tasksToRun">The tasks to run.</param>
        /// <param name="maxTasksToRunInParallel">The maximum number of tasks to run in parallel.</param>
        /// <param name="timeoutInMilliseconds">The maximum milliseconds we should allow the max tasks to run in parallel before allowing another task to start. Specify -1 to wait indefinitely.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        [SuppressMessage("Reliability", "CA2008:Do not create tasks without passing a TaskScheduler", Justification = "OK.")]
        public static void StartAndWaitAllThrottled(this IEnumerable<Task> tasksToRun, int maxTasksToRunInParallel, int timeoutInMilliseconds, CancellationToken cancellationToken = default)
        {
            if (tasksToRun == null)
            {
                throw new ArgumentNullException(nameof(tasksToRun));
            }

            if (maxTasksToRunInParallel < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(maxTasksToRunInParallel));
            }

            if (timeoutInMilliseconds is < -1 or 0)
            {
                throw new ArgumentOutOfRangeException(nameof(timeoutInMilliseconds));
            }

            // Convert to a list of tasks so that we don't enumerate over it multiple times needlessly.
            var tasks = tasksToRun.ToList();

            using var throttler = new SemaphoreSlim(maxTasksToRunInParallel);
            var postTaskTasks = new List<Task>();

            // Have each task notify the throttler when it completes so that it decrements the number of tasks currently running.
            tasks.ForEach(t => postTaskTasks.Add(t.ContinueWith(_ => throttler.Release(), cancellationToken)));

            // Start running each task.
            foreach (var task in tasks)
            {
                // Increment the number of tasks currently running and wait if too many are running.
                throttler.Wait(timeoutInMilliseconds, cancellationToken);

                cancellationToken.ThrowIfCancellationRequested();
                task.Start();
            }

            // Wait for all of the provided tasks to complete.
            // We wait on the list of "post" tasks instead of the original tasks, otherwise there is a potential race condition where the throttler's using block is exited
            // before some Tasks have had their "post" action completed, which references the throttler, resulting in an exception due to accessing a disposed object.
            Task.WaitAll(postTaskTasks.ToArray(), cancellationToken);
        }
    }
}