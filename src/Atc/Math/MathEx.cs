// ReSharper disable CommentTypo
namespace Atc.Math;

/// <summary>
/// Provides extended mathematical operations including number theory, signal processing, and functional programming utilities.
/// </summary>
[SuppressMessage("Minor Code Smell", "S4136:Method overloads should be grouped together", Justification = "OK.")]
[SuppressMessage("Naming", "CA1711:Identifiers should not have incorrect suffix", Justification = "OK.")]
public static class MathEx
{
    /// <summary>
    /// Calculates the greatest common divisor (GCD) of two integers using Euclid's algorithm.
    /// </summary>
    /// <param name="v1">The first integer value.</param>
    /// <param name="v2">The second integer value.</param>
    /// <returns>The greatest common divisor of <paramref name="v1"/> and <paramref name="v2"/>.</returns>
    public static int GreatestCommonDivisor(
        int v1,
        int v2)
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
    /// Calculates the greatest common divisor (GCD) of two double-precision floating-point numbers.
    /// </summary>
    /// <param name="v1">The first double value.</param>
    /// <param name="v2">The second double value.</param>
    /// <returns>The greatest common divisor of <paramref name="v1"/> and <paramref name="v2"/>.</returns>
    /// <remarks>
    /// This method converts the decimal portions to integers by scaling based on decimal precision before applying the GCD algorithm.
    /// </remarks>
    public static double GreatestCommonDivisor(
        double v1,
        double v2)
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
    public static IEnumerable<int> GetDivisorsLessThanOrEqual(
        int value,
        int max)
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
    /// Implements a step function (Heaviside step function) that returns 0 for negative values and 1 for non-negative values.
    /// </summary>
    /// <param name="x">The input value.</param>
    /// <returns>0 if <paramref name="x"/> is negative; otherwise, 1.</returns>
    public static int Step(int x)
    {
        return x < 0 ? 0 : 1;
    }

    /// <summary>
    /// Implements a rectangular (pulse) function that returns a specified height within a defined width, otherwise 0.
    /// </summary>
    /// <param name="x">The input value.</param>
    /// <param name="width">The width of the rectangular pulse. Default is 1.</param>
    /// <param name="height">The height of the rectangular pulse. Default is 1.</param>
    /// <returns><paramref name="height"/> if <paramref name="x"/> is within [0, <paramref name="width"/>); otherwise, 0.</returns>
    public static int Rect(
        int x,
        int width = 1,
        int height = 1)
    {
        return x < 0 || x >= width ? 0 : height;
    }

    /// <summary>
    /// Implements a hysteresis (hysteron) operator where the output depends on both current input and previous state.
    /// </summary>
    /// <param name="state">The current state of the operator, which is updated based on the input.</param>
    /// <param name="x">The input value.</param>
    /// <param name="width">The upper threshold. When input reaches or exceeds this value, state becomes <paramref name="height"/>. Default is 1.</param>
    /// <param name="height">The maximum output value. Default is 1.</param>
    /// <returns>The updated state value.</returns>
    /// <remarks>
    /// This function maintains state between calls, implementing memory-like behavior common in control systems.
    /// </remarks>
    public static int Hysteron(
        ref int state,
        int x,
        int width = 1,
        int height = 1)
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
    /// Rounds a value up to the nearest multiple of a specified period.
    /// </summary>
    /// <param name="x">The value to round.</param>
    /// <param name="period">The period (interval) to round to.</param>
    /// <returns>The smallest multiple of <paramref name="period"/> that is greater than or equal to <paramref name="x"/>.</returns>
    public static int Ceiling(
        int x,
        int period)
    {
        var n = x / period;
        if (x > 0 && x % period != 0)
        {
            n += 1;
        }

        return n * period;
    }

    /// <summary>
    /// Rounds a value down to the nearest multiple of a specified period.
    /// </summary>
    /// <param name="x">The value to round.</param>
    /// <param name="period">The period (interval) to round to.</param>
    /// <returns>The largest multiple of <paramref name="period"/> that is less than or equal to <paramref name="x"/>.</returns>
    public static int Floor(
        int x,
        int period)
    {
        var n = x / period;
        if (x < 0 && x % period != 0)
        {
            n -= 1;
        }

        return n * period;
    }

    /// <summary>
    /// Generates a sawtooth wave pattern with a specified period.
    /// </summary>
    /// <param name="x">The input value.</param>
    /// <param name="period">The period of the sawtooth wave.</param>
    /// <returns>A value in the range [0, <paramref name="period"/>) that repeats in a sawtooth pattern.</returns>
    public static int SawTooth(
        int x,
        int period)
    {
        var y = x % period;
        return y < 0 ? y + period : y;
    }

    /// <summary>
    /// Creates a new function that multiplies the results of two functions pointwise.
    /// </summary>
    /// <param name="f">The first function.</param>
    /// <param name="g">The second function.</param>
    /// <returns>A function that returns <c>f(x) * g(x)</c> for any input <c>x</c>.</returns>
    public static Func<int, int> Multiply(
        Func<int, int> f,
        Func<int, int> g)
    {
        return x => f(x) * g(x);
    }

    /// <summary>
    /// Creates a new function that represents the composition of two functions.
    /// </summary>
    /// <param name="f">The outer function.</param>
    /// <param name="g">The inner function.</param>
    /// <returns>A function that returns <c>f(g(x))</c> for any input <c>x</c>.</returns>
    public static Func<int, int> Compose(
        Func<int, int> f,
        Func<int, int> g)
    {
        return x => f(g(x));
    }

    /// <summary>
    /// Creates a quantized version of a function by applying floor quantization to its input.
    /// </summary>
    /// <param name="f">The function to quantize.</param>
    /// <param name="period">The quantization period.</param>
    /// <returns>A function that evaluates <paramref name="f"/> at floor-quantized inputs.</returns>
    public static Func<int, int> Floor(
        Func<int, int> f,
        int period)
    {
        return x => f(Floor(x, period));
    }

    /// <summary>
    /// Creates a quantized version of a function by applying ceiling quantization to its input.
    /// </summary>
    /// <param name="f">The function to quantize.</param>
    /// <param name="period">The quantization period.</param>
    /// <returns>A function that evaluates <paramref name="f"/> at ceiling-quantized inputs.</returns>
    public static Func<int, int> Ceiling(
        Func<int, int> f,
        int period)
    {
        return x => f(Ceiling(x, period));
    }

    /// <summary>
    /// Creates a periodic version of a function by applying sawtooth wrapping to its input.
    /// </summary>
    /// <param name="f">The function to make periodic.</param>
    /// <param name="period">The period of repetition.</param>
    /// <returns>A function that repeats <paramref name="f"/> every <paramref name="period"/> units.</returns>
    public static Func<int, int> Periodic(
        Func<int, int> f,
        int period)
    {
        return x => f(SawTooth(x, period));
    }

    /// <summary>
    /// Creates a modulated function by combining a carrier function with a cell function.
    /// </summary>
    /// <param name="carrier">The carrier function that provides the base signal.</param>
    /// <param name="cellFunction">The cell function that modulates the carrier within each period.</param>
    /// <param name="period">The modulation period.</param>
    /// <returns>A function representing the modulated signal.</returns>
    /// <remarks>
    /// This implements a form of amplitude modulation where the carrier is sampled at period boundaries
    /// and interpolated using the cell function.
    /// </remarks>
    public static Func<int, int> Modulate(
        Func<int, int> carrier,
        Func<int, int> cellFunction,
        int period)
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