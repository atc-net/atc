using System.Net;
using Xunit;

namespace Atc.Tests.Extensions
{
    public class HttpStatusCodeExtensionsTests
    {
        [Theory]
        [InlineData("Accepted", HttpStatusCode.Accepted)]
        [InlineData("Ok", HttpStatusCode.OK)]
        [InlineData("ImUsed", HttpStatusCode.IMUsed)]
        public void ToNormalizedString(string expected, HttpStatusCode httpStatusCode)
            => Assert.Equal(expected, httpStatusCode.ToNormalizedString());
    }
}