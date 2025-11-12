<div style='text-align: right'>

[References](Index.md)&nbsp;&nbsp;-&nbsp;&nbsp;[References extended](IndexExtended.md)
</div>

# System.Collections.Generic

<br />

## DictionaryExtensions
Provides extension methods for working with `System.Collections.Generic.Dictionary`2`. These methods enhance dictionary functionality with efficient retrieval, addition, and updating of values.

>```csharp
>public static class DictionaryExtensions
>```

### Static Methods

#### GetOrAdd
>```csharp
>TValue GetOrAdd(this Dictionary<TKey, TValue> dict, TKey key, TValue value)
>```
><b>Summary:</b> Retrieves the value associated with the specified key or adds a new value if the key does not exist.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`dict`&nbsp;&nbsp;-&nbsp;&nbsp;The dictionary instance.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`key`&nbsp;&nbsp;-&nbsp;&nbsp;The key whose value to get or add.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value to add if the key does not exist.<br />
>
><b>Returns:</b> The existing or newly added value.
#### GetOrAdd
>```csharp
>TValue GetOrAdd(this Dictionary<TKey, TValue> dict, TKey key, Func<TKey, TValue> valueFactory)
>```
><b>Summary:</b> Retrieves the value associated with the specified key or adds a new value if the key does not exist.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`dict`&nbsp;&nbsp;-&nbsp;&nbsp;The dictionary instance.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`key`&nbsp;&nbsp;-&nbsp;&nbsp;The key whose value to get or add.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The value to add if the key does not exist.<br />
>
><b>Returns:</b> The existing or newly added value.
#### TryUpdate
>```csharp
>bool TryUpdate(this Dictionary<TKey, TValue> dict, TKey key, TValue value)
>```
><b>Summary:</b> Attempts to update the value of an existing key in the dictionary.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`dict`&nbsp;&nbsp;-&nbsp;&nbsp;The dictionary instance.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`key`&nbsp;&nbsp;-&nbsp;&nbsp;The key whose value should be updated.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The new value to assign.<br />
>
><b>Returns:</b> `true` if the key exists and the value was updated; otherwise, `false`.
#### TryUpdate
>```csharp
>bool TryUpdate(this Dictionary<TKey, TValue> dict, TKey key, Func<TKey, TValue, TValue> valueFactory)
>```
><b>Summary:</b> Attempts to update the value of an existing key in the dictionary.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`dict`&nbsp;&nbsp;-&nbsp;&nbsp;The dictionary instance.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`key`&nbsp;&nbsp;-&nbsp;&nbsp;The key whose value should be updated.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`value`&nbsp;&nbsp;-&nbsp;&nbsp;The new value to assign.<br />
>
><b>Returns:</b> `true` if the key exists and the value was updated; otherwise, `false`.

<br />

## EnumerableExtensions
Provides extension methods for asynchronous enumeration of collections.

>```csharp
>public static class EnumerableExtensions
>```

### Static Methods

#### CountAsync
>```csharp
>Task<int> CountAsync(this IEnumerable<T> source, CancellationToken cancellationToken = null)
>```
><b>Summary:</b> Asynchronously counts the elements in a sequence.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`source`&nbsp;&nbsp;-&nbsp;&nbsp;The source sequence to count.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`cancellationToken`&nbsp;&nbsp;-&nbsp;&nbsp;A  to observe while waiting for the asynchronous operation to complete.<br />
>
><b>Returns:</b> A task that represents the asynchronous operation. The task result contains the number of elements in the sequence.
#### SelectToArray
>```csharp
>TResult[] SelectToArray(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
>```
><b>Summary:</b> Projects each element of a sequence into a new form and returns the results as an array.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`source`&nbsp;&nbsp;-&nbsp;&nbsp;The sequence of elements to transform.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`selector`&nbsp;&nbsp;-&nbsp;&nbsp;A transform function to apply to each element.<br />
>
><b>Returns:</b> An array containing the transformed elements from the source sequence.
>
><b>Remarks:</b> This is a convenience method that combines `System.Linq.Enumerable.Select``2(System.Collections.Generic.IEnumerable{``0},System.Func{``0,``1})` and `System.Linq.Enumerable.ToArray``1(System.Collections.Generic.IEnumerable{``0})`.
#### SelectToList
>```csharp
>List<TResult> SelectToList(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
>```
><b>Summary:</b> Projects each element of a sequence into a new form and returns the results as a `System.Collections.Generic.List`1`.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`source`&nbsp;&nbsp;-&nbsp;&nbsp;The sequence of elements to transform.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`selector`&nbsp;&nbsp;-&nbsp;&nbsp;A transform function to apply to each element.<br />
>
><b>Returns:</b> A `System.Collections.Generic.List`1` containing the transformed elements from the source sequence.
>
><b>Remarks:</b> This is a convenience method that combines `System.Linq.Enumerable.Select``2(System.Collections.Generic.IEnumerable{``0},System.Func{``0,``1})` and `System.Linq.Enumerable.ToList``1(System.Collections.Generic.IEnumerable{``0})`.
#### ToAsyncEnumerable
>```csharp
>IAsyncEnumerable<T> ToAsyncEnumerable(this IEnumerable<T> source, CancellationToken cancellationToken = null)
>```
><b>Summary:</b> Converts an `System.Collections.Generic.IEnumerable`1` to an `System.Collections.Generic.IAsyncEnumerable`1`.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`source`&nbsp;&nbsp;-&nbsp;&nbsp;The source sequence to convert.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`cancellationToken`&nbsp;&nbsp;-&nbsp;&nbsp;A  to observe while waiting for the asynchronous operation to complete.<br />
>
><b>Returns:</b> An `System.Collections.Generic.IAsyncEnumerable`1` that contains the elements from the input sequence.
#### ToListAsync
>```csharp
>Task<List<T>> ToListAsync(this IEnumerable<T> source, CancellationToken cancellationToken = null)
>```
><b>Summary:</b> Asynchronously creates a `System.Collections.Generic.List`1` from an `System.Collections.Generic.IEnumerable`1`.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`source`&nbsp;&nbsp;-&nbsp;&nbsp;The source sequence to convert to a list.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`cancellationToken`&nbsp;&nbsp;-&nbsp;&nbsp;A  to observe while waiting for the asynchronous operation to complete.<br />
>
><b>Returns:</b> A task that represents the asynchronous operation. The task result contains a list with the elements from the input sequence.

<br />

## ReadOnlyListExtensions

>```csharp
>public static class ReadOnlyListExtensions
>```

### Static Methods

#### GetPowerSet
>```csharp
>IEnumerable<IEnumerable<T>> GetPowerSet(this IReadOnlyList<T> list)
>```
#### GetUniqueCombinations
>```csharp
>IEnumerable<IEnumerable<string>> GetUniqueCombinations(this IReadOnlyList<string> list)
>```
#### GetUniqueCombinationsAsCommaSeparated
>```csharp
>IEnumerable<string> GetUniqueCombinationsAsCommaSeparated(this IReadOnlyList<string> list)
>```
<hr /><div style='text-align: right'><i>Generated by MarkdownCodeDoc version 1.2</i></div>
