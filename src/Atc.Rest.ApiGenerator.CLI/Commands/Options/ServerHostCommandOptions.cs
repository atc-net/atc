using System.ComponentModel.DataAnnotations;
using McMaster.Extensions.CommandLineUtils;

namespace Atc.Rest.ApiGenerator.CLI.Commands.Options
{
    public class ServerHostCommandOptions : BaseGenerateCommandOptions
    {
        [Required]
        [Option("--apiPath", "Path to api project.", CommandOptionType.SingleValue)]
        public string? ApiPath { get; set; }

        [Required]
        [Option("--domainPath", "Path to domain project.", CommandOptionType.SingleValue)]
        public string? DomainPath { get; set; }
    }
}