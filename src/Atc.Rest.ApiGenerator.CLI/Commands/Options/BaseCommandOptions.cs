using System.ComponentModel.DataAnnotations;
using McMaster.Extensions.CommandLineUtils;

namespace Atc.Rest.ApiGenerator.CLI.Commands.Options
{
    public abstract class BaseCommandOptions
    {
        [Required]
        [Option("--specificationPath", "Path to Open API specification (directory, file, url)", CommandOptionType.SingleValue)]
        public string? SpecificationPath { get; set; }
    }
}