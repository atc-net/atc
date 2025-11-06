namespace Atc.Tests.Extensions;

public class HttpStatusCodeExtensionsTests
{
    [Theory]
    [InlineData("Accepted", HttpStatusCode.Accepted)]
    [InlineData("Ok", HttpStatusCode.OK)]
    [InlineData("ImUsed", HttpStatusCode.IMUsed)]
    public void ToNormalizedString(
        string expected,
        HttpStatusCode httpStatusCode)
        => Assert.Equal(expected, httpStatusCode.ToNormalizedString());

    [Theory]
    [InlineData(HttpStatusCode.Continue, "Status100Continue")]
    [InlineData(HttpStatusCode.SwitchingProtocols, "Status101SwitchingProtocols")]
    [InlineData(HttpStatusCode.Processing, "Status102Processing")]
    [InlineData(HttpStatusCode.OK, "Status200OK")]
    [InlineData(HttpStatusCode.Created, "Status201Created")]
    [InlineData(HttpStatusCode.Accepted, "Status202Accepted")]
    [InlineData(HttpStatusCode.NonAuthoritativeInformation, "Status203NonAuthoritative")]
    [InlineData(HttpStatusCode.NoContent, "Status204NoContent")]
    [InlineData(HttpStatusCode.ResetContent, "Status205ResetContent")]
    [InlineData(HttpStatusCode.PartialContent, "Status206PartialContent")]
    [InlineData(HttpStatusCode.MultiStatus, "Status207MultiStatus")]
    [InlineData(HttpStatusCode.AlreadyReported, "Status208AlreadyReported")]
    [InlineData(HttpStatusCode.IMUsed, "Status226IMUsed")]
    [InlineData(HttpStatusCode.MultipleChoices, "Status300MultipleChoices")]
    [InlineData(HttpStatusCode.MovedPermanently, "Status301MovedPermanently")]
    [InlineData(HttpStatusCode.Found, "Status302Found")]
    [InlineData(HttpStatusCode.SeeOther, "Status303SeeOther")]
    [InlineData(HttpStatusCode.NotModified, "Status304NotModified")]
    [InlineData(HttpStatusCode.UseProxy, "Status305UseProxy")]
    [InlineData(HttpStatusCode.Unused, "Status306SwitchProxy")]
    [InlineData(HttpStatusCode.TemporaryRedirect, "Status307TemporaryRedirect")]
    [InlineData(HttpStatusCode.PermanentRedirect, "Status308PermanentRedirect")]
    [InlineData(HttpStatusCode.BadRequest, "Status400BadRequest")]
    [InlineData(HttpStatusCode.Unauthorized, "Status401Unauthorized")]
    [InlineData(HttpStatusCode.PaymentRequired, "Status402PaymentRequired")]
    [InlineData(HttpStatusCode.Forbidden, "Status403Forbidden")]
    [InlineData(HttpStatusCode.NotFound, "Status404NotFound")]
    [InlineData(HttpStatusCode.MethodNotAllowed, "Status405MethodNotAllowed")]
    [InlineData(HttpStatusCode.NotAcceptable, "Status406NotAcceptable")]
    [InlineData(HttpStatusCode.ProxyAuthenticationRequired, "Status407ProxyAuthenticationRequired")]
    [InlineData(HttpStatusCode.RequestTimeout, "Status408RequestTimeout")]
    [InlineData(HttpStatusCode.Conflict, "Status409Conflict")]
    [InlineData(HttpStatusCode.Gone, "Status410Gone")]
    [InlineData(HttpStatusCode.LengthRequired, "Status411LengthRequired")]
    [InlineData(HttpStatusCode.PreconditionFailed, "Status412PreconditionFailed")]
    [InlineData(HttpStatusCode.RequestEntityTooLarge, "Status413RequestEntityTooLarge")]
    [InlineData(HttpStatusCode.RequestUriTooLong, "Status414RequestUriTooLong")]
    [InlineData(HttpStatusCode.UnsupportedMediaType, "Status415UnsupportedMediaType")]
    [InlineData(HttpStatusCode.RequestedRangeNotSatisfiable, "Status416RequestedRangeNotSatisfiable")]
    [InlineData(HttpStatusCode.ExpectationFailed, "Status417ExpectationFailed")]
    [InlineData(HttpStatusCode.MisdirectedRequest, "Status421MisdirectedRequest")]
    [InlineData(HttpStatusCode.UnprocessableEntity, "Status422UnprocessableEntity")]
    [InlineData(HttpStatusCode.Locked, "Status423Locked")]
    [InlineData(HttpStatusCode.FailedDependency, "Status424FailedDependency")]
    [InlineData(HttpStatusCode.UpgradeRequired, "Status426UpgradeRequired")]
    [InlineData(HttpStatusCode.PreconditionRequired, "Status428PreconditionRequired")]
    [InlineData(HttpStatusCode.TooManyRequests, "Status429TooManyRequests")]
    [InlineData(HttpStatusCode.RequestHeaderFieldsTooLarge, "Status431RequestHeaderFieldsTooLarge")]
    [InlineData(HttpStatusCode.UnavailableForLegalReasons, "Status451UnavailableForLegalReasons")]
    [InlineData(HttpStatusCode.InternalServerError, "Status500InternalServerError")]
    [InlineData(HttpStatusCode.NotImplemented, "Status501NotImplemented")]
    [InlineData(HttpStatusCode.BadGateway, "Status502BadGateway")]
    [InlineData(HttpStatusCode.ServiceUnavailable, "Status503ServiceUnavailable")]
    [InlineData(HttpStatusCode.GatewayTimeout, "Status504GatewayTimeout")]
    [InlineData(HttpStatusCode.HttpVersionNotSupported, "Status505HttpVersionNotsupported")]
    [InlineData(HttpStatusCode.VariantAlsoNegotiates, "Status506VariantAlsoNegotiates")]
    [InlineData(HttpStatusCode.InsufficientStorage, "Status507InsufficientStorage")]
    [InlineData(HttpStatusCode.LoopDetected, "Status508LoopDetected")]
    [InlineData(HttpStatusCode.NotExtended, "Status510NotExtended")]
    [InlineData(HttpStatusCode.NetworkAuthenticationRequired, "Status511NetworkAuthenticationRequired")]
    public void ToStatusCodesConstant(
        HttpStatusCode httpStatusCode,
        string expected)
        => Assert.Equal(expected, httpStatusCode.ToStatusCodesConstant());

