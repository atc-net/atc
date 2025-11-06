<div style='text-align: right'>

[References](Index.md)&nbsp;&nbsp;-&nbsp;&nbsp;[References extended](IndexExtended.md)
</div>

# Atc.Math

<br />

## MathEx
Provides extended mathematical operations including number theory, signal processing, and functional programming utilities.

>```csharp
>public static class MathEx
>```

### Static Methods

#### Ceiling
>```csharp
>int Ceiling(int x, int period)
>```
><b>Summary:</b> Rounds a value up to the nearest multiple of a specified period.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`x`&nbsp;&nbsp;-&nbsp;&nbsp;The value to round.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`period`&nbsp;&nbsp;-&nbsp;&nbsp;The period (interval) to round to.<br />
>
><b>Returns:</b> The smallest multiple of `period` that is greater than or equal to `x`.
#### Ceiling
>```csharp
>Func<int, int> Ceiling(Func<int, int> f, int period)
>```
><b>Summary:</b> Rounds a value up to the nearest multiple of a specified period.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`x`&nbsp;&nbsp;-&nbsp;&nbsp;The value to round.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`period`&nbsp;&nbsp;-&nbsp;&nbsp;The period (interval) to round to.<br />
>
><b>Returns:</b> The smallest multiple of `period` that is greater than or equal to `x`.
#### Compose
>```csharp
>Func<int, int> Compose(Func<int, int> f, Func<int, int> g)
>```
><b>Summary:</b> Creates a new function that represents the composition of two functions.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`f`&nbsp;&nbsp;-&nbsp;&nbsp;The outer function.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`g`&nbsp;&nbsp;-&nbsp;&nbsp;The inner function.<br />
>
><b>Returns:</b> A function that returns `f(g(x))` for any input `x`.
#### Floor
>```csharp
>int Floor(int x, int period)
>```
><b>Summary:</b> Rounds a value down to the nearest multiple of a specified period.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`x`&nbsp;&nbsp;-&nbsp;&nbsp;The value to round.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`period`&nbsp;&nbsp;-&nbsp;&nbsp;The period (interval) to round to.<br />
>
><b>Returns:</b> The largest multiple of `period` that is less than or equal to `x`.
#### Floor
>```csharp
>Func<int, int> Floor(Func<int, int> f, int period)
>```
><b>Summary:</b> Rounds a value down to the nearest multiple of a specified period.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`x`&nbsp;&nbsp;-&nbsp;&nbsp;The value to round.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`period`&nbsp;&nbsp;-&nbsp;&nbsp;The period (interval) to round to.<br />
>
><b>Returns:</b> The largest multiple of `period` that is less than or equal to `x`.
#### GetDivisorsLessThanOrEqual
>```csharp
>IEnumerable<int> GetDivisorsLessThanOrEqual(int value, int max)
>```
><b>Summary:</b> Gets divisors for `value` that is less than or equal to the specified `max` value.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value to get divisors of.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`max`&nbsp;&nbsp;-&nbsp;&nbsp;The maximum divisor threshold.<br />
#### GreatestCommonDivisor
>```csharp
>int GreatestCommonDivisor(int v1, int v2)
>```
><b>Summary:</b> Calculates the greatest common divisor (GCD) of two integers using Euclid's algorithm.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`v1`&nbsp;&nbsp;-&nbsp;&nbsp;The first integer value.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`v2`&nbsp;&nbsp;-&nbsp;&nbsp;The second integer value.<br />
>
><b>Returns:</b> The greatest common divisor of `v1` and `v2`.
#### GreatestCommonDivisor
>```csharp
>double GreatestCommonDivisor(double v1, double v2)
>```
><b>Summary:</b> Calculates the greatest common divisor (GCD) of two integers using Euclid's algorithm.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`v1`&nbsp;&nbsp;-&nbsp;&nbsp;The first integer value.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`v2`&nbsp;&nbsp;-&nbsp;&nbsp;The second integer value.<br />
>
><b>Returns:</b> The greatest common divisor of `v1` and `v2`.
#### Hysteron
>```csharp
>int Hysteron(ref int state, int x, int width = 1, int height = 1)
>```
><b>Summary:</b> Implements a hysteresis (hysteron) operator where the output depends on both current input and previous state.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`state`&nbsp;&nbsp;-&nbsp;&nbsp;The current state of the operator, which is updated based on the input.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`x`&nbsp;&nbsp;-&nbsp;&nbsp;The input value.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`width`&nbsp;&nbsp;-&nbsp;&nbsp;The upper threshold. When input reaches or exceeds this value, state becomes . Default is 1.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`height`&nbsp;&nbsp;-&nbsp;&nbsp;The maximum output value. Default is 1.<br />
>
><b>Returns:</b> The updated state value.
>
><b>Remarks:</b> This function maintains state between calls, implementing memory-like behavior common in control systems.
#### Modulate
>```csharp
>Func<int, int> Modulate(Func<int, int> carrier, Func<int, int> cellFunction, int period)
>```
><b>Summary:</b> Creates a modulated function by combining a carrier function with a cell function.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`carrier`&nbsp;&nbsp;-&nbsp;&nbsp;The carrier function that provides the base signal.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`cellFunction`&nbsp;&nbsp;-&nbsp;&nbsp;The cell function that modulates the carrier within each period.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`period`&nbsp;&nbsp;-&nbsp;&nbsp;The modulation period.<br />
>
><b>Returns:</b> A function representing the modulated signal.
>
><b>Remarks:</b> This implements a form of amplitude modulation where the carrier is sampled at period boundaries and interpolated using the cell function.
#### Multiply
>```csharp
>Func<int, int> Multiply(Func<int, int> f, Func<int, int> g)
>```
><b>Summary:</b> Creates a new function that multiplies the results of two functions pointwise.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`f`&nbsp;&nbsp;-&nbsp;&nbsp;The first function.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`g`&nbsp;&nbsp;-&nbsp;&nbsp;The second function.<br />
>
><b>Returns:</b> A function that returns `f(x) * g(x)` for any input `x`.
#### Periodic
>```csharp
>Func<int, int> Periodic(Func<int, int> f, int period)
>```
><b>Summary:</b> Creates a periodic version of a function by applying sawtooth wrapping to its input.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`f`&nbsp;&nbsp;-&nbsp;&nbsp;The function to make periodic.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`period`&nbsp;&nbsp;-&nbsp;&nbsp;The period of repetition.<br />
>
><b>Returns:</b> A function that repeats `f` every `period` units.
#### Rect
>```csharp
>int Rect(int x, int width = 1, int height = 1)
>```
><b>Summary:</b> Implements a rectangular (pulse) function that returns a specified height within a defined width, otherwise 0.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`x`&nbsp;&nbsp;-&nbsp;&nbsp;The input value.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`width`&nbsp;&nbsp;-&nbsp;&nbsp;The width of the rectangular pulse. Default is 1.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`height`&nbsp;&nbsp;-&nbsp;&nbsp;The height of the rectangular pulse. Default is 1.<br />
>
><b>Returns:</b> `height` if `x` is within [0, `width`); otherwise, 0.
#### SawTooth
>```csharp
>int SawTooth(int x, int period)
>```
><b>Summary:</b> Generates a sawtooth wave pattern with a specified period.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`x`&nbsp;&nbsp;-&nbsp;&nbsp;The input value.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`period`&nbsp;&nbsp;-&nbsp;&nbsp;The period of the sawtooth wave.<br />
>
><b>Returns:</b> A value in the range [0, `period`) that repeats in a sawtooth pattern.
#### Step
>```csharp
>int Step(int x)
>```
><b>Summary:</b> Implements a step function (Heaviside step function) that returns 0 for negative values and 1 for non-negative values.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`x`&nbsp;&nbsp;-&nbsp;&nbsp;The input value.<br />
>
><b>Returns:</b> 0 if `x` is negative; otherwise, 1.
<hr /><div style='text-align: right'><i>Generated by MarkdownCodeDoc version 1.2</i></div>
