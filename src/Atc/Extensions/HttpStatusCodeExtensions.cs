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

        public static bool IsInformational(this HttpStatusCode httpStatusCode)
            => (int)httpStatusCode >= 100 && (int)httpStatusCode < 200;

        public static bool IsSuccessful(this HttpStatusCode httpStatusCode)
            => (int)httpStatusCode >= 200 && (int)httpStatusCode < 300;

        public static bool IsRedirects(this HttpStatusCode httpStatusCode)
            => (int)httpStatusCode >= 300 && (int)httpStatusCode < 400;

        public static bool IsClientErrors(this HttpStatusCode httpStatusCode)
            => (int)httpStatusCode >= 400 && (int)httpStatusCode < 500;

        public static bool IsServerErrors(this HttpStatusCode httpStatusCode)
            => (int)httpStatusCode >= 500 && (int)httpStatusCode < 600;
    }
}