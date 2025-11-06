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
    None                  = 0x00000,

    // Apps
    AzureFunctionApp      = 0x000001,
    AndroidApp            = 0x000002,
    ConsoleApp            = 0x000004,
    CliApp                = 0x000008,
    BlazorServerApp       = 0x000010,
    BlazorWAsmApp         = 0x000020,
    MauiApp               = 0x000040,
    IosApp                = 0x000080,
    UwpApp                = 0x000100,
    WebApp                = 0x000200,
    WpfApp                = 0x000400,
    WinFormApp            = 0x000800,

    // Libraries
    Library               = 0x001000,
    RazorLibrary          = 0x002000,
    UwpLibrary            = 0x004000,
    WpfLibrary            = 0x008000,

    // Modules
    AzureIotEdgeModule    = 0x010000,

    // Extensions
    VisualStudioExtension = 0x020000,

    // Services
    WebApi                = 0x040000,
    WorkerService         = 0x080000,

    // Tests
    BUnitTest             = 0x100000,
    MsTest                = 0x200000,
    NUnitTest             = 0x400000,
    XUnitTest             = 0x800000,

    // Combined
    Apps = AzureFunctionApp | AndroidApp | ConsoleApp | CliApp | BlazorServerApp | BlazorWAsmApp | MauiApp | IosApp | UwpApp | WebApp | WpfApp | WinFormApp,
    Modules = AzureIotEdgeModule,
    Libraries = Library | RazorLibrary | UwpLibrary | WpfLibrary,
    Services = WorkerService | WebApi,
    Tests = BUnitTest | MsTest | NUnitTest | XUnitTest,
}