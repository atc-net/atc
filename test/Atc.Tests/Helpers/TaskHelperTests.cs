using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Atc.Helpers;
using FluentAssertions;
using Xunit;

namespace Atc.Tests.Helpers
{
    public class TaskHelperTests
    {
        [Fact]
        public async Task WhenAll()
        {
            // Arrange
            const int expected = 1;

            var taskCompletionSource = new TaskCompletionSource<int>();
            taskCompletionSource.TrySetResult(expected);

            // Act
            var actual = (await TaskHelper.WhenAll(taskCompletionSource.Task)).ToList();

            // Assert
            actual
                .Should()
                .NotBeNull()
                .And
                .NotBeEmpty()
                .And.HaveCount(1);

            Assert.Equal(expected, actual[0]);
        }

        [Fact]
        public async Task WhenAll_Throws_AggregateException()
        {
            const string firstExceptionMessage = "First Exception!";
            const string secondExceptionMessage = "Second Exception!";

            // Arrange
            var taskCompletionSource = new TaskCompletionSource<int>();
            taskCompletionSource.TrySetException(new Exception[]
            {
                new (firstExceptionMessage),
                new (secondExceptionMessage),
            });

            // Act & Assert
            var actual = await Assert.ThrowsAsync<AggregateException>(async () => await TaskHelper.WhenAll(taskCompletionSource.Task));

            actual
                .Should()
                .NotBeNull();

            Assert.Equal(typeof(AggregateException), actual.GetType());

            actual.InnerExceptions
                .Should()
                .NotBeEmpty()
                .And
                .HaveCount(2);

            Assert.Equal(firstExceptionMessage, actual.InnerExceptions[0].Message);
            Assert.Equal(secondExceptionMessage, actual.InnerExceptions[1].Message);
        }

        [Fact]
        [SuppressMessage("Blocker Code Smell", "S2699:Tests should include assertions", Justification = "OK. Just expect no exceptions.")]
        public void RunSync()
        {
            // Arrange
            var doSomethingTask = DoSomethingAsync();

            // Act
            TaskHelper.RunSync(() => doSomethingTask);
        }

        [Fact]
        public void RunSyncAndReturnResult()
        {
            // Arrange
            var doSomethingTask = DoSomethingAndReturnResultAsync();

            // Act
            var actual = TaskHelper.RunSync(() => doSomethingTask);

            // Assert
            Assert.Equal(42, actual);
        }

        private Task DoSomethingAsync()
        {
            return Task.Delay(100);
        }

        private async Task<int> DoSomethingAndReturnResultAsync()
        {
            await Task.Delay(100);
            return 42;
        }
    }
}