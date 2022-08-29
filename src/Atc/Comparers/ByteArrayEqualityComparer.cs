// ReSharper disable once CheckNamespace
// ReSharper disable LoopCanBeConvertedToQuery
// ReSharper disable ForCanBeConvertedToForeach
namespace Atc;

/// <summary>
/// ByteArrayEqualityComparer.
/// </summary>
[SuppressMessage("StyleCop.CSharp.SpacingRules", "SA1011:Closing square brackets should be spaced correctly", Justification = "OK.")]
public class ByteArrayEqualityComparer : IEqualityComparer<byte[]>
{
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