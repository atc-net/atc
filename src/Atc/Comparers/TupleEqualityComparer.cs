// ReSharper disable once CheckNamespace
namespace Atc;

/// <summary>
/// TupleEqualityComparer.
/// </summary>
/// <typeparam name="T1">The type of the 1.</typeparam>
/// <typeparam name="T2">The type of the 2.</typeparam>
public class TupleEqualityComparer<T1, T2> : EqualityComparer<Tuple<T1, T2>>
{
    /// <summary>
    /// When overridden in a derived class, determines whether two objects of type are equal.
    /// </summary>
    /// <param name="x">The first object to compare.</param>
    /// <param name="y">The second object to compare.</param>
    /// <returns>
    /// true if the specified objects are equal; otherwise, false.
    /// </returns>
    public override bool Equals(Tuple<T1, T2> x, Tuple<T1, T2> y)
    {
        if (x is null)
        {
            throw new ArgumentNullException(nameof(x));
        }

        if (y is null)
        {
            throw new ArgumentNullException(nameof(y));
        }

        return x.Item1!.Equals(y.Item1) && x.Item2!.Equals(y.Item2);
    }

    /// <summary>
    /// Returns a hash code for this instance.
    /// </summary>
    /// <param name="obj">The object.</param>
    /// <returns>
    /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
    /// </returns>
    public override int GetHashCode(Tuple<T1, T2> obj)
    {
        if (obj is null)
        {
            throw new ArgumentNullException(nameof(obj));
        }

        return obj.Item1!.GetHashCode() + obj.Item2!.GetHashCode();
    }
}