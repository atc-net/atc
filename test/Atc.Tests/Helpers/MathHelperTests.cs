namespace Atc.Tests.Helpers;

public class MathHelperTests
{
    [Theory]
    [InlineData(25, 127, 95)]
    public void PercentageAsInteger(int expected, double totalValue, double value)
    {
        // Act
        var actual = MathHelper.PercentageAsInteger(totalValue, value);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(25.2, 127, 95)]
    public void Percentage(double expected, double totalValue, double value)
    {
        // Act
        var actual = MathHelper.Percentage(totalValue, value);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(25.2, 127, 95, 1)]
    [InlineData(25.2, 127, 95, 2)]
    [InlineData(25.197, 127, 95, 3)]
    [InlineData(0, 0, 0, 2)]
    [InlineData(90, 100, 10, 2)]
    [InlineData(88, 100, 12, 2)]
    [InlineData(87.6, 100, 12.4, 2)]
    [InlineData(87.5, 100, 12.5, 2)]
    [InlineData(87.4, 100, 12.6, 2)]
    public void Percentage_Digits(double expected, double totalValue, double value, int digits)
    {
        // Act
        var actual = MathHelper.Percentage(totalValue, value, digits);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(260.96, 127.2)]
    public void CelsiusToFahrenheit(double expected, double input)
    {
        // Act
        var actual = MathHelper.CelsiusToFahrenheit(input);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(127.19999999999999, 260.96)]
    [InlineData(37.777777777777779, 100)]
    public void FahrenheitToCelsius(double expected, double input)
    {
        // Act
        var actual = MathHelper.FahrenheitToCelsius(input);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(4.5546112160044023, 260.96)]
    [InlineData(20, 1145.9155902616465)]
    public void DegreesToRadians(double expected, double input)
    {
        // Act
        var actual = MathHelper.DegreesToRadians(input);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(14951.906621733962, 260.96)]
    [InlineData(1145.9155902616465, 20)]
    public void RadiansToDegrees(double expected, double input)
    {
        // Act
        var actual = MathHelper.RadiansToDegrees(input);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(260.96, 260.96)]
    public void EnsureDegreesAreBetween0And360(double expected, double input)
    {
        // Act
        var actual = MathHelper.EnsureDegreesAreBetween0And360(input);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void EnsureDegreesAreBetween0And360_Point2D()
    {
        // Arrange
        var point = new Point2D(1.1, 2.2);

        // Act
        var actual = MathHelper.EnsureDegreesAreBetween0And360(point);

        // Assert
        Assert.Equal(1.1, actual.X);
        Assert.Equal(2.2, actual.Y);
    }

    [Fact]
    public void EnsureDegreesAreBetween0And360_Point3D()
    {
        // Arrange
        var point = new Point3D(1.1, 2.2, 3.3);

        // Act
        var actual = MathHelper.EnsureDegreesAreBetween0And360(point);

        // Assert
        Assert.Equal(1.1, actual.X);
        Assert.Equal(2.2, actual.Y);
        Assert.Equal(3.3, actual.Z);
    }

    [Theory]
    [InlineData(-0.98757888805121785, 260.96)]
    public void Sin(double expected, double input)
    {
        // Act
        var actual = MathHelper.Sin(input);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(-0.15712396340316789, 260.96)]
    public void Cos(double expected, double input)
    {
        // Act
        var actual = MathHelper.Cos(input);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(6.2853486295859735, 260.96)]
    public void Tan(double expected, double input)
    {
        // Act
        var actual = MathHelper.Tan(input);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(double.NaN, 260.96)]
    public void Asin(double expected, double input)
    {
        // Act
        var actual = MathHelper.Asin(input);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(double.NaN, 260.96)]
    public void Acos(double expected, double input)
    {
        // Act
        var actual = MathHelper.Acos(input);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(89.78044336654348, 260.96)]
    public void Atan(double expected, double input)
    {
        // Act
        var actual = MathHelper.Atan(input);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(4, new[] { 8, 4, 6 })]
    public void Min_Array_Int(int expected, int[] input)
    {
        // Act
        var actual = MathHelper.Min(input);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(4, new[] { 8, 4, 6 })]
    public void Min_List_Int(int expected, int[] data)
    {
        // Arrange
        var input = new List<int>();
        input.AddRange(data);

        // Act
        var actual = MathHelper.Min(input);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(4.4, new[] { 8.5, 4.4, 6 })]
    public void Min_Array_Double(double expected, double[] input)
    {
        // Act
        var actual = MathHelper.Min(input);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(4.4, new[] { 8.5, 4.4, 6 })]
    public void Min_List_Double(double expected, double[] data)
    {
        // Arrange
        var input = new List<double>();
        input.AddRange(data);

        // Act
        var actual = MathHelper.Min(input);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(8, new[] { 8, 4, 6 })]
    public void Max_Array_Int(int expected, int[] input)
    {
        // Act
        var actual = MathHelper.Max(input);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(8, new[] { 8, 4, 6 })]
    public void Max_List_Int(int expected, int[] data)
    {
        // Arrange
        var input = new List<int>();
        input.AddRange(data);

        // Act
        var actual = MathHelper.Max(input);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(8.5, new[] { 8.5, 4.4, 6 })]
    public void Max_Array_Double(double expected, double[] input)
    {
        // Act
        var actual = MathHelper.Max(input);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(8.5, new[] { 8.5, 4.4, 6 })]
    public void Max_List_Double(double expected, double[] data)
    {
        // Arrange
        var input = new List<double>();
        input.AddRange(data);

        // Act
        var actual = MathHelper.Max(input);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(true, 0)]
    [InlineData(true, 0.00000000000001)]
    [InlineData(false, 0.000001)]
    public void IsEqualToZero(bool expected, double input)
    {
        // Act
        var actual = MathHelper.IsEqualToZero(input);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(true, 1, 1)]
    [InlineData(false, 1, 1.00000000000001)]
    [InlineData(false, 1, 1.000001)]
    public void IsEquals(bool expected, double inputA, double inputB)
    {
        // Act
        var actual = MathHelper.IsEquals(inputA, inputB);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(12.12, 12.12, 1)]
    [InlineData(12.12, 12.12, 2)]
    [InlineData(12.12, 12.12, 3)]
    public void TruncateToMaxPrecision(double expected, double input, int decimalPrecision)
    {
        // Act
        var actual = MathHelper.TruncateToMaxPrecision(input, decimalPrecision);

        // Assert
        Assert.Equal(expected, actual);
    }
}