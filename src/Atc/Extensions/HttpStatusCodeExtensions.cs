// ReSharper disable once CheckNamespace
namespace System.Net
{
    public static class HttpStatusCodeExtensions
    {
        public static string ToNormalizedString(this HttpStatusCode httpStatusCode)
        {
            return httpStatusCode switch
            {
                HttpStatusCode.OK => "Ok",
                HttpStatusCode.IMUsed => "ImUsed",
                _ => httpStatusCode.ToString()
            };
        }
    }
}