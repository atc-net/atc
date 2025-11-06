// ReSharper disable CheckNamespace
namespace Microsoft.AspNetCore.Http;

/// <summary>
/// Extension methods for <see cref="IFormFile"/> to simplify file handling in ASP.NET Core.
/// </summary>
public static class FormFileExtensions
{
    /// <summary>
    /// Converts an uploaded form file to a byte array.
    /// </summary>
    /// <param name="formFile">The form file to convert.</param>
    /// <returns>A task representing the asynchronous operation, containing the file contents as a byte array.</returns>
    public static Task<byte[]> GetBytes(this IFormFile formFile)
    {
        ArgumentNullException.ThrowIfNull(formFile);

        return GetBytesInternalAsync(formFile);
    }

    private static async Task<byte[]> GetBytesInternalAsync(IFormFile formFile)
    {
        await using var memoryStream = new MemoryStream();
        await formFile.CopyToAsync(memoryStream);
        return memoryStream.ToArray();
    }
}