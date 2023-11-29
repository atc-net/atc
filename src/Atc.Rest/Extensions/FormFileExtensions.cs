// ReSharper disable CheckNamespace
namespace Microsoft.AspNetCore.Http;

public static class FormFileExtensions
{
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