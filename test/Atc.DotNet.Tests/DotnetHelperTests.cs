using System.IO;
using Xunit;

namespace Atc.DotNet.Tests
{
    public class DotnetHelperTests
    {
        [Fact]
        public void GetDotnetDirectory()
        {
            // Act
            var actual = DotnetHelper.GetDotnetDirectory();

            // Assert
            Assert.NotNull(actual);
            Assert.True(Directory.Exists(actual.FullName));
        }

        [Fact]
        public void GetDotnetExecutable()
        {
            // Act
            var actual = DotnetHelper.GetDotnetExecutable();

            // Assert
            Assert.NotNull(actual);
            Assert.True(File.Exists(actual.FullName));
        }
    }
}
