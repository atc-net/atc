// ReSharper disable once CheckNamespace
// ReSharper disable LoopCanBeConvertedToQuery
// ReSharper disable ForCanBeConvertedToForeach
namespace Atc;

/// <summary>
/// Provides equality comparison for byte arrays based on their content.
/// Two byte arrays are considered equal if they have the same length and all corresponding bytes are equal.
/// </summary>
[SuppressMessage("StyleCop.CSharp.SpacingRules", "SA1011:Closing square brackets should be spaced correctly", Justification = "OK.")]
public class ByteArrayEqualityComparer : IEqualityComparer<byte[]>
{
    /// <summary>
    /// Determines whether two byte arrays are equal by comparing their contents.
    /// </summary>
    /// <param name="x">The first byte array to compare.</param>
    /// <param name="y">The second byte array to compare.</param>
    /// <returns><c>true</c> if the byte arrays have the same length and all corresponding bytes are equal; otherwise, <c>false</c>.</returns>
    public bool Equals(
        byte[]? x,
        byte[]? y)
    {
        if (ReferenceEquals(x, y))
        {
            return true;
        }

        if (x == null || y == null)
        {
            return false;
        }

        if (x.Length != y.Length)
        {
            return false;
        }

        for (var i = 0; i < x.Length; i++)
        {
            if (x[i] != y[i])
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// Returns a hash code for the specified byte array based on its content.
    /// </summary>
    /// <param name="obj">The byte array for which to generate a hash code.</param>
    /// <returns>A hash code for the byte array, or 0 if the array is null.</returns>
    public int GetHashCode(
        byte[]? obj)
    {
        if (obj is null)
        {
            return 0;
        }

        var result = 13 * obj.Length;
        for (var i = 0; i < obj.Length; i++)
        {
            result = (17 * result) + obj[i];
        }

        return result;
    }
}