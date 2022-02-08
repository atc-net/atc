namespace Atc.Tests.Extensions;

public class HttpStatusCodeExtensionsTests
{
    [Theory]
    [InlineData("Accepted", HttpStatusCode.Accepted)]
    [InlineData("Ok", HttpStatusCode.OK)]
    [InlineData("ImUsed", HttpStatusCode.IMUsed)]
    public void ToNormalizedString(string expected, HttpStatusCode httpStatusCode)
        => Assert.Equal(expected, httpStatusCode.ToNormalizedString());

    [Theory]
    [InlineData(true, HttpStatusCode.Continue)]
    [InlineData(false, HttpStatusCode.OK)]
    [InlineData(false, HttpStatusCode.Ambiguous)]
    [InlineData(false, HttpStatusCode.BadRequest)]
    [InlineData(false, HttpStatusCode.InternalServerError)]
    public void IsInformational(bool expected, HttpStatusCode httpStatusCode)
        => Assert.Equal(expected, httpStatusCode.IsInformational());

    [Theory]
    [InlineData(false, HttpStatusCode.Continue)]
    [InlineData(true, HttpStatusCode.OK)]
    [InlineData(false, HttpStatusCode.Ambiguous)]
    [InlineData(false, HttpStatusCode.BadRequest)]
    [InlineData(false, HttpStatusCode.InternalServerError)]
    public void IsSuccessful(bool expected, HttpStatusCode httpStatusCode)
        => Assert.Equal(expected, httpStatusCode.IsSuccessful());

    [Theory]
    [InlineData(false, HttpStatusCode.Continue)]
    [InlineData(false, HttpStatusCode.OK)]
    [InlineData(true, HttpStatusCode.Ambiguous)]
    [InlineData(false, HttpStatusCode.BadRequest)]
    [InlineData(false, HttpStatusCode.InternalServerError)]
    public void IsRedirect(bool expected, HttpStatusCode httpStatusCode)
        => Assert.Equal(expected, httpStatusCode.IsRedirect());

    [Theory]
    [InlineData(false, HttpStatusCode.Continue)]
    [InlineData(false, HttpStatusCode.OK)]
    [InlineData(false, HttpStatusCode.Ambiguous)]
    [InlineData(true, HttpStatusCode.BadRequest)]
    [InlineData(false, HttpStatusCode.InternalServerError)]
    public void IsClientError(bool expected, HttpStatusCode httpStatusCode)
        => Assert.Equal(expected, httpStatusCode.IsClientError());

    [Theory]
    [InlineData(false, HttpStatusCode.Continue)]
    [InlineData(false, HttpStatusCode.OK)]
    [InlineData(false, HttpStatusCode.Ambiguous)]
    [InlineData(false, HttpStatusCode.BadRequest)]
    [InlineData(true, HttpStatusCode.InternalServerError)]
    public void IsServerError(bool expected, HttpStatusCode httpStatusCode)
        => Assert.Equal(expected, httpStatusCode.IsServerError());

    [Theory]
    [InlineData(false, HttpStatusCode.Continue)]
    [InlineData(false, HttpStatusCode.OK)]
    [InlineData(false, HttpStatusCode.Ambiguous)]
    [InlineData(true, HttpStatusCode.BadRequest)]
    [InlineData(true, HttpStatusCode.InternalServerError)]
    public void IsClientOrServerError(bool expected, HttpStatusCode httpStatusCode)
        => Assert.Equal(expected, httpStatusCode.IsClientOrServerError());
}