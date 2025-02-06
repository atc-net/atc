namespace Atc.Helpers;

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
    [SuppressMessage("Major Code Smell", "S4457:Parameter validation in \"async\"/\"await\" methods should be wrapped", Justification = "OK.")]
    public static async Task<TResult> Execute<TResult>(
        Func<CancellationToken, Task<TResult>> taskToRun,
        TimeSpan timeout,
        CancellationToken cancellationToken = default)
    {
        if (taskToRun is null)
        {
            throw new ArgumentNullException(nameof(taskToRun));
        }

        using var timeoutCancellation = new CancellationTokenSource();
        using var combinedCancellation = CancellationTokenSource
            .CreateLinkedTokenSource(cancellationToken, timeoutCancellation.Token);
        var originalTask = taskToRun(combinedCancellation.Token);
        var delayTask = Task.Delay(timeout, timeoutCancellation.Token);
        var completedTask = await Task
            .WhenAny(originalTask, delayTask)
            .ConfigureAwait(false);

#if NET8_0_OR_GREATER
        await timeoutCancellation.CancelAsync();
#else
        timeoutCancellation.Cancel();
#endif
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
    /// <param name="tasks">The tasks.</param>
    /// <remarks>
    /// This method gives us an AggregateException and not only the first exception occurrence,
    /// in case of an exception thrown from one of the tasks.
    /// </remarks>
    [SuppressMessage("Microsoft.Design", "CA1031:Do not catch general exception types", Justification = "OK.")]
    [SuppressMessage("Usage", "CA2201:Do not raise reserved exception types", Justification = "OK.")]
    [SuppressMessage("Code Smell", "S112:General exceptions should never be thrown", Justification = "OK.")]
    public static async Task WhenAll(IEnumerable<Task> tasks)
    {
        var allTasks = Task.WhenAll(tasks);

        try
        {
            await allTasks;
            return;
        }
        catch
        {
            // Ignore
        }

        throw allTasks.Exception ?? throw new Exception("Could not get AggregateException from tasks!");
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
    [SuppressMessage("Microsoft.Design", "CA1031:Do not catch general exception types", Justification = "OK.")]
    [SuppressMessage("Usage", "CA2201:Do not raise reserved exception types", Justification = "OK.")]
    [SuppressMessage("Code Smell", "S112:General exceptions should never be thrown", Justification = "OK.")]
    public static async Task<IEnumerable<T>> WhenAll<T>(IEnumerable<Task<T>> tasks)
    {
        var allTasks = Task.WhenAll(tasks);

        try
        {
            return await allTasks;
        }
        catch
        {
            // Ignore
        }

        throw allTasks.Exception ?? throw new Exception("Could not get AggregateException from tasks!");
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
    [SuppressMessage("Microsoft.Design", "CA1031:Do not catch general exception types", Justification = "OK.")]
    [SuppressMessage("Usage", "CA2201:Do not raise reserved exception types", Justification = "OK.")]
    [SuppressMessage("Code Smell", "S112:General exceptions should never be thrown", Justification = "OK.")]
    public static async Task<IEnumerable<T>> WhenAll<T>(params Task<T>[] tasks)
    {
        var allTasks = Task.WhenAll(tasks);

        try
        {
            return await allTasks;
        }
        catch
        {
            // Ignore
        }

        throw allTasks.Exception ?? throw new Exception("Could not get AggregateException from tasks!");
    }

    /// <summary>
    /// Runs a Task function synchronous.
    /// </summary>
    /// <param name="func">The Task function.</param>
    [SuppressMessage("Microsoft.Reliability", "CA2008:Do not create tasks without passing a TaskScheduler", Justification = "OK. https://github.com/dotnet/roslyn-analyzers/issues/1907")]
    public static void RunSync(Func<Task> func)
    {
        var taskFactory = new TaskFactory(
            CancellationToken.None,
            TaskCreationOptions.None,
            TaskContinuationOptions.None,
            TaskScheduler.Default);

        taskFactory
            .StartNew(func)
            .Unwrap()
            .GetAwaiter()
            .GetResult();
    }

    /// <summary>
    /// Runs a Task function synchronous.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <param name="func">The Task function.</param>
    [SuppressMessage("Microsoft.Reliability", "CA2008:Do not create tasks without passing a TaskScheduler", Justification = "OK. https://github.com/dotnet/roslyn-analyzers/issues/1907")]
    public static TResult RunSync<TResult>(Func<Task<TResult>> func)
    {
        var taskFactory = new TaskFactory(
            CancellationToken.None,
            TaskCreationOptions.None,
            TaskContinuationOptions.None,
            TaskScheduler.Default);

        return taskFactory
            .StartNew(func)
            .Unwrap()
            .GetAwaiter()
            .GetResult();
    }

    /// <summary>
    /// Executes the provided action on a background thread, ignoring its completion status.
    /// This method is intended for fire-and-forget scenarios where the action is non-critical and does not need to be awaited or monitored.
    /// </summary>
    /// <param name="action">The action to execute asynchronously.</param>
    /// <exception cref="ArgumentNullException">Thrown if the action is null.</exception>
    [SuppressMessage("Design", "CA1030:Use events where appropriate", Justification = "OK.")]
    public static void FireAndForget(
        Action action)
    {
        if (action is null)
        {
            throw new ArgumentNullException(nameof(action));
        }

        Task.Run(action).Forget();
    }

    /// <summary>
    /// Initiates the execution of a provided task and intentionally ignores its result or completion status.
    /// This is a fire-and-forget utility method, used when the outcome of the task is not needed or is handled elsewhere.
    /// It's primarily used for tasks where the result is not critical and does not need to be awaited or monitored.
    /// </summary>
    /// <param name="task">The task to execute and forget.</param>
    /// <exception cref="ArgumentNullException">Thrown if the task is null.</exception>
    [SuppressMessage("Design", "CA1030:Use events where appropriate", Justification = "OK.")]
    public static void FireAndForget(
        Task task)
    {
        if (task is null)
        {
            throw new ArgumentNullException(nameof(task));
        }

        task.Forget();
    }
}