    [Theory]
    [InlineData(true, HttpStatusCode.Continue)]
    [InlineData(false, HttpStatusCode.OK)]
    [InlineData(false, HttpStatusCode.Ambiguous)]
    [InlineData(false, HttpStatusCode.BadRequest)]
    [InlineData(false, HttpStatusCode.InternalServerError)]
    public void IsInformational(
        bool expected,
        HttpStatusCode httpStatusCode)
        => Assert.Equal(expected, httpStatusCode.IsInformational());

    [Theory]
    [InlineData(false, HttpStatusCode.Continue)]
    [InlineData(true, HttpStatusCode.OK)]
    [InlineData(false, HttpStatusCode.Ambiguous)]
    [InlineData(false, HttpStatusCode.BadRequest)]
    [InlineData(false, HttpStatusCode.InternalServerError)]
    public void IsSuccessful(
        bool expected,
        HttpStatusCode httpStatusCode)
        => Assert.Equal(expected, httpStatusCode.IsSuccessful());

    [Theory]
    [InlineData(false, HttpStatusCode.Continue)]
    [InlineData(false, HttpStatusCode.OK)]
    [InlineData(true, HttpStatusCode.Ambiguous)]
    [InlineData(false, HttpStatusCode.BadRequest)]
    [InlineData(false, HttpStatusCode.InternalServerError)]
    public void IsRedirect(
        bool expected,
        HttpStatusCode httpStatusCode)
        => Assert.Equal(expected, httpStatusCode.IsRedirect());

    [Theory]
    [InlineData(false, HttpStatusCode.Continue)]
    [InlineData(false, HttpStatusCode.OK)]
    [InlineData(false, HttpStatusCode.Ambiguous)]
    [InlineData(true, HttpStatusCode.BadRequest)]
    [InlineData(false, HttpStatusCode.InternalServerError)]
    public void IsClientError(
        bool expected,
        HttpStatusCode httpStatusCode)
        => Assert.Equal(expected, httpStatusCode.IsClientError());

    [Theory]
    [InlineData(false, HttpStatusCode.Continue)]
    [InlineData(false, HttpStatusCode.OK)]
    [InlineData(false, HttpStatusCode.Ambiguous)]
    [InlineData(false, HttpStatusCode.BadRequest)]
    [InlineData(true, HttpStatusCode.InternalServerError)]
    public void IsServerError(
        bool expected,
        HttpStatusCode httpStatusCode)
        => Assert.Equal(expected, httpStatusCode.IsServerError());

    [Theory]
    [InlineData(false, HttpStatusCode.Continue)]
    [InlineData(false, HttpStatusCode.OK)]
    [InlineData(false, HttpStatusCode.Ambiguous)]
    [InlineData(true, HttpStatusCode.BadRequest)]
    [InlineData(true, HttpStatusCode.InternalServerError)]
    public void IsClientOrServerError(
        bool expected,
        HttpStatusCode httpStatusCode)
        => Assert.Equal(expected, httpStatusCode.IsClientOrServerError());
}