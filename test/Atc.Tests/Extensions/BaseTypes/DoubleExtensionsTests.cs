using System;
using Xunit;

namespace Atc.Tests.Extensions.BaseTypes
{
    public class DoubleExtensionsTests
    {
        [Theory]
        [InlineData(true, 12.3, 12.3)]
        public void IsEqual(bool expected, double a, double b)
        {
            // Act
            var actual = a.IsEqual(b);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(true, 12.3, 12.3)]
        [InlineData(false, 12.3, null)]
        [InlineData(false, null, 12.3)]
        [InlineData(true, null, null)]
        public void IsEqual_Nullable(bool expected, double? a, double? b)
        {
            // Act
            var actual = a.IsEqual(b);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(true, 12.3, 12.3, 2)]
        [InlineData(true, 12.31, 12.3, 1)]
        [InlineData(true, 12.311, 12.31, 2)]
        public void IsEqual_DecimalPrecision(bool expected, double a, double b, int decimalPrecision)
        {
            // Act
            var actual = a.IsEqual(b, decimalPrecision);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(true, 12.3, 12.3, 2)]
        [InlineData(false, 12.3, null, 2)]
        [InlineData(false, null, 12.3, 2)]
        [InlineData(true, null, null, 2)]
        [InlineData(true, 12.31, 12.3, 1)]
        [InlineData(true, 12.311, 12.31, 2)]
        public void IsEqual_Nullable_DecimalPrecision(bool expected, double? a, double? b, int decimalPrecision)
        {
            // Act
            var actual = a.IsEqual(b, decimalPrecision);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(true, 12.3, 12.30000000000000001)]
        [InlineData(false, 12, 12.3)]
        public void AreClose(bool expected, double a, double b)
        {
            // Act
            var actual = a.AreClose(b);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(true, 12.31, 12)]
        [InlineData(true, 12.30000000000000001, 12.3)]
        [InlineData(false, 12, 12.3)]
        public void GreaterThanOrClose(bool expected, double a, double b)
        {
            // Act
            var actual = a.GreaterThanOrClose(b);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(false, -0.1)]
        [InlineData(true, 0)]
        [InlineData(false, 0.1)]
        public void IsZero(bool expected, double input)
        {
            // Act
            var actual = input.IsZero();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(10, 10)]
        [InlineData(12, 12)]
        [InlineData(12, 12.4)]
        [InlineData(13, 12.6)]
        [InlineData(12, 12.49)]
        [InlineData(13, 12.50)]
        [InlineData(13, 12.51)]
        public void CurrencyRoundingAsInteger(int expected, double input)
        {
            // Act
            var actual = input.CurrencyRoundingAsInteger();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(0.0, 0)]
        [InlineData(10.0, 10)]
        [InlineData(12.0, 12)]
        [InlineData(12.4, 12.4)]
        [InlineData(12.6, 12.6)]
        [InlineData(12.49, 12.49)]
        [InlineData(12.5, 12.50)]
        [InlineData(12.51, 12.51)]
        [InlineData(12.45, 12.449)]
        [InlineData(12.45, 12.450)]
        [InlineData(12.45, 12.451)]
        [InlineData(12.44, 12.4449)]
        [InlineData(12.45, 12.4450)]
        [InlineData(12.45, 12.4451)]
        public void CurrencyRounding(double expected, double input)
        {
            // Act
            var actual = input.CurrencyRounding();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(0.0, 0, 0)]
        [InlineData(10.0, 10, 0)]
        [InlineData(12.0, 12, 0)]
        [InlineData(12.0, 12.4, 0)]
        [InlineData(13.0, 12.6, 0)]
        [InlineData(12.0, 12.49, 0)]
        [InlineData(13.0, 12.50, 0)]
        [InlineData(13.0, 12.51, 0)]
        [InlineData(12.0, 12.449, 0)]
        [InlineData(12.0, 12.450, 0)]
        [InlineData(12.0, 12.451, 0)]
        [InlineData(12.0, 12.4449, 0)]
        [InlineData(12.0, 12.4450, 0)]
        [InlineData(12.0, 12.4451, 0)]
        [InlineData(0.0, 0, 1)]
        [InlineData(10.0, 10, 1)]
        [InlineData(12.0, 12, 1)]
        [InlineData(12.4, 12.4, 1)]
        [InlineData(12.6, 12.6, 1)]
        [InlineData(12.5, 12.49, 1)]
        [InlineData(12.5, 12.50, 1)]
        [InlineData(12.5, 12.51, 1)]
        [InlineData(12.4, 12.449, 1)]
        [InlineData(12.5, 12.450, 1)]
        [InlineData(12.5, 12.451, 1)]
        [InlineData(12.4, 12.4449, 1)]
        [InlineData(12.4, 12.4450, 1)]
        [InlineData(12.4, 12.4451, 1)]
        [InlineData(0.0, 0, 2)]
        [InlineData(10.0, 10, 2)]
        [InlineData(12.0, 12, 2)]
        [InlineData(12.4, 12.4, 2)]
        [InlineData(12.6, 12.6, 2)]
        [InlineData(12.49, 12.49, 2)]
        [InlineData(12.5, 12.50, 2)]
        [InlineData(12.51, 12.51, 2)]
        [InlineData(12.45, 12.449, 2)]
        [InlineData(12.45, 12.450, 2)]
        [InlineData(12.45, 12.451, 2)]
        [InlineData(12.44, 12.4449, 2)]
        [InlineData(12.45, 12.4450, 2)]
        [InlineData(12.45, 12.4451, 2)]
        [InlineData(0.0, 0, 3)]
        [InlineData(10.0, 10, 3)]
        [InlineData(12.0, 12, 3)]
        [InlineData(12.4, 12.4, 3)]
        [InlineData(12.6, 12.6, 3)]
        [InlineData(12.49, 12.49, 3)]
        [InlineData(12.5, 12.50, 3)]
        [InlineData(12.51, 12.51, 3)]
        [InlineData(12.449, 12.449, 3)]
        [InlineData(12.450, 12.450, 3)]
        [InlineData(12.451, 12.451, 3)]
        [InlineData(12.445, 12.4449, 3)]
        [InlineData(12.4450, 12.4450, 3)]
        [InlineData(12.445, 12.4451, 3)]
        public void CurrencyRounding_Digits(double expected, double input, int digits)
        {
            // Act
            var actual = input.CurrencyRounding(digits);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(21.23, 21.2345)]
        [InlineData(1.0, 1.0)]
        [InlineData(1.1, 1.1)]
        [InlineData(1.11, 1.11)]
        [InlineData(1.11, 1.111)]
        [InlineData(1.12, 1.115)]
        public void RoundOff2(double expected, double input)
        {
            // Act
            var actual = input.RoundOff2();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(21.2345, 21.2345)]
        [InlineData(1.0, 1.0)]
        [InlineData(1.000000001, 1.000000001)]
        [InlineData(1.0000000011, 1.0000000011)]
        [InlineData(1.0000000011, 1.00000000111)]
        [InlineData(1.0000000012, 1.00000000115)]
        public void RoundOff10(double expected, double input)
        {
            // Act
            var actual = input.RoundOff10();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(21, 21.2345, 0)]
        [InlineData(21.2, 21.2345, 1)]
        [InlineData(21.23, 21.2345, 2)]
        [InlineData(21.234, 21.2345, 3)]
        [InlineData(1.0, 1.0, 2)]
        [InlineData(1.1, 1.1, 2)]
        [InlineData(1.11, 1.11, 2)]
        [InlineData(1.11, 1.111, 2)]
        [InlineData(1.12, 1.115, 2)]
        [InlineData(1.000000001, 1.000000001, 10)]
        [InlineData(1.0000000011, 1.0000000011, 10)]
        [InlineData(1.0000000011, 1.00000000111, 10)]
        [InlineData(1.0000000012, 1.00000000115, 10)]
        public void RoundOff_NumberOfDecimals(double expected, double input, int numberOfDecimals)
        {
            // Act
            var actual = input.RoundOff(numberOfDecimals);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(21.23, 21.2345)]
        [InlineData(1.0, 1.0)]
        [InlineData(1.1, 1.1)]
        [InlineData(1.11, 1.11)]
        [InlineData(1.11, 1.111)]
        [InlineData(1.12, 1.115)]
        public void RoundOffPercent(double expected, double input)
        {
            // Act
            var actual = input.RoundOffPercent();

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}