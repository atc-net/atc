// ReSharper disable once CheckNamespace
namespace Atc.DotNet;

[Flags]
[SuppressMessage("StyleCop.CSharp.SpacingRules", "SA1025:Code should not contain multiple whitespace in a row", Justification = "OK.")]
public enum DotnetProjectType
{
    // Default
    None                  = 0x00000,

    // Apps
    AzureFunctionApp      = 0x000001,
    AndroidApp            = 0x000002,
    ConsoleApp            = 0x000004,
    CliApp                = 0x000008,
    BlazorServerApp       = 0x000010,
    BlazorWAsmApp         = 0x000020,
    IosApp                = 0x000040,
    UwpApp                = 0x000080,
    WebApp                = 0x000100,
    WpfApp                = 0x000200,
    WinFormApp            = 0x000400,

    // Libraries
    Library               = 0x000800,
    RazorLibrary          = 0x001000,
    UwpLibrary            = 0x002000,
    WpfLibrary            = 0x004000,

    // Modules
    AzureIotEdgeModule    = 0x008000,

    // Extensions
    VisualStudioExtension = 0x010000,

    // Services
    WebApi = 0x020000,
    WorkerService         = 0x040000,

    // Tests
    BUnitTest             = 0x080000,
    MsTest                = 0x100000,
    NUnitTest             = 0x200000,
    XUnitTest             = 0x400000,

    // Combined
    Apps = AzureFunctionApp | AndroidApp | ConsoleApp | CliApp | BlazorServerApp | BlazorWAsmApp | IosApp | UwpApp | WebApp | WpfApp | WinFormApp,
    Modules = AzureIotEdgeModule,
    Libraries = Library | RazorLibrary | UwpLibrary | WpfLibrary,
    Services = WorkerService | WebApi,
    Tests = BUnitTest | MsTest | NUnitTest | XUnitTest,
}