// ReSharper disable CheckNamespace
namespace System.Security.Cryptography.X509Certificates;

/// <summary>
/// Provides extension methods for the X509Certificate2 class.
/// </summary>
public static class X509Certificate2Extensions
{
    /// <summary>
    /// Gets the name identifier of the certificate. This can be the FriendlyName, or a substring of the SubjectName.
    /// </summary>
    /// <param name="certificate">The X509Certificate2 object.</param>
    /// <returns>
    /// The FriendlyName of the certificate if not null or empty; otherwise, a substring of the SubjectName starting
    /// from "CN=" if it exists, or the full SubjectName if "CN=" is not found.
    /// </returns>
    public static string GetNameIdentifier(
        this X509Certificate2 certificate)
    {
        if (certificate is null)
        {
            throw new ArgumentNullException(nameof(certificate));
        }

        if (!string.IsNullOrEmpty(certificate.FriendlyName))
        {
            return certificate.FriendlyName;
        }

        if (certificate.SubjectName is null ||
            string.IsNullOrEmpty(certificate.SubjectName.Name))
        {
            return string.Empty;
        }

        const string searchText = "CN=";
        var index = certificate.SubjectName.Name.IndexOf(searchText, StringComparison.OrdinalIgnoreCase);
        return index == -1
            ? certificate.SubjectName.Name
            : certificate.SubjectName.Name[(index + searchText.Length)..];
    }

    /// <summary>
    /// Checks if the certificate is valid. A certificate is considered valid if it is not archived,
    /// the current date is within the certificate's validity period, and it has a non-empty name identifier.
    /// </summary>
    /// <param name="certificate">The X509Certificate2 object.</param>
    /// <returns>
    /// True if the certificate is valid; otherwise, false.
    /// </returns>
    public static bool IsValid(
        this X509Certificate2 certificate)
    {
        if (certificate is null)
        {
            throw new ArgumentNullException(nameof(certificate));
        }

        return !certificate.Archived &&
               DateTime.Now < certificate.NotAfter &&
               DateTime.Now > certificate.NotBefore &&
               !string.IsNullOrEmpty(certificate.GetNameIdentifier());
    }
}