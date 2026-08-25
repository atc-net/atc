namespace Atc.DotNet.Tests;

/// <summary>
/// The SDK of a project file was resolved through <c>XElement.FirstAttribute</c>, which is only
/// the <c>Sdk</c> attribute when it happens to be written first. Any attribute placed ahead of it
/// - including an <c>xmlns</c> declaration, which LINQ to XML also exposes as an attribute -
/// made the whole project type detection fall through to <see cref="DotnetProjectType.None"/>.
/// </summary>
public class DotnetCsProjFileHelperSdkAttributeTests
{
    [Theory]
    [InlineData(DotnetProjectType.ConsoleApp, "<Project Sdk=\"Microsoft.NET.Sdk\">")]
    [InlineData(DotnetProjectType.ConsoleApp, "<Project ToolsVersion=\"15.0\" Sdk=\"Microsoft.NET.Sdk\">")]
    [InlineData(DotnetProjectType.ConsoleApp, "<Project xmlns=\"http://schemas.microsoft.com/developer/msbuild/2003\" Sdk=\"Microsoft.NET.Sdk\">")]
    public void GetProjectType_FileContent_ResolvesSdk_RegardlessOfAttributeOrder(
        DotnetProjectType expected,
        string projectStartElement)
    {
        // Arrange
        var fileContent = $"""
            {projectStartElement}
              <PropertyGroup>
                <OutputType>Exe</OutputType>
                <TargetFramework>net9.0</TargetFramework>
              </PropertyGroup>
            </Project>
            """;

        // Atc
        var actual = DotnetCsProjFileHelper.GetProjectType(fileContent);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(DotnetProjectType.WebApi, "Microsoft.NET.Sdk.Web", "Swashbuckle.AspNetCore")]
    [InlineData(DotnetProjectType.XUnitTest, "Microsoft.NET.Sdk", "xunit")]
    public void GetProjectType_FileContent_ResolvesSdk_WhenNamespaceIsDeclaredBeforeSdkAttribute(
        DotnetProjectType expected,
        string sdk,
        string packageReference)
    {
        // Arrange
        var fileContent = $"""
            <Project xmlns="http://schemas.microsoft.com/developer/msbuild/2003" Sdk="{sdk}">
              <PropertyGroup>
                <TargetFramework>net9.0</TargetFramework>
              </PropertyGroup>
              <ItemGroup>
                <PackageReference Include="{packageReference}" Version="1.2.3" />
              </ItemGroup>
            </Project>
            """;

        // Atc
        var actual = DotnetCsProjFileHelper.GetProjectType(fileContent);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(DotnetProjectType.AspireAppHost, "Aspire.AppHost.Sdk/9.0.0")]
    [InlineData(DotnetProjectType.RazorLibrary, "Microsoft.NET.Sdk.Razor")]
    [InlineData(DotnetProjectType.WorkerService, "Microsoft.NET.Sdk.Worker")]
    public void GetProjectType_FileContent_ResolvesWellKnownSdk_WhenAnotherAttributeComesFirst(
        DotnetProjectType expected,
        string sdk)
    {
        // Arrange
        var fileContent = $"""
            <Project ToolsVersion="15.0" Sdk="{sdk}">
              <PropertyGroup>
                <TargetFramework>net9.0</TargetFramework>
              </PropertyGroup>
            </Project>
            """;

        // Atc
        var actual = DotnetCsProjFileHelper.GetProjectType(fileContent);

        // Assert
        Assert.Equal(expected, actual);
    }
}