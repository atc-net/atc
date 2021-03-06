using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Atc.Tests.Extensions
{
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
        public void StartAndWaitAllThrottled(int expectedSeconds, int numberOfTasksToRun, int maxTasksToRunInParallel, int jobRunningForSeconds)
        {
            // Arrange
            var listOfTasks = new List<Task>();
            var timer = Stopwatch.StartNew();
            for (int i = 0; i < numberOfTasksToRun; i++)
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
        public void StartAndWaitAllThrottledWithTimeout(int expectedSeconds, int numberOfTasksToRun, int maxTasksToRunInParallel, int jobRunningForSeconds)
        {
            // Arrange
            var listOfTasks = new List<Task>();
            var timer = Stopwatch.StartNew();
            for (int i = 0; i < numberOfTasksToRun; i++)
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
    }
}