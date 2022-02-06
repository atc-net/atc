// ReSharper disable CommentTypo
namespace Atc.Math;

/// <summary>
/// MathEx
/// </summary>
[SuppressMessage("Minor Code Smell", "S4136:Method overloads should be grouped together", Justification = "OK.")]
[SuppressMessage("Naming", "CA1711:Identifiers should not have incorrect suffix", Justification = "OK.")]
public static class MathEx
{
    /// <summary>
    /// Find greatest common divisor.
    /// </summary>
    /// <param name="v1">The v1.</param>
    /// <param name="v2">The v2.</param>
    public static int GreatestCommonDivisor(int v1, int v2)
    {
        // Take absolute values
        if (v1 < 0)
        {
            v1 = -v1;
        }

        if (v2 < 0)
        {
            v2 = -v2;
        }

        do
        {
            if (v1 < v2)
            {
                v2 = Interlocked.Exchange(ref v1, v2); // swap the two operands
            }

            v1 %= v2;
        }
        while (v1 != 0);

        return v2;
    }

    /// <summary>
    /// Find greatest common divisor.
    /// </summary>
    /// <param name="v1">The v1.</param>
    /// <param name="v2">The v2.</param>
    public static double GreatestCommonDivisor(double v1, double v2)
    {
        var maxDecimalPoints = System.Math.Max(
            v1.CountDecimalPoints(),
            v2.CountDecimalPoints());

        var v1Int = (int)v1;
        var v2Int = (int)v2;

        if (maxDecimalPoints > 0)
        {
            v1Int = (int)(v1 * maxDecimalPoints * 10);
            v2Int = (int)(v2 * maxDecimalPoints * 10);
        }

        var greatestCommonIntDivisor = (double)GreatestCommonDivisor(v1Int, v2Int);
        return maxDecimalPoints > 0
            ? greatestCommonIntDivisor / (maxDecimalPoints * 10)
            : greatestCommonIntDivisor;
    }

    /// <summary>
    /// Gets divisors for <paramref name="value"/> that is less than or equal to the specified <paramref name="max"/> value.
    /// </summary>
    /// <param name="value">The value to get divisors of.</param>
    /// <param name="max">The maximum divisor threshold.</param>
    public static IEnumerable<int> GetDivisorsLessThanOrEqual(int value, int max)
    {
        if (value < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(value), value, $"{nameof(value)} cannot be less than 1.");
        }

        if (max < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(max), max, $"{nameof(max)} cannot be less than 1.");
        }

        IEnumerable<int> Iterator()
        {
            int halfMax = System.Math.Min(max, System.Math.Abs(value / 2));
            yield return 1;

            for (int i = 2; i <= halfMax; ++i)
            {
                if (value % i == 0)
                {
                    yield return i;
                }
            }

            if (max != 1 && max >= value)
            {
                yield return value;
            }
        }

        return Iterator();
    }

    /// <summary>
    /// Steps the specified x.
    /// </summary>
    /// <param name="x">The x.</param>
    public static int Step(int x)
    {
        return x < 0 ? 0 : 1;
    }

    /// <summary>
    /// Rects the specified x.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <param name="width">The width.</param>
    /// <param name="height">The height.</param>
    public static int Rect(int x, int width = 1, int height = 1)
    {
        return x < 0 || x >= width ? 0 : height;
    }

    /// <summary>
    /// Associates the input with the result of an operator that takes the path of a loop,
    /// and its next state depends on its past state.
    /// </summary>
    /// <param name="state">Represents the state of the operator.</param>
    /// <param name="x">Represents the input of the operator</param>
    /// <param name="width">Represents the width of the loop</param>
    /// <param name="height">Represents the height of the loop</param>
    public static int Hysteron(ref int state, int x, int width = 1, int height = 1)
    {
        if (x >= width)
        {
            return state = height;
        }

        if (x <= 0)
        {
            return state = 0;
        }

        return state;
    }

    /// <summary>
    /// Ceilings the specified x.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <param name="period">The period.</param>
    public static int Ceiling(int x, int period)
    {
        var n = x / period;
        if (x > 0 && x % period != 0)
        {
            n += 1;
        }

        return n * period;
    }

    /// <summary>
    /// Floors the specified x.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <param name="period">The period.</param>
    public static int Floor(int x, int period)
    {
        var n = x / period;
        if (x < 0 && x % period != 0)
        {
            n -= 1;
        }

        return n * period;
    }

    /// <summary>
    /// Saws the tooth.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <param name="period">The period.</param>
    public static int SawTooth(int x, int period)
    {
        var y = x % period;
        return y < 0 ? y + period : y;
    }

    /// <summary>
    /// Multiplies the specified f.
    /// </summary>
    /// <param name="f">The f.</param>
    /// <param name="g">The g.</param>
    public static Func<int, int> Multiply(Func<int, int> f, Func<int, int> g)
    {
        return x => f(x) * g(x);
    }

    /// <summary>
    /// Composes the specified f.
    /// </summary>
    /// <param name="f">The f.</param>
    /// <param name="g">The g.</param>
    public static Func<int, int> Compose(Func<int, int> f, Func<int, int> g)
    {
        return x => f(g(x));
    }

    /// <summary>
    /// Floors the specified f.
    /// </summary>
    /// <param name="f">The f.</param>
    /// <param name="period">The period.</param>
    public static Func<int, int> Floor(Func<int, int> f, int period)
    {
        return x => f(Floor(x, period));
    }

    /// <summary>
    /// Ceilings the specified f.
    /// </summary>
    /// <param name="f">The f.</param>
    /// <param name="period">The period.</param>
    public static Func<int, int> Ceiling(Func<int, int> f, int period)
    {
        return x => f(Ceiling(x, period));
    }

    /// <summary>
    /// Periodics the specified f.
    /// </summary>
    /// <param name="f">The f.</param>
    /// <param name="period">The period.</param>
    public static Func<int, int> Periodic(Func<int, int> f, int period)
    {
        return x => f(SawTooth(x, period));
    }

    /// <summary>
    /// Modulates the specified carrier.
    /// </summary>
    /// <param name="carrier">The carrier.</param>
    /// <param name="cellFunction">The cell function.</param>
    /// <param name="period">The period.</param>
    public static Func<int, int> Modulate(Func<int, int> carrier, Func<int, int> cellFunction, int period)
    {
        return x =>
        {
            var n0 = Floor(carrier, period)(x);
            var n1 = Floor(carrier, period)(x + period);

            // ReSharper disable once StyleCop.SA1407
            return n0 + ((n1 - n0) * Periodic(cellFunction, period)(x));
        };
    }
}