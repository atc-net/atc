using System.ComponentModel.DataAnnotations;
using McMaster.Extensions.CommandLineUtils;

namespace Atc.Rest.ApiGenerator.CLI.Commands.Options
{
    public abstract class BaseCommandOptions
    {
        [Option("--verboseMode", "Use verboseMode for more debug/trace information", CommandOptionType.SingleValue, ShortName = "v")]
        public string? VerboseMode { get; set; }

        [Required]
        [Option("--specificationPath", "Path to Open API specification (directory, file, url)", CommandOptionType.SingleValue, ShortName = "s")]
        public string? SpecificationPath { get; set; }
    }
}