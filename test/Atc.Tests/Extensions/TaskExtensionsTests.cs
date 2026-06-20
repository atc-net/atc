namespace Atc.Tests.Extensions;

[Trait(Traits.Category, Traits.Categories.Integration)]
[Trait(Traits.Category, Traits.Categories.SkipWhenLiveUnitTesting)]
public class TaskExtensionsTests
{
    [Theory]
    [InlineData(1, 1, 3, 1)]
    [InlineData(1, 2, 3, 1)]
    [InlineData(1, 3, 3, 1)]
    [InlineData(2, 4, 3, 1)]
    [InlineData(2, 5, 3, 1)]
    [InlineData(2, 6, 3, 1)]
    [InlineData(3, 7, 3, 1)]
    public void StartAndWaitAllThrottled(
        int expectedSeconds,
        int numberOfTasksToRun,
        int maxTasksToRunInParallel,
        int jobRunningForSeconds)
    {
        if (numberOfTasksToRun > Environment.ProcessorCount)
        {
            // Only run the test if we have enough logical processors available.
            return;
        }

        // Arrange
        var listOfTasks = new List<Task>();
        var timer = Stopwatch.StartNew();
        for (var i = 0; i < numberOfTasksToRun; i++)
        {
            listOfTasks.Add(new Task(
                () =>
                {
                    Thread.Sleep(TimeSpan.FromMilliseconds(jobRunningForSeconds * 1000));
                }));
        }

        // Atc
        listOfTasks.StartAndWaitAllThrottled(maxTasksToRunInParallel);
        timer.Stop();

        // Assert
        Assert.True(timer.Elapsed.Seconds.Equals(expectedSeconds));
    }

    [Theory]
    [InlineData(1, 1, 3, 1)]
    [InlineData(1, 2, 3, 1)]
    [InlineData(1, 3, 3, 1)]
    [InlineData(2, 4, 3, 1)]
    [InlineData(2, 5, 3, 1)]
    [InlineData(2, 6, 3, 1)]
    [InlineData(3, 7, 3, 1)]
    public void StartAndWaitAllThrottledWithTimeout(
        int expectedSeconds,
        int numberOfTasksToRun,
        int maxTasksToRunInParallel,
        int jobRunningForSeconds)
    {
        if (numberOfTasksToRun > Environment.ProcessorCount)
        {
            // Only run the test if we have enough logical processors available.
            return;
        }

        // Arrange
        var listOfTasks = new List<Task>();
        var timer = Stopwatch.StartNew();
        for (var i = 0; i < numberOfTasksToRun; i++)
        {
            listOfTasks.Add(new Task(
                () =>
                {
                    Thread.Sleep(TimeSpan.FromMilliseconds(jobRunningForSeconds * 1000));
                }));
        }

        // Atc
        listOfTasks.StartAndWaitAllThrottled(maxTasksToRunInParallel, 2000);
        timer.Stop();

        // Assert
        Assert.True(timer.Elapsed.Seconds.Equals(expectedSeconds));
    }

    [Fact]
    public void StartAndWaitAllThrottled_WhenSlotTimeoutExpires_ThrowsTimeoutException()
    {
        // Arrange: 2 tasks that sleep 300 ms, max 1 parallel, slot timeout of 50 ms.
        // Task 1 starts and holds the semaphore slot. Task 2 waits only 50 ms for the
        // slot to become free — well before task 1 finishes — so WaitForExit must throw.
        var tasks = new List<Task>
        {
            new(() => Thread.Sleep(300)),
            new(() => Thread.Sleep(300)),
        };

        // Act & Assert
        Assert.Throws<TimeoutException>(() => tasks.StartAndWaitAllThrottled(1, 50));
    }
}