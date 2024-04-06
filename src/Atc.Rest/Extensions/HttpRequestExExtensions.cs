// ReSharper disable CheckNamespace
namespace Microsoft.AspNetCore.Http;

public static class HttpRequestExExtensions
{
    /// <summary>
    /// Retrieve the raw body as a string from the Request.Body stream
    /// </summary>
    /// <param name="request">Request instance to applies to</param>
    /// <param name="encoding">Optional - Encoding, defaults to UTF8</param>
    public static async Task<string> GetRawBodyStringAsync(
        this HttpRequest request,
        Encoding? encoding = null)
    {
        ArgumentNullException.ThrowIfNull(request);

        encoding ??= Encoding.UTF8;

        using var reader = new StreamReader(request.Body, encoding);
        return await reader.ReadToEndAsync();
    }

    /// <summary>
    /// Retrieves the raw body as a byte array from the Request.Body stream
    /// </summary>
    /// <param name="request">Request instance to applies to</param>
    public static async Task<byte[]> GetRawBodyBytesAsync(
        this HttpRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);

        using var ms = new MemoryStream(2048);
        await request.Body.CopyToAsync(ms);
        return ms.ToArray();
    }
}