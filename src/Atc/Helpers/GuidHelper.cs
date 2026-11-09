namespace Atc.Helpers;

/// <summary>
/// Helper methods for creating <see cref="Guid"/> values.
/// </summary>
public static class GuidHelper
{
    /// <summary>
    /// Creates a deterministic <see cref="Guid"/> from one or more components: the same components always give the
    /// same <see cref="Guid"/>, so it can serve as a stable id derived from natural keys (e.g. a source system and its id).
    /// </summary>
    /// <remarks>
    /// <para>
    /// The components are joined with '-', encoded as UTF-8 and hashed with SHA-256; the first 16 bytes of the hash
    /// become the <see cref="Guid"/> (via <see cref="Guid(byte[])"/>). The result is stable across platforms and versions
    /// of this library, so it is safe to store.
    /// </para>
    /// <para>
    /// The <see cref="Guid"/> does not carry RFC 4122/9562 version and variant bits, so it is not a standard UUIDv5.
    /// Because the components are joined with '-', ("a-b", "c") and ("a", "b-c") give the same <see cref="Guid"/>;
    /// avoid '-' in components when that matters.
    /// </para>
    /// </remarks>
    /// <param name="components">The ordered components; at least one, none of them <see langword="null"/>.</param>
    /// <returns>The deterministic <see cref="Guid"/>.</returns>
    /// <exception cref="ArgumentException">Thrown when no components are given, or a component is <see langword="null"/>.</exception>
    /// <example>
    /// <code>
    /// var id = GuidHelper.CreateDeterministic("device", "123");
    /// // Always 9174bb27-8d27-375a-3046-9518b6264ddc
    /// </code>
    /// </example>
    public static Guid CreateDeterministic(params string[] components)
    {
        if (components is null || components.Length == 0)
        {
            throw new ArgumentException("At least one component must be provided.", nameof(components));
        }

        if (components.Any(c => c is null))
        {
            throw new ArgumentException("Components cannot be null.", nameof(components));
        }

        var input = Encoding.UTF8.GetBytes(string.Join("-", components));

#if NET5_0_OR_GREATER
        var hash = System.Security.Cryptography.SHA256.HashData(input);
#else
        using var sha256 = System.Security.Cryptography.SHA256.Create();
        var hash = sha256.ComputeHash(input);
#endif

        var guidBytes = new byte[16];
        Array.Copy(hash, guidBytes, guidBytes.Length);
        return new Guid(guidBytes);
    }
}