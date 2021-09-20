using Atc.Units.DigitalInformation;
using Xunit;

namespace Atc.Tests.Units.DigitalInformation
{
    public class ByteSizeTests
    {
        [Theory]
        [InlineData("1 B", 1)]
        [InlineData("1 KB", 1024L)]
        [InlineData("2 KB", 2 * 1024L)]
        [InlineData("1 MB", 1024L * 1024L)]
        [InlineData("1 GB", 1024L * 1024L * 1024L)]
        [InlineData("1 TB", 1024L * 1024L * 1024L * 1024L)]
        [InlineData("1 PB", 1024L * 1024L * 1024L * 1024L * 1024L)]
        [InlineData("1 EB", 1024L * 1024L * 1024L * 1024L * 1024L * 1024L)]
        public void Format_Default(string expected, long size)
        {
            // Arrange
            var byteSize = new ByteSize(size);

            // Atc
            var actual = byteSize.Format();

            // Assert
            Assert.Equal(expected, actual);
            Assert.Equal(expected, byteSize.ToString());
        }

        [Theory]
        [InlineData("1 B", 1)]
        [InlineData("1 KB", 1024L)]
        [InlineData("2 KB", 2 * 1024L)]
        [InlineData("1 MB", 1024L * 1024L)]
        [InlineData("1 GB", 1024L * 1024L * 1024L)]
        [InlineData("1 TB", 1024L * 1024L * 1024L * 1024L)]
        [InlineData("1 PB", 1024L * 1024L * 1024L * 1024L * 1024L)]
        [InlineData("1 EB", 1024L * 1024L * 1024L * 1024L * 1024L * 1024L)]
        public void Format_Default_Formatter(string expected, long size)
        {
            // Arrange
            var byteSize = new ByteSize(size);
            var formatter = new ByteSizeFormatter();

            // Atc
            var actual = byteSize.Format(formatter);

            // Assert
            Assert.Equal(expected, actual);
            Assert.Equal(expected, byteSize.ToString(formatter));
        }
    }
}