// ReSharper disable once CheckNamespace
namespace Atc;

/// <summary>
/// Provides equality comparison for tuples by comparing both items.
/// Two tuples are considered equal if both Item1 and Item2 are equal.
/// </summary>
/// <typeparam name="T1">The type of the first item in the tuple.</typeparam>
/// <typeparam name="T2">The type of the second item in the tuple.</typeparam>
public class TupleEqualityComparer<T1, T2> : EqualityComparer<Tuple<T1, T2>>
{
    /// <summary>
    /// Determines whether two tuples are equal by comparing both items.
    /// </summary>
    /// <param name="x">The first tuple to compare.</param>
    /// <param name="y">The second tuple to compare.</param>
    /// <returns><c>true</c> if both Item1 and Item2 of the tuples are equal; otherwise, <c>false</c>.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="x"/> or <paramref name="y"/> is null.</exception>
    public override bool Equals(Tuple<T1, T2>? x, Tuple<T1, T2>? y)
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
    /// Returns a hash code for the specified tuple by combining the hash codes of both items.
    /// </summary>
    /// <param name="obj">The tuple for which to generate a hash code.</param>
    /// <returns>A hash code calculated from both items in the tuple.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="obj"/> is null.</exception>
    public override int GetHashCode(Tuple<T1, T2> obj)
    {
        if (obj is null)
        {
            throw new ArgumentNullException(nameof(obj));
        }

        return obj.Item1!.GetHashCode() + obj.Item2!.GetHashCode();
    }
}