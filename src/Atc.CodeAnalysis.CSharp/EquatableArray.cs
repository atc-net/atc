namespace Atc.CodeAnalysis.CSharp;

/// <summary>
/// An immutable array with value-based equality, for models that flow through an incremental source generator pipeline.
/// </summary>
/// <remarks>
/// Roslyn's incremental pipeline compares the output of each step with the previous run to decide whether the
/// following steps must run again. <see cref="ImmutableArray{T}"/> compares by reference, so a model holding one
/// is never equal to the model from the previous run, and the cache never hits. <see cref="EquatableArray{T}"/>
/// compares element by element instead.
/// <para>
/// A <see langword="default"/> instance behaves as an empty array, and <see langword="null"/> elements are allowed.
/// </para>
/// </remarks>
/// <typeparam name="T">The element type, which must implement <see cref="IEquatable{T}"/> so elements compare by value.</typeparam>
public readonly struct EquatableArray<T> : IEquatable<EquatableArray<T>>, IReadOnlyList<T>
    where T : IEquatable<T>
{
    private readonly ImmutableArray<T> values;

    /// <summary>
    /// Initializes a new instance of the <see cref="EquatableArray{T}"/> struct.
    /// </summary>
    /// <param name="values">The elements. A default (uninitialized) <see cref="ImmutableArray{T}"/> is treated as empty.</param>
    public EquatableArray(ImmutableArray<T> values)
    {
        this.values = values.IsDefault
            ? ImmutableArray<T>.Empty
            : values;
    }

    /// <summary>
    /// Gets an empty <see cref="EquatableArray{T}"/>.
    /// </summary>
    [SuppressMessage("Design", "CA1000:Do not declare static members on generic types", Justification = "Mirrors ImmutableArray<T>.Empty.")]
    public static EquatableArray<T> Empty => new(ImmutableArray<T>.Empty);

    /// <summary>
    /// Gets a value indicating whether the array has no elements.
    /// </summary>
    public bool IsEmpty => Values.IsEmpty;

    /// <summary>
    /// Gets the number of elements in the array.
    /// </summary>
    public int Length => Values.Length;

    /// <summary>
    /// Gets the number of elements in the array. Same as <see cref="Length"/>.
    /// </summary>
    public int Count => Values.Length;

    private ImmutableArray<T> Values => values.IsDefault
        ? ImmutableArray<T>.Empty
        : values;

    /// <summary>
    /// Gets the element at the specified index.
    /// </summary>
    /// <param name="index">The zero-based index of the element.</param>
    /// <returns>The element at <paramref name="index"/>.</returns>
    /// <exception cref="IndexOutOfRangeException">Thrown when <paramref name="index"/> is outside the array.</exception>
    public T this[int index] => Values[index];

    /// <summary>
    /// Determines whether two arrays hold equal elements in the same order.
    /// </summary>
    /// <param name="left">The first array.</param>
    /// <param name="right">The second array.</param>
    /// <returns><see langword="true"/> when the arrays are equal; otherwise <see langword="false"/>.</returns>
    public static bool operator ==(
        EquatableArray<T> left,
        EquatableArray<T> right)
        => left.Equals(right);

    /// <summary>
    /// Determines whether two arrays differ in length or in any element.
    /// </summary>
    /// <param name="left">The first array.</param>
    /// <param name="right">The second array.</param>
    /// <returns><see langword="true"/> when the arrays are not equal; otherwise <see langword="false"/>.</returns>
    public static bool operator !=(
        EquatableArray<T> left,
        EquatableArray<T> right)
        => !left.Equals(right);

    /// <summary>
    /// Wraps an <see cref="ImmutableArray{T}"/> in an <see cref="EquatableArray{T}"/>. A default array becomes empty.
    /// </summary>
    /// <param name="values">The array to wrap.</param>
    /// <returns>An <see cref="EquatableArray{T}"/> over the same elements.</returns>
    [SuppressMessage("Usage", "CA2225:Operator overloads have named alternates", Justification = "The named alternate is the ToEquatableArray extension method and the constructor.")]
    public static implicit operator EquatableArray<T>(ImmutableArray<T> values)
        => new(values);

    /// <summary>
    /// Gets the elements as an <see cref="ImmutableArray{T}"/>. The result is never a default (uninitialized) array.
    /// </summary>
    /// <returns>The wrapped elements.</returns>
    public ImmutableArray<T> AsImmutableArray()
        => Values;

    /// <summary>
    /// Determines whether this array holds the same elements, in the same order, as <paramref name="other"/>.
    /// Elements are compared with <see cref="EqualityComparer{T}.Default"/>, so <see langword="null"/> elements are allowed.
    /// </summary>
    /// <param name="other">The array to compare with.</param>
    /// <returns><see langword="true"/> when the arrays are equal; otherwise <see langword="false"/>.</returns>
    public bool Equals(EquatableArray<T> other)
    {
        var left = Values;
        var right = other.Values;
        if (left == right)
        {
            return true;
        }

        if (left.Length != right.Length)
        {
            return false;
        }

        var comparer = EqualityComparer<T>.Default;
        for (var i = 0; i < left.Length; i++)
        {
            if (!comparer.Equals(left[i], right[i]))
            {
                return false;
            }
        }

        return true;
    }

    /// <inheritdoc />
    public override bool Equals(object? obj)
        => obj is EquatableArray<T> other && Equals(other);

    /// <summary>
    /// Returns a hash code computed from the elements, so equal arrays have equal hash codes.
    /// </summary>
    /// <returns>The hash code.</returns>
    public override int GetHashCode()
    {
        var comparer = EqualityComparer<T>.Default;
        unchecked
        {
            var hash = 17;
            foreach (var item in Values)
            {
                hash = (hash * 31) + (item is null ? 0 : comparer.GetHashCode(item));
            }

            return hash;
        }
    }

    /// <summary>
    /// Returns an allocation-free enumerator over the elements.
    /// </summary>
    /// <returns>An <see cref="ImmutableArray{T}.Enumerator"/>.</returns>
    public ImmutableArray<T>.Enumerator GetEnumerator()
        => Values.GetEnumerator();

    /// <inheritdoc />
    IEnumerator<T> IEnumerable<T>.GetEnumerator()
        => ((IEnumerable<T>)Values).GetEnumerator();

    /// <inheritdoc />
    IEnumerator IEnumerable.GetEnumerator()
        => ((IEnumerable)Values).GetEnumerator();
}