namespace Atc.Tests.Extensions;

[Trait(Traits.Category, Traits.Categories.Integration)]
[Trait(Traits.Category, Traits.Categories.SkipWhenLiveUnitTesting)]
public class X509Certificate2ExtensionsTests
{
    [Fact]
    [SupportedOSPlatform("windows")]
    public void GetNameIdentifier_WithFriendlyName()
    {
        // Arrange
        using var certificate = CreateTestCertificate("CN=Test Subject");
        certificate.FriendlyName = "MyFriendlyName";

        // Act
        var actual = certificate.GetNameIdentifier();

        // Assert
        Assert.Equal("MyFriendlyName", actual);
    }

    [Fact]
    public void GetNameIdentifier_WithoutFriendlyName()
    {
        // Arrange
        using var certificate = CreateTestCertificate("CN=Test Subject");

        // Act
        var actual = certificate.GetNameIdentifier();

        // Assert
        Assert.StartsWith("Test Subject", actual, StringComparison.Ordinal);
    }

    [Fact]
    public void IsValid_WithValidCertificate()
    {
        // Arrange
        using var certificate = CreateTestCertificate("CN=Test Subject");

        // Act
        var actual = certificate.IsValid();

        // Assert
        Assert.True(actual);
    }

    private static X509Certificate2 CreateTestCertificate(string subjectName)
    {
        using var rsa = RSA.Create(2048);
        var request = new CertificateRequest(
            subjectName,
            rsa,
            HashAlgorithmName.SHA256,
            RSASignaturePadding.Pkcs1);

        var certificate = request.CreateSelfSigned(
            DateTimeOffset.Now.AddDays(-1),
            DateTimeOffset.Now.AddDays(365));

        return certificate;
    }
}