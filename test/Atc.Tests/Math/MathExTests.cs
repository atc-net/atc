namespace Atc.Tests.Math;

public class MathExTests
{
    [Theory]
    [InlineData(3, 9, 3)]
    [InlineData(4, 8, 12)]
    [InlineData(6, 54, 24)]
    [InlineData(14, 42, 56)]
    [InlineData(6, 48, 18)]
    [InlineData(21, 1071, 462)]
    [InlineData(65, 89765, 12350)]
    public void GreatestCommonDivisor(int expected, int v1, int v2)
    {
        // Act
        var actual = MathEx.GreatestCommonDivisor(v1, v2);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(0.5, 1.5, 2.5)]
    [InlineData(3.3, 9.9, 3.3)]
    [InlineData(9.5, 89765.5, 12350)]
    public void GreatestCommonDivisor_As_Double(double expected, double v1, double v2)
    {
        // Act
        var actual = MathEx.GreatestCommonDivisor(v1, v2);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(new[] { 1, 2, 4, 8 }, 16, 8)]
    [InlineData(new[] { 1 }, 1, 1)]
    [InlineData(new[] { 1, 3 }, 9, 5)]
    [InlineData(new[] { 1, 3, 9 }, 9, 9)]
    [InlineData(new[] { 1, 3, 9 }, 9, 29)]
    [InlineData(new[] { 1, 5, 13, 65, 1381, 6905, 17953 }, 89765, 44882)]
    public void GetDivisorsLessThanOrEqual(IEnumerable<int> expected, int value, int max)
    {
        // Act
        var actual = MathEx.GetDivisorsLessThanOrEqual(value, max);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(-1, 10)]
    [InlineData(0, 10)]
    [InlineData(10, -1)]
    [InlineData(10, 0)]
    public void GetDivisorsLessThanOrEqual_Expected_ArgumentOutOfRangeException(int value, int max)
        => Assert.Throws<ArgumentOutOfRangeException>(() => MathEx.GetDivisorsLessThanOrEqual(value, max));

    [Theory]
    [InlineData(0, int.MinValue)]
    [InlineData(0, -1)]
    [InlineData(1, 0)]
    [InlineData(1, 1)]
    [InlineData(1, int.MaxValue)]
    public void Step(int expected, int x)
    {
        // Act
        var actual = MathEx.Step(x);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(0, -1, 1, 1)]
    [InlineData(1, 0, 1, 1)]
    [InlineData(0, 1, 1, 1)]
    [InlineData(0, 5, 1, 1)]
    [InlineData(5, 0, 10, 5)]
    [InlineData(5, 5, 10, 5)]
    [InlineData(0, 10, 10, 5)]
    public void Rect(int expected, int x, int width, int height)
    {
        // Act
        var actual = MathEx.Rect(x, width, height);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(0, 0, 1, 1)]
    [InlineData(0, 5, 10, 5)]
    [InlineData(0, -1, 10, 5)]
    [InlineData(5, 10, 10, 5)]
    public void Hysteron(int expected, int x, int width, int height)
    {
        // Arrange
        int state = 0;

        // Act
        var actual = MathEx.Hysteron(ref state, x, width, height);

        // Assert
        Assert.Equal(expected, actual);
        Assert.Equal(expected, state);
    }

    [Theory]
    [InlineData(0, 0, 5)]
    [InlineData(5, 1, 5)]
    [InlineData(5, 5, 5)]
    [InlineData(10, 6, 5)]
    [InlineData(-5, -5, 5)]
    [InlineData(-5, -6, 5)]
    public void Ceiling_Int(int expected, int x, int period)
    {
        // Act
        var actual = MathEx.Ceiling(x, period);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(0, 0, 5)]
    [InlineData(0, 1, 5)]
    [InlineData(5, 5, 5)]
    [InlineData(5, 6, 5)]
    [InlineData(-5, -5, 5)]
    [InlineData(-10, -6, 5)]
    public void Floor_Int(int expected, int x, int period)
    {
        // Act
        var actual = MathEx.Floor(x, period);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(0, 0, 5)]
    [InlineData(1, 1, 5)]
    [InlineData(4, 4, 5)]
    [InlineData(0, 5, 5)]
    [InlineData(1, 6, 5)]
    [InlineData(4, -1, 5)]
    [InlineData(0, -5, 5)]
    public void SawTooth(int expected, int x, int period)
    {
        // Act
        var actual = MathEx.SawTooth(x, period);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Multiply()
    {
        // Arrange
        Func<int, int> f = x => x * 2;
        Func<int, int> g = x => x + 3;

        // Act
        var actual = MathEx.Multiply(f, g);

        // Assert
        Assert.Equal(20, actual(2)); // f(2) * g(2) = 4 * 5 = 20
    }

    [Fact]
    public void Compose()
    {
        // Arrange
        Func<int, int> f = x => x * 2;
        Func<int, int> g = x => x + 3;

        // Act
        var actual = MathEx.Compose(f, g);

        // Assert
        Assert.Equal(10, actual(2)); // f(g(2)) = f(5) = 10
    }

    [Fact]
    public void Floor_Func()
    {
        // Arrange
        Func<int, int> f = x => x * 2;
        int period = 5;

        // Act
        var actual = MathEx.Floor(f, period);

        // Assert
        Assert.Equal(10, actual(7)); // Floor(7, 5) = 5, f(5) = 10
    }

    [Fact]
    public void Ceiling_Func()
    {
        // Arrange
        Func<int, int> f = x => x * 2;
        int period = 5;

        // Act
        var actual = MathEx.Ceiling(f, period);

        // Assert
        Assert.Equal(20, actual(7)); // Ceiling(7, 5) = 10, f(10) = 20
    }

    [Fact]
    public void Periodic()
    {
        // Arrange
        Func<int, int> f = x => x * 2;
        int period = 5;

        // Act
        var actual = MathEx.Periodic(f, period);

        // Assert
        Assert.Equal(4, actual(7)); // SawTooth(7, 5) = 2, f(2) = 4
    }

    [Fact]
    public void Modulate()
    {
        // Arrange
        Func<int, int> carrier = x => x;
        Func<int, int> cellFunction = x => x;
        int period = 10;

        // Act
        var actual = MathEx.Modulate(carrier, cellFunction, period);

        // Assert
        var result = actual(5);
        Assert.True(result >= 0);
    }
}