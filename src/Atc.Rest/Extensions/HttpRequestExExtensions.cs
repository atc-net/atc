// ReSharper disable CheckNamespace
namespace Microsoft.AspNetCore.Http;

/// <summary>
/// Extension methods for <see cref="HttpRequest"/> to retrieve raw request body content.
/// </summary>
public static class HttpRequestExExtensions
{
    /// <summary>
    /// Retrieves the raw body as a string from the Request.Body stream.
    /// </summary>
    /// <param name="request">The HTTP request instance.</param>
    /// <param name="encoding">The encoding to use for reading the stream. Defaults to UTF8 if not specified.</param>
    /// <returns>A task representing the asynchronous operation, containing the request body as a string.</returns>
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
    /// Retrieves the raw body as a byte array from the Request.Body stream.
    /// </summary>
    /// <param name="request">The HTTP request instance.</param>
    /// <returns>A task representing the asynchronous operation, containing the request body as a byte array.</returns>
    public static async Task<byte[]> GetRawBodyBytesAsync(
        this HttpRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);

        using var ms = new MemoryStream(2048);
        await request.Body.CopyToAsync(ms);
        return ms.ToArray();
    }
}