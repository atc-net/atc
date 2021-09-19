using Atc.Math.UnitOfDigitalInformation;
using Xunit;

// ReSharper disable StringLiteralTypo
namespace Atc.Tests.Math.UnitOfDigitalInformation
{
    public class ByteSizeFormatterTests
    {
        [Theory]
        [InlineData("1", 1)]
        [InlineData("1", 1024L)]
        [InlineData("2", 2 * 1024L)]
        [InlineData("1", 1024L * 1024L)]
        [InlineData("1", 1024L * 1024L * 1024L)]
        [InlineData("1", 1024L * 1024L * 1024L * 1024L)]
        [InlineData("1", 1024L * 1024L * 1024L * 1024L * 1024L)]
        [InlineData("1", 1024L * 1024L * 1024L * 1024L * 1024L * 1024L)]
        public void Format_Suffix_None(string expected, long size)
        {
            // Arrange
            var formatter = new ByteSizeFormatter
            {
                SuffixFormat = ByteSizeSuffixType.None,
            };

            // Atc
            var actual = formatter.Format(size);

            // Assert
            Assert.Equal(expected, actual);
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
        public void Format_Suffix_Short(string expected, long size)
        {
            // Arrange
            var formatter = new ByteSizeFormatter
            {
                SuffixFormat = ByteSizeSuffixType.Short,
            };

            // Atc
            var actual = formatter.Format(size);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("1 byte", 1)]
        [InlineData("2 bytes", 2)]
        [InlineData("1 Kilobyte", 1024L)]
        [InlineData("1 Megabyte", 1024L * 1024L)]
        [InlineData("1 Gigabyte", 1024L * 1024L * 1024L)]
        [InlineData("1 Terabyte", 1024L * 1024L * 1024L * 1024L)]
        [InlineData("1 Petabyte", 1024L * 1024L * 1024L * 1024L * 1024L)]
        [InlineData("1 Exabyte", 1024L * 1024L * 1024L * 1024L * 1024L * 1024L)]
        public void Format_Suffix_Full(string expected, long size)
        {
            // Arrange
            var formatter = new ByteSizeFormatter
            {
                SuffixFormat = ByteSizeSuffixType.Full,
            };

            // Atc
            var actual = formatter.Format(size);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("1 B", 1, 0)]
        [InlineData("2 B", 2, 0)]
        [InlineData("512 B", 512, 0)]
        [InlineData("1 KB", 1024L, 0)]
        [InlineData("1 KB", 1024L + 511, 0)]
        [InlineData("2 KB", 1024L + 512, 0)]
        [InlineData("2 KB", 2 * 1024L, 0)]
        [InlineData("353 GB", 378630729272, 0)]
        public void Format_Rounding_Closest(string expected, long size, int numberOfDecimals)
        {
            // Arrange
            var formatter = new ByteSizeFormatter
            {
                RoundingRule = ByteSizeRoundingRuleType.Closest,
                NumberOfDecimals = numberOfDecimals,
            };

            // Atc
            var actual = formatter.Format(size);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("1 B", 1, 0)]
        [InlineData("2 B", 2, 0)]
        [InlineData("512 B", 512, 0)]
        [InlineData("1 KB", 1024L, 0)]
        [InlineData("2 KB", 1024L + 511, 0)]
        [InlineData("2 KB", 1024L + 512, 0)]
        [InlineData("2 KB", 2 * 1024L, 0)]
        [InlineData("353 GB", 378630729272, 0)]
        public void Format_Rounding_Up(string expected, long size, int numberOfDecimals)
        {
            // Arrange
            var formatter = new ByteSizeFormatter
            {
                RoundingRule = ByteSizeRoundingRuleType.Up,
                NumberOfDecimals = numberOfDecimals,
            };

            // Atc
            var actual = formatter.Format(size);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("1 B", 1, 0)]
        [InlineData("2 B", 2, 0)]
        [InlineData("512 B", 512, 0)]
        [InlineData("1 KB", 1024L, 0)]
        [InlineData("1 KB", 1024L + 511, 0)]
        [InlineData("1 KB", 1024L + 512, 0)]
        [InlineData("2 KB", 2 * 1024L, 0)]
        [InlineData("352 GB", 378630729272, 0)]
        public void Format_Rounding_Down(string expected, long size, int numberOfDecimals)
        {
            // Arrange
            var formatter = new ByteSizeFormatter
            {
                RoundingRule = ByteSizeRoundingRuleType.Down,
                NumberOfDecimals = numberOfDecimals,
            };

            // Atc
            var actual = formatter.Format(size);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("1 B", 1, 0, ByteSizeUnitType.Byte, ByteSizeUnitType.Byte, GlobalizationLcidConstants.Denmark)]
        [InlineData("2 B", 2, 0, ByteSizeUnitType.Byte, ByteSizeUnitType.Byte, GlobalizationLcidConstants.Denmark)]
        [InlineData("512 B", 512, 0, ByteSizeUnitType.Byte, ByteSizeUnitType.Byte, GlobalizationLcidConstants.Denmark)]
        [InlineData("1.024 B", 1024L, 0, ByteSizeUnitType.Byte, ByteSizeUnitType.Byte, GlobalizationLcidConstants.Denmark)]
        [InlineData("1.535 B", 1024L + 511, 0, ByteSizeUnitType.Byte, ByteSizeUnitType.Byte, GlobalizationLcidConstants.Denmark)]
        [InlineData("1.536 B", 1024L + 512, 0, ByteSizeUnitType.Byte, ByteSizeUnitType.Byte, GlobalizationLcidConstants.Denmark)]
        [InlineData("2.048 B", 2 * 1024L, 0, ByteSizeUnitType.Byte, ByteSizeUnitType.Byte, GlobalizationLcidConstants.Denmark)]
        [InlineData("378.630.729.272 B", 378630729272, 0, ByteSizeUnitType.Byte, ByteSizeUnitType.Byte, GlobalizationLcidConstants.Denmark)]
        [InlineData("1 B", 1, 0, ByteSizeUnitType.Byte, ByteSizeUnitType.Byte, GlobalizationLcidConstants.UnitedStates)]
        [InlineData("2 B", 2, 0, ByteSizeUnitType.Byte, ByteSizeUnitType.Byte, GlobalizationLcidConstants.UnitedStates)]
        [InlineData("512 B", 512, 0, ByteSizeUnitType.Byte, ByteSizeUnitType.Byte, GlobalizationLcidConstants.UnitedStates)]
        [InlineData("1,024 B", 1024L, 0, ByteSizeUnitType.Byte, ByteSizeUnitType.Byte, GlobalizationLcidConstants.UnitedStates)]
        [InlineData("1,535 B", 1024L + 511, 0, ByteSizeUnitType.Byte, ByteSizeUnitType.Byte, GlobalizationLcidConstants.UnitedStates)]
        [InlineData("1,536 B", 1024L + 512, 0, ByteSizeUnitType.Byte, ByteSizeUnitType.Byte, GlobalizationLcidConstants.UnitedStates)]
        [InlineData("2,048 B", 2 * 1024L, 0, ByteSizeUnitType.Byte, ByteSizeUnitType.Byte, GlobalizationLcidConstants.UnitedStates)]
        [InlineData("378,630,729,272 B", 378630729272, 0, ByteSizeUnitType.Byte, ByteSizeUnitType.Byte, GlobalizationLcidConstants.UnitedStates)]
        public void Format_MinMax(string expected, long size, int numberOfDecimals, ByteSizeUnitType minUnit, ByteSizeUnitType maxUnit, int lcid)
        {

            // Arrange
            var formatter = new ByteSizeFormatter
            {
                NumberOfDecimals = numberOfDecimals,
                MinUnit = minUnit,
                MaxUnit = maxUnit,
                NumberFormatInfo = new System.Globalization.CultureInfo(lcid).NumberFormat,
            };

            // Atc
            var actual = formatter.Format(size);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}