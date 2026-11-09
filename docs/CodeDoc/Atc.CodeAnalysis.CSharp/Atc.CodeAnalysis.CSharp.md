<div style='text-align: right'>

[References](Index.md)&nbsp;&nbsp;-&nbsp;&nbsp;[References extended](IndexExtended.md)
</div>

# Atc.CodeAnalysis.CSharp

<br />

## AtcCodeAnalysisCSharpTypeInitializer

>```csharp
>public class AtcCodeAnalysisCSharpTypeInitializer
>```


<br />

## EnumerableExtensions
Extension methods for `System.Collections.Generic.IEnumerable`1`.

>```csharp
>public static class EnumerableExtensions
>```

### Static Methods

#### ToEquatableArray
>```csharp
>EquatableArray<T> ToEquatableArray(this IEnumerable<T> source)
>```
><b>Summary:</b> Copies the elements into an `Atc.CodeAnalysis.CSharp.EquatableArray`1`, so a model holding them compares by value in an incremental source generator pipeline.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`source`&nbsp;&nbsp;-&nbsp;&nbsp;The elements to copy.<br />
>
><b>Returns:</b> An `Atc.CodeAnalysis.CSharp.EquatableArray`1` with the elements in the same order.

<br />

## EquatableArray&lt;T&gt;
An immutable array with value-based equality, for models that flow through an incremental source generator pipeline.
><b>Remarks:</b> Roslyn's incremental pipeline compares the output of each step with the previous run to decide whether the following steps must run again. `System.Collections.Immutable.ImmutableArray`1` compares by reference, so a model holding one is never equal to the model from the previous run, and the cache never hits. `Atc.CodeAnalysis.CSharp.EquatableArray`1` compares element by element instead. A <see langword="default" /> instance behaves as an empty array, and <see langword="null" /> elements are allowed.

>```csharp
>public struct EquatableArray&lt;T&gt; : IEquatable<EquatableArray<T>>, IReadOnlyList<T>, IReadOnlyCollection<T>, IEnumerable<T>, IEnumerable
>```

### Static Properties

#### Empty
>```csharp
>Empty
>```
><b>Summary:</b> Gets an empty `Atc.CodeAnalysis.CSharp.EquatableArray`1`.
### Properties

#### Count
>```csharp
>Count
>```
><b>Summary:</b> Gets the number of elements in the array. Same as `Atc.CodeAnalysis.CSharp.EquatableArray`1.Length`.
#### IsEmpty
>```csharp
>IsEmpty
>```
><b>Summary:</b> Gets a value indicating whether the array has no elements.
#### Item
>```csharp
>Item
>```
><b>Summary:</b> Gets the element at the specified index.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`index`&nbsp;&nbsp;-&nbsp;&nbsp;The zero-based index of the element.<br />
>
><b>Returns:</b> The element at `index`.
#### Length
>```csharp
>Length
>```
><b>Summary:</b> Gets the number of elements in the array.
### Methods

#### AsImmutableArray
>```csharp
>ImmutableArray<T> AsImmutableArray()
>```
><b>Summary:</b> Gets the elements as an `System.Collections.Immutable.ImmutableArray`1`. The result is never a default (uninitialized) array.
>
><b>Returns:</b> The wrapped elements.
#### Equals
>```csharp
>bool Equals(EquatableArray<T> other)
>```
><b>Summary:</b> Determines whether this array holds the same elements, in the same order, as `other`. Elements are compared with `System.Collections.Generic.EqualityComparer`1.Default`, so <see langword="null" /> elements are allowed.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`other`&nbsp;&nbsp;-&nbsp;&nbsp;The array to compare with.<br />
>
><b>Returns:</b> <see langword="true" /> when the arrays are equal; otherwise <see langword="false" />.
#### Equals
>```csharp
>bool Equals(object obj)
>```
><b>Summary:</b> Determines whether this array holds the same elements, in the same order, as `other`. Elements are compared with `System.Collections.Generic.EqualityComparer`1.Default`, so <see langword="null" /> elements are allowed.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`other`&nbsp;&nbsp;-&nbsp;&nbsp;The array to compare with.<br />
>
><b>Returns:</b> <see langword="true" /> when the arrays are equal; otherwise <see langword="false" />.
#### GetEnumerator
>```csharp
>Enumerator GetEnumerator()
>```
><b>Summary:</b> Returns an allocation-free enumerator over the elements.
>
><b>Returns:</b> An `System.Collections.Immutable.ImmutableArray`1.Enumerator`.
#### GetHashCode
>```csharp
>int GetHashCode()
>```
><b>Summary:</b> Returns a hash code computed from the elements, so equal arrays have equal hash codes.
>
><b>Returns:</b> The hash code.

<br />

## ImmutableArrayExtensions
Extension methods for `System.Collections.Immutable.ImmutableArray`1`.

>```csharp
>public static class ImmutableArrayExtensions
>```

### Static Methods

#### ToEquatableArray
>```csharp
>EquatableArray<T> ToEquatableArray(this ImmutableArray<T> source)
>```
><b>Summary:</b> Wraps the array in an `Atc.CodeAnalysis.CSharp.EquatableArray`1` without copying it, so a model holding it compares by value in an incremental source generator pipeline. A default (uninitialized) array becomes empty.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`source`&nbsp;&nbsp;-&nbsp;&nbsp;The array to wrap.<br />
>
><b>Returns:</b> An `Atc.CodeAnalysis.CSharp.EquatableArray`1` over the same elements.
<hr /><div style='text-align: right'><i>Generated by MarkdownCodeDoc version 1.2</i></div>
