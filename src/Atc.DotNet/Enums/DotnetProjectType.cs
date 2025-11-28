// ReSharper disable once CheckNamespace
namespace Atc.DotNet;

/// <summary>
/// Defines the types of .NET projects.
/// This enum uses flags to allow combining multiple project types.
/// </summary>
[Flags]
[SuppressMessage("StyleCop.CSharp.SpacingRules", "SA1025:Code should not contain multiple whitespace in a row", Justification = "OK.")]
public enum DotnetProjectType
{
    // Default
    None                  = 0x0000000,

    // Apps
    AzureFunctionApp      = 0x0000001,
    AndroidApp            = 0x0000002,
    ConsoleApp            = 0x0000004,
    CliApp                = 0x0000008,
    BlazorServerApp       = 0x0000010,
    BlazorWAsmApp         = 0x0000020,
    MauiApp               = 0x0000040,
    IosApp                = 0x0000080,
    UwpApp                = 0x0000100,
    WebApp                = 0x0000200,
    WpfApp                = 0x0000400,
    WinFormApp            = 0x0000800,

    // Libraries
    Library               = 0x0001000,
    RazorLibrary          = 0x0002000,
    UwpLibrary            = 0x0004000,
    WpfLibrary            = 0x0008000,

    // Modules
    AzureIotEdgeModule    = 0x0010000,

    // Extensions
    VisualStudioExtension = 0x0020000,

    // Services
    WebApi                = 0x0040000,
    WorkerService         = 0x0080000,
    AspireAppHost         = 0x0100000,
    AspireServiceDefaults = 0x0200000,

    // Tests
    BUnitTest             = 0x0400000,
    MsTest                = 0x0800000,
    NUnitTest             = 0x1000000,
    XUnitTest             = 0x2000000,

    // Combined
    Apps = AzureFunctionApp | AndroidApp | ConsoleApp | CliApp | BlazorServerApp | BlazorWAsmApp | MauiApp | IosApp | UwpApp | WebApp | WpfApp | WinFormApp,
    Modules = AzureIotEdgeModule,
    Libraries = Library | RazorLibrary | UwpLibrary | WpfLibrary,
    Aspire = AspireAppHost | AspireServiceDefaults,
    Services = WorkerService | WebApi,
    Tests = BUnitTest | MsTest | NUnitTest | XUnitTest,
}