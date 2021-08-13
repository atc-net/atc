<div style='text-align: right'>

[References](Index.md)&nbsp;&nbsp;-&nbsp;&nbsp;[References extended](IndexExtended.md)
</div>

# Atc.Math

<br />


## MathEx
MathEx


```csharp
public static class MathEx
```

### Static Methods


#### Ceiling

```csharp
int Ceiling(int x, int period)
```
<p><b>Summary:</b> Ceilings the specified x.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`x`&nbsp;&nbsp;-&nbsp;&nbsp;The x.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`period`&nbsp;&nbsp;-&nbsp;&nbsp;The period.<br />
#### Ceiling

```csharp
Func<int, int> Ceiling(Func<int, int> f, int period)
```
<p><b>Summary:</b> Ceilings the specified x.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`x`&nbsp;&nbsp;-&nbsp;&nbsp;The x.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`period`&nbsp;&nbsp;-&nbsp;&nbsp;The period.<br />
#### Compose

```csharp
Func<int, int> Compose(Func<int, int> f, Func<int, int> g)
```
<p><b>Summary:</b> Composes the specified f.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`f`&nbsp;&nbsp;-&nbsp;&nbsp;The f.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`g`&nbsp;&nbsp;-&nbsp;&nbsp;The g.<br />
#### Floor

```csharp
int Floor(int x, int period)
```
<p><b>Summary:</b> Floors the specified x.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`x`&nbsp;&nbsp;-&nbsp;&nbsp;The x.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`period`&nbsp;&nbsp;-&nbsp;&nbsp;The period.<br />
#### Floor

```csharp
Func<int, int> Floor(Func<int, int> f, int period)
```
<p><b>Summary:</b> Floors the specified x.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`x`&nbsp;&nbsp;-&nbsp;&nbsp;The x.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`period`&nbsp;&nbsp;-&nbsp;&nbsp;The period.<br />
#### GetDivisorsLessThanOrEqual

```csharp
IEnumerable<int> GetDivisorsLessThanOrEqual(int value, int max)
```
<p><b>Summary:</b> Gets divisors for `value` that is less than or equal to the specified `max` value.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value to get divisors of.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`max`&nbsp;&nbsp;-&nbsp;&nbsp;The maximum divisor threshold.<br />
#### GreatestCommonDivisor

```csharp
int GreatestCommonDivisor(int v1, int v2)
```
<p><b>Summary:</b> Find greatest common divisor.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`v1`&nbsp;&nbsp;-&nbsp;&nbsp;The v1.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`v2`&nbsp;&nbsp;-&nbsp;&nbsp;The v2.<br />
#### GreatestCommonDivisor

```csharp
double GreatestCommonDivisor(double v1, double v2)
```
<p><b>Summary:</b> Find greatest common divisor.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`v1`&nbsp;&nbsp;-&nbsp;&nbsp;The v1.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`v2`&nbsp;&nbsp;-&nbsp;&nbsp;The v2.<br />
#### Hysteron

```csharp
int Hysteron(ref int state, int x, int width = 1, int height = 1)
```
<p><b>Summary:</b> Associates the input with the result of an operator that takes the path of a loop, and its next state depends on its past state.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`state`&nbsp;&nbsp;-&nbsp;&nbsp;Represents the state of the operator.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`x`&nbsp;&nbsp;-&nbsp;&nbsp;Represents the input of the operator<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`width`&nbsp;&nbsp;-&nbsp;&nbsp;Represents the width of the loop<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`height`&nbsp;&nbsp;-&nbsp;&nbsp;Represents the height of the loop<br />
#### Modulate

```csharp
Func<int, int> Modulate(Func<int, int> carrier, Func<int, int> cellFunction, int period)
```
<p><b>Summary:</b> Modulates the specified carrier.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`carrier`&nbsp;&nbsp;-&nbsp;&nbsp;The carrier.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`cellFunction`&nbsp;&nbsp;-&nbsp;&nbsp;The cell function.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`period`&nbsp;&nbsp;-&nbsp;&nbsp;The period.<br />
#### Multiply

```csharp
Func<int, int> Multiply(Func<int, int> f, Func<int, int> g)
```
<p><b>Summary:</b> Multiplies the specified f.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`f`&nbsp;&nbsp;-&nbsp;&nbsp;The f.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`g`&nbsp;&nbsp;-&nbsp;&nbsp;The g.<br />
#### Periodic

```csharp
Func<int, int> Periodic(Func<int, int> f, int period)
```
<p><b>Summary:</b> Periodics the specified f.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`f`&nbsp;&nbsp;-&nbsp;&nbsp;The f.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`period`&nbsp;&nbsp;-&nbsp;&nbsp;The period.<br />
#### Rect

```csharp
int Rect(int x, int width = 1, int height = 1)
```
<p><b>Summary:</b> Rects the specified x.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`x`&nbsp;&nbsp;-&nbsp;&nbsp;The x.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`width`&nbsp;&nbsp;-&nbsp;&nbsp;The width.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`height`&nbsp;&nbsp;-&nbsp;&nbsp;The height.<br />
#### SawTooth

```csharp
int SawTooth(int x, int period)
```
<p><b>Summary:</b> Saws the tooth.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`x`&nbsp;&nbsp;-&nbsp;&nbsp;The x.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`period`&nbsp;&nbsp;-&nbsp;&nbsp;The period.<br />
#### Step

```csharp
int Step(int x)
```
<p><b>Summary:</b> Steps the specified x.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`x`&nbsp;&nbsp;-&nbsp;&nbsp;The x.<br />
<hr /><div style='text-align: right'><i>Generated by MarkdownCodeDoc version 1.2</i></div>